using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSettlementAccessModel : SettlementAccessModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanMainHeroEnterSettlement(Settlement settlement, out AccessDetails accessDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanMainHeroEnterDungeon(Settlement settlement, out AccessDetails accessDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CanMainHeroEnterLordsHall(Settlement settlement, out AccessDetails accessDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanMainHeroEnterKeepInternal(Settlement settlement, out AccessDetails accessDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanMainHeroAccessLocation(Settlement settlement, string locationId, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsRequestMeetingOptionAvailable(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanMainHeroDoSettlementAction(Settlement settlement, SettlementAction settlementAction, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroGoToArena(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroGoToTavern(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroEnterArena(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanMainHeroEnterVillage(Settlement settlement, out AccessDetails accessDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroManageTown(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanMainHeroEnterCastle(Settlement settlement, out AccessDetails accessDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CanMainHeroEnterTown(Settlement settlement, out AccessDetails accessDetails)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroWalkAroundTownCenter(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroRecruitTroops(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroCraft(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroJoinTournament(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroWatchTournament(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroTrade(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanMainHeroWaitInSettlement(Settlement settlement, out bool disableOption, out TextObject disabledText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSettlementAccessModel()
	{
		throw null;
	}
}
