using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public static class Utilities
{
	public enum EngineRenderDisplayMode
	{
		ShowNone,
		ShowAlbedo,
		ShowNormals,
		ShowVertexNormals,
		ShowSpecular,
		ShowGloss,
		ShowOcclusion,
		ShowGbufferShadowMask,
		ShowTranslucency,
		ShowMotionVector,
		ShowVertexColor,
		ShowDepth,
		ShowTiledLightOverdraw,
		ShowTiledDecalOverdraw,
		ShowMeshId,
		ShowDisableSunLighting,
		ShowDebugTexture,
		ShowTextureDensity,
		ShowOverdraw,
		ShowVsComplexity,
		ShowPsComplexity,
		ShowDisableAmbientLighting,
		ShowEntityId,
		ShowPrtDiffuseAmbient,
		ShowLightDebugMode,
		ShowParticleShadingAtlas,
		ShowTerrainAngle,
		ShowParallaxDebug,
		ShowAlbedoValidation,
		NumDebugModes
	}

	private class MainThreadJob
	{
		private Delegate _function;

		private object[] _parameters;

		private Semaphore wait_handle;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal MainThreadJob(Delegate function, object[] parameters)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal MainThreadJob(Semaphore sema, Delegate function, object[] parameters)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void Invoke()
		{
			throw null;
		}
	}

	public class MainThreadPerformanceQuery : IDisposable
	{
		private string _name;

		private string _parent;

		private Stopwatch _stopWatch;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MainThreadPerformanceQuery(string parent, string name)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Dispose()
		{
			throw null;
		}
	}

	private static ConcurrentQueue<MainThreadJob> jobs;

	public static bool renderingActive;

	public static int EngineFrameNo
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

	private static PlatformFilePath DefaultBannerlordConfigFullPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ConstructMainThreadJob(Delegate function, params object[] parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ConstructMainThreadJob(Semaphore semaphore, Delegate function, params object[] parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RunJobs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void WaitJobs()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OutputBenchmarkValuesToPerformanceReporter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetLoadingScreenPercentage(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetFixedDt(bool enabled, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetBenchmarkStatus(int status, string def)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetBenchmarkStatus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetApplicationMemoryStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsBenchmarkQuited()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetNativeMemoryStatistics()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CommandLineArgumentExists(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetConsoleHostMachine()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ExportNavMeshFaceMarks(string file_name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string TakeSSFromTop(string file_name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckIfAssetsAndSourcesAreSame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DisableCoreGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetApplicationMemory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GatherCoreGameReferences(string scene_names)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsOnlyCoreContentEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FindMeshesWithoutLods(string module_name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetDisableDumpGeneration(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetPrintCallstackAtCrahses(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetModulesNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetFullFilePathOfScene(string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryGetFullFilePathOfScene(string sceneName, out string fullPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryGetUniqueIdentifiersForScene(string sceneName, out UniqueSceneId identifiers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TryGetUniqueIdentifiersForSceneFile(string xsceneFilePath, out UniqueSceneId identifiers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PairSceneNameToModuleName(string sceneName, string moduleName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string[] GetSingleModuleScenesOfModule(string moduleName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetFullCommandLineString()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetScreenTextRenderingState(bool state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetMessageLineRenderingState(bool state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckIfTerrainShaderHeaderGenerationFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GenerateTerrainShaderHeaders(string targetPlatform, string targetConfig, string output_path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CompileTerrainShadersDist(string targetPlatform, string targetConfig, string output_path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCrashOnAsserts(bool val)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCrashOnWarnings(bool val)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCreateDumpOnWarnings(bool val)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ToggleRender()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetRenderAgents(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckShaderCompilation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CompileAllShaders(string targetPlatform)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetExecutableWorkingDirectory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetDumpFolderPath(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckSceneForProblems(string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCoreGameState(int state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetCoreGameState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ExecuteCommandLineCommand(string command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void QuitGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExitProcess(int exitCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetBasePath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetVisualTestsValidatePath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetVisualTestsTestFilesPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetAttachmentsPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartScenePerformanceReport(string folderPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsSceneReportFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetFps()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetMainFps()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetRendererFps()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EnableSingleGPUQueryPerFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearDecalAtlas(DecalAtlasGroup atlasGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FlushManagedObjectsMemory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnLoadingWindowEnabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DebugSetGlobalLoadingWindowState(bool newState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnLoadingWindowDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DisableGlobalLoadingWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EnableGlobalLoadingWindow()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EnableGlobalEditDataCacher()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DoFullBakeAllLevelsAutomated(string module, string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetReturnCode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DisableGlobalEditDataCacher()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DoFullBakeSingleLevelAutomated(string module, string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DoLightOnlyBakeSingleLevelAutomated(string module, string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DoLightOnlyBakeAllLevelsAutomated(string module, string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool DidAutomatedGIBakeFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetSelectedEntities(ref List<GameEntity> gameEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeleteEntitiesInEditorScene(List<GameEntity> gameEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CreateSelectionInEditor(List<GameEntity> gameEntities, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SelectEntities(List<GameEntity> gameEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetEntitiesOfSelectionSet(string selectionSetName, ref List<GameEntity> gameEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddCommandLineFunction(string concatName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetNumberOfShaderCompilationsInProgress()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int IsDetailedSoundLogOn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ulong GetCurrentCpuMemoryUsageMB()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ulong GetGpuMemoryOfAllocationGroup(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetGPUMemoryStats(ref float totalMemory, ref float renderTargetMemory, ref float depthTargetMemory, ref float srvMemory, ref float bufferMemory)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetDetailedGPUMemoryData(ref int totalMemoryAllocated, ref int totalMemoryUsed, ref int emptyChunkTotalSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetRenderMode(EngineRenderDisplayMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetForceDrawEntityID(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddPerformanceReportToken(string performance_type, string name, float loading_time)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddSceneObjectReport(string scene_name, string report_name, float report_value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OutputPerformanceReports()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TakeScreenshot(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TakeScreenshot(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetAllocationAlwaysValidScene(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CheckResourceModifications()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetGraphicsPreset(int preset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetLocalOutputPath()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPCInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetGPUMemoryMB()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetCurrentEstimatedGPUMemoryCostMB()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DumpGPUMemoryStatistics(string filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int SaveDataAsTexture(string path, int width, int height, float[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearOldResourcesAndObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LoadVirtualTextureTileset(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDeltaTime(int timerId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LoadSkyBoxes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetApplicationName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenNavalDlcPurchasePage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetWindowTitle(string title)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ProcessWindowTitle(string title)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static uint GetCurrentProcessID()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DoDelayedexit(int returnCode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetAssertionsAndWarningsSetExitCode(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetReportMode(bool reportMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetAssertionAtShaderCompile(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCrashReportCustomString(string customString)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCrashReportCustomStack(string customStack)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetSteamAppId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetForceVsync(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string LoadBannerlordConfigFile()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveResult SaveConfigFile(string configProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OpenOnscreenKeyboard(string initialText, string descriptionText, int maxLength, int keyboardTypeEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetSystemLanguage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int RegisterGPUAllocationGroup(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetMemoryUsageOfCategory(int category)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetDetailedXBOXMemoryInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetFrameLimiterWithSleep(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetFrameLimiterWithSleep()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPossibleCommandLineStartingWith(string command, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsDevkit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsLockhartPlatform()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetVertexBufferChunkSystemMemoryUsage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetBuildNumber()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ApplicationVersion GetApplicationVersionWithBuildNumber()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ParallelFor(int startIndex, int endIndex, long curKey, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ParallelForWithoutRenderThread(int startIndex, int endIndex, long curKey, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ClearShaderMemory()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RegisterMeshForGPUMorph(string metaMeshName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ParallelForWithDt(int startIndex, int endIndex, long curKey, int grainSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ulong GetMainThreadId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ulong GetCurrentThreadId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetWatchdogValue(string fileName, string groupName, string key, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetWatchdogAutoreport(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DetachWatchdog()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetPlatformModulePaths()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsAsyncPhysicsThread()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StartLoadingStuckCheckState(float timeoutThresholdSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EndLoadingStuckCheckState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Utilities()
	{
		throw null;
	}
}
