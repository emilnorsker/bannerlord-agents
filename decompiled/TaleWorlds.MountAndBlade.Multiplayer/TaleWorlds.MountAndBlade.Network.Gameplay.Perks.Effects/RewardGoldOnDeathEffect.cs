using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml;

namespace TaleWorlds.MountAndBlade.Network.Gameplay.Perks.Effects;

public class RewardGoldOnDeathEffect : MPPerkEffect
{
	private enum OrderBy
	{
		Random = 0,
		WealthAscending = 1,
		WealthDescending = 2,
		DistanceAscending = 3,
		DistanceDescending = 4,
		DeadCanReceiveEnd = 3
	}

	protected static string StringType;

	private int _value;

	private int _count;

	private OrderBy _orderBy;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected RewardGoldOnDeathEffect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Deserialize(XmlNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool GetIsTeamRewardedOnDeath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void CalculateRewardedGoldOnDeath(Agent agent, List<(MissionPeer, int)> teamMembers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int SortByDistance(Agent from, Agent a, Agent b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static RewardGoldOnDeathEffect()
	{
		throw null;
	}
}
