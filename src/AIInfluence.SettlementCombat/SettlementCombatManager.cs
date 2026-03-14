using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Behaviors.AIActions;
using AIInfluence.SettlementCombat.PhrasesDisplay;
using AIInfluence.SettlementCombat.PhrasesDisplay.Popup;
using AIInfluence.Util;
using Helpers;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using SandBox.Conversation.MissionLogics;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.SettlementCombat;

public class SettlementCombatManager
{
	private class PlayerKnockoutInfo
	{
		public bool IsAggressor;

		public float PlayerPower;

		public float EnemyPower;

		public Settlement Settlement;
	}

	private readonly AIInfluenceBehavior _behavior;

	private readonly CombatPromptGenerator _promptGenerator;

	private readonly CombatStatistics _statistics;

	private readonly DefenderSpawner _defenderSpawner;

	private readonly CivilianBehavior _civilianBehavior;

	private readonly PostCombatEventCreator _eventCreator;

	private readonly SettlementCombatLogger _logger;

	private readonly Random _random = new Random();

	private bool _villagePostCombatInquiryShown = false;

	private ActiveCombat _activeCombat;

	private bool _combatEnded = false;

	private bool _pendingEscapePenalty = false;

	private int _escapeTotalTroops = 0;

	private int _escapeNearbyTroops = 0;

	private ActiveCombat _savedCombatForTransition = null;

	private string _previousSceneName = "";

	private int _currentRetryAttempt = 0;

	private int _currentPostCombatRetryAttempt = 0;

	private ActiveCombat _postCombatRetryData = null;

	private CombatResult _postCombatRetryResult = null;

	private bool _missionModeChanged = false;

	private MissionMode _previousMissionMode = (MissionMode)0;

	private const int MAX_RETRY_ATTEMPTS = 3;

	private const float RETRY_DELAY_SECONDS = 5f;

	private PlayerKnockoutInfo _playerKnockout;

	public bool HasActiveCombat => _activeCombat != null;

