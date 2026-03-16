using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIGameEntityComponent : IGameEntityComponent
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetEntityDelegate(UIntPtr entityComponent);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetEntityPointerDelegate(UIntPtr componentPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetFirstMetaMeshDelegate(UIntPtr entityComponent);

	private static readonly Encoding _utf8;

	public static GetEntityDelegate call_GetEntityDelegate;

	public static GetEntityPointerDelegate call_GetEntityPointerDelegate;

	public static GetFirstMetaMeshDelegate call_GetFirstMetaMeshDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetEntity(GameEntityComponent entityComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetEntityPointer(UIntPtr componentPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh GetFirstMetaMesh(GameEntityComponent entityComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIGameEntityComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIGameEntityComponent()
	{
		throw null;
	}
}
