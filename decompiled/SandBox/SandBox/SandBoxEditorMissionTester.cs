using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;

namespace SandBox;

internal class SandBoxEditorMissionTester : IEditorMissionTester
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	void IEditorMissionTester.StartMissionForEditor(string missionName, string sceneName, string levels)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IEditorMissionTester.StartMissionForReplayEditor(string missionName, string sceneName, string levels, string fileName, bool record, float startTime, float endTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandBoxEditorMissionTester()
	{
		throw null;
	}
}
