using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade.Multiplayer.Missions;

public class MultiplayerPracticeMissionComponent : MissionLogic
{
	private LobbyClient _lobbyClient;

	private float _lastMessagePrintPassedTime;

	private bool _shutDownMissionTriggered;

	private float _shutDownMissionTimer;

	private int _shutDownMissionCount;

	private const int ShutDownDurationInSeconds = 3;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InformMissionDuration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerPracticeMissionComponent()
	{
		throw null;
	}
}
