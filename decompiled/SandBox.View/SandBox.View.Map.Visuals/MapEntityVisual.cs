using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace SandBox.View.Map.Visuals;

public abstract class MapEntityVisual
{
	public MapScreen MapScreen
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public abstract CampaignVec2 InteractionPositionForPlayer { get; }

	public abstract MapEntityVisual AttachedTo { get; }

	public virtual bool IsMobileEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual MatrixFrame CircleLocalFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public virtual bool IsMainEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public virtual float BearingRotation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public abstract bool OnMapClick(bool followModifierUsed);

	public abstract void OnHover();

	public abstract void OnOpenEncyclopedia();

	public abstract bool IsVisibleOrFadingOut();

	public abstract Vec3 GetVisualPosition();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void ReleaseResources()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnHoverEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnTrackAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsEnemyOf(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsAllyOf(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MapEntityVisual()
	{
		throw null;
	}
}
public abstract class MapEntityVisual<T> : MapEntityVisual
{
	public T MapEntity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapEntityVisual(T entity)
	{
		throw null;
	}
}
