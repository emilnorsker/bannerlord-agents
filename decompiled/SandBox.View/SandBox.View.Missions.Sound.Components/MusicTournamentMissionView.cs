using System.Runtime.CompilerServices;
using SandBox.Tournaments.MissionLogics;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions.Sound.Components;

public class MusicTournamentMissionView : MissionView, IMusicHandler
{
	private enum ArenaIntensityLevel
	{
		None,
		Low,
		Mid,
		High
	}

	private enum ReactionType
	{
		Positive,
		Negative,
		End
	}

	private const string ArenaSoundTag = "arena_sound";

	private const string ArenaIntensityParameterId = "ArenaIntensity";

	private const string ArenaPositiveReactionsSoundId = "event:/mission/ambient/arena/reaction";

	private const string ArenaNegativeReactionsSoundId = "event:/mission/ambient/arena/negative_reaction";

	private const string ArenaTournamentEndSoundId = "event:/mission/ambient/arena/reaction";

	private const int MainAgentKnocksDownAnOpponentBaseIntensityChange = 1;

	private const int MainAgentKnocksDownAnOpponentHeadShotIntensityChange = 3;

	private const int MainAgentKnocksDownAnOpponentMountedTargetIntensityChange = 1;

	private const int MainAgentKnocksDownAnOpponentRangedHitIntensityChange = 1;

	private const int MainAgentKnocksDownAnOpponentMeleeHitIntensityChange = 2;

	private const int MainAgentHeadShotFrom15MetersRangeIntensityChange = 3;

	private const int MainAgentDismountsAnOpponentIntensityChange = 3;

	private const int MainAgentBreaksAShieldIntensityChange = 2;

	private const int MainAgentWinsTournamentRoundIntensityChange = 10;

	private const int RoundEndIntensityChange = 10;

	private const int MainAgentKnocksDownATeamMateIntensityChange = -30;

	private const int MainAgentKnocksDownAFriendlyHorseIntensityChange = -20;

	private int _currentTournamentIntensity;

	private ArenaIntensityLevel _arenaIntensityLevel;

	private bool _allOneShotSoundEventsAreDisabled;

	private TournamentBehavior _tournamentBehavior;

	private TournamentMatch _currentMatch;

	private TournamentMatch _lastMatch;

	private GameEntity _arenaSoundEntity;

	private bool _isFinalRound;

	private bool _fightStarted;

	private Timer _startTimer;

	bool IMusicHandler.IsPausable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIntensityFall()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMusicHandler.OnUpdated(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, bool isSiegeEngineHit, in Blow blow, in AttackCollisionData collisionData, float damagedHp, float hitDistance, float shotDifficulty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissileHit(Agent attacker, Agent victim, bool isCanceled, AttackCollisionData collisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMeleeHit(Agent attacker, Agent victim, bool isCanceled, AttackCollisionData collisionData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAudienceIntensity(int intensityChangeAmount, bool isEnd = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Cheer(ReactionType reactionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTournamentRoundBegin(bool isFinalRound)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTournamentRoundEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicTournamentMissionView()
	{
		throw null;
	}
}
