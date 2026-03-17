using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AIInfluence.API;
using AIInfluence.Behaviors.AIActions;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using AIInfluence.Behaviors.RolePlay;
using AIInfluence.Diplomacy;
using AIInfluence.Diseases;
using AIInfluence.DynamicEvents;
using AIInfluence.Patches.Diseases;
using AIInfluence.Services;
using AIInfluence.SettlementCombat;
using AIInfluence.UI;
using AIInfluence.Util;
using Helpers;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;
using KillCharacterAction = TaleWorlds.CampaignSystem.Actions.KillCharacterAction;

namespace AIInfluence;

public class AIInfluenceBehavior : CampaignBehaviorBase
{
	private readonly string _logFilePath;

	private readonly string _saveDataPath;

	private string _currentSaveFolder;

	private string _npcContextsJson;

	private Dictionary<string, NPCContext> _npcContexts = new Dictionary<string, NPCContext>();

	private Dictionary<string, string> _stringIdToContextKey = new Dictionary<string, string>();

	private Dictionary<string, string> _npcFilePathCache = new Dictionary<string, string>();

	private readonly Random _random = new Random();

	private readonly AIDecisionHandler _decisionHandler;

	private readonly SettlementCombatHandler _settlementCombatHandler;

	private SettlementCombatManager _settlementCombatManager;

	private bool _isInitialized = false;

	private CampaignTime _lastDialogueAnalysisTime = CampaignTime.Never;

	private static AIInfluenceBehavior _instance;

	private static bool _settingsSubscribed;

	private static AIInfluenceBehavior _settingsOwner;

	private readonly DelayedTaskManager _delayedTaskManager;

	private readonly SaveQueueManager _saveQueueManager;

	private WorldInfoManager _worldInfoManager;

	private static int _hourlyTickCounter;

	private NPCInitiativeSystem _npcInitiativeSystem;

	private List<string> _followingHeroIds = new List<string>();

	private string _serializedActionState = string.Empty;

	private string _lastKnownPlayerStringId;

	private bool _playerReinforcementAdded = false;

	private const string WelcomeMarkerFileName = "welcome_popup_shown.txt";

	private static readonly Regex StreamingResponseFieldRegex = new Regex("\"response\"\\s*:\\s*\"(?<text>(?:\\\\.|[^\"\\\\])*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

	private bool _welcomeCheckedThisSession = false;

	public static AIInfluenceBehavior Instance => _instance;

	public NPCInitiativeSystem InitiativeSystem => _npcInitiativeSystem;

	public static void ResetStaticFlags()
	{
		try
		{
			if (_settingsSubscribed && GlobalSettings<ModSettings>.Instance != null && _settingsOwner != null)
			{
				GlobalSettings<ModSettings>.Instance.OnSettingChanged -= _settingsOwner.OnSettingChanged;
			}
		}
		catch
		{
		}
		_settingsSubscribed = false;
		_settingsOwner = null;
		AIActionManager.ResetInstance();
	}

	~AIInfluenceBehavior()
	{
		try
		{
			if (GlobalSettings<ModSettings>.Instance != null)
			{
				GlobalSettings<ModSettings>.Instance.OnSettingChanged -= OnSettingChanged;
			}
		}
		catch
		{
		}
		finally
		{
		}
	}

	public NPCInitiativeSystem GetNPCInitiativeSystem()
	{
		return _npcInitiativeSystem;
	}

	public AIInfluenceBehavior()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_logFilePath = Path.Combine(fullName, "logs", "mod_log.txt");
		_saveDataPath = Path.Combine(fullName, "save_data");
		_decisionHandler = new AIDecisionHandler(this);
		_settlementCombatHandler = new SettlementCombatHandler(this);
		_settlementCombatManager = new SettlementCombatManager(this);
		_instance = this;
		_delayedTaskManager = new DelayedTaskManager(this);
		_saveQueueManager = new SaveQueueManager(this);
		DialogManager.Initialize(this);
		if (!_settingsSubscribed)
		{
			GlobalSettings<ModSettings>.Instance.OnSettingChanged -= OnSettingChanged;
			GlobalSettings<ModSettings>.Instance.OnSettingChanged += OnSettingChanged;
			_settingsSubscribed = true;
			_settingsOwner = this;
			LogMessage($"[SYSTEM] Subscribed to settings events for instance {base.GetHashCode()}");
		}
		else
		{
			LogMessage("[SYSTEM] Settings events already subscribed globally - skipping to prevent double subscription");
		}
		_worldInfoManager = WorldInfoManager.Instance;
	}

	public void LogMessage(string message)
	{
		bool isAlwaysLog = !string.IsNullOrEmpty(message) && (message.StartsWith("[ERROR]") || message.StartsWith("[SYNC-TRACE]"));
		if (!isAlwaysLog && (!_isInitialized || !(GlobalSettings<ModSettings>.Instance?.EnableDebugLogging ?? false)))
		{
			return;
		}
		try
		{
			string directoryName = Path.GetDirectoryName(_logFilePath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			File.AppendAllText(_logFilePath, $"[{DateTime.Now:HH:mm:ss.fff}] {message}{Environment.NewLine}");
		}
		catch (Exception)
		{
		}
	}

	public Dictionary<string, NPCContext> GetNPCContexts()
	{
		return _npcContexts;
	}

	public async Task<string> SendAIRequest(string prompt, string requestType)
	{
		try
		{
			LogMessage("[SEND_AI_REQUEST] Отправляем запрос типа '" + requestType + "' к ИИ");
			LogMessage($"[SEND_AI_REQUEST] Длина промта: {prompt.Length} символов");
			string response = ((!(requestType == "multi_dialogue_analysis")) ? (await AIClient.GetAIResponse("System", "Analysis", prompt)) : (await AIClient.GetRawTextResponse(prompt)));
			LogMessage($"[SEND_AI_REQUEST] Получен ответ от ИИ для '{requestType}': {response?.Length ?? 0} символов");
			if (!string.IsNullOrEmpty(response) && !response.StartsWith("Error:"))
			{
				LogMessage("[SEND_AI_REQUEST_SUCCESS] Успешный ответ для " + requestType);
				LogMessage("[SEND_AI_REQUEST_FULL_RESPONSE] Полный ответ: " + response);
				return response;
			}
			LogMessage("[SEND_AI_REQUEST_ERROR] Ошибка ИИ для " + requestType + ": " + response);
			return null;
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			LogMessage("[SEND_AI_REQUEST_EXCEPTION] Исключение для " + requestType + ": " + ex2.Message);
			return "Error: " + ex2.Message;
		}
	}

	public async Task<string> SendAIRequestWithBackend(string prompt, string requestType, string backend, int cachePrefixLength = 0)
	{
		try
		{
			LogMessage("[SEND_AI_REQUEST] Отправляем запрос типа '" + requestType + "' к ИИ backend '" + backend + "'");
			LogMessage(string.Format("[SEND_AI_REQUEST] Длина промта: {0} символов{1}", prompt.Length, (cachePrefixLength > 0) ? $", кэш-префикс: {cachePrefixLength}" : ""));
			string response = await AIClient.GetRawTextResponseWithBackend(prompt, backend, cachePrefixLength);
			LogMessage($"[SEND_AI_REQUEST] Получен ответ от ИИ для '{requestType}': {response?.Length ?? 0} символов");
			if (string.IsNullOrEmpty(response))
			{
				string error = "Error: Empty response from backend '" + backend + "'";
				LogMessage("[SEND_AI_REQUEST_ERROR] " + error + " для " + requestType);
				return error + " for " + requestType;
			}
			if (response.StartsWith("Error:"))
			{
				LogMessage("[SEND_AI_REQUEST_ERROR] Ошибка ИИ для " + requestType + ": " + response);
				return response;
			}
			LogMessage("[SEND_AI_REQUEST_SUCCESS] Успешный ответ для " + requestType);
			LogMessage("[SEND_AI_REQUEST_FULL_RESPONSE] Полный ответ: " + response);
			return response;
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			LogMessage("[SEND_AI_REQUEST_EXCEPTION] Исключение для " + requestType + ": " + ex2.Message);
			return null;
		}
	}

	public async Task<string> SendAIRequestRaw(string prompt)
	{
		try
		{
			LogMessage("[SEND_AI_REQUEST_RAW] Отправляем сырой запрос к ИИ");
			LogMessage($"[SEND_AI_REQUEST_RAW] Длина промта: {prompt.Length} символов");
			string response = await AIClient.GetRawTextResponse(prompt);
			LogMessage($"[SEND_AI_REQUEST_RAW] Получен ответ от ИИ: {response?.Length ?? 0} символов");
			if (string.IsNullOrEmpty(response))
			{
				LogMessage("[SEND_AI_REQUEST_RAW_ERROR] Error: Empty response from backend");
				return "Error: Empty response from backend";
			}
			if (response.StartsWith("Error:"))
			{
				LogMessage("[SEND_AI_REQUEST_RAW_ERROR] Ошибка ИИ: " + response);
				return response;
			}
			LogMessage("[SEND_AI_REQUEST_RAW_SUCCESS] Успешный ответ");
			return response;
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			LogMessage("[SEND_AI_REQUEST_RAW_EXCEPTION] Исключение: " + ex2.Message);
			return "Error: " + ex2.Message;
		}
	}

	public NPCContext GetNPCContextByStringId(string stringId)
	{
		NPCContext value3;
		if (_stringIdToContextKey.TryGetValue(stringId, out var value))
		{
			if (_npcContexts.TryGetValue(value, out var value2))
			{
				return value2;
			}
			NPCContext nPCContext = LoadNPCContext(stringId);
			if (nPCContext != null && !string.IsNullOrEmpty(nPCContext.StringId))
			{
				_npcContexts[value] = nPCContext;
				if (nPCContext.StringId != value)
				{
					_npcContexts[nPCContext.StringId] = nPCContext;
				}
				return nPCContext;
			}
			_stringIdToContextKey.Remove(stringId);
			LogMessage("[DEBUG] GetNPCContextByStringId: Failed to reload context for '" + stringId + "', removed from index");
		}
		else if (_npcContexts.TryGetValue(stringId, out value3))
		{
			UpdateStringIdIndex(stringId, stringId);
			return value3;
		}
		return null;
	}

	public Hero GetHeroById(string stringId)
	{
		if (string.IsNullOrEmpty(stringId))
		{
			return null;
		}
		return Campaign.Current.CampaignObjectManager.Find<Hero>(stringId);
	}

	private void UpdateStringIdIndex(string npcId, string stringId)
	{
		_stringIdToContextKey[stringId] = npcId;
	}

	public DelayedTaskManager GetDelayedTaskManager()
	{
		return _delayedTaskManager;
	}

	public WorldInfoManager GetWorldInfoManager()
	{
		return _worldInfoManager;
	}

	public SettlementCombatManager GetSettlementCombatManager()
	{
		return _settlementCombatManager;
	}

	public override void RegisterEvents()
	{
		CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener((object)this, (Action<CampaignGameStarter>)OnSessionLaunched);
		CampaignEvents.TickEvent.AddNonSerializedListener((object)this, (Action<float>)delegate(float dt)
		{
			OnTick(dt);
		});
		CampaignEvents.DailyTickEvent.AddNonSerializedListener((object)this, (Action)OnDailyTick);
		CampaignEvents.HourlyTickEvent.AddNonSerializedListener((object)this, (Action)OnHourlyTick);
		CampaignEvents.RulingClanChanged.AddNonSerializedListener((object)this, (Action<Kingdom, Clan>)OnRulingClanChanged);
		CampaignEvents.SettlementEntered.AddNonSerializedListener((object)this, (Action<MobileParty, Settlement, Hero>)OnSettlementEntered);
		CampaignEvents.OnSettlementLeftEvent.AddNonSerializedListener((object)this, (Action<MobileParty, Settlement>)OnSettlementLeft);
		CampaignEvents.OnMissionEndedEvent.AddNonSerializedListener((object)this, (Action<IMission>)OnMissionEnded);
		CampaignEvents.MapEventStarted.AddNonSerializedListener((object)this, (Action<MapEvent, PartyBase, PartyBase>)OnMapEventStartedForDisease);
		CampaignEvents.MapEventEnded.AddNonSerializedListener((object)this, (Action<MapEvent>)OnMapEventEndedForDisease);
		CampaignEvents.HeroPrisonerTaken.AddNonSerializedListener((object)this, (Action<PartyBase, Hero>)OnHeroPrisonerTaken);
		CampaignEvents.HeroPrisonerReleased.AddNonSerializedListener((object)this, (Action<Hero, PartyBase, IFaction, EndCaptivityDetail, bool>)OnHeroPrisonerReleased);
		CampaignEvents.MobilePartyDestroyed.AddNonSerializedListener((object)this, (Action<MobileParty, PartyBase>)OnMobilePartyDestroyed);
		CampaignEvents.HeroKilledEvent.AddNonSerializedListener((object)this, (Action<Hero, Hero, KillCharacterActionDetail, bool>)OnHeroKilled);
		CampaignEvents.NewCompanionAdded.AddNonSerializedListener((object)this, (Action<Hero>)OnNewCompanionAdded);
		CampaignEvents.OnPartyJoinedArmyEvent.AddNonSerializedListener((object)this, (Action<MobileParty>)OnPartyJoinedArmy);
		CampaignEvents.OnClanChangedKingdomEvent.AddNonSerializedListener((object)this, (Action<Clan, Kingdom, Kingdom, ChangeKingdomActionDetail, bool>)OnClanChangedKingdom);
		RegisterMarriageEvent();
		WorldInfoManager.Instance.RegisterEvents();
		SettlementOwnershipTracker.Instance.RegisterEvents();
		KingdomLeadershipTracker.Instance.RegisterEvents();
		InitializationManager.Instance.InitializeDiplomacyInitializer();
	}

	private void OnMissionEnded(IMission mission)
	{
		try
		{
			_playerReinforcementAdded = false;
		}
		catch (Exception ex)
		{
			LogMessage("[PLAYER_REINFORCEMENT] ERROR in OnMissionEnded: " + ex.Message);
		}
	}

	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomActionDetail detail, bool showNotification)
	{
		try
		{
			if (clan == null || clan.Heroes == null)
			{
				return;
			}
			foreach (Hero item in (List<Hero>)(object)clan.Heroes)
			{
				if (item != null && !string.IsNullOrEmpty(((MBObjectBase)item).StringId))
				{
					InvalidateCachesForNPC(((MBObjectBase)item).StringId);
				}
			}
			LogMessage(string.Format("[CACHE] Invalidated caches for {0} heroes from clan {1} (kingdom change: {2} → {3})", ((List<Hero>)(object)clan.Heroes).Count, clan.Name, ((oldKingdom == null) ? null : ((object)oldKingdom.Name)?.ToString()) ?? "none", ((newKingdom == null) ? null : ((object)newKingdom.Name)?.ToString()) ?? "none"));
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnClanChangedKingdom: " + ex.Message);
		}
	}

	private void RegisterMarriageEvent()
	{
		try
		{
			PropertyInfo property = typeof(CampaignEvents).GetProperty("BeforeHeroesMarried", BindingFlags.Static | BindingFlags.Public);
			if (property != null)
			{
				object value = property.GetValue(null);
				MethodInfo methodInfo = value?.GetType().GetMethod("AddNonSerializedListener");
				if (methodInfo != null)
				{
					Type typeFromHandle = typeof(Action<Hero, Hero, bool>);
					Delegate obj = Delegate.CreateDelegate(typeFromHandle, this, "OnHeroesMarried");
					methodInfo.Invoke(value, new object[2] { this, obj });
					LogMessage("[DEBUG] Registered BeforeHeroesMarried event");
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Failed to register BeforeHeroesMarried event: " + ex.Message);
		}
	}

	private void OnHeroesMarried(Hero hero1, Hero hero2, bool showNotification)
	{
		try
		{
			if (hero1 != null && hero2 != null)
			{
				NPCRelationsCache.Instance.InvalidateCacheWithRelated(((MBObjectBase)hero1).StringId);
				NPCRelationsCache.Instance.InvalidateCacheWithRelated(((MBObjectBase)hero2).StringId);
				_npcFilePathCache.Remove(((MBObjectBase)hero1).StringId);
				_npcFilePathCache.Remove(((MBObjectBase)hero2).StringId);
				LogMessage($"[CACHE] Invalidated caches for married heroes: {hero1.Name} and {hero2.Name}");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnHeroesMarried: " + ex.Message);
		}
	}

	public void InitializeNPCInitiativeSystem()
	{
		if (_npcInitiativeSystem == null)
		{
			_npcInitiativeSystem = new NPCInitiativeSystem(this);
			LogMessage("[SYSTEM] NPC Initiative System initialized.");
		}
	}

	public void Tick(float dt)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		_delayedTaskManager.Tick(dt);
		_saveQueueManager.Tick(dt);
		DiseaseManager.Instance?.TickInMission(dt);
		if (_npcInitiativeSystem != null)
		{
			_npcInitiativeSystem.Tick(dt);
		}
		Action result;
		while (TtsLipSyncService.MainThreadQueue.TryDequeue(out result))
		{
			try
			{
				result();
			}
			catch (Exception ex)
			{
				LogMessage("[LipSync] MainThread action error: " + ex.Message);
			}
		}
	}

	public static void CheckAndEnforcePlayer2Backend()
	{
	}

	private async void OnTick(float dt)
	{
		_delayedTaskManager.Tick(dt);
		_worldInfoManager?.Tick(dt);
		_saveQueueManager?.Tick(dt);
		DiseaseManager.Instance?.TickDiseaseQueue();
		AIActionIntegration.Instance.Update(dt);
	}

	private void OnDailyTick()
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		try
		{
			DynamicEventsManager.Instance?.OnDailyTick();
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] DynamicEventsManager OnDailyTick error: " + ex.Message);
		}
		if (_npcInitiativeSystem != null)
		{
			try
			{
				_npcInitiativeSystem.OnDailyTick();
			}
			catch (Exception ex2)
			{
				LogMessage("[ERROR] NPCInitiativeSystem OnDailyTick error: " + ex2.Message);
			}
		}
		try
		{
			CreateKingdomLeadersContexts();
		}
		catch (Exception ex3)
		{
			LogMessage("[ERROR] CreateKingdomLeadersContexts OnDailyTick error: " + ex3.Message);
		}
		try
		{
			RPItemManager.Instance?.OnDailyTick();
		}
		catch (Exception ex4)
		{
			LogMessage("[ERROR] RPItemManager OnDailyTick error: " + ex4.Message);
		}
	}

	private void CheckPlayerCharacterChanged()
	{
		try
		{
			if (Hero.MainHero != null)
			{
				string stringId = ((MBObjectBase)Hero.MainHero).StringId;
				if (!string.IsNullOrEmpty(_lastKnownPlayerStringId) && _lastKnownPlayerStringId != stringId)
				{
					OnPlayerCharacterChanged(_lastKnownPlayerStringId, stringId);
				}
				_lastKnownPlayerStringId = stringId;
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] CheckPlayerCharacterChanged: " + ex.Message);
		}
	}

	private void OnPlayerCharacterChanged(string oldPlayerStringId, string newPlayerStringId)
	{
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		Hero mainHero = Hero.MainHero;
		string text = ((mainHero == null) ? null : ((object)mainHero.Name)?.ToString()) ?? "Unknown";
		Hero val = ((IEnumerable<Hero>)Hero.DeadOrDisabledHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == oldPlayerStringId)) ?? Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == oldPlayerStringId));
		string text2 = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? oldPlayerStringId;
		LogMessage("[PLAYER_CHANGE] Player character changed: " + text2 + " (" + oldPlayerStringId + ") → " + text + " (" + newPlayerStringId + ")");
		RemoveNPCContextForNewPlayer(newPlayerStringId);
		int num = 0;
		List<string> list = _npcContexts.Keys.ToList();
		foreach (string item in list)
		{
			if (_npcContexts.TryGetValue(item, out var context))
			{
				RenamePlayerInConversationHistory(context, text2);
				RefreshPlayerInfoInContext(context, mainHero);
				context.IsPlayerKnown = false;
				context.PlayerInfo.ClaimedName = null;
				context.PlayerInfo.ClaimedClan = null;
				context.PlayerInfo.ClaimedAge = 0;
				context.PlayerInfo.ClaimedGold = 0;
				context.PlayerInfo.SuspectedLie = false;
				Hero val2 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == context.StringId));
				if (val2 != null)
				{
					SaveNPCContext(context.StringId, val2, context);
				}
				num++;
			}
		}
		LogMessage($"[PLAYER_CHANGE] Updated {num} NPC contexts. Old player conversations attributed to \"{text2}\".");
		InformationManager.DisplayMessage(new InformationMessage("[AIInfluence] Player character changed to " + text + ". NPC memories updated.", Color.FromUint(4293307392u)));
	}

	private void RemoveNPCContextForNewPlayer(string newPlayerStringId)
	{
		bool flag = false;
		List<string> list = (from kvp in _npcContexts
			where kvp.Value.StringId == newPlayerStringId || kvp.Key == newPlayerStringId
			select kvp.Key).ToList();
		foreach (string item in list)
		{
			_npcContexts.Remove(item);
			flag = true;
		}
		if (_stringIdToContextKey.ContainsKey(newPlayerStringId))
		{
			_stringIdToContextKey.Remove(newPlayerStringId);
		}
		_npcFilePathCache.Remove(newPlayerStringId);
		string nPCFilePath = GetNPCFilePath(newPlayerStringId);
		if (!string.IsNullOrEmpty(nPCFilePath) && File.Exists(nPCFilePath))
		{
			try
			{
				File.Delete(nPCFilePath);
				LogMessage("[PLAYER_CHANGE] Deleted NPC context file for new player: " + nPCFilePath);
			}
			catch (Exception ex)
			{
				LogMessage("[PLAYER_CHANGE] Failed to delete NPC context file: " + ex.Message);
			}
		}
		if (flag)
		{
			LogMessage("[PLAYER_CHANGE] Removed NPC context for new player character (StringId: " + newPlayerStringId + ")");
		}
		else
		{
			LogMessage("[PLAYER_CHANGE] No existing NPC context found for new player character (StringId: " + newPlayerStringId + ")");
		}
	}

	private void RenamePlayerInConversationHistory(NPCContext context, string oldHeroName)
	{
		if (context.ConversationHistory == null || context.ConversationHistory.Count == 0)
		{
			return;
		}
		for (int i = 0; i < context.ConversationHistory.Count; i++)
		{
			string text = context.ConversationHistory[i];
			if (text != null && text.StartsWith("Player: "))
			{
				context.ConversationHistory[i] = oldHeroName + ": " + text.Substring("Player: ".Length);
			}
			else if (text != null && text.StartsWith("Player ("))
			{
				context.ConversationHistory[i] = text.Replace("Player (", oldHeroName + " (");
			}
		}
	}

	private void RefreshPlayerInfoInContext(NPCContext context, Hero mainHero)
	{
		if (context.PlayerInfo == null)
		{
			context.PlayerInfo = new PlayerInfo();
		}
		if (mainHero != null)
		{
			context.PlayerInfo.RealName = ((object)mainHero.Name)?.ToString() ?? "Unknown";
			PlayerInfo playerInfo = context.PlayerInfo;
			Clan clan = mainHero.Clan;
			playerInfo.RealClan = ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "No clan";
			context.PlayerInfo.RealAge = (int)mainHero.Age;
			PlayerInfo playerInfo2 = context.PlayerInfo;
			CultureObject culture = mainHero.Culture;
			playerInfo2.RealCulture = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown culture";
			context.PlayerInfo.RealGender = (mainHero.IsFemale ? "female" : "male");
			context.PlayerInfo.PlayerStringId = ((MBObjectBase)mainHero).StringId ?? "";
			Clan clan2 = mainHero.Clan;
			if (((clan2 != null) ? clan2.Kingdom : null) != null)
			{
				context.PlayerInfo.RealKingdom = ((object)mainHero.Clan.Kingdom.Name).ToString();
				context.PlayerInfo.RealKingdomId = ((MBObjectBase)mainHero.Clan.Kingdom).StringId ?? "";
				context.PlayerInfo.IsMercenary = mainHero.Clan.IsUnderMercenaryService;
			}
			else
			{
				context.PlayerInfo.RealKingdom = null;
				context.PlayerInfo.RealKingdomId = null;
				context.PlayerInfo.IsMercenary = false;
			}
		}
	}

	private void OnHourlyTick()
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		CheckPlayerCharacterChanged();
		if (_npcInitiativeSystem != null)
		{
			_npcInitiativeSystem.OnHourlyTick();
		}
		TryShowWelcomePopupForCurrentCampaign();
		if (GlobalSettings<ModSettings>.Instance.EnableNearbyNPCInitialization)
		{
			_hourlyTickCounter++;
			if (_hourlyTickCounter >= 2)
			{
				_hourlyTickCounter = 0;
				InitializeNearbyNPCs();
			}
		}
		try
		{
			DiseaseManager.Instance?.OnHourlyTick();
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] DiseaseManager OnHourlyTick error: " + ex.Message);
		}
		CheckSpawnedQuestPartiesGone();
	}

	private void CheckSpawnedQuestPartiesGone()
	{
		try
		{
			IEnumerable<QuestBase> quests = Campaign.Current?.QuestManager?.Quests;
			if (quests == null)
			{
				return;
			}
			foreach (QuestBase q in quests.ToList())
			{
				if (q is AIGeneratedQuest aiQuest && q.IsOngoing && !string.IsNullOrEmpty(aiQuest.SpawnedPartyId))
				{
					var allParties = MobileParty.All;
					if (allParties == null || !allParties.Any((MobileParty p) => ((MBObjectBase)p).StringId == aiQuest.SpawnedPartyId))
					{
						HandleSpawnedQuestPartyDefeated(aiQuest.SpawnedPartyId);
					}
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] CheckSpawnedQuestPartiesGone: " + ex.Message);
		}
	}

	private void InitializeNearbyNPCs()
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		try
		{
			LogMessage("[DEBUG] Starting periodic NPC initialization check...");
			MobileParty partyBelongedTo = Hero.MainHero.PartyBelongedTo;
			if (partyBelongedTo == null)
			{
				LogMessage("[DEBUG] Player party is null, skipping NPC initialization.");
				return;
			}
			List<Hero> list = ((IEnumerable<Hero>)Hero.AllAliveHeroes).ToList();
			Dictionary<string, NPCContext> nPCContexts = GetNPCContexts();
			if (nPCContexts == null)
			{
				LogMessage("[DEBUG] NPC contexts is null, skipping initialization.");
				return;
			}
			int num = 0;
			int num2 = 0;
			foreach (Hero item in list)
			{
				if (item == Hero.MainHero || nPCContexts.ContainsKey(((MBObjectBase)item).StringId))
				{
					continue;
				}
				bool flag = item.Clan != null && item.Clan == Clan.PlayerClan;
				MobileParty partyBelongedTo2 = item.PartyBelongedTo;
				if (partyBelongedTo2 == null)
				{
					continue;
				}
				Vec2 position2D = partyBelongedTo.GetPosition2D();
				float num3 = (position2D).Distance(partyBelongedTo2.GetPosition2D());
				if (!flag && num3 > 30f)
				{
					continue;
				}
				num2++;
				string arg = (flag ? "clan member" : $"distance: {num3:F1}");
				LogMessage($"[DEBUG] Initializing nearby NPC: {item.Name} ({arg})");
				NPCContext orCreateNPCContext = GetOrCreateNPCContext(item);
				if (orCreateNPCContext != null)
				{
					if (orCreateNPCContext.InteractionCount == 0)
					{
						orCreateNPCContext.InteractionCount = 1;
						LogMessage($"[DEBUG] Marked nearby NPC {item.Name} as initialized (InteractionCount set to 1)");
					}
					if (!orCreateNPCContext.KnowledgeGenerated)
					{
						WorldInfoManager.WorldSecretsManager.Instance.CheckSecretKnowledge(item, orCreateNPCContext);
						WorldInfoManager.InformationManager.Instance.CheckInfoKnowledge(item, orCreateNPCContext);
						orCreateNPCContext.KnowledgeGenerated = true;
					}
					SaveNPCContext(((MBObjectBase)item).StringId, item, orCreateNPCContext);
					num++;
				}
			}
			LogMessage($"[DEBUG] Periodic NPC initialization completed: {num}/{num2} NPCs initialized.");
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Failed to initialize nearby NPCs: " + ex.Message);
		}
	}

	private void OnAgentJoinedConversation(IAgent agent)
	{
		try
		{
			if (agent == null || agent.Character == null)
			{
				return;
			}
			BasicCharacterObject character = agent.Character;
			CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
			if (val != null && ((BasicCharacterObject)val).IsHero)
			{
				LogMessage($"[SYSTEM] OnAgentJoinedConversation: {((BasicCharacterObject)val).Name}");
				if (_npcInitiativeSystem != null)
				{
					_npcInitiativeSystem.OnConversationStarted(new List<CharacterObject> { val });
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Error in OnAgentJoinedConversation: " + ex.Message);
		}
	}

	public void ApplyRelationChangeWithDelay(Hero npc, int relationChange, Color color, string message)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		_delayedTaskManager.AddTask(4.0, delegate
		{
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			if (npc == null || Hero.MainHero == null)
			{
				LogMessage("[ERROR] Invalid NPC or player for relation change.");
			}
			else
			{
				int relation = npc.GetRelation(Hero.MainHero);
				bool flag = true;
				string arg = "";
				if (relationChange > 0 && relation >= 100)
				{
					flag = false;
					arg = " (already at maximum)";
				}
				else if (relationChange < 0 && relation <= -100)
				{
					flag = false;
					arg = " (already at minimum)";
				}
				if (!flag)
				{
					LogMessage($"[DEBUG] Relation change {relationChange} had no effect - relations stayed at {relation}{arg}.");
				}
				else
				{
					ChangeRelationAction.ApplyPlayerRelation(npc, relationChange, false, true);
					int relation2 = npc.GetRelation(Hero.MainHero);
					if (relation != relation2 && !string.IsNullOrEmpty(message))
					{
						InformationManager.DisplayMessage(new InformationMessage(message, color));
						LogMessage($"[DEBUG] Relation changed from {relation} to {relation2} by {relationChange} (actual change: {relation2 - relation}). Displayed message: {message}");
					}
					else if (relation != relation2)
					{
						LogMessage($"[DEBUG] Relation changed from {relation} to {relation2} by {relationChange} (actual change: {relation2 - relation}).");
					}
					else
					{
						LogMessage($"[DEBUG] Relation change {relationChange} had no effect - relations stayed at {relation} (no change applied).");
					}
				}
			}
		});
	}

	public void ProcessQuestAction(Hero npc, NPCContext context, QuestActionData questAction)
	{
		string text = ((npc == null) ? null : ((object)npc.Name)?.ToString()) ?? "Unknown";
		string text2 = questAction.Action?.ToLower() ?? "";
		LogMessage("[QUEST] Processing quest action '" + text2 + "' for " + text);
		try
		{
			switch (text2)
			{
			case "create_quest":
				ProcessCreateQuest(npc, context, questAction);
				break;
			case "complete_quest":
				ProcessCompleteQuest(npc, context, questAction);
				break;
			case "fail_quest":
				ProcessFailQuest(npc, context, questAction);
				break;
			case "update_quest":
				ProcessUpdateQuest(npc, context, questAction);
				break;
			default:
				LogMessage("[QUEST] Unknown quest action: " + text2);
				break;
			}
		}
		catch (Exception ex)
		{
			LogMessage("[QUEST] Error processing quest action '" + text2 + "' for " + text + ": " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void ProcessCreateQuest(Hero npc, NPCContext context, QuestActionData questAction)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		string text = ((npc == null) ? null : ((object)npc.Name)?.ToString()) ?? "Unknown";
		if (string.IsNullOrEmpty(questAction.Title) || string.IsNullOrEmpty(questAction.Description))
		{
			LogMessage("[QUEST] Quest from " + text + " has no title or description, ignoring");
			return;
		}
		int num = Math.Max(0, Math.Min(questAction.RewardGold, 50000));
		int num2 = Math.Max(7, Math.Min(questAction.DurationDays, 120));
		List<string> effectiveTargetNpcIds = questAction.GetEffectiveTargetNpcIds();
		string text2 = questAction.CompleterNpcId ?? "";
		string text3 = questAction.AIVerificationNotes ?? "";
		int valueOrDefault = questAction.ProgressTarget.GetValueOrDefault();
		string text4 = questAction.ProgressLabel ?? "";
		string stringId = ((MBObjectBase)npc).StringId;
		CampaignTime now = CampaignTime.Now;
		string text5 = $"ai_quest_{stringId}_{(int)(now).ToDays}_{_random.Next(1000)}";
		CampaignTime duration = CampaignTime.DaysFromNow((float)num2);
		AIGeneratedQuest aIGeneratedQuest = new AIGeneratedQuest(text5, npc, duration, num, questAction.Title, questAction.Description, effectiveTargetNpcIds, text3, text2, valueOrDefault, text4);
		if (context.ActiveAIQuests == null)
		{
			context.ActiveAIQuests = new List<AIQuestInfo>();
		}
		AIQuestInfo obj = new AIQuestInfo
		{
			QuestId = text5,
			Title = questAction.Title,
			Description = questAction.Description,
			RewardGold = num
		};
		now = CampaignTime.Now;
		obj.CreatedDays = (now).ToDays;
		obj.DurationDays = num2;
		obj.QuestGiverNpcId = ((MBObjectBase)npc).StringId;
		obj.TargetNpcId = ((effectiveTargetNpcIds.Count > 0) ? effectiveTargetNpcIds[0] : null);
		obj.TargetNpcIds = effectiveTargetNpcIds;
		obj.AIVerificationNotes = text3;
		obj.CompleterNpcId = text2;
		obj.ProgressTarget = valueOrDefault;
		obj.ProgressLabel = text4;
		obj.RewardItems = questAction.RewardItems ?? new List<QuestItemReward>();
		obj.RewardSkill = questAction.RewardSkill ?? "";
		obj.RewardSkillXp = Math.Max(0, Math.Min(questAction.RewardSkillXp, 10000));
		obj.CrimeRatingChange = questAction.CrimeRatingChange.HasValue
			? (int?)Math.Max(-100, Math.Min(questAction.CrimeRatingChange.Value, 100))
			: null;
		obj.InfluenceChange = questAction.InfluenceChange.HasValue
			? (int?)Math.Max(-200, Math.Min(questAction.InfluenceChange.Value, 200))
			: null;
		AIQuestInfo item = obj;
		context.ActiveAIQuests.Add(item);
		SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		foreach (string targetNpcId in effectiveTargetNpcIds)
		{
			if (string.IsNullOrEmpty(targetNpcId))
			{
				continue;
			}
			try
			{
				Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == targetNpcId));
				if (val != null)
				{
					((QuestBase)aIGeneratedQuest).AddTrackedObject((ITrackableCampaignObject)(object)val);
					EnsureQuestTargetContextFileExists(targetNpcId, val);
					NPCContext nPCContext = LoadNPCContext(targetNpcId);
					if (nPCContext != null)
					{
						if (nPCContext.IncomingAIQuests == null)
						{
							nPCContext.IncomingAIQuests = new List<AIQuestInfo>();
						}
						nPCContext.IncomingAIQuests.Add(item);
						if (string.IsNullOrEmpty(nPCContext.Name) || nPCContext.Name == "Unknown_NPC")
						{
							nPCContext.Name = ((object)val.Name)?.ToString() ?? "Unknown_NPC";
						}
						if (string.IsNullOrEmpty(nPCContext.StringId))
						{
							nPCContext.StringId = targetNpcId;
						}
						_npcContexts[targetNpcId] = nPCContext;
						UpdateStringIdIndex(targetNpcId, targetNpcId);
						SaveNPCContext(targetNpcId, val, nPCContext);
						LogMessage($"[QUEST] Added incoming quest '{questAction.Title}' to target NPC {val.Name} ({targetNpcId})");
					}
				}
				else
				{
					LogMessage("[QUEST] Target NPC with ID '" + targetNpcId + "' not found");
				}
			}
			catch (Exception ex)
			{
				LogMessage("[QUEST] Error adding quest to target NPC '" + targetNpcId + "': " + ex.Message);
			}
		}
		SpawnNpcData spawnData = questAction.SpawnNpc;
		if (spawnData == null && questAction.SpawnHostileParty)
		{
			spawnData = new SpawnNpcData
			{
				Alignment = "hostile",
				PartyName = string.IsNullOrEmpty(questAction.HostilePartyLabel) ? "Quest Enemies" : questAction.HostilePartyLabel,
                PartySize = Math.Max(5, Math.Min(questAction.HostilePartySize, 1500)),
				PartyTroops = string.IsNullOrEmpty(questAction.HostileTroopName) ? null : new List<string> { questAction.HostileTroopName },
				Settlement = npc?.CurrentSettlement != null ? ((object)npc.CurrentSettlement.Name)?.ToString() : null
			};
		}
		if (spawnData != null)
		{
			var spawnService = new NpcSpawnService(LogMessage);
			var spawnResult = spawnService.Spawn(spawnData);
			if (spawnResult.Success && spawnResult.Party != null)
			{
				string partyStringId = ((MBObjectBase)spawnResult.Party).StringId;
				item.SpawnedPartyId = partyStringId;
				item.SpawnedPartyDefeatMeansFailure = !string.Equals(spawnData.Alignment, "hostile", StringComparison.OrdinalIgnoreCase);
				spawnResult.Party.SetPartyUsedByQuest(true);
				if (string.Equals(spawnData.Alignment, "hostile", StringComparison.OrdinalIgnoreCase))
				{
					string partyName = spawnData.PartyName ?? (spawnResult.Party.Name?.ToString()) ?? "a party";
					string spawnLocation = !string.IsNullOrEmpty(spawnData.Settlement)
						? spawnData.Settlement
						: (npc?.PartyBelongedTo != null ? ((npc.Name)?.ToString() ?? "the quest giver") : "the player");
					string addNote = "A hostile party '" + partyName + "' (id:" + item.SpawnedPartyId + ") was spawned near " + spawnLocation + ". The quest is complete when this party is destroyed.";
					item.AIVerificationNotes = string.IsNullOrEmpty(item.AIVerificationNotes) ? addNote : item.AIVerificationNotes + " " + addNote;
				}
				QuestBase questBase2 = Campaign.Current?.QuestManager?.Quests?.FirstOrDefault((Func<QuestBase, bool>)((QuestBase q) => ((MBObjectBase)q).StringId == item.QuestId && q.IsOngoing));
				if (questBase2 is AIGeneratedQuest aiGenQuest)
				{
					aiGenQuest.SpawnedPartyId = partyStringId;
				}
				questBase2?.AddTrackedObject((ITrackableCampaignObject)(object)spawnResult.Party);
				InformationManager.DisplayMessage(new InformationMessage($"A party has appeared on the map!", ExtraColors.RedAIInfluence));
			}
			if (spawnResult.Success && spawnResult.Hero != null)
			{
            NPCContext spawnedContext = GetOrCreateNPCContext(spawnResult.Hero);
            if (spawnedContext != null)
                SaveNPCContext(((MBObjectBase)spawnResult.Hero).StringId, spawnResult.Hero, spawnedContext);
			}
			else if (spawnResult.Error != null)
			{
				LogMessage("[QUEST] spawn_npc failed: " + spawnResult.Error);
			}
			SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		}
		LogMessage(string.Format("[QUEST] Created quest '{0}' (ID: {1}) from {2}, reward: {3}, duration: {4} days, targets: [{5}]", questAction.Title, text5, text, num, num2, string.Join(", ", effectiveTargetNpcIds)) + ((!string.IsNullOrEmpty(text2)) ? (", completer: " + text2) : "") + ((valueOrDefault > 0) ? $", progress: 0/{valueOrDefault} ({text4})" : ""));
	}

	private void ApplyQuestItemRewards(AIQuestInfo questInfo)
	{
		if (questInfo.RewardItems == null || questInfo.RewardItems.Count == 0)
		{
			return;
		}
		foreach (QuestItemReward reward in questInfo.RewardItems)
		{
			if (string.IsNullOrEmpty(reward.ItemName) || reward.Count <= 0)
			{
				continue;
			}
			ItemObject item = ItemMentionParser.FindBestItemMatch(reward.ItemName);
			if (item != null)
			{
				int clampedCount = Math.Max(1, Math.Min(reward.Count, 100));
				MobileParty.MainParty.ItemRoster.AddToCounts(item, clampedCount);
				LogMessage($"[QUEST] Gave {clampedCount}x '{item.Name}' (resolved from '{reward.ItemName}') as quest item reward");
			}
			else
			{
				LogMessage($"[QUEST] Item reward '{reward.ItemName}' could not be resolved to any game item");
			}
		}
	}

	private void ApplyQuestSkillReward(AIQuestInfo questInfo)
	{
		if (string.IsNullOrEmpty(questInfo.RewardSkill) || questInfo.RewardSkillXp <= 0)
		{
			return;
		}
		SkillObject skill = Skills.All?.FirstOrDefault((SkillObject s) => string.Equals(((MBObjectBase)s).StringId, questInfo.RewardSkill, StringComparison.OrdinalIgnoreCase));
		if (skill != null)
		{
			Hero mainHero = Hero.MainHero;
			if (mainHero != null)
			{
				mainHero.AddSkillXp(skill, (float)questInfo.RewardSkillXp);
				LogMessage($"[QUEST] Gave {questInfo.RewardSkillXp} XP in {questInfo.RewardSkill} as quest skill reward");
			}
			else
			{
				LogMessage($"[QUEST] Skill reward skipped — MainHero is null");
			}
		}
		else
		{
			LogMessage($"[QUEST] Skill '{questInfo.RewardSkill}' not found in game skills");
		}
	}

	private void ApplyQuestPoliticalEffects(AIQuestInfo questInfo)
	{
		if (questInfo.CrimeRatingChange.HasValue && questInfo.CrimeRatingChange.Value != 0)
		{
			Kingdom kingdom = Hero.MainHero?.Clan?.Kingdom ?? Hero.MainHero?.MapFaction as Kingdom;
			if (kingdom != null)
			{
				ChangeCrimeRatingAction.Apply(kingdom, (float)questInfo.CrimeRatingChange.Value, true);
				LogMessage($"[QUEST] Crime rating changed by {questInfo.CrimeRatingChange.Value} in {kingdom.Name}");
			}
			else
			{
				LogMessage($"[QUEST] Crime rating change of {questInfo.CrimeRatingChange.Value} skipped — player has no kingdom affiliation");
			}
		}
		if (questInfo.InfluenceChange.HasValue && questInfo.InfluenceChange.Value != 0)
		{
			Clan playerClan = Clan.PlayerClan;
			if (playerClan != null)
			{
				ChangeClanInfluenceAction.Apply(playerClan, (float)questInfo.InfluenceChange.Value);
				LogMessage($"[QUEST] Clan influence changed by {questInfo.InfluenceChange.Value}");
			}
			else
			{
				LogMessage($"[QUEST] Influence change of {questInfo.InfluenceChange.Value} skipped — player clan is null");
			}
		}
	}

	private void CleanupSpawnedQuestParty(AIQuestInfo questInfo)
	{
		if (string.IsNullOrEmpty(questInfo.SpawnedPartyId))
		{
			return;
		}
		try
		{
			MobileParty party = MobileParty.All?.FirstOrDefault((MobileParty p) => ((MBObjectBase)p).StringId == questInfo.SpawnedPartyId);
			if (party != null)
			{
				QuestBase questBase = Campaign.Current?.QuestManager?.Quests?.FirstOrDefault((Func<QuestBase, bool>)((QuestBase q) => ((MBObjectBase)q).StringId == questInfo.QuestId && q.IsOngoing));
				questBase?.RemoveTrackedObject((ITrackableCampaignObject)(object)party);
				party.SetPartyUsedByQuest(false);
				DestroyPartyAction.Apply((PartyBase)null, party);
				LogMessage($"[QUEST] Destroyed spawned party '{questInfo.SpawnedPartyId}' on quest end");
				questInfo.SpawnedPartyId = null;
				if (questBase is AIGeneratedQuest aiQuest)
				{
					aiQuest.SpawnedPartyId = "";
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[QUEST] Error destroying spawned party: " + ex.Message);
		}
	}

	private (AIQuestInfo questInfo, NPCContext context, string npcId)? FindQuestBySpawnedPartyId(string spawnedPartyId)
	{
		if (string.IsNullOrEmpty(spawnedPartyId))
		{
			return null;
		}
		foreach (KeyValuePair<string, NPCContext> kv in _npcContexts.ToList())
		{
			AIQuestInfo q = kv.Value?.ActiveAIQuests?.FirstOrDefault((AIQuestInfo x) => x.SpawnedPartyId == spawnedPartyId);
			if (q != null)
			{
				return (q, kv.Value, kv.Key);
			}
			q = kv.Value?.IncomingAIQuests?.FirstOrDefault((AIQuestInfo x) => x.SpawnedPartyId == spawnedPartyId);
			if (q != null)
			{
				return (q, kv.Value, kv.Key);
			}
		}
		return null;
	}

	private void HandleSpawnedQuestPartyDefeated(string spawnedPartyId)
	{
		var found = FindQuestBySpawnedPartyId(spawnedPartyId);
		if (found == null)
		{
			return;
		}
		AIQuestInfo questInfo = found.Value.questInfo;
		NPCContext context = found.Value.context;
		string npcId = found.Value.npcId;
		Hero npc = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == npcId));
		if (npc == null)
		{
			LogMessage("[QUEST] Cannot handle spawned party defeat: NPC " + npcId + " not found");
			questInfo.SpawnedPartyId = null;
			AIGeneratedQuest orphanedQuest = Campaign.Current?.QuestManager?.Quests?.FirstOrDefault((Func<QuestBase, bool>)((QuestBase q) => ((MBObjectBase)q).StringId == questInfo.QuestId && q.IsOngoing)) as AIGeneratedQuest;
			if (orphanedQuest != null)
			{
				orphanedQuest.SpawnedPartyId = "";
			}
			return;
		}
		string updateLog = "The spawned quest party was destroyed.";
		questInfo.SpawnedPartyId = null;
		int newProgress = Math.Min(questInfo.ProgressCurrent + 1, questInfo.ProgressTarget);
		questInfo.ProgressCurrent = newProgress;
		if (questInfo.UpdateLogs == null)
		{
			questInfo.UpdateLogs = new List<AIQuestUpdateLog>();
		}
		questInfo.UpdateLogs.Add(new AIQuestUpdateLog
		{
			NpcId = "system",
			NpcName = "World",
			Message = updateLog,
			Day = CampaignTime.Now.ToDays,
			ProgressSetTo = newProgress
		});
		AIGeneratedQuest aiQuest = Campaign.Current?.QuestManager?.Quests?.FirstOrDefault((Func<QuestBase, bool>)((QuestBase q) => ((MBObjectBase)q).StringId == questInfo.QuestId && q.IsOngoing)) as AIGeneratedQuest;
		if (aiQuest != null)
		{
			aiQuest.SpawnedPartyId = "";
			aiQuest.AddUpdateLog(updateLog);
			aiQuest.SetDiscreteProgress(newProgress);
		}
		SyncQuestInfoAcrossNpcs(questInfo);
		if (newProgress >= questInfo.ProgressTarget && questInfo.ProgressTarget > 0)
		{
			QuestActionData action = new QuestActionData { QuestId = questInfo.QuestId, CompletionReason = updateLog, SetProgress = newProgress };
			if (questInfo.SpawnedPartyDefeatMeansFailure)
			{
				ProcessFailQuest(npc, context, action);
			}
			else
			{
				ProcessCompleteQuest(npc, context, action);
			}
		}
		else
		{
			SaveNPCContext(npcId, npc, context);
			LogMessage($"[QUEST] Spawned party defeat recorded for '{questInfo.Title}' (progress: {newProgress}/{questInfo.ProgressTarget})");
			InformationManager.DisplayMessage(new InformationMessage("Quest updated: " + questInfo.Title + $" ({newProgress}/{questInfo.ProgressTarget})", ExtraColors.GreenAIInfluence));
		}
	}

	private void ProcessUpdateQuest(Hero npc, NPCContext context, QuestActionData questAction)
	{
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected O, but got Unknown
		string text = ((npc == null) ? null : ((object)npc.Name)?.ToString()) ?? "Unknown";
		string questId = questAction.QuestId;
		if (string.IsNullOrEmpty(questId))
		{
			LogMessage("[QUEST] Cannot update quest: no quest ID for " + text);
			return;
		}
		AIQuestInfo aIQuestInfo = context.ActiveAIQuests?.Find((AIQuestInfo q) => q.QuestId == questId);
		if (aIQuestInfo == null)
		{
			aIQuestInfo = context.IncomingAIQuests?.Find((AIQuestInfo q) => q.QuestId == questId);
		}
		if (aIQuestInfo == null)
		{
			LogMessage("[QUEST] Quest '" + questId + "' not found for update by " + text);
			return;
		}
		string text2 = questAction.UpdateLog ?? "";
		int? setProgress = questAction.SetProgress;
		Campaign current = Campaign.Current;
		object obj;
		if (current == null)
		{
			obj = null;
		}
		else
		{
			QuestManager questManager = current.QuestManager;
			obj = ((questManager == null) ? null : ((IEnumerable<QuestBase>)questManager.Quests)?.FirstOrDefault((Func<QuestBase, bool>)((QuestBase q) => ((MBObjectBase)q).StringId == questId && q.IsOngoing)));
		}
		AIGeneratedQuest aIGeneratedQuest = obj as AIGeneratedQuest;
		if (!string.IsNullOrEmpty(text2))
		{
			aIGeneratedQuest?.AddUpdateLog(text2);
			if (aIQuestInfo.UpdateLogs == null)
			{
				aIQuestInfo.UpdateLogs = new List<AIQuestUpdateLog>();
			}
			List<AIQuestUpdateLog> updateLogs = aIQuestInfo.UpdateLogs;
			AIQuestUpdateLog obj2 = new AIQuestUpdateLog
			{
				NpcId = ((MBObjectBase)npc).StringId,
				NpcName = text,
				Message = text2
			};
			CampaignTime now = CampaignTime.Now;
			obj2.Day = (now).ToDays;
			obj2.ProgressSetTo = setProgress;
			updateLogs.Add(obj2);
		}
		if (setProgress.HasValue && aIQuestInfo.ProgressTarget > 0)
		{
			int num = (aIQuestInfo.ProgressCurrent = Math.Max(0, Math.Min(setProgress.Value, aIQuestInfo.ProgressTarget)));
			aIGeneratedQuest?.SetDiscreteProgress(num);
			LogMessage($"[QUEST] Progress updated to {num}/{aIQuestInfo.ProgressTarget} for '{aIQuestInfo.Title}'");
		}
		RemoveTrackerForNpc(npc, questId);
		SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		SyncQuestInfoAcrossNpcs(aIQuestInfo);
		LogMessage("[QUEST] Quest '" + aIQuestInfo.Title + "' updated by " + text + ((!string.IsNullOrEmpty(text2)) ? (": " + text2) : "") + (setProgress.HasValue ? $" (progress: {aIQuestInfo.ProgressCurrent}/{aIQuestInfo.ProgressTarget})" : ""));
		InformationManager.DisplayMessage(new InformationMessage("Quest updated: " + aIQuestInfo.Title + (setProgress.HasValue ? $" ({aIQuestInfo.ProgressCurrent}/{aIQuestInfo.ProgressTarget})" : ""), ExtraColors.GreenAIInfluence));
	}

	private void ProcessCompleteQuest(Hero npc, NPCContext context, QuestActionData questAction)
	{
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		string text = ((npc == null) ? null : ((object)npc.Name)?.ToString()) ?? "Unknown";
		string questId = questAction.QuestId;
		string text2 = questAction.CompletionReason ?? "";
		if (string.IsNullOrEmpty(questId))
		{
			LogMessage("[QUEST] Cannot complete quest: no quest ID for " + text);
			return;
		}
		AIQuestInfo questInfo = context.ActiveAIQuests?.Find((AIQuestInfo q) => q.QuestId == questId);
		bool flag = false;
		if (questInfo == null)
		{
			questInfo = context.IncomingAIQuests?.Find((AIQuestInfo q) => q.QuestId == questId);
			flag = questInfo != null;
		}
		if (questInfo == null)
		{
			LogMessage("[QUEST] Quest '" + questId + "' not found in active or incoming quests for " + text);
			return;
		}
		string completerNpcId = questInfo.CompleterNpcId;
		if (!string.IsNullOrEmpty(completerNpcId) && !(completerNpcId == ((MBObjectBase)npc).StringId) && !(questInfo.QuestGiverNpcId == ((MBObjectBase)npc).StringId))
		{
			LogMessage("[QUEST] NPC " + text + " is not authorized to complete quest '" + questInfo.Title + "'. Expected completer: " + completerNpcId + ". Treating as update_quest instead.");
			questAction.Action = "update_quest";
			questAction.UpdateLog = text2;
			ProcessUpdateQuest(npc, context, questAction);
			return;
		}
		Campaign current = Campaign.Current;
		object obj;
		if (current == null)
		{
			obj = null;
		}
		else
		{
			QuestManager questManager = current.QuestManager;
			obj = ((questManager == null) ? null : ((IEnumerable<QuestBase>)questManager.Quests)?.FirstOrDefault((Func<QuestBase, bool>)((QuestBase q) => ((MBObjectBase)q).StringId == questId && q.IsOngoing)));
		}
		QuestBase val = (QuestBase)obj;
		if (val != null)
		{
			if (questInfo.ProgressTarget > 0 && val is AIGeneratedQuest aIGeneratedQuest)
			{
				int val2 = questAction.SetProgress ?? questInfo.ProgressTarget;
				int num = Math.Max(0, Math.Min(val2, questInfo.ProgressTarget));
				aIGeneratedQuest.SetDiscreteProgress(num);
				questInfo.ProgressCurrent = num;
			}
			val.CompleteQuestWithSuccess();
			ApplyQuestItemRewards(questInfo);
			ApplyQuestSkillReward(questInfo);
			ApplyQuestPoliticalEffects(questInfo);
			LogMessage("[QUEST] Completed quest '" + questInfo.Title + "' (game object found)");
		}
		else
		{
			if (questInfo.RewardGold > 0)
			{
				GiveGoldAction.ApplyBetweenCharacters((Hero)null, Hero.MainHero, questInfo.RewardGold, false);
			}
			Hero val3 = ((!string.IsNullOrEmpty(questInfo.QuestGiverNpcId)) ? Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == questInfo.QuestGiverNpcId)) : npc);
			if (val3 != null)
			{
				ChangeRelationAction.ApplyPlayerRelation(val3, 5, true, true);
			}
			ApplyQuestItemRewards(questInfo);
			ApplyQuestSkillReward(questInfo);
			ApplyQuestPoliticalEffects(questInfo);
			LogMessage("[QUEST] Completed quest '" + questInfo.Title + "' (manual reward, game object not found)");
			InformationManager.DisplayMessage(new InformationMessage($"Quest completed: {questInfo.Title} (Reward: {questInfo.RewardGold} denars)", ExtraColors.GreenAIInfluence));
		}
		AddQuestToHistory(questInfo, "completed", text2, ((MBObjectBase)npc).StringId);
		context.ActiveAIQuests?.Remove(questInfo);
		context.IncomingAIQuests?.RemoveAll((AIQuestInfo q) => q.QuestId == questId);
		SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		CleanupQuestFromAllNpcs(npc, questInfo);
	}

	private void ProcessFailQuest(Hero npc, NPCContext context, QuestActionData questAction)
	{
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		string text = ((npc == null) ? null : ((object)npc.Name)?.ToString()) ?? "Unknown";
		string questId = questAction.QuestId;
		string reason = questAction.CompletionReason ?? "";
		if (string.IsNullOrEmpty(questId))
		{
			LogMessage("[QUEST] Cannot fail quest: no quest ID for " + text);
			return;
		}
		AIQuestInfo questInfo = context.ActiveAIQuests?.Find((AIQuestInfo q) => q.QuestId == questId);
		bool flag = false;
		if (questInfo == null)
		{
			questInfo = context.IncomingAIQuests?.Find((AIQuestInfo q) => q.QuestId == questId);
			flag = questInfo != null;
		}
		if (questInfo == null)
		{
			LogMessage("[QUEST] Quest '" + questId + "' not found in active or incoming quests for " + text);
			return;
		}
		Campaign current = Campaign.Current;
		object obj;
		if (current == null)
		{
			obj = null;
		}
		else
		{
			QuestManager questManager = current.QuestManager;
			obj = ((questManager == null) ? null : ((IEnumerable<QuestBase>)questManager.Quests)?.FirstOrDefault((Func<QuestBase, bool>)((QuestBase q) => ((MBObjectBase)q).StringId == questId && q.IsOngoing)));
		}
		QuestBase val = (QuestBase)obj;
		if (val != null)
		{
			val.CompleteQuestWithFail(new TextObject("Quest failed: " + questInfo.Title, (Dictionary<string, object>)null));
			LogMessage("[QUEST] Failed quest '" + questInfo.Title + "' (game object found)");
		}
		else
		{
			Hero val2 = ((!string.IsNullOrEmpty(questInfo.QuestGiverNpcId)) ? Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == questInfo.QuestGiverNpcId)) : npc);
			if (val2 != null)
			{
				ChangeRelationAction.ApplyPlayerRelation(val2, -3, true, true);
			}
			LogMessage("[QUEST] Failed quest '" + questInfo.Title + "' (manual penalty, game object not found)");
			InformationManager.DisplayMessage(new InformationMessage("Quest failed: " + questInfo.Title, ExtraColors.RedAIInfluence));
		}
		AddQuestToHistory(questInfo, "failed", reason, ((MBObjectBase)npc).StringId);
		context.ActiveAIQuests?.Remove(questInfo);
		context.IncomingAIQuests?.RemoveAll((AIQuestInfo q) => q.QuestId == questId);
		SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		CleanupQuestFromAllNpcs(npc, questInfo);
	}

	public void HandleQuestTimedOut(string questId, string questTitle, string giverNpcId)
	{
		try
		{
			if (string.IsNullOrEmpty(giverNpcId))
			{
				return;
			}
			NPCContext nPCContext = LoadNPCContext(giverNpcId);
			if (nPCContext == null)
			{
				return;
			}
			AIQuestInfo aIQuestInfo = nPCContext.ActiveAIQuests?.Find((AIQuestInfo q) => q.QuestId == questId);
			if (aIQuestInfo != null)
			{
				AddQuestToHistory(aIQuestInfo, "timed_out", "Player did not complete the quest before the deadline expired.", giverNpcId);
				nPCContext.ActiveAIQuests?.Remove(aIQuestInfo);
				Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == giverNpcId));
				if (val != null)
				{
					SaveNPCContext(giverNpcId, val, nPCContext);
				}
				CleanupQuestFromAllNpcs(null, aIQuestInfo);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[QUEST] Error handling quest timeout for '" + questId + "': " + ex.Message);
		}
	}

	private void AddQuestToHistory(AIQuestInfo questInfo, string outcome, string reason, string completedByNpcId)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string giverNpcId = questInfo.QuestGiverNpcId;
			if (string.IsNullOrEmpty(giverNpcId))
			{
				return;
			}
			NPCContext nPCContext = (_npcContexts.ContainsKey(giverNpcId) ? _npcContexts[giverNpcId] : LoadNPCContext(giverNpcId));
			if (nPCContext != null)
			{
				if (nPCContext.CompletedQuestHistory == null)
				{
					nPCContext.CompletedQuestHistory = new List<AIQuestHistoryEntry>();
				}
				List<AIQuestHistoryEntry> completedQuestHistory = nPCContext.CompletedQuestHistory;
				AIQuestHistoryEntry obj = new AIQuestHistoryEntry
				{
					QuestId = questInfo.QuestId,
					Title = questInfo.Title,
					Outcome = outcome,
					Reason = reason,
					CompletedByNpcId = completedByNpcId
				};
				CampaignTime now = CampaignTime.Now;
				obj.Day = (now).ToDays;
				completedQuestHistory.Add(obj);
				while (nPCContext.CompletedQuestHistory.Count > 3)
				{
					nPCContext.CompletedQuestHistory.RemoveAt(0);
				}
				_npcContexts[giverNpcId] = nPCContext;
				Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == giverNpcId));
				if (val != null)
				{
					SaveNPCContext(giverNpcId, val, nPCContext);
				}
				LogMessage("[QUEST] Added history: '" + questInfo.Title + "' → " + outcome + " (reason: " + reason + ")");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[QUEST] Error adding quest to history: " + ex.Message);
		}
	}

	private void RemoveTrackerForNpc(Hero npc, string questId)
	{
		try
		{
			Campaign current = Campaign.Current;
			object obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				QuestManager questManager = current.QuestManager;
				obj = ((questManager == null) ? null : ((IEnumerable<QuestBase>)questManager.Quests)?.FirstOrDefault((Func<QuestBase, bool>)((QuestBase q) => ((MBObjectBase)q).StringId == questId && q.IsOngoing)));
			}
			QuestBase val = (QuestBase)obj;
			if (val != null && val.IsTracked((ITrackableCampaignObject)(object)npc))
			{
				val.RemoveTrackedObject((ITrackableCampaignObject)(object)npc);
				LogMessage($"[QUEST] Removed map tracker for {npc.Name} on quest '{questId}'");
			}
		}
		catch (Exception ex)
		{
			LogMessage($"[QUEST] Error removing tracker for {((npc != null) ? npc.Name : null)}: {ex.Message}");
		}
	}

	private void SyncQuestInfoAcrossNpcs(AIQuestInfo updatedQuestInfo)
	{
		try
		{
			string questId = updatedQuestInfo.QuestId;
			HashSet<string> hashSet = new HashSet<string>();
			if (!string.IsNullOrEmpty(updatedQuestInfo.QuestGiverNpcId))
			{
				hashSet.Add(updatedQuestInfo.QuestGiverNpcId);
			}
			foreach (string effectiveTargetNpcId in updatedQuestInfo.GetEffectiveTargetNpcIds())
			{
				if (!string.IsNullOrEmpty(effectiveTargetNpcId))
				{
					hashSet.Add(effectiveTargetNpcId);
				}
			}
			foreach (string npcId in hashSet)
			{
				NPCContext nPCContext = (_npcContexts.ContainsKey(npcId) ? _npcContexts[npcId] : LoadNPCContext(npcId));
				if (nPCContext == null)
				{
					continue;
				}
				bool flag = false;
				AIQuestInfo aIQuestInfo = nPCContext.ActiveAIQuests?.Find((AIQuestInfo q) => q.QuestId == questId);
				if (aIQuestInfo != null)
				{
					aIQuestInfo.UpdateLogs = updatedQuestInfo.UpdateLogs;
					aIQuestInfo.ProgressCurrent = updatedQuestInfo.ProgressCurrent;
					aIQuestInfo.SpawnedPartyId = updatedQuestInfo.SpawnedPartyId;
					flag = true;
				}
				AIQuestInfo aIQuestInfo2 = nPCContext.IncomingAIQuests?.Find((AIQuestInfo q) => q.QuestId == questId);
				if (aIQuestInfo2 != null)
				{
					aIQuestInfo2.UpdateLogs = updatedQuestInfo.UpdateLogs;
					aIQuestInfo2.ProgressCurrent = updatedQuestInfo.ProgressCurrent;
					aIQuestInfo2.SpawnedPartyId = updatedQuestInfo.SpawnedPartyId;
					flag = true;
				}
				if (flag)
				{
					Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == npcId));
					if (val != null)
					{
						SaveNPCContext(npcId, val, nPCContext);
					}
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[QUEST] Error syncing quest info across NPCs: " + ex.Message);
		}
	}

	private void CleanupQuestFromAllNpcs(Hero excludeNpc, AIQuestInfo questInfo)
	{
		CleanupSpawnedQuestParty(questInfo);
		try
		{
			HashSet<string> hashSet = new HashSet<string>();
			if (!string.IsNullOrEmpty(questInfo.QuestGiverNpcId))
			{
				hashSet.Add(questInfo.QuestGiverNpcId);
			}
			foreach (string effectiveTargetNpcId in questInfo.GetEffectiveTargetNpcIds())
			{
				if (!string.IsNullOrEmpty(effectiveTargetNpcId))
				{
					hashSet.Add(effectiveTargetNpcId);
				}
			}
			if (excludeNpc != null)
			{
				hashSet.Remove(((MBObjectBase)excludeNpc).StringId);
			}
			foreach (string npcId in hashSet)
			{
				Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == npcId));
				if (val == null)
				{
					continue;
				}
				NPCContext nPCContext = LoadNPCContext(npcId);
				if (nPCContext != null)
				{
					bool flag = false;
					List<AIQuestInfo> activeAIQuests = nPCContext.ActiveAIQuests;
					if (activeAIQuests != null && activeAIQuests.RemoveAll((AIQuestInfo q) => q.QuestId == questInfo.QuestId) > 0)
					{
						flag = true;
					}
					List<AIQuestInfo> incomingAIQuests = nPCContext.IncomingAIQuests;
					if (incomingAIQuests != null && incomingAIQuests.RemoveAll((AIQuestInfo q) => q.QuestId == questInfo.QuestId) > 0)
					{
						flag = true;
					}
					if (flag)
					{
						SaveNPCContext(npcId, val, nPCContext);
						LogMessage($"[QUEST] Cleaned up quest '{questInfo.QuestId}' from {val.Name}'s context");
					}
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[QUEST] Error cleaning up quest from NPCs: " + ex.Message);
		}
	}

	private void FailQuestsForDeadHero(Hero deadHero)
	{
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		if (deadHero == null)
		{
			return;
		}
		try
		{
			Campaign current = Campaign.Current;
			QuestManager val = ((current != null) ? current.QuestManager : null);
			if (((val != null) ? val.Quests : null) == null)
			{
				return;
			}
			string stringId = ((MBObjectBase)deadHero).StringId;
			List<AIGeneratedQuest> list = new List<AIGeneratedQuest>();
			List<QuestBase> list2 = new List<QuestBase>();
			foreach (QuestBase item in (List<QuestBase>)(object)val.Quests)
			{
				if (item is AIGeneratedQuest aIGeneratedQuest && item.IsOngoing)
				{
					if (item.QuestGiver == deadHero || aIGeneratedQuest.NpcStringId == stringId)
					{
						list.Add(aIGeneratedQuest);
					}
					else if (item.IsTracked((ITrackableCampaignObject)(object)deadHero))
					{
						list2.Add(item);
					}
				}
			}
			foreach (AIGeneratedQuest aiQuest in list)
			{
				try
				{
					LogMessage($"[QUEST] Failing quest '{((MBObjectBase)aiQuest).StringId}' — quest giver {deadHero.Name} has died");
					string npcStringId = aiQuest.NpcStringId;
					if (!string.IsNullOrEmpty(npcStringId))
					{
						NPCContext nPCContext = LoadNPCContext(npcStringId);
						if (nPCContext != null)
						{
							AIQuestInfo aIQuestInfo = nPCContext.ActiveAIQuests?.Find((AIQuestInfo q) => q.QuestId == ((MBObjectBase)aiQuest).StringId);
							if (aIQuestInfo != null)
							{
								AddQuestToHistory(aIQuestInfo, "failed", "Quest giver has died.", npcStringId);
								nPCContext.ActiveAIQuests?.Remove(aIQuestInfo);
								SaveNPCContext(npcStringId, deadHero, nPCContext);
								CleanupQuestFromAllNpcs(null, aIQuestInfo);
							}
						}
					}
					((QuestBase)aiQuest).CompleteQuestWithFail(new TextObject("{=AIInfluence_QuestGiverDied}Quest failed: the quest giver has died.", (Dictionary<string, object>)null));
				}
				catch (Exception ex)
				{
					LogMessage("[QUEST] Error failing quest '" + ((MBObjectBase)aiQuest).StringId + "' for dead giver: " + ex.Message);
				}
			}
			foreach (QuestBase item2 in list2)
			{
				try
				{
					item2.RemoveTrackedObject((ITrackableCampaignObject)(object)deadHero);
					LogMessage($"[QUEST] Removed dead hero {deadHero.Name} from tracked objects of quest '{((MBObjectBase)item2).StringId}'");
				}
				catch (Exception ex2)
				{
					LogMessage("[QUEST] Error removing dead hero from quest tracking: " + ex2.Message);
				}
			}
		}
		catch (Exception ex3)
		{
			LogMessage("[QUEST] Error in FailQuestsForDeadHero: " + ex3.Message + "\n" + ex3.StackTrace);
		}
	}

	private void SyncQuestsWithGameState()
	{
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		try
		{
			Campaign current = Campaign.Current;
			QuestManager val = ((current != null) ? current.QuestManager : null);
			if (((val != null) ? val.Quests : null) == null)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			foreach (QuestBase item in ((IEnumerable<QuestBase>)val.Quests).ToList())
			{
				AIGeneratedQuest aiQuest = item as AIGeneratedQuest;
				if (aiQuest == null || !item.IsOngoing)
				{
					continue;
				}
				Hero questGiver = item.QuestGiver;
				if (questGiver != null && !questGiver.IsDead)
				{
					continue;
				}
				try
				{
					string text = ((questGiver == null) ? null : ((object)questGiver.Name)?.ToString()) ?? aiQuest.NpcStringId ?? "Unknown";
					LogMessage("[QUEST_SYNC] Quest '" + ((MBObjectBase)aiQuest).StringId + "' has dead/null giver (" + text + ") — failing on load");
					string text2 = ((questGiver != null) ? ((MBObjectBase)questGiver).StringId : null) ?? aiQuest.NpcStringId;
					if (!string.IsNullOrEmpty(text2))
					{
						NPCContext nPCContext = LoadNPCContext(text2);
						if (nPCContext != null)
						{
							AIQuestInfo aIQuestInfo = nPCContext.ActiveAIQuests?.Find((AIQuestInfo q) => q.QuestId == ((MBObjectBase)aiQuest).StringId);
							if (aIQuestInfo != null)
							{
								AddQuestToHistory(aIQuestInfo, "failed", "Quest giver died or was removed.", text2);
								nPCContext.ActiveAIQuests?.Remove(aIQuestInfo);
								if (questGiver != null)
								{
									SaveNPCContext(text2, questGiver, nPCContext);
								}
								CleanupQuestFromAllNpcs(null, aIQuestInfo);
							}
						}
					}
					((QuestBase)aiQuest).CompleteQuestWithFail(new TextObject("{=AIInfluence_QuestGiverDied}Quest failed: the quest giver has died.", (Dictionary<string, object>)null));
				}
				catch (Exception ex)
				{
					LogMessage("[QUEST_SYNC] Error failing quest with dead giver: " + ex.Message);
				}
			}
			foreach (QuestBase item2 in ((IEnumerable<QuestBase>)val.Quests).ToList())
			{
				if (!(item2 is AIGeneratedQuest aIGeneratedQuest) || !item2.IsOngoing)
				{
					continue;
				}
				string questId = ((MBObjectBase)aIGeneratedQuest).StringId;
				Hero questGiver2 = ((QuestBase)aIGeneratedQuest).QuestGiver;
				string text3 = ((questGiver2 != null) ? ((MBObjectBase)questGiver2).StringId : null) ?? aIGeneratedQuest.NpcStringId;
				if (string.IsNullOrEmpty(text3))
				{
					continue;
				}
				NPCContext nPCContext2 = (_npcContexts.ContainsKey(text3) ? _npcContexts[text3] : LoadNPCContext(text3));
				if (nPCContext2 == null)
				{
					continue;
				}
				List<AIQuestInfo> activeAIQuests = nPCContext2.ActiveAIQuests;
				if (activeAIQuests != null && activeAIQuests.Any((AIQuestInfo q) => q.QuestId == questId))
				{
					continue;
				}
				if (nPCContext2.ActiveAIQuests == null)
				{
					nPCContext2.ActiveAIQuests = new List<AIQuestInfo>();
				}
				AIQuestInfo aIQuestInfo2 = aIGeneratedQuest.ToQuestInfo();
				nPCContext2.ActiveAIQuests.Add(aIQuestInfo2);
				_npcContexts[text3] = nPCContext2;
				if (((QuestBase)aIGeneratedQuest).QuestGiver != null)
				{
					SaveNPCContext(text3, ((QuestBase)aIGeneratedQuest).QuestGiver, nPCContext2);
				}
				num++;
				string title = aIQuestInfo2.Title;
				string arg = questId;
				Hero questGiver3 = ((QuestBase)aIGeneratedQuest).QuestGiver;
				LogMessage($"[QUEST_SYNC] Restored quest '{title}' (ID: {arg}) to {((questGiver3 != null) ? questGiver3.Name : null)}'s context");
				foreach (string targetId in aIGeneratedQuest.TargetNpcIds)
				{
					if (string.IsNullOrEmpty(targetId))
					{
						continue;
					}
					try
					{
						Hero val2 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == targetId));
						if (val2 == null)
						{
							continue;
						}
						NPCContext nPCContext3 = (_npcContexts.ContainsKey(targetId) ? _npcContexts[targetId] : LoadNPCContext(targetId));
						if (nPCContext3 == null)
						{
							continue;
						}
						List<AIQuestInfo> incomingAIQuests = nPCContext3.IncomingAIQuests;
						if (incomingAIQuests == null || !incomingAIQuests.Any((AIQuestInfo q) => q.QuestId == questId))
						{
							if (nPCContext3.IncomingAIQuests == null)
							{
								nPCContext3.IncomingAIQuests = new List<AIQuestInfo>();
							}
							nPCContext3.IncomingAIQuests.Add(aIQuestInfo2);
							_npcContexts[targetId] = nPCContext3;
							SaveNPCContext(targetId, val2, nPCContext3);
							LogMessage($"[QUEST_SYNC] Restored incoming quest '{aIQuestInfo2.Title}' to target {val2.Name}'s context");
						}
					}
					catch (Exception ex2)
					{
						LogMessage("[QUEST_SYNC] Error restoring incoming quest for target '" + targetId + "': " + ex2.Message);
					}
				}
			}
			List<QuestBase> list = ((IEnumerable<QuestBase>)val.Quests)?.Where((QuestBase q) => q is AIGeneratedQuest).ToList() ?? new List<QuestBase>();
			LogMessage($"[QUEST_SYNC] QuestManager contains {list.Count} AIGeneratedQuest(s): " + string.Join(", ", list.Select((QuestBase q) => $"'{((MBObjectBase)q).StringId}' (ongoing={q.IsOngoing})")));
			int num3 = 0;
			foreach (KeyValuePair<string, NPCContext> npcContext in _npcContexts)
			{
				if (npcContext.Value?.ActiveAIQuests != null)
				{
					num3 += npcContext.Value.ActiveAIQuests.Count;
				}
			}
			LogMessage($"[QUEST_SYNC] NPC JSON contexts contain {num3} active AI quest(s) total");
			HashSet<string> completedOrFailedQuestIds = new HashSet<string>(from q in (IEnumerable<QuestBase>)val.Quests
				where q is AIGeneratedQuest && !q.IsOngoing
				select ((MBObjectBase)q).StringId);
			foreach (KeyValuePair<string, NPCContext> item3 in _npcContexts.ToList())
			{
				string npcId = item3.Key;
				NPCContext value = item3.Value;
				if (value == null)
				{
					continue;
				}
				bool flag = false;
				if (value.ActiveAIQuests != null && value.ActiveAIQuests.Count > 0)
				{
					int count = value.ActiveAIQuests.Count;
					value.ActiveAIQuests.RemoveAll((AIQuestInfo q) => completedOrFailedQuestIds.Contains(q.QuestId));
					int num4 = count - value.ActiveAIQuests.Count;
					if (num4 > 0)
					{
						num2 += num4;
						flag = true;
						LogMessage($"[QUEST_SYNC] Removed {num4} completed/failed active quest(s) from {value.Name ?? npcId}'s context");
					}
				}
				if (value.IncomingAIQuests != null && value.IncomingAIQuests.Count > 0)
				{
					int count2 = value.IncomingAIQuests.Count;
					value.IncomingAIQuests.RemoveAll((AIQuestInfo q) => completedOrFailedQuestIds.Contains(q.QuestId));
					int num5 = count2 - value.IncomingAIQuests.Count;
					if (num5 > 0)
					{
						num2 += num5;
						flag = true;
						LogMessage($"[QUEST_SYNC] Removed {num5} completed/failed incoming quest(s) from {value.Name ?? npcId}'s context");
					}
				}
				if (flag)
				{
					Hero val3 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == npcId));
					if (val3 != null)
					{
						SaveNPCContext(npcId, val3, value);
					}
				}
			}
			if (num > 0 || num2 > 0)
			{
				LogMessage($"[QUEST_SYNC] Synchronization complete: {num} quest(s) restored to JSON, {num2} stale quest(s) removed");
			}
			else
			{
				LogMessage("[QUEST_SYNC] All quests are in sync");
			}
		}
		catch (Exception ex3)
		{
			LogMessage("[QUEST_SYNC] Error during quest synchronization: " + ex3.Message + "\n" + ex3.StackTrace);
		}
	}

	private void ProcessWorkshopSale(Hero npc, NPCContext context, string workshopStringId, int agreedPrice)
	{
		if (npc == null || string.IsNullOrEmpty(workshopStringId) || agreedPrice <= 0)
		{
			LogMessage($"[WORKSHOP] Invalid workshop sale parameters: NPC={((npc != null) ? npc.Name : null)}, StringId={workshopStringId}, Price={agreedPrice}");
			return;
		}
		Workshop val = ((IEnumerable<Workshop>)npc.OwnedWorkshops)?.FirstOrDefault((Func<Workshop, bool>)((Workshop w) => ((SettlementArea)w).Tag == workshopStringId));
		if (val == null)
		{
			LogMessage($"[WORKSHOP] Workshop with string_id '{workshopStringId}' not found in {npc.Name}'s owned workshops");
			LogMessage("[WORKSHOP] Available workshops: " + string.Join(", ", ((IEnumerable<Workshop>)npc.OwnedWorkshops)?.Select(delegate(Workshop w)
			{
				string tag = ((SettlementArea)w).Tag;
				WorkshopType workshopType2 = w.WorkshopType;
				return $"{tag} ({((workshopType2 != null) ? workshopType2.Name : null)})";
			}) ?? new List<string>()));
		}
		else
		{
			WorkshopType workshopType = val.WorkshopType;
			string arg = $"{((workshopType != null) ? workshopType.Name : null)} in {((SettlementArea)val).Settlement.Name}";
			LogMessage($"[WORKSHOP] Scheduling workshop sale: {arg} (string_id: {workshopStringId}), agreed price: {agreedPrice}");
			context.PendingWorkshopSale = new PendingWorkshopSale
			{
				WorkshopStringId = workshopStringId,
				AgreedPrice = agreedPrice
			};
		}
	}

	public void ExecutePendingWorkshopSale(Hero npc, NPCContext context)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification || context.PendingWorkshopSale == null)
		{
			return;
		}
		string workshopStringId = context.PendingWorkshopSale.WorkshopStringId;
		int agreedPrice = context.PendingWorkshopSale.AgreedPrice;
		context.PendingWorkshopSale = null;
		_delayedTaskManager.AddTask(2.0, delegate
		{
			//IL_041d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0424: Expected O, but got Unknown
			//IL_042b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0430: Unknown result type (might be due to invalid IL or missing references)
			//IL_043a: Expected O, but got Unknown
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ba: Expected O, but got Unknown
			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Expected O, but got Unknown
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Expected O, but got Unknown
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Expected O, but got Unknown
			Workshop val = ((IEnumerable<Workshop>)npc.OwnedWorkshops)?.FirstOrDefault((Func<Workshop, bool>)((Workshop w) => ((SettlementArea)w).Tag == workshopStringId));
			if (val == null)
			{
				LogMessage("[WORKSHOP] Workshop with string_id '" + workshopStringId + "' disappeared before sale");
			}
			else
			{
				WorkshopType workshopType = val.WorkshopType;
				string text = $"{((workshopType != null) ? workshopType.Name : null)} in {((SettlementArea)val).Settlement.Name}";
				int gold = Hero.MainHero.Gold;
				if (gold >= agreedPrice)
				{
					try
					{
						Type type = typeof(ChangeRelationAction).Assembly.GetType("TaleWorlds.CampaignSystem.Actions.ChangeOwnerOfWorkshopAction");
						if (type != null)
						{
							MethodInfo method = type.GetMethod("ApplyInternal", BindingFlags.Static | BindingFlags.NonPublic);
							if (method != null)
							{
								int initialCapital = Campaign.Current.Models.WorkshopModel.InitialCapital;
								method.Invoke(null, new object[5]
								{
									val,
									Hero.MainHero,
									val.WorkshopType,
									initialCapital,
									agreedPrice
								});
								LogMessage("[WORKSHOP] Successfully used ChangeOwnerOfWorkshopAction.ApplyInternal - money transfer handled automatically");
							}
							else
							{
								LogMessage("[WORKSHOP] ApplyInternal method not found, using fallback");
								val.ChangeOwnerOfWorkshop(Hero.MainHero, val.WorkshopType, Campaign.Current.Models.WorkshopModel.InitialCapital);
								val.UpdateLastRunTime();
								Hero.MainHero.ChangeHeroGold(-agreedPrice);
								npc.ChangeHeroGold(agreedPrice);
								try
								{
									((CampaignEventReceiver)CampaignEventDispatcher.Instance).OnWorkshopOwnerChanged(val, npc);
								}
								catch (Exception ex)
								{
									LogMessage("[WORKSHOP] Failed to trigger OnWorkshopOwnerChanged: " + ex.Message);
								}
							}
						}
						else
						{
							LogMessage("[WORKSHOP] ChangeOwnerOfWorkshopAction class not found, using fallback");
							val.ChangeOwnerOfWorkshop(Hero.MainHero, val.WorkshopType, Campaign.Current.Models.WorkshopModel.InitialCapital);
							val.UpdateLastRunTime();
							Hero.MainHero.ChangeHeroGold(-agreedPrice);
							npc.ChangeHeroGold(agreedPrice);
							try
							{
								((CampaignEventReceiver)CampaignEventDispatcher.Instance).OnWorkshopOwnerChanged(val, npc);
							}
							catch (Exception ex2)
							{
								LogMessage("[WORKSHOP] Failed to trigger OnWorkshopOwnerChanged: " + ex2.Message);
							}
						}
						LogMessage($"[WORKSHOP] Successfully sold {text} from {npc.Name} to player for {agreedPrice} denars");
						TextObject val2 = new TextObject("{=AIInfluence_WorkshopBought}You bought {WORKSHOP_NAME} from {NPC_NAME} for {PRICE} denars", new Dictionary<string, object>
						{
							{ "WORKSHOP_NAME", text },
							{ "NPC_NAME", npc.Name },
							{ "PRICE", agreedPrice }
						});
						InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), ExtraColors.GreenAIInfluence));
						return;
					}
					catch (Exception ex3)
					{
						LogMessage("[ERROR] Failed to complete workshop sale: " + ex3.Message + "\n" + ex3.StackTrace);
						TextObject val3 = new TextObject("{=AIInfluence_WorkshopTransactionFailed}Failed to complete transaction: {ERROR_MESSAGE}", new Dictionary<string, object> { { "ERROR_MESSAGE", ex3.Message } });
						InformationManager.DisplayMessage(new InformationMessage(((object)val3).ToString(), ExtraColors.RedAIInfluence));
						return;
					}
				}
				LogMessage($"[WORKSHOP] Player has insufficient gold! Has {gold}, needs {agreedPrice}");
				TextObject val4 = new TextObject("{=AIInfluence_WorkshopInsufficientFunds}У вас недостаточно денег для покупки {WORKSHOP_NAME}! У вас {PLAYER_GOLD} динаров, а нужно {AGREED_PRICE} динаров.", new Dictionary<string, object>
				{
					{ "WORKSHOP_NAME", text },
					{ "PLAYER_GOLD", gold },
					{ "AGREED_PRICE", agreedPrice }
				});
				InformationManager.DisplayMessage(new InformationMessage(((object)val4).ToString(), ExtraColors.RedAIInfluence));
				LogMessage("[WORKSHOP] Sale failed due to insufficient funds");
			}
		});
	}

	public void ProcessItemTransfers(Hero npc, NPCContext context, List<ItemTransferData> itemTransfers)
	{
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		if (itemTransfers == null || itemTransfers.Count == 0 || npc == null)
		{
			return;
		}
		string text = ((object)npc.Name)?.ToString() ?? "Unknown";
		foreach (ItemTransferData transfer in itemTransfers)
		{
			bool flag = false;
			string errorReason = "";
			ItemObject val = ((IEnumerable<ItemObject>)Items.All).FirstOrDefault((Func<ItemObject, bool>)((ItemObject x) => ((MBObjectBase)x).StringId == transfer.ItemId));
			string value = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? transfer.ItemId;
			if (transfer.Action == "give")
			{
				flag = InventoryHelper.TransferItem(transfer.ItemId, transfer.Amount, npc, Hero.MainHero, out errorReason);
				if (flag)
				{
					LogMessage($"[ITEM_TRANSFER] {text} GAVE {transfer.Amount} of {transfer.ItemId} to Player.");
					RPItemManager.Instance?.UpdateItemOwner(transfer.ItemId, "MainParty");
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCGaveItem}{npcName} gave you {amount} {itemId}", new Dictionary<string, object>
					{
						{ "npcName", text },
						{ "amount", transfer.Amount },
						{ "itemId", value }
					})).ToString(), ExtraColors.GreenAIInfluence));
				}
			}
			else if (transfer.Action == "take")
			{
				flag = InventoryHelper.TransferItem(transfer.ItemId, transfer.Amount, Hero.MainHero, npc, out errorReason);
				if (flag)
				{
					LogMessage($"[ITEM_TRANSFER] {text} TOOK {transfer.Amount} of {transfer.ItemId} from Player.");
					RPItemManager.Instance?.UpdateItemOwner(transfer.ItemId, ((MBObjectBase)npc).StringId);
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCTookItem}{npcName} took {amount} {itemId} from you", new Dictionary<string, object>
					{
						{ "npcName", text },
						{ "amount", transfer.Amount },
						{ "itemId", value }
					})).ToString(), Colors.Yellow));
				}
			}
			else
			{
				errorReason = "Unknown action '" + transfer.Action + "'";
			}
			if (!flag)
			{
				LogMessage("[ITEM_TRANSFER] FAILED (" + transfer.Action + " " + transfer.ItemId + "): " + errorReason);
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_ItemTransferFailed}Failed to transfer {itemId}: {error}", new Dictionary<string, object>
				{
					{ "itemId", value },
					{ "error", errorReason }
				})).ToString(), ExtraColors.RedAIInfluence));
			}
		}
	}

	public void ProcessMoneyTransfer(Hero npc, NPCContext context, MoneyTransferInfo moneyTransfer)
	{
		LogMessage($"[DEBUG][MONEY_TRANSFER_EXEC] ProcessMoneyTransfer called for {((object)npc?.Name ?? "null")} - amount={moneyTransfer?.Amount}, action={moneyTransfer?.Action}. If you never see this line after a chat-window transfer, the transfer was never executed.");
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		if (moneyTransfer == null || moneyTransfer.Amount <= 0)
		{
			LogMessage("[MONEY_TRANSFER] Invalid money transfer parameters");
			return;
		}
		string text = moneyTransfer.Action?.ToLower();
		int amount = moneyTransfer.Amount;
		string text2 = ((object)npc.Name)?.ToString() ?? "Unknown";
		if (text == "give")
		{
			int gold = npc.Gold;
			if (gold < amount)
			{
				LogMessage($"[MONEY_TRANSFER] NPC {text2} tried to give {amount} denars but only has {gold}");
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCInsufficientGold}{npcName} does not have enough money (has {npcGold}, wanted to give {amount})", new Dictionary<string, object>
				{
					{ "npcName", text2 },
					{ "npcGold", gold },
					{ "amount", amount }
				})).ToString(), ExtraColors.RedAIInfluence));
				return;
			}
			npc.ChangeHeroGold(-amount);
			Hero.MainHero.ChangeHeroGold(amount);
			LogMessage($"[MONEY_TRANSFER] {text2} gave {amount} denars to player (NPC: {gold} -> {npc.Gold}, Player: {Hero.MainHero.Gold - amount} -> {Hero.MainHero.Gold})");
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCGaveGold}{npcName} gave you {amount} denars", new Dictionary<string, object>
			{
				{ "npcName", text2 },
				{ "amount", amount }
			})).ToString(), ExtraColors.GreenAIInfluence));
		}
		else if (text == "receive")
		{
			int gold2 = Hero.MainHero.Gold;
			if (gold2 < amount)
			{
				LogMessage($"[MONEY_TRANSFER] Player has insufficient gold! Has {gold2}, trying to give {amount}");
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_PlayerInsufficientGold}You do not have enough money! You have {playerGold} denars", new Dictionary<string, object> { { "playerGold", gold2 } })).ToString(), ExtraColors.RedAIInfluence));
				return;
			}
			Hero.MainHero.ChangeHeroGold(-amount);
			npc.ChangeHeroGold(amount);
			LogMessage($"[MONEY_TRANSFER] Player gave {amount} denars to {text2} (Player: {gold2} -> {Hero.MainHero.Gold}, NPC: {npc.Gold - amount} -> {npc.Gold})");
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_PlayerGaveGold}You gave {amount} denars to {npcName}", new Dictionary<string, object>
			{
				{ "amount", amount },
				{ "npcName", text2 }
			})).ToString(), Colors.Yellow));
		}
		else
		{
			LogMessage("[MONEY_TRANSFER] Unknown action: " + text);
		}
	}

	public void InitiateCombatLogic(Hero npc, NPCContext context)
	{
		Hero obj = npc;
		string text = ((obj == null) ? null : ((object)obj.Name)?.ToString()) ?? "Unknown";
		LogMessage("[DEBUG] Initiating combat logic with " + text + ".");
		var conversationManager = Campaign.Current?.ConversationManager;
		if (conversationManager?.IsConversationInProgress == true)
		{
			LogMessage("[DEBUG] Ending conversation before starting battle with " + text + ".");
			conversationManager.EndConversation();
		}
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			LogMessage("[DEBUG] EnableModification is false, skipping combat initiation for " + text + ".");
			return;
		}
		_delayedTaskManager.AddTask(0.1, delegate
		{
			InitiateCombatLogicDelayed(npc, context);
		});
	}

	private void InitiateCombatLogicDelayed(Hero npc, NPCContext context)
	{
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		string text = ((npc == null) ? null : ((object)npc.Name)?.ToString()) ?? "Unknown";
		LogMessage("[DEBUG] Starting delayed combat logic for " + text + ".");
		try
		{
			MobileParty mainParty = MobileParty.MainParty;
			PartyBase party = mainParty.Party;
			MobileParty partyBelongedTo = npc.PartyBelongedTo;
			PartyBase val = ((partyBelongedTo != null) ? partyBelongedTo.Party : null);
			if (npc.CurrentSettlement != null)
			{
				LogMessage($"[DEBUG] {text} is in settlement: {npc.CurrentSettlement.Name}. Using NEW settlement combat manager.");
				string combatResponse = context.CombatResponse;
				string npcResponse = ((combatResponse != null && combatResponse.StartsWith("attack:")) ? context.CombatResponse.Substring(7).Trim() : (text + " готовится к бою!"));
				_settlementCombatManager.InitiateCombat(npc, context, CombatTriggerType.NPCAttack, npcResponse);
				LogMessage("[DEBUG] Settlement combat initiated via new manager for " + text + ". Waiting for AI analysis...");
				return;
			}
			MobileParty partyBelongedTo2 = npc.PartyBelongedTo;
			if (((partyBelongedTo2 != null) ? partyBelongedTo2.Army : null) != null)
			{
				LogMessage($"[DEBUG] {text} is in army: {npc.PartyBelongedTo.Army.Name}. Using army combat handler.");
				MobileParty leaderParty = npc.PartyBelongedTo.Army.LeaderParty;
				if (leaderParty == null)
				{
					LogMessage("[ERROR] Army leader party is null for " + text + ".");
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_CombatError}Unable to initiate battle with {npcName} in army!", new Dictionary<string, object> { { "npcName", text } })).ToString(), ExtraColors.RedAIInfluence));
					context.NegativeToneCount = 0;
					context.EscalationState = "neutral";
					context.CombatResponse = null;
					SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
					LogMessage("[DEBUG] NPC context updated after failed army combat for " + text + ".");
					return;
				}
				val = leaderParty.Party;
				LogMessage($"[DEBUG] Using army leader party for combat: {leaderParty.Name}");
			}
			if (val == null)
			{
				LogMessage("[ERROR] Target party is null for " + text + " and they are not in a settlement. Cannot initiate combat.");
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_CombatError}Unable to initiate battle with {npcName}!", new Dictionary<string, object> { { "npcName", text } })).ToString(), ExtraColors.RedAIInfluence));
				context.NegativeToneCount = 0;
				context.EscalationState = "neutral";
				context.CombatResponse = null;
				SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
				LogMessage("[DEBUG] NPC context updated after failed combat for " + text + ".");
				return;
			}
			LogMessage("[DEBUG] === DIAGNOSTIC: NEARBY PARTIES ===");
			MBReadOnlyList<MobileParty> all = MobileParty.All;
			List<MobileParty> list = new List<MobileParty>();
			float num = 50f;
			foreach (MobileParty item in (List<MobileParty>)(object)all)
			{
				if (item != null && item != mainParty && item.CurrentSettlement == null)
				{
					Vec2 position2D = item.GetPosition2D();
					float num2 = (position2D).Distance(mainParty.GetPosition2D());
					if (num2 <= num)
					{
						bool flag = item.MapFaction != null && mainParty.MapFaction != null && item.MapFaction.IsAtWarWith(mainParty.MapFaction);
						bool flag2 = item.LeaderHero != null && item.LeaderHero.IsLord;
						LogMessage($"[DEBUG] Nearby party: {item.Name} (distance: {num2:F1}, hostile: {flag}, lord: {flag2}, men: {item.MemberRoster.TotalManCount})");
						list.Add(item);
					}
				}
			}
			LogMessage($"[DEBUG] Total nearby parties: {list.Count}");
			LogMessage("[DEBUG] === END DIAGNOSTIC ===");
			if (PlayerEncounter.Current != null)
			{
				PlayerEncounter.Finish(false);
				LogMessage("[DEBUG] Existing PlayerEncounter finished.");
			}
			PartyBase capturedTargetParty = val;
			PartyBase capturedPlayerPartyBase = party;
			Hero capturedNpc = npc;
			string capturedNpcName = text;
			NPCContext capturedContext = context;
			_delayedTaskManager.AddTask(0.1, delegate
			{
				InitiateCombatStep2_CreateEncounter(capturedTargetParty, capturedPlayerPartyBase, capturedNpc, capturedNpcName, capturedContext);
			});
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Exception in InitiateCombatLogicDelayed: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void InitiateCombatStep2_CreateEncounter(PartyBase targetParty, PartyBase playerPartyBase, Hero npc, string npcName, NPCContext context)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			LogMessage("[DEBUG] Step 2: Creating PlayerEncounter for " + npcName);
			if (targetParty == null || !targetParty.IsActive)
			{
				LogMessage("[ERROR] Target party became invalid. Cannot start combat.");
				return;
			}
			PlayerEncounter.RestartPlayerEncounter(playerPartyBase, targetParty, false);
			if (PlayerEncounter.Current == null)
			{
				LogMessage("[ERROR] Failed to create PlayerEncounter for " + npcName + ".");
				return;
			}
			LogMessage($"[DEBUG] PlayerEncounter created and initialized. PlayerSide: {PlayerEncounter.Current.PlayerSide}");
			_delayedTaskManager.AddTask(0.1, delegate
			{
				InitiateCombatStep3_StartBattle(npc, npcName, context);
			});
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Exception in InitiateCombatStep2: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void InitiateCombatStep3_StartBattle(Hero npc, string npcName, NPCContext context)
	{
		try
		{
			LogMessage("[DEBUG] Step 3: Starting battle for " + npcName);
			if (PlayerEncounter.Current == null)
			{
				LogMessage("[ERROR] PlayerEncounter is null in Step 3. Cannot continue.");
				return;
			}
			var conversationManager = Campaign.Current?.ConversationManager;
			if (conversationManager?.IsConversationInProgress == true)
			{
				LogMessage("[DEBUG] Closing conversation before starting battle.");
				conversationManager.EndConversation();
			}
			PlayerEncounter.SetMeetingDone();
			if (PlayerEncounter.Battle == null)
			{
				LogMessage("[DEBUG] Starting battle via PlayerEncounter.StartBattle()");
				PlayerEncounter.StartBattle();
			}
			_delayedTaskManager.AddTask(0.1, delegate
			{
				InitiateCombatStep4_ActivateMenu(npc, npcName, context);
			});
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Exception in InitiateCombatStep3: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void InitiateCombatStep4_ActivateMenu(Hero npc, string npcName, NPCContext context)
	{
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			LogMessage("[DEBUG] Step 4: Activating encounter menu for " + npcName);
			var conversationManager = Campaign.Current?.ConversationManager;
			if (conversationManager?.IsConversationInProgress == true)
			{
				LogMessage("[DEBUG] Closing conversation before activating menu.");
				conversationManager.EndConversation();
			}
			if (PlayerEncounter.Current != null && PlayerEncounter.Battle != null)
			{
				GameMenu.ActivateGameMenu("encounter");
				LogMessage("[DEBUG] Activated 'encounter' game menu.");
			}
			else
			{
				LogMessage("[WARNING] PlayerEncounter or Battle is null. Trying fallback...");
				if (PlayerEncounter.Current != null)
				{
					bool flag = default(bool);
					bool flag2 = default(bool);
					string encounterMenu = Campaign.Current.Models.EncounterGameMenuModel.GetEncounterMenu(PlayerEncounter.EncounteredParty, PartyBase.MainParty, out flag, out flag2);
					if (!string.IsNullOrEmpty(encounterMenu))
					{
						GameMenu.ActivateGameMenu(encounterMenu);
						LogMessage("[DEBUG] Activated fallback menu: " + encounterMenu);
					}
				}
			}
			if (PlayerEncounter.Current != null)
			{
				LogMessage("[DEBUG] === PLAYER ENCOUNTER DIAGNOSTIC ===");
				LogMessage("[DEBUG] PlayerEncounter created successfully");
				LogMessage($"[DEBUG] PlayerSide: {PlayerEncounter.Current.PlayerSide}");
				LogMessage($"[DEBUG] Player position: {MobileParty.MainParty.Position} (IsOnLand: {MobileParty.MainParty.Position.IsOnLand})");
				LogMessage($"[DEBUG] IsNavalEncounter: {PlayerEncounter.IsNavalEncounter()}");
				if (PlayerEncounter.Battle != null)
				{
					MBReadOnlyList<MapEventParty> parties = PlayerEncounter.Battle.AttackerSide.Parties;
					MBReadOnlyList<MapEventParty> parties2 = PlayerEncounter.Battle.DefenderSide.Parties;
					LogMessage($"[DEBUG] Attacker parties count: {((List<MapEventParty>)(object)parties).Count}");
					LogMessage($"[DEBUG] Defender parties count: {((List<MapEventParty>)(object)parties2).Count}");
					foreach (MapEventParty item in (List<MapEventParty>)(object)parties)
					{
						LogMessage($"[DEBUG] Attacker party: {item.Party.Name}");
					}
					foreach (MapEventParty item2 in (List<MapEventParty>)(object)parties2)
					{
						LogMessage($"[DEBUG] Defender party: {item2.Party.Name}");
					}
				}
				else
				{
					LogMessage("[DEBUG] PlayerEncounter.Battle is null");
				}
				LogMessage("[DEBUG] === END PLAYER ENCOUNTER DIAGNOSTIC ===");
			}
			string text = npcName;
			MapEvent battle = PlayerEncounter.Battle;
			LogMessage("[DEBUG] Battle status check for " + text + ". MapEvent: " + (((battle != null) ? ((object)((MBObjectBase)battle).Id/*cast due to .constrained prefix*/).ToString() : null) ?? "null"));
			_delayedTaskManager.AddTask(0.2, delegate
			{
				InitiateCombatStep5_StartMission(npc, npcName, context);
			});
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Exception in InitiateCombatStep4: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void InitiateCombatStep5_StartMission(Hero npc, string npcName, NPCContext context)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			LogMessage("[DEBUG] Step 5: Auto-starting battle mission for " + npcName);
			if (PlayerEncounter.Current == null || PlayerEncounter.Battle == null)
			{
				LogMessage("[WARNING] PlayerEncounter or Battle is null in Step 5. Cannot auto-start mission.");
				return;
			}
			var conversationManager = Campaign.Current?.ConversationManager;
			if (conversationManager?.IsConversationInProgress == true)
			{
				LogMessage("[DEBUG] Closing conversation before starting mission.");
				conversationManager.EndConversation();
			}
			MapEvent battle = PlayerEncounter.Battle;
			if (battle == null)
			{
				LogMessage("[ERROR] MapEvent.PlayerMapEvent is null. Cannot start attack.");
				return;
			}
			if (!((IEnumerable<MapEventParty>)battle.PartiesOnSide(PartyBase.MainParty.OpponentSide)).Any((MapEventParty party) => party.Party.NumberOfHealthyMembers > 0))
			{
				LogMessage("[WARNING] No enemy troops to attack. Skipping auto-start.");
				return;
			}
			if (Hero.MainHero.IsWounded)
			{
				LogMessage("[WARNING] Main hero is wounded. Cannot lead attack. Skipping auto-start.");
				return;
			}
			LogMessage("[DEBUG] Calling MenuHelper.EncounterAttackConsequence to start mission...");
			MenuHelper.EncounterAttackConsequence((MenuCallbackArgs)null);
			LogMessage("[DEBUG] MenuHelper.EncounterAttackConsequence called. Battle mission should be starting...");
			context.NegativeToneCount = 0;
			context.EscalationState = "neutral";
			context.CombatResponse = null;
			SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			LogMessage("[DEBUG] NPC context reset after combat initiation for " + npcName + ".");
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Exception in InitiateCombatStep5: " + ex.Message + "\n" + ex.StackTrace);
			try
			{
				context.NegativeToneCount = 0;
				context.EscalationState = "neutral";
				context.CombatResponse = null;
				SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			}
			catch
			{
			}
		}
	}

	public async Task HandlePlayerInput()
	{
		Hero npc = Hero.OneToOneConversationHero;
		if (npc == null)
		{
			LogMessage("[ERROR] No conversation hero found.");
			return;
		}
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			LogMessage("[SYSTEM] Mod is disabled, skipping conversation processing");
			return;
		}
		string npcId = ((MBObjectBase)npc).StringId;
		string npcName = ((object)npc.Name)?.ToString() ?? "Unknown";
		Clan clan = npc.Clan;
		string faction = ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "No faction";
		MobileParty npcParty = npc.PartyBelongedTo;
		bool isHostile = npcParty != null && npcParty.MapFaction != null && npcParty.MapFaction.IsAtWarWith(Hero.MainHero.MapFaction);
		string locationInfo = WorldInfoManager.Instance.GetLocationInfo(npc, npcParty);
		LogMessage(string.Format("[DEBUG] NPC {0} party: {1}; Hostile: {2}; Relation with player: {3}; Location: {4}", npcName, (npcParty != null) ? ((string)(object)npcParty.Name) : "none", isHostile, npc.GetRelation(Hero.MainHero), locationInfo));
		NPCContext context = GetOrCreateNPCContext(npc);
		bool isNPCInitiated = context.IsNPCInitiatedConversation;
		if (isNPCInitiated)
		{
			LogMessage("[NPC_INITIATIVE] This is NPC-initiated conversation with " + npcName);
		}
		context.IsNPCInitiatedConversation = false;
		UpdateContextData(context, npc);
		CharacterInfo.UpdateEncyclopediaDescription(npc, context.AIGeneratedBackstory, context.AIGeneratedPersonality);
		string title = ((object)new TextObject("{=AIInfluence_PlayerInputTitle}Your message to {npcName}:", new Dictionary<string, object> { { "npcName", npcName } })).ToString();
		string description = BuildDialogueInputDescription(context, npcName);
		string playerInput = await TextInput(title, description, npc);
		if (string.IsNullOrEmpty(playerInput))
		{
			LogMessage("[DEBUG] Player cancelled or entered empty input.");
			MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", ((object)new TextObject("{=AIInfluence_PlayerSilent}You remain silent.", (Dictionary<string, object>)null)).ToString(), false);
			return;
		}
		LogMessage("[PLAYER_INPUT] " + playerInput);
		context.AddMessage("Player: " + playerInput);
		SaveNPCContext(npcId, npc, context);
		WorldInfoManager.Instance.UpdateTimeContext(context);
		WorldInfoManager.Instance.UpdateWarStatus(context);
		string prompt;
		if (isNPCInitiated && _npcInitiativeSystem != null)
		{
			prompt = _npcInitiativeSystem.GeneratePartyInitiativePrompt(npc, context);
			LogMessage("[PROMPT] NPC-initiated conversation for " + npcName);
		}
		else
		{
			prompt = PromptGenerator.GeneratePrompt(npc, context);
		}
		LogMessage("[PROMPT] For " + npcName + ": " + prompt);
		context.LastInteractionTime = CampaignTime.Now;
		string aiResponse = null;
		int maxRetries = 3;
		for (int attempt = 1; attempt <= maxRetries; attempt++)
		{
			try
			{
				aiResponse = await AIClient.GetAIResponse(npcName, faction, prompt + "\nPlayer: " + playerInput);
				if (!string.IsNullOrEmpty(aiResponse) && !aiResponse.StartsWith("Error:"))
				{
					break;
				}
				LogMessage(string.Format("[WARNING] Attempt {0} failed: {1}", attempt, string.IsNullOrEmpty(aiResponse) ? "Empty response" : aiResponse));
				if (attempt < maxRetries)
				{
					await Task.Delay(1000 * attempt);
				}
				continue;
			}
			catch (Exception ex)
			{
				LogMessage($"[WARNING] Attempt {attempt} failed: {ex.Message}");
				if (attempt == maxRetries)
				{
					LogMessage("[ERROR] Max retries reached for OpenRouter");
					aiResponse = "{\"response\": \"I am unable to respond right now. Try again later.\", \"suspected_lie\": false, \"claimed_name\": null, \"claimed_clan\": null, \"claimed_age\": null, \"tone\": \"neutral\", \"threat_level\": \"none\", \"escalation_state\": \"neutral\", \"deescalation_attempt\": false, \"decision\": \"none\"}";
					break;
				}
				await Task.Delay(1000 * attempt);
				continue;
			}
		}
		if (string.IsNullOrEmpty(aiResponse) || aiResponse.StartsWith("Error:"))
		{
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_AIError}{npcName} is silent, as if lost in thought. Try again later.", new Dictionary<string, object> { { "npcName", npcName } })).ToString(), Colors.Yellow));
			LogMessage("[ERROR] AI response error: " + (aiResponse ?? "Empty response"));
			MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", "I am unable to respond right now. Try again later.", false);
			return;
		}
		LogMessage("[DEBUG] Raw AI response: " + aiResponse);
		string cleanedResponse = JsonCleaner.CleanJsonResponse(aiResponse);
		LogMessage("[DEBUG] Cleaned AI response: " + cleanedResponse);
		AIResponse aiResult;
		try
		{
			if (!JsonCleaner.IsValidJson(cleanedResponse))
			{
				throw new JsonException("Cleaned response is not valid JSON.");
			}
			aiResult = JsonConvert.DeserializeObject<AIResponse>(cleanedResponse);
			if (aiResult == null)
			{
				LogMessage("[WARNING] AI response is null after parsing. Falling back to default response.");
				aiResult = new AIResponse
				{
					Response = "I have nothing to say right now.",
					SuspectedLie = false,
					ClaimedName = null,
					ClaimedClan = null,
					ClaimedAge = null,
					Tone = "neutral",
					ThreatLevel = "none",
					EscalationState = "neutral",
					DeescalationAttempt = false,
					Decision = "none"
				};
			}
		}
		catch (JsonException ex2)
		{
			JsonException ex3 = ex2;
			JsonException ex4 = ex3;
			LogMessage("[ERROR] Failed to parse AI response: " + ((Exception)(object)ex4).Message + ". Cleaned response: " + cleanedResponse);
			string fallbackResponse = JsonCleaner.ExtractFallbackResponse(aiResponse, npcName);
			aiResult = new AIResponse
			{
				Response = fallbackResponse,
				SuspectedLie = false,
				ClaimedName = null,
				ClaimedClan = null,
				ClaimedAge = null,
				Tone = "neutral",
				ThreatLevel = "none",
				EscalationState = "neutral",
				DeescalationAttempt = false,
				Decision = "none"
			};
		}
		if (!string.IsNullOrEmpty(aiResult.RomanceIntent) && aiResult.RomanceIntent != "none")
		{
			CampaignTime now = CampaignTime.Now;
			context.LastRomanceInteractionDays = (int)(now).ToDays;
			int romanceChange = _random.Next(GlobalSettings<ModSettings>.Instance.MinRomanceChange, GlobalSettings<ModSettings>.Instance.MaxRomanceChange + 1);
			if (aiResult.RomanceIntent == "romance")
			{
				romanceChange += 2;
			}
			context.RomanceLevel = Math.Min(100f, context.RomanceLevel + (float)romanceChange);
			LogMessage($"[DEBUG] Romance [{aiResult.RomanceIntent}] interaction with {npcName}. RomanceLevel now {context.RomanceLevel:F1} (change: +{romanceChange}).");
		}
		if (!string.IsNullOrEmpty(aiResult.Decision))
		{
			LogMessage("[DEBUG] Processing AI decision: " + aiResult.Decision + " for " + npcName);
			if (aiResult.Decision == "propose_marriage")
			{
				context.MarriageResponse = "pending_player_choice";
				LogMessage("[DEBUG] NPC " + npcName + " has proposed marriage. Awaiting AI's assessment of player's following response.");
			}
			else if (aiResult.Decision == "accept_marriage")
			{
				LogMessage("[DEBUG] Marriage accepted (AI decided). Setting MarriageResponse flag...");
				LogMessage($"[DEBUG] Marriage conditions: IsRomanceEligible={context.IsRomanceEligible}, RomanceLevel={context.RomanceLevel:F1}");
				context.MarriageResponse = "married";
				LogMessage("[DEBUG] Set MarriageResponse=married. Wedding will occur in 15 seconds.");
			}
			else if (aiResult.Decision == "reject_marriage")
			{
				LogMessage("[DEBUG] Marriage rejected (AI decided). Reducing romance level.");
				context.RomanceLevel = Math.Max(0f, context.RomanceLevel - 10f);
				context.MarriageResponse = "rejected";
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_MarriageRejected}{npcName} has rejected the marriage proposal.", new Dictionary<string, object> { { "npcName", npcName } })).ToString(), ExtraColors.RedAIInfluence));
			}
		}
		if (aiResult.CharacterDeath != null && aiResult.CharacterDeath.ShouldDie)
		{
			try
			{
				string deathReason = aiResult.CharacterDeath.DeathReason ?? "unknown causes";
				string killerStringId = aiResult.CharacterDeath.KillerStringId;
				LogMessage("[ROLEPLAY] Character " + npcName + " has died: " + deathReason);
				if (!string.IsNullOrEmpty(killerStringId))
				{
					LogMessage("[ROLEPLAY] Killer identified: " + killerStringId);
				}
				else
				{
					LogMessage("[ROLEPLAY] Natural death (no killer)");
				}
				if (!CanNPCBeKilledThroughRoleplay(npc))
				{
					LogMessage("[ROLEPLAY] Character " + npcName + " CANNOT be killed through roleplay - conditions not met (not in mission, not prisoner, or has army on map)");
					context.PendingAIResponse = aiResult;
					MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", aiResult.Response, false);
					context.LastDynamicResponse = aiResult.Response;
					SaveNPCContext(npcId, npc, context);
					return;
				}
				LogMessage("[ROLEPLAY] Character " + npcName + " CAN be killed - all conditions met");
				context.DeathReason = deathReason;
				context.KillerStringId = killerStringId;
				context.PendingDeath = "pending";
				SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
				if (Settlement.CurrentSettlement != null && Mission.Current != null)
				{
					LogMessage($"[ROLEPLAY] Death occurred in settlement {Settlement.CurrentSettlement.Name} - marking for settlement combat analysis");
					context.PendingSettlementCombat = "roleplay_death";
					context.SettlementCombatResponse = aiResult.Response;
				}
				else
				{
					LogMessage("[ROLEPLAY] Character " + npcName + " death pending - will be executed in DialogManager after delay.");
				}
			}
			catch (Exception ex5)
			{
				Exception ex6 = ex5;
				LogMessage("[ERROR] Failed to process character death for " + npcName + ": " + ex6.Message);
				LogMessage("[ERROR] Stack trace: " + ex6.StackTrace);
			}
		}
		bool personalityUpdated = false;
		bool backstoryUpdated = false;
		bool quirksUpdated = false;
		if (!string.IsNullOrEmpty(aiResult.CharacterPersonality) && string.IsNullOrEmpty(context.AIGeneratedPersonality))
		{
			string trimmedPersonality = (context.AIGeneratedPersonality = aiResult.CharacterPersonality.Trim());
			personalityUpdated = true;
			LogMessage("[CHARACTER_PERSONALITY] AI generated personality for " + npcName + ": " + trimmedPersonality);
		}
		if (!string.IsNullOrEmpty(aiResult.CharacterBackstory) && string.IsNullOrEmpty(context.AIGeneratedBackstory))
		{
			string trimmedBackstory = (context.AIGeneratedBackstory = aiResult.CharacterBackstory.Trim());
			backstoryUpdated = true;
			LogMessage("[CHARACTER_BACKSTORY] AI generated backstory for " + npcName + ": " + trimmedBackstory);
		}
		if (!string.IsNullOrEmpty(aiResult.CharacterSpeechQuirks) && string.IsNullOrEmpty(context.AIGeneratedSpeechQuirks))
		{
			string trimmedQuirks = (context.AIGeneratedSpeechQuirks = aiResult.CharacterSpeechQuirks.Trim());
			quirksUpdated = true;
			LogMessage("[CHARACTER_SPEECH_QUIRKS] AI generated speech quirks for " + npcName + ": " + trimmedQuirks);
		}
		if (personalityUpdated || backstoryUpdated || quirksUpdated)
		{
			LogMessage($"[DEBUG] Updating encyclopedia immediately after AI generation (personality: {personalityUpdated}, backstory: {backstoryUpdated}, quirks: {quirksUpdated})");
		}
		CharacterInfo.UpdateEncyclopediaDescription(npc, context.AIGeneratedBackstory, context.AIGeneratedPersonality);
		if (aiResult.AllowsLettersFromNPC.HasValue && aiResult.AllowsLettersFromNPC.Value != context.AllowsLettersFromNPC)
		{
			LogMessage($"[DEBUG] {npcName} wants to change AllowsLettersFromNPC to {aiResult.AllowsLettersFromNPC.Value} (processed in DialogManager)");
		}
		context.EscalationState = aiResult.EscalationState;
		if (aiResult.Tone == "negative")
		{
			context.NegativeToneCount = context.NegativeToneCount.GetValueOrDefault() + 1;
			LogMessage($"[DEBUG] Negative tone detected. NegativeToneCount: {context.NegativeToneCount}. EscalationState: {context.EscalationState}");
		}
		else if (aiResult.DeescalationAttempt)
		{
			context.NegativeToneCount = 0;
			context.EscalationState = "neutral";
			LogMessage("[DEBUG] Deescalation attempt detected. Reset NegativeToneCount to 0. EscalationState: " + context.EscalationState);
		}
		else
		{
			context.NegativeToneCount = 0;
			LogMessage("[DEBUG] Non-negative tone detected. Reset NegativeToneCount to 0. EscalationState: " + context.EscalationState);
		}
		try
		{
			_decisionHandler.HandleAIDecision(context, npc, aiResult, playerInput);
		}
		catch (Exception ex7)
		{
			LogMessage("[ERROR] Failed to handle AI decision: " + ex7.Message);
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_ConflictError}{npcName} seems unsettled, but no fight breaks out.", new Dictionary<string, object> { { "npcName", npcName } })).ToString(), Colors.Yellow));
		}
		context.PendingAIResponse = aiResult;
		context.LastAIResponseJson = cleanedResponse;
		MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", aiResult.Response, false);
		context.LastDynamicResponse = aiResult.Response;
		LogMessage("[DEBUG] Set DYNAMIC_NPC_RESPONSE: " + aiResult.Response);
		if (!string.IsNullOrEmpty(aiResult.InternalThoughts))
		{
			LogMessage("[INTERNAL THOUGHTS] " + npcName + ": " + aiResult.InternalThoughts);
		}
		try
		{
			string npcHistoryLine = npcName + ": " + aiResult.Response;
			if (context.ConversationHistory == null)
			{
				context.ConversationHistory = new List<string>();
			}
			if (context.ConversationHistory.Count == 0 || context.ConversationHistory[context.ConversationHistory.Count - 1] != npcHistoryLine)
			{
				context.AddMessage(npcHistoryLine);
				LogMessage("[DEBUG] Added NPC reply to history: " + npcHistoryLine);
			}
		}
		catch
		{
		}
		if (aiResult.Decision == "attack")
		{
			context.CombatResponse = "attack: " + aiResult.Response;
			LogMessage("[DEBUG] Saved combat response: " + context.CombatResponse);
			if (Settlement.CurrentSettlement != null && Mission.Current != null)
			{
				context.PendingSettlementCombat = "attack";
				context.SettlementCombatResponse = aiResult.Response;
				LogMessage("[SETTLEMENT_COMBAT] Marked for settlement combat, response saved");
			}
		}
		else if (aiResult.Decision == "surrender")
		{
			context.CombatResponse = null;
			context.IsSurrendering = true;
			LogMessage("[EVENT] NPC " + npcName + " surrenders. Clearing CombatResponse.");
		}
		else if (aiResult.Decision == "accept_surrender")
		{
			if (context.CombatResponse == null || !context.CombatResponse.Contains("accept_surrender"))
			{
				context.CombatResponse = "accept_surrender: " + aiResult.Response;
			}
			context.IsPlayerSurrendering = true;
			LogMessage("[EVENT] NPC " + npcName + " accepts player surrender. CombatResponse: " + context.CombatResponse);
		}
		else if (aiResult.Decision == "release")
		{
			context.CombatResponse = "release: " + aiResult.Response;
			LogMessage("[EVENT] NPC " + npcName + " decides to release player without combat. Saved as combat response: " + context.CombatResponse);
		}
		else
		{
			LogMessage("[DEBUG] No special decision for " + npcName + ". Decision: '" + aiResult.Decision + "', CombatResponse: '" + context.CombatResponse + "'");
		}
		context.PlayerInfo.SuspectedLie = aiResult.SuspectedLie;
		if (!string.IsNullOrEmpty(aiResult.ClaimedName))
		{
			context.PlayerInfo.ClaimedName = aiResult.ClaimedName;
			LogMessage("[DEBUG] Updated claimed name: " + context.PlayerInfo.ClaimedName);
		}
		if (!string.IsNullOrEmpty(aiResult.ClaimedClan))
		{
			context.PlayerInfo.ClaimedClan = aiResult.ClaimedClan;
			LogMessage("[DEBUG] Updated claimed clan: " + context.PlayerInfo.ClaimedClan);
		}
		if (aiResult.ClaimedAge.HasValue)
		{
			context.PlayerInfo.ClaimedAge = aiResult.ClaimedAge.Value;
			LogMessage($"[DEBUG] Updated claimed age: {context.PlayerInfo.ClaimedAge}");
		}
		if (aiResult.ClaimedGold > 0)
		{
			context.PlayerInfo.ClaimedGold = aiResult.ClaimedGold;
			LogMessage($"[DEBUG] Player claimed to have {context.PlayerInfo.ClaimedGold} denars");
		}
		bool isSellingWorkshop = !string.IsNullOrEmpty(aiResult.WorkshopAction) && aiResult.WorkshopAction.ToLower() == "sell";
		if (aiResult.MoneyTransfer != null && aiResult.MoneyTransfer.Amount > 0)
		{
			if (isSellingWorkshop)
			{
				LogMessage("[MONEY_TRANSFER] Ignoring money_transfer because workshop is being sold (money transfer happens automatically in workshop sale)");
			}
			else
			{
				context.PendingMoneyTransfer = aiResult.MoneyTransfer;
				LogMessage($"[MONEY_TRANSFER] Saved pending money transfer: {aiResult.MoneyTransfer.Action} {aiResult.MoneyTransfer.Amount} denars for NPC {npc.Name}");
			}
		}
		else if (aiResult.MoneyTransfer != null)
		{
			LogMessage($"[MONEY_TRANSFER] MoneyTransfer exists but Amount <= 0: Action={aiResult.MoneyTransfer.Action}, Amount={aiResult.MoneyTransfer.Amount}");
		}
		else
		{
			LogMessage("[MONEY_TRANSFER] MoneyTransfer is null in aiResult");
		}
		if (aiResult.ItemTransfers != null && aiResult.ItemTransfers.Count > 0)
		{
			context.PendingItemTransfers = aiResult.ItemTransfers;
			LogMessage($"[ITEM_TRANSFER] Saved pending item transfers: {aiResult.ItemTransfers.Count} items for NPC {npc.Name}");
		}
		else if (aiResult.ItemTransfers != null)
		{
			LogMessage($"[ITEM_TRANSFER] ItemTransfers exists but Count <= 0: {aiResult.ItemTransfers.Count} items");
		}
		else
		{
			LogMessage("[ITEM_TRANSFER] ItemTransfers is null in aiResult");
		}
		if (isSellingWorkshop)
		{
			ProcessWorkshopSale(npc, context, aiResult.WorkshopStringId, aiResult.WorkshopPrice);
		}
		if (aiResult.Tone == "positive")
		{
			int relationChange = _random.Next(GlobalSettings<ModSettings>.Instance.MinPositiveRelationChange, GlobalSettings<ModSettings>.Instance.MaxPositiveRelationChange + 1);
			string message = ((object)new TextObject("{=AIInfluence_RelationImproved}Your relations with {npcName} have improved due to your friendly tone.", new Dictionary<string, object> { { "npcName", npcName } })).ToString();
			context.PendingRelationChange = new PendingRelationChange
			{
				RelationChange = relationChange,
				Message = message,
				Color = ExtraColors.GreenAIInfluence
			};
			LogMessage($"[DEBUG] Positive tone detected. Scheduled relation increase by {relationChange} for 'What do you say?'.");
		}
		else if (aiResult.Tone == "negative")
		{
			int relationChange2 = _random.Next(GlobalSettings<ModSettings>.Instance.MinNegativeRelationChange, GlobalSettings<ModSettings>.Instance.MaxNegativeRelationChange + 1);
			string message2 = ((object)new TextObject("{=AIInfluence_RelationWorsened}Your relations with {npcName} have worsened due to your aggressive tone.", new Dictionary<string, object> { { "npcName", npcName } })).ToString();
			context.PendingRelationChange = new PendingRelationChange
			{
				RelationChange = -relationChange2,
				Message = message2,
				Color = ExtraColors.RedAIInfluence
			};
			LogMessage($"[DEBUG] Negative tone detected. Scheduled relation decrease by {relationChange2} for 'What do you say?'.");
		}
		else
		{
			LogMessage("[DEBUG] Neutral tone detected. No relation change.");
		}
		if (aiResult.SuspectedLie)
		{
			float trustPenalty = (float)(_random.NextDouble() * (double)(GlobalSettings<ModSettings>.Instance.MaxLieTrustPenalty - GlobalSettings<ModSettings>.Instance.MinLieTrustPenalty) + (double)GlobalSettings<ModSettings>.Instance.MinLieTrustPenalty);
			int relationPenalty = _random.Next(GlobalSettings<ModSettings>.Instance.MinLieRelationPenalty, GlobalSettings<ModSettings>.Instance.MaxLieRelationPenalty + 1);
			context.LiePenaltySum += trustPenalty;
			UpdateTrustLevel(context, npc);
			string message3 = ((object)new TextObject("{=AIInfluence_RelationReduced}Your relations with {npcName} have worsened due to suspicions of lying.", new Dictionary<string, object> { { "npcName", npcName } })).ToString();
			context.PendingLiePenalty = new PendingRelationChange
			{
				RelationChange = -relationPenalty,
				Message = message3,
				Color = Colors.Yellow
			};
			LogMessage($"[DEBUG] Lie detected by AI. Trust penalty: {trustPenalty:F2}, LiePenaltySum: {context.LiePenaltySum:F2}, TrustLevel: {context.TrustLevel:F3}. Scheduled result decrease by {relationPenalty} for 'What do you say?'.");
		}
		SaveNPCContext(npcId, npc, context);
		if ((GlobalSettings<ModSettings>.Instance?.EnableTTS ?? false) && !string.IsNullOrEmpty(context.AssignedTTSVoice))
		{
			string responseText = context.LastDynamicResponse;
			string ttsInstructions = context.PendingAIResponse?.TTSInstructions ?? "";
			if (!string.IsNullOrEmpty(responseText))
			{
				if (!string.IsNullOrEmpty(context.LastTTSPlayedText) && string.Equals(context.LastTTSPlayedText, responseText, StringComparison.Ordinal) && string.Equals(context.LastTTSInstructions ?? "", ttsInstructions, StringComparison.Ordinal))
				{
					LogMessage("[TTS] Skipping TTS preparation: same text and instructions already played.");
					context.PreparedTts = null;
				}
				else
				{
					LogMessage("[TTS] Pre-generating TTS for " + npcName + " before showing 'NPC ready'...");
					try
					{
						bool voiceExists = await Player2Client.VoiceExistsAsync(context.AssignedTTSVoice);
						string voiceToUse = context.AssignedTTSVoice;
						if (!voiceExists)
						{
							LogMessage("[TTS] Voice " + context.AssignedTTSVoice + " no longer exists. Replacing.");
							string newVoice = await Player2Client.GetRandomVoiceAsync(context.Gender);
							if (!string.IsNullOrEmpty(newVoice))
							{
								voiceToUse = newVoice;
								context.AssignedTTSVoice = newVoice;
								LogMessage("[TTS] Replaced voice for " + npcName + ": " + newVoice);
							}
							else
							{
								LogMessage("[TTS] Failed to assign new voice for " + npcName + ". Skipping TTS.");
								voiceToUse = null;
							}
						}
						if (!string.IsNullOrEmpty(voiceToUse))
						{
							TtsPreparedData prepared = await TtsLipSyncService.PrepareAsync(responseText, voiceToUse, npcName, ttsInstructions, context.EscalationState ?? "neutral");
							if (prepared != null)
							{
								context.PreparedTts = prepared;
								context.LastTTSPlayedText = responseText;
								context.LastTTSInstructions = ttsInstructions;
								SaveNPCContext(npcId, npc, context);
								LogMessage("[TTS] TTS prepared successfully for " + npcName + ".");
							}
							else
							{
								context.PreparedTts = null;
								LogMessage("[TTS] TTS preparation failed for " + npcName + ".");
							}
						}
					}
					catch (Exception ex5)
					{
						Exception ex8 = ex5;
						context.PreparedTts = null;
						LogMessage("[TTS_ERROR] TTS preparation failed for " + npcName + ": " + ex8.Message);
					}
				}
			}
		}
		string messageText = ((object)new TextObject("{=AIInfluence_NPCReady}{npcName} is ready to respond.", new Dictionary<string, object> { { "npcName", npcName } })).ToString();
		LogMessage("[DEBUG] Displayed notification: " + npcName + " is ready to respond.");
		InformationManager.DisplayMessage(new InformationMessage(messageText, Colors.White));
		if (!(GlobalSettings<ModSettings>.Instance?.EnableResponseReadySound ?? false))
		{
			return;
		}
		try
		{
			SoundEvent.PlaySound2D("event:/ui/notification/alert");
		}
		catch (Exception ex9)
		{
			LogMessage("[SOUND] PlaySound2D failed: " + ex9.Message);
		}
	}

	private static string TryExtractStreamingResponseText(string partialJson)
	{
		if (string.IsNullOrEmpty(partialJson))
		{
			return "";
		}
		Match match = StreamingResponseFieldRegex.Match(partialJson);
		if (!match.Success)
		{
			if (!partialJson.TrimStart(Array.Empty<char>()).StartsWith("{", StringComparison.Ordinal))
				return partialJson;
			return "";
		}
		string value = match.Groups["text"].Value;
		string text = "\"" + value + "\"";
		try
		{
			return JsonConvert.DeserializeObject<string>(text) ?? "";
		}
		catch (Exception ex)
		{
			Instance?.LogMessage("[ChatWindow] JSON unescape failed for partial stream chunk: " + ex.Message);
			return value.Replace("\\/", "/").Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\t", "\t").Replace("\\\"", "\"");
		}
	}

	public async Task<string> ProcessChatInput(Hero npc, string playerMessage, Action<string> onPartialResponse = null)
	{
		if (npc == null || string.IsNullOrEmpty(playerMessage))
			return "";
		string npcId = ((MBObjectBase)npc).StringId;
		string npcName = ((object)npc.Name)?.ToString() ?? "Unknown";
		Clan clan = npc.Clan;
		string faction = ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "No faction";
		NPCContext context = GetOrCreateNPCContext(npc);
		UpdateContextData(context, npc);
		string heroDisplayName = ((object)Hero.MainHero?.Name)?.ToString() ?? "Player";
		context.AddMessage(heroDisplayName + ": " + playerMessage);
		SaveNPCContext(npcId, npc, context);
		WorldInfoManager.Instance.UpdateTimeContext(context);
		WorldInfoManager.Instance.UpdateWarStatus(context);
		context.PendingRelationChange = null;
		context.PendingLiePenalty = null;
		string prompt = PromptGenerator.GeneratePrompt(npc, context);
		StringBuilder streamJsonBuilder = (onPartialResponse == null) ? null : new StringBuilder();
		string lastStreamPreview = "";
		Action<string> streamCallback = (onPartialResponse == null) ? null : (Action<string>)delegate(string streamDelta)
		{
			streamJsonBuilder.Append(streamDelta ?? "");
			string text = TryExtractStreamingResponseText(streamJsonBuilder.ToString());
			if (!string.IsNullOrEmpty(text) && !string.Equals(text, lastStreamPreview, StringComparison.Ordinal))
			{
				lastStreamPreview = text;
				try
				{
					onPartialResponse(text);
				}
				catch (Exception ex2)
				{
					LogMessage("[ChatWindow] Stream update callback failed: " + ex2.Message);
				}
			}
		};
		string aiResponse = null;
		for (int attempt = 1; attempt <= 3; attempt++)
		{
			try
			{
				if (attempt > 1)
				{
					streamJsonBuilder?.Clear();
					lastStreamPreview = "";
					onPartialResponse?.Invoke("");
				}
				aiResponse = await AIClient.GetAIResponse(npcName, faction, prompt + "\nPlayer: " + playerMessage, streamCallback);
				if (!string.IsNullOrEmpty(aiResponse) && !aiResponse.StartsWith("Error:"))
					break;
				if (attempt < 3)
					await Task.Delay(1000 * attempt);
			}
			catch (Exception ex)
			{
				LogMessage($"[ChatWindow] Attempt {attempt} failed: {ex.Message}");
				if (attempt < 3)
					await Task.Delay(1000 * attempt);
			}
		}
		if (string.IsNullOrEmpty(aiResponse) || aiResponse.StartsWith("Error:"))
			return "";
		string cleaned = JsonCleaner.CleanJsonResponse(aiResponse);
		AIResponse aiResult;
		try
		{
			aiResult = JsonCleaner.IsValidJson(cleaned)
				? JsonConvert.DeserializeObject<AIResponse>(cleaned)
				: new AIResponse { Response = JsonCleaner.ExtractFallbackResponse(aiResponse, npcName), Decision = "none" };
		}
		catch (Exception)
		{
			aiResult = new AIResponse { Response = JsonCleaner.ExtractFallbackResponse(aiResponse, npcName), Decision = "none" };
		}
		if (aiResult == null)
			return "";
		string reply = aiResult.Response ?? "";
		context.LastInteractionTime = CampaignTime.Now;
		context.InteractionCount++;
		LogMessage("[DEBUG][CHAT_ACTION_AUDIT] ── AI response fields for chat window ──");
		LogMessage($"[DEBUG][CHAT_ACTION_AUDIT] decision        = '{aiResult.Decision}'");
		LogMessage($"[DEBUG][CHAT_ACTION_AUDIT] technical_action= '{aiResult.TechnicalAction}'");
		LogMessage($"[DEBUG][CHAT_ACTION_AUDIT] money_transfer  = {(aiResult.MoneyTransfer != null ? $"action={aiResult.MoneyTransfer.Action} amount={aiResult.MoneyTransfer.Amount}" : "null")}");
		LogMessage($"[DEBUG][CHAT_ACTION_AUDIT] item_transfers  = {(aiResult.ItemTransfers != null ? $"{aiResult.ItemTransfers.Count} item(s)" : "null")}");
		LogMessage($"[DEBUG][CHAT_ACTION_AUDIT] kingdom_action  = '{aiResult.KingdomAction}'");
		LogMessage($"[DEBUG][CHAT_ACTION_AUDIT] quest_action    = {(aiResult.QuestAction != null ? $"action={aiResult.QuestAction.Action}" : "null")}");
		LogMessage($"[DEBUG][CHAT_ACTION_AUDIT] tone            = '{aiResult.Tone}'");
		LogMessage($"[DEBUG][CHAT_ACTION_AUDIT] workshop_action = '{aiResult.WorkshopAction}'");
		if (aiResult.CharacterDeath != null && aiResult.CharacterDeath.ShouldDie && CanNPCBeKilledThroughRoleplay(npc))
		{
			context.DeathReason = aiResult.CharacterDeath.DeathReason ?? "unknown causes";
			context.KillerStringId = aiResult.CharacterDeath.KillerStringId;
			context.PendingDeath = "pending";
			bool isSettlementCombat = Settlement.CurrentSettlement != null && Mission.Current != null;
			if (isSettlementCombat)
			{
				context.PendingSettlementCombat = "roleplay_death";
				context.SettlementCombatResponse = reply;
			}
			SaveNPCContext(npcId, npc, context);
			GetDelayedTaskManager().AddTask(5.0, delegate
			{
				try
				{
					if (isSettlementCombat)
					{
						SettlementCombatManager settlementCombatManager = GetSettlementCombatManager();
						if (settlementCombatManager != null)
						{
							settlementCombatManager.InitiateCombat(npc, context, CombatTriggerType.RoleplayDeath, context.SettlementCombatResponse);
							context.PendingSettlementCombat = null;
							context.SettlementCombatResponse = null;
							SaveNPCContext(npcId, npc, context);
						}
					}
					else
					{
						var cm = Campaign.Current?.ConversationManager;
						if (cm?.IsConversationInProgress == true) cm.EndConversation();
						GetDelayedTaskManager().AddTask(1.0, delegate
						{
							try
							{
								if (npc != null && !npc.IsDead)
								{
									Hero killer = string.IsNullOrEmpty(context.KillerStringId) ? null : Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == context.KillerStringId));
									KillCharacterHeroPublic(npc, killer, killedInAction: false);
								}
								context.PendingDeath = null;
								context.KillerStringId = null;
								SaveNPCContext(npcId, npc, context);
							}
							catch (Exception ex5) { LogMessage("[ERROR] Chat death execution failed: " + ex5.Message); }
						});
					}
				}
				catch (Exception ex6) { LogMessage("[ERROR] Chat death schedule failed: " + ex6.Message); }
			});
		}
		if (aiResult.Decision == "accept_marriage")
		{
			float delay = GlobalSettings<ModSettings>.Instance.DialogDelay;
			GetDelayedTaskManager().AddTask(delay, delegate { try { MarriageSystem.AcceptMarriage(npc, Hero.MainHero, context); context.MarriageResponse = null; SaveNPCContext(npcId, npc, context); } catch (Exception ex4) { LogMessage("[ERROR] Marriage failed: " + ex4.Message); } });
		}
		else if (aiResult.Decision == "propose_marriage")
			context.MarriageResponse = "pending_player_choice";
		else if (aiResult.Decision == "reject_marriage")
		{
			context.RomanceLevel = Math.Max(0f, context.RomanceLevel - 10f);
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_MarriageRejected}{npcName} has rejected the marriage proposal.", new Dictionary<string, object> { { "npcName", npcName } })).ToString(), ExtraColors.RedAIInfluence));
		}
		if (!string.IsNullOrEmpty(aiResult.CharacterPersonality) && string.IsNullOrEmpty(context.AIGeneratedPersonality))
			context.AIGeneratedPersonality = aiResult.CharacterPersonality.Trim();
		if (!string.IsNullOrEmpty(aiResult.CharacterBackstory) && string.IsNullOrEmpty(context.AIGeneratedBackstory))
			context.AIGeneratedBackstory = aiResult.CharacterBackstory.Trim();
		if (!string.IsNullOrEmpty(aiResult.CharacterSpeechQuirks) && string.IsNullOrEmpty(context.AIGeneratedSpeechQuirks))
			context.AIGeneratedSpeechQuirks = aiResult.CharacterSpeechQuirks.Trim();
		CharacterInfo.UpdateEncyclopediaDescription(npc, context.AIGeneratedBackstory, context.AIGeneratedPersonality);
		context.PlayerInfo.SuspectedLie = aiResult.SuspectedLie;
		if (!string.IsNullOrEmpty(aiResult.ClaimedName)) context.PlayerInfo.ClaimedName = aiResult.ClaimedName;
		if (!string.IsNullOrEmpty(aiResult.ClaimedClan)) context.PlayerInfo.ClaimedClan = aiResult.ClaimedClan;
		if (aiResult.ClaimedAge.HasValue) context.PlayerInfo.ClaimedAge = aiResult.ClaimedAge.Value;
		if (aiResult.ClaimedGold > 0) context.PlayerInfo.ClaimedGold = aiResult.ClaimedGold;
		context.PendingAIResponse = aiResult;
		context.LastAIResponseJson = cleaned;
		context.LastDynamicResponse = reply;
		context.AddMessage(npcName + ": " + reply);
		if (Campaign.Current?.ConversationManager != null)
		{
			try { MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", reply, false); }
			catch (Exception ex) { LogMessage("[ChatWindow] SetTextVariable failed: " + ex.Message); }
		}
		bool decisionHandled = false;
		try
		{
			_decisionHandler.HandleAIDecision(context, npc, aiResult, playerMessage);
			decisionHandled = true;
		}
		catch (Exception ex3)
		{
			LogMessage("[ChatWindow] HandleAIDecision failed: " + ex3.Message);
		}
		context.LastTechnicalActionForDisplay = null;
		if (!string.IsNullOrEmpty(aiResult.TechnicalAction) && !aiResult.TechnicalAction.Equals("none", StringComparison.OrdinalIgnoreCase))
		{
			context.LastTechnicalActionForDisplay = aiResult.TechnicalAction;
			foreach (string action in aiResult.TechnicalAction.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
			{
				string[] parts = action.Trim().Split(new[] { ':' }, 2);
				string actionName = parts[0].Trim();
				string payload = parts.Length > 1 ? parts[1].Trim() : "";
			bool isStop = payload.Equals("STOP", StringComparison.OrdinalIgnoreCase);
			if (npc.IsPrisoner && !isStop)
			{
				LogMessage($"[TECHNICAL_ACTION] Skipping action '{actionName}' for prisoner {npc.Name}");
				continue;
			}
			if (isStop)
			{
				AIActionManager.Instance?.StopAction(npc, actionName, showMessage: true);
				LogMessage($"[TECHNICAL_ACTION] Stopped '{actionName}' for {npc.Name}");
			}
			else
			{
				AIActionManager.Instance?.StopAction(npc, actionName);
			if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, actionName, payload) == true)
				AIActionManager.Instance?.StartAction(npc, actionName);
			}
			}
			aiResult.TechnicalAction = null;
		}
		if (aiResult.AllowsLettersFromNPC.HasValue && aiResult.AllowsLettersFromNPC.Value != context.AllowsLettersFromNPC)
			context.AllowsLettersFromNPC = aiResult.AllowsLettersFromNPC.Value;
		if (!string.IsNullOrEmpty(aiResult.RomanceIntent) && aiResult.RomanceIntent != "none")
		{
			context.LastRomanceInteractionDays = (int)CampaignTime.Now.ToDays;
			context.RomanceLevel = Math.Min(100f, context.RomanceLevel + _random.Next(GlobalSettings<ModSettings>.Instance.MinRomanceChange, GlobalSettings<ModSettings>.Instance.MaxRomanceChange + 1) + (aiResult.RomanceIntent == "romance" ? 2 : 0));
		}
		if (!string.IsNullOrEmpty(aiResult.WorkshopAction) && aiResult.WorkshopAction.Equals("sell", StringComparison.OrdinalIgnoreCase))
			ProcessWorkshopSale(npc, context, aiResult.WorkshopStringId, aiResult.WorkshopPrice);
		if (aiResult.MoneyTransfer != null && aiResult.MoneyTransfer.Amount > 0)
			ProcessMoneyTransfer(npc, context, aiResult.MoneyTransfer);
		if (aiResult.ItemTransfers != null && aiResult.ItemTransfers.Count > 0)
			ProcessItemTransfers(npc, context, aiResult.ItemTransfers);
		if (!string.IsNullOrEmpty(aiResult.KingdomAction) && !aiResult.KingdomAction.Equals("none", StringComparison.OrdinalIgnoreCase))
			ProcessKingdomAction(npc, aiResult, context);
		if (aiResult.QuestAction != null && !string.IsNullOrEmpty(aiResult.QuestAction.Action))
		{
			QuestActionData capturedQuestAction = aiResult.QuestAction;
			GetDelayedTaskManager().AddTask(5.0, delegate { try { ProcessQuestAction(npc, GetOrCreateNPCContext(npc), capturedQuestAction); } catch (Exception ex7) { LogMessage("[ERROR] Chat quest action failed: " + ex7.Message); } });
		}
		if (aiResult.Tone == "positive")
		{
			int rel = _random.Next(GlobalSettings<ModSettings>.Instance.MinPositiveRelationChange, GlobalSettings<ModSettings>.Instance.MaxPositiveRelationChange + 1);
			ApplyRelationChangeWithDelay(npc, rel, ExtraColors.GreenAIInfluence, ((object)new TextObject("{=AIInfluence_RelationImproved}Your relations with {npcName} have improved due to your friendly tone.", new Dictionary<string, object> { { "npcName", npcName } })).ToString());
		}
		else if (aiResult.Tone == "negative")
		{
			int rel2 = _random.Next(GlobalSettings<ModSettings>.Instance.MinNegativeRelationChange, GlobalSettings<ModSettings>.Instance.MaxNegativeRelationChange + 1);
			ApplyRelationChangeWithDelay(npc, -rel2, ExtraColors.RedAIInfluence, ((object)new TextObject("{=AIInfluence_RelationWorsened}Your relations with {npcName} have worsened due to your aggressive tone.", new Dictionary<string, object> { { "npcName", npcName } })).ToString());
		}
		if (aiResult.SuspectedLie)
		{
			float trustPenalty = (float)(_random.NextDouble() * (double)(GlobalSettings<ModSettings>.Instance.MaxLieTrustPenalty - GlobalSettings<ModSettings>.Instance.MinLieTrustPenalty) + (double)GlobalSettings<ModSettings>.Instance.MinLieTrustPenalty);
			int relPenalty = _random.Next(GlobalSettings<ModSettings>.Instance.MinLieRelationPenalty, GlobalSettings<ModSettings>.Instance.MaxLieRelationPenalty + 1);
			context.LiePenaltySum += trustPenalty;
			UpdateTrustLevel(context, npc);
			ApplyRelationChangeWithDelay(npc, -relPenalty, Colors.Yellow, ((object)new TextObject("{=AIInfluence_RelationReduced}Your relations with {npcName} have worsened due to suspicions of lying.", new Dictionary<string, object> { { "npcName", npcName } })).ToString());
		}
		SaveNPCContext(npcId, npc, context);
		if (decisionHandled && string.Equals(aiResult.Decision, "attack", StringComparison.OrdinalIgnoreCase))
			InitiateCombatLogic(npc, context);
		return reply;
	}

	public async Task HandlePlayerDiplomaticInput()
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		Hero npc = Hero.OneToOneConversationHero;
		if (npc == null)
		{
			LogMessage("[ERROR] No conversation hero found for diplomatic statement.");
			return;
		}
		Hero mainHero = Hero.MainHero;
		object obj;
		if (mainHero == null)
		{
			obj = null;
		}
		else
		{
			Clan clan = mainHero.Clan;
			obj = ((clan != null) ? clan.Kingdom : null);
		}
		Kingdom playerKingdom = (Kingdom)obj;
		if (playerKingdom == null)
		{
			LogMessage("[PLAYER_DIPLO] Player does not have a kingdom");
			InformationManager.DisplayMessage(new InformationMessage("You must lead a kingdom to make diplomatic statements", ExtraColors.RedAIInfluence));
			return;
		}
		string npcName = ((object)npc.Name)?.ToString() ?? "Unknown";
		LogMessage("[PLAYER_DIPLO] Opening diplomatic statement dialog via " + npcName);
		string playerInput = await TextInput(((object)new TextObject("{=AIInfluence_DiplomaticInputTitle}Your diplomatic statement:", (Dictionary<string, object>)null)).ToString(), null, npc);
		if (string.IsNullOrEmpty(playerInput))
		{
			LogMessage("[PLAYER_DIPLO] Player cancelled or entered empty statement.");
			InformationManager.DisplayMessage(new InformationMessage("Diplomatic statement cancelled", Colors.Yellow));
			return;
		}
		LogMessage("[PLAYER_DIPLO] Player statement: " + playerInput);
		InformationManager.DisplayMessage(new InformationMessage("Analyzing your diplomatic statement...", Colors.Cyan));
		try
		{
			await DiplomacyManager.Instance.ProcessPlayerStatement(playerInput);
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Failed to process diplomatic statement: " + ex.Message);
			InformationManager.DisplayMessage(new InformationMessage("Failed to process your diplomatic statement. Please try again.", ExtraColors.RedAIInfluence));
		}
	}

	private void UpdateTrustLevel(NPCContext context, Hero npc)
	{
		if (GlobalSettings<ModSettings>.Instance.UseAdvancedTrust)
		{
			int num = context.PlayerRelation?.Value ?? 0;
			float num2 = (float)Math.Tanh((double)num / 100.0) * 0.6f;
			float num3 = (float)context.InteractionCount * GlobalSettings<ModSettings>.Instance.InteractionTrustBonus;
			float num4 = (context.IsPlayerKnown ? GlobalSettings<ModSettings>.Instance.FamiliarityTrustBonus : 0f);
			float liePenaltySum = context.LiePenaltySum;
			float trustLevel = Math.Max(0f, Math.Min(1f, num2 + num3 + num4 - liePenaltySum));
			context.TrustLevel = trustLevel;
		}
		else
		{
			int num5 = context.PlayerRelation?.Value ?? 0;
			float liePenaltySum2 = context.LiePenaltySum;
			float num6 = Math.Max(0f, Math.Min(1f, (float)num5 / 100f - liePenaltySum2));
			LogMessage($"[DEBUG] Basic trust level: {num6:F2} (Relation: {num5}, LiePenalty: {liePenaltySum2:F2})");
			context.TrustLevel = num6;
		}
	}

	private void UpdateDiseaseInfoForNPC(NPCContext context, Hero npc)
	{
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DiseaseManager instance = DiseaseManager.Instance;
			if (instance == null || !GlobalSettings<ModSettings>.Instance.EnableDiseaseSystem)
			{
				context.IsSick = false;
				context.CurrentDiseases = new List<NPCDiseaseInfo>();
				context.DiseaseProgress = 0f;
				context.IsTreated = false;
				return;
			}
			List<DiseaseInstance> heroDiseases = instance.GetHeroDiseases(npc);
			if (heroDiseases == null || heroDiseases.Count == 0)
			{
				context.IsSick = false;
				context.CurrentDiseases = new List<NPCDiseaseInfo>();
				context.DiseaseProgress = 0f;
				context.IsTreated = false;
				return;
			}
			context.IsSick = true;
			context.CurrentDiseases = new List<NPCDiseaseInfo>();
			float num = 0f;
			bool isTreated = false;
			foreach (DiseaseInstance item2 in heroDiseases)
			{
				Disease diseaseById = instance.GetDiseaseById(item2.DiseaseId);
				if (diseaseById != null)
				{
					NPCDiseaseInfo obj = new NPCDiseaseInfo
					{
						Name = (diseaseById.Name ?? "Unknown disease"),
						Severity = diseaseById.Severity,
						Progress = item2.DiseaseProgress,
						IsTreated = item2.IsTreated
					};
					CampaignTime now = CampaignTime.Now;
					obj.DaysInfected = (int)((now).ToDays - (double)item2.InfectedAt);
					NPCDiseaseInfo item = obj;
					context.CurrentDiseases.Add(item);
					num += item2.DiseaseProgress;
					if (item2.IsTreated)
					{
						isTreated = true;
					}
				}
			}
			context.DiseaseProgress = ((heroDiseases.Count > 0) ? (num / (float)heroDiseases.Count) : 0f);
			context.IsTreated = isTreated;
		}
		catch (Exception ex)
		{
			LogMessage($"[ERROR] UpdateDiseaseInfoForNPC failed for {((npc != null) ? npc.Name : null)}: {ex.Message}");
			context.IsSick = false;
			context.CurrentDiseases = new List<NPCDiseaseInfo>();
			context.DiseaseProgress = 0f;
			context.IsTreated = false;
		}
	}

	public void UpdateContextData(NPCContext context, Hero npc)
	{
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		context.PlayerInfo.RealName = ((object)Hero.MainHero.Name).ToString();
		PlayerInfo playerInfo = context.PlayerInfo;
		Clan clan = Hero.MainHero.Clan;
		playerInfo.RealClan = ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "No clan";
		context.PlayerInfo.RealAge = (int)Hero.MainHero.Age;
		PlayerInfo playerInfo2 = context.PlayerInfo;
		CultureObject culture = Hero.MainHero.Culture;
		playerInfo2.RealCulture = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown culture";
		context.PlayerInfo.RealGender = (Hero.MainHero.IsFemale ? "female" : "male");
		context.PlayerInfo.PlayerStringId = ((MBObjectBase)Hero.MainHero).StringId ?? "";
		Clan clan2 = Hero.MainHero.Clan;
		if (((clan2 != null) ? clan2.Kingdom : null) != null)
		{
			context.PlayerInfo.RealKingdom = ((object)Hero.MainHero.Clan.Kingdom.Name).ToString();
			context.PlayerInfo.RealKingdomId = ((MBObjectBase)Hero.MainHero.Clan.Kingdom).StringId ?? "";
			context.PlayerInfo.IsMercenary = Hero.MainHero.Clan.IsUnderMercenaryService;
		}
		else
		{
			context.PlayerInfo.RealKingdom = null;
			context.PlayerInfo.RealKingdomId = null;
			context.PlayerInfo.IsMercenary = false;
		}
		WorldInfoManager.Instance.UpdatePlayerRelation(context, npc);
		WorldInfoManager.Instance.UpdateCurrentTask(context, npc);
		WorldInfoManager.Instance.UpdateEmotionalState(context, npc);
		WorldInfoManager.Instance.UpdateLocationType(context, npc);
		WorldInfoManager.Instance.UpdatePlayerForces(context);
		WorldInfoManager.Instance.UpdateNPCForces(context, npc);
		WorldInfoManager.Instance.UpdateInformationAccessLevel(context, npc);
		UpdateTrustLevel(context, npc);
		context.IsInPlayerParty = npc.PartyBelongedTo == Hero.MainHero.PartyBelongedTo;
		context.IsWithPlayer = IsNPCWithPlayer(npc);
		TrackSettlementVisit(context, npc);
		if (!context.IsPlayerKnown)
		{
			string relativesInfo = PromptGenerator.GetRelativesInfo(npc);
			string playerName = context.PlayerInfo.RealName;
			if (relativesInfo.Split(new char[1] { ';' }).Any((string r) => r.Contains(playerName)))
			{
				context.IsPlayerKnown = true;
				context.PlayerInfo.ClaimedName = context.PlayerInfo.RealName;
				context.PlayerInfo.ClaimedClan = context.PlayerInfo.RealClan;
				context.PlayerInfo.ClaimedAge = context.PlayerInfo.RealAge;
				LogMessage("[DEBUG] Player recognized as relative during update: " + context.PlayerInfo.ClaimedName);
			}
			else if (GlobalSettings<ModSettings>.Instance.CompanionAutoRecognize && npc.IsPlayerCompanion)
			{
				context.IsPlayerKnown = true;
				context.PlayerInfo.ClaimedName = context.PlayerInfo.RealName;
				context.PlayerInfo.ClaimedClan = context.PlayerInfo.RealClan;
				context.PlayerInfo.ClaimedAge = context.PlayerInfo.RealAge;
				LogMessage("[DEBUG] Player recognized as companion during update: " + context.PlayerInfo.ClaimedName);
			}
			else if (GlobalSettings<ModSettings>.Instance.KingdomAutoRecognize && Hero.MainHero.IsKingdomLeader && npc.MapFaction != null && npc.MapFaction == Hero.MainHero.MapFaction)
			{
				context.IsPlayerKnown = true;
				context.PlayerInfo.ClaimedName = context.PlayerInfo.RealName;
				context.PlayerInfo.ClaimedClan = context.PlayerInfo.RealClan;
				context.PlayerInfo.ClaimedAge = context.PlayerInfo.RealAge;
				LogMessage("[DEBUG] Player recognized as kingdom leader during update: " + context.PlayerInfo.ClaimedName);
			}
		}
		bool flag = GlobalSettings<ModSettings>.Instance.AllowRomanceWithMarried || (npc.Spouse == null && Hero.MainHero.Spouse == null);
		context.IsRomanceEligible = !npc.IsPrisoner && flag && !PromptGenerator.AreRelated(npc, Hero.MainHero) && context.PlayerInfo.RealGender != (npc.IsFemale ? "female" : "male");
		if (context.TimeContext != null)
		{
			CampaignTime val = CampaignTime.Now - context.TimeContext.LastUpdated;
			if (!((val).ToHours >= 2.0))
			{
				goto IL_04ea;
			}
		}
		WorldInfoManager.Instance.UpdateTimeContext(context);
		goto IL_04ea;
		IL_04ea:
		int num = context.RecentEvents?.Count ?? 0;
		WorldInfoManager.Instance.CleanOldEvents(context);
		int num2 = context.RecentEvents?.Count ?? 0;
		if (num != num2)
		{
			LogMessage($"[CONTEXT] Cleaned events for {npc.Name}: {num} → {num2} (removed {num - num2})");
		}
		UpdateDiseaseInfoForNPC(context, npc);
		SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		LogMessage($"[CONTEXT] Updated and saved context data for {npc.Name}. Events count: {context.RecentEvents?.Count ?? 0}. Player info: Name={context.PlayerInfo.RealName}, Clan={context.PlayerInfo.RealClan}, Age={context.PlayerInfo.RealAge}, Culture={context.PlayerInfo.RealCulture}");
	}

	public NPCContext GetOrCreateNPCContext(Hero npc)
	{
		string stringId = ((MBObjectBase)npc).StringId;
		LogMessage($"[DEBUG] Retrieving NPC context for {npc.Name} (ID: {stringId})");
		if (_npcContexts.ContainsKey(stringId))
		{
			NPCContext nPCContext = _npcContexts[stringId];
			string text = ((object)npc.Name)?.ToString() ?? "Unknown_NPC";
			if (nPCContext.Name != text)
			{
				LogMessage("[DEBUG] Hero name changed from '" + nPCContext.Name + "' to '" + text + "' for " + stringId);
				nPCContext.Name = text;
				SaveNPCContext(stringId, npc, nPCContext);
			}
			bool isRomanceEligible = nPCContext.IsRomanceEligible;
			bool flag = GlobalSettings<ModSettings>.Instance.AllowRomanceWithMarried || (npc.Spouse == null && Hero.MainHero.Spouse == null);
			nPCContext.IsRomanceEligible = !npc.IsPrisoner && flag && !PromptGenerator.AreRelated(npc, Hero.MainHero) && nPCContext.PlayerInfo.RealGender != (npc.IsFemale ? "female" : "male");
			if (isRomanceEligible != nPCContext.IsRomanceEligible)
			{
				LogMessage($"[DEBUG] IsRomanceEligible changed for {stringId}: {isRomanceEligible} -> {nPCContext.IsRomanceEligible}");
			}
			NPCContext nPCContext2 = LoadNPCContext(stringId);
			if (nPCContext2 != null)
			{
				if (nPCContext2.AIGeneratedPersonality != null && string.IsNullOrEmpty(nPCContext2.AIGeneratedPersonality))
				{
					nPCContext.AIGeneratedPersonality = null;
					LogMessage("[DEBUG] Converted empty AIGeneratedPersonality to null for " + stringId + " (from file)");
				}
				else if (nPCContext2.AIGeneratedPersonality != null)
				{
					nPCContext.AIGeneratedPersonality = nPCContext2.AIGeneratedPersonality;
				}
				else if (nPCContext.AIGeneratedPersonality != null && string.IsNullOrEmpty(nPCContext.AIGeneratedPersonality))
				{
					nPCContext.AIGeneratedPersonality = null;
					LogMessage("[DEBUG] Converted empty AIGeneratedPersonality to null for " + stringId + " (from memory)");
				}
				if (nPCContext2.AIGeneratedBackstory != null && string.IsNullOrEmpty(nPCContext2.AIGeneratedBackstory))
				{
					nPCContext.AIGeneratedBackstory = null;
					LogMessage("[DEBUG] Converted empty AIGeneratedBackstory to null for " + stringId + " (from file)");
				}
				else if (nPCContext2.AIGeneratedBackstory != null)
				{
					nPCContext.AIGeneratedBackstory = nPCContext2.AIGeneratedBackstory;
				}
				else if (nPCContext.AIGeneratedBackstory != null && string.IsNullOrEmpty(nPCContext.AIGeneratedBackstory))
				{
					nPCContext.AIGeneratedBackstory = null;
					LogMessage("[DEBUG] Converted empty AIGeneratedBackstory to null for " + stringId + " (from memory)");
				}
				if (nPCContext2.AIGeneratedSpeechQuirks != null && string.IsNullOrEmpty(nPCContext2.AIGeneratedSpeechQuirks))
				{
					nPCContext.AIGeneratedSpeechQuirks = null;
					LogMessage("[DEBUG] Converted empty AIGeneratedSpeechQuirks to null for " + stringId + " (from file)");
				}
				else if (nPCContext2.AIGeneratedSpeechQuirks != null)
				{
					nPCContext.AIGeneratedSpeechQuirks = nPCContext2.AIGeneratedSpeechQuirks;
				}
				else if (nPCContext.AIGeneratedSpeechQuirks != null && string.IsNullOrEmpty(nPCContext.AIGeneratedSpeechQuirks))
				{
					nPCContext.AIGeneratedSpeechQuirks = null;
					LogMessage("[DEBUG] Converted empty AIGeneratedSpeechQuirks to null for " + stringId + " (from memory)");
				}
				if (!string.IsNullOrEmpty(nPCContext2.AssignedTTSVoice) && nPCContext2.AssignedTTSVoice != nPCContext.AssignedTTSVoice)
				{
					LogMessage("[TTS] Voice updated from file for " + stringId + ": '" + nPCContext.AssignedTTSVoice + "' → '" + nPCContext2.AssignedTTSVoice + "'");
					nPCContext.AssignedTTSVoice = nPCContext2.AssignedTTSVoice;
				}
			}
			else
			{
				if (nPCContext.AIGeneratedPersonality != null && string.IsNullOrEmpty(nPCContext.AIGeneratedPersonality))
				{
					nPCContext.AIGeneratedPersonality = null;
					LogMessage("[DEBUG] Converted empty AIGeneratedPersonality to null for " + stringId + " (from memory, no file)");
				}
				if (nPCContext.AIGeneratedBackstory != null && string.IsNullOrEmpty(nPCContext.AIGeneratedBackstory))
				{
					nPCContext.AIGeneratedBackstory = null;
					LogMessage("[DEBUG] Converted empty AIGeneratedBackstory to null for " + stringId + " (from memory, no file)");
				}
				if (nPCContext.AIGeneratedSpeechQuirks != null && string.IsNullOrEmpty(nPCContext.AIGeneratedSpeechQuirks))
				{
					nPCContext.AIGeneratedSpeechQuirks = null;
					LogMessage("[DEBUG] Converted empty AIGeneratedSpeechQuirks to null for " + stringId + " (from memory, no file)");
				}
			}
			CharacterInfo.UpdateEncyclopediaDescription(npc, nPCContext.AIGeneratedBackstory, nPCContext.AIGeneratedPersonality);
			EnsureValidTTSVoice(nPCContext, npc);
			LogMessage("[DEBUG] Found existing context for " + stringId);
			return nPCContext;
		}
		return CreateNPCContextWithoutSave(npc, stringId);
	}

	private NPCContext CreateNPCContextWithoutSave(Hero npc, string npcId)
	{
		NPCContext nPCContext = LoadNPCContext(npcId);
		if (string.IsNullOrEmpty(nPCContext.Name) || nPCContext.Name == "Unknown_NPC")
		{
			nPCContext.Name = ((object)npc.Name)?.ToString() ?? "Unknown_NPC";
			LogMessage("[WARNING] Assigned name " + nPCContext.Name + " to NPC " + npcId);
		}
		nPCContext.StringId = npcId;
		nPCContext.Gender = (npc.IsFemale ? "female" : "male");
		EnsureValidTTSVoice(nPCContext, npc);
		nPCContext.PlayerInfo.RealName = ((object)Hero.MainHero.Name).ToString();
		PlayerInfo playerInfo = nPCContext.PlayerInfo;
		Clan clan = Hero.MainHero.Clan;
		playerInfo.RealClan = ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "No clan";
		nPCContext.PlayerInfo.RealAge = (int)Hero.MainHero.Age;
		PlayerInfo playerInfo2 = nPCContext.PlayerInfo;
		CultureObject culture = Hero.MainHero.Culture;
		playerInfo2.RealCulture = ((culture == null) ? null : ((object)((BasicCultureObject)culture).Name)?.ToString()) ?? "Unknown culture";
		nPCContext.PlayerInfo.RealGender = (Hero.MainHero.IsFemale ? "female" : "male");
		nPCContext.PlayerInfo.PlayerStringId = ((MBObjectBase)Hero.MainHero).StringId ?? "";
		Clan clan2 = Hero.MainHero.Clan;
		if (((clan2 != null) ? clan2.Kingdom : null) != null)
		{
			nPCContext.PlayerInfo.RealKingdom = ((object)Hero.MainHero.Clan.Kingdom.Name).ToString();
			nPCContext.PlayerInfo.RealKingdomId = ((MBObjectBase)Hero.MainHero.Clan.Kingdom).StringId ?? "";
			nPCContext.PlayerInfo.IsMercenary = Hero.MainHero.Clan.IsUnderMercenaryService;
		}
		else
		{
			nPCContext.PlayerInfo.RealKingdom = null;
			nPCContext.PlayerInfo.RealKingdomId = null;
			nPCContext.PlayerInfo.IsMercenary = false;
		}
		if (nPCContext.CharacterDescription == null)
		{
			nPCContext.CharacterDescription = "";
			LogMessage("[DEBUG] Initialized CharacterDescription for " + nPCContext.Name + " to empty string.");
		}
		nPCContext.IsInPlayerParty = npc.PartyBelongedTo == Hero.MainHero.PartyBelongedTo;
		nPCContext.IsWithPlayer = IsNPCWithPlayer(npc);
		bool flag = GlobalSettings<ModSettings>.Instance.AllowRomanceWithMarried || (npc.Spouse == null && Hero.MainHero.Spouse == null);
		nPCContext.IsRomanceEligible = !npc.IsPrisoner && flag && !PromptGenerator.AreRelated(npc, Hero.MainHero) && nPCContext.PlayerInfo.RealGender != (npc.IsFemale ? "female" : "male");
		if (nPCContext.LastRomanceInteractionDays == 0)
		{
			nPCContext.LastRomanceInteractionDays = -1;
		}
		string relativesInfo = PromptGenerator.GetRelativesInfo(npc);
		string playerName = nPCContext.PlayerInfo.RealName;
		bool flag2 = relativesInfo.Split(new char[1] { ';' }).Any((string r) => r.Contains(playerName));
		bool flag3 = false;
		string text = "";
		if (flag2)
		{
			flag3 = true;
			text = "relative";
		}
		else if (GlobalSettings<ModSettings>.Instance.CompanionAutoRecognize && npc.IsPlayerCompanion)
		{
			flag3 = true;
			text = "companion";
		}
		else if (GlobalSettings<ModSettings>.Instance.KingdomAutoRecognize && Hero.MainHero.IsKingdomLeader && npc.MapFaction != null && npc.MapFaction == Hero.MainHero.MapFaction)
		{
			flag3 = true;
			text = "kingdom_member";
		}
		else if (GlobalSettings<ModSettings>.Instance.ClanTierAutoRecognize && !nPCContext.ClanTierRecognitionChecked)
		{
			Clan clan3 = Hero.MainHero.Clan;
			if (((clan3 != null) ? new int?(clan3.Tier) : ((int?)null)) >= GlobalSettings<ModSettings>.Instance.ClanTierThreshold)
			{
				Random random = new Random();
				float num = random.Next(0, 101);
				if (num <= GlobalSettings<ModSettings>.Instance.ClanTierRecognitionChance)
				{
					flag3 = true;
					text = "";
				}
				nPCContext.ClanTierRecognitionChecked = true;
			}
		}
		if (flag3)
		{
			nPCContext.IsPlayerKnown = true;
			nPCContext.PlayerInfo.ClaimedName = nPCContext.PlayerInfo.RealName;
			nPCContext.PlayerInfo.ClaimedClan = nPCContext.PlayerInfo.RealClan;
			nPCContext.PlayerInfo.ClaimedAge = nPCContext.PlayerInfo.RealAge;
			LogMessage("[DEBUG] Player recognized as " + text + ": " + nPCContext.PlayerInfo.ClaimedName + " of " + nPCContext.PlayerInfo.ClaimedClan);
		}
		UpdateContextData(nPCContext, npc);
		InitializeActiveEventsForNPC(nPCContext, npc);
		LogMessage($"[DEBUG] Initialized NPC context with real player info: Name={nPCContext.PlayerInfo.RealName}, Clan={nPCContext.PlayerInfo.RealClan}, Age={nPCContext.PlayerInfo.RealAge}, Culture={nPCContext.PlayerInfo.RealCulture}, Gender={nPCContext.PlayerInfo.RealGender}");
		_npcContexts[npcId] = nPCContext;
		UpdateStringIdIndex(npcId, npcId);
		return nPCContext;
	}

	private void InitializeActiveEventsForNPC(NPCContext context, Hero npc)
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<DynamicEvent> activeEvents = DynamicEventsManager.Instance.GetActiveEvents();
			int num = 0;
			foreach (DynamicEvent dynamicEvent in activeEvents)
			{
				if (dynamicEvent.CharactersInvolved != null && dynamicEvent.CharactersInvolved.Contains(((MBObjectBase)npc).StringId) && !context.RecentEvents.Any((CampaignEvent e) => e.Description == dynamicEvent.Description && e.Type == dynamicEvent.Type))
				{
					CampaignEvent item = new CampaignEvent
					{
						Type = dynamicEvent.Type,
						Description = dynamicEvent.Description,
						Timestamp = CampaignTime.DaysFromNow((float)(-dynamicEvent.DaysSinceCreation))
					};
					context.RecentEvents.Add(item);
					num++;
					LogMessage($"[NPC_CONTEXT_INIT] Added active event '{dynamicEvent.Description}' to {npc.Name} context");
				}
			}
			if (num > 0)
			{
				LogMessage($"[NPC_CONTEXT_INIT] Initialized {num} active events for {npc.Name}");
			}
		}
		catch (Exception ex)
		{
			LogMessage($"[ERROR] Failed to initialize active events for NPC {npc.Name}: {ex.Message}");
		}
	}

	public string FindNPCFileByStringId(string saveDir, string stringId)
	{
		try
		{
			if (string.IsNullOrEmpty(saveDir) || !Directory.Exists(saveDir))
			{
				return null;
			}
			if (stringId == "diseases" || stringId == "disease_instances" || stringId == "settlement_disease_instances")
			{
				return null;
			}
			if (_npcFilePathCache.TryGetValue(stringId, out var value))
			{
				if (File.Exists(value))
				{
					return value;
				}
				_npcFilePathCache.Remove(stringId);
			}
			if (_npcFilePathCache.Count < 10)
			{
				string[] files = Directory.GetFiles(saveDir, "*.json");
				string[] array = files;
				foreach (string text in array)
				{
					try
					{
						string fileName = Path.GetFileName(text);
						switch (fileName)
						{
						case "diplomatic_statements.json":
							continue;
						case "economic_effects.json":
							continue;
						case "settlement_ownership_history.json":
							continue;
						case "kingdom_leadership_history.json":
							continue;
						case "war_statistics.json":
							continue;
						case "diplomatic_events.json":
							continue;
						case "pending_player_statements.json":
							continue;
						case "alliances.json":
							continue;
						case "alliance_data.json":
							continue;
						case "trade_agreements.json":
							continue;
						case "territory_transfers.json":
							continue;
						case "tribute_agreements.json":
							continue;
						case "tributes.json":
							continue;
						case "rp_items.json":
							continue;
						case "reparations.json":
							continue;
						case "disease_instances.json":
							continue;
						case "diseases.json":
							continue;
						}
						if (fileName == "settlement_disease_instances.json")
						{
							continue;
						}
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
						if (_npcFilePathCache.ContainsKey(fileNameWithoutExtension))
						{
							continue;
						}
						string text2 = File.ReadAllText(text);
						NPCContext nPCContext = JsonConvert.DeserializeObject<NPCContext>(text2);
						if (nPCContext?.StringId != null)
						{
							_npcFilePathCache[nPCContext.StringId] = text;
							if (nPCContext.StringId == stringId)
							{
								return text;
							}
						}
					}
					catch (JsonException)
					{
					}
					catch (IOException)
					{
					}
					catch (Exception)
					{
					}
				}
			}
			else
			{
				string text3 = Path.Combine(saveDir, stringId + ".json");
				if (File.Exists(text3))
				{
					_npcFilePathCache[stringId] = text3;
					return text3;
				}
				if (_npcFilePathCache.TryGetValue(stringId, out var value2))
				{
					return value2;
				}
			}
			return null;
		}
		catch (Exception ex4)
		{
			LogMessage("[ERROR] Error searching for NPC file by StringId " + stringId + ": " + ex4.Message);
			return null;
		}
	}

	public NPCContext LoadNPCContext(string npcId)
	{
		try
		{
			if (string.IsNullOrEmpty(npcId))
			{
				LogMessage("[ERROR] LoadNPCContext called with empty npcId. Returning empty context.");
				return new NPCContext();
			}
			if (npcId == "diseases" || npcId == "disease_instances" || npcId == "settlement_disease_instances")
			{
				return new NPCContext();
			}
			if (_npcContexts.TryGetValue(npcId, out var cached))
			{
				if (cached.ConversationHistory == null) cached.ConversationHistory = new List<string>();
				if (cached.RecentEvents == null) cached.RecentEvents = new List<CampaignEvent>();
				if (cached.ProcessedMessageHashes == null) cached.ProcessedMessageHashes = new HashSet<string>();
				return cached;
			}
			NPCContext newContext = new NPCContext
			{
				StringId = npcId
			};
			_npcContexts[npcId] = newContext;
			UpdateStringIdIndex(npcId, npcId);
			return newContext;
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Failed to load NPC context for " + npcId + ": " + ex);
			return new NPCContext
			{
				StringId = npcId ?? string.Empty
			};
		}
	}

	private void EnsureQuestTargetContextFileExists(string npcId, Hero npc)
	{
		if (npc == null || string.IsNullOrEmpty(npcId))
		{
			return;
		}
		string activeSaveDirectory = GetActiveSaveDirectory();
		if (string.IsNullOrEmpty(activeSaveDirectory) || !Directory.Exists(activeSaveDirectory))
		{
			return;
		}
		string text = FindNPCFileByStringId(activeSaveDirectory, npcId);
		if (!string.IsNullOrEmpty(text) && File.Exists(text))
		{
			return;
		}
		try
		{
			string text2 = ((object)npc.Name).ToString().Replace(" ", "_").Replace("/", "")
				.Replace("\\", "_")
				.Replace("?", "");
			string text3 = Path.Combine(activeSaveDirectory, text2 + " (" + ((MBObjectBase)npc).StringId + ").json");
			NPCContext nPCContext = new NPCContext
			{
				StringId = npcId,
				Name = (((object)npc.Name)?.ToString() ?? "Unknown_NPC"),
				IncomingAIQuests = new List<AIQuestInfo>()
			};
			string contents = JsonConvert.SerializeObject((object)nPCContext, (Formatting)1);
			File.WriteAllText(text3, contents);
			_npcFilePathCache[npcId] = text3;
			LogMessage($"[QUEST] Created context file for quest target {npc.Name} ({npcId})");
		}
		catch (Exception ex)
		{
			LogMessage("[QUEST] Failed to create context file for target " + npcId + ": " + ex.Message);
		}
	}

	public void SaveNPCContext(string npcId, Hero npc, NPCContext context)
	{
		if (string.IsNullOrEmpty(npcId))
		{
			LogMessage("[ERROR] SaveNPCContext called with empty npcId.");
			throw new ArgumentException("npcId must not be null or empty.", "npcId");
		}
		if (context == null)
		{
			LogMessage("[ERROR] SaveNPCContext called with null context for npcId=" + npcId + ".");
			throw new ArgumentNullException("context");
		}
		_npcContexts[npcId] = context;
		if (!string.IsNullOrEmpty(context.StringId))
		{
			UpdateStringIdIndex(npcId, context.StringId);
		}
	}

	public void SaveNPCContextImmediate(string npcId, Hero npc, NPCContext context)
	{
		//IL_01ff: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (string.IsNullOrEmpty(_currentSaveFolder))
			{
				_currentSaveFolder = GetActiveSaveDirectory();
			}
			string text = ((object)npc.Name).ToString().Replace(" ", "_").Replace("/", "")
				.Replace("\\", "_")
				.Replace("?", "");
			string text2 = Path.Combine(_currentSaveFolder, text + " (" + ((MBObjectBase)npc).StringId + ").json");
			string text3 = FindNPCFileByStringId(_currentSaveFolder, context.StringId);
			bool flag = !string.IsNullOrEmpty(text3) && text3 != text2;
			if (string.IsNullOrEmpty(text3) || text3 != text2)
			{
				_npcFilePathCache[context.StringId] = text2;
			}
			bool flag2 = !File.Exists(text3 ?? text2);
			if (flag2)
			{
				bool flag3 = context.InteractionCount > 0 || (context.LastInteractionTime != CampaignTime.Never && context.LastInteractionTimeDays >= 0.0);
				if (!flag3 && GlobalSettings<ModSettings>.Instance.EnableNearbyNPCInitialization && context.IsPlayerKnown)
				{
					flag3 = true;
				}
				if (!flag3)
				{
					LogMessage($"[NPC] Skipping save for temporary context: {npc.Name} (id:{npcId}) - file doesn't exist and context wasn't properly initialized (InteractionCount={context.InteractionCount}, LastInteractionTimeDays={context.LastInteractionTimeDays})");
					return;
				}
			}
			_npcContexts.TryGetValue(npcId, out NPCContext nPCContext);
			if (nPCContext != null && !ReferenceEquals(nPCContext, context))
			{
				if (nPCContext.ConversationHistory != null && nPCContext.ConversationHistory.Any())
				{
					bool flag4 = false;
					if (context.ConversationHistory != null && context.ConversationHistory.Any())
					{
						foreach (string item in context.ConversationHistory)
						{
							if (!nPCContext.ConversationHistory.Contains(item))
							{
								flag4 = true;
								break;
							}
						}
					}
					if (flag4)
					{
						List<string> list = new List<string>(nPCContext.ConversationHistory);
						foreach (string item2 in context.ConversationHistory)
						{
							if (!list.Contains(item2))
							{
								list.Add(item2);
							}
						}
						context.ConversationHistory = list;
						LogMessage($"[NPC] Merged conversation history for {npcId}: {context.ConversationHistory.Count} total messages (added {list.Count - nPCContext.ConversationHistory.Count} new)");
					}
					else
					{
						context.ConversationHistory = nPCContext.ConversationHistory;
						LogMessage($"[NPC] Preserved existing conversation history for {npcId}: {context.ConversationHistory.Count} messages (no new messages to add)");
					}
				}
				context.InteractionCount = Math.Max(context.InteractionCount, nPCContext.InteractionCount);
				if (Math.Abs(context.TrustLevel - nPCContext.TrustLevel) < 0.01f || context.InteractionCount <= nPCContext.InteractionCount)
				{
					context.TrustLevel = nPCContext.TrustLevel;
				}
				else
				{
					LogMessage($"[NPC] TrustLevel changed: {nPCContext.TrustLevel:F3} -> {context.TrustLevel:F3} for {npcId}");
				}
				context.LiePenaltySum = nPCContext.LiePenaltySum;
				if (context.RomanceLevel > nPCContext.RomanceLevel)
				{
					LogMessage($"[NPC] RomanceLevel increased: {nPCContext.RomanceLevel:F1} -> {context.RomanceLevel:F1} for {npcId}");
				}
				else
				{
					context.RomanceLevel = nPCContext.RomanceLevel;
				}
				if (context.LastRomanceInteractionDays > nPCContext.LastRomanceInteractionDays)
				{
					LogMessage($"[NPC] LastRomanceInteractionDays updated: {nPCContext.LastRomanceInteractionDays} -> {context.LastRomanceInteractionDays} for {npcId}");
				}
				else if (nPCContext.LastRomanceInteractionDays > 0)
				{
					context.LastRomanceInteractionDays = nPCContext.LastRomanceInteractionDays;
				}
				if (nPCContext.RecentEvents != null && nPCContext.RecentEvents.Any() && (context.RecentEvents == null || context.RecentEvents.Count >= nPCContext.RecentEvents.Count))
				{
					bool flag5 = false;
					if (context.RecentEvents != null && context.RecentEvents.Any())
					{
						foreach (CampaignEvent newEvent in context.RecentEvents)
						{
							if (!nPCContext.RecentEvents.Any((CampaignEvent e) => e.Description == newEvent.Description && e.Type == newEvent.Type))
							{
								flag5 = true;
								break;
							}
						}
					}
					if (flag5)
					{
						List<CampaignEvent> list2 = new List<CampaignEvent>(nPCContext.RecentEvents);
						foreach (CampaignEvent newEvent2 in context.RecentEvents)
						{
							if (!list2.Any((CampaignEvent e) => e.Description == newEvent2.Description && e.Type == newEvent2.Type))
							{
								list2.Add(newEvent2);
							}
						}
						context.RecentEvents = list2;
					}
					else
					{
						context.RecentEvents = nPCContext.RecentEvents;
					}
				}
				if (nPCContext.DialogueAnalysisEvents != null && nPCContext.DialogueAnalysisEvents.Any())
				{
					bool flag6 = false;
					if (context.DialogueAnalysisEvents != null && context.DialogueAnalysisEvents.Any())
					{
						foreach (CampaignEvent newEvent3 in context.DialogueAnalysisEvents)
						{
							if (!nPCContext.DialogueAnalysisEvents.Any((CampaignEvent e) => e.Description == newEvent3.Description && e.Type == newEvent3.Type))
							{
								flag6 = true;
								break;
							}
						}
					}
					if (flag6)
					{
						List<CampaignEvent> list3 = new List<CampaignEvent>(nPCContext.DialogueAnalysisEvents);
						foreach (CampaignEvent newEvent4 in context.DialogueAnalysisEvents)
						{
							if (!list3.Any((CampaignEvent e) => e.Description == newEvent4.Description && e.Type == newEvent4.Type))
							{
								list3.Add(newEvent4);
							}
						}
						context.DialogueAnalysisEvents = list3;
						LogMessage($"[NPC] Merged DialogueAnalysisEvents for {npcId}: {context.DialogueAnalysisEvents.Count} total events");
					}
					else
					{
						context.DialogueAnalysisEvents = nPCContext.DialogueAnalysisEvents;
					}
				}
				if (!string.IsNullOrEmpty(nPCContext.CharacterDescription))
				{
					context.CharacterDescription = nPCContext.CharacterDescription;
					LogMessage("[NPC] Preserved CharacterDescription for " + npcId + ": '" + context.CharacterDescription + "'");
				}
				if (nPCContext.Quirks != null && nPCContext.Quirks.Any())
				{
					context.Quirks = nPCContext.Quirks;
					LogMessage($"[NPC] Preserved Quirks for {npcId}: {context.Quirks.Count} items");
				}
				if (nPCContext.KnownSecrets != null)
				{
					List<string> list4 = new List<string>(nPCContext.KnownSecrets);
					if (context.KnownSecrets != null && context.KnownSecrets.Any())
					{
						foreach (string knownSecret in context.KnownSecrets)
						{
							if (!list4.Contains(knownSecret))
							{
								list4.Add(knownSecret);
							}
						}
					}
					context.KnownSecrets = list4;
					if (!list4.Any())
					{
					}
				}
				if (nPCContext.KnownInfo != null)
				{
					List<string> list5 = new List<string>(nPCContext.KnownInfo);
					if (context.KnownInfo != null && context.KnownInfo.Any())
					{
						foreach (string item3 in context.KnownInfo)
						{
							if (!list5.Contains(item3))
							{
								list5.Add(item3);
							}
						}
					}
					context.KnownInfo = list5;
					if (!list5.Any())
					{
					}
				}
				if (nPCContext.AIGeneratedPersonality != null && !string.IsNullOrEmpty(nPCContext.AIGeneratedPersonality))
				{
					context.AIGeneratedPersonality = nPCContext.AIGeneratedPersonality;
				}
				else if (nPCContext.AIGeneratedPersonality != null && string.IsNullOrEmpty(nPCContext.AIGeneratedPersonality))
				{
					context.AIGeneratedPersonality = null;
					LogMessage("[NPC] Converted empty AIGeneratedPersonality to null for " + npcId + " (user wants regeneration)");
				}
				else if (!string.IsNullOrEmpty(context.AIGeneratedPersonality))
				{
					LogMessage($"[NPC] Saving new AIGeneratedPersonality for {npcId} ({context.AIGeneratedPersonality.Length} chars)");
				}
				else
				{
					context.AIGeneratedPersonality = null;
				}
				if (nPCContext.AIGeneratedBackstory != null && !string.IsNullOrEmpty(nPCContext.AIGeneratedBackstory))
				{
					context.AIGeneratedBackstory = nPCContext.AIGeneratedBackstory;
				}
				else if (nPCContext.AIGeneratedBackstory != null && string.IsNullOrEmpty(nPCContext.AIGeneratedBackstory))
				{
					context.AIGeneratedBackstory = null;
					LogMessage("[NPC] Converted empty AIGeneratedBackstory to null for " + npcId + " (user wants regeneration)");
				}
				else if (!string.IsNullOrEmpty(context.AIGeneratedBackstory))
				{
					LogMessage($"[NPC] Saving new AIGeneratedBackstory for {npcId} ({context.AIGeneratedBackstory.Length} chars)");
				}
				else
				{
					context.AIGeneratedBackstory = null;
				}
				if (nPCContext.AIGeneratedSpeechQuirks != null && !string.IsNullOrEmpty(nPCContext.AIGeneratedSpeechQuirks))
				{
					context.AIGeneratedSpeechQuirks = nPCContext.AIGeneratedSpeechQuirks;
				}
				else if (nPCContext.AIGeneratedSpeechQuirks != null && string.IsNullOrEmpty(nPCContext.AIGeneratedSpeechQuirks))
				{
					context.AIGeneratedSpeechQuirks = null;
					LogMessage("[NPC] Converted empty AIGeneratedSpeechQuirks to null for " + npcId + " (user wants regeneration)");
				}
				else if (!string.IsNullOrEmpty(context.AIGeneratedSpeechQuirks))
				{
					LogMessage($"[NPC] Saving new AIGeneratedSpeechQuirks for {npcId} ({context.AIGeneratedSpeechQuirks.Length} chars)");
				}
				else
				{
					context.AIGeneratedSpeechQuirks = null;
				}
			}
			else
			{
				if (string.IsNullOrEmpty(context.CharacterDescription))
				{
					context.CharacterDescription = "";
					LogMessage("[NPC] Initialized empty CharacterDescription for " + npcId);
				}
				LogMessage("[NPC] No existing context found, using current data for " + npcId);
			}
			string contents = JsonConvert.SerializeObject((object)context, (Formatting)1);
			File.WriteAllText(text2, contents);
			if (flag2 && GlobalSettings<ModSettings>.Instance != null && GlobalSettings<ModSettings>.Instance.EnableDebugLogging)
			{
				string fileName = Path.GetFileName(text2);
				string message = $"[NPC] Создан новый .json файл: {fileName} ({npc.Name}, {((MBObjectBase)npc).StringId})";
				LogMessage(message);
				try
				{
				}
				catch (Exception ex3)
				{
					LogMessage("[WARNING] Failed to display InformationMessage: " + ex3.Message);
				}
			}
			if (flag && !string.IsNullOrEmpty(text3) && File.Exists(text3) && text3 != text2)
			{
				try
				{
					File.Delete(text3);
					LogMessage("[DEBUG] Deleted old file after successful rename: " + Path.GetFileName(text3));
				}
				catch (Exception ex4)
				{
					LogMessage("[WARNING] Could not delete old file " + text3 + ": " + ex4.Message);
				}
			}
			_npcContexts[npcId] = context;
			UpdateStringIdIndex(npcId, context.StringId);
		}
		catch (Exception ex5)
		{
			LogMessage("[ERROR] Failed to save NPC context for " + npcId + ": " + ex5.Message);
		}
	}

	private void MigrateRomanceData(NPCContext context)
	{
		if (context.LastRomanceInteractionDays == 0)
		{
			context.LastRomanceInteractionDays = -1;
			LogMessage("[DEBUG] Initialized LastRomanceInteractionDays to -1 for new NPC: " + context.Name);
		}
	}

	public string GetActiveSaveDirectory()
	{
		try
		{
			Campaign current = Campaign.Current;
			string path = ((current != null) ? current.UniqueGameId.ToString() : null) ?? "default";
			string text = Path.Combine(_saveDataPath, path);
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
				LogMessage("[DEBUG] Created save directory: " + text);
			}
			return text;
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Failed to get active save directory: " + ex.Message);
			return _saveDataPath;
		}
	}

	public string GetNPCFilePath(string stringId, bool forceRefresh = false)
	{
		if (string.IsNullOrEmpty(stringId))
		{
			return null;
		}
		if (!forceRefresh && _npcFilePathCache.TryGetValue(stringId, out var value))
		{
			if (File.Exists(value))
			{
				return value;
			}
			_npcFilePathCache.Remove(stringId);
		}
		string activeSaveDirectory = GetActiveSaveDirectory();
		if (string.IsNullOrEmpty(activeSaveDirectory))
		{
			return null;
		}
		string text = FindNPCFileByStringId(activeSaveDirectory, stringId);
		if (!string.IsNullOrEmpty(text))
		{
			_npcFilePathCache[stringId] = text;
		}
		return text;
	}

	public void ClearFilePathCache()
	{
		int count = _npcFilePathCache.Count;
		_npcFilePathCache.Clear();
		if (count > 0)
		{
			LogMessage($"[CACHE] File path cache cleared ({count} entries removed)");
		}
	}

	public void InvalidateCachesForNPC(string npcId)
	{
		if (!string.IsNullOrEmpty(npcId))
		{
			NPCRelationsCache.Instance.InvalidateCache(npcId);
			_npcFilePathCache.Remove(npcId);
			LogMessage("[CACHE] Invalidated caches for NPC " + npcId);
		}
	}

	private string BuildDialogueInputDescription(NPCContext context, string npcName)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		if (context == null)
		{
			return string.Empty;
		}
		List<string> list = new List<string>();
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if ((instance == null || instance.EnableNPCLastMessageHistory) && !string.IsNullOrWhiteSpace(context.LastDynamicResponse))
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> { { "NPC_NAME", npcName } };
			string text = ((object)new TextObject("{=AIInfluence_MessageDialog_LastResponse}Last message from {NPC_NAME}:", dictionary)).ToString();
			list.Add(text + "\n" + context.LastDynamicResponse.Trim());
		}
		string item;
		if (context.LastInteractionTimeDays < 0.0)
		{
			item = ((object)new TextObject("{=AIInfluence_MessageDialog_LastInteraction_Never}You last communicated: Never", (Dictionary<string, object>)null)).ToString();
		}
		else
		{
			CampaignTime now = CampaignTime.Now;
			double d = (now).ToDays - context.LastInteractionTimeDays;
			int num = Math.Max(0, (int)Math.Floor(d));
			Dictionary<string, object> dictionary2 = new Dictionary<string, object> { { "DAYS", num } };
			item = ((object)new TextObject("{=AIInfluence_MessageDialog_LastInteraction}You last communicated: {DAYS} days ago", dictionary2)).ToString();
		}
		list.Add(item);
		return (list.Count > 0) ? string.Join("\n\n", list) : string.Empty;
	}

	private async Task<string> TextInput(string title, string description = null, Hero npcHero = null)
	{
		TextObject affirmativeText = new TextObject("{=AIInfluence_Confirm}Confirm", (Dictionary<string, object>)null);
		TextObject negativeText = new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null);
		TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
		if (((npcHero != null) ? npcHero.CharacterObject : null) != null)
		{
			try
			{
				CharacterCode charCode = CampaignUIHelper.GetCharacterCode(npcHero.CharacterObject, false);
				AIInfluencePortraitWidget.PendingCharacterCode = ((charCode != null) ? charCode.Code : null);
			}
			catch
			{
				AIInfluencePortraitWidget.PendingCharacterCode = null;
			}
		}
		else
		{
			AIInfluencePortraitWidget.PendingCharacterCode = null;
		}
		AIInfluenceTextQueryPopupManager.Show(new TextInquiryData(title, description ?? string.Empty, true, true, ((object)affirmativeText).ToString(), ((object)negativeText).ToString(), (Action<string>)delegate(string input)
		{
			AIInfluencePortraitWidget.PendingCharacterCode = null;
			tcs.TrySetResult(input);
		}, (Action)delegate
		{
			AIInfluencePortraitWidget.PendingCharacterCode = null;
			tcs.TrySetResult(null);
		}, false, (Func<string, Tuple<bool, string>>)null, "", ""));
		return await tcs.Task;
	}

	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		try
		{
			if (_isInitialized)
			{
				LogMessage("[SYSTEM] OnSessionLaunched called again - skipping re-initialization to prevent double initialization");
				return;
			}
			_isInitialized = true;
			ClearFilePathCache();
			NPCRelationsCache.Instance.ClearCache();
			LogMessage("[CACHE] All caches cleared on session launch");
			InitializationManager.Instance.InitializeAllSystems(this, campaignGameStarter);
			DiseaseMedicinePerkPatch.ApplyDiseaseDescriptions();
			SyncQuestsWithGameState();
			Campaign current = Campaign.Current;
			if (((current != null) ? current.ConversationManager : null) != null)
			{
				CampaignEvents.OnAgentJoinedConversationEvent.AddNonSerializedListener((object)this, (Action<IAgent>)OnAgentJoinedConversation);
				LogMessage("[SYSTEM] Subscribed to CampaignEvents.OnAgentJoinedConversationEvent");
			}
			Hero mainHero = Hero.MainHero;
			_lastKnownPlayerStringId = ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null);
			Hero mainHero2 = Hero.MainHero;
			LogMessage($"[PLAYER_TRACKING] Initial player character: {((mainHero2 != null) ? mainHero2.Name : null)} (StringId: {_lastKnownPlayerStringId})");
			LogMessage("[SYSTEM] DialogueAnalyzer system ready for dynamic event generation.");
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Exception in OnSessionLaunched: " + ex.Message);
			InformationManager.DisplayMessage(new InformationMessage("AIInfluence initialization error: " + ex.Message, ExtraColors.RedAIInfluence));
		}
	}

	private void OnSettingChanged(string settingName, object value)
	{
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		if (!_isInitialized)
		{
			LogMessage("[SETTINGS] Ignoring setting change '" + settingName + "' - behavior not initialized yet");
			return;
		}
		LogMessage($"[SETTINGS] Setting '{settingName}' changed to '{value}' for instance {base.GetHashCode()}.");
		if (settingName == "ClearAllNPCs" && (bool)value)
		{
			GlobalSettings<ModSettings>.Instance.ClearAllNPCs = false;
			ClearAllNPCData();
			return;
		}
		if (settingName == "ClearAllNPCEvents" && (bool)value)
		{
			GlobalSettings<ModSettings>.Instance.ClearAllNPCEvents = false;
			ClearAllNPCEvents();
			return;
		}
		if (settingName == "LoadAllNPCs" && (bool)value)
		{
			GlobalSettings<ModSettings>.Instance.LoadAllNPCs = false;
			LogMessage("[WARNING] LoadAllNPCs ignored: sidecar NPC import is disabled in native save mode.");
			return;
		}
		if (settingName == "EraseSpecificNPC" && (bool)value)
		{
			GlobalSettings<ModSettings>.Instance.EraseSpecificNPC = false;
			ShowNPCEraseWindow();
			return;
		}
		if (settingName == "AIBackend")
		{
			string arg = GlobalSettings<ModSettings>.Instance?.AIBackend?.SelectedValue;
			int num = GlobalSettings<ModSettings>.Instance?.AIBackend?.SelectedIndex ?? (-1);
			LogMessage($"[SETTINGS] AI Backend change detected. New value: {arg} (index: {num})");
			return;
		}
		if (settingName == "DebugGenerateQuestFromPrompt" && (bool)value)
		{
			DebugGenerateQuestFromPrompt();
			return;
		}
		if (settingName == "DebugSpawnTestQuest" && (bool)value)
		{
			DebugSpawnTestQuest();
			return;
		}
		if (settingName == "DebugViewActiveQuests" && (bool)value)
		{
			DebugViewActiveQuests();
			return;
		}
		if (settingName == "DebugFailAllQuests" && (bool)value)
		{
			DebugFailAllQuests();
			return;
		}
		if (settingName == "ForceGenerateEvent" && (bool)value)
		{
			LogMessage("[SETTINGS] Force generating dynamic event and clearing diplomatic data...");
			DynamicEventsManager.Instance?.ClearAllEvents();
			DiplomaticStatementsStorage.Instance?.ClearAllStatements();
			DiplomacyManager.Instance?.ClearActiveDiplomaticEvents();
			InformationManager.DisplayMessage(new InformationMessage("All events and diplomatic data cleared!", ExtraColors.GreenAIInfluence));
			DynamicEventsManager.Instance?.GenerateEventsManually();
			InformationManager.DisplayMessage(new InformationMessage("Forced event generation started!", ExtraColors.GreenAIInfluence));
			return;
		}
		if (settingName == "ViewActiveEvents" && (bool)value)
		{
			LogMessage("[SETTINGS] Viewing active dynamic events...");
			ViewActiveEvents();
			return;
		}
		if (settingName == "ClearAllDynamicEvents" && (bool)value)
		{
			LogMessage("[SETTINGS] Starting complete cleanup of all dynamic events and diplomacy systems...");
			try
			{
				DynamicEventsManager.Instance?.ClearAllEvents();
				DiplomacyManager.Instance?.CompleteCleanup();
				LogMessage("[SETTINGS] Complete cleanup finished successfully!");
				InformationManager.DisplayMessage(new InformationMessage("All dynamic events and diplomacy systems cleared!", ExtraColors.GreenAIInfluence));
				return;
			}
			catch (Exception ex)
			{
				LogMessage("[SETTINGS] ERROR during complete cleanup: " + ex.Message + "\n" + ex.StackTrace);
				InformationManager.DisplayMessage(new InformationMessage("Error during cleanup: " + ex.Message, ExtraColors.RedAIInfluence));
				return;
			}
		}
		if (!(settingName == "EnableDiplomacy"))
		{
			return;
		}
		bool flag = (bool)value;
		LogMessage("[SETTINGS] Diplomacy system " + (flag ? "enabled" : "disabled"));
		if (flag && GlobalSettings<ModSettings>.Instance.CanEnableDiplomacy())
		{
			if (!DiplomacyManager.Instance.IsInitialized)
			{
				DiplomacyManager.Instance.Initialize();
				InformationManager.DisplayMessage(new InformationMessage("Diplomacy system initialized!", ExtraColors.GreenAIInfluence));
				LogMessage("[SETTINGS] Diplomacy manager initialized via settings change");
			}
		}
		else if (!flag)
		{
			LogMessage("[SETTINGS] Diplomacy system disabled");
		}
	}

	private void DebugSpawnTestQuest()
	{
		try
		{
		Vec2 mainPos = MobileParty.MainParty?.GetPosition2D() ?? default;
		Hero questGiver = Hero.FindAll((Hero h) => h != Hero.MainHero && h.IsAlive && h.IsActive && !h.IsWanderer)
			?.OrderBy((Hero h) =>
			{
				Vec2 pos = h.PartyBelongedTo != null ? h.PartyBelongedTo.GetPosition2D() : (h.CurrentSettlement?.GetPosition2D() ?? default);
				return pos.Distance(mainPos);
			})
			?.FirstOrDefault();
			if (questGiver == null)
			{
				InformationManager.DisplayMessage(new InformationMessage("[QuestDebug] No suitable NPC found for test quest.", ExtraColors.RedAIInfluence));
				return;
			}
			NPCContext context = GetOrCreateNPCContext(questGiver);
			QuestActionData testAction = new QuestActionData
			{
				Action = "create_quest",
				Title = "[DEBUG] Test Quest",
				Description = "A debug quest to verify all reward and spawn systems.",
				DurationDays = 14,
				RewardGold = 500,
				RewardItems = new List<QuestItemReward> { new QuestItemReward { ItemName = "grain", Count = 10 } },
				RewardSkill = "Charm",
				RewardSkillXp = 300,
				InfluenceChange = 5,
				CrimeRatingChange = -10,
				SpawnHostileParty = true,
				HostilePartySize = 8,
				HostileTroopName = "looter",
				HostilePartyLabel = "[DEBUG] Test Bandits",
				AIVerificationNotes = "Debug quest — always completable.",
				ProgressTarget = 3,
				ProgressLabel = "steps completed"
			};
			ProcessCreateQuest(questGiver, context, testAction);
			InformationManager.DisplayMessage(new InformationMessage($"[QuestDebug] Test quest created on {questGiver.Name}.", ExtraColors.GreenAIInfluence));
		}
		catch (Exception ex)
		{
			LogMessage("[QuestDebug] DebugSpawnTestQuest error: " + ex.Message);
			InformationManager.DisplayMessage(new InformationMessage("[QuestDebug] Error — see mod_log.txt", ExtraColors.RedAIInfluence));
		}
	}

	private void DebugGenerateQuestFromPrompt()
	{
		string rawPrompt = GlobalSettings<ModSettings>.Instance?.DebugQuestPrompt;
		if (string.IsNullOrWhiteSpace(rawPrompt))
		{
			InformationManager.DisplayMessage(new InformationMessage("[QuestDebug] Quest Generation Prompt is empty.", ExtraColors.RedAIInfluence));
			return;
		}
		string prompt = rawPrompt.Trim();
		if (prompt.Length > 500)
			prompt = prompt.Substring(0, 500);

		Vec2 mainPos = MobileParty.MainParty?.GetPosition2D() ?? default;
		Hero questGiver = Hero.FindAll((Hero h) => h != Hero.MainHero && h.IsAlive && h.IsActive && !h.IsWanderer)
			?.OrderBy((Hero h) =>
			{
				Vec2 pos = h.PartyBelongedTo != null ? h.PartyBelongedTo.GetPosition2D() : (h.CurrentSettlement?.GetPosition2D ?? default);
				return pos.Distance(mainPos);
			})
			?.FirstOrDefault();
		if (questGiver == null)
		{
			InformationManager.DisplayMessage(new InformationMessage("[QuestDebug] No suitable NPC found.", ExtraColors.RedAIInfluence));
			return;
		}

		InformationManager.DisplayMessage(new InformationMessage("[QuestDebug] Generating quest from prompt...", ExtraColors.GreenAIInfluence));
		LogMessage("[QuestDebug] Prompt: " + prompt);

		string requestPrompt = "You are generating a Bannerlord quest action.\nReturn ONLY valid JSON in this exact wrapper:\n{\"quest_action\":{...}}\n" +
			"Inside quest_action provide action=create_quest with fields: title, description, duration_days (7-60), reward_gold (0-5000), " +
			"and optionally spawn_npc (object with: name, alignment, culture, backstory, personality, is_female, age, settlement, " +
			"equipment {weapon, shield, head, body, cape, gloves, legs, horse, tier}, party_name, party_troops, party_size).\n" +
			"alignment must be one of: friendly, hostile, neutral.\n" +
			"All item/troop/settlement names are fuzzy-matched — use natural language names.\n" +
			"Do not add explanations.\nPlayer quest request: " + prompt;

		Task.Run(async () =>
		{
			try
			{
				Task<string> requestTask = SendAIRequestRaw(requestPrompt);
				Task timeoutTask = Task.Delay(45000);
				Task completedTask = await Task.WhenAny(requestTask, timeoutTask);
				string rawResponse = (completedTask == timeoutTask) ? "Error: Timeout (45s)" : await requestTask;

				TtsLipSyncService.MainThreadQueue.Enqueue(() =>
				{
					try
					{
						if (string.IsNullOrEmpty(rawResponse) || rawResponse.StartsWith("Error:"))
						{
							LogMessage("[QuestDebug] AI request failed: " + (rawResponse ?? "empty"));
							InformationManager.DisplayMessage(new InformationMessage("[QuestDebug] Failed: " + (rawResponse ?? "empty"), ExtraColors.RedAIInfluence));
							return;
						}
						string cleaned = JsonCleaner.CleanJsonGeneric(rawResponse) ?? rawResponse;
						AIResponse aiResponse = JsonConvert.DeserializeObject<AIResponse>(cleaned);
						QuestActionData questAction = aiResponse?.QuestAction;
						if (questAction == null)
							questAction = JsonConvert.DeserializeObject<QuestActionData>(cleaned);
						if (questAction == null || !"create_quest".Equals(questAction.Action, StringComparison.OrdinalIgnoreCase))
						{
							LogMessage("[QuestDebug] Parse failed or wrong action. Raw: " + rawResponse);
							InformationManager.DisplayMessage(new InformationMessage("[QuestDebug] Parse failed — see mod_log.txt", ExtraColors.RedAIInfluence));
							return;
						}
						NPCContext context = GetOrCreateNPCContext(questGiver);
						ProcessCreateQuest(questGiver, context, questAction);
						InformationManager.DisplayMessage(new InformationMessage($"[QuestDebug] Quest created on {questGiver.Name}.", ExtraColors.GreenAIInfluence));
					}
					catch (Exception ex)
					{
						LogMessage("[QuestDebug] Main-thread error: " + ex.Message + "\n" + ex.StackTrace);
						InformationManager.DisplayMessage(new InformationMessage("[QuestDebug] Error — see mod_log.txt", ExtraColors.RedAIInfluence));
					}
				});
			}
			catch (Exception ex)
			{
				LogMessage("[QuestDebug] Background error: " + ex.Message + "\n" + ex.StackTrace);
			}
		});
	}

	private void DebugViewActiveQuests()
	{
		try
		{
			int total = 0;
		foreach (KeyValuePair<string, NPCContext> kv in _npcContexts.ToList())
		{
			List<AIQuestInfo> quests = kv.Value?.ActiveAIQuests;
			if (quests == null || quests.Count == 0)
				{
					continue;
				}
				foreach (AIQuestInfo q in quests)
				{
					string progress = q.ProgressTarget > 0 ? $" [{q.ProgressCurrent}/{q.ProgressTarget} {q.ProgressLabel}]" : "";
					string party = !string.IsNullOrEmpty(q.SpawnedPartyId) ? $" | party:{q.SpawnedPartyId}" : "";
					InformationManager.DisplayMessage(new InformationMessage(
						$"[Quest] \"{q.Title}\" giver:{q.QuestGiverNpcId} gold:{q.RewardGold}{progress}{party}", ExtraColors.GreenAIInfluence));
					LogMessage($"[QuestDebug] Active quest: {q.QuestId} | {q.Title} | giver:{q.QuestGiverNpcId} | gold:{q.RewardGold}{progress}{party}");
					total++;
				}
			}
			if (total == 0)
			{
				InformationManager.DisplayMessage(new InformationMessage("[QuestDebug] No active AI quests found.", ExtraColors.GreenAIInfluence));
			}
		}
		catch (Exception ex)
		{
			LogMessage("[QuestDebug] DebugViewActiveQuests error: " + ex.Message);
		}
	}

	private void DebugFailAllQuests()
	{
		try
		{
			int count = 0;
		foreach (KeyValuePair<string, NPCContext> kv in _npcContexts.ToList())
		{
			List<AIQuestInfo> quests = kv.Value?.ActiveAIQuests?.ToList();
			if (quests == null)
			{
				continue;
			}
			foreach (AIQuestInfo q in quests)
			{
				Hero giver = Hero.FindFirst((Hero h) => ((MBObjectBase)h).StringId == q.QuestGiverNpcId);
				if (giver == null)
				{
					continue;
				}
				QuestActionData failAction = new QuestActionData
				{
					Action = "fail_quest",
					QuestId = q.QuestId,
					CompletionReason = "Debug: force-failed via MCM"
				};
				ProcessFailQuest(giver, kv.Value, failAction);
				count++;
			}
		}
			InformationManager.DisplayMessage(new InformationMessage($"[QuestDebug] Failed {count} active quest(s).", ExtraColors.GreenAIInfluence));
			LogMessage($"[QuestDebug] DebugFailAllQuests: failed {count} quest(s)");
		}
		catch (Exception ex)
		{
			LogMessage("[QuestDebug] DebugFailAllQuests error: " + ex.Message);
		}
	}

	private void ViewActiveEvents()
	{
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		try
		{
			List<DynamicEvent> list = DynamicEventsManager.Instance?.GetActiveEvents();
			if (list == null || !list.Any())
			{
				InformationManager.DisplayMessage(new InformationMessage("No active dynamic events", Colors.Yellow));
				return;
			}
			InformationManager.DisplayMessage(new InformationMessage($"=== ACTIVE DYNAMIC EVENTS ({list.Count}) ===", ExtraColors.NewsColorMessage));
			foreach (DynamicEvent item in from e in list
				orderby e.Importance descending, e.DaysSinceCreation
				select e)
			{
				string text = $"[{item.Type.ToUpper()}] [Importance: {item.Importance}/10] [Age: {item.DaysSinceCreation} days]";
				InformationManager.DisplayMessage(new InformationMessage(text, Colors.Cyan));
				string text2 = ((item.Description.Length > 200) ? (item.Description.Substring(0, 197) + "...") : item.Description);
				InformationManager.DisplayMessage(new InformationMessage(text2, Colors.White));
				string text3 = "Kingdoms: ";
				text3 = ((item.KingdomsInvolved != null) ? ((!(item.KingdomsInvolved is string text4) || !(text4 == "all")) ? (text3 + string.Join(", ", item.GetKingdomStringIds())) : (text3 + "all (global)")) : (text3 + "none (neutral)"));
				InformationManager.DisplayMessage(new InformationMessage(text3 + " | Player: " + (item.PlayerInvolved ? "YES" : "NO") + " | Speed: " + item.SpreadSpeed, Colors.Gray));
				InformationManager.DisplayMessage(new InformationMessage("---", Colors.Gray));
			}
			InformationManager.DisplayMessage(new InformationMessage("=== END OF EVENTS ===", ExtraColors.NewsColorMessage));
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Failed to view active events: " + ex.Message);
			InformationManager.DisplayMessage(new InformationMessage("Error viewing events!", ExtraColors.RedAIInfluence));
		}
	}

	private void OnRulingClanChanged(Kingdom kingdom, Clan newRulingClan)
	{
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((newRulingClan != null) ? newRulingClan.Leader : null) != null && newRulingClan.Leader != Hero.MainHero)
			{
				Hero leader = newRulingClan.Leader;
				LogMessage($"[KINGDOM_LEADER_CHANGE] {leader.Name} became the ruler of kingdom {kingdom.Name}");
				string previousRulerInfo = WorldInfoManager.GetPreviousRulerInfo(kingdom, leader);
				LogMessage("[KINGDOM_LEADER_CHANGE] Previous ruler info: " + previousRulerInfo);
				string text = $"{kingdom.Name} (kingdom_id:{((MBObjectBase)kingdom).StringId})";
				string text2 = "Became the new ruler of " + text + ". Previous ruler: " + previousRulerInfo;
				if (newRulingClan == Hero.MainHero.Clan)
				{
					string text3 = ((leader == Hero.MainHero) ? "(you became the ruler)" : $"(your clan member {leader.Name} became the ruler)");
					string text4 = $"(player's clan: {Hero.MainHero.Clan.Name}, clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId})";
					text2 = text2 + " " + text3 + " " + text4;
				}
				CampaignEvent ev = new CampaignEvent
				{
					Type = "KingdomLeadership",
					Description = text2,
					Timestamp = CampaignTime.Now
				};
				HashSet<string> hashSet = new HashSet<string>();
				hashSet.Add(((MBObjectBase)leader).StringId);
				HashSet<string> processedParticipantIds = WorldInfoManager.Instance.AddEventToDirectParticipantsImmediately("KingdomLeadership", ev, null, leader, hashSet);
				WorldInfoManager.Instance.QueueEventForInformedNPCs(ev, null, leader, null, defer: false, null, processedParticipantIds);
				LogMessage($"[KINGDOM_LEADER_CHANGE] KingdomLeadership event queued for {leader.Name}.");
			}
		}
		catch (Exception ex)
		{
			object arg;
			if (newRulingClan == null)
			{
				arg = null;
			}
			else
			{
				Hero leader2 = newRulingClan.Leader;
				arg = ((leader2 != null) ? leader2.Name : null);
			}
			LogMessage($"[ERROR] Error processing OnRulingClanChanged for new ruler {arg}: {ex.Message}");
		}
	}

	private void CleanupOldEvents()
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null)
		{
			return;
		}
		float num = instance.RecentEventsLifetimeDays;
		int maxRecentEvents = instance.MaxRecentEvents;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		string activeSaveDirectory = GetActiveSaveDirectory();
		if (string.IsNullOrEmpty(activeSaveDirectory) || !Directory.Exists(activeSaveDirectory))
		{
			LogMessage("[CLEANUP] Save folder not found or empty: " + activeSaveDirectory);
			return;
		}
		string[] files = Directory.GetFiles(activeSaveDirectory, "*.json", SearchOption.TopDirectoryOnly);
		LogMessage($"[CLEANUP] Starting cleanup for {files.Length} NPC files...");
		string[] array = files;
		foreach (string path in array)
		{
			try
			{
				string text = File.ReadAllText(path);
				NPCContext nPCContext = JsonConvert.DeserializeObject<NPCContext>(text);
				if (nPCContext == null || nPCContext.RecentEvents == null || nPCContext.RecentEvents.Count == 0)
				{
					continue;
				}
				int count = nPCContext.RecentEvents.Count;
				WorldInfoManager.Instance?.TrimRecentEvents(nPCContext);
				int count2 = nPCContext.RecentEvents.Count;
				int num5 = count - count2;
				num3++;
				if (num5 <= 0)
				{
					continue;
				}
				num2 += num5;
				try
				{
					string contents = JsonConvert.SerializeObject((object)nPCContext, (Formatting)1);
					File.WriteAllText(path, contents);
					num4++;
					if (instance.EnableDebugLogging)
					{
						LogMessage($"[CLEANUP] Cleaned {nPCContext.Name}: {count} → {count2} events (removed {num5})");
					}
				}
				catch (Exception ex)
				{
					LogMessage("[ERROR] Failed to save cleaned context for " + nPCContext.Name + ": " + ex.Message);
				}
			}
			catch (Exception ex2)
			{
				LogMessage("[ERROR] Failed to process file " + Path.GetFileName(path) + ": " + ex2.Message);
			}
		}
		if (num2 > 0 || num3 > 0)
		{
			LogMessage($"[CLEANUP] Cleaned {num2} old events from {num3} NPC files (saved {num4} files), max age: {num} days, max count: {maxRecentEvents}");
		}
	}

	public void CreateKingdomLeadersContexts()
	{
		try
		{
			LogMessage("[KINGDOM_LEADERS] Creating contexts for kingdom leaders...");
			int num = 0;
			List<(string, Hero, NPCContext)> list = new List<(string, Hero, NPCContext)>();
			foreach (Kingdom item in (List<Kingdom>)(object)Kingdom.All)
			{
				if (item.Leader == null || item.Leader == Hero.MainHero)
				{
					continue;
				}
				try
				{
					string stringId = ((MBObjectBase)item.Leader).StringId;
					bool flag = _npcContexts.ContainsKey(stringId);
					string activeSaveDirectory = GetActiveSaveDirectory();
					string text = FindNPCFileByStringId(activeSaveDirectory, stringId);
					bool flag2 = !string.IsNullOrEmpty(text) && File.Exists(text);
					if (flag && flag2)
					{
						num++;
						continue;
					}
					if (flag && !flag2)
					{
						LogMessage($"[KINGDOM_LEADERS] Context for {item.Leader.Name} exists in memory but file is missing. Recreating...");
						_npcContexts.Remove(stringId);
						if (_stringIdToContextKey.ContainsKey(stringId))
						{
							string key = _stringIdToContextKey[stringId];
							_stringIdToContextKey.Remove(stringId);
							if (_npcContexts.ContainsKey(key))
							{
								_npcContexts.Remove(key);
							}
						}
					}
					NPCContext nPCContext = CreateNPCContextWithoutSave(item.Leader, stringId);
					if (nPCContext.InteractionCount == 0)
					{
						nPCContext.InteractionCount = 1;
						LogMessage($"[KINGDOM_LEADERS] Marked {item.Leader.Name} as initialized (InteractionCount set to 1)");
					}
					if (!nPCContext.KnowledgeGenerated)
					{
						WorldInfoManager.WorldSecretsManager.Instance.CheckSecretKnowledge(item.Leader, nPCContext);
						WorldInfoManager.InformationManager.Instance.CheckInfoKnowledge(item.Leader, nPCContext);
						nPCContext.KnowledgeGenerated = true;
					}
					UpdateContextData(nPCContext, item.Leader);
					list.Add((stringId, item.Leader, nPCContext));
					LogMessage($"[KINGDOM_LEADERS] Created context for {item.Leader.Name} (Leader of {item.Name}) with {nPCContext.KnownSecrets?.Count ?? 0} secrets and {nPCContext.KnownInfo?.Count ?? 0} info items");
					num++;
				}
				catch (Exception ex)
				{
					Hero leader = item.Leader;
					LogMessage($"[ERROR] Failed to create context for {((leader != null) ? leader.Name : null)} (Leader of {item.Name}): {ex.Message}");
				}
			}
			foreach (var (npcId, val, context) in list)
			{
				try
				{
					SaveNPCContext(npcId, val, context);
					LogMessage($"[KINGDOM_LEADERS] Saved context for {val.Name}");
				}
				catch (Exception ex2)
				{
					LogMessage($"[ERROR] Failed to save context for {val.Name}: {ex2.Message}");
				}
			}
			LogMessage($"[KINGDOM_LEADERS] Successfully created contexts for {num} kingdom leaders.");
		}
		catch (Exception ex3)
		{
			LogMessage("[ERROR] Failed to create kingdom leaders contexts: " + ex3.Message);
		}
	}

	public void ClearAllNPCData()
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		string activeSaveDirectory = GetActiveSaveDirectory();
		if (string.IsNullOrEmpty(activeSaveDirectory) || !Directory.Exists(activeSaveDirectory))
		{
			LogMessage("[NPC_DATA] No save data directory found to clear.");
			InformationManager.DisplayMessage(new InformationMessage("No save data found to clear.", Colors.Yellow));
			return;
		}
		try
		{
			string[] files = Directory.GetFiles(activeSaveDirectory, "*.json");
			string[] array = files;
			foreach (string path in array)
			{
				File.Delete(path);
			}
			_npcContexts.Clear();
			_stringIdToContextKey.Clear();
			LogMessage($"[NPC_DATA] Cleared all NPC data for the current save game ({Path.GetFileName(activeSaveDirectory)}). Deleted {files.Length} files.");
			InformationManager.DisplayMessage(new InformationMessage($"Cleared all {Path.GetFileName(activeSaveDirectory)} NPC data ({files.Length} files).", ExtraColors.GreenAIInfluence));
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Failed to clear NPC data: " + ex.Message);
			InformationManager.DisplayMessage(new InformationMessage("Error clearing NPC data: " + ex.Message, ExtraColors.RedAIInfluence));
		}
	}

	public void ClearAllNPCEvents()
	{
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		int num = 0;
		string activeSaveDirectory = GetActiveSaveDirectory();
		if (string.IsNullOrEmpty(activeSaveDirectory))
		{
			LogMessage("[EVENTS_CLEAR] No save directory found. Cannot clear NPC events.");
			InformationManager.DisplayMessage(new InformationMessage("No save directory found. Cannot clear NPC events.", Colors.Yellow));
			return;
		}
		try
		{
			List<NPCContext> list = _npcContexts.Values.ToList();
			foreach (NPCContext item in list)
			{
				if (item.RecentEvents != null && item.RecentEvents.Count > 0)
				{
					item.RecentEvents.Clear();
					num++;
				}
			}
			List<string> list2 = _npcContexts.Keys.ToList();
			foreach (string item2 in list2)
			{
				string text = FindNPCFileByStringId(activeSaveDirectory, item2);
				if (string.IsNullOrEmpty(text) || !File.Exists(text))
				{
					continue;
				}
				try
				{
					string text2 = File.ReadAllText(text);
					NPCContext nPCContext = JsonConvert.DeserializeObject<NPCContext>(text2);
					if (nPCContext.RecentEvents != null && nPCContext.RecentEvents.Count > 0)
					{
						nPCContext.RecentEvents.Clear();
						string contents = JsonConvert.SerializeObject((object)nPCContext, (Formatting)1);
						File.WriteAllText(text, contents);
					}
				}
				catch (Exception ex)
				{
					LogMessage("[ERROR] Failed to clear events for " + item2 + ": " + ex.Message);
				}
			}
			LogMessage($"[EVENTS_CLEAR] Cleared RecentEvents for {num} NPCs in memory and files.");
			InformationManager.DisplayMessage(new InformationMessage($"Cleared RecentEvents for {num} NPCs.", ExtraColors.GreenAIInfluence));
		}
		catch (Exception ex2)
		{
			LogMessage("[ERROR] Failed to clear NPC events: " + ex2.Message);
			InformationManager.DisplayMessage(new InformationMessage("Error clearing NPC events: " + ex2.Message, ExtraColors.RedAIInfluence));
		}
	}

	private bool IsNPCWithPlayer(Hero npc)
	{
		MobileParty partyBelongedTo = Hero.MainHero.PartyBelongedTo;
		MobileParty partyBelongedTo2 = npc.PartyBelongedTo;
		if (partyBelongedTo == null || partyBelongedTo2 == null)
		{
			LogMessage(string.Format("[DEBUG] IsNPCWithPlayer({0}): playerParty={1}, npcParty={2} -> false", npc.Name, ((partyBelongedTo == null) ? null : ((object)partyBelongedTo.Name)?.ToString()) ?? "null", ((partyBelongedTo2 == null) ? null : ((object)partyBelongedTo2.Name)?.ToString()) ?? "null"));
			return false;
		}
		if (partyBelongedTo2 == partyBelongedTo)
		{
			LogMessage($"[DEBUG] IsNPCWithPlayer({npc.Name}): Same party ({partyBelongedTo2.Name}) -> true");
			return true;
		}
		Army army = partyBelongedTo.Army;
		Army army2 = partyBelongedTo2.Army;
		if (army != null && ((List<MobileParty>)(object)army.Parties).Contains(partyBelongedTo2))
		{
			LogMessage($"[DEBUG] IsNPCWithPlayer({npc.Name}): NPC party ({partyBelongedTo2.Name}) is in player's army ({army.Name}) -> true");
			return true;
		}
		if (army2 != null && ((List<MobileParty>)(object)army2.Parties).Contains(partyBelongedTo))
		{
			LogMessage($"[DEBUG] IsNPCWithPlayer({npc.Name}): Player party ({partyBelongedTo.Name}) is in NPC's army ({army2.Name}) -> true");
			return true;
		}
		if (army != null && army2 != null && army == army2)
		{
			LogMessage($"[DEBUG] IsNPCWithPlayer({npc.Name}): Both in same army ({army.Name}) -> true");
			return true;
		}
		return false;
	}

	private void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		if (hero != null && _npcContexts.ContainsKey(((MBObjectBase)hero).StringId))
		{
			NPCContext context = _npcContexts[((MBObjectBase)hero).StringId];
			TrackSettlementVisitForHero(context, hero, settlement);
		}
		try
		{
			DiseaseManager.Instance?.OnPartyEnteredSettlement(party, settlement, hero);
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Disease settlement entry treatment error: " + ex.Message);
		}
		if (party != MobileParty.MainParty || settlement == null)
		{
			return;
		}
		_playerReinforcementAdded = false;
		_delayedTaskManager.AddTask(3.0, delegate
		{
			try
			{
				if (Settlement.CurrentSettlement != null && Mission.Current != null && Settlement.CurrentSettlement == settlement && !_playerReinforcementAdded)
				{
					PlayerReinforcementMissionLogic playerReinforcementMissionLogic = Mission.Current.MissionBehaviors.OfType<PlayerReinforcementMissionLogic>().FirstOrDefault();
					if (playerReinforcementMissionLogic != null)
					{
						_playerReinforcementAdded = true;
					}
					else
					{
						Mission.Current.AddMissionBehavior((MissionBehavior)(object)new PlayerReinforcementMissionLogic(this));
						_playerReinforcementAdded = true;
						LogMessage("[PLAYER_REINFORCEMENT] PlayerReinforcementMissionLogic added to current mission (delayed initialization after settlement entry)");
					}
				}
			}
			catch (Exception ex2)
			{
				LogMessage("[PLAYER_REINFORCEMENT] ERROR in delayed initialization: " + ex2.Message);
			}
		});
	}

	private void OnSettlementLeft(MobileParty party, Settlement settlement)
	{
		try
		{
			if (party != MobileParty.MainParty || settlement == null)
			{
				return;
			}
			LogMessage($"[SETTLEMENT] Player left settlement {settlement.Name}");
			if (settlement.Notables != null)
			{
				List<Hero> list = ((IEnumerable<Hero>)settlement.Notables).Where((Hero h) => h != null && !h.IsAlive).ToList();
				foreach (Hero item in list)
				{
					((List<Hero>)(object)settlement.Notables).Remove(item);
					LogMessage($"[SETTLEMENT] Removed dead hero {item.Name} from {settlement.Name}.Notables to prevent crash");
				}
			}
			_playerReinforcementAdded = false;
			LogMessage("[PLAYER_REINFORCEMENT] Flag reset on settlement exit");
			if (_settlementCombatManager != null && _settlementCombatManager.HasActiveCombat)
			{
				_settlementCombatManager.OnPlayerLeavesSettlement();
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnSettlementLeft: " + ex.Message);
		}
	}

	private void TrackSettlementVisit(NPCContext context, Hero npc)
	{
		object obj = npc.CurrentSettlement;
		if (obj == null)
		{
			MobileParty partyBelongedTo = npc.PartyBelongedTo;
			obj = ((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null);
		}
		Settlement val = (Settlement)obj;
		if (val != null)
		{
			TrackSettlementVisitForHero(context, npc, val);
		}
	}

	private void TrackSettlementVisitForHero(NPCContext context, Hero npc, Settlement settlement)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		SettlementVisit settlementVisit = context.VisitedSettlements.FirstOrDefault((SettlementVisit v) => v.SettlementId == ((MBObjectBase)settlement).StringId);
		if (settlementVisit == null)
		{
			SettlementVisit item = new SettlementVisit(((MBObjectBase)settlement).StringId, ((object)settlement.Name).ToString(), CampaignTime.Now);
			context.VisitedSettlements.Add(item);
		}
		else
		{
			CampaignTime val = CampaignTime.Now;
			double toDays = (val).ToDays;
			val = settlementVisit.VisitTime;
			int num = (int)(toDays - (val).ToDays);
			if (num >= 1)
			{
				settlementVisit.VisitTime = CampaignTime.Now;
			}
		}
		if (context.VisitedSettlements.Count > 10)
		{
			context.VisitedSettlements = context.VisitedSettlements.OrderByDescending(delegate(SettlementVisit v)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime visitTime = v.VisitTime;
				return (visitTime).ToDays;
			}).Take(10).ToList();
		}
	}

	public SaveQueueStats GetSaveQueueStats()
	{
		return _saveQueueManager.GetStats();
	}

	private static string CompressPayload(string payload)
	{
		if (string.IsNullOrEmpty(payload))
		{
			return payload;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(payload);
		using MemoryStream memoryStream = new MemoryStream();
		using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionLevel.Optimal, leaveOpen: true))
		{
			gZipStream.Write(bytes, 0, bytes.Length);
		}
		return "gz:" + Convert.ToBase64String(memoryStream.ToArray());
	}

	private static string DecompressPayload(string payload)
	{
		if (string.IsNullOrEmpty(payload) || !payload.StartsWith("gz:"))
		{
			return payload;
		}
		byte[] buffer = Convert.FromBase64String(payload.Substring(3));
		using MemoryStream stream = new MemoryStream(buffer);
		using GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress);
		using StreamReader streamReader = new StreamReader(stream2, Encoding.UTF8);
		return streamReader.ReadToEnd();
	}

	public override void SyncData(IDataStore dataStore)
	{
		bool binarySyncCompatibilityMode = false;
		if (binarySyncCompatibilityMode)
		{
			if (dataStore.IsSaving)
			{
				FlushAllNpcContextsForSave();
			}
			if (dataStore.IsLoading)
			{
				_saveQueueManager.ClearQueue();
				if (_followingHeroIds == null)
				{
					_followingHeroIds = new List<string>();
				}
				_npcContexts = new Dictionary<string, NPCContext>();
				_npcFilePathCache.Clear();
				_stringIdToContextKey.Clear();
			}
			return;
		}
		string syncStage = "sync-start";
		try
		{
			LogMessage($"[SYNC-TRACE] Enter SyncData. isSaving={dataStore.IsSaving}, isLoading={dataStore.IsLoading}");
			if (dataStore.IsSaving)
			{
				syncStage = "save-prepare-state";
				_npcContexts ??= new Dictionary<string, NPCContext>();
				AIActionManager instance = AIActionManager.Instance;
				if (instance != null)
				{
					_followingHeroIds = instance.GetActiveFollowingHeroIds();
					_serializedActionState = CompressPayload(instance.SerializeActiveActions());
					LogMessage($"[SAVE] Saving {_followingHeroIds.Count} following hero IDs to game save");
					LogMessage($"[SAVE] Serialized AI actions length: {_serializedActionState?.Length ?? 0}");
				}
				Dictionary<string, NPCContext> contextsToSave = new Dictionary<string, NPCContext>(_npcContexts);
				_npcContextsJson = CompressPayload(JsonConvert.SerializeObject(contextsToSave));
				LogMessage($"[SAVE] Serialized {contextsToSave.Count} NPC contexts into game save");
			}
			syncStage = "sync-followingHeroIds";
			dataStore.SyncData<List<string>>("AIInfluence_followingHeroIds", ref _followingHeroIds);
			syncStage = "sync-aiActionState";
			dataStore.SyncData<string>("AIInfluence_aiActionState", ref _serializedActionState);
			syncStage = "sync-npcContexts";
			dataStore.SyncData<string>("AIInfluence_npcContexts", ref _npcContextsJson);
			if (dataStore.IsLoading)
			{
				LogMessage("[SYNC-TRACE] After SyncData read. followingHeroIdsCount=" + (_followingHeroIds?.Count ?? 0) + ", aiActionStateLength=" + (_serializedActionState?.Length ?? 0) + ", npcPayloadLength=" + (_npcContextsJson?.Length ?? 0));
				if (!string.IsNullOrEmpty(_npcContextsJson))
				{
					try
					{
						syncStage = "load-deserialize-npcContexts";
						string value = DecompressPayload(_npcContextsJson);
						_npcContexts = JsonConvert.DeserializeObject<Dictionary<string, NPCContext>>(value) ?? throw new InvalidOperationException("NPC context payload deserialized to null.");
						_npcContextsJson = null; // free the raw string now that objects are materialized
						LogMessage($"[LOAD] Restored {_npcContexts.Count} NPC contexts from game save");
					}
					catch (Exception ex)
					{
						LogMessage("[ERROR] Failed to deserialize NPC contexts from game save. stage=" + syncStage + ", payloadLength=" + (_npcContextsJson?.Length ?? 0) + ". " + ex);
						_npcContexts = new Dictionary<string, NPCContext>();
						_npcContextsJson = null;
						LogMessage("[ERROR] Recovering load with empty NPC context state to keep save loadable.");
					}
				}
				if (_followingHeroIds == null)
				{
					_followingHeroIds = new List<string>();
					LogMessage("[LOAD] Initialized empty following hero IDs list (old save format)");
				}
				bool flag = false;
				if (!string.IsNullOrEmpty(_serializedActionState))
				{
					syncStage = "load-schedule-action-state-restore";
					flag = true;
					string stateCopy = DecompressPayload(_serializedActionState);
					_delayedTaskManager.AddTask(3.0, delegate
					{
						AIActionManager.Instance.RestoreActionsFromSerialized(stateCopy);
					});
				}
				if (!flag)
				{
					syncStage = "load-schedule-following-restore";
					LogMessage($"[LOAD] Loaded {_followingHeroIds.Count} following hero IDs from game save");
					if (_followingHeroIds.Count > 0)
					{
						List<string> heroIdsToRestore = new List<string>(_followingHeroIds);
						_delayedTaskManager.AddTask(3.0, delegate
						{
							LogMessage($"[LOAD] Restoring {heroIdsToRestore.Count} follow actions after load");
							AIActionManager.Instance.RestoreFollowingActions(heroIdsToRestore);
						});
					}
				}
			}
			syncStage = "sync-currentSaveFolder";
			dataStore.SyncData<string>("AIInfluence_currentSaveFolder", ref _currentSaveFolder);
			LogMessage("[SYNC-TRACE] Exit SyncData success.");
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] SyncData failed at stage=" + syncStage + ". followingHeroIdsCount=" + (_followingHeroIds?.Count ?? 0) + ", aiActionStateLength=" + (_serializedActionState?.Length ?? 0) + ", npcPayloadLength=" + (_npcContextsJson?.Length ?? 0) + ". " + ex);
			if (dataStore.IsLoading)
			{
				_followingHeroIds = new List<string>();
				_npcContexts = new Dictionary<string, NPCContext>();
				_npcContextsJson = null;
				LogMessage("[ERROR] Recovering SyncData load failure with default AIInfluence state.");
				return;
			}
			throw;
		}
	}

	private void FlushAllNpcContextsForSave()
	{
		foreach (KeyValuePair<string, NPCContext> item in _npcContexts.ToList())
		{
			if (string.IsNullOrEmpty(item.Key) || item.Value == null)
			{
				continue;
			}
			Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == item.Key));
			if (val != null)
			{
				SaveNPCContextImmediate(item.Key, val, item.Value);
			}
		}
	}

	public void LoadAllNPCsForEvent()
	{
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		try
		{
			string activeSaveDirectory = GetActiveSaveDirectory();
			if (string.IsNullOrEmpty(activeSaveDirectory) || !Directory.Exists(activeSaveDirectory))
			{
				LogMessage("[WARNING] LoadAllNPCsForEvent: No save directory found.");
				return;
			}
			string[] files = Directory.GetFiles(activeSaveDirectory, "*.json");
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			string[] array = files;
			foreach (string text in array)
			{
				try
				{
					string fileName = Path.GetFileName(text);
					switch (fileName)
					{
					case "diplomatic_statements.json":
						continue;
					case "rp_items.json":
						continue;
					case "economic_effects.json":
						continue;
					case "settlement_ownership_history.json":
						continue;
					case "kingdom_leadership_history.json":
						continue;
					case "war_statistics.json":
						continue;
					case "diplomatic_events.json":
						continue;
					case "pending_player_statements.json":
						continue;
					case "alliances.json":
						continue;
					case "alliance_data.json":
						continue;
					case "trade_agreements.json":
						continue;
					case "territory_transfers.json":
						continue;
					case "tribute_agreements.json":
						continue;
					case "tributes.json":
						continue;
					case "reparations.json":
						continue;
					case "disease_instances.json":
						continue;
					case "diseases.json":
						continue;
					}
					if (fileName == "settlement_disease_instances.json")
					{
						continue;
					}
					string text2 = File.ReadAllText(text);
					NPCContext nPCContext = JsonConvert.DeserializeObject<NPCContext>(text2);
					if (nPCContext != null && !string.IsNullOrEmpty(nPCContext.StringId))
					{
						if (!_npcFilePathCache.ContainsKey(nPCContext.StringId))
						{
							_npcFilePathCache[nPCContext.StringId] = text;
							num3++;
						}
						if (!_npcContexts.ContainsKey(nPCContext.StringId))
						{
							_npcContexts[nPCContext.StringId] = nPCContext;
							UpdateStringIdIndex(nPCContext.StringId, nPCContext.StringId);
							num++;
						}
						else
						{
							num2++;
						}
					}
				}
				catch (Exception ex)
				{
					LogMessage("[ERROR] LoadAllNPCsForEvent: Failed to load " + Path.GetFileName(text) + ": " + ex.Message);
				}
			}
			LogMessage($"[INFO] LoadAllNPCsForEvent: Loaded {num} new NPCs, {num2} already in memory. Total in memory: {_npcContexts.Count}. File path cache filled: {num3} entries (total cache size: {_npcFilePathCache.Count})");
			InformationManager.DisplayMessage(new InformationMessage($"Loaded {num} new NPCs into memory, {num2} already in memory. Total in memory: {_npcContexts.Count} NPCs", ExtraColors.GreenAIInfluence));
		}
		catch (Exception ex2)
		{
			LogMessage("[ERROR] LoadAllNPCsForEvent failed: " + ex2.Message);
		}
	}

	public void CleanupDeadNPCs()
	{
		try
		{
			string activeSaveDirectory = GetActiveSaveDirectory();
			if (string.IsNullOrEmpty(activeSaveDirectory) || !Directory.Exists(activeSaveDirectory))
			{
				LogMessage("[WARNING] CleanupDeadNPCs: No save directory found.");
				return;
			}
			List<string> list = new List<string>();
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<string, NPCContext> item in _npcContexts.ToList())
			{
				string npcId = item.Key;
				NPCContext value = item.Value;
				if (npcId.Contains("Unknown_NPC") || npcId.Contains("kingdom_leadership_history") || npcId.Contains("settlement_ownership_history") || npcId.Contains("war_statistics"))
				{
					list.Add(npcId);
					LogMessage("[CLEANUP] Found system entry in memory (will remove): " + value.Name + " (" + npcId + ")");
					continue;
				}
				Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == npcId));
				if (val == null)
				{
					val = ((IEnumerable<Hero>)Hero.DeadOrDisabledHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == npcId));
					if (val != null && !val.IsAlive)
					{
						list.Add(npcId);
						LogMessage("[CLEANUP] Found dead NPC in memory: " + value.Name + " (" + npcId + ")");
					}
				}
			}
			foreach (string item2 in list)
			{
				if (_npcContexts.ContainsKey(item2))
				{
					NPCContext nPCContext = _npcContexts[item2];
					_npcContexts.Remove(item2);
					if (_stringIdToContextKey.ContainsKey(item2))
					{
						_stringIdToContextKey.Remove(item2);
					}
					num++;
					LogMessage("[CLEANUP] Removed from memory: " + nPCContext.Name + " (" + item2 + ")");
				}
			}
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
			{
				"dynamic_events.json", "pending_player_statements.json", "diplomatic_events.json", "war_statistics.json", "diplomatic_statements.json", "alliances.json", "alliance_data.json", "economic_effects.json", "settlement_ownership_history.json", "kingdom_leadership_history.json",
				"trade_agreements.json", "territory_transfers.json", "tribute_agreements.json", "tributes.json", "reparations.json", "rp_items.json", "disease_instances.json", "diseases.json", "settlement_disease_instances.json"
			};
			string[] files = Directory.GetFiles(activeSaveDirectory, "*.json");
			string[] array = files;
			foreach (string path in array)
			{
				try
				{
					string fileName = Path.GetFileName(path);
					if (hashSet.Contains(fileName))
					{
						continue;
					}
					string text = File.ReadAllText(path);
					NPCContext context = JsonConvert.DeserializeObject<NPCContext>(text);
					if (context == null || string.IsNullOrEmpty(context.StringId))
					{
						continue;
					}
					if (context.StringId.Contains("Unknown_NPC") || context.StringId.Contains("kingdom_leadership_history") || context.StringId.Contains("settlement_ownership_history") || context.StringId.Contains("war_statistics"))
					{
						File.Delete(path);
						num2++;
						LogMessage("[CLEANUP] Deleted system entry file: " + context.Name + " (" + context.StringId + ") - " + fileName);
						continue;
					}
					Hero val2 = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == context.StringId));
					if (val2 == null)
					{
						val2 = ((IEnumerable<Hero>)Hero.DeadOrDisabledHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == context.StringId));
						if (val2 != null && !val2.IsAlive)
						{
							File.Delete(path);
							num2++;
							LogMessage("[CLEANUP] Deleted file for dead NPC: " + context.Name + " (" + context.StringId + ") - " + fileName);
						}
					}
				}
				catch (Exception ex)
				{
					LogMessage("[ERROR] CleanupDeadNPCs: Failed to process file " + Path.GetFileName(path) + ": " + ex.Message);
				}
			}
			LogMessage($"[CLEANUP] Daily cleanup completed. Removed {num} NPCs from memory, deleted {num2} files. Active NPCs in memory: {_npcContexts.Count}");
		}
		catch (Exception ex2)
		{
			LogMessage("[ERROR] CleanupDeadNPCs failed: " + ex2.Message);
		}
	}

	private void EnsureValidTTSVoice(NPCContext context, Hero npc)
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableTTS)
		{
			return;
		}
		if (string.IsNullOrEmpty(context.Gender))
		{
			context.Gender = (npc.IsFemale ? "female" : "male");
		}
		Task.Run(async delegate
		{
			try
			{
				if (string.IsNullOrEmpty(context.AssignedTTSVoice))
				{
					string assignedVoice = await Player2Client.GetRandomVoiceAsync(context.Gender);
					if (!string.IsNullOrEmpty(assignedVoice))
					{
						context.AssignedTTSVoice = assignedVoice;
					}
					else
					{
						LogMessage("[WARNING] Failed to assign TTS voice to " + context.Name + " (gender: " + context.Gender + "). TTS will be disabled for this NPC.");
					}
				}
				else if (!(await Player2Client.VoiceExistsAsync(context.AssignedTTSVoice)))
				{
					LogMessage("[TTS] Voice " + context.AssignedTTSVoice + " for " + context.Name + " no longer exists in API. Replacing with new voice.");
					string newVoice = await Player2Client.GetRandomVoiceAsync(context.Gender);
					if (!string.IsNullOrEmpty(newVoice))
					{
						context.AssignedTTSVoice = newVoice;
						LogMessage("[TTS] Replaced voice for " + context.Name + ": " + newVoice);
					}
					else
					{
						LogMessage("[WARNING] Failed to assign new voice for " + context.Name + ". TTS will be disabled.");
						context.AssignedTTSVoice = null;
					}
				}
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				LogMessage("[TTS_ERROR] Exception while ensuring voice for " + context.Name + ": " + ex2.Message);
			}
		});
	}

	public string AssignRandomVoiceForGender(string gender)
	{
		try
		{
			string randomVoice = Player2Client.GetRandomVoice(gender);
			if (string.IsNullOrEmpty(randomVoice))
			{
				LogMessage("[TTS_ERROR] Failed to assign voice for gender " + gender + ". GetRandomVoice returned null or empty string.");
				return null;
			}
			LogMessage("[TTS] Successfully assigned voice " + randomVoice + " for gender " + gender);
			return randomVoice;
		}
		catch (Exception ex)
		{
			LogMessage("[TTS_ERROR] Exception while assigning voice for gender " + gender + ": " + ex.Message);
			LogMessage("[TTS_ERROR] StackTrace: " + ex.StackTrace);
			return null;
		}
	}

	public List<NPCEraseInfo> GetInitializedNPCs()
	{
		List<NPCEraseInfo> list = new List<NPCEraseInfo>();
		string activeSaveDirectory = GetActiveSaveDirectory();
		if (string.IsNullOrEmpty(activeSaveDirectory) || !Directory.Exists(activeSaveDirectory))
		{
			LogMessage("[NPC_ERASE] No save directory found.");
			return list;
		}
		try
		{
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
			{
				"dynamic_events.json", "pending_player_statements.json", "diplomatic_events.json", "war_statistics.json", "diplomatic_statements.json", "alliances.json", "alliance_data.json", "economic_effects.json", "settlement_ownership_history.json", "kingdom_leadership_history.json",
				"trade_agreements.json", "territory_transfers.json", "tribute_agreements.json", "tributes.json", "reparations.json", "rp_items.json"
			};
			string[] files = Directory.GetFiles(activeSaveDirectory, "*.json");
			string[] array = files;
			foreach (string text in array)
			{
				try
				{
					string fileName = Path.GetFileName(text);
					if (hashSet.Contains(fileName))
					{
						continue;
					}
					string text2 = File.ReadAllText(text);
					NPCContext context = JsonConvert.DeserializeObject<NPCContext>(text2);
					if (context == null || string.IsNullOrEmpty(context.StringId))
					{
						continue;
					}
					Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == context.StringId));
					if (val != null)
					{
						NPCEraseInfo obj = new NPCEraseInfo
						{
							StringId = context.StringId,
							Name = context.Name,
							FilePath = text,
							Hero = val,
							Context = context,
							InteractionCount = context.InteractionCount
						};
						List<string> conversationHistory = context.ConversationHistory;
						obj.HasConversationHistory = conversationHistory != null && conversationHistory.Count > 0;
						List<string> knownSecrets = context.KnownSecrets;
						obj.HasKnownSecrets = knownSecrets != null && knownSecrets.Count > 0;
						List<string> knownInfo = context.KnownInfo;
						obj.HasKnownInfo = knownInfo != null && knownInfo.Count > 0;
						List<CampaignEvent> recentEvents = context.RecentEvents;
						int hasEvents;
						if (recentEvents == null || recentEvents.Count <= 0)
						{
							List<CampaignEvent> dialogueAnalysisEvents = context.DialogueAnalysisEvents;
							hasEvents = ((dialogueAnalysisEvents != null && dialogueAnalysisEvents.Count > 0) ? 1 : 0);
						}
						else
						{
							hasEvents = 1;
						}
						obj.HasEvents = (byte)hasEvents != 0;
						list.Add(obj);
					}
				}
				catch (Exception ex)
				{
					LogMessage("[NPC_ERASE] Error reading file " + Path.GetFileName(text) + ": " + ex.Message);
				}
			}
			LogMessage($"[NPC_ERASE] Found {list.Count} initialized NPCs");
		}
		catch (Exception ex2)
		{
			LogMessage("[NPC_ERASE] Error getting initialized NPCs: " + ex2.Message);
		}
		return list;
	}

	public bool EraseSpecificNPC(string npcStringId)
	{
		try
		{
			LogMessage("[NPC_ERASE] Starting erase for NPC: " + npcStringId);
			if (_npcContexts.ContainsKey(npcStringId))
			{
				_npcContexts.Remove(npcStringId);
				LogMessage("[NPC_ERASE] Removed from memory: " + npcStringId);
			}
			if (_stringIdToContextKey.ContainsKey(npcStringId))
			{
				_stringIdToContextKey.Remove(npcStringId);
				LogMessage("[NPC_ERASE] Removed from StringId index: " + npcStringId);
			}
			string activeSaveDirectory = GetActiveSaveDirectory();
			if (!string.IsNullOrEmpty(activeSaveDirectory))
			{
				string text = FindNPCFileByStringId(activeSaveDirectory, npcStringId);
				if (!string.IsNullOrEmpty(text) && File.Exists(text))
				{
					File.Delete(text);
					LogMessage("[NPC_ERASE] Deleted file: " + Path.GetFileName(text));
				}
			}
			LogMessage("[NPC_ERASE] Successfully erased NPC: " + npcStringId);
			return true;
		}
		catch (Exception ex)
		{
			LogMessage("[NPC_ERASE] Error erasing NPC " + npcStringId + ": " + ex.Message);
			return false;
		}
	}

	private void ShowNPCEraseWindow()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		try
		{
			InformationManager.HideInquiry();
			List<NPCEraseInfo> initializedNPCs = GetInitializedNPCs();
			if (!initializedNPCs.Any())
			{
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPC_Erase_No_NPCs_Found}No initialized NPCs found. No NPCs have been created yet.", (Dictionary<string, object>)null)).ToString(), Colors.Yellow));
				return;
			}
			initializedNPCs = initializedNPCs.OrderBy((NPCEraseInfo n) => n.Name).ToList();
			ShowNPCErasePage(initializedNPCs, 0);
		}
		catch (Exception ex)
		{
			LogMessage("[NPC_ERASE] Error showing NPC erase window: " + ex.Message);
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPC_Erase_Error_Message}Error showing NPC selection window: {ERROR}", new Dictionary<string, object> { { "ERROR", ex.Message } })).ToString(), ExtraColors.RedAIInfluence));
		}
	}

	private void ShowNPCErasePage(List<NPCEraseInfo> npcList, int pageIndex)
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		int totalPages = (npcList.Count + 15 - 1) / 15;
		int startIndex = pageIndex * 15;
		int num = Math.Min(startIndex + 15, npcList.Count);
		LogMessage($"[NPC_ERASE_DEBUG] Showing page {pageIndex + 1}/{totalPages}, NPCs {startIndex + 1}-{num} of {npcList.Count}");
		List<NPCEraseInfo> source = npcList.Skip(startIndex).Take(15).ToList();
		List<string> values = source.Select(delegate(NPCEraseInfo npc, int index)
		{
			int num2 = startIndex + index + 1;
			LogMessage($"[NPC_ERASE_DEBUG] {npc.Name}: Conversations={npc.HasConversationHistory} ({(npc.Context?.ConversationHistory?.Count).GetValueOrDefault()}), " + $"Secrets={npc.HasKnownSecrets} ({(npc.Context?.KnownSecrets?.Count).GetValueOrDefault()}), " + $"Info={npc.HasKnownInfo} ({(npc.Context?.KnownInfo?.Count).GetValueOrDefault()}), " + $"Events={npc.HasEvents} (Recent={(npc.Context?.RecentEvents?.Count).GetValueOrDefault()}, Dialogue={(npc.Context?.DialogueAnalysisEvents?.Count).GetValueOrDefault()})");
			return $"{num2}. {npc.Name}";
		}).ToList();
		string text = string.Join("\n", values);
		string text2;
		string text3;
		if (totalPages == 1)
		{
			text2 = ((object)new TextObject("{=AIInfluence_NPC_Erase_Select_NPC_Button}Select NPC", (Dictionary<string, object>)null)).ToString();
			text3 = ((object)new TextObject("{=AIInfluence_NPC_Erase_Cancel_Button}Cancel", (Dictionary<string, object>)null)).ToString();
			LogMessage("[NPC_ERASE_DEBUG] Single page mode: Select NPC + Cancel");
		}
		else if (pageIndex == 0)
		{
			text2 = ((object)new TextObject("{=AIInfluence_NPC_Erase_Next_Page_Button}Next Page", (Dictionary<string, object>)null)).ToString();
			text3 = ((object)new TextObject("{=AIInfluence_NPC_Erase_Cancel_Button}Cancel", (Dictionary<string, object>)null)).ToString();
			LogMessage("[NPC_ERASE_DEBUG] First page mode: Next Page + Cancel");
		}
		else if (pageIndex == totalPages - 1)
		{
			text2 = ((object)new TextObject("{=AIInfluence_NPC_Erase_Select_NPC_Button}Select NPC", (Dictionary<string, object>)null)).ToString();
			text3 = ((object)new TextObject("{=AIInfluence_NPC_Erase_Previous_Page_Button}Previous Page", (Dictionary<string, object>)null)).ToString();
			LogMessage("[NPC_ERASE_DEBUG] Last page mode: Select NPC + Previous Page");
		}
		else
		{
			text2 = ((object)new TextObject("{=AIInfluence_NPC_Erase_Next_Page_Button}Next Page", (Dictionary<string, object>)null)).ToString();
			text3 = ((object)new TextObject("{=AIInfluence_NPC_Erase_Previous_Page_Button}Previous Page", (Dictionary<string, object>)null)).ToString();
			LogMessage("[NPC_ERASE_DEBUG] Middle page mode: Next Page + Previous Page");
		}
		InformationManager.ShowInquiry(new InquiryData(((object)new TextObject("{=AIInfluence_NPC_Erase_Page_Title}Select NPC to Erase (Page {PAGE}/{TOTAL})", new Dictionary<string, object>
		{
			{
				"PAGE",
				pageIndex + 1
			},
			{ "TOTAL", totalPages }
		})).ToString(), ((object)new TextObject("{=AIInfluence_NPC_Erase_Select_Description}Choose an NPC to permanently delete from memory and saved files. This action cannot be undone!", (Dictionary<string, object>)null)).ToString() + "\n\n" + ((object)new TextObject("{=AIInfluence_NPC_Erase_Available_NPCs}Available NPCs ({COUNT} total):", new Dictionary<string, object> { { "COUNT", npcList.Count } })).ToString() + "\n\n" + text, true, true, text2, text3, (Action)delegate
		{
			LogMessage($"[NPC_ERASE_DEBUG] Affirmative button clicked on page {pageIndex + 1}");
			InformationManager.HideInquiry();
			if (pageIndex < totalPages - 1)
			{
				LogMessage($"[NPC_ERASE_DEBUG] Navigating to next page {pageIndex + 2}");
				Task.Delay(100).ContinueWith(delegate
				{
					ShowNPCErasePage(npcList, pageIndex + 1);
				});
			}
			else
			{
				LogMessage("[NPC_ERASE_DEBUG] Showing NPC selection dialog");
				Task.Delay(100).ContinueWith(delegate
				{
					ShowNPCSelectionDialog(npcList);
				});
			}
		}, (Action)delegate
		{
			LogMessage($"[NPC_ERASE_DEBUG] Negative button clicked on page {pageIndex + 1}");
			InformationManager.HideInquiry();
			if (pageIndex > 0)
			{
				LogMessage($"[NPC_ERASE_DEBUG] Navigating to previous page {pageIndex}");
				Task.Delay(100).ContinueWith(delegate
				{
					ShowNPCErasePage(npcList, pageIndex - 1);
				});
			}
		}, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), false, false);
	}

	private void ShowNPCSelectionDialog(List<NPCEraseInfo> npcList)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		LogMessage($"[NPC_ERASE_DEBUG] Starting NPC selection dialog for {npcList.Count} NPCs");
		AIInfluenceTextQueryPopupManager.Show(new TextInquiryData(((object)new TextObject("{=AIInfluence_NPC_Erase_Enter_Number_Title}Enter NPC Number", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_NPC_Erase_Enter_Number_Description}Enter the number of the NPC you want to erase (1-{COUNT}):", new Dictionary<string, object> { { "COUNT", npcList.Count } })).ToString(), true, true, ((object)new TextObject("{=AIInfluence_NPC_Erase_Erase_Button}Erase", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_NPC_Erase_Cancel_Button}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<string>)delegate(string result)
		{
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Expected O, but got Unknown
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			LogMessage("[NPC_ERASE_DEBUG] Text input result: '" + result + "'");
			if (int.TryParse(result, out var result2) && result2 > 0 && result2 <= npcList.Count)
			{
				NPCEraseInfo selectedNPC = npcList[result2 - 1];
				LogMessage($"[NPC_ERASE_DEBUG] Selected NPC: {selectedNPC.Name} (index {result2})");
				LogMessage("[NPC_ERASE_DEBUG] About to show confirmation dialog");
				Task.Delay(100).ContinueWith(delegate
				{
					//IL_001d: Unknown result type (might be due to invalid IL or missing references)
					//IL_0027: Expected O, but got Unknown
					//IL_0048: Unknown result type (might be due to invalid IL or missing references)
					//IL_0052: Expected O, but got Unknown
					//IL_005a: Unknown result type (might be due to invalid IL or missing references)
					//IL_0064: Expected O, but got Unknown
					//IL_006a: Unknown result type (might be due to invalid IL or missing references)
					//IL_0074: Expected O, but got Unknown
					//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
					//IL_00cb: Expected O, but got Unknown
					LogMessage("[NPC_ERASE_DEBUG] Showing confirmation dialog after delay");
					InformationManager.ShowInquiry(new InquiryData(((object)new TextObject("{=AIInfluence_NPC_Erase_Confirm_Title}Confirm NPC Erase", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_NPC_Erase_Confirm_Description}Are you sure you want to permanently delete {NAME}? This will completely remove the NPC from the game. This action cannot be undone!", new Dictionary<string, object> { { "NAME", selectedNPC.Name } })).ToString(), true, true, ((object)new TextObject("{=AIInfluence_NPC_Erase_Confirm_Yes_Button}Yes, Delete", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_NPC_Erase_Confirm_Cancel_Button}Cancel", (Dictionary<string, object>)null)).ToString(), (Action)delegate
					{
						//IL_0121: Unknown result type (might be due to invalid IL or missing references)
						//IL_012b: Expected O, but got Unknown
						//IL_012b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0130: Unknown result type (might be due to invalid IL or missing references)
						//IL_013a: Expected O, but got Unknown
						//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
						//IL_00c6: Expected O, but got Unknown
						//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
						//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d5: Expected O, but got Unknown
						LogMessage("[NPC_ERASE_DEBUG] Confirmation accepted for " + selectedNPC.Name);
						InformationManager.HideInquiry();
						LogMessage("[NPC_ERASE_DEBUG] Starting erase process for " + selectedNPC.StringId);
						if (EraseSpecificNPC(selectedNPC.StringId))
						{
							LogMessage("[NPC_ERASE_DEBUG] Erase successful for " + selectedNPC.Name);
							InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPC_Erase_Success_Message}Successfully erased {NAME} from memory and saved files.", new Dictionary<string, object> { { "NAME", selectedNPC.Name } })).ToString(), ExtraColors.GreenAIInfluence));
						}
						else
						{
							LogMessage("[NPC_ERASE_DEBUG] Erase failed for " + selectedNPC.Name);
							InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPC_Erase_Failed_Message}Failed to erase {NAME}. Check logs for details.", new Dictionary<string, object> { { "NAME", selectedNPC.Name } })).ToString(), ExtraColors.RedAIInfluence));
						}
					}, (Action)delegate
					{
						LogMessage("[NPC_ERASE_DEBUG] Confirmation cancelled for " + selectedNPC.Name);
					}, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), false, false);
					LogMessage("[NPC_ERASE_DEBUG] Confirmation dialog should now be visible");
				});
			}
			else
			{
				LogMessage($"[NPC_ERASE_DEBUG] Invalid NPC number: '{result}', valid range: 1-{npcList.Count}");
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPC_Erase_Invalid_Number_Message}Invalid NPC number. Please enter a number between 1 and {COUNT}.", new Dictionary<string, object> { { "COUNT", npcList.Count } })).ToString(), ExtraColors.RedAIInfluence));
			}
		}, (Action)delegate
		{
			LogMessage("[NPC_ERASE_DEBUG] Text input cancelled");
		}, false, (Func<string, Tuple<bool, string>>)null, "", ""));
	}

	public void ProcessKingdomAction(Hero npc, AIResponse aiResult, NPCContext context)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification || npc == null || aiResult == null || string.IsNullOrWhiteSpace(aiResult.KingdomAction) || aiResult.KingdomAction.Equals("none", StringComparison.OrdinalIgnoreCase))
		{
			return;
		}
		DelayedTaskManager delayedTaskManager = GetDelayedTaskManager();
		if (delayedTaskManager != null)
		{
			AIResponse snapshot = new AIResponse
			{
				KingdomAction = aiResult.KingdomAction,
				KingdomActionReason = aiResult.KingdomActionReason
			};
			string text = ((object)npc.Name)?.ToString() ?? "Unknown";
			LogMessage("[KINGDOM_ACTION] Scheduled '" + snapshot.KingdomAction + "' from " + text + " to execute in 6 seconds.");
			delayedTaskManager.AddTask(6.0, delegate
			{
				try
				{
					ExecuteKingdomAction(npc, snapshot, context);
				}
				catch (Exception ex)
				{
					LogMessage("[ERROR] Delayed kingdom action '" + snapshot.KingdomAction + "' failed: " + ex.Message + "\n" + ex.StackTrace);
				}
			});
		}
		else
		{
			ExecuteKingdomAction(npc, aiResult, context);
		}
	}

	private void ExecuteKingdomAction(Hero npc, AIResponse aiResult, NPCContext context)
	{
		//IL_10ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c1: Expected O, but got Unknown
		//IL_10c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d7: Expected O, but got Unknown
		//IL_131b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1322: Expected O, but got Unknown
		//IL_1329: Unknown result type (might be due to invalid IL or missing references)
		//IL_132e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1338: Expected O, but got Unknown
		//IL_148b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1492: Expected O, but got Unknown
		//IL_1499: Unknown result type (might be due to invalid IL or missing references)
		//IL_149e: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a8: Expected O, but got Unknown
		//IL_1600: Unknown result type (might be due to invalid IL or missing references)
		//IL_1607: Expected O, but got Unknown
		//IL_160e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1613: Unknown result type (might be due to invalid IL or missing references)
		//IL_161d: Expected O, but got Unknown
		//IL_1e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e97: Expected O, but got Unknown
		//IL_1e9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ead: Expected O, but got Unknown
		//IL_21c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d0: Expected O, but got Unknown
		//IL_21d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_21dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e6: Expected O, but got Unknown
		//IL_24cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d6: Expected O, but got Unknown
		//IL_24dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ec: Expected O, but got Unknown
		//IL_262f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2636: Expected O, but got Unknown
		//IL_263d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2642: Unknown result type (might be due to invalid IL or missing references)
		//IL_264c: Expected O, but got Unknown
		//IL_283f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2846: Expected O, but got Unknown
		//IL_284d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2852: Unknown result type (might be due to invalid IL or missing references)
		//IL_285c: Expected O, but got Unknown
		//IL_2a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a6f: Expected O, but got Unknown
		//IL_2a76: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a85: Expected O, but got Unknown
		//IL_2f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f74: Expected O, but got Unknown
		//IL_2f81: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f86: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f90: Expected O, but got Unknown
		//IL_34f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_34fc: Expected O, but got Unknown
		//IL_3509: Unknown result type (might be due to invalid IL or missing references)
		//IL_350e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3518: Expected O, but got Unknown
		//IL_3b47: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b50: Expected O, but got Unknown
		//IL_3b5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b6c: Expected O, but got Unknown
		//IL_183c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1846: Expected O, but got Unknown
		//IL_1846: Unknown result type (might be due to invalid IL or missing references)
		//IL_184b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1855: Expected O, but got Unknown
		//IL_1e3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e44: Expected O, but got Unknown
		//IL_1e44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e49: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e53: Expected O, but got Unknown
		//IL_1be6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Invalid comparison between Unknown and I4
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Invalid comparison between Unknown and I4
		//IL_1654: Unknown result type (might be due to invalid IL or missing references)
		//IL_165b: Invalid comparison between Unknown and I4
		//IL_0add: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae4: Expected O, but got Unknown
		//IL_0aeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afa: Expected O, but got Unknown
		//IL_0a7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a86: Expected O, but got Unknown
		//IL_0a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a95: Expected O, but got Unknown
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Expected O, but got Unknown
		//IL_0957: Unknown result type (might be due to invalid IL or missing references)
		//IL_095c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0966: Expected O, but got Unknown
		//IL_254a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2551: Expected O, but got Unknown
		//IL_2570: Unknown result type (might be due to invalid IL or missing references)
		//IL_2575: Unknown result type (might be due to invalid IL or missing references)
		//IL_257f: Expected O, but got Unknown
		//IL_08b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bc: Expected O, but got Unknown
		//IL_08bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cb: Expected O, but got Unknown
		//IL_09f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a03: Expected O, but got Unknown
		//IL_0a03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Expected O, but got Unknown
		//IL_0d69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d70: Expected O, but got Unknown
		//IL_0d77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d86: Expected O, but got Unknown
		//IL_1669: Unknown result type (might be due to invalid IL or missing references)
		//IL_166f: Invalid comparison between Unknown and I4
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b55: Expected O, but got Unknown
		//IL_0b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b64: Expected O, but got Unknown
		//IL_2fc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fcf: Expected O, but got Unknown
		//IL_2ff8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ffd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3007: Expected O, but got Unknown
		//IL_117c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1183: Expected O, but got Unknown
		//IL_11b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c5: Expected O, but got Unknown
		//IL_3047: Unknown result type (might be due to invalid IL or missing references)
		//IL_3050: Expected O, but got Unknown
		//IL_3079: Unknown result type (might be due to invalid IL or missing references)
		//IL_307e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3088: Expected O, but got Unknown
		//IL_25d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e2: Expected O, but got Unknown
		//IL_25e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f1: Expected O, but got Unknown
		//IL_1511: Unknown result type (might be due to invalid IL or missing references)
		//IL_1518: Expected O, but got Unknown
		//IL_1537: Unknown result type (might be due to invalid IL or missing references)
		//IL_153c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1546: Expected O, but got Unknown
		//IL_354e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3557: Expected O, but got Unknown
		//IL_3580: Unknown result type (might be due to invalid IL or missing references)
		//IL_3585: Unknown result type (might be due to invalid IL or missing references)
		//IL_358f: Expected O, but got Unknown
		//IL_11e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f0: Expected O, but got Unknown
		//IL_0bb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbf: Expected O, but got Unknown
		//IL_0bc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd5: Expected O, but got Unknown
		//IL_30de: Unknown result type (might be due to invalid IL or missing references)
		//IL_30e7: Expected O, but got Unknown
		//IL_3110: Unknown result type (might be due to invalid IL or missing references)
		//IL_3115: Unknown result type (might be due to invalid IL or missing references)
		//IL_311f: Expected O, but got Unknown
		//IL_0ca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb0: Expected O, but got Unknown
		//IL_0cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc6: Expected O, but got Unknown
		//IL_1267: Unknown result type (might be due to invalid IL or missing references)
		//IL_1248: Unknown result type (might be due to invalid IL or missing references)
		//IL_124d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1257: Expected O, but got Unknown
		//IL_2256: Unknown result type (might be due to invalid IL or missing references)
		//IL_225d: Expected O, but got Unknown
		//IL_227c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2281: Unknown result type (might be due to invalid IL or missing references)
		//IL_228b: Expected O, but got Unknown
		//IL_0c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c46: Expected O, but got Unknown
		//IL_0c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c55: Expected O, but got Unknown
		//IL_26bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_26c3: Expected O, but got Unknown
		//IL_26e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_26f1: Expected O, but got Unknown
		//IL_15a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15af: Expected O, but got Unknown
		//IL_15af: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_15be: Expected O, but got Unknown
		//IL_139c: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a3: Expected O, but got Unknown
		//IL_13c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d1: Expected O, but got Unknown
		//IL_0d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d12: Expected O, but got Unknown
		//IL_0d12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d21: Expected O, but got Unknown
		//IL_28cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d3: Expected O, but got Unknown
		//IL_28f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2901: Expected O, but got Unknown
		//IL_12c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12cb: Expected O, but got Unknown
		//IL_12cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12da: Expected O, but got Unknown
		//IL_0e28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e32: Expected O, but got Unknown
		//IL_0e32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e41: Expected O, but got Unknown
		//IL_22be: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c5: Expected O, but got Unknown
		//IL_22e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_22e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f3: Expected O, but got Unknown
		//IL_1f1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f24: Expected O, but got Unknown
		//IL_1f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f52: Expected O, but got Unknown
		//IL_2323: Unknown result type (might be due to invalid IL or missing references)
		//IL_232a: Expected O, but got Unknown
		//IL_2349: Unknown result type (might be due to invalid IL or missing references)
		//IL_234e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2358: Expected O, but got Unknown
		//IL_2dd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ddc: Expected O, but got Unknown
		//IL_2dfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e00: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e0a: Expected O, but got Unknown
		//IL_1430: Unknown result type (might be due to invalid IL or missing references)
		//IL_143a: Expected O, but got Unknown
		//IL_143a: Unknown result type (might be due to invalid IL or missing references)
		//IL_143f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1449: Expected O, but got Unknown
		//IL_1f85: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8c: Expected O, but got Unknown
		//IL_1fab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fba: Expected O, but got Unknown
		//IL_2b56: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b5d: Expected O, but got Unknown
		//IL_2b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b8b: Expected O, but got Unknown
		//IL_0f1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f24: Expected O, but got Unknown
		//IL_0f57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f66: Expected O, but got Unknown
		//IL_1fea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff1: Expected O, but got Unknown
		//IL_2010: Unknown result type (might be due to invalid IL or missing references)
		//IL_2015: Unknown result type (might be due to invalid IL or missing references)
		//IL_201f: Expected O, but got Unknown
		//IL_23b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b9: Expected O, but got Unknown
		//IL_23d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_23dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e7: Expected O, but got Unknown
		//IL_2cf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cfc: Expected O, but got Unknown
		//IL_2d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d43: Expected O, but got Unknown
		//IL_2bb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bbf: Expected O, but got Unknown
		//IL_2bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c06: Expected O, but got Unknown
		//IL_0f87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8e: Expected O, but got Unknown
		//IL_0fad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbc: Expected O, but got Unknown
		//IL_275b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2762: Expected O, but got Unknown
		//IL_2781: Unknown result type (might be due to invalid IL or missing references)
		//IL_2786: Unknown result type (might be due to invalid IL or missing references)
		//IL_2790: Expected O, but got Unknown
		//IL_2970: Unknown result type (might be due to invalid IL or missing references)
		//IL_2977: Expected O, but got Unknown
		//IL_2996: Unknown result type (might be due to invalid IL or missing references)
		//IL_299b: Unknown result type (might be due to invalid IL or missing references)
		//IL_29a5: Expected O, but got Unknown
		//IL_2d6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d72: Expected O, but got Unknown
		//IL_2d91: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d96: Unknown result type (might be due to invalid IL or missing references)
		//IL_2da0: Expected O, but got Unknown
		//IL_2c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c46: Expected O, but got Unknown
		//IL_2c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c74: Expected O, but got Unknown
		//IL_0fea: Unknown result type (might be due to invalid IL or missing references)
		//IL_3600: Unknown result type (might be due to invalid IL or missing references)
		//IL_3609: Expected O, but got Unknown
		//IL_3632: Unknown result type (might be due to invalid IL or missing references)
		//IL_3637: Unknown result type (might be due to invalid IL or missing references)
		//IL_3641: Expected O, but got Unknown
		//IL_2471: Unknown result type (might be due to invalid IL or missing references)
		//IL_247b: Expected O, but got Unknown
		//IL_247b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2480: Unknown result type (might be due to invalid IL or missing references)
		//IL_248a: Expected O, but got Unknown
		//IL_1059: Unknown result type (might be due to invalid IL or missing references)
		//IL_1063: Expected O, but got Unknown
		//IL_1063: Unknown result type (might be due to invalid IL or missing references)
		//IL_1068: Unknown result type (might be due to invalid IL or missing references)
		//IL_1072: Expected O, but got Unknown
		//IL_27e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f2: Expected O, but got Unknown
		//IL_27f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2801: Expected O, but got Unknown
		//IL_2a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a1b: Expected O, but got Unknown
		//IL_2a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a20: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a2a: Expected O, but got Unknown
		//IL_3681: Unknown result type (might be due to invalid IL or missing references)
		//IL_368a: Expected O, but got Unknown
		//IL_36b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_36b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_36c2: Expected O, but got Unknown
		//IL_210b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2088: Unknown result type (might be due to invalid IL or missing references)
		//IL_3718: Unknown result type (might be due to invalid IL or missing references)
		//IL_3721: Expected O, but got Unknown
		//IL_374a: Unknown result type (might be due to invalid IL or missing references)
		//IL_374f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3759: Expected O, but got Unknown
		//IL_216a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2174: Expected O, but got Unknown
		//IL_2174: Unknown result type (might be due to invalid IL or missing references)
		//IL_2179: Unknown result type (might be due to invalid IL or missing references)
		//IL_2183: Expected O, but got Unknown
		//IL_20e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f3: Expected O, but got Unknown
		//IL_20f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2102: Expected O, but got Unknown
		//IL_16ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f0: Invalid comparison between Unknown and I4
		//IL_328c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3295: Expected O, but got Unknown
		//IL_18a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18aa: Expected O, but got Unknown
		//IL_18c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d8: Expected O, but got Unknown
		//IL_2ee5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eef: Expected O, but got Unknown
		//IL_2eef: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ef4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2efe: Expected O, but got Unknown
		//IL_2e89: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e93: Expected O, but got Unknown
		//IL_2e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e98: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ea2: Expected O, but got Unknown
		//IL_3370: Unknown result type (might be due to invalid IL or missing references)
		//IL_3375: Unknown result type (might be due to invalid IL or missing references)
		//IL_337f: Expected O, but got Unknown
		//IL_3490: Unknown result type (might be due to invalid IL or missing references)
		//IL_3499: Expected O, but got Unknown
		//IL_34a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_34b5: Expected O, but got Unknown
		//IL_343b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3445: Expected O, but got Unknown
		//IL_3445: Unknown result type (might be due to invalid IL or missing references)
		//IL_344a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3454: Expected O, but got Unknown
		//IL_3869: Unknown result type (might be due to invalid IL or missing references)
		//IL_3872: Expected O, but got Unknown
		//IL_3973: Unknown result type (might be due to invalid IL or missing references)
		//IL_397c: Expected O, but got Unknown
		//IL_39c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_39c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_39d1: Expected O, but got Unknown
		//IL_3926: Unknown result type (might be due to invalid IL or missing references)
		//IL_392b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3935: Expected O, but got Unknown
		//IL_3ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aed: Expected O, but got Unknown
		//IL_3afa: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aff: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b09: Expected O, but got Unknown
		//IL_3a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a9b: Expected O, but got Unknown
		//IL_3a9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aa0: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aaa: Expected O, but got Unknown
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		try
		{
			if (aiResult == null || string.IsNullOrWhiteSpace(aiResult.KingdomAction))
			{
				return;
			}
			string text = aiResult.KingdomAction.ToLower();
			if (text == "none")
			{
				return;
			}
			string text2 = (string.IsNullOrWhiteSpace(aiResult.KingdomActionReason) ? "none" : aiResult.KingdomActionReason.Trim());
			int num;
			switch (text)
			{
			default:
				num = ((text == "break_alliance") ? 1 : 0);
				break;
			case "declare_war":
			case "propose_peace":
			case "accept_peace":
			case "reject_peace":
			case "propose_alliance":
			case "accept_alliance":
			case "reject_alliance":
				num = 1;
				break;
			}
			bool flag = (byte)num != 0;
			int num2;
			switch (text)
			{
			default:
				num2 = ((text == "dismiss_vassal") ? 1 : 0);
				break;
			case "hire_mercenary":
			case "offer_vassalage":
			case "dismiss_mercenary":
				num2 = 1;
				break;
			}
			bool flag2 = (byte)num2 != 0;
			bool flag3 = text == "join_player_clan" || text == "join_player_kingdom" || text == "hire_mercenary_clan";
			bool flag4 = text == "kick_from_clan" || text == "dismiss_npc_mercenary" || text == "release_npc_vassal";
			bool flag5 = text == "transfer_kingdom";
			if (flag)
			{
				if (npc.MapFaction is Kingdom)
				{
					IFaction mapFaction = npc.MapFaction;
					if (npc == ((mapFaction != null) ? mapFaction.Leader : null))
					{
						goto IL_01db;
					}
				}
				LogMessage("[KINGDOM_ACTION] Skipping - NPC is not a kingdom leader (action: " + text + ")");
				return;
			}
			goto IL_01db;
			IL_04d0:
			Kingdom npcKingdom = default(Kingdom);
			Kingdom playerKingdom;
			switch (text)
			{
			case "declare_war":
				if (!FactionManager.IsAtWarAgainstFaction((IFaction)(object)npcKingdom, (IFaction)(object)playerKingdom))
				{
					DiplomacyPatches.WithBypass(delegate
					{
						DeclareWarAction.ApplyByDefault((IFaction)(object)npcKingdom, (IFaction)(object)playerKingdom);
					});
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_DeclareWar}{KINGDOM} has declared war on {PLAYER_KINGDOM}! Reason: {REASON}", new Dictionary<string, object>
					{
						{ "KINGDOM", npcKingdom.Name },
						{ "PLAYER_KINGDOM", playerKingdom.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "not specified"
						}
					})).ToString(), ExtraColors.RedAIInfluence));
					LogMessage($"[KINGDOM_ACTION] War declared by {npcKingdom.Name} on {playerKingdom.Name}");
				}
				break;
			case "propose_peace":
				if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)npcKingdom, (IFaction)(object)playerKingdom))
				{
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_ProposePeace}{KINGDOM} proposes peace! Reason: {REASON}", new Dictionary<string, object>
					{
						{ "KINGDOM", npcKingdom.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "not specified"
						}
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Peace proposed by {npcKingdom.Name} to {playerKingdom.Name}");
				}
				break;
			case "accept_peace":
				if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)npcKingdom, (IFaction)(object)playerKingdom))
				{
					DiplomacyPatches.WithBypass(delegate
					{
						MakePeaceAction.Apply((IFaction)(object)npcKingdom, (IFaction)(object)playerKingdom);
					});
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_AcceptPeace}{KINGDOM} has accepted peace with {PLAYER_KINGDOM}!", new Dictionary<string, object>
					{
						{ "KINGDOM", npcKingdom.Name },
						{ "PLAYER_KINGDOM", playerKingdom.Name }
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Peace accepted between {npcKingdom.Name} and {playerKingdom.Name}");
				}
				break;
			case "reject_peace":
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_RejectPeace}{KINGDOM} has rejected the peace proposal! Reason: {REASON}", new Dictionary<string, object>
				{
					{ "KINGDOM", npcKingdom.Name },
					{
						"REASON",
						aiResult.KingdomActionReason ?? "not specified"
					}
				})).ToString(), ExtraColors.RedAIInfluence));
				LogMessage($"[KINGDOM_ACTION] Peace rejected by {npcKingdom.Name}");
				break;
			case "propose_alliance":
				if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
				{
					LogMessage("[KINGDOM_ACTION] Alliance actions disabled - diplomacy system is off");
					TextObject val10 = new TextObject("{=AIInfluence_AllianceSystemDisabled}Alliance system is disabled. Enable diplomacy in mod settings to use alliances.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val10).ToString(), ExtraColors.RedAIInfluence));
				}
				else if (AllianceSystem.Instance != null)
				{
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_ProposeAlliance}{KINGDOM} proposes an alliance! Reason: {REASON}", new Dictionary<string, object>
					{
						{ "KINGDOM", npcKingdom.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "not specified"
						}
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Alliance proposed by {npcKingdom.Name} to {playerKingdom.Name}");
				}
				break;
			case "accept_alliance":
				if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
				{
					LogMessage("[KINGDOM_ACTION] Alliance actions disabled - diplomacy system is off");
					TextObject val21 = new TextObject("{=AIInfluence_AllianceSystemDisabled}Alliance system is disabled. Enable diplomacy in mod settings to use alliances.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val21).ToString(), ExtraColors.RedAIInfluence));
				}
				else if (AllianceSystem.Instance != null)
				{
					AllianceSystem.Instance.CreateAlliance(npcKingdom, playerKingdom);
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_AcceptAlliance}{KINGDOM} has accepted the alliance proposal with {PLAYER_KINGDOM}!", new Dictionary<string, object>
					{
						{ "KINGDOM", npcKingdom.Name },
						{ "PLAYER_KINGDOM", playerKingdom.Name }
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Alliance formed between {npcKingdom.Name} and {playerKingdom.Name}");
				}
				break;
			case "reject_alliance":
				if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
				{
					LogMessage("[KINGDOM_ACTION] Alliance actions disabled - diplomacy system is off");
					TextObject val57 = new TextObject("{=AIInfluence_AllianceSystemDisabled}Alliance system is disabled. Enable diplomacy in mod settings to use alliances.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val57).ToString(), ExtraColors.RedAIInfluence));
				}
				else
				{
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_RejectAlliance}{KINGDOM} has rejected the alliance proposal! Reason: {REASON}", new Dictionary<string, object>
					{
						{ "KINGDOM", npcKingdom.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "not specified"
						}
					})).ToString(), ExtraColors.RedAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Alliance rejected by {npcKingdom.Name}");
				}
				break;
			case "break_alliance":
				if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
				{
					LogMessage("[KINGDOM_ACTION] Alliance actions disabled - diplomacy system is off");
					TextObject val22 = new TextObject("{=AIInfluence_AllianceSystemDisabled}Alliance system is disabled. Enable diplomacy in mod settings to use alliances.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val22).ToString(), ExtraColors.RedAIInfluence));
				}
				else if (AllianceSystem.Instance != null && playerKingdom != null && AllianceSystem.Instance.AreAllied(npcKingdom, playerKingdom))
				{
					AllianceSystem.Instance.BreakAlliance(npcKingdom, playerKingdom);
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_BreakAlliance}{KINGDOM} has broken the alliance with {PLAYER_KINGDOM}! Reason: {REASON}", new Dictionary<string, object>
					{
						{ "KINGDOM", npcKingdom.Name },
						{ "PLAYER_KINGDOM", playerKingdom.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "they value your service"
						}
					})).ToString(), ExtraColors.RedAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Alliance broken between {npcKingdom.Name} and {playerKingdom.Name}");
				}
				break;
			case "hire_mercenary":
			{
				Clan playerClan12 = Clan.PlayerClan;
				if (playerClan12 == null)
				{
					LogMessage("[KINGDOM_ACTION] Failed to get player clan for mercenary hire");
					break;
				}
				if (npcKingdom == null)
				{
					LogMessage("[KINGDOM_ACTION] Failed to get NPC kingdom for mercenary hire");
					break;
				}
				int tier3 = playerClan12.Tier;
				int mercenaryEligibleTier = Campaign.Current.Models.ClanTierModel.MercenaryEligibleTier;
				bool flag28 = playerClan12.Kingdom != null && !playerClan12.IsUnderMercenaryService;
				if (tier3 < mercenaryEligibleTier)
				{
					LogMessage($"[KINGDOM_ACTION] Player clan tier ({tier3}) is too low for mercenary service (requires {mercenaryEligibleTier})");
					TextObject val58 = new TextObject("{=AIInfluence_MercenaryHire_ClanTierTooLow}{NPC_NAME} wanted to hire you as a mercenary, but your clan tier is too low (requires tier {TIER}).", (Dictionary<string, object>)null);
					val58.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					val58.SetTextVariable("TIER", mercenaryEligibleTier.ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val58).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				if (flag28)
				{
					LogMessage("[KINGDOM_ACTION] Player is already a vassal, cannot hire as mercenary");
					TextObject val59 = new TextObject("{=AIInfluence_MercenaryHire_AlreadyVassal}{NPC_NAME} wanted to hire you as a mercenary, but you are already a vassal of another kingdom.", (Dictionary<string, object>)null);
					val59.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val59).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				int mercenaryAwardFactorToJoinKingdom3 = Campaign.Current.Models.MinorFactionsModel.GetMercenaryAwardFactorToJoinKingdom(playerClan12, npcKingdom, false);
				try
				{
					ChangeKingdomAction.ApplyByJoinFactionAsMercenary(playerClan12, npcKingdom, CampaignTime.Zero, mercenaryAwardFactorToJoinKingdom3, true);
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_HireMercenary}{KINGDOM_LEADER} has hired you as a mercenary for {KINGDOM}! You will receive {GOLD} gold per day. Reason: {REASON}", new Dictionary<string, object>
					{
						{ "KINGDOM_LEADER", npc.Name },
						{ "KINGDOM", npcKingdom.Name },
						{ "GOLD", mercenaryAwardFactorToJoinKingdom3 },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "they recognize your worth"
						}
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Player hired as mercenary by {npcKingdom.Name}, award: {mercenaryAwardFactorToJoinKingdom3} gold/day");
					break;
				}
				catch (Exception ex16)
				{
					LogMessage("[ERROR] Failed to hire player as mercenary: " + ex16.Message);
					TextObject val60 = new TextObject("{=AIInfluence_MercenaryJoinFailed}Failed to join as mercenary due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val60).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "offer_vassalage":
			{
				Clan playerClan11 = Clan.PlayerClan;
				if (playerClan11 == null)
				{
					LogMessage("[KINGDOM_ACTION] Failed to get player clan for vassalage offer");
					break;
				}
				int tier2 = playerClan11.Tier;
				int vassalEligibleTier = Campaign.Current.Models.ClanTierModel.VassalEligibleTier;
				bool flag27 = playerClan11.Kingdom != null && playerClan11.Kingdom != npcKingdom && !playerClan11.IsUnderMercenaryService;
				if (tier2 < vassalEligibleTier)
				{
					LogMessage($"[KINGDOM_ACTION] Player clan tier ({tier2}) is too low for vassalage (requires {vassalEligibleTier})");
					TextObject val54 = new TextObject("{=AIInfluence_VassalOffer_ClanTierTooLow}{NPC_NAME} wanted to make you a vassal, but your clan tier is too low (requires tier {TIER}).", (Dictionary<string, object>)null);
					val54.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					val54.SetTextVariable("TIER", vassalEligibleTier.ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val54).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				if (flag27)
				{
					LogMessage("[KINGDOM_ACTION] Player is already a vassal of another kingdom");
					TextObject val55 = new TextObject("{=AIInfluence_VassalOffer_DefectProposal}{NPC_NAME} wants you to defect and become a vassal of {KINGDOM}! This is a major decision. Reason: {REASON}", (Dictionary<string, object>)null);
					val55.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					val55.SetTextVariable("KINGDOM", ((object)npcKingdom.Name).ToString());
					val55.SetTextVariable("REASON", aiResult.KingdomActionReason ?? "they value your loyalty");
					InformationManager.DisplayMessage(new InformationMessage(((object)val55).ToString(), ExtraColors.GreenAIInfluence));
					break;
				}
				try
				{
					ChangeKingdomAction.ApplyByJoinToKingdom(playerClan11, npcKingdom, CampaignTime.Zero, true);
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_OfferVassalage}{KINGDOM_LEADER} has made you a vassal lord of {KINGDOM}! You can now vote in kingdom decisions and may receive fiefs. Reason: {REASON}", new Dictionary<string, object>
					{
						{ "KINGDOM_LEADER", npc.Name },
						{ "KINGDOM", npcKingdom.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "they recognize your worth"
						}
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Player accepted as vassal by {npcKingdom.Name}");
					break;
				}
				catch (Exception ex15)
				{
					LogMessage("[ERROR] Failed to make player a vassal: " + ex15.Message);
					TextObject val56 = new TextObject("{=AIInfluence_VassalJoinFailed}Failed to join as vassal due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val56).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "dismiss_mercenary":
			{
				Clan playerClan7 = Clan.PlayerClan;
				if (playerClan7 == null)
				{
					LogMessage("[KINGDOM_ACTION] Failed to get player clan for mercenary dismissal");
					break;
				}
				if (!playerClan7.IsUnderMercenaryService || playerClan7.Kingdom != npcKingdom)
				{
					LogMessage("[KINGDOM_ACTION] Player is not a mercenary in our kingdom, cannot dismiss");
					TextObject val36 = new TextObject("{=AIInfluence_MercenaryDismiss_NotOurMercenary}{NPC_NAME} tried to dismiss you from mercenary service, but you are not their mercenary.", (Dictionary<string, object>)null);
					val36.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val36).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				try
				{
					ChangeKingdomAction.ApplyByLeaveKingdomAsMercenary(playerClan7, true);
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_DismissMercenary}{KINGDOM_LEADER} has released you from mercenary service with {KINGDOM}. You are now a free agent. Reason: {REASON}", new Dictionary<string, object>
					{
						{ "KINGDOM_LEADER", npc.Name },
						{ "KINGDOM", npcKingdom.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "your service is no longer needed"
						}
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Player dismissed from mercenary service by {npcKingdom.Name}. Reason: {text2}");
					break;
				}
				catch (Exception ex7)
				{
					LogMessage("[ERROR] Failed to dismiss player from mercenary service: " + ex7.Message);
					TextObject val37 = new TextObject("{=AIInfluence_MercenaryLeaveFailed}Failed to leave mercenary service due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val37).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "dismiss_vassal":
			{
				Clan playerClan13 = Clan.PlayerClan;
				if (playerClan13 == null)
				{
					LogMessage("[KINGDOM_ACTION] Failed to get player clan for vassal dismissal");
					break;
				}
				if (playerClan13.Kingdom != npcKingdom || playerClan13.IsUnderMercenaryService)
				{
					LogMessage("[KINGDOM_ACTION] Player is not a vassal in our kingdom, cannot dismiss");
					TextObject val61 = new TextObject("{=AIInfluence_VassalDismiss_NotOurVassal}{NPC_NAME} tried to release you from vassalage, but you are not their vassal.", (Dictionary<string, object>)null);
					val61.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val61).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				try
				{
					ChangeKingdomAction.ApplyByLeaveKingdom(playerClan13, true);
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_DismissVassal}{KINGDOM_LEADER} has released you from your oath to {KINGDOM}! You are no longer a vassal. Reason: {REASON}", new Dictionary<string, object>
					{
						{ "KINGDOM_LEADER", npc.Name },
						{ "KINGDOM", npcKingdom.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "your oath is ended"
						}
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] Player dismissed from vassalage by {npcKingdom.Name}. Reason: {text2}");
					break;
				}
				catch (Exception ex17)
				{
					LogMessage("[ERROR] Failed to dismiss player from vassalage: " + ex17.Message);
					TextObject val62 = new TextObject("{=AIInfluence_VassalLeaveFailed}Failed to leave vassalage due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val62).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "join_player_clan":
			{
				Clan playerClan8 = Clan.PlayerClan;
				if (playerClan8 == null)
				{
					LogMessage("[KINGDOM_ACTION] Failed to get player clan for NPC to join");
					break;
				}
				bool flag13 = IsPlayerFamilyMember(npc);
				bool flag14 = (int)npc.Occupation == 16 || npc.IsWanderer;
				bool flag15 = (int)npc.Occupation == 3 && npc.Clan != null;
				Clan clan4 = npc.Clan;
				bool flag16 = clan4 != null && clan4.IsUnderMercenaryService;
				bool isKingdomLeader = npc.IsKingdomLeader;
				bool flag17 = npc.CompanionOf == playerClan8;
				bool flag18 = flag14 && !flag17;
				bool flag19 = flag15 && !flag16 && !isKingdomLeader;
				if (flag13)
				{
					if (flag17)
					{
						try
						{
							RemoveCompanionAction.ApplyByByTurningToLord(playerClan8, npc);
							if ((int)npc.Occupation != 3 && npc.Age >= 18f)
							{
								npc.SetNewOccupation((Occupation)3);
								LogMessage($"[KINGDOM_ACTION] {npc.Name} is a family member who was incorrectly a companion - converted to Lord and removed from companion status");
							}
							else
							{
								LogMessage($"[KINGDOM_ACTION] {npc.Name} is a family member who was incorrectly a companion - removed from companion status (keeping current occupation)");
							}
						}
						catch (Exception ex8)
						{
							LogMessage($"[ERROR] Failed to remove {npc.Name} from companion status: {ex8.Message}");
						}
					}
					if (npc.Clan != playerClan8)
					{
						npc.Clan = playerClan8;
						LogMessage($"[KINGDOM_ACTION] {npc.Name} is a family member - ensured they are in player's clan (not as companion)");
					}
					else
					{
						LogMessage($"[KINGDOM_ACTION] {npc.Name} is already in player's clan as family member");
					}
					if (MobileParty.MainParty != null && npc.PartyBelongedTo != MobileParty.MainParty)
					{
						AddHeroToPartyAction.Apply(npc, MobileParty.MainParty, true);
						LogMessage($"[KINGDOM_ACTION] Added family member {npc.Name} to player party");
					}
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_JoinPlayerClan_Family}{NPC_NAME} has pledged their service to you! Reason: {REASON}", new Dictionary<string, object>
					{
						{ "NPC_NAME", npc.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "they wish to serve you"
						}
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] {npc.Name} (family member) pledged service to player. Reason: {text2}");
					break;
				}
				if (!flag18 && !flag19)
				{
					LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} cannot join player clan (not eligible)");
					TextObject val38 = new TextObject("{=AIInfluence_JoinClan_NotEligible}{NPC_NAME} tried to join your clan, but they are not eligible (only free wanderers or non-mercenary lords may do so).", (Dictionary<string, object>)null);
					val38.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val38).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				try
				{
					if (npc.GovernorOf != null)
					{
						try
						{
							ChangeGovernorAction.RemoveGovernorOf(npc);
							LogMessage($"[KINGDOM_ACTION] Removed {npc.Name} from governor position of {((SettlementComponent)npc.GovernorOf).Name} before joining player's clan");
						}
						catch (Exception ex9)
						{
							LogMessage($"[ERROR] Failed to remove governor status from {npc.Name}: {ex9.Message}");
						}
					}
					bool flag20 = Settlement.CurrentSettlement != null || npc.CurrentSettlement != null;
					bool flag21 = AIActionManager.Instance?.IsActionActive(npc, "follow_player") ?? false;
					MobileParty val39 = null;
					if (flag21)
					{
						val39 = npc.PartyBelongedTo;
						string arg = ((val39 == null) ? null : ((object)val39.Name)?.ToString()) ?? "null";
						LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} is following player with follow_player action. In settlement: {flag20}, Party: {arg}");
					}
					else if (npc.PartyBelongedTo != null && npc.PartyBelongedTo != MobileParty.MainParty)
					{
						LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} belongs to party {npc.PartyBelongedTo.Name}, proceeding with companion assignment.");
					}
					AddCompanionAction.Apply(playerClan8, npc);
					if (flag21)
					{
						if (flag20)
						{
							LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} is in settlement - canceling follow_player and adding to player party");
							AIActionManager.Instance?.StopAction(npc, "follow_player");
							LogMessage($"[KINGDOM_ACTION] Stopped follow_player action for {npc.Name} (in settlement)");
							if (val39 != null && val39.IsActive && val39 != MobileParty.MainParty)
							{
								try
								{
									if (npc.PartyBelongedTo == val39)
									{
										val39.MemberRoster.RemoveTroop(npc.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
										LogMessage($"[KINGDOM_ACTION] Removed {npc.Name} from temporary party {val39.Name}");
									}
									if (val39.MemberRoster.Count == 0)
									{
										val39.RemoveParty();
										LogMessage($"[KINGDOM_ACTION] Removed empty temporary party {val39.Name}");
									}
								}
								catch (Exception ex10)
								{
									LogMessage("[ERROR] Error removing temporary party: " + ex10.Message);
								}
							}
							if (MobileParty.MainParty != null && npc.PartyBelongedTo != MobileParty.MainParty)
							{
								AddHeroToPartyAction.Apply(npc, MobileParty.MainParty, true);
								LogMessage($"[KINGDOM_ACTION] Added {npc.Name} to player party");
							}
						}
						else
						{
							LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} is on global map with temporary party - replacing with real clan party and keeping follow_player");
							if (val39 != null && val39.IsActive)
							{
								try
								{
									if (npc.PartyBelongedTo == val39)
									{
										val39.MemberRoster.RemoveTroop(npc.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
										LogMessage($"[KINGDOM_ACTION] Removed {npc.Name} from temporary party {val39.Name}");
									}
									if (val39.MemberRoster.Count == 0)
									{
										val39.RemoveParty();
										LogMessage($"[KINGDOM_ACTION] Removed empty temporary party {val39.Name}");
									}
								}
								catch (Exception ex11)
								{
									LogMessage("[ERROR] Error removing temporary party: " + ex11.Message);
								}
							}
							MobileParty val40 = GameVersionCompatibility.CreateNewClanMobileParty(npc, playerClan8);
							if (val40 != null)
							{
								LogMessage($"[KINGDOM_ACTION] Created real clan party '{val40.Name}' for {npc.Name}");
								if (npc.PartyBelongedTo == val40)
								{
									LogMessage($"[KINGDOM_ACTION] {npc.Name} is in new clan party '{val40.Name}'");
									if (AIActionManager.Instance?.GetActiveAction(npc, "follow_player") is FollowPlayerAction followPlayerAction)
									{
										followPlayerAction.EnsureGlobalMapParty(forceCreate: true);
										LogMessage($"[KINGDOM_ACTION] Updated follow_player action for {npc.Name} to use new clan party");
									}
									else
									{
										LogMessage($"[WARNING] Could not get follow_player action instance for {npc.Name} to update party");
									}
								}
								else
								{
									MobileParty partyBelongedTo = npc.PartyBelongedTo;
									string arg2 = ((partyBelongedTo == null) ? null : ((object)partyBelongedTo.Name)?.ToString()) ?? "null";
									LogMessage($"[ERROR] {npc.Name} is not in new clan party after creation! PartyBelongedTo: {arg2}");
								}
							}
							else
							{
								LogMessage($"[ERROR] Failed to create clan party for {npc.Name}, adding to player party instead");
								if (MobileParty.MainParty != null && npc.PartyBelongedTo != MobileParty.MainParty)
								{
									AddHeroToPartyAction.Apply(npc, MobileParty.MainParty, true);
								}
							}
						}
					}
					else if (MobileParty.MainParty != null && npc.PartyBelongedTo != MobileParty.MainParty)
					{
						AddHeroToPartyAction.Apply(npc, MobileParty.MainParty, true);
					}
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_JoinPlayerClan}{NPC_NAME} has joined your clan as a companion! Reason: {REASON}", new Dictionary<string, object>
					{
						{ "NPC_NAME", npc.Name },
						{
							"REASON",
							aiResult.KingdomActionReason ?? "they wish to follow you"
						}
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] {npc.Name} joined player's clan. Reason: {text2}");
					break;
				}
				catch (Exception ex12)
				{
					LogMessage("[ERROR] Failed to add NPC to player clan: " + ex12.Message);
					TextObject val41 = new TextObject("{=AIInfluence_JoinClanFailed}Failed to join your clan due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val41).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "join_player_kingdom":
			{
				Clan playerClan2 = Clan.PlayerClan;
				if (playerClan2 == null || playerClan2.Kingdom == null)
				{
					LogMessage("[KINGDOM_ACTION] Player is not in a kingdom or clan is null");
					break;
				}
				Kingdom kingdom = playerClan2.Kingdom;
				if (kingdom.Leader != Hero.MainHero)
				{
					LogMessage("[KINGDOM_ACTION] Player is not a kingdom leader, cannot accept NPC clan");
					TextObject val11 = new TextObject("{=AIInfluence_JoinKingdom_PlayerNotLeader}{NPC_NAME} wanted to join your kingdom, but you are not a kingdom leader.", (Dictionary<string, object>)null);
					val11.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val11).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				if (!npc.IsClanLeader)
				{
					LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} is not a clan leader, cannot join kingdom");
					TextObject val12 = new TextObject("{=AIInfluence_JoinKingdom_NotClanLeader}{NPC_NAME} is not a clan leader, they cannot pledge their clan to your kingdom.", (Dictionary<string, object>)null);
					val12.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val12).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				if (npc.IsKingdomLeader)
				{
					LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} is a kingdom leader, cannot join another kingdom");
					TextObject val13 = new TextObject("{=AIInfluence_JoinKingdom_IsKingdomLeader}{NPC_NAME} is a kingdom leader, they cannot join your kingdom as a vassal.", (Dictionary<string, object>)null);
					val13.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val13).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				Clan clan = npc.Clan;
				if (clan == null)
				{
					LogMessage("[KINGDOM_ACTION] NPC clan is null");
					break;
				}
				try
				{
					bool isUnderMercenaryService = clan.IsUnderMercenaryService;
					string text6 = aiResult.KingdomActionReason;
					if (isUnderMercenaryService)
					{
						int mercenaryAwardFactorToJoinKingdom = Campaign.Current.Models.MinorFactionsModel.GetMercenaryAwardFactorToJoinKingdom(clan, kingdom, false);
						ChangeKingdomAction.ApplyByJoinFactionAsMercenary(clan, kingdom, CampaignTime.Zero, mercenaryAwardFactorToJoinKingdom, true);
						if (string.IsNullOrWhiteSpace(text6))
						{
							text6 = "they seek to serve you";
						}
						InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_JoinPlayerKingdomMerc}{NPC_NAME}'s clan has joined your kingdom {KINGDOM} as mercenaries! Reason: {REASON}", new Dictionary<string, object>
						{
							{ "NPC_NAME", npc.Name },
							{ "KINGDOM", kingdom.Name },
							{ "REASON", text6 }
						})).ToString(), ExtraColors.GreenAIInfluence));
					}
					else
					{
						ChangeKingdomAction.ApplyByJoinToKingdom(clan, kingdom, CampaignTime.Zero, true);
						if (string.IsNullOrWhiteSpace(text6))
						{
							text6 = "they recognize your leadership";
						}
						InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_JoinPlayerKingdom}{NPC_NAME}'s clan has pledged vassalage to your kingdom {KINGDOM}! Reason: {REASON}", new Dictionary<string, object>
						{
							{ "NPC_NAME", npc.Name },
							{ "KINGDOM", kingdom.Name },
							{ "REASON", text6 }
						})).ToString(), ExtraColors.GreenAIInfluence));
					}
					LogMessage($"[KINGDOM_ACTION] {npc.Name}'s clan joined player's kingdom {kingdom.Name}. Reason: {text6}");
					break;
				}
				catch (Exception ex2)
				{
					LogMessage("[ERROR] Failed to join NPC clan to player kingdom: " + ex2.Message);
					TextObject val14 = new TextObject("{=AIInfluence_JoinKingdomFailed}Failed to join your kingdom due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val14).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "hire_mercenary_clan":
			{
				Clan playerClan9 = Clan.PlayerClan;
				if (playerClan9 == null || playerClan9.Kingdom == null)
				{
					LogMessage("[KINGDOM_ACTION] Player is not in a kingdom or clan is null");
					break;
				}
				Kingdom kingdom4 = playerClan9.Kingdom;
				if (kingdom4.Leader != Hero.MainHero)
				{
					LogMessage("[KINGDOM_ACTION] Player is not a kingdom leader, cannot hire mercenaries");
					TextObject val42 = new TextObject("{=AIInfluence_HireMercClan_PlayerNotLeader}{NPC_NAME} wanted to accept your mercenary offer, but you are not a kingdom leader.", (Dictionary<string, object>)null);
					val42.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val42).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				if (!npc.IsClanLeader)
				{
					LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} is not a clan leader, cannot be hired as mercenary");
					TextObject val43 = new TextObject("{=AIInfluence_HireMercClan_NotClanLeader}{NPC_NAME} is not a clan leader, they cannot be hired as mercenaries.", (Dictionary<string, object>)null);
					val43.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val43).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				if (npc.IsKingdomLeader)
				{
					LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} is a kingdom leader, cannot be hired as mercenary");
					TextObject val44 = new TextObject("{=AIInfluence_HireMercClan_IsKingdomLeader}{NPC_NAME} is a kingdom leader, they cannot be hired as mercenaries.", (Dictionary<string, object>)null);
					val44.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val44).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				Clan clan5 = npc.Clan;
				if (clan5 == null)
				{
					LogMessage("[KINGDOM_ACTION] NPC clan is null");
					break;
				}
				if (!clan5.IsMinorFaction)
				{
					LogMessage($"[KINGDOM_ACTION] NPC clan {clan5.Name} is not a minor faction, cannot be hired as mercenaries");
					TextObject val45 = new TextObject("{=AIInfluence_HireMercClan_NotMinorFaction}{NPC_NAME}'s clan is not a mercenary clan (must be a minor faction).", (Dictionary<string, object>)null);
					val45.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val45).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				try
				{
					int mercenaryAwardFactorToJoinKingdom2 = Campaign.Current.Models.MinorFactionsModel.GetMercenaryAwardFactorToJoinKingdom(clan5, kingdom4, false);
					StartMercenaryServiceAction.ApplyByDefault(clan5, kingdom4, mercenaryAwardFactorToJoinKingdom2);
					string text12 = aiResult.KingdomActionReason;
					if (string.IsNullOrWhiteSpace(text12))
					{
						text12 = "they accept your offer";
					}
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_HireMercenaryClan}{NPC_NAME}'s clan has joined your kingdom {KINGDOM} as mercenaries! Reason: {REASON}", new Dictionary<string, object>
					{
						{ "NPC_NAME", npc.Name },
						{ "KINGDOM", kingdom4.Name },
						{ "REASON", text12 }
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] {npc.Name}'s clan hired as mercenaries by player's kingdom {kingdom4.Name}. Reason: {text12}");
					break;
				}
				catch (Exception ex13)
				{
					LogMessage("[ERROR] Failed to hire NPC clan as mercenaries: " + ex13.Message);
					TextObject val46 = new TextObject("{=AIInfluence_HireMercenariesFailed}Failed to hire as mercenaries due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val46).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "kick_from_clan":
			{
				Clan playerClan5 = Clan.PlayerClan;
				if (playerClan5 == null)
				{
					LogMessage("[KINGDOM_ACTION] Failed to get player clan for kicking NPC");
					break;
				}
				if (npc.CompanionOf != playerClan5)
				{
					LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} is not player's companion, cannot kick");
					TextObject val23 = new TextObject("{=AIInfluence_KickFromClan_NotCompanion}{NPC_NAME} tried to leave your clan, but they are not your companion.", (Dictionary<string, object>)null);
					val23.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val23).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				try
				{
					RemoveCompanionAction.ApplyByFire(playerClan5, npc);
					string text9 = aiResult.KingdomActionReason;
					if (string.IsNullOrWhiteSpace(text9))
					{
						text9 = "they chose to leave";
					}
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_KickFromClan}{NPC_NAME} has left your clan. Reason: {REASON}", new Dictionary<string, object>
					{
						{ "NPC_NAME", npc.Name },
						{ "REASON", text9 }
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] {npc.Name} left player's clan. Reason: {text9}");
					break;
				}
				catch (Exception ex5)
				{
					LogMessage("[ERROR] Failed to kick NPC from clan: " + ex5.Message);
					TextObject val24 = new TextObject("{=AIInfluence_LeaveClanFailed}Failed to leave clan due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val24).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "dismiss_npc_mercenary":
			{
				Clan playerClan3 = Clan.PlayerClan;
				if (playerClan3 == null || playerClan3.Kingdom == null)
				{
					LogMessage("[KINGDOM_ACTION] Player is not in a kingdom or clan is null");
					break;
				}
				Kingdom kingdom2 = playerClan3.Kingdom;
				if (kingdom2.Leader != Hero.MainHero)
				{
					LogMessage("[KINGDOM_ACTION] Player is not a kingdom leader, cannot dismiss mercenaries");
					TextObject val15 = new TextObject("{=AIInfluence_DismissNPCMerc_PlayerNotLeader}{NPC_NAME} wanted to leave mercenary service, but you are not a kingdom leader.", (Dictionary<string, object>)null);
					val15.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val15).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				Clan clan2 = npc.Clan;
				if (clan2 == null)
				{
					LogMessage("[KINGDOM_ACTION] NPC clan is null");
					break;
				}
				if (!clan2.IsUnderMercenaryService || clan2.Kingdom != kingdom2)
				{
					LogMessage($"[KINGDOM_ACTION] NPC clan {clan2.Name} is not a mercenary in player's kingdom");
					TextObject val16 = new TextObject("{=AIInfluence_DismissNPCMerc_NotOurMercenary}{NPC_NAME}'s clan is not serving as mercenaries in your kingdom.", (Dictionary<string, object>)null);
					val16.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val16).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				try
				{
					EndMercenaryServiceAction.EndByDefault(clan2);
					string text7 = aiResult.KingdomActionReason;
					if (string.IsNullOrWhiteSpace(text7))
					{
						text7 = "they chose to leave";
					}
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_DismissNPCMercenary}{NPC_NAME}'s clan has left your mercenary service. Reason: {REASON}", new Dictionary<string, object>
					{
						{ "NPC_NAME", npc.Name },
						{ "REASON", text7 }
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] {npc.Name}'s clan left player's mercenary service. Reason: {text7}");
					break;
				}
				catch (Exception ex3)
				{
					LogMessage("[ERROR] Failed to dismiss NPC from mercenary service: " + ex3.Message);
					TextObject val17 = new TextObject("{=AIInfluence_MercenaryLeaveFailed}Failed to leave mercenary service due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val17).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "release_npc_vassal":
			{
				Clan playerClan4 = Clan.PlayerClan;
				if (playerClan4 == null || playerClan4.Kingdom == null)
				{
					LogMessage("[KINGDOM_ACTION] Player is not in a kingdom or clan is null");
					break;
				}
				Kingdom kingdom3 = playerClan4.Kingdom;
				if (kingdom3.Leader != Hero.MainHero)
				{
					LogMessage("[KINGDOM_ACTION] Player is not a kingdom leader, cannot release vassals");
					TextObject val18 = new TextObject("{=AIInfluence_ReleaseNPCVassal_PlayerNotLeader}{NPC_NAME} wanted to leave vassalage, but you are not a kingdom leader.", (Dictionary<string, object>)null);
					val18.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val18).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				Clan clan3 = npc.Clan;
				if (clan3 == null)
				{
					LogMessage("[KINGDOM_ACTION] NPC clan is null");
					break;
				}
				if (clan3.Kingdom != kingdom3 || clan3.IsUnderMercenaryService)
				{
					LogMessage($"[KINGDOM_ACTION] NPC clan {clan3.Name} is not a vassal in player's kingdom");
					TextObject val19 = new TextObject("{=AIInfluence_ReleaseNPCVassal_NotOurVassal}{NPC_NAME}'s clan is not your vassal.", (Dictionary<string, object>)null);
					val19.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val19).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				try
				{
					ChangeKingdomAction.ApplyByLeaveKingdom(clan3, true);
					string text8 = aiResult.KingdomActionReason;
					if (string.IsNullOrWhiteSpace(text8))
					{
						text8 = "they chose to leave";
					}
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_ReleaseNPCVassal}{NPC_NAME}'s clan has been released from vassalage to {KINGDOM}. They are now independent. Reason: {REASON}", new Dictionary<string, object>
					{
						{ "NPC_NAME", npc.Name },
						{ "KINGDOM", kingdom3.Name },
						{ "REASON", text8 }
					})).ToString(), ExtraColors.GreenAIInfluence));
					LogMessage($"[KINGDOM_ACTION] {npc.Name}'s clan released from vassalage to player's kingdom. Reason: {text8}");
					break;
				}
				catch (Exception ex4)
				{
					LogMessage("[ERROR] Failed to release NPC from vassalage: " + ex4.Message);
					TextObject val20 = new TextObject("{=AIInfluence_VassalLeaveFailed}Failed to leave vassalage due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val20).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "transfer_kingdom":
			{
				int num3;
				if (npc.MapFaction is Kingdom)
				{
					IFaction mapFaction2 = npc.MapFaction;
					num3 = ((npc == ((mapFaction2 != null) ? mapFaction2.Leader : null)) ? 1 : 0);
				}
				else
				{
					num3 = 0;
				}
				bool flag11 = (byte)num3 != 0;
				int num4;
				if (Hero.MainHero.MapFaction is Kingdom)
				{
					Hero mainHero = Hero.MainHero;
					IFaction mapFaction3 = Hero.MainHero.MapFaction;
					num4 = ((mainHero == ((mapFaction3 != null) ? mapFaction3.Leader : null)) ? 1 : 0);
				}
				else
				{
					num4 = 0;
				}
				bool flag12 = (byte)num4 != 0;
				Kingdom val25 = null;
				Clan val26 = null;
				Hero val27 = null;
				Hero val28 = null;
				string text10 = "";
				if (flag11)
				{
					IFaction mapFaction4 = npc.MapFaction;
					val25 = (Kingdom)(object)((mapFaction4 is Kingdom) ? mapFaction4 : null);
					if (val25 == null)
					{
						LogMessage("[KINGDOM_ACTION] Failed to get NPC kingdom for transfer");
						break;
					}
					Clan playerClan6 = Clan.PlayerClan;
					if (playerClan6 == null)
					{
						LogMessage("[KINGDOM_ACTION] Player clan is null, cannot transfer kingdom");
						TextObject val29 = new TextObject("{=AIInfluence_TransferKingdom_NoClan}{NPC_NAME} wanted to transfer the kingdom to you, but you don't have a clan.", (Dictionary<string, object>)null);
						val29.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
						InformationManager.DisplayMessage(new InformationMessage(((object)val29).ToString(), ExtraColors.RedAIInfluence));
						break;
					}
					if (playerClan6.Kingdom != val25)
					{
						LogMessage("[KINGDOM_ACTION] Player is not in NPC's kingdom, cannot transfer");
						TextObject val30 = new TextObject("{=AIInfluence_TransferKingdom_NotInKingdom}{NPC_NAME} wanted to transfer the kingdom to you, but you are not a member of {KINGDOM}.", (Dictionary<string, object>)null);
						val30.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
						val30.SetTextVariable("KINGDOM", ((object)val25.Name).ToString());
						InformationManager.DisplayMessage(new InformationMessage(((object)val30).ToString(), ExtraColors.RedAIInfluence));
						break;
					}
					int tier = playerClan6.Tier;
					if (tier < 4)
					{
						LogMessage($"[KINGDOM_ACTION] Player clan tier ({tier}) is too low for kingdom transfer (requires tier 4)");
						TextObject val31 = new TextObject("{=AIInfluence_TransferKingdom_LowTier}{NPC_NAME} wanted to transfer the kingdom to you, but your clan is not prestigious enough to rule a kingdom. Your clan needs to achieve greater renown and standing among the nobility first.", (Dictionary<string, object>)null);
						val31.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
						InformationManager.DisplayMessage(new InformationMessage(((object)val31).ToString(), ExtraColors.RedAIInfluence));
						break;
					}
					val26 = playerClan6;
					val27 = Hero.MainHero;
					val28 = npc;
					text10 = "NPC to Player";
				}
				else
				{
					if (!flag12)
					{
						LogMessage("[KINGDOM_ACTION] Neither NPC nor player is a kingdom leader, cannot transfer");
						TextObject val32 = new TextObject("{=AIInfluence_TransferKingdom_NoLeader}Kingdom transfer failed: neither you nor {NPC_NAME} is a kingdom leader.", (Dictionary<string, object>)null);
						val32.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
						InformationManager.DisplayMessage(new InformationMessage(((object)val32).ToString(), ExtraColors.RedAIInfluence));
						break;
					}
					IFaction mapFaction5 = Hero.MainHero.MapFaction;
					val25 = (Kingdom)(object)((mapFaction5 is Kingdom) ? mapFaction5 : null);
					if (val25 == null)
					{
						LogMessage("[KINGDOM_ACTION] Failed to get player kingdom for transfer");
						break;
					}
					if ((object)npc.MapFaction != val25)
					{
						LogMessage("[KINGDOM_ACTION] NPC is not in player's kingdom, cannot transfer");
						TextObject val33 = new TextObject("{=AIInfluence_TransferKingdom_NPCNotInKingdom}You wanted to transfer the kingdom to {NPC_NAME}, but they are not a member of {KINGDOM}.", (Dictionary<string, object>)null);
						val33.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
						val33.SetTextVariable("KINGDOM", ((object)val25.Name).ToString());
						InformationManager.DisplayMessage(new InformationMessage(((object)val33).ToString(), ExtraColors.RedAIInfluence));
						break;
					}
					if (npc.Clan == null)
					{
						LogMessage("[KINGDOM_ACTION] NPC clan is null, cannot transfer kingdom");
						TextObject val34 = new TextObject("{=AIInfluence_TransferKingdom_NPCNoClan}You wanted to transfer the kingdom to {NPC_NAME}, but they don't have a clan.", (Dictionary<string, object>)null);
						val34.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
						InformationManager.DisplayMessage(new InformationMessage(((object)val34).ToString(), ExtraColors.RedAIInfluence));
						break;
					}
					val26 = npc.Clan;
					val27 = npc;
					val28 = Hero.MainHero;
					text10 = "Player to NPC";
				}
				try
				{
					ChangeRulingClanAction.Apply(val25, val26);
					string text11 = aiResult.KingdomActionReason;
					if (string.IsNullOrWhiteSpace(text11))
					{
						text11 = "the kingdom has been transferred";
					}
					if (flag11)
					{
						InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_TransferKingdom_NPCToPlayer}{OLD_RULER} has transferred the leadership of {KINGDOM} to you! You are now the ruler. Reason: {REASON}", new Dictionary<string, object>
						{
							{ "OLD_RULER", val28.Name },
							{ "KINGDOM", val25.Name },
							{ "REASON", text11 }
						})).ToString(), ExtraColors.GreenAIInfluence));
					}
					else
					{
						InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_TransferKingdom_PlayerToNPC}You have transferred the leadership of {KINGDOM} to {NEW_RULER}! They are now the ruler. Reason: {REASON}", new Dictionary<string, object>
						{
							{ "KINGDOM", val25.Name },
							{ "NEW_RULER", val27.Name },
							{ "REASON", text11 }
						})).ToString(), ExtraColors.GreenAIInfluence));
					}
					LogMessage($"[KINGDOM_ACTION] Kingdom {val25.Name} transferred from {val28.Name} to {val27.Name} ({text10}). Reason: {text11}");
					break;
				}
				catch (Exception ex6)
				{
					LogMessage("[ERROR] Failed to transfer kingdom: " + ex6.Message);
					TextObject val35 = new TextObject("{=AIInfluence_TransferKingdomFailed}Failed to transfer kingdom due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val35).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "grant_fief":
			{
				Clan playerClan10 = Clan.PlayerClan;
				if (playerClan10 == null)
				{
					LogMessage("[KINGDOM_ACTION] Player clan is null, cannot grant fief");
					TextObject val47 = new TextObject("{=AIInfluence_GrantFief_NoClan}{NPC_NAME} wanted to grant you a fief, but you don't have a clan.", (Dictionary<string, object>)null);
					val47.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val47).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				string settlementId = aiResult.SettlementId;
				if (string.IsNullOrWhiteSpace(settlementId))
				{
					LogMessage("[KINGDOM_ACTION] Settlement ID not provided for grant_fief");
					TextObject val48 = new TextObject("{=AIInfluence_GrantFief_NoSettlement}{NPC_NAME} wanted to grant you a fief, but no settlement was specified.", (Dictionary<string, object>)null);
					val48.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val48).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				Settlement val49 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == settlementId));
				if (val49 == null)
				{
					LogMessage("[KINGDOM_ACTION] Settlement with ID '" + settlementId + "' not found");
					TextObject val50 = new TextObject("{=AIInfluence_GrantFief_SettlementNotFound}{NPC_NAME} wanted to grant you a fief, but the settlement was not found.", (Dictionary<string, object>)null);
					val50.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val50).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				bool flag22 = npcKingdom != null && npc == npcKingdom.Leader;
				bool flag23 = npc.IsClanLeader && npc.Clan != null;
				bool flag24 = val49.OwnerClan == npc.Clan;
				Clan ownerClan2 = val49.OwnerClan;
				bool flag25 = ((ownerClan2 != null) ? ownerClan2.Kingdom : null) == npcKingdom;
				bool flag26 = false;
				string text13 = "";
				if (flag22 && flag25)
				{
					flag26 = true;
					LogMessage($"[KINGDOM_ACTION] NPC is kingdom leader - can grant any fief from {npcKingdom.Name}");
				}
				else if (flag23 && flag24)
				{
					flag26 = true;
					LogMessage("[KINGDOM_ACTION] NPC is clan leader - can grant their own clan's fief");
				}
				else if (!flag22 && !flag23)
				{
					text13 = "not a kingdom or clan leader";
				}
				else if (flag23 && !flag24)
				{
					text13 = "can only grant fiefs belonging to their own clan";
				}
				else if (flag22 && !flag25)
				{
					text13 = "settlement does not belong to their kingdom";
				}
				if (!flag26)
				{
					LogMessage("[KINGDOM_ACTION] NPC does not have permission to grant fief: " + text13);
					TextObject val51 = new TextObject("{=AIInfluence_GrantFief_NoPermission}{NPC_NAME} wanted to grant you {SETTLEMENT}, but they do not have the authority to do so. {REASON}", (Dictionary<string, object>)null);
					val51.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					val51.SetTextVariable("SETTLEMENT", ((object)val49.Name).ToString());
					string text14 = "";
					if (text13.Contains("not a kingdom or clan leader"))
					{
						text14 = "They are not a kingdom leader or clan leader.";
					}
					else if (text13.Contains("can only grant fiefs belonging to their own clan"))
					{
						text14 = "As a clan leader, they can only grant fiefs belonging to their own clan.";
					}
					else if (text13.Contains("settlement does not belong to their kingdom"))
					{
						text14 = "The settlement does not belong to their kingdom.";
					}
					val51.SetTextVariable("REASON", text14);
					InformationManager.DisplayMessage(new InformationMessage(((object)val51).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				try
				{
					string text15 = aiResult.KingdomActionReason;
					if (string.IsNullOrWhiteSpace(text15))
					{
						text15 = "Granted by Liege";
					}
					TerritoryTransferSystem instance2 = TerritoryTransferSystem.Instance;
					if (instance2 != null)
					{
						instance2.TransferSettlementToClanById(settlementId, playerClan10, text15);
						InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_GrantFief_Generic}{NPC_NAME} has granted you {SETTLEMENT}! Reason: {REASON}", new Dictionary<string, object>
						{
							{ "NPC_NAME", npc.Name },
							{ "SETTLEMENT", val49.Name },
							{ "REASON", text15 }
						})).ToString(), ExtraColors.GreenAIInfluence));
						LogMessage($"[KINGDOM_ACTION] Fief {val49.Name} granted to player clan {playerClan10.Name} by {npc.Name}.");
					}
					else
					{
						LogMessage("[KINGDOM_ACTION] TerritoryTransferSystem is not available");
						TextObject val52 = new TextObject("{=AIInfluence_GrantFiefFailed}Failed to grant fief: TerritoryTransferSystem is not available.", (Dictionary<string, object>)null);
						InformationManager.DisplayMessage(new InformationMessage(((object)val52).ToString(), ExtraColors.RedAIInfluence));
					}
					break;
				}
				catch (Exception ex14)
				{
					LogMessage("[ERROR] Failed to grant fief: " + ex14.Message + "\n" + ex14.StackTrace);
					TextObject val53 = new TextObject("{=AIInfluence_GrantFiefFailed}Failed to grant fief due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val53).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			case "receive_fief":
			{
				Clan playerClan = Clan.PlayerClan;
				if (playerClan == null)
				{
					LogMessage("[KINGDOM_ACTION] Player clan is null, cannot receive fief");
					TextObject val = new TextObject("{=AIInfluence_ReceiveFief_NoClan}You wanted to grant a fief to {NPC_NAME}, but you don't have a clan.", (Dictionary<string, object>)null);
					val.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				bool flag6 = playerKingdom != null && Hero.MainHero == playerKingdom.Leader;
				bool flag7 = Hero.MainHero.IsClanLeader && Hero.MainHero.Clan == playerClan;
				if (!flag6 && !flag7)
				{
					LogMessage("[KINGDOM_ACTION] Player is not a kingdom or clan leader, cannot grant fief");
					TextObject val2 = new TextObject("{=AIInfluence_ReceiveFief_NoPermission}You wanted to grant a fief to {NPC_NAME}, but you are not a kingdom leader or clan leader.", (Dictionary<string, object>)null);
					val2.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				string settlementIdReceive = aiResult.SettlementId;
				if (string.IsNullOrWhiteSpace(settlementIdReceive))
				{
					LogMessage("[KINGDOM_ACTION] Settlement ID not provided for receive_fief");
					TextObject val3 = new TextObject("{=AIInfluence_ReceiveFief_NoSettlement}You wanted to grant a fief to {NPC_NAME}, but no settlement was specified.", (Dictionary<string, object>)null);
					val3.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val3).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				Settlement val4 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == settlementIdReceive));
				if (val4 == null)
				{
					LogMessage("[KINGDOM_ACTION] Settlement with ID '" + settlementIdReceive + "' not found");
					TextObject val5 = new TextObject("{=AIInfluence_ReceiveFief_SettlementNotFound}You wanted to grant a fief to {NPC_NAME}, but the settlement was not found.", (Dictionary<string, object>)null);
					val5.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val5).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				Clan ownerClan = val4.OwnerClan;
				bool flag8 = ((ownerClan != null) ? ownerClan.Kingdom : null) == playerKingdom;
				bool flag9 = val4.OwnerClan == playerClan;
				bool flag10 = false;
				string text3 = "";
				if (flag6 && flag8)
				{
					flag10 = true;
					LogMessage($"[KINGDOM_ACTION] Player is kingdom leader - can grant any fief from {playerKingdom.Name}");
				}
				else if (flag7 && flag9)
				{
					flag10 = true;
					LogMessage("[KINGDOM_ACTION] Player is clan leader - can grant their own clan's fief");
				}
				else if (flag7 && !flag9)
				{
					text3 = "can only grant fiefs belonging to your own clan";
				}
				else if (flag6 && !flag8)
				{
					text3 = "settlement does not belong to your kingdom";
				}
				if (!flag10)
				{
					LogMessage("[KINGDOM_ACTION] Player does not have permission to grant fief: " + text3);
					TextObject val6 = new TextObject("{=AIInfluence_ReceiveFief_NoPermission2}You wanted to grant {SETTLEMENT} to {NPC_NAME}, but you do not have the authority to do so. {REASON}", (Dictionary<string, object>)null);
					val6.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					val6.SetTextVariable("SETTLEMENT", ((object)val4.Name).ToString());
					string text4 = "";
					if (text3.Contains("can only grant fiefs belonging to your own clan"))
					{
						text4 = "As a clan leader, you can only grant fiefs belonging to your own clan.";
					}
					else if (text3.Contains("settlement does not belong to your kingdom"))
					{
						text4 = "The settlement does not belong to your kingdom.";
					}
					val6.SetTextVariable("REASON", text4);
					InformationManager.DisplayMessage(new InformationMessage(((object)val6).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				if (npc.Clan == null)
				{
					LogMessage($"[KINGDOM_ACTION] NPC {npc.Name} does not have a clan, cannot receive fief");
					TextObject val7 = new TextObject("{=AIInfluence_ReceiveFief_NoNPCClan}You wanted to grant {SETTLEMENT} to {NPC_NAME}, but they don't have a clan.", (Dictionary<string, object>)null);
					val7.SetTextVariable("NPC_NAME", ((object)npc.Name).ToString());
					val7.SetTextVariable("SETTLEMENT", ((object)val4.Name).ToString());
					InformationManager.DisplayMessage(new InformationMessage(((object)val7).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
				try
				{
					string text5 = aiResult.KingdomActionReason;
					if (string.IsNullOrWhiteSpace(text5))
					{
						text5 = "Received from Liege";
					}
					TerritoryTransferSystem instance = TerritoryTransferSystem.Instance;
					if (instance != null)
					{
						instance.TransferSettlementToClanById(settlementIdReceive, npc.Clan, text5);
						InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_KingdomAction_ReceiveFief}{NPC_NAME} has accepted {SETTLEMENT} from you! Reason: {REASON}", new Dictionary<string, object>
						{
							{ "NPC_NAME", npc.Name },
							{ "SETTLEMENT", val4.Name },
							{ "REASON", text5 }
						})).ToString(), ExtraColors.GreenAIInfluence));
						LogMessage($"[KINGDOM_ACTION] Fief {val4.Name} granted to NPC clan {npc.Clan.Name} by player.");
					}
					else
					{
						LogMessage("[KINGDOM_ACTION] TerritoryTransferSystem is not available");
						TextObject val8 = new TextObject("{=AIInfluence_ReceiveFiefFailed}Failed to grant fief: TerritoryTransferSystem is not available.", (Dictionary<string, object>)null);
						InformationManager.DisplayMessage(new InformationMessage(((object)val8).ToString(), ExtraColors.RedAIInfluence));
					}
					break;
				}
				catch (Exception ex)
				{
					LogMessage("[ERROR] Failed to receive fief: " + ex.Message + "\n" + ex.StackTrace);
					TextObject val9 = new TextObject("{=AIInfluence_ReceiveFiefFailed}Failed to grant fief due to technical error.", (Dictionary<string, object>)null);
					InformationManager.DisplayMessage(new InformationMessage(((object)val9).ToString(), ExtraColors.RedAIInfluence));
					break;
				}
			}
			default:
				LogMessage("[KINGDOM_ACTION] Unknown action: " + aiResult.KingdomAction);
				break;
			}
			return;
			IL_01db:
			if (flag2)
			{
				IFaction mapFaction6 = npc.MapFaction;
				Kingdom val63 = (Kingdom)(object)((mapFaction6 is Kingdom) ? mapFaction6 : null);
				bool flag29 = val63 != null && npc == val63.Leader;
				bool flag30 = val63 != null && ((int)npc.Occupation == 3 || npc.IsClanLeader) && !flag29;
				if (text == "hire_mercenary")
				{
					if (!flag29 && !flag30)
					{
						LogMessage("[KINGDOM_ACTION] Skipping - NPC is not a kingdom leader or vassal (action: " + text + ")");
						return;
					}
				}
				else if (!flag29)
				{
					LogMessage("[KINGDOM_ACTION] Skipping - NPC is not a kingdom leader (action: " + text + ")");
					return;
				}
			}
			npcKingdom = null;
			ref Kingdom reference = ref npcKingdom;
			IFaction mapFaction7 = npc.MapFaction;
			reference = (Kingdom)(object)((mapFaction7 is Kingdom) ? mapFaction7 : null);
			playerKingdom = null;
			if (flag)
			{
				if (Hero.MainHero.MapFaction is Kingdom)
				{
					Hero mainHero2 = Hero.MainHero;
					IFaction mapFaction8 = Hero.MainHero.MapFaction;
					if (mainHero2 == ((mapFaction8 != null) ? mapFaction8.Leader : null))
					{
						if (npcKingdom == null)
						{
							LogMessage("[KINGDOM_ACTION] Failed to get NPC kingdom for diplomatic action");
							return;
						}
						ref Kingdom reference2 = ref playerKingdom;
						IFaction mapFaction9 = Hero.MainHero.MapFaction;
						reference2 = (Kingdom)(object)((mapFaction9 is Kingdom) ? mapFaction9 : null);
						if (playerKingdom == null)
						{
							LogMessage("[KINGDOM_ACTION] Failed to get player kingdom for diplomatic action");
							return;
						}
						LogMessage($"[KINGDOM_ACTION] Processing diplomatic action '{aiResult.KingdomAction}' from {npcKingdom.Name} to {playerKingdom.Name}. Reason: {text2}");
						goto IL_04d0;
					}
				}
				LogMessage("[KINGDOM_ACTION] Skipping diplomatic action - player is not a kingdom leader");
				return;
			}
			if (flag2)
			{
				if (npcKingdom == null)
				{
					LogMessage("[KINGDOM_ACTION] Failed to get NPC kingdom for recruitment action");
					return;
				}
				bool flag31 = npc == npcKingdom.Leader;
				bool flag32 = ((int)npc.Occupation == 3 || npc.IsClanLeader) && !flag31;
				string text16 = (flag31 ? "leader" : (flag32 ? "vassal" : "unknown"));
				LogMessage($"[KINGDOM_ACTION] Processing recruitment action '{aiResult.KingdomAction}' from {npcKingdom.Name} ({text16}). Reason: {text2}");
			}
			else if (flag3)
			{
				LogMessage($"[KINGDOM_ACTION] Processing join action '{aiResult.KingdomAction}' by {npc.Name}. Reason: {text2}");
			}
			else if (flag4)
			{
				LogMessage($"[KINGDOM_ACTION] Processing dismissal action '{aiResult.KingdomAction}' of {npc.Name}. Reason: {text2}");
			}
			else if (flag5)
			{
				LogMessage("[KINGDOM_ACTION] Processing transfer kingdom action '" + aiResult.KingdomAction + "'. Reason: " + text2);
			}
			goto IL_04d0;
		}
		catch (Exception ex18)
		{
			LogMessage("[ERROR] ProcessKingdomAction failed: " + ex18.Message + "\n" + ex18.StackTrace);
		}
	}

	private bool IsPlayerFamilyMember(Hero hero)
	{
		if (hero == null || Hero.MainHero == null)
		{
			return false;
		}
		return hero == Hero.MainHero.Spouse || Hero.MainHero.Spouse == hero || (hero.Siblings != null && hero.Siblings.Contains(Hero.MainHero)) || (Hero.MainHero.Siblings != null && Hero.MainHero.Siblings.Contains(hero)) || (hero.Children != null && ((List<Hero>)(object)hero.Children).Contains(Hero.MainHero)) || (Hero.MainHero.Children != null && ((List<Hero>)(object)Hero.MainHero.Children).Contains(hero)) || hero.Father == Hero.MainHero || hero.Mother == Hero.MainHero || Hero.MainHero.Father == hero || Hero.MainHero.Mother == hero;
	}

	private bool CanNPCBeKilledThroughRoleplay(Hero npc)
	{
		if (npc == null || npc.IsDead)
		{
			LogMessage("[ROLEPLAY_KILL_CHECK] NPC is null or already dead - cannot kill");
			return false;
		}
		if (Mission.Current != null && Settlement.CurrentSettlement != null)
		{
			Agent val = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.Character != null && (object)a.Character == npc.CharacterObject && a.IsActive() && a.IsHuman));
			if (val != null)
			{
				LogMessage($"[ROLEPLAY_KILL_CHECK] {npc.Name} is in active mission - CAN be killed");
				return true;
			}
		}
		if (npc.IsPrisoner)
		{
			if (npc.PartyBelongedToAsPrisoner != null && npc.PartyBelongedToAsPrisoner == PartyBase.MainParty)
			{
				LogMessage($"[ROLEPLAY_KILL_CHECK] {npc.Name} is prisoner of player party - CAN be killed");
				return true;
			}
			if (npc.CurrentSettlement != null && (npc.CurrentSettlement.IsTown || npc.CurrentSettlement.IsCastle))
			{
				LogMessage($"[ROLEPLAY_KILL_CHECK] {npc.Name} is prisoner in settlement {npc.CurrentSettlement.Name} - CAN be killed");
				return true;
			}
			if (npc.PartyBelongedToAsPrisoner != null)
			{
				LogMessage($"[ROLEPLAY_KILL_CHECK] {npc.Name} is prisoner of {npc.PartyBelongedToAsPrisoner.Name} - CANNOT be killed (prisoner in another party on map)");
				return false;
			}
		}
		if (npc.PartyBelongedTo != null && npc.PartyBelongedTo != MobileParty.MainParty)
		{
			int totalManCount = npc.PartyBelongedTo.MemberRoster.TotalManCount;
			if (totalManCount > 1)
			{
				LogMessage($"[ROLEPLAY_KILL_CHECK] {npc.Name} has party with {totalManCount} troops on map - CANNOT be killed (has army protection)");
				return false;
			}
			LogMessage($"[ROLEPLAY_KILL_CHECK] {npc.Name} has party but only 1 troop (alone) - CAN be killed");
			return true;
		}
		if (npc.PartyBelongedTo == MobileParty.MainParty)
		{
			LogMessage($"[ROLEPLAY_KILL_CHECK] {npc.Name} is in player's party (companion) - CAN be killed");
			return true;
		}
		if (npc.CurrentSettlement != null && npc.PartyBelongedTo == null)
		{
			LogMessage($"[ROLEPLAY_KILL_CHECK] {npc.Name} is in settlement {npc.CurrentSettlement.Name} without party - CAN be killed");
			return true;
		}
		LogMessage($"[ROLEPLAY_KILL_CHECK] {npc.Name} - default case - CAN be killed");
		return true;
	}

	public void KillCharacterHeroPublic(Hero hero, Hero killer, bool killedInAction)
	{
		KillCharacterHero(hero, killer, killedInAction);
	}

	private void KillCharacterHero(Hero hero, Hero killer, bool killedInAction)
	{
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (hero == null || hero.IsDead)
			{
				LogMessage("[WARNING] Attempted to kill null or already dead hero");
				return;
			}
			TextObject name = hero.Name;
			Hero obj = killer;
			LogMessage(string.Format("[CHARACTER_DEATH] Killing {0}, killer: {1}, killedInAction: {2}", name, ((obj == null) ? null : ((object)obj.Name)?.ToString()) ?? "unknown", killedInAction));
			if (Mission.Current != null)
			{
				try
				{
					Agent val = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.Character != null && (object)a.Character == hero.CharacterObject && a.IsActive() && a.IsHuman));
					if (val != null)
					{
						LogMessage($"[CHARACTER_DEATH] Found active agent for {hero.Name} in mission, killing agent physically");
						Agent val2 = null;
						if (killer != null)
						{
							val2 = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.Character != null && (object)a.Character == killer.CharacterObject && a.IsActive() && a.IsHuman));
							if (val2 != null)
							{
								LogMessage($"[CHARACTER_DEATH] Found killer agent: {killer.Name} (Index: {val2.Index})");
							}
							else
							{
								LogMessage($"[CHARACTER_DEATH] Killer {killer.Name} not found as active agent in mission");
							}
						}
						Blow val3 = default(Blow);
						val3 = new Blow(val.Index);
						val3.DamageType = (DamageTypes)0;
						val3.BoneIndex = val.Monster.HeadLookDirectionBoneIndex;
						val3.GlobalPosition = val.Position;
						val3.GlobalPosition.z = val3.GlobalPosition.z + val.GetEyeGlobalHeight();
						val3.BaseMagnitude = 10000f;
						val3.InflictedDamage = 10000;
						val3.SwingDirection = val.LookDirection;
						val3.Direction = val3.SwingDirection;
						val3.DamageCalculated = true;
						val3.DamagedPercentage = 1f;
						val3.VictimBodyPart = (BoneBodyPartType)0;
						val3.OwnerId = ((val2 != null) ? val2.Index : (-1));
						object arg = val3.OwnerId;
						Hero obj2 = killer;
						LogMessage(string.Format("[CHARACTER_DEATH] Blow OwnerId set to: {0} (killer: {1})", arg, ((obj2 == null) ? null : ((object)obj2.Name)?.ToString()) ?? "none"));
						val.Die(val3, (KillInfo)(-1));
						LogMessage($"[CHARACTER_DEATH] Agent for {hero.Name} killed in mission - death animation should play");
					}
					else
					{
						LogMessage($"[CHARACTER_DEATH] No active human agent found for {hero.Name} in current mission");
					}
				}
				catch (Exception ex)
				{
					LogMessage($"[ERROR] Failed to kill agent in mission for {hero.Name}: {ex.Message}");
					LogMessage("[ERROR] Agent kill stack trace: " + ex.StackTrace);
				}
			}
			else
			{
				LogMessage("[CHARACTER_DEATH] No active mission - hero will be killed without agent death animation");
			}
			KillCharacterAction.ApplyByMurder(hero, killer, true);
			LogMessage($"[CHARACTER_DEATH] Applied KillCharacterAction.ApplyByMurder for {hero.Name}");
			TextObject name2 = hero.Name;
			Hero obj3 = killer;
			LogMessage(string.Format("[CHARACTER_DEATH] {0} has been killed successfully by {1}", name2, ((obj3 == null) ? null : ((object)obj3.Name)?.ToString()) ?? "unknown"));
			if (hero.CurrentSettlement != null && hero.CurrentSettlement.Notables != null && ((List<Hero>)(object)hero.CurrentSettlement.Notables).Contains(hero))
			{
				((List<Hero>)(object)hero.CurrentSettlement.Notables).Remove(hero);
				LogMessage($"[CHARACTER_DEATH] Removed dead hero {hero.Name} from {hero.CurrentSettlement.Name}.Notables to prevent crash");
			}
		}
		catch (Exception ex2)
		{
			Hero obj4 = hero;
			LogMessage($"[ERROR] Failed to kill character {((obj4 != null) ? obj4.Name : null)}: {ex2.Message}");
			LogMessage("[ERROR] Stack trace: " + ex2.StackTrace);
		}
	}

	private void OnMapEventStartedForDisease(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		try
		{
			ModSettings instance = GlobalSettings<ModSettings>.Instance;
			if (instance != null && instance.EnableDiseaseSystem)
			{
				DiseaseManager.Instance?.OnBattleStarted(mapEvent);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnMapEventStartedForDisease: " + ex.Message);
		}
	}

	private void OnMapEventEndedForDisease(MapEvent mapEvent)
	{
		try
		{
			ModSettings instance = GlobalSettings<ModSettings>.Instance;
			if (instance != null && instance.EnableDiseaseSystem)
			{
				DiseaseManager.Instance?.OnBattleEnded(mapEvent);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnMapEventEndedForDisease: " + ex.Message);
		}
	}

	private void OnHeroPrisonerTaken(PartyBase capturer, Hero prisoner)
	{
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (prisoner == null || !prisoner.IsLord)
			{
				return;
			}
			object obj;
			if (capturer == null)
			{
				obj = null;
			}
			else
			{
				Hero owner = capturer.Owner;
				if (owner == null)
				{
					obj = null;
				}
				else
				{
					Clan clan = owner.Clan;
					obj = ((clan != null) ? clan.Kingdom : null);
				}
			}
			Kingdom val = (Kingdom)obj;
			if (val == null)
			{
				return;
			}
			Clan clan2 = prisoner.Clan;
			Kingdom val2 = ((clan2 != null) ? clan2.Kingdom : null);
			if (val2 != null && FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)val2))
			{
				WarStatisticsTracker.Instance?.IncrementLordsCaptured(val2);
				LogMessage($"[WAR_EVENT] {val.Name} captured lord {prisoner.Name} from {val2.Name}");
			}
			Settlement val3 = ((capturer != null) ? capturer.Settlement : null);
			if (val3 == null && ((capturer != null) ? capturer.MobileParty : null) != null)
			{
				(val3, _) = WorldInfoManager.Instance.GetNearestSettlementInfo(capturer.MobileParty);
			}
			Hero val4 = ((capturer != null) ? capturer.Owner : null);
			string text = ((val4 == null) ? null : ((object)val4.Name)?.ToString()) ?? ((capturer == null) ? null : ((object)capturer.Name)?.ToString()) ?? "unknown";
			object obj2 = ((val4 != null) ? ((MBObjectBase)val4).StringId : null);
			if (obj2 == null)
			{
				if (capturer == null)
				{
					obj2 = null;
				}
				else
				{
					MobileParty mobileParty = capturer.MobileParty;
					if (mobileParty == null)
					{
						obj2 = null;
					}
					else
					{
						Hero leaderHero = mobileParty.LeaderHero;
						obj2 = ((leaderHero != null) ? ((MBObjectBase)leaderHero).StringId : null);
					}
				}
				if (obj2 == null)
				{
					obj2 = "unknown";
				}
			}
			string text2 = (string)obj2;
			object obj3;
			if (val4 == null)
			{
				obj3 = null;
			}
			else
			{
				Clan clan3 = val4.Clan;
				obj3 = ((clan3 == null) ? null : ((object)clan3.Name)?.ToString());
			}
			if (obj3 == null)
			{
				obj3 = "unknown";
			}
			string text3 = (string)obj3;
			object obj4;
			if (val4 == null)
			{
				obj4 = null;
			}
			else
			{
				Clan clan4 = val4.Clan;
				obj4 = ((clan4 != null) ? ((MBObjectBase)clan4).StringId : null);
			}
			if (obj4 == null)
			{
				obj4 = "unknown";
			}
			string text4 = (string)obj4;
			string text5 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) was captured by {text} (id:{text2}) of {text3} (id:{text4})";
			if (val3 != null)
			{
				string arg = (val3.IsTown ? "town" : (val3.IsCastle ? "castle" : "village"));
				text5 += $" and taken to {val3.Name} (id:{((MBObjectBase)val3).StringId}) {arg}";
			}
			int num;
			if (((capturer != null) ? capturer.Owner : null) != Hero.MainHero)
			{
				object obj5;
				if (capturer == null)
				{
					obj5 = null;
				}
				else
				{
					MobileParty mobileParty2 = capturer.MobileParty;
					obj5 = ((mobileParty2 != null) ? mobileParty2.LeaderHero : null);
				}
				if (obj5 != Hero.MainHero && (((capturer != null) ? capturer.Owner : null) == null || capturer.Owner.Clan != Hero.MainHero.Clan))
				{
					num = ((prisoner != null && prisoner.Clan == Hero.MainHero.Clan) ? 1 : 0);
					goto IL_02d5;
				}
			}
			num = 1;
			goto IL_02d5;
			IL_02d5:
			bool flag = (byte)num != 0;
			if (flag)
			{
				string text6 = "";
				if (((capturer != null) ? capturer.Owner : null) == Hero.MainHero || (((capturer != null) ? capturer.MobileParty : null) != null && capturer.MobileParty.LeaderHero == Hero.MainHero))
				{
					text6 = "(you captured them)";
				}
				else if (prisoner == Hero.MainHero)
				{
					text6 = "(you were captured)";
				}
				else if (((capturer != null) ? capturer.Owner : null) != null && capturer.Owner.Clan == Hero.MainHero.Clan)
				{
					text6 = $"(your clan member {capturer.Owner.Name} captured them)";
				}
				else if (prisoner != null && prisoner.Clan == Hero.MainHero.Clan)
				{
					text6 = $"(your clan member {prisoner.Name} was captured)";
				}
				string text7 = $"(player's clan: {Hero.MainHero.Clan.Name}, clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId})";
				text5 = text5 + " " + text6 + " " + text7;
			}
			CampaignEvent ev = new CampaignEvent
			{
				Type = "PrisonerTaken",
				Description = text5,
				Timestamp = CampaignTime.Now
			};
			PrisonerEventData prisonerEventData = new PrisonerEventData
			{
				Prisoner = prisoner,
				Participant = val4,
				Location = val3,
				IsPlayerInvolved = flag,
				Description = text5,
				Type = "PrisonerTaken"
			};
			HashSet<string> hashSet = new HashSet<string>();
			hashSet.Add(((MBObjectBase)prisoner).StringId);
			if (val4 != null)
			{
				hashSet.Add(((MBObjectBase)val4).StringId);
				HashSet<string> recentBattleParticipants = WorldInfoManager.Instance.GetRecentBattleParticipants(((MBObjectBase)val4).StringId);
				if (recentBattleParticipants.Count > 0)
				{
					hashSet.UnionWith(recentBattleParticipants);
				}
			}
			HashSet<string> processedParticipantIds = WorldInfoManager.Instance.AddEventToDirectParticipantsImmediately("PrisonerTaken", ev, val3, prisoner, hashSet, prisonerEventData);
			WorldInfoManager.Instance.QueueEventForInformedNPCs(ev, val3, prisoner, null, defer: true, prisonerEventData, processedParticipantIds);
			LogMessage($"[PRISONER_EVENT] PrisonerTaken event queued for {prisoner.Name}.");
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnHeroPrisonerTaken: " + ex.Message);
		}
	}

	private void OnHeroPrisonerReleased(Hero prisoner, PartyBase party, IFaction capturerFaction, EndCaptivityDetail detail, bool showNotification)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected I4, but got Unknown
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (prisoner == null || prisoner == Hero.MainHero)
			{
				return;
			}
			if (prisoner.IsLord)
			{
				Clan clan = prisoner.Clan;
				Kingdom val = ((clan != null) ? clan.Kingdom : null);
				if (val != null && (int)detail != 5)
				{
					WarStatisticsTracker.Instance?.DecrementLordsCaptured(val);
				}
			}
			Settlement val2 = ((party != null) ? party.Settlement : null);
			if (val2 == null && ((party != null) ? party.MobileParty : null) != null)
			{
				(val2, _) = WorldInfoManager.Instance.GetNearestSettlementInfo(party.MobileParty);
			}
			string text = "PrisonerReleased";
			string text2 = "";
			bool flag = false;
			string text3;
			string text4;
			string text5;
			string text6;
			int num;
			switch ((int)detail)
			{
			case 3:
				if (party != null && party.IsSettlement)
				{
					Settlement settlement = party.Settlement;
					flag = Settlement.CurrentSettlement == settlement || (Hero.MainHero.PartyBelongedTo != null && Hero.MainHero.PartyBelongedTo.CurrentSettlement == settlement) || prisoner.IsPlayerCompanion;
					if (flag)
					{
						text = "PrisonBreakRescue";
						string text9 = ((settlement == null) ? null : ((object)settlement.Name)?.ToString()) ?? "Unknown settlement";
						string text10 = ((settlement != null) ? ((MBObjectBase)settlement).StringId : null) ?? "unknown";
						text2 = $"Player rescued {prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) from the dungeons of {text9} (id:{text10})";
					}
					else
					{
						string text11 = ((settlement == null) ? null : ((object)settlement.Name)?.ToString()) ?? "Unknown settlement";
						string text12 = ((settlement != null) ? ((MBObjectBase)settlement).StringId : null) ?? "unknown";
						text2 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) escaped from the dungeons of {text11} (id:{text12})";
					}
				}
				else
				{
					text2 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) escaped from captivity";
				}
				break;
			case 4:
			{
				Hero val3 = ((party != null) ? party.Owner : null);
				text3 = ((val3 == null) ? null : ((object)val3.Name)?.ToString()) ?? ((party == null) ? null : ((object)party.Name)?.ToString()) ?? "unknown";
				object obj = ((val3 != null) ? ((MBObjectBase)val3).StringId : null);
				if (obj == null)
				{
					if (party == null)
					{
						obj = null;
					}
					else
					{
						MobileParty mobileParty = party.MobileParty;
						if (mobileParty == null)
						{
							obj = null;
						}
						else
						{
							Hero leaderHero = mobileParty.LeaderHero;
							obj = ((leaderHero != null) ? ((MBObjectBase)leaderHero).StringId : null);
						}
					}
					if (obj == null)
					{
						obj = "unknown";
					}
				}
				text4 = (string)obj;
				object obj2;
				if (val3 == null)
				{
					obj2 = null;
				}
				else
				{
					Clan clan2 = val3.Clan;
					obj2 = ((clan2 == null) ? null : ((object)clan2.Name)?.ToString());
				}
				if (obj2 == null)
				{
					obj2 = "unknown";
				}
				text5 = (string)obj2;
				object obj3;
				if (val3 == null)
				{
					obj3 = null;
				}
				else
				{
					Clan clan3 = val3.Clan;
					obj3 = ((clan3 != null) ? ((MBObjectBase)clan3).StringId : null);
				}
				if (obj3 == null)
				{
					obj3 = "unknown";
				}
				text6 = (string)obj3;
				if (((party != null) ? party.Owner : null) != Hero.MainHero)
				{
					object obj4;
					if (party == null)
					{
						obj4 = null;
					}
					else
					{
						MobileParty mobileParty2 = party.MobileParty;
						obj4 = ((mobileParty2 != null) ? mobileParty2.LeaderHero : null);
					}
					if (obj4 != Hero.MainHero && (((party != null) ? party.Owner : null) == null || party.Owner.Clan != Hero.MainHero.Clan))
					{
						num = ((prisoner != null && prisoner.Clan == Hero.MainHero.Clan) ? 1 : 0);
						goto IL_039b;
					}
				}
				num = 1;
				goto IL_039b;
			}
			case 0:
				text2 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) was ransomed and released";
				break;
			case 2:
				text2 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) was released after a battle";
				break;
			case 1:
				text2 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) was released after peace was declared";
				break;
			case 6:
				text2 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) was released in exchange for compensation";
				break;
			case 5:
				text2 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) died in captivity";
				break;
			default:
				{
					text2 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) was released from captivity";
					break;
				}
				IL_039b:
				flag = (byte)num != 0;
				text2 = $"{prisoner.Name} (id:{((MBObjectBase)prisoner).StringId}) was released by {text3} (id:{text4}) of {text5} (id:{text6})";
				if (flag)
				{
					string text7 = "";
					if (((party != null) ? party.Owner : null) == Hero.MainHero || (((party != null) ? party.MobileParty : null) != null && party.MobileParty.LeaderHero == Hero.MainHero))
					{
						text7 = "(you released them)";
					}
					else if (prisoner == Hero.MainHero)
					{
						text7 = "(you were released)";
					}
					else if (((party != null) ? party.Owner : null) != null && party.Owner.Clan == Hero.MainHero.Clan)
					{
						text7 = $"(your clan member {party.Owner.Name} released them)";
					}
					else if (prisoner != null && prisoner.Clan == Hero.MainHero.Clan)
					{
						text7 = $"(your clan member {prisoner.Name} was released)";
					}
					string text8 = $"(player's clan: {Hero.MainHero.Clan.Name}, clan_id:{((MBObjectBase)Hero.MainHero.Clan).StringId})";
					text2 = text2 + " " + text7 + " " + text8;
				}
				break;
			}
			if (val2 != null)
			{
				string arg = (val2.IsTown ? "town" : (val2.IsCastle ? "castle" : "village"));
				text2 += $" at {val2.Name} (id:{((MBObjectBase)val2).StringId}) {arg}";
			}
			CampaignEvent ev = new CampaignEvent
			{
				Type = text,
				Description = text2,
				Timestamp = CampaignTime.Now
			};
			PrisonerEventData prisonerEventData = new PrisonerEventData
			{
				Prisoner = prisoner,
				Participant = ((party != null) ? party.Owner : null),
				Location = val2,
				IsPlayerInvolved = flag,
				Description = text2,
				Type = text
			};
			HashSet<string> hashSet = new HashSet<string>();
			hashSet.Add(((MBObjectBase)prisoner).StringId);
			if (((party != null) ? party.Owner : null) != null)
			{
				hashSet.Add(((MBObjectBase)party.Owner).StringId);
			}
			HashSet<string> processedParticipantIds = WorldInfoManager.Instance.AddEventToDirectParticipantsImmediately(text, ev, val2, prisoner, hashSet, prisonerEventData);
			WorldInfoManager.Instance.QueueEventForInformedNPCs(ev, val2, prisoner, null, defer: true, prisonerEventData, processedParticipantIds);
			LogMessage($"[PRISONER_EVENT] {text} event queued for {prisoner.Name}.");
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnHeroPrisonerReleased: " + ex.Message);
		}
	}

	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (victim == null)
			{
				return;
			}
			FailQuestsForDeadHero(victim);
			if (!victim.IsLord)
			{
				return;
			}
			object obj;
			if (killer == null)
			{
				obj = null;
			}
			else
			{
				Clan clan = killer.Clan;
				obj = ((clan != null) ? clan.Kingdom : null);
			}
			Kingdom val = (Kingdom)obj;
			if (val != null)
			{
				Clan clan2 = victim.Clan;
				Kingdom val2 = ((clan2 != null) ? clan2.Kingdom : null);
				if (val2 != null && FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)val2) && ((int)detail == 4 || (int)detail == 1))
				{
					WarStatisticsTracker.Instance?.IncrementLordsKilled(val);
					LogMessage($"[WAR_EVENT] {val.Name} killed lord {victim.Name} from {val2.Name} (Detail: {detail})");
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnHeroKilled: " + ex.Message);
		}
	}

	private void OnMobilePartyDestroyed(MobileParty destroyedParty, PartyBase destroyerParty)
	{
		try
		{
			if (destroyedParty == null)
			{
				return;
			}
			string partyId = ((MBObjectBase)destroyedParty).StringId;
			if (!string.IsNullOrEmpty(partyId) && FindQuestBySpawnedPartyId(partyId) != null)
			{
				HandleSpawnedQuestPartyDefeated(partyId);
				return;
			}
			if (!destroyedParty.IsCaravan)
			{
				return;
			}
			Hero owner = destroyedParty.Owner;
			object obj;
			if (owner == null)
			{
				obj = null;
			}
			else
			{
				Clan clan = owner.Clan;
				obj = ((clan != null) ? clan.Kingdom : null);
			}
			Kingdom val = (Kingdom)obj;
			if (val == null)
			{
				return;
			}
			object obj2;
			if (destroyerParty == null)
			{
				obj2 = null;
			}
			else
			{
				Hero owner2 = destroyerParty.Owner;
				if (owner2 == null)
				{
					obj2 = null;
				}
				else
				{
					Clan clan2 = owner2.Clan;
					obj2 = ((clan2 != null) ? clan2.Kingdom : null);
				}
			}
			Kingdom val2 = (Kingdom)obj2;
			if (val2 != null && FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)val2))
			{
				WarStatisticsTracker.Instance?.IncrementCaravansDestroyed(val);
				LogMessage($"[WAR_EVENT] {val.Name} lost caravan to {val2.Name}");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnMobilePartyDestroyed: " + ex.Message);
		}
	}

	private void OnPartyJoinedArmy(MobileParty mobileParty)
	{
		try
		{
			if (mobileParty == null || mobileParty.IsMainParty)
			{
				return;
			}
			Hero partyLeader = mobileParty.LeaderHero;
			if (partyLeader == null)
			{
				return;
			}
			bool flag = mobileParty.Army != null && mobileParty.Army.LeaderParty != null && mobileParty.Army.LeaderParty.IsMainParty;
			TaskManager instance = TaskManager.Instance;
			if (instance == null)
			{
				return;
			}
			HeroTask activeTask = instance.GetActiveTask(partyLeader);
			if (activeTask == null || !activeTask.IsActive())
			{
				return;
			}
			if (flag)
			{
				instance.CancelTask(partyLeader);
				AIActionManager.Instance?.StopAllActions(partyLeader);
				LogMessage(string.Format("[ARMY_JOIN_PLAYER] {0} joined player's army. Cancelled all active tasks and actions: {1}", partyLeader.Name, activeTask.Description ?? "No description"));
				return;
			}
			TextObject name = partyLeader.Name;
			Army army = mobileParty.Army;
			object obj;
			if (army == null)
			{
				obj = null;
			}
			else
			{
				MobileParty leaderParty = army.LeaderParty;
				if (leaderParty == null)
				{
					obj = null;
				}
				else
				{
					Hero leaderHero = leaderParty.LeaderHero;
					obj = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString());
				}
			}
			if (obj == null)
			{
				obj = "unknown";
			}
			LogMessage(string.Format("[ARMY_JOIN_WARNING] {0} joined army (leader: {1}) despite having active player task: {2}. ", name, obj, activeTask.Description ?? "No description") + "This should have been prevented by PreventArmyJoinOnPlayerTaskPatch. Attempting to detach from army.");
			if (mobileParty.Army == null || mobileParty.AttachedTo == null)
			{
				return;
			}
			_delayedTaskManager.AddTask(0.10000000149011612, delegate
			{
				try
				{
					if (mobileParty.Army != null && mobileParty.AttachedTo != null)
					{
						mobileParty.AttachedTo = null;
						LogMessage($"[ARMY_JOIN_FIXED] Successfully detached {partyLeader.Name} from army to continue player task.");
					}
				}
				catch (Exception ex2)
				{
					LogMessage($"[ARMY_JOIN_ERROR] Failed to detach {partyLeader.Name} from army: {ex2.Message}");
				}
			});
		}
		catch (Exception ex)
		{
			LogMessage("[ARMY_JOIN_ERROR] Error in OnPartyJoinedArmy: " + ex.Message);
		}
	}

	private void OnNewCompanionAdded(Hero companion)
	{
		try
		{
			if (companion != null && companion.CompanionOf == Clan.PlayerClan && companion.PartyBelongedTo != MobileParty.MainParty && (companion.CurrentSettlement != null || Settlement.CurrentSettlement != null))
			{
				AIActionManager instance = AIActionManager.Instance;
				if (instance != null && instance.IsActionActive(companion, "follow_player"))
				{
					LogMessage($"[COMPANION_ADDED] Companion {companion.Name} has active follow_player action - skipping auto-move (will be handled by join_player_clan logic)");
					return;
				}
				if (MobileParty.MainParty == null)
				{
					LogMessage($"[COMPANION_ADDED] Cannot move {companion.Name} to player party - MainParty is null");
					return;
				}
				LogMessage($"[COMPANION_ADDED] Moving companion {companion.Name} to player party (joined via standard dialog)");
				AddHeroToPartyAction.Apply(companion, MobileParty.MainParty, true);
				LogMessage($"[COMPANION_ADDED] Successfully moved {companion.Name} to player party");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] OnNewCompanionAdded: " + ex.Message);
		}
	}

	public void SaveAllData()
	{
		try
		{
			DiplomacyManager.Instance.SaveAllData();
			SettlementOwnershipTracker.Instance.SaveData();
			KingdomLeadershipTracker.Instance.SaveData();
			LogMessage("[SYSTEM] All data saved successfully");
		}
		catch (Exception ex)
		{
			LogMessage("[SYSTEM] ERROR saving data: " + ex.Message);
		}
	}

	public void ClearCurrentSaveData()
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		try
		{
			DiplomacyManager.Instance.ClearCurrentSaveData();
			InformationManager.DisplayMessage(new InformationMessage("All diplomacy data cleared for current save", Colors.Yellow));
			LogMessage("[SYSTEM] All diplomacy data cleared for current save");
		}
		catch (Exception ex)
		{
			LogMessage("[SYSTEM] ERROR clearing diplomacy data: " + ex.Message);
			InformationManager.DisplayMessage(new InformationMessage("Error clearing diplomacy data: " + ex.Message, ExtraColors.RedAIInfluence));
		}
	}

	private void OnGameLoadFinished()
	{
		try
		{
			LogMessage("[WELCOME] OnGameLoadFinished event received, trying to show welcome popup.");
			TryShowWelcomePopupForCurrentCampaign();
		}
		catch (Exception ex)
		{
			LogMessage("[WELCOME][ERROR] Exception in OnGameLoadFinished: " + ex.Message);
		}
	}

	private void TryShowWelcomePopupForCurrentCampaign()
	{
		try
		{
			if (_welcomeCheckedThisSession)
			{
				return;
			}
			_welcomeCheckedThisSession = true;
			LogMessage("[WELCOME] TryShowWelcomePopupForCurrentCampaign called.");
			string activeSaveDirectory = GetActiveSaveDirectory();
			string text = Path.Combine(activeSaveDirectory, "welcome_popup_shown.txt");
			if (File.Exists(text))
			{
				LogMessage("[WELCOME] Welcome popup already shown for this campaign, skipping.");
				return;
			}
			try
			{
				File.WriteAllText(text, DateTime.Now.ToString("O"));
				LogMessage("[WELCOME] Created welcome marker file: " + text);
			}
			catch (Exception ex)
			{
				LogMessage("[WELCOME][ERROR] Failed to create welcome marker file: " + ex.Message);
			}
			ShowWelcomePopup();
		}
		catch (Exception ex2)
		{
			LogMessage("[WELCOME][ERROR] Exception in TryShowWelcomePopupForCurrentCampaign: " + ex2.Message);
		}
	}

	private void ShowWelcomePopup()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		string text = ((object)new TextObject("{=AIInfluence_Welcome_Title}Welcome to AI Influence", (Dictionary<string, object>)null)).ToString();
		string text2 = ((object)new TextObject("{=AIInfluence_Welcome_Description}You are starting a new campaign with the AI Influence modification, which makes the behavior of lords and factions more lively and meaningful. The world reacts more actively to your actions, and the campaign feels more dynamic and less predictable.\n\nThis mod is developed by a single person in their free time, so any support and feedback is especially valuable. If you enjoy the mod, you can join our community on Discord or support development on Boosty — this directly helps to improve the project and release new updates. Thank you for playing with AI Influence!", (Dictionary<string, object>)null)).ToString();
		List<InquiryElement> list = new List<InquiryElement>
		{
			new InquiryElement((object)"discord", ((object)new TextObject("{=AIInfluence_Welcome_Discord_Button}Open Discord", (Dictionary<string, object>)null)).ToString(), (ImageIdentifier)null, true, ((object)new TextObject("{=AIInfluence_Welcome_Discord_Hint}Open the AI Influence Discord server", (Dictionary<string, object>)null)).ToString()),
			new InquiryElement((object)"boosty", ((object)new TextObject("{=AIInfluence_Welcome_Boosty_Button}Open Boosty", (Dictionary<string, object>)null)).ToString(), (ImageIdentifier)null, true, ((object)new TextObject("{=AIInfluence_Welcome_Boosty_Hint}Open the AI Influence Boosty support page", (Dictionary<string, object>)null)).ToString()),
			new InquiryElement((object)"afdian", ((object)new TextObject("{=AIInfluence_OpenAfdian_Button}Open Afdian", (Dictionary<string, object>)null)).ToString(), (ImageIdentifier)null, true, ((object)new TextObject("{=AIInfluence_OpenAfdian_Hint}Open the AI Influence Afdian support page in your browser", (Dictionary<string, object>)null)).ToString()),
			new InquiryElement((object)"continue", ((object)new TextObject("{=AIInfluence_Welcome_Continue_Button}Continue", (Dictionary<string, object>)null)).ToString(), (ImageIdentifier)null, true, ((object)new TextObject("{=AIInfluence_Welcome_Continue_Hint}Close this window and start your new campaign", (Dictionary<string, object>)null)).ToString())
		};
		MultiSelectionInquiryData val = new MultiSelectionInquiryData(text, text2, list, true, 1, 1, ((object)GameTexts.FindText("str_done", (string)null)).ToString(), string.Empty, (Action<List<InquiryElement>>)OnWelcomePopupSelection, (Action<List<InquiryElement>>)null, string.Empty, false);
		MBInformationManager.ShowMultiSelectionInquiry(val, false, false);
	}

	private void OnWelcomePopupSelection(List<InquiryElement> elements)
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		if (elements == null || elements.Count == 0)
		{
			return;
		}
		string text = elements[0]?.Identifier as string;
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			switch (text)
			{
			case "discord":
				GlobalSettings<ModSettings>.Instance.OpenDiscordServer();
				break;
			case "boosty":
				try
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = "https://boosty.to/aiinfluence",
						UseShellExecute = true
					});
					break;
				}
				catch (Exception ex2)
				{
					InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_Welcome_Boosty_Error}Could not open browser. Boosty: https://boosty.to/aiinfluence", (Dictionary<string, object>)null)).ToString(), Colors.Yellow));
					LogMessage("[WELCOME][ERROR] Could not open Boosty link: " + ex2.Message);
					break;
				}
			case "afdian":
				try
				{
					GlobalSettings<ModSettings>.Instance?.OpenAfdianPage?.Invoke();
					break;
				}
				catch (Exception ex)
				{
					LogMessage("[WELCOME][ERROR] Could not open Afdian link: " + ex.Message);
					break;
				}
			case "continue":
				break;
			}
		}
		catch (Exception ex3)
		{
			LogMessage("[WELCOME][ERROR] Exception in OnWelcomePopupSelection: " + ex3.Message);
		}
	}
}
