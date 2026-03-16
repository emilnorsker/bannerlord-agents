using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMBEditor : IMBEditor
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ActivateSceneEditorPresentationDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddEditorWarningDelegate(byte[] msg);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddEntityWarningDelegate(UIntPtr entityId, byte[] msg);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddNavMeshWarningDelegate(UIntPtr sceneId, in PathFaceRecord record, byte[] msg);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ApplyDeltaToEditorCameraDelegate(in Vec3 delta);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool BorderHelpersEnabledDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeactivateSceneEditorPresentationDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnterEditMissionModeDelegate(UIntPtr missionPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnterEditModeDelegate(UIntPtr sceneWidgetPointer, ref MatrixFrame initialCameraFrame, float initialCameraElevation, float initialCameraBearing);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ExitEditModeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAllPrefabsAndChildWithTagDelegate(byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetEditorSceneViewDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HelpersEnabledDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsEditModeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsEditModeEnabledDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsEntitySelectedDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsReplayManagerRecordingDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsReplayManagerRenderingDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsReplayManagerReplayingDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LeaveEditMissionModeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LeaveEditModeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RenderEditorMeshDelegate(UIntPtr metaMeshId, ref MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLevelVisibilityDelegate(byte[] cumulated_string);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetUpgradeLevelVisibilityDelegate(byte[] cumulated_string);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TickEditModeDelegate(float dt);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TickSceneEditorPresentationDelegate(float dt);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ToggleEnableEditorPhysicsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateSceneTreeDelegate([MarshalAs(UnmanagedType.U1)] bool do_next_frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ZoomToPositionDelegate(Vec3 pos);

	private static readonly Encoding _utf8;

	public static ActivateSceneEditorPresentationDelegate call_ActivateSceneEditorPresentationDelegate;

	public static AddEditorWarningDelegate call_AddEditorWarningDelegate;

	public static AddEntityWarningDelegate call_AddEntityWarningDelegate;

	public static AddNavMeshWarningDelegate call_AddNavMeshWarningDelegate;

	public static ApplyDeltaToEditorCameraDelegate call_ApplyDeltaToEditorCameraDelegate;

	public static BorderHelpersEnabledDelegate call_BorderHelpersEnabledDelegate;

	public static DeactivateSceneEditorPresentationDelegate call_DeactivateSceneEditorPresentationDelegate;

	public static EnterEditMissionModeDelegate call_EnterEditMissionModeDelegate;

	public static EnterEditModeDelegate call_EnterEditModeDelegate;

	public static ExitEditModeDelegate call_ExitEditModeDelegate;

	public static GetAllPrefabsAndChildWithTagDelegate call_GetAllPrefabsAndChildWithTagDelegate;

	public static GetEditorSceneViewDelegate call_GetEditorSceneViewDelegate;

	public static HelpersEnabledDelegate call_HelpersEnabledDelegate;

	public static IsEditModeDelegate call_IsEditModeDelegate;

	public static IsEditModeEnabledDelegate call_IsEditModeEnabledDelegate;

	public static IsEntitySelectedDelegate call_IsEntitySelectedDelegate;

	public static IsReplayManagerRecordingDelegate call_IsReplayManagerRecordingDelegate;

	public static IsReplayManagerRenderingDelegate call_IsReplayManagerRenderingDelegate;

	public static IsReplayManagerReplayingDelegate call_IsReplayManagerReplayingDelegate;

	public static LeaveEditMissionModeDelegate call_LeaveEditMissionModeDelegate;

	public static LeaveEditModeDelegate call_LeaveEditModeDelegate;

	public static RenderEditorMeshDelegate call_RenderEditorMeshDelegate;

	public static SetLevelVisibilityDelegate call_SetLevelVisibilityDelegate;

	public static SetUpgradeLevelVisibilityDelegate call_SetUpgradeLevelVisibilityDelegate;

	public static TickEditModeDelegate call_TickEditModeDelegate;

	public static TickSceneEditorPresentationDelegate call_TickSceneEditorPresentationDelegate;

	public static ToggleEnableEditorPhysicsDelegate call_ToggleEnableEditorPhysicsDelegate;

	public static UpdateSceneTreeDelegate call_UpdateSceneTreeDelegate;

	public static ZoomToPositionDelegate call_ZoomToPositionDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateSceneEditorPresentation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEditorWarning(string msg)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEntityWarning(UIntPtr entityId, string msg)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNavMeshWarning(UIntPtr sceneId, in PathFaceRecord record, string msg)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyDeltaToEditorCamera(in Vec3 delta)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool BorderHelpersEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactivateSceneEditorPresentation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnterEditMissionMode(UIntPtr missionPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnterEditMode(UIntPtr sceneWidgetPointer, ref MatrixFrame initialCameraFrame, float initialCameraElevation, float initialCameraBearing)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExitEditMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAllPrefabsAndChildWithTag(string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SceneView GetEditorSceneView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HelpersEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEditMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEditModeEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEntitySelected(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsReplayManagerRecording()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsReplayManagerRendering()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsReplayManagerReplaying()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LeaveEditMissionMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LeaveEditMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderEditorMesh(UIntPtr metaMeshId, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLevelVisibility(string cumulated_string)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpgradeLevelVisibility(string cumulated_string)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickEditMode(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickSceneEditorPresentation(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToggleEnableEditorPhysics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateSceneTree(bool do_next_frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ZoomToPosition(Vec3 pos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMBEditor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMBEditor()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMBEditor.ApplyDeltaToEditorCamera(in Vec3 delta)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMBEditor.AddNavMeshWarning(UIntPtr sceneId, in PathFaceRecord record, string msg)
	{
		throw null;
	}
}
