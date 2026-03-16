using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Missions.Objectives;

internal class GenericMissionObjectiveTarget<T> : MissionObjectiveTarget<T>
{
	internal Func<T, bool> IsActiveCallback;

	internal Func<T, TextObject> GetNameCallback;

	internal Func<T, Vec3> GetGlobalPositionCallback;

	internal TextObject Name;

	internal Vec3 StaticPosition;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericMissionObjectiveTarget(T target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec3 GetGlobalPosition()
	{
		throw null;
	}
}
