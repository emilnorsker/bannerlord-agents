using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaleWorlds.Library.Http;

namespace TaleWorlds.Diamond.Rest;

internal class ClientRestSessionTask
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CWaitUntilFinished_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ClientRestSessionTask _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

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

	private static readonly int RequestRetryTimeout;

	private readonly Type[] RetryableExceptions;

	public bool _willTryAgain;

	private string _requestAddress;

	private string _postData;

	private string _messageName;

	private int _maxIterationCount;

	private int _currentIterationCount;

	private Stopwatch _sw;

	private TaskCompletionSource<bool> _taskCompletionSource;

	private IHttpDriver _networkClient;

	private bool _resultExamined;

	public RestRequestMessage RestRequestMessage
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

	public bool Finished
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

	public bool Successful
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

	public IHttpRequestTask Request
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

	public RestResponse RestResponse
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

	public bool IsCompletelyFinished
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClientRestSessionTask(RestRequestMessage restRequestMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRequestData(byte[] userCertificate, string address, IHttpDriver networkClient)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DetermineNextTry()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetCode(WebException webException)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExamineResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CWaitUntilFinished_003Ed__40))]
	public Task WaitUntilFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFinishedAsSuccessful(RestResponse restResponse)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFinishedAsFailed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFinishedAsFailed(RestResponse restResponse)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateAndSetRequest()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PrintExceptions(Exception e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ClientRestSessionTask()
	{
		throw null;
	}
}
