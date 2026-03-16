using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIManaged : IManaged
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DecreaseReferenceCountDelegate(UIntPtr ptr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetClassTypeDefinitionDelegate(int index, ref EngineClassTypeDefinition engineClassTypeDefinition);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetClassTypeDefinitionCountDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void IncreaseReferenceCountDelegate(UIntPtr ptr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseManagedObjectDelegate(UIntPtr ptr);

	private static readonly Encoding _utf8;

	public static DecreaseReferenceCountDelegate call_DecreaseReferenceCountDelegate;

	public static GetClassTypeDefinitionDelegate call_GetClassTypeDefinitionDelegate;

	public static GetClassTypeDefinitionCountDelegate call_GetClassTypeDefinitionCountDelegate;

	public static IncreaseReferenceCountDelegate call_IncreaseReferenceCountDelegate;

	public static ReleaseManagedObjectDelegate call_ReleaseManagedObjectDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DecreaseReferenceCount(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetClassTypeDefinition(int index, ref EngineClassTypeDefinition engineClassTypeDefinition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetClassTypeDefinitionCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void IncreaseReferenceCount(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseManagedObject(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIManaged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIManaged()
	{
		throw null;
	}
}
