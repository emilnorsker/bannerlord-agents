using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade.Multiplayer;

public sealed class MapCheckHelpers
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CCheckMaps_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<(bool isRefusedToJoin, string notExistingMap)> _003C_003Et__builder;

		public GameServerEntry serverEntry;

		private TaskAwaiter<(bool isRefusedToJoin, string notExistingMap)> _003C_003Eu__1;

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
	private struct _003CCheckMapDownloaderMaps_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<(bool isRefusedToJoin, string notExistingMap)> _003C_003Et__builder;

		public GameServerEntry serverEntry;

		private Stopwatch _003Cwatch_003E5__2;

		private Task<string> _003CdownloadTask_003E5__3;

		private TaskAwaiter<Task> _003C_003Eu__1;

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

	private static readonly double TimeoutDuration;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string MapListEndpoint(GameServerEntry serverEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CCheckMaps_003Ed__2))]
	public static Task<(bool isRefusedToJoin, string notExistingMap)> CheckMaps(GameServerEntry serverEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckCurrentlyPlayedMap(GameServerEntry serverEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CCheckMapDownloaderMaps_003Ed__4))]
	private static Task<(bool isRefusedToJoin, string notExistingMap)> CheckMapDownloaderMaps(GameServerEntry serverEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool DoesSceneExist(string mapId, string uniqueMapId, string revision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MapCheckHelpers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MapCheckHelpers()
	{
		throw null;
	}
}
