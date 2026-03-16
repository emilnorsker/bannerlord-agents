using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.View.CharacterCreation;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterCreation;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.ViewModelCollection.EscapeMenu;
using TaleWorlds.ScreenSystem;

namespace SandBox.GauntletUI.CharacterCreation;

[CharacterCreationStageView(typeof(CharacterCreationNarrativeStage))]
public class CharacterCreationNarrativeStageView : CharacterCreationStageViewBase
{
	protected readonly TextObject _affirmativeActionText;

	protected readonly TextObject _negativeActionText;

	private GauntletMovieIdentifier _movie;

	private GauntletLayer GauntletLayer;

	private CharacterCreationNarrativeStageVM _dataSource;

	private readonly CharacterCreationManager _characterCreationManager;

	private Scene _characterScene;

	private Camera _camera;

	private List<AgentVisuals> _currentMenuAgentVisuals;

	private List<GameEntity> _currentMenuMountEntities;

	private bool _isAgentVisualsDirty;

	private bool _isAgentVisualVisibilitiesDirty;

	private EscapeMenuVM _escapeMenuDatasource;

	private GauntletMovieIdentifier _escapeMenuMovie;

	public SceneLayer CharacterLayer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterCreationNarrativeStageView(CharacterCreationManager characterCreationManager, ControlCharacterCreationStage affirmativeAction, TextObject affirmativeActionText, ControlCharacterCreationStage negativeAction, TextObject negativeActionText, ControlCharacterCreationStage onRefresh, ControlCharacterCreationStageReturnInt getCurrentStageIndexAction, ControlCharacterCreationStageReturnInt getTotalStageCountAction, ControlCharacterCreationStageReturnInt getFurthestIndexAction, ControlCharacterCreationStageWithInt goToIndexAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetGenericScene(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateHotKeyVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenScene(Scene cachedScene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshAgentVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnHumanNarrativeMenuCharacter(NarrativeMenuCharacter character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnNonHumanNarrativeMenuCharacter(NarrativeMenuCharacter character)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearCharacterVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearMountEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private AgentVisualsData CreateAgentVisual(NarrativeMenuCharacter character, MatrixFrame characterFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMenuChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectionChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleLayerInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void NextStage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void PreviousStage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetVirtualStageCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IEnumerable<ScreenLayer> GetLayers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void LoadEscapeMenuMovie()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ReleaseEscapeMenuMovie()
	{
		throw null;
	}
}
