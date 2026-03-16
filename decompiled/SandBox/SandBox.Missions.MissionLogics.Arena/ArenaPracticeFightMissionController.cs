using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics.Arena;

public class ArenaPracticeFightMissionController : MissionLogic
{
	private const int AIParticipantCount = 30;

	private const int MaxAliveAgentCount = 6;

	private const int MaxSpawnInterval = 14;

	private const int MinSpawnDistanceSquared = 144;

	private const int TotalStageCount = 3;

	private const int PracticeFightTroopTierLimit = 3;

	public int TeleportTime;

	private Settlement _settlement;

	private int _spawnedOpponentAgentCount;

	private int _aliveOpponentCount;

	private float _nextSpawnTime;

	private List<MatrixFrame> _initialSpawnFrames;

	private List<MatrixFrame> _spawnFrames;

	private List<Team> _AIParticipantTeams;

	private List<Agent> _participantAgents;

	private Team _tournamentMasterTeam;

	private BasicMissionTimer _teleportTimer;

	private List<CharacterObject> _participantCharacters;

	private const float XpShareForKill = 0.5f;

	private const float XpShareForDamage = 0.5f;

	private int AISpawnIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int RemainingOpponentCountFromLastPractice
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

	public bool IsPlayerPracticing
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

	public int OpponentCountBeatenByPlayer
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

	public int RemainingOpponentCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsPlayerSurvived
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

	public bool AfterPractice
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
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayerNearTournamentMaster()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnArenaAgent(Team team, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, bool isSiegeEngineHit, in Blow blow, in AttackCollisionData collisionData, float damagedHp, float hitDistance, float shotDifficulty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnemyHitReward(Agent affectedAgent, Agent affectorAgent, float lastSpeedBonus, float lastShotDifficulty, WeaponComponentData attackerWeapon, AgentAttackType attackType, float hitpointRatio, float damageAmount, bool isSneakAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Team SelectRandomAiTeam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override InquiryData OnEndMissionRequest(out bool canPlayerLeave)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartPlayerPractice()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartPractice()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckPracticeEndedForPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRandomWeapons(Equipment equipment, int spawnIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddRandomClothes(CharacterObject troop, Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeTeams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeParticipantCharacters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<CharacterObject> GetParticipantCharacters(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GetUpgradeTargets(CharacterObject troop, ref List<CharacterObject> list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ArrangePlayerTeamEnmity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Team GetStrongestTeamExceptPlayerTeam()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int CalculateTeamPower(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetSpawnFrame(bool considerPlayerDistance, bool isInitialSpawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float CalculateLocationScore(MatrixFrame matrixFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArenaPracticeFightMissionController()
	{
		throw null;
	}
}
