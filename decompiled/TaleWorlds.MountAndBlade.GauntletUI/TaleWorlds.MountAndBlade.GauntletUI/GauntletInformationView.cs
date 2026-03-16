using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.GauntletUI;

public class GauntletInformationView : GlobalLayer
{
	private TooltipBaseVM _dataSource;

	private GauntletMovieIdentifier _movie;

	private GauntletLayer _layerAsGauntletLayer;

	private static GauntletInformationView _current;

	private const float _tooltipExtendTreshold = 0.18f;

	private float _gamepadTooltipExtendTimer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GauntletInformationView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetExtendTooltipKeyText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetKey(string categoryId, string keyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetKey(string categoryId, int keyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShowTooltip(Type type, object[] args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHideTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGetIsAnyTooltipActive(out bool isAnyTooltipActive, out bool isAnyTooltipExtended)
	{
		throw null;
	}
}
