using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class CastleGateAI : UsableMachineAIBase
{
	private CastleGate.GateState _initialState;

	public override bool HasActionCompleted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetInitialGateState(CastleGate.GateState newInitialState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CastleGateAI(CastleGate gate)
	{
		throw null;
	}
}
