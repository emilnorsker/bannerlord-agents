using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Library;

namespace TaleWorlds.DotNet;

public static class Managed
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[MonoNativeFunctionWrapper]
	public delegate void PassManagedInitializeMethodPointerDelegate([MarshalAs(UnmanagedType.FunctionPtr)] Delegate initalizer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[MonoNativeFunctionWrapper]
	public delegate void PassManagedCallbackMethodPointersDelegate([MarshalAs(UnmanagedType.FunctionPtr)] Delegate methodDelegate);

	[MonoNativeFunctionWrapper]
	public delegate void InitializerDelegate(Delegate argument);

	private static List<IManagedComponent> _components;

	private static ICallbackManager _callbackManager;

	[ThreadStatic]
	internal static string ReturnValueFromEngine;

	private static ManagedInitializeMethod _initializer;

	private static Dictionary<string, Type> _moduleTypes;

	private static Dictionary<int, IntPtr> _engineApiPointers;

	private static Dictionary<uint, uint> _scriptTags;

	private static Dictionary<uint, Dictionary<uint, FieldInfo>> _fieldsOfScriptsCached;

	private static Dictionary<uint, Dictionary<uint, FieldInfo>> _editableFieldsOfScriptsCached;

	private static Dictionary<uint, ConstructorInfo> _constructorsOfScriptsCached;

	private static Dictionary<uint, Delegate> _constructorDelegatesOfScriptsCached;

	private static Dictionary<Type, Delegate> _constructorDelegatesOfWeakReferencesCached;

	private static Delegate PassManagedInitializeMethodPointerMono;

	private static Delegate PassManagedEngineCallbackMethodPointersMono;

	internal static bool Closing
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

	internal static Dictionary<string, Type> ModuleTypes
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal static NativeTelemetryManager NativeTelemetryManager
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

	public static string ManagedCallbacksDll
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Managed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void SetLogsFolder(string logFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	public static string GetStackTraceStr(int skipCount = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	public static string GetStackTraceRaw(int skipCount = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint GetStringHashCode(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetStackTraceRaw(StackTrace stack, int skipCount = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	public static string GetModuleList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	public static void GetVersionInts(ref int major, ref int minor, ref int revision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static DotNetObject CreateCustomParameterStringArray(int length)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static DotNetObject AddCustomParameter<T>(T parameterData) where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void GarbageCollect(bool forceTimer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void SetStringArrayValueAtIndex(string[] array, int index, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static string GetStringArrayValueAtIndex(string[] array, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PassInitializationMethodPointersForMono(IntPtr a, IntPtr b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PassInitializationMethodPointersForDotNet(Delegate a, Delegate b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Start(IEnumerable<IManagedComponent> components)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedInitializeMethod))]
	private static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void CheckSharedStructureSizes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void SetClosing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void PreFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void ApplicationTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void ApplicationTickLight(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static bool CheckClassNameIsValid(string className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static int GetStringArrayLength(string[] array)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static string[] GetClassFields(string className, bool recursive, bool includeInternal, bool includeProtected, bool includePrivate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static ManagedObject CreateObjectClassInstanceWithPointer(string className, IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string GetClassNamesAux(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static ManagedObject CreateObjectClassInstanceWithInteger(string className, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void SetCurrentStringReturnValue(IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void SetCurrentStringReturnValueAsUnicode(IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static string GetObjectClassName(string className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void EngineApiMethodInterfaceInitializer(int id, IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void FillEngineApiPointers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static long GetMemoryUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void PassCustomCallbackMethodPointers(string name, IntPtr initalizer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static string CallCommandlineFunction(string functionName, string arguments)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeTypes(Dictionary<string, Type> types)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddTypes(Dictionary<string, Type> types)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddConstructorDelegateOfClass<T>()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddConstructorDelegateOfWeakReferenceClass<T>()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PassManagedInitializeMethodPointer(Delegate initializer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PassManagedEngineCallbackMethodPointers(Delegate methodDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static void LoadManagedComponent(string assemblyName, string managedInterface)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Dictionary<uint, FieldInfo> GetEditableFieldsOfClass(uint classNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static FieldInfo GetFieldOfClass(uint classNameHash, uint fieldNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static ConstructorInfo GetConstructorOfClass(string className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Delegate GetConstructorDelegateOfClass(string className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Delegate GetConstructorDelegateOfWeakReferenceClass(Type classType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static bool IsClassFieldExists(uint classNameHash, uint fieldNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[LibraryCallback(null, false)]
	internal static string GetEnumNamesOfField(uint classNameHash, uint fieldNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("show_version", "dotnet")]
	public static string ShowDotNetVersion(List<string> strings)
	{
		throw null;
	}
}
