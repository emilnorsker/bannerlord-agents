using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.DynamicEvents;

public class BattleHistoryManager
{
	private static BattleHistoryManager _instance;

	private readonly List<BattleInfo> _recentBattles = new List<BattleInfo>();

	private readonly Dictionary<MapEvent, (int attackerInitial, int defenderInitial)> _battleInitialTroops = new Dictionary<MapEvent, (int, int)>();

	public static BattleHistoryManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new BattleHistoryManager();
			}
			return _instance;
		}
	}

	private BattleHistoryManager()
	{
		RegisterBattleEvents();
	}

	private void RegisterBattleEvents()
	{
		CampaignEvents.MapEventStarted.AddNonSerializedListener((object)this, (Action<MapEvent, PartyBase, PartyBase>)OnBattleStarted);
		CampaignEvents.MapEventEnded.AddNonSerializedListener((object)this, (Action<MapEvent>)OnBattleEnded);
	}

	private void OnBattleStarted(MapEvent mapEvent, PartyBase attackerParty, PartyBase defenderParty)
	{
		int num = 0;
		int num2 = 0;
		foreach (MapEventParty item in (List<MapEventParty>)(object)mapEvent.PartiesOnSide((BattleSideEnum)1))
		{
			num += item.Party.MemberRoster.TotalManCount;
		}
		foreach (MapEventParty item2 in (List<MapEventParty>)(object)mapEvent.PartiesOnSide((BattleSideEnum)0))
		{
			num2 += item2.Party.MemberRoster.TotalManCount;
		}
		_battleInitialTroops[mapEvent] = (num, num2);
	}

	private void OnBattleEnded(MapEvent mapEvent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Invalid comparison between Unknown and I4
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Invalid comparison between Unknown and I4
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Invalid comparison between Unknown and I4
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Invalid comparison between Unknown and I4
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Invalid comparison between Unknown and I4
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Invalid comparison between Unknown and I4
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Invalid comparison between Unknown and I4
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Invalid comparison between Unknown and I4
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		BattleSideEnum winningSide = mapEvent.WinningSide;
		if ((int)winningSide == -1 || !_battleInitialTroops.TryGetValue(mapEvent, out (int, int) value))
		{
			return;
		}
		var (num, num2) = value;
		if (num + num2 < DynamicEventsGenerator.LARGE_BATTLE_TROOPS_THRESHOLD)
		{
			_battleInitialTroops.Remove(mapEvent);
			return;
		}
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		foreach (MapEventParty item2 in (List<MapEventParty>)(object)mapEvent.PartiesOnSide((BattleSideEnum)1))
		{
			num3 += item2.Party.MemberRoster.TotalHealthyCount;
			num4 += item2.Party.MemberRoster.TotalWoundedRegulars;
		}
		foreach (MapEventParty item3 in (List<MapEventParty>)(object)mapEvent.PartiesOnSide((BattleSideEnum)0))
		{
			num5 += item3.Party.MemberRoster.TotalHealthyCount;
			num6 += item3.Party.MemberRoster.TotalWoundedRegulars;
		}
		int attackerLosses = num - (num3 + num4);
		int defenderLosses = num2 - (num5 + num6);
		string battleType = "Field battle";
		Settlement val = null;
		if ((int)mapEvent.EventType == 5)
		{
			battleType = "Siege";
			MapEventParty? obj = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)1)).FirstOrDefault();
			object obj2;
			if (obj == null)
			{
				obj2 = null;
			}
			else
			{
				PartyBase party = obj.Party;
				obj2 = ((party != null) ? party.MobileParty : null);
			}
			MobileParty val2 = (MobileParty)obj2;
			if (((val2 == null) ? null : val2.SiegeEvent?.BesiegedSettlement) != null)
			{
				val = val2.SiegeEvent.BesiegedSettlement;
			}
			else
			{
				MapEventParty val3 = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)0)).FirstOrDefault();
				object obj3;
				if (val3 == null)
				{
					obj3 = null;
				}
				else
				{
					PartyBase party2 = val3.Party;
					obj3 = ((party2 != null) ? party2.Settlement : null);
				}
				if (obj3 != null)
				{
					val = val3.Party.Settlement;
				}
			}
		}
		else
		{
			MapEventParty? obj4 = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)1)).FirstOrDefault();
			PartyBase val4 = ((obj4 != null) ? obj4.Party : null);
			if (((val4 != null) ? val4.MobileParty : null) != null)
			{
				(val, _) = GetNearestSettlementInfo(val4.MobileParty);
			}
			if (Campaign.Current != null && Campaign.Current.MapSceneWrapper != null)
			{
				IMapScene mapSceneWrapper = Campaign.Current.MapSceneWrapper;
				CampaignVec2 position = mapEvent.Position;
				TerrainType terrainTypeAtPosition = mapSceneWrapper.GetTerrainTypeAtPosition(ref position);
				if ((int)terrainTypeAtPosition == 10 || (int)terrainTypeAtPosition == 8 || (int)terrainTypeAtPosition == 19 || (int)terrainTypeAtPosition == 18 || (int)terrainTypeAtPosition == 11)
				{
					battleType = "Naval battle";
				}
			}
		}
		BattleSideEnum val5 = (BattleSideEnum)((int)winningSide != 1);
		MapEventParty val6 = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide(winningSide)).FirstOrDefault();
		PartyBase val7 = ((val6 != null) ? val6.Party : null);
		Hero val8 = ((val7 != null) ? val7.LeaderHero : null);
		MapEventParty val9 = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide(val5)).FirstOrDefault();
		PartyBase val10 = ((val9 != null) ? val9.Party : null);
		Hero val11 = ((val10 != null) ? val10.LeaderHero : null);
		string battleSideInfo = GetBattleSideInfo((BattleSideEnum)1, mapEvent);
		string battleSideInfo2 = GetBattleSideInfo((BattleSideEnum)0, mapEvent);
		string winner = (((int)winningSide == 1) ? battleSideInfo : battleSideInfo2);
		MapEventParty val12 = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)1)).FirstOrDefault();
		object obj5;
		if (val12 == null)
		{
			obj5 = null;
		}
		else
		{
			PartyBase party3 = val12.Party;
			obj5 = ((party3 != null) ? party3.LeaderHero : null);
		}
		Hero val13 = (Hero)obj5;
		MapEventParty val14 = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)0)).FirstOrDefault();
		object obj6;
		if (val14 == null)
		{
			obj6 = null;
		}
		else
		{
			PartyBase party4 = val14.Party;
			obj6 = ((party4 != null) ? party4.LeaderHero : null);
		}
		Hero val15 = (Hero)obj6;
		BattleInfo item = new BattleInfo
		{
			AttackerKingdom = battleSideInfo,
			DefenderKingdom = battleSideInfo2,
			BattleType = battleType,
			Winner = winner,
			AttackerLeader = (((val13 == null) ? null : ((object)val13.Name)?.ToString()) ?? "Unknown"),
			DefenderLeader = (((val15 == null) ? null : ((object)val15.Name)?.ToString()) ?? "Unknown"),
			Location = (((val == null) ? null : ((object)val.Name)?.ToString()) ?? "Unknown location"),
			DaysAgo = 0,
			AttackerTroops = num,
			DefenderTroops = num2,
			AttackerLosses = attackerLosses,
			DefenderLosses = defenderLosses,
			BattleTime = CampaignTime.Now
		};
		_recentBattles.Add(item);
		_recentBattles.RemoveAll(delegate(BattleInfo b)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime val16 = CampaignTime.Now - b.BattleTime;
			return ((CampaignTime)(ref val16)).ToDays > 30.0;
		});
		_battleInitialTroops.Remove(mapEvent);
	}

	private string GetBattleSideInfo(BattleSideEnum side, MapEvent mapEvent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Invalid comparison between Unknown and I4
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Invalid comparison between Unknown and I4
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		MBReadOnlyList<MapEventParty> val = mapEvent.PartiesOnSide(side);
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		foreach (MapEventParty item in (List<MapEventParty>)(object)val)
		{
			Hero leaderHero = item.Party.LeaderHero;
			object obj;
			if (leaderHero == null)
			{
				obj = null;
			}
			else
			{
				Clan clan = leaderHero.Clan;
				obj = ((clan != null) ? clan.Kingdom : null);
			}
			if (obj != null)
			{
				hashSet.Add(((object)leaderHero.Clan.Kingdom.Name).ToString());
			}
			else if (((leaderHero != null) ? leaderHero.Clan : null) != null)
			{
				hashSet2.Add(((object)leaderHero.Clan.Name).ToString());
			}
		}
		List<string> list = new List<string>();
		list.AddRange(hashSet);
		list.AddRange(hashSet2);
		if (list.Count == 0)
		{
			if ((int)mapEvent.EventType == 5 && mapEvent.MapEventSettlement != null)
			{
				Settlement mapEventSettlement = mapEvent.MapEventSettlement;
				if ((int)side == 0)
				{
					IFaction mapFaction = mapEventSettlement.MapFaction;
					if (mapFaction != null && mapFaction.IsKingdomFaction)
					{
						return $"{mapEventSettlement.MapFaction.Name} defenders";
					}
					Hero owner = mapEventSettlement.Owner;
					object obj2;
					if (owner == null)
					{
						obj2 = null;
					}
					else
					{
						Clan clan2 = owner.Clan;
						obj2 = ((clan2 != null) ? clan2.Kingdom : null);
					}
					if (obj2 != null)
					{
						return $"{mapEventSettlement.Owner.Clan.Kingdom.Name} defenders";
					}
					Hero owner2 = mapEventSettlement.Owner;
					if (((owner2 != null) ? owner2.Clan : null) != null)
					{
						return $"{mapEventSettlement.Owner.Clan.Name} defenders";
					}
				}
				else if ((int)side == 1)
				{
					MapEventParty val2 = ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)1)).FirstOrDefault();
					object obj3;
					if (val2 == null)
					{
						obj3 = null;
					}
					else
					{
						PartyBase party = val2.Party;
						obj3 = ((party != null) ? party.LeaderHero : null);
					}
					if (obj3 != null)
					{
						Hero leaderHero2 = val2.Party.LeaderHero;
						Clan clan3 = leaderHero2.Clan;
						if (((clan3 != null) ? clan3.Kingdom : null) != null)
						{
							return $"{leaderHero2.Clan.Kingdom.Name} attackers";
						}
						if (leaderHero2.Clan != null)
						{
							return $"{leaderHero2.Clan.Name} attackers";
						}
					}
				}
			}
			foreach (MapEventParty item2 in (List<MapEventParty>)(object)val)
			{
				PartyBase party2 = item2.Party;
				if (party2 != null)
				{
					IFaction mapFaction2 = party2.MapFaction;
					if (((mapFaction2 != null) ? new bool?(mapFaction2.IsKingdomFaction) : ((bool?)null)) == true)
					{
						hashSet.Add(((object)item2.Party.MapFaction.Name).ToString());
						continue;
					}
				}
				PartyBase party3 = item2.Party;
				if (((party3 != null) ? party3.MapFaction : null) != null && !item2.Party.MapFaction.IsBanditFaction)
				{
					hashSet2.Add(((object)item2.Party.MapFaction.Name).ToString());
				}
			}
			list.Clear();
			list.AddRange(hashSet);
			list.AddRange(hashSet2);
			if (list.Count > 0)
			{
				return (list.Count == 1) ? list[0] : string.Join(" and ", list);
			}
			foreach (MapEventParty item3 in (List<MapEventParty>)(object)val)
			{
				PartyBase party4 = item3.Party;
				if (party4 != null)
				{
					MobileParty mobileParty = party4.MobileParty;
					if (((mobileParty != null) ? new bool?(mobileParty.IsBandit) : ((bool?)null)) == true)
					{
						return "bandits";
					}
				}
				PartyBase party5 = item3.Party;
				if (party5 != null)
				{
					MobileParty mobileParty2 = party5.MobileParty;
					if (((mobileParty2 != null) ? new bool?(mobileParty2.IsVillager) : ((bool?)null)) == true)
					{
						return "villagers";
					}
				}
				PartyBase party6 = item3.Party;
				if (party6 != null)
				{
					MobileParty mobileParty3 = party6.MobileParty;
					if (((mobileParty3 != null) ? new bool?(mobileParty3.IsCaravan) : ((bool?)null)) == true)
					{
						return "caravan";
					}
				}
			}
			AIInfluenceBehavior.Instance?.LogMessage($"[WARNING] GetBattleSideInfo (DynamicEvents): Could not determine faction for {side}. Party count: {((IEnumerable<MapEventParty>)val).Count()}");
			return (((IEnumerable<MapEventParty>)val).Count() > 1) ? "unknown coalition" : "unknown forces";
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		return string.Join(" and ", list);
	}

	private (Settlement Settlement, float Distance) GetNearestSettlementInfo(MobileParty party)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		Settlement item = null;
		float num = float.MaxValue;
		foreach (Settlement item2 in (List<Settlement>)(object)Settlement.All)
		{
			Vec2 position2D = party.GetPosition2D();
			float num2 = ((Vec2)(ref position2D)).Distance(item2.GetPosition2D());
			if (num2 < num)
			{
				num = num2;
				item = item2;
			}
		}
		return (Settlement: item, Distance: num);
	}

	public List<BattleInfo> GetRecentLargeBattles()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		foreach (BattleInfo recentBattle in _recentBattles)
		{
			CampaignTime val = CampaignTime.Now - recentBattle.BattleTime;
			recentBattle.DaysAgo = (int)((CampaignTime)(ref val)).ToDays;
		}
		return _recentBattles.ToList();
	}

	private string GetDiscoveryPotential(Settlement settlement)
	{
		List<string> list = new List<string>();
		if (settlement.IsCastle)
		{
			list.Add("ancient fortress");
		}
		CultureObject culture = settlement.Culture;
		string text = ((culture != null) ? ((MBObjectBase)culture).StringId : null) ?? "";
		if (text.Contains("empire"))
		{
			list.Add("imperial ruins");
		}
		else if (text.Contains("vlandia"))
		{
			list.Add("old kingdom artifacts");
		}
		else if (text.Contains("sturgia"))
		{
			list.Add("northern mysteries");
		}
		if (SettlementCaptureManager.Instance.IsRecentlyCaptured(((MBObjectBase)settlement).StringId, 60))
		{
			list.Add("recently disturbed");
		}
		return list.Any() ? string.Join(", ", list) : "moderate archaeological potential";
	}

	private bool IsDiseaseVulnerable(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return false;
		}
		bool flag = settlement.Town.Prosperity < (float)DynamicEventsGenerator.PROSPERITY_MEDIUM_THRESHOLD;
		bool flag2 = ((Fief)settlement.Town).FoodStocks < (float)DynamicEventsGenerator.FOOD_STOCKS_LOW_THRESHOLD;
		bool flag3 = settlement.Town.Security < (float)DynamicEventsGenerator.TOWN_SECURITY_LOW_THRESHOLD;
		bool isUnderSiege = settlement.IsUnderSiege;
		return flag || flag2 || flag3 || isUnderSiege;
	}

	private string GetVulnerabilityLevel(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return "unknown";
		}
		int num = 0;
		if (settlement.Town.Prosperity < 2000f)
		{
			num++;
		}
		if (((Fief)settlement.Town).FoodStocks < 100f)
		{
			num++;
		}
		if (settlement.Town.Security < 30f)
		{
			num++;
		}
		if (settlement.IsUnderSiege)
		{
			num++;
		}
		return num switch
		{
			1 => "low vulnerability", 
			2 => "moderate vulnerability", 
			3 => "high vulnerability", 
			4 => "extreme vulnerability", 
			_ => "unknown vulnerability", 
		};
	}

	private string GetRiskFactors(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return "none";
		}
		List<string> list = new List<string>();
		if (settlement.Town.Prosperity < 2000f)
		{
			list.Add("poverty");
		}
		if (((Fief)settlement.Town).FoodStocks < 100f)
		{
			list.Add("food shortage");
		}
		if (settlement.Town.Security < 30f)
		{
			list.Add("poor sanitation");
		}
		if (settlement.IsUnderSiege)
		{
			list.Add("siege conditions");
		}
		return list.Any() ? string.Join(", ", list) : "none";
	}

	private bool HasStrangeOccurrencePotential(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return false;
		}
		bool flag = settlement.Town.Loyalty < (float)DynamicEventsGenerator.TOWN_LOYALTY_LOW_THRESHOLD;
		bool flag2 = settlement.Town.Security < (float)DynamicEventsGenerator.TOWN_SECURITY_LOW_THRESHOLD;
		bool isUnderSiege = settlement.IsUnderSiege;
		bool flag3 = SettlementCaptureManager.Instance.IsRecentlyCaptured(((MBObjectBase)settlement).StringId);
		return flag || flag2 || isUnderSiege || flag3;
	}

	private string GetStrangePotential(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return "unknown";
		}
		int num = 0;
		if (settlement.Town.Loyalty < 30f)
		{
			num++;
		}
		if (settlement.Town.Security < 30f)
		{
			num++;
		}
		if (settlement.IsUnderSiege)
		{
			num++;
		}
		if (SettlementCaptureManager.Instance.IsRecentlyCaptured(((MBObjectBase)settlement).StringId))
		{
			num++;
		}
		return num switch
		{
			1 => "low strange potential", 
			2 => "moderate strange potential", 
			3 => "high strange potential", 
			4 => "extreme strange potential", 
			_ => "unknown strange potential", 
		};
	}

	private string GetContributingFactors(Settlement settlement)
	{
		if (settlement.Town == null)
		{
			return "none";
		}
		List<string> list = new List<string>();
		if (settlement.Town.Loyalty < 30f)
		{
			list.Add("discontent population");
		}
		if (settlement.Town.Security < 30f)
		{
			list.Add("lawlessness");
		}
		if (settlement.IsUnderSiege)
		{
			list.Add("siege stress");
		}
		if (SettlementCaptureManager.Instance.IsRecentlyCaptured(((MBObjectBase)settlement).StringId))
		{
			list.Add("recent instability");
		}
		return list.Any() ? string.Join(", ", list) : "none";
	}
}
