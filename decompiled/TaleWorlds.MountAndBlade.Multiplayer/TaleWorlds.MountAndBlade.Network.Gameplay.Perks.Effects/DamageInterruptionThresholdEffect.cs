using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class DamageInterruptionThresholdEffect : MPPerkEffect
{
	protected static string StringType;

	private float _value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected DamageInterruptionThresholdEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDamageInterruptionThreshold()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DamageInterruptionThresholdEffect()
	{
		throw null;
	}
}
