using System.Runtime.CompilerServices;
using SandBox.View;
using SandBox.ViewModelCollection.SaveLoad;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI;

[OverrideView(typeof(SaveLoadScreen))]
public class GauntletSaveLoadScreen : ScreenBase
{
	private GauntletLayer _gauntletLayer;

	private SaveLoadVM _dataSource;

	private SpriteCategory _spriteCategory;

	private readonly bool _isSaving;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletSaveLoadScreen(bool isSaving)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPostFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateInputRestrictions()
	{
		throw null;
	}
}
