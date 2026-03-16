using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine;

public class JobManager
{
	private List<Job> _jobs;

	private object _locker;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JobManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddJob(Job job)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnTick(float dt)
	{
		throw null;
	}
}
