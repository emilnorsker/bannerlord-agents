using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.Captivity;

public class CaptivityEscapeCaptivityObjective : MissionObjective
{
	private readonly NavalStorylineCaptivityMissionController _captivityMissionController;

	private readonly TextObject _name;

	private readonly TextObject _description;

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
	public CaptivityEscapeCaptivityObjective(Mission mission, NavalStorylineCaptivityMissionController captivityMissionController)
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
}
