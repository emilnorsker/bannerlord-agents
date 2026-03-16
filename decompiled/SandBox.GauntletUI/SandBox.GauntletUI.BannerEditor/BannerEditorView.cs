using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.Tableaus.Thumbnails;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI.BannerEditor;

public class BannerEditorView
{
	private GauntletMovieIdentifier _gauntletmovie;

	private readonly SpriteCategory _spriteCategory;

	private bool _isFinalized;

	private float _cameraCurrentRotation;

	private float _cameraTargetRotation;

	private float _cameraCurrentDistanceAdder;

	private float _cameraTargetDistanceAdder;

	private float _cameraCurrentElevationAdder;

	private float _cameraTargetElevationAdder;

	private readonly BasicCharacterObject _character;

	private Scene _scene;

	private MBAgentRendererSceneController _agentRendererSceneController;

	private AgentVisuals[] _agentVisuals;

	private int _agentVisualToShowIndex;

	private bool _checkWhetherAgentVisualIsReady;

	private bool _firstCharacterRender;

	private bool _refreshBannersNextFrame;

	private bool _refreshCharacterAndShieldNextFrame;

	private MatrixFrame _characterFrame;

	private MissionWeapon _shieldWeapon;

	private Equipment _weaponEquipment;

	private Banner _currentBanner;

	private Camera _camera;

	private BannerEditorTextureCreationData _latestBannerTextureCreationData;

	private BannerEditorTextureCreationData _latestShieldTextureCreationData;

	private bool _isOpenedFromCharacterCreation;

	private ControlCharacterCreationStage _affirmativeAction;

	private ControlCharacterCreationStage _negativeAction;

	private ControlCharacterCreationStageWithInt _goToIndexAction;

	public GauntletLayer GauntletLayer
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

	public BannerEditorVM DataSource
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

	public Banner Banner
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
	public BannerEditorView(BasicCharacterObject character, Banner banner, ControlCharacterCreationStage affirmativeAction, TextObject affirmativeActionText, ControlCharacterCreationStage negativeAction, TextObject negativeActionText, ControlCharacterCreationStage onRefresh = null, ControlCharacterCreationStageReturnInt getCurrentStageIndexAction = null, ControlCharacterCreationStageReturnInt getTotalStageCountAction = null, ControlCharacterCreationStageReturnInt getFurthestIndexAction = null, ControlCharacterCreationStageWithInt goToIndexAction = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Exit(bool isCancel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMapIconAsDirtyForAllPlayerClanParties()
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
	private void OnNewBannerReadyForBanners(Banner bannerOfTexture, Texture newTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshShieldAndCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshShieldAndCharacterAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewBannerReadyForShield(Texture newTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHotKeyReleasedOnAnyLayer(string hotkeyName)
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
	public void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GoToIndex(int index)
	{
		throw null;
	}
}
