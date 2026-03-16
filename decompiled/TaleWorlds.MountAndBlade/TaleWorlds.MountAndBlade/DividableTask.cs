using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class DividableTask
{
	private bool _isTaskCompletelyFinished;

	private bool _isMainTaskFinished;

	private bool _lastActionCalled;

	private DividableTask _continueToTask;

	private Action _lastAction;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DividableTask(DividableTask continueToTask = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetTaskStatus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTaskFinished(bool callLastAction = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLastAction(Action action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual bool UpdateExtra()
	{
		throw null;
	}
}
