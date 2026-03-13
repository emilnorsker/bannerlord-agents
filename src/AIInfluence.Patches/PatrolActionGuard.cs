using AIInfluence.Behaviors.AIActions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Patches;

internal static class PatrolActionGuard
{
	public static bool ShouldBlockSettlementOrder(MobileParty owner, Settlement settlement)
	{
		Hero hero = ((owner != null) ? owner.LeaderHero : null);
		if (!IsPatrolActionActive(hero))
		{
			return false;
		}
		if (!PatrolSettlementAction.TryGetActivePatrolTargetId(hero, out var settlementId) || string.IsNullOrWhiteSpace(settlementId))
		{
			return false;
		}
		if (settlement != null && ((MBObjectBase)settlement).StringId == settlementId)
		{
			return false;
		}
		LogBlock(hero, owner, settlement, settlementId, isPoint: false);
		return true;
	}

	public static bool ShouldBlockPointOrder(MobileParty owner)
	{
		Hero hero = ((owner != null) ? owner.LeaderHero : null);
		if (!IsPatrolActionActive(hero))
		{
			return false;
		}
		LogBlock(hero, owner, null, null, isPoint: true);
		return true;
	}

	private static bool IsPatrolActionActive(Hero hero)
	{
		if (hero == null)
		{
			return false;
		}
		return AIActionManager.Instance?.IsActionActive(hero, "patrol_settlement") ?? false;
	}

	private static void LogBlock(Hero hero, MobileParty owner, Settlement newSettlement, string activeTargetId, bool isPoint)
	{
		string text = ((hero == null) ? null : ((object)hero.Name)?.ToString()) ?? ((owner == null) ? null : ((object)owner.Name)?.ToString()) ?? "unknown";
		string text2 = ((owner == null) ? null : ((object)owner.Name)?.ToString()) ?? text;
		string text3 = ((newSettlement == null) ? null : ((object)newSettlement.Name)?.ToString()) ?? (isPoint ? "custom point" : "unknown");
		string message = (isPoint ? ("[patrol_settlement] Blocking vanilla patrol point order for " + text2 + " (" + text + ") while AI action is active.") : ("[patrol_settlement] Blocking vanilla patrol order for " + text2 + " (" + text + ") to " + text3 + ". Active target id: " + activeTargetId + "."));
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
