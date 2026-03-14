using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Behaviors.AIActions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.SettlementCombat;

public class CivilianBehavior
{
	private enum CivilianType
	{
		Man,
		Woman,
		Child
	}

	private enum CivilianState
	{
		Panic,
		Fight
	}

	private readonly AIInfluenceBehavior _behavior;

	private readonly SettlementCombatLogger _logger;

	private readonly Random _random = new Random();

	private readonly HashSet<Agent> _panickedCivilians = new HashSet<Agent>();

	private readonly HashSet<Agent> _fightingCivilians = new HashSet<Agent>();

	private Dictionary<Agent, float> _phraseTimers = new Dictionary<Agent, float>();

	private readonly Dictionary<Agent, CivilianState> _civilianStates = new Dictionary<Agent, CivilianState>();

	private Team _civilianTeam;

	private List<string> _phrasesManPanic = new List<string>();

	private List<string> _phrasesManFight = new List<string>();

	private List<string> _phrasesWoman = new List<string>();

	private List<string> _phrasesChild = new List<string>();

	private List<string> _initialPhrasesMalePanic = new List<string>();

	private List<string> _initialPhrasesMaleFight = new List<string>();

	private List<string> _initialPhrasesFemale = new List<string>();

	private List<string> _initialPhrasesChild = new List<string>();

	private ActiveCombat _currentCombat;

	private CombatSituationAnalysis _currentAnalysis;

	private HashSet<Agent> _processedAgents = new HashSet<Agent>();

	private Dictionary<Agent, WorldPosition> _lastFleePositions = new Dictionary<Agent, WorldPosition>();

	public CivilianBehavior(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
		_logger = SettlementCombatLogger.Instance;
	}

