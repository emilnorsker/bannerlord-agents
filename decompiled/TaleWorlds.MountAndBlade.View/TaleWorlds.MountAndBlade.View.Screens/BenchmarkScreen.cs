using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.View.Screens;

public class BenchmarkScreen : ScreenBase
{
	private SceneView _sceneView;

	private Scene _scene;

	private Camera _camera;

	private MatrixFrame _cameraFrame;

	private Timer _cameraTimer;

	private const string _parentEntityName = "LocationEntityParent";

	private const string _sceneName = "benchmark";

	private const string _xmlPath = "../../../Tools/TestAutomation/Attachments/benchmark_scene_performance.xml";

	private List<GameEntity> _cameraLocationEntities;

	private int _currentEntityIndex;

	private PerformanceAnalyzer _analyzer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BenchmarkScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}
}
