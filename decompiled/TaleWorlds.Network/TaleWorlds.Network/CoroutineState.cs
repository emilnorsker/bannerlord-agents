using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

public abstract class CoroutineState
{
	protected CoroutineManager CoroutineManager
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

	protected internal abstract bool IsFinished { get; }

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void Initialize(CoroutineManager coroutineManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected CoroutineState()
	{
		throw null;
	}
}
