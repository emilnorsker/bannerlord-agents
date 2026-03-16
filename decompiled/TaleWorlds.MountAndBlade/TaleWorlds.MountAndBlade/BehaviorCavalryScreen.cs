using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class BehaviorCavalryScreen : BehaviorComponent
{
	private Formation _mainFormation;

	private Formation _flankingEnemyCavalryFormation;

	private float _threatFormationCacheTime;

	private const float _threatFormationCacheExpireTime = 5f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BehaviorCavalryScreen(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnValidBehaviorSideChanged()
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
	public override TextObject GetBehaviorString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override float GetAiWeight()
	{
		throw null;
	}
}
