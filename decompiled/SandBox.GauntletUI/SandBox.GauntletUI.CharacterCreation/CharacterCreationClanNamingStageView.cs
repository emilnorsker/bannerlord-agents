using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.View.CharacterCreation;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterCreation;
using TaleWorlds.Core;
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

[CharacterCreationStageView(typeof(CharacterCreationClanNamingStage))]
public class CharacterCreationClanNamingStageView : CharacterCreationStageViewBase
{
	private CharacterCreationManager _characterCreationManager;

	private GauntletLayer GauntletLayer;

	private CharacterCreationClanNamingStageVM _dataSource;

	private GauntletMovieIdentifier _clanNamingStageMovie;

	private TextObject _affirmativeActionText;

	private TextObject _negativeActionText;

	private Banner _banner;

	private float _cameraCurrentRotation;

	private float _cameraTargetRotation;

	private float _cameraCurrentDistanceAdder;

	private float _cameraTargetDistanceAdder;

	private float _cameraCurrentElevationAdder;

	private float _cameraTargetElevationAdder;

	private readonly BasicCharacterObject _character;

	private Scene _scene;

	private MBAgentRendererSceneController _agentRendererSceneController;

	private AgentVisuals _agentVisuals;

	private MatrixFrame _characterFrame;

	private Equipment _weaponEquipment;

	private Camera _camera;

	private EscapeMenuVM _escapeMenuDatasource;

	private GauntletMovieIdentifier _escapeMenuMovie;

	private ItemRosterElement ShieldRosterElement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private int ShieldSlotIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public SceneLayer SceneLayer
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
	public CharacterCreationClanNamingStageView(CharacterCreationManager characterCreationManager, ControlCharacterCreationStage affirmativeAction, TextObject affirmativeActionText, ControlCharacterCreationStage negativeAction, TextObject negativeActionText, ControlCharacterCreationStage refreshAction, ControlCharacterCreationStageReturnInt getCurrentStageIndexAction, ControlCharacterCreationStageReturnInt getTotalStageCountAction, ControlCharacterCreationStageReturnInt getFurthestIndexAction, ControlCharacterCreationStageWithInt goToIndexAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddCharacterEntity(in ActionIndexCache action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateBanners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewBannerReadyForBanners(Texture newTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshCharacterEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleLayerInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleUserInput(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NormalizeControllerInputForDeadZone(ref float inputValue, float controllerDeadZone)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCamera(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override IEnumerable<ScreenLayer> GetLayers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetVirtualStageCount()
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
	public override void LoadEscapeMenuMovie()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ReleaseEscapeMenuMovie()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHotKeyReleasedOnAnyLayer(string hotkeyName)
	{
		throw null;
	}
}
