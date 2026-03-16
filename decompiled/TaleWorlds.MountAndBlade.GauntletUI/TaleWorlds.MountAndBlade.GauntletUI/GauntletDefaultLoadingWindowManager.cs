using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.GauntletUI;

public class GauntletDefaultLoadingWindowManager : GlobalLayer, ILoadingWindowManager
{
	private GauntletMovieIdentifier _movie;

	private GauntletLayer _gauntletLayer;

	private LoadingWindowViewModel _loadingWindowViewModel;

	private SpriteCategory _sploadingCategory;

	private SpriteCategory _mpLoadingCategory;

	private SpriteCategory _mpBackgroundCategory;

	private bool _isMultiplayer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletDefaultLoadingWindowManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILoadingWindowManager.Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILoadingWindowManager.Destroy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILoadingWindowManager.EnableLoadingWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ILoadingWindowManager.DisableLoadingWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual string GetSpriteCategoryName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLateTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCurrentModeIsMultiplayer(bool isMultiplayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadImage(int index, out string imageName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnloadImage(int index)
	{
		throw null;
	}
}
