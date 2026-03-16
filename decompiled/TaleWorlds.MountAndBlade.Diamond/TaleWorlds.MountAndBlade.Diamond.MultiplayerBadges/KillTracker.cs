using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Diamond.MultiplayerBadges;

public class KillTracker : GameBadgeTracker
{
	private readonly string _badgeId;

	private readonly BadgeCondition _condition;

	private readonly Dictionary<(PlayerId, string, string), int> _dataDictionary;

	private readonly string _faction;

	private readonly string _troop;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public KillTracker(string badgeId, BadgeCondition condition, Dictionary<(PlayerId, string, string), int> dataDictionary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnKill(KillData killData)
	{
		throw null;
	}
}
