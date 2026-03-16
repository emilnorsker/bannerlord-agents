using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultPrisonBreakModel : PrisonBreakModel
{
	private const int BasePrisonBreakCost = 1000;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetNumberOfGuardsToSpawn(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanPlayerStagePrisonBreak(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetPrisonBreakStartCost(Hero prisonerHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetRelationRewardOnPrisonBreak(Hero prisonerHero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetRogueryRewardOnPrisonBreak(Hero prisonerHero, bool isSuccess)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultPrisonBreakModel()
	{
		throw null;
	}
}
