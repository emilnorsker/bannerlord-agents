using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIUtil : IUtil
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddCommandLineFunctionDelegate(byte[] concatName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMainThreadPerformanceQueryDelegate(byte[] parent, byte[] name, float seconds);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddPerformanceReportTokenDelegate(byte[] performance_type, byte[] name, float loading_time);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddSceneObjectReportDelegate(byte[] scene_name, byte[] report_name, float report_value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CheckIfAssetsAndSourcesAreSameDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckIfTerrainShaderHeaderGenerationFinishedDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CheckResourceModificationsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CheckSceneForProblemsDelegate(byte[] path);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckShaderCompilationDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void clear_decal_atlasDelegate(DecalAtlasGroup atlasGroup);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearOldResourcesAndObjectsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearShaderMemoryDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CommandLineArgumentExistsDelegate(byte[] str);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CompileAllShadersDelegate(byte[] targetPlatform);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CompileTerrainShadersDistDelegate(byte[] targetPlatform, byte[] targetConfig, byte[] output_path);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CreateSelectionInEditorDelegate(IntPtr gameEntities, int entityCount, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DebugSetGlobalLoadingWindowStateDelegate([MarshalAs(UnmanagedType.U1)] bool s);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeleteEntitiesInEditorSceneDelegate(IntPtr gameEntities, int entityCount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DetachWatchdogDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool DidAutomatedGIBakeFinishedDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DisableCoreGameDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DisableGlobalEditDataCacherDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DisableGlobalLoadingWindowDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DoDelayedexitDelegate(int returnCode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DoFullBakeAllLevelsAutomatedDelegate(byte[] module, byte[] sceneName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DoFullBakeSingleLevelAutomatedDelegate(byte[] module, byte[] sceneName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DoLightOnlyBakeAllLevelsAutomatedDelegate(byte[] module, byte[] sceneName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DoLightOnlyBakeSingleLevelAutomatedDelegate(byte[] module, byte[] sceneName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DumpGPUMemoryStatisticsDelegate(byte[] filePath);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnableGlobalEditDataCacherDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnableGlobalLoadingWindowDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnableSingleGPUQueryPerFrameDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EndLoadingStuckCheckStateDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int ExecuteCommandLineCommandDelegate(byte[] command);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ExitProcessDelegate(int exitCode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int ExportNavMeshFaceMarksDelegate(byte[] file_name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FindMeshesWithoutLodsDelegate(byte[] module_name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FlushManagedObjectsMemoryDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GatherCoreGameReferencesDelegate(byte[] scene_names);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GenerateTerrainShaderHeadersDelegate(byte[] targetPlatform, byte[] targetConfig, byte[] output_path);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetApplicationMemoryDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetApplicationMemoryStatisticsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetApplicationNameDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAttachmentsPathDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetBaseDirectoryDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetBenchmarkStatusDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetBuildNumberDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetConsoleHostMachineDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetCoreGameStateDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate ulong GetCurrentCpuMemoryUsageDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetCurrentEstimatedGPUMemoryCostMBDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetCurrentProcessIDDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate ulong GetCurrentThreadIdDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetDeltaTimeDelegate(int timerId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetDetailedGPUBufferMemoryStatsDelegate(ref int totalMemoryAllocated, ref int totalMemoryUsed, ref int emptyChunkCount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetDetailedXBOXMemoryInfoDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetEditorSelectedEntitiesDelegate(IntPtr gameEntitiesTemp);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetEditorSelectedEntityCountDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetEngineFrameNoDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetEntitiesOfSelectionSetDelegate(byte[] name, IntPtr gameEntitiesTemp);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetEntityCountOfSelectionSetDelegate(byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetExecutableWorkingDirectoryDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetFpsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetFrameLimiterWithSleepDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetFullCommandLineStringDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetFullFilePathOfSceneDelegate(byte[] sceneName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetFullModulePathDelegate(byte[] moduleName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetFullModulePathsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetGPUMemoryMBDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate ulong GetGpuMemoryOfAllocationGroupDelegate(byte[] allocationName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetGPUMemoryStatsDelegate(ref float totalMemory, ref float renderTargetMemory, ref float depthTargetMemory, ref float srvMemory, ref float bufferMemory);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetLocalOutputPathDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetMainFpsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate ulong GetMainThreadIdDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetMemoryUsageOfCategoryDelegate(int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetModulesCodeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNativeMemoryStatisticsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNumberOfShaderCompilationsInProgressDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetPCInfoDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetPlatformModulePathsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetPossibleCommandLineStartingWithDelegate(byte[] command, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetRendererFpsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetReturnCodeDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetSingleModuleScenesOfModuleDelegate(byte[] moduleName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetSteamAppIdDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetSystemLanguageDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetVertexBufferChunkSystemMemoryUsageDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetVisualTestsTestFilesPathDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetVisualTestsValidatePathDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsAsyncPhysicsThreadDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsBenchmarkQuitedDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int IsDetailedSoundLogOnDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsDevkitDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsEditModeEnabledDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsLockhartPlatformDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsSceneReportFinishedDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LoadSkyBoxesDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LoadVirtualTextureTilesetDelegate(byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ManagedParallelForDelegate(int fromInclusive, int toExclusive, long curKey, int grainSize);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ManagedParallelForWithDtDelegate(int fromInclusive, int toExclusive, long curKey, int grainSize);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ManagedParallelForWithoutRenderThreadDelegate(int fromInclusive, int toExclusive, long curKey, int grainSize);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OnLoadingWindowDisabledDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OnLoadingWindowEnabledDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OpenNavalDlcPurchasePageDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OpenOnscreenKeyboardDelegate(byte[] initialText, byte[] descriptionText, int maxLength, int keyboardTypeEnum);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OutputBenchmarkValuesToPerformanceReporterDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OutputPerformanceReportsDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PairSceneNameToModuleNameDelegate(byte[] sceneName, byte[] moduleName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int ProcessWindowTitleDelegate(byte[] title);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void QuitGameDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int RegisterGPUAllocationGroupDelegate(byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RegisterMeshForGPUMorphDelegate(byte[] metaMeshName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int SaveDataAsTextureDelegate(byte[] path, int width, int height, IntPtr data);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SelectEntitiesDelegate(IntPtr gameEntities, int entityCount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAllocationAlwaysValidSceneDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAssertionAtShaderCompileDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAssertionsAndWarningsSetExitCodeDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBenchmarkStatusDelegate(int status, byte[] def);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCanLoadModulesDelegate([MarshalAs(UnmanagedType.U1)] bool canLoadModules);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCoreGameStateDelegate(int state);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCrashOnAssertsDelegate([MarshalAs(UnmanagedType.U1)] bool val);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCrashOnWarningsDelegate([MarshalAs(UnmanagedType.U1)] bool val);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCrashReportCustomStackDelegate(byte[] customStack);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCrashReportCustomStringDelegate(byte[] customString);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCreateDumpOnWarningsDelegate([MarshalAs(UnmanagedType.U1)] bool val);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDisableDumpGenerationDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDumpFolderPathDelegate(byte[] path);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFixedDtDelegate([MarshalAs(UnmanagedType.U1)] bool enabled, float dt);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetForceDrawEntityIDDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetForceVsyncDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFrameLimiterWithSleepDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetGraphicsPresetDelegate(int preset);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLoadingScreenPercentageDelegate(float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMessageLineRenderingStateDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPrintCallstackAtCrahsesDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRenderAgentsDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRenderModeDelegate(int mode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetReportModeDelegate([MarshalAs(UnmanagedType.U1)] bool reportMode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetScreenTextRenderingStateDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetWatchdogAutoreportDelegate([MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetWatchdogValueDelegate(byte[] fileName, byte[] groupName, byte[] key, byte[] value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetWindowTitleDelegate(byte[] title);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StartLoadingStuckCheckStateDelegate(float seconds);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StartScenePerformanceReportDelegate(byte[] folderPath);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TakeScreenshotFromPlatformPathDelegate(PlatformFilePath path);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TakeScreenshotFromStringPathDelegate(byte[] path);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int TakeSSFromTopDelegate(byte[] file_name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ToggleRenderDelegate();

	private static readonly Encoding _utf8;

	public static AddCommandLineFunctionDelegate call_AddCommandLineFunctionDelegate;

	public static AddMainThreadPerformanceQueryDelegate call_AddMainThreadPerformanceQueryDelegate;

	public static AddPerformanceReportTokenDelegate call_AddPerformanceReportTokenDelegate;

	public static AddSceneObjectReportDelegate call_AddSceneObjectReportDelegate;

	public static CheckIfAssetsAndSourcesAreSameDelegate call_CheckIfAssetsAndSourcesAreSameDelegate;

	public static CheckIfTerrainShaderHeaderGenerationFinishedDelegate call_CheckIfTerrainShaderHeaderGenerationFinishedDelegate;

	public static CheckResourceModificationsDelegate call_CheckResourceModificationsDelegate;

	public static CheckSceneForProblemsDelegate call_CheckSceneForProblemsDelegate;

	public static CheckShaderCompilationDelegate call_CheckShaderCompilationDelegate;

	public static clear_decal_atlasDelegate call_clear_decal_atlasDelegate;

	public static ClearOldResourcesAndObjectsDelegate call_ClearOldResourcesAndObjectsDelegate;

	public static ClearShaderMemoryDelegate call_ClearShaderMemoryDelegate;

	public static CommandLineArgumentExistsDelegate call_CommandLineArgumentExistsDelegate;

	public static CompileAllShadersDelegate call_CompileAllShadersDelegate;

	public static CompileTerrainShadersDistDelegate call_CompileTerrainShadersDistDelegate;

	public static CreateSelectionInEditorDelegate call_CreateSelectionInEditorDelegate;

	public static DebugSetGlobalLoadingWindowStateDelegate call_DebugSetGlobalLoadingWindowStateDelegate;

	public static DeleteEntitiesInEditorSceneDelegate call_DeleteEntitiesInEditorSceneDelegate;

	public static DetachWatchdogDelegate call_DetachWatchdogDelegate;

	public static DidAutomatedGIBakeFinishedDelegate call_DidAutomatedGIBakeFinishedDelegate;

	public static DisableCoreGameDelegate call_DisableCoreGameDelegate;

	public static DisableGlobalEditDataCacherDelegate call_DisableGlobalEditDataCacherDelegate;

	public static DisableGlobalLoadingWindowDelegate call_DisableGlobalLoadingWindowDelegate;

	public static DoDelayedexitDelegate call_DoDelayedexitDelegate;

	public static DoFullBakeAllLevelsAutomatedDelegate call_DoFullBakeAllLevelsAutomatedDelegate;

	public static DoFullBakeSingleLevelAutomatedDelegate call_DoFullBakeSingleLevelAutomatedDelegate;

	public static DoLightOnlyBakeAllLevelsAutomatedDelegate call_DoLightOnlyBakeAllLevelsAutomatedDelegate;

	public static DoLightOnlyBakeSingleLevelAutomatedDelegate call_DoLightOnlyBakeSingleLevelAutomatedDelegate;

	public static DumpGPUMemoryStatisticsDelegate call_DumpGPUMemoryStatisticsDelegate;

	public static EnableGlobalEditDataCacherDelegate call_EnableGlobalEditDataCacherDelegate;

	public static EnableGlobalLoadingWindowDelegate call_EnableGlobalLoadingWindowDelegate;

	public static EnableSingleGPUQueryPerFrameDelegate call_EnableSingleGPUQueryPerFrameDelegate;

	public static EndLoadingStuckCheckStateDelegate call_EndLoadingStuckCheckStateDelegate;

	public static ExecuteCommandLineCommandDelegate call_ExecuteCommandLineCommandDelegate;

	public static ExitProcessDelegate call_ExitProcessDelegate;

	public static ExportNavMeshFaceMarksDelegate call_ExportNavMeshFaceMarksDelegate;

	public static FindMeshesWithoutLodsDelegate call_FindMeshesWithoutLodsDelegate;

	public static FlushManagedObjectsMemoryDelegate call_FlushManagedObjectsMemoryDelegate;

	public static GatherCoreGameReferencesDelegate call_GatherCoreGameReferencesDelegate;

	public static GenerateTerrainShaderHeadersDelegate call_GenerateTerrainShaderHeadersDelegate;

	public static GetApplicationMemoryDelegate call_GetApplicationMemoryDelegate;

	public static GetApplicationMemoryStatisticsDelegate call_GetApplicationMemoryStatisticsDelegate;

	public static GetApplicationNameDelegate call_GetApplicationNameDelegate;

	public static GetAttachmentsPathDelegate call_GetAttachmentsPathDelegate;

	public static GetBaseDirectoryDelegate call_GetBaseDirectoryDelegate;

	public static GetBenchmarkStatusDelegate call_GetBenchmarkStatusDelegate;

	public static GetBuildNumberDelegate call_GetBuildNumberDelegate;

	public static GetConsoleHostMachineDelegate call_GetConsoleHostMachineDelegate;

	public static GetCoreGameStateDelegate call_GetCoreGameStateDelegate;

	public static GetCurrentCpuMemoryUsageDelegate call_GetCurrentCpuMemoryUsageDelegate;

	public static GetCurrentEstimatedGPUMemoryCostMBDelegate call_GetCurrentEstimatedGPUMemoryCostMBDelegate;

	public static GetCurrentProcessIDDelegate call_GetCurrentProcessIDDelegate;

	public static GetCurrentThreadIdDelegate call_GetCurrentThreadIdDelegate;

	public static GetDeltaTimeDelegate call_GetDeltaTimeDelegate;

	public static GetDetailedGPUBufferMemoryStatsDelegate call_GetDetailedGPUBufferMemoryStatsDelegate;

	public static GetDetailedXBOXMemoryInfoDelegate call_GetDetailedXBOXMemoryInfoDelegate;

	public static GetEditorSelectedEntitiesDelegate call_GetEditorSelectedEntitiesDelegate;

	public static GetEditorSelectedEntityCountDelegate call_GetEditorSelectedEntityCountDelegate;

	public static GetEngineFrameNoDelegate call_GetEngineFrameNoDelegate;

	public static GetEntitiesOfSelectionSetDelegate call_GetEntitiesOfSelectionSetDelegate;

	public static GetEntityCountOfSelectionSetDelegate call_GetEntityCountOfSelectionSetDelegate;

	public static GetExecutableWorkingDirectoryDelegate call_GetExecutableWorkingDirectoryDelegate;

	public static GetFpsDelegate call_GetFpsDelegate;

	public static GetFrameLimiterWithSleepDelegate call_GetFrameLimiterWithSleepDelegate;

	public static GetFullCommandLineStringDelegate call_GetFullCommandLineStringDelegate;

	public static GetFullFilePathOfSceneDelegate call_GetFullFilePathOfSceneDelegate;

	public static GetFullModulePathDelegate call_GetFullModulePathDelegate;

	public static GetFullModulePathsDelegate call_GetFullModulePathsDelegate;

	public static GetGPUMemoryMBDelegate call_GetGPUMemoryMBDelegate;

	public static GetGpuMemoryOfAllocationGroupDelegate call_GetGpuMemoryOfAllocationGroupDelegate;

	public static GetGPUMemoryStatsDelegate call_GetGPUMemoryStatsDelegate;

	public static GetLocalOutputPathDelegate call_GetLocalOutputPathDelegate;

	public static GetMainFpsDelegate call_GetMainFpsDelegate;

	public static GetMainThreadIdDelegate call_GetMainThreadIdDelegate;

	public static GetMemoryUsageOfCategoryDelegate call_GetMemoryUsageOfCategoryDelegate;

	public static GetModulesCodeDelegate call_GetModulesCodeDelegate;

	public static GetNativeMemoryStatisticsDelegate call_GetNativeMemoryStatisticsDelegate;

	public static GetNumberOfShaderCompilationsInProgressDelegate call_GetNumberOfShaderCompilationsInProgressDelegate;

	public static GetPCInfoDelegate call_GetPCInfoDelegate;

	public static GetPlatformModulePathsDelegate call_GetPlatformModulePathsDelegate;

	public static GetPossibleCommandLineStartingWithDelegate call_GetPossibleCommandLineStartingWithDelegate;

	public static GetRendererFpsDelegate call_GetRendererFpsDelegate;

	public static GetReturnCodeDelegate call_GetReturnCodeDelegate;

	public static GetSingleModuleScenesOfModuleDelegate call_GetSingleModuleScenesOfModuleDelegate;

	public static GetSteamAppIdDelegate call_GetSteamAppIdDelegate;

	public static GetSystemLanguageDelegate call_GetSystemLanguageDelegate;

	public static GetVertexBufferChunkSystemMemoryUsageDelegate call_GetVertexBufferChunkSystemMemoryUsageDelegate;

	public static GetVisualTestsTestFilesPathDelegate call_GetVisualTestsTestFilesPathDelegate;

	public static GetVisualTestsValidatePathDelegate call_GetVisualTestsValidatePathDelegate;

	public static IsAsyncPhysicsThreadDelegate call_IsAsyncPhysicsThreadDelegate;

	public static IsBenchmarkQuitedDelegate call_IsBenchmarkQuitedDelegate;

	public static IsDetailedSoundLogOnDelegate call_IsDetailedSoundLogOnDelegate;

	public static IsDevkitDelegate call_IsDevkitDelegate;

	public static IsEditModeEnabledDelegate call_IsEditModeEnabledDelegate;

	public static IsLockhartPlatformDelegate call_IsLockhartPlatformDelegate;

	public static IsSceneReportFinishedDelegate call_IsSceneReportFinishedDelegate;

	public static LoadSkyBoxesDelegate call_LoadSkyBoxesDelegate;

	public static LoadVirtualTextureTilesetDelegate call_LoadVirtualTextureTilesetDelegate;

	public static ManagedParallelForDelegate call_ManagedParallelForDelegate;

	public static ManagedParallelForWithDtDelegate call_ManagedParallelForWithDtDelegate;

	public static ManagedParallelForWithoutRenderThreadDelegate call_ManagedParallelForWithoutRenderThreadDelegate;

	public static OnLoadingWindowDisabledDelegate call_OnLoadingWindowDisabledDelegate;

	public static OnLoadingWindowEnabledDelegate call_OnLoadingWindowEnabledDelegate;

	public static OpenNavalDlcPurchasePageDelegate call_OpenNavalDlcPurchasePageDelegate;

	public static OpenOnscreenKeyboardDelegate call_OpenOnscreenKeyboardDelegate;

	public static OutputBenchmarkValuesToPerformanceReporterDelegate call_OutputBenchmarkValuesToPerformanceReporterDelegate;

	public static OutputPerformanceReportsDelegate call_OutputPerformanceReportsDelegate;

	public static PairSceneNameToModuleNameDelegate call_PairSceneNameToModuleNameDelegate;

	public static ProcessWindowTitleDelegate call_ProcessWindowTitleDelegate;

	public static QuitGameDelegate call_QuitGameDelegate;

	public static RegisterGPUAllocationGroupDelegate call_RegisterGPUAllocationGroupDelegate;

	public static RegisterMeshForGPUMorphDelegate call_RegisterMeshForGPUMorphDelegate;

	public static SaveDataAsTextureDelegate call_SaveDataAsTextureDelegate;

	public static SelectEntitiesDelegate call_SelectEntitiesDelegate;

	public static SetAllocationAlwaysValidSceneDelegate call_SetAllocationAlwaysValidSceneDelegate;

	public static SetAssertionAtShaderCompileDelegate call_SetAssertionAtShaderCompileDelegate;

	public static SetAssertionsAndWarningsSetExitCodeDelegate call_SetAssertionsAndWarningsSetExitCodeDelegate;

	public static SetBenchmarkStatusDelegate call_SetBenchmarkStatusDelegate;

	public static SetCanLoadModulesDelegate call_SetCanLoadModulesDelegate;

	public static SetCoreGameStateDelegate call_SetCoreGameStateDelegate;

	public static SetCrashOnAssertsDelegate call_SetCrashOnAssertsDelegate;

	public static SetCrashOnWarningsDelegate call_SetCrashOnWarningsDelegate;

	public static SetCrashReportCustomStackDelegate call_SetCrashReportCustomStackDelegate;

	public static SetCrashReportCustomStringDelegate call_SetCrashReportCustomStringDelegate;

	public static SetCreateDumpOnWarningsDelegate call_SetCreateDumpOnWarningsDelegate;

	public static SetDisableDumpGenerationDelegate call_SetDisableDumpGenerationDelegate;

	public static SetDumpFolderPathDelegate call_SetDumpFolderPathDelegate;

	public static SetFixedDtDelegate call_SetFixedDtDelegate;

	public static SetForceDrawEntityIDDelegate call_SetForceDrawEntityIDDelegate;

	public static SetForceVsyncDelegate call_SetForceVsyncDelegate;

	public static SetFrameLimiterWithSleepDelegate call_SetFrameLimiterWithSleepDelegate;

	public static SetGraphicsPresetDelegate call_SetGraphicsPresetDelegate;

	public static SetLoadingScreenPercentageDelegate call_SetLoadingScreenPercentageDelegate;

	public static SetMessageLineRenderingStateDelegate call_SetMessageLineRenderingStateDelegate;

	public static SetPrintCallstackAtCrahsesDelegate call_SetPrintCallstackAtCrahsesDelegate;

	public static SetRenderAgentsDelegate call_SetRenderAgentsDelegate;

	public static SetRenderModeDelegate call_SetRenderModeDelegate;

	public static SetReportModeDelegate call_SetReportModeDelegate;

	public static SetScreenTextRenderingStateDelegate call_SetScreenTextRenderingStateDelegate;

	public static SetWatchdogAutoreportDelegate call_SetWatchdogAutoreportDelegate;

	public static SetWatchdogValueDelegate call_SetWatchdogValueDelegate;

	public static SetWindowTitleDelegate call_SetWindowTitleDelegate;

	public static StartLoadingStuckCheckStateDelegate call_StartLoadingStuckCheckStateDelegate;

	public static StartScenePerformanceReportDelegate call_StartScenePerformanceReportDelegate;

	public static TakeScreenshotFromPlatformPathDelegate call_TakeScreenshotFromPlatformPathDelegate;

	public static TakeScreenshotFromStringPathDelegate call_TakeScreenshotFromStringPathDelegate;

	public static TakeSSFromTopDelegate call_TakeSSFromTopDelegate;

	public static ToggleRenderDelegate call_ToggleRenderDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCommandLineFunction(string concatName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMainThreadPerformanceQuery(string parent, string name, float seconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPerformanceReportToken(string performance_type, string name, float loading_time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSceneObjectReport(string scene_name, string report_name, float report_value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckIfAssetsAndSourcesAreSame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfTerrainShaderHeaderGenerationFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckResourceModifications()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckSceneForProblems(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckShaderCompilation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void clear_decal_atlas(DecalAtlasGroup atlasGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearOldResourcesAndObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearShaderMemory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CommandLineArgumentExists(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompileAllShaders(string targetPlatform)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CompileTerrainShadersDist(string targetPlatform, string targetConfig, string output_path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateSelectionInEditor(UIntPtr[] gameEntities, int entityCount, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DebugSetGlobalLoadingWindowState(bool s)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteEntitiesInEditorScene(UIntPtr[] gameEntities, int entityCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DetachWatchdog()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DidAutomatedGIBakeFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableCoreGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableGlobalEditDataCacher()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableGlobalLoadingWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoDelayedexit(int returnCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoFullBakeAllLevelsAutomated(string module, string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoFullBakeSingleLevelAutomated(string module, string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoLightOnlyBakeAllLevelsAutomated(string module, string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DoLightOnlyBakeSingleLevelAutomated(string module, string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DumpGPUMemoryStatistics(string filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableGlobalEditDataCacher()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableGlobalLoadingWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableSingleGPUQueryPerFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndLoadingStuckCheckState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ExecuteCommandLineCommand(string command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExitProcess(int exitCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ExportNavMeshFaceMarks(string file_name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FindMeshesWithoutLods(string module_name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FlushManagedObjectsMemory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GatherCoreGameReferences(string scene_names)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GenerateTerrainShaderHeaders(string targetPlatform, string targetConfig, string output_path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetApplicationMemory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetApplicationMemoryStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetApplicationName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAttachmentsPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetBaseDirectory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetBenchmarkStatus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetBuildNumber()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetConsoleHostMachine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCoreGameState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetCurrentCpuMemoryUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCurrentEstimatedGPUMemoryCostMB()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetCurrentProcessID()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetCurrentThreadId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetDeltaTime(int timerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetDetailedGPUBufferMemoryStats(ref int totalMemoryAllocated, ref int totalMemoryUsed, ref int emptyChunkCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetDetailedXBOXMemoryInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetEditorSelectedEntities(UIntPtr[] gameEntitiesTemp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetEditorSelectedEntityCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetEngineFrameNo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetEntitiesOfSelectionSet(string name, UIntPtr[] gameEntitiesTemp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetEntityCountOfSelectionSet(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetExecutableWorkingDirectory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFps()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetFrameLimiterWithSleep()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFullCommandLineString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFullFilePathOfScene(string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFullModulePath(string moduleName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFullModulePaths()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGPUMemoryMB()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetGpuMemoryOfAllocationGroup(string allocationName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetGPUMemoryStats(ref float totalMemory, ref float renderTargetMemory, ref float depthTargetMemory, ref float srvMemory, ref float bufferMemory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetLocalOutputPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMainFps()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetMainThreadId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMemoryUsageOfCategory(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetModulesCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetNativeMemoryStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfShaderCompilationsInProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetPCInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetPlatformModulePaths()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetPossibleCommandLineStartingWith(string command, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetRendererFps()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetReturnCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetSingleModuleScenesOfModule(string moduleName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSteamAppId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetSystemLanguage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetVertexBufferChunkSystemMemoryUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetVisualTestsTestFilesPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetVisualTestsValidatePath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAsyncPhysicsThread()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBenchmarkQuited()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int IsDetailedSoundLogOn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDevkit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEditModeEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLockhartPlatform()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsSceneReportFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadSkyBoxes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadVirtualTextureTileset(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ManagedParallelFor(int fromInclusive, int toExclusive, long curKey, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ManagedParallelForWithDt(int fromInclusive, int toExclusive, long curKey, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ManagedParallelForWithoutRenderThread(int fromInclusive, int toExclusive, long curKey, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnLoadingWindowDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnLoadingWindowEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OpenNavalDlcPurchasePage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OpenOnscreenKeyboard(string initialText, string descriptionText, int maxLength, int keyboardTypeEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OutputBenchmarkValuesToPerformanceReporter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OutputPerformanceReports()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PairSceneNameToModuleName(string sceneName, string moduleName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ProcessWindowTitle(string title)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void QuitGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int RegisterGPUAllocationGroup(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterMeshForGPUMorph(string metaMeshName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SaveDataAsTexture(string path, int width, int height, float[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SelectEntities(UIntPtr[] gameEntities, int entityCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAllocationAlwaysValidScene(UIntPtr scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAssertionAtShaderCompile(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAssertionsAndWarningsSetExitCode(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBenchmarkStatus(int status, string def)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCanLoadModules(bool canLoadModules)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCoreGameState(int state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCrashOnAsserts(bool val)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCrashOnWarnings(bool val)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCrashReportCustomStack(string customStack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCrashReportCustomString(string customString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCreateDumpOnWarnings(bool val)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDisableDumpGeneration(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDumpFolderPath(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFixedDt(bool enabled, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForceDrawEntityID(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForceVsync(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFrameLimiterWithSleep(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGraphicsPreset(int preset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLoadingScreenPercentage(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMessageLineRenderingState(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPrintCallstackAtCrahses(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderAgents(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderMode(int mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetReportMode(bool reportMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScreenTextRenderingState(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWatchdogAutoreport(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWatchdogValue(string fileName, string groupName, string key, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWindowTitle(string title)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartLoadingStuckCheckState(float seconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartScenePerformanceReport(string folderPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TakeScreenshotFromPlatformPath(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TakeScreenshotFromStringPath(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string TakeSSFromTop(string file_name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ToggleRender()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIUtil()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIUtil()
	{
		throw null;
	}
}
