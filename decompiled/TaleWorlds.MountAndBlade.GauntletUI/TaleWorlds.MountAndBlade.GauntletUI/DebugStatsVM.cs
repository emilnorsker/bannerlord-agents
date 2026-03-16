using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.GauntletUI;

internal class DebugStatsVM : ViewModel
{
	private string _gameVersion;

	[DataSourceProperty]
	public string GameVersion
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
	public DebugStatsVM()
	{
		throw null;
	}
}
