using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIPhysicsMaterial : IPhysicsMaterial
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetAngularDampingAtIndexDelegate(int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetDynamicFrictionAtIndexDelegate(int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate PhysicsMaterialFlags GetFlagsAtIndexDelegate(int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate PhysicsMaterial GetIndexWithNameDelegate(byte[] materialName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetLinearDampingAtIndexDelegate(int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetMaterialCountDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetMaterialNameAtIndexDelegate(int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetRestitutionAtIndexDelegate(int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetStaticFrictionAtIndexDelegate(int index);

	private static readonly Encoding _utf8;

	public static GetAngularDampingAtIndexDelegate call_GetAngularDampingAtIndexDelegate;

	public static GetDynamicFrictionAtIndexDelegate call_GetDynamicFrictionAtIndexDelegate;

	public static GetFlagsAtIndexDelegate call_GetFlagsAtIndexDelegate;

	public static GetIndexWithNameDelegate call_GetIndexWithNameDelegate;

	public static GetLinearDampingAtIndexDelegate call_GetLinearDampingAtIndexDelegate;

	public static GetMaterialCountDelegate call_GetMaterialCountDelegate;

	public static GetMaterialNameAtIndexDelegate call_GetMaterialNameAtIndexDelegate;

	public static GetRestitutionAtIndexDelegate call_GetRestitutionAtIndexDelegate;

	public static GetStaticFrictionAtIndexDelegate call_GetStaticFrictionAtIndexDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAngularDampingAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetDynamicFrictionAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PhysicsMaterialFlags GetFlagsAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PhysicsMaterial GetIndexWithName(string materialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetLinearDampingAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMaterialCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetMaterialNameAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetRestitutionAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetStaticFrictionAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIPhysicsMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIPhysicsMaterial()
	{
		throw null;
	}
}
