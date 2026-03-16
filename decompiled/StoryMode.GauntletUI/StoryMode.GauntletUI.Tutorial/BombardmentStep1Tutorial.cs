using System.Runtime.CompilerServices;
using SandBox.GauntletUI.Tutorial;
using SandBox.ViewModelCollection.MapSiege;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;

namespace StoryMode.GauntletUI.Tutorial;

[Tutorial("BombardmentStep1")]
public class BombardmentStep1Tutorial : TutorialItemBase
{
	private bool _playerSelectedSiegeEngine;

	private bool _isGameMenuChangedAfterActivation;

	private bool _isActivated;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BombardmentStep1Tutorial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsConditionsMetForCompletion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerStartEngineConstruction(PlayerStartEngineConstructionEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameMenuOptionSelected(GameMenuOption obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameMenuOpened(MenuCallbackArgs obj)
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
