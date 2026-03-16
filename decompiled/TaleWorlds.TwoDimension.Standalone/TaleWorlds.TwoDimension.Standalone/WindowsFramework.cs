using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TaleWorlds.TwoDimension.Standalone;

public class WindowsFramework
{
	public bool IsActive;

	private FrameworkDomain[] _frameworkDomains;

	private Thread[] _frameworkDomainThreads;

	private Stopwatch _timer;

	private List<IMessageCommunicator> _messageCommunicators;

	public bool IsFinalized;

	private int _abortedThreadCount;

	public WindowsFrameworkThreadConfig ThreadConfig
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public long ElapsedTicks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public long TicksPerSecond
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WindowsFramework()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(FrameworkDomain[] frameworkDomains)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateThread(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterMessageCommunicator(IMessageCommunicator communicator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnRegisterMessageCommunicator(IMessageCommunicator communicator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MessageLoop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MainLoop(object parameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Stop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Start()
	{
		throw null;
	}
}
