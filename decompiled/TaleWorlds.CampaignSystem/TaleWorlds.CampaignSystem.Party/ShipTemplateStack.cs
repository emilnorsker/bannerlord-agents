using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.Party;

public struct ShipTemplateStack
{
	public ShipHull ShipHull;

	public int MinValue;

	public int MaxValue;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipTemplateStack(ShipHull shipHull, int minValue, int maxValue)
	{
		throw null;
	}
}
