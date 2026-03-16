using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

[EngineClass("ftdnNative_string")]
public sealed class NativeString : NativeObject
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal NativeString(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NativeString Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetString(string newString)
	{
		throw null;
	}
}
