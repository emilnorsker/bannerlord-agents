using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.AgentOrigins;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public class AIActionManager
{
	private class PartyReturnInfo
	{
		public MobileParty Party { get; }

		public Settlement Destination { get; }

		public PartyReturnInfo(MobileParty party, Settlement destination)
		{
			Party = party;
			Destination = destination;
		}
	}

	[Serializable]
	public class AIActionSaveData
	{
		public string HeroId { get; set; }

		public string ActionName { get; set; }

		public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
	}

	private static AIActionManager _instance;

	private Dictionary<Hero, List<AIActionBase>> _activeActions;

	private Dictionary<string, Type> _registeredActionTypes;

	private Dictionary<Hero, PartyReturnInfo> _partiesTravelingToRemoval;

	private HashSet<Hero> _heroesInPartyOnSettlementEntry;

	private HashSet<Hero> _heroesWithFollowActionHistory;

	private static readonly HashSet<string> _nonPersistentActions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "create_party", "create_rp_weapon" };

	private float _settlementEntryCheckTimer = 0f;

	private const float SETTLEMENT_ENTRY_CHECK_INTERVAL = 0.5f;

	private bool _eventsRegistered = false;

	public static AIActionManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new AIActionManager();
			}
			return _instance;
		}
	}

	public static void ResetInstance()
	{
		if (_instance != null)
		{
			_instance.LogMessage("Resetting AIActionManager instance for new game/save load");
			_instance._eventsRegistered = false;
			_instance = null;
		}
	}

	private AIActionManager()
	{
		_activeActions = new Dictionary<Hero, List<AIActionBase>>();
		_registeredActionTypes = new Dictionary<string, Type>();
		_partiesTravelingToRemoval = new Dictionary<Hero, PartyReturnInfo>();
		_heroesInPartyOnSettlementEntry = new HashSet<Hero>();
		_heroesWithFollowActionHistory = new HashSet<Hero>();
		RegisterDefaultActions();
	}

	public void InitializeEvents()
	{
		if (!_eventsRegistered)
		{
			RegisterEvents();
			_eventsRegistered = true;
		}
	}

	private void RegisterEvents()
	{
		try
		{
			CampaignEvents.SettlementEntered.AddNonSerializedListener((object)this, (Action<MobileParty, Settlement, Hero>)OnSettlementEntered);
			CampaignEvents.OnSettlementLeftEvent.AddNonSerializedListener((object)this, (Action<MobileParty, Settlement>)OnSettlementLeft);
			CampaignEvents.OnHeroJoinedPartyEvent.AddNonSerializedListener((object)this, (Action<Hero, MobileParty>)OnHeroJoinedParty);
			CampaignEvents.MapEventStarted.AddNonSerializedListener((object)this, (Action<MapEvent, PartyBase, PartyBase>)OnMapEventStarted);
			CampaignEvents.MapEventEnded.AddNonSerializedListener((object)this, (Action<MapEvent>)OnMapEventEnded);
			CampaignEvents.OnMissionStartedEvent.AddNonSerializedListener((object)this, (Action<IMission>)OnMissionStarted);
			CampaignEvents.HeroKilledEvent.AddNonSerializedListener((object)this, (Action<Hero, Hero, KillCharacterActionDetail, bool>)OnHeroKilled);
			CampaignEvents.HeroPrisonerTaken.AddNonSerializedListener((object)this, (Action<PartyBase, Hero>)OnHeroPrisonerTaken);
			LogMessage("AIActionManager events registered");
		}
		catch (Exception ex)
		{
			LogMessage("ERROR registering events: " + ex.Message);
		}
	}

	private void RegisterDefaultActions()
	{
		RegisterAction<FollowPlayerAction>();
		RegisterAction<GoToSettlementAction>();
		RegisterAction<ReturnToPlayerAction>();
		RegisterAction<CreatePartyAction>();
		RegisterAction<AttackPartyAction>();
		RegisterAction<SiegeSettlementAction>();
		RegisterAction<PatrolSettlementAction>();
		RegisterAction<WaitNearSettlementAction>();
		RegisterAction<RaidVillageAction>();
		RegisterAction<CreateRPItemAction>();
		RegisterAction<CreateRPWeaponAction>();
		RegisterAction<TransferTroopsAndPrisonersAction>();
	}

	internal string SerializeActiveActions()
	{
		try
		{
			List<AIActionSaveData> list = CaptureActiveActionsForSave();
			if (list == null || list.Count == 0)
			{
				return string.Empty;
			}
			return JsonConvert.SerializeObject((object)list);
		}
		catch (Exception ex)
		{
			LogMessage("ERROR serializing AI action state: " + ex.Message);
			return string.Empty;
		}
	}

	internal void RestoreActionsFromSerialized(string serializedState)
	{
		if (string.IsNullOrWhiteSpace(serializedState))
		{
			LogMessage("[RESTORE] No serialized AI action state provided.");
			return;
		}
		try
		{
			List<AIActionSaveData> savedActions = JsonConvert.DeserializeObject<List<AIActionSaveData>>(serializedState);
			RestoreActionsFromSave(savedActions);
		}
		catch (Exception ex)
		{
			LogMessage("ERROR restoring AI action state: " + ex.Message);
		}
	}

	public void RegisterAction<T>() where T : AIActionBase, new()
	{
		T val = new T();
		string actionName = val.ActionName;
		if (_registeredActionTypes.ContainsKey(actionName))
		{
			LogMessage("WARNING: Action '" + actionName + "' already registered, overwriting");
		}
		_registeredActionTypes[actionName] = typeof(T);
	}

	public bool StartAction(Hero hero, string actionName, bool forceRestart = false)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return false;
		}
		if (hero == null)
		{
			LogMessage("ERROR: Cannot start action - hero not specified");
			return false;
		}
		if (!_registeredActionTypes.ContainsKey(actionName))
		{
			LogMessage("ERROR: Action '" + actionName + "' not registered");
			return false;
		}
		if (hero.IsPrisoner)
		{
			LogMessage($"[AI_ACTION] Cannot start action '{actionName}' for prisoner {hero.Name} - prisoners cannot execute actions requiring freedom of movement.");
			return false;
		}
		if (hero.PartyBelongedTo != null && hero.PartyBelongedTo.Army != null)
		{
			Army army = hero.PartyBelongedTo.Army;
			bool flag = army.LeaderParty == hero.PartyBelongedTo;
			if (!flag && hero.PartyBelongedTo.AttachedTo != null)
			{
				MobileParty leaderParty = army.LeaderParty;
				object obj;
				if (leaderParty == null)
				{
					obj = null;
				}
				else
				{
					Hero leaderHero = leaderParty.LeaderHero;
					obj = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString());
				}
				if (obj == null)
				{
					obj = "unknown";
				}
				string arg = (string)obj;
				LogMessage($"[ARMY_DETACH] {hero.Name} is in army (leader: {arg}). Detaching to allow player task execution.");
				hero.PartyBelongedTo.AttachedTo = null;
			}
			else if (flag)
			{
				LogMessage($"[ARMY_DETACH] {hero.Name} is army leader. Not detaching - will go with army.");
			}
		}
		StopAllActiveActionsExcept(hero, actionName);
		try
		{
			Type type = _registeredActionTypes[actionName];
			AIActionBase aIActionBase = (AIActionBase)Activator.CreateInstance(type);
			aIActionBase.Initialize(hero);
			if (!aIActionBase.CanExecute())
			{
				LogMessage($"Action '{actionName}' cannot be executed for {hero.Name} in current conditions");
				return false;
			}
			aIActionBase.Start();
			if (!_activeActions.ContainsKey(hero))
			{
				_activeActions[hero] = new List<AIActionBase>();
			}
			_activeActions[hero].Add(aIActionBase);
			if (actionName == "follow_player")
			{
				_heroesWithFollowActionHistory.Add(hero);
				LogMessage($"Added {hero.Name} to follow action history");
			}
			return true;
		}
		catch (Exception ex)
		{
			LogMessage("ERROR starting action '" + actionName + "': " + ex.Message + "\n" + ex.StackTrace);
			return false;
		}
	}

	public bool StopAction(Hero hero, string actionName, bool showMessage = false, bool cancelTask = true)
	{
		if (hero == null || !_activeActions.ContainsKey(hero))
		{
			return false;
		}
		AIActionBase aIActionBase = _activeActions[hero].FirstOrDefault((AIActionBase a) => a.ActionName == actionName);
		if (aIActionBase != null)
		{
			if (showMessage && aIActionBase is FollowPlayerAction followPlayerAction)
			{
				followPlayerAction.StopWithMessage();
			}
			else
			{
				aIActionBase.Stop();
			}
			_activeActions[hero].Remove(aIActionBase);
			if (_activeActions[hero].Count == 0)
			{
				_activeActions.Remove(hero);
			}
			if (cancelTask)
			{
				try
				{
					TaskManager.Instance?.CancelTask(hero);
				}
				catch (Exception ex)
				{
					LogMessage($"ERROR cancelling task for {((hero != null) ? hero.Name : null)}: {ex.Message}");
				}
			}
			return true;
		}
		return false;
	}

	private void StopAllActiveActionsExcept(Hero hero, string exceptActionName)
	{
		if (hero == null || !_activeActions.ContainsKey(hero))
		{
			return;
		}
		List<AIActionBase> list = new List<AIActionBase>(_activeActions[hero]);
		foreach (AIActionBase item in list)
		{
			if (!string.Equals(item.ActionName, exceptActionName, StringComparison.OrdinalIgnoreCase))
			{
				item.Stop();
				_activeActions[hero].Remove(item);
			}
		}
		if (_activeActions[hero].Count == 0)
		{
			_activeActions.Remove(hero);
		}
	}

	public void StopAllActions(Hero hero)
	{
		if (hero == null || !_activeActions.ContainsKey(hero))
		{
			return;
		}
		List<AIActionBase> list = new List<AIActionBase>(_activeActions[hero]);
		foreach (AIActionBase item in list)
		{
			item.Stop();
		}
		_activeActions.Remove(hero);
		try
		{
			TaskManager.Instance?.CancelTask(hero);
		}
		catch (Exception ex)
		{
			LogMessage($"ERROR cancelling task for {((hero != null) ? hero.Name : null)}: {ex.Message}");
		}
	}

	public void StopAllActions()
	{
		List<Hero> list = new List<Hero>(_activeActions.Keys);
		foreach (Hero item in list)
		{
			StopAllActions(item);
		}
	}

	public bool IsActionActive(Hero hero, string actionName)
	{
		if (hero == null || !_activeActions.ContainsKey(hero))
		{
			return false;
		}
		return _activeActions[hero].Any((AIActionBase a) => a.ActionName == actionName && a.IsActive);
	}

	public List<string> GetActiveActions(Hero hero)
	{
		if (hero == null || !_activeActions.ContainsKey(hero))
		{
			return new List<string>();
		}
		return (from a in _activeActions[hero]
			where a.IsActive
			select a.ActionName).ToList();
	}

	public AIActionBase GetActiveAction(Hero hero, string actionName)
	{
		if (hero == null || !_activeActions.ContainsKey(hero))
		{
			return null;
		}
		return _activeActions[hero].FirstOrDefault((AIActionBase a) => a.ActionName == actionName && a.IsActive);
	}

	public List<string> GetRegisteredActions()
	{
		return new List<string>(_registeredActionTypes.Keys);
	}

	public List<Hero> GetHeroesFollowingPlayerInSettlement(Settlement settlement, bool onlyActive = true)
	{
		List<Hero> list = new List<Hero>();
		try
		{
			if (settlement == null)
			{
				return list;
			}
			foreach (KeyValuePair<Hero, List<AIActionBase>> activeAction in _activeActions)
			{
				Hero key = activeAction.Key;
				if (key == null || key.IsDead || key.IsPrisoner)
				{
					continue;
				}
				AIActionBase aIActionBase = activeAction.Value.FirstOrDefault((AIActionBase a) => a.ActionName == "follow_player");
				if (aIActionBase == null || (onlyActive && !aIActionBase.IsActive))
				{
					continue;
				}
				if (key.StayingInSettlement != settlement && key.CurrentSettlement != settlement && key.PartyBelongedTo != MobileParty.MainParty)
				{
					MobileParty partyBelongedTo = key.PartyBelongedTo;
					if (((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null) != settlement)
					{
						continue;
					}
				}
				list.Add(key);
			}
		}
		catch (Exception ex)
		{
			LogMessage($"ERROR gathering follow_player heroes for settlement {((settlement != null) ? settlement.Name : null)}: {ex.Message}");
		}
		return list;
	}

	public void Update(float deltaTime)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		List<Hero> list = new List<Hero>(_activeActions.Keys);
		foreach (Hero item in list)
		{
			if (!_activeActions.TryGetValue(item, out var value) || value == null)
			{
				continue;
			}
			List<AIActionBase> list2 = new List<AIActionBase>(value);
			foreach (AIActionBase item2 in list2)
			{
				if (!item2.IsActive)
				{
					continue;
				}
				try
				{
					item2.Update(deltaTime);
				}
				catch (Exception ex)
				{
					LogMessage($"ERROR updating action '{item2.ActionName}' for {item.Name}: {ex.Message}");
					item2.Stop();
					if (_activeActions.TryGetValue(item, out var value2))
					{
						value2.Remove(item2);
					}
				}
			}
			if (_activeActions.TryGetValue(item, out var value3) && (value3.Count == 0 || value3.All((AIActionBase a) => !a.IsActive)))
			{
				_activeActions.Remove(item);
			}
		}
		CheckPartiesTravelingToRemoval();
		_settlementEntryCheckTimer += deltaTime;
		if (_settlementEntryCheckTimer >= 0.5f)
		{
			_settlementEntryCheckTimer = 0f;
			CheckFollowingNPCsSettlementEntry();
		}
	}

	public bool ParseAndExecuteCommand(string command)
	{
		if (string.IsNullOrEmpty(command))
		{
			return false;
		}
		string[] array = command.Split(new char[1] { ':' });
		if (array.Length < 3)
		{
			LogMessage("ERROR: Invalid action command format: " + command);
			return false;
		}
		if (array[0].Trim().ToUpper() != "ACTION")
		{
			return false;
		}
		string actionName = array[1].Trim();
		string text = array[2].Trim();
		LogMessage($"[DEBUG][ParseAndExecuteCommand] Full command: '{command}'");
		LogMessage($"[DEBUG][ParseAndExecuteCommand] Parsed prefix='{array[0]}', actionName='{actionName}', heroIdentifier='{text}'");
		LogMessage($"[DEBUG][ParseAndExecuteCommand] Calling FindHeroByNameOrId('{text}'). NOTE: This method ONLY searches by DISPLAY NAME, not by StringId.");
		Hero val = FindHeroByNameOrId(text);
		if (val == null)
		{
			LogMessage($"[DEBUG][ParseAndExecuteCommand] HERO NOT FOUND for identifier='{text}'. This is most likely a StringId, but FindHeroByNameOrId only does name matching.");
			LogMessage("ERROR: Hero '" + text + "' not found");
			return false;
		}
		LogMessage($"[DEBUG][ParseAndExecuteCommand] Hero found: '{val.Name}' (StringId='{((MBObjectBase)val).StringId}')");
		string text2 = ((array.Length >= 4) ? string.Join(":", array.Skip(3)).Trim() : null);
		if (!string.IsNullOrEmpty(text2) && text2.Equals("STOP", StringComparison.OrdinalIgnoreCase))
		{
			return StopAction(val, actionName, showMessage: true);
		}
		if (!PrepareActionParameter(val, actionName, text2))
		{
			return false;
		}
		return StartAction(val, actionName);
	}

	private bool PrepareActionParameter(Hero hero, string actionName, string parameter)
	{
		if (string.IsNullOrWhiteSpace(parameter))
		{
			return true;
		}
		if (!(actionName == "go_to_settlement"))
		{
			if (actionName == "siege_settlement")
			{
				try
				{
					string[] array = parameter.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					if (array.Length == 0)
					{
						LogMessage($"ERROR: Empty parameter for siege_settlement (hero {((hero != null) ? hero.Name : null)}).");
						return false;
					}
					string text = array[0].Trim();
					bool autoReturn = array.Skip(1).Any((string t) => t.Trim().Equals("then:return", StringComparison.OrdinalIgnoreCase) || t.Trim().Equals("return", StringComparison.OrdinalIgnoreCase));
					if (!GoToSettlementAction.PrepareDestination(hero, text, out var settlement))
					{
						LogMessage($"ERROR: Failed to find settlement '{text}' for siege_settlement (hero {((hero != null) ? hero.Name : null)}).");
						return false;
					}
					if (IsSettlementOwnedByHero(settlement, hero))
					{
						TextObject arg = ((hero != null) ? hero.Name : null);
						TextObject name = settlement.Name;
						object obj;
						if (hero == null)
						{
							obj = null;
						}
						else
						{
							Clan clan = hero.Clan;
							obj = ((clan == null) ? null : ((object)clan.Name)?.ToString());
						}
						if (obj == null)
						{
							obj = "their faction";
						}
						LogMessage($"ERROR: {arg} attempted to attack own settlement {name} (belongs to {obj}). Action blocked.");
						return false;
					}
					SiegeSettlementAction.PrepareSiegeTarget(hero, ((MBObjectBase)settlement).StringId, autoReturn);
					LogMessage($"Prepared siege_settlement for {((hero != null) ? hero.Name : null)} -> {settlement.Name}");
					return true;
				}
				catch (Exception ex)
				{
					LogMessage($"ERROR parsing siege_settlement parameter for {((hero != null) ? hero.Name : null)}: {ex.Message}");
					return false;
				}
			}
			LogMessage("WARNING: Parameter '" + parameter + "' supplied for action '" + actionName + "' but no handler exists. Ignoring.");
			return true;
		}
		if (GoToSettlementAction.PrepareDestination(hero, parameter, out var settlement2))
		{
			LogMessage($"Prepared go_to_settlement for {hero.Name} -> {settlement2.Name}");
			return true;
		}
		LogMessage($"ERROR: Settlement '{parameter}' not found for go_to_settlement action (hero {hero.Name}).");
		return false;
	}

	private bool IsSettlementOwnedByHero(Settlement settlement, Hero hero)
	{
		if (settlement == null || hero == null || hero.Clan == null)
		{
			return false;
		}
		if (settlement.OwnerClan == hero.Clan)
		{
			return true;
		}
		if (hero.Clan.Kingdom != null && (object)settlement.MapFaction == hero.Clan.Kingdom)
		{
			return true;
		}
		if (hero.Clan.Kingdom == null && (object)settlement.MapFaction == hero.Clan)
		{
			return true;
		}
		return false;
	}

	public void RegisterPartyForRemoval(Hero hero, MobileParty party, Settlement destination)
	{
		if (hero == null || party == null)
		{
			return;
		}
		bool flag = _partiesTravelingToRemoval.ContainsKey(hero);
		if (flag && hero.IsNotable)
		{
			PartyReturnInfo partyReturnInfo = _partiesTravelingToRemoval[hero];
			if (partyReturnInfo.Destination != null)
			{
				LogMessage(string.Format("Notable {0} already registered for return to {1}, ignoring new destination {2}", hero.Name, partyReturnInfo.Destination.Name, ((destination == null) ? null : ((object)destination.Name)?.ToString()) ?? "unknown"));
				return;
			}
		}
		_partiesTravelingToRemoval[hero] = new PartyReturnInfo(party, destination);
		string arg = ((destination != null) ? ((object)destination.Name).ToString() : "unknown destination");
		LogMessage(flag ? $"Updated party removal tracking for {hero.Name}; new destination: {arg}" : $"Registered party of {hero.Name} for removal when it arrives at {arg}");
	}

	public bool IsPartyRegisteredForReturn(Hero hero)
	{
		if (hero == null)
		{
			return false;
		}
		return _partiesTravelingToRemoval.ContainsKey(hero);
	}

	public void UnregisterPartyForReturn(Hero hero)
	{
		if (hero != null && _partiesTravelingToRemoval.ContainsKey(hero))
		{
			_partiesTravelingToRemoval.Remove(hero);
			LogMessage($"Unregistered party return for {hero.Name} - follow_player reactivated");
		}
	}

	private void CheckPartiesTravelingToRemoval()
	{
		if (_partiesTravelingToRemoval.Count == 0)
		{
			return;
		}
		List<Hero> list = new List<Hero>(_partiesTravelingToRemoval.Keys);
		foreach (Hero item in list)
		{
			if (!_partiesTravelingToRemoval.ContainsKey(item))
			{
				continue;
			}
			PartyReturnInfo partyReturnInfo = _partiesTravelingToRemoval[item];
			MobileParty party = partyReturnInfo.Party;
			Settlement val = partyReturnInfo.Destination;
			if (party == null || !party.IsActive)
			{
				LogMessage($"Party for {item.Name} no longer exists, removing from tracking");
				_partiesTravelingToRemoval.Remove(item);
				continue;
			}
			Settlement currentSettlement = party.CurrentSettlement;
			if (item.IsNotable && val != null && currentSettlement == null)
			{
				try
				{
					Settlement partyTargetSettlement = GameVersionCompatibility.GetPartyTargetSettlement(party);
					if (partyTargetSettlement != val)
					{
						LogMessage(string.Format("Notable {0}'s party target changed from {1} to {2} - restoring correct destination", item.Name, val.Name, ((partyTargetSettlement == null) ? null : ((object)partyTargetSettlement.Name)?.ToString()) ?? "null"));
						GameVersionCompatibility.SetMoveGoToSettlement(party, val);
						GameVersionCompatibility.ConditionalDisableAi(party);
					}
				}
				catch (Exception ex)
				{
					LogMessage($"Error checking party target for {item.Name}: {ex.Message}");
				}
			}
			bool flag = false;
			if (val != null)
			{
				if (currentSettlement == null)
				{
					float distance = GameVersionCompatibility.GetDistance(party, val);
					if (distance <= 0.2f)
					{
						LogMessage($"Party of {item.Name} reached destination {val.Name} (distance {distance:F2}) - forcing settlement entry");
						try
						{
							GameVersionCompatibility.ConditionalDisableAi(party);
							EnterSettlementAction.ApplyForParty(party, val);
							currentSettlement = party.CurrentSettlement;
						}
						catch (Exception ex2)
						{
							LogMessage($"ERROR forcing settlement entry for {item.Name}: {ex2.Message}");
						}
					}
				}
				flag = currentSettlement == val;
			}
			else if (currentSettlement != null && currentSettlement.IsTown)
			{
				flag = true;
				val = currentSettlement;
			}
			if (flag && val != null)
			{
				LogMessage($"Party of {item.Name} arrived at {val.Name}, finalizing removal");
				FinalizePartyRemoval(item, party, val);
				_partiesTravelingToRemoval.Remove(item);
			}
		}
	}

	private List<AIActionSaveData> CaptureActiveActionsForSave()
	{
		List<AIActionSaveData> list = new List<AIActionSaveData>();
		foreach (KeyValuePair<Hero, List<AIActionBase>> activeAction in _activeActions)
		{
			Hero key = activeAction.Key;
			if (key == null || key.IsDead || key.IsPrisoner || string.IsNullOrEmpty(((MBObjectBase)key).StringId))
			{
				continue;
			}
			foreach (AIActionBase item2 in activeAction.Value)
			{
				if (item2 != null && item2.IsActive && !_nonPersistentActions.Contains(item2.ActionName))
				{
					AIActionSaveData item = new AIActionSaveData
					{
						HeroId = ((MBObjectBase)key).StringId,
						ActionName = item2.ActionName,
						Parameters = (item2.GetStateDataForSave() ?? new Dictionary<string, string>())
					};
					list.Add(item);
				}
			}
		}
		LogMessage($"[SAVE] Captured {list.Count} active AI actions for serialization.");
		return list;
	}

	private void RestoreActionsFromSave(List<AIActionSaveData> savedActions)
	{
		if (savedActions == null || savedActions.Count == 0)
		{
			LogMessage("[RESTORE] No AI actions found in serialized state.");
			return;
		}
		int num = 0;
		foreach (AIActionSaveData actionData in savedActions)
		{
			if (actionData != null && !string.IsNullOrWhiteSpace(actionData.HeroId) && !string.IsNullOrWhiteSpace(actionData.ActionName))
			{
				Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == actionData.HeroId));
				if (val == null)
				{
					LogMessage("[RESTORE] Hero '" + actionData.HeroId + "' not found, skipping action '" + actionData.ActionName + "'.");
				}
				else if (val.IsDead || val.IsPrisoner)
				{
					LogMessage($"[RESTORE] Hero '{val.Name}' unavailable (dead/prisoner), skipping action '{actionData.ActionName}'.");
				}
				else if (!_nonPersistentActions.Contains(actionData.ActionName) && PrepareActionFromSavedData(val, actionData) && StartAction(val, actionData.ActionName))
				{
					num++;
				}
			}
		}
		LogMessage($"[RESTORE] Restored {num} AI actions after load.");
	}

	private bool PrepareActionFromSavedData(Hero hero, AIActionSaveData data)
	{
		Dictionary<string, string> dictionary = data.Parameters ?? new Dictionary<string, string>();
		switch (data.ActionName)
		{
		case "follow_player":
		case "return_to_player":
			return true;
		case "go_to_settlement":
		{
			if (!dictionary.TryGetValue("settlementId", out var value2))
			{
				LogMessage("[RESTORE] go_to_settlement missing settlementId parameter.");
				return false;
			}
			float waitDays = GetFloat(dictionary, "waitDays", 3f);
			Settlement settlement;
			return GoToSettlementAction.PrepareDestination(hero, value2, out settlement, waitDays);
		}
		case "attack_party":
		{
			if (!dictionary.TryGetValue("targetPartyId", out var value4))
			{
				LogMessage("[RESTORE] attack_party missing targetPartyId parameter.");
				return false;
			}
			return AttackPartyAction.PrepareAttackTarget(hero, value4);
		}
		case "siege_settlement":
		{
			if (!dictionary.TryGetValue("settlementId", out var value5))
			{
				LogMessage("[RESTORE] siege_settlement missing settlementId parameter.");
				return false;
			}
			bool autoReturn2 = GetBool(dictionary, "autoReturn");
			return SiegeSettlementAction.PrepareSiegeTarget(hero, value5, autoReturn2);
		}
		case "patrol_settlement":
		{
			if (!dictionary.TryGetValue("settlementId", out var value3))
			{
				LogMessage("[RESTORE] patrol_settlement missing settlementId parameter.");
				return false;
			}
			bool autoReturn = GetBool(dictionary, "autoReturn");
			float hours = GetFloat(dictionary, "remainingHours", 7f * (float)CampaignTime.HoursInDay);
			float durationDays = ConvertHoursToDays(hours, 7f);
			return PatrolSettlementAction.PreparePatrolRequest(hero, value3, durationDays, autoReturn);
		}
		case "wait_near_settlement":
		{
			if (!dictionary.TryGetValue("settlementId", out var waitId))
			{
				LogMessage("[RESTORE] wait_near_settlement missing settlementId parameter.");
				return false;
			}
			float hours2 = GetFloat(dictionary, "remainingHours", 2f * (float)CampaignTime.HoursInDay);
			float waitDays2 = ConvertHoursToDays(hours2, 2f);
			float desiredRadius = GetFloat(dictionary, "radius", 10f);
			Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == waitId));
			if (val == null)
			{
				LogMessage("[RESTORE] Failed to find settlement '" + waitId + "' for wait_near_settlement.");
				return false;
			}
			return WaitNearSettlementAction.PrepareWaitRequest(hero, val, waitDays2, desiredRadius);
		}
		case "raid_village":
		{
			if (!dictionary.TryGetValue("settlementId", out var value))
			{
				LogMessage("[RESTORE] raid_village missing settlementId parameter.");
				return false;
			}
			return RaidVillageAction.PrepareRaidTarget(hero, value);
		}
		default:
			LogMessage("[RESTORE] Unsupported action '" + data.ActionName + "' in save data.");
			return false;
		}
	}

	private static float GetFloat(Dictionary<string, string> parameters, string key, float defaultValue)
	{
		if (parameters != null && parameters.TryGetValue(key, out var value) && float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		return defaultValue;
	}

	private static bool GetBool(Dictionary<string, string> parameters, string key)
	{
		if (parameters != null && parameters.TryGetValue(key, out var value) && bool.TryParse(value, out var result))
		{
			return result;
		}
		return false;
	}

	private static float ConvertHoursToDays(float hours, float fallbackDays)
	{
		if (hours <= 0f)
		{
			return fallbackDays;
		}
		float num = ((CampaignTime.HoursInDay > 0) ? ((float)CampaignTime.HoursInDay) : 24f);
		return (num > 0f) ? (hours / num) : fallbackDays;
	}

	private void FinalizePartyRemoval(Hero hero, MobileParty party, Settlement destination)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null || party == null || destination == null)
		{
			return;
		}
		try
		{
			LogMessage($"Finalizing removal of {hero.Name}'s party at {destination.Name}");
			PlaceHeroInSettlement(hero, destination);
			if (party == MobileParty.MainParty)
			{
				LogMessage($"CRITICAL: Attempted to destroy MainParty in FinalizePartyRemoval for {hero.Name}! This would corrupt the game. Skipping destruction.");
				return;
			}
			if (party.MemberRoster.Contains(hero.CharacterObject))
			{
				party.MemberRoster.RemoveTroop(hero.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
			}
			GameVersionCompatibility.RemoveShips(party);
			DestroyPartyAction.Apply((PartyBase)null, party);
			LogMessage($"{hero.Name} placed in {destination.Name} and party was removed");
			if (_heroesWithFollowActionHistory.Contains(hero))
			{
				_heroesWithFollowActionHistory.Remove(hero);
				LogMessage($"Removed {hero.Name} from follow action history (returned to home settlement)");
			}
		}
		catch (Exception ex)
		{
			LogMessage($"ERROR finalizing party removal for {hero.Name}: {ex.Message}");
		}
	}

	private void PlaceHeroInSettlement(Hero hero, Settlement settlement)
	{
		if (hero == null || settlement == null)
		{
			return;
		}
		try
		{
			hero.StayingInSettlement = settlement;
			EnterSettlementAction.ApplyForCharacterOnly(hero, settlement);
			if (settlement.IsTown && (hero.IsWanderer || hero.IsPlayerCompanion))
			{
				LogMessage($"{hero.Name} teleported to tavern in {settlement.Name}");
			}
			else
			{
				LogMessage($"{hero.Name} returned to {settlement.Name}");
			}
		}
		catch (Exception ex)
		{
			LogMessage($"ERROR placing {hero.Name} in {((settlement != null) ? settlement.Name : null)}: {ex.Message}");
		}
	}

	private Hero FindHeroByNameOrId(string identifier)
	{
		if (string.IsNullOrEmpty(identifier))
		{
			return null;
		}
		LogMessage($"[DEBUG][FindHeroByNameOrId] Searching for identifier='{identifier}'");
		LogMessage($"[DEBUG][FindHeroByNameOrId] SEARCH METHOD: exact display-name match (case-insensitive). StringIds like 'lord_empire_1' will NOT match any hero display name.");
		Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h.Name != (TextObject)null && ((object)h.Name).ToString().Equals(identifier, StringComparison.OrdinalIgnoreCase)));
		if (val == null)
		{
			LogMessage($"[DEBUG][FindHeroByNameOrId] Exact name match: NOT FOUND for '{identifier}'. Trying substring match...");
			val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h.Name != (TextObject)null && ((object)h.Name).ToString().IndexOf(identifier, StringComparison.OrdinalIgnoreCase) >= 0));
			if (val == null)
				LogMessage($"[DEBUG][FindHeroByNameOrId] Substring name match: NOT FOUND for '{identifier}'. Hero lookup FAILED. This confirms the identifier is a StringId, not a display name.");
			else
				LogMessage($"[DEBUG][FindHeroByNameOrId] Substring match found: '{val.Name}' (StringId='{((MBObjectBase)val).StringId}') - partial name match on '{identifier}'");
		}
		else
		{
			LogMessage($"[DEBUG][FindHeroByNameOrId] Exact match found: '{val.Name}' (StringId='{((MBObjectBase)val).StringId}')");
		}
		return val;
	}

	private void LogMessage(string message)
	{
		AIActionsLogger.Instance.Log("[AIActionManager] " + message);
	}

	public void Clear()
	{
		StopAllActions();
		_activeActions.Clear();
		_partiesTravelingToRemoval.Clear();
		_heroesInPartyOnSettlementEntry.Clear();
	}

	public void CleanupOldParties()
	{
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			HashSet<Hero> hashSet = new HashSet<Hero>();
			foreach (KeyValuePair<Hero, List<AIActionBase>> activeAction in _activeActions)
			{
				Hero key = activeAction.Key;
				List<AIActionBase> value = activeAction.Value;
				if (value.Any((AIActionBase a) => a.ActionName == "follow_player"))
				{
					hashSet.Add(key);
				}
			}
			LogMessage("Heroes with follow actions: " + string.Join(", ", hashSet.Select((Hero h) => h.Name)));
			List<MobileParty> list = new List<MobileParty>();
			foreach (MobileParty item in (List<MobileParty>)(object)MobileParty.All)
			{
				if (item != MobileParty.MainParty && !item.IsGarrison && !item.IsMilitia && item.ActualClan == Clan.PlayerClan && item.LeaderHero != null)
				{
					bool flag = item.LeaderHero.Clan == Clan.PlayerClan;
					if (!hashSet.Contains(item.LeaderHero) && !flag)
					{
						LogMessage($"Found old party for {item.LeaderHero.Name} (no follow action, not companion) - marking for removal");
						list.Add(item);
					}
					else if (flag)
					{
						LogMessage($"Keeping companion party for {item.LeaderHero.Name} - companions can create caravans");
					}
				}
			}
			foreach (MobileParty item2 in list)
			{
				try
				{
					if (item2 == MobileParty.MainParty)
					{
						LogMessage("CRITICAL: Attempted to remove MainParty! This would corrupt the game. Skipping removal.");
						continue;
					}
					TextObject name = item2.Name;
					Hero leaderHero = item2.LeaderHero;
					LogMessage($"Removing old party: {name} (Leader: {((leaderHero != null) ? leaderHero.Name : null)})");
					if (item2.LeaderHero != null)
					{
						item2.MemberRoster.RemoveTroop(item2.LeaderHero.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
					}
					item2.RemoveParty();
					LogMessage($"Successfully removed old party: {item2.Name}");
				}
				catch (Exception ex)
				{
					LogMessage($"ERROR removing party {item2.Name}: {ex.Message}");
				}
			}
		}
		catch (Exception ex2)
		{
			LogMessage("ERROR during cleanup: " + ex2.Message);
		}
	}

	private bool IsLord(Hero hero)
	{
		if (hero == null)
		{
			return false;
		}
		return hero.Clan != null && hero.Clan != Clan.PlayerClan && hero.Clan.Leader != hero && !hero.IsWanderer;
	}

	private void CheckFollowingNPCsSettlementEntry()
	{
		if (Hero.MainHero == null || Hero.MainHero.CurrentSettlement == null)
		{
			return;
		}
		Settlement currentSettlement = Hero.MainHero.CurrentSettlement;
		foreach (KeyValuePair<Hero, List<AIActionBase>> item in _activeActions.ToList())
		{
			Hero key = item.Key;
			List<AIActionBase> value = item.Value;
			if (!(value.FirstOrDefault((AIActionBase a) => a.ActionName == "follow_player") is FollowPlayerAction { IsActive: not false } followPlayerAction))
			{
				continue;
			}
			bool flag = false;
			if (key.StayingInSettlement != null)
			{
				flag = true;
			}
			if (key.PartyBelongedTo != null && key.PartyBelongedTo.CurrentSettlement != null)
			{
				flag = true;
			}
			if (flag || key.PartyBelongedTo == MobileParty.MainParty)
			{
				continue;
			}
			MobileParty partyBelongedTo = key.PartyBelongedTo;
			if (partyBelongedTo == null)
			{
				continue;
			}
			float distance = GameVersionCompatibility.GetDistance(partyBelongedTo, currentSettlement);
			if (distance <= 0.2f)
			{
				LogMessage($"[AUTO-ENTRY] Hero {key.Name} approached settlement {currentSettlement.Name} (distance: {distance:F2}) - entering automatically");
				try
				{
					GameVersionCompatibility.EnterSettlementForFollowingHero(key, currentSettlement);
					followPlayerAction.SetNeedsMissionFollowingInit(needsInit: true);
					LogMessage($"[AUTO-ENTRY] Successfully entered {key.Name} into {currentSettlement.Name}");
				}
				catch (Exception ex)
				{
					LogMessage($"[AUTO-ENTRY] ERROR entering {key.Name} into settlement: {ex.Message}");
				}
			}
		}
	}

	private void OnSettlementEntered(MobileParty party, Settlement settlement, Hero hero)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		if (party != MobileParty.MainParty || settlement == null)
		{
			return;
		}
		LogMessage($"Player entered settlement {settlement.Name}, managing following heroes");
		_heroesInPartyOnSettlementEntry.Clear();
		if (MobileParty.MainParty != null && MobileParty.MainParty.MemberRoster != null)
		{
			foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)MobileParty.MainParty.MemberRoster.GetTroopRoster())
			{
				if (item.Character == null || !((BasicCharacterObject)item.Character).IsHero || item.Character.HeroObject == null)
				{
					continue;
				}
				Hero heroObject = item.Character.HeroObject;
				if (heroObject.IsPrisoner)
				{
					LogMessage($"Skipping {heroObject.Name} - is a prisoner");
					continue;
				}
				_heroesInPartyOnSettlementEntry.Add(heroObject);
				LogMessage($"Remembered {heroObject.Name} was in party on settlement entry");
				if (heroObject.Clan != Clan.PlayerClan)
				{
					continue;
				}
				try
				{
					if (PlayerEncounter.LocationEncounter != null)
					{
						LocationComplex current2 = LocationComplex.Current;
						LocationCharacter val = ((current2 != null) ? current2.GetLocationCharacterOfHero(heroObject) : null);
						if (val != null)
						{
							PlayerEncounter.LocationEncounter.AddAccompanyingCharacter(val, true);
							LogMessage($"Added companion {heroObject.Name} to accompanying characters for mission loading");
						}
					}
				}
				catch (Exception ex)
				{
					LogMessage($"Error adding companion {heroObject.Name} to accompanying characters: {ex.Message}");
				}
			}
		}
		foreach (KeyValuePair<Hero, List<AIActionBase>> item2 in _activeActions.ToList())
		{
			Hero key = item2.Key;
			List<AIActionBase> value = item2.Value;
			if (!value.Any((AIActionBase a) => a.ActionName == "follow_player") || !(value.FirstOrDefault((AIActionBase a) => a.ActionName == "follow_player") is FollowPlayerAction followPlayerAction))
			{
				continue;
			}
			if (followPlayerAction.IsActive)
			{
				if (key.PartyBelongedTo == MobileParty.MainParty)
				{
					LogMessage($"Hero {key.Name} is in player party - already entering settlement with player, skipping separate entry");
					if (key.Clan == Clan.PlayerClan)
					{
						LogMessage($"Companion {key.Name} is in player party - will load automatically in mission, no special following needed");
						continue;
					}
					followPlayerAction.SetNeedsMissionFollowingInit(needsInit: true);
					LogMessage($"Marked NPC lord {key.Name} for mission following initialization when mission loads");
					continue;
				}
				MobileParty partyBelongedTo = key.PartyBelongedTo;
				if (partyBelongedTo == null)
				{
					LogMessage($"Hero {key.Name} has no party while entering settlement {settlement.Name} - attempting to create one");
					followPlayerAction.EnsureGlobalMapParty(forceCreate: true);
					partyBelongedTo = key.PartyBelongedTo;
				}
				if (partyBelongedTo != null && partyBelongedTo != MobileParty.MainParty)
				{
					float distance = GameVersionCompatibility.GetDistance(partyBelongedTo, settlement);
					if (distance <= 0.2f)
					{
						LogMessage($"Hero {key.Name} is close enough (distance: {distance:F2}) - entering settlement");
						GameVersionCompatibility.EnterSettlementForFollowingHero(key, settlement);
						followPlayerAction.SetNeedsMissionFollowingInit(needsInit: true);
						LogMessage($"Marked {key.Name} for mission following initialization when mission loads");
					}
					else
					{
						LogMessage($"Hero {key.Name} is too far (distance: {distance:F2}) - NOT entering settlement");
					}
				}
				else
				{
					LogMessage($"Hero {key.Name} still has no valid party after creation attempt - cannot enter settlement");
				}
			}
			else
			{
				LogMessage($"Hero {key.Name} has follow action but it's disabled - not entering settlement");
			}
		}
	}

	private void OnMissionStarted(IMission mission)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		LogMessage("Mission started: " + ((object)mission)?.GetType()?.Name + ", initializing following actions");
		if (MobileParty.MainParty != null && MobileParty.MainParty.MemberRoster != null)
		{
			foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)MobileParty.MainParty.MemberRoster.GetTroopRoster())
			{
				if (item.Character == null || !((BasicCharacterObject)item.Character).IsHero || item.Character.HeroObject == null)
				{
					continue;
				}
				Hero heroObject = item.Character.HeroObject;
				if (heroObject.Clan != Clan.PlayerClan || heroObject.IsPrisoner)
				{
					continue;
				}
				try
				{
					if (PlayerEncounter.LocationEncounter != null)
					{
						LocationComplex current2 = LocationComplex.Current;
						LocationCharacter val = ((current2 != null) ? current2.GetLocationCharacterOfHero(heroObject) : null);
						if (val != null)
						{
							PlayerEncounter.LocationEncounter.AddAccompanyingCharacter(val, true);
							LogMessage($"Added companion {heroObject.Name} to accompanying characters on mission start");
						}
						else
						{
							LogMessage($"Could not find LocationCharacter for companion {heroObject.Name}");
						}
					}
					else
					{
						LogMessage($"No LocationEncounter for companion {heroObject.Name}");
					}
				}
				catch (Exception ex)
				{
					LogMessage($"Error adding companion {heroObject.Name} to accompanying characters on mission start: {ex.Message}");
				}
			}
		}
		foreach (KeyValuePair<Hero, List<AIActionBase>> item2 in _activeActions.ToList())
		{
			Hero key = item2.Key;
			List<AIActionBase> value = item2.Value;
			if (!(value.FirstOrDefault((AIActionBase a) => a.ActionName == "follow_player") is FollowPlayerAction { IsActive: not false } followPlayerAction))
			{
				continue;
			}
			if (key.Clan == Clan.PlayerClan)
			{
				if (key.PartyBelongedTo == null || key.PartyBelongedTo == MobileParty.MainParty || key.PartyBelongedTo.LeaderHero != key)
				{
					LogMessage($"Skipping mission following init for companion {key.Name} - no own party, handled by accompanying characters");
					continue;
				}
				LogMessage($"Companion {key.Name} has own party - processing as regular hero");
			}
			if (key.CurrentSettlement != null || Settlement.CurrentSettlement != null)
			{
				LogMessage($"Hero {key.Name} is in settlement - adding to accompanying characters and initializing mission following");
				try
				{
					if (PlayerEncounter.LocationEncounter != null && LocationComplex.Current != null)
					{
						LocationCharacter locationCharacterOfHero = LocationComplex.Current.GetLocationCharacterOfHero(key);
						if (locationCharacterOfHero != null)
						{
							PlayerEncounter.LocationEncounter.AddAccompanyingCharacter(locationCharacterOfHero, true);
							LogMessage($"Added {key.Name} to accompanying characters (existing LocationCharacter)");
						}
						else if (key.IsNotable && Settlement.CurrentSettlement != null)
						{
							try
							{
								CreateLocationCharacterForNotable(key, Settlement.CurrentSettlement);
								LogMessage($"Created LocationCharacter for notable {key.Name} manually");
								LocationCharacter locationCharacterOfHero2 = LocationComplex.Current.GetLocationCharacterOfHero(key);
								if (locationCharacterOfHero2 != null)
								{
									PlayerEncounter.LocationEncounter.AddAccompanyingCharacter(locationCharacterOfHero2, true);
									LogMessage($"Added {key.Name} to accompanying characters (manually created LocationCharacter)");
								}
							}
							catch (Exception ex2)
							{
								LogMessage($"Error creating LocationCharacter for notable {key.Name}: {ex2.Message}");
							}
						}
						else
						{
							LogMessage($"LocationCharacter not found for {key.Name}, will be created in ReinitializeMissionFollowing");
						}
					}
				}
				catch (Exception ex3)
				{
					LogMessage($"Error adding {key.Name} to accompanying characters: {ex3.Message}");
				}
				followPlayerAction.ReinitializeMissionFollowing();
			}
			else if (followPlayerAction.GetNeedsMissionFollowingInit())
			{
				LogMessage($"Initializing mission following for {key.Name} on mission start (needs init flag set)");
				followPlayerAction.ReinitializeMissionFollowing();
			}
			else
			{
				LogMessage($"Skipping mission following init for {key.Name} - not in settlement and needs init flag not set");
			}
		}
	}

	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification)
	{
		if (victim != null && IsActionActive(victim, "follow_player"))
		{
			LogMessage($"Hero {victim.Name} was killed - stopping any follow actions");
			StopAction(victim, "follow_player", showMessage: true);
		}
	}

	private void OnHeroPrisonerTaken(PartyBase capturer, Hero prisoner)
	{
		if (prisoner != null)
		{
			if (IsActionActive(prisoner, "follow_player"))
			{
				LogMessage($"Hero {prisoner.Name} was taken prisoner - stopping follow_player action with message");
				StopAction(prisoner, "follow_player", showMessage: true);
			}
			StopAllActions(prisoner);
		}
	}

	private void OnHeroJoinedParty(Hero hero, MobileParty party)
	{
		if (hero == null || party == null)
		{
			return;
		}
		try
		{
			if (party == MobileParty.MainParty)
			{
				if (_activeActions.TryGetValue(hero, out var value) && value.FirstOrDefault((AIActionBase a) => a is FollowPlayerAction) is FollowPlayerAction { IsBoardedOnShip: not false })
				{
					LogMessage($"Hero {hero.Name} boarded player ship - KEEPING FollowPlayerAction active (IsBoardedOnShip=true)");
					return;
				}
				LogMessage($"Hero {hero.Name} joined the player's party via OnHeroJoinedParty - clearing all AI actions and tasks for this hero");
				StopAllActions(hero);
			}
		}
		catch (Exception ex)
		{
			LogMessage($"ERROR in OnHeroJoinedParty for {((hero != null) ? hero.Name : null)}: {ex.Message}");
		}
	}

	private void OnSettlementLeft(MobileParty party, Settlement settlement)
	{
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		if (party != MobileParty.MainParty || settlement == null)
		{
			return;
		}
		LogMessage($"Player left settlement {settlement.Name}, managing follow heroes");
		CheckStoppedFollowActionsInSettlement(settlement);
		foreach (KeyValuePair<Hero, List<AIActionBase>> item in _activeActions.ToList())
		{
			Hero key = item.Key;
			List<AIActionBase> value = item.Value;
			if (!value.Any((AIActionBase a) => a.ActionName == "follow_player"))
			{
				continue;
			}
			try
			{
				bool flag = _heroesInPartyOnSettlementEntry.Contains(key);
				FollowPlayerAction followPlayerAction = value.FirstOrDefault((AIActionBase a) => a.ActionName == "follow_player") as FollowPlayerAction;
				bool flag2 = followPlayerAction?.IsActive ?? false;
				bool flag3 = key.Clan == Clan.PlayerClan;
				if (flag)
				{
					if (flag2 && !flag3)
					{
						if (MobileParty.MainParty != null && MobileParty.MainParty.MemberRoster.Contains(key.CharacterObject))
						{
							MobileParty.MainParty.MemberRoster.RemoveTroop(key.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
							LogMessage($"Removed {key.Name} from player roster (NPC lord with follow_player) - can now create own party");
						}
					}
					else
					{
						LogMessage($"{key.Name} was in party on settlement entry - keeping in roster");
						if (MobileParty.MainParty != null && !MobileParty.MainParty.MemberRoster.Contains(key.CharacterObject))
						{
							MobileParty.MainParty.MemberRoster.AddToCounts(key.CharacterObject, 1, false, 0, 0, true, -1);
							LogMessage($"Added {key.Name} back to player roster");
						}
					}
				}
				else if (MobileParty.MainParty != null && MobileParty.MainParty.MemberRoster.Contains(key.CharacterObject))
				{
					MobileParty.MainParty.MemberRoster.RemoveTroop(key.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
					LogMessage($"Removed {key.Name} (not in party on entry) from player roster after leaving settlement");
				}
				bool flag4 = false;
				if (key.StayingInSettlement == settlement)
				{
					flag4 = true;
				}
				if (key.PartyBelongedTo != null && key.PartyBelongedTo.CurrentSettlement == settlement)
				{
					flag4 = true;
				}
				if (!flag4)
				{
					LogMessage($"Hero {key.Name} is NOT in settlement {settlement.Name} - skipping exit logic");
					continue;
				}
				LogMessage($"Hero {key.Name} IS in settlement {settlement.Name} - processing exit");
				if (followPlayerAction != null && !followPlayerAction.IsActive && key.PartyBelongedTo != null && key.PartyBelongedTo.CurrentSettlement == settlement)
				{
					LogMessage($"Follow action for {key.Name} was stopped in mission, but party still in settlement - setting up return");
					try
					{
						followPlayerAction.SetupReturnFromSettlement();
						LogMessage($"Called SetupReturnFromSettlement for {key.Name}");
					}
					catch (Exception ex)
					{
						LogMessage("Error setting up return for stopped follow action: " + ex.Message);
					}
				}
				if (followPlayerAction == null || !followPlayerAction.IsActive)
				{
					continue;
				}
				if (key.IsNotable && ((List<Hero>)(object)settlement.Notables).Contains(key) && key.HomeSettlement != settlement)
				{
					((List<Hero>)(object)settlement.Notables).Remove(key);
					LogMessage($"Removed {key.Name} (notable) from {settlement.Name}.Notables (not his home settlement)");
				}
				if (key.PartyBelongedTo == null)
				{
					LogMessage($"Hero {key.Name} has no party while leaving settlement {settlement.Name} - attempting to create one");
					followPlayerAction.EnsureGlobalMapParty(forceCreate: true);
				}
				if (flag)
				{
					LogMessage($"Stopping follow_player for {key.Name} - was in player party on settlement entry");
					StopAction(key, "follow_player");
					continue;
				}
				LogMessage($"Setting up global map following for {key.Name} after leaving settlement");
				if (key.PartyBelongedTo != null && key.PartyBelongedTo != MobileParty.MainParty)
				{
					GameVersionCompatibility.RestoreAiAfterLeavingSettlement(key.PartyBelongedTo);
					LogMessage($"Restored AI for {key.Name}'s party after leaving settlement");
				}
				if (Mission.Current != null)
				{
					followPlayerAction.CleanupMissionFollowing();
				}
			}
			catch (Exception ex2)
			{
				LogMessage($"ERROR leaving settlement for {key.Name}: {ex2.Message}");
			}
		}
		CleanupOldParties();
	}

	private void CheckStoppedFollowActionsInSettlement(Settlement settlement)
	{
		if (settlement == null)
		{
			return;
		}
		try
		{
			List<Hero> heroesInSettlement = new List<Hero>();
			if (settlement.Notables != null)
			{
				heroesInSettlement.AddRange((IEnumerable<Hero>)settlement.Notables);
			}
			List<Hero> collection = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h.StayingInSettlement == settlement && h != Hero.MainHero && !heroesInSettlement.Contains(h)).ToList();
			heroesInSettlement.AddRange(collection);
			List<Hero> list = heroesInSettlement.Where((Hero h) => _heroesWithFollowActionHistory.Contains(h)).ToList();
			foreach (Hero item in list)
			{
				try
				{
					if (item.PartyBelongedTo == MobileParty.MainParty || IsActionActive(item, "follow_player"))
					{
						continue;
					}
					Settlement val = null;
					if (item.IsNotable)
					{
						val = item.HomeSettlement;
					}
					Settlement val2 = item.StayingInSettlement ?? item.CurrentSettlement;
					if (val != null && val2 == val)
					{
						continue;
					}
					MobileParty partyBelongedTo = item.PartyBelongedTo;
					bool flag = false;
					if (partyBelongedTo == null)
					{
						flag = true;
						LogMessage($"Hero {item.Name} has no party and is not in home settlement - needs return setup");
					}
					else if (partyBelongedTo.CurrentSettlement == settlement)
					{
						flag = true;
						LogMessage($"Hero {item.Name}'s party is in settlement and hero is not in home settlement - needs return setup");
					}
					if (flag)
					{
						FollowPlayerAction followPlayerAction = new FollowPlayerAction();
						followPlayerAction.Initialize(item);
						if (Settlement.CurrentSettlement != null)
						{
							LogMessage($"Setting up return from settlement for {item.Name}");
							followPlayerAction.SetupReturnFromSettlement();
						}
						else
						{
							LogMessage($"Setting up return from global map for {item.Name}");
							followPlayerAction.SetupReturnFromGlobalMap();
						}
					}
				}
				catch (Exception ex)
				{
					LogMessage($"Error checking stopped follow action for {item.Name}: {ex.Message}");
				}
			}
		}
		catch (Exception ex2)
		{
			LogMessage("Error in CheckStoppedFollowActionsInSettlement: " + ex2.Message);
		}
	}

	private void OnMapEventEnded(MapEvent mapEvent)
	{
		if (mapEvent == null || !mapEvent.IsPlayerMapEvent)
		{
			return;
		}
		LogMessage("Map event ended, checking for following parties after battle");
		foreach (KeyValuePair<Hero, List<AIActionBase>> item in _activeActions.ToList())
		{
			Hero key = item.Key;
			List<AIActionBase> value = item.Value;
			if (!value.Any((AIActionBase a) => a.ActionName == "follow_player" && a.IsActive))
			{
				continue;
			}
			if (key.PartyBelongedTo != null && key.PartyBelongedTo != MobileParty.MainParty)
			{
				MobileParty partyBelongedTo = key.PartyBelongedTo;
				try
				{
					if (partyBelongedTo.CurrentSettlement == null && value.FirstOrDefault((AIActionBase a) => a.ActionName == "follow_player" && a.IsActive) is FollowPlayerAction followPlayerAction)
					{
						LogMessage($"Restoring escort behavior for {key.Name} after battle");
						followPlayerAction.EnsureGlobalMapParty();
					}
				}
				catch (Exception ex)
				{
					LogMessage($"ERROR restoring escort for {key.Name} after battle: {ex.Message}");
				}
			}
			else
			{
				try
				{
					LogMessage($"Hero {key.Name} lost their party in battle - stopping follow action");
					StopAction(key, "follow_player", showMessage: true);
				}
				catch (Exception ex2)
				{
					LogMessage($"ERROR stopping follow action for {key.Name}: {ex2.Message}");
				}
			}
		}
	}

	private void OnMapEventStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		if (mapEvent == null || !mapEvent.IsPlayerMapEvent)
		{
			return;
		}
		LogMessage("Map event started, checking for nearby following parties");
		BattleSideEnum val = (BattleSideEnum)(-1);
		if (attackerParty == PartyBase.MainParty || mapEvent.AttackerSide.LeaderParty == PartyBase.MainParty)
		{
			val = (BattleSideEnum)1;
		}
		else if (defenderParty == PartyBase.MainParty || mapEvent.DefenderSide.LeaderParty == PartyBase.MainParty)
		{
			val = (BattleSideEnum)0;
		}
		if ((int)val == -1)
		{
			return;
		}
		foreach (KeyValuePair<Hero, List<AIActionBase>> item in _activeActions.ToList())
		{
			Hero key = item.Key;
			List<AIActionBase> value = item.Value;
			if (!value.Any((AIActionBase a) => a.ActionName == "follow_player" && a.IsActive) || key.PartyBelongedTo == null || key.PartyBelongedTo == MobileParty.MainParty)
			{
				continue;
			}
			MobileParty partyBelongedTo = key.PartyBelongedTo;
			Vec2 position2D = partyBelongedTo.GetPosition2D();
			float num = (position2D).Distance(MobileParty.MainParty.GetPosition2D());
			if (num <= 3f)
			{
				try
				{
					if (mapEvent.CanPartyJoinBattle(partyBelongedTo.Party, val))
					{
						partyBelongedTo.Party.MapEventSide = mapEvent.GetMapEventSide(val);
						LogMessage($"Added {key.Name}'s party to battle on {val} side (distance: {num:F1})");
					}
					else
					{
						LogMessage($"{key.Name} cannot join battle (faction relations prevent joining)");
					}
				}
				catch (Exception ex)
				{
					LogMessage($"ERROR adding {key.Name} to battle: {ex.Message}");
				}
			}
			else
			{
				LogMessage($"{key.Name} too far from battle (distance: {num:F1})");
			}
		}
	}

	public List<string> GetActiveFollowingHeroIds()
	{
		List<string> list = new List<string>();
		try
		{
			foreach (KeyValuePair<Hero, List<AIActionBase>> item in _activeActions.ToList())
			{
				Hero key = item.Key;
				List<AIActionBase> value = item.Value;
				AIActionBase aIActionBase = value.FirstOrDefault((AIActionBase a) => a.ActionName == "follow_player");
				if (aIActionBase != null && aIActionBase.IsActive)
				{
					list.Add(((MBObjectBase)key).StringId);
				}
			}
			LogMessage(string.Format("[SAVE] Found {0} active follow actions: {1}", list.Count, string.Join(", ", list)));
		}
		catch (Exception ex)
		{
			LogMessage("[ERROR] GetActiveFollowingHeroIds failed: " + ex.Message);
		}
		return list;
	}

	public void RestoreFollowingActions(List<string> heroStringIds)
	{
		if (heroStringIds == null || heroStringIds.Count == 0)
		{
			LogMessage("[LOAD] No following actions to restore");
			return;
		}
		try
		{
			LogMessage($"[LOAD] Restoring {heroStringIds.Count} follow actions");
			foreach (string heroId in heroStringIds)
			{
				try
				{
					Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == heroId));
					if (val == null)
					{
						LogMessage("[LOAD] Hero with StringId '" + heroId + "' not found, skipping");
					}
					else if (!val.IsAlive)
					{
						LogMessage($"[LOAD] Hero {val.Name} is dead, skipping");
					}
					else if (StartAction(val, "follow_player"))
					{
						LogMessage($"[LOAD] Restored follow action for {val.Name}");
					}
					else
					{
						LogMessage($"[LOAD] Failed to restore follow action for {val.Name}");
					}
				}
				catch (Exception ex)
				{
					LogMessage("[ERROR] Failed to restore follow action for hero '" + heroId + "': " + ex.Message);
				}
			}
			LogMessage("[LOAD] Follow actions restoration completed");
		}
		catch (Exception ex2)
		{
			LogMessage("[ERROR] RestoreFollowingActions failed: " + ex2.Message);
		}
	}

	private void CreateLocationCharacterForNotable(Hero notable, Settlement settlement)
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		if (notable == null || settlement == null || LocationComplex.Current == null)
		{
			LogMessage($"Cannot create LocationCharacter for notable: notable={((notable != null) ? notable.Name : null)}, settlement={((settlement != null) ? settlement.Name : null)}, LocationComplex={LocationComplex.Current != null}");
			return;
		}
		try
		{
			LocationCharacter locationCharacterOfHero = LocationComplex.Current.GetLocationCharacterOfHero(notable);
			if (locationCharacterOfHero != null)
			{
				LogMessage($"LocationCharacter already exists for notable {notable.Name}");
				return;
			}
			Location val = null;
			val = ((!settlement.IsFortification) ? settlement.LocationComplex.GetLocationWithId("village_center") : settlement.LocationComplex.GetLocationWithId("center"));
			if (val == null)
			{
				LogMessage($"Could not find target location for notable {notable.Name} in settlement {settlement.Name}");
				return;
			}
			AgentData val2 = new AgentData((IAgentOriginBase)new SimpleAgentOrigin((BasicCharacterObject)(object)notable.CharacterObject, -1, (Banner)null, default(UniqueTroopDescriptor)));
			Monster monsterWithSuffix = FaceGen.GetMonsterWithSuffix(((BasicCharacterObject)notable.CharacterObject).Race, "_settlement");
			val2.Monster(monsterWithSuffix);
			val2.NoHorses(true);
			IFaction mapFaction = notable.MapFaction;
			uint num = ((mapFaction != null) ? mapFaction.Color : 4291609515u);
			uint num2 = ((mapFaction != null) ? mapFaction.Color : 4291609515u);
			val2.ClothingColor1(num).ClothingColor2(num2);
			string text = "";
			if (settlement.IsFortification)
			{
				text = (notable.IsArtisan ? "sp_notable_artisan" : (notable.IsMerchant ? "sp_notable_merchant" : (notable.IsPreacher ? "sp_notable_preacher" : (notable.IsGangLeader ? "sp_notable_gangleader" : (notable.IsRuralNotable ? "sp_notable_rural_notable" : "sp_notable")))));
				MBReadOnlyList<Workshop> ownedWorkshops = notable.OwnedWorkshops;
				if (((List<Workshop>)(object)ownedWorkshops).Count > 0)
				{
					foreach (Workshop item in (List<Workshop>)(object)ownedWorkshops)
					{
						if (!item.WorkshopType.IsHidden)
						{
							text = text + "_" + ((SettlementArea)item).Tag;
							break;
						}
					}
				}
			}
			else
			{
				text = "sp_notable_rural_notable";
			}
			string text2 = "";
			if (settlement.IsFortification)
			{
				string text3 = (notable.IsArtisan ? "_villager_artisan" : (notable.IsMerchant ? "_villager_merchant" : (notable.IsPreacher ? "_villager_preacher" : (notable.IsGangLeader ? "_villager_gangleader" : (notable.IsRuralNotable ? "_villager_ruralnotable" : (notable.IsFemale ? "_lord" : "_villager_merchant"))))));
				text2 = ActionSetCode.GenerateActionSetNameWithSuffix(val2.AgentMonster, notable.IsFemale, text3);
			}
			IAgentBehaviorManager agentBehaviorManager = SandBoxManager.Instance.AgentBehaviorManager;
			AddBehaviorsDelegate val3 = new AddBehaviorsDelegate(agentBehaviorManager.AddFixedCharacterBehaviors);
			LocationCharacter val4 = new LocationCharacter(val2, val3, text, true, (CharacterRelations)0, text2, true, false, (ItemObject)null, false, false, true, (AfterAgentCreatedDelegate)null, false);
			val.AddCharacter(val4);
			LogMessage($"Successfully created LocationCharacter for notable {notable.Name} in {settlement.Name} at location {val.StringId}");
		}
		catch (Exception ex)
		{
			LogMessage($"Error creating LocationCharacter for notable {notable.Name}: {ex.Message}\n{ex.StackTrace}");
		}
	}
}
