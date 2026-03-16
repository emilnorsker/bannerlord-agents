using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class GoldGainOnAssistEffect : MPPerkEffect
{
	protected static string StringType;

	private int _value;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GoldGainOnAssistEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetGoldOnAssist()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GoldGainOnAssistEffect()
	{
		throw null;
	}
}
