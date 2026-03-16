using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View;

public class CraftedDataView
{
	public delegate void OnMeshBuiltDelegate(WeaponDesign weaponDesign, ref MetaMesh builtMesh);

	public static OnMeshBuiltDelegate OnWeaponMeshBuilt;

	public static OnMeshBuiltDelegate OnHolsterMeshBuilt;

	public static OnMeshBuiltDelegate OnHolsterMeshWithWeaponBuilt;

	private MetaMesh _weaponMesh;

	private MetaMesh _holsterMesh;

	private MetaMesh _holsterMeshWithWeapon;

	private MetaMesh _nonBatchedWeaponMesh;

	private MetaMesh _nonBatchedHolsterMesh;

	private MetaMesh _nonBatchedHolsterMeshWithWeapon;

	public WeaponDesign CraftedData
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

	public MetaMesh WeaponMesh
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MetaMesh HolsterMesh
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MetaMesh HolsterMeshWithWeapon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MetaMesh NonBatchedWeaponMesh
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MetaMesh NonBatchedHolsterMesh
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MetaMesh NonBatchedHolsterMeshWithWeapon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CraftedDataView(WeaponDesign craftedData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MetaMesh GenerateWeaponMesh(bool batchMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MetaMesh GenerateHolsterMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MetaMesh GenerateHolsterMeshWithWeapon(bool batchMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MetaMesh BuildWeaponMesh(WeaponDesign craftedData, float pivotDiff, bool pieceTypeHidingEnabledForHolster, bool batchAllMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MetaMesh BuildHolsterMesh(WeaponDesign craftedData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MetaMesh BuildHolsterMeshWithWeapon(WeaponDesign craftedData, float pivotDiff, bool batchAllMeshes)
	{
		throw null;
	}
}
