using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.DynamicEvents;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diseases;

public class DiseaseManager
{
	private static DiseaseManager _instance;

	public static string PendingPlayerDiseaseDeathName = null;

	public static readonly Dictionary<string, string> PendingDiseaseDeathNames = new Dictionary<string, string>();

	private DiseaseStorage _storage;

	private List<Disease> _diseases;

	private List<DiseaseInstance> _diseaseInstances;

	private List<SettlementDiseaseInstance> _settlementDiseaseInstances;

	private int _hourlyTickCounter = 0;

	private const int HourlyTicksFor6Hours = 6;

	private int _twelveHourTickCounter = 0;

	private const int HourlyTicksFor12Hours = 12;

	private float _missionInfectionTimer = 0f;

	private const float MissionInfectionInterval = 60f;

	private DiseaseQueueManager _queueManager;

	private Dictionary<string, int> _preBattlePrisonerCounts = new Dictionary<string, int>();

	private Dictionary<MobileParty, Settlement> _partiesGoingForTreatment = new Dictionary<MobileParty, Settlement>();

	private Dictionary<string, float?> _manualQuarantine = new Dictionary<string, float?>();

	private Dictionary<string, Disease> _diseaseIndex = new Dictionary<string, Disease>();

	private Dictionary<string, List<Disease>> _settlementDiseaseIndex = new Dictionary<string, List<Disease>>();

	private Dictionary<string, List<DiseaseInstance>> _heroInstanceIndex = new Dictionary<string, List<DiseaseInstance>>();

	private Dictionary<string, List<DiseaseInstance>> _partyTroopIndex = new Dictionary<string, List<DiseaseInstance>>();

	private Dictionary<string, List<DiseaseInstance>> _partyPrisonerIndex = new Dictionary<string, List<DiseaseInstance>>();

	private Dictionary<string, HashSet<string>> _heroRecoveredDiseaseIds = new Dictionary<string, HashSet<string>>();

	private Dictionary<string, DiseaseInstance> _heroSeasonalImmunityIndex = new Dictionary<string, DiseaseInstance>();

	private Dictionary<string, Hero> _heroLookup = new Dictionary<string, Hero>();

	private Dictionary<string, MobileParty> _partyLookup = new Dictionary<string, MobileParty>();

	private Dictionary<string, Settlement> _settlementLookup = new Dictionary<string, Settlement>();

	private const string LordHallLocationId = "lordshall";

	public static DiseaseManager Instance => _instance;

	public static float PrisonerSpreadModifier => DiseaseSpreadSystem.PrisonerSpreadModifier;

	public IReadOnlyList<Disease> Diseases => _diseases;

	public IReadOnlyList<DiseaseInstance> DiseaseInstances => _diseaseInstances;

	public IReadOnlyList<SettlementDiseaseInstance> SettlementDiseaseInstances => _settlementDiseaseInstances;

	public DiseaseManager()
	{
		_instance = this;
		_storage = new DiseaseStorage();
		_diseases = new List<Disease>();
		_diseaseInstances = new List<DiseaseInstance>();
		_settlementDiseaseInstances = new List<SettlementDiseaseInstance>();
		_queueManager = new DiseaseQueueManager(this);
	}

	public void Initialize()
	{
		_diseases = _storage.LoadDiseases();
		_diseaseInstances = _storage.LoadDiseaseInstances();
		_settlementDiseaseInstances = _storage.LoadSettlementDiseaseInstances();
		_manualQuarantine = _storage.LoadManualQuarantine();
		RebuildEntityLookups();
		RebuildIndexes();
		foreach (DiseaseInstance diseaseInstance in _diseaseInstances)
		{
			if (string.IsNullOrEmpty(diseaseInstance.DiseaseName))
			{
				Disease diseaseById = GetDiseaseById(diseaseInstance.DiseaseId);
				if (diseaseById != null)
				{
					diseaseInstance.DiseaseName = diseaseById.Name;
				}
			}
		}
		CleanupExpiredDiseases();
		CleanupOrphanedInstances();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		foreach (DiseaseInstance diseaseInstance2 in _diseaseInstances)
		{
			if (diseaseInstance2.TargetType != DiseaseTargetType.Hero || diseaseInstance2.IsRecovered || diseaseInstance2.IsDead)
			{
				continue;
			}
			Hero val = LookupHero(diseaseInstance2.TargetId);
			if (val != null)
			{
				if (val.IsLord)
				{
					num++;
				}
				else if (val.IsNotable)
				{
					num2++;
				}
				else if (val.IsWanderer)
				{
					num3++;
				}
				else
				{
					num4++;
				}
			}
		}
		if (num + num2 + num3 + num4 > 0)
		{
			DiseaseLogger.Instance?.Log($"[DISEASE_INIT] Active hero disease instances after cleanup: {num} lords, {num2} notables, {num3} wanderers, {num4} other");
		}
		CleanupRecoveredAndDeadInstances();
	}

	public void SaveAll()
	{
		_storage.SaveAll(_diseases, _diseaseInstances, _settlementDiseaseInstances, _manualQuarantine);
	}

	public void RebuildIndexes()
	{
		_diseaseIndex.Clear();
		_settlementDiseaseIndex.Clear();
		_heroInstanceIndex.Clear();
		_partyTroopIndex.Clear();
		_partyPrisonerIndex.Clear();
		_heroRecoveredDiseaseIds.Clear();
		_heroSeasonalImmunityIndex.Clear();
		foreach (Disease disease in _diseases)
		{
			_diseaseIndex[disease.Id] = disease;
			if (disease.SettlementId != null && !disease.IsExpired())
			{
				if (!_settlementDiseaseIndex.TryGetValue(disease.SettlementId, out var value))
				{
					value = new List<Disease>(2);
					_settlementDiseaseIndex[disease.SettlementId] = value;
				}
				value.Add(disease);
			}
		}
		foreach (DiseaseInstance diseaseInstance in _diseaseInstances)
		{
			IndexInstanceInternal(diseaseInstance);
		}
	}

	private void IndexInstanceInternal(DiseaseInstance inst)
	{
		if (inst.TargetType == DiseaseTargetType.Hero)
		{
			if (!_heroInstanceIndex.TryGetValue(inst.TargetId, out var value))
			{
				value = new List<DiseaseInstance>(2);
				_heroInstanceIndex[inst.TargetId] = value;
			}
			value.Add(inst);
			if (inst.IsRecovered)
			{
				if (!_heroRecoveredDiseaseIds.TryGetValue(inst.TargetId, out var value2))
				{
					value2 = new HashSet<string>();
					_heroRecoveredDiseaseIds[inst.TargetId] = value2;
				}
				value2.Add(inst.DiseaseId);
				if (inst.HasActiveSeasonalImmunity())
				{
					_heroSeasonalImmunityIndex[inst.TargetId] = inst;
				}
			}
		}
		else if (inst.TargetType == DiseaseTargetType.PartyTroops)
		{
			string key = inst.PartyId ?? inst.TargetId;
			if (!_partyTroopIndex.TryGetValue(key, out var value3))
			{
				value3 = new List<DiseaseInstance>(2);
				_partyTroopIndex[key] = value3;
			}
			value3.Add(inst);
		}
		else if (inst.TargetType == DiseaseTargetType.PartyPrisoners)
		{
			string key2 = inst.PartyId ?? inst.TargetId;
			if (!_partyPrisonerIndex.TryGetValue(key2, out var value4))
			{
				value4 = new List<DiseaseInstance>(2);
				_partyPrisonerIndex[key2] = value4;
			}
			value4.Add(inst);
		}
	}

	private void IndexDisease(Disease disease)
	{
		_diseaseIndex[disease.Id] = disease;
		if (disease.SettlementId != null && !disease.IsExpired())
		{
			if (!_settlementDiseaseIndex.TryGetValue(disease.SettlementId, out var value))
			{
				value = new List<Disease>(2);
				_settlementDiseaseIndex[disease.SettlementId] = value;
			}
			value.Add(disease);
		}
	}

	public void RebuildEntityLookups()
	{
		_heroLookup.Clear();
		if (Hero.AllAliveHeroes != null)
		{
			foreach (Hero item in (List<Hero>)(object)Hero.AllAliveHeroes)
			{
				if (item != null)
				{
					_heroLookup[((MBObjectBase)item).StringId] = item;
				}
			}
		}
		_partyLookup.Clear();
		if (MobileParty.All != null)
		{
			foreach (MobileParty item2 in (List<MobileParty>)(object)MobileParty.All)
			{
				if (item2 != null)
				{
					_partyLookup[((MBObjectBase)item2).StringId] = item2;
				}
			}
		}
		if (_settlementLookup.Count != 0 || Settlement.All == null)
		{
			return;
		}
		foreach (Settlement item3 in (List<Settlement>)(object)Settlement.All)
		{
			if (item3 != null)
			{
				_settlementLookup[((MBObjectBase)item3).StringId] = item3;
			}
		}
	}

	public Hero LookupHero(string stringId)
	{
		if (string.IsNullOrEmpty(stringId))
		{
			return null;
		}
		_heroLookup.TryGetValue(stringId, out var value);
		return value;
	}

	public MobileParty LookupParty(string stringId)
	{
		if (string.IsNullOrEmpty(stringId))
		{
			return null;
		}
		_partyLookup.TryGetValue(stringId, out var value);
		return value;
	}

	public Settlement LookupSettlement(string stringId)
	{
		if (string.IsNullOrEmpty(stringId))
		{
			return null;
		}
		_settlementLookup.TryGetValue(stringId, out var value);
		return value;
	}

