using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class CustomBattleTroopSupplier : IMissionTroopSupplier
{
	private readonly CustomBattleCombatant _customBattleCombatant;

	private TaleWorlds.Library.PriorityQueue<float, BasicCharacterObject> _characters;

	private int _numAllocated;

	private int _numWounded;

	private int _numKilled;

	private int _numRouted;

	private Func<BasicCharacterObject, bool> _customAllocationConditions;

	private bool _anyTroopRemainsToBeSupplied;

	private readonly bool _isPlayerSide;

	private readonly bool _isPlayerGeneral;

	private readonly bool _isSallyOut;

	private int _nextTroopRank;

	public int NumRemovedTroops
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int NumTroopsNotSupplied
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool AnyTroopRemainsToBeSupplied
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomBattleTroopSupplier(CustomBattleCombatant customBattleCombatant, bool isPlayerSide, bool isPlayerGeneral, bool isSallyOut, Func<BasicCharacterObject, bool> customAllocationConditions = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ArrangePriorities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetSallyOutAmbushProbabilityOfTroop(BasicCharacterObject character, int troopCountTotal, ref float heroProbability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetDefaultProbabilityOfTroop(BasicCharacterObject character, int troopCountTotal, UnitSpawnPrioritizations unitSpawnPrioritization, ref float heroProbability, ref int[] troopCountByFormationType, ref int[] enqueuedTroopCountByFormationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<IAgentOriginBase> SupplyTroops(int numberToAllocate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IAgentOriginBase SupplyOneTroop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<IAgentOriginBase> GetAllTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicCharacterObject GetGeneralCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<BasicCharacterObject> AllocateTroops(int numberToAllocate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private BasicCharacterObject AllocateTroop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTroopWounded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTroopKilled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTroopRouted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPlayerControllableTroops()
	{
		throw null;
	}
}
