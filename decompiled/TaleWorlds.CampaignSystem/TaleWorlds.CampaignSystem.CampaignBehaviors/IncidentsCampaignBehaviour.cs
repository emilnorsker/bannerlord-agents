using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.CampaignSystem.Incidents;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class IncidentsCampaignBehaviour : CampaignBehaviorBase, INonReadyObjectHandler
{
	[Flags]
	public enum IncidentTrigger
	{
		LeavingVillage = 1,
		LeavingTown = 2,
		LeavingCastle = 4,
		LeavingSettlement = 8,
		LeavingEncounter = 0x10,
		LeavingBattle = 0x20,
		EnteringVillage = 0x40,
		EnteringTown = 0x80,
		EnteringCastle = 0x100,
		WaitingInSettlement = 0x200,
		DuringSiege = 0x400
	}

	public enum IncidentType
	{
		TroopSettlementRelation,
		FoodConsumption,
		PlightOfCivilians,
		PartyCampLife,
		AnimalIllness,
		Illness,
		HuntingForaging,
		PostBattle,
		HardTravel,
		Profit,
		DreamsSongsAndSigns,
		FiefManagement,
		Siege,
		Workshop
	}

	private CampaignTime _lastGlobalIncidentCooldown;

	private Dictionary<Incident, CampaignTime> _incidentsOnCooldown;

	private long _activeIncidentSeed;

	private bool _canInvokeSettlementEvent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnIncidentResolved(Incident incident)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementEntered(MobileParty mobileParty, Settlement settlement, Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementLeft(MobileParty mobileParty, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreated(CampaignGameStarter obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void INonReadyObjectHandler.OnBeforeNonReadyObjectsDeleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ConversationEnded(IEnumerable<CharacterObject> conversationCharacters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnded(MapEvent evt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameMenuOpened(MenuCallbackArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGameMenuOptionSelected(GameMenu gameMenu, GameMenuOption option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeirSelectionOver(Hero obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryInvokeIncident(IncidentTrigger trigger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CampaignTime GetCooldownTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIncidentsOnCooldown()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IReadOnlyList<Incident> GetOccurableEventsForTrigger(IncidentTrigger trigger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeIncident(Incident incident)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Incident RegisterIncident(string id, string title, string description, IncidentTrigger trigger, IncidentType type, CampaignTime cooldown, Func<TextObject, bool> condition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeIncidents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IncidentsCampaignBehaviour()
	{
		throw null;
	}
}
