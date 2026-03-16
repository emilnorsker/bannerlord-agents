using System.Runtime.CompilerServices;
using NavalDLC.Storyline.MissionControllers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions;

[MissionManager]
public static class NavalMissions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenNavalBattleMission(MissionInitializerRecord rec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenNavalSetPieceBattleMission(MissionInitializerRecord rec, MBList<IShipOrigin> playerShips, MBList<IShipOrigin> playerAllyShips, MBList<IShipOrigin> enemyShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenBlockedEstuaryMission(MissionInitializerRecord rec, MobileParty enemyParty, bool startFromCheckPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenNavalStorylineCaptivityMission(MissionInitializerRecord rec, CharacterObject allyCharacter, CharacterObject enemyCharacter, CharacterObject crewCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenNavalStorylinePirateBattleMission(MissionInitializerRecord rec, MobileParty pirateParty, int pirateTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenNavalStorylineQuest5SetPieceBattleMission(MissionInitializerRecord rec, MobileParty enemyParty, Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState lastHitCheckpoint = Quest5SetPieceBattleMissionController.Quest5SetPieceBattleMissionState.InitializePhase1Part1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenNavalFinalConversationMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenNavalStorylineWoundedBeastBattleMission(MissionInitializerRecord rec)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenHelpingAnAllySetPieceBattleMission(MissionInitializerRecord rec, MobileParty merchantParty, MobileParty seaHoundsParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenFloatingFortressSetPieceBattleMission(MissionInitializerRecord rec, bool startFromCheckpoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenNavalStorylineAlleyFightMission(MissionInitializerRecord rec)
	{
		throw null;
	}
}
