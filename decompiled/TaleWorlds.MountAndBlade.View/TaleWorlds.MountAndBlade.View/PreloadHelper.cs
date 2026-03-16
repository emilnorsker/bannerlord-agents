using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View;

public class PreloadHelper
{
	private readonly HashSet<(string, bool, bool)> _uniqueMetaMeshNames;

	private readonly HashSet<string> _uniqueDynamicPhysicsShapeName;

	private readonly HashSet<(MetaMesh, bool, bool)> _uniqueMetaMeshes;

	private readonly HashSet<ItemObject> _loadedItems;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadCharacters(List<BasicCharacterObject> characters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WaitForMeshesToBeLoaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadEquipments(List<Equipment> equipments)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadItems(List<ItemObject> items)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEquipment(Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddItemObject(ItemObject item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadEntities(List<WeakGameEntity> entities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadMeshesAndPhysics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterMetaMeshUsageIfValid(string metaMeshName, bool useTableau, bool useTeamColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterMetaMeshUsageIfValid(MetaMesh metaMesh, bool useTableau, bool useTeamColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterPhysicsBodyUsageIfValid(HashSet<string> uniquePhysicsShapeName, string physicsShape)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PreloadHelper()
	{
		throw null;
	}
}
