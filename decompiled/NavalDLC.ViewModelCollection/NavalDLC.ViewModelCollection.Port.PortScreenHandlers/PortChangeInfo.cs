using System.Runtime.CompilerServices;

namespace NavalDLC.ViewModelCollection.Port.PortScreenHandlers;

public readonly struct PortChangeInfo
{
	public readonly float GoldCost;

	public readonly string Description;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortChangeInfo(float goldCost, string description)
	{
		throw null;
	}
}
