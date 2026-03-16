using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class MBGlobals
{
	public const float Gravity = 9.806f;

	public static readonly Vec3 GravitationalAcceleration;

	private static bool _initialized;

	private static Dictionary<string, MBActionSet> _actionSets;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeReferences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBActionSet GetActionSetWithSuffix(Monster monster, bool isFemale, string suffix)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBActionSet GetActionSet(string actionSetCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetMethodName<T>(Expression<Func<T>> memberExpression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MBGlobals()
	{
		throw null;
	}
}
