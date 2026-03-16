using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal static class EngineCallbacksGenerated
{
	internal delegate UIntPtr CrashInformationCollector_CollectInformation_delegate();

	internal delegate UIntPtr EngineController_GetApplicationPlatformName_delegate();

	internal delegate UIntPtr EngineController_GetModulesVersionStr_delegate();

	internal delegate UIntPtr EngineController_GetVersionStr_delegate();

	internal delegate void EngineController_Initialize_delegate();

	internal delegate void EngineController_OnConfigChange_delegate();

	internal delegate void EngineController_OnConstrainedStateChange_delegate([MarshalAs(UnmanagedType.U1)] bool isConstrained);

	internal delegate void EngineController_OnControllerDisconnection_delegate();

	internal delegate void EngineController_OnDLCInstalled_delegate();

	internal delegate void EngineController_OnDLCLoaded_delegate();

	internal delegate void EngineManaged_CheckSharedStructureSizes_delegate();

	internal delegate void EngineManaged_EngineApiMethodInterfaceInitializer_delegate(int id, IntPtr pointer);

	internal delegate void EngineManaged_FillEngineApiPointers_delegate();

	internal delegate void EngineScreenManager_InitializeLastPressedKeys_delegate(NativeObjectPointer lastKeysPressed);

	internal delegate void EngineScreenManager_LateTick_delegate(float dt);

	internal delegate void EngineScreenManager_OnGameWindowFocusChange_delegate([MarshalAs(UnmanagedType.U1)] bool focusGained);

	internal delegate void EngineScreenManager_OnOnscreenKeyboardCanceled_delegate();

	internal delegate void EngineScreenManager_OnOnscreenKeyboardDone_delegate(IntPtr inputText);

	internal delegate void EngineScreenManager_PreTick_delegate(float dt);

	internal delegate void EngineScreenManager_Tick_delegate(float dt);

	internal delegate void EngineScreenManager_Update_delegate();

	internal delegate void ManagedExtensions_CollectCommandLineFunctions_delegate();

	internal delegate void ManagedExtensions_CopyObjectFieldsFrom_delegate(int dst, int src, IntPtr className, int callFieldChangeEventAsInteger);

	internal delegate int ManagedExtensions_CreateScriptComponentInstance_delegate(IntPtr className, UIntPtr entityPtr, NativeObjectPointer managedScriptComponent);

	internal delegate void ManagedExtensions_ForceGarbageCollect_delegate();

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool ManagedExtensions_GetEditorVisibilityOfField_delegate(uint classNameHash, uint fieldNamehash);

	internal delegate void ManagedExtensions_GetObjectField_delegate(int managedObject, uint classNameHash, ref ScriptComponentFieldHolder scriptComponentFieldHolder, uint fieldNameHash, RglScriptFieldType type);

	internal delegate UIntPtr ManagedExtensions_GetScriptComponentClassNames_delegate();

	internal delegate RglScriptFieldType ManagedExtensions_GetTypeOfField_delegate(uint classNameHash, uint fieldNameHash);

	internal delegate void ManagedExtensions_SetObjectFieldBool_delegate(int managedObject, uint classNameHash, uint fieldNameHash, [MarshalAs(UnmanagedType.U1)] bool value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldColor_delegate(int managedObject, uint classNameHash, uint fieldNameHash, Vec3 value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldDouble_delegate(int managedObject, uint classNameHash, uint fieldNameHash, double value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldEntity_delegate(int managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldEnum_delegate(int managedObject, uint classNameHash, uint fieldNameHash, IntPtr value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldFloat_delegate(int managedObject, uint classNameHash, uint fieldNameHash, float value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldInt_delegate(int managedObject, uint classNameHash, uint fieldNameHash, int value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldMaterial_delegate(int managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldMatrixFrame_delegate(int managedObject, uint classNameHash, uint fieldNameHash, MatrixFrame value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldMesh_delegate(int managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldString_delegate(int managedObject, uint classNameHash, uint fieldNameHash, IntPtr value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldTexture_delegate(int managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger);

	internal delegate void ManagedExtensions_SetObjectFieldVec3_delegate(int managedObject, uint classNameHash, uint fieldNameHash, Vec3 value, int callFieldChangeEventAsInteger);

	internal delegate int ManagedScriptHolder_CreateManagedScriptHolder_delegate();

	internal delegate void ManagedScriptHolder_FixedTickComponents_delegate(int thisPointer, float fixedDt);

	internal delegate int ManagedScriptHolder_GetNumberOfScripts_delegate(int thisPointer);

	internal delegate void ManagedScriptHolder_RemoveScriptComponentFromAllTickLists_delegate(int thisPointer, int sc);

	internal delegate void ManagedScriptHolder_SetScriptComponentHolder_delegate(int thisPointer, int sc);

	internal delegate void ManagedScriptHolder_TickComponents_delegate(int thisPointer, float dt);

	internal delegate void ManagedScriptHolder_TickComponentsEditor_delegate(int thisPointer, float dt);

	internal delegate void MessageManagerBase_PostMessageLine_delegate(int thisPointer, IntPtr text, uint color);

	internal delegate void MessageManagerBase_PostMessageLineFormatted_delegate(int thisPointer, IntPtr text, uint color);

	internal delegate void MessageManagerBase_PostSuccessLine_delegate(int thisPointer, IntPtr text);

	internal delegate void MessageManagerBase_PostWarningLine_delegate(int thisPointer, IntPtr text);

	internal delegate void NativeParallelDriver_ParalelForLoopBodyCaller_delegate(long loopBodyKey, int localStartIndex, int localEndIndex);

	internal delegate void NativeParallelDriver_ParalelForLoopBodyWithDtCaller_delegate(long loopBodyKey, int localStartIndex, int localEndIndex);

	internal delegate int RenderTargetComponent_CreateRenderTargetComponent_delegate(NativeObjectPointer renderTarget);

	internal delegate void RenderTargetComponent_OnPaintNeeded_delegate(int thisPointer);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool SceneProblemChecker_OnCheckForSceneProblems_delegate(NativeObjectPointer scene);

	internal delegate void ScriptComponentBehavior_AddScriptComponentToTick_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_DeregisterAsPrefabScriptComponent_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_DeregisterAsUndoStackScriptComponent_delegate(int thisPointer);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool ScriptComponentBehavior_DisablesOroCreation_delegate(int thisPointer);

	internal delegate int ScriptComponentBehavior_GetEditableFields_delegate(IntPtr className);

	internal delegate void ScriptComponentBehavior_HandleOnRemoved_delegate(int thisPointer, int removeReason);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool ScriptComponentBehavior_IsOnlyVisual_delegate(int thisPointer);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool ScriptComponentBehavior_MovesEntity_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_OnBoundingBoxValidate_delegate(int thisPointer);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool ScriptComponentBehavior_OnCheckForProblems_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_OnDynamicNavmeshVertexUpdate_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_OnEditModeVisibilityChanged_delegate(int thisPointer, [MarshalAs(UnmanagedType.U1)] bool currentVisibility);

	internal delegate void ScriptComponentBehavior_OnEditorInit_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_OnEditorTick_delegate(int thisPointer, float dt);

	internal delegate void ScriptComponentBehavior_OnEditorValidate_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_OnEditorVariableChanged_delegate(int thisPointer, IntPtr variableName);

	internal delegate void ScriptComponentBehavior_OnInit_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_OnPhysicsCollisionAux_delegate(int thisPointer, ref PhysicsContact contact, UIntPtr entity0, UIntPtr entity1, [MarshalAs(UnmanagedType.U1)] bool isFirstShape);

	internal delegate void ScriptComponentBehavior_OnPreInit_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_OnSaveAsPrefab_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_OnSceneSave_delegate(int thisPointer, IntPtr saveFolder);

	internal delegate void ScriptComponentBehavior_OnTerrainReload_delegate(int thisPointer, int step);

	internal delegate void ScriptComponentBehavior_RegisterAsPrefabScriptComponent_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_RegisterAsUndoStackScriptComponent_delegate(int thisPointer);

	internal delegate void ScriptComponentBehavior_SetScene_delegate(int thisPointer, NativeObjectPointer scene);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool ScriptComponentBehavior_SkeletonPostIntegrateCallbackAux_delegate(int script, UIntPtr animResultPointer);

	internal delegate void ThumbnailCreatorView_OnThumbnailRenderComplete_delegate(IntPtr renderId, NativeObjectPointer renderTarget);

	internal static Delegate[] Delegates
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(CrashInformationCollector_CollectInformation_delegate))]
	internal static UIntPtr CrashInformationCollector_CollectInformation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineController_GetApplicationPlatformName_delegate))]
	internal static UIntPtr EngineController_GetApplicationPlatformName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineController_GetModulesVersionStr_delegate))]
	internal static UIntPtr EngineController_GetModulesVersionStr()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineController_GetVersionStr_delegate))]
	internal static UIntPtr EngineController_GetVersionStr()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineController_Initialize_delegate))]
	internal static void EngineController_Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineController_OnConfigChange_delegate))]
	internal static void EngineController_OnConfigChange()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineController_OnConstrainedStateChange_delegate))]
	internal static void EngineController_OnConstrainedStateChange(bool isConstrained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineController_OnControllerDisconnection_delegate))]
	internal static void EngineController_OnControllerDisconnection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineController_OnDLCInstalled_delegate))]
	internal static void EngineController_OnDLCInstalled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineController_OnDLCLoaded_delegate))]
	internal static void EngineController_OnDLCLoaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineManaged_CheckSharedStructureSizes_delegate))]
	internal static void EngineManaged_CheckSharedStructureSizes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineManaged_EngineApiMethodInterfaceInitializer_delegate))]
	internal static void EngineManaged_EngineApiMethodInterfaceInitializer(int id, IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineManaged_FillEngineApiPointers_delegate))]
	internal static void EngineManaged_FillEngineApiPointers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineScreenManager_InitializeLastPressedKeys_delegate))]
	internal static void EngineScreenManager_InitializeLastPressedKeys(NativeObjectPointer lastKeysPressed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineScreenManager_LateTick_delegate))]
	internal static void EngineScreenManager_LateTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineScreenManager_OnGameWindowFocusChange_delegate))]
	internal static void EngineScreenManager_OnGameWindowFocusChange(bool focusGained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineScreenManager_OnOnscreenKeyboardCanceled_delegate))]
	internal static void EngineScreenManager_OnOnscreenKeyboardCanceled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineScreenManager_OnOnscreenKeyboardDone_delegate))]
	internal static void EngineScreenManager_OnOnscreenKeyboardDone(IntPtr inputText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineScreenManager_PreTick_delegate))]
	internal static void EngineScreenManager_PreTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineScreenManager_Tick_delegate))]
	internal static void EngineScreenManager_Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(EngineScreenManager_Update_delegate))]
	internal static void EngineScreenManager_Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_CollectCommandLineFunctions_delegate))]
	internal static void ManagedExtensions_CollectCommandLineFunctions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_CopyObjectFieldsFrom_delegate))]
	internal static void ManagedExtensions_CopyObjectFieldsFrom(int dst, int src, IntPtr className, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_CreateScriptComponentInstance_delegate))]
	internal static int ManagedExtensions_CreateScriptComponentInstance(IntPtr className, UIntPtr entityPtr, NativeObjectPointer managedScriptComponent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_ForceGarbageCollect_delegate))]
	internal static void ManagedExtensions_ForceGarbageCollect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_GetEditorVisibilityOfField_delegate))]
	internal static bool ManagedExtensions_GetEditorVisibilityOfField(uint classNameHash, uint fieldNamehash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_GetObjectField_delegate))]
	internal static void ManagedExtensions_GetObjectField(int managedObject, uint classNameHash, ref ScriptComponentFieldHolder scriptComponentFieldHolder, uint fieldNameHash, RglScriptFieldType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_GetScriptComponentClassNames_delegate))]
	internal static UIntPtr ManagedExtensions_GetScriptComponentClassNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_GetTypeOfField_delegate))]
	internal static RglScriptFieldType ManagedExtensions_GetTypeOfField(uint classNameHash, uint fieldNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldBool_delegate))]
	internal static void ManagedExtensions_SetObjectFieldBool(int managedObject, uint classNameHash, uint fieldNameHash, bool value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldColor_delegate))]
	internal static void ManagedExtensions_SetObjectFieldColor(int managedObject, uint classNameHash, uint fieldNameHash, Vec3 value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldDouble_delegate))]
	internal static void ManagedExtensions_SetObjectFieldDouble(int managedObject, uint classNameHash, uint fieldNameHash, double value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldEntity_delegate))]
	internal static void ManagedExtensions_SetObjectFieldEntity(int managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldEnum_delegate))]
	internal static void ManagedExtensions_SetObjectFieldEnum(int managedObject, uint classNameHash, uint fieldNameHash, IntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldFloat_delegate))]
	internal static void ManagedExtensions_SetObjectFieldFloat(int managedObject, uint classNameHash, uint fieldNameHash, float value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldInt_delegate))]
	internal static void ManagedExtensions_SetObjectFieldInt(int managedObject, uint classNameHash, uint fieldNameHash, int value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldMaterial_delegate))]
	internal static void ManagedExtensions_SetObjectFieldMaterial(int managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldMatrixFrame_delegate))]
	internal static void ManagedExtensions_SetObjectFieldMatrixFrame(int managedObject, uint classNameHash, uint fieldNameHash, MatrixFrame value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldMesh_delegate))]
	internal static void ManagedExtensions_SetObjectFieldMesh(int managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldString_delegate))]
	internal static void ManagedExtensions_SetObjectFieldString(int managedObject, uint classNameHash, uint fieldNameHash, IntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldTexture_delegate))]
	internal static void ManagedExtensions_SetObjectFieldTexture(int managedObject, uint classNameHash, uint fieldNameHash, UIntPtr value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedExtensions_SetObjectFieldVec3_delegate))]
	internal static void ManagedExtensions_SetObjectFieldVec3(int managedObject, uint classNameHash, uint fieldNameHash, Vec3 value, int callFieldChangeEventAsInteger)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedScriptHolder_CreateManagedScriptHolder_delegate))]
	internal static int ManagedScriptHolder_CreateManagedScriptHolder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedScriptHolder_FixedTickComponents_delegate))]
	internal static void ManagedScriptHolder_FixedTickComponents(int thisPointer, float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedScriptHolder_GetNumberOfScripts_delegate))]
	internal static int ManagedScriptHolder_GetNumberOfScripts(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedScriptHolder_RemoveScriptComponentFromAllTickLists_delegate))]
	internal static void ManagedScriptHolder_RemoveScriptComponentFromAllTickLists(int thisPointer, int sc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedScriptHolder_SetScriptComponentHolder_delegate))]
	internal static void ManagedScriptHolder_SetScriptComponentHolder(int thisPointer, int sc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedScriptHolder_TickComponents_delegate))]
	internal static void ManagedScriptHolder_TickComponents(int thisPointer, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedScriptHolder_TickComponentsEditor_delegate))]
	internal static void ManagedScriptHolder_TickComponentsEditor(int thisPointer, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MessageManagerBase_PostMessageLine_delegate))]
	internal static void MessageManagerBase_PostMessageLine(int thisPointer, IntPtr text, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MessageManagerBase_PostMessageLineFormatted_delegate))]
	internal static void MessageManagerBase_PostMessageLineFormatted(int thisPointer, IntPtr text, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MessageManagerBase_PostSuccessLine_delegate))]
	internal static void MessageManagerBase_PostSuccessLine(int thisPointer, IntPtr text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MessageManagerBase_PostWarningLine_delegate))]
	internal static void MessageManagerBase_PostWarningLine(int thisPointer, IntPtr text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(NativeParallelDriver_ParalelForLoopBodyCaller_delegate))]
	internal static void NativeParallelDriver_ParalelForLoopBodyCaller(long loopBodyKey, int localStartIndex, int localEndIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(NativeParallelDriver_ParalelForLoopBodyWithDtCaller_delegate))]
	internal static void NativeParallelDriver_ParalelForLoopBodyWithDtCaller(long loopBodyKey, int localStartIndex, int localEndIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(RenderTargetComponent_CreateRenderTargetComponent_delegate))]
	internal static int RenderTargetComponent_CreateRenderTargetComponent(NativeObjectPointer renderTarget)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(RenderTargetComponent_OnPaintNeeded_delegate))]
	internal static void RenderTargetComponent_OnPaintNeeded(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(SceneProblemChecker_OnCheckForSceneProblems_delegate))]
	internal static bool SceneProblemChecker_OnCheckForSceneProblems(NativeObjectPointer scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_AddScriptComponentToTick_delegate))]
	internal static void ScriptComponentBehavior_AddScriptComponentToTick(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_DeregisterAsPrefabScriptComponent_delegate))]
	internal static void ScriptComponentBehavior_DeregisterAsPrefabScriptComponent(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_DeregisterAsUndoStackScriptComponent_delegate))]
	internal static void ScriptComponentBehavior_DeregisterAsUndoStackScriptComponent(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_DisablesOroCreation_delegate))]
	internal static bool ScriptComponentBehavior_DisablesOroCreation(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_GetEditableFields_delegate))]
	internal static int ScriptComponentBehavior_GetEditableFields(IntPtr className)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_HandleOnRemoved_delegate))]
	internal static void ScriptComponentBehavior_HandleOnRemoved(int thisPointer, int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_IsOnlyVisual_delegate))]
	internal static bool ScriptComponentBehavior_IsOnlyVisual(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_MovesEntity_delegate))]
	internal static bool ScriptComponentBehavior_MovesEntity(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnBoundingBoxValidate_delegate))]
	internal static void ScriptComponentBehavior_OnBoundingBoxValidate(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnCheckForProblems_delegate))]
	internal static bool ScriptComponentBehavior_OnCheckForProblems(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnDynamicNavmeshVertexUpdate_delegate))]
	internal static void ScriptComponentBehavior_OnDynamicNavmeshVertexUpdate(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnEditModeVisibilityChanged_delegate))]
	internal static void ScriptComponentBehavior_OnEditModeVisibilityChanged(int thisPointer, bool currentVisibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnEditorInit_delegate))]
	internal static void ScriptComponentBehavior_OnEditorInit(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnEditorTick_delegate))]
	internal static void ScriptComponentBehavior_OnEditorTick(int thisPointer, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnEditorValidate_delegate))]
	internal static void ScriptComponentBehavior_OnEditorValidate(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnEditorVariableChanged_delegate))]
	internal static void ScriptComponentBehavior_OnEditorVariableChanged(int thisPointer, IntPtr variableName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnInit_delegate))]
	internal static void ScriptComponentBehavior_OnInit(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnPhysicsCollisionAux_delegate))]
	internal static void ScriptComponentBehavior_OnPhysicsCollisionAux(int thisPointer, ref PhysicsContact contact, UIntPtr entity0, UIntPtr entity1, bool isFirstShape)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnPreInit_delegate))]
	internal static void ScriptComponentBehavior_OnPreInit(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnSaveAsPrefab_delegate))]
	internal static void ScriptComponentBehavior_OnSaveAsPrefab(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnSceneSave_delegate))]
	internal static void ScriptComponentBehavior_OnSceneSave(int thisPointer, IntPtr saveFolder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_OnTerrainReload_delegate))]
	internal static void ScriptComponentBehavior_OnTerrainReload(int thisPointer, int step)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_RegisterAsPrefabScriptComponent_delegate))]
	internal static void ScriptComponentBehavior_RegisterAsPrefabScriptComponent(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_RegisterAsUndoStackScriptComponent_delegate))]
	internal static void ScriptComponentBehavior_RegisterAsUndoStackScriptComponent(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_SetScene_delegate))]
	internal static void ScriptComponentBehavior_SetScene(int thisPointer, NativeObjectPointer scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ScriptComponentBehavior_SkeletonPostIntegrateCallbackAux_delegate))]
	internal static bool ScriptComponentBehavior_SkeletonPostIntegrateCallbackAux(int script, UIntPtr animResultPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ThumbnailCreatorView_OnThumbnailRenderComplete_delegate))]
	internal static void ThumbnailCreatorView_OnThumbnailRenderComplete(IntPtr renderId, NativeObjectPointer renderTarget)
	{
		throw null;
	}
}
