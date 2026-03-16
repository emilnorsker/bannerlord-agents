using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

internal class BurningSoundNode : ScriptComponentBehavior
{
	private const int MaxNumberOfCachedBurningNodes = 5;

	private const string _soundPath = "event:/mission/ambient/detail/fire/fire_dynamic";

	private const float FireRadius = 5f;

	private const float FireRadiusSq = 25f;

	private List<BurningNode> _burningNodesAttached;

	private bool _enabled;

	private float _burningSoundEventIntensityParam;

	private SoundEvent _burningSoundEvent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BurningSoundNode()
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
	protected override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTickParallel2(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddBurningNode(BurningNode node)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartFire()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopFire()
	{
		throw null;
	}
}
