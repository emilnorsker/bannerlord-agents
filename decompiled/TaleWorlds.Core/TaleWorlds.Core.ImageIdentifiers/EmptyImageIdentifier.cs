using System.Runtime.CompilerServices;

namespace TaleWorlds.Core.ImageIdentifiers;

public class EmptyImageIdentifier : ImageIdentifier
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public EmptyImageIdentifier()
	{
		throw null;
	}
}
