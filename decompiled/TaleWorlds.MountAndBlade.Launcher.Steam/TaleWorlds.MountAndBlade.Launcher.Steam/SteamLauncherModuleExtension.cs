using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.ModuleManager;

namespace TaleWorlds.MountAndBlade.Launcher.Steam;

public class SteamLauncherModuleExtension : IPlatformModuleExtension
{
	private bool _steamInitialized;

	private List<string> _modulePaths;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SteamLauncherModuleExtension()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(List<string> args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string[] GetModulePaths()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLauncherMode(bool isLauncherModeActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckEntitlement(string title)
	{
		throw null;
	}
}
