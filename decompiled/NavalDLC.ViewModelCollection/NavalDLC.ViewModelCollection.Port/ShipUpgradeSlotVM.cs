using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace NavalDLC.ViewModelCollection.Port;

public class ShipUpgradeSlotVM : ShipUpgradeSlotBaseVM
{
	private readonly ShipUpgradePiece _initialSelectedPiece;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ShipUpgradeSlotVM(Ship ship, TextObject slotName, string shipSlotTag, string slotTypeId, Action<ShipUpgradeSlotBaseVM> onSelected)
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
}
