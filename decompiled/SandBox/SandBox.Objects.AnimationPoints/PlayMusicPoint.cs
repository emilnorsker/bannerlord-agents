using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects.AnimationPoints;

public class PlayMusicPoint : AnimationPoint
{
	private InstrumentData _instrumentData;

	private SoundEvent _trackEvent;

	private bool _hasInstrumentAttached;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartLoop(SoundEvent trackEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndLoop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnUseStopped(Agent userAgent, bool isSuccessful, int preferenceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeInstrument(Tuple<InstrumentData, float> instrument)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlayMusicPoint()
	{
		throw null;
	}
}
