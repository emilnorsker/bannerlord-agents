using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Actions;

public static class RemoveCompanionAction
{
	public enum RemoveCompanionDetail
	{
		Fire,
		Death,
		AfterQuest,
		ByTurningToLord
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Clan clan, Hero companion, RemoveCompanionDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByFire(Clan clan, Hero companion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyAfterQuest(Clan clan, Hero companion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDeath(Clan clan, Hero companion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByByTurningToLord(Clan clan, Hero companion)
	{
		throw null;
	}
}
