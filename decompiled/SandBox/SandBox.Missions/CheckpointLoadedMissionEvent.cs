using System.Runtime.CompilerServices;
using TaleWorlds.Library.EventSystem;

namespace SandBox.Missions;

public class CheckpointLoadedMissionEvent : EventBase
{
	public readonly int LoadedCheckpointUniqueId;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CheckpointLoadedMissionEvent(int loadedCheckpointUniqueId)
	{
		throw null;
	}
}
