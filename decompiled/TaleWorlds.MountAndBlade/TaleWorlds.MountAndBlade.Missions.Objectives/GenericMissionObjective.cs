using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.Missions.Objectives;

internal class GenericMissionObjective : MissionObjective
{
	internal string IUniqueId;

	internal TextObject IName;

	internal TextObject IDescription;

	internal Func<MissionObjective, bool> IsActivationRequirementsMetCallback;

	internal Func<MissionObjective, bool> IsCompletionRequirementsMetCallback;

	internal Action<MissionObjective> OnStartCallback;

	internal Action<MissionObjective> OnCompleteCallback;

	internal Action<MissionObjective, float> OnTickCallback;

	internal Func<MissionObjective, MissionObjectiveProgressInfo> GetProgressCallback;

	private List<MissionObjectiveTarget> _targets;

	public override string UniqueId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject Description
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GenericMissionObjective(Mission mission, string id, TextObject name, TextObject description)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MissionObjectiveProgressInfo GetCurrentProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsActivationRequirementsMet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsCompletionRequirementsMet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnComplete()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}
}
