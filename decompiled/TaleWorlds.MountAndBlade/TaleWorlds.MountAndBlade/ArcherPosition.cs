using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class ArcherPosition
{
	private FormationAI.BehaviorSide _closestSide;

	private int _connectedSides;

	private SiegeQuerySystem _siegeQuerySystem;

	private readonly Formation[] _lastAssignedFormations;

	public GameEntity Entity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public TacticalPosition TacticalArcherPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public int ConnectedSides
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Formation GetLastAssignedFormation(int teamIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArcherPosition(GameEntity _entity, SiegeQuerySystem siegeQuerySystem, BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int ConvertToBinaryPow(int pow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsArcherPositionRelatedToSide(FormationAI.BehaviorSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FormationAI.BehaviorSide GetArcherPositionClosestSide()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDeploymentFinished(SiegeQuerySystem siegeQuerySystem, BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineArcherPositionSide(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CalculateArcherPositionSideUsingAttackerRegions(SiegeQuerySystem siegeQuerySystem, Vec3 position, out FormationAI.BehaviorSide _closestSide, out int ConnectedSides)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CalculateArcherPositionSideUsingDefenderLanes(SiegeQuerySystem siegeQuerySystem, Vec3 position, out FormationAI.BehaviorSide _closestSide, out int ConnectedSides)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLastAssignedFormation(int teamIndex, Formation formation)
	{
		throw null;
	}
}
