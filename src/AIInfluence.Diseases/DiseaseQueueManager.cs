using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diseases;

public class DiseaseQueueManager
{
	private enum InfectionPhase
	{
		Idle,
		SyncTroopInstances,
		CheckPlayerSettlement,
		CheckCaravans,
		CheckVillagerParties,
		CheckLords,
		CheckNotables,
		CheckWanderers,
		CheckSettlementForces,
		CheckEpidemics,
		LeaderToTroopSpread,
		CheckAITreatment,
		SeasonalHeroes,
		SeasonalParties,
		SaveAndFinish,
		Done
	}

	private readonly DiseaseManager _manager;

	private const int ITEMS_PER_TICK = 20;

	private InfectionPhase _infectionPhase = InfectionPhase.Idle;

	private int _infectionBatchIndex = 0;

	private List<DiseaseInstance> _snapTroopInstances;

	private List<MobileParty> _snapCaravans;

	private List<MobileParty> _snapVillagerParties;

	private List<Hero> _snapLords;

	private List<Settlement> _snapSettlementsWithDisease;

	private List<Settlement> _snapTownsCastles;

	private List<Settlement> _snapTownsCastlesVillages;

	private List<MobileParty> _snapPartiesWithInfectedLeaders;

	private List<Hero> _snapInfectedAIHeroes;

	private List<Hero> _snapWanderers;

	private List<Hero> _snapTravelingHeroes;

	private List<MobileParty> _snapTravelingParties;

	private List<MobileParty> _dailySpreadParties;

	private int _dailySpreadIndex = 0;

	private bool _dailySpreadActive = false;

	public bool IsInfectionCycleActive => _infectionPhase != InfectionPhase.Idle && _infectionPhase != InfectionPhase.Done;

	public bool IsDailySpreadActive => _dailySpreadActive;

	public DiseaseQueueManager(DiseaseManager manager)
	{
		_manager = manager;
	}

