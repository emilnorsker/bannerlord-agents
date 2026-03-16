using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Objects;

public class AreaMarker : MissionObject, ITrackableBase
{
	public float AreaRadius;

	public int AreaIndex;

	public bool CheckToggle;

	public virtual string Tag
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnEditorInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionInRange(Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual List<UsableMachine> GetUsableMachinesInRange(string excludeTag = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual List<UsableMachine> GetUsableMachinesWithTagInRange(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual List<GameEntity> GetGameEntitiesWithTagInRange(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual TextObject GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual Vec3 GetPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	TextObject ITrackableBase.GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vec3 ITrackableBase.GetPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AreaMarker()
	{
		throw null;
	}
}
