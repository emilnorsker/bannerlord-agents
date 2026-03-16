using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;
using TaleWorlds.Core;

namespace StoryMode.GauntletUI.Tutorial;

[Tutorial("EncyclopediaFogOfWarTutorial")]
public class EncyclopediaFogOfWarTutorial : TutorialItemBase
{
	private EncyclopediaPages _activatedPage;

	private bool _registeredEvents;

	private bool _lastActiveState;

	private bool _isActive;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaFogOfWarTutorial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TutorialContexts GetTutorialsRelevantContext()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTutorialContextChanged(TutorialContextChangedEvent evnt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForActivation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForCompletion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLimitedInformationPageOpened(EncyclopediaPageChangedEvent evnt)
	{
		throw null;
	}
}
