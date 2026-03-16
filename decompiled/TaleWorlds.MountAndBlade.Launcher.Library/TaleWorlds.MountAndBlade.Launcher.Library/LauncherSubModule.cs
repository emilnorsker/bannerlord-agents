using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.ModuleManager;

namespace TaleWorlds.MountAndBlade.Launcher.Library;

public class LauncherSubModule : ViewModel
{
	public readonly SubModuleInfo Info;

	private string _name;

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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LauncherSubModule(SubModuleInfo subModuleInfo)
	{
		throw null;
	}
}
