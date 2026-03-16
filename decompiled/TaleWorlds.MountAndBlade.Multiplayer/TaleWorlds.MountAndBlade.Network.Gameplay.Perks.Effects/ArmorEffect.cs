using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class ArmorEffect : MPOnSpawnPerkEffect
{
	protected static string StringType;

	private float _value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ArmorEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDrivenPropertyBonusOnSpawn(bool isPlayer, DrivenProperty drivenProperty, float baseValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ArmorEffect()
	{
		throw null;
	}
}
