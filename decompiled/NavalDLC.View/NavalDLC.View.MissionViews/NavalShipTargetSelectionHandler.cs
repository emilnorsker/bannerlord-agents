using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews;

public class NavalShipTargetSelectionHandler : MissionView
{
	public const float MaxDistanceForFocusCheck = 1000f;

	public const float MinDistanceForFocusCheck = 10f;

	public readonly float MaxDistanceToCenterForFocus;

	private readonly List<(MissionShip, float)> _distanceCache;

	private readonly MBList<MissionShip> _focusedShipsCache;

	private readonly MBList<MissionShip> _enemyShipsCache;

	private Vec2 _centerOfScreen;

	private bool _isTargetingDisabled;

	private Camera ActiveCamera
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event Action<MBReadOnlyList<MissionShip>> OnShipsFocused
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPreDisplayMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetShipDistanceToCenter(MissionShip ship, Vec3 cameraPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsFormationTargetingDisabled(bool isDisabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalShipTargetSelectionHandler()
	{
		throw null;
	}
}
