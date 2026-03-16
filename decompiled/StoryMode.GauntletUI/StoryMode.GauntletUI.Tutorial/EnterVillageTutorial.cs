using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;

namespace StoryMode.GauntletUI.Tutorial;

[Tutorial("EnterVillageTutorial")]
public class EnterVillageTutorial : TutorialItemBase
{
	private bool _isEnterOptionSelected;

	private const string _enterGameMenuOptionId = "storymode_tutorial_village_enter";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EnterVillageTutorial()
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameMenuOptionSelected(GameMenuOption obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForCompletion()
	{
		throw null;
	}
}