	private void EnforceInstanceCap()
	{
		int num = 0;
		for (int i = 0; i < _diseaseInstances.Count; i++)
		{
			if (!_diseaseInstances[i].IsRecovered && !_diseaseInstances[i].IsDead)
			{
				num++;
			}
		}
		if (num <= 800)
		{
			return;
		}
		int num2 = num - 800;
		MobileParty mainParty = MobileParty.MainParty;
		string text = ((mainParty != null) ? ((MBObjectBase)mainParty).StringId : null);
		Hero mainHero = Hero.MainHero;
		string text2 = ((mainHero != null) ? ((MBObjectBase)mainHero).StringId : null);
		List<DiseaseInstance> list = new List<DiseaseInstance>();
		for (int j = 0; j < _diseaseInstances.Count; j++)
		{
			DiseaseInstance diseaseInstance = _diseaseInstances[j];
			if (!diseaseInstance.IsRecovered && !diseaseInstance.IsDead)
			{
				bool flag = false;
				if (diseaseInstance.TargetType == DiseaseTargetType.Hero && diseaseInstance.TargetId == text2)
				{
					flag = true;
				}
				else if ((diseaseInstance.TargetType == DiseaseTargetType.PartyTroops || diseaseInstance.TargetType == DiseaseTargetType.PartyPrisoners) && diseaseInstance.PartyId == text)
				{
					flag = true;
				}
				if (!flag)
				{
					list.Add(diseaseInstance);
				}
			}
		}
		list.Sort(delegate(DiseaseInstance a, DiseaseInstance b)
		{
			int num5 = ((a.TargetType == DiseaseTargetType.Hero) ? 1 : 0);
			int num6 = ((b.TargetType == DiseaseTargetType.Hero) ? 1 : 0);
			return (num5 != num6) ? num5.CompareTo(num6) : a.DiseaseProgress.CompareTo(b.DiseaseProgress);
		});
		int num3 = 0;
		for (int num4 = 0; num4 < list.Count; num4++)
		{
			if (num3 >= num2)
			{
				break;
			}
			list[num4].IsRecovered = true;
			list[num4].DiseaseProgress = 0f;
			num3++;
		}
		if (num3 > 0)
		{
			LogMessage($"[DISEASE_MANAGER] Instance cap enforced: auto-recovered {num3} instances (was {num}, cap {800})");
			RebuildIndexes();
		}
	}

