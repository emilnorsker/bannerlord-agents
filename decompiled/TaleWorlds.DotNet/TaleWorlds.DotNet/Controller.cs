using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.DotNet;

public static class Controller
{
	[MonoNativeFunctionWrapper]
	private delegate void ControllerMethodDelegate();

	[MonoNativeFunctionWrapper]
	private delegate void CreateApplicationDomainMethodDelegate(IntPtr gameDllNameAsPointer, IntPtr gameTypeNameAsPointer, int currentEngineAsInteger, int currentPlatformAsInteger);

	[MonoNativeFunctionWrapper]
	private delegate void OverrideManagedDllFolderDelegate(IntPtr overridenFolderAsPointer);

	private static bool _hostedByNative;

	private static Delegate _passControllerMethods;

	private static Delegate _passManagedInitializeMethod;

	private static Delegate _passManagedCallbackMethod;

	private static IntPtr _passManagedInitializeMethodPointer;

	private static IntPtr _passManagedCallbackMethodPointer;

	private static CreateApplicationDomainMethodDelegate _loadOnCurrentApplicationDomainMethod;

	private static Runtime RuntimeLibrary
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(OverrideManagedDllFolderDelegate))]
	public static void OverrideManagedDllFolder(IntPtr overridenFolderAsPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(CreateApplicationDomainMethodDelegate))]
	public static void LoadOnCurrentApplicationDomain(IntPtr gameDllNameAsPointer, IntPtr gameTypeNameAsPointer, int currentEngineAsInteger, int currentPlatformAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void SetEngineMethodsAsHostedByNative(IntPtr passControllerMethods, IntPtr passManagedInitializeMethod, IntPtr passManagedCallbackMethod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetEngineMethodsAsMono(IntPtr passControllerMethods, IntPtr passManagedInitializeMethod, IntPtr passManagedCallbackMethod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetEngineMethodsAsHostedDotNetCore(IntPtr passControllerMethods, IntPtr passManagedInitializeMethod, IntPtr passManagedCallbackMethod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetEngineMethodsAsDotNet(Delegate passControllerMethods, Delegate passManagedInitializeMethod, Delegate passManagedCallbackMethod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Start()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PassControllerMethods(Delegate loadOnCurrentApplicationDomainMethod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Controller()
	{
		throw null;
	}
}
