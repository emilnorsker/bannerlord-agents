using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension.Standalone;

public abstract class FrameworkDomain
{
	public abstract void Update();

	public abstract void Destroy();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected FrameworkDomain()
	{
		throw null;
	}
}
