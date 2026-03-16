using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace SandBox.CampaignBehaviors;

public class GuardsCampaignBehavior : CampaignBehaviorBase
{
	public const float UnarmedTownGuardSpawnRate = 0.4f;

	private readonly List<(CharacterObject, int)> _garrisonTroops;

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
	private float GetProsperityMultiplier(SettlementComponent settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGarrisonAndPrisonCharacters(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeGarrisonCharacters(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LocationCharactersAreReadyToSpawn(Dictionary<string, int> unusedUsablePointCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddGuardsFromGarrison(Settlement settlement, Dictionary<string, int> unusedUsablePointCount, Location location)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ItemObject GetSuitableSpear(CultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AgentData TakeGuardAgentDataFromGarrisonTroopList(CultureObject culture, bool overrideWeaponWithSpear = false, bool unarmed = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static AgentData PrepareGuardAgentDataFromGarrison(CharacterObject guardRosterElement, bool overrideWeaponWithSpear = false, bool unarmed = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IfEquipmentHasSpearSwapSlots(Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveShields(Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateCastleGuard(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateStandGuard(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateStandGuardWithSpear(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreateUnarmedGuard(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreatePatrollingGuard(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private LocationCharacter CreatePrisonGuard(CultureObject culture, CharacterRelations relation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void AddDialogs(CampaignGameStarter campaignGameStarter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_prison_guard_criminal_start_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_prison_guard_start_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_prison_guard_talk_about_prisoners_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_prison_guard_visit_prison_cheat_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool can_player_bribe_to_prison_guard_clickable(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_prison_guard_reject_visit_prison_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_prison_guard_visit_prison_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_guard_start_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfConversationAgentIsEscortingTheMainAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_prison_guard_visit_prison_nobody_inside_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool prison_guard_visit_permission_try_bribe_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_prison_guard_visit_permission_bribe_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_prison_guard_visit_break_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsCastleGuard()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_castle_guard_start_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_castle_guard_criminal_start_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_castle_guard_nobody_inside_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_castle_guard_player_can_enter_lordshall_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_bribe_to_enter_lords_hall_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void conversation_player_bribe_to_enter_lords_hall_on_consequence()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_player_bribe_to_enter_lords_hall_on_clickable_condition(out TextObject explanation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenLordsHallMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_disguised_start_on_condition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool conversation_disguised_start_on_condition_alt()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GuardsCampaignBehavior()
	{
		throw null;
	}
}
