using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;

namespace TaleWorlds.CampaignSystem.Actions;

public static class DestroyShipAction
{
	public enum ShipDestroyDetail
	{
		ApplyDefault,
		ApplyByDiscard
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Ship ship, ShipDestroyDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Apply(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDiscard(Ship ship)
	{
		throw null;
	}
}
