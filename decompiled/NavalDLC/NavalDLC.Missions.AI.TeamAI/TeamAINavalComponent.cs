using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.TeamAI;

public class TeamAINavalComponent : TeamAIComponent
{
	private readonly bool _isRiverBattle;

	private NavalShipsLogic _navalShipsLogic;

	private SpawnPathData _spawnPathData;

	public NavalQuerySystem TeamNavalQuerySystem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public bool UseSpawnPathApproachPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TeamAINavalComponent(Mission currentMission, Team currentTeam, float thinkTimerTime, float applyTimerTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUnitAddedToFormationForTheFirstTime(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Formation GetConnectedAllyFormation(ulong shipUniqueBitwiseID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Formation GetNearestAllyShipFormation(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetRiverApproachPosition(out Vec2 position, out Vec2 direction)
	{
		throw null;
	}
}
