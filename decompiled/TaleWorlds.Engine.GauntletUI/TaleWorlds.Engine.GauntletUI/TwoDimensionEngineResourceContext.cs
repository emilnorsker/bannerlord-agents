using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.Engine.GauntletUI;

public class TwoDimensionEngineResourceContext : ITwoDimensionResourceContext
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	TaleWorlds.TwoDimension.Texture ITwoDimensionResourceContext.LoadTexture(ResourceDepot resourceDepot, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TwoDimensionEngineResourceContext()
	{
		throw null;
	}
}
