using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

[EngineStruct("Attack_collision_data", false, null)]
public struct AttackCollisionData
{
	[MarshalAs(UnmanagedType.U1)]
	private bool _attackBlockedWithShield;

	[MarshalAs(UnmanagedType.U1)]
	private bool _correctSideShieldBlock;

	[MarshalAs(UnmanagedType.U1)]
	private bool _isAlternativeAttack;

	[MarshalAs(UnmanagedType.U1)]
	private bool _isColliderAgent;

	[MarshalAs(UnmanagedType.U1)]
	private bool _collidedWithShieldOnBack;

	[MarshalAs(UnmanagedType.U1)]
	private bool _isMissile;

	[MarshalAs(UnmanagedType.U1)]
	private bool _missileBlockedWithWeapon;

	[MarshalAs(UnmanagedType.U1)]
	private bool _missileHasPhysics;

	[MarshalAs(UnmanagedType.U1)]
	private bool _entityExists;

	[MarshalAs(UnmanagedType.U1)]
	private bool _thrustTipHit;

	[MarshalAs(UnmanagedType.U1)]
	private bool _missileGoneUnderWater;

	[MarshalAs(UnmanagedType.U1)]
	private bool _missileGoneOutOfBorder;

	[MarshalAs(UnmanagedType.U1)]
	private bool _collidedWithLastBoneSegment;

	private int _collisionResult;

	private Vec3 _weaponBlowDir;

	[CustomEngineStructMemberData(true)]
	public float BaseMagnitude;

	[CustomEngineStructMemberData(true)]
	public float MovementSpeedDamageModifier;

	[CustomEngineStructMemberData(true)]
	public int AbsorbedByArmor;

	[CustomEngineStructMemberData(true)]
	public int InflictedDamage;

	[CustomEngineStructMemberData(true)]
	public int SelfInflictedDamage;

	[MarshalAs(UnmanagedType.U1)]
	[CustomEngineStructMemberData(true)]
	public bool IsShieldBroken;

	[MarshalAs(UnmanagedType.U1)]
	[CustomEngineStructMemberData(true)]
	public bool IsSneakAttack;

	public bool AttackBlockedWithShield
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CorrectSideShieldBlock
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAlternativeAttack
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsColliderAgent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CollidedWithShieldOnBack
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsMissile
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool MissileBlockedWithWeapon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool MissileHasPhysics
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool EntityExists
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool ThrustTipHit
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool MissileGoneUnderWater
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool MissileGoneOutOfBorder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool CollidedWithLastBoneSegment
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsHorseCharge
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsFallDamage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public CombatCollisionResult CollisionResult
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int AffectorWeaponSlotOrMissileIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public int StrikeType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public int DamageType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public sbyte CollisionBoneIndex
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

	public BoneBodyPartType VictimHitBodyPart
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public sbyte AttackBoneIndex
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

	public Agent.UsageDirection AttackDirection
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public int PhysicsMaterialIndex
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

	public CombatHitResultFlags CollisionHitResultFlags
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

	public float AttackProgress
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public float CollisionDistanceOnWeapon
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public float AttackerStunPeriod
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float DefenderStunPeriod
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float MissileTotalDamage
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public float MissileStartingBaseSpeed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public float ChargeVelocity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public float FallSpeed
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

	public Vec3 WeaponRotUp
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 WeaponBlowDir
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec3 CollisionGlobalPosition
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

	public Vec3 MissileVelocity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 MissileStartingPosition
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 VictimAgentCurVelocity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 CollisionGlobalNormal
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 LastBoneSegmentRotUp
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Vec3 LastBoneSegmentSwingDir
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCollisionBoneIndexForAreaDamage(sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateCollisionPositionAndBoneForReflect(int inflictedDamage, Vec3 position, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AttackCollisionData(bool attackBlockedWithShield, bool correctSideShieldBlock, bool isAlternativeAttack, bool isColliderAgent, bool collidedWithShieldOnBack, bool isMissile, bool missileBlockedWithWeapon, bool missileHasPhysics, bool entityExists, bool thrustTipHit, bool missileGoneUnderWater, bool missileGoneOutOfBorder, bool collidedWithLastBoneSegment, CombatCollisionResult collisionResult, int affectorWeaponSlotOrMissileIndex, int StrikeType, int DamageType, sbyte CollisionBoneIndex, BoneBodyPartType VictimHitBodyPart, sbyte AttackBoneIndex, Agent.UsageDirection AttackDirection, int PhysicsMaterialIndex, CombatHitResultFlags CollisionHitResultFlags, float AttackProgress, float CollisionDistanceOnWeapon, float AttackerStunPeriod, float DefenderStunPeriod, float MissileTotalDamage, float MissileStartingBaseSpeed, float ChargeVelocity, float FallSpeed, Vec3 WeaponRotUp, Vec3 weaponBlowDir, Vec3 CollisionGlobalPosition, Vec3 MissileVelocity, Vec3 MissileStartingPosition, Vec3 VictimAgentCurVelocity, Vec3 GroundNormal, Vec3 LastBoneSegmentRotUp, Vec3 LastBoneSegmentSwingDir)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AttackCollisionData GetAttackCollisionDataForDebugPurpose(bool _attackBlockedWithShield, bool _correctSideShieldBlock, bool _isAlternativeAttack, bool _isColliderAgent, bool _collidedWithShieldOnBack, bool _isMissile, bool _isMissileBlockedWithWeapon, bool _missileHasPhysics, bool _entityExists, bool _thrustTipHit, bool _missileGoneUnderWater, bool _missileGoneOutOfBorder, CombatCollisionResult collisionResult, int affectorWeaponSlotOrMissileIndex, int StrikeType, int DamageType, sbyte CollisionBoneIndex, BoneBodyPartType VictimHitBodyPart, sbyte AttackBoneIndex, Agent.UsageDirection AttackDirection, int PhysicsMaterialIndex, CombatHitResultFlags CollisionHitResultFlags, float AttackProgress, float CollisionDistanceOnWeapon, float AttackerStunPeriod, float DefenderStunPeriod, float MissileTotalDamage, float MissileInitialSpeed, float ChargeVelocity, float FallSpeed, Vec3 WeaponRotUp, Vec3 _weaponBlowDir, Vec3 CollisionGlobalPosition, Vec3 MissileVelocity, Vec3 MissileStartingPosition, Vec3 VictimAgentCurVelocity, Vec3 GroundNormal)
	{
		throw null;
	}
}
