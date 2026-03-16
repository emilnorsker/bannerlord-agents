using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.ModuleManager;

namespace TaleWorlds.MountAndBlade.Launcher.Library;

public class LauncherModuleVM : ViewModel
{
	public readonly ModuleInfo Info;

	private readonly Action<LauncherModuleVM, int, string> _onChangeLoadingOrder;

	private readonly Action<LauncherModuleVM> _onSelect;

	private readonly Func<SubModuleInfo, LauncherDLLData> _querySubmoduleVerifyData;

	private readonly Func<ModuleInfo, bool> _areAllDependenciesPresent;

	private MBBindingList<LauncherSubModule> _subModules;

	private LauncherHintVM _dangerousHint;

	private LauncherHintVM _dependencyHint;

	private string _name;

	private string _versionText;

	private bool _isDisabled;

	private bool _isDangerous;

	private bool _isOfficial;

	private bool _anyDependencyAvailable;

	[DataSourceProperty]
	public MBBindingList<LauncherSubModule> SubModules
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
	public LauncherHintVM DangerousHint
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
	public LauncherHintVM DependencyHint
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
	public string VersionText
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
	public string Name
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
	public bool AnyDependencyAvailable
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
	public bool IsDangerous
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
	public bool IsOfficial
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
	public bool IsSelected
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
	public LauncherModuleVM(ModuleInfo moduleInfo, Action<LauncherModuleVM, int, string> onChangeLoadingOrder, Action<LauncherModuleVM> onSelect, Func<ModuleInfo, bool> areAllDependenciesPresent, Func<SubModuleInfo, LauncherDLLData> queryIsSubmoduleDangerous)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string ProcessModuleName(string originalModuleName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateIsDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSelect()
	{
		throw null;
	}
}
