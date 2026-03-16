using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.Library.Http;

public class HttpGetRequest : IHttpRequestTask
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CDoTask_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public HttpGetRequest _003C_003E4__this;

		private HttpRequestMessage _003CrequestMessage_003E5__2;

		private HttpResponseMessage _003Cresponse_003E5__3;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private HttpContent _003Ccontent_003E5__4;

		private TaskAwaiter<string> _003C_003Eu__2;

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

	private const int BufferSize = 1024;

	private HttpClient _httpClient;

	private readonly string _address;

	private Version _versionToUse;

	public HttpRequestTaskState State
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

	public string ResponseData
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

	public HttpStatusCode ResponseStatusCode
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

	public Exception Exception
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
	public HttpGetRequest(HttpClient httpClient, string address)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HttpGetRequest(HttpClient httpClient, string address, Version version)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetFinishedAsSuccessful(string responseData, HttpStatusCode statusCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetFinishedAsUnsuccessful(Exception e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Start()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CDoTask_003Ed__29))]
	private void DoTask()
	{
		throw null;
	}
}
