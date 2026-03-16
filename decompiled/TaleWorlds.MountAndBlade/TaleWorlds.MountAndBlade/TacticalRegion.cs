using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade;

public class TacticalRegion : MissionObject
{
	public enum TacticalRegionTypeEnum
	{
		Forest,
		DifficultTerrain,
		Opening
	}

	public bool IsEditorDebugRingVisible;

	private WorldPosition _position;

	public float radius;

	private List<TacticalPosition> _linkedTacticalPositions;

	public TacticalRegionTypeEnum tacticalRegionType;

	public WorldPosition Position
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

	public List<TacticalPosition> LinkedTacticalPositions
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
	public override void AfterMissionStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TacticalRegion()
	{
		throw null;
	}
}
