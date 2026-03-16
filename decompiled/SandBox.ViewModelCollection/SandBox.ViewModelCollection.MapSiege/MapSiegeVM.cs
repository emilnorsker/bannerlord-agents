using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.MapSiege;

public class MapSiegeVM : ViewModel
{
	public class SiegePOIDistanceComparer : IComparer<MapSiegePOIVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(MapSiegePOIVM x, MapSiegePOIVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SiegePOIDistanceComparer()
		{
			throw null;
		}
	}

	private readonly Camera _mapCamera;

	private readonly SiegePOIDistanceComparer _poiDistanceComparer;

	private MBBindingList<MapSiegePOIVM> _pointsOfInterest;

	private MapSiegeProductionVM _productionController;

	private float _preparationProgress;

	private string _preparationTitleText;

	private bool _isPreparationsCompleted;

	private bool IsPlayerLeaderOfSiegeEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public float PreparationProgress
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsPreparationsCompleted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string PreparationTitleText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MapSiegeProductionVM ProductionController
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<MapSiegePOIVM> PointsOfInterest
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapSiegeVM(Camera mapCamera, MatrixFrame[] batteringRamFrames, MatrixFrame[] rangedSiegeEngineFrames, MatrixFrame[] towerSiegeEngineFrames, MatrixFrame[] defenderSiegeEngineFrames, MatrixFrame[] breachableWallFrames)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPOISelection(MapSiegePOIVM poi)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSelectionFromScene(MatrixFrame frameOfEngine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update(float mapCameraDistanceValue)
	{
		throw null;
	}
}
