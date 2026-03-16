using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.View.Map;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.ViewModelCollection.EscapeMenu;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(MapEscapeMenuView))]
public class GauntletMapEscapeMenuView : MapView
{
	private GauntletLayer _layerAsGauntletLayer;

	private EscapeMenuVM _escapeMenuDatasource;

	private GauntletMovieIdentifier _escapeMenuMovie;

	private readonly List<EscapeMenuItemVM> _menuItems;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapEscapeMenuView(List<EscapeMenuItemVM> items)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CreateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnIdleTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsEscaped()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TutorialContexts GetTutorialContext()
	{
		throw null;
	}
}
