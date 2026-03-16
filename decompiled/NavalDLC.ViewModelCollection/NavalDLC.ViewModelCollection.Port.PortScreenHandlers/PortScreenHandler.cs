using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace NavalDLC.ViewModelCollection.Port.PortScreenHandlers;

public abstract class PortScreenHandler
{
	public readonly struct ShipUpgradePieceInfo
	{
		public readonly Ship Ship;

		public readonly string ShipSlotTag;

		public readonly ShipUpgradePiece Piece;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipUpgradePieceInfo(Ship ship, string shipSlotTag, ShipUpgradePiece piece)
		{
			throw null;
		}
	}

	public readonly struct ShipFigureheadInfo
	{
		public readonly Ship Ship;

		public readonly Figurehead Figurehead;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipFigureheadInfo(Ship ship, Figurehead figurehead)
		{
			throw null;
		}
	}

	public readonly struct ShipRenameInfo
	{
		public readonly Ship Ship;

		public readonly string NewName;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipRenameInfo(Ship ship, string newName)
		{
			throw null;
		}
	}

	public readonly struct ShipTradeInfo
	{
		public readonly Ship Ship;

		public readonly int Price;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipTradeInfo(Ship ship, int price)
		{
			throw null;
		}
	}

	protected MBReadOnlyList<Ship> _initialLeftShips;

	protected MBReadOnlyList<Ship> _initialRightShips;

	private MBList<Ship> _leftShips;

	private MBList<Ship> _rightShips;

	private MBList<ShipTradeInfo> _shipsToBuy;

	private MBList<ShipTradeInfo> _shipsToSell;

	private MBList<Ship> _shipsToRepair;

	private MBList<Ship> _shipsToSend;

	private MBList<ShipRenameInfo> _shipsToRename;

	private MBList<ShipUpgradePieceInfo> _selectedShipPieces;

	private MBList<ShipFigureheadInfo> _selectedFigureheads;

	public MBReadOnlyList<Ship> LeftShips
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Ship> RightShips
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipTradeInfo> ShipsToBuy
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipTradeInfo> ShipsToSell
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Ship> ShipsToRepair
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<Ship> ShipsToSend
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipRenameInfo> ShipsToRename
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipUpgradePieceInfo> SelectedShipPieces
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<ShipFigureheadInfo> SelectedFigureheads
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortScreenHandler(MBReadOnlyList<Ship> initialLeftShips, MBReadOnlyList<Ship> initialRightShips)
	{
		throw null;
	}

	public abstract TextObject GetLeftRosterName();

	public abstract TextObject GetRightRosterName();

	public abstract PartyBase GetLeftSideOwnerParty();

	public abstract PartyBase GetRightSideOwnerParty();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortActionInfo GetCanBuyShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortActionInfo GetCanSellShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortActionInfo GetCanRepairShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortActionInfo GetCanRepairAll(Ship selectedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortActionInfo GetCanUpgradeShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortActionInfo GetCanRenameShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortActionInfo GetCanSendToClan(Ship ship)
	{
		throw null;
	}

	public abstract int GetTradeCostOfShip(Ship ship, bool isRightSideSelling);

	public abstract int GetRepairCostOfShip(Ship ship, bool isRightSideRepairing);

	public abstract int GetUpgradeCostOfShip(Ship ship, ShipUpgradePiece piece, bool isRightSideUpgrading);

	public abstract int GetTotalGoldCost();

	public abstract bool GetCanConfirm(out TextObject disabledHint);

	public abstract void OnConfirmChanges();

	public abstract List<PortChangeInfo> GetChanges();

	protected abstract PortActionInfo CanBuyShip(Ship ship);

	protected abstract PortActionInfo CanSellShip(Ship ship);

	protected abstract PortActionInfo CanRepairShip(Ship ship);

	protected abstract PortActionInfo CanRepairAll();

	protected abstract PortActionInfo CanUpgradeShip(Ship ship);

	protected abstract PortActionInfo CanRenameShip(Ship ship);

	protected abstract PortActionInfo CanSendToClan(Ship ship);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool AreThereAnyChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBuyShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSellShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnRepairShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSendToClan(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnRenameShip(Ship ship, string newName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnResetShipName(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnResetShipUpgrade(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUpgradePieceSelected(Ship ship, string shipSlotTag, ShipUpgradePiece piece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFigureheadSelected(Ship ship, Figurehead figurehead)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearCurrentFigurehead(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReequipPreviousFigurehead(Ship ship)
	{
		throw null;
	}
}
