using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.ViewModelCollection.Education;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.MountAndBlade.ViewModelCollection.EscapeMenu;
using TaleWorlds.ScreenSystem;

namespace SandBox.GauntletUI;

[GameStateScreen(typeof(EducationState))]
public class GauntletEducationScreen : ScreenBase, IGameStateListener
{
	private readonly EducationState _educationState;

	private readonly Hero _child;

	private readonly PreloadHelper _preloadHelper;

	private EducationVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private bool _startedRendering;

	private Scene _characterScene;

	private MBAgentRendererSceneController _agentRendererSceneController;

	private Camera _camera;

	private List<AgentVisuals> _agentVisuals;

	private GameEntity _cradleEntity;

	private EscapeMenuVM _escapeMenuDatasource;

	private GauntletMovieIdentifier _escapeMenuMovie;

	private bool _isEscapeOpen;

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
	public GauntletEducationScreen(EducationState educationState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnOptionSelect(EducationCharacterProperties[] characterProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ToggleEscapeMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CloseEducationScreen(bool isCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshSceneCharacters(EducationCharacterProperties[] characterProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PreloadCharactersAndEquipment(List<BasicCharacterObject> characters, List<Equipment> equipments)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static AgentVisualsData CreateAgentVisual(CharacterObject character, MatrixFrame characterFrame, Equipment equipment, string actionName, Scene scene, CultureObject childsCulture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenEscapeMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveEscapeMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<EscapeMenuItemVM> GetEscapeMenuItems()
	{
		throw null;
	}
}
