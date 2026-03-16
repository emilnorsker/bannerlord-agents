using System.Runtime.CompilerServices;
using System.Xml;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class DrivenPropertyEffect : MPPerkEffect
{
	protected static string StringType;

	private DrivenProperty _drivenProperty;

	private float _value;

	private bool _isRatio;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected DrivenPropertyEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUpdate(Agent agent, bool newState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDrivenPropertyBonus(DrivenProperty drivenProperty, float baseValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DrivenPropertyEffect()
	{
		throw null;
	}
}
