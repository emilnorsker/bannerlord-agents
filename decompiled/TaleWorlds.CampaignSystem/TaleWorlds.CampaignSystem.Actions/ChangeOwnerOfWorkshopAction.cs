using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements.Workshops;

namespace TaleWorlds.CampaignSystem.Actions;

public static class ChangeOwnerOfWorkshopAction
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Workshop workshop, Hero newOwner, WorkshopType workshopType, int capital, int cost)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByBankruptcy(Workshop workshop, Hero newOwner, WorkshopType workshopType, int cost)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByPlayerBuying(Workshop workshop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByPlayerSelling(Workshop workshop, Hero newOwner, WorkshopType workshopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByDeath(Workshop workshop, Hero newOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByWar(Workshop workshop, Hero newOwner, WorkshopType workshopType)
	{
		throw null;
	}
}
