using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.View.Map.Visuals;

public class MapWeatherVisual : MapEntityVisual<WeatherNode>
{
	public GameEntity Prefab;

	private WeatherEvent _previousWeatherEvent;

	private int _maskPixelIndex;

	public Vec2 Position
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public Vec2 PrefabSpawnOffset
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public int MaskPixelIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapWeatherVisual(WeatherNode weatherNode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AttachNewRainPrefabToVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AttachNewBlizzardPrefabToVisual()
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
}
