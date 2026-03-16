using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaleWorlds.Library.Http;

namespace TaleWorlds.Diamond.Rest;

public class ClientRestSession : IClientSession
{
	private enum ConnectionResultType
	{
		None,
		Connected,
		Disconnected,
		CantConnect
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DDiamond_002DIClientSession_002DLogin_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

		public LoginMessage message;

		public ClientRestSession _003C_003E4__this;

		private ClientRestSessionTask _003CclientRestSessionTask_003E5__2;

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
	private struct _003CTaleWorlds_002DDiamond_002DIClientSession_002DCallFunction_003Ed__33<TResult> : IAsyncStateMachine where TResult : FunctionResult
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<TResult> _003C_003Et__builder;

		public ClientRestSession _003C_003E4__this;

		public Message message;

		private ClientRestSessionTask _003CclientRestSessionTask_003E5__2;

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
	private struct _003CTaleWorlds_002DDiamond_002DIClientSession_002DCheckConnection_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public ClientRestSession _003C_003E4__this;

		private TaskAwaiter<string> _003C_003Eu__1;

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

	private static readonly long CriticalStateCheckTime;

	private readonly Queue<ClientRestSessionTask> _messageTaskQueue;

	private readonly string _address;

	private byte[] _userCertificate;

	private ClientRestSessionTask _currentMessageTask;

	private ConnectionResultType _currentConnectionResultType;

	private Stopwatch _timer;

	private long _lastRequestOperationTime;

	private bool _sessionInitialized;

	private SessionCredentials _sessionCredentials;

	private RestDataJsonConverter _restDataJsonConverter;

	private IHttpDriver _platformNetworkClient;

	public bool IsConnected
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

	public IClient Client
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
	public ClientRestSession(IClient client, string address, IHttpDriver platformNetworkClient)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssignRequestJob(ClientRestSessionTask requestMessageTask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveRequestJob()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClientSession.Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TryAssignJob()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearMessageTaskQueueDueToDisconnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Connect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Disconnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendMessage(RestRequestMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DDiamond_002DIClientSession_002DLogin_003Ed__31))]
	Task<LoginResult> IClientSession.Login(LoginMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClientSession.SendMessage(Message message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DDiamond_002DIClientSession_002DCallFunction_003Ed__33<>))]
	Task<TResult> IClientSession.CallFunction<TResult>(Message message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleMessage(Message message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDisconnected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCantConnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DDiamond_002DIClientSession_002DCheckConnection_003Ed__38))]
	Task<bool> IClientSession.CheckConnection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ClientRestSession()
	{
		throw null;
	}
}
