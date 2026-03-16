using System;
using System.Runtime.CompilerServices;

namespace JetBrains.Annotations;

[AttributeUsage(AttributeTargets.Parameter)]
public class PathReferenceAttribute : Attribute
{
	[UsedImplicitly]
	public string BasePath
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
	public PathReferenceAttribute()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	public PathReferenceAttribute([PathReference] string basePath)
	{
		throw null;
	}
}
