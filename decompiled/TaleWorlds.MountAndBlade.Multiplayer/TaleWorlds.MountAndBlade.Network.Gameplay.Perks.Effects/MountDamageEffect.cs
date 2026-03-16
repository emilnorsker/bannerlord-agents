using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class MountDamageEffect : MPCombatPerkEffect
{
	protected static string StringType;

	private float _value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MountDamageEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetMountDamage(WeaponComponentData attackerWeapon, DamageTypes damageType, bool isAlternativeAttack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MountDamageEffect()
	{
		throw null;
	}
}
