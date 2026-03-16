using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.Objects;

public class GenericMissionEventScript : ScriptComponentBehavior
{
	public string EventId;

	public string Parameter;

	[EditableScriptComponentVariable(false, "")]
	public bool IsDisabled;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericMissionEventScript()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericMissionEventScript(string eventId, string parameter)
	{
		throw null;
	}
}
