using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public abstract class SallyOutMissionController : MissionLogic
{
	private const float BesiegedTotalTroopRatio = 0.25f;

	private const float BesiegedInitialTroopRatio = 0.1f;

	private const float BesiegedReinforcementRatio = 0.01f;

	private const float BesiegerInitialTroopRatio = 0.1f;

	private const float BesiegerReinforcementRatio = 0.1f;

	private const float BesiegedInitialInterval = 1f;

	private const float BesiegerInitialInterval = 90f;

	private const float BesiegerIntervalChange = 15f;

	private const int BesiegerIntervalChangeCount = 5;

	private const float PlayerToGateSquaredDistanceThreshold = 25f;

	private SallyOutMissionNotificationsHandler _sallyOutNotificationsHandler;

	private List<CastleGate> _castleGates;

	private BasicMissionTimer _besiegedDeploymentTimer;

	private BasicMissionTimer _besiegerActivationTimer;

	private MBReadOnlyList<SiegeWeapon> _besiegerSiegeEngines;

	protected MissionAgentSpawnLogic MissionAgentSpawnLogic;

	private bool _isSallyOutAmbush;

	private float BesiegedDeploymentDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private float BesiegerActivationDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MBReadOnlyList<SiegeWeapon> BesiegerSiegeEngines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SallyOutMissionController(bool isSallyOutAmbush)
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
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	protected abstract void GetInitialTroopCounts(out int besiegedTotalTroopCount, out int besiegerTotalTroopCount);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTimers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateDefenders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustTotalTroopCounts(ref int besiegedTotalTroopCount, ref int besiegerTotalTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupInitialSpawn(int besiegedTotalTroopCount, int besiegerTotalTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WorldPosition? GetSallyOutFleePositionForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static MissionSpawnSettings CreateSallyOutSpawnSettings(float besiegedReinforcementPercentage, float besiegerReinforcementPercentage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDefenderTeamTacticalDecision(in TacticalDecision decision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeactivateBesiegers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateBesiegers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBReadOnlyList<SiegeWeapon> GetBesiegerSiegeEngines()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DisableSiegeEngines()
	{
		throw null;
	}
}
