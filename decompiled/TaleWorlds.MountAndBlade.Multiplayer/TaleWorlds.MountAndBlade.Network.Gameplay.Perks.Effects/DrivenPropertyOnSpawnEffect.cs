using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class DrivenPropertyOnSpawnEffect : MPOnSpawnPerkEffect
{
	protected static string StringType;

	private DrivenProperty _drivenProperty;

	private float _value;

	private bool _isRatio;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected DrivenPropertyOnSpawnEffect()
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
	static DrivenPropertyOnSpawnEffect()
	{
		throw null;
	}
}
