using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class ShieldDamageEffect : MPPerkEffect
{
	private enum BlockType
	{
		Any,
		CorrectSide,
		WrongSide
	}

	protected static string StringType;

	private float _value;

	private BlockType _blockType;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ShieldDamageEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetShieldDamage(bool isCorrectSideBlock)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ShieldDamageEffect()
	{
		throw null;
	}
}
