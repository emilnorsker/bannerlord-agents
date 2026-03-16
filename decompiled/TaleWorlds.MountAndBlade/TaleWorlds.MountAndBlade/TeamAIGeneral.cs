using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class TeamAIGeneral : TeamAIComponent
{
	private int _numberOfEnemiesInShootRange;

	private int _numberOfEnemiesCloseToAttack;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TeamAIGeneral(Mission currentMission, Team currentTeam, float thinkTimerTime = 10f, float applyTimerTime = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUnitAddedToFormationForTheFirstTime(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateVariables()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void DebugTick(float dt)
	{
		throw null;
	}
}
