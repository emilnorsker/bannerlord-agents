using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem;

public static class CampaignMission
{
	public interface ICampaignMissionManager
	{
		IMission OpenSiegeMissionWithDeployment(string scene, float[] wallHitPointsPercentages, bool hasAnySiegeTower, List<MissionSiegeWeapon> siegeWeaponsOfAttackers, List<MissionSiegeWeapon> siegeWeaponsOfDefenders, bool isPlayerAttacker, int upgradeLevel = 0, bool isSallyOut = false, bool isReliefForceAttack = false);

		IMission OpenSiegeMissionNoDeployment(string scene, bool isSallyOut = false, bool isReliefForceAttack = false);

		IMission OpenSiegeLordsHallFightMission(string scene, FlattenedTroopRoster attackerPriorityList);

		IMission OpenBattleMission(MissionInitializerRecord rec);

		IMission OpenCaravanBattleMission(MissionInitializerRecord rec, bool isCaravan);

		IMission OpenBattleMission(string scene, bool usesTownDecalAtlas);

		IMission OpenNavalBattleMission(MissionInitializerRecord rec);

		IMission OpenNavalSetPieceBattleMission(MissionInitializerRecord rec, MBList<IShipOrigin> playerShips, MBList<IShipOrigin> playerAllyShips, MBList<IShipOrigin> enemyShips);

		IMission OpenHideoutBattleMission(string scene, FlattenedTroopRoster playerTroops, bool isTutorial);

		IMission OpenTownCenterMission(string scene, int townUpgradeLevel, Location location, CharacterObject talkToChar, string playerSpawnTag);

		IMission OpenCastleCourtyardMission(string scene, int castleUpgradeLevel, Location location, CharacterObject talkToChar);

		IMission OpenVillageMission(string scene, Location location, CharacterObject talkToChar);

		IMission OpenIndoorMission(string scene, int upgradeLevel, Location location, CharacterObject talkToChar);

		IMission OpenPrisonBreakMission(string scene, Location location, CharacterObject prisonerCharacter);

		IMission OpenArenaStartMission(string scene, Location location, CharacterObject talkToChar);

		IMission OpenArenaDuelMission(string scene, Location location, CharacterObject duelCharacter, bool requireCivilianEquipment, bool spawnBOthSidesWithHorse, Action<CharacterObject> onDuelEndAction, float customAgentHealth);

		IMission OpenConversationMission(ConversationCharacterData playerCharacterData, ConversationCharacterData conversationPartnerData, string specialScene = "", string sceneLevels = "", bool isMultiAgentConversation = false);

		IMission OpenMeetingMission(string scene, CharacterObject character);

		IMission OpenAlleyFightMission(string scene, int upgradeLevel, Location location, TroopRoster playerSideTroops, TroopRoster rivalSideTroops);

		IMission OpenCombatMissionWithDialogue(string scene, CharacterObject characterToTalkTo, int upgradeLevel);

		IMission OpenBattleMissionWhileEnteringSettlement(string scene, int upgradeLevel, int numberOfMaxTroopToBeSpawnedForPlayer, int numberOfMaxTroopToBeSpawnedForOpponent);

		IMission OpenRetirementMission(string scene, Location location, CharacterObject talkToChar = null, string sceneLevels = null, string unconsciousMenuId = "");

		IMission OpenHideoutAmbushMission(string sceneName, FlattenedTroopRoster playerTroops, Location location);

		IMission OpenDisguiseMission(string scene, bool willSetUpContact, string sceneLevels, Location fromLocation);
	}

	public static ICampaignMission Current
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenBattleMission(string scene, bool usesTownDecalAtlas)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenAlleyFightMission(string scene, int upgradeLevel, Location location, TroopRoster playerSideTroops, TroopRoster rivalSideTroops)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenCombatMissionWithDialogue(string scene, CharacterObject characterToTalkTo, int upgradeLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenBattleMissionWhileEnteringSettlement(string scene, int upgradeLevel, int numberOfMaxTroopToBeSpawnedForPlayer, int numberOfMaxTroopToBeSpawnedForOpponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenHideoutBattleMission(string scene, FlattenedTroopRoster playerTroops, bool isTutorial)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenSiegeMissionWithDeployment(string scene, float[] wallHitPointsPercentages, bool hasAnySiegeTower, List<MissionSiegeWeapon> siegeWeaponsOfAttackers, List<MissionSiegeWeapon> siegeWeaponsOfDefenders, bool isPlayerAttacker, int upgradeLevel = 0, bool isSallyOut = false, bool isReliefForceAttack = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenSiegeMissionNoDeployment(string scene, bool isSallyOut = false, bool isReliefForceAttack = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenSiegeLordsHallFightMission(string scene, FlattenedTroopRoster attackerPriorityList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenBattleMission(MissionInitializerRecord rec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenNavalBattleMission(MissionInitializerRecord rec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenNavalSetPieceBattleMission(MissionInitializerRecord rec, MBList<IShipOrigin> playerShips, MBList<IShipOrigin> playerAllyShips, MBList<IShipOrigin> enemyShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenCaravanBattleMission(MissionInitializerRecord rec, bool isCaravan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenTownCenterMission(string scene, Location location, CharacterObject talkToChar, int townUpgradeLevel, string playerSpawnTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenCastleCourtyardMission(string scene, Location location, CharacterObject talkToChar, int castleUpgradeLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenVillageMission(string scene, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenIndoorMission(string scene, int upgradeLevel, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenPrisonBreakMission(string scene, Location location, CharacterObject prisonerCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenArenaStartMission(string scene, Location location, CharacterObject talkToChar)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenArenaDuelMission(string scene, Location location, CharacterObject talkToChar, bool requireCivilianEquipment, bool spawnBothSidesWithHorse, Action<CharacterObject> onDuelEnd, float customAgentHealth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenConversationMission(ConversationCharacterData playerCharacterData, ConversationCharacterData conversationPartnerData, string specialScene = "", string sceneLevels = "", bool isMultiAgentConversation = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenRetirementMission(string scene, Location location, CharacterObject talkToChar = null, string sceneLevels = null, string unconsciousMenuId = "")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenHideoutAmbushMission(string sceneName, FlattenedTroopRoster playerTroops, Location location)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IMission OpenDisguiseMission(string scene, bool willSetUpContact, string sceneLevels, Location fromLocation)
	{
		throw null;
	}
}
