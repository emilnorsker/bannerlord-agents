using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineClass("rglManaged_script_component")]
public sealed class ManagedScriptComponent : ScriptComponent
{
	public ScriptComponentBehavior ScriptComponentBehavior
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVariableEditorWidgetStatus(string field, bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVariableEditorWidgetValue(string field, RglScriptFieldType fieldType, double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ManagedScriptComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ManagedScriptComponent(UIntPtr pointer)
	{
		throw null;
	}
}
