using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace TaleWorlds.MountAndBlade;

public class DefaultItemPickupModel : ItemPickupModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetItemScoreForAgent(SpawnedItemEntity item, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsItemAvailableForAgent(SpawnedItemEntity item, Agent agent, EquipmentIndex slotToPickUp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsAgentEquipmentSuitableForPickUpAvailability(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultItemPickupModel()
	{
		throw null;
	}
}
