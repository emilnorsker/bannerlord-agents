using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem;

public struct AIBehaviorData : IEquatable<AIBehaviorData>
{
	public static readonly AIBehaviorData Invalid;

	public IMapPoint Party;

	public CampaignVec2 Position;

	public AiBehavior AiBehavior;

	public bool WillGatherArmy;

	public bool IsFromPort;

	public bool IsTargetingPort;

	public MobileParty.NavigationType NavigationType;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AIBehaviorData(IMapPoint party, AiBehavior aiBehavior, MobileParty.NavigationType navigationType, bool willGatherArmy, bool isFromPort, bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AIBehaviorData(CampaignVec2 position, AiBehavior aiBehavior, MobileParty.NavigationType navigationType, bool willGatherArmy, bool isFromPort, bool isTargetingPort)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool Equals(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Equals(AIBehaviorData other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetHashCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator ==(AIBehaviorData a, AIBehaviorData b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool operator !=(AIBehaviorData a, AIBehaviorData b)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static AIBehaviorData()
	{
		throw null;
	}
}
