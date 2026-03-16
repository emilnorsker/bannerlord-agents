using System.Runtime.CompilerServices;
using NavalDLC.Map;
using SandBox.View.Map.Visuals;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.View.Map.Visuals;

public class StormVisual : MapEntityVisual<Storm>
{
	private enum StormVisualState
	{
		VisualNotInitialized,
		Developing,
		Active,
		Finalizing,
		ReadyToBeReleased
	}

	public const int DefaultStormVisualHeight = 0;

	private StormVisualState _visualState;

	private SoundEvent _stormSoundEvent;

	public GameEntity VisualEntity;

	private Scene _mapScene;

	public override CampaignVec2 InteractionPositionForPlayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override MapEntityVisual AttachedTo
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsReadyToBeReleased
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StormVisual(Storm storm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool OnMapClick(bool followModifierUsed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnHover()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnOpenEncyclopedia()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsVisibleOrFadingOut()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec3 GetVisualPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VisualTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateVisualState(StormVisualState newState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private StormVisualState GetStormVisualState(Storm storm)
	{
		throw null;
	}
}
