using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TaleWorlds.Library.Http;

public class DotNetHttpDriver : IHttpDriver
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DLibrary_002DHttp_002DIHttpDriver_002DHttpGetString_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public DotNetHttpDriver _003C_003E4__this;

		public string url;

		private HttpResponseMessage _003CresponseMessage_003E5__2;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DLibrary_002DHttp_002DIHttpDriver_002DHttpPostString_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public DotNetHttpDriver _003C_003E4__this;

		public string url;

		public string postData;

		public string mediaType;

		private HttpResponseMessage _003Cresponse_003E5__2;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private HttpContent _003Ccontent_003E5__3;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DLibrary_002DHttp_002DIHttpDriver_002DHttpDownloadData_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<byte[]> _003C_003Et__builder;

		public DotNetHttpDriver _003C_003E4__this;

		public string url;

		private TaskAwaiter<byte[]> _003C_003Eu__1;

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

	private HttpClient _httpClient;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DotNetHttpDriver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IHttpRequestTask IHttpDriver.CreateHttpPostRequestTask(string address, string postData, bool withUserToken)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IHttpRequestTask IHttpDriver.CreateHttpGetRequestTask(string address, bool withUserToken)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DLibrary_002DHttp_002DIHttpDriver_002DHttpGetString_003Ed__4))]
	Task<string> IHttpDriver.HttpGetString(string url, bool withUserToken)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DLibrary_002DHttp_002DIHttpDriver_002DHttpPostString_003Ed__5))]
	Task<string> IHttpDriver.HttpPostString(string url, string postData, string mediaType, bool withUserToken)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DLibrary_002DHttp_002DIHttpDriver_002DHttpDownloadData_003Ed__6))]
	Task<byte[]> IHttpDriver.HttpDownloadData(string url)
	{
		throw null;
	}
}
