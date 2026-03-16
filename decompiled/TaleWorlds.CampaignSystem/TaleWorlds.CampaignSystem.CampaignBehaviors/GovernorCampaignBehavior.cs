using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class GovernorCampaignBehavior : CampaignBehaviorBase
{
	private const int CultureDialogueOptionCount = 3;

	private List<CultureObject> _availablePlayerKingdomCultures;

	private int _kingdomCreationCurrentCulturePageIndex;

	private CultureObject _kingdomCreationChosenCulture;

	private TextObject _kingdomCreationChosenName;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTickSettlement(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroChangedClan(Hero hero, Clan oldClan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddDialogs(CampaignGameStarter starter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterAction.KillCharacterActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_talk_start_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_talk_start_reply_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_talk_kingdom_creation_start_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void governor_talk_kingdom_creation_start_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_talk_kingdom_creation_start_clickable_condition(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_talk_kingdom_creation_culture_option_0_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_talk_kingdom_creation_culture_option_1_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_talk_kingdom_creation_culture_option_2_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleAvailableCultureConditionAndText(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetCultureIndex(int optionIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void governor_talk_kingdom_creation_culture_option_0_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void governor_talk_kingdom_creation_culture_option_1_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void governor_talk_kingdom_creation_culture_option_2_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_talk_kingdom_creation_culture_other_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void governor_talk_kingdom_creation_culture_other_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_kingdom_creation_culture_selected_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void governor_talk_kingdom_creation_name_selection_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnKingdomNameSelectionDone(string chosenName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnKingdomNameSelectionCancel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool governor_talk_kingdom_creation_finalization_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void governor_talk_kingdom_creation_finalization_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GovernorCampaignBehavior()
	{
		throw null;
	}
}
