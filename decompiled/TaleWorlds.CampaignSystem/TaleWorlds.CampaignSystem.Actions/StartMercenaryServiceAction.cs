using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Actions;

public static class StartMercenaryServiceAction
{
	public enum StartMercenaryServiceActionDetails
	{
		ApplyByDefault
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyStart(Clan clan, Kingdom kingdom, int awardMultiplier, StartMercenaryServiceActionDetails details)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDefault(Clan clan, Kingdom kingdom, int awardMultiplier)
	{
		throw null;
	}
}
