using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.CustomBattle;

[MissionManager]
public static class CustomNavalMissions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AtmosphereInfo CreateAtmosphereInfoForMission(string seasonId, int timeOfDay, float windStrength, Vec2 windDirection, TerrainType terrain)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenNavalBattleForCustomMission(string scene, BasicCharacterObject playerCharacter, CustomBattleCombatant playerParty, MBList<IShipOrigin> playerTeamShips, CustomBattleCombatant enemyParty, MBList<IShipOrigin> enemyTeamShips, bool isPlayerGeneral, string seasonString, float timeOfDay, float windStrength, NavalCustomBattleWindConfig.Direction windDirection, TerrainType terrain)
	{
		throw null;
	}
}
