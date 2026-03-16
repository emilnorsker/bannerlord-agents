using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineClass("rglScript_component")]
public abstract class ScriptComponent : NativeObject
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ScriptComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ScriptComponent(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName()
	{
		throw null;
	}
}
