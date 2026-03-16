using System.Runtime.CompilerServices;

namespace TaleWorlds.Diamond;

internal sealed class ThreadedClientCantConnectTask : ThreadedClientTask
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThreadedClientCantConnectTask(IClient client)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void DoJob()
	{
		throw null;
	}
}
