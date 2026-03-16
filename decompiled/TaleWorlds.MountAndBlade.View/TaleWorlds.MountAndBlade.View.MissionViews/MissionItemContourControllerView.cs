using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

public class MissionItemContourControllerView : MissionView
{
	private const float SceneItemQueryFreq = 1f;

	private readonly WeakGameEntity[] _tempPickableEntities;

	private readonly UIntPtr[] _pickableItemsId;

	private readonly List<GameEntity> _contourItems;

	private GameEntity _focusedGameEntity;

	private IFocusable _currentFocusedObject;

	private bool _isContourAppliedToAllItems;

	private bool _isContourAppliedToFocusedItem;

	private readonly uint _nonFocusedDefaultContourColor;

	private readonly uint _nonFocusedAmmoContourColor;

	private readonly uint _nonFocusedThrowableContourColor;

	private readonly uint _nonFocusedBannerContourColor;

	private readonly uint _focusedContourColor;

	private float _lastItemQueryTime;

	private static bool IsAllowedByOption
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFocusGained(Agent agent, IFocusable focusableObject, bool isInteractable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFocusLost(Agent agent, IFocusable focusableObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateContourListWithNearbyItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyContourToAllItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private uint GetNonFocusedColor(GameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveContourFromAllItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddContourToFocusedItem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveContourFromFocusedItem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private UsableMachine GetUsableMachineFromPoint(UsableMissionObject standingPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionItemContourControllerView()
	{
		throw null;
	}
}
