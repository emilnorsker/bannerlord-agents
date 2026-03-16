using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public abstract class SpawnFrameBehaviorBase
{
	private struct WeightCache
	{
		private const int Length = 3;

		private float _value1;

		private float _value2;

		private float _value3;

		private float this[int index]
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private WeightCache(float value1, float value2, float value3)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static WeightCache CreateDecreasingCache()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool CheckAndInsertNewValueIfLower(float value, out float valueDifference)
		{
			throw null;
		}
	}

	private const string ExcludeMountedTag = "exclude_mounted";

	private const string ExcludeFootmenTag = "exclude_footmen";

	protected const string SpawnPointTag = "spawnpoint";

	public IEnumerable<GameEntity> SpawnPoints;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected SpawnFrameBehaviorBase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void Initialize()
	{
		throw null;
	}

	public abstract MatrixFrame GetSpawnFrame(Team team, bool hasMount, bool isInitialSpawn);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MatrixFrame GetSpawnFrameFromSpawnPoints(IList<GameEntity> spawnPointsList, Team team, bool hasMount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}
}
