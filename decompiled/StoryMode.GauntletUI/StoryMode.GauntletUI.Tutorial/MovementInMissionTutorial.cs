using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace StoryMode.GauntletUI.Tutorial;

[Tutorial("MovementInMissionTutorial")]
public class MovementInMissionTutorial : TutorialItemBase
{
	private bool _playerMovedForward;

	private bool _playerMovedBackward;

	private bool _playerMovedLeft;

	private bool _playerMovedRight;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MovementInMissionTutorial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForCompletion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerMovementFlagChanged(MissionPlayerMovementFlagsChangeEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TutorialContexts GetTutorialsRelevantContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForActivation()
	{
		throw null;
	}
}
