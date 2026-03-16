using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineClass("rglNative_script_component")]
public sealed class NativeScriptComponent : ScriptComponent
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal NativeScriptComponent(UIntPtr pointer)
	{
		throw null;
	}
}
