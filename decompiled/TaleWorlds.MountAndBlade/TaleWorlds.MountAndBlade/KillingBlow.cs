using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

[EngineStruct("Killing_blow", false, null)]
public struct KillingBlow
{
	public Vec3 RagdollImpulseLocalPoint;

	public Vec3 RagdollImpulseAmount;

	public int DeathAction;

	public DamageTypes DamageType;

	public AgentAttackType AttackType;

	public int OwnerId;

	public BoneBodyPartType VictimBodyPart;

	public int WeaponClass;

	public Agent.KillInfo OverrideKillInfo;

	public Vec3 BlowPosition;

	public WeaponFlags WeaponRecordWeaponFlags;

	public int WeaponItemKind;

	public int InflictedDamage;

	[MarshalAs(UnmanagedType.U1)]
	public bool IsMissile;

	[MarshalAs(UnmanagedType.U1)]
	public bool IsValid;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public KillingBlow(Blow b, Vec3 ragdollImpulsePoint, Vec3 ragdollImpulseAmount, int deathAction, int weaponItemKind, Agent.KillInfo overrideKillInfo = Agent.KillInfo.Invalid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsHeadShot()
	{
		throw null;
	}
}
