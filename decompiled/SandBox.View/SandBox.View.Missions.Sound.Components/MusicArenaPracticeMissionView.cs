using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions.Sound.Components;

public class MusicArenaPracticeMissionView : MissionView, IMusicHandler
{
	private enum ArenaIntensityLevel
	{
		None,
		Low,
		Mid,
		High
	}

	private const string ArenaSoundTag = "arena_sound";

	private const string ArenaIntensityParameterId = "ArenaIntensity";

	private const string ArenaPositiveReactionsSoundId = "event:/mission/ambient/arena/reaction";

	private const int MainAgentKnocksDownAnOpponentBaseIntensityChange = 1;

	private const int MainAgentKnocksDownAnOpponentHeadShotIntensityChange = 3;

	private const int MainAgentKnocksDownAnOpponentMountedTargetIntensityChange = 1;

	private const int MainAgentKnocksDownAnOpponentRangedHitIntensityChange = 1;

	private const int MainAgentKnocksDownAnOpponentMeleeHitIntensityChange = 2;

	private const int MainAgentHeadShotFrom15MetersRangeIntensityChange = 3;

	private const int MainAgentDismountsAnOpponentIntensityChange = 3;

	private const int MainAgentBreaksAShieldIntensityChange = 2;

	private int _currentTournamentIntensity;

	private ArenaIntensityLevel _currentArenaIntensityLevel;

	private bool _allOneShotSoundEventsAreDisabled;

	private GameEntity _arenaSoundEntity;

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
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
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
	private void UpdateAudienceIntensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Cheer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnUpdated(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicArenaPracticeMissionView()
	{
		throw null;
	}
}
