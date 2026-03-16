using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.Objects;

namespace SandBox.Objects.AreaMarkers;

public class StealthAreaMarker : AreaMarker
{
	private const string ReinforcementAllyGroupSpawnPointTag = "reinforcement_ally_group_spawn_point_tag";

	private const string WaitPointTag = "wait_point_tag";

	public string ReinforcementAllyGroupId;

	public GameEntity ReinforcementAllyGroupSpawnPoint
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

	public GameEntity WaitPoint
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
	public override void AfterMissionStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StealthAreaMarker()
	{
		throw null;
	}
}
