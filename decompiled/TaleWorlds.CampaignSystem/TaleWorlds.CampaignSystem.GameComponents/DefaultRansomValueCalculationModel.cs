using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultRansomValueCalculationModel : RansomValueCalculationModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int PrisonerRansomValue(CharacterObject prisoner, Hero sellerHero = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultRansomValueCalculationModel()
	{
		throw null;
	}
}
