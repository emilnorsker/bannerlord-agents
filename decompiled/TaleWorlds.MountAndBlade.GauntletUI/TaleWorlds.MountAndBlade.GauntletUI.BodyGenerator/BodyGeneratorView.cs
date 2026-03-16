using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.ViewModelCollection.FaceGenerator;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.GauntletUI.BodyGenerator;

public class BodyGeneratorView : IFaceGeneratorHandler
{
	private const int ViewOrderPriority = 1;

	private const bool MakeSound = true;

	private Scene _facegenScene;

	private MBAgentRendererSceneController _agentRendererSceneController;

	private GauntletMovieIdentifier _viewMovie;

	private AgentVisuals _visualToShow;

	private List<KeyValuePair<AgentVisuals, int>> _visualsBeingPrepared;

	private readonly bool _openedFromMultiplayer;

	private AgentVisuals _nextVisualToShow;

	private int _currentAgentVisualIndex;

	private bool _refreshCharacterEntityNextFrame;

	private int _makeVoiceInFrames;

	private MatrixFrame _initialCharacterFrame;

	private bool _setMorphAnimNextFrame;

	private string _nextMorphAnimToSet;

	private bool _nextMorphAnimLoopValue;

	private List<BodyProperties> _templateBodyProperties;

	private readonly ControlCharacterCreationStage _affirmativeAction;

	private readonly ControlCharacterCreationStage _negativeAction;

	private readonly ControlCharacterCreationStageReturnInt _getTotalStageCountAction;

	private readonly ControlCharacterCreationStageReturnInt _getCurrentStageIndexAction;

	private readonly ControlCharacterCreationStageReturnInt _getFurthestIndexAction;

	private readonly ControlCharacterCreationStageWithInt _goToIndexAction;

	public bool IsDressed;

	public SkeletonType SkeletonType;

	private readonly Equipment _dressedEquipment;

	private Camera _camera;

	private int _cameraLookMode;

	private MatrixFrame _targetCameraGlobalFrame;

	private MatrixFrame _defaultCameraGlobalFrame;

	private float _characterCurrentRotation;

	private float _characterTargetRotation;

	private float _cameraCurrentDistanceAdder;

	private float _cameraCurrentElevationAdder;

	private SpriteCategory _facegenCategory;

	private IInputContext DebugInput
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public FaceGenVM DataSource
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

	public BodyGenerator BodyGen
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
	public BodyGeneratorView(ControlCharacterCreationStage affirmativeAction, TextObject affirmativeActionText, ControlCharacterCreationStage negativeAction, TextObject negativeActionText, BasicCharacterObject character, bool openedFromMultiplayer, IFaceGeneratorCustomFilter filter, Equipment dressedEquipment = null, ControlCharacterCreationStageReturnInt getCurrentStageIndexAction = null, ControlCharacterCreationStageReturnInt getTotalStageCountAction = null, ControlCharacterCreationStageReturnInt getFurthestIndexAction = null, ControlCharacterCreationStageWithInt goToIndexAction = null, FaceGenHistory faceGenHistory = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddCharacterEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetNewBodyPropertiesAndBodyGen(BodyProperties bodyProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetFaceToDefault()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeightChanged(float sliderValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAgeChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("show_debug", "facegen")]
	public static string FaceGenShowDebug(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineArgumentFunction("toggle_update_deform_keys", "facegen")]
	public static string FaceGenUpdateDeformKeys(List<string> strings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReadyToRender()
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
	private void TickLayerInputs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickInput(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NormalizeControllerInputForDeadZone(ref float inputValue, float controllerDeadZone)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHotKeyReleasedOnAnyLayer(string hotkeyName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHotKeyPressedOnAnyLayer(string hotkeyName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshCharacterEntityAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.MakeVoice()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.MakeVoiceDelayed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.RefreshCharacterEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.SetFacialAnimation(string faceAnimation, bool loop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearAgentVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.Done()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.Cancel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.ChangeToFaceCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.ChangeToEyeCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.ChangeToNoseCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.ChangeToMouthCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.ChangeToBodyCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.ChangeToHairCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.UndressCharacterEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.DressCharacterEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IFaceGeneratorHandler.DefaultFace()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GoToIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static MatrixFrame InitCamera(Camera camera, Vec3 cameraPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCamera(float dt)
	{
		throw null;
	}
}
