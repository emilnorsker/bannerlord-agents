using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.AgentBehaviors;

public class AlarmedBehaviorGroup : AgentBehaviorGroup
{
	public const float SafetyDistance = 15f;

	public const float SafetyDistanceSquared = 225f;

	private readonly MissionFightHandler _missionFightHandler;

	public bool DisableCalmDown;

	private readonly BasicMissionTimer _alarmedTimer;

	private readonly BasicMissionTimer _checkCalmDownTimer;

	public bool DoNotCheckForAlarmFactorIncrease;

	public bool DoNotIncreaseAlarmFactorDueToSeeingOrHearingTheEnemy;

	private bool _canMoveWhenCautious;

	private readonly MissionTimer _lastSuspiciousPositionTimer;

	private readonly MissionTimer _alarmYellTimer;

	private readonly List<Agent> _ignoredAgentsForAlarm;

	private readonly MBList<GameEntity> _stealthIndoorLightingAreas;

	private MissionTime _lastAlarmTriggerTime;

	public float AlarmFactor
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AlarmedBehaviorGroup(AgentNavigator navigator, Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCanMoveWhenCautious(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAgentAlarmState(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAILastSuspiciousPositionHelper(in WorldPosition lastSuspiciousPosition, bool checkNavMeshForCorrection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSoundFactor(Agent currentAgent, float sneakingNoiseMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetVisualFactor(Vec3 usedGlobalLookDirection, Agent currentAgent, MBReadOnlyList<GameEntity> stealthIndoorLightingAreas, ref bool hasVisualOnCorpse, ref bool hasVisualOnEnemy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetVisualStrength(Vec3 positionDifferenceDirection, Vec3 usedGlobalLookDirection, Agent currentAgent, bool currentAgentHasSpeed, float distance, float equipmentStealthBonus)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetAlarmFactor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddAlarmFactor(float addedAlarmFactor, Agent suspiciousAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAlarmFactor(float addedAlarmFactor, in WorldPosition suspiciousPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt, bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickActiveBehaviors(float dt, bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetScore(bool isSimulation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsNearDanger()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent GetClosestAlarmSource(out float distanceSquared)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AlarmAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleMissiles(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAddSoundAlarmFactor(Agent alarmCreatorAgent, in Vec3 soundPosition, float soundLevelSquareRoot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ForceThink(float inSeconds)
	{
		throw null;
	}
}
