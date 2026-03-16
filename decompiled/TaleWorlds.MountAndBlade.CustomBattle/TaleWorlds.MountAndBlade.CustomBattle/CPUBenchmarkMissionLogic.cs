using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.CustomBattle;

public class CPUBenchmarkMissionLogic : MissionLogic
{
	private delegate void MainThreadJobDelegate();

	private enum BattlePhase
	{
		Start,
		ArrowShower,
		MeleePosition,
		Cav1Pos,
		Cav1PosDef,
		CavalryPosition,
		MeleeAttack,
		RangedAdvance,
		CavalryAdvance,
		CavalryCharge,
		CavalryCharge2,
		RangedAdvance2,
		FullCharge
	}

	private enum BenchmarkStatus
	{
		Inactive,
		Active,
		Result,
		SetDefinition
	}

	private const float FormationDistDiff = 20f;

	private const float PressTimeForExit = 0.05f;

	private const float ResultTime = 9f;

	private readonly int _attackerInfCount;

	private readonly int _attackerRangedCount;

	private readonly int _attackerCavCount;

	private readonly int _defenderInfCount;

	private readonly int _defenderCavCount;

	private int _curPath;

	private float _benchmarkExit;

	private bool _benchmarkFinished;

	private static bool _isSiege;

	private float _showResultTime;

	private Path[] _paths;

	private Path[] _targets;

	private float _cameraSpeed;

	private float _curPathSpeed;

	private float _curPathLenght;

	private float _nextPathSpeed;

	private float _prevPathSpeed;

	private float _cameraPassedDistanceOnPath;

	private MissionAgentSpawnLogic _missionAgentSpawnLogic;

	private bool _formationsSetUp;

	private Formation _defLeftInf;

	private Formation _defMidCav;

	private Formation _defRightInf;

	private Formation _defLeftBInf;

	private Formation _defMidBInf;

	private Formation _defRightBInf;

	private Formation _attLeftInf;

	private Formation _attRightInf;

	private Formation _attLeftRanged;

	private Formation _attRightRanged;

	private Formation _attLeftCav;

	private Formation _attRightCav;

	private Camera _benchmarkCamera;

	private BattlePhase _battlePhase;

	private bool _isCurPhaseInPlay;

	private float _totalTime;

	private bool _benchmarkStarted;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CPUBenchmarkMissionLogic(int attackerInfCount, int attackerRangedCount, int attackerCavCount, int defenderInfCount, int defenderCavCount)
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
	private void SetupFormations()
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
	public override void OnPreMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Check()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("cpu_benchmark_mission", "benchmark")]
	public static string CPUBenchmarkMission(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("cpu_benchmark", "benchmark")]
	public static string CPUBenchmark(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("benchmark_start", "state_string")]
	public static string BenchmarkStateStart(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("benchmark_end", "state_string")]
	public static string BenchmarkStateEnd(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mission OpenCPUBenchmarkMission(string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CPUBenchmarkMissionLogic()
	{
		throw null;
	}
}
