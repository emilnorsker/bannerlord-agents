using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

[EngineStruct("Blow", false, null)]
public struct Blow
{
	public BlowWeaponRecord WeaponRecord;

	public Vec3 GlobalPosition;

	public Vec3 Direction;

	public Vec3 SwingDirection;

	public int InflictedDamage;

	public int SelfInflictedDamage;

	public float BaseMagnitude;

	public float DefenderStunPeriod;

	public float AttackerStunPeriod;

	public float AbsorbedByArmor;

	public float MovementSpeedDamageModifier;

	public StrikeType StrikeType;

	public AgentAttackType AttackType;

	[CustomEngineStructMemberData("blow_flags")]
	public BlowFlags BlowFlag;

	public int OwnerId;

	public sbyte BoneIndex;

	public BoneBodyPartType VictimBodyPart;

	public DamageTypes DamageType;

	[MarshalAs(UnmanagedType.U1)]
	public bool NoIgnore;

	[MarshalAs(UnmanagedType.U1)]
	public bool DamageCalculated;

	[MarshalAs(UnmanagedType.U1)]
	public bool IsFallDamage;

	public float DamagedPercentage;

	public bool IsMissile
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Blow(int ownerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBlowCrit(int maxHitPointsOfVictim)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBlowLow(int maxHitPointsOfVictim)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsHeadShot()
	{
		throw null;
	}
}
