using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;

public class MissionEntitySelectionUIHandler : MissionView
{
	private Action<WeakGameEntity> onSelect;

	private Action<WeakGameEntity> onHover;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionEntitySelectionUIHandler(Action<WeakGameEntity> onSelect = null, Action<WeakGameEntity> onHover = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WeakGameEntity GetCollidedEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	public void TickDebug()
	{
		throw null;
	}
}
