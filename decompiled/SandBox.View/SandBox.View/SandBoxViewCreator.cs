using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using SandBox.View.Map;
using SandBox.View.Menu;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.ScreenSystem;

namespace SandBox.View;

public static class SandBoxViewCreator
{
	private static Dictionary<Type, MBList<Type>> _actualViewTypes;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SandBoxViewCreator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CollectTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CheckOverridenViews(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ScreenBase CreateSaveLoadScreen(bool isSaving)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionCraftingView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionNameMarkerUIHandler(Mission mission = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionConversationView(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionBarterView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionAgentAlarmStateView(Mission mission = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionMainAgentDetectionView(Mission mission = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionStealthFailCounter(Mission mission = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionTournamentView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionQuestBarView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MapView CreateMapView<T>(params object[] parameters) where T : MapView
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MenuView CreateMenuView<T>(params object[] parameters) where T : MenuView
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateBoardGameView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionView CreateMissionArenaPracticeFightView()
	{
		throw null;
	}
}
