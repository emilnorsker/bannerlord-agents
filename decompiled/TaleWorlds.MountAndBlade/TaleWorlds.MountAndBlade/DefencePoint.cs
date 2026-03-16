using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class DefencePoint : ScriptComponentBehavior
{
	private List<Agent> defenders;

	public BattleSideEnum Side;

	public IEnumerable<Agent> Defenders
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddDefender(Agent defender)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveDefender(Agent defender)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PurgeInactiveDefenders()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetPosition(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetVacantPosition(Agent a)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CountOccupiedDefenderPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefencePoint()
	{
		throw null;
	}
}
