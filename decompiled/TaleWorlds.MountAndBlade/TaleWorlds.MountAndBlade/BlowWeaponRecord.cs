using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

[EngineStruct("Blow_weapon_record", false, null)]
public struct BlowWeaponRecord
{
	public Vec3 StartingPosition;

	public Vec3 CurrentPosition;

	public Vec3 Velocity;

	public ItemFlags ItemFlags;

	public WeaponFlags WeaponFlags;

	public WeaponClass WeaponClass;

	public sbyte BoneNoToAttach;

	public int AffectorWeaponSlotOrMissileIndex;

	public float Weight;

	[MarshalAs(UnmanagedType.U1)]
	[CustomEngineStructMemberData(true)]
	private bool _isMissile;

	[MarshalAs(UnmanagedType.U1)]
	private bool _isMaterialMetal;

	public bool IsMissile
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsShield
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsRanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAmmo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillAsMeleeBlow(ItemObject item, WeaponComponentData weaponComponentData, int affectorWeaponSlot, sbyte weaponAttachBoneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillAsMissileBlow(ItemObject item, WeaponComponentData weaponComponentData, int missileIndex, sbyte weaponAttachBoneIndex, Vec3 startingPosition, Vec3 currentPosition, Vec3 velocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasWeapon()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetHitSound(bool isOwnerHumanoid, bool isCriticalBlow, bool isLowBlow, bool isNonTipThrust, AgentAttackType attackType, DamageTypes damageType)
	{
		throw null;
	}
}
