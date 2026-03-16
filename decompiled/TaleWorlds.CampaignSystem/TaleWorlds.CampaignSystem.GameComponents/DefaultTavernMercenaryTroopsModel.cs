using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultTavernMercenaryTroopsModel : TavernMercenaryTroopsModel
{
	public override float RegularMercenariesSpawnChance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultTavernMercenaryTroopsModel()
	{
		throw null;
	}
}
