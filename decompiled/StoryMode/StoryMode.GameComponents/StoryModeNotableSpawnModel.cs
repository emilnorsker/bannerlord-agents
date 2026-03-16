using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace StoryMode.GameComponents;

public class StoryModeNotableSpawnModel : NotableSpawnModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetTargetNotableCountForSettlement(Settlement settlement, Occupation occupation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeNotableSpawnModel()
	{
		throw null;
	}
}
