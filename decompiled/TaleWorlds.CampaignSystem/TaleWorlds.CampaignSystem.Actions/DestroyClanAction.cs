using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Actions;

public static class DestroyClanAction
{
	private enum DestroyClanActionDetails
	{
		Default,
		RebellionFailure,
		ClanLeaderDeath
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Clan destroyedClan, DestroyClanActionDetails details)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Apply(Clan destroyedClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByFailedRebellion(Clan failedRebellionClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByClanLeaderDeath(Clan destroyedClan)
	{
		throw null;
	}
}
