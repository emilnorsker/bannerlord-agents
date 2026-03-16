using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class Markable : ScriptComponentBehavior
{
	public string MarkerPrefabName;

	private GameEntity _marker;

	private DestructableComponent _destructibleComponent;

	private bool _markerActive;

	private bool _markerVisible;

	private float _markerEventBeginningTime;

	private float _markerActiveDuration;

	private float _markerPassiveDuration;

	private bool MarkerActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableMarkerActivation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateMarkerFor(float activeSeconds, float passiveSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeactivateMarker()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetPassiveDurationTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Markable()
	{
		throw null;
	}
}
