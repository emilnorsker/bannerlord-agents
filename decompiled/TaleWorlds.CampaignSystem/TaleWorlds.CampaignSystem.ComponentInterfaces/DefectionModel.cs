using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class DefectionModel : MBGameModel<DefaultDefectionModel>
{
	public abstract bool CanHeroDefectToFaction(Hero hero, Kingdom kingdom);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected DefectionModel()
	{
		throw null;
	}
}
