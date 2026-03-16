using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Actions;

public static class DeclareWarAction
{
	public enum DeclareWarDetail
	{
		Default,
		CausedByPlayerHostility,
		CausedByKingdomDecision,
		CausedByRebellion,
		CausedByCrimeRatingChange,
		CausedByKingdomCreation,
		CausedByClaimOnThrone,
		CausedByCallToWarAgreement
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(IFaction faction1, IFaction faction2, DeclareWarDetail declareWarDetail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByKingdomDecision(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDefault(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByPlayerHostility(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByRebellion(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByCrimeRatingChange(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByKingdomCreation(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByClaimOnThrone(IFaction faction1, IFaction faction2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByCallToWarAgreement(IFaction faction1, IFaction faction2)
	{
		throw null;
	}
}
