using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class AgentProximityMap
{
	public struct ProximityMapSearchStruct
	{
		internal ProximityMapSearchStructInternal SearchStructInternal;

		internal bool LoopAllAgents;

		internal int LastAgentLoopIndex;

		public Agent LastFoundAgent
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			internal set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void RefreshLastFoundAgent(Mission mission)
		{
			throw null;
		}
	}

	[Serializable]
	[EngineStruct("Managed_proximity_map_search_struct", false, null)]
	internal struct ProximityMapSearchStructInternal
	{
		internal int CurrentElementIndex;

		internal Vec2i Loc;

		internal Vec2i GridMin;

		internal Vec2i GridMax;

		internal Vec2 SearchPos;

		internal float SearchDistSq;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal Agent GetCurrentAgent(Mission mission)
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanSearchRadius(float searchRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ProximityMapSearchStruct BeginSearch(Mission mission, Vec2 searchPos, float searchRadius, bool extendRangeByBiggestAgentCollisionPadding = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FindNext(Mission mission, ref ProximityMapSearchStruct searchStruct)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AgentProximityMap()
	{
		throw null;
	}
}
