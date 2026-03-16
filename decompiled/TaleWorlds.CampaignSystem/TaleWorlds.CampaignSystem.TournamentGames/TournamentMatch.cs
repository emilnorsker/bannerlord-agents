using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.TournamentGames;

public class TournamentMatch
{
	public enum MatchState
	{
		Ready,
		Started,
		Finished
	}

	private readonly int _numberOfWinnerParticipants;

	public readonly TournamentGame.QualificationMode QualificationMode;

	private readonly TournamentTeam[] _teams;

	private readonly List<TournamentParticipant> _participants;

	private List<TournamentParticipant> _winners;

	private readonly int _participantCount;

	private int _teamSize;

	public IEnumerable<TournamentTeam> Teams
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IEnumerable<TournamentParticipant> Participants
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MatchState State
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public IEnumerable<TournamentParticipant> Winners
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsReady
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TournamentMatch(int participantCount, int numberOfTeamsPerMatch, int numberOfWinnerParticipants, TournamentGame.QualificationMode qualificationMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void End()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Start()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TournamentParticipant GetParticipant(int uniqueSeed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsParticipantRequired()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddParticipant(TournamentParticipant participant, bool firstTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlayerParticipating()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPlayerWinner()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TournamentParticipant> GetWinners()
	{
		throw null;
	}
}
