using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public abstract class MPCombatPerkEffect : MPPerkEffect
{
	protected enum HitType
	{
		Any,
		Melee,
		Ranged
	}

	protected HitType EffectHitType;

	protected DamageTypes? DamageType;

	protected WeaponClass? WeaponClass;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool IsSatisfied(WeaponComponentData attackerWeapon, DamageTypes damageType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool IsWeaponRanged(WeaponComponentData attackerWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MPCombatPerkEffect()
	{
		throw null;
	}
}
