using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace TaleWorlds.Library;

public abstract class TestCommonBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CWaitUntil_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public TestCommonBase _003C_003E4__this;

		public Func<bool> func;

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

	public int TestRandomSeed;

	public bool IsTestEnabled;

	public bool isParallelThread;

	public string SceneNameToOpenOnStartup;

	public object TestLock;

	private static TestCommonBase _baseInstance;

	private DateTime timeoutTimerStart;

	private bool timeoutTimerEnabled;

	private int commonWaitTimeoutLimits;

	public static TestCommonBase BaseInstance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public abstract void Tick();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartTimeoutTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToggleTimeoutTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckTimeoutTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected TestCommonBase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual string GetGameStatus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WaitFor(double seconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CWaitUntil_003Ed__18))]
	public virtual Task WaitUntil(Func<bool> func)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Task WaitForAsync(double seconds, Random random)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Task WaitForAsync(double seconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetAttachmentsFolderPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnFinalize()
	{
		throw null;
	}
}
