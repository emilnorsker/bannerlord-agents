using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace NavalDLC.ViewModelCollection.Port.PortScreenHandlers;

public class PortScreenStoryModeHandler : PortScreenHandler
{
	private readonly PartyBase _leftParty;

	private readonly PartyBase _rightParty;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PortScreenStoryModeHandler(PartyBase leftParty, PartyBase rightParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetLeftRosterName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetRightRosterName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PartyBase GetLeftSideOwnerParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override PartyBase GetRightSideOwnerParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetTradeCostOfShip(Ship ship, bool isRightSideSelling)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetRepairCostOfShip(Ship ship, bool isRightSideRepairing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetUpgradeCostOfShip(Ship ship, ShipUpgradePiece piece, bool isRightSideUpgrading)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetTotalGoldCost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool GetCanConfirm(out TextObject disabledHint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnConfirmChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PortActionInfo CanBuyShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PortActionInfo CanSellShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PortActionInfo CanRenameShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PortActionInfo CanRepairShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PortActionInfo CanRepairAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PortActionInfo CanUpgradeShip(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override PortActionInfo CanSendToClan(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<PortChangeInfo> GetChanges()
	{
		throw null;
	}
}
