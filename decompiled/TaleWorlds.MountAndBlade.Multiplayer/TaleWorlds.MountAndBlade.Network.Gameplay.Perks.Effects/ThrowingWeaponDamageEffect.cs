using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class ThrowingWeaponDamageEffect : MPPerkEffect
{
	protected static string StringType;

	private float _value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ThrowingWeaponDamageEffect()
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
	static ThrowingWeaponDamageEffect()
	{
		throw null;
	}
}
