using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerMissionAgentVisualSpawnComponent : MissionNetwork
{
	private class VisualSpawnFrameSelectionHelper
	{
		private const string SpawnPointTagPrefix = "sp_visual_";

		private const string AttackerSpawnPointTagPrefix = "sp_visual_attacker_";

		private const string DefenderSpawnPointTagPrefix = "sp_visual_defender_";

		private const int NumberOfSpawnPoints = 6;

		private const int PlayerSpawnPointIndex = 0;

		private GameEntity[] _visualSpawnPoints;

		private GameEntity[] _visualAttackerSpawnPoints;

		private GameEntity[] _visualDefenderSpawnPoints;

		private VirtualPlayer[] _visualSpawnPointUsers;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public VisualSpawnFrameSelectionHelper()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MatrixFrame GetSpawnPointFrameForPlayer(VirtualPlayer player, BattleSideEnum side, int agentVisualIndex, int totalTroopCount, bool isMounted = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FreeSpawnPointFromPlayer(VirtualPlayer player)
		{
			throw null;
		}
	}

	private VisualSpawnFrameSelectionHelper _spawnFrameSelectionHelper;

	public event Action OnMyAgentVisualSpawned
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action OnMyAgentSpawnedFromVisual
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action OnMyAgentVisualRemoved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SpawnAgentVisualsForPeer(MissionPeer missionPeer, AgentBuildData buildData, int selectedEquipmentSetIndex = -1, bool isBot = false, int totalTroopCount = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAgentVisuals(MissionPeer missionPeer, bool sync = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMyAgentSpawned()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerMissionAgentVisualSpawnComponent()
	{
		throw null;
	}
}
