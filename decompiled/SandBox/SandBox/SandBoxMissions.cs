using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace SandBox;

[MissionManager]
public static class SandBoxMissions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionInitializerRecord CreateSandBoxMissionInitializerRecord(string sceneName, string sceneLevels, bool doNotUseLoadingScreen, DecalAtlasGroup decalAtlasGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionInitializerRecord CreateSandBoxTrainingMissionInitializerRecord(string sceneName, string sceneLevels = "", bool doNotUseLoadingScreen = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenTownCenterMission(string scene, int townUpgradeLevel, Location location, CharacterObject talkToChar, string playerSpawnTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenTownCenterMission(string scene, string sceneLevels, Location location, CharacterObject talkToChar, string playerSpawnTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenTownCenterShadowATargetMission(string scene, string sceneLevels, Location location, CharacterObject talkToChar, string playerSpawnTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenCastleCourtyardMission(string scene, int castleUpgradeLevel, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenCastleCourtyardMission(string scene, string sceneLevels, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenIndoorMission(string scene, int townUpgradeLevel, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenIndoorMission(string scene, Location location, CharacterObject talkToChar = null, string sceneLevels = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenPrisonBreakMission(string scene, Location location, CharacterObject prisonerCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenVillageMission(string scene, Location location, CharacterObject talkToChar = null, string sceneLevels = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenArenaStartMission(string scene, Location location, CharacterObject talkToChar = null, string sceneLevels = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenRetirementMission(string scene, Location location, CharacterObject talkToChar = null, string sceneLevels = null, string unconsciousMenuId = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenArenaDuelMission(string scene, Location location, CharacterObject duelCharacter, bool requireCivilianEquipment, bool spawnBOthSidesWithHorse, Action<CharacterObject> onDuelEnd, float customAgentHealth, string sceneLevels = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenArenaDuelMission(string scene, Location location)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenBattleMission(MissionInitializerRecord rec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenCaravanBattleMission(MissionInitializerRecord rec, bool isCaravan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenAlleyFightMission(MissionInitializerRecord rec, Location location, TroopRoster playerSideTroops, TroopRoster rivalSideTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenCombatMissionWithDialogue(MissionInitializerRecord rec, CharacterObject characterToTalkTo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenBattleMissionWhileEnteringSettlement(string scene, int upgradeLevel, int numberOfMaxTroopToBeSpawnedForPlayer, int numberOfMaxTroopToBeSpawnedForOpponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenBattleMission(string scene, bool usesTownDecalAtlas)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenAlleyFightMission(string scene, int upgradeLevel, Location location, TroopRoster playerSideTroops, TroopRoster rivalSideTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenCombatMissionWithDialogue(string scene, CharacterObject characterToTalkTo, int upgradeLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenHideoutBattleMission(string scene, FlattenedTroopRoster playerTroops, bool isTutorial)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod(UsableByEditor = true)]
	public static Mission OpenHideoutAmbushMission(string sceneName, FlattenedTroopRoster playerTroops, Location location)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenCampMission(string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenSiegeMissionWithDeployment(string scene, float[] wallHitPointPercentages, bool hasAnySiegeTower, List<MissionSiegeWeapon> siegeWeaponsOfAttackers, List<MissionSiegeWeapon> siegeWeaponsOfDefenders, bool isPlayerAttacker, int sceneUpgradeLevel = 0, bool isSallyOut = false, bool isReliefForceAttack = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenSiegeMissionNoDeployment(string scene, bool isSallyOut = false, bool isReliefForceAttack = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenSiegeLordsHallFightMission(string scene, FlattenedTroopRoster attackerPriorityList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenVillageBattleMission(string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenConversationMission(ConversationCharacterData playerCharacterData, ConversationCharacterData conversationPartnerData, string specialScene = "", string sceneLevels = "", bool isMultiAgentConversation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenMeetingMission(string scene, CharacterObject character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Settlement GetCurrentTown()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MissionAgentSpawnLogic CreateCampaignMissionAgentSpawnLogic(BattleSizeType battleSizeType, FlattenedTroopRoster priorTroopsForDefenders = null, FlattenedTroopRoster priorTroopsForAttackers = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenDisguiseMission(string scene, bool willSetUpContact, Location fromLocation, string sceneLevels = null)
	{
		throw null;
	}
}
