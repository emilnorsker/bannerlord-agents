using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Parameter)]
public sealed class AspMvcAreaAttribute : PathReferenceAttribute
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
	[UsedImplicitly]
	public AspMvcAreaAttribute()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AspMvcAreaAttribute(string anonymousProperty)
	{
		throw null;
	}
}
