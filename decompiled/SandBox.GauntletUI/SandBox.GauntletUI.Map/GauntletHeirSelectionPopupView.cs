using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map.HeirSelectionPopup;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(HeirSelectionPopupView))]
public class GauntletHeirSelectionPopupView : MapView
{
	private GauntletLayer _layerAsGauntletLayer;

	private HeirSelectionPopupVM _dataSource;

	private GauntletMovieIdentifier _movie;

	private readonly Dictionary<Hero, int> _heirApparents;

	private SpriteCategory _gameOverCategory;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletHeirSelectionPopupView(Dictionary<Hero, int> heirApparents)
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
	protected override void OnMenuModeTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnIdleTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsEscaped()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsOpeningEscapeMenuOnFocusChangeAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeKeyVisuals()
	{
		throw null;
	}
}
