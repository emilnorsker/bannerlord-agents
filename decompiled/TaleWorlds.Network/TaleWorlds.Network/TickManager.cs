using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

public class TickManager
{
	public delegate void TickDelegate();

	private Stopwatch _stopwatch;

	private int _tickRate;

	private TickDelegate _tickMethod;

	private double _residualWaitTime;

	private double _numberOfTicksPerMilisecond;

	private double _inverseNumberOfTicksPerMilisecond;

	private double _maxTickMilisecond;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TickManager(int tickRate, TickDelegate tickMethod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}
}
