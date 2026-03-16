using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Network;

namespace TaleWorlds.Core;

public class WaitForGameState : CoroutineState
{
	private Type _stateType;

	protected override bool IsFinished
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WaitForGameState(Type stateType)
	{
		throw null;
	}
}
