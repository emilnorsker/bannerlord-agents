using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;
using TaleWorlds.Core;

namespace StoryMode.GauntletUI.Tutorial;

[Tutorial("EncyclopediaTrackTutorial")]
public class EncyclopediaTrackTutorial : TutorialItemBase
{
	private bool _isActive;

	private bool _usedTrackFromEncyclopedia;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaTrackTutorial()
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTrackToggledFromEncyclopedia(PlayerToggleTrackSettlementFromEncyclopediaEvent callback)
	{
		throw null;
	}
}
