using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics;

public class MissionAgentHandler : MissionLogic
{
	private const float PassageUsageDeltaTime = 30f;

	private static readonly uint[] _tournamentTeamColors;

	private static readonly uint[] _villagerClothColors;

	private static int _disabledFaceId;

	private static int _disabledFaceIdForAnimals;

	private readonly Dictionary<string, List<UsableMachine>> _usablePoints;

	private readonly Dictionary<string, List<UsableMachine>> _pairedUsablePoints;

	private readonly HashSet<UsableMachine> _usedSpawnPoints;

	private List<UsableMachine> _disabledPassages;

	private readonly List<(LocationCharacter, MatrixFrame, GameEntity, bool, bool, Timer)> _spawnTimers;

	private float _passageUsageTime;

	public List<UsableMachine> TownPassageProps
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<UsableMachine> DisabledPassages
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public List<UsableMachine> UsablePoints
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasPassages()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAgentHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRenderingStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionModeChange(MissionMode oldMissionMode, bool atStart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializePairedUsableObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAllProps()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	public void DetectMissingEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveDeactivatedUsablePlacesFromList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Dictionary<string, int> FindUnusedUsablePointCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DisableUnavailableWaypoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SpawnLocationCharacters(string overridenTagValue = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAlreadySpawned(IAgentOriginBase agentOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent SpawnDefaultLocationCharacter(LocationCharacter locationCharacter, bool simulateAgentAfterSpawn = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SimulateAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetFrameForFollowingAgent(Agent followedAgent, out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FadeoutExitingLocationCharacter(LocationCharacter locationCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SpawnEnteringLocationCharacter(LocationCharacter locationCharacter, Location fromLocation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetUsablePlaceUsed(string spawnTag, GameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetInitialFrameForSpawnTag(string spawnTag, ref WeakGameEntity spawnedOnGameEntity, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasUsablePointWithTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<string> GetAllSpawnTags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<UsableMachine> GetAllUsablePointsWithTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent SpawnWanderingAgent(LocationCharacter locationCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetSpawnFrameFromUsableMachine(UsableMachine usableMachine, out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SpawnWanderingAgentWithDelay(LocationCharacter locationCharacter, MatrixFrame matrixFrame, GameEntity spawnEntity, bool noHorses = true, bool hasTorch = false, float delay = 3f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Agent SpawnWanderingAgentWithInitialFrame(LocationCharacter locationCharacter, MatrixFrame spawnPointFrame, WeakGameEntity spawnEntity, bool noHorses = true, bool hasTorch = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint GetRandomTournamentTeamColor(int teamIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static (uint color1, uint color2) GetAgentSettlementColors(LocationCharacter locationCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UsableMachine FindUnusedPointWithTagForAgent(Agent agent, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<UsableMachine> FindUnusedPoints(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private UsableMachine FindUnusedPointForAgent(Agent agent, Dictionary<string, List<UsableMachine>> usableMachinesList, string primaryTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<UsableMachine> FindAllUnusedPoints(Agent agent, string primaryTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TeleportTargetAgentNearReferenceAgent(Agent referenceAgent, Agent teleportAgent, bool teleportFollowers, bool teleportOpposite)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetPointCountOfUsableMachine(UsableMachine usableMachine, bool checkForUnusedOnes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MissionAgentHandler()
	{
		throw null;
	}
}
