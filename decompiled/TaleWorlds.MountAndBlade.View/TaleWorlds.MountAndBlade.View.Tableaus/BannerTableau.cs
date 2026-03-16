using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.Tableaus;

public class BannerTableau
{
	private static int _tableauIndex;

	private bool _isFinalized;

	private bool _isEnabled;

	private bool _isNineGrid;

	private bool _isDirty;

	private Banner _banner;

	private int _latestWidth;

	private int _latestHeight;

	private int _tableauSizeX;

	private int _tableauSizeY;

	private float RenderScale;

	private float _customRenderScale;

	private Scene _scene;

	private Camera _defaultCamera;

	private Camera _nineGridCamera;

	private MetaMesh _currentMultiMesh;

	private GameEntity _currentMeshEntity;

	private int _meshIndexToUpdate;

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

	internal Camera CurrentCamera
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
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
	public BannerTableau()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FirstTimeInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Refresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetEnabled(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetSize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBannerCode(string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomRenderScale(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BannerTableauContinuousRenderFunction(Texture sender, EventArgs e)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetIsNineGrid(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMeshIndexToUpdate(int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpdatePositionValueManual(Vec2 value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpdateSizeValueManual(Vec2 value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpdateRotationValueManual((float, bool) value)
	{
		throw null;
	}
}
