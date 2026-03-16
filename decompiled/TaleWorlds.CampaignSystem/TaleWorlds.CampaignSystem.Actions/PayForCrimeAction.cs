using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.Actions;

public static class PayForCrimeAction
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(IFaction faction, CrimeModel.PaymentMethod paymentMethod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetClearCrimeCost(IFaction faction, CrimeModel.PaymentMethod paymentMethod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Apply(IFaction faction, CrimeModel.PaymentMethod paymentMethod)
	{
		throw null;
	}
}
