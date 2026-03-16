using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class HeroDeathProbabilityCalculationModel : MBGameModel<HeroDeathProbabilityCalculationModel>
{
	public abstract float CalculateHeroDeathProbability(Hero hero);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected HeroDeathProbabilityCalculationModel()
	{
		throw null;
	}
}
