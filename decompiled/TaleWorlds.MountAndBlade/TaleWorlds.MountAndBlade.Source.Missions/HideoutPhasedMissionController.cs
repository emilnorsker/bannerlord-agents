using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Source.Missions;

public class HideoutPhasedMissionController : MissionLogic
{
	public const int PhaseCount = 4;

	private GameEntity[] _spawnPoints;

	private Stack<MatrixFrame[]> _spawnPointFrames;

	private bool _isNewlyPopulatedFormationGivenOrder;

	public override MissionBehaviorType BehaviorType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool IsPhasingInitialized
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
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
	private void ReadySpawnPointLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateSpawnPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPhaseChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreOrderGesturesEnabled_AdditionalCondition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HideoutPhasedMissionController()
	{
		throw null;
	}
}