	public void StartInfectionCheckCycle()
	{
		if (IsInfectionCycleActive)
		{
			return;
		}
		List<Hero> source = ((IEnumerable<Hero>)Hero.AllAliveHeroes)?.ToList() ?? new List<Hero>();
		List<MobileParty> source2 = ((IEnumerable<MobileParty>)MobileParty.All)?.ToList() ?? new List<MobileParty>();
		List<Settlement> source3 = ((IEnumerable<Settlement>)Settlement.All)?.ToList() ?? new List<Settlement>();
		_snapTroopInstances = _manager.GetActiveTroopInstances();
		_snapCaravans = source2.Where((MobileParty p) => p != null && p.IsCaravan).ToList();
		_snapVillagerParties = source2.Where(delegate(MobileParty p)
		{
			int result;
			if (p != null && p.IsVillager)
			{
				TroopRoster memberRoster = p.MemberRoster;
				result = ((memberRoster != null && memberRoster.TotalRegulars > 0) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
		_snapLords = source.Where((Hero h) => h.IsLord && h != Hero.MainHero && h.CurrentSettlement != null).ToList();
		_snapSettlementsWithDisease = source3.Where((Settlement s) => s != null && _manager.GetAllDiseasesForSettlement(s).Count > 0).ToList();
		_snapTownsCastles = source3.Where((Settlement s) => s != null && (s.IsTown || s.IsCastle)).ToList();
		_snapTownsCastlesVillages = source3.Where((Settlement s) => s != null && (s.IsTown || s.IsCastle || s.IsVillage)).ToList();
		_snapPartiesWithInfectedLeaders = source2.Where(delegate(MobileParty p)
		{
			int result;
			if (((p != null) ? p.LeaderHero : null) != null)
			{
				TroopRoster memberRoster = p.MemberRoster;
				if (memberRoster != null && memberRoster.TotalRegulars > 0)
				{
					result = (_manager.IsHeroInfected(p.LeaderHero) ? 1 : 0);
					goto IL_003e;
				}
			}
			result = 0;
			goto IL_003e;
			IL_003e:
			return (byte)result != 0;
		}).ToList();
		_snapInfectedAIHeroes = source.Where((Hero h) => h != Hero.MainHero && _manager.IsHeroInfected(h)).ToList();
		HashSet<string> diseasedSettlementIds = new HashSet<string>(_snapSettlementsWithDisease.Select((Settlement s) => ((MBObjectBase)s).StringId));
		_snapWanderers = source.Where((Hero h) => h != null && h.IsAlive && h.IsWanderer && h.CurrentSettlement != null && diseasedSettlementIds.Contains(((MBObjectBase)h.CurrentSettlement).StringId)).ToList();
		_snapTravelingHeroes = source.Where((Hero h) => h != null && h.IsAlive && h.CurrentSettlement == null).ToList();
		_snapTravelingParties = source2.Where(delegate(MobileParty p)
		{
			int result;
			if (p != null && p.CurrentSettlement == null)
			{
				TroopRoster memberRoster = p.MemberRoster;
				result = ((memberRoster != null && memberRoster.TotalRegulars > 0) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
		_infectionBatchIndex = 0;
		_infectionPhase = InfectionPhase.SyncTroopInstances;
	}

	public void StartDailySpreadCycle(List<MobileParty> parties)
	{
		_dailySpreadParties = parties;
		_dailySpreadIndex = 0;
		_dailySpreadActive = parties != null && parties.Count > 0;
	}

	public void Tick()
	{
		if (IsInfectionCycleActive)
		{
			TickInfectionPhase();
		}
		if (_dailySpreadActive)
		{
			TickDailySpread();
		}
	}

	private void TickInfectionPhase()
	{
		try
		{
			switch (_infectionPhase)
			{
			case InfectionPhase.SyncTroopInstances:
				ProcessBatch(_snapTroopInstances, _manager.SyncSingleTroopInstance, InfectionPhase.CheckPlayerSettlement);
				break;
			case InfectionPhase.CheckPlayerSettlement:
				_manager.CheckPlayerSettlementInfection();
				AdvanceInfectionTo(InfectionPhase.CheckCaravans);
				break;
			case InfectionPhase.CheckCaravans:
				ProcessBatch(_snapCaravans, DiseaseSpreadSystem.CheckSingleCaravanInfection, InfectionPhase.CheckVillagerParties);
				break;
			case InfectionPhase.CheckVillagerParties:
				ProcessBatch(_snapVillagerParties, DiseaseSpreadSystem.CheckSingleVillagerPartyInfection, InfectionPhase.CheckLords);
				break;
			case InfectionPhase.CheckLords:
				ProcessBatch(_snapLords, DiseaseSpreadSystem.CheckSingleLordInfection, InfectionPhase.CheckNotables);
				break;
			case InfectionPhase.CheckNotables:
				ProcessBatch(_snapSettlementsWithDisease, DiseaseSpreadSystem.CheckSettlementNotableInfection, InfectionPhase.CheckWanderers);
				break;
			case InfectionPhase.CheckWanderers:
				ProcessBatch(_snapWanderers, DiseaseSpreadSystem.CheckSingleWandererInfection, InfectionPhase.CheckSettlementForces);
				break;
			case InfectionPhase.CheckSettlementForces:
				ProcessBatch(_snapTownsCastlesVillages, _manager.CheckSettlementForcesInfectionSingle, InfectionPhase.CheckEpidemics);
				break;
			case InfectionPhase.CheckEpidemics:
				ProcessBatch(_snapTownsCastles, DiseaseSpreadSystem.CheckSettlementEpidemic, InfectionPhase.LeaderToTroopSpread);
				break;
			case InfectionPhase.LeaderToTroopSpread:
				ProcessBatch(_snapPartiesWithInfectedLeaders, DiseaseSpreadSystem.SpreadDiseaseFromLeaderToTroops, InfectionPhase.CheckAITreatment);
				break;
			case InfectionPhase.CheckAITreatment:
				ProcessBatch(_snapInfectedAIHeroes, _manager.CheckAITreatmentSingle, InfectionPhase.SeasonalHeroes);
				break;
			case InfectionPhase.SeasonalHeroes:
				ProcessBatch(_snapTravelingHeroes, SeasonalDiseaseSystem.ProcessSeasonalCheckForHero, InfectionPhase.SeasonalParties);
				break;
			case InfectionPhase.SeasonalParties:
				ProcessBatch(_snapTravelingParties, SeasonalDiseaseSystem.ProcessSeasonalCheckForParty, InfectionPhase.SaveAndFinish);
				break;
			case InfectionPhase.SaveAndFinish:
				_manager.SaveAll();
				_infectionPhase = InfectionPhase.Done;
				break;
			}
		}
		catch (Exception)
		{
			_infectionPhase = InfectionPhase.Done;
		}
	}

	private void ProcessBatch<T>(List<T> list, Action<T> processItem, InfectionPhase nextPhase)
	{
		if (list == null || _infectionBatchIndex >= list.Count)
		{
			AdvanceInfectionTo(nextPhase);
			return;
		}
		int num = Math.Min(_infectionBatchIndex + 20, list.Count);
		for (int i = _infectionBatchIndex; i < num; i++)
		{
			try
			{
				processItem(list[i]);
			}
			catch (Exception)
			{
			}
		}
		_infectionBatchIndex = num;
		if (_infectionBatchIndex >= list.Count)
		{
			AdvanceInfectionTo(nextPhase);
		}
	}

	private void AdvanceInfectionTo(InfectionPhase phase)
	{
		_infectionPhase = phase;
		_infectionBatchIndex = 0;
	}

	private void TickDailySpread()
	{
		if (_dailySpreadParties == null || _dailySpreadIndex >= _dailySpreadParties.Count)
		{
			_dailySpreadActive = false;
			return;
		}
		int num = Math.Min(_dailySpreadIndex + 20, _dailySpreadParties.Count);
		for (int i = _dailySpreadIndex; i < num; i++)
		{
			try
			{
				DiseaseSpreadSystem.SpreadDiseaseWithinParty(_dailySpreadParties[i]);
				DiseaseSpreadSystem.CheckPrisonerToTroopSpread(_dailySpreadParties[i]);
				DiseaseSpreadSystem.CheckPrisonerHeroSpread(_dailySpreadParties[i]);
			}
			catch (Exception)
			{
			}
		}
		_dailySpreadIndex = num;
		if (_dailySpreadIndex >= _dailySpreadParties.Count)
		{
			_dailySpreadActive = false;
		}
	}
}
