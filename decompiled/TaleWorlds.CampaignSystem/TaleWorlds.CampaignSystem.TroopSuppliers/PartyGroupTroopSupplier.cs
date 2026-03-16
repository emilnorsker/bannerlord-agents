using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.TroopSuppliers;

public class PartyGroupTroopSupplier : IMissionTroopSupplier
{
	private readonly int _initialTroopCount;

	private int _numAllocated;

	private int _numWounded;

	private int _numKilled;

	private int _numRouted;

	private bool _isPlayerSide;

	private Func<UniqueTroopDescriptor, MapEventParty, bool> _customAllocationConditions;

	private bool _anyTroopRemainsToBeSupplied;

	private int _nextTroopRank;

	internal MapEventSide PartyGroup
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
	public PartyGroupTroopSupplier(MapEvent mapEvent, BattleSideEnum side, FlattenedTroopRoster priorTroops = null, Func<UniqueTroopDescriptor, MapEventParty, bool> customAllocationConditions = null)
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
	public int GetNumberOfPlayerControllableTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTroopWounded(UniqueTroopDescriptor troopDescriptor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTroopKilled(UniqueTroopDescriptor troopDescriptor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTroopRouted(UniqueTroopDescriptor troopDescriptor, bool isOrderRetreat)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal CharacterObject GetTroop(UniqueTroopDescriptor troopDescriptor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartyBase GetParty(UniqueTroopDescriptor troopDescriptor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTroopScoreHit(UniqueTroopDescriptor descriptor, BasicCharacterObject attackedCharacter, int damage, bool isFatal, bool isTeamKill, WeaponComponentData attackerWeapon)
	{
		throw null;
	}
}
