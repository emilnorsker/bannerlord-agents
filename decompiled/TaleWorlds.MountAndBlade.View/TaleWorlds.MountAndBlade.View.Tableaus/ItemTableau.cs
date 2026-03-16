using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.Tableaus;

public class ItemTableau
{
	private static int _tableauIndex;

	private Scene _tableauScene;

	private GameEntity _itemTableauEntity;

	private MatrixFrame _itemTableauFrame;

	private bool _isRotating;

	private bool _isTranslating;

	private bool _isRotatingByDefault;

	private bool _initialized;

	private int _tableauSizeX;

	private int _tableauSizeY;

	private float _cameraRatio;

	private Camera _camera;

	private Vec3 _midPoint;

	private const float InitialCamFov = 1f;

	private float _curZoomSpeed;

	private Vec3 _curCamDisplacement;

	private bool _isEnabled;

	private float _panRotation;

	private float _tiltRotation;

	private bool _hasInitialTiltRotation;

	private float _initialTiltRotation;

	private bool _hasInitialPanRotation;

	private float _initialPanRotation;

	private float RenderScale;

	private string _stringId;

	private int _ammo;

	private int _averageUnitCost;

	private string _itemModifierId;

	private string _bannerCode;

	private ItemRosterElement _itemRosterElement;

	private MatrixFrame _initialFrame;

	private bool _lockMouse;

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

	private TableauView View
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private bool _isSizeValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemTableau()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetSize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void SetEnabled(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStringId(string stringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAmmo(int ammo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAverageUnitCost(int averageUnitCost)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetItemModifierId(string itemModifierId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBannerCode(string bannerCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Recalculate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TranslateCamera(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TranslateCameraAux(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateItem(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateItemVerticalWithAmount(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateItemHorizontalWithAmount(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePosition(float mouseMoveX, float mouseMoveY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateRotation(float mouseMoveX, float mouseMoveY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInitialTiltRotation(float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInitialPanRotation(float amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Zoom(double value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetItem(ItemRosterElement itemRosterElement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshItemTableau()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TableauMaterialTabInventoryItemTooltipOnRender(Texture sender, EventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeCameraLookMidPoint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCamFovHorizontal(float camFov)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMouseLock(bool forceUnlock = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickCameraZoom(float dt)
	{
		throw null;
	}
}
