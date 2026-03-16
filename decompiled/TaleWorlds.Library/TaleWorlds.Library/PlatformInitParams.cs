using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public class PlatformInitParams : Dictionary<string, object>
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlatformInitParams()
	{
		throw null;
	}
}
