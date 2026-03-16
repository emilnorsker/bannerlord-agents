using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond.MultiplayerBadges;

public static class BadgeManager
{
	public const string PropertyParameterName = "property";

	public const string ValueParameterName = "value";

	public const string MinValueParameterName = "min_value";

	public const string MaxValueParameterName = "max_value";

	public const string IsBestParameterName = "is_best";

	private static Dictionary<string, Badge> _badgesById;

	private static Dictionary<BadgeType, List<Badge>> _badgesByType;

	public static List<Badge> Badges
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public static bool IsInitialized
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeWithXML(string xmlPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void LoadFromXml(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Badge GetByIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Badge GetById(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<Badge> GetByType(BadgeType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetBadgeConditionValue(this PlayerData playerData, BadgeCondition condition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetBadgeConditionNumericValue(this PlayerData playerData, BadgeCondition condition)
	{
		throw null;
	}
}
