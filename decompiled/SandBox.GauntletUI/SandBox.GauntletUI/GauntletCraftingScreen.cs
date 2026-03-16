using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.Screens;
using TaleWorlds.ScreenSystem;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI;

[GameStateScreen(typeof(CraftingState))]
public class GauntletCraftingScreen : ScreenBase, ICraftingStateHandler, IGameStateListener
{
	private struct CameraParameters
	{
		public float HorizontalRotation;

		public float VerticalRotation;

		public float Zoom;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CameraParameters(float horizontalRotation, float verticalRotation, float zoom)
		{
			throw null;
		}
	}

	private const float _controllerRotationSensitivity = 2f;

	private Scene _craftingScene;

	private SceneLayer _sceneLayer;

	private readonly CraftingState _craftingState;

	private CraftingVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private GauntletMovieIdentifier _gauntletMovie;

	private SpriteCategory _craftingCategory;

	private Camera _camera;

	private MatrixFrame _initialCameraFrame;

	private Vec3 _dofParams;

	private Vec3 _cameraZoomDirection;

	private CameraParameters _currentCameraValues;

	private CameraParameters _targetCameraValues;

	private GameEntity _craftingEntity;

	private MatrixFrame _initialEntityFrame;

	private WeaponDesign _craftedData;

	private bool _isInitialized;

	private static KeyValuePair<string, string> _reloadXmlPath;

	private SceneView SceneView
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletCraftingScreen(CraftingState craftingState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReloadPieces()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnResetCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnWeaponCrafted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCraftingLogicInitialized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnCraftingLogicRefreshed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeEntityAndCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshItemEntity(bool isItemVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickCameraInput(float dt)
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
	private void ResetEntityAndCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CopyXmlCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PasteXmlCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SwithToCraftedItem(ItemObject itemObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ItemUsageSetFlags GetItemUsageSetFlag(WeaponComponentData item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHotKeyReleasedInAnyLayer(string hotKeyId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateListener.OnFinalize()
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
}