	public Disease CreateDiseaseFromDiseaseEventData(DynamicEvent dynamicEvent, DiseaseEventData data)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		if (data == null || string.IsNullOrEmpty(data.SettlementId))
		{
			return null;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return null;
		}
		ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
		int count = GetAllDiseases().Count;
		if (count >= instance2.DiseaseMaxSimultaneous)
		{
			return null;
		}
		if (_diseases.Count > 0)
		{
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			float num2 = _diseases.Max((Disease d) => d.CreatedAt);
			float num3 = num - num2;
			if (num3 < (float)instance2.DiseaseMinDaysBetweenOutbreaks)
			{
				return null;
			}
		}
		int diseaseMaxSeverity = instance2.DiseaseMaxSeverity;
		DiseaseEffects effects = ConvertDiseaseEffectsData(data.DiseaseEffects);
		Disease disease = CreateDiseaseFromEvent(dynamicEvent, data.DiseaseName ?? "Неизвестная болезнь", data.DiseaseDescription ?? "Странная болезнь неизвестного происхождения.", Math.Max(1, Math.Min(diseaseMaxSeverity, data.Severity)), effects, data.SettlementId);
		if (disease != null)
		{
			data.DiseaseId = disease.Id;
			float diseaseMaxSpreadRate = instance2.DiseaseMaxSpreadRate;
			disease.SpreadRate = ((data.SpreadRate > 0f) ? Math.Min(diseaseMaxSpreadRate, Math.Max(0.1f, data.SpreadRate)) : 0.5f);
			if (data.DurationDays > 0)
			{
				disease.DurationDays = Math.Max(7, Math.Min(120, data.DurationDays));
			}
		}
		return disease;
	}

	private static DiseaseEffects ConvertDiseaseEffectsData(DiseaseEffectsData data)
	{
		DiseaseEffects diseaseEffects = new DiseaseEffects();
		if (data == null)
		{
			return diseaseEffects;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		float val = instance?.DiseaseMinCombatModifier ?? 0.5f;
		float val2 = instance?.DiseaseMinMapSpeedModifier ?? 0.5f;
		float val3 = instance?.DiseaseMaxMoralePenalty ?? (-30f);
		float val4 = instance?.DiseaseMaxPhysicalSkillPenalty ?? (-30f);
		float val5 = instance?.DiseaseMaxDeathChance ?? 0.3f;
		if (data.PhysicalSkillPenalty != 0f)
		{
			float val6 = 0f - Math.Abs(data.PhysicalSkillPenalty);
			float value = Math.Max(val4, Math.Min(0f, val6));
			string[] physicalSkills = DiseaseEffects.PhysicalSkills;
			foreach (string key in physicalSkills)
			{
				diseaseEffects.SkillModifiers[key] = value;
			}
		}
		diseaseEffects.CombatModifiers.DamageMultiplier = Math.Max(val, Math.Min(1f, Math.Abs(data.CombatDamageModifier)));
		diseaseEffects.CombatModifiers.DefenseMultiplier = Math.Max(val, Math.Min(1f, Math.Abs(data.CombatDefenseModifier)));
		diseaseEffects.CombatModifiers.SpeedMultiplier = Math.Max(val, Math.Min(1f, Math.Abs(data.CombatSpeedModifier)));
		diseaseEffects.MapModifiers.MovementSpeedMultiplier = Math.Max(val2, Math.Min(1f, Math.Abs(data.MapSpeedModifier)));
		float val7 = 0f - Math.Abs(data.MoraleModifier);
		diseaseEffects.MapModifiers.MoraleModifier = Math.Max(val3, Math.Min(0f, val7));
		diseaseEffects.DeathChance = Math.Max(0f, Math.Min(val5, Math.Abs(data.DeathChance)));
		return diseaseEffects;
	}

	public Disease CreateDiseaseFromEvent(DynamicEvent dynamicEvent, string diseaseName, string diseaseDescription, int severity, DiseaseEffects effects, string settlementId)
	{
		Disease disease = new Disease
		{
			Id = Guid.NewGuid().ToString(),
			Name = diseaseName,
			Description = diseaseDescription,
			Type = dynamicEvent.Type,
			Severity = Math.Max(1, Math.Min(GlobalSettings<ModSettings>.Instance?.DiseaseMaxSeverity ?? 5, severity)),
			Effects = (effects ?? new DiseaseEffects()),
			SettlementId = settlementId,
			SpreadRate = 0.5f,
			DurationDays = GetDiseaseDuration(severity),
			SourceEventId = dynamicEvent.Id
		};
		_diseases.Add(disease);
		IndexDisease(disease);
		return disease;
	}

	public Disease RegisterSeasonalDisease(string diseaseName, string diseaseDescription, int severity, DiseaseEffects effects)
	{
		Disease disease = new Disease
		{
			Id = Guid.NewGuid().ToString(),
			Name = diseaseName,
			Description = diseaseDescription,
			Type = "seasonal",
			Severity = Math.Max(1, Math.Min(5, severity)),
			Effects = (effects ?? new DiseaseEffects()),
			SettlementId = null,
			SpreadRate = 0.1f,
			DurationDays = 14,
			SourceEventId = null
		};
		_diseases.Add(disease);
		IndexDisease(disease);
		return disease;
	}

	private int GetDiseaseDuration(int severity)
	{
		return severity switch
		{
			1 => 30, 
			2 => 45, 
			3 => 60, 
			4 => 75, 
			5 => 90, 
			_ => 30, 
		};
	}

	public Disease GetDiseaseById(string diseaseId)
	{
		if (string.IsNullOrEmpty(diseaseId))
		{
			return null;
		}
		_diseaseIndex.TryGetValue(diseaseId, out var value);
		return value;
	}

	public Disease GetDiseaseForSettlement(Settlement settlement)
	{
		if (settlement == null)
		{
			return null;
		}
		if (_settlementDiseaseIndex.TryGetValue(((MBObjectBase)settlement).StringId, out var value))
		{
			for (int i = 0; i < value.Count; i++)
			{
				if (!value[i].IsExpired())
				{
					return value[i];
				}
			}
		}
		return null;
	}

	public List<Disease> GetAllDiseasesForSettlement(Settlement settlement)
	{
		if (settlement == null)
		{
			return new List<Disease>();
		}
		if (!_settlementDiseaseIndex.TryGetValue(((MBObjectBase)settlement).StringId, out var value))
		{
			return new List<Disease>();
		}
		List<Disease> list = new List<Disease>(value.Count);
		for (int i = 0; i < value.Count; i++)
		{
			if (!value[i].IsExpired())
			{
				list.Add(value[i]);
			}
		}
		return list;
	}

	public List<Disease> GetAllDiseases()
	{
		return _diseases.Where((Disease d) => !d.IsExpired()).ToList();
	}

	public bool SettlementHasDisease(Settlement settlement)
	{
		return GetDiseaseForSettlement(settlement) != null;
	}

	public Disease SpreadDiseaseToNewSettlement(Disease sourceDisease, Settlement targetSettlement)
	{
		if (sourceDisease == null || targetSettlement == null)
		{
			return null;
		}
		if (SettlementHasDisease(targetSettlement))
		{
			return null;
		}
		Disease disease = new Disease
		{
			Id = Guid.NewGuid().ToString(),
			Name = sourceDisease.Name,
			Description = sourceDisease.Description,
			Type = sourceDisease.Type,
			Severity = sourceDisease.Severity,
			Effects = sourceDisease.Effects,
			SettlementId = ((MBObjectBase)targetSettlement).StringId,
			SpreadRate = sourceDisease.SpreadRate,
			DurationDays = Math.Max(7, (int)((float)sourceDisease.DurationDays * (GlobalSettings<ModSettings>.Instance?.DiseaseSpreadInheritFactor ?? 0.75f))),
			SourceEventId = sourceDisease.SourceEventId
		};
		_diseases.Add(disease);
		IndexDisease(disease);
		return disease;
	}

	public bool InfectHero(Hero hero, Disease disease)
	{
		if (hero == null || disease == null)
		{
			return false;
		}
		if (!hero.IsAlive || hero.IsDead)
		{
			return false;
		}
		if (hero.IsChild)
		{
			return false;
		}
		if (IsHeroInfectedWith(hero, disease))
		{
			return false;
		}
		if (disease.Type != "seasonal" && HasHeroRecoveredFrom(hero, disease))
		{
			return false;
		}
		if (disease.Type == "seasonal" && HasSeasonalImmunity(hero))
		{
			return false;
		}
		if (ImmunitySystem.CheckImmunity(hero, disease))
		{
			return false;
		}
		float num = DiseaseEffectSystem.CalculateInitialProgress(hero, disease);
		DiseaseInstance diseaseInstance = new DiseaseInstance
		{
			DiseaseId = disease.Id,
			DiseaseName = disease.Name,
			TargetId = ((MBObjectBase)hero).StringId,
			TargetType = DiseaseTargetType.Hero,
			InitialProgress = num,
			DiseaseProgress = num
		};
		_diseaseInstances.Add(diseaseInstance);
		IndexInstanceInternal(diseaseInstance);
		if (hero == Hero.MainHero || ((hero != null) ? hero.PartyBelongedTo : null) == MobileParty.MainParty)
		{
			LogMessage($"[DISEASE_MANAGER] {hero.Name} infected with {disease.Name} (progress: {num:F1}%)");
		}
		if (hero == Hero.MainHero)
		{
			DiseaseUI.NotifyPlayerInfection(isPlayerInfected: true, areTroopsInfected: false);
		}
		else if (((hero != null) ? hero.PartyBelongedTo : null) == MobileParty.MainParty)
		{
			DiseaseUI.NotifyCompanionInfection();
		}
		return true;
	}

	public bool IsHeroInfectedWith(Hero hero, Disease disease)
	{
		if (hero == null || disease == null)
		{
			return false;
		}
		if (!_heroInstanceIndex.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			return false;
		}
		for (int i = 0; i < value.Count; i++)
		{
			DiseaseInstance diseaseInstance = value[i];
			if (diseaseInstance.DiseaseId == disease.Id && !diseaseInstance.IsRecovered && !diseaseInstance.IsDead)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasHeroRecoveredFrom(Hero hero, Disease disease)
	{
		if (hero == null || disease == null)
		{
			return false;
		}
		if (_heroRecoveredDiseaseIds.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			return value.Contains(disease.Id);
		}
		return false;
	}

	public bool HasSeasonalImmunity(Hero hero)
	{
		if (hero == null)
		{
			return false;
		}
		if (_heroSeasonalImmunityIndex.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			return value.HasActiveSeasonalImmunity();
		}
		return false;
	}

	public List<DiseaseInstance> GetHeroDiseases(Hero hero)
	{
		if (hero == null)
		{
			return new List<DiseaseInstance>();
		}
		if (!_heroInstanceIndex.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			return new List<DiseaseInstance>();
		}
		List<DiseaseInstance> list = new List<DiseaseInstance>();
		for (int i = 0; i < value.Count; i++)
		{
			DiseaseInstance diseaseInstance = value[i];
			if (!diseaseInstance.IsRecovered && !diseaseInstance.IsDead)
			{
				list.Add(diseaseInstance);
			}
		}
		return list;
	}

	public bool IsHeroInfected(Hero hero)
	{
		if (hero == null)
		{
			return false;
		}
		if (!_heroInstanceIndex.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			return false;
		}
		for (int i = 0; i < value.Count; i++)
		{
			if (!value[i].IsRecovered && !value[i].IsDead)
			{
				return true;
			}
		}
		return false;
	}

	public List<DiseaseInstance> GetHeroPermanentModifierInstances(Hero hero)
	{
		if (hero == null)
		{
			return new List<DiseaseInstance>();
		}
		if (!_heroInstanceIndex.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			return new List<DiseaseInstance>();
		}
		List<DiseaseInstance> list = new List<DiseaseInstance>();
		for (int i = 0; i < value.Count; i++)
		{
			DiseaseInstance diseaseInstance = value[i];
			if (diseaseInstance.IsRecovered && diseaseInstance.PermanentModifiers != null)
			{
				list.Add(diseaseInstance);
			}
		}
		return list;
	}

	public bool InfectPartyTroops(MobileParty party, Disease disease, int infectedCount)
	{
		if (party == null || disease == null || infectedCount <= 0)
		{
			return false;
		}
		if (party.MemberRoster == null || party.MemberRoster.TotalRegulars <= 0)
		{
			return false;
		}
		if (ImmunitySystem.CheckTroopImmunity(party, disease))
		{
			return false;
		}
		DiseaseInstance diseaseInstance = null;
		if (_partyTroopIndex.TryGetValue(((MBObjectBase)party).StringId, out var value))
		{
			for (int i = 0; i < value.Count; i++)
			{
				DiseaseInstance diseaseInstance2 = value[i];
				if (diseaseInstance2.DiseaseId == disease.Id && !diseaseInstance2.IsRecovered && !diseaseInstance2.IsTreated && !diseaseInstance2.HasPostTreatmentEffect)
				{
					diseaseInstance = diseaseInstance2;
					break;
				}
			}
		}
		if (diseaseInstance != null)
		{
			AddInfectedTroops(diseaseInstance, party, infectedCount);
			return true;
		}
		DiseaseInstance diseaseInstance3 = new DiseaseInstance
		{
			DiseaseId = disease.Id,
			DiseaseName = disease.Name,
			TargetId = ((MBObjectBase)party).StringId,
			TargetType = DiseaseTargetType.PartyTroops,
			PartyId = ((MBObjectBase)party).StringId,
			InitialProgress = 15f,
			DiseaseProgress = 15f,
			TotalTroopCount = party.MemberRoster.TotalRegulars
		};
		CalculateTroopTierDistribution(diseaseInstance3, party, infectedCount);
		_diseaseInstances.Add(diseaseInstance3);
		IndexInstanceInternal(diseaseInstance3);
		if (party == MobileParty.MainParty)
		{
			LogMessage($"[DISEASE_MANAGER] {infectedCount} troops infected with {disease.Name} in party {party.Name}");
		}
		if (party == MobileParty.MainParty)
		{
			DiseaseUI.NotifyPlayerInfection(isPlayerInfected: false, areTroopsInfected: true);
		}
		return true;
	}

	private void AddInfectedTroops(DiseaseInstance instance, MobileParty party, int count)
	{
		Dictionary<int, int> partyTroopTiers = GetPartyTroopTiers(party);
		int totalRegulars = party.MemberRoster.TotalRegulars;
		int num = count;
		foreach (KeyValuePair<int, int> item in partyTroopTiers.OrderBy((KeyValuePair<int, int> t) => t.Key))
		{
			if (num <= 0)
			{
				break;
			}
			int troopCountInTier = instance.GetTroopCountInTier(item.Key);
			int num2 = Math.Max(0, item.Value - troopCountInTier);
			if (num2 > 0)
			{
				int num3 = Math.Min(num, num2);
				instance.AddTroopsToTier(item.Key, num3);
				num -= num3;
			}
		}
		instance.TotalTroopCount = totalRegulars;
	}

	private void CalculateTroopTierDistribution(DiseaseInstance instance, MobileParty party, int infectedCount)
	{
		Dictionary<int, int> partyTroopTiers = GetPartyTroopTiers(party);
		int totalRegulars = party.MemberRoster.TotalRegulars;
		if (totalRegulars <= 0)
		{
			return;
		}
		int num = infectedCount;
		foreach (KeyValuePair<int, int> item in partyTroopTiers.OrderBy((KeyValuePair<int, int> t) => t.Key))
		{
			if (num <= 0)
			{
				break;
			}
			float num2 = (float)item.Value / (float)totalRegulars;
			int val = Math.Max(1, (int)((float)infectedCount * num2));
			val = Math.Min(val, num);
			val = Math.Min(val, item.Value);
			instance.AddTroopsToTier(item.Key, val);
			num -= val;
		}
		if (num > 0 && partyTroopTiers.Count > 0)
		{
			int tier = partyTroopTiers.Keys.Min();
			instance.AddTroopsToTier(tier, num);
		}
	}

	private Dictionary<int, int> GetPartyTroopTiers(MobileParty party)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (((party != null) ? party.MemberRoster : null) == null)
		{
			return dictionary;
		}
		foreach (TroopRosterElement item in (List<TroopRosterElement>)(object)party.MemberRoster.GetTroopRoster())
		{
			TroopRosterElement current = item;
			if (current.Character != null && !((BasicCharacterObject)current.Character).IsHero)
			{
				int troopTier = GetTroopTier(current.Character);
				if (dictionary.ContainsKey(troopTier))
				{
					dictionary[troopTier] += (current).Number;
				}
				else
				{
					dictionary[troopTier] = (current).Number;
				}
			}
		}
		return dictionary;
	}

	public int GetTroopTier(CharacterObject troop)
	{
		if (troop == null)
		{
			return 1;
		}
		return Math.Max(1, Math.Min(6, troop.Tier));
	}

	public float CalculateTierModifier(int tier)
	{
		return 1f - (float)(Math.Max(1, tier) - 1) * 0.03f;
	}

	public DiseaseInstance GetPartyDiseaseInstance(MobileParty party, Disease disease)
	{
		if (party == null || disease == null)
		{
			return null;
		}
		if (!_partyTroopIndex.TryGetValue(((MBObjectBase)party).StringId, out var value))
		{
			return null;
		}
		for (int i = 0; i < value.Count; i++)
		{
			DiseaseInstance diseaseInstance = value[i];
			if (diseaseInstance.DiseaseId == disease.Id && !diseaseInstance.IsRecovered)
			{
				return diseaseInstance;
			}
		}
		return null;
	}

	public List<DiseaseInstance> GetPartyDiseases(MobileParty party)
	{
		if (party == null)
		{
			return new List<DiseaseInstance>();
		}
		if (party.MemberRoster == null || party.MemberRoster.TotalRegulars <= 0)
		{
			return new List<DiseaseInstance>();
		}
		if (!_partyTroopIndex.TryGetValue(((MBObjectBase)party).StringId, out var value))
		{
			return new List<DiseaseInstance>();
		}
		List<DiseaseInstance> list = new List<DiseaseInstance>();
		for (int i = 0; i < value.Count; i++)
		{
			if (!value[i].IsRecovered)
			{
				list.Add(value[i]);
			}
		}
		return list;
	}

	public bool PartyHasInfectedTroops(MobileParty party)
	{
		if (((party != null) ? party.MemberRoster : null) == null || party.MemberRoster.TotalRegulars <= 0)
		{
			return false;
		}
		return GetPartyDiseases(party).Count > 0;
	}

	public float GetPartyInfectionRate(MobileParty party)
	{
		List<DiseaseInstance> partyDiseases = GetPartyDiseases(party);
		if (partyDiseases.Count == 0 || ((party != null) ? party.MemberRoster : null) == null)
		{
			return 0f;
		}
		int num = partyDiseases.Sum((DiseaseInstance d) => d.InfectedTroopCount);
		int totalRegulars = party.MemberRoster.TotalRegulars;
		if (totalRegulars <= 0)
		{
			return 0f;
		}
		return Math.Min(100f, (float)num / (float)totalRegulars * 100f);
	}

	public bool SetQuarantine(Settlement settlement, bool quarantined, int durationDays = 0, bool forceByKingdomLeader = false)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null)
		{
			return false;
		}
		List<Disease> allDiseasesForSettlement = GetAllDiseasesForSettlement(settlement);
		float? value2;
		if (quarantined)
		{
			if (durationDays >= 1)
			{
				_ = CampaignTime.Now;
				if (true)
				{
					CampaignTime now = CampaignTime.Now;
					float num = (float)(now).ToDays;
					float num2 = num;
					if (_manualQuarantine.TryGetValue(((MBObjectBase)settlement).StringId, out var value) && value.HasValue && value.Value > num)
					{
						num2 = value.Value;
					}
					value2 = num2 + (float)durationDays;
					goto IL_00a1;
				}
			}
			value2 = null;
			goto IL_00a1;
		}
		foreach (Disease item in allDiseasesForSettlement)
		{
			item.RemoveQuarantine();
		}
		_manualQuarantine.Remove(((MBObjectBase)settlement).StringId);
		goto IL_0157;
		IL_0157:
		SaveAll();
		return true;
		IL_00a1:
		if (allDiseasesForSettlement.Count > 0)
		{
			foreach (Disease item2 in allDiseasesForSettlement)
			{
				int quarantine = ((durationDays >= 1) ? durationDays : 0);
				item2.SetQuarantine(quarantine);
			}
		}
		_manualQuarantine[((MBObjectBase)settlement).StringId] = value2;
		goto IL_0157;
	}

	public bool IsSettlementUnderQuarantine(Settlement settlement)
	{
		if (settlement == null)
		{
			return false;
		}
		if (_manualQuarantine.ContainsKey(((MBObjectBase)settlement).StringId))
		{
			return true;
		}
		if (_settlementDiseaseIndex.TryGetValue(((MBObjectBase)settlement).StringId, out var value))
		{
			for (int i = 0; i < value.Count; i++)
			{
				if (!value[i].IsExpired() && value[i].IsQuarantined)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsPartyExemptFromQuarantine(MobileParty party, Settlement settlement)
	{
		if (party == null || settlement == null)
		{
			return true;
		}
		if (party == MobileParty.MainParty)
		{
			return true;
		}
		if (settlement.OwnerClan != null && party.ActualClan == settlement.OwnerClan && party.IsLordParty)
		{
			return true;
		}
		return false;
	}

	public bool IsPartyHostileToSettlement(MobileParty party, Settlement settlement)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Invalid comparison between Unknown and I4
		if (party == null || settlement == null)
		{
			return false;
		}
		if (party.BesiegedSettlement == settlement)
		{
			return true;
		}
		if (party.MapFaction != null && settlement.MapFaction != null && FactionManager.IsAtWarAgainstFaction(party.MapFaction, settlement.MapFaction))
		{
			if ((int)party.DefaultBehavior == 4 && party.TargetSettlement == settlement)
			{
				return true;
			}
			if ((int)party.DefaultBehavior == 5 && party.TargetSettlement == settlement)
			{
				return true;
			}
		}
		return false;
	}

	public void CheckQuarantineExpiration()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		foreach (Disease disease in _diseases)
		{
			if (disease.IsQuarantined && disease.IsQuarantineExpired())
			{
				disease.RemoveQuarantine();
			}
		}
		if (_manualQuarantine.Count <= 0)
		{
			return;
		}
		_ = CampaignTime.Now;
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, float?> item in _manualQuarantine)
		{
			if (item.Value.HasValue && num >= item.Value.Value)
			{
				list.Add(item.Key);
			}
		}
		foreach (string item2 in list)
		{
			_manualQuarantine.Remove(item2);
		}
	}

	public bool TryGetQuarantineSettlementEffect(Settlement settlement, out float prosperityPerDay, out float foodPerDay, out float securityPerDay, out float loyaltyPerDay, out float incomeMultiplier, out string reason)
	{
		prosperityPerDay = 0f;
		foodPerDay = 0f;
		securityPerDay = 0f;
		loyaltyPerDay = 0f;
		incomeMultiplier = 1f;
		reason = null;
		if (settlement == null)
		{
			return false;
		}
		if (!IsSettlementUnderQuarantine(settlement))
		{
			return false;
		}
		bool flag = SettlementHasDisease(settlement);
		reason = "{=AIInfluence_QuarantinePenaltyReason}Quarantine";
		if (flag)
		{
			prosperityPerDay = -10f;
			foodPerDay = -10f;
			loyaltyPerDay = 1f;
			securityPerDay = 1f;
			incomeMultiplier = 0.75f;
		}
		else
		{
			prosperityPerDay = -20f;
			foodPerDay = -20f;
			loyaltyPerDay = -1f;
			securityPerDay = -1f;
			incomeMultiplier = 0.5f;
		}
		return true;
	}

	public float GetQuarantineIncomeMultiplier(Settlement settlement)
	{
		if (settlement == null || !IsSettlementUnderQuarantine(settlement))
		{
			return 1f;
		}
		return SettlementHasDisease(settlement) ? 0.75f : 0.5f;
	}

	public void OnDailyTick()
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && !instance.EnableDiseaseSystem)
		{
			return;
		}
		RebuildEntityLookups();
		RebuildIndexes();
		CleanupOrphanedInstances();
		UpdateAllTreatmentEffectiveness();
		UpdateAllDiseaseProgress();
		CheckHeroDeaths();
		ProcessTroopDeaths();
		CheckRecovery();
		CleanupRecoveredAndDeadInstances();
		ApplyAllDiseaseEffects();
		ProcessSettlementAutoTreatment();
		List<MobileParty> parties = ((IEnumerable<MobileParty>)MobileParty.All).Where(delegate(MobileParty p)
		{
			int result;
			if (p != null)
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
		_queueManager.StartDailySpreadCycle(parties);
		CheckQuarantineExpiration();
		CheckPreventionExpiration();
		CleanupExpiredDiseases();
		EnforceInstanceCap();
		SaveAll();
	}

	private void UpdateAllTreatmentEffectiveness()
	{
		foreach (DiseaseInstance item in _diseaseInstances.Where((DiseaseInstance i) => i.IsTreated && !i.IsRecovered && !i.IsDead))
		{
			Disease diseaseById = GetDiseaseById(item.DiseaseId);
			if (diseaseById != null)
			{
				TreatmentSystem.UpdateTreatmentEffectiveness(item, diseaseById);
			}
		}
	}

	private void UpdateAllDiseaseProgress()
	{
		foreach (DiseaseInstance item in _diseaseInstances.Where((DiseaseInstance i) => !i.IsRecovered && !i.IsDead))
		{
			Disease diseaseById = GetDiseaseById(item.DiseaseId);
			if (diseaseById != null)
			{
				DiseaseEffectSystem.UpdateDiseaseProgress(item, diseaseById);
			}
		}
		foreach (SettlementDiseaseInstance item2 in _settlementDiseaseInstances.Where((SettlementDiseaseInstance i) => !i.IsRecovered()))
		{
			Disease diseaseById2 = GetDiseaseById(item2.DiseaseId);
			if (diseaseById2 != null)
			{
				UpdateSettlementDiseaseProgress(item2, diseaseById2);
			}
		}
	}

	private void UpdateSettlementDiseaseProgress(SettlementDiseaseInstance instance, Disease disease)
	{
		float dailyProgressIncrease = disease.GetDailyProgressIncrease();
		if (instance.IsTreated)
		{
			Settlement val = LookupSettlement(instance.SettlementId);
			if (val != null)
			{
				int medicalTier = TreatmentSystem.GetMedicalTier(val);
				float tierRecoveryBonus = TreatmentSystem.GetTierRecoveryBonus(medicalTier);
				float progressDifficultyMultiplier = DiseaseEffectSystem.GetProgressDifficultyMultiplier(instance.InfectionProgress);
				float num = disease.GetBaseRecoveryRate() * tierRecoveryBonus * progressDifficultyMultiplier;
				instance.InfectionProgress = Math.Max(0f, instance.InfectionProgress - num);
				return;
			}
		}
		float val2 = ((disease.Severity <= 2) ? 90f : 100f);
		instance.InfectionProgress = Math.Min(val2, instance.InfectionProgress + dailyProgressIncrease);
		instance.AverageProgress = instance.InfectionProgress;
	}

	private void CheckHeroDeaths()
	{
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		List<DiseaseInstance> list = _diseaseInstances.Where((DiseaseInstance i) => i.TargetType == DiseaseTargetType.Hero && i.DiseaseProgress >= 100f && !i.IsDead && !i.IsRecovered).ToList();
		foreach (DiseaseInstance item in list)
		{
			Hero val = LookupHero(item.TargetId);
			if (val == null || !val.IsAlive)
			{
				continue;
			}
			Disease diseaseById = GetDiseaseById(item.DiseaseId);
			if (diseaseById == null)
			{
				continue;
			}
			string text = ((object)val.Name)?.ToString() ?? item.TargetId;
			if (diseaseById.Severity > 2)
			{
				SetDiseaseDeathReason(val, diseaseById);
				DiseaseUI.NotifyLordDeathFromDisease(val, diseaseById);
				PendingDiseaseDeathNames[item.TargetId] = diseaseById.Name.ToString();
				if (val == Hero.MainHero)
				{
					PendingPlayerDiseaseDeathName = diseaseById.Name.ToString();
				}
				KillCharacterAction.ApplyByOldAge(val, showNotification: false);
				if (!val.IsAlive || val.IsDead)
				{
					item.IsDead = true;
					LogMessage("[DISEASE_MANAGER] " + text + " (" + SeasonalDiseaseSystem.GetHeroTypeTag(val) + ") died from " + diseaseById.Name);
				}
				else
				{
					DiseaseLogger.Instance?.Log($"[DISEASE_MANAGER] WARNING: Failed to kill {text} (StringId: {item.TargetId}) from {diseaseById.Name} — hero is still alive (IsLord: {val.IsLord}, IsNotable: {val.IsNotable}, Occupation: {val.Occupation})");
				}
			}
		}
	}

	private void ProcessTroopDeaths()
	{
		List<DiseaseInstance> list = _diseaseInstances.Where((DiseaseInstance i) => i.TargetType == DiseaseTargetType.PartyTroops && i.DiseaseProgress >= 80f && !i.IsRecovered).ToList();
		foreach (DiseaseInstance item in list)
		{
			MobileParty val = LookupParty(item.PartyId);
			if (((val != null) ? val.MemberRoster : null) != null)
			{
				Disease diseaseById = GetDiseaseById(item.DiseaseId);
				if (diseaseById != null && diseaseById.Severity > 2)
				{
					DiseaseEffectSystem.KillTroopsFromDisease(item, diseaseById, val);
				}
			}
		}
		List<DiseaseInstance> list2 = _diseaseInstances.Where((DiseaseInstance i) => i.TargetType == DiseaseTargetType.PartyPrisoners && i.DiseaseProgress >= 80f && !i.IsRecovered).ToList();
		foreach (DiseaseInstance item2 in list2)
		{
			MobileParty val2 = LookupParty(item2.PartyId);
			if (((val2 != null) ? val2.PrisonRoster : null) != null)
			{
				Disease diseaseById2 = GetDiseaseById(item2.DiseaseId);
				if (diseaseById2 != null && diseaseById2.Severity > 2)
				{
					KillPrisonersFromDisease(item2, diseaseById2, val2);
				}
			}
		}
		foreach (SettlementDiseaseInstance item3 in _settlementDiseaseInstances.Where((SettlementDiseaseInstance i) => i.InfectionProgress >= 80f && !i.IsRecovered()))
		{
			Settlement val3 = LookupSettlement(item3.SettlementId);
			if (val3 != null)
			{
				Disease diseaseById3 = GetDiseaseById(item3.DiseaseId);
				if (diseaseById3 != null)
				{
					ProcessSettlementForceDeaths(item3, diseaseById3, val3);
				}
			}
		}
	}

	private void ProcessSettlementForceDeaths(SettlementDiseaseInstance instance, Disease disease, Settlement settlement)
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		float num = ((!(instance.InfectionProgress >= 100f)) ? ((instance.InfectionProgress - 80f) / 400f) : (0.05f + (float)disease.Severity * 0.01f));
		if (instance.TargetType == "militia")
		{
			int num2 = instance.CalculateInfectedMilitiaCount(settlement.Militia);
			int num3 = Math.Max(1, (int)((float)num2 * num));
			settlement.Militia = Math.Max(0f, settlement.Militia - (float)num3);
			instance.UpdateMilitiaInfectedCount(settlement.Militia);
		}
		else
		{
			if (!(instance.TargetType == "garrison"))
			{
				return;
			}
			Town town = settlement.Town;
			object obj;
			if (town == null)
			{
				obj = null;
			}
			else
			{
				MobileParty garrisonParty = ((Fief)town).GarrisonParty;
				obj = ((garrisonParty != null) ? garrisonParty.MemberRoster : null);
			}
			if (obj == null)
			{
				return;
			}
			TroopRoster memberRoster = ((Fief)settlement.Town).GarrisonParty.MemberRoster;
			int num4 = Math.Max(1, (int)((float)instance.InfectedCount * num));
			int num5 = num4;
			foreach (TroopRosterElement item in ((IEnumerable<TroopRosterElement>)memberRoster.GetTroopRoster()).ToList())
			{
				TroopRosterElement current = item;
				if (num5 <= 0)
				{
					break;
				}
				if (current.Character != null && !((BasicCharacterObject)current.Character).IsHero)
				{
					int num6 = Math.Min(num5, (current).Number);
					memberRoster.RemoveTroop(current.Character, num6, default(UniqueTroopDescriptor), 0);
					num5 -= num6;
				}
			}
			instance.InfectedCount = Math.Max(0, instance.InfectedCount - num4);
		}
	}

	private void CheckRecovery()
	{
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_084b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0852: Expected O, but got Unknown
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Expected O, but got Unknown
		List<DiseaseInstance> list = _diseaseInstances.Where((DiseaseInstance i) => i.TargetType == DiseaseTargetType.Hero && i.DiseaseProgress <= 0f && !i.IsRecovered && !i.IsDead).ToList();
		foreach (DiseaseInstance item in list)
		{
			item.IsRecovered = true;
			if (!_heroRecoveredDiseaseIds.TryGetValue(item.TargetId, out var value))
			{
				value = new HashSet<string>();
				_heroRecoveredDiseaseIds[item.TargetId] = value;
			}
			value.Add(item.DiseaseId);
			Hero val = LookupHero(item.TargetId);
			Disease diseaseById = GetDiseaseById(item.DiseaseId);
			if (val == null || diseaseById == null)
			{
				continue;
			}
			if (val == Hero.MainHero)
			{
				LogMessage($"[DISEASE_MANAGER] {val.Name} recovered from {diseaseById.Name}");
			}
			if (diseaseById.Severity >= 4)
			{
				item.PermanentModifiers = diseaseById.Effects.GetPermanentModifiers();
				if (val == Hero.MainHero)
				{
					LogMessage($"[DISEASE_MANAGER] {val.Name} has permanent effects from {diseaseById.Name}");
				}
			}
			if (diseaseById.Type == "seasonal")
			{
				_ = CampaignTime.Now;
				if (true)
				{
					float num = GlobalSettings<ModSettings>.Instance?.SeasonalPostRecoveryImmunityDays ?? 21;
					if (num > 0f)
					{
						CampaignTime now = CampaignTime.Now;
						item.SeasonalImmunityEndDays = (float)(now).ToDays + num;
						_heroSeasonalImmunityIndex[item.TargetId] = item;
						if (val == Hero.MainHero)
						{
							LogMessage($"[DISEASE_MANAGER] {val.Name} gained seasonal immunity for {num} days after recovering from {diseaseById.Name}");
						}
					}
				}
			}
			if (val.PartyBelongedTo != null)
			{
				Hero effectiveSurgeon = val.PartyBelongedTo.EffectiveSurgeon;
				float num2 = 25f;
				float num3 = diseaseById.Severity;
				float num4 = ((val.PartyBelongedTo.CurrentSettlement != null && !val.PartyBelongedTo.CurrentSettlement.IsCastle) ? 2f : 1f);
				if (effectiveSurgeon != null)
				{
					float num5 = 1f + (float)effectiveSurgeon.Level * 0.1f;
					float num6 = num2 * num3 * num4 * num5;
					effectiveSurgeon.AddSkillXp(DefaultSkills.Medicine, num6);
					if (val == Hero.MainHero || effectiveSurgeon == Hero.MainHero)
					{
						LogMessage($"[DISEASE_MANAGER] Surgeon {effectiveSurgeon.Name} gained {num6:F1} medicine XP for curing {val.Name} from {diseaseById.Name} (severity {diseaseById.Severity})");
					}
				}
				if (val != effectiveSurgeon)
				{
					float num7 = 1f + (float)val.Level * 0.1f;
					float num8 = num2 * num3 * num4 * num7 * 0.5f;
					val.AddSkillXp(DefaultSkills.Medicine, num8);
					if (val == Hero.MainHero)
					{
						LogMessage($"[DISEASE_MANAGER] {val.Name} gained {num8:F1} medicine XP from surviving {diseaseById.Name}");
					}
				}
			}
			else
			{
				float num9 = 25f;
				float num10 = diseaseById.Severity;
				float num11 = num9 * num10 * (1f + (float)val.Level * 0.1f) * 0.5f;
				val.AddSkillXp(DefaultSkills.Medicine, num11);
				if (val == Hero.MainHero)
				{
					LogMessage($"[DISEASE_MANAGER] {val.Name} (no party) gained {num11:F1} medicine XP from surviving {diseaseById.Name}");
				}
			}
			if (val == Hero.MainHero)
			{
				DiseaseUI.NotifyPlayerRecovery(isPlayerRecovered: true, areTroopsRecovered: false);
			}
		}
		List<DiseaseInstance> list2 = _diseaseInstances.Where((DiseaseInstance i) => i.TargetType == DiseaseTargetType.PartyTroops && i.DiseaseProgress <= 0f && !i.IsRecovered).ToList();
		bool flag = false;
		foreach (DiseaseInstance item2 in list2)
		{
			item2.IsRecovered = true;
			MobileParty val2 = LookupParty(item2.PartyId);
			Disease diseaseById2 = GetDiseaseById(item2.DiseaseId);
			if (val2 == null || diseaseById2 == null)
			{
				continue;
			}
			float battleHardenedImmunityBonus = DiseasePerkBonuses.GetBattleHardenedImmunityBonus(val2, diseaseById2);
			if (battleHardenedImmunityBonus > 0f)
			{
				int num12 = 30;
				item2.ApplyPrevention((int)(battleHardenedImmunityBonus * 100f), num12);
				if (val2 == MobileParty.MainParty)
				{
					LogMessage($"[PERK] Battle Hardened: troops in {val2.Name} gained +{battleHardenedImmunityBonus:P0} immunity for {num12} days after surviving {diseaseById2.Name}");
				}
			}
			Hero effectiveSurgeon2 = val2.EffectiveSurgeon;
			if (effectiveSurgeon2 != null && item2.InfectedTroopCount > 0)
			{
				float num13 = 1f;
				if (item2.TroopTierDistribution != null && item2.TroopTierDistribution.Count > 0)
				{
					float num14 = 0f;
					int num15 = 0;
					foreach (KeyValuePair<int, int> item3 in item2.TroopTierDistribution)
					{
						num14 += (float)(item3.Key * item3.Value);
						num15 += item3.Value;
					}
					if (num15 > 0)
					{
						num13 = num14 / (float)num15;
					}
				}
				float num16 = 15f * (float)item2.InfectedTroopCount * num13;
				float num17 = diseaseById2.Severity;
				float num18 = ((val2.CurrentSettlement != null && !val2.CurrentSettlement.IsCastle) ? 2f : 1f);
				float num19 = num16 * num17 * num18;
				effectiveSurgeon2.AddSkillXp(DefaultSkills.Medicine, num19);
				if (val2 == MobileParty.MainParty)
				{
					LogMessage($"[DISEASE_MANAGER] Surgeon {effectiveSurgeon2.Name} gained {num19:F1} medicine XP for curing {item2.InfectedTroopCount} troops (avg tier {num13:F1}) from {diseaseById2.Name} (severity {diseaseById2.Severity})");
				}
			}
			if (val2 == MobileParty.MainParty)
			{
				LogMessage($"[DISEASE_MANAGER] Troops in {val2.Name} recovered from {diseaseById2.Name}");
				flag = true;
			}
		}
		if (flag && MobileParty.MainParty != null && !_diseaseInstances.Any((DiseaseInstance i) => i.TargetType == DiseaseTargetType.PartyTroops && i.PartyId == ((MBObjectBase)MobileParty.MainParty).StringId && !i.IsRecovered && !i.IsDead))
		{
			DiseaseUI.NotifyPlayerRecovery(isPlayerRecovered: false, areTroopsRecovered: true);
		}
		List<DiseaseInstance> list3 = _diseaseInstances.Where((DiseaseInstance i) => i.TargetType == DiseaseTargetType.PartyPrisoners && i.DiseaseProgress <= 0f && !i.IsRecovered).ToList();
		foreach (DiseaseInstance item4 in list3)
		{
			item4.IsRecovered = true;
			MobileParty val3 = LookupParty(item4.PartyId);
			Disease diseaseById3 = GetDiseaseById(item4.DiseaseId);
			if (val3 != null && diseaseById3 != null)
			{
				if (val3 == MobileParty.MainParty)
				{
					LogMessage($"[DISEASE_MANAGER] Prisoners in {val3.Name} recovered from {diseaseById3.Name}");
				}
				if (val3 == MobileParty.MainParty)
				{
					TextObject val4 = new TextObject("{=AIInfluence_PrisonerRecovered}Prisoners recovered from {DISEASE}", (Dictionary<string, object>)null);
					val4.SetTextVariable("DISEASE", diseaseById3.Name);
					InformationManager.DisplayMessage(new InformationMessage(((object)val4).ToString(), DiseaseUI.RecoveryColor));
				}
			}
		}
		List<SettlementDiseaseInstance> list4 = _settlementDiseaseInstances.Where((SettlementDiseaseInstance i) => i.InfectionProgress <= 0f && !i.IsRecovered()).ToList();
		foreach (SettlementDiseaseInstance item5 in list4)
		{
			item5.MarkRecovered();
		}
	}

	private void ApplyAllDiseaseEffects()
	{
	}

	private void ProcessSettlementAutoTreatment()
	{
		foreach (SettlementDiseaseInstance item in _settlementDiseaseInstances.Where((SettlementDiseaseInstance i) => !i.IsRecovered()))
		{
			if (!item.NeedsAutoTreatment())
			{
				continue;
			}
			Settlement val = LookupSettlement(item.SettlementId);
			if (val != null)
			{
				Disease diseaseById = GetDiseaseById(item.DiseaseId);
				if (diseaseById != null)
				{
					TreatmentSystem.AutoTreatSettlementForces(val, item, diseaseById);
				}
			}
		}
	}

	private void CheckPreventionExpiration()
	{
		foreach (DiseaseInstance item in _diseaseInstances.Where((DiseaseInstance i) => i.HasPreventionEffect))
		{
			if (item.IsPreventionExpired())
			{
				item.RemovePrevention();
			}
		}
	}

	public void OnHourlyTick()
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || instance.EnableDiseaseSystem)
		{
			_hourlyTickCounter++;
			if (_hourlyTickCounter >= 6)
			{
				_hourlyTickCounter = 0;
				RebuildEntityLookups();
				RebuildIndexes();
				_queueManager.StartInfectionCheckCycle();
			}
			_twelveHourTickCounter++;
			if (_twelveHourTickCounter >= 12)
			{
				_twelveHourTickCounter = 0;
				OnDailyTick();
			}
		}
	}

	public void TickDiseaseQueue()
	{
		_queueManager?.Tick();
	}

	internal List<DiseaseInstance> GetActiveTroopInstances()
	{
		return _diseaseInstances.Where((DiseaseInstance i) => (i.TargetType == DiseaseTargetType.PartyTroops || i.TargetType == DiseaseTargetType.PartyPrisoners) && !i.IsRecovered).ToList();
	}

	internal void SyncSingleTroopInstance(DiseaseInstance instance)
	{
		MobileParty val = LookupParty(instance.PartyId);
		if (val == null)
		{
			return;
		}
		TroopRoster val2 = ((instance.TargetType == DiseaseTargetType.PartyPrisoners) ? val.PrisonRoster : val.MemberRoster);
		if (val2 == null)
		{
			return;
		}
		int totalRegulars = val2.TotalRegulars;
		if (totalRegulars <= 0)
		{
			instance.InfectedTroopCount = 0;
			instance.TroopTierDistribution?.Clear();
			instance.TotalTroopCount = 0;
			instance.IsRecovered = true;
			return;
		}
		if (instance.InfectedTroopCount <= totalRegulars)
		{
			instance.TotalTroopCount = totalRegulars;
			return;
		}
		float num = (float)totalRegulars / (float)instance.InfectedTroopCount;
		int num2 = totalRegulars;
		if (instance.TroopTierDistribution != null)
		{
			List<int> list = instance.TroopTierDistribution.Keys.ToList();
			int num3 = 0;
			foreach (int item in list)
			{
				int num4 = (int)((float)instance.TroopTierDistribution[item] * num);
				instance.TroopTierDistribution[item] = num4;
				num3 += num4;
			}
			int num5 = num3 - num2;
			if (num5 != 0 && list.Count > 0)
			{
				int key = list.OrderByDescending((int t) => instance.TroopTierDistribution[t]).First();
				instance.TroopTierDistribution[key] = Math.Max(0, instance.TroopTierDistribution[key] - num5);
			}
		}
		instance.InfectedTroopCount = num2;
		instance.TotalTroopCount = totalRegulars;
		if (val == MobileParty.MainParty)
		{
			LogMessage($"[DISEASE_MANAGER] Synced troop infection for party {val.Name}: " + $"InfectedTroopCount capped from {(int)((float)num2 / num)} to {num2} (current party size: {totalRegulars})");
		}
	}

	public void OnBattleStarted(MapEvent mapEvent)
	{
		if (mapEvent == null)
		{
			return;
		}
		_preBattlePrisonerCounts.Clear();
		try
		{
			foreach (PartyBase involvedParty in mapEvent.InvolvedParties)
			{
				if (((involvedParty != null) ? involvedParty.MobileParty : null) != null)
				{
					Dictionary<string, int> preBattlePrisonerCounts = _preBattlePrisonerCounts;
					string stringId = ((MBObjectBase)involvedParty.MobileParty).StringId;
					TroopRoster prisonRoster = involvedParty.PrisonRoster;
					preBattlePrisonerCounts[stringId] = ((prisonRoster != null) ? prisonRoster.TotalManCount : 0);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void OnBattleEnded(MapEvent mapEvent)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (mapEvent == null || !mapEvent.HasWinner)
		{
			return;
		}
		try
		{
			MapEventSide mapEventSide = mapEvent.GetMapEventSide(mapEvent.DefeatedSide);
			MapEventSide winner = mapEvent.Winner;
			if (mapEventSide == null || winner == null)
			{
				return;
			}
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			Dictionary<string, float> dictionary2 = new Dictionary<string, float>();
			foreach (MapEventParty item in (List<MapEventParty>)(object)mapEventSide.Parties)
			{
				PartyBase party = item.Party;
				MobileParty val = ((party != null) ? party.MobileParty : null);
				if (val == null)
				{
					continue;
				}
				List<DiseaseInstance> list = new List<DiseaseInstance>();
				if (_partyTroopIndex.TryGetValue(((MBObjectBase)val).StringId, out var value))
				{
					for (int i = 0; i < value.Count; i++)
					{
						if (!value[i].IsRecovered)
						{
							list.Add(value[i]);
						}
					}
				}
				foreach (DiseaseInstance item2 in list)
				{
					if (item2.TotalTroopCount > 0 && item2.InfectedTroopCount > 0)
					{
						float num = (float)item2.InfectedTroopCount / (float)item2.TotalTroopCount;
						if (!dictionary.ContainsKey(item2.DiseaseId) || dictionary[item2.DiseaseId] < num)
						{
							dictionary[item2.DiseaseId] = num;
							dictionary2[item2.DiseaseId] = item2.DiseaseProgress;
						}
					}
				}
			}
			foreach (PartyBase involvedParty in mapEvent.InvolvedParties)
			{
				MobileParty val2 = ((involvedParty != null) ? involvedParty.MobileParty : null);
				if (val2 == null || !_partyTroopIndex.TryGetValue(((MBObjectBase)val2).StringId, out var value2))
				{
					continue;
				}
				for (int j = 0; j < value2.Count; j++)
				{
					if (!value2[j].IsRecovered)
					{
						SyncSingleTroopInstance(value2[j]);
					}
				}
			}
			if (dictionary.Count == 0)
			{
				return;
			}
			foreach (MapEventParty item3 in (List<MapEventParty>)(object)winner.Parties)
			{
				PartyBase party2 = item3.Party;
				MobileParty val3 = ((party2 != null) ? party2.MobileParty : null);
				if (val3 == null)
				{
					continue;
				}
				TroopRoster prisonRoster = val3.PrisonRoster;
				int num2 = ((prisonRoster != null) ? prisonRoster.TotalManCount : 0);
				_preBattlePrisonerCounts.TryGetValue(((MBObjectBase)val3).StringId, out var value3);
				int num3 = num2 - value3;
				if (num3 <= 0)
				{
					continue;
				}
				foreach (KeyValuePair<string, float> item4 in dictionary)
				{
					string key = item4.Key;
					float value4 = item4.Value;
					if (!dictionary2.TryGetValue(key, out var value5))
					{
						value5 = 15f;
					}
					int infectedCount = Math.Max(1, (int)((float)num3 * value4));
					CreatePrisonerDiseaseInstance(val3, key, infectedCount, num2, value5);
				}
			}
			_preBattlePrisonerCounts.Clear();
		}
		catch (Exception)
		{
		}
	}

	private void CreatePrisonerDiseaseInstance(MobileParty party, string diseaseId, int infectedCount, int totalPrisoners, float progress)
	{
		Disease diseaseById = GetDiseaseById(diseaseId);
		if (diseaseById == null)
		{
			return;
		}
		DiseaseInstance diseaseInstance = null;
		if (_partyPrisonerIndex.TryGetValue(((MBObjectBase)party).StringId, out var value))
		{
			for (int i = 0; i < value.Count; i++)
			{
				DiseaseInstance diseaseInstance2 = value[i];
				if (diseaseInstance2.DiseaseId == diseaseId && !diseaseInstance2.IsRecovered)
				{
					diseaseInstance = diseaseInstance2;
					break;
				}
			}
		}
		if (diseaseInstance != null)
		{
			diseaseInstance.InfectedTroopCount = Math.Min(diseaseInstance.InfectedTroopCount + infectedCount, totalPrisoners);
			diseaseInstance.TotalTroopCount = totalPrisoners;
			if (party == MobileParty.MainParty)
			{
				LogMessage($"[DISEASE_BATTLE] Updated prisoner infection in {party.Name}: " + $"+{infectedCount} infected with {diseaseById.Name} (total: {diseaseInstance.InfectedTroopCount}/{totalPrisoners})");
			}
			return;
		}
		DiseaseInstance diseaseInstance3 = new DiseaseInstance
		{
			DiseaseId = diseaseId,
			DiseaseName = diseaseById.Name,
			TargetId = ((MBObjectBase)party).StringId,
			TargetType = DiseaseTargetType.PartyPrisoners,
			PartyId = ((MBObjectBase)party).StringId,
			InitialProgress = progress,
			DiseaseProgress = progress,
			InfectedTroopCount = infectedCount,
			TotalTroopCount = totalPrisoners
		};
		_diseaseInstances.Add(diseaseInstance3);
		IndexInstanceInternal(diseaseInstance3);
		if (party == MobileParty.MainParty)
		{
			LogMessage($"[DISEASE_BATTLE] {infectedCount}/{totalPrisoners} prisoners infected with {diseaseById.Name} " + $"in {party.Name} (progress: {progress:F1}%)");
		}
		if (party == MobileParty.MainParty)
		{
			DiseaseUI.NotifyPrisonerInfection(diseaseById.Name, infectedCount);
		}
	}

	public List<DiseaseInstance> GetPartyPrisonerDiseases(MobileParty party)
	{
		if (party == null)
		{
			return new List<DiseaseInstance>();
		}
		if (!_partyPrisonerIndex.TryGetValue(((MBObjectBase)party).StringId, out var value))
		{
			return new List<DiseaseInstance>();
		}
		List<DiseaseInstance> list = new List<DiseaseInstance>();
		for (int i = 0; i < value.Count; i++)
		{
			DiseaseInstance diseaseInstance = value[i];
			if (!diseaseInstance.IsRecovered && !diseaseInstance.IsDead)
			{
				list.Add(diseaseInstance);
			}
		}
		return list;
	}

	private void KillPrisonersFromDisease(DiseaseInstance instance, Disease disease, MobileParty party)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		if (instance.InfectedTroopCount <= 0)
		{
			return;
		}
		float num = ((!(instance.DiseaseProgress >= 100f)) ? ((instance.DiseaseProgress - 80f) / 400f) : (0.05f + (float)disease.Severity * 0.01f));
		int num2 = Math.Max(1, (int)((float)instance.InfectedTroopCount * num));
		int num3 = 0;
		int num4 = party.PrisonRoster.Count - 1;
		while (num4 >= 0 && num3 < num2)
		{
			TroopRosterElement elementCopyAtIndex = party.PrisonRoster.GetElementCopyAtIndex(num4);
			if (elementCopyAtIndex.Character != null && !((BasicCharacterObject)elementCopyAtIndex.Character).IsHero)
			{
				int num5 = Math.Min((elementCopyAtIndex).Number, num2 - num3);
				party.PrisonRoster.AddToCounts(elementCopyAtIndex.Character, -num5, false, 0, 0, true, -1);
				num3 += num5;
			}
			num4--;
		}
		instance.InfectedTroopCount = Math.Max(0, instance.InfectedTroopCount - num3);
		instance.TotalTroopCount = party.PrisonRoster.TotalManCount;
		if (instance.InfectedTroopCount <= 0 || instance.TotalTroopCount <= 0)
		{
			instance.IsRecovered = true;
		}
		if (num3 > 0)
		{
			if (party == MobileParty.MainParty)
			{
				LogMessage($"[DISEASE_MANAGER] {num3} prisoners died from {disease.Name} in {party.Name}");
			}
			if (party == MobileParty.MainParty)
			{
				TextObject val = new TextObject("{=AIInfluence_PrisonerDiedDisease}{COUNT} prisoners died from {DISEASE}", (Dictionary<string, object>)null);
				val.SetTextVariable("COUNT", num3);
				val.SetTextVariable("DISEASE", disease.Name);
				InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Colors.Gray));
			}
		}
	}

	internal void CheckPlayerSettlementInfection()
	{
		Hero mainHero = Hero.MainHero;
		if (mainHero == null || !mainHero.IsAlive)
		{
			return;
		}
		Settlement currentSettlement = mainHero.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		List<Disease> allDiseasesForSettlement = GetAllDiseasesForSettlement(currentSettlement);
		if (allDiseasesForSettlement == null || allDiseasesForSettlement.Count == 0)
		{
			return;
		}
		foreach (Disease item in allDiseasesForSettlement)
		{
			if (!IsHeroInfectedWith(mainHero, item) && DiseaseSpreadSystem.CheckSettlementInfection(mainHero, currentSettlement, item))
			{
				InfectHero(mainHero, item);
			}
			if (MobileParty.MainParty != null)
			{
				DiseaseSpreadSystem.CheckPartyTroopInfection(MobileParty.MainParty, item);
			}
		}
		if (MobileParty.MainParty != null && PartyHasInfectedTroops(MobileParty.MainParty))
		{
			DiseaseSpreadSystem.CheckPlayerInfectionFromTroops(mainHero, MobileParty.MainParty);
		}
	}

	internal void CheckSettlementForcesInfectionSingle(Settlement settlement)
	{
		List<Disease> allDiseasesForSettlement = GetAllDiseasesForSettlement(settlement);
		foreach (Disease item in allDiseasesForSettlement)
		{
			DiseaseSpreadSystem.CheckSettlementMilitiaAndGarrisonInfection(settlement, item);
		}
	}

	internal void CheckAITreatmentSingle(Hero hero)
	{
		if (hero == null || !hero.IsAlive || hero.IsDead)
		{
			return;
		}
		Settlement currentSettlement = hero.CurrentSettlement;
		if (currentSettlement == null || (!currentSettlement.IsTown && !currentSettlement.IsCastle && !currentSettlement.IsVillage))
		{
			return;
		}
		List<DiseaseInstance> heroDiseases = GetHeroDiseases(hero);
		foreach (DiseaseInstance item in heroDiseases)
		{
			if (!item.IsTreated && !item.HasPostTreatmentEffect)
			{
				TreatmentSystem.TreatAIHero(hero, item, currentSettlement);
			}
		}
	}

	internal void LogInternal(string message)
	{
		LogMessage(message);
	}

	public void MarkPartyGoingForTreatment(MobileParty party, Settlement settlement)
	{
		if (party != null && settlement != null)
		{
			_partiesGoingForTreatment[party] = settlement;
		}
	}

	public void OnPartyEnteredSettlement(MobileParty party, Settlement settlement, Hero hero)
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if ((instance != null && !instance.EnableDiseaseSystem) || party == null || settlement == null || (!settlement.IsTown && !settlement.IsCastle && !settlement.IsVillage))
		{
			return;
		}
		Settlement value;
		bool goalWasTreatment = _partiesGoingForTreatment.TryGetValue(party, out value) && value == settlement;
		_partiesGoingForTreatment.Remove(party);
		Hero leaderHero = party.LeaderHero;
		if (leaderHero != null && leaderHero != Hero.MainHero && leaderHero.IsAlive && IsHeroInfected(leaderHero))
		{
			TryTreatHeroOnEntry(leaderHero, settlement, goalWasTreatment);
		}
		if (hero != null && hero != leaderHero && hero != Hero.MainHero && hero.IsAlive && IsHeroInfected(hero))
		{
			TryTreatHeroOnEntry(hero, settlement, goalWasTreatment);
		}
		if (party != MobileParty.MainParty)
		{
			TroopRoster memberRoster = party.MemberRoster;
			if (memberRoster != null && memberRoster.TotalRegulars > 0 && PartyHasInfectedTroops(party))
			{
				TryTreatTroopsOnEntry(party, settlement, goalWasTreatment);
			}
		}
	}

	private void TryTreatHeroOnEntry(Hero hero, Settlement settlement, bool goalWasTreatment)
	{
		List<DiseaseInstance> heroDiseases = GetHeroDiseases(hero);
		foreach (DiseaseInstance item in heroDiseases)
		{
			if (item.IsTreated || item.HasPostTreatmentEffect)
			{
				continue;
			}
			Disease diseaseById = GetDiseaseById(item.DiseaseId);
			if (diseaseById == null)
			{
				continue;
			}
			if (!goalWasTreatment)
			{
				float num = 0.25f + (float)diseaseById.Severity * 0.05f;
				if (MBRandom.RandomFloat > num)
				{
					continue;
				}
			}
			TreatmentSystem.TreatAIHero(hero, item, settlement);
		}
	}

	private void TryTreatTroopsOnEntry(MobileParty party, Settlement settlement, bool goalWasTreatment)
	{
		List<DiseaseInstance> partyDiseases = GetPartyDiseases(party);
		if (partyDiseases == null || partyDiseases.Count == 0)
		{
			return;
		}
		if (!goalWasTreatment)
		{
			int num = 0;
			foreach (DiseaseInstance item in partyDiseases)
			{
				Disease diseaseById = GetDiseaseById(item.DiseaseId);
				if (diseaseById != null && diseaseById.Severity > num)
				{
					num = diseaseById.Severity;
				}
			}
			float num2 = 0.25f + (float)num * 0.05f;
			if (MBRandom.RandomFloat > num2)
			{
				return;
			}
		}
		Hero leaderHero = party.LeaderHero;
		string text = ((object)party.Name)?.ToString();
		int num3 = 0;
		foreach (DiseaseInstance item2 in partyDiseases)
		{
			if (!item2.IsTreated && !item2.HasPostTreatmentEffect && ((leaderHero == null) ? TreatmentSystem.TreatTroopsFree(item2, settlement, text ?? ((object)party).ToString()) : TreatmentSystem.TreatTroops(item2, settlement, leaderHero)))
			{
				num3++;
			}
		}
		if (num3 > 0)
		{
			if (leaderHero != null)
			{
				HospitalVisitSettlementNotification.NotifySettlementForceTreated(settlement, "party_troops", leaderHero);
			}
			else
			{
				HospitalVisitSettlementNotification.NotifySettlementForceTreated(settlement, "party_troops", null, text ?? ((object)party).ToString());
			}
		}
	}

	public void TickInMission(float dt)
	{
		if (CampaignMission.Current != null)
		{
			_missionInfectionTimer += dt;
			if (!(_missionInfectionTimer < 60f))
			{
				_missionInfectionTimer = 0f;
				OnMissionTick();
			}
		}
	}

	public void OnMissionTick()
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && !instance.EnableDiseaseSystem)
		{
			return;
		}
		Hero mainHero = Hero.MainHero;
		if (mainHero == null || !mainHero.IsAlive)
		{
			return;
		}
		Settlement currentSettlement = Settlement.CurrentSettlement;
		if (currentSettlement == null)
		{
			return;
		}
		ICampaignMission current = CampaignMission.Current;
		object obj;
		if (current == null)
		{
			obj = null;
		}
		else
		{
			Location location = current.Location;
			obj = ((location != null) ? location.StringId : null);
		}
		if ((string?)obj == "lordshall")
		{
			List<Hero> infectedHeroes = (from h in DiseaseSpreadSystem.GetInfectedHeroesInSettlement(currentSettlement)
				where h.IsLord && h != mainHero
				select h).ToList();
			List<Disease> diseasesFromInfectedHeroes = DiseaseSpreadSystem.GetDiseasesFromInfectedHeroes(infectedHeroes);
			{
				foreach (Disease item in diseasesFromInfectedHeroes)
				{
					if (IsHeroInfected(mainHero))
					{
						break;
					}
					if (DiseaseSpreadSystem.CheckLordHallInfection(mainHero, currentSettlement, item))
					{
						InfectHero(mainHero, item);
					}
				}
				return;
			}
		}
		List<Disease> allDiseasesForSettlement = GetAllDiseasesForSettlement(currentSettlement);
		foreach (Disease item2 in allDiseasesForSettlement)
		{
			if (IsHeroInfected(mainHero))
			{
				break;
			}
			if (DiseaseSpreadSystem.CheckMissionInfection(mainHero, currentSettlement, item2))
			{
				InfectHero(mainHero, item2);
			}
		}
	}

	private void CleanupExpiredDiseases()
	{
		HashSet<string> diseaseIdsWithActiveInstances = new HashSet<string>();
		for (int i = 0; i < _diseaseInstances.Count; i++)
		{
			DiseaseInstance diseaseInstance = _diseaseInstances[i];
			if (!diseaseInstance.IsRecovered && !diseaseInstance.IsDead)
			{
				diseaseIdsWithActiveInstances.Add(diseaseInstance.DiseaseId);
			}
		}
		_diseases.RemoveAll(delegate(Disease d)
		{
			if (!d.IsExpired())
			{
				return false;
			}
			if (diseaseIdsWithActiveInstances.Contains(d.Id))
			{
				LogMessage("[DISEASE_MANAGER] Keeping expired disease '" + d.Name + "' — still has active instances");
				return false;
			}
			LogMessage("[DISEASE_MANAGER] Removed expired disease: " + d.Name);
			return true;
		});
		_diseaseIndex.Clear();
		_settlementDiseaseIndex.Clear();
		foreach (Disease disease in _diseases)
		{
			_diseaseIndex[disease.Id] = disease;
			if (disease.SettlementId != null && !disease.IsExpired())
			{
				if (!_settlementDiseaseIndex.TryGetValue(disease.SettlementId, out var value))
				{
					value = new List<Disease>(2);
					_settlementDiseaseIndex[disease.SettlementId] = value;
				}
				value.Add(disease);
			}
		}
		int count = _diseaseInstances.Count;
		_diseaseInstances.RemoveAll((DiseaseInstance diseaseInstance2) => !_diseaseIndex.ContainsKey(diseaseInstance2.DiseaseId) && diseaseInstance2.PermanentModifiers == null && !diseaseInstance2.HasActiveSeasonalImmunity());
		if (_diseaseInstances.Count != count)
		{
			RebuildIndexes();
		}
	}

	private void CleanupRecoveredAndDeadInstances()
	{
		int count = _diseaseInstances.Count;
		_diseaseInstances.RemoveAll((DiseaseInstance i) => i.IsDead || (i.TargetType == DiseaseTargetType.PartyTroops && i.IsRecovered) || (i.TargetType == DiseaseTargetType.PartyPrisoners && i.IsRecovered) || (i.TargetType == DiseaseTargetType.Hero && i.IsRecovered && i.PermanentModifiers == null && !i.HasActiveSeasonalImmunity() && !_diseaseIndex.ContainsKey(i.DiseaseId)));
		if (_diseaseInstances.Count != count)
		{
			RebuildIndexes();
		}
	}

	private void CleanupOrphanedInstances()
	{
		int count = _diseaseInstances.Count;
		_diseaseInstances.RemoveAll(delegate(DiseaseInstance i)
		{
			if (i.TargetType == DiseaseTargetType.Hero)
			{
				_heroLookup.TryGetValue(i.TargetId, out var value);
				if (value == null || !value.IsAlive || value.IsDead)
				{
					string text = ((value == null) ? "not found in AllAliveHeroes" : "dead or disabled");
					DiseaseLogger.Instance?.Log($"[DISEASE_CLEANUP] Removed orphaned hero instance: TargetId={i.TargetId}, Disease={i.DiseaseName ?? i.DiseaseId}, Progress={i.DiseaseProgress:F1}% ({text})");
					return true;
				}
				if (value.IsChild)
				{
					DiseaseLogger.Instance?.Log($"[DISEASE_CLEANUP] Removed child hero instance: {value.Name} (TargetId={i.TargetId}), Disease={i.DiseaseName ?? i.DiseaseId}, Progress={i.DiseaseProgress:F1}%");
					return true;
				}
				return false;
			}
			if ((i.TargetType == DiseaseTargetType.PartyTroops || i.TargetType == DiseaseTargetType.PartyPrisoners) && !string.IsNullOrEmpty(i.PartyId) && !_partyLookup.ContainsKey(i.PartyId))
			{
				DiseaseLogger.Instance?.Log($"[DISEASE_CLEANUP] Removed orphaned party instance: PartyId={i.PartyId}, Disease={i.DiseaseName ?? i.DiseaseId}, Progress={i.DiseaseProgress:F1}% (party not found)");
				return true;
			}
			return false;
		});
		int num = count - _diseaseInstances.Count;
		if (num > 0)
		{
			DiseaseLogger.Instance?.Log($"[DISEASE_CLEANUP] Total removed: {num} orphaned instances (before: {count}, after: {_diseaseInstances.Count})");
			RebuildIndexes();
		}
	}

	public SettlementDiseaseInstance GetSettlementDiseaseInstance(Settlement settlement, string targetType)
	{
		return _settlementDiseaseInstances.FirstOrDefault((SettlementDiseaseInstance i) => i.SettlementId == ((MBObjectBase)settlement).StringId && i.TargetType == targetType && !i.IsRecovered());
	}

	public SettlementDiseaseInstance CreateSettlementDiseaseInstance(Settlement settlement, Disease disease, string targetType)
	{
		SettlementDiseaseInstance settlementDiseaseInstance = new SettlementDiseaseInstance
		{
			SettlementId = ((MBObjectBase)settlement).StringId,
			DiseaseId = disease.Id,
			TargetType = targetType,
			InfectionProgress = 15f
		};
		_settlementDiseaseInstances.Add(settlementDiseaseInstance);
		return settlementDiseaseInstance;
	}

	public List<SettlementDiseaseInstance> GetAllSettlementDiseaseInstances(Settlement settlement)
	{
		return _settlementDiseaseInstances.Where((SettlementDiseaseInstance i) => i.SettlementId == ((MBObjectBase)settlement).StringId && !i.IsRecovered()).ToList();
	}

	internal void LogMessage(string message)
	{
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableDebugLogging)
		{
			DiseaseLogger.Instance?.Log(message);
		}
	}

	private void SetDiseaseDeathReason(Hero hero, Disease disease)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		try
		{
			NPCContext nPCContext = AIInfluenceBehavior.Instance?.GetNPCContextByStringId(((MBObjectBase)hero).StringId);
			if (nPCContext != null)
			{
				TextObject val = new TextObject("{=AIInfluence_DeathReasonFromDisease}Died from {DISEASE_NAME}. {DESCRIPTION}", (Dictionary<string, object>)null);
				val.SetTextVariable("DISEASE_NAME", disease.Name);
				val.SetTextVariable("DESCRIPTION", disease.Description ?? "");
				nPCContext.DeathReason = ((object)val).ToString();
				AIInfluenceBehavior.Instance?.SaveNPCContext(((MBObjectBase)hero).StringId, hero, nPCContext);
				if (hero == Hero.MainHero)
				{
					LogMessage($"[DISEASE_MANAGER] Set death reason for {hero.Name}");
				}
			}
		}
		catch (Exception ex)
		{
			if (hero == Hero.MainHero)
			{
				LogMessage("[DISEASE_MANAGER] Error setting death reason: " + ex.Message);
			}
		}
	}
}
