using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.DotNet;

public class GameApplicationDomainController : MarshalByRefObject
{
	private delegate void InitializerDelegate(Delegate argument);

	private static Delegate _passManagedInitializeMethod;

	private static Delegate _passManagedCallbackMethod;

	private static GameApplicationDomainController _instance;

	private bool _newApplicationDomain;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameApplicationDomainController(bool newApplicationDomain)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameApplicationDomainController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadAsHostedByNative(IntPtr passManagedInitializeMethodPointer, IntPtr passManagedCallbackMethodPointer, string gameApiDllName, string gameApiTypeName, Platform currentPlatform)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Load(Delegate passManagedInitializeMethod, Delegate passManagedCallbackMethod, string gameApiDllName, string gameApiTypeName, Platform currentPlatform)
	{
		throw null;
	}
}
