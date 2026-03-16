using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Tournaments.MissionLogics;
using TaleWorlds.MountAndBlade;

namespace SandBox.Tournaments.AgentControllers;

public class ArcheryTournamentAgentController : AgentController
{
	private List<DestructableComponent> _targetList;

	private DestructableComponent _target;

	private TournamentArcheryMissionController _missionController;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargets(List<DestructableComponent> targetList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTarget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SelectNewTarget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetScore(DestructableComponent target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTargetHit(Agent agent, DestructableComponent target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArcheryTournamentAgentController()
	{
		throw null;
	}
}
