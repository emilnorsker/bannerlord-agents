using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Diamond.Lobby.LocalData;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace TaleWorlds.MountAndBlade;

public class MissionMatchHistoryComponent : MissionNetwork
{
	private bool _recordedHistory;

	private MatchHistoryData _matchHistoryData;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MissionMatchHistoryComponent CreateIfConditionsAreMet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionMatchHistoryComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void PrintDebugLog(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AddRemoveMessageHandlers(NetworkMessageHandlerRegistererContainer registerer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TeamChange(NetworkCommunicator player, Team oldTeam, Team nextTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventMissionStateChange(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}
}
