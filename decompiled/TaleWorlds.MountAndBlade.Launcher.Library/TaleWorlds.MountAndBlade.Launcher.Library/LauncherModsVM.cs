using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade.Launcher.Library.UserDatas;

namespace TaleWorlds.MountAndBlade.Launcher.Library;

public class LauncherModsVM : ViewModel
{
	private UserData _userData;

	private List<ModuleInfo> _modulesCache;

	private UserDataManager _userDataManager;

	private LauncherModsDLLManager _dllManager;

	private MBBindingList<LauncherModuleVM> _modules;

	private bool _isDisabledOnMultiplayer;

	private string _nameCategoryText;

	private string _versionCategoryText;

	public string ModuleListCode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsDisabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string NameCategoryText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string VersionCategoryText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<LauncherModuleVM> Modules
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LauncherModsVM(UserDataManager userDataManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Refresh(bool isDisabled, bool isMultiplayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadSubModules(bool isMultiplayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsVisible(bool isMultiplayer, ModuleInfo moduleInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeLoadingOrderOf(LauncherModuleVM targetModule, int insertIndex, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeIsSelectedOf(LauncherModuleVM targetModule)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreAllDependenciesOfModulePresent(ModuleInfo info)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LauncherDLLData GetSubModuleVerifyData(SubModuleInfo subModule)
	{
		throw null;
	}
}
