using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Missions.Objectives;

public abstract class MissionObjectiveTarget
{
	public abstract bool IsActive();

	public abstract TextObject GetName();

	public abstract Vec3 GetGlobalPosition();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MissionObjectiveTarget()
	{
		throw null;
	}
}
public abstract class MissionObjectiveTarget<T> : MissionObjectiveTarget
{
	public T Target
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionObjectiveTarget(T target)
	{
		throw null;
	}
}