	public SettlementCombatManager(AIInfluenceBehavior behavior)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		_behavior = behavior;
		_logger = SettlementCombatLogger.Instance;
		_promptGenerator = new CombatPromptGenerator(behavior);
		_statistics = new CombatStatistics(behavior);
		_defenderSpawner = new DefenderSpawner(behavior);
		_civilianBehavior = new CivilianBehavior(behavior);
		_eventCreator = new PostCombatEventCreator(behavior);
		_defenderSpawner.SetStatistics(_statistics);
		CampaignEvents.OnMissionStartedEvent.AddNonSerializedListener((object)this, (Action<IMission>)OnMissionStarted);
		CampaignEvents.OnMissionEndedEvent.AddNonSerializedListener((object)this, (Action<IMission>)OnMissionEnded);
	}

	public void OnPlayerKnockedOut(float playerPower, float enemyPower)
	{
		try
		{
			if (_activeCombat != null && _activeCombat.Settlement != null)
			{
				string text = _activeCombat.Analysis?.AggressorStringId;
				int num;
				if (!(text == "main_hero"))
				{
					Hero mainHero = Hero.MainHero;
					num = ((text == ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null)) ? 1 : 0);
				}
				else
				{
					num = 1;
				}
				bool flag = (byte)num != 0;
				_playerKnockout = new PlayerKnockoutInfo
				{
					IsAggressor = flag,
					PlayerPower = playerPower,
					EnemyPower = enemyPower,
					Settlement = _activeCombat.Settlement
				};
				_logger.Log($"Player knocked out in settlement combat. IsAggressor={flag}, PlayerPower={playerPower:F1}, EnemyPower={enemyPower:F1}");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("OnPlayerKnockedOut", ex.Message, ex);
		}
	}

	private void OnMissionStarted(IMission mission)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (_savedCombatForTransition == null)
			{
				return;
			}
			if (Settlement.CurrentSettlement == null || Settlement.CurrentSettlement != _savedCombatForTransition.Settlement)
			{
				_logger.Log("Player left settlement, clearing saved combat");
				_savedCombatForTransition = null;
				return;
			}
			_logger.Log("=== LOCATION TRANSITION DETECTED ===");
			_logger.Log("Previous location: " + _previousSceneName);
			SettlementCombatLogger logger = _logger;
			Mission current = Mission.Current;
			logger.Log("Current location: " + (((current != null) ? current.SceneName : null) ?? "Unknown"));
			_logger.Log($"Continuing combat from {_savedCombatForTransition.LocationType} to current location");
			_activeCombat = _savedCombatForTransition;
			_savedCombatForTransition = null;
			if (Agent.Main != null)
			{
				_activeCombat.PlayerEntryPosition = Agent.Main.Position;
				_logger.Log($"Saved player entry position in new location: {_activeCombat.PlayerEntryPosition}");
			}
			_activeCombat.LocationType = DetermineLocationType();
			_logger.Log($"New location type: {_activeCombat.LocationType}");
			ContinueCombatInNewLocation();
		}
		catch (Exception ex)
		{
			_logger.LogError("OnMissionStarted", ex.Message, ex);
			_savedCombatForTransition = null;
		}
	}

	private void OnMissionEnded(IMission mission)
	{
		try
		{
			if (_activeCombat == null)
			{
				return;
			}
			if (!_combatEnded)
			{
				Mission current = Mission.Current;
				_previousSceneName = ((current != null) ? current.SceneName : null) ?? "";
				if (PlayerEncounter.InsideSettlement && _activeCombat.LocationType == LocationType.SmallIndoor)
				{
					_logger.Log("=== SAVING COMBAT FOR TRANSITION ===");
					_logger.Log("Combat in small location ending, saving state for potential continuation");
					_logger.Log($"Defenders spawned in small location: {_activeCombat.DefendersSpawnedInSmallLocation}");
					if (Mission.Current != null)
					{
						_activeCombat.NPCsFromSmallLocation = new List<string>();
						foreach (Agent item in (List<Agent>)(object)Mission.Current.Agents)
						{
							if (item == null || !item.IsActive() || !item.IsHuman || item == Agent.Main)
							{
								continue;
							}
							BasicCharacterObject character = item.Character;
							CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
							if (val == null)
							{
								continue;
							}
							if (_civilianBehavior != null && _civilianBehavior.IsAgentUnderCivilianControl(item))
							{
								_logger.Log("Skipping civilian from small location (already controlled): " + item.Name);
							}
							else if (!((BasicCharacterObject)val).IsHero && IsDefenderOrMilitary(val))
							{
								string stringId = ((MBObjectBase)val).StringId;
								if (!string.IsNullOrEmpty(stringId) && !_activeCombat.NPCsFromSmallLocation.Contains(stringId))
								{
									_activeCombat.NPCsFromSmallLocation.Add(stringId);
									_logger.Log("Saved military NPC from small location: " + item.Name + " (" + stringId + ") - NOT a hero");
								}
							}
							else if (((BasicCharacterObject)val).IsHero)
							{
								_logger.Log("Skipping hero from small location: " + item.Name + " - heroes stay in small location");
							}
						}
						_logger.Log($"Total military NPCs saved from small location (excluding heroes): {_activeCombat.NPCsFromSmallLocation.Count}");
					}
					_savedCombatForTransition = _activeCombat;
					_activeCombat = null;
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("OnMissionEnded", ex.Message, ex);
		}
		if (_activeCombat != null)
		{
			_behavior.GetDelayedTaskManager().AddTask(0.1, delegate
			{
				try
				{
					if (_activeCombat != null && Mission.Current == null)
					{
						bool insideSettlement = PlayerEncounter.InsideSettlement;
						int num;
						if (Settlement.CurrentSettlement == null)
						{
							MobileParty mainParty = MobileParty.MainParty;
							num = ((((mainParty != null) ? mainParty.CurrentSettlement : null) != null) ? 1 : 0);
						}
						else
						{
							num = 1;
						}
						bool flag = (byte)num != 0;
						if (!insideSettlement && !flag)
						{
							_logger.Log("OnMissionEnded: Player detected on world map during active settlement combat. Finalizing.");
							OnPlayerLeavesSettlement();
						}
						else if (insideSettlement && Mission.Current == null && !ForcePlayerExitAfterCombat("OnMissionEnded_Escape"))
						{
							_logger.Log("OnMissionEnded: Forced exit skipped/failed while player escape detected. Finalizing manually.");
							OnPlayerLeavesSettlement();
						}
					}
				}
				catch (Exception ex2)
				{
					_logger.LogError("OnMissionEnded_DelayedCheck", ex2.Message, ex2);
				}
			});
		}
		if (_activeCombat != null)
		{
			ScheduleSettlementEscapeMonitor();
		}
	}

	private void ScheduleSettlementEscapeMonitor()
	{
		_behavior.GetDelayedTaskManager().AddTask(1.0, delegate
		{
			try
			{
				if (_activeCombat != null)
				{
					if (Mission.Current != null)
					{
						ScheduleSettlementEscapeMonitor();
					}
					else
					{
						bool insideSettlement = PlayerEncounter.InsideSettlement;
						int num;
						if (Settlement.CurrentSettlement == null)
						{
							MobileParty mainParty = MobileParty.MainParty;
							num = ((((mainParty != null) ? mainParty.CurrentSettlement : null) != null) ? 1 : 0);
						}
						else
						{
							num = 1;
						}
						bool flag = (byte)num != 0;
						if (insideSettlement || flag)
						{
							_logger.Log("[EscapeMonitor] Player flagged as inside settlement without mission – forcing exit");
							if (!ForcePlayerExitAfterCombat("EscapeMonitor"))
							{
								OnPlayerLeavesSettlement();
							}
						}
						else
						{
							OnPlayerLeavesSettlement();
						}
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("ScheduleSettlementEscapeMonitor", ex.Message, ex);
			}
		});
	}

	private void ContinueCombatInNewLocation()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_logger.Log("=== CONTINUING COMBAT IN NEW LOCATION ===");
			if (Mission.Current != null)
			{
				if ((int)Mission.Current.Mode != 2)
				{
					_previousMissionMode = Mission.Current.Mode;
					Mission.Current.SetMissionMode((MissionMode)2, false);
					_missionModeChanged = true;
					_logger.Log($"Mission mode set to Battle for continued combat (previous: {_previousMissionMode})");
				}
				else if (!_missionModeChanged)
				{
					_previousMissionMode = (MissionMode)2;
					_missionModeChanged = true;
					_logger.Log("Mission already in Battle mode during transition; preserving state");
				}
			}
			_behavior.GetDelayedTaskManager().AddTask(0.20000000298023224, delegate
			{
				SetupTeamHostility();
			});
			try
			{
				Mission current = Mission.Current;
				MissionConversationLogic val = ((current != null) ? current.GetMissionBehavior<MissionConversationLogic>() : null);
				if (val != null)
				{
					val.DisableStartConversation(true);
				}
				_logger.Log("MissionConversationLogic: auto-start disabled during combat (transition)");
			}
			catch
			{
			}
			if (Mission.Current != null)
			{
				CombatPhrasesDisplay combatPhrasesDisplay = new CombatPhrasesDisplay(_activeCombat.Analysis);
				Mission.Current.AddMissionBehavior((MissionBehavior)(object)combatPhrasesDisplay);
				_logger.Log("Phrases display logic added to mission (transition)");
				CombatPhrasePopupView.EnsureCreated();
			}
			if (_activeCombat.Analysis != null && _activeCombat.Analysis.NeedsDefenders)
			{
				int defendersSpawnedInSmallLocation = _activeCombat.DefendersSpawnedInSmallLocation;
				_logger.Log($"Spawning {defendersSpawnedInSmallLocation} defenders at entrance (matching small location count)");
				if (defendersSpawnedInSmallLocation > 0)
				{
					_defenderSpawner.SpawnGuardsForTransition(_activeCombat, defendersSpawnedInSmallLocation);
				}
				if (_activeCombat.LocationType == LocationType.LargeOutdoor)
				{
					_defenderSpawner.HandleTransitionToLargeLocation(_activeCombat);
				}
			}
			else
			{
				_logger.Log("Skipping defender spawn on transition: needs_defenders = false");
			}
			if (_activeCombat.Analysis != null && _activeCombat.Analysis.CivilianPanic)
			{
				_behavior.GetDelayedTaskManager().AddTask(2.0, delegate
				{
					try
					{
						bool flag = HasChildrenInLocation();
						_logger.Log($"Initializing civilian panic in new location after transition (hasChildren: {flag})");
						_civilianBehavior.InitiatePanic(_activeCombat, flag);
					}
					catch (Exception ex2)
					{
						_logger.LogError("InitiatePanicAfterTransition", ex2.Message, ex2);
					}
				});
			}
			else
			{
				_logger.Log("Skipping civilian panic initialization: civilian_panic = false");
			}
			PreparePlayerTroopsForBattle();
			_behavior.GetDelayedTaskManager().AddTask(0.5, delegate
			{
				PrepareExistingDefenders();
			});
			if (_activeCombat.NPCsFromSmallLocation != null && _activeCombat.NPCsFromSmallLocation.Count > 0)
			{
				_logger.Log($"Scheduling small-location survivors spawn in 8s (count: {_activeCombat.NPCsFromSmallLocation.Count})");
				_behavior.GetDelayedTaskManager().AddTask(8.0, delegate
				{
					_logger.Log("8 seconds passed, spawning military NPCs from small location");
					SpawnNPCsFromSmallLocation();
				});
			}
			StartCombatTracking();
			_logger.Log("Combat successfully continued in new location");
		}
		catch (Exception ex)
		{
			_logger.LogError("ContinueCombatInNewLocation", ex.Message, ex);
		}
		_behavior.GetDelayedTaskManager().AddTask(1.0, delegate
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Invalid comparison between Unknown and I4
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				if (Mission.Current != null && (int)Mission.Current.Mode != 2)
				{
					_logger.Log($"[Retry] Mission mode is still {Mission.Current.Mode}, forcing Battle again");
					_previousMissionMode = Mission.Current.Mode;
					Mission.Current.SetMissionMode((MissionMode)2, false);
					_missionModeChanged = true;
				}
			}
			catch (Exception ex2)
			{
				_logger.LogError("EnsureBattleMode_Retry", ex2.Message, ex2);
			}
		});
	}

	public DefenderSpawner GetDefenderSpawner()
	{
		return _defenderSpawner;
	}

	public bool IsActiveCombat()
	{
		return (_activeCombat != null && !_combatEnded) || _savedCombatForTransition != null;
	}

	public bool ShouldBlockMissionExit()
	{
		if (!IsActiveCombat())
		{
			return false;
		}
		if (_activeCombat?.Analysis == null)
		{
			return true;
		}
		if (!_activeCombat.Analysis.NeedsDefenders && !_activeCombat.Analysis.CivilianPanic)
		{
			return false;
		}
		return true;
	}

	public CivilianBehavior GetCivilianBehavior()
	{
		return _civilianBehavior;
	}

	public bool IsCombatPromptReady()
	{
		if (_activeCombat != null)
		{
			return _activeCombat.Analysis != null;
		}
		if (_savedCombatForTransition != null)
		{
			return _savedCombatForTransition.Analysis != null;
		}
		return false;
	}

	public void InitiateCombat(Hero npc, NPCContext context, CombatTriggerType triggerType, string npcResponse = null)
	{
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		try
		{
			_logger.Log("=== InitiateCombat Called ===");
			_logger.Log($"  TriggerType: {triggerType}");
			_logger.Log("  NPC: " + (((npc == null) ? null : ((object)npc.Name)?.ToString()) ?? "NULL"));
			_logger.Log("  Context: " + ((context != null) ? "Present" : "NULL"));
			_logger.Log("  Response: " + (string.IsNullOrEmpty(npcResponse) ? "EMPTY/NULL" : npcResponse.Substring(0, Math.Min(50, npcResponse.Length))));
			if (_activeCombat != null)
			{
				_logger.Log("Combat already active, ignoring new combat initiation");
				return;
			}
			if (Mission.Current == null)
			{
				_logger.Log("ERROR: No active mission, cannot initiate settlement combat");
				return;
			}
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (currentSettlement == null)
			{
				_logger.Log("ERROR: No current settlement, cannot initiate settlement combat");
				_logger.Log("  Mission.Current: " + ((Mission.Current != null) ? "Present" : "NULL"));
				_logger.Log("  Settlement.CurrentSettlement: NULL - this is likely the issue!");
				return;
			}
			_logger.LogCombatInitiated(((object)currentSettlement.Name).ToString(), ((MBObjectBase)currentSettlement).StringId, triggerType.ToString(), ((npc == null) ? null : ((object)npc.Name)?.ToString()) ?? "Unknown", ((npc != null) ? ((MBObjectBase)npc).StringId : null) ?? "unknown");
			_currentRetryAttempt = 0;
			LocationType locationType = DetermineLocationType();
			_activeCombat = new ActiveCombat
			{
				Settlement = currentSettlement,
				TriggerNPC = npc,
				TriggerContext = context,
				TriggerType = triggerType,
				TriggerResponse = npcResponse,
				StartTime = CampaignTime.Now,
				LocationType = locationType,
				DefendersSpawnedInSmallLocation = 0,
				NPCsFromSmallLocation = new List<string>()
			};
			_activeCombat.PlayerCompanions = CollectCompanionsForCombat(currentSettlement);
			_logger.Log($"Detected {_activeCombat.PlayerCompanions.Count} companions/followers near player for combat context");
			_logger.Log($"Combat location type: {locationType}");
			SendSituationAnalysisPrompt();
		}
		catch (Exception ex)
		{
			_logger.LogError("InitiateCombat", ex.Message, ex);
		}
	}

	private async void SendSituationAnalysisPrompt()
	{
		try
		{
			_logger.Log($"Generating situation analysis prompt for {_activeCombat.Settlement.Name}... (Attempt {_currentRetryAttempt + 1}/{3})");
			string prompt = _promptGenerator.GenerateSituationAnalysisPrompt(_activeCombat);
			_logger.LogSituationAnalysisPrompt(((MBObjectBase)_activeCombat.Settlement).StringId, prompt);
			_logger.Log("Sending prompt to AI for situation analysis");
			string aiResponse = await _behavior.SendAIRequestRaw(prompt);
			_logger.Log("=== AI Response Received ===");
			_logger.Log($"  Response is null: {aiResponse == null}");
			_logger.Log($"  Response is empty: {string.IsNullOrEmpty(aiResponse)}");
			_logger.Log($"  Response length: {aiResponse?.Length ?? 0}");
			_logger.Log(string.Format("  Starts with Error: {0}", aiResponse?.StartsWith("Error:") ?? false));
			_logger.Log("  Full response:");
			_logger.Log("---START---");
			_logger.Log(aiResponse ?? "");
			_logger.Log("---END---");
			if (string.IsNullOrEmpty(aiResponse) || aiResponse.StartsWith("Error:"))
			{
				_logger.LogError("SendSituationAnalysisPrompt", "AI returned empty or error response");
				HandleAIError();
				return;
			}
			_logger.Log("AI response valid, proceeding to parse");
			CombatSituationAnalysis analysis = ParseSituationAnalysis(aiResponse);
			if (analysis == null)
			{
				_logger.LogError("SendSituationAnalysisPrompt", "Failed to parse AI analysis");
				_logger.Log("---RAW AI RESPONSE START---");
				_logger.Log(aiResponse ?? "");
				_logger.Log("---RAW AI RESPONSE END---");
				HandleAIError();
			}
			else
			{
				_currentRetryAttempt = 0;
				ProcessAIAnalysis(analysis);
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError("SendSituationAnalysisPrompt", ex2.Message, ex2);
			HandleAIError();
		}
	}

	private List<Hero> CollectCompanionsForCombat(Settlement settlement)
	{
		HashSet<Hero> hashSet = new HashSet<Hero>();
		try
		{
			if (settlement == null)
			{
				return new List<Hero>();
			}
			foreach (Hero item in (List<Hero>)(object)Hero.AllAliveHeroes)
			{
				if (item != null && item != Hero.MainHero && !item.IsDead && !item.IsPrisoner && (item.CompanionOf == Clan.PlayerClan || item == Hero.MainHero.Spouse) && IsHeroPresentWithPlayer(item, settlement))
				{
					hashSet.Add(item);
				}
			}
			List<Hero> list = AIActionManager.Instance?.GetHeroesFollowingPlayerInSettlement(settlement);
			if (list != null)
			{
				foreach (Hero item2 in list)
				{
					if (item2 != null && item2 != Hero.MainHero && !item2.IsDead && !item2.IsPrisoner && IsHeroPresentWithPlayer(item2, settlement))
					{
						hashSet.Add(item2);
					}
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("CollectCompanionsForCombat", ex.Message, ex);
		}
		return (from h in hashSet
			where h != null && !string.IsNullOrEmpty(((MBObjectBase)h).StringId)
			orderby ((object)h.Name)?.ToString()
			select h).ToList();
	}

	private bool IsHeroPresentWithPlayer(Hero hero, Settlement settlement)
	{
		if (hero == null)
		{
			return false;
		}
		if (hero.PartyBelongedTo == MobileParty.MainParty)
		{
			return true;
		}
		if (settlement != null)
		{
			if (hero.CurrentSettlement == settlement || hero.StayingInSettlement == settlement)
			{
				return true;
			}
			MobileParty partyBelongedTo = hero.PartyBelongedTo;
			if (((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null) == settlement)
			{
				return true;
			}
		}
		if (Mission.Current != null)
		{
			return ((IEnumerable<Agent>)Mission.Current.Agents).Any((Agent agent) => agent != null && agent.IsActive() && agent.Character != null && ((MBObjectBase)agent.Character).StringId == ((MBObjectBase)hero).StringId);
		}
		return false;
	}

	private void HandleAIError()
	{
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		_currentRetryAttempt++;
		if (_currentRetryAttempt < 3)
		{
			_logger.Log($"Retrying AI request in {5f} seconds... (Attempt {_currentRetryAttempt + 1}/{3})");
			TextObject val = new TextObject("{=AIInfluence_SettlementCombat_Retry}[AI Influence] Settlement combat analysis failed (attempt {current}/{max}). Retrying in {seconds} sec.", (Dictionary<string, object>)null).SetTextVariable("current", _currentRetryAttempt).SetTextVariable("max", 3).SetTextVariable("seconds", 5f, 2);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.RedAIInfluence));
			_behavior.GetDelayedTaskManager().AddTask(5.0, delegate
			{
				if (_activeCombat != null)
				{
					SendSituationAnalysisPrompt();
				}
			});
			return;
		}
		_logger.LogError("HandleAIError", $"All {3} retry attempts failed. Resetting combat state.");
		TextObject val2 = new TextObject("{=AIInfluence_SettlementCombat_Failed}[AI Influence] Settlement combat analysis failed after all attempts. Try starting combat again.", (Dictionary<string, object>)null);
		InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), ExtraColors.RedAIInfluence));
		if (_activeCombat?.TriggerContext != null)
		{
			_activeCombat.TriggerContext.PendingSettlementCombat = null;
			_activeCombat.TriggerContext.SettlementCombatResponse = null;
			_activeCombat.TriggerContext.PendingDeath = null;
			_activeCombat.TriggerContext.KillerStringId = null;
			_activeCombat.TriggerContext.CombatResponse = null;
			_activeCombat.TriggerContext.IsSurrendering = false;
			_activeCombat.TriggerContext.NegativeToneCount = 0;
			_activeCombat.TriggerContext.EscalationState = "neutral";
			if (_activeCombat.TriggerNPC != null)
			{
				_behavior.SaveNPCContext(((MBObjectBase)_activeCombat.TriggerNPC).StringId, _activeCombat.TriggerNPC, _activeCombat.TriggerContext);
				_logger.Log($"NPC context flags cleared for {_activeCombat.TriggerNPC.Name} - dialogue available again");
			}
		}
		Campaign current = Campaign.Current;
		if (current != null)
		{
			ConversationManager conversationManager = current.ConversationManager;
			if (((conversationManager != null) ? new bool?(conversationManager.IsConversationInProgress) : ((bool?)null)) == true)
			{
				Campaign.Current.ConversationManager.EndConversation();
			}
		}
		_activeCombat = null;
		_combatEnded = false;
		_currentRetryAttempt = 0;
	}

	private CombatSituationAnalysis ParseSituationAnalysis(string aiResponse)
	{
		try
		{
			_logger.Log("Parsing AI response...");
			_logger.Log($"Raw response length: {aiResponse?.Length ?? 0}");
			string text = JsonCleaner.CleanJsonGeneric(aiResponse);
			if (string.IsNullOrEmpty(text))
			{
				_logger.LogError("ParseSituationAnalysis", "JsonCleaner returned empty/null result");
				_logger.Log("---RAW RESPONSE START---");
				_logger.Log(aiResponse ?? "");
				_logger.Log("---RAW RESPONSE END---");
				return null;
			}
			_logger.Log($"Cleaned response length: {text.Length}");
			_logger.Log("---CLEANED RESPONSE START---");
			_logger.Log(text ?? "");
			_logger.Log("---CLEANED RESPONSE END---");
			CombatSituationAnalysis combatSituationAnalysis = JsonConvert.DeserializeObject<CombatSituationAnalysis>(text);
			if (combatSituationAnalysis == null)
			{
				_logger.LogError("ParseSituationAnalysis", "Deserialization returned null");
				return null;
			}
			if (combatSituationAnalysis.NeedsDefenders && !combatSituationAnalysis.CivilianPanic)
			{
				_logger.Log("WARNING: needs_defenders = true but civilian_panic = false, correcting to civilian_panic = true");
				combatSituationAnalysis.CivilianPanic = true;
			}
			_logger.Log($"Successfully parsed combat situation analysis (needs_defenders: {combatSituationAnalysis.NeedsDefenders}, civilian_panic: {combatSituationAnalysis.CivilianPanic})");
			return combatSituationAnalysis;
		}
		catch (Exception ex)
		{
			_logger.LogError("ParseSituationAnalysis", "Failed to parse: " + ex.Message, ex);
			_logger.Log("Raw response: " + aiResponse);
			return null;
		}
	}

	public void ProcessAIAnalysis(CombatSituationAnalysis analysis)
	{
		try
		{
			_logger.Log("Processing AI analysis...");
			_logger.Log("Aggressor: " + analysis.AggressorStringId + ", Defender: " + analysis.DefenderStringId);
			_logger.Log($"Witnesses: {analysis.Witnesses?.Count ?? 0}");
			_logger.LogAnalysisResult(analysis.AggressorStringId, analysis.DefenderStringId, analysis.Witnesses?.Count ?? 0, analysis.NeedsDefenders, analysis.Lords?.Count ?? 0);
			if (analysis.Lords != null && analysis.Lords.Any())
			{
				_logger.Log("Lords intervention details:");
				foreach (LordIntervention lord in analysis.Lords)
				{
					_logger.Log("  - Lord " + lord.StringId + ":");
					_logger.Log("    * Side: " + lord.Side);
					_logger.Log("    * Reason: " + lord.InterventionReason);
					_logger.Log("    * Arrival phrase: \"" + lord.ArrivalPhrase + "\"");
				}
			}
			_activeCombat.Analysis = analysis;
			ApplyCompanionDecisionsFromAnalysis(analysis);
			CloseDialogAndStartCombat();
		}
		catch (Exception ex)
		{
			_logger.LogError("ProcessAIAnalysis", ex.Message, ex);
		}
	}

	private void CloseDialogAndStartCombat()
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Invalid comparison between Unknown and I4
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Campaign current = Campaign.Current;
			if (current != null)
			{
				ConversationManager conversationManager = current.ConversationManager;
				if (((conversationManager != null) ? new bool?(conversationManager.IsConversationInProgress) : ((bool?)null)) == true)
				{
					Campaign.Current.ConversationManager.EndConversation();
					_logger.Log("Conversation ended after AI analysis");
				}
			}
			if (!string.IsNullOrEmpty(_activeCombat.Analysis?.SituationDescription))
			{
				InformationManager.DisplayMessage(new InformationMessage(_activeCombat.Analysis.SituationDescription, Colors.Gray));
			}
			if (_activeCombat.TriggerType == CombatTriggerType.RoleplayDeath)
			{
				_logger.Log("Roleplay death detected - killing character before mode switch");
				try
				{
					Hero triggerNPC = _activeCombat.TriggerNPC;
					NPCContext context = _activeCombat.TriggerContext;
					if (triggerNPC != null && !triggerNPC.IsDead)
					{
						Hero val2 = null;
						if (!string.IsNullOrEmpty(context?.KillerStringId))
						{
							val2 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == context.KillerStringId));
							if (val2 != null)
							{
								_logger.Log($"Killer identified: {val2.Name} ({context.KillerStringId})");
							}
							else
							{
								_logger.Log("Killer with ID " + context.KillerStringId + " not found");
							}
						}
						else
						{
							_logger.Log("Natural death (no killer)");
						}
						_behavior.KillCharacterHeroPublic(triggerNPC, val2, killedInAction: false);
						_logger.Log($"Character {triggerNPC.Name} killed");
						if (context != null)
						{
							context.PendingDeath = null;
							context.KillerStringId = null;
							_behavior.SaveNPCContext(((MBObjectBase)triggerNPC).StringId, triggerNPC, context);
						}
					}
				}
				catch (Exception ex2)
				{
					_logger.LogError("KillCharacterAfterRoleplayDeath", ex2.Message, ex2);
					return;
				}
			}
			if (Mission.Current != null && (int)Mission.Current.Mode != 2)
			{
				_previousMissionMode = Mission.Current.Mode;
				Mission.Current.SetMissionMode((MissionMode)2, false);
				_missionModeChanged = true;
				_logger.Log($"Mission mode switched: {_previousMissionMode} -> Battle");
			}
			SetupTeamHostility();
			try
			{
				Mission current2 = Mission.Current;
				MissionConversationLogic val = ((current2 != null) ? current2.GetMissionBehavior<MissionConversationLogic>() : null);
				if (val != null)
				{
					val.DisableStartConversation(true);
				}
				_logger.Log("MissionConversationLogic: auto-start disabled during combat");
			}
			catch
			{
			}
			SpawnCombatParticipants();
			PreparePlayerTroopsForBattle();
			PrepareExistingDefenders();
			StartCombatTracking();
		}
		catch (Exception ex)
		{
			_logger.LogError("CloseDialogAndStartCombat", ex.Message, ex);
		}
	}

	private void ApplyCompanionDecisionsFromAnalysis(CombatSituationAnalysis analysis)
	{
		try
		{
			if (_activeCombat == null)
			{
				return;
			}
			if (_activeCombat.PlayerCompanions == null || !_activeCombat.PlayerCompanions.Any())
			{
				_activeCombat.CompanionDecisions.Clear();
				return;
			}
			Dictionary<string, CompanionCombatDecision> dictionary = new Dictionary<string, CompanionCombatDecision>();
			Dictionary<string, string> dictionary2 = analysis?.CompanionStance;
			if (dictionary2 != null)
			{
				foreach (string key in dictionary2.Keys)
				{
					if (!_activeCombat.PlayerCompanions.Any((Hero h) => ((h != null) ? ((MBObjectBase)h).StringId : null) == key))
					{
						_logger.Log("[COMPANION] AI returned stance for unknown hero " + key + ", ignoring entry");
					}
				}
			}
			foreach (Hero playerCompanion in _activeCombat.PlayerCompanions)
			{
				if (playerCompanion == null || string.IsNullOrEmpty(((MBObjectBase)playerCompanion).StringId))
				{
					continue;
				}
				CompanionCombatDecision decision = CompanionCombatDecision.StayOut;
				bool flag = false;
				if (dictionary2 != null && dictionary2.TryGetValue(((MBObjectBase)playerCompanion).StringId, out var value))
				{
					if (!TryParseCompanionDecision(value, out decision))
					{
						_logger.Log($"[COMPANION] Invalid stance '{value}' for {playerCompanion.Name}, defaulting to stay_out");
					}
				}
				else
				{
					_logger.Log($"[COMPANION] No stance provided for {playerCompanion.Name}, defaulting to stay_out");
				}
				dictionary[((MBObjectBase)playerCompanion).StringId] = decision;
				_logger.Log($"[COMPANION] Decision for {playerCompanion.Name} ({((MBObjectBase)playerCompanion).StringId}): {decision}");
			}
			_activeCombat.CompanionDecisions = dictionary;
		}
		catch (Exception ex)
		{
			_logger.LogError("ApplyCompanionDecisionsFromAnalysis", ex.Message, ex);
		}
	}

	private bool TryParseCompanionDecision(string value, out CompanionCombatDecision decision)
	{
		switch (value?.Trim().ToLowerInvariant())
		{
		case "support_player":
			decision = CompanionCombatDecision.SupportPlayer;
			return true;
		case "oppose_player":
			decision = CompanionCombatDecision.OpposePlayer;
			return true;
		case "stay_out":
			decision = CompanionCombatDecision.StayOut;
			return true;
		default:
			decision = CompanionCombatDecision.StayOut;
			return false;
		}
	}

	private void HandleCompanionAgentDecision(Agent agent, CompanionCombatDecision decision, bool playerIsAggressor, Agent aggressorAgent, ref int defendersFound)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (agent == null || Mission.Current == null)
			{
				return;
			}
			switch (decision)
			{
			case CompanionCombatDecision.SupportPlayer:
				if (Mission.Current.PlayerTeam != null && agent.Team != Mission.Current.PlayerTeam)
				{
					agent.SetTeam(Mission.Current.PlayerTeam, true);
				}
				WieldBestMeleeWeapon(agent);
				agent.SetWatchState((WatchState)2);
				agent.SetAgentFlags((AgentFlag)(agent.GetAgentFlags() | 8 | 0x10));
				if (!playerIsAggressor && aggressorAgent != null && aggressorAgent != Agent.Main)
				{
					agent.SetLookAgent(aggressorAgent);
				}
				_logger.Log("[COMPANION] " + agent.Name + " fights alongside the player");
				break;
			case CompanionCombatDecision.OpposePlayer:
				if (Mission.Current.DefenderTeam != null && agent.Team != Mission.Current.DefenderTeam)
				{
					agent.SetTeam(Mission.Current.DefenderTeam, true);
				}
				WieldBestMeleeWeapon(agent);
				agent.SetWatchState((WatchState)2);
				agent.SetAgentFlags((AgentFlag)(agent.GetAgentFlags() | 8 | 0x10));
				if (Agent.Main != null)
				{
					agent.SetLookAgent(Agent.Main);
				}
				defendersFound++;
				_logger.Log("[COMPANION] " + agent.Name + " turns against the player");
				TrySummonLordTroops(agent);
				break;
			case CompanionCombatDecision.StayOut:
				_civilianBehavior?.ForceAgentPanic(agent);
				_logger.Log("[COMPANION] " + agent.Name + " refuses to fight and stays out");
				break;
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("HandleCompanionAgentDecision", ex.Message, ex);
		}
	}

	private void TrySummonLordTroops(Agent agent)
	{
		try
		{
			if (agent == null || Mission.Current == null || _activeCombat == null)
			{
				return;
			}
			BasicCharacterObject character = agent.Character;
			CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
			if (val == null || !((BasicCharacterObject)val).IsHero || val.HeroObject == null)
			{
				return;
			}
			Hero heroObject = val.HeroObject;
			if (heroObject.IsWanderer || heroObject.Clan == null || heroObject.Clan == Clan.PlayerClan)
			{
				_logger.Log($"[LORD_TROOPS] Hero {heroObject.Name} is not a lord, skipping troop summon");
				return;
			}
			bool flag = heroObject.PartyBelongedTo != null && heroObject.PartyBelongedTo.MemberRoster != null && heroObject.PartyBelongedTo.MemberRoster.TotalManCount > 0;
			bool flag2 = heroObject.PartyBelongedTo != null && heroObject.PartyBelongedTo.Army != null && heroObject.PartyBelongedTo.Army.LeaderParty == heroObject.PartyBelongedTo;
			if (!flag && !flag2)
			{
				_logger.Log($"[LORD_TROOPS] Lord {heroObject.Name} has no party or army, skipping troop summon");
				return;
			}
			_logger.Log($"[LORD_TROOPS] Lord {heroObject.Name} has party/army - summoning troops (hasParty: {flag}, isArmyLeader: {flag2})");
			if (Mission.Current != null)
			{
				PlayerReinforcementMissionLogic missionBehavior = Mission.Current.GetMissionBehavior<PlayerReinforcementMissionLogic>();
				if (missionBehavior != null)
				{
					int num = missionBehavior.TransferLordTroopsToDefenderTeam(heroObject);
					if (num > 0)
					{
						_logger.Log($"[LORD_TROOPS] Transferred {num} already summoned troops from lord {heroObject.Name} to DefenderTeam");
					}
				}
			}
			_defenderSpawner.SpawnLordTroopsForHostileCompanion(heroObject, _activeCombat);
		}
		catch (Exception ex)
		{
			_logger.LogError("TrySummonLordTroops", ex.Message, ex);
		}
	}

	internal void ApplyCompanionDecisionToAgent(Agent agent)
	{
		try
		{
			if (agent == null || Mission.Current == null)
			{
				return;
			}
			BasicCharacterObject character = agent.Character;
			CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
			if (val == null || string.IsNullOrEmpty(((MBObjectBase)val).StringId))
			{
				return;
			}
			ActiveCombat activeCombat = _activeCombat ?? _savedCombatForTransition;
			if (activeCombat == null || activeCombat.CompanionDecisions == null || !activeCombat.CompanionDecisions.TryGetValue(((MBObjectBase)val).StringId, out var value))
			{
				return;
			}
			string aggressorId = activeCombat.Analysis?.AggressorStringId;
			int num;
			if (!(aggressorId == "main_hero"))
			{
				string text = aggressorId;
				Hero mainHero = Hero.MainHero;
				num = ((text == ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null)) ? 1 : 0);
			}
			else
			{
				num = 1;
			}
			bool flag = (byte)num != 0;
			Agent aggressorAgent = null;
			if (flag)
			{
				aggressorAgent = Agent.Main;
			}
			else if (!string.IsNullOrEmpty(aggressorId))
			{
				aggressorAgent = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.IsActive() && a.Character != null && ((MBObjectBase)a.Character).StringId == aggressorId));
			}
			int defendersFound = 0;
			HandleCompanionAgentDecision(agent, value, flag, aggressorAgent, ref defendersFound);
		}
		catch (Exception ex)
		{
			_logger.LogError("ApplyCompanionDecisionToAgent", ex.Message, ex);
		}
	}

	private void SpawnCombatParticipants()
	{
		try
		{
			CombatSituationAnalysis analysis = _activeCombat.Analysis;
			if (Mission.Current != null)
			{
				CombatPhrasesDisplay combatPhrasesDisplay = new CombatPhrasesDisplay(analysis);
				Mission.Current.AddMissionBehavior((MissionBehavior)(object)combatPhrasesDisplay);
				_logger.Log("Phrases display logic added to mission");
				CombatPhrasePopupView.EnsureCreated();
			}
			if (analysis.NeedsDefenders)
			{
				_defenderSpawner.SpawnDefenders(_activeCombat);
			}
			if (analysis.CivilianPanic)
			{
				bool hasChildren = HasChildrenInLocation();
				_civilianBehavior.InitiatePanic(_activeCombat, hasChildren);
			}
			else
			{
				_logger.Log("Skipping civilian panic initialization: civilian_panic = false");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnCombatParticipants", ex.Message, ex);
		}
	}

	private void SetupTeamHostility()
	{
		try
		{
			if (Mission.Current == null)
			{
				return;
			}
			Team playerTeam = Mission.Current.PlayerTeam;
			Team defenderTeam = Mission.Current.DefenderTeam;
			if (playerTeam == null || defenderTeam == null)
			{
				_logger.Log("ERROR: PlayerTeam or DefenderTeam is null, cannot setup team hostility");
				return;
			}
			string text = _activeCombat?.Analysis?.AggressorStringId;
			if (!(text == "main_hero"))
			{
				Hero mainHero = Hero.MainHero;
				if (!(text == ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null)))
				{
					playerTeam.SetIsEnemyOf(defenderTeam, false);
					defenderTeam.SetIsEnemyOf(playerTeam, false);
					_logger.Log("Team hostility set: Player is NOT aggressor, teams are neutral initially");
					return;
				}
			}
			playerTeam.SetIsEnemyOf(defenderTeam, true);
			defenderTeam.SetIsEnemyOf(playerTeam, true);
			_logger.Log("Team hostility set: Player is AGGRESSOR, DefenderTeam is hostile to PlayerTeam");
		}
		catch (Exception ex)
		{
			_logger.LogError("SetupTeamHostility", ex.Message, ex);
		}
	}

	private LocationType DetermineLocationType()
	{
		try
		{
			if (Mission.Current == null)
			{
				return LocationType.LargeOutdoor;
			}
			string text = Mission.Current.SceneName?.ToLower() ?? "";
			bool flag = text.Contains("lordshall") || (text.Contains("lord") && text.Contains("hall"));
			bool flag2 = text.Contains("tavern");
			bool flag3 = text.Contains("arena");
			bool flag4 = text.Contains("prison");
			bool flag5 = text.Contains("dungeon");
			bool flag6 = text.Contains("keep") && text.Contains("interior");
			if (flag || flag2 || flag3 || flag4 || flag5 || flag6)
			{
				_logger.Log($"Location type: SMALL INDOOR (LordsHall={flag}, Tavern={flag2}, Arena={flag3}, Prison={flag4}, Dungeon={flag5}, Keep={flag6})");
				return LocationType.SmallIndoor;
			}
			_logger.Log("Location type: LARGE OUTDOOR (city center, castle, village)");
			return LocationType.LargeOutdoor;
		}
		catch (Exception ex)
		{
			_logger.LogError("DetermineLocationType", ex.Message, ex);
			return LocationType.LargeOutdoor;
		}
	}

	private bool HasChildrenInLocation()
	{
		try
		{
			if (Mission.Current == null)
			{
				return false;
			}
			string text = Mission.Current.SceneName?.ToLower() ?? "";
			bool flag = text.Contains("tavern");
			bool flag2 = text.Contains("arena");
			bool flag3 = text.Contains("prison");
			bool flag4 = text.Contains("dungeon");
			bool flag5 = text.Contains("lordshall") || (text.Contains("lord") && text.Contains("hall"));
			bool flag6 = text.Contains("keep") && text.Contains("interior");
			bool flag7 = flag || flag2 || flag3 || flag4 || flag5 || flag6;
			if (flag7)
			{
				_logger.Log($"No children in this location: Tavern={flag}, Arena={flag2}, Prison={flag3}, Dungeon={flag4}, LordsHall={flag5}, Keep={flag6}");
			}
			return !flag7;
		}
		catch (Exception ex)
		{
			_logger.LogError("HasChildrenInLocation", ex.Message, ex);
			return false;
		}
	}

	private void PreparePlayerTroopsForBattle()
	{
		try
		{
			if (Mission.Current == null || Mission.Current.PlayerTeam == null)
			{
				return;
			}
			int num = 0;
			foreach (Agent item in (List<Agent>)(object)Mission.Current.PlayerTeam.ActiveAgents)
			{
				if (item != null && item.IsActive() && item.IsHuman)
				{
					WieldBestMeleeWeapon(item);
					item.SetWatchState((WatchState)2);
					num++;
				}
			}
			_logger.Log($"Player troops prepared for battle: {num} troops armed");
			PrepareNPCAttacker();
		}
		catch (Exception ex)
		{
			_logger.LogError("PreparePlayerTroopsForBattle", ex.Message, ex);
		}
	}

	private void PrepareExistingDefenders()
	{
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Invalid comparison between Unknown and I4
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Invalid comparison between Unknown and I4
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Invalid comparison between Unknown and I4
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current == null || _activeCombat == null)
			{
				return;
			}
			if (_activeCombat.Analysis != null && !_activeCombat.Analysis.CivilianPanic && !_activeCombat.Analysis.NeedsDefenders)
			{
				_logger.Log("Skipping PrepareExistingDefenders: NeedsDefenders=false AND CivilianPanic=false");
				return;
			}
			string aggressorId = _activeCombat.Analysis?.AggressorStringId;
			int num;
			if (!(aggressorId == "main_hero"))
			{
				string text = aggressorId;
				Hero mainHero = Hero.MainHero;
				num = ((text == ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null)) ? 1 : 0);
			}
			else
			{
				num = 1;
			}
			bool flag = (byte)num != 0;
			Agent val = null;
			if (flag)
			{
				val = Agent.Main;
			}
			else if (!string.IsNullOrEmpty(aggressorId))
			{
				val = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.IsActive() && a.Character != null && ((MBObjectBase)a.Character).StringId == aggressorId));
			}
			if (val == null)
			{
				_logger.Log("WARNING: Could not find aggressor agent, defenders may not have a specific target");
			}
			_logger.Log("Preparing existing defenders/guards/lords; aggressor: " + ((val != null) ? val.Name.ToString() : "UNKNOWN"));
			int defendersFound = 0;
			PlayerReinforcementMissionLogic missionBehavior = Mission.Current.GetMissionBehavior<PlayerReinforcementMissionLogic>();
			foreach (Agent item in (List<Agent>)(object)Mission.Current.Agents)
			{
				if (item == null || !item.IsActive() || !item.IsHuman || item == Agent.Main || item == val || (_civilianBehavior != null && _civilianBehavior.IsAgentUnderCivilianControl(item)) || (!flag && item.Team == Mission.Current.PlayerTeam) || (missionBehavior != null && missionBehavior.IsSummonedTroop(item)))
				{
					continue;
				}
				BasicCharacterObject character = item.Character;
				CharacterObject val2 = (CharacterObject)(object)((character is CharacterObject) ? character : null);
				if (val2 == null)
				{
					continue;
				}
				if (_activeCombat.CompanionDecisions != null && ((BasicCharacterObject)val2).IsHero && _activeCombat.CompanionDecisions.TryGetValue(((MBObjectBase)val2).StringId, out var value))
				{
					HandleCompanionAgentDecision(item, value, flag, val, ref defendersFound);
					continue;
				}
				bool flag2 = Settlement.CurrentSettlement != null && Settlement.CurrentSettlement.IsTown;
				bool flag3 = (int)val2.Occupation == 15 || (int)val2.Occupation == 21 || (int)val2.Occupation == 27;
				if (flag2 && flag3)
				{
					if (_random.NextDouble() < 0.3)
					{
						_logger.Log("City bandit joins player: " + item.Name);
						if (item.Team != Mission.Current.PlayerTeam)
						{
							item.SetTeam(Mission.Current.PlayerTeam, true);
						}
						WieldBestMeleeWeapon(item);
						item.SetWatchState((WatchState)2);
						AgentFlag agentFlags = item.GetAgentFlags();
						agentFlags = (AgentFlag)(agentFlags | 8);
						agentFlags = (AgentFlag)(agentFlags | 0x10);
						agentFlags = (AgentFlag)(agentFlags & -33);
						agentFlags = (AgentFlag)(agentFlags & -4097);
						item.SetAgentFlags(agentFlags);
						if (!flag && val != null)
						{
							item.SetLookAgent(val);
						}
						defendersFound++;
					}
					else
					{
						_logger.Log("City bandit panics instead of fighting: " + item.Name);
						_civilianBehavior?.ForceAgentPanic(item);
					}
				}
				else if (IsDefenderOrMilitary(val2))
				{
					_logger.Log($"Found existing defender: {item.Name} (Hero: {((BasicCharacterObject)val2).IsHero})");
					if (flag && item.Team != Mission.Current.DefenderTeam)
					{
						item.SetTeam(Mission.Current.DefenderTeam, true);
					}
					WieldBestMeleeWeapon(item);
					item.SetWatchState((WatchState)2);
					if (val != null)
					{
						item.SetLookAgent(val);
					}
					item.SetAgentFlags((AgentFlag)(item.GetAgentFlags() | 8 | 0x10));
					defendersFound++;
				}
			}
			_logger.Log($"Prepared {defendersFound} existing defenders/guards/lords for combat");
		}
		catch (Exception ex)
		{
			_logger.LogError("PrepareExistingDefenders", ex.Message, ex);
		}
	}

	private void SpawnNPCsFromSmallLocation()
	{
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current == null || _activeCombat == null || _activeCombat.NPCsFromSmallLocation == null)
			{
				return;
			}
			_logger.Log("=== SPAWNING MILITARY NPCs FROM SMALL LOCATION ===");
			_logger.Log($"Total military NPCs to spawn (excluding heroes): {_activeCombat.NPCsFromSmallLocation.Count}");
			int num = 0;
			List<CharacterObject> list = new List<CharacterObject>();
			foreach (string npcId in _activeCombat.NPCsFromSmallLocation)
			{
				if (string.IsNullOrEmpty(npcId))
				{
					continue;
				}
				CharacterObject val = MBObjectManager.Instance.GetObject<CharacterObject>(npcId);
				if (val == null)
				{
					Hero val2 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == npcId));
					if (val2 != null)
					{
						val = val2.CharacterObject;
					}
				}
				if (val == null)
				{
					_logger.Log("WARNING: Could not find character for NPC ID: " + npcId);
					continue;
				}
				if (((BasicCharacterObject)val).IsHero)
				{
					_logger.Log($"Skipping hero {((BasicCharacterObject)val).Name} ({npcId}) - heroes should not spawn during transition");
					continue;
				}
				list.Add(val);
				num++;
			}
			if (list.Count > 0)
			{
				Vec3 val3 = _activeCombat.PlayerEntryPosition;
				if (val3 == Vec3.Zero)
				{
					if (Agent.Main != null && Agent.Main.IsActive())
					{
						val3 = Agent.Main.Position;
					}
					else
					{
						Mission current = Mission.Current;
						if (current != null)
						{
							DefenderSpawner defenderSpawner = _defenderSpawner;
						}
					}
				}
				_defenderSpawner.SpawnDefendersAtPosition(list, _activeCombat, val3, "Military NPC from small location", ignoreSideLimit: true);
			}
			_logger.Log($"Successfully scheduled {num} military NPCs from small location to spawn at player exit position (heroes excluded)");
		}
		catch (Exception ex)
		{
			_logger.LogError("SpawnNPCsFromSmallLocation", ex.Message, ex);
		}
	}

	private bool IsDefenderOrMilitary(CharacterObject character)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Invalid comparison between Unknown and I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Invalid comparison between Unknown and I4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Invalid comparison between Unknown and I4
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Invalid comparison between Unknown and I4
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((BasicCharacterObject)character).IsHero)
			{
				return true;
			}
			if ((int)character.Occupation == 7 || (int)character.Occupation == 24 || (int)character.Occupation == 23 || (int)character.Occupation == 30 || (int)character.Occupation == 2 || (int)character.Occupation == 29 || (int)character.Occupation == 21 || (int)character.Occupation == 27 || (int)character.Occupation == 15)
			{
				return true;
			}
			bool flag;
			bool flag2;
			if (character.Tier > 0 && ((BasicCharacterObject)character).Equipment != null)
			{
				flag = false;
				flag2 = false;
				EquipmentElement val2;
				for (EquipmentIndex val = (EquipmentIndex)0; (int)val < 5; val = (EquipmentIndex)(val + 1))
				{
					val2 = ((BasicCharacterObject)character).Equipment[val];
					if (!((EquipmentElement)(ref val2)).IsEmpty)
					{
						flag = true;
						break;
					}
				}
				val2 = ((BasicCharacterObject)character).Equipment[(EquipmentIndex)6];
				if (((EquipmentElement)(ref val2)).IsEmpty)
				{
					val2 = ((BasicCharacterObject)character).Equipment[(EquipmentIndex)5];
					if (((EquipmentElement)(ref val2)).IsEmpty)
					{
						goto IL_0117;
					}
				}
				flag2 = true;
				goto IL_0117;
			}
			goto IL_0127;
			IL_0117:
			if (flag && flag2)
			{
				return true;
			}
			goto IL_0127;
			IL_0127:
			return false;
		}
		catch
		{
			return false;
		}
	}

	private void PrepareNPCAttacker()
	{
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (_activeCombat == null || _activeCombat.TriggerType != CombatTriggerType.NPCAttack)
			{
				return;
			}
			Hero triggerNPC = _activeCombat.TriggerNPC;
			if (triggerNPC == null || triggerNPC.CharacterObject == null)
			{
				_logger.Log("TriggerNPC is null or has no CharacterObject");
				return;
			}
			Agent val = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.IsActive() && a.Character != null && (object)a.Character == triggerNPC.CharacterObject));
			if (val != null)
			{
				if (_civilianBehavior != null && _civilianBehavior.IsAgentUnderCivilianControl(val))
				{
					_logger.Log("NPC attacker " + val.Name + " already configured by CivilianBehavior, skipping PrepareNPCAttacker");
					return;
				}
				_logger.Log("Found attacker agent: " + val.Name);
				string text = _activeCombat.Analysis?.AggressorStringId;
				if (text == ((MBObjectBase)triggerNPC).StringId)
				{
					_logger.Log($"NPC {triggerNPC.Name} is AGGRESSOR - making hostile to player");
					if (val.Team != Mission.Current.DefenderTeam)
					{
						val.SetTeam(Mission.Current.DefenderTeam, true);
					}
					WieldBestMeleeWeapon(val);
					val.SetWatchState((WatchState)2);
					if (Agent.Main != null)
					{
						val.SetLookAgent(Agent.Main);
					}
					val.SetAgentFlags((AgentFlag)(val.GetAgentFlags() | 8 | 0x10));
					_logger.Log("NPC attacker prepared for combat");
				}
			}
			else
			{
				_logger.Log($"WARNING: Could not find agent for attacker NPC {triggerNPC.Name} in mission");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("PrepareNPCAttacker", ex.Message, ex);
		}
	}

	private void WieldBestMeleeWeapon(Agent agent)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Invalid comparison between Unknown and I4
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Invalid comparison between Unknown and I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Invalid comparison between Unknown and I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Invalid comparison between Unknown and I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Invalid comparison between Unknown and I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Invalid comparison between Unknown and I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Invalid comparison between Unknown and I4
		try
		{
			if (agent == null || !agent.IsActive())
			{
				return;
			}
			EquipmentIndex val = (EquipmentIndex)(-1);
			for (EquipmentIndex val2 = (EquipmentIndex)0; (int)val2 < 5; val2 = (EquipmentIndex)(val2 + 1))
			{
				MissionWeapon val3 = agent.Equipment[val2];
				if (!((MissionWeapon)(ref val3)).IsEmpty)
				{
					val3 = agent.Equipment[val2];
					WeaponClass weaponClass = ((MissionWeapon)(ref val3)).CurrentUsageItem.WeaponClass;
					if ((int)weaponClass == 2 || (int)weaponClass == 3 || (int)weaponClass == 4 || (int)weaponClass == 5 || (int)weaponClass == 6 || (int)weaponClass == 8 || (int)weaponClass == 7 || (int)weaponClass == 1 || (int)weaponClass == 9 || (int)weaponClass == 10 || (int)weaponClass == 11)
					{
						val = val2;
						break;
					}
					if ((int)val == -1)
					{
						val = val2;
					}
				}
			}
			if ((int)val != -1)
			{
				agent.TryToWieldWeaponInSlot(val, (WeaponWieldActionType)2, false);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("WieldBestMeleeWeapon", ex.Message, ex);
		}
	}

	private void SheathPlayerTroopsWeapons()
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Invalid comparison between Unknown and I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Invalid comparison between Unknown and I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Invalid comparison between Unknown and I4
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Invalid comparison between Unknown and I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Invalid comparison between Unknown and I4
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Invalid comparison between Unknown and I4
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Invalid comparison between Unknown and I4
		try
		{
			if (Mission.Current == null || Mission.Current.PlayerTeam == null)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			foreach (Agent item in (List<Agent>)(object)Mission.Current.PlayerTeam.ActiveAgents)
			{
				if (item == null || !item.IsActive() || !item.IsHuman || item == Agent.Main)
				{
					continue;
				}
				BasicCharacterObject character = item.Character;
				CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
				if (val != null)
				{
					bool flag = (int)val.Occupation == 7 || (int)val.Occupation == 24 || (int)val.Occupation == 23 || (int)val.Occupation == 30 || (int)val.Occupation == 2 || (int)val.Occupation == 29;
					bool flag2 = ((BasicCharacterObject)val).IsHero && val.HeroObject != null && val.HeroObject.IsLord;
					if (flag || flag2)
					{
						num2++;
						continue;
					}
				}
				if ((int)item.GetWieldedItemIndex((HandIndex)0) != -1)
				{
					item.TryToSheathWeaponInHand((HandIndex)0, (WeaponWieldActionType)0);
				}
				if ((int)item.GetWieldedItemIndex((HandIndex)1) != -1)
				{
					item.TryToSheathWeaponInHand((HandIndex)1, (WeaponWieldActionType)0);
				}
				num++;
			}
			_logger.Log($"Player troops disarmed: {num} troops sheathed weapons, {num2} defenders/lords kept weapons");
		}
		catch (Exception ex)
		{
			_logger.LogError("SheathPlayerTroopsWeapons", ex.Message, ex);
		}
	}

	private void StartCombatTracking()
	{
		_statistics.StartTracking(_activeCombat, _civilianBehavior, this);
		_logger.Log("Combat tracking started");
	}

	public void OnAllEnemiesEliminated()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		try
		{
			_villagePostCombatInquiryShown = false;
			if (_activeCombat == null)
			{
				_logger.Log("OnAllEnemiesEliminated: _activeCombat is already null");
				return;
			}
			_logger.Log("=== All Enemies Eliminated - Returning to Peace Mode ===");
			_logger.Log($"  _missionModeChanged: {_missionModeChanged}");
			_logger.Log($"  _previousMissionMode: {_previousMissionMode}");
			SettlementCombatLogger logger = _logger;
			Mission current = Mission.Current;
			logger.Log($"  Current Mission.Mode: {((current != null) ? new MissionMode?(current.Mode) : ((MissionMode?)null))}");
			_combatEnded = true;
			_logger.Log("Combat marked as ended (_combatEnded = true)");
			ForcePlayerExitAfterCombat("OnAllEnemiesEliminated");
			if (_missionModeChanged && Mission.Current != null)
			{
				Mission.Current.SetMissionMode(_previousMissionMode, false);
				_missionModeChanged = false;
				_logger.Log($"Mission mode restored: Battle -> {_previousMissionMode}");
			}
			else
			{
				_logger.Log($"Mission mode NOT restored (missionModeChanged={_missionModeChanged}, Mission.Current={Mission.Current != null})");
			}
			try
			{
				Mission current2 = Mission.Current;
				MissionConversationLogic val = ((current2 != null) ? current2.GetMissionBehavior<MissionConversationLogic>() : null);
				if (val != null)
				{
					val.DisableStartConversation(false);
				}
				_logger.Log("MissionConversationLogic: auto-start re-enabled after combat ended");
			}
			catch
			{
			}
			SheathPlayerTroopsWeapons();
			try
			{
				_behavior.GetDelayedTaskManager()?.AddTask(5.0, delegate
				{
					try
					{
						TryShowVillagePostCombatInquiry();
					}
					catch (Exception ex4)
					{
						_logger.LogError("DelayedTryShowVillagePostCombatInquiry", ex4.Message, ex4);
					}
				});
			}
			catch (Exception ex)
			{
				_logger.LogError("ScheduleVillagePostCombatInquiry", ex.Message, ex);
				TryShowVillagePostCombatInquiry();
			}
			try
			{
				Settlement settlement = _activeCombat.Settlement;
				if (settlement != null && (settlement.IsTown || settlement.IsCastle))
				{
					string text = _activeCombat.Analysis?.AggressorStringId;
					int num;
					if (!(text == "main_hero"))
					{
						Hero mainHero = Hero.MainHero;
						num = ((text == ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null)) ? 1 : 0);
					}
					else
					{
						num = 1;
					}
					bool flag = (byte)num != 0;
					bool flag2 = settlement.OwnerClan != null && settlement.OwnerClan == Clan.PlayerClan;
					if (flag && !flag2)
					{
						TextObject val2 = new TextObject("{=AIInfluence_CannotCaptureSettlementTitle}After the battle in the settlement", (Dictionary<string, object>)null);
						TextObject val3 = new TextObject("{=AIInfluence_CannotCaptureSettlementAfterCombat}You have killed all defenders of this settlement and there is nothing more you can do here. You have inflicted serious damage, but you cannot take control of the settlement.", (Dictionary<string, object>)null);
						InformationManager.ShowInquiry(new InquiryData(((object)val2).ToString(), ((object)val3).ToString(), true, false, ((object)GameTexts.FindText("str_ok", (string)null)).ToString(), string.Empty, (Action)null, (Action)null, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), true, false);
					}
				}
			}
			catch (Exception ex2)
			{
				_logger.LogError("OnAllEnemiesEliminated_SettlementCaptureInfo", ex2.Message, ex2);
			}
			_logger.Log("Combat transitioned to peace mode. Waiting for player to leave settlement for final statistics.");
		}
		catch (Exception ex3)
		{
			_logger.LogError("OnAllEnemiesEliminated", ex3.Message, ex3);
		}
	}

	private bool ForcePlayerExitAfterCombat(string reason)
	{
		try
		{
			if (!PlayerEncounter.InsideSettlement)
			{
				_logger.Log("ForcePlayerExitAfterCombat[" + reason + "]: Player already outside settlement, skipping.");
				return false;
			}
			if (Mission.Current != null)
			{
				_logger.Log("ForcePlayerExitAfterCombat[" + reason + "]: Mission still active (" + Mission.Current.SceneName + "). Skipping forced exit.");
				return false;
			}
			if (_activeCombat == null)
			{
				_logger.Log("ForcePlayerExitAfterCombat[" + reason + "]: No active combat, skipping forced exit.");
				return false;
			}
			MobileParty mainParty = MobileParty.MainParty;
			object obj;
			if (mainParty == null)
			{
				obj = null;
			}
			else
			{
				Settlement currentSettlement = mainParty.CurrentSettlement;
				obj = ((currentSettlement != null) ? ((MBObjectBase)currentSettlement).StringId : null);
			}
			if (obj == null)
			{
				ActiveCombat activeCombat = _activeCombat;
				if (activeCombat == null)
				{
					obj = null;
				}
				else
				{
					Settlement settlement = activeCombat.Settlement;
					obj = ((settlement != null) ? ((MBObjectBase)settlement).StringId : null);
				}
				if (obj == null)
				{
					obj = "unknown";
				}
			}
			string text = (string)obj;
			_logger.Log("ForcePlayerExitAfterCombat[" + reason + "]: Forcing PlayerEncounter.LeaveSettlement for " + text);
			PlayerEncounter.LeaveSettlement();
			Campaign current = Campaign.Current;
			if (((current != null) ? current.CurrentMenuContext : null) != null)
			{
				GameMenu.ExitToLast();
				_logger.Log("ForcePlayerExitAfterCombat[" + reason + "]: Closed active game menu after forcing exit");
			}
			return true;
		}
		catch (Exception ex)
		{
			_logger.LogError("ForcePlayerExitAfterCombat", ex.Message, ex);
			return false;
		}
	}

	public void OnPlayerLeavesSettlement()
	{
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool combatEnded = _combatEnded;
			if (_activeCombat == null)
			{
				_logger.Log("No active combat - skipping post-combat event");
				return;
			}
			if (!combatEnded)
			{
				ApplyEscapePenaltyIfNeeded();
			}
			else
			{
				_pendingEscapePenalty = false;
				_logger.Log("Peaceful exit detected – skipping escape penalty.");
			}
			if (!combatEnded)
			{
				try
				{
					Settlement settlement = _activeCombat.Settlement;
					if (settlement != null && MobileParty.MainParty != null)
					{
						CampaignVec2 val = settlement.GatePosition;
						Vec2 val2 = ((CampaignVec2)(ref val)).ToVec2();
						val = settlement.Position;
						Vec2 val3 = ((CampaignVec2)(ref val)).ToVec2();
						Vec2 val4 = val2 - val3;
						if (((Vec2)(ref val4)).LengthSquared <= 0.0001f)
						{
							((Vec2)(ref val4))._002Ector(1f, 0f);
						}
						else
						{
							val4 = ((Vec2)(ref val4)).Normalized();
						}
						Vec2 val5 = val2 + val4 * 3f;
						MobileParty.MainParty.Position = new CampaignVec2(val5, true);
						_logger.Log($"Player teleported on world map to {val5} (2f from settlement gate)");
					}
				}
				catch (Exception ex)
				{
					_logger.LogError("OnPlayerLeavesSettlement_Teleport", ex.Message, ex);
				}
			}
			else
			{
				_logger.Log("Peaceful exit detected – skipping teleport.");
			}
			if (!combatEnded)
			{
				try
				{
					if (PlayerEncounter.InsideSettlement)
					{
						MobileParty mainParty = MobileParty.MainParty;
						object obj;
						if (mainParty == null)
						{
							obj = null;
						}
						else
						{
							Settlement currentSettlement = mainParty.CurrentSettlement;
							obj = ((currentSettlement != null) ? ((MBObjectBase)currentSettlement).StringId : null);
						}
						if (obj == null)
						{
							obj = "unknown";
						}
						string text = (string)obj;
						PlayerEncounter.LeaveSettlement();
						_logger.Log("Forced PlayerEncounter.LeaveSettlement for " + text);
					}
					Campaign current = Campaign.Current;
					if (((current != null) ? current.CurrentMenuContext : null) != null)
					{
						GameMenu.ExitToLast();
						_logger.Log("Closed active game menu after leaving settlement");
					}
				}
				catch (Exception ex2)
				{
					_logger.LogError("OnPlayerLeavesSettlement_ForceExit", ex2.Message, ex2);
				}
			}
			else
			{
				_logger.Log("Peaceful exit detected – keeping default game menu flow.");
			}
			if (_activeCombat.Analysis == null)
			{
				_logger.Log("Combat was initiated but AI analysis not received yet - skipping post-combat event");
				_activeCombat = null;
				_combatEnded = false;
				return;
			}
			_logger.Log("Player leaving settlement, finalizing combat...");
			if (_missionModeChanged && Mission.Current != null)
			{
				Mission.Current.SetMissionMode(_previousMissionMode, false);
				_missionModeChanged = false;
				_logger.Log($"Mission mode restored: Battle -> {_previousMissionMode}");
			}
			try
			{
				Mission current2 = Mission.Current;
				MissionConversationLogic val6 = ((current2 != null) ? current2.GetMissionBehavior<MissionConversationLogic>() : null);
				if (val6 != null)
				{
					val6.DisableStartConversation(false);
				}
				_logger.Log("MissionConversationLogic: auto-start re-enabled on player leaving settlement");
			}
			catch
			{
			}
			SheathPlayerTroopsWeapons();
			_statistics.StopTracking();
			CombatResult combatResult = _statistics.GetCombatResult();
			_logger.LogCombatEnded(((MBObjectBase)_activeCombat.Settlement).StringId, combatResult.TotalKilled, combatResult.TotalWounded, combatResult.CiviliansKilled, combatResult.CiviliansWounded);
			if (_activeCombat.Settlement.IsVillage && combatResult.CiviliansKilled > 0 && SettlementPenaltyManager.Instance != null)
			{
				SettlementPenaltyManager.Instance.ApplyCasualtiesToVillage(_activeCombat.Settlement, combatResult.CiviliansKilled);
			}
			int num = combatResult.MilitiaKilled + combatResult.SimpleDefendersKilled;
			if (num > 0 && SettlementPenaltyManager.Instance != null)
			{
				SettlementPenaltyManager.Instance.ApplyMilitiaCasualties(_activeCombat.Settlement, num);
			}
			ActiveCombat activeCombat = _activeCombat;
			try
			{
				HandlePlayerKnockoutConsequences(activeCombat, combatResult);
			}
			catch (Exception ex3)
			{
				_logger.LogError("HandlePlayerKnockoutConsequences", ex3.Message, ex3);
			}
			_defenderSpawner?.ClearCombat();
			_savedCombatForTransition = null;
			_activeCombat = null;
			_combatEnded = false;
			_currentPostCombatRetryAttempt = 0;
			SendPostCombatEventPrompt(activeCombat, combatResult);
		}
		catch (Exception ex4)
		{
			_logger.LogError("OnPlayerLeavesSettlement", ex4.Message, ex4);
		}
	}

	internal void RegisterPlayerEscapeAttempt(int totalTroops, int nearbyTroops)
	{
		try
		{
			_escapeTotalTroops = Math.Max(1, totalTroops);
			_escapeNearbyTroops = Math.Min(Math.Max(0, nearbyTroops), _escapeTotalTroops);
			if (_escapeNearbyTroops <= 0)
			{
				_escapeNearbyTroops = Math.Min(_escapeTotalTroops, Math.Max(1, nearbyTroops));
			}
			if (_escapeTotalTroops <= 0)
			{
				_pendingEscapePenalty = false;
				return;
			}
			float num = (float)_escapeNearbyTroops / (float)_escapeTotalTroops;
			if (num < 0.7f)
			{
				_pendingEscapePenalty = true;
				_logger.Log($"Escape penalty scheduled: nearby={_escapeNearbyTroops}, total={_escapeTotalTroops}, ratio={num:0.00}");
			}
			else
			{
				_pendingEscapePenalty = false;
				_logger.Log($"Escape penalty skipped: ratio {num:0.00} >= {0.7f}");
			}
		}
		catch (Exception ex)
		{
			_pendingEscapePenalty = false;
			_logger.LogError("RegisterPlayerEscapeAttempt", ex.Message, ex);
		}
	}

	private void ApplyEscapePenaltyIfNeeded()
	{
		if (!_pendingEscapePenalty)
		{
			return;
		}
		_pendingEscapePenalty = false;
		int escapeTotalTroops = _escapeTotalTroops;
		int num = Math.Min(_escapeNearbyTroops, escapeTotalTroops);
		_escapeTotalTroops = 0;
		_escapeNearbyTroops = 0;
		if (escapeTotalTroops <= 0)
		{
			return;
		}
		float num2 = (float)num / (float)escapeTotalTroops;
		if (num2 >= 0.7f)
		{
			return;
		}
		int num3 = (int)Math.Ceiling((float)escapeTotalTroops * (0.7f - num2));
		if (num3 > 0)
		{
			int num4 = SacrificePlayerTroops(num3);
			if (num4 <= 0)
			{
				_logger.Log("Escape penalty calculated, but no troops were removed.");
				return;
			}
			ShowEscapePenaltyPopup(num4, escapeTotalTroops, num, num2);
			_logger.Log($"Escape penalty applied: removed {num4} troops (total={escapeTotalTroops}, nearby={num}, ratio={num2:0.00}).");
		}
	}

	private int SacrificePlayerTroops(int requested)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (MobileParty.MainParty == null || requested <= 0)
			{
				return 0;
			}
			TroopRoster memberRoster = MobileParty.MainParty.MemberRoster;
			int num = 0;
			for (int i = 0; i < requested; i++)
			{
				CharacterObject val = null;
				float num2 = float.MaxValue;
				foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)memberRoster.GetTroopRoster())
				{
					TroopRosterElement current = item;
					if (current.Character == null || ((BasicCharacterObject)current.Character).IsHero)
					{
						continue;
					}
					int num3 = ((TroopRosterElement)(ref current)).Number - ((TroopRosterElement)(ref current)).WoundedNumber;
					if (num3 > 0)
					{
						float num4 = (float)((BasicCharacterObject)current.Character).Level + ((((TroopRosterElement)(ref current)).WoundedNumber > 0) ? (-0.5f) : 0f);
						if (num4 < num2)
						{
							num2 = num4;
							val = current.Character;
						}
					}
				}
				if (val == null)
				{
					break;
				}
				memberRoster.AddToCounts(val, -1, false, 0, 0, true, -1);
				num++;
			}
			return num;
		}
		catch (Exception ex)
		{
			_logger.LogError("SacrificePlayerTroops", ex.Message, ex);
			return 0;
		}
	}

	private void ShowEscapePenaltyPopup(int removed, int total, int nearby, float ratio)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		try
		{
			TextObject val = new TextObject("{=AIInfluence_EscapePenaltyTitle}Retreat at a Cost", (Dictionary<string, object>)null);
			TextObject val2 = new TextObject("{=AIInfluence_EscapePenaltyLine1}You managed to leave the settlement, but {LOST_TROOPS} troops stayed behind to cover your retreat and were lost.", (Dictionary<string, object>)null);
			val2.SetTextVariable("LOST_TROOPS", removed);
			TextObject val3 = new TextObject("{=AIInfluence_EscapePenaltyLine2}{NEARBY} out of {TOTAL} troops escaped with you ({RATIO}%).", (Dictionary<string, object>)null);
			val3.SetTextVariable("NEARBY", nearby);
			val3.SetTextVariable("TOTAL", total);
			val3.SetTextVariable("RATIO", MathF.Round(ratio * 100f, 1), 2);
			string text = $"{val2}\n\n{val3}";
			InformationManager.ShowInquiry(new InquiryData(((object)val).ToString(), text, true, false, ((object)GameTexts.FindText("str_ok", (string)null)).ToString(), string.Empty, (Action)null, (Action)null, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), true, false);
		}
		catch (Exception ex)
		{
			_logger.LogError("ShowEscapePenaltyPopup", ex.Message, ex);
		}
	}

	private async void SendPostCombatEventPrompt(ActiveCombat combat, CombatResult result)
	{
		try
		{
			_logger.Log($"Generating post-combat event prompt... (Attempt {_currentPostCombatRetryAttempt + 1}/{3})");
			_postCombatRetryData = combat;
			_postCombatRetryResult = result;
			string prompt = _promptGenerator.GeneratePostCombatEventPrompt(combat, result);
			_logger.LogPostCombatEventPrompt(((MBObjectBase)combat.Settlement).StringId, prompt);
			_logger.Log("Sending prompt to AI for post-combat event creation");
			string aiResponse = await _behavior.SendAIRequestRaw(prompt);
			_logger.Log("=== AI Response Received (Post-Combat) ===");
			_logger.Log($"  Response is null: {aiResponse == null}");
			_logger.Log($"  Response is empty: {string.IsNullOrEmpty(aiResponse)}");
			_logger.Log($"  Response length: {aiResponse?.Length ?? 0}");
			_logger.Log(string.Format("  Starts with Error: {0}", aiResponse?.StartsWith("Error:") ?? false));
			_logger.Log("  Full response:");
			_logger.Log("---START---");
			_logger.Log(aiResponse ?? "");
			_logger.Log("---END---");
			if (string.IsNullOrEmpty(aiResponse) || aiResponse.StartsWith("Error:"))
			{
				_logger.LogError("SendPostCombatEventPrompt", "AI returned empty or error response");
				HandlePostCombatAIError();
				return;
			}
			_logger.Log("AI response valid (post-combat), proceeding to process");
			_currentPostCombatRetryAttempt = 0;
			_postCombatRetryData = null;
			_postCombatRetryResult = null;
			ProcessPostCombatEventResponse(combat, result, aiResponse);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError("SendPostCombatEventPrompt", ex2.Message, ex2);
			HandlePostCombatAIError();
		}
	}

	private void HandlePostCombatAIError()
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		_currentPostCombatRetryAttempt++;
		if (_currentPostCombatRetryAttempt < 3)
		{
			_logger.Log($"Retrying post-combat AI request in {5f} seconds... (Attempt {_currentPostCombatRetryAttempt + 1}/{3})");
			_behavior.GetDelayedTaskManager().AddTask(5.0, delegate
			{
				if (_postCombatRetryData != null && _postCombatRetryResult != null)
				{
					SendPostCombatEventPrompt(_postCombatRetryData, _postCombatRetryResult);
				}
			});
		}
		else
		{
			_logger.LogError("HandlePostCombatAIError", $"All {3} retry attempts failed for post-combat event. Event will not be created.");
			_currentPostCombatRetryAttempt = 0;
			_postCombatRetryData = null;
			_postCombatRetryResult = null;
			InformationManager.DisplayMessage(new InformationMessage("Failed to create post-combat event.", ExtraColors.RedAIInfluence));
		}
	}

	public void ProcessPostCombatEventResponse(ActiveCombat combat, CombatResult combatResult, string aiResponse)
	{
		try
		{
			if (combat == null)
			{
				_logger.Log("WARNING: Combat is null when processing post-combat event");
				return;
			}
			_logger.LogPostCombatEventResponse(((MBObjectBase)combat.Settlement).StringId, aiResponse);
			_eventCreator.CreatePostCombatEvent(aiResponse, combat.Settlement, combatResult);
			_logger.Log($"Post-combat event processed successfully for {combat.Settlement.Name}");
		}
		catch (Exception ex)
		{
			_logger.LogError("ProcessPostCombatEventResponse", ex.Message, ex);
		}
	}

	public CombatStatistics GetStatistics()
	{
		return _statistics;
	}

	public Settlement GetActiveCombatSettlement()
	{
		if (_activeCombat != null)
		{
			return _activeCombat.Settlement;
		}
		if (_savedCombatForTransition != null)
		{
			return _savedCombatForTransition.Settlement;
		}
		if (_postCombatRetryData != null)
		{
			return _postCombatRetryData.Settlement;
		}
		return null;
	}

	public bool IsCurrentLocationLargeOutdoor()
	{
		try
		{
			if (_activeCombat != null)
			{
				return _activeCombat.LocationType == LocationType.LargeOutdoor;
			}
			if (_savedCombatForTransition != null)
			{
				return _savedCombatForTransition.LocationType == LocationType.LargeOutdoor;
			}
			return DetermineLocationType() == LocationType.LargeOutdoor;
		}
		catch
		{
			return true;
		}
	}

	public bool TryGetCompanionDecision(string heroStringId, out CompanionCombatDecision decision)
	{
		decision = CompanionCombatDecision.StayOut;
		if (string.IsNullOrEmpty(heroStringId))
		{
			return false;
		}
		ActiveCombat activeCombat = _activeCombat ?? _savedCombatForTransition;
		if (activeCombat?.CompanionDecisions != null && activeCombat.CompanionDecisions.TryGetValue(heroStringId, out decision))
		{
			return true;
		}
		return false;
	}

	private void TryShowVillagePostCombatInquiry()
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		try
		{
			if (_villagePostCombatInquiryShown || _activeCombat == null)
			{
				return;
			}
			Settlement settlement = _activeCombat.Settlement;
			if (settlement == null || !settlement.IsVillage)
			{
				_logger.Log("TryShowVillagePostCombatInquiry: Settlement is null or not a village, skipping.");
				return;
			}
			string text = _activeCombat.Analysis?.AggressorStringId;
			if (!(text == "main_hero"))
			{
				Hero mainHero = Hero.MainHero;
				if (!(text == ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null)))
				{
					_logger.Log("TryShowVillagePostCombatInquiry: Player is not aggressor, skipping village action menu.");
					return;
				}
			}
			if (_activeCombat.Analysis != null && !_activeCombat.Analysis.NeedsDefenders)
			{
				_logger.Log("TryShowVillagePostCombatInquiry: needs_defenders = false, skipping village action menu (silent combat).");
				return;
			}
			if (Mission.Current == null)
			{
				_logger.Log("TryShowVillagePostCombatInquiry: Mission is null, cannot show inquiry inside mission.");
				return;
			}
			_villagePostCombatInquiryShown = true;
			List<InquiryElement> list = new List<InquiryElement>
			{
				new InquiryElement((object)"loot_only", ((object)new TextObject("{=AIInfluence_VillageLootOnly}Raid the village", (Dictionary<string, object>)null)).ToString(), (ImageIdentifier)null, true, ((object)new TextObject("{=AIInfluence_VillageLootOnlyDesc}Take supplies and valuables without burning the village.", (Dictionary<string, object>)null)).ToString()),
				new InquiryElement((object)"burn_only", ((object)new TextObject("{=AIInfluence_VillageBurnOnly}Burn the village", (Dictionary<string, object>)null)).ToString(), (ImageIdentifier)null, true, ((object)new TextObject("{=AIInfluence_VillageBurnOnlyDesc}Leave the loot, but burn the village to the ground.", (Dictionary<string, object>)null)).ToString()),
				new InquiryElement((object)"loot_and_burn", ((object)new TextObject("{=AIInfluence_VillageLootAndBurn}Raid and burn the village", (Dictionary<string, object>)null)).ToString(), (ImageIdentifier)null, true, ((object)new TextObject("{=AIInfluence_VillageLootAndBurnDesc}First take everything valuable, then burn the village.", (Dictionary<string, object>)null)).ToString()),
				new InquiryElement((object)"do_nothing", ((object)new TextObject("{=AIInfluence_VillageDoNothing}Do nothing", (Dictionary<string, object>)null)).ToString(), (ImageIdentifier)null, true, ((object)new TextObject("{=AIInfluence_VillageDoNothingDesc}Leave the village untouched.", (Dictionary<string, object>)null)).ToString())
			};
			TextObject val = new TextObject("{=AIInfluence_VillageAfterCombatTitle}After the battle in the village", (Dictionary<string, object>)null);
			TextObject val2 = new TextObject("{=AIInfluence_VillageAfterCombatDesc}You have defeated the village defenders. What will you do next?", (Dictionary<string, object>)null);
			MultiSelectionInquiryData val3 = new MultiSelectionInquiryData(((object)val).ToString(), ((object)val2).ToString(), list, true, 1, 1, ((object)GameTexts.FindText("str_done", (string)null)).ToString(), ((object)GameTexts.FindText("str_cancel", (string)null)).ToString(), (Action<List<InquiryElement>>)OnVillagePostCombatSelection, (Action<List<InquiryElement>>)null, string.Empty, false);
			MBInformationManager.ShowMultiSelectionInquiry(val3, false, false);
			_logger.Log("Village post-combat inquiry shown.");
		}
		catch (Exception ex)
		{
			_logger.LogError("TryShowVillagePostCombatInquiry", ex.Message, ex);
		}
	}

	private void OnVillagePostCombatSelection(List<InquiryElement> elements)
	{
		try
		{
			if (elements == null || elements.Count == 0)
			{
				_logger.Log("OnVillagePostCombatSelection: No selection made, doing nothing.");
				return;
			}
			string text = elements[0]?.Identifier as string;
			if (string.IsNullOrEmpty(text))
			{
				_logger.Log("OnVillagePostCombatSelection: Selection identifier is null or empty.");
				return;
			}
			ActiveCombat activeCombat = _activeCombat ?? _savedCombatForTransition ?? _postCombatRetryData;
			if (activeCombat == null || activeCombat.Settlement == null || !activeCombat.Settlement.IsVillage)
			{
				_logger.Log("OnVillagePostCombatSelection: No valid village combat context, skipping.");
				return;
			}
			Settlement settlement = activeCombat.Settlement;
			bool flag = text == "loot_only" || text == "loot_and_burn";
			bool flag2 = text == "burn_only" || text == "loot_and_burn";
			if (flag)
			{
				OpenVillageLootScreen(settlement);
				activeCombat.VillageLooted = true;
			}
			if (flag2)
			{
				BurnVillage(settlement);
				activeCombat.VillageBurned = true;
			}
			if (!flag && !flag2)
			{
				_logger.Log("OnVillagePostCombatSelection: Player chose to do nothing with the village.");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("OnVillagePostCombatSelection", ex.Message, ex);
		}
	}

	private void OpenVillageLootScreen(Settlement settlement)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		try
		{
			if (settlement == null || !settlement.IsVillage || MobileParty.MainParty == null)
			{
				return;
			}
			Village village = settlement.Village;
			if (village == null || village.VillageType == null)
			{
				return;
			}
			ItemRoster val = new ItemRoster();
			int num = 0;
			int num2 = 0;
			if (_postCombatRetryResult != null)
			{
				num = _postCombatRetryResult.CiviliansKilled;
				num2 = _postCombatRetryResult.MilitiaKilled + _postCombatRetryResult.SimpleDefendersKilled;
			}
			float num3 = 1f + (float)num * 0.03f + (float)num2 * 0.01f;
			num3 = MathF.Clamp(num3, 1f, 6f);
			float num4 = village.Hearth * 0.9f * num3;
			num4 = MathF.Max(num4, 20f);
			Campaign current = Campaign.Current;
			int? obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				GameModels models = current.Models;
				if (models == null)
				{
					obj = null;
				}
				else
				{
					RaidModel raidModel = models.RaidModel;
					obj = ((raidModel != null) ? new int?(raidModel.GoldRewardForEachLostHearth) : ((int?)null));
				}
			}
			int num5 = obj ?? 4;
			if (num5 > 0)
			{
				int num6 = (int)(num4 * (float)num5);
				if (num6 > 0)
				{
					GiveGoldAction.ApplyBetweenCharacters((Hero)null, Hero.MainHero, num6, false);
				}
			}
			foreach (var (val2, num7) in (List<(ItemObject, float)>)(object)village.VillageType.Productions)
			{
				if ((village.VillageType.PrimaryProduction == DefaultItems.Grain && val2 == DefaultItems.Grain) || val2 != DefaultItems.Grain)
				{
					float num8 = num4 * num7 / 35f;
					int num9 = (int)num8;
					if (num9 > 0)
					{
						val.AddToCounts(val2, num9);
					}
				}
			}
			if (val.Count <= 0)
			{
				_logger.Log("OpenVillageLootScreen: No items generated for village loot.");
				return;
			}
			InventoryScreenHelper.OpenScreenAsLoot(new Dictionary<PartyBase, ItemRoster> { 
			{
				PartyBase.MainParty,
				val
			} });
			_logger.Log($"OpenVillageLootScreen: Loot screen opened for village {((MBObjectBase)settlement).StringId}, items: {val.Count}");
		}
		catch (Exception ex)
		{
			_logger.LogError("OpenVillageLootScreen", ex.Message, ex);
		}
	}

	private void BurnVillage(Settlement settlement)
	{
		try
		{
			if (settlement != null && settlement.IsVillage)
			{
				if (MobileParty.MainParty != null)
				{
					ChangeVillageStateAction.ApplyBySettingToLooted(settlement, MobileParty.MainParty);
				}
				float settlementHitPoints = settlement.SettlementHitPoints;
				if (settlementHitPoints > 0f)
				{
					IncreaseSettlementHealthAction.Apply(settlement, 0f - settlementHitPoints);
				}
				_logger.Log("BurnVillage: Village " + ((MBObjectBase)settlement).StringId + " marked as looted and burned (HP set to 0 via IncreaseSettlementHealthAction).");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("BurnVillage", ex.Message, ex);
		}
	}

	private void HandlePlayerKnockoutConsequences(ActiveCombat combat, CombatResult result)
	{
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Expected O, but got Unknown
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_0715: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (_playerKnockout == null || combat == null || combat.Settlement == null)
			{
				return;
			}
			PlayerKnockoutInfo playerKnockout = _playerKnockout;
			_playerKnockout = null;
			if (!playerKnockout.IsAggressor)
			{
				return;
			}
			float num = MathF.Max(0.1f, playerKnockout.PlayerPower);
			float num2 = MathF.Max(0.1f, playerKnockout.EnemyPower);
			float num3 = num / num2;
			if (num3 >= 1f)
			{
				if (result != null)
				{
					result.PlayerEvacuated = true;
					result.Participants.Add(((MBObjectBase)Hero.MainHero).StringId);
				}
				TextObject val = new TextObject("{=AIInfluence_PlayerEvacuatedAfterKnockout}During the battle you lost consciousness, but your men carried you away from the fight and saved you from captivity.", (Dictionary<string, object>)null);
				InformationManager.ShowInquiry(new InquiryData(((object)new TextObject("{=AIInfluence_PlayerEvacuated_Title}You were evacuated from battle", (Dictionary<string, object>)null)).ToString(), ((object)val).ToString(), true, false, ((object)GameTexts.FindText("str_ok", (string)null)).ToString(), string.Empty, (Action)null, (Action)null, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), true, false);
				return;
			}
			Settlement settlement = combat.Settlement;
			if (settlement == null)
			{
				return;
			}
			Settlement val2 = null;
			if (settlement.IsTown || settlement.IsCastle)
			{
				val2 = settlement;
			}
			else if (settlement.IsVillage)
			{
				Village village = settlement.Village;
				val2 = ((village != null) ? village.Bound : null);
			}
			if (val2 == null)
			{
				IFaction mapFaction = settlement.MapFaction;
				float num4 = float.MaxValue;
				foreach (Settlement item in (List<Settlement>)(object)Settlement.All)
				{
					if ((item.IsTown || item.IsCastle) && item.MapFaction == mapFaction)
					{
						CampaignVec2 gatePosition = item.GatePosition;
						float num5 = ((CampaignVec2)(ref gatePosition)).DistanceSquared(settlement.GatePosition);
						if (num5 < num4)
						{
							num4 = num5;
							val2 = item;
						}
					}
				}
			}
			if (val2 == null)
			{
				return;
			}
			try
			{
				IFaction mapFaction2 = settlement.MapFaction;
				if (mapFaction2 != null)
				{
					ChangeCrimeRatingAction.Apply(mapFaction2, 40f, false);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("HandlePlayerKnockoutConsequences_CrimeRating", ex.Message, ex);
			}
			try
			{
				HashSet<Hero> hashSet = new HashSet<Hero>();
				try
				{
					if (combat.PlayerCompanions != null)
					{
						foreach (Hero playerCompanion in combat.PlayerCompanions)
						{
							if (playerCompanion != null && playerCompanion != Hero.MainHero && !playerCompanion.IsDead && !playerCompanion.IsPrisoner && !playerCompanion.IsNotable)
							{
								hashSet.Add(playerCompanion);
							}
						}
					}
					if (result != null && result.LordsArrived != null)
					{
						foreach (LordArrivalInfo lordInfo in result.LordsArrived)
						{
							if (lordInfo != null && lordInfo.OnPlayerSide && !string.IsNullOrEmpty(lordInfo.LordStringId))
							{
								Hero val3 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == lordInfo.LordStringId));
								if (val3 != null && val3 != Hero.MainHero && !val3.IsDead && !val3.IsPrisoner && !val3.IsNotable)
								{
									hashSet.Add(val3);
								}
							}
						}
					}
				}
				catch (Exception ex2)
				{
					_logger.LogError("HandlePlayerKnockoutConsequences_GatherCompanions", ex2.Message, ex2);
				}
				if (MobileParty.MainParty != null)
				{
					try
					{
						TroopRoster memberRoster = MobileParty.MainParty.MemberRoster;
						for (int num6 = memberRoster.Count - 1; num6 >= 0; num6--)
						{
							TroopRosterElement elementCopyAtIndex = memberRoster.GetElementCopyAtIndex(num6);
							if (elementCopyAtIndex.Character != null && (!((BasicCharacterObject)elementCopyAtIndex.Character).IsHero || elementCopyAtIndex.Character.HeroObject != Hero.MainHero) && ((TroopRosterElement)(ref elementCopyAtIndex)).Number > 0)
							{
								memberRoster.AddToCounts(elementCopyAtIndex.Character, -((TroopRosterElement)(ref elementCopyAtIndex)).Number, false, 0, 0, true, -1);
							}
						}
					}
					catch (Exception ex3)
					{
						_logger.LogError("HandlePlayerKnockoutConsequences_ClearPlayerParty", ex3.Message, ex3);
					}
				}
				if (Hero.MainHero != null)
				{
					TeleportHeroAction.ApplyImmediateTeleportToSettlement(Hero.MainHero, val2);
				}
				PartyBase party = val2.Party;
				if (party != null)
				{
					TakePrisonerAction.Apply(party, Hero.MainHero);
					if (hashSet != null && hashSet.Count > 0)
					{
						foreach (Hero item2 in hashSet)
						{
							try
							{
								if (item2 == null || item2.IsDead || item2.IsPrisoner)
								{
									continue;
								}
								TakePrisonerAction.Apply(party, item2);
								if (result != null && !string.IsNullOrEmpty(((MBObjectBase)item2).StringId))
								{
									if (!result.CapturedHeroes.Contains(((MBObjectBase)item2).StringId))
									{
										result.CapturedHeroes.Add(((MBObjectBase)item2).StringId);
									}
									if (!result.Participants.Contains(((MBObjectBase)item2).StringId))
									{
										result.Participants.Add(((MBObjectBase)item2).StringId);
									}
								}
							}
							catch (Exception ex4)
							{
								_logger.LogError("HandlePlayerKnockoutConsequences_CaptureCompanion", ex4.Message, ex4);
							}
						}
					}
				}
				if (result != null)
				{
					result.PlayerCaptured = true;
					result.PlayerPrisonSettlement = val2;
					if (!result.Participants.Contains(((MBObjectBase)Hero.MainHero).StringId))
					{
						result.Participants.Add(((MBObjectBase)Hero.MainHero).StringId);
					}
				}
				TextObject val4 = new TextObject("{=AIInfluence_PlayerCapturedAfterKnockout}You lost consciousness during the attack. While you were unconscious, the defenders of {SETTLEMENT} captured you and transported you to {PRISON_SETTLEMENT}.", (Dictionary<string, object>)null).SetTextVariable("SETTLEMENT", settlement.Name).SetTextVariable("PRISON_SETTLEMENT", val2.Name);
				InformationManager.ShowInquiry(new InquiryData(((object)new TextObject("{=AIInfluence_PlayerCaptured_Title}You have been captured", (Dictionary<string, object>)null)).ToString(), ((object)val4).ToString(), true, false, ((object)GameTexts.FindText("str_ok", (string)null)).ToString(), string.Empty, (Action)null, (Action)null, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), true, false);
			}
			catch (Exception ex5)
			{
				_logger.LogError("HandlePlayerKnockoutConsequences_Capture", ex5.Message, ex5);
			}
		}
		catch (Exception ex6)
		{
			_logger.LogError("HandlePlayerKnockoutConsequences", ex6.Message, ex6);
		}
	}
}
