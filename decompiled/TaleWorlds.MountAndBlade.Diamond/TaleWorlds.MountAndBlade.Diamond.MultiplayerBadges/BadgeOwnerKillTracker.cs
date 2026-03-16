using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Diamond.MultiplayerBadges;

public class BadgeOwnerKillTracker : GameBadgeTracker
{
	private readonly string _badgeId;

	private readonly BadgeCondition _condition;

	private readonly List<string> _requiredBadges;

	private readonly Dictionary<(PlayerId, string, string), int> _dataDictionary;

	private readonly Dictionary<PlayerId, bool> _playerBadgeMap;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BadgeOwnerKillTracker(string badgeId, BadgeCondition condition, Dictionary<(PlayerId, string, string), int> dataDictionary)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerJoin(PlayerData playerData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnKill(KillData killData)
	{
		throw null;
	}
}
