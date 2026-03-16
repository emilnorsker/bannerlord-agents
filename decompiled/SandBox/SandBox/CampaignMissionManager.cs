using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace SandBox;

public class CampaignMissionManager : ICampaignMissionManager
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenSiegeMissionWithDeployment(string scene, float[] wallHitPointsPercentages, bool hasAnySiegeTower, List<MissionSiegeWeapon> siegeWeaponsOfAttackers, List<MissionSiegeWeapon> siegeWeaponsOfDefenders, bool isPlayerAttacker, int upgradeLevel, bool isSallyOut, bool isReliefForceAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenSiegeMissionNoDeployment(string scene, bool isSallyOut, bool isReliefForceAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenSiegeLordsHallFightMission(string scene, FlattenedTroopRoster attackerPriorityList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenBattleMission(MissionInitializerRecord rec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenCaravanBattleMission(MissionInitializerRecord rec, bool isCaravan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenBattleMission(string scene, bool usesTownDecalAtlas)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenAlleyFightMission(string scene, int upgradeLevel, Location location, TroopRoster playerSideTroops, TroopRoster rivalSideTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenCombatMissionWithDialogue(string scene, CharacterObject characterToTalkTo, int upgradeLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenBattleMissionWhileEnteringSettlement(string scene, int upgradeLevel, int numberOfMaxTroopToBeSpawnedForPlayer, int numberOfMaxTroopToBeSpawnedForOpponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenHideoutBattleMission(string scene, FlattenedTroopRoster playerTroops, bool isTutorial)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenTownCenterMission(string scene, int townUpgradeLevel, Location location, CharacterObject talkToChar, string playerSpawnTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenCastleCourtyardMission(string scene, int castleUpgradeLevel, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenVillageMission(string scene, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenIndoorMission(string scene, int upgradeLevel, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenPrisonBreakMission(string scene, Location location, CharacterObject prisonerCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenArenaStartMission(string scene, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenArenaDuelMission(string scene, Location location, CharacterObject duelCharacter, bool requireCivilianEquipment, bool spawnBOthSidesWithHorse, Action<CharacterObject> onDuelEndAction, float customAgentHealth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenConversationMission(ConversationCharacterData playerCharacterData, ConversationCharacterData conversationPartnerData, string specialScene, string sceneLevels, bool isMultiAgentConversation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenMeetingMission(string scene, CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenRetirementMission(string scene, Location location, CharacterObject talkToChar, string sceneLevels, string unconsciousMenuId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ICampaignMissionManager.OpenHideoutAmbushMission(string sceneName, FlattenedTroopRoster playerTroops, Location location)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenDisguiseMission(string scene, bool willSetUpContact, string sceneLevels, Location fromLocation)
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
	public CampaignMissionManager()
	{
		throw null;
	}
}
