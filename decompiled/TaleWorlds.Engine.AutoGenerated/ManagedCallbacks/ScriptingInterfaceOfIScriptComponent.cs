using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIScriptComponent : IScriptComponent
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNameDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetScriptComponentBehaviorDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVariableEditorWidgetStatusDelegate(UIntPtr pointer, byte[] field, [MarshalAs(UnmanagedType.U1)] bool enabled);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVariableEditorWidgetValueDelegate(UIntPtr pointer, byte[] field, RglScriptFieldType fieldType, double value);

	private static readonly Encoding _utf8;

	public static GetNameDelegate call_GetNameDelegate;

	public static GetScriptComponentBehaviorDelegate call_GetScriptComponentBehaviorDelegate;

	public static SetVariableEditorWidgetStatusDelegate call_SetVariableEditorWidgetStatusDelegate;

	public static SetVariableEditorWidgetValueDelegate call_SetVariableEditorWidgetValueDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptComponentBehavior GetScriptComponentBehavior(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVariableEditorWidgetStatus(UIntPtr pointer, string field, bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVariableEditorWidgetValue(UIntPtr pointer, string field, RglScriptFieldType fieldType, double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIScriptComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIScriptComponent()
	{
		throw null;
	}
}
