using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public struct ShipSlotAndPieceName
{
	public string SlotName;

	public string PieceName;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipSlotAndPieceName(string slotName, string pieceName)
	{
		throw null;
	}
}
