using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;

namespace SandBox.ViewModelCollection.Missions.NameMarker;

public abstract class MissionNameMarkerProvider
{
	private Action _onSetMarkersDirty;

	private bool _initialized;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionNameMarkerProvider()
	{
		throw null;
	}

	public abstract void CreateMarkers(List<MissionNameMarkerTargetBaseVM> markers);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(Mission mission, Action onSetMarkersDirty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Destroy(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnInitialize(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnDestroy(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SetMarkersDirty()
	{
		throw null;
	}
}
