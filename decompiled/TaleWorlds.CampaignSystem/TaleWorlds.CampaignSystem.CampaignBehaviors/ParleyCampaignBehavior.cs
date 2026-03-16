using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class ParleyCampaignBehavior : CampaignBehaviorBase, IParleyCampaignBehavior
{
	private PartyBase _parleyedParty;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartParley(PartyBase partyBase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddMenus(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void game_menu_town_menu_request_meeting_on_init(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_menu_request_meeting_with_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void game_menu_request_meeting_town_leave_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void game_menu_request_meeting_castle_leave_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SettlementMenuLeaveConsequenceCommon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void game_menu_request_meeting_with_on_consequence(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetMeetingScene(out string sceneLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_meeting_town_leave_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool game_meeting_castle_leave_on_condition(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ParleyCampaignBehavior()
	{
		throw null;
	}
}
