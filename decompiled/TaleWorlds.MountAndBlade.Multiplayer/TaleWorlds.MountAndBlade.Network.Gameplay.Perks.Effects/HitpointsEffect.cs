using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class HitpointsEffect : MPOnSpawnPerkEffect
{
	protected static string StringType;

	private float _value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected HitpointsEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetHitpoints(bool isPlayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static HitpointsEffect()
	{
		throw null;
	}
}
