using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

internal class CustomParameter<T> : DotNetObject
{
	public T Target
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomParameter(T target)
	{
		throw null;
	}
}
