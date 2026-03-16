using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfISceneView : ISceneView
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddClearTaskDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool clearOnlySceneview);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckSceneReadyToRenderDelegate(UIntPtr ptr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearAllDelegate(UIntPtr pointer, [MarshalAs(UnmanagedType.U1)] bool clear_scene, [MarshalAs(UnmanagedType.U1)] bool remove_terrain);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateSceneViewDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DoNotClearDelegate(UIntPtr pointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetSceneDelegate(UIntPtr ptr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ProjectedMousePositionOnGroundDelegate(UIntPtr pointer, out Vec3 groundPosition, out Vec3 groundNormal, [MarshalAs(UnmanagedType.U1)] bool mouseVisible, BodyFlags excludeBodyOwnerFlags, [MarshalAs(UnmanagedType.U1)] bool checkOccludedSurface);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ProjectedMousePositionOnWaterDelegate(UIntPtr pointer, out Vec3 groundPosition, [MarshalAs(UnmanagedType.U1)] bool mouseVisible);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RayCastForClosestEntityOrTerrainDelegate(UIntPtr ptr, ref Vec3 sourcePoint, ref Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ReadyToRenderDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 ScreenPointToViewportPointDelegate(UIntPtr ptr, float position_x, float position_y);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAcceptGlobalDebugRenderObjectsDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCameraDelegate(UIntPtr ptr, UIntPtr cameraPtr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCleanScreenUntilLoadingDoneDelegate(UIntPtr pointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetClearAndDisableAfterSucessfullRenderDelegate(UIntPtr pointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetClearGbufferDelegate(UIntPtr pointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDoQuickExposureDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFocusedShadowmapDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool enable, ref Vec3 center, float radius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetForceShaderCompilationDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPointlightResolutionMultiplierDelegate(UIntPtr pointer, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPostfxConfigParamsDelegate(UIntPtr ptr, int value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPostfxFromConfigDelegate(UIntPtr ptr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRenderWithPostfxDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetResolutionScalingDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSceneDelegate(UIntPtr ptr, UIntPtr scenePtr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSceneUsesContourDelegate(UIntPtr pointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSceneUsesShadowsDelegate(UIntPtr pointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSceneUsesSkyboxDelegate(UIntPtr pointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetShadowmapResolutionMultiplierDelegate(UIntPtr pointer, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TranslateMouseDelegate(UIntPtr pointer, ref Vec3 worldMouseNear, ref Vec3 worldMouseFar, float maxDistance);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 WorldPointToScreenPointDelegate(UIntPtr ptr, Vec3 position);

	private static readonly Encoding _utf8;

	public static AddClearTaskDelegate call_AddClearTaskDelegate;

	public static CheckSceneReadyToRenderDelegate call_CheckSceneReadyToRenderDelegate;

	public static ClearAllDelegate call_ClearAllDelegate;

	public static CreateSceneViewDelegate call_CreateSceneViewDelegate;

	public static DoNotClearDelegate call_DoNotClearDelegate;

	public static GetSceneDelegate call_GetSceneDelegate;

	public static ProjectedMousePositionOnGroundDelegate call_ProjectedMousePositionOnGroundDelegate;

	public static ProjectedMousePositionOnWaterDelegate call_ProjectedMousePositionOnWaterDelegate;

	public static RayCastForClosestEntityOrTerrainDelegate call_RayCastForClosestEntityOrTerrainDelegate;

	public static ReadyToRenderDelegate call_ReadyToRenderDelegate;

	public static ScreenPointToViewportPointDelegate call_ScreenPointToViewportPointDelegate;

	public static SetAcceptGlobalDebugRenderObjectsDelegate call_SetAcceptGlobalDebugRenderObjectsDelegate;

	public static SetCameraDelegate call_SetCameraDelegate;

	public static SetCleanScreenUntilLoadingDoneDelegate call_SetCleanScreenUntilLoadingDoneDelegate;

	public static SetClearAndDisableAfterSucessfullRenderDelegate call_SetClearAndDisableAfterSucessfullRenderDelegate;

	public static SetClearGbufferDelegate call_SetClearGbufferDelegate;

	public static SetDoQuickExposureDelegate call_SetDoQuickExposureDelegate;

	public static SetFocusedShadowmapDelegate call_SetFocusedShadowmapDelegate;

	public static SetForceShaderCompilationDelegate call_SetForceShaderCompilationDelegate;

	public static SetPointlightResolutionMultiplierDelegate call_SetPointlightResolutionMultiplierDelegate;

	public static SetPostfxConfigParamsDelegate call_SetPostfxConfigParamsDelegate;

	public static SetPostfxFromConfigDelegate call_SetPostfxFromConfigDelegate;

	public static SetRenderWithPostfxDelegate call_SetRenderWithPostfxDelegate;

	public static SetResolutionScalingDelegate call_SetResolutionScalingDelegate;

	public static SetSceneDelegate call_SetSceneDelegate;

	public static SetSceneUsesContourDelegate call_SetSceneUsesContourDelegate;

	public static SetSceneUsesShadowsDelegate call_SetSceneUsesShadowsDelegate;

	public static SetSceneUsesSkyboxDelegate call_SetSceneUsesSkyboxDelegate;

	public static SetShadowmapResolutionMultiplierDelegate call_SetShadowmapResolutionMultiplierDelegate;

	public static TranslateMouseDelegate call_TranslateMouseDelegate;

	public static WorldPointToScreenPointDelegate call_WorldPointToScreenPointDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddClearTask(UIntPtr ptr, bool clearOnlySceneview)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckSceneReadyToRender(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAll(UIntPtr pointer, bool clear_scene, bool remove_terrain)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SceneView CreateSceneView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoNotClear(UIntPtr pointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Scene GetScene(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ProjectedMousePositionOnGround(UIntPtr pointer, out Vec3 groundPosition, out Vec3 groundNormal, bool mouseVisible, BodyFlags excludeBodyOwnerFlags, bool checkOccludedSurface)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ProjectedMousePositionOnWater(UIntPtr pointer, out Vec3 groundPosition, bool mouseVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrain(UIntPtr ptr, ref Vec3 sourcePoint, ref Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ReadyToRender(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 ScreenPointToViewportPoint(UIntPtr ptr, float position_x, float position_y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAcceptGlobalDebugRenderObjects(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCamera(UIntPtr ptr, UIntPtr cameraPtr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCleanScreenUntilLoadingDone(UIntPtr pointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClearAndDisableAfterSucessfullRender(UIntPtr pointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClearGbuffer(UIntPtr pointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDoQuickExposure(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFocusedShadowmap(UIntPtr ptr, bool enable, ref Vec3 center, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForceShaderCompilation(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPointlightResolutionMultiplier(UIntPtr pointer, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPostfxConfigParams(UIntPtr ptr, int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPostfxFromConfig(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderWithPostfx(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetResolutionScaling(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScene(UIntPtr ptr, UIntPtr scenePtr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSceneUsesContour(UIntPtr pointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSceneUsesShadows(UIntPtr pointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSceneUsesSkybox(UIntPtr pointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShadowmapResolutionMultiplier(UIntPtr pointer, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TranslateMouse(UIntPtr pointer, ref Vec3 worldMouseNear, ref Vec3 worldMouseFar, float maxDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 WorldPointToScreenPoint(UIntPtr ptr, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfISceneView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfISceneView()
	{
		throw null;
	}
}
