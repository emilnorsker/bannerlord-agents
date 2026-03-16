using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class SiegeLane
{
	public enum LaneStateEnum
	{
		Safe,
		Unused,
		Used,
		Active,
		Abandoned,
		Contested,
		Conceited
	}

	public enum LaneDefenseStates
	{
		Empty,
		Token,
		Full
	}

	private readonly Formation[] _lastAssignedFormations;

	private SiegeQuerySystem _siegeQuerySystem;

	private SiegeWeapon _attackerMovableWeapon;

	public LaneStateEnum LaneState
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

	public FormationAI.BehaviorSide LaneSide
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public List<IPrimarySiegeWeapon> PrimarySiegeWeapons
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

	public bool IsOpen
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

	public bool IsBreach
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

	public bool HasGate
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

	public List<ICastleKeyPosition> DefensePoints
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

	public WorldPosition DefenderOrigin
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

	public WorldPosition AttackerOrigin
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
	public SiegeLane(FormationAI.BehaviorSide laneSide, SiegeQuerySystem siegeQuerySystem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CalculateIsLaneUnusable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Formation GetLastAssignedFormation(int teamIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLaneState(LaneStateEnum newLaneState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLastAssignedFormation(int teamIndex, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSiegeQuerySystem(SiegeQuerySystem siegeQuerySystem)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float CalculateLaneCapacity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LaneDefenseStates GetDefenseState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsPowerBehindLane()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsUnderAttack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDefended()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DetermineLaneState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldPosition GetCurrentAttackerPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DetermineOrigins()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshLane()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPrimarySiegeWeapons(List<IPrimarySiegeWeapon> primarySiegeWeapons)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDefensePoints(List<ICastleKeyPosition> defensePoints)
	{
		throw null;
	}
}
