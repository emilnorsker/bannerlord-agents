using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.MountAndBlade;

namespace SandBox.Tournaments;

[MissionManager]
public static class TournamentMissionStarter
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenTournamentArcheryMission(string scene, TournamentGame tournamentGame, Settlement settlement, CultureObject culture, bool isPlayerParticipating)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenTournamentFightMission(string scene, TournamentGame tournamentGame, Settlement settlement, CultureObject culture, bool isPlayerParticipating)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenTournamentHorseRaceMission(string scene, TournamentGame tournamentGame, Settlement settlement, CultureObject culture, bool isPlayerParticipating)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenTournamentJoustingMission(string scene, TournamentGame tournamentGame, Settlement settlement, CultureObject culture, bool isPlayerParticipating)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MissionMethod]
	public static Mission OpenBattleChallengeMission(string scene, IList<Hero> priorityCharsAttacker, IList<Hero> priorityCharsDefender)
	{
		throw null;
	}
}
