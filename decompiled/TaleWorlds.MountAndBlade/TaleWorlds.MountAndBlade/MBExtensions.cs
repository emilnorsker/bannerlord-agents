using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public static class MBExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Vec2 GetGlobalOrganicDirectionAux(ColumnFormation columnFormation, int depthCount = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 GetGlobalOrganicDirection(this ColumnFormation columnFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 GetGlobalHeadDirection(this ColumnFormation columnFormation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<T> FindAllWithType<T>(this IEnumerable<GameEntity> entities) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<T> FindAllWithType<T>(this IEnumerable<MissionObject> missionObjects) where T : MissionObject
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<GameEntity> FindAllWithCompatibleType(this IEnumerable<GameEntity> sceneProps, params Type[] types)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<MissionObject> FindAllWithCompatibleType(this IEnumerable<MissionObject> missionObjects, params Type[] types)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CollectScriptComponentsIncludingChildrenAux<T>(GameEntity entity, MBList<T> list) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CollectScriptComponentsIncludingChildrenAux<T>(WeakGameEntity entity, MBList<T> list) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<T> CollectScriptComponentsIncludingChildrenRecursive<T>(this GameEntity entity) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MBList<T> CollectScriptComponentsIncludingChildrenRecursive<T>(this WeakGameEntity entity) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<T> CollectScriptComponentsWithTagIncludingChildrenRecursive<T>(this GameEntity entity, string tag) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<T> CollectScriptComponentsWithTagIncludingChildrenRecursive<T>(this WeakGameEntity entity, string tag) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<GameEntity> CollectChildrenEntitiesWithTag(this GameEntity entity, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<WeakGameEntity> CollectChildrenEntitiesWithTag(this WeakGameEntity entity, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WeakGameEntity GetFirstChildEntityWithName(this WeakGameEntity entity, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetFirstScriptInFamilyDescending<T>(this GameEntity entity) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T GetFirstScriptInFamilyDescending<T>(this WeakGameEntity entity) where T : ScriptComponentBehavior
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HasParentOfType(this GameEntity e, Type t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HasParentOfType(this WeakGameEntity e, Type t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TSource ElementAtOrValue<TSource>(this IEnumerable<TSource> source, int index, TSource value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsOpponentOf(this BattleSideEnum s, BattleSideEnum side)
	{
		throw null;
	}
}
