using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class MBEditor
{
	public static Scene _editorScene;

	private static MBAgentRendererSceneController _agentRendererSceneController;

	public static bool _isEditorMissionOn;

	public static bool IsEditModeOn
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static bool EditModeEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void SetEditorScene(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void CloseEditorScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void DestroyEditor(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UpdateSceneTree(bool doNextFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsEntitySelected(GameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsEntitySelected(WeakGameEntity entity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RenderEditorMesh(MetaMesh mesh, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyDeltaToEditorCamera(Vec3 delta)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EnterEditMode(SceneView sceneView, MatrixFrame initialCameraFrame, float initialCameraElevation, float initialCameraBearing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TickEditMode(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LeaveEditMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EnterEditMissionMode(Mission mission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LeaveEditMissionMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsEditorMissionOn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ActivateSceneEditorPresentation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeactivateSceneEditorPresentation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TickSceneEditorPresentation(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SceneView GetEditorSceneView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool HelpersEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool BorderHelpersEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ZoomToPosition(Vec3 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsReplayManagerReplaying()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsReplayManagerRendering()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsReplayManagerRecording()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddEditorWarning(string msg)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddEntityWarning(WeakGameEntity entityId, string msg)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddNavMeshWarning(Scene scene, PathFaceRecord record, string msg)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetAllPrefabsAndChildWithTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExitEditMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetUpgradeLevelVisibility(List<string> levels)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetLevelVisibility(List<string> levels)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ToggleEnableEditorPhysics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBEditor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MBEditor()
	{
		throw null;
	}
}
