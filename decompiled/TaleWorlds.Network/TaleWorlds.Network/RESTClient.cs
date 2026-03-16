using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TaleWorlds.Network;

public class RESTClient
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGet_003Ed__4<TResult> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<TResult> _003C_003Et__builder;

		public RESTClient _003C_003E4__this;

		public string service;

		public List<KeyValuePair<string, string>> headers;

		private TaskAwaiter<WebResponse> _003C_003Eu__1;

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
	private struct _003CGet_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public RESTClient _003C_003E4__this;

		public string service;

		public List<KeyValuePair<string, string>> headers;

		private TaskAwaiter<WebResponse> _003C_003Eu__1;

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
	private struct _003CPost_003Ed__6<TResult> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<TResult> _003C_003Et__builder;

		public RESTClient _003C_003E4__this;

		public string service;

		public List<KeyValuePair<string, string>> headers;

		public string contentType;

		public string payLoad;

		private HttpWebRequest _003Chttp_003E5__2;

		private byte[] _003Cbytes_003E5__3;

		private TaskAwaiter<Stream> _003C_003Eu__1;

		private TaskAwaiter<WebResponse> _003C_003Eu__2;

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
	private struct _003CPost_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public RESTClient _003C_003E4__this;

		public string service;

		public List<KeyValuePair<string, string>> headers;

		public string contentType;

		public string payLoad;

		private HttpWebRequest _003Chttp_003E5__2;

		private byte[] _003Cbytes_003E5__3;

		private TaskAwaiter<Stream> _003C_003Eu__1;

		private TaskAwaiter<WebResponse> _003C_003Eu__2;

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

	private string _serviceAddress;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RESTClient(string serviceAddress)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ServiceException GetServiceErrorCode(Stream stream)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private HttpWebRequest CreateHttpRequest(string service, List<KeyValuePair<string, string>> headers, string contentType, string method)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGet_003Ed__4<>))]
	public Task<TResult> Get<TResult>(string service, List<KeyValuePair<string, string>> headers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGet_003Ed__5))]
	public Task Get(string service, List<KeyValuePair<string, string>> headers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CPost_003Ed__6<>))]
	public Task<TResult> Post<TResult>(string service, List<KeyValuePair<string, string>> headers, string payLoad, string contentType = "application/json")
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CPost_003Ed__7))]
	public Task Post(string service, List<KeyValuePair<string, string>> headers, string payLoad, string contentType = "application/json")
	{
		throw null;
	}
}
