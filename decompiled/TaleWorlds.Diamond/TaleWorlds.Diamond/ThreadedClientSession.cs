using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TaleWorlds.Diamond;

public class ThreadedClientSession : IClientSession
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DDiamond_002DIClientSession_002DLogin_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LoginResult> _003C_003Et__builder;

		public ThreadedClientSession _003C_003E4__this;

		public LoginMessage message;

		private ThreadedClientSessionLoginTask _003Ctask_003E5__2;

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
	private struct _003CTaleWorlds_002DDiamond_002DIClientSession_002DCallFunction_003Ed__14<TReturn> : IAsyncStateMachine where TReturn : FunctionResult
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<TReturn> _003C_003Et__builder;

		public ThreadedClientSession _003C_003E4__this;

		public Message message;

		private ThreadedClientSessionFunctionTask _003Ctask_003E5__2;

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

	private IClientSession _session;

	private ThreadedClient _threadedClient;

	private Queue<ThreadedClientSessionTask> _tasks;

	private ThreadedClientSessionTask _task;

	private volatile bool _tasBegunJob;

	private readonly int _threadSleepTime;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThreadedClientSession(ThreadedClient threadedClient, IClientSession session, int threadSleepTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshTask(Task previousTask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ThreadMain()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClientSession.Connect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClientSession.Disconnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IClientSession.Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DDiamond_002DIClientSession_002DLogin_003Ed__12))]
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
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DDiamond_002DIClientSession_002DCallFunction_003Ed__14<>))]
	Task<TReturn> IClientSession.CallFunction<TReturn>(Message message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Task<bool> IClientSession.CheckConnection()
	{
		throw null;
	}
}
