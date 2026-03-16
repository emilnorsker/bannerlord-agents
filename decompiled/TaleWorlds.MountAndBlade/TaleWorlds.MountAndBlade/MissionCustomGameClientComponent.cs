using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade;

public class MissionCustomGameClientComponent : MissionLobbyComponent
{
	private LobbyClient _lobbyClient;

	private bool _isServerEndedBeforeClientLoaded;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetServerEndingBeforeClientLoaded(bool isServerEndingBeforeClientLoaded)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void QuitMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionCustomGameClientComponent()
	{
		throw null;
	}
}
