using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.View;

public static class ViewCreatorManager
{
	private static Dictionary<string, MBList<MethodInfo>> _viewCreators;

	private static Dictionary<Type, MBList<Type>> _actualViewTypes;

	private static HashSet<Type> _defaultTypes;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ViewCreatorManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CollectTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CheckAssemblyScreens(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IEnumerable<MissionBehavior> CreateDefaultMissionBehaviors(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IEnumerable<MissionBehavior> CollectMissionBehaviors(string missionName, Mission mission, IEnumerable<MissionBehavior> behaviors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ScreenBase CreateScreenView<T>() where T : ScreenBase, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ScreenBase CreateScreenView<T>(params object[] parameters) where T : ScreenBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionView<T>(bool isNetwork = false, Mission mission = null, params object[] parameters) where T : MissionView, new()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionViewWithArgs<T>(params object[] parameters) where T : MissionView
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CheckOverridenViews(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CollectDefaults(Assembly assembly)
	{
		throw null;
	}
}
