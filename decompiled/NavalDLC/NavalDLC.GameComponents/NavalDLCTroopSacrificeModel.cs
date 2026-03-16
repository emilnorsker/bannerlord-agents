using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace NavalDLC.GameComponents;

public class NavalDLCTroopSacrificeModel : TroopSacrificeModel
{
	private const int MinNumberOfShipsForSacrificeShips = 2;

	public override int BreakOutArmyLeaderRelationPenalty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int BreakOutArmyMemberRelationPenalty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetLostTroopCountForBreakingInBesiegedSettlement(MobileParty party, SiegeEvent siegeEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ExplainedNumber GetLostTroopCountForBreakingOutOfBesiegedSettlement(MobileParty party, SiegeEvent siegeEvent, bool isBreakingOutFromPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetNumberOfTroopsSacrificedForTryingToGetAway(BattleSideEnum battleSide, MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CanPlayerSideTryToGetAwayWithTheirShipStats(out float totalDamageToApply)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetShipsToSacrificeForTryingToGetAway(BattleSideEnum playerBattleSide, MapEvent mapEvent, out MBList<Ship> shipsToCapture, out Ship shipToTakeDamage, out float damageToApplyForLastShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Ship GetShipToSacrifice(float maxHitPointScore, List<Ship> shipsToSacrifice)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static float GetShipSacrificeScore(Ship shipToConsider, int maxOwnedShipCount, int ownerCurrentShipCount, float maxHitPointScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanPlayerGetAwayFromEncounter(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCTroopSacrificeModel()
	{
		throw null;
	}
}
