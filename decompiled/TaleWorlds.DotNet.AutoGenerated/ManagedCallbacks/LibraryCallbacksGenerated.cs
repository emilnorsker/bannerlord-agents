using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCallbacks;

internal static class LibraryCallbacksGenerated
{
	internal delegate void DotNetObject_DecreaseReferenceCount_delegate(int dotnetObjectId);

	internal delegate int DotNetObject_GetAliveDotNetObjectCount_delegate();

	internal delegate UIntPtr DotNetObject_GetAliveDotNetObjectNames_delegate();

	internal delegate void DotNetObject_IncreaseReferenceCount_delegate(int dotnetObjectId);

	internal delegate void Managed_ApplicationTick_delegate(float dt);

	internal delegate void Managed_ApplicationTickLight_delegate(float dt);

	internal delegate UIntPtr Managed_CallCommandlineFunction_delegate(IntPtr functionName, IntPtr arguments);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool Managed_CheckClassNameIsValid_delegate(IntPtr className);

	internal delegate void Managed_CheckSharedStructureSizes_delegate();

	internal delegate int Managed_CreateCustomParameterStringArray_delegate(int length);

	internal delegate int Managed_CreateObjectClassInstanceWithInteger_delegate(IntPtr className, int value);

	internal delegate int Managed_CreateObjectClassInstanceWithPointer_delegate(IntPtr className, IntPtr pointer);

	internal delegate void Managed_EngineApiMethodInterfaceInitializer_delegate(int id, IntPtr pointer);

	internal delegate void Managed_FillEngineApiPointers_delegate();

	internal delegate void Managed_GarbageCollect_delegate([MarshalAs(UnmanagedType.U1)] bool forceTimer);

	internal delegate int Managed_GetClassFields_delegate(IntPtr className, [MarshalAs(UnmanagedType.U1)] bool recursive, [MarshalAs(UnmanagedType.U1)] bool includeInternal, [MarshalAs(UnmanagedType.U1)] bool includeProtected, [MarshalAs(UnmanagedType.U1)] bool includePrivate);

	internal delegate UIntPtr Managed_GetEnumNamesOfField_delegate(uint classNameHash, uint fieldNameHash);

	internal delegate long Managed_GetMemoryUsage_delegate();

	internal delegate UIntPtr Managed_GetModuleList_delegate();

	internal delegate UIntPtr Managed_GetObjectClassName_delegate(IntPtr className);

	internal delegate UIntPtr Managed_GetStackTraceRaw_delegate(int skipCount);

	internal delegate UIntPtr Managed_GetStackTraceStr_delegate(int skipCount);

	internal delegate int Managed_GetStringArrayLength_delegate(int array);

	internal delegate UIntPtr Managed_GetStringArrayValueAtIndex_delegate(int array, int index);

	internal delegate void Managed_GetVersionInts_delegate(ref int major, ref int minor, ref int revision);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool Managed_IsClassFieldExists_delegate(uint classNameHash, uint fieldNameHash);

	internal delegate void Managed_LoadManagedComponent_delegate(IntPtr assemblyName, IntPtr managedInterface);

	internal delegate void Managed_OnFinalize_delegate();

	internal delegate void Managed_PassCustomCallbackMethodPointers_delegate(IntPtr name, IntPtr initalizer);

	internal delegate void Managed_PreFinalize_delegate();

	internal delegate void Managed_SetClosing_delegate();

	internal delegate void Managed_SetCurrentStringReturnValue_delegate(IntPtr pointer);

	internal delegate void Managed_SetCurrentStringReturnValueAsUnicode_delegate(IntPtr pointer);

	internal delegate void Managed_SetLogsFolder_delegate(IntPtr logFolder);

	internal delegate void Managed_SetStringArrayValueAtIndex_delegate(int array, int index, IntPtr value);

	internal delegate void ManagedDelegate_InvokeAux_delegate(int thisPointer);

	internal delegate int ManagedObject_GetAliveManagedObjectCount_delegate();

	internal delegate UIntPtr ManagedObject_GetAliveManagedObjectNames_delegate();

	internal delegate UIntPtr ManagedObject_GetClassOfObject_delegate(int thisPointer);

	internal delegate UIntPtr ManagedObject_GetCreationCallstack_delegate(IntPtr name);

	internal delegate int NativeObject_GetAliveNativeObjectCount_delegate();

	internal delegate UIntPtr NativeObject_GetAliveNativeObjectNames_delegate();