	public void InitiatePanic(ActiveCombat combat, bool hasChildren = true)
	{
		try
		{
			Mission current = Mission.Current;
			if (current == null)
			{
				_logger.Log("[CIVILIAN_BEHAVIOR] No active mission");
				return;
			}
			CombatSituationAnalysis analysis = combat.Analysis;
			if (analysis == null)
			{
				_logger.Log("[CIVILIAN_BEHAVIOR] No analysis available");
				return;
			}
			if (!analysis.CivilianPanic)
			{
				_logger.Log("[CIVILIAN_BEHAVIOR] civilian_panic = false, skipping panic initialization (silent combat)");
				_currentCombat = combat;
				_currentAnalysis = analysis;
				Cleanup();
				return;
			}
			_currentCombat = combat;
			_currentAnalysis = analysis;
			_processedAgents.Clear();
			Cleanup();
			_phraseTimers.Clear();
			_logger.Log($"[CIVILIAN_BEHAVIOR] Initiating civilian panic in {combat.Settlement.Name} (children present: {hasChildren})");
			_logger.Log($"[CIVILIAN_BEHAVIOR] _currentAnalysis set: AggressorStringId={analysis.AggressorStringId}, CivilianPanic={analysis.CivilianPanic}");
			_logger.Log(string.Format("[CIVILIAN_BEHAVIOR] Mission scene: {0}, Total agents in mission: {1}", current.SceneName ?? "Unknown", ((IEnumerable<Agent>)current.Agents)?.Count() ?? 0));
			if (!current.MissionBehaviors.OfType<SettlementCombatMissionLogic>().Any())
			{
				_logger.Log("[CIVILIAN_BEHAVIOR] SettlementCombatMissionLogic not found in mission - adding it now");
				SettlementCombatManager settlementCombatManager = _behavior.GetSettlementCombatManager();
				if (settlementCombatManager != null)
				{
					CombatStatistics statistics = settlementCombatManager.GetStatistics();
					if (statistics != null)
					{
						SettlementCombatMissionLogic settlementCombatMissionLogic = new SettlementCombatMissionLogic(statistics, _behavior, this, settlementCombatManager);
						current.AddMissionBehavior((MissionBehavior)(object)settlementCombatMissionLogic);
						_logger.Log("[CIVILIAN_BEHAVIOR] SettlementCombatMissionLogic added to mission - OnTick will now be called");
					}
					else
					{
						_logger.Log("[CIVILIAN_BEHAVIOR] ERROR: Cannot add SettlementCombatMissionLogic - CombatStatistics is null!");
					}
				}
				else
				{
					_logger.Log("[CIVILIAN_BEHAVIOR] ERROR: Cannot add SettlementCombatMissionLogic - SettlementCombatManager is null!");
				}
			}
			else
			{
				_logger.Log("[CIVILIAN_BEHAVIOR] SettlementCombatMissionLogic already exists in mission - OnTick will be called");
			}
			if (!hasChildren && analysis.CivilianPhrasesChild != null)
			{
				analysis.CivilianPhrasesChild.Clear();
				_logger.Log("Child phrases cleared - no children in this location");
			}
			Agent val = null;
			if (combat.TriggerType == CombatTriggerType.NPCAttack && combat.TriggerNPC != null)
			{
				val = ((IEnumerable<Agent>)current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.IsActive() && a.Character != null && ((MBObjectBase)a.Character).StringId == ((MBObjectBase)combat.TriggerNPC).StringId));
				if (val != null)
				{
					_logger.Log("[CIVILIAN_BEHAVIOR] Trigger NPC " + (val.Name?.ToString() ?? "Unknown") + " will ALWAYS fight (aggressor)");
					MakeCivilianFight(val, analysis);
					_processedAgents.Add(val);
				}
				else
				{
					_logger.Log("[CIVILIAN_BEHAVIOR] WARNING: Trigger NPC not found in mission agents!");
				}
			}
			List<Agent> list = FindCivilians(current, combat);
			_logger.Log($"[CIVILIAN_BEHAVIOR] Found {list.Count} civilians in mission for panic/fight processing");
			if (list.Count == 0)
			{
				_logger.Log("[CIVILIAN_BEHAVIOR] No civilians found immediately, will retry in 1 second (transition case)");
				_behavior.GetDelayedTaskManager()?.AddTask(1.0, delegate
				{
					try
					{
						if (Mission.Current != null && _currentCombat != null && _currentAnalysis != null)
						{
							List<Agent> list2 = FindCivilians(Mission.Current, _currentCombat);
							_logger.Log($"[CIVILIAN_BEHAVIOR] Retry: Found {list2.Count} civilians after delay");
							if (list2.Count > 0)
							{
								Agent triggerAgent = null;
								if (_currentCombat.TriggerType == CombatTriggerType.NPCAttack && _currentCombat.TriggerNPC != null)
								{
									triggerAgent = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.IsActive() && a.Character != null && ((MBObjectBase)a.Character).StringId == ((MBObjectBase)_currentCombat.TriggerNPC).StringId));
								}
								ProcessCiviliansForPanicAndFight(list2, _currentCombat, _currentAnalysis, triggerAgent);
							}
						}
					}
					catch (Exception ex2)
					{
						_logger.LogError("InitiatePanic_Retry", ex2.Message, ex2);
					}
				});
			}
			else
			{
				ProcessCiviliansForPanicAndFight(list, combat, analysis, val);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("InitiatePanic", ex.Message, ex);
		}
	}

	private void ProcessCiviliansForPanicAndFight(List<Agent> civilians, ActiveCombat combat, CombatSituationAnalysis analysis, Agent triggerAgent)
	{
		try
		{
			if (civilians == null || civilians.Count == 0)
			{
				_logger.Log("[CIVILIAN_BEHAVIOR] No civilians to process");
				return;
			}
			DelayedTaskManager delayedTaskManager = _behavior.GetDelayedTaskManager();
			if (delayedTaskManager != null)
			{
				delayedTaskManager.AddTask(1.0, delegate
				{
					try
					{
						List<Agent> list = new List<Agent>();
						foreach (Agent civilian in civilians)
						{
							if (triggerAgent == null || civilian != triggerAgent)
							{
								if (!analysis.CivilianPanic)
								{
									BasicCharacterObject character2 = civilian.Character;
									CharacterObject val2 = (CharacterObject)(object)((character2 is CharacterObject) ? character2 : null);
									if (val2 != null && ((BasicCharacterObject)val2).IsHero && val2.HeroObject != null && val2.HeroObject.IsNotable)
									{
										continue;
									}
								}
								CivilianType civilianType2 = GetCivilianType(civilian);
								if (civilianType2 != CivilianType.Child)
								{
									bool flag2 = HasUsableWeapon(civilian);
									switch (civilianType2)
									{
									case CivilianType.Woman:
										if (flag2)
										{
											list.Add(civilian);
										}
										break;
									case CivilianType.Man:
									{
										double num3 = 0.25;
										bool flag3 = _random.NextDouble() < num3;
										_logger.Log($"Man {civilian.Name}: hasWeapon={flag2}, fightChance={num3:F2}, shouldFight={flag3}");
										if (flag3)
										{
											list.Add(civilian);
										}
										break;
									}
									}
								}
							}
						}
						_logger.Log($"[CIVILIAN_BEHAVIOR] Applying fight state to {list.Count} civilians (delayed 1s)");
						foreach (Agent item in list)
						{
							if (item != null && item.IsActive())
							{
								_processedAgents.Add(item);
								MakeCivilianFight(item, analysis);
							}
						}
					}
					catch (Exception ex2)
					{
						_logger.LogError("DelayedFightInit", ex2.Message, ex2);
					}
				});
				delayedTaskManager.AddTask(2.0, delegate
				{
					try
					{
						List<Agent> list = new List<Agent>();
						List<Agent> list2 = new List<Agent>();
						foreach (Agent civilian2 in civilians)
						{
							if ((triggerAgent == null || civilian2 != triggerAgent) && !_processedAgents.Contains(civilian2) && !_fightingCivilians.Contains(civilian2))
							{
								if (!analysis.CivilianPanic)
								{
									BasicCharacterObject character2 = civilian2.Character;
									CharacterObject val2 = (CharacterObject)(object)((character2 is CharacterObject) ? character2 : null);
									if (val2 != null && ((BasicCharacterObject)val2).IsHero && val2.HeroObject != null && val2.HeroObject.IsNotable)
									{
										continue;
									}
								}
								CivilianType civilianType2 = GetCivilianType(civilian2);
								bool flag2 = HasUsableWeapon(civilian2);
								switch (civilianType2)
								{
								case CivilianType.Child:
									list2.Add(civilian2);
									break;
								case CivilianType.Woman:
									if (!flag2)
									{
										list.Add(civilian2);
									}
									break;
								case CivilianType.Man:
									list.Add(civilian2);
									break;
								}
							}
						}
						_logger.Log($"[CIVILIAN_BEHAVIOR] Applying panic state to {list.Count} civilians and {list2.Count} children (delayed 2s)");
						foreach (Agent item2 in list)
						{
							if (item2 != null && item2.IsActive())
							{
								_processedAgents.Add(item2);
								MakeCivilianPanic(item2, analysis);
							}
						}
						foreach (Agent item3 in list2)
						{
							if (item3 != null && item3.IsActive())
							{
								_processedAgents.Add(item3);
								MakeCivilianPanicNonKillable(item3, analysis);
							}
						}
						_logger.Log($"[CIVILIAN_BEHAVIOR] {_panickedCivilians.Count} panicking, {_fightingCivilians.Count} fighting");
						int num3 = _panickedCivilians.Count + _fightingCivilians.Count;
						_logger.LogCivilianPanic(num3, civilians.Count, ((MBObjectBase)combat.Settlement).StringId);
						_logger.Log($"[CIVILIAN_BEHAVIOR] Total processed: {num3} (panicking: {_panickedCivilians.Count}, fighting: {_fightingCivilians.Count})");
					}
					catch (Exception ex2)
					{
						_logger.LogError("DelayedPanicInit", ex2.Message, ex2);
					}
				});
				_logger.Log("[CIVILIAN_BEHAVIOR] Scheduled delayed initialization: fighting civilians in 1s, panicking civilians in 2s");
			}
			else
			{
				_logger.Log("[CIVILIAN_BEHAVIOR] WARNING: DelayedTaskManager is null, applying states immediately");
				foreach (Agent civilian3 in civilians)
				{
					if (triggerAgent != null && civilian3 == triggerAgent)
					{
						continue;
					}
					if (!analysis.CivilianPanic)
					{
						BasicCharacterObject character = civilian3.Character;
						CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
						if (val != null && ((BasicCharacterObject)val).IsHero && val.HeroObject != null && val.HeroObject.IsNotable)
						{
							continue;
						}
					}
					_processedAgents.Add(civilian3);
					CivilianType civilianType = GetCivilianType(civilian3);
					bool flag = HasUsableWeapon(civilian3);
					switch (civilianType)
					{
					case CivilianType.Child:
						MakeCivilianPanicNonKillable(civilian3, analysis);
						break;
					case CivilianType.Woman:
						if (flag)
						{
							MakeCivilianFight(civilian3, analysis);
						}
						else
						{
							MakeCivilianPanic(civilian3, analysis);
						}
						break;
					case CivilianType.Man:
					{
						double num = 0.25;
						if (_random.NextDouble() < num)
						{
							MakeCivilianFight(civilian3, analysis);
						}
						else
						{
							MakeCivilianPanic(civilian3, analysis);
						}
						break;
					}
					}
				}
				_logger.Log($"[CIVILIAN_BEHAVIOR] {_panickedCivilians.Count} panicking, {_fightingCivilians.Count} fighting");
				int num2 = _panickedCivilians.Count + _fightingCivilians.Count;
				_logger.LogCivilianPanic(num2, civilians.Count, ((MBObjectBase)combat.Settlement).StringId);
				_logger.Log($"[CIVILIAN_BEHAVIOR] Total processed: {num2} (panicking: {_panickedCivilians.Count}, fighting: {_fightingCivilians.Count})");
			}
			StartPhraseSystem(analysis);
		}
		catch (Exception ex)
		{
			_logger.LogError("InitiatePanic", ex.Message, ex);
		}
	}

	public void ForceAgentPanic(Agent agent)
	{
		try
		{
			if (agent != null && agent.IsActive())
			{
				CombatSituationAnalysis analysis = _currentAnalysis ?? new CombatSituationAnalysis();
				SetCivilianState(agent, CivilianState.Panic, delegate
				{
					MakeCivilianPanicInternal(agent, analysis);
				});
				_logger.Log("[CIVILIAN_BEHAVIOR] Forced panic for agent " + agent.Name);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("ForceAgentPanic", ex.Message, ex);
		}
	}

	private List<Agent> FindCivilians(Mission mission, ActiveCombat combat)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Invalid comparison between Unknown and I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Invalid comparison between Unknown and I4
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Invalid comparison between Unknown and I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Invalid comparison between Unknown and I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Invalid comparison between Unknown and I4
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Invalid comparison between Unknown and I4
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		List<Agent> list = new List<Agent>();
		foreach (Agent item in (List<Agent>)(object)mission.Agents)
		{
			if (item == null || !item.IsActive() || !item.IsHuman)
			{
				continue;
			}
			BasicCharacterObject character = item.Character;
			CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
			if (val == null)
			{
				continue;
			}
			bool flag = (int)val.Occupation == 7 || (int)val.Occupation == 24 || (int)val.Occupation == 23 || (int)val.Occupation == 30 || (int)val.Occupation == 2 || (int)val.Occupation == 29;
			bool flag2 = ((BasicCharacterObject)val).IsHero && val.HeroObject != null && val.HeroObject.IsLord && HasUsableWeapon(item);
			if (flag || flag2)
			{
				continue;
			}
			if (item.Team == mission.PlayerTeam)
			{
				PlayerReinforcementMissionLogic missionBehavior = mission.GetMissionBehavior<PlayerReinforcementMissionLogic>();
				if ((missionBehavior != null && missionBehavior.IsSummonedTroop(item)) || IsCompanionOrFollower(item))
				{
					continue;
				}
			}
			if ((item.Team != mission.DefenderTeam || !Extensions.HasAnyFlag<AgentFlag>(item.GetAgentFlags(), (AgentFlag)8)) && !IsCompanionOrFollower(item))
			{
				bool flag3 = IsCivilian(val);
				bool flag4 = ((BasicCharacterObject)val).IsHero && ((BasicCharacterObject)val).IsFemale && !HasUsableWeapon(item);
				if (flag3 || flag4)
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	private bool IsCivilian(CharacterObject character)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected I4, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		if (((BasicCharacterObject)character).IsHero)
		{
			Hero heroObject = character.HeroObject;
			if (heroObject.IsLord)
			{
				return false;
			}
		}
		Occupation occupation = character.Occupation;
		Occupation val = occupation;
		if ((int)val <= 7)
		{
			if ((int)val != 2 && (int)val != 7)
			{
				goto IL_0081;
			}
		}
		else if ((int)val != 15)
		{
			switch (val - 21)
			{
			case 0:
			case 2:
			case 3:
			case 6:
			case 8:
			case 9:
				break;
			default:
				goto IL_0081;
			}
		}
		return false;
		IL_0081:
		return true;
	}

	private void MakeCivilianPanic(Agent civilian, CombatSituationAnalysis analysis)
	{
		if (!IsCompanionOrFollower(civilian))
		{
			SetCivilianState(civilian, CivilianState.Panic, delegate
			{
				MakeCivilianPanicInternal(civilian, analysis);
			});
		}
	}

	private void MakeCivilianPanicNonKillable(Agent civilian, CombatSituationAnalysis analysis)
	{
		if (!IsCompanionOrFollower(civilian))
		{
			SetCivilianState(civilian, CivilianState.Panic, delegate
			{
				MakeCivilianPanicNonKillableInternal(civilian, analysis);
			});
		}
	}

	private void MakeCivilianFight(Agent civilian, CombatSituationAnalysis analysis)
	{
		if (IsCompanionOrFollower(civilian))
		{
			return;
		}
		if (_panickedCivilians.Contains(civilian))
		{
			_logger.Log("WARNING: Cannot make " + civilian.Name + " fight - already in panicked list");
			return;
		}
		SetCivilianState(civilian, CivilianState.Fight, delegate
		{
			MakeCivilianFightInternal(civilian, analysis);
		});
	}

	private bool IsCompanionOrFollower(Agent agent)
	{
		try
		{
			if (((agent != null) ? agent.Character : null) == null)
			{
				return false;
			}
			BasicCharacterObject character = agent.Character;
			CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
			if (val == null)
			{
				return false;
			}
			Hero heroObject = val.HeroObject;
			if (heroObject == null)
			{
				return false;
			}
			if (heroObject.CompanionOf == Clan.PlayerClan || heroObject == Hero.MainHero.Spouse)
			{
				return true;
			}
			AIActionManager instance = AIActionManager.Instance;
			if (instance != null && instance.IsActionActive(heroObject, "follow_player"))
			{
				return true;
			}
			SettlementCombatManager settlementCombatManager = _behavior.GetSettlementCombatManager();
			if (settlementCombatManager != null && settlementCombatManager.TryGetCompanionDecision(((MBObjectBase)heroObject).StringId, out var _))
			{
				return true;
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("IsCompanionOrFollower", ex.Message, ex);
		}
		return false;
	}

	private void StartPhraseSystem(CombatSituationAnalysis analysis)
	{
		try
		{
			if (analysis != null)
			{
				if (_initialPhrasesMalePanic.Count == 0 && analysis.CivilianPhrasesMalePanic != null)
				{
					_initialPhrasesMalePanic = new List<string>(analysis.CivilianPhrasesMalePanic);
				}
				if (_initialPhrasesMaleFight.Count == 0 && analysis.CivilianPhrasesMaleFight != null)
				{
					_initialPhrasesMaleFight = new List<string>(analysis.CivilianPhrasesMaleFight);
				}
				if (_initialPhrasesFemale.Count == 0 && analysis.CivilianPhrasesFemale != null)
				{
					_initialPhrasesFemale = new List<string>(analysis.CivilianPhrasesFemale);
				}
				if (_initialPhrasesChild.Count == 0 && analysis.CivilianPhrasesChild != null)
				{
					_initialPhrasesChild = new List<string>(analysis.CivilianPhrasesChild);
				}
				_phrasesManPanic = new List<string>(_initialPhrasesMalePanic);
				_phrasesManFight = new List<string>(_initialPhrasesMaleFight);
				_phrasesWoman = new List<string>(_initialPhrasesFemale);
				_phrasesChild = new List<string>(_initialPhrasesChild);
				int num = _phrasesManPanic.Count + _phrasesManFight.Count + _phrasesWoman.Count + _phrasesChild.Count;
				_logger.Log($"[CIVILIAN_BEHAVIOR] Phrase system started with {num} total phrases");
				_logger.Log($"Phrases loaded: {_phrasesManPanic.Count} panic men, {_phrasesManFight.Count} fighting men, {_phrasesWoman.Count} women, {_phrasesChild.Count} children");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("StartPhraseSystem", ex.Message, ex);
		}
	}

	private void GiveSimpleWeaponToCivilian(Agent civilian)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Invalid comparison between Unknown and I4
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Invalid comparison between Unknown and I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Invalid comparison between Unknown and I4
		try
		{
			if (civilian == null || !civilian.IsActive())
			{
				return;
			}
			EquipmentIndex? val = null;
			for (EquipmentIndex val2 = (EquipmentIndex)0; (int)val2 < 5; val2 = (EquipmentIndex)(val2 + 1))
			{
				MissionWeapon val3 = civilian.Equipment[val2];
				if ((val3).IsEmpty)
				{
					val = val2;
					break;
				}
			}
			if (!val.HasValue)
			{
				civilian.Equipment[(EquipmentIndex)0] = MissionWeapon.Invalid;
				val = (EquipmentIndex)0;
			}
			List<ItemObject> list = new List<ItemObject>();
			MBReadOnlyList<ItemObject> objectTypeList = MBObjectManager.Instance.GetObjectTypeList<ItemObject>();
			foreach (ItemObject item in (List<ItemObject>)(object)objectTypeList)
			{
				if (item == null)
				{
					continue;
				}
				WeaponComponent weaponComponent = item.WeaponComponent;
				if (weaponComponent == null || (int)item.Tier > 0)
				{
					continue;
				}
				WeaponComponentData primaryWeapon = weaponComponent.PrimaryWeapon;
				if (primaryWeapon != null)
				{
					WeaponClass weaponClass = primaryWeapon.WeaponClass;
					if ((int)weaponClass != 16 && (int)weaponClass != 17)
					{
						list.Add(item);
					}
				}
			}
			if (list.Count > 0)
			{
				ItemObject val4 = list[_random.Next(list.Count)];
				MissionWeapon val5 = default(MissionWeapon);
				(val5)._002Ector(val4, (ItemModifier)null, (Banner)null);
				civilian.Equipment[val.Value] = val5;
				_logger.Log($"Gave tier 1 weapon '{((MBObjectBase)val4).StringId}' to civilian {civilian.Name} in slot {val.Value}");
			}
			else
			{
				_logger.Log("WARNING: Could not find tier 1 melee weapon for civilian " + civilian.Name);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("GiveSimpleWeaponToCivilian", ex.Message, ex);
		}
	}

	private void WieldWeapon(Agent agent)
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
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
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
				if (!(val3).IsEmpty)
				{
					val3 = agent.Equipment[val2];
					WeaponClass weaponClass = (val3).CurrentUsageItem.WeaponClass;
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
				_logger.Log($"Agent {agent.Name} wielding weapon from slot {val}");
			}
			else
			{
				_logger.Log("WARNING: Agent " + agent.Name + " has no weapons to wield!");
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("WieldWeapon", ex.Message, ex);
		}
	}

	private CivilianType GetCivilianType(Agent civilian)
	{
		BasicCharacterObject character = civilian.Character;
		CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
		if (val == null)
		{
			return CivilianType.Man;
		}
		if (((BasicCharacterObject)val).Age < 18f)
		{
			return CivilianType.Child;
		}
		if (((BasicCharacterObject)val).IsFemale)
		{
			return CivilianType.Woman;
		}
		return CivilianType.Man;
	}

	public void OnTick(float dt)
	{
		try
		{
			if (Mission.Current != null && _currentCombat != null && _currentAnalysis != null)
			{
				SettlementCombatManager settlementCombatManager = _behavior?.GetSettlementCombatManager();
				if (settlementCombatManager != null && settlementCombatManager.IsActiveCombat())
				{
					RestorePanicAnimationForPanickingAgents();
					ClearPanicAnimationForFightingAgents();
					UpdateFleeingFromAggressors(dt);
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("CivilianBehavior.OnTick", ex.Message, ex);
		}
	}

	private void ClearPanicAnimationForFightingAgents()
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			foreach (Agent item in _fightingCivilians.ToList())
			{
				if (item == null || !item.IsActive() || !_civilianStates.TryGetValue(item, out var value) || value != CivilianState.Fight)
				{
					continue;
				}
				if (!HasUsableWeapon(item))
				{
					_logger.Log("WARNING: Fighting civilian " + item.Name + " has no weapon, converting to panic!");
					_fightingCivilians.Remove(item);
					AgentFlag agentFlags = item.GetAgentFlags();
					agentFlags = (AgentFlag)(agentFlags & -9);
					agentFlags = (AgentFlag)(agentFlags & -17);
					agentFlags = (AgentFlag)(agentFlags | 0x20);
					item.SetAgentFlags(agentFlags);
					item.SetAlarmState((AIStateFlag)0);
					item.SetLookAgent((Agent)null);
					if (_currentAnalysis != null)
					{
						MakeCivilianPanic(item, _currentAnalysis);
					}
					continue;
				}
				if (!item.IsAlarmed())
				{
					item.SetAlarmState((AIStateFlag)3);
				}
				if ((int)item.CurrentWatchState != 2)
				{
					item.SetWatchState((WatchState)2);
				}
				AgentFlag agentFlags2 = item.GetAgentFlags();
				if (!Extensions.HasAnyFlag<AgentFlag>(agentFlags2, (AgentFlag)24))
				{
					agentFlags2 = (AgentFlag)(agentFlags2 | 8);
					agentFlags2 = (AgentFlag)(agentFlags2 | 0x10);
					agentFlags2 = (AgentFlag)(agentFlags2 & -33);
					agentFlags2 = (AgentFlag)(agentFlags2 & -4097);
					item.SetAgentFlags(agentFlags2);
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("ClearPanicAnimationForFightingAgents", ex.Message, ex);
		}
	}

	private void RestorePanicAnimationForPanickingAgents()
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			foreach (Agent item in _panickedCivilians.ToList())
			{
				if (item == null || !item.IsActive())
				{
					continue;
				}
				if (_fightingCivilians.Contains(item))
				{
					_panickedCivilians.Remove(item);
					_lastFleePositions.Remove(item);
					item.SetAlarmState((AIStateFlag)0);
					item.SetWatchState((WatchState)2);
					item.SetLookAgent((Agent)null);
					continue;
				}
				if (_civilianStates.TryGetValue(item, out var value) && value == CivilianState.Fight)
				{
					_panickedCivilians.Remove(item);
					_lastFleePositions.Remove(item);
					item.SetAlarmState((AIStateFlag)0);
					item.SetWatchState((WatchState)2);
					item.SetLookAgent((Agent)null);
					continue;
				}
				if (!item.IsAlarmed())
				{
					item.SetAlarmState((AIStateFlag)3);
					item.SetWatchState((WatchState)2);
				}
				AgentFlag val = item.GetAgentFlags();
				bool flag = false;
				if (Extensions.HasAnyFlag<AgentFlag>(val, (AgentFlag)24))
				{
					val = (AgentFlag)(val & -9);
					val = (AgentFlag)(val & -17);
					val = (AgentFlag)(val | 0x20);
					val = (AgentFlag)(val & -4097);
					flag = true;
				}
				if (!Extensions.HasAnyFlag<AgentFlag>(val, (AgentFlag)32))
				{
					val = (AgentFlag)(val | 0x20);
					flag = true;
				}
				if (HasUsableWeapon(item))
				{
					DropAllWeapons(item);
				}
				if (flag)
				{
					item.SetAgentFlags(val);
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("RestorePanicAnimationForPanickingAgents", ex.Message, ex);
		}
	}

	private void UpdateFleeingFromAggressors(float dt)
	{
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (_currentAnalysis == null || Mission.Current == null)
			{
				return;
			}
			SettlementCombatManager settlementCombatManager = _behavior?.GetSettlementCombatManager();
			if (settlementCombatManager == null || !settlementCombatManager.IsActiveCombat())
			{
				return;
			}
			List<Agent> aggressorAgents = GetAggressorAgents();
			if (aggressorAgents.Count == 0)
			{
				return;
			}
			Vec3 val4 = default(Vec3);
			WorldPosition val5 = default(WorldPosition);
			foreach (Agent item in _panickedCivilians.ToList())
			{
				if (item == null || !item.IsActive())
				{
					if (item != null)
					{
						_lastFleePositions.Remove(item);
					}
					continue;
				}
				if (_fightingCivilians.Contains(item))
				{
					_lastFleePositions.Remove(item);
					continue;
				}
				if (_civilianStates.TryGetValue(item, out var value) && value == CivilianState.Fight)
				{
					_panickedCivilians.Remove(item);
					_lastFleePositions.Remove(item);
					continue;
				}
				Agent val = null;
				float num = float.MaxValue;
				Vec3 position;
				foreach (Agent item2 in aggressorAgents)
				{
					if (item2 != null && item2.IsActive())
					{
						position = item.Position;
						float num2 = (position).DistanceSquared(item2.Position);
						if (num2 < num)
						{
							num = num2;
							val = item2;
						}
					}
				}
				float num3 = ((val != null) ? MathF.Sqrt(num) : float.MaxValue);
				if (val != null && num3 > 42f)
				{
					item.SetLookAgent(val);
				}
				else if (val != null && num <= 2025f)
				{
					item.SetLookAgent((Agent)null);
					position = item.Position;
					Vec2 asVec = (position).AsVec2;
					position = val.Position;
					Vec2 val2 = asVec - (position).AsVec2;
					float num4 = (val2).Normalize();
					if (num4 < 0.1f)
					{
						float num5 = (float)(_random.NextDouble() * Math.PI * 2.0);
						(val2)._002Ector(MathF.Cos(num5), MathF.Sin(num5));
					}
					WorldPosition value2 = FindSafeFleePosition(item, val2, val, 35f);
					if (!(value2).IsValid)
					{
						position = item.Position;
						Vec2 val3 = (position).AsVec2 + val2 * 35f;
						(val4)._002Ector(val3.x, val3.y, item.Position.z, -1f);
						(val5)._002Ector(Mission.Current.Scene, UIntPtr.Zero, val4, false);
						Vec3 groundVec = (val5).GetGroundVec3();
						(value2)._002Ector(Mission.Current.Scene, UIntPtr.Zero, groundVec, false);
					}
					item.SetScriptedPosition(ref value2, false, (AIScriptedFrameFlags)0);
					_lastFleePositions[item] = value2;
					item.SetMaximumSpeedLimit(-1f, false);
				}
				else if (val != null)
				{
					item.SetLookAgent((Agent)null);
					if (_lastFleePositions.ContainsKey(item))
					{
						item.DisableScriptedMovement();
						_lastFleePositions.Remove(item);
					}
				}
				else
				{
					item.SetLookAgent((Agent)null);
					if (_lastFleePositions.ContainsKey(item))
					{
						item.DisableScriptedMovement();
						_lastFleePositions.Remove(item);
					}
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("UpdateFleeingFromAggressors", ex.Message, ex);
		}
	}

	private WorldPosition FindSafeFleePosition(Agent civilian, Vec2 preferredDirection, Agent aggressor, float fleeDistance)
	{
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current == null || civilian == null || !civilian.IsActive())
			{
				return WorldPosition.Invalid;
			}
			Vec3 position = civilian.Position;
			Vec2 asVec = (position).AsVec2;
			Vec3 position2 = civilian.Position;
			List<Vec2> list = new List<Vec2>();
			list.Add(preferredDirection);
			float num = MathF.Atan2(preferredDirection.y, preferredDirection.x);
			for (int i = -2; i <= 2; i++)
			{
				if (i != 0)
				{
					float num2 = num + (float)i * (float)Math.PI / 4f;
					list.Add(new Vec2(MathF.Cos(num2), MathF.Sin(num2)));
				}
			}
			Vec3 val4 = default(Vec3);
			WorldPosition result = default(WorldPosition);
			foreach (Vec2 item in list)
			{
				Vec2 val = asVec + item * fleeDistance;
				bool flag = true;
				for (int j = 1; j <= 5; j++)
				{
					float num3 = (float)j / 5f;
					Vec2 val2 = asVec + item * (fleeDistance * num3);
					float num4 = 0f;
					Mission.Current.Scene.GetHeightAtPoint(val2, (BodyFlags)544321929, ref num4);
					float num5 = position2.z + num3 * (num4 - position2.z);
					float num6 = MathF.Abs(num4 - num5);
					if (num6 > 2f)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				float num7 = 0f;
				Mission.Current.Scene.GetHeightAtPoint(val, (BodyFlags)544321929, ref num7);
				float num8 = MathF.Abs(num7 - position2.z);
				if (num8 > 2f)
				{
					continue;
				}
				Vec2[] array = (Vec2[])(object)new Vec2[5]
				{
					new Vec2(val.x + 15f, val.y),
					new Vec2(val.x - 15f, val.y),
					new Vec2(val.x, val.y + 15f),
					new Vec2(val.x, val.y - 15f),
					val
				};
				bool flag2 = true;
				float num9 = 0f;
				Vec2[] array2 = array;
				foreach (Vec2 val3 in array2)
				{
					float num10 = 0f;
					Mission.Current.Scene.GetHeightAtPoint(val3, (BodyFlags)544321929, ref num10);
					float num11 = MathF.Abs(num10 - num7);
					if (num11 > num9)
					{
						num9 = num11;
					}
				}
				if (num9 > 2f)
				{
					continue;
				}
				if (aggressor != null && aggressor.IsActive())
				{
					position = aggressor.Position;
					Vec2 asVec2 = (position).AsVec2;
					float num12 = (val).DistanceSquared(asVec2);
					if (num12 < 4f)
					{
						continue;
					}
				}
				(val4)._002Ector(val.x, val.y, num7, -1f);
				(result)._002Ector(Mission.Current.Scene, UIntPtr.Zero, val4, false);
				return result;
			}
			return WorldPosition.Invalid;
		}
		catch (Exception ex)
		{
			_logger.LogError("FindSafeFleePosition", ex.Message, ex);
			return WorldPosition.Invalid;
		}
	}

	private List<Agent> GetAggressorAgents()
	{
		List<Agent> list = new List<Agent>();
		try
		{
			if (Mission.Current == null || _currentAnalysis == null)
			{
				_logger.Log($"GetAggressorAgents: Mission.Current={Mission.Current != null}, _currentAnalysis={_currentAnalysis != null}");
				return list;
			}
			SettlementCombatManager settlementCombatManager = _behavior?.GetSettlementCombatManager();
			if (settlementCombatManager == null || !settlementCombatManager.IsActiveCombat())
			{
				return list;
			}
			string aggressorId = _currentAnalysis.AggressorStringId;
			if (string.IsNullOrEmpty(aggressorId))
			{
				_logger.Log("GetAggressorAgents: AggressorStringId is null or empty");
				return list;
			}
			if (aggressorId == "main_hero")
			{
				goto IL_0106;
			}
			string text = aggressorId;
			Hero mainHero = Hero.MainHero;
			if (text == ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null))
			{
				goto IL_0106;
			}
			Agent val = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.IsActive() && a.Character != null && ((MBObjectBase)a.Character).StringId == aggressorId));
			if (val != null)
			{
				list.Add(val);
				_logger.Log("GetAggressorAgents: Found NPC aggressor " + val.Name + " (" + aggressorId + ")");
			}
			else
			{
				_logger.Log("GetAggressorAgents: NPC aggressor " + aggressorId + " not found in mission agents");
			}
			goto end_IL_0007;
			IL_0106:
			if (Agent.Main != null && Agent.Main.IsActive())
			{
				list.Add(Agent.Main);
			}
			else
			{
				_logger.Log("GetAggressorAgents: Player is aggressor but Agent.Main is null or inactive");
			}
			end_IL_0007:;
		}
		catch (Exception ex)
		{
			_logger.LogError("GetAggressorAgents", ex.Message, ex);
		}
		return list;
	}

	private void EnsureAgentTeam(Agent civilian)
	{
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current == null || civilian == null)
			{
				return;
			}
			Team aggressorTeam;
			if (_civilianTeam == null || _civilianTeam.Mission != Mission.Current)
			{
				aggressorTeam = null;
				if (_currentAnalysis != null && !string.IsNullOrEmpty(_currentAnalysis.AggressorStringId))
				{
					string aggressorId = _currentAnalysis.AggressorStringId;
					if (!(aggressorId == "main_hero"))
					{
						string text = aggressorId;
						Hero mainHero = Hero.MainHero;
						if (!(text == ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null)))
						{
							Agent val = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.IsActive() && a.Character != null && ((MBObjectBase)a.Character).StringId == aggressorId));
							if (val != null)
							{
								aggressorTeam = val.Team;
							}
							goto IL_0117;
						}
					}
					aggressorTeam = Mission.Current.PlayerTeam;
				}
				goto IL_0117;
			}
			goto IL_0280;
			IL_0280:
			if (civilian.Team != _civilianTeam && _civilianTeam != null)
			{
				civilian.SetTeam(_civilianTeam, false);
			}
			return;
			IL_0117:
			if (Mission.Current.DefenderTeam != null && Mission.Current.DefenderTeam != aggressorTeam)
			{
				_civilianTeam = Mission.Current.DefenderTeam;
			}
			else
			{
				_civilianTeam = ((IEnumerable<Team>)Mission.Current.Teams).FirstOrDefault((Func<Team, bool>)((Team t) => t != null && t != aggressorTeam && t.IsValid)) ?? Mission.Current.DefenderTeam;
				if (_civilianTeam == aggressorTeam)
				{
					_logger.Log("WARNING: Panicking civilians may be on aggressor's team!");
				}
			}
			if (_civilianTeam == null)
			{
				_civilianTeam = Mission.Current.DefenderTeam ?? Mission.Current.PlayerTeam;
				_logger.Log("WARNING: No suitable team found for panicking civilians, using fallback");
			}
			if (_civilianTeam != null && aggressorTeam != null && !_civilianTeam.IsEnemyOf(aggressorTeam))
			{
				_civilianTeam.SetIsEnemyOf(aggressorTeam, true);
				aggressorTeam.SetIsEnemyOf(_civilianTeam, true);
				_logger.Log($"Set enemy relationship: {_civilianTeam.Side} <-> {aggressorTeam.Side} for panicking civilians");
			}
			goto IL_0280;
		}
		catch (Exception ex)
		{
			_logger.LogError("EnsureAgentTeam", ex.Message, ex);
		}
	}

	private void DropAllWeapons(Agent agent)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			for (EquipmentIndex val = (EquipmentIndex)0; (int)val < 5; val = (EquipmentIndex)(val + 1))
			{
				MissionWeapon val2 = agent.Equipment[val];
				if (!(val2).IsEmpty)
				{
					agent.DropItem(val, (WeaponClass)0);
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("DropAllWeapons", ex.Message, ex);
		}
	}

	public void Cleanup()
	{
		_panickedCivilians.Clear();
		_fightingCivilians.Clear();
		_phraseTimers.Clear();
		_civilianStates.Clear();
		_lastFleePositions.Clear();
	}

	public bool IsAgentUnderCivilianControl(Agent agent)
	{
		if (agent == null)
		{
			return false;
		}
		return _civilianStates.ContainsKey(agent);
	}

	public bool IsAgentPanicking(Agent agent)
	{
		if (agent == null)
		{
			return false;
		}
		CivilianState value;
		return _civilianStates.TryGetValue(agent, out value) && value == CivilianState.Panic;
	}

	public bool IsAgentFighting(Agent agent)
	{
		if (agent == null)
		{
			return false;
		}
		CivilianState value;
		return _civilianStates.TryGetValue(agent, out value) && value == CivilianState.Fight;
	}

	private void SetCivilianState(Agent civilian, CivilianState state, Action applyState)
	{
		if (civilian == null || !civilian.IsActive())
		{
			return;
		}
		bool flag = _panickedCivilians.Contains(civilian);
		bool flag2 = _fightingCivilians.Contains(civilian);
		CivilianState value;
		bool flag3 = _civilianStates.TryGetValue(civilian, out value);
		if (flag && flag2)
		{
			_logger.Log("ERROR: Civilian " + civilian.Name + " is in BOTH lists! Removing from both.");
			_panickedCivilians.Remove(civilian);
			_fightingCivilians.Remove(civilian);
			_lastFleePositions.Remove(civilian);
		}
		if (flag3)
		{
			if (value == state)
			{
				applyState();
				return;
			}
			switch (value)
			{
			case CivilianState.Panic:
				_panickedCivilians.Remove(civilian);
				_lastFleePositions.Remove(civilian);
				_logger.Log($"Switching {civilian.Name} from Panic to {state}");
				break;
			case CivilianState.Fight:
				_fightingCivilians.Remove(civilian);
				_logger.Log($"Switching {civilian.Name} from Fight to {state}");
				break;
			}
		}
		switch (state)
		{
		case CivilianState.Fight:
			if (_panickedCivilians.Contains(civilian))
			{
				_logger.Log("WARNING: " + civilian.Name + " is in panicked list when setting Fight state, removing!");
				_panickedCivilians.Remove(civilian);
				_lastFleePositions.Remove(civilian);
			}
			break;
		case CivilianState.Panic:
			if (_fightingCivilians.Contains(civilian))
			{
				_logger.Log("WARNING: " + civilian.Name + " is in fighting list when setting Panic state, removing!");
				_fightingCivilians.Remove(civilian);
			}
			break;
		}
		applyState();
		_civilianStates[civilian] = state;
	}

	private void ApplyCustomPanic(Agent civilian)
	{
		if (civilian != null && civilian.IsActive())
		{
			civilian.SetAlarmState((AIStateFlag)3);
			civilian.SetWatchState((WatchState)2);
		}
	}

	private void MakeCivilianPanicInternal(Agent civilian, CombatSituationAnalysis analysis)
	{
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current == null || civilian == null || !civilian.IsActive())
			{
				return;
			}
			if (_fightingCivilians.Contains(civilian))
			{
				_logger.Log("ERROR: Attempted to apply panic to fighting civilian " + civilian.Name + ", skipping! State: " + (_civilianStates.TryGetValue(civilian, out var value) ? value.ToString() : "none"));
				return;
			}
			if (_civilianStates.TryGetValue(civilian, out var value2) && value2 == CivilianState.Fight)
			{
				_logger.Log("ERROR: Attempted to apply panic to civilian " + civilian.Name + " with Fight state, skipping!");
				return;
			}
			_fightingCivilians.Remove(civilian);
			if (!_panickedCivilians.Contains(civilian))
			{
				_panickedCivilians.Add(civilian);
			}
			else
			{
				_logger.Log("WARNING: " + civilian.Name + " already in panicked list!");
			}
			EnsureAgentTeam(civilian);
			civilian.SetIsAIPaused(false);
			AgentFlag agentFlags = civilian.GetAgentFlags();
			agentFlags = (AgentFlag)(agentFlags & -9);
			agentFlags = (AgentFlag)(agentFlags & -17);
			agentFlags = (AgentFlag)(agentFlags | 0x20);
			agentFlags = (AgentFlag)(agentFlags & -4097);
			civilian.SetAgentFlags(agentFlags);
			AgentFlag agentFlags2 = civilian.GetAgentFlags();
			if (Extensions.HasAnyFlag<AgentFlag>(agentFlags2, (AgentFlag)24))
			{
				_logger.Log($"ERROR: {civilian.Name} still has attack/defend flags after panic setup! Flags: {agentFlags2}");
			}
			civilian.SetLookAgent((Agent)null);
			DropAllWeapons(civilian);
			ApplyCustomPanic(civilian);
			_logger.Log("Custom panic activated for " + civilian.Name);
			_phraseTimers[civilian] = (float)(_random.NextDouble() * 5.0);
		}
		catch (Exception ex)
		{
			_logger.LogError("MakeCivilianPanicInternal", ex.Message, ex);
		}
	}

	private void MakeCivilianPanicNonKillableInternal(Agent civilian, CombatSituationAnalysis analysis)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current != null && civilian != null && civilian.IsActive())
			{
				if (_fightingCivilians.Contains(civilian))
				{
					_logger.Log("WARNING: Attempted to apply panic to fighting civilian " + civilian.Name + ", skipping!");
					return;
				}
				_fightingCivilians.Remove(civilian);
				_panickedCivilians.Add(civilian);
				EnsureAgentTeam(civilian);
				civilian.SetIsAIPaused(false);
				AgentFlag agentFlags = civilian.GetAgentFlags();
				agentFlags = (AgentFlag)(agentFlags & -9);
				agentFlags = (AgentFlag)(agentFlags & -17);
				agentFlags = (AgentFlag)(agentFlags | 0x20);
				civilian.SetAgentFlags(agentFlags);
				civilian.SetLookAgent((Agent)null);
				DropAllWeapons(civilian);
				ApplyCustomPanic(civilian);
				_logger.Log("Custom panic activated for " + civilian.Name + " (non-killable)");
				_phraseTimers[civilian] = (float)(_random.NextDouble() * 5.0);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("MakeCivilianPanicNonKillableInternal", ex.Message, ex);
		}
	}

	private void MakeCivilianFightInternal(Agent civilian, CombatSituationAnalysis analysis)
	{
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Mission.Current != null && civilian != null && civilian.IsActive())
			{
				if (_panickedCivilians.Contains(civilian))
				{
					_panickedCivilians.Remove(civilian);
					_lastFleePositions.Remove(civilian);
					civilian.SetAlarmState((AIStateFlag)0);
					civilian.SetWatchState((WatchState)1);
					civilian.SetLookAgent((Agent)null);
					_logger.Log("WARNING: Civilian " + civilian.Name + " was in panicked list, removed and reset to fight state");
				}
				if (!_fightingCivilians.Contains(civilian))
				{
					_fightingCivilians.Add(civilian);
				}
				else
				{
					_logger.Log("WARNING: " + civilian.Name + " already in fighting list!");
				}
				civilian.SetTeam(Mission.Current.DefenderTeam, false);
				civilian.SetMaximumSpeedLimit(-1f, false);
				civilian.SetWatchState((WatchState)2);
				civilian.SetAlarmState((AIStateFlag)3);
				if (!HasUsableWeapon(civilian))
				{
					GiveSimpleWeaponToCivilian(civilian);
				}
				WieldWeapon(civilian);
				if (!HasUsableWeapon(civilian))
				{
					_logger.Log("WARNING: Civilian " + civilian.Name + " cannot fight without weapon, converting to panic!");
					_fightingCivilians.Remove(civilian);
					AgentFlag agentFlags = civilian.GetAgentFlags();
					agentFlags = (AgentFlag)(agentFlags & -9);
					agentFlags = (AgentFlag)(agentFlags & -17);
					agentFlags = (AgentFlag)(agentFlags | 0x20);
					civilian.SetAgentFlags(agentFlags);
					civilian.SetAlarmState((AIStateFlag)0);
					civilian.SetLookAgent((Agent)null);
					MakeCivilianPanic(civilian, analysis);
				}
				else
				{
					_logger.Log("Fighting civilian " + civilian.Name + ": ready to fight (weapon given, team set, Alarmed state)");
					_phraseTimers[civilian] = (float)(_random.NextDouble() * 5.0);
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("MakeCivilianFightInternal", ex.Message, ex);
		}
	}

	private bool HasUsableWeapon(Agent agent)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (agent == null)
			{
				return false;
			}
			for (EquipmentIndex val = (EquipmentIndex)0; (int)val < 5; val = (EquipmentIndex)(val + 1))
			{
				MissionWeapon val2 = agent.Equipment[val];
				if (!(val2).IsEmpty)
				{
					val2 = agent.Equipment[val];
					if ((val2).Item != null)
					{
						return true;
					}
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}
}
