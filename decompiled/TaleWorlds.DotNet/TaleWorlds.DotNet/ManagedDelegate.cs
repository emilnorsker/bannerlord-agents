using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

public class ManagedDelegate : DotNetObject
{
	public delegate void DelegateDefinition();

	private DelegateDefinition _instance;

	public DelegateDefinition Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ManagedDelegate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	public void InvokeAux()
	{
		throw null;
	}
}
