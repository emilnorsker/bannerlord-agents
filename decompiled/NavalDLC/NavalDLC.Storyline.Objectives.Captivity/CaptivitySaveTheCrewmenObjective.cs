using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.Captivity;

public class CaptivitySaveTheCrewmenObjective : MissionObjective
{
	private class CaptivityCrewmenTarget : MissionObjectiveTarget<Agent>
	{
		private readonly TextObject _name;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CaptivityCrewmenTarget(TextObject name, Agent agent)
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

	private readonly NavalStorylineCaptivityMissionController _captivityMissionController;

	private readonly TextObject _name;

	private readonly TextObject _description;

	private readonly TextObject _targetName;

	private MissionObjectiveProgressInfo _cachedProgress;

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
	public CaptivitySaveTheCrewmenObjective(Mission mission, NavalStorylineCaptivityMissionController captivityMissionController)
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
	public override MissionObjectiveProgressInfo GetCurrentProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}
}
