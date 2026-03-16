using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public sealed class BehaviorAdvance : BehaviorComponent
{
	private bool _isInShieldWallDistance;

	private bool _switchedToShieldWallRecently;

	private Timer _switchedToShieldWallTimer;

	private Vec2 _reformPosition;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorAdvance(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBehaviorActivatedAux()
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
