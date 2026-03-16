using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Localization;

namespace NavalDLC.ViewModelCollection.Port;

public class ShipFigureheadSlotVM : ShipUpgradeSlotBaseVM
{
	public delegate Figurehead GetCurrentFigureheadDelegate(Ship ship);

	public delegate Ship GetShipOfFigureheadDelegate(Figurehead figurehead, bool isRightSide);

	public delegate bool GetIsRightSideDelegate(Ship ship);

	private readonly Figurehead _initialSelectedFigurehead;

	private readonly List<Figurehead> _enabledFigureheads;

	public static event GetCurrentFigureheadDelegate GetCurrentFigurehead
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

	public static event GetShipOfFigureheadDelegate GetShipOfFigurehead
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

	public static event GetIsRightSideDelegate GetIsRightSide
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
	public ShipFigureheadSlotVM(Ship ship, TextObject slotName, string shipSlotTag, string slotTypeId, Action<ShipUpgradeSlotBaseVM> onSelected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ResetPieces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool GetIsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateAvailableFigureheads()
	{
		throw null;
	}
}
