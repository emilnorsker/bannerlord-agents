using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class PerkResetCampaignBehavior : CampaignBehaviorBase
{
	private Hero _heroForPerkReset;

	private CharacterAttribute _attributeForPerkReset;

	private SkillObject _selectedSkillForReset;

	private CampaignTime _warningTime;

	public int PerkResetCost
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool HasEnoughSkillValueForReset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

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
	public void OnSessionLaunched(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddDialogs(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPerkReset(Hero hero, PerkObject perk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_player_has_single_clan_member_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_skill_not_developed_enough_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_arena_skill_not_developed_enough_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_finish_perk_reset_dialogs_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_train_another_skill_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_train_another_clan_member_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_player_accept_perk_reset_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_arena_player_accept_price(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_player_select_skill_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_arena_ask_price_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_arena_player_select_skill_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_set_skills_for_reset_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_list_perks_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_player_select_attribute_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_arena_player_select_attribute_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_player_select_clan_member_for_perk_reset_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_player_select_player_for_perk_reset_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_arena_list_clan_members_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_arena_player_select_clan_member_multiple_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_has_multiple_clan_members_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_has_single_clan_member_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DailyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetHeroesForDialog()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAttributesForDialog()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSkillsForDialog()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetPerkTreeForHero(Hero hero, SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearPermanentBonusesIfExists(Hero hero, PerkObject perk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearPerksForSkill(Hero hero, SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveACompanionFromPlayerParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WarnPlayerAboutCompanionLimit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<Hero> GetClanMembersInParty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PerkResetCampaignBehavior()
	{
		throw null;
	}
}
