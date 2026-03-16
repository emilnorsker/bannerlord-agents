using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;

namespace NavalDLC.ViewModelCollection.Port;

public class ShipUpgradePieceVM : ShipUpgradePieceBaseVM
{
	public readonly ShipUpgradePiece Piece;

	public readonly Ship Ship;

	public static event Func<Ship, ShipUpgradePiece, int> GetUpgradePrice
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipUpgradePieceVM(ShipUpgradePiece piece, Ship ship, Action<ShipUpgradePieceBaseVM> onSelected)
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
}
