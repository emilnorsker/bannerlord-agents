using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace NavalDLC.Missions;

public class NavalMissionManager : ICampaignMissionManager
{
	private readonly ICampaignMissionManager _baseMissionManager;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMissionManager(ICampaignMissionManager baseMissionManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenNavalBattleMission(MissionInitializerRecord rec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenNavalSetPieceBattleMission(MissionInitializerRecord rec, MBList<IShipOrigin> playerShips, MBList<IShipOrigin> playerAllyShips, MBList<IShipOrigin> enemyShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenAlleyFightMission(string scene, int upgradeLevel, Location location, TroopRoster playerSideTroops, TroopRoster rivalSideTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenArenaDuelMission(string scene, Location location, CharacterObject duelCharacter, bool requireCivilianEquipment, bool spawnBOthSidesWithHorse, Action<CharacterObject> onDuelEndAction, float customAgentHealth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenArenaStartMission(string scene, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenBattleMission(MissionInitializerRecord rec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenBattleMission(string scene, bool usesTownDecalAtlas)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenBattleMissionWhileEnteringSettlement(string scene, int upgradeLevel, int numberOfMaxTroopToBeSpawnedForPlayer, int numberOfMaxTroopToBeSpawnedForOpponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenCaravanBattleMission(MissionInitializerRecord rec, bool isCaravan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenCastleCourtyardMission(string scene, int castleUpgradeLevel, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenCombatMissionWithDialogue(string scene, CharacterObject characterToTalkTo, int upgradeLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenConversationMission(ConversationCharacterData playerCharacterData, ConversationCharacterData conversationPartnerData, string specialScene = "", string sceneLevels = "", bool isMultiAgentConversation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenHideoutBattleMission(string scene, FlattenedTroopRoster playerTroops, bool isTutorial)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenIndoorMission(string scene, int upgradeLevel, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenMeetingMission(string scene, CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenPrisonBreakMission(string scene, Location location, CharacterObject prisonerCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenRetirementMission(string scene, Location location, CharacterObject talkToChar = null, string sceneLevels = null, string unconsciousMenuId = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenSiegeLordsHallFightMission(string scene, FlattenedTroopRoster attackerPriorityList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenSiegeMissionNoDeployment(string scene, bool isSallyOut = false, bool isReliefForceAttack = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenSiegeMissionWithDeployment(string scene, float[] wallHitPointsPercentages, bool hasAnySiegeTower, List<MissionSiegeWeapon> siegeWeaponsOfAttackers, List<MissionSiegeWeapon> siegeWeaponsOfDefenders, bool isPlayerAttacker, int upgradeLevel = 0, bool isSallyOut = false, bool isReliefForceAttack = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenTownCenterMission(string scene, int townUpgradeLevel, Location location, CharacterObject talkToChar, string playerSpawnTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenVillageMission(string scene, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenHideoutAmbushMission(string sceneName, FlattenedTroopRoster playerTroops, Location location)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenDisguiseMission(string scene, bool willSetUpContact, string sceneLevels, Location fromLocation)
	{
		throw null;
	}
}
