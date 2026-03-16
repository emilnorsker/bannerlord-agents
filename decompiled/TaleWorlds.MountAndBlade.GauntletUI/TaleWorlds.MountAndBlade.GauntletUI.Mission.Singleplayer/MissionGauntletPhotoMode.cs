using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;
using TaleWorlds.MountAndBlade.ViewModelCollection;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.GauntletUI.Mission.Singleplayer;

[OverrideView(typeof(PhotoModeView))]
public class MissionGauntletPhotoMode : MissionView
{
	private readonly TextObject _screenShotTakenMessage;

	private const float _cameraRollAmount = 0.1f;

	private const float _cameraFocusAmount = 0.1f;

	private GauntletLayer _gauntletLayer;

	private PhotoModeVM _dataSource;

	private bool _registered;

	private SpriteCategory _photoModeCategory;

	private float _cameraRoll;

	private bool _photoModeOrbitState;

	private bool _suspended;

	private bool _vignetteMode;

	private bool _hideAgentsMode;

	private int _takePhoto;

	private bool _saveAmbientOcclusionPass;

	private bool _saveObjectIdPass;

	private bool _saveShadowPass;

	private bool _prevUIDisabled;

	private bool _prevMouseEnabled;

	private Scene _missionScene
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private InputContext _input
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanTakePicture()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetCanMoveCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetChanges()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool OnEscape()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsOpeningEscapeMenuOnFocusChangeAllowed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletPhotoMode()
	{
		throw null;
	}
}
