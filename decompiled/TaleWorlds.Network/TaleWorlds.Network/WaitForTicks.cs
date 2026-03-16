using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

public class WaitForTicks : CoroutineState
{
	private int _beginTick;

	internal int TickCount
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

	protected internal override bool IsFinished
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WaitForTicks(int tickCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void Initialize(CoroutineManager coroutineManager)
	{
		throw null;
	}
}
