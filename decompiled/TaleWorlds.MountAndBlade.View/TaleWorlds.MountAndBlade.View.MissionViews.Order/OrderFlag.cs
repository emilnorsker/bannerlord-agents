using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.Screens;

namespace TaleWorlds.MountAndBlade.View.MissionViews.Order;

public class OrderFlag
{
	private readonly GameEntity _entity;

	private readonly GameEntity _flag;

	private readonly GameEntity _gear;

	private readonly GameEntity _arrow;

	private readonly GameEntity _width;

	private readonly GameEntity _attack;

	private readonly GameEntity _flagUnavailable;

	private readonly GameEntity _widthLeft;

	private readonly GameEntity _widthRight;

	public bool IsTroop;

	private bool _isWidthVisible;

	private float _customWidth;

	private GameEntity _activeVisualEntity;

	protected readonly IEnumerable<IOrderableWithInteractionArea> _orderablesWithInteractionArea;

	protected readonly Mission _mission;

	protected readonly MissionScreen _missionScreen;

	private readonly float _arrowLength;

	private bool _isArrowVisible;

	private Vec2 _arrowDirection;

	public IOrderable FocusedOrderableObject
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

	public int LatestUpdateFrameNo
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

	public Vec3 Position
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		private set
		{
			throw null;
		}
	}

	public MatrixFrame Frame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsVisible
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
	public OrderFlag(Mission mission, MissionScreen missionScreen, float flagScale = 10f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetActiveVisualEntity(GameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCurrentMesh(bool isOnValidGround)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetArrowVisibility(bool isVisible, Vec2 arrowDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual Vec3 GetFlagPosition(out bool isOnValidGround, bool checkForTargetEntity, Vec3 targetCollisionPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void UpdateFrame(out bool isOnValidGround, bool checkForTargetEntity, Vec3 targetCollisionPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsPositionOnValidGround(WorldPosition worldPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsOrderPositionValid(WorldPosition orderPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WeakGameEntity GetCollidedEntity(out Vec3 closestPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWidthVisibility(bool isVisible, float width)
	{
		throw null;
	}
}
