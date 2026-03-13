using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace AIInfluence.SettlementCombat;

public class ActiveCombat
{
	public Settlement Settlement { get; set; }

	public Hero TriggerNPC { get; set; }

	public NPCContext TriggerContext { get; set; }

	public CombatTriggerType TriggerType { get; set; }

	public string TriggerResponse { get; set; }

	public CampaignTime StartTime { get; set; }

	public CombatSituationAnalysis Analysis { get; set; }

	public LocationType LocationType { get; set; }

	public int DefendersSpawnedInSmallLocation { get; set; }

	public List<string> NPCsFromSmallLocation { get; set; }

	public Vec3 PlayerEntryPosition { get; set; }

	public bool VillageLooted { get; set; }

	public bool VillageBurned { get; set; }

	public List<Hero> PlayerCompanions { get; set; }

	public Dictionary<string, CompanionCombatDecision> CompanionDecisions { get; set; }

	public ActiveCombat()
	{
		PlayerCompanions = new List<Hero>();
		CompanionDecisions = new Dictionary<string, CompanionCombatDecision>();
	}
}
