using System.Runtime.CompilerServices;

namespace TaleWorlds.Diamond;

internal abstract class ThreadedClientTask
{
	public IClient Client
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
	protected ThreadedClientTask(IClient client)
	{
		throw null;
	}

	public abstract void DoJob();
}
