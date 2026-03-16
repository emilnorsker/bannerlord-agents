using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultGenericXpModel : GenericXpModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetXpMultiplier(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultGenericXpModel()
	{
		throw null;
	}
}
