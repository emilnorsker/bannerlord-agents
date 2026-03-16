using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.WoundedBeast;

internal class FinishOffConsortsObjective : MissionObjective
{
	private class ShipObjectiveTarget : MissionObjectiveTarget
	{
		public readonly MissionShip TargetShip;

		private readonly TextObject _name;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ShipObjectiveTarget(MissionShip targetShip, TextObject name)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Vec3 GetGlobalPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override TextObject GetName()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsActive()
		{
			throw null;
		}
	}

	private MissionObjectiveProgressInfo _cachedProgress;

	private List<MissionShip> _targets;

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
	public FinishOffConsortsObjective(Mission mission, List<MissionShip> targetShips)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MissionObjectiveProgressInfo GetCurrentProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
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
}
