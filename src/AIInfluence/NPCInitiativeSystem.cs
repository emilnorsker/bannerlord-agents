using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AIInfluence.API;
using AIInfluence.Behaviors.AIActions;
using AIInfluence.UI;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class NPCInitiativeSystem
{
	private readonly AIInfluenceBehavior _behavior;

	private readonly Random _random;

	private readonly string _logFilePath;

	private Queue<NPCInitiativeRequest> _pendingRequests = new Queue<NPCInitiativeRequest>();

	private HashSet<string> _npcContactedToday = new HashSet<string>();

	private CampaignTime _lastRequestShown = CampaignTime.Never;

	private const int MAX_REQUESTS_PER_DAY = 1;

	private int _requestsShownToday = 0;

	private CampaignTime _lastResetDay = CampaignTime.Never;

	private CampaignTime _lastInitiativeCheckDay = CampaignTime.Never;

	private bool _isProcessingRequest = false;

	private NPCInitiativeRequest _readyToOpenRequest = null;

	private CampaignTime _lastMapCheckTime = CampaignTime.Never;

	private CampaignTime _lastHostileInitiativeTime = CampaignTime.Never;

	private Dictionary<string, NPCMapApproachIntent> _approachingParties = new Dictionary<string, NPCMapApproachIntent>();

	private int _mapCheckHourlyCounter = 0;

	private List<PendingPlayerLetter> _pendingPlayerLetters = new List<PendingPlayerLetter>();

	private Queue<(Hero npc, string message, CampaignTime arrivalTime)> _pendingNPCResponses = new Queue<(Hero, string, CampaignTime)>();

	public NPCInitiativeSystem(AIInfluenceBehavior behavior)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		_behavior = behavior;
		_random = new Random();
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		string text = Path.Combine(fullName, "logs");
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
		}
		catch
		{
		}
		_logFilePath = Path.Combine(text, "npc_initiative.txt");
	}

	private static string UnescapeFormatting(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		text = text.Replace("\\n", "\n");
		text = text.Replace("\\t", "\t");
		text = text.Replace("\\r", "\r");
		return text;
	}

	private void LogMessage(string message)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(_logFilePath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			File.AppendAllText(_logFilePath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}{Environment.NewLine}");
		}
		catch (Exception)
		{
		}
	}

	public void Tick(float dt)
	{
		if (Campaign.Current != null && Hero.MainHero != null && GlobalSettings<ModSettings>.Instance.EnableModification && GlobalSettings<ModSettings>.Instance.EnableNPCInitiative && !Hero.MainHero.IsPrisoner)
		{
			TryOpenReadyRequest();
			TryShowNextRequest();
			UpdateMapInitiative(dt);
			CheckPendingLetters();
			CheckPendingNPCResponses();
		}
	}

	private void StopPursuit(string partyId, MobileParty party, string reason)
	{
		if (party != null && party.IsActive)
		{
			GameVersionCompatibility.ConditionalEnableAi(party);
			Hero leaderHero = party.LeaderHero;
			string text = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString()) ?? partyId;
			LogMessage("[NPC_MAP_INITIATIVE] Stopped pursuit for " + text + ". Reason: " + reason);
		}
		_approachingParties.Remove(partyId);
	}

	private void UpdateMapInitiative(float dt)
	{
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		if (_approachingParties.Count == 0 || MobileParty.MainParty == null || !MobileParty.MainParty.IsActive)
		{
			return;
		}
		if (Hero.MainHero != null && Hero.MainHero.IsPrisoner)
		{
			List<(string, MobileParty)> list = new List<(string, MobileParty)>();
			foreach (KeyValuePair<string, NPCMapApproachIntent> approachingParty in _approachingParties)
			{
				string partyId = approachingParty.Key;
				MobileParty item = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty p) => ((MBObjectBase)p).StringId == partyId));
				list.Add((partyId, item));
			}
			{
				foreach (var (text, val) in list)
				{
					if (val != null && val.IsActive)
					{
						GameVersionCompatibility.ConditionalEnableAi(val);
						Hero leaderHero = val.LeaderHero;
						string text2 = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString()) ?? text;
						LogMessage("[NPC_MAP_INITIATIVE] Stopped pursuit for " + text2 + ". Reason: Player is prisoner");
					}
					_approachingParties.Remove(text);
				}
				return;
			}
		}
		if (IsPartyInitiativeActive())
		{
			return;
		}
		List<string> list2 = new List<string>();
		Dictionary<string, NPCMapApproachIntent> dictionary = new Dictionary<string, NPCMapApproachIntent>();
		Dictionary<string, (MobileParty, string)> dictionary2 = new Dictionary<string, (MobileParty, string)>();
		if (MobileParty.MainParty.CurrentSettlement != null)
		{
			LogMessage("[NPC_MAP_INITIATIVE] Player entered settlement - stopping all pursuits");
			List<(string, MobileParty)> list3 = new List<(string, MobileParty)>();
			foreach (KeyValuePair<string, NPCMapApproachIntent> approachingParty2 in _approachingParties)
			{
				string partyId2 = approachingParty2.Key;
				MobileParty item2 = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty p) => ((MBObjectBase)p).StringId == partyId2));
				list3.Add((partyId2, item2));
			}
			{
				foreach (var (text3, val2) in list3)
				{
					if (val2 != null && val2.IsActive)
					{
						GameVersionCompatibility.ConditionalEnableAi(val2);
						Hero leaderHero2 = val2.LeaderHero;
						string text4 = ((leaderHero2 == null) ? null : ((object)leaderHero2.Name)?.ToString()) ?? text3;
						LogMessage("[NPC_MAP_INITIATIVE] Stopped pursuit for " + text4 + ". Reason: Player entered settlement");
					}
					_approachingParties.Remove(text3);
				}
				return;
			}
		}
		foreach (KeyValuePair<string, NPCMapApproachIntent> approachingParty3 in _approachingParties)
		{
			string partyId3 = approachingParty3.Key;
			NPCMapApproachIntent value = approachingParty3.Value;
			MobileParty val3 = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty p) => ((MBObjectBase)p).StringId == partyId3));
			if (val3 == null || !val3.IsActive || val3.LeaderHero == null)
			{
				list2.Add(partyId3);
				string text5 = "Unknown";
				if (val3 == null)
				{
					text5 = "Party is null";
				}
				else if (!val3.IsActive)
				{
					text5 = "Party not active";
				}
				else if (val3.LeaderHero == null)
				{
					text5 = "Leader is null";
				}
				LogMessage("[NPC_MAP_INITIATIVE] Removing invalid party " + partyId3 + " (" + text5 + ")");
				continue;
			}
			if (val3.LeaderHero.IsPrisoner)
			{
				list2.Add(partyId3);
				dictionary2[partyId3] = (val3, "NPC is prisoner");
				continue;
			}
			float elapsedDaysUntilNow = (value.DetectTime).ElapsedDaysUntilNow;
			bool flag = false;
			string item3 = "";
			float num = value.TimeoutDays;
			if (num <= 0f)
			{
				int hashCode = partyId3.GetHashCode();
				float num2 = (float)Math.Abs(hashCode % 1000) / 1000f;
				num = ((!value.IsHostile) ? (2f + num2 * 3f) : (4f + num2 * 4f));
				NPCMapApproachIntent value2 = value;
				value2.TimeoutDays = num;
				dictionary[partyId3] = value2;
			}
			if (elapsedDaysUntilNow >= num)
			{
				flag = true;
				string arg = (value.IsHostile ? "Hostile" : "Neutral");
				item3 = $"{arg} timeout ({elapsedDaysUntilNow:F1} days >= {num:F1} days)";
			}
			if (flag)
			{
				list2.Add(partyId3);
				dictionary2[partyId3] = (val3, item3);
			}
			else if (!value.IsHostile && !value.DialogShown)
			{
				Vec2 position2D = val3.GetPosition2D();
				float num3 = (position2D).Distance(MobileParty.MainParty.GetPosition2D());
				if (num3 <= 2f)
				{
					ShowMapInitiativeInquiry(val3.LeaderHero, value);
					NPCMapApproachIntent value3 = value;
					value3.DialogShown = true;
					dictionary[partyId3] = value3;
					val3.SetMoveModeHold();
				}
			}
		}
		foreach (KeyValuePair<string, NPCMapApproachIntent> item4 in dictionary)
		{
			_approachingParties[item4.Key] = item4.Value;
		}
		foreach (string item5 in list2)
		{
			if (dictionary2.TryGetValue(item5, out var value4))
			{
				var (val4, text6) = value4;
				if (val4 != null && val4.IsActive)
				{
					GameVersionCompatibility.ConditionalEnableAi(val4);
					Hero leaderHero3 = val4.LeaderHero;
					string text7 = ((leaderHero3 == null) ? null : ((object)leaderHero3.Name)?.ToString()) ?? item5;
					LogMessage("[NPC_MAP_INITIATIVE] Stopped pursuit for " + text7 + ". Reason: " + text6);
				}
			}
			_approachingParties.Remove(item5);
		}
	}

	private void ShowMapInitiativeInquiry(Hero npc, NPCMapApproachIntent intent)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		if (npc == null || npc.IsPrisoner)
		{
			LogMessage("[NPC_MAP_INITIATIVE] Cannot show inquiry - NPC is null or prisoner");
			return;
		}
		string text = ((object)npc.Name).ToString();
		TextObject val = new TextObject("{=AIInfluence_InitiativeTitle}{NPC_NAME} wants to talk", new Dictionary<string, object> { { "NPC_NAME", text } });
		TextObject val2 = new TextObject("{=AIInfluence_InitiativeMessage}{NPC_NAME} approaches you and wants to talk about something. (Prompt sent to AI, dialogue will open automatically when AI responds)", new Dictionary<string, object> { { "NPC_NAME", text } });
		string text2 = UnescapeFormatting(((object)val).ToString());
		string text3 = UnescapeFormatting(((object)val2).ToString());
		InformationManager.ShowInquiry(new InquiryData(text2, text3, true, true, ((object)new TextObject("{=AIInfluence_AcceptTalk}Talk", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_DeclineTalk}Not now", (Dictionary<string, object>)null)).ToString(), (Action)delegate
		{
			OnAcceptMapInitiative(npc);
		}, (Action)delegate
		{
			OnDeclineMapInitiative(npc);
		}, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), true, false);
		LogMessage("[NPC_MAP_INITIATIVE] Showed inquiry for " + text);
	}

	private async void OnAcceptMapInitiative(Hero npc)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification || npc == null || npc.PartyBelongedTo == null)
		{
			return;
		}
		if (npc.IsPrisoner)
		{
			LogMessage($"[NPC_MAP_INITIATIVE] Cannot accept talk - NPC {npc.Name} is prisoner");
			return;
		}
		LogMessage($"[NPC_MAP_INITIATIVE] Accepted talk with {npc.Name}");
		if (!npc.HasMet)
		{
			npc.SetHasMet();
			LogMessage($"[NPC_MAP_INITIATIVE] Made {npc.Name} known to player (SetHasMet) before processing request");
		}
		_isProcessingRequest = true;
		_approachingParties.Remove(((MBObjectBase)npc.PartyBelongedTo).StringId);
		NPCContext context = _behavior.GetOrCreateNPCContext(npc);
		_behavior.UpdateContextData(context, npc);
		if (!string.IsNullOrEmpty(context.AIGeneratedBackstory) || !string.IsNullOrEmpty(context.AIGeneratedPersonality))
		{
			CharacterInfo.UpdateEncyclopediaDescription(npc, context.AIGeneratedBackstory, context.AIGeneratedPersonality);
		}
		context.IsNPCInitiatedConversation = true;
		context.IsHostileInitiative = false;
		context.AdditionalContext += "\n[CONTEXT: You spotted the player on the map and approached them to talk.]";
		_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		NPCInitiativeRequest request = new NPCInitiativeRequest
		{
			NPC = npc,
			Context = context,
			IsInParty = false,
			CreatedTime = CampaignTime.Now
		};
		await GenerateAndStartPartyConversation(request);
	}

	private void OnDeclineMapInitiative(Hero npc)
	{
		if (npc != null && npc.PartyBelongedTo != null)
		{
			LogMessage($"[NPC_MAP_INITIATIVE] Declined talk with {npc.Name}");
			_approachingParties.Remove(((MBObjectBase)npc.PartyBelongedTo).StringId);
			MobileParty partyBelongedTo = npc.PartyBelongedTo;
			if (partyBelongedTo != null && partyBelongedTo.IsActive)
			{
				GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo);
				LogMessage($"[NPC_MAP_INITIATIVE] Re-enabled AI for {npc.Name}'s party after declining talk");
			}
		}
	}

	public void OnDailyTick()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (Campaign.Current == null || Hero.MainHero == null || !GlobalSettings<ModSettings>.Instance.EnableNPCInitiative || Hero.MainHero.IsPrisoner)
		{
			return;
		}
		if (_lastInitiativeCheckDay != CampaignTime.Never)
		{
			CampaignTime now = CampaignTime.Now;
			float num = (float)((now).ToDays - (_lastInitiativeCheckDay).ToDays);
			if (num < 3f)
			{
				LogMessage($"[NPC_INITIATIVE] Skipping daily check - only {num:F1} days since last check (need 3 days)");
				return;
			}
		}
		_lastInitiativeCheckDay = CampaignTime.Now;
		_npcContactedToday.Clear();
		PerformDailyCheck();
	}

	private void PerformDailyCheck()
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			LogMessage("[NPC_INITIATIVE] Mod is disabled, skipping initiative check");
			return;
		}
		try
		{
			LogMessage("[NPC_INITIATIVE] Starting NPC initiative check (every 3 days)");
			Dictionary<string, NPCContext> nPCContexts = _behavior.GetNPCContexts();
			if (nPCContexts == null)
			{
				return;
			}
			List<KeyValuePair<string, NPCContext>> list = nPCContexts.ToList();
			int num = 0;
			int num2 = 0;
			int num3 = 1;
			foreach (KeyValuePair<string, NPCContext> item in list)
			{
				if (num2 >= num3)
				{
					LogMessage($"[NPC_INITIATIVE] Daily initiative limit reached ({num3}), stopping checks");
					break;
				}
				string npcStringId = item.Key;
				NPCContext value = item.Value;
				if (_npcContactedToday.Contains(npcStringId))
				{
					continue;
				}
				Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((h != null) ? ((MBObjectBase)h).StringId : null) == npcStringId));
				if (val == null || !val.IsAlive || val.IsPrisoner)
				{
					continue;
				}
				if (!value.AllowsLettersFromNPC)
				{
					LogMessage($"[NPC_INITIATIVE] Skipping {val.Name} - NPC does not want to send letters (AllowsLettersFromNPC = false)");
				}
				else
				{
					if (value.InteractionCount < 10)
					{
						continue;
					}
					if (AIActionManager.Instance != null)
					{
						List<string> activeActions = AIActionManager.Instance.GetActiveActions(val);
						if (activeActions.Contains("attack_party") || activeActions.Contains("raid_village") || activeActions.Contains("return_to_player") || activeActions.Contains("follow_player"))
						{
							LogMessage($"[NPC_INITIATIVE] Skipping {val.Name} - Busy with high priority action (Attack/Raid/Return/Follow)");
							continue;
						}
					}
					value = _behavior.GetOrCreateNPCContext(val);
					num++;
					float num4 = CalculateInitiativeChance(val, value);
					int num5 = _random.Next(0, 100);
					object[] obj = new object[4] { val.Name, null, null, null };
					IFaction mapFaction = val.MapFaction;
					obj[1] = ((mapFaction != null) ? mapFaction.Name : null);
					obj[2] = num4;
					obj[3] = num5;
					LogMessage(string.Format("[NPC_INITIATIVE] {0} ({1}) initiative check (chance: {2:F1}%, roll: {3})", obj));
					if ((float)num5 < num4)
					{
						CreateInitiativeRequest(val, value);
						num2++;
						_npcContactedToday.Add(npcStringId);
						TextObject name = val.Name;
						IFaction mapFaction2 = val.MapFaction;
						LogMessage($"[NPC_INITIATIVE] ✓ {name} ({((mapFaction2 != null) ? mapFaction2.Name : null)}) PASSED initiative check - will contact player");
					}
					else
					{
						TextObject name2 = val.Name;
						IFaction mapFaction3 = val.MapFaction;
						LogMessage($"[NPC_INITIATIVE] ✗ {name2} ({((mapFaction3 != null) ? mapFaction3.Name : null)}) FAILED initiative check");
					}
				}
			}
			LogMessage($"[NPC_INITIATIVE] Checked {num} NPCs, initiatives: {num2}/{num3}");
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] NPC Initiative daily check failed: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private float CalculateInitiativeChance(Hero npc, NPCContext context)
	{
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		float num = GlobalSettings<ModSettings>.Instance.NPCInitiativeBaseChance;
		LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Base chance: {num:F1}%");
		int relation = Hero.MainHero.GetRelation(npc);
		if (relation > 20)
		{
			num += GlobalSettings<ModSettings>.Instance.NPCInitiativeFriendlyBonus;
			LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Friendly bonus (+{GlobalSettings<ModSettings>.Instance.NPCInitiativeFriendlyBonus:F1}%) for relation {relation}, total: {num:F1}%");
		}
		else if (relation < -20)
		{
			num += GlobalSettings<ModSettings>.Instance.NPCInitiativeHostileBonus;
			LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Hostile bonus (+{GlobalSettings<ModSettings>.Instance.NPCInitiativeHostileBonus:F1}%) for relation {relation}, total: {num:F1}%");
		}
		else
		{
			LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Neutral relation ({relation}), no relation bonus");
		}
		LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Checking romance level: {context.RomanceLevel:F1} (threshold: >50)");
		if (context.RomanceLevel > 50f)
		{
			num += GlobalSettings<ModSettings>.Instance.NPCInitiativeRomanceBonus;
			LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Romance bonus (+{GlobalSettings<ModSettings>.Instance.NPCInitiativeRomanceBonus:F1}%) for romance level {context.RomanceLevel:F1}, total: {num:F1}%");
		}
		else
		{
			LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - No romance bonus (romance level {context.RomanceLevel:F1} <= 50)");
		}
		if (context.InteractionCount > 10)
		{
			num += GlobalSettings<ModSettings>.Instance.NPCInitiativeFamiliarityBonus;
			LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Familiarity bonus (+{GlobalSettings<ModSettings>.Instance.NPCInitiativeFamiliarityBonus:F1}%) for {context.InteractionCount} interactions, total: {num:F1}%");
		}
		if (IsNPCInPlayerParty(npc))
		{
			num += GlobalSettings<ModSettings>.Instance.NPCInitiativePartyBonus;
			LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Party bonus (+{GlobalSettings<ModSettings>.Instance.NPCInitiativePartyBonus:F1}%) for being in party, total: {num:F1}%");
		}
		if (context.LastInteractionTime != CampaignTime.Never)
		{
			CampaignTime val = CampaignTime.Now;
			double toDays = (val).ToDays;
			val = context.LastInteractionTime;
			float num2 = (float)(toDays - (val).ToDays);
			if (num2 > 20f)
			{
				num += GlobalSettings<ModSettings>.Instance.NPCInitiativeLongTimeSinceContactBonus;
				LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Long time bonus (+{GlobalSettings<ModSettings>.Instance.NPCInitiativeLongTimeSinceContactBonus:F1}%) for {num2:F0} days since last contact, total: {num:F1}%");
			}
			else
			{
				LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Recent contact ({num2:F0} days), no long time bonus");
			}
		}
		float num3 = Math.Max(0f, Math.Min(100f, num));
		if (num3 != num)
		{
			LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - Clamped from {num:F1}% to {num3:F1}%");
		}
		LogMessage($"[NPC_INITIATIVE_CHANCE] {npc.Name} - FINAL chance: {num3:F1}%");
		return num3;
	}

	private void CreateInitiativeRequest(Hero npc, NPCContext context)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null || !npc.IsAlive || npc.IsPrisoner)
		{
			string text = ((npc == null) ? null : ((object)npc.Name)?.ToString()) ?? "Unknown";
			LogMessage("[NPC_INITIATIVE] Skipping " + text + " - NPC is dead, null, or prisoner");
		}
		else if (!IsAnyInitiativeActive())
		{
			bool flag = IsNPCInPlayerParty(npc);
			NPCInitiativeRequest item = new NPCInitiativeRequest
			{
				NPC = npc,
				Context = context,
				IsInParty = flag,
				CreatedTime = CampaignTime.Now
			};
			_pendingRequests.Enqueue(item);
			LogMessage($"[NPC_INITIATIVE] {npc.Name} wants to talk to player (in party: {flag})");
		}
	}

	private bool IsPartyInitiativeActive()
	{
		return _isProcessingRequest || _readyToOpenRequest != null;
	}

	private bool IsMapInitiativeActive()
	{
		return _approachingParties.Count > 0;
	}

	private bool IsAnyInitiativeActive()
	{
		return IsPartyInitiativeActive() || IsMapInitiativeActive();
	}

	private bool CanStartConversation()
	{
		if (Campaign.Current == null || Hero.MainHero == null)
		{
			return false;
		}
		if (Hero.MainHero.IsPrisoner)
		{
			return false;
		}
		ConversationManager conversationManager = Campaign.Current.ConversationManager;
		if (conversationManager != null && conversationManager.IsConversationInProgress)
		{
			return false;
		}
		if (Mission.Current != null)
		{
			return false;
		}
		GameStateManager current = GameStateManager.Current;
		if (!(((current != null) ? current.ActiveState : null) is MapState))
		{
			return false;
		}
		return true;
	}

	private void TryOpenReadyRequest()
	{
		if (_readyToOpenRequest != null)
		{
			if (Hero.MainHero != null && Hero.MainHero.IsPrisoner)
			{
				_readyToOpenRequest = null;
				_isProcessingRequest = false;
			}
			else if (_readyToOpenRequest.NPC != null && _readyToOpenRequest.NPC.IsPrisoner)
			{
				LogMessage($"[NPC_INITIATIVE] Cannot open ready request - NPC {_readyToOpenRequest.NPC.Name} is prisoner");
				_readyToOpenRequest = null;
				_isProcessingRequest = false;
			}
			else if (CanStartConversation())
			{
				LogMessage($"[NPC_INITIATIVE] Conditions met, opening conversation with {_readyToOpenRequest.NPC.Name}");
				NPCInitiativeRequest readyToOpenRequest = _readyToOpenRequest;
				_readyToOpenRequest = null;
				OpenConversation(readyToOpenRequest);
			}
		}
	}

	private void OpenConversation(NPCInitiativeRequest request)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		if (request == null || request.NPC == null)
		{
			LogMessage("[NPC_INITIATIVE] Cannot open conversation - request or NPC is null");
			_isProcessingRequest = false;
			return;
		}
		if (request.NPC.IsPrisoner)
		{
			LogMessage($"[NPC_INITIATIVE] Cannot open conversation - NPC {request.NPC.Name} is prisoner");
			_isProcessingRequest = false;
			return;
		}
		if (!CanStartConversation())
		{
			LogMessage("[NPC_INITIATIVE] Cannot open conversation - conditions changed at last moment");
			_readyToOpenRequest = request;
			return;
		}
		if (IsMapInitiativeActive())
		{
			LogMessage("[NPC_INITIATIVE] Cannot open conversation - map initiative is active");
			_readyToOpenRequest = request;
			return;
		}
		if (request.NPC != null && !request.NPC.HasMet)
		{
			request.NPC.SetHasMet();
			LogMessage($"[NPC_INITIATIVE] Made {request.NPC.Name} known to player (SetHasMet) before opening dialog");
		}
		CampaignMission.OpenConversationMission(new ConversationCharacterData(CharacterObject.PlayerCharacter, (PartyBase)null, true, false, false, false, false, false), new ConversationCharacterData(request.NPC.CharacterObject, (PartyBase)null, true, true, false, false, false, false), "", "", false);
		LogMessage($"[NPC_INITIATIVE] Conversation opened with {request.NPC.Name}");
		_isProcessingRequest = false;
		if (request.NPC != null && !request.IsInParty && request.NPC.PartyBelongedTo != null && request.NPC.PartyBelongedTo != MobileParty.MainParty && request.NPC.PartyBelongedTo.IsActive)
		{
			MobileParty partyBelongedTo = request.NPC.PartyBelongedTo;
			GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo);
			LogMessage($"[NPC_MAP_INITIATIVE] Re-enabled AI for {request.NPC.Name}'s party after opening dialog");
		}
	}

	private void TryShowNextRequest()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		if (!CanStartConversation() || (IsAnyInitiativeActive() && (_isProcessingRequest || IsMapInitiativeActive())) || _pendingRequests.Count == 0)
		{
			return;
		}
		CampaignTime now;
		if (_lastResetDay != CampaignTime.Never)
		{
			now = CampaignTime.Now;
			float num = (float)((now).ToDays - (_lastResetDay).ToDays);
			if (num >= 1f)
			{
				_requestsShownToday = 0;
				_lastResetDay = CampaignTime.Now;
			}
		}
		else
		{
			_lastResetDay = CampaignTime.Now;
		}
		if (_requestsShownToday >= 1)
		{
			LogMessage($"[NPC_INITIATIVE] Daily limit reached ({_requestsShownToday}/{1}), deferring requests");
			return;
		}
		if (_lastRequestShown != CampaignTime.Never)
		{
			now = CampaignTime.Now;
			float num2 = (float)((now).ToHours - (_lastRequestShown).ToHours);
			if (num2 < 4f)
			{
				return;
			}
		}
		NPCInitiativeRequest nPCInitiativeRequest = _pendingRequests.Dequeue();
		if (nPCInitiativeRequest.NPC == null || !nPCInitiativeRequest.NPC.IsAlive || nPCInitiativeRequest.NPC.IsPrisoner)
		{
			LogMessage("[NPC_INITIATIVE] Request cancelled - NPC unavailable (dead, null, or prisoner)");
			_isProcessingRequest = false;
			return;
		}
		_lastRequestShown = CampaignTime.Now;
		_requestsShownToday++;
		LogMessage($"[NPC_INITIATIVE] Showing request {_requestsShownToday}/{1} today");
		ShowInitiativeRequest(nPCInitiativeRequest);
	}

	private void ShowInitiativeRequest(NPCInitiativeRequest request)
	{
		if (request.NPC == null || request.NPC.IsPrisoner)
		{
			LogMessage("[NPC_INITIATIVE] Cannot show request - NPC is null or prisoner");
			_isProcessingRequest = false;
			return;
		}
		_isProcessingRequest = true;
		if (request.IsInParty)
		{
			ShowPartyMemberRequest(request);
		}
		else if (!CanSendMessenger(request.NPC))
		{
			LogMessage($"[NPC_INITIATIVE] {request.NPC.Name} cannot send messenger (prisoner or other restriction)");
			_isProcessingRequest = false;
		}
		else
		{
			ShowMessengerRequest(request);
		}
	}

	private void ShowPartyMemberRequest(NPCInitiativeRequest request)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		string text = ((object)request.NPC.Name).ToString();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("NPC_NAME", text);
		TextObject val = new TextObject("{=AIInfluence_InitiativeTitle}{NPC_NAME} wants to talk", dictionary);
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2.Add("NPC_NAME", text);
		TextObject val2 = new TextObject("{=AIInfluence_InitiativeMessage}{NPC_NAME} approaches you and wants to talk about something.", dictionary2);
		string text2 = UnescapeFormatting(((object)val).ToString());
		string text3 = UnescapeFormatting(((object)val2).ToString());
		InformationManager.ShowInquiry(new InquiryData(text2, text3, true, true, ((object)new TextObject("{=AIInfluence_AcceptTalk}Talk", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_DeclineTalk}Not now", (Dictionary<string, object>)null)).ToString(), (Action)delegate
		{
			OnAcceptPartyMemberTalk(request);
		}, (Action)delegate
		{
			OnDeclinePartyMemberTalk(request);
		}, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), true, false);
		LogMessage("[NPC_INITIATIVE] Showed party member request from " + text);
	}

	private void ShowMessengerRequest(NPCInitiativeRequest request)
	{
		_ = GenerateAndShowMessengerMessage(request);
	}

	public void InitiateMessengerFlow(Hero npc)
	{
		if (npc == null || !npc.IsAlive || npc.IsPrisoner)
		{
			LogMessage($"[NPC_INITIATIVE] Cannot initiate messenger flow - NPC {((npc != null) ? npc.Name : null)} is unavailable");
			return;
		}
		LogMessage($"[NPC_INITIATIVE] Initiating messenger flow for {npc.Name} from external menu");
		NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(npc);
		float distance = CalculateDistanceToNPC(npc);
		int cost = CalculateMessengerCost(distance);
		PlayerMessengerRequest request = new PlayerMessengerRequest
		{
			TargetNPC = npc,
			Context = orCreateNPCContext,
			Cost = cost,
			Distance = distance
		};
		_isProcessingRequest = true;
		ShowTavernMessengerConfirmation(request);
	}

	private void ShowTavernMessengerConfirmation(PlayerMessengerRequest request)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		if (request == null || request.TargetNPC == null)
		{
			LogMessage("[NPC_MESSENGER] ShowTavernMessengerConfirmation: Invalid request");
			_isProcessingRequest = false;
			return;
		}
		string text = ((object)request.TargetNPC.Name).ToString();
		int num = request.Cost;
		if (num <= 0)
		{
			float distance = CalculateDistanceToNPC(request.TargetNPC);
			num = CalculateMessengerCost(distance);
			request.Cost = num;
		}
		bool canAffordMessenger = Hero.MainHero.Gold >= num;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("NPC_NAME", text);
		TextObject val = new TextObject("{=AIInfluence_SendMessengerTo}Send messenger to {NPC_NAME}", dictionary);
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2.Add("NPC_NAME", text);
		dictionary2.Add("COST", num);
		TextObject val2 = new TextObject("{=AIInfluence_TavernMessengerInfo}You want to send a messenger to {NPC_NAME}.\n\nThe messenger will deliver your letter and bring back a response if they choose to reply.\n\nCost: {COST} denars", dictionary2);
		string text2 = ((object)new TextObject("{=AIInfluence_SendMessengerSimple}Send Messenger", (Dictionary<string, object>)null)).ToString();
		string messengerHintText;
		if (canAffordMessenger)
		{
			Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
			dictionary3.Add("COST", num);
			messengerHintText = ((object)new TextObject("{=AIInfluence_MessengerHintEnough}The messenger will take {COST} denars for the journey.", dictionary3)).ToString();
		}
		else
		{
			Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
			dictionary4.Add("COST", num);
			messengerHintText = ((object)new TextObject("{=AIInfluence_MessengerHintNotEnough}The journey costs {COST} denars, but you don't have enough gold.", dictionary4)).ToString();
		}
		string text3 = $"tavern_messenger_{text}_{DateTime.Now.Ticks}";
		string text4 = UnescapeFormatting(((object)val).ToString());
		string text5 = UnescapeFormatting(((object)val2).ToString());
		InformationManager.ShowInquiry(new InquiryData(text4, text5, canAffordMessenger, true, text2, ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action)delegate
		{
			OnSendMessengerToNPC(request);
		}, (Action)delegate
		{
			OnTavernMessengerCancelled();
		}, text3, 0f, (Action)null, (Func<ValueTuple<bool, string>>)(() => (canAffordMessenger, messengerHintText)), (Func<ValueTuple<bool, string>>)(() => (true, ""))), true, false);
		LogMessage($"[NPC_MESSENGER] Showed tavern messenger confirmation for {text} (cost: {num} denars, can afford: {canAffordMessenger})");
	}

	private void OnTavernMessengerCancelled()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		TextObject val = new TextObject("{=AIInfluence_MessengerCancelled}You decided not to send a message.", (Dictionary<string, object>)null);
		InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Gray));
		_isProcessingRequest = false;
	}

	private async Task GenerateAndShowMessengerMessage(NPCInitiativeRequest request)
	{
		try
		{
			if (request.NPC == null || !request.NPC.IsAlive || request.NPC.IsPrisoner)
			{
				LogMessage("[NPC_INITIATIVE] Cannot generate messenger message - NPC is dead, null, or prisoner");
				_isProcessingRequest = false;
				return;
			}
			string npcName = ((object)request.NPC.Name).ToString();
			RefreshContextData(request.NPC, request.Context);
			if (!string.IsNullOrEmpty(request.Context.AIGeneratedBackstory) || !string.IsNullOrEmpty(request.Context.AIGeneratedPersonality))
			{
				CharacterInfo.UpdateEncyclopediaDescription(request.NPC, request.Context.AIGeneratedBackstory, request.Context.AIGeneratedPersonality);
			}
			string prompt = GenerateMessengerPrompt(request.NPC, request.Context);
			LogMessage("[NPC_MESSENGER_PROMPT] Full prompt for " + npcName + ":\n" + prompt);
			LogMessage("[NPC_MESSENGER_DEBUG] About to send AI request for " + npcName);
			LogMessage("[NPC_MESSENGER_DEBUG] Last 3 messages from history:");
			if (request.Context.ConversationHistory != null && request.Context.ConversationHistory.Any())
			{
				List<string> lastMessages = request.Context.ConversationHistory.Skip(Math.Max(0, request.Context.ConversationHistory.Count - 3)).ToList();
				foreach (string msg in lastMessages)
				{
					LogMessage("  - " + msg);
				}
			}
			else
			{
				LogMessage("  - No conversation history");
			}
			AIInfluenceBehavior.ClearNpcTurnDialogueTools(request.Context);
			OpenRouterCallResult sendResult = await _behavior.SendAIRequest(prompt, "npc_messenger", request.NPC, request.Context);
			string aiResponse = sendResult.Payload;
			LogMessage($"[NPC_MESSENGER_DEBUG] Received AI response for {npcName}, length: {aiResponse?.Length ?? 0}");
			LogMessage("[NPC_MESSENGER_DEBUG] FULL AI RESPONSE JSON: " + aiResponse);
			if (!sendResult.Success || string.IsNullOrEmpty(aiResponse))
			{
				LogMessage("[ERROR] Failed to generate messenger message from " + npcName);
				return;
			}
			AIResponse response = NpcOpenRouterAssistantParser.Parse(aiResponse, npcName);
			AIInfluenceBehavior.ApplyNpcContextToolDeferralsToAiResponse(request.Context, response);
			AIInfluenceBehavior.ApplyNpcDialogueToolsToAiResponse(request.Context, response);
			string message = response?.Response ?? "The messenger failed to deliver the message.";
			message = UnescapeFormatting(message);
			request.Context.LastAIResponseJson = JsonConvert.SerializeObject(response);
			if (!string.IsNullOrEmpty(response.CharacterPersonality) && string.IsNullOrEmpty(request.Context.AIGeneratedPersonality))
			{
				string trimmedPersonality = response.CharacterPersonality.Trim();
				request.Context.AIGeneratedPersonality = trimmedPersonality;
				LogMessage("[NPC_MESSENGER] [CHARACTER_PERSONALITY] AI generated personality for " + npcName + ": " + trimmedPersonality);
			}
			if (!string.IsNullOrEmpty(response.CharacterBackstory) && string.IsNullOrEmpty(request.Context.AIGeneratedBackstory))
			{
				string trimmedBackstory = response.CharacterBackstory.Trim();
				request.Context.AIGeneratedBackstory = trimmedBackstory;
				LogMessage("[NPC_MESSENGER] [CHARACTER_BACKSTORY] AI generated backstory for " + npcName + ": " + trimmedBackstory);
			}
			if (!string.IsNullOrEmpty(response.CharacterSpeechQuirks) && string.IsNullOrEmpty(request.Context.AIGeneratedSpeechQuirks))
			{
				string trimmedQuirks = response.CharacterSpeechQuirks.Trim();
				request.Context.AIGeneratedSpeechQuirks = trimmedQuirks;
				LogMessage("[NPC_MESSENGER] [CHARACTER_SPEECH_QUIRKS] AI generated speech quirks for " + npcName + ": " + trimmedQuirks);
			}
			if (response.AllowsLettersFromNPC.HasValue && response.AllowsLettersFromNPC.Value != request.Context.AllowsLettersFromNPC)
			{
				request.Context.AllowsLettersFromNPC = response.AllowsLettersFromNPC.Value;
				LogMessage($"[NPC_MESSENGER] {npcName} changed AllowsLettersFromNPC to {request.Context.AllowsLettersFromNPC}");
				Dictionary<string, object> letterStatusDict = new Dictionary<string, object> { { "NPC_NAME", npcName } };
				string statusTextId = (request.Context.AllowsLettersFromNPC ? "AIInfluence_NPCWillSendLetters" : "AIInfluence_NPCWillNotSendLetters");
				string fallbackText = (request.Context.AllowsLettersFromNPC ? "{NPC_NAME} will now send you letters." : "{NPC_NAME} will no longer send you letters.");
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=" + statusTextId + "}" + fallbackText, letterStatusDict)).ToString(), Colors.Gray));
			}
			if (!string.IsNullOrEmpty(request.Context.AIGeneratedBackstory) || !string.IsNullOrEmpty(request.Context.AIGeneratedPersonality))
			{
				CharacterInfo.UpdateEncyclopediaDescription(request.NPC, request.Context.AIGeneratedBackstory, request.Context.AIGeneratedPersonality);
			}
			if (!request.Context.KnowledgeGenerated)
			{
				WorldInfoManager.WorldSecretsManager.Instance.CheckSecretKnowledge(request.NPC, request.Context);
				WorldInfoManager.InformationManager.Instance.CheckInfoKnowledge(request.NPC, request.Context);
				request.Context.KnowledgeGenerated = true;
			}
			LogMessage("[NPC_MESSENGER] Parsed message from AI: " + message);
			LogMessage("[NPC_MESSENGER_DEBUG] Response object - romance_intent: " + response?.RomanceIntent + ", decision: " + response?.Decision);
			bool isDuplicate = false;
			if (request.Context.ConversationHistory != null && request.Context.ConversationHistory.Any())
			{
				string messageToCheck = npcName + ": " + message + " (sent via messenger)";
				if (request.Context.ConversationHistory.Contains(messageToCheck))
				{
					isDuplicate = true;
					LogMessage("[NPC_MESSENGER_ERROR] DUPLICATE MESSAGE DETECTED! This exact message is already in history!");
					LogMessage("[NPC_MESSENGER_ERROR] This should be IMPOSSIBLE if AI is generating new content!");
					LogMessage("[NPC_MESSENGER_ERROR] Message: " + message);
				}
			}
			CampaignTime now = CampaignTime.Now;
			double sentAtDays = (now).ToDays;
			request.Context.ConversationHistory.Add($"{npcName}: {message} [YOU ALREADY SENT THIS MESSAGE VIA MESSENGER EARLIER - DO NOT REPEAT IT] [sent_at_days={sentAtDays:F3}]");
			request.Context.LastDynamicResponse = message;
			_behavior.SaveNPCContext(((MBObjectBase)request.NPC).StringId, request.NPC, request.Context);
			_behavior.ApplyPendingQuestActionFromTools(request.NPC, request.Context);
			float distanceToNPC = CalculateDistanceToNPC(request.NPC);
			int messengerCost = CalculateMessengerCost(distanceToNPC);
			bool canAffordMessenger = Hero.MainHero.Gold >= messengerCost;
			LogMessage($"[NPC_MESSENGER] Distance to {npcName}: {distanceToNPC:F1}, Cost: {messengerCost} denars, Player gold: {Hero.MainHero.Gold}, Can afford: {canAffordMessenger}");
			string uniqueWindowId = $"messenger_{npcName}_{DateTime.Now.Ticks}";
			TextObject titleText = new TextObject("{=AIInfluence_MessengerTitle}Messenger from {NPC_NAME}", new Dictionary<string, object> { { "NPC_NAME", npcName } });
			string windowTitle = ((object)titleText).ToString();
			TextObject messageText = new TextObject("{=AIInfluence_MessengerMessage}A messenger has arrived with a message:\n{MESSAGE}", new Dictionary<string, object> { { "MESSAGE", message } });
			string messageContent = ((object)messageText).ToString();
			messageContent = UnescapeFormatting(messageContent);
			string sendMessengerButtonText = ((object)new TextObject("{=AIInfluence_SendMessengerSimple}Send Messenger", new Dictionary<string, object> { { "COST", messengerCost } })).ToString();
			string messengerHintText;
			if (canAffordMessenger)
			{
				messengerHintText = ((object)new TextObject("{=AIInfluence_MessengerHintEnough}The messenger will take {COST} denars for the journey.", new Dictionary<string, object> { { "COST", messengerCost } })).ToString();
			}
			else
			{
				messengerHintText = ((object)new TextObject("{=AIInfluence_MessengerHintNotEnough}The journey costs {COST} denars, but you don't have enough gold.", new Dictionary<string, object> { { "COST", messengerCost } })).ToString();
			}
			LogMessage("[NPC_MESSENGER_DEBUG] About to show window with ID: " + uniqueWindowId);
			LogMessage("[NPC_MESSENGER_DEBUG] Window message: " + message);
			LogMessage($"[NPC_MESSENGER_DEBUG] Message content length: {messageContent.Length}");
			LogMessage($"[NPC_MESSENGER_DEBUG] Is duplicate: {isDuplicate}");
			if (GlobalSettings<ModSettings>.Instance?.EnableResponseReadySound ?? false)
			{
				try
				{
					SoundEvent.PlaySound2D("event:/ui/notification/alert");
				}
				catch
				{
				}
			}
			PlayerMessengerRequest messengerRequest = new PlayerMessengerRequest
			{
				TargetNPC = request.NPC,
				Context = request.Context,
				Cost = messengerCost,
				Distance = distanceToNPC
			};
			InformationManager.ShowInquiry(new InquiryData(windowTitle, messageContent, canAffordMessenger, true, sendMessengerButtonText, ((object)new TextObject("{=AIInfluence_MessengerAcknowledge}Acknowledge", (Dictionary<string, object>)null)).ToString(), (Action)delegate
			{
				OnSendMessengerToNPC(messengerRequest);
			}, (Action)delegate
			{
				OnAcknowledgeMessenger(request);
			}, uniqueWindowId, 0f, (Action)null, (Func<ValueTuple<bool, string>>)(() => (canAffordMessenger, messengerHintText)), (Func<ValueTuple<bool, string>>)(() => (true, ""))), true, false);
			LogMessage("[NPC_MESSENGER] " + npcName + " message: " + message);
			LogMessage("[NPC_INITIATIVE] Showed messenger window ID: " + uniqueWindowId + " from " + npcName);
			LogMessage("[NPC_MESSENGER_DEBUG] Window visible with message: " + message);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			LogMessage("[ERROR] GenerateAndShowMessengerMessage failed: " + ex2.Message + "\n" + ex2.StackTrace);
		}
		finally
		{
			_isProcessingRequest = false;
			LogMessage("[NPC_INITIATIVE] Processing flag reset after messenger message attempt");
		}
	}

	private string GenerateMessengerPrompt(Hero npc, NPCContext context)
	{
		string text = PromptGenerator.GeneratePrompt(npc, context, false, isMessengerMode: true);
		string text2 = "\n\n=== SPECIAL SITUATION: YOU INITIATED CONTACT ===\nYou decided to reach out to this person by sending them a messenger with a written message.\nIMPORTANT: This is a WRITTEN MESSAGE, not a live conversation. Do NOT use **asterisks** for actions.\nCRITICAL: You are SENDING a message TO the player.\nDo NOT mention receiving any letter or message from them - you initiated this contact yourself.\n\n**CRITICAL INSTRUCTIONS:**\n- Pay attention to your recent conversations with the player (check your conversation history above)\n- You can write about recent events, your relationship, current situation, or anything relevant\n- Be specific and personal - avoid generic greetings\n- DO NOT repeat topics from your previous conversations\n- Make this message feel natural and motivated by recent events or your relationship\n- Keep the tone appropriate to your relationship (friendly/romantic/business-like/concerned)\n" + $"- Your message should be at least {GlobalSettings<ModSettings>.Instance.PromptMinResponseLength} characters and not exceed {GlobalSettings<ModSettings>.Instance.PromptMaxResponseLength} characters\n" + "- NEVER mention receiving a letter or message from the player - you are the one sending the message\n";
		return text + text2;
	}

	public string GeneratePartyInitiativePrompt(Hero npc, NPCContext context)
	{
		string text = PromptGenerator.GeneratePrompt(npc, context);
		string text2 = ((string.IsNullOrEmpty(context.AdditionalContext) || !context.AdditionalContext.Contains("returned to the player after completing a task")) ? ("\n\n=== SPECIAL SITUATION: YOU INITIATED CONVERSATION ===\nYOU approached the player and started this conversation yourself. The player agreed to talk.\n\n**CRITICAL INSTRUCTIONS:**\n- Pay attention to your recent conversations with the player (check your conversation history above)\n- You can talk about recent events, your relationship, current situation, or anything relevant\n- Be specific and personal - avoid generic greetings like \"Hello, how are you?\"\n- DO NOT repeat topics from your previous conversations\n- Make this conversation feel natural and motivated by recent events or your relationship\n- Keep the tone appropriate to your relationship (friendly/romantic/concerned/business-like)\n" + $"- Your opening should be at least {GlobalSettings<ModSettings>.Instance.PromptMinResponseLength} characters and not exceed {GlobalSettings<ModSettings>.Instance.PromptMaxResponseLength} characters\n") : ("\n\n=== SPECIAL SITUATION: YOU RETURNED TO THE PLAYER ===\nYOU have just returned to the player. The player agreed to talk.\n\n**CRITICAL INSTRUCTIONS:**\n- Pay attention to your recent conversations with the player (check your conversation history above)\n- Say something relevant based on your relationship and recent interactions\n- Keep the tone appropriate to your relationship with the player\n" + $"- Your opening should be at least {GlobalSettings<ModSettings>.Instance.PromptMinResponseLength} characters and not exceed {GlobalSettings<ModSettings>.Instance.PromptMaxResponseLength} characters\n"));
		return text + text2;
	}

	private void OnAcceptPartyMemberTalk(NPCInitiativeRequest request)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		if (request.NPC == null || !request.NPC.IsAlive || request.NPC.IsPrisoner)
		{
			LogMessage("[NPC_INITIATIVE] Cannot accept talk - NPC is dead, null, or prisoner");
			_isProcessingRequest = false;
			TextObject val = new TextObject("{=AIInfluence_InitiativeFailed}The NPC is no longer available.", (Dictionary<string, object>)null);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Gray));
			return;
		}
		LogMessage($"[NPC_INITIATIVE] Player accepted talk with {request.NPC.Name}");
		if (!request.NPC.HasMet)
		{
			request.NPC.SetHasMet();
			LogMessage($"[NPC_INITIATIVE] Made {request.NPC.Name} known to player (SetHasMet) before processing request");
		}
		_ = GenerateAndStartPartyConversation(request);
	}

	public async Task StartConversationAfterReturn(NPCInitiativeRequest request)
	{
		await GenerateAndStartPartyConversation(request);
	}

	private async Task GenerateAndStartPartyConversation(NPCInitiativeRequest request)
	{
		try
		{
			if (request.NPC == null || !request.NPC.IsAlive || request.NPC.IsPrisoner)
			{
				LogMessage("[NPC_INITIATIVE] Cannot start party conversation - NPC is dead, null, or prisoner");
				_isProcessingRequest = false;
				TextObject errorText = new TextObject("{=AIInfluence_InitiativeFailed}The NPC is no longer available.", (Dictionary<string, object>)null);
				InformationManager.DisplayMessage(new InformationMessage(((object)errorText).ToString(), Colors.Gray));
				return;
			}
			RefreshContextData(request.NPC, request.Context);
			if (!string.IsNullOrEmpty(request.Context.AIGeneratedBackstory) || !string.IsNullOrEmpty(request.Context.AIGeneratedPersonality))
			{
				CharacterInfo.UpdateEncyclopediaDescription(request.NPC, request.Context.AIGeneratedBackstory, request.Context.AIGeneratedPersonality);
			}
			request.Context.IsNPCInitiatedConversation = true;
			request.Context.IsHostileInitiative = false;
			_behavior.SaveNPCContext(((MBObjectBase)request.NPC).StringId, request.NPC, request.Context);
			if (!CanStartConversation())
			{
				LogMessage("[NPC_INITIATIVE] Cannot open conversation - player state changed (in dialog/mission/not on map). Will wait for suitable conditions.");
				_readyToOpenRequest = request;
				_isProcessingRequest = false;
			}
			else
			{
				LogMessage($"[NPC_INITIATIVE] Opening neutral initiative dialog with {request.NPC.Name} - response will be generated in dialog");
				OpenConversation(request);
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			LogMessage("[ERROR] GenerateAndStartPartyConversation failed: " + ex2.Message + "\n" + ex2.StackTrace);
			TextObject errorText2 = new TextObject("{=AIInfluence_ConversationStartFailed}Failed to start conversation", (Dictionary<string, object>)null);
			InformationManager.DisplayMessage(new InformationMessage(((object)errorText2).ToString(), ExtraColors.RedAIInfluence));
			_isProcessingRequest = false;
		}
	}

	private void OnDeclinePartyMemberTalk(NPCInitiativeRequest request)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		LogMessage($"[NPC_INITIATIVE] Player declined talk with {request.NPC.Name}");
		_isProcessingRequest = false;
		request.Context.IsNPCInitiatedConversation = false;
		_behavior.SaveNPCContext(((MBObjectBase)request.NPC).StringId, request.NPC, request.Context);
		string value = ((object)request.NPC.Name).ToString();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("NPC_NAME", value);
		TextObject val = new TextObject("{=AIInfluence_InitiativeDeclined}{NPC_NAME} looks a bit disappointed but nods understandingly.", dictionary);
		InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Gray));
	}

	private void OnAcknowledgeMessenger(NPCInitiativeRequest request)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		LogMessage($"[NPC_INITIATIVE] Player read message from {request.NPC.Name}");
		_isProcessingRequest = false;
		TextObject val = new TextObject("{=AIInfluence_MessengerDeparted}The messenger bows and departs on his return journey.", (Dictionary<string, object>)null);
		InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Gray));
	}

	private float CalculateDistanceToNPC(Hero npc)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null || MobileParty.MainParty == null)
		{
			return 100f;
		}
		Vec2 position2D = MobileParty.MainParty.GetPosition2D();
		Vec2 val;
		if (npc.PartyBelongedTo != null && npc.PartyBelongedTo.IsActive)
		{
			val = npc.PartyBelongedTo.GetPosition2D();
		}
		else if (npc.CurrentSettlement != null)
		{
			val = npc.CurrentSettlement.GetPosition2D;
		}
		else
		{
			if (npc.HomeSettlement == null)
			{
				return 100f;
			}
			val = npc.HomeSettlement.GetPosition2D;
		}
		return (position2D).Distance(val);
	}

	private int CalculateMessengerCost(float distance)
	{
		float messengerCostPerDistance = GlobalSettings<ModSettings>.Instance.MessengerCostPerDistance;
		int val = (int)(distance * messengerCostPerDistance);
		return Math.Max(50, val);
	}

	private float CalculateDeliveryTimeHours(float distance)
	{
		float messengerDeliveryHoursPerDistance = GlobalSettings<ModSettings>.Instance.MessengerDeliveryHoursPerDistance;
		float num = 10f;
		float val = distance / num * messengerDeliveryHoursPerDistance;
		return Math.Max(2f, val);
	}

	private string BuildMessageDialogDescription(string baseDescription, string npcName, NPCContext context)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		if (context == null)
		{
			return baseDescription;
		}
		List<string> list = new List<string> { baseDescription };
		if (!string.IsNullOrWhiteSpace(context.LastDynamicResponse))
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
		return string.Join("\n\n", list);
	}

	private void OnSendMessengerToNPC(PlayerMessengerRequest request)
	{
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		if (request == null || request.TargetNPC == null)
		{
			LogMessage("[NPC_MESSENGER] OnSendMessengerToNPC: Invalid request");
			_isProcessingRequest = false;
			return;
		}
		LogMessage($"[NPC_MESSENGER] Player wants to send messenger to {request.TargetNPC.Name}");
		string text = ((object)request.TargetNPC.Name).ToString();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("NPC_NAME", text);
		TextObject val = new TextObject("{=AIInfluence_WriteMessage}Write a message to {NPC_NAME}", dictionary);
		int messengerCost = request.Cost;
		if (messengerCost <= 0)
		{
			float distance = CalculateDistanceToNPC(request.TargetNPC);
			messengerCost = CalculateMessengerCost(distance);
			request.Cost = messengerCost;
		}
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2.Add("COST", messengerCost);
		string enoughGoldHint = ((object)new TextObject("{=AIInfluence_MessengerHintEnough}The messenger will take {COST} denars for the journey.", dictionary2)).ToString();
		string notEnoughGoldHint = ((object)new TextObject("{=AIInfluence_MessengerHintNotEnough}The journey costs {COST} denars, but you don't have enough gold.", dictionary2)).ToString();
		string emptyMessageHint = ((object)new TextObject("{=AIInfluence_EmptyMessage}You need to write something in the message.", (Dictionary<string, object>)null)).ToString();
		string baseDescription = ((Hero.MainHero.Gold >= messengerCost) ? enoughGoldHint : notEnoughGoldHint);
		string text2 = BuildMessageDialogDescription(baseDescription, text, request.Context);
		try
		{
			Hero targetNPC = request.TargetNPC;
			if (((targetNPC != null) ? targetNPC.CharacterObject : null) != null)
			{
				CharacterCode characterCode = CampaignUIHelper.GetCharacterCode(request.TargetNPC.CharacterObject, false);
				AIInfluencePortraitWidget.PendingCharacterCode = ((characterCode != null) ? characterCode.Code : null);
			}
		}
		catch
		{
			AIInfluencePortraitWidget.PendingCharacterCode = null;
		}
		AIInfluenceTextQueryPopupManager.Show(new TextInquiryData(((object)val).ToString(), text2, true, true, ((object)new TextObject("{=AIInfluence_SendLetter}Send", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<string>)delegate(string playerMessage)
		{
			AIInfluencePortraitWidget.PendingCharacterCode = null;
			OnPlayerMessageConfirmed(request, playerMessage);
		}, (Action)delegate
		{
			AIInfluencePortraitWidget.PendingCharacterCode = null;
			OnPlayerMessageCancelled();
		}, false, (Func<string, Tuple<bool, string>>)delegate(string value)
		{
			if (Hero.MainHero.Gold < messengerCost)
			{
				return new Tuple<bool, string>(item1: false, notEnoughGoldHint);
			}
			return string.IsNullOrWhiteSpace(value) ? new Tuple<bool, string>(item1: false, emptyMessageHint) : new Tuple<bool, string>(item1: true, enoughGoldHint);
		}, "", ""));
	}

	private void OnPlayerMessageConfirmed(PlayerMessengerRequest request, string playerMessage)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		if (string.IsNullOrWhiteSpace(playerMessage))
		{
			TextObject val = new TextObject("{=AIInfluence_EmptyMessage}You need to write something in the message.", (Dictionary<string, object>)null);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Yellow));
			_isProcessingRequest = false;
			return;
		}
		string text = ((object)request.TargetNPC.Name).ToString();
		if (Hero.MainHero.Gold < request.Cost)
		{
			TextObject val2 = new TextObject("{=AIInfluence_NotEnoughGold}You don't have enough gold to send a messenger.", (Dictionary<string, object>)null);
			InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), Colors.Yellow));
			_isProcessingRequest = false;
			return;
		}
		Hero.MainHero.ChangeHeroGold(-request.Cost);
		float num = CalculateDeliveryTimeHours(request.Distance);
		CampaignTime expectedArrivalTime = CampaignTime.HoursFromNow(num);
		PendingPlayerLetter item = new PendingPlayerLetter
		{
			TargetNPCStringId = ((MBObjectBase)request.TargetNPC).StringId,
			PlayerMessage = playerMessage,
			SentTime = CampaignTime.Now,
			ExpectedArrivalTime = expectedArrivalTime,
			Distance = request.Distance
		};
		_pendingPlayerLetters.Add(item);
		string arg = ((object)Hero.MainHero.Name).ToString();
		CampaignTime now = CampaignTime.Now;
		double toDays = (now).ToDays;
		request.Context.ConversationHistory.Add($"{arg}: {playerMessage} [SENT VIA MESSENGER BY PLAYER] [sent_at_days={toDays:F3}]");
		request.Context.LastInteractionTime = CampaignTime.Now;
		_behavior.SaveNPCContext(((MBObjectBase)request.TargetNPC).StringId, request.TargetNPC, request.Context);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("NPC_NAME", text);
		dictionary.Add("HOURS", (int)num);
		TextObject val3 = new TextObject("{=AIInfluence_MessengerSent}Your messenger has departed to deliver your message to {NPC_NAME}. Expected arrival in approximately {HOURS} hours.", dictionary);
		InformationManager.DisplayMessage(new InformationMessage(((object)val3).ToString(), Colors.Gray));
		LogMessage($"[NPC_MESSENGER] Player sent message to {text}. Cost: {request.Cost}, Delivery time: {num:F1} hours. Message: {playerMessage}");
		_isProcessingRequest = false;
	}

	private void OnPlayerMessageCancelled()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		TextObject val = new TextObject("{=AIInfluence_MessengerCancelled}You decided not to send a message.", (Dictionary<string, object>)null);
		InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Gray));
		_isProcessingRequest = false;
	}

	public void CheckPendingLetters()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		if (_pendingPlayerLetters.Count == 0)
		{
			return;
		}
		List<PendingPlayerLetter> list = new List<PendingPlayerLetter>();
		List<PendingPlayerLetter> list2 = new List<PendingPlayerLetter>();
		foreach (PendingPlayerLetter letter in _pendingPlayerLetters)
		{
			CampaignTime val = CampaignTime.Now;
			double toHours = (val).ToHours;
			val = letter.ExpectedArrivalTime;
			if (toHours >= (val).ToHours)
			{
				Hero val2 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((h != null) ? ((MBObjectBase)h).StringId : null) == letter.TargetNPCStringId));
				if (val2 != null && val2.IsAlive && !val2.IsPrisoner)
				{
					list.Add(letter);
					continue;
				}
				LogMessage("[NPC_MESSENGER] Letter to " + letter.TargetNPCStringId + " failed to deliver - NPC unavailable");
				list2.Add(letter);
			}
		}
		foreach (PendingPlayerLetter item in list)
		{
			DeliverPlayerLetter(item);
			list2.Add(item);
		}
		foreach (PendingPlayerLetter item2 in list2)
		{
			_pendingPlayerLetters.Remove(item2);
		}
	}

	private void DeliverPlayerLetter(PendingPlayerLetter letter)
	{
		Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((h != null) ? ((MBObjectBase)h).StringId : null) == letter.TargetNPCStringId));
		if (val == null || !val.IsAlive || val.IsPrisoner)
		{
			LogMessage("[NPC_MESSENGER] Cannot deliver letter - NPC " + letter.TargetNPCStringId + " is unavailable");
			return;
		}
		LogMessage($"[NPC_MESSENGER] Delivering player's letter to {val.Name}");
		GenerateNPCResponseToPlayerLetter(val, letter);
	}

	private async Task GenerateNPCResponseToPlayerLetter(Hero npc, PendingPlayerLetter letter)
	{
		try
		{
			if (npc == null || !npc.IsAlive || npc.IsPrisoner)
			{
				LogMessage("[NPC_MESSENGER] Cannot generate response - NPC is unavailable");
				return;
			}
			string npcName = ((object)npc.Name).ToString();
			NPCContext context = _behavior.GetOrCreateNPCContext(npc);
			RefreshContextData(npc, context);
			bool originalAllowsLetters = context.AllowsLettersFromNPC;
			context.AllowsLettersFromNPC = true;
			string prompt = GenerateLetterResponsePrompt(npc, context, letter.PlayerMessage);
			context.AllowsLettersFromNPC = originalAllowsLetters;
			LogMessage("[NPC_MESSENGER] Generating response from " + npcName + " to player's letter (AllowsLetters forced to true for prompt)");
			LogMessage("[NPC_MESSENGER_PROMPT] Full prompt for letter response:\n" + prompt);
			AIInfluenceBehavior.ClearNpcTurnDialogueTools(context);
			OpenRouterCallResult sendResult = await _behavior.SendAIRequest(prompt, "npc_letter_response", npc, context);
			string aiResponse = sendResult.Payload;
			if (!sendResult.Success || string.IsNullOrEmpty(aiResponse))
			{
				LogMessage("[ERROR] Failed to generate letter response from " + npcName);
				return;
			}
			AIResponse response = NpcOpenRouterAssistantParser.Parse(aiResponse, npcName);
			AIInfluenceBehavior.ApplyNpcContextToolDeferralsToAiResponse(context, response);
			AIInfluenceBehavior.ApplyNpcDialogueToolsToAiResponse(context, response);
			LogMessage("[NPC_MESSENGER_DEBUG] Parsed response from " + npcName + ":");
			LogMessage("  - response: " + (response?.Response?.Substring(0, Math.Min(100, (response?.Response?.Length).GetValueOrDefault())) ?? "null") + "...");
			LogMessage("  - technical_action: " + (response?.TechnicalAction ?? "null"));
			LogMessage("  - romance_intent: " + (response?.RomanceIntent ?? "null"));
			if (response == null || string.IsNullOrEmpty(response.Response) || response.Response.Equals("null", StringComparison.OrdinalIgnoreCase) || response.Response.Equals("no_response", StringComparison.OrdinalIgnoreCase))
			{
				LogMessage("[NPC_MESSENGER] " + npcName + " chose not to respond to player's letter");
				return;
			}
			string message = response.Response;
			message = UnescapeFormatting(message);
			CampaignTime now = CampaignTime.Now;
			double sentAtDays = (now).ToDays;
			context.ConversationHistory.Add($"{npcName}: {message} [SENT VIA MESSENGER AS REPLY] [sent_at_days={sentAtDays:F3}]");
			context.LastAIResponseJson = JsonConvert.SerializeObject(response);
			_behavior.ApplyPendingQuestActionFromTools(npc, context);
			if (!string.IsNullOrEmpty(response.CharacterPersonality) && string.IsNullOrEmpty(context.AIGeneratedPersonality))
			{
				context.AIGeneratedPersonality = response.CharacterPersonality.Trim();
				LogMessage("[NPC_MESSENGER] AI generated personality for " + npcName + ": " + context.AIGeneratedPersonality);
			}
			if (!string.IsNullOrEmpty(response.CharacterBackstory) && string.IsNullOrEmpty(context.AIGeneratedBackstory))
			{
				context.AIGeneratedBackstory = response.CharacterBackstory.Trim();
				LogMessage("[NPC_MESSENGER] AI generated backstory for " + npcName + ": " + context.AIGeneratedBackstory);
			}
			if (!string.IsNullOrEmpty(response.CharacterSpeechQuirks) && string.IsNullOrEmpty(context.AIGeneratedSpeechQuirks))
			{
				context.AIGeneratedSpeechQuirks = response.CharacterSpeechQuirks.Trim();
			}
			if (response.AllowsLettersFromNPC.HasValue && response.AllowsLettersFromNPC.Value != context.AllowsLettersFromNPC)
			{
				context.AllowsLettersFromNPC = response.AllowsLettersFromNPC.Value;
				LogMessage($"[NPC_MESSENGER] {npcName} changed AllowsLettersFromNPC to {context.AllowsLettersFromNPC} (reply)");
				Dictionary<string, object> letterStatusDict = new Dictionary<string, object> { { "NPC_NAME", npcName } };
				string statusTextId = (context.AllowsLettersFromNPC ? "AIInfluence_NPCWillSendLetters" : "AIInfluence_NPCWillNotSendLetters");
				string fallbackText = (context.AllowsLettersFromNPC ? "{NPC_NAME} will now send you letters." : "{NPC_NAME} will no longer send you letters.");
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=" + statusTextId + "}" + fallbackText, letterStatusDict)).ToString(), Colors.Gray));
			}
			LogMessage("[NPC_MESSENGER] " + npcName + " response: " + message);
			if (!string.IsNullOrEmpty(response.TechnicalAction) && response.TechnicalAction != "null")
			{
				LogMessage("[NPC_MESSENGER] NPC " + npcName + " requested action via letter: " + response.TechnicalAction);
				ProcessLetterTechnicalAction(npc, response.TechnicalAction);
			}
			if (!context.KnowledgeGenerated)
			{
				WorldInfoManager.WorldSecretsManager.Instance.CheckSecretKnowledge(npc, context);
				WorldInfoManager.InformationManager.Instance.CheckInfoKnowledge(npc, context);
				context.KnowledgeGenerated = true;
			}
			context.LastInteractionTime = CampaignTime.Now;
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			float deliveryHours = CalculateDeliveryTimeHours(letter.Distance);
			ScheduleNPCLetterDelivery(npc, message, deliveryHours);
			LogMessage($"[NPC_MESSENGER] Response from {npcName} scheduled for delivery in {deliveryHours:F1} hours");
		}
		catch (Exception ex)
		{
			Exception ex3 = ex;
			LogMessage("[ERROR] GenerateNPCResponseToPlayerLetter failed: " + ex3.Message + "\n" + ex3.StackTrace);
		}
	}

	private string GenerateLetterResponsePrompt(Hero npc, NPCContext context, string playerMessage)
	{
		string text = PromptGenerator.GeneratePrompt(npc, context, false, isMessengerMode: true);
		string text2 = ((object)Hero.MainHero.Name).ToString();
		string text3 = "\n\n=== SPECIAL SITUATION: YOU RECEIVED A LETTER ===\nYou have received a letter from " + text2 + " via messenger.\n\n**THE PLAYER'S LETTER:**\n\"" + playerMessage + "\"\n\n**YOUR OPTIONS:**\n1. **Reply** - Write a response letter. Set `response` to your reply message.\n2. **No Reply** - If you don't want to respond, set `response` to \"null\" or \"no_response\". NO letter will be sent back.\n\n**AVAILABLE ACTIONS:**\nUse `technical_action` ONLY if the player EXPLICITLY asks you to do one of these:\n- `go_to_settlement:<settlement_id>:<days>` - Travel to a settlement. Use exact settlement_id from the list above or from Nearby/Mentioned Settlements.\n- `wait_near_settlement:<settlement_id>:<days>` - Wait near a settlement. Use exact settlement_id.\n- `follow_player` - Come to the player and follow them.\nIf the player doesn't ask you to go somewhere or come to them, set `technical_action` to null.\n\n**CRITICAL INSTRUCTIONS:**\n- This is a WRITTEN MESSAGE. Do NOT use **asterisks** for actions.\n- Consider your relationship with the player and your character when deciding whether to reply.\n- Only perform actions if the player EXPLICITLY requests it in their letter.\n- If you don't want to reply (annoyed, busy, hostile), set response to \"null\".\n" + $"- Your response should be at least {GlobalSettings<ModSettings>.Instance.PromptMinResponseLength} characters (if you reply).\n" + $"- Do not exceed {GlobalSettings<ModSettings>.Instance.PromptMaxResponseLength} characters.\n";
		return text + text3;
	}

	private void ProcessLetterTechnicalAction(Hero npc, string technicalAction)
	{
		if (string.IsNullOrEmpty(technicalAction) || technicalAction == "null")
		{
			return;
		}
		string[] array = technicalAction.Split(new char[1] { ':' }, 2);
		string text = array[0].Trim().ToLowerInvariant();
		string text2 = ((array.Length > 1) ? array[1].Trim() : string.Empty);
		if (text != "go_to_settlement" && text != "wait_near_settlement" && text != "follow_player")
		{
			LogMessage("[NPC_MESSENGER] Action '" + text + "' is not allowed for letter responses - ignoring");
			return;
		}
		try
		{
			if (AIActionIntegration.Instance.TryPrepareActionParameter(npc, text, text2))
			{
				if (AIActionManager.Instance.StartAction(npc, text, forceRestart: true))
				{
					LogMessage($"[NPC_MESSENGER] Started action '{text}' for {npc.Name} from letter response");
				}
				else
				{
					LogMessage($"[NPC_MESSENGER] FAILED to start '{text}' for {npc.Name}");
				}
			}
			else
			{
				LogMessage("[NPC_MESSENGER] FAILED to prepare parameters for '" + text + "' with payload: " + text2);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] Failed to process letter action: " + ex.Message);
		}
	}

	private void ScheduleNPCLetterDelivery(Hero npc, string message, float deliveryHours)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime item = CampaignTime.HoursFromNow(deliveryHours);
		_pendingNPCResponses.Enqueue((npc, message, item));
		LogMessage($"[NPC_MESSENGER] Scheduled response from {npc.Name} for delivery at {(item).ToHours:F1} hours");
	}

	public void CheckPendingNPCResponses()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (_pendingNPCResponses.Count == 0)
		{
			return;
		}
		while (_pendingNPCResponses.Count > 0)
		{
			(Hero npc, string message, CampaignTime arrivalTime) tuple = _pendingNPCResponses.Peek();
			Hero item = tuple.npc;
			string item2 = tuple.message;
			CampaignTime item3 = tuple.arrivalTime;
			CampaignTime now = CampaignTime.Now;
			if ((now).ToHours >= (item3).ToHours)
			{
				_pendingNPCResponses.Dequeue();
				if (item == null || !item.IsAlive || item.IsPrisoner)
				{
					LogMessage("[NPC_MESSENGER] Cannot deliver NPC response - NPC is unavailable");
				}
				else
				{
					ShowNPCLetterResponse(item, item2);
				}
				continue;
			}
			break;
		}
	}

	private void ShowNPCLetterResponse(Hero npc, string message)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		string text = ((object)npc.Name).ToString();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("NPC_NAME", text);
		TextObject val = new TextObject("{=AIInfluence_MessengerTitle}Messenger from {NPC_NAME}", dictionary);
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2.Add("MESSAGE", message);
		TextObject val2 = new TextObject("{=AIInfluence_MessengerMessage}A messenger has arrived with a message:\n{MESSAGE}", dictionary2);
		string text2 = ((object)val2).ToString();
		text2 = UnescapeFormatting(text2);
		float num = CalculateDistanceToNPC(npc);
		int num2 = CalculateMessengerCost(num);
		bool canAffordMessenger = Hero.MainHero.Gold >= num2;
		LogMessage($"[NPC_MESSENGER_REPLY] Distance to {text}: {num:F1}, Reply cost: {num2} denars, Player gold: {Hero.MainHero.Gold}, Can afford: {canAffordMessenger}");
		NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(npc);
		orCreateNPCContext.LastInteractionTime = CampaignTime.Now;
		orCreateNPCContext.LastDynamicResponse = message;
		_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, orCreateNPCContext);
		Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
		dictionary3.Add("COST", num2);
		string text3 = ((object)new TextObject("{=AIInfluence_SendMessengerSimple}Send Messenger", dictionary3)).ToString();
		string messengerHintText;
		if (canAffordMessenger)
		{
			Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
			dictionary4.Add("COST", num2);
			messengerHintText = ((object)new TextObject("{=AIInfluence_MessengerHintEnough}The messenger will take {COST} denars for the journey.", dictionary4)).ToString();
		}
		else
		{
			Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
			dictionary5.Add("COST", num2);
			messengerHintText = ((object)new TextObject("{=AIInfluence_MessengerHintNotEnough}The journey costs {COST} denars, but you don't have enough gold.", dictionary5)).ToString();
		}
		PlayerMessengerRequest messengerRequest = new PlayerMessengerRequest
		{
			TargetNPC = npc,
			Context = orCreateNPCContext,
			Cost = num2,
			Distance = num
		};
		string text4 = $"letter_reply_{text}_{DateTime.Now.Ticks}";
		string text5 = UnescapeFormatting(((object)val).ToString());
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableResponseReadySound)
		{
			try
			{
				SoundEvent.PlaySound2D("event:/ui/notification/alert");
			}
			catch
			{
			}
		}
		InformationManager.ShowInquiry(new InquiryData(text5, text2, canAffordMessenger, true, text3, ((object)new TextObject("{=AIInfluence_MessengerAcknowledge}Acknowledge", (Dictionary<string, object>)null)).ToString(), (Action)delegate
		{
			OnSendMessengerToNPC(messengerRequest);
		}, (Action)delegate
		{
		}, text4, 0f, (Action)null, (Func<ValueTuple<bool, string>>)(() => (canAffordMessenger, messengerHintText)), (Func<ValueTuple<bool, string>>)(() => (true, ""))), true, false);
		LogMessage("[NPC_MESSENGER] Showed letter response from " + text + " to player: " + message);
	}

	private bool IsNPCInPlayerParty(Hero npc)
	{
		if (npc == null || MobileParty.MainParty == null)
		{
			return false;
		}
		return MobileParty.MainParty.MemberRoster.Contains(npc.CharacterObject);
	}

	private bool CanSendMessenger(Hero npc)
	{
		if (npc == null)
		{
			LogMessage("[NPC_INITIATIVE] Cannot send messenger: NPC is null");
			return false;
		}
		if (!npc.IsAlive)
		{
			LogMessage($"[NPC_INITIATIVE] {npc.Name} cannot send messenger: is dead");
			return false;
		}
		if (npc.IsPrisoner)
		{
			LogMessage($"[NPC_INITIATIVE] {npc.Name} cannot send messenger: is a prisoner");
			return false;
		}
		return true;
	}

	private void RefreshContextData(Hero npc, NPCContext context)
	{
		if (npc != null && context != null)
		{
			_behavior.UpdateContextData(context, npc);
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		}
	}

	public int GetPendingRequestsCount()
	{
		return _pendingRequests.Count;
	}

	public void ClearPendingRequests()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		_pendingRequests.Clear();
		_readyToOpenRequest = null;
		_npcContactedToday.Clear();
		_requestsShownToday = 0;
		_lastRequestShown = CampaignTime.Never;
		_lastResetDay = CampaignTime.Never;
		_lastInitiativeCheckDay = CampaignTime.Never;
		_isProcessingRequest = false;
		LogMessage("[NPC_INITIATIVE] All pending requests and counters cleared");
	}

	public Queue<NPCInitiativeRequest> GetPendingRequests()
	{
		return _pendingRequests;
	}

	public void OnHourlyTick()
	{
		if (Campaign.Current != null && Hero.MainHero != null && GlobalSettings<ModSettings>.Instance.EnableModification && GlobalSettings<ModSettings>.Instance.EnableNPCInitiative && GlobalSettings<ModSettings>.Instance.EnableNPCMapInitiative && !Hero.MainHero.IsPrisoner)
		{
			_mapCheckHourlyCounter++;
			if (_mapCheckHourlyCounter >= 5)
			{
				_mapCheckHourlyCounter = 0;
				PerformMapCheck();
			}
		}
	}

	private void PerformMapCheck()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		if (MobileParty.MainParty == null || (Hero.MainHero != null && Hero.MainHero.IsPrisoner) || IsAnyInitiativeActive())
		{
			return;
		}
		ExplainedNumber partySpottingRange = Campaign.Current.Models.MapVisibilityModel.GetPartySpottingRange(MobileParty.MainParty, false);
		float resultNumber = (partySpottingRange).ResultNumber;
		List<(MobileParty, Hero, bool)> list = new List<(MobileParty, Hero, bool)>();
		foreach (MobileParty item in (List<MobileParty>)(object)MobileParty.All)
		{
			if (!item.IsLordParty || item.LeaderHero == null || item == MobileParty.MainParty || !item.LeaderHero.IsAlive || item.LeaderHero.IsPrisoner || !item.IsVisible)
			{
				continue;
			}
			Vec2 position2D = item.GetPosition2D();
			if (!((position2D).DistanceSquared(MobileParty.MainParty.GetPosition2D()) <= resultNumber * resultNumber) || _approachingParties.ContainsKey(((MBObjectBase)item).StringId) || item.MapEvent != null || item.SiegeEvent != null)
			{
				continue;
			}
			Hero leaderHero = item.LeaderHero;
			if (AIActionManager.Instance != null)
			{
				List<string> activeActions = AIActionManager.Instance.GetActiveActions(leaderHero);
				if (activeActions.Contains("attack_party") || activeActions.Contains("raid_village") || activeActions.Contains("return_to_player") || activeActions.Contains("go_to_settlement") || activeActions.Contains("siege_settlement") || activeActions.Contains("patrol_settlement") || activeActions.Contains("follow_player"))
				{
					continue;
				}
			}
			bool flag = item.MapFaction.IsAtWarWith(Hero.MainHero.MapFaction);
			if (!flag)
			{
				int relation = Hero.MainHero.GetRelation(leaderHero);
				float nPCInitiativeMapBaseChance = GlobalSettings<ModSettings>.Instance.NPCInitiativeMapBaseChance;
				if (_random.NextDouble() * 100.0 < (double)nPCInitiativeMapBaseChance)
				{
					list.Add((item, leaderHero, flag));
				}
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		if (IsMapInitiativeActive())
		{
			LogMessage("[NPC_MAP_INITIATIVE] Race condition detected - aborting selection because someone is already approaching");
			return;
		}
		(MobileParty, Hero, bool) tuple = list[_random.Next(list.Count)];
		LogMessage($"[NPC_MAP_INITIATIVE] Selected {tuple.Item2.Name} from {list.Count} candidates to approach player! (Hostile: {tuple.Item3})");
		int hashCode = ((MBObjectBase)tuple.Item1).StringId.GetHashCode();
		float num = (float)Math.Abs(hashCode % 1000) / 1000f;
		float num2 = ((!tuple.Item3) ? (2f + num * 3f) : (4f + num * 4f));
		_approachingParties[((MBObjectBase)tuple.Item1).StringId] = new NPCMapApproachIntent
		{
			IsHostile = tuple.Item3,
			DetectTime = CampaignTime.Now,
			DialogShown = false,
			TimeoutDays = num2
		};
		LogMessage($"[NPC_MAP_INITIATIVE] Timeout set for {tuple.Item2.Name}: {num2:F1} days");
		bool flag2 = tuple.Item1.TargetParty == MobileParty.MainParty;
		if (tuple.Item3 || flag2)
		{
			LogMessage($"[NPC_MAP_INITIATIVE] {tuple.Item2.Name} is hostile/at war or already targeting player - waiting for vanilla engagement");
		}
		else
		{
			GameVersionCompatibility.SetMoveEscortParty(tuple.Item1, MobileParty.MainParty);
		}
	}

	public async Task GenerateHostileInitiativeResponse(Hero npc)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		try
		{
			if (npc == null)
			{
				return;
			}
			if (npc.IsPrisoner)
			{
				LogMessage($"[NPC_HOSTILE_INITIATIVE] Cannot generate response - NPC {npc.Name} is prisoner");
				MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", "I have nothing to say to you.", false);
				return;
			}
			NPCContext context = _behavior.GetOrCreateNPCContext(npc);
			if (!string.IsNullOrEmpty(context.AIGeneratedBackstory) || !string.IsNullOrEmpty(context.AIGeneratedPersonality))
			{
				CharacterInfo.UpdateEncyclopediaDescription(npc, context.AIGeneratedBackstory, context.AIGeneratedPersonality);
			}
			TextObject approachText = new TextObject("{=AIInfluence_NPCApproachingHostile}{NPC_NAME} looks at you with hostility...", new Dictionary<string, object> { 
			{
				"NPC_NAME",
				((object)npc.Name).ToString()
			} });
			InformationManager.DisplayMessage(new InformationMessage(((object)approachText).ToString(), ExtraColors.RedAIInfluence));
			RefreshContextData(npc, context);
			string prompt = GenerateHostileInitiativePrompt(npc, context);
			LogMessage($"[NPC_HOSTILE_PROMPT] Full prompt for {npc.Name}:\n{prompt}");
			AIInfluenceBehavior.ClearNpcTurnDialogueTools(context);
			OpenRouterCallResult sendResult = await _behavior.SendAIRequest(prompt, "npc_hostile_initiative", npc, context);
			string aiResponse = sendResult.Payload;
			if (!sendResult.Success || string.IsNullOrEmpty(aiResponse))
			{
				MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", "Get out of my sight!", false);
				return;
			}
			string npcNameStr = ((object)npc.Name)?.ToString() ?? "NPC";
			AIResponse response = NpcOpenRouterAssistantParser.Parse(aiResponse, npcNameStr);
			AIInfluenceBehavior.ApplyNpcContextToolDeferralsToAiResponse(context, response);
			AIInfluenceBehavior.ApplyNpcDialogueToolsToAiResponse(context, response);
			string message = response?.Response ?? "...";
			message = UnescapeFormatting(message);
			context.LastAIResponseJson = JsonConvert.SerializeObject(response);
			context.ConversationHistory.Add($"{npc.Name}: {message}");
			_behavior.ApplyPendingQuestActionFromTools(npc, context);
			if (!string.IsNullOrEmpty(response.CharacterPersonality) && string.IsNullOrEmpty(context.AIGeneratedPersonality))
			{
				LogMessage(string.Format(arg1: context.AIGeneratedPersonality = response.CharacterPersonality.Trim(), format: "[NPC_HOSTILE_INITIATIVE] [CHARACTER_PERSONALITY] AI generated personality for {0}: {1}", arg0: npc.Name));
			}
			if (!string.IsNullOrEmpty(response.CharacterBackstory) && string.IsNullOrEmpty(context.AIGeneratedBackstory))
			{
				LogMessage(string.Format(arg1: context.AIGeneratedBackstory = response.CharacterBackstory.Trim(), format: "[NPC_HOSTILE_INITIATIVE] [CHARACTER_BACKSTORY] AI generated backstory for {0}: {1}", arg0: npc.Name));
			}
			if (!string.IsNullOrEmpty(response.CharacterSpeechQuirks) && string.IsNullOrEmpty(context.AIGeneratedSpeechQuirks))
			{
				LogMessage(string.Format(arg1: context.AIGeneratedSpeechQuirks = response.CharacterSpeechQuirks.Trim(), format: "[NPC_HOSTILE_INITIATIVE] [CHARACTER_SPEECH_QUIRKS] AI generated speech quirks for {0}: {1}", arg0: npc.Name));
			}
			if (!string.IsNullOrEmpty(context.AIGeneratedBackstory) || !string.IsNullOrEmpty(context.AIGeneratedPersonality))
			{
				CharacterInfo.UpdateEncyclopediaDescription(npc, context.AIGeneratedBackstory, context.AIGeneratedPersonality);
			}
			if (!context.KnowledgeGenerated)
			{
				WorldInfoManager.WorldSecretsManager.Instance.CheckSecretKnowledge(npc, context);
				WorldInfoManager.InformationManager.Instance.CheckInfoKnowledge(npc, context);
				context.KnowledgeGenerated = true;
			}
			MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", message, false);
			context.LastDynamicResponse = message;
			context.PendingAIResponse = response;
			if (response.Decision == "attack")
			{
				context.CombatResponse = "attack: " + message;
				LogMessage("[NPC_HOSTILE_INITIATIVE] Saved combat response: " + context.CombatResponse);
			}
			else if (response.Decision == "release")
			{
				context.CombatResponse = "release: " + message;
				LogMessage($"[NPC_HOSTILE_INITIATIVE] NPC {npc.Name} decides to release player. Saved as combat response: {context.CombatResponse}");
			}
			else if (response.Decision == "accept_surrender")
			{
				context.CombatResponse = "accept_surrender: " + message;
				context.IsSurrendering = false;
				LogMessage($"[NPC_HOSTILE_INITIATIVE] NPC {npc.Name} accepts player surrender. CombatResponse: {context.CombatResponse}");
			}
			else if (response.Decision == "surrender")
			{
				context.CombatResponse = null;
				context.IsSurrendering = true;
				LogMessage($"[NPC_HOSTILE_INITIATIVE] NPC {npc.Name} surrenders. Clearing CombatResponse.");
			}
			if (response?.Tone == "positive")
			{
				int relationChange = _random.Next(GlobalSettings<ModSettings>.Instance.MinPositiveRelationChange, GlobalSettings<ModSettings>.Instance.MaxPositiveRelationChange + 1);
				string relMsg = ((object)new TextObject("{=AIInfluence_RelationImproved}Your relations with {npcName} have improved due to your friendly tone.", new Dictionary<string, object> { { "npcName", npcNameStr } })).ToString();
				context.PendingRelationChange = new PendingRelationChange
				{
					RelationChange = relationChange,
					Message = relMsg,
					Color = ExtraColors.GreenAIInfluence
				};
				LogMessage($"[NPC_HOSTILE_INITIATIVE] Positive tone — scheduled relation +{relationChange} for {npc.Name}");
			}
			else if (response?.Tone == "negative")
			{
				int relationChange2 = _random.Next(GlobalSettings<ModSettings>.Instance.MinNegativeRelationChange, GlobalSettings<ModSettings>.Instance.MaxNegativeRelationChange + 1);
				string relMsg2 = ((object)new TextObject("{=AIInfluence_RelationWorsened}Your relations with {npcName} have worsened due to your aggressive tone.", new Dictionary<string, object> { { "npcName", npcNameStr } })).ToString();
				context.PendingRelationChange = new PendingRelationChange
				{
					RelationChange = -relationChange2,
					Message = relMsg2,
					Color = ExtraColors.RedAIInfluence
				};
				LogMessage($"[NPC_HOSTILE_INITIATIVE] Negative tone — scheduled relation -{relationChange2} for {npc.Name}");
			}
			else
			{
				LogMessage($"[NPC_HOSTILE_INITIATIVE] Neutral/null tone — no relation change for {npc.Name}");
			}
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			TextObject readyText = new TextObject("{=AIInfluence_NPCReady}{npcName} is ready to respond.", new Dictionary<string, object> { 
			{
				"npcName",
				((object)npc.Name).ToString()
			} });
			InformationManager.DisplayMessage(new InformationMessage(((object)readyText).ToString(), Color.White));
			if (GlobalSettings<ModSettings>.Instance?.EnableResponseReadySound ?? false)
			{
				try
				{
					SoundEvent.PlaySound2D("event:/ui/notification/alert");
				}
				catch
				{
				}
			}
		}
		catch (Exception ex2)
		{
			LogMessage("[ERROR] GenerateHostileInitiativeResponse failed: " + ex2.Message);
		}
	}

	private string GenerateHostileInitiativePrompt(Hero npc, NPCContext context)
	{
		string text = PromptGenerator.GeneratePrompt(npc, context);
		string text2 = "\n\n=== SPECIAL SITUATION: YOU INTERCEPTED THE PLAYER (HOSTILE) ===\nYou are hostile to the player. You have successfully intercepted/caught them on the map.\nYou are stronger than them and have the advantage.\nYou initiated this conversation to threaten, demand something, or attack.\n\n**CRITICAL INSTRUCTIONS:**\n- Be aggressive and dominant.\n- State your demands or intent clearly.\n- Do NOT be polite.\n" + $"- Your message should be at least {GlobalSettings<ModSettings>.Instance.PromptMinResponseLength} characters and not exceed {GlobalSettings<ModSettings>.Instance.PromptMaxResponseLength} characters\n";
		return text + text2;
	}

	public async Task GenerateNeutralInitiativeResponse(Hero npc)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		try
		{
			if (npc == null)
			{
				return;
			}
			if (npc.IsPrisoner)
			{
				LogMessage($"[NPC_NEUTRAL_INITIATIVE] Cannot generate response - NPC {npc.Name} is prisoner");
				MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", "I have nothing to say to you.", false);
				return;
			}
			NPCContext context = _behavior.GetOrCreateNPCContext(npc);
			if (!string.IsNullOrEmpty(context.AIGeneratedBackstory) || !string.IsNullOrEmpty(context.AIGeneratedPersonality))
			{
				CharacterInfo.UpdateEncyclopediaDescription(npc, context.AIGeneratedBackstory, context.AIGeneratedPersonality);
			}
			TextObject approachText = new TextObject("{=AIInfluence_NPCApproachingNeutral}{NPC_NAME} approaches you...", new Dictionary<string, object> { 
			{
				"NPC_NAME",
				((object)npc.Name).ToString()
			} });
			InformationManager.DisplayMessage(new InformationMessage(((object)approachText).ToString(), Colors.Gray));
			RefreshContextData(npc, context);
			string prompt = GeneratePartyInitiativePrompt(npc, context);
			LogMessage($"[NPC_NEUTRAL_PROMPT] Full prompt for {npc.Name}:\n{prompt}");
			AIInfluenceBehavior.ClearNpcTurnDialogueTools(context);
			OpenRouterCallResult sendResult = await _behavior.SendAIRequest(prompt, "npc_neutral_initiative", npc, context);
			string aiResponse = sendResult.Payload;
			if (!sendResult.Success || string.IsNullOrEmpty(aiResponse))
			{
				MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", "I wanted to talk, but I'm not sure what to say...", false);
				return;
			}
			string npcNameStr = ((object)npc.Name)?.ToString() ?? "NPC";
			AIResponse response = NpcOpenRouterAssistantParser.Parse(aiResponse, npcNameStr);
			AIInfluenceBehavior.ApplyNpcContextToolDeferralsToAiResponse(context, response);
			AIInfluenceBehavior.ApplyNpcDialogueToolsToAiResponse(context, response);
			string message = response?.Response ?? "...";
			message = UnescapeFormatting(message);
			context.LastAIResponseJson = JsonConvert.SerializeObject(response);
			context.ConversationHistory.Add($"{npc.Name}: {message}");
			_behavior.ApplyPendingQuestActionFromTools(npc, context);
			if (!string.IsNullOrEmpty(response.CharacterPersonality) && string.IsNullOrEmpty(context.AIGeneratedPersonality))
			{
				LogMessage(string.Format(arg1: context.AIGeneratedPersonality = response.CharacterPersonality.Trim(), format: "[NPC_INITIATIVE] [CHARACTER_PERSONALITY] AI generated personality for {0}: {1}", arg0: npc.Name));
			}
			if (!string.IsNullOrEmpty(response.CharacterBackstory) && string.IsNullOrEmpty(context.AIGeneratedBackstory))
			{
				LogMessage(string.Format(arg1: context.AIGeneratedBackstory = response.CharacterBackstory.Trim(), format: "[NPC_INITIATIVE] [CHARACTER_BACKSTORY] AI generated backstory for {0}: {1}", arg0: npc.Name));
			}
			if (!string.IsNullOrEmpty(response.CharacterSpeechQuirks) && string.IsNullOrEmpty(context.AIGeneratedSpeechQuirks))
			{
				LogMessage(string.Format(arg1: context.AIGeneratedSpeechQuirks = response.CharacterSpeechQuirks.Trim(), format: "[NPC_INITIATIVE] [CHARACTER_SPEECH_QUIRKS] AI generated speech quirks for {0}: {1}", arg0: npc.Name));
			}
			if (!string.IsNullOrEmpty(context.AIGeneratedBackstory) || !string.IsNullOrEmpty(context.AIGeneratedPersonality))
			{
				CharacterInfo.UpdateEncyclopediaDescription(npc, context.AIGeneratedBackstory, context.AIGeneratedPersonality);
			}
			if (!context.KnowledgeGenerated)
			{
				WorldInfoManager.WorldSecretsManager.Instance.CheckSecretKnowledge(npc, context);
				WorldInfoManager.InformationManager.Instance.CheckInfoKnowledge(npc, context);
				context.KnowledgeGenerated = true;
			}
			MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", message, false);
			context.LastDynamicResponse = message;
			context.PendingAIResponse = response;
			if (response?.Tone == "positive")
			{
				int relationChange = _random.Next(GlobalSettings<ModSettings>.Instance.MinPositiveRelationChange, GlobalSettings<ModSettings>.Instance.MaxPositiveRelationChange + 1);
				string relMsg = ((object)new TextObject("{=AIInfluence_RelationImproved}Your relations with {npcName} have improved due to your friendly tone.", new Dictionary<string, object> { { "npcName", npcNameStr } })).ToString();
				context.PendingRelationChange = new PendingRelationChange
				{
					RelationChange = relationChange,
					Message = relMsg,
					Color = ExtraColors.GreenAIInfluence
				};
				LogMessage($"[NPC_NEUTRAL_INITIATIVE] Positive tone — scheduled relation +{relationChange} for {npc.Name}");
			}
			else if (response?.Tone == "negative")
			{
				int relationChange2 = _random.Next(GlobalSettings<ModSettings>.Instance.MinNegativeRelationChange, GlobalSettings<ModSettings>.Instance.MaxNegativeRelationChange + 1);
				string relMsg2 = ((object)new TextObject("{=AIInfluence_RelationWorsened}Your relations with {npcName} have worsened due to your aggressive tone.", new Dictionary<string, object> { { "npcName", npcNameStr } })).ToString();
				context.PendingRelationChange = new PendingRelationChange
				{
					RelationChange = -relationChange2,
					Message = relMsg2,
					Color = ExtraColors.RedAIInfluence
				};
				LogMessage($"[NPC_NEUTRAL_INITIATIVE] Negative tone — scheduled relation -{relationChange2} for {npc.Name}");
			}
			else
			{
				LogMessage($"[NPC_NEUTRAL_INITIATIVE] Neutral/null tone — no relation change for {npc.Name}");
			}
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			TextObject readyText = new TextObject("{=AIInfluence_NPCReady}{npcName} is ready to respond.", new Dictionary<string, object> { 
			{
				"npcName",
				((object)npc.Name).ToString()
			} });
			InformationManager.DisplayMessage(new InformationMessage(((object)readyText).ToString(), Color.White));
			if (GlobalSettings<ModSettings>.Instance?.EnableResponseReadySound ?? false)
			{
				try
				{
					SoundEvent.PlaySound2D("event:/ui/notification/alert");
				}
				catch
				{
				}
			}
		}
		catch (Exception ex2)
		{
			LogMessage("[ERROR] GenerateNeutralInitiativeResponse failed: " + ex2.Message);
		}
	}

	public void OnConversationStarted(IEnumerable<CharacterObject> characters)
	{
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		if (characters == null)
		{
			return;
		}
		foreach (CharacterObject character in characters)
		{
			if (character.HeroObject == null)
			{
				continue;
			}
			Hero heroObject = character.HeroObject;
			MobileParty partyBelongedTo = heroObject.PartyBelongedTo;
			string text = ((partyBelongedTo != null) ? ((MBObjectBase)partyBelongedTo).StringId : null);
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			bool flag = heroObject.MapFaction.IsAtWarWith(Hero.MainHero.MapFaction);
			if (_approachingParties.TryGetValue(text, out var value))
			{
				if (!heroObject.IsPrisoner)
				{
					LogMessage($"[NPC_MAP_INITIATIVE] Conversation started with approaching party {heroObject.Name}. Hostile: {value.IsHostile}");
					ProcessConversationStart(heroObject, value.IsHostile);
					_approachingParties.Remove(text);
					break;
				}
				LogMessage($"[NPC_MAP_INITIATIVE] Cannot process initiative - NPC {heroObject.Name} is prisoner");
				_approachingParties.Remove(text);
			}
			else
			{
				if (!flag || !GlobalSettings<ModSettings>.Instance.EnableHostileInitiative)
				{
					continue;
				}
				MobileParty partyBelongedTo2 = heroObject.PartyBelongedTo;
				if (partyBelongedTo2 == null)
				{
					LogMessage($"[NPC_MAP_INITIATIVE] Cannot process hostile initiative - NPC {heroObject.Name} has no valid party");
					continue;
				}
				if (partyBelongedTo2.IsFleeing())
				{
					LogMessage($"[NPC_MAP_INITIATIVE] Hostile {heroObject.Name} is fleeing from player - skipping initiative dialog");
					continue;
				}
				float num = partyBelongedTo2.Party.CalculateCurrentStrength();
				float num2 = MobileParty.MainParty.Party.CalculateCurrentStrength();
				if (num <= num2)
				{
					LogMessage($"[NPC_MAP_INITIATIVE] Hostile {heroObject.Name} is weaker or equal to player (NPC: {num:F0}, Player: {num2:F0}) - skipping initiative dialog");
					continue;
				}
				float num3;
				if (_lastHostileInitiativeTime == CampaignTime.Never)
				{
					num3 = float.MaxValue;
				}
				else
				{
					CampaignTime now = CampaignTime.Now;
					num3 = (float)((now).ToDays - (_lastHostileInitiativeTime).ToDays);
				}
				if (num3 >= (float)GlobalSettings<ModSettings>.Instance.HostileInitiativeCooldown)
				{
					LogMessage($"[NPC_MAP_INITIATIVE] HOSTILE INTERCEPTION! {heroObject.Name} caught player. (Cooldown passed: {num3:F1} >= {GlobalSettings<ModSettings>.Instance.HostileInitiativeCooldown}, NPC stronger: {num:F0} > {num2:F0})");
					ProcessConversationStart(heroObject, isHostile: true);
					_lastHostileInitiativeTime = CampaignTime.Now;
					break;
				}
				LogMessage($"[NPC_MAP_INITIATIVE] Hostile {heroObject.Name} caught player, but cooldown active ({num3:F1} < {GlobalSettings<ModSettings>.Instance.HostileInitiativeCooldown}). Using vanilla logic.");
			}
		}
	}

	private void ProcessConversationStart(Hero npc, bool isHostile)
	{
		if (!npc.HasMet)
		{
			npc.SetHasMet();
			LogMessage($"[NPC_MAP_INITIATIVE] Made {npc.Name} known to player (SetHasMet) before dialog starts");
		}
		NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(npc);
		orCreateNPCContext.IsNPCInitiatedConversation = true;
		orCreateNPCContext.IsHostileInitiative = isHostile;
		_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, orCreateNPCContext);
	}
}
