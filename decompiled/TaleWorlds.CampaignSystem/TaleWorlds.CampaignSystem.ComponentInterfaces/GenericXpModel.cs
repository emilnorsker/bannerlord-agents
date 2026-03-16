using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class GenericXpModel : MBGameModel<GenericXpModel>
{
	public abstract float GetXpMultiplier(Hero hero);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GenericXpModel()
	{
		throw null;
	}
}
