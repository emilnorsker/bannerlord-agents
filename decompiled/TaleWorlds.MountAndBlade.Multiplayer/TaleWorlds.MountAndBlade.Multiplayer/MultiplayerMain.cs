using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Diamond.ClientApplication;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond;

namespace TaleWorlds.MountAndBlade.Multiplayer;

public static class MultiplayerMain
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CGetDedicatedCustomServerAuthToken_003Ed__20 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

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

	private static ClientApplicationConfiguration _lobbyClientApplicationConfiguration;

	private static DiamondClientApplication _diamondClientApplication;

	public static LobbyClient GameClient
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool IsInitialized
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
	static MultiplayerMain()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize(IGameNetworkHandler gameNetworkHandler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InitializeAsDedicatedServer(IGameNetworkHandler gameNetworkHandler)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MultiplayerGameType[] GetAvailableRankedGameModes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MultiplayerGameType[] GetAvailableCustomGameModes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MultiplayerGameType[] GetAvailableQuickPlayGameModes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetAvailableMatchmakerRegions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetUserDefaultRegion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetUserCurrentRegion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetUserSelectedGameTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("gettoken", "customserver")]
	public static string GetDedicatedCustomServerAuthToken(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CGetDedicatedCustomServerAuthToken_003Ed__20))]
	private static void GetDedicatedCustomServerAuthToken()
	{
		throw null;
	}
}
