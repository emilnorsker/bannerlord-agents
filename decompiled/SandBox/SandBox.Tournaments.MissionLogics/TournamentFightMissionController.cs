using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.TournamentGames;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Tournaments.MissionLogics;

public class TournamentFightMissionController : MissionLogic, ITournamentGameBehavior
{
	private readonly CharacterObject _defaultWeaponTemplatesIdTeamSizeOne;

	private readonly CharacterObject _defaultWeaponTemplatesIdTeamSizeTwo;

	private readonly CharacterObject _defaultWeaponTemplatesIdTeamSizeFour;

	private TournamentMatch _match;

	private bool _isLastRound;

	private BasicMissionTimer _endTimer;

	private BasicMissionTimer _cheerTimer;

	private List<GameEntity> _spawnPoints;

	private bool _isSimulated;

	private bool _forceEndMatch;

	private bool _cheerStarted;

	private CultureObject _culture;

	private List<TournamentParticipant> _aliveParticipants;

	private List<TournamentTeam> _aliveTeams;

	private List<Agent> _currentTournamentAgents;

	private List<Agent> _currentTournamentMountAgents;

	private const float XpShareForKill = 0.5f;

	private const float XpShareForDamage = 0.5f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TournamentFightMissionController(CultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrepareForMatch()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartMatch(TournamentMatch match, bool isLastRound)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnTournamentParticipant(GameEntity spawnPoint, TournamentParticipant participant, Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<Equipment> GetTeamWeaponEquipmentList(int teamSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SkipMatch(TournamentMatch match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMatchEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMatchResultsReady()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMatchEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAgentWithRandomItems(TournamentParticipant participant, Team team, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRandomClothes(CultureObject culture, TournamentParticipant participant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfTeamIsDead(TournamentTeam affectedParticipantTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddScoreToRemainingTeams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanAgentRout(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, bool isSiegeEngineHit, in Blow blow, in AttackCollisionData collisionData, float damagedHp, float hitDistance, float shotDifficulty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnemyHitReward(Agent affectedAgent, Agent affectorAgent, float lastSpeedBonus, float lastShotDifficulty, WeaponComponentData lastAttackerWeapon, AgentAttackType attackType, float hitpointRatio, float damageAmount, bool isSneakAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfIsThereAnyEnemies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Simulate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsThereAnyPlayerAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SkipMatch()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override InquiryData OnEndMissionRequest(out bool canPlayerLeave)
	{
		throw null;
	}
}
