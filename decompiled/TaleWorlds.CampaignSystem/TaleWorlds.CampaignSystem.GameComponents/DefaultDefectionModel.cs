using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultDefectionModel : DefectionModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanHeroDefectToFaction(Hero hero, Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultDefectionModel()
	{
		throw null;
	}
}
