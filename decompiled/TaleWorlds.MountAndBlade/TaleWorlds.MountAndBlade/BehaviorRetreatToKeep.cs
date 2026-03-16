using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class BehaviorRetreatToKeep : BehaviorComponent
{
	public override float NavmeshlessTargetPositionPenalty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorRetreatToKeep(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetAiWeight()
	{
		throw null;
	}
}
