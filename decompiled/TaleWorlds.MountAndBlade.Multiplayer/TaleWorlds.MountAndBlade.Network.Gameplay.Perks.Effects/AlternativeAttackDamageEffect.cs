using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class AlternativeAttackDamageEffect : MPPerkEffect
{
	private enum AttackType
	{
		Any,
		Kick,
		Bash
	}

	protected static string StringType;

	private AttackType _attackType;

	private float _value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected AlternativeAttackDamageEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDamage(WeaponComponentData attackerWeapon, DamageTypes damageType, bool isAlternativeAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static AlternativeAttackDamageEffect()
	{
		throw null;
	}
}
