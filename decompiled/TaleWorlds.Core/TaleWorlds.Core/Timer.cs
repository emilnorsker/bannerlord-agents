using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class Timer
{
	private float _latestGameTime;

	private bool _autoReset;

	public float StartTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public float Duration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public float PreviousDeltaTime
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
	public Timer(float gameTime, float duration, bool autoReset = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool Check(float gameTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float ElapsedTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset(float gameTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset(float gameTime, float newDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdjustStartTime(float deltaTime)
	{
		throw null;
	}
}
