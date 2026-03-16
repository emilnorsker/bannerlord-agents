using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.ModuleManager;

namespace TaleWorlds.PlatformService.Steam;

public class SteamModuleExtension : IPlatformModuleExtension
{
	private List<string> _modulePaths;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SteamModuleExtension()
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
