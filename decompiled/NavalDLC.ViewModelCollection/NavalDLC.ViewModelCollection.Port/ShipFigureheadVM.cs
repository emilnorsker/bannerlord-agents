using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Core.ViewModelCollection.Information;

namespace NavalDLC.ViewModelCollection.Port;

public class ShipFigureheadVM : ShipUpgradePieceBaseVM
{
	public Ship EquippedShip;

	public bool IsRightSide;

	public readonly Figurehead Figurehead;

	private readonly IViewDataTracker _viewDataTracker;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipFigureheadVM(Figurehead figurehead, Action<ShipUpgradePieceBaseVM> onSelected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PropertyBasedTooltipVM GetProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteInspectBegin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Update()
	{
		throw null;
	}
}
