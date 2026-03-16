using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine.Options;

public struct SelectionData
{
	public bool IsLocalizationId;

	public string Data;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SelectionData(bool isLocalizationId, string data)
	{
		throw null;
	}
}
