using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;
using TaleWorlds.TwoDimension;

namespace NavalDLC.GauntletUI;

public class NavalDLCGauntletUISubModule : MBSubModuleBase
{
	private const int NumberOfWaitFramesToLoad = 5;

	private bool _initializedLoadingCategory;

	private bool _loadBackgroundCategory;

	private int _frameCounterToLoad;

	private SpriteCategory _fullBackgroundsCategory;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnApplicationTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSubModuleLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSubModuleUnloaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCGauntletUISubModule()
	{
		throw null;
	}
}
