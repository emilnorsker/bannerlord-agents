using System.Runtime.CompilerServices;
using TaleWorlds.Library.EventSystem;

namespace TaleWorlds.MountAndBlade.Objects;

public class GenericMissionEvent : EventBase
{
	public readonly string EventId;

	public readonly string Parameter;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericMissionEvent(string eventId, string parameter)
	{
		throw null;
	}
}
