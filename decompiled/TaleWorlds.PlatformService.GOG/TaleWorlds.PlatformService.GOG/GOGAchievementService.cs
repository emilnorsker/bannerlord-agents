using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaleWorlds.AchievementSystem;

namespace TaleWorlds.PlatformService.GOG;

public class GOGAchievementService : IAchievementService
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CTaleWorlds_002DAchievementSystem_002DIAchievementService_002DGetStat_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<int> _003C_003Et__builder;

		public GOGAchievementService _003C_003E4__this;

		public string name;

		private TaskAwaiter<int> _003C_003Eu__1;

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
	private struct _003CTaleWorlds_002DAchievementSystem_002DIAchievementService_002DGetStats_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<int[]> _003C_003Et__builder;

		public GOGAchievementService _003C_003E4__this;

		public string[] names;

		private TaskAwaiter<int[]> _003C_003Eu__1;

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

	private GOGPlatformServices _gogPlatformServices;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GOGAchievementService(GOGPlatformServices epicPlatformServices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IAchievementService.SetStat(string name, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DAchievementSystem_002DIAchievementService_002DGetStat_003Ed__3))]
	Task<int> IAchievementService.GetStat(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CTaleWorlds_002DAchievementSystem_002DIAchievementService_002DGetStats_003Ed__4))]
	Task<int[]> IAchievementService.GetStats(string[] names)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IAchievementService.IsInitializationCompleted()
	{
		throw null;
	}
}
