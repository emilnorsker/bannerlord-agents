using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;

namespace SandBox;

public class SandBoxMissionManager : ISandBoxMissionManager
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenTournamentFightMission(string scene, TournamentGame tournamentGame, Settlement settlement, CultureObject culture, bool isPlayerParticipating)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenTournamentHorseRaceMission(string scene, TournamentGame tournamentGame, Settlement settlement, CultureObject culture, bool isPlayerParticipating)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenTournamentJoustingMission(string scene, TournamentGame tournamentGame, Settlement settlement, CultureObject culture, bool isPlayerParticipating)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IMission OpenTournamentArcheryMission(string scene, TournamentGame tournamentGame, Settlement settlement, CultureObject culture, bool isPlayerParticipating)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IMission ISandBoxMissionManager.OpenBattleChallengeMission(string scene, IList<Hero> priorityCharsAttacker, IList<Hero> priorityCharsDefender)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandBoxMissionManager()
	{
		throw null;
	}
}
