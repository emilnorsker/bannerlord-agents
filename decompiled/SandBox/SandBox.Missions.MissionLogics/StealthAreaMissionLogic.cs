using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Objects.AreaMarkers;
using SandBox.Objects.Usables;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class StealthAreaMissionLogic : MissionLogic
{
	public delegate List<IAgentOriginBase> GetReinforcementAllyTroopsDelegate(StealthAreaData triggeredStealthAreaData, StealthAreaMarker stealthAreaMarker);

	public class StealthAreaData
	{
		internal bool IsStealthAreaTriggered;

		internal bool IsReinforcementCalled;

		internal readonly StealthAreaUsePoint StealthAreaUsePoint;

		internal readonly Dictionary<StealthAreaMarker, List<Agent>> StealthAreaMarkers;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal StealthAreaData(StealthAreaUsePoint stealthAreaUsePoint)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void AddAgentToStealthAreaMarker(StealthAreaMarker stealthAreaMarker, Agent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void RemoveAgentFromStealthAreaMarker(StealthAreaMarker stealthAreaMarker, Agent agent)
		{
			throw null;
		}
	}

	private readonly MBList<StealthAreaData> _stealthAreaData;

	private readonly Dictionary<string, Dictionary<string, int>> _agentSpawnTypes;

	private readonly MBList<Agent> _allyTroops;

	public GetReinforcementAllyTroopsDelegate GetReinforcementAllyTroops;

	public MBReadOnlyList<Agent> AllyTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool AllReinforcementsCalled
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
	public StealthAreaMissionLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSentry(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgentSpawnType(string spawnGroupId, Dictionary<string, int> spawnDictionary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAgentSpawnTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<IAgentOriginBase> GetReinforcementAllyGroupTroops(StealthAreaData triggeredStealthAreaData, StealthAreaMarker stealthAreaMarker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentBuild(Agent agent, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentTeamChanged(Team prevTeam, Team newTeam, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckStealthAreaMarkerForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnObjectUsed(Agent userAgent, UsableMissionObject usedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAllyAgent(IAgentOriginBase character, GameEntity spawnPoint, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfAllStealthAreasAreTriggered()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfAllStealthAreasReinforcementsAreCalled()
	{
		throw null;
	}
}
