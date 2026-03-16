using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class BehaviorMountedSkirmish : BehaviorComponent
{
	private struct Ellipse
	{
		private readonly Vec2 _center;

		private readonly float _radius;

		private readonly float _halfLength;

		private readonly Vec2 _direction;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Ellipse(Vec2 center, float radius, float halfLength, Vec2 direction)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Vec2 GetTargetPos(Vec2 position, float distance)
		{
			throw null;
		}
	}

	private bool _engaging;

	private bool _isEnemyReachable;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorMountedSkirmish(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CalculateCurrentOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TickOccasionally()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnBehaviorActivatedAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetAiWeight()
	{
		throw null;
	}
}
