using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
public sealed class AspMvcControllerAttribute : Attribute
{
	[UsedImplicitly]
	public string AnonymousProperty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AspMvcControllerAttribute()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AspMvcControllerAttribute(string anonymousProperty)
	{
		throw null;
	}
}
