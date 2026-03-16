using System.Runtime.CompilerServices;
using NavalDLC.Missions.AI.TeamAI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.AI.Tactics;

public abstract class NavalTacticComponent : TacticComponent
{
	private const float EngagementDistanceSquared = 40000f;

	protected readonly TeamAINavalComponent TeamAINavalComponent;

	protected bool HasBattleBeenJoined;

	protected MBReadOnlyList<Formation> _shipOrderCached;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalTacticComponent(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetDefaultNavalBehaviorWeights(Formation f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void NavalApproach()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void CheckAndSetHasBattleBeenJoined()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool HasShipOrderChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ManageFormationCounts()
	{
		throw null;
	}
}
