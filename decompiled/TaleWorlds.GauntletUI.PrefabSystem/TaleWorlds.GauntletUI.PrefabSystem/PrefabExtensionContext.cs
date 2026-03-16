using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI.PrefabSystem;

public class PrefabExtensionContext
{
	private List<PrefabExtension> _prefabExtensions;

	public IEnumerable<PrefabExtension> PrefabExtensions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PrefabExtensionContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddExtension(PrefabExtension prefabExtension)
	{
		throw null;
	}
}