	internal static Delegate[] Delegates
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
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(DotNetObject_DecreaseReferenceCount_delegate))]
	internal static void DotNetObject_DecreaseReferenceCount(int dotnetObjectId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(DotNetObject_GetAliveDotNetObjectCount_delegate))]
	internal static int DotNetObject_GetAliveDotNetObjectCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(DotNetObject_GetAliveDotNetObjectNames_delegate))]
	internal static UIntPtr DotNetObject_GetAliveDotNetObjectNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(DotNetObject_IncreaseReferenceCount_delegate))]
	internal static void DotNetObject_IncreaseReferenceCount(int dotnetObjectId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_ApplicationTick_delegate))]
	internal static void Managed_ApplicationTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_ApplicationTickLight_delegate))]
	internal static void Managed_ApplicationTickLight(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_CallCommandlineFunction_delegate))]
	internal static UIntPtr Managed_CallCommandlineFunction(IntPtr functionName, IntPtr arguments)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_CheckClassNameIsValid_delegate))]
	internal static bool Managed_CheckClassNameIsValid(IntPtr className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_CheckSharedStructureSizes_delegate))]
	internal static void Managed_CheckSharedStructureSizes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_CreateCustomParameterStringArray_delegate))]
	internal static int Managed_CreateCustomParameterStringArray(int length)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_CreateObjectClassInstanceWithInteger_delegate))]
	internal static int Managed_CreateObjectClassInstanceWithInteger(IntPtr className, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_CreateObjectClassInstanceWithPointer_delegate))]
	internal static int Managed_CreateObjectClassInstanceWithPointer(IntPtr className, IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_EngineApiMethodInterfaceInitializer_delegate))]
	internal static void Managed_EngineApiMethodInterfaceInitializer(int id, IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_FillEngineApiPointers_delegate))]
	internal static void Managed_FillEngineApiPointers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GarbageCollect_delegate))]
	internal static void Managed_GarbageCollect(bool forceTimer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetClassFields_delegate))]
	internal static int Managed_GetClassFields(IntPtr className, bool recursive, bool includeInternal, bool includeProtected, bool includePrivate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetEnumNamesOfField_delegate))]
	internal static UIntPtr Managed_GetEnumNamesOfField(uint classNameHash, uint fieldNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetMemoryUsage_delegate))]
	internal static long Managed_GetMemoryUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetModuleList_delegate))]
	internal static UIntPtr Managed_GetModuleList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetObjectClassName_delegate))]
	internal static UIntPtr Managed_GetObjectClassName(IntPtr className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetStackTraceRaw_delegate))]
	internal static UIntPtr Managed_GetStackTraceRaw(int skipCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetStackTraceStr_delegate))]
	internal static UIntPtr Managed_GetStackTraceStr(int skipCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetStringArrayLength_delegate))]
	internal static int Managed_GetStringArrayLength(int array)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetStringArrayValueAtIndex_delegate))]
	internal static UIntPtr Managed_GetStringArrayValueAtIndex(int array, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_GetVersionInts_delegate))]
	internal static void Managed_GetVersionInts(ref int major, ref int minor, ref int revision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_IsClassFieldExists_delegate))]
	internal static bool Managed_IsClassFieldExists(uint classNameHash, uint fieldNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_LoadManagedComponent_delegate))]
	internal static void Managed_LoadManagedComponent(IntPtr assemblyName, IntPtr managedInterface)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_OnFinalize_delegate))]
	internal static void Managed_OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_PassCustomCallbackMethodPointers_delegate))]
	internal static void Managed_PassCustomCallbackMethodPointers(IntPtr name, IntPtr initalizer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_PreFinalize_delegate))]
	internal static void Managed_PreFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_SetClosing_delegate))]
	internal static void Managed_SetClosing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_SetCurrentStringReturnValue_delegate))]
	internal static void Managed_SetCurrentStringReturnValue(IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_SetCurrentStringReturnValueAsUnicode_delegate))]
	internal static void Managed_SetCurrentStringReturnValueAsUnicode(IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_SetLogsFolder_delegate))]
	internal static void Managed_SetLogsFolder(IntPtr logFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Managed_SetStringArrayValueAtIndex_delegate))]
	internal static void Managed_SetStringArrayValueAtIndex(int array, int index, IntPtr value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedDelegate_InvokeAux_delegate))]
	internal static void ManagedDelegate_InvokeAux(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedObject_GetAliveManagedObjectCount_delegate))]
	internal static int ManagedObject_GetAliveManagedObjectCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedObject_GetAliveManagedObjectNames_delegate))]
	internal static UIntPtr ManagedObject_GetAliveManagedObjectNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedObject_GetClassOfObject_delegate))]
	internal static UIntPtr ManagedObject_GetClassOfObject(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedObject_GetCreationCallstack_delegate))]
	internal static UIntPtr ManagedObject_GetCreationCallstack(IntPtr name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(NativeObject_GetAliveNativeObjectCount_delegate))]
	internal static int NativeObject_GetAliveNativeObjectCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(NativeObject_GetAliveNativeObjectNames_delegate))]
	internal static UIntPtr NativeObject_GetAliveNativeObjectNames()
	{
		throw null;
	}
}
