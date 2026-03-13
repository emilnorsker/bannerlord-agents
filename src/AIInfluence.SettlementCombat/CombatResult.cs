using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.SettlementCombat;

public class CombatResult
{
	public Settlement Settlement { get; set; }

	public CampaignTime Duration { get; set; }

	public int TotalKilled { get; set; }

	public int TotalWounded { get; set; }

	public int CiviliansKilled { get; set; }

	public int CiviliansWounded { get; set; }

	public List<DeathRecord> Deaths { get; set; } = new List<DeathRecord>();

	public List<WoundRecord> Wounds { get; set; } = new List<WoundRecord>();

	public List<string> Participants { get; set; } = new List<string>();

	public List<string> CapturedHeroes { get; set; } = new List<string>();

	public bool SimpleDefendersArrived { get; set; }

	public int SimpleDefendersSpawned { get; set; }

	public bool MilitiaArrived { get; set; }

	public int MilitiaSpawned { get; set; }

	public bool GuardsArrived { get; set; }

	public int GuardsSpawned { get; set; }

	public List<LordArrivalInfo> LordsArrived { get; set; } = new List<LordArrivalInfo>();

	public int MilitiaKilled { get; set; }

	public int SimpleDefendersKilled { get; set; }

	public int GuardsKilled { get; set; }

	public SideCasualtySummary DefenderCasualties { get; set; } = new SideCasualtySummary();

	public SideCasualtySummary AttackerCasualties { get; set; } = new SideCasualtySummary();

	public CivilianCasualtySummary CivilianCasualties { get; set; } = new CivilianCasualtySummary();

	public List<VipCasualtyRecord> ImportantCasualties { get; set; } = new List<VipCasualtyRecord>();

	public int PlayerSummonedTroopsCount { get; set; }

	public string PlayerSummonedTroopsInfo { get; set; } = "";

	public bool PlayerEvacuated { get; set; }

	public bool PlayerCaptured { get; set; }

	public Settlement PlayerPrisonSettlement { get; set; }
}
