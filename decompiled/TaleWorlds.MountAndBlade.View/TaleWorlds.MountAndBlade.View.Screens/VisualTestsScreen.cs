using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Engine.Options;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.View.Screens;

public class VisualTestsScreen : ScreenBase
{
	public enum CameraPointTestType
	{
		Final,
		Albedo,
		Normal,
		Specular,
		AO,
		OnlyAmbient,
		OnlyDirect
	}

	public class CameraPoint
	{
		public MatrixFrame CamFrame;

		public string CameraName;

		public List<CameraPointTestType> TestTypes;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public CameraPoint()
		{
			throw null;
		}
	}

	private Scene _scene;

	private MBAgentRendererSceneController _agentRendererSceneController;

	private Camera _camera;

	private SceneLayer _sceneLayer;

	private List<CameraPoint> CamPoints;

	private DateTime testTime;

	private string _validWriteDirectory;

	private string _validReadDirectory;

	private string _pathDirectory;

	private string _failDirectory;

	private string _reportFile;

	private int CurCameraIndex;

	private int TestSubIndex;

	private bool isValidTest_;

	private ConfigQuality preset_;

	public static bool isSceneSuccess;

	private string date;

	private string scene_name;

	private int frameCounter;

	private List<string> testTypesToCheck_;

	private int CamPointCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StartedRendering()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetSubTestName(CameraPointTestType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EngineRenderDisplayMode GetRenderMode(CameraPointTestType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VisualTestsScreen(bool isValidTest, ConfigQuality preset, string sceneName, DateTime testTime, List<string> testTypesToCheck)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivate()
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ShouldCheckTestModeWithTag(string mode, GameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool ShouldCheckTestMode(string mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetCameraPoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTestCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TakeScreenshotAndAnalyze()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AnalyzeImageDifferences(string path1, string path2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static VisualTestsScreen()
	{
		throw null;
	}
}
