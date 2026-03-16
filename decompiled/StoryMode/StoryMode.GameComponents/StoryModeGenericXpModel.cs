using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace StoryMode.GameComponents;

public class StoryModeGenericXpModel : GenericXpModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetXpMultiplier(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeGenericXpModel()
	{
		throw null;
	}
}
