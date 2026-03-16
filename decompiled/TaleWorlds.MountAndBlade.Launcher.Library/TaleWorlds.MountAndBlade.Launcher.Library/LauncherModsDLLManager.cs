using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade.Launcher.Library.UserDatas;

namespace TaleWorlds.MountAndBlade.Launcher.Library;

public class LauncherModsDLLManager
{
	private Dictionary<SubModuleInfo, LauncherDLLData> _subModulesWithDLLs;

	private UserData _userData;

	public bool ShouldUpdateSaveData
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
	public LauncherModsDLLManager(UserData userData, List<SubModuleInfo> allSubmodules)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateUserDataLatestValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VerifySubModules(List<SubModuleInfo> subModulesToVerify)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ResultData GetDLLVerifyReport(string[] dlls)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LauncherDLLData GetSubModuleVerifyData(SubModuleInfo subModuleInfo)
	{
		throw null;
	}
}
