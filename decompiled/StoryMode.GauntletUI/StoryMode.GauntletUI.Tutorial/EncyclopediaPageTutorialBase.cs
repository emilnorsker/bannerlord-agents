using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;
using TaleWorlds.Core;

namespace StoryMode.GauntletUI.Tutorial;

public abstract class EncyclopediaPageTutorialBase : TutorialItemBase
{
	private bool _isActive;

	private readonly EncyclopediaPages _activationPage;

	private readonly EncyclopediaPages _alternateActivationPage;

	private EncyclopediaPages _lastActivatedPage;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaPageTutorialBase(EncyclopediaPages activationPage, EncyclopediaPages alternateActivationPage)
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
	public override bool IsConditionsMetForCompletion()
	{
		throw null;
	}
}
