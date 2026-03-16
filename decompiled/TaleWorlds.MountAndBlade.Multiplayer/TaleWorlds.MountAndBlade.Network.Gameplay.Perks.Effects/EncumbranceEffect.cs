using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class EncumbranceEffect : MPPerkEffect
{
	protected static string StringType;

	private bool _isOnBody;

	private float _value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected EncumbranceEffect()
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
	public override float GetEncumbrance(bool isOnBody)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static EncumbranceEffect()
	{
		throw null;
	}
}
