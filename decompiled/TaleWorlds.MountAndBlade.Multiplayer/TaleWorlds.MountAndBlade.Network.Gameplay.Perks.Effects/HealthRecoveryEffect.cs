using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class HealthRecoveryEffect : MPPerkEffect
{
	protected static string StringType;

	private float _value;

	private int _period;

	public override bool IsTickRequired
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected HealthRecoveryEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTick(Agent agent, int tickCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static HealthRecoveryEffect()
	{
		throw null;
	}
}
