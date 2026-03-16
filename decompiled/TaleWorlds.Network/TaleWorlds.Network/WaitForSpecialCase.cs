using System.Runtime.CompilerServices;

namespace TaleWorlds.Network;

public class WaitForSpecialCase : CoroutineState
{
	public delegate bool IsConditionSatisfiedDelegate();

	private IsConditionSatisfiedDelegate _isConditionSatisfiedDelegate;

	protected internal override bool IsFinished
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WaitForSpecialCase(IsConditionSatisfiedDelegate isConditionSatisfiedDelegate)
	{
		throw null;
	}
}
