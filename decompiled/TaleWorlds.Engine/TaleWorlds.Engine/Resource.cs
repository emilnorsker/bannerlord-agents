using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineClass("rglResource")]
public abstract class Resource : NativeObject
{
	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected Resource()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Resource(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("_RGL_KEEP_ASSERTS")]
	protected void CheckResourceParameter(Resource param, string paramName = "")
	{
		throw null;
	}
}
