using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.Localization;

namespace NavalDLC.GameComponents;

public class NavalDLCFleetManagementModel : FleetManagementModel
{
	public override int MinimumTroopCountRequiredToSendShips
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanTroopsReturn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override CampaignTime GetReturnTimeForTroops(Ship ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanSendShipToPlayerClan(Ship ship, int playerShipsCount, int troopsCountToSend, out TextObject hint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCFleetManagementModel()
	{
		throw null;
	}
}
