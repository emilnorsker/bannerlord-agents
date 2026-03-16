using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public struct ShipVisualSlotInfo
{
	public string VisualSlotTag;

	public string VisualPieceId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipVisualSlotInfo(string visualSlotId, string visualPieceId)
	{
		throw null;
	}
}
