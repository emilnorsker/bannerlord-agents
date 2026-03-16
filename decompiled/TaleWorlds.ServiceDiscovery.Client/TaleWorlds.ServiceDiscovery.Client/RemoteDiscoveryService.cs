using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TaleWorlds.ServiceDiscovery.Client;

public class RemoteDiscoveryService : IDiscoveryService
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DServiceDiscovery_002DClient_002DIDiscoveryService_002DResolveService_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ServiceAddress[]> _003C_003Et__builder;

		public RemoteDiscoveryService _003C_003E4__this;

		public string service;

		public string tag;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DServiceDiscovery_002DClient_002DIDiscoveryService_002DResolveServiceByTag_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ServiceResolvedAddress> _003C_003Et__builder;

		public RemoteDiscoveryService _003C_003E4__this;

		public string tag;

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

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DServiceDiscovery_002DClient_002DIDiscoveryService_002DDiscoverServices_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ServiceAddress[]> _003C_003Et__builder;

		public RemoteDiscoveryService _003C_003E4__this;

		private HttpClient _003Cclient_003E5__2;

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

	private readonly string _address;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RemoteDiscoveryService(string address)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DServiceDiscovery_002DClient_002DIDiscoveryService_002DResolveService_003Ed__2))]
	Task<ServiceAddress[]> IDiscoveryService.ResolveService(string service, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DServiceDiscovery_002DClient_002DIDiscoveryService_002DResolveServiceByTag_003Ed__3))]
	Task<ServiceResolvedAddress> IDiscoveryService.ResolveServiceByTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DServiceDiscovery_002DClient_002DIDiscoveryService_002DDiscoverServices_003Ed__4))]
	Task<ServiceAddress[]> IDiscoveryService.DiscoverServices()
	{
		throw null;
	}
}
