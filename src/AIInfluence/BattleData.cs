using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AIInfluence;

public class BattleData
{
	public BattleTypes BattleType { get; set; }

	public Vec2 Position { get; set; }

	public Settlement BattleSettlement { get; set; }

	public BattleSideEnum WinningSide { get; set; }

	public Hero WinnerHero { get; set; }

	public Hero LoserHero { get; set; }

	public string WinningSideInfo { get; set; }

	public string LosingSideInfo { get; set; }

	public string WinnerStats { get; set; }

	public string LoserStats { get; set; }

	public HashSet<string> AttackerHeroIds { get; set; }

	public HashSet<string> DefenderHeroIds { get; set; }

	public bool IsPlayerInvolved { get; set; }

	public string PlayerInvolvementTag { get; set; }
}
