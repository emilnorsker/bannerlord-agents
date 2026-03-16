using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Actions;

public static class MakePeaceAction
{
	public enum MakePeaceDetail
	{
		Default,
		ByKingdomDecision
	}

	private const float DefaultValueForBeingLimitedAfterPeace = 100000f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(IFaction faction1, IFaction faction2, int dailyTributeFrom1To2, int dailyTributeDuration, MakePeaceDetail detail = MakePeaceDetail.Default)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Apply(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByKingdomDecision(IFaction faction1, IFaction faction2, int dailyTributeFrom1To2, int dailyTributeDuration)
	{
		throw null;
	}
}
