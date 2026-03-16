using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.Tableaus;

public class CharacterTableau
{
	private static int _tableauIndex;

	private bool _isFinalized;

	private MatrixFrame _mountSpawnPoint;

	private MatrixFrame _bannerSpawnPoint;

	private float _animationFrequencyThreshold;

	private MatrixFrame _initialSpawnFrame;

	private MatrixFrame _characterMountPositionFrame;

	private MatrixFrame _mountCharacterPositionFrame;

	private AgentVisuals _agentVisuals;

	private AgentVisuals _mountVisuals;

	private int _agentVisualLoadingCounter;

	private int _mountVisualLoadingCounter;

	private AgentVisuals _oldAgentVisuals;

	private AgentVisuals _oldMountVisuals;

	private int _initialLoadingCounter;

	private ActionIndexCache _idleAction;

	private string _idleFaceAnim;

	private Scene _tableauScene;

	private MBAgentRendererSceneController _agentRendererSceneController;

	private Camera _continuousRenderCamera;

	private float _cameraRatio;

	private MatrixFrame _camPos;

	private MatrixFrame _camPosGatheredFromScene;

	private string _charStringId;

	private int _tableauSizeX;

	private int _tableauSizeY;

	private uint _clothColor1;

	private uint _clothColor2;

	private bool _isRotatingCharacter;

	private bool _isCharacterMountPlacesSwapped;

	private string _mountCreationKey;

	private string _equipmentCode;

	private bool _isEquipmentAnimActive;

	private float _animationGap;

	private float _mainCharacterRotation;

	private bool _isEnabled;

	private float _renderScale;

	private float _customRenderScale;

	private int _latestWidth;

	private int _latestHeight;

	private string _bodyPropertiesCode;

	private BodyProperties _bodyProperties;

	private bool _isFemale;

	private StanceTypes _stanceIndex;

	private Equipment _equipment;

	private Banner _banner;

	private int _race;

	private bool _isBannerShownInBackground;

	private ItemObject _bannerItem;

	private GameEntity _bannerEntity;

	private int _leftHandEquipmentIndex;

	private int _rightHandEquipmentIndex;

	private bool _isEquipmentIndicesDirty;

	private bool _customAnimationStartScheduled;

	private float _customAnimationTimer;

	private string _customAnimationName;

	private ActionIndexCache _customAnimation;

	private MBActionSet _characterActionSet;

	private bool _isVisualsDirty;

	private Equipment _oldEquipment;

	public Texture Texture
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

	public bool IsRunningCustomAnimation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool ShouldLoopCustomAnimation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	public float CustomAnimationWaitDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	private TableauView View
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterTableau()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetCustomAnimationProgressRatio()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopCustomAnimationIfCantContinue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetEnabled(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLeftHandWieldedEquipmentIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRightHandWieldedEquipmentIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetSize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCharStringID(string charStringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBodyProperties(string bodyPropertiesCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStanceIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomRenderScale(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdjustCharacterForStanceIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ForceRefresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsFemale(bool isFemale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsBannerShownInBackground(bool isBannerShownInBackground)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRace(int race)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIdleAction(string idleAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomAnimation(string animation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartCustomAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StopCustomAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIdleFaceAnim(string idleFaceAnim)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEquipmentCode(string equipmentCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsEquipmentAnimActive(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMountCreationKey(string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBannerCode(string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetArmorColor1(uint clothColor1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetArmorColor2(uint clothColor2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ActionIndexCache GetIdleAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshCharacterTableau(Equipment oldEquipment = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateCharacter(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TriggerCharacterMountPlacesSwap()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCharacterTableauMouseMove(int mouseMoveX)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCharacterRotation(int mouseMoveX)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FirstTimeInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeAgentVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMount(bool isRiderAgentMounted = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateBannerItem()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBannerTableauRenderDone(Texture newTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyBannerTextureToMesh(Mesh bannerMesh, Texture bannerTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ItemObject GetAndRemoveBannerFromEquipment(ref Equipment equipment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void CharacterTableauContinuousRenderFunction(Texture sender, EventArgs e)
	{
		throw null;
	}
}
