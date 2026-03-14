using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class WarStatisticsTracker
{
	private static WarStatisticsTracker _instance;

	private CampaignTime _lastStatisticsUpdate;

	private const float UPDATE_INTERVAL_HOURS = 12f;

	private const int HISTORY_RETENTION_HOURS = 240;

	private readonly DiplomacyStorage _storage;

	public static WarStatisticsTracker Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new WarStatisticsTracker();
			}
			return _instance;
		}
	}

	public Dictionary<string, KingdomWarStats> KingdomStats { get; set; } = new Dictionary<string, KingdomWarStats>();

	private WarStatisticsTracker()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		_lastStatisticsUpdate = CampaignTime.Now;
		_storage = new DiplomacyStorage();
		WarFatigueLogger.Instance.LogInitialization();
	}

	public static void Reset()
	{
		if (_instance != null)
		{
			_instance.KingdomStats.Clear();
			AIInfluenceBehavior.Instance?.LogMessage("[WAR_STATS] War statistics tracker state reset for new campaign");
		}
		_instance = null;
	}

	public void Initialize()
	{
		WarFatigueLogger.Instance.Log("[WAR_STATS] Initializing war statistics tracker...");
		KingdomStats.Clear();
		_storage.LoadWarStatistics(this);
		InitializeExistingWars();
		CleanupConflictingDiplomaticRelations();
		WarFatigueLogger.Instance.Log($"[WAR_STATS] War statistics tracker initialized with {KingdomStats.Count} kingdoms");
	}

	private void InitializeExistingWars()
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		Random random = new Random();
		foreach (Kingdom kingdom in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			InitializeKingdomStats(kingdom);
			List<Kingdom> list = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)k)).ToList();
			foreach (Kingdom item in list)
			{
				string stringId = ((MBObjectBase)kingdom).StringId;
				string stringId2 = ((MBObjectBase)item).StringId;
				KingdomWarStats kingdomWarStats = KingdomStats[stringId];
				if (!kingdomWarStats.WarsAgainstKingdoms.ContainsKey(stringId2))
				{
					kingdomWarStats.WarsAgainstKingdoms[stringId2] = new WarStatsAgainstKingdom
					{
						EnemyKingdomId = stringId2,
						IsActive = true,
						CasualtiesAgainstThisKingdom = 0,
						PreviousCasualtiesAgainstThisKingdom = 0
					};
					int num = random.Next(15, 41);
					kingdomWarStats.WarsAgainstKingdoms[stringId2].WarStartTime = CampaignTime.DaysFromNow((float)(-num));
					WarFatigueLogger.Instance.Log($"[WAR_STATS] Initialized existing war tracking: {kingdom.Name} vs {item.Name} (start time set to {num} days ago - existing war)");
					continue;
				}
				WarStatsAgainstKingdom warStatsAgainstKingdom = kingdomWarStats.WarsAgainstKingdoms[stringId2];
				warStatsAgainstKingdom.IsActive = true;
				_ = warStatsAgainstKingdom.WarStartTime;
				CampaignTime warStartTime = warStatsAgainstKingdom.WarStartTime;
				if ((warStartTime).GetYear == 0 || warStatsAgainstKingdom.WarStartTimeDays <= 0f)
				{
					int num2 = random.Next(15, 41);
					warStatsAgainstKingdom.WarStartTime = CampaignTime.DaysFromNow((float)(-num2));
					WarFatigueLogger.Instance.Log($"[WAR_STATS] Fixed war start time: {kingdom.Name} vs {item.Name} (start time set to {num2} days ago - fixed existing war)");
				}
				else
				{
					WarFatigueLogger.Instance.Log($"[WAR_STATS] War already properly tracked: {kingdom.Name} vs {item.Name} (keeping existing start time, reactivated)");
				}
			}
		}
	}

	private void CleanupConflictingDiplomaticRelations()
	{
		WarFatigueLogger.Instance.Log("[WAR_STATS] Cleaning up conflicting diplomatic relations...");
		int num = 0;
		int num2 = 0;
		foreach (Kingdom kingdom1 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k != kingdom1))
			{
				if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom1, (IFaction)(object)item))
				{
					AllianceSystem instance = AllianceSystem.Instance;
					if (instance != null && instance.AreAllied(kingdom1, item))
					{
						WarFatigueLogger.Instance.Log($"[WAR_STATS] Breaking conflicting alliance: {kingdom1.Name} ↔ {item.Name} (at war)");
						instance.BreakAlliance(kingdom1, item);
						num++;
					}
					TradeAgreementSystem instance2 = TradeAgreementSystem.Instance;
					if (instance2 != null && instance2.HasTradeAgreement(kingdom1, item, out var _))
					{
						WarFatigueLogger.Instance.Log($"[WAR_STATS] Ending conflicting trade agreement: {kingdom1.Name} ↔ {item.Name} (at war)");
						instance2.EndTradeAgreement(kingdom1, item);
						num2++;
					}
				}
			}
		}
		if (num > 0 || num2 > 0)
		{
			WarFatigueLogger.Instance.Log($"[WAR_STATS] Cleanup complete: {num} alliances broken, {num2} trade agreements ended");
		}
		else
		{
			WarFatigueLogger.Instance.Log("[WAR_STATS] No conflicting diplomatic relations found");
		}
	}

	public void SaveData()
	{
		_storage.SaveWarStatistics(this);
	}

	public void InitializeKingdomStats(Kingdom kingdom)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom != null)
		{
			string stringId = ((MBObjectBase)kingdom).StringId;
			if (!KingdomStats.ContainsKey(stringId))
			{
				KingdomWarStats kingdomWarStats = new KingdomWarStats
				{
					KingdomId = stringId,
					InitialTroops = CalculateTotalTroops(kingdom),
					CurrentTroops = CalculateTotalTroops(kingdom),
					InitialSettlements = (((List<Settlement>)(object)kingdom.Settlements)?.Count ?? 0),
					CurrentSettlements = (((List<Settlement>)(object)kingdom.Settlements)?.Count ?? 0),
					LastUpdateTime = CampaignTime.Now
				};
				KingdomStats[stringId] = kingdomWarStats;
				WarFatigueLogger.Instance.Log($"[WAR_STATS] Initialized stats for {kingdom.Name}: {kingdomWarStats.InitialTroops} troops, {kingdomWarStats.InitialSettlements} settlements");
			}
		}
	}

	public void TrackWarStart(Kingdom kingdom1, Kingdom kingdom2)
	{
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom1 == null || kingdom2 == null)
		{
			return;
		}
		InitializeKingdomStats(kingdom1);
		InitializeKingdomStats(kingdom2);
		string k1Id = ((MBObjectBase)kingdom1).StringId;
		string k2Id = ((MBObjectBase)kingdom2).StringId;
		if (KingdomStats.ContainsKey(k1Id))
		{
			KingdomWarStats kingdomWarStats = KingdomStats[k1Id];
			bool flag = kingdomWarStats.WarsAgainstKingdoms.ContainsKey(k2Id);
			bool flag2 = flag && kingdomWarStats.WarsAgainstKingdoms[k2Id].IsActive;
			if (!flag || !flag2)
			{
				bool flag3 = kingdomWarStats.WarsAgainstKingdoms.Values.Any((WarStatsAgainstKingdom w) => w.IsActive && w.EnemyKingdomId != k2Id);
				kingdomWarStats.WarsAgainstKingdoms[k2Id] = new WarStatsAgainstKingdom
				{
					EnemyKingdomId = k2Id,
					WarStartTime = CampaignTime.Now,
					IsActive = true,
					CasualtiesAgainstThisKingdom = 0,
					PreviousCasualtiesAgainstThisKingdom = 0
				};
				WarFatigueLogger.Instance.Log($"[WAR_STATS] Tracked NEW war start: {kingdom1.Name} vs {kingdom2.Name} (new war, start time = now, losses reset to 0)");
				if (!flag3)
				{
					kingdomWarStats.BaseFatigue = kingdomWarStats.WarFatigue;
					kingdomWarStats.TotalCasualties = 0;
					kingdomWarStats.TotalLordsCaptured = 0;
					kingdomWarStats.TotalLordsKilled = 0;
					kingdomWarStats.TotalSettlementsLost = 0;
					kingdomWarStats.TotalCaravansDestroyed = 0;
					kingdomWarStats.InitialTroops = CalculateTotalTroops(kingdom1);
					kingdomWarStats.CurrentTroops = kingdomWarStats.InitialTroops;
					kingdomWarStats.InitialSettlements = ((List<Settlement>)(object)kingdom1.Settlements)?.Count ?? 0;
					kingdomWarStats.CurrentSettlements = kingdomWarStats.InitialSettlements;
					kingdomWarStats.PreviousCasualties = 0;
					kingdomWarStats.PreviousTroops = kingdomWarStats.InitialTroops;
					WarFatigueLogger.Instance.Log($"[WAR_STATS] Reset loss counters for {kingdom1.Name} (new war, no other active wars). Base fatigue preserved: {kingdomWarStats.BaseFatigue:F1}%. Baseline: {kingdomWarStats.InitialTroops} troops, {kingdomWarStats.InitialSettlements} settlements");
				}
				else
				{
					kingdomWarStats.CurrentTroops = CalculateTotalTroops(kingdom1);
					kingdomWarStats.CurrentSettlements = ((List<Settlement>)(object)kingdom1.Settlements)?.Count ?? 0;
					WarFatigueLogger.Instance.Log($"[WAR_STATS] New war {kingdom1.Name} vs {kingdom2.Name} (has other active wars). Keeping existing baseline. Fatigue: {kingdomWarStats.WarFatigue:F1}%. Baseline: {kingdomWarStats.InitialTroops} troops, {kingdomWarStats.InitialSettlements} settlements");
				}
			}
			else
			{
				kingdomWarStats.WarsAgainstKingdoms[k2Id].IsActive = true;
				WarFatigueLogger.Instance.Log($"[WAR_STATS] War already active: {kingdom1.Name} vs {kingdom2.Name}");
			}
		}
		if (KingdomStats.ContainsKey(k2Id))
		{
			KingdomWarStats kingdomWarStats2 = KingdomStats[k2Id];
			bool flag4 = kingdomWarStats2.WarsAgainstKingdoms.ContainsKey(k1Id);
			bool flag5 = flag4 && kingdomWarStats2.WarsAgainstKingdoms[k1Id].IsActive;
			if (!flag4 || !flag5)
			{
				bool flag6 = kingdomWarStats2.WarsAgainstKingdoms.Values.Any((WarStatsAgainstKingdom w) => w.IsActive && w.EnemyKingdomId != k1Id);
				kingdomWarStats2.WarsAgainstKingdoms[k1Id] = new WarStatsAgainstKingdom
				{
					EnemyKingdomId = k1Id,
					WarStartTime = CampaignTime.Now,
					IsActive = true,
					CasualtiesAgainstThisKingdom = 0,
					PreviousCasualtiesAgainstThisKingdom = 0
				};
				WarFatigueLogger.Instance.Log($"[WAR_STATS] Tracked NEW war start: {kingdom2.Name} vs {kingdom1.Name} (new war, start time = now, losses reset to 0)");
				if (!flag6)
				{
					kingdomWarStats2.BaseFatigue = kingdomWarStats2.WarFatigue;
					kingdomWarStats2.TotalCasualties = 0;
					kingdomWarStats2.TotalLordsCaptured = 0;
					kingdomWarStats2.TotalLordsKilled = 0;
					kingdomWarStats2.TotalSettlementsLost = 0;
					kingdomWarStats2.TotalCaravansDestroyed = 0;
					kingdomWarStats2.InitialTroops = CalculateTotalTroops(kingdom2);
					kingdomWarStats2.CurrentTroops = kingdomWarStats2.InitialTroops;
					kingdomWarStats2.InitialSettlements = ((List<Settlement>)(object)kingdom2.Settlements)?.Count ?? 0;
					kingdomWarStats2.CurrentSettlements = kingdomWarStats2.InitialSettlements;
					kingdomWarStats2.PreviousCasualties = 0;
					kingdomWarStats2.PreviousTroops = kingdomWarStats2.InitialTroops;
					WarFatigueLogger.Instance.Log($"[WAR_STATS] Reset loss counters for {kingdom2.Name} (new war, no other active wars). Base fatigue preserved: {kingdomWarStats2.BaseFatigue:F1}%. Baseline: {kingdomWarStats2.InitialTroops} troops, {kingdomWarStats2.InitialSettlements} settlements");
				}
				else
				{
					kingdomWarStats2.CurrentTroops = CalculateTotalTroops(kingdom2);
					kingdomWarStats2.CurrentSettlements = ((List<Settlement>)(object)kingdom2.Settlements)?.Count ?? 0;
					WarFatigueLogger.Instance.Log($"[WAR_STATS] New war {kingdom2.Name} vs {kingdom1.Name} (has other active wars). Keeping existing baseline. Fatigue: {kingdomWarStats2.WarFatigue:F1}%. Baseline: {kingdomWarStats2.InitialTroops} troops, {kingdomWarStats2.InitialSettlements} settlements");
				}
			}
			else
			{
				kingdomWarStats2.WarsAgainstKingdoms[k1Id].IsActive = true;
				WarFatigueLogger.Instance.Log($"[WAR_STATS] War already active: {kingdom2.Name} vs {kingdom1.Name}");
			}
		}
		WarFatigueLogger.Instance.Log($"[WAR_STATS] Tracked war start: {kingdom1.Name} vs {kingdom2.Name}");
	}

	public void UpdateCasualties(Kingdom kingdom, int casualties, Kingdom enemyKingdom = null)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null || casualties <= 0)
		{
			return;
		}
		InitializeKingdomStats(kingdom);
		string stringId = ((MBObjectBase)kingdom).StringId;
		KingdomWarStats kingdomWarStats = KingdomStats[stringId];
		kingdomWarStats.TotalCasualties += casualties;
		if (enemyKingdom != null && enemyKingdom != kingdom)
		{
			if (FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)enemyKingdom))
			{
				string stringId2 = ((MBObjectBase)enemyKingdom).StringId;
				if (!kingdomWarStats.WarsAgainstKingdoms.ContainsKey(stringId2))
				{
					kingdomWarStats.WarsAgainstKingdoms[stringId2] = new WarStatsAgainstKingdom
					{
						EnemyKingdomId = stringId2,
						WarStartTime = CampaignTime.Now,
						IsActive = true,
						CasualtiesAgainstThisKingdom = 0,
						PreviousCasualtiesAgainstThisKingdom = 0
					};
				}
				kingdomWarStats.WarsAgainstKingdoms[stringId2].CasualtiesAgainstThisKingdom += casualties;
				WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name} suffered {casualties} casualties against {enemyKingdom.Name} (war casualties: {kingdomWarStats.WarsAgainstKingdoms[stringId2].CasualtiesAgainstThisKingdom})");
			}
			else
			{
				WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name} suffered {casualties} casualties against {enemyKingdom.Name} (not at war, not counted towards fatigue)");
			}
		}
		else
		{
			WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name} suffered {casualties} casualties (no enemy kingdom or non-kingdom battle)");
		}
	}

	public void IncrementLordsCaptured(Kingdom kingdom)
	{
		if (kingdom != null)
		{
			InitializeKingdomStats(kingdom);
			KingdomWarStats kingdomWarStats = KingdomStats[((MBObjectBase)kingdom).StringId];
			kingdomWarStats.TotalLordsCaptured++;
			WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name} lord captured (total: {kingdomWarStats.TotalLordsCaptured})");
		}
	}

	public void DecrementLordsCaptured(Kingdom kingdom)
	{
		if (kingdom != null)
		{
			InitializeKingdomStats(kingdom);
			KingdomWarStats kingdomWarStats = KingdomStats[((MBObjectBase)kingdom).StringId];
			if (kingdomWarStats.TotalLordsCaptured > 0)
			{
				kingdomWarStats.TotalLordsCaptured--;
				WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name} lord released (total: {kingdomWarStats.TotalLordsCaptured})");
			}
		}
	}

	public void IncrementLordsKilled(Kingdom kingdom)
	{
		if (kingdom != null)
		{
			InitializeKingdomStats(kingdom);
			KingdomWarStats kingdomWarStats = KingdomStats[((MBObjectBase)kingdom).StringId];
			kingdomWarStats.TotalLordsKilled++;
			WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name} lord killed (total: {kingdomWarStats.TotalLordsKilled})");
		}
	}

	public void IncrementSettlementsLost(Kingdom kingdom)
	{
		if (kingdom != null)
		{
			InitializeKingdomStats(kingdom);
			KingdomWarStats kingdomWarStats = KingdomStats[((MBObjectBase)kingdom).StringId];
			kingdomWarStats.TotalSettlementsLost++;
			WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name} settlement lost (total: {kingdomWarStats.TotalSettlementsLost})");
		}
	}

	public void IncrementCaravansDestroyed(Kingdom kingdom)
	{
		if (kingdom != null)
		{
			InitializeKingdomStats(kingdom);
			KingdomWarStats kingdomWarStats = KingdomStats[((MBObjectBase)kingdom).StringId];
			kingdomWarStats.TotalCaravansDestroyed++;
			WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name} caravan destroyed (total: {kingdomWarStats.TotalCaravansDestroyed})");
		}
	}

	public void UpdateWarStatistics()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime val = CampaignTime.Now - _lastStatisticsUpdate;
		if ((val).ToHours < 12.0)
		{
			return;
		}
		foreach (Kingdom kingdom in (List<Kingdom>)(object)Kingdom.All)
		{
			if (kingdom == null || kingdom.IsEliminated)
			{
				continue;
			}
			InitializeKingdomStats(kingdom);
			string stringId = ((MBObjectBase)kingdom).StringId;
			KingdomWarStats kingdomWarStats = KingdomStats[stringId];
			kingdomWarStats.PreviousCasualties = kingdomWarStats.TotalCasualties;
			kingdomWarStats.PreviousTroops = kingdomWarStats.CurrentTroops;
			kingdomWarStats.CurrentTroops = CalculateTotalTroops(kingdom);
			int num = (kingdomWarStats.CurrentSettlements = ((List<Settlement>)(object)kingdom.Settlements)?.Count ?? 0);
			kingdomWarStats.DaysAtWar = CalculateDaysAtWar(kingdom);
			if (kingdomWarStats.InitialSettlements > 0)
			{
				int val2 = kingdomWarStats.InitialSettlements - num;
				kingdomWarStats.TotalSettlementsLost = Math.Max(0, val2);
			}
			else
			{
				kingdomWarStats.InitialSettlements = num;
				kingdomWarStats.TotalSettlementsLost = 0;
			}
			CreateStatsSnapshot(kingdomWarStats);
			foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)k)))
			{
				string stringId2 = ((MBObjectBase)item).StringId;
				if (kingdomWarStats.WarsAgainstKingdoms.ContainsKey(stringId2))
				{
					WarStatsAgainstKingdom warStatsAgainstKingdom = kingdomWarStats.WarsAgainstKingdoms[stringId2];
					warStatsAgainstKingdom.PreviousCasualtiesAgainstThisKingdom = warStatsAgainstKingdom.CasualtiesAgainstThisKingdom;
				}
			}
			bool flag = ((IEnumerable<Kingdom>)Kingdom.All).Any((Kingdom k) => k != kingdom && !k.IsEliminated && FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)k));
			if (flag)
			{
				float num3 = CalculateWarFatigue(kingdomWarStats);
				kingdomWarStats.WarFatigue = kingdomWarStats.BaseFatigue + num3;
				kingdomWarStats.WarFatigue = Math.Min(kingdomWarStats.WarFatigue, 100f);
				if (kingdomWarStats.BaseFatigue > 0f)
				{
					float num4 = GlobalSettings<ModSettings>.Instance.FatigueRecoveryPerDay * 0.25f * 0.5f;
					kingdomWarStats.BaseFatigue = Math.Max(0f, kingdomWarStats.BaseFatigue - num4);
				}
			}
			kingdomWarStats.LastUpdateTime = CampaignTime.Now;
			if (flag || kingdomWarStats.WarFatigue > 0f)
			{
				WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name}: Troops={kingdomWarStats.CurrentTroops}, Casualties={kingdomWarStats.TotalCasualties}, Lords Captured={kingdomWarStats.TotalLordsCaptured}, Lords Killed={kingdomWarStats.TotalLordsKilled}, Settlements Lost={kingdomWarStats.TotalSettlementsLost}, Fatigue={kingdomWarStats.WarFatigue:F1}%");
			}
		}
		_lastStatisticsUpdate = CampaignTime.Now;
		SaveData();
	}

	public WarStatistics GetWarStatistics(Kingdom kingdom1, Kingdom kingdom2)
	{
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom1 == null || kingdom2 == null)
		{
			return new WarStatistics();
		}
		InitializeKingdomStats(kingdom1);
		InitializeKingdomStats(kingdom2);
		KingdomWarStats kingdomWarStats = KingdomStats[((MBObjectBase)kingdom1).StringId];
		KingdomWarStats kingdomWarStats2 = KingdomStats[((MBObjectBase)kingdom2).StringId];
		WarStatistics obj = new WarStatistics
		{
			Kingdom1Id = ((MBObjectBase)kingdom1).StringId,
			Kingdom2Id = ((MBObjectBase)kingdom2).StringId,
			Kingdom1Casualties = (kingdomWarStats.WarsAgainstKingdoms.ContainsKey(((MBObjectBase)kingdom2).StringId) ? kingdomWarStats.WarsAgainstKingdoms[((MBObjectBase)kingdom2).StringId].CasualtiesAgainstThisKingdom : 0),
			Kingdom2Casualties = (kingdomWarStats2.WarsAgainstKingdoms.ContainsKey(((MBObjectBase)kingdom1).StringId) ? kingdomWarStats2.WarsAgainstKingdoms[((MBObjectBase)kingdom1).StringId].CasualtiesAgainstThisKingdom : 0),
			Kingdom1Troops = kingdomWarStats.CurrentTroops,
			Kingdom2Troops = kingdomWarStats2.CurrentTroops,
			Kingdom1WarFatigue = kingdomWarStats.WarFatigue,
			Kingdom2WarFatigue = kingdomWarStats2.WarFatigue
		};
		int daysAtWar;
		if (!kingdomWarStats.WarsAgainstKingdoms.ContainsKey(((MBObjectBase)kingdom2).StringId))
		{
			daysAtWar = 0;
		}
		else
		{
			CampaignTime val = CampaignTime.Now - kingdomWarStats.WarsAgainstKingdoms[((MBObjectBase)kingdom2).StringId].WarStartTime;
			daysAtWar = (int)(val).ToDays;
		}
		obj.DaysAtWar = daysAtWar;
		return obj;
	}

	public void ApplyDailyFatigueRecovery()
	{
		foreach (Kingdom kingdom in (List<Kingdom>)(object)Kingdom.All)
		{
			if (kingdom == null || kingdom.IsEliminated)
			{
				continue;
			}
			InitializeKingdomStats(kingdom);
			string stringId = ((MBObjectBase)kingdom).StringId;
			KingdomWarStats kingdomWarStats = KingdomStats[stringId];
			if (!((IEnumerable<Kingdom>)Kingdom.All).Any((Kingdom k) => k != kingdom && !k.IsEliminated && FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)k)) && kingdomWarStats.WarFatigue > 0f)
			{
				float fatigueRecoveryPerDay = GlobalSettings<ModSettings>.Instance.FatigueRecoveryPerDay;
				float warFatigue = kingdomWarStats.WarFatigue;
				float baseFatigue = kingdomWarStats.BaseFatigue;
				kingdomWarStats.WarFatigue = Math.Max(0f, kingdomWarStats.WarFatigue - fatigueRecoveryPerDay);
				kingdomWarStats.BaseFatigue = Math.Max(0f, kingdomWarStats.BaseFatigue - fatigueRecoveryPerDay);
				if (warFatigue != kingdomWarStats.WarFatigue)
				{
					WarFatigueLogger.Instance.Log($"[WAR_STATS] {kingdom.Name} fatigue recovery: {warFatigue:F1}% → {kingdomWarStats.WarFatigue:F1}% (base: {baseFatigue:F1}% → {kingdomWarStats.BaseFatigue:F1}%, recovered {fatigueRecoveryPerDay:F1} points)");
				}
			}
		}
	}

	private float CalculateWarFatigue(KingdomWarStats stats)
	{
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		if (stats == null || stats.InitialTroops == 0)
		{
			return 0f;
		}
		float num = 0f;
		int num2 = 0;
		if (stats.WarsAgainstKingdoms != null)
		{
			foreach (WarStatsAgainstKingdom value in stats.WarsAgainstKingdoms.Values)
			{
				if (value != null && value.IsActive)
				{
					num2 += value.CasualtiesAgainstThisKingdom;
				}
			}
		}
		float num3 = (float)num2 * GlobalSettings<ModSettings>.Instance.FatiguePerTroopLost;
		num += num3;
		float num4 = (float)stats.TotalLordsCaptured * GlobalSettings<ModSettings>.Instance.FatiguePerLordCaptured;
		num += num4;
		float num5 = (float)stats.TotalLordsKilled * GlobalSettings<ModSettings>.Instance.FatiguePerLordKilled;
		num += num5;
		float num6 = (float)Math.Max(0, stats.TotalSettlementsLost) * GlobalSettings<ModSettings>.Instance.FatiguePerSettlementLost;
		num += num6;
		float num7 = (float)stats.TotalCaravansDestroyed * GlobalSettings<ModSettings>.Instance.FatiguePerCaravanDestroyed;
		num += num7;
		float num8 = 0f;
		if (stats.WarsAgainstKingdoms != null)
		{
			foreach (WarStatsAgainstKingdom value2 in stats.WarsAgainstKingdoms.Values)
			{
				if (value2 != null && value2.IsActive && value2.WarStartTimeDays > 0f)
				{
					CampaignTime now = CampaignTime.Now;
					float val = (float)(now).ToDays - value2.WarStartTimeDays;
					val = Math.Max(0f, val);
					num8 += Math.Min(val / 30f, 1f) * 10f;
				}
			}
		}
		num += Math.Min(num8, 10f);
		return Math.Min(Math.Max(0f, num), 100f);
	}

	private void CreateStatsSnapshot(KingdomWarStats stats)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		if (stats != null)
		{
			WarStatsSnapshot item = new WarStatsSnapshot
			{
				Timestamp = CampaignTime.Now,
				Troops = stats.CurrentTroops,
				Casualties = stats.TotalCasualties,
				LordsCaptured = stats.TotalLordsCaptured,
				LordsKilled = stats.TotalLordsKilled,
				SettlementsLost = stats.TotalSettlementsLost,
				CaravansDestroyed = stats.TotalCaravansDestroyed
			};
			stats.StatsHistory.Add(item);
			CampaignTime now = CampaignTime.Now;
			float currentHours = (float)(now).ToHours;
			stats.StatsHistory.RemoveAll(delegate(WarStatsSnapshot s)
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime timestamp = s.Timestamp;
				float num = (float)(timestamp).ToHours;
				return currentHours - num > 240f;
			});
		}
	}

	private int CalculateTotalTroops(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return 0;
		}
		int num = 0;
		foreach (Clan item in (List<Clan>)(object)kingdom.Clans)
		{
			if (item == null)
			{
				continue;
			}
			foreach (Hero lord in item.GetLords())
			{
				if (lord != null)
				{
					MobileParty partyBelongedTo = lord.PartyBelongedTo;
					if (partyBelongedTo != null && partyBelongedTo.MemberRoster != null)
					{
						num += partyBelongedTo.MemberRoster.TotalManCount;
					}
				}
			}
		}
		foreach (Settlement item2 in (List<Settlement>)(object)kingdom.Settlements)
		{
			if (item2 != null && item2.Town != null)
			{
				MobileParty garrisonParty = ((Fief)item2.Town).GarrisonParty;
				if (garrisonParty != null && garrisonParty.MemberRoster != null)
				{
					num += garrisonParty.MemberRoster.TotalManCount;
				}
			}
		}
		return num;
	}

	private int CalculateDaysAtWar(Kingdom kingdom)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return 0;
		}
		InitializeKingdomStats(kingdom);
		KingdomWarStats kingdomWarStats = KingdomStats[((MBObjectBase)kingdom).StringId];
		int num = 0;
		foreach (WarStatsAgainstKingdom warStats in kingdomWarStats.WarsAgainstKingdoms.Values)
		{
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == warStats.EnemyKingdomId));
			if (val == null || val.IsEliminated || !FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)val))
			{
				continue;
			}
			_ = warStats.WarStartTime;
			if (true)
			{
				CampaignTime val2 = CampaignTime.Now - warStats.WarStartTime;
				int val3 = (int)(val2).ToDays;
				val3 = Math.Max(0, val3);
				if (val3 > num)
				{
					num = val3;
				}
			}
		}
		return num;
	}

	public KingdomWarStats GetKingdomStats(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return null;
		}
		InitializeKingdomStats(kingdom);
		return KingdomStats[((MBObjectBase)kingdom).StringId];
	}

	public void OnWarEnded(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 != null && kingdom2 != null)
		{
			string stringId = ((MBObjectBase)kingdom1).StringId;
			string stringId2 = ((MBObjectBase)kingdom2).StringId;
			if (KingdomStats.ContainsKey(stringId) && KingdomStats[stringId].WarsAgainstKingdoms.ContainsKey(stringId2))
			{
				KingdomStats[stringId].WarsAgainstKingdoms[stringId2].IsActive = false;
				WarFatigueLogger.Instance.Log($"[WAR_STATS] War marked as inactive: {kingdom1.Name} vs {kingdom2.Name}");
			}
			if (KingdomStats.ContainsKey(stringId2) && KingdomStats[stringId2].WarsAgainstKingdoms.ContainsKey(stringId))
			{
				KingdomStats[stringId2].WarsAgainstKingdoms[stringId].IsActive = false;
				WarFatigueLogger.Instance.Log($"[WAR_STATS] War marked as inactive: {kingdom2.Name} vs {kingdom1.Name}");
			}
			WarFatigueLogger.Instance.Log($"[WAR_STATS] War ended: {kingdom1.Name} vs {kingdom2.Name}");
		}
	}

	public void SaveDiplomaticReason(Kingdom sourceKingdom, Kingdom targetKingdom, string actionType, string reason, string statementText)
	{
		if (sourceKingdom != null && targetKingdom != null && !string.IsNullOrEmpty(actionType) && !string.IsNullOrEmpty(reason))
		{
			InitializeKingdomStats(sourceKingdom);
			string stringId = ((MBObjectBase)sourceKingdom).StringId;
			KingdomWarStats kingdomWarStats = KingdomStats[stringId];
			if (kingdomWarStats.DiplomaticReasons == null)
			{
				kingdomWarStats.DiplomaticReasons = new Dictionary<string, DiplomaticReason>();
			}
			string key = actionType + "_" + ((MBObjectBase)targetKingdom).StringId;
			kingdomWarStats.DiplomaticReasons[key] = new DiplomaticReason(actionType, ((MBObjectBase)targetKingdom).StringId, reason, statementText);
			WarFatigueLogger.Instance.Log($"[WAR_STATS] Saved {actionType} reason for {sourceKingdom.Name} vs {targetKingdom.Name}: {reason}");
		}
	}

	public List<DiplomaticReason> GetDiplomaticReasons(Kingdom kingdom, string actionType = null)
	{
		if (kingdom == null)
		{
			return new List<DiplomaticReason>();
		}
		KingdomWarStats kingdomStats = GetKingdomStats(kingdom);
		if (kingdomStats?.DiplomaticReasons == null)
		{
			return new List<DiplomaticReason>();
		}
		List<DiplomaticReason> list = kingdomStats.DiplomaticReasons.Values.ToList();
		if (!string.IsNullOrEmpty(actionType))
		{
			list = list.Where((DiplomaticReason r) => r.ActionType == actionType).ToList();
		}
		return list;
	}

	public DiplomaticReason GetDiplomaticReason(Kingdom sourceKingdom, Kingdom targetKingdom, string actionType)
	{
		if (sourceKingdom == null || targetKingdom == null || string.IsNullOrEmpty(actionType))
		{
			return null;
		}
		KingdomWarStats kingdomStats = GetKingdomStats(sourceKingdom);
		if (kingdomStats?.DiplomaticReasons == null)
		{
			return null;
		}
		string key = actionType + "_" + ((MBObjectBase)targetKingdom).StringId;
		return kingdomStats.DiplomaticReasons.ContainsKey(key) ? kingdomStats.DiplomaticReasons[key] : null;
	}

	public string GetWarStatsHistory(Kingdom kingdom)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return "No war statistics history available";
		}
		KingdomWarStats kingdomStats = GetKingdomStats(kingdom);
		if (kingdomStats == null || kingdomStats.StatsHistory == null || !kingdomStats.StatsHistory.Any())
		{
			return "No war statistics history available";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("War statistics over last 10 days (2-day periods):");
		CampaignTime now = CampaignTime.Now;
		List<string> list = new List<string>();
		for (int i = 0; i < 5; i++)
		{
			float periodStartDays = i * 2;
			float periodEndDays = (i + 1) * 2;
			List<WarStatsSnapshot> source = (from s in kingdomStats.StatsHistory.Where(delegate(WarStatsSnapshot s)
				{
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					//IL_000d: Unknown result type (might be due to invalid IL or missing references)
					//IL_0012: Unknown result type (might be due to invalid IL or missing references)
					//IL_0017: Unknown result type (might be due to invalid IL or missing references)
					CampaignTime val2 = now - s.Timestamp;
					float num2 = (float)(val2).ToDays;
					return num2 >= periodStartDays && num2 < periodEndDays;
				})
				orderby s.Timestamp
				select s).ToList();
			if (source.Any())
			{
				WarStatsSnapshot warStatsSnapshot = source.Last();
				CampaignTime val = now - warStatsSnapshot.Timestamp;
				float num = (float)(val).ToDays;
				list.Add($"  - {num:F0} days ago: Troops: {warStatsSnapshot.Troops}, Casualties: {warStatsSnapshot.Casualties}, Lords Captured: {warStatsSnapshot.LordsCaptured}, Lords Killed: {warStatsSnapshot.LordsKilled}, Settlements Lost: {warStatsSnapshot.SettlementsLost}, Caravans Lost: {warStatsSnapshot.CaravansDestroyed}");
			}
		}
		if (!list.Any())
		{
			list.Add($"  - Current: Troops: {kingdomStats.CurrentTroops}, Casualties: {kingdomStats.TotalCasualties}, Lords Captured: {kingdomStats.TotalLordsCaptured}, Lords Killed: {kingdomStats.TotalLordsKilled}, Settlements Lost: {kingdomStats.TotalSettlementsLost}, Caravans Lost: {kingdomStats.TotalCaravansDestroyed}");
		}
		list.Reverse();
		foreach (string item in list)
		{
			stringBuilder.AppendLine(item);
		}
		return stringBuilder.ToString();
	}

	public string GetWarStatsChangeSummary(Kingdom kingdom)
	{
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return "No data";
		}
		KingdomWarStats kingdomStats = GetKingdomStats(kingdom);
		if (kingdomStats == null || kingdomStats.StatsHistory == null || kingdomStats.StatsHistory.Count < 2)
		{
			return "Insufficient history data";
		}
		WarStatsSnapshot warStatsSnapshot = kingdomStats.StatsHistory.OrderBy((WarStatsSnapshot s) => s.Timestamp).First();
		WarStatsSnapshot warStatsSnapshot2 = kingdomStats.StatsHistory.OrderBy((WarStatsSnapshot s) => s.Timestamp).Last();
		int num = warStatsSnapshot2.Troops - warStatsSnapshot.Troops;
		int num2 = warStatsSnapshot2.Casualties - warStatsSnapshot.Casualties;
		int num3 = warStatsSnapshot2.LordsCaptured - warStatsSnapshot.LordsCaptured;
		int num4 = warStatsSnapshot2.LordsKilled - warStatsSnapshot.LordsKilled;
		int num5 = warStatsSnapshot2.SettlementsLost - warStatsSnapshot.SettlementsLost;
		int num6 = warStatsSnapshot2.CaravansDestroyed - warStatsSnapshot.CaravansDestroyed;
		CampaignTime val = warStatsSnapshot2.Timestamp - warStatsSnapshot.Timestamp;
		float num7 = (float)(val).ToDays;
		int num8 = warStatsSnapshot2.Troops + num2 - warStatsSnapshot.Troops;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string.Format("Changes over {0:F0} days: Troops {1}{2}, ", num7, (num >= 0) ? "+" : "", num));
		stringBuilder.Append($"Casualties +{num2}, ");
		stringBuilder.Append($"Lords Captured +{num3}, ");
		stringBuilder.Append($"Lords Killed +{num4}, ");
		stringBuilder.Append($"Settlements Lost +{num5}, ");
		stringBuilder.Append($"Caravans Lost +{num6}");
		if (num2 > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("WAR IMPACT ANALYSIS:");
			stringBuilder.AppendLine($"  - Started period with: {warStatsSnapshot.Troops:N0} troops");
			stringBuilder.AppendLine($"  - Current troops: {warStatsSnapshot2.Troops:N0}");
			stringBuilder.AppendLine($"  - Total casualties: {num2:N0}");
			stringBuilder.AppendLine($"  - Recruited during period: ~{num8:N0} troops (estimated)");
			stringBuilder.Append(string.Format("  - Net army change: {0:N0} ({1}{2:F1}% from period start)", num, (num >= 0) ? "+" : "", (double)num * 100.0 / (double)Math.Max(1, warStatsSnapshot.Troops)));
			if (num < 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.Append($"  - War is DRAINING manpower: Lost {Math.Abs(num):N0} net troops despite recruiting {num8:N0}");
			}
			else if ((double)num8 > (double)num2 * 0.8)
			{
				stringBuilder.AppendLine();
				stringBuilder.Append($"  - Kingdom is sustaining the war through recruitment: Recruited {num8:N0} vs {num2:N0} casualties");
			}
		}
		return stringBuilder.ToString();
	}

	public string GetEnemyWarStatsHistory(Kingdom kingdom)
	{
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return "No enemy statistics available";
		}
		StringBuilder stringBuilder = new StringBuilder();
		List<Kingdom> list = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)k)).ToList();
		if (!list.Any())
		{
			return "No active enemies to report statistics for";
		}
		stringBuilder.AppendLine("### ENEMY WAR STATISTICS ###");
		stringBuilder.AppendLine("Current state of kingdoms you are at war with:");
		stringBuilder.AppendLine();
		foreach (Kingdom item in list)
		{
			KingdomWarStats kingdomStats = GetKingdomStats(item);
			if (kingdomStats == null)
			{
				continue;
			}
			stringBuilder.AppendLine($"{item.Name} ({((MBObjectBase)item).StringId}):");
			stringBuilder.AppendLine($"  - Current Troops: {kingdomStats.CurrentTroops}");
			stringBuilder.AppendLine($"  - Casualties: {kingdomStats.TotalCasualties}");
			stringBuilder.AppendLine($"  - War Fatigue: {kingdomStats.WarFatigue:F1}%");
			stringBuilder.AppendLine($"  - Settlements Lost: {kingdomStats.TotalSettlementsLost}");
			stringBuilder.AppendLine($"  - Lords Captured: {kingdomStats.TotalLordsCaptured}");
			stringBuilder.AppendLine($"  - Lords Killed: {kingdomStats.TotalLordsKilled}");
			if (kingdomStats.StatsHistory != null && kingdomStats.StatsHistory.Count >= 2)
			{
				WarStatsSnapshot warStatsSnapshot = kingdomStats.StatsHistory.OrderBy((WarStatsSnapshot s) => s.Timestamp).First();
				WarStatsSnapshot warStatsSnapshot2 = kingdomStats.StatsHistory.OrderBy((WarStatsSnapshot s) => s.Timestamp).Last();
				int num = warStatsSnapshot2.Troops - warStatsSnapshot.Troops;
				CampaignTime val = warStatsSnapshot2.Timestamp - warStatsSnapshot.Timestamp;
				float num2 = (float)(val).ToDays;
				string text = ((num >= 0) ? "growing" : "declining");
				stringBuilder.AppendLine(string.Format("  - Trend over {0:F0} days: Troops {1}{2} ({3})", num2, (num >= 0) ? "+" : "", num, text));
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	public string GetSettlementChangesDetails(Kingdom kingdom, int maxDays = 90)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		SettlementOwnershipTracker instance = SettlementOwnershipTracker.Instance;
		if (instance == null)
		{
			return "";
		}
		List<Kingdom> source = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)k)).ToList();
		if (!source.Any())
		{
			return "";
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		CampaignTime val = CampaignTime.Now;
		float num = (float)(val).ToDays;
		float cutoffDays = num - (float)maxDays;
		foreach (Settlement item in ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown || s.IsCastle))
		{
			SettlementOwnershipHistory ownershipHistory = instance.GetOwnershipHistory(((MBObjectBase)item).StringId);
			if (ownershipHistory == null || !ownershipHistory.OwnershipChanges.Any())
			{
				continue;
			}
			List<OwnershipChange> list5 = (from c in ownershipHistory.OwnershipChanges.Where(delegate(OwnershipChange c)
				{
					//IL_0001: Unknown result type (might be due to invalid IL or missing references)
					//IL_0006: Unknown result type (might be due to invalid IL or missing references)
					CampaignTime changeDate = c.ChangeDate;
					return (float)(changeDate).ToDays >= cutoffDays;
				})
				orderby c.ChangeDate
				select c).ToList();
			if (!list5.Any())
			{
				continue;
			}
			foreach (OwnershipChange change in list5)
			{
				bool flag = change.FromKingdomId == ((MBObjectBase)kingdom).StringId || change.ToKingdomId == ((MBObjectBase)kingdom).StringId;
				bool flag2 = source.Any((Kingdom e) => ((MBObjectBase)e).StringId == change.FromKingdomId || ((MBObjectBase)e).StringId == change.ToKingdomId);
				if (!flag || !flag2)
				{
					continue;
				}
				val = change.ChangeDate;
				float num2 = num - (float)(val).ToDays;
				string text = (item.IsTown ? "town" : "castle");
				string text2 = ((change.ChangeReason == "conquest") ? "conquered" : ((change.ChangeReason == "diplomacy") ? "transferred" : ((change.ChangeReason == "rebellion") ? "rebelled" : "changed hands")));
				if (change.FromKingdomId == ((MBObjectBase)kingdom).StringId)
				{
					Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == change.ToKingdomId));
					string text3 = ((val2 == null) ? null : ((object)val2.Name)?.ToString()) ?? change.ToKingdomName;
					string captureDetails = GetCaptureDetails(item, change, num2);
					if (list5.Where((OwnershipChange c) => c.ChangeDate > change.ChangeDate && c.ToKingdomId == ((MBObjectBase)kingdom).StringId).Any())
					{
						list3.Add($"{item.Name} ({text}, string_id:{((MBObjectBase)item).StringId}) - lost to {text3} ({num2:F0} days ago){captureDetails} but RECAPTURED");
					}
					else
					{
						list.Add($"{item.Name} ({text}, string_id:{((MBObjectBase)item).StringId}) - lost to {text3} ({num2:F0} days ago, {text2}){captureDetails}");
					}
				}
				else if (change.ToKingdomId == ((MBObjectBase)kingdom).StringId)
				{
					Kingdom val3 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == change.FromKingdomId));
					string text4 = ((val3 == null) ? null : ((object)val3.Name)?.ToString()) ?? change.FromKingdomName;
					string captureDetails2 = GetCaptureDetails(item, change, num2);
					if (list5.Where((OwnershipChange c) => c.ChangeDate > change.ChangeDate && c.FromKingdomId == ((MBObjectBase)kingdom).StringId).Any())
					{
						list4.Add($"{item.Name} ({text}, string_id:{((MBObjectBase)item).StringId}) - captured from {text4} ({num2:F0} days ago){captureDetails2} but ENEMY RECAPTURED");
					}
					else
					{
						list2.Add($"{item.Name} ({text}, string_id:{((MBObjectBase)item).StringId}) - captured from {text4} ({num2:F0} days ago, {text2}){captureDetails2}");
					}
				}
			}
		}
		if (list.Any() || list2.Any() || list3.Any() || list4.Any())
		{
			stringBuilder.AppendLine("### SETTLEMENT CHANGES DURING CURRENT WARS ###");
			stringBuilder.AppendLine($"Territorial changes in the last {maxDays} days:");
			stringBuilder.AppendLine();
			if (list.Any())
			{
				stringBuilder.AppendLine($"**Settlements LOST to enemies ({list.Count}):**");
				foreach (string item2 in list.OrderByDescending(delegate(string l)
				{
					Match match = Regex.Match(l, "\\((\\d+\\.?\\d*) days ago");
					return match.Success ? float.Parse(match.Groups[1].Value) : 0f;
				}))
				{
					stringBuilder.AppendLine("  - " + item2);
				}
				stringBuilder.AppendLine();
			}
			if (list2.Any())
			{
				stringBuilder.AppendLine($"**Settlements CAPTURED from enemies ({list2.Count}):**");
				foreach (string item3 in list2.OrderByDescending(delegate(string c)
				{
					Match match = Regex.Match(c, "\\((\\d+\\.?\\d*) days ago");
					return match.Success ? float.Parse(match.Groups[1].Value) : 0f;
				}))
				{
					stringBuilder.AppendLine("  - " + item3);
				}
				stringBuilder.AppendLine();
			}
			if (list3.Any())
			{
				stringBuilder.AppendLine($"**Settlements RECAPTURED after being lost ({list3.Count}):**");
				foreach (string item4 in list3)
				{
					stringBuilder.AppendLine("  - " + item4);
				}
				stringBuilder.AppendLine();
			}
			if (list4.Any())
			{
				stringBuilder.AppendLine($"**Settlements LOST after being captured ({list4.Count}):**");
				foreach (string item5 in list4)
				{
					stringBuilder.AppendLine("  - " + item5);
				}
				stringBuilder.AppendLine();
			}
		}
		return stringBuilder.ToString();
	}

	private string GetCaptureDetails(Settlement settlement, OwnershipChange change, float daysAgo)
	{
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		if (change == null || string.IsNullOrEmpty(change.CapturerHeroId))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == change.CapturerHeroId));
		if (val == null)
		{
			return "";
		}
		bool flag = val == Hero.MainHero;
		bool flag2 = false;
		MobileParty partyBelongedTo = val.PartyBelongedTo;
		Army val2 = ((partyBelongedTo != null) ? partyBelongedTo.Army : null);
		List<string> list = new List<string>();
		string text = null;
		if (val2 != null && val2.LeaderParty != null)
		{
			Hero leaderHero = val2.LeaderParty.LeaderHero;
			text = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString()) ?? "Unknown";
			Hero mainHero = Hero.MainHero;
			MobileParty val3 = ((mainHero != null) ? mainHero.PartyBelongedTo : null);
			MobileParty val4 = val3;
			if (((val4 != null) ? val4.Army : null) == val2)
			{
				flag2 = true;
			}
			HashSet<(string, string, string)> hashSet = new HashSet<(string, string, string)>();
			foreach (MobileParty item7 in (List<MobileParty>)(object)val2.Parties)
			{
				if (((item7 != null) ? item7.LeaderHero : null) != null)
				{
					string item = ((object)item7.LeaderHero.Name)?.ToString() ?? "Unknown";
					Clan clan = item7.LeaderHero.Clan;
					string item2 = ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "Unknown";
					Clan clan2 = item7.LeaderHero.Clan;
					string item3 = ((clan2 != null) ? ((MBObjectBase)clan2).StringId : null) ?? "";
					hashSet.Add((item, item2, item3));
					if (item7.LeaderHero == Hero.MainHero)
					{
						flag2 = true;
					}
				}
				foreach (TroopRosterElement item8 in (List<TroopRosterElement>)(object)item7.MemberRoster.GetTroopRoster())
				{
					CharacterObject character = item8.Character;
					if (character != null && ((BasicCharacterObject)character).IsHero && item8.Character.HeroObject != null)
					{
						Hero heroObject = item8.Character.HeroObject;
						if (heroObject == Hero.MainHero)
						{
							flag2 = true;
						}
						string item4 = ((object)heroObject.Name)?.ToString() ?? "Unknown";
						Clan clan3 = heroObject.Clan;
						string item5 = ((clan3 == null) ? null : ((object)clan3.Name)?.ToString()) ?? "Unknown";
						Clan clan4 = heroObject.Clan;
						string item6 = ((clan4 != null) ? ((MBObjectBase)clan4).StringId : null) ?? "";
						hashSet.Add((item4, item5, item6));
					}
				}
			}
			foreach (var item9 in from l in hashSet
				orderby l.Item1, l.Name
				select l)
			{
				if (item9.Item2 != "Unknown" && !string.IsNullOrEmpty(item9.Item3))
				{
					list.Add(item9.Item1 + " (" + item9.Item2 + ", string_id:" + item9.Item3 + ")");
				}
				else
				{
					list.Add(item9.Item1);
				}
			}
		}
		else if (partyBelongedTo != null)
		{
			Hero leaderHero2 = partyBelongedTo.LeaderHero;
			string text2 = ((leaderHero2 == null) ? null : ((object)leaderHero2.Name)?.ToString()) ?? "Unknown";
			if (val == Hero.MainHero || partyBelongedTo.LeaderHero == Hero.MainHero)
			{
				flag2 = true;
			}
			foreach (TroopRosterElement item10 in (List<TroopRosterElement>)(object)partyBelongedTo.MemberRoster.GetTroopRoster())
			{
				CharacterObject character2 = item10.Character;
				if (character2 != null && ((BasicCharacterObject)character2).IsHero && item10.Character.HeroObject != null)
				{
					Hero heroObject2 = item10.Character.HeroObject;
					if (heroObject2 == Hero.MainHero)
					{
						flag2 = true;
					}
					string text3 = ((object)heroObject2.Name)?.ToString() ?? "Unknown";
					Clan clan5 = heroObject2.Clan;
					string text4 = ((clan5 == null) ? null : ((object)clan5.Name)?.ToString()) ?? "";
					if (!string.IsNullOrEmpty(text4))
					{
						list.Add(text3 + " (" + text4 + ")");
					}
					else
					{
						list.Add(text3);
					}
				}
			}
		}
		if (flag)
		{
			stringBuilder.Append(" [PLAYER captured]");
		}
		else if (flag2)
		{
			stringBuilder.Append(" [player participated]");
		}
		if (val2 != null && text != null)
		{
			stringBuilder.Append(" [Army led by " + text);
			if (list.Any())
			{
				List<string> values = list.Take(5).ToList();
				stringBuilder.Append(": " + string.Join(", ", values));
				if (list.Count > 5)
				{
					stringBuilder.Append($" (+{list.Count - 5} more)");
				}
			}
			stringBuilder.Append("]");
		}
		else if (list.Any() && list.Count > 1)
		{
			List<string> values2 = list.Take(3).ToList();
			stringBuilder.Append(" [Participants: " + string.Join(", ", values2));
			if (list.Count > 3)
			{
				stringBuilder.Append($" (+{list.Count - 3} more)");
			}
			stringBuilder.Append("]");
		}
		return stringBuilder.ToString();
	}

	public void ClearAllData()
	{
		try
		{
			KingdomStats.Clear();
			WarFatigueLogger.Instance.Log("[WAR_STATS] Cleared all war statistics data");
		}
		catch (Exception ex)
		{
			WarFatigueLogger.Instance.Log("[WAR_STATS] Error clearing data: " + ex.Message);
		}
	}

	private void LogMessage(string message)
	{
		DiplomacyLogger.Instance.Log(message);
	}
}
