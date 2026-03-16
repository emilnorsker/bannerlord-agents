using System.Runtime.CompilerServices;
using NavalDLC.Missions.AI.TeamAI;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.NavalPhysics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions;

public class AgentNavalComponent : AgentComponent
{
	private const float OffShipCheckInterval = 5f;

	private const float BreatheCheckInterval = 5f;

	private const float BreatheHoldMaxDurationBase = 60f;

	private AgentMovementMode _lastMovementMode;

	private float _lastBreatheTime;

	private float _lastBreatheCheckTime;

	private float _lastOffShipCheckTime;

	private float _breatheHoldMaxDurationFinal;

	private ulong _parentShipUniqueBitwiseID;

	private TeamAINavalComponent _teamAINavalComponent;

	private GameEntity _steppedEntityCache;

	private NavalDLC.Missions.NavalPhysics.NavalPhysics _steppedNavalPhysicsCached;

	private PlankBridgeSteppedAgentManager _steppedPlankBridgeSteppedAgentManagerCached;

	private readonly NavalShipsLogic _navalShipsLogic;

	private readonly NavalAgentsLogic _navalAgentsLogic;

	public MissionShip SteppedShip
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

	public MissionShip FormationShip
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

	public bool BlockDrowning
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
	public AgentNavalComponent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFormationSet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipCaptured()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCanDrown(bool canDrown)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetBreath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTickParallel(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAgentOffShip(bool forceAssumeAgentOnWater = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAgentDrown()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrownAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetupAgentToJumpOffABurningShip()
	{
		throw null;
	}
}
