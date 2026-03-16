using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[MeansImplicitUse]
public sealed class PublicAPIAttribute : Attribute
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public PublicAPIAttribute()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PublicAPIAttribute(string comment)
	{
		throw null;
	}
}
