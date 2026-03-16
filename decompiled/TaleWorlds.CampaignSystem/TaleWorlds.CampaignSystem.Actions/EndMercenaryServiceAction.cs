using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Actions;

public static class EndMercenaryServiceAction
{
	public enum EndMercenaryServiceActionDetails
	{
		ApplyByDefault,
		ApplyByLeavingKingdom,
		ApplyByBecomingVassal
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Apply(Clan clan, EndMercenaryServiceActionDetails details)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndByDefault(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndByLeavingKingdom(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndByBecomingVassal(Clan clan)
	{
		throw null;
	}
}
