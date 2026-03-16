using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NetworkMessages.FromClient;
using NetworkMessages.FromServer;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace TaleWorlds.MountAndBlade.Multiplayer.NetworkComponents;

public class BaseNetworkComponent : UdpNetworkComponent
{
	public delegate void WelcomeMessageReceivedDelegate(string messageText);

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CHandleServerEventLoadMission_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public GameNetworkMessage baseMessage;

		public BaseNetworkComponent _003C_003E4__this;

		private LoadMission _003Cmessage_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CInitializeCustomGameAux_003Ed__44 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public BaseNetworkComponent _003C_003E4__this;

		public InitializeCustomGameMessage message;

		private TaskAwaiter _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CHandleServerEventUnloadMissionAux_003Ed__45 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public BaseNetworkComponent _003C_003E4__this;

		public UnloadMission message;

		private TaskAwaiter _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CHandleClientEventFinishedLoadingAux_003Ed__47 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public BaseNetworkComponent _003C_003E4__this;

		public NetworkCommunicator networkPeer;

		public FinishedLoading message;

		private TaskAwaiter _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public Action OnIntermissionStateUpdated;

	private BaseNetworkComponentData _baseNetworkComponentData;

	public MultiplayerIntermissionState ClientIntermissionState
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

	public float CurrentIntermissionTimer
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

	public bool DisplayingWelcomeMessage
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

	public event WelcomeMessageReceivedDelegate WelcomeMessageReceived
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
	private void EnsureBaseNetworkComponentData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AddRemoveMessageHandlers(NetworkMessageHandlerRegistererContainer registerer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUdpNetworkHandlerTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void HandleNewClientConnect(PlayerConnectionInfo playerConnectionInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void HandlePlayerDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void IntermissionCastVote(string itemID, int voteCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void HandleNewClientAfterSynchronized(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUdpNetworkHandlerClose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDisplayingWelcomeMessage(bool displaying)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventMultiplayerOptionsInitial(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventMultiplayerOptionsImmediate(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventMultiplayerIntermissionUpdate(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventIntermissionMapItemAdded(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventUsableMapAdded(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSyncPlayerMuteState(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSyncMutedPlayers(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventUpdateIntermissionVotingManagerValues(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventIntermissionCultureItemAdded(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventIntermissionMapItemVoteCountChanged(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventIntermissionCultureItemVoteCountChanged(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAddPeerComponent(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventRemovePeerComponent(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSynchronizingDone(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CHandleServerEventLoadMission_003Ed__41))]
	private void HandleServerEventLoadMission(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventUnloadMission(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventInitializeCustomGame(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CInitializeCustomGameAux_003Ed__44))]
	private void InitializeCustomGameAux(InitializeCustomGameMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CHandleServerEventUnloadMissionAux_003Ed__45))]
	private void HandleServerEventUnloadMissionAux(UnloadMission message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventFinishedLoading(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CHandleClientEventFinishedLoadingAux_003Ed__47))]
	private void HandleClientEventFinishedLoadingAux(NetworkCommunicator networkPeer, FinishedLoading message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleSyncRelevantGameOptionsToServer(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleIntermissionClientVote(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BaseNetworkComponent()
	{
		throw null;
	}
}
