using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class GoldGainOnKillEffect : MPPerkEffect
{
	private enum EnemyValue
	{
		Any,
		Higher,
		Lower
	}

	protected static string StringType;

	private int _value;

	private EnemyValue _enemyValue;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected GoldGainOnKillEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetGoldOnKill(float attackerValue, float victimValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static GoldGainOnKillEffect()
	{
		throw null;
	}
}
