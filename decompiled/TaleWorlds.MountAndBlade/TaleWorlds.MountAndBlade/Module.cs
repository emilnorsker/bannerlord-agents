using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ModuleManager;
using TaleWorlds.PlatformService;

namespace TaleWorlds.MountAndBlade;

public sealed class Module : DotNetObject, IGameStateManagerOwner
{
	public enum XmlInformationType
	{
		Parameters,
		MbObjectType
	}

	private enum StartupType
	{
		None,
		TestMode,
		GameServer,
		Singleplayer,
		Multiplayer,
		Count
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CShutDownWithDelay_003Ed__137 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public Module _003C_003E4__this;

		public int seconds;

		public string reason;

		private int _003Ci_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void MoveNext()
		{
			throw null;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			throw null;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private bool _enableCoreContentOnReturnToRoot;

	private List<MissionInfo> _missionInfos;

	private TestContext _testContext;

	private SingleThreadedSynchronizationContext _synchronizationContext;

	private readonly Dictionary<SubModuleInfo, MBSubModuleBase> _subModuleBases;

	private bool _splashScreenPlayed;

	private List<InitialStateOption> _initialStateOptions;

	private IEditorMissionTester _editorMissionTester;

	private Dictionary<string, MultiplayerGameMode> _multiplayerGameModesWithNames;

	private MBList<MultiplayerGameTypeInfo> _multiplayerGameTypes;

	private bool _isShuttingDown;

	public static Module CurrentModule
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

	public GameStateManager GlobalGameStateManager
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

	public bool MultiplayerRequested
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool ReturnToEditorState
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

	public bool LoadingFinished
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

	public GameTextManager GlobalTextManager
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

	public bool IsOnlyCoreContentEnabled
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

	public JobManager JobManager
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

	public GameStartupInfo StartupInfo
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

	public event Action SkinsXMLHasChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action ImguiProfilerTick
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Module()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<MBSubModuleBase> CollectSubModules()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CreateModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddSubModule(SubModuleInfo subModuleInfo, Assembly subModuleAssembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Dictionary<string, Type> CollectModuleAssemblyTypes(Assembly moduleAssembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeSubModuleBases()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewModuleLoaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBSubModuleBase GetSubModuleBase(SubModuleInfo subModuleInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinalizeSubModulesBases()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void LoadSingleModule(string modulePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool OnPlatformTextRequested(string initialText, string descriptionText, int maxLength, int keyboardTypeEnum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadLocalizationXmls()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetWindowTitle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnsureAsyncJobsAreFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ProcessApplicationArguments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnApplicationTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConfirmReturnToMainMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNetworkTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void RunTest(string commandLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal void TickTest(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnDumpCreated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnDumpCreationStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetMetaMeshPackageMapping(Dictionary<string, string> metaMeshPackageMappings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetItemMeshNames(HashSet<string> itemMeshNames)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal string GetMetaMeshPackageMapping()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal string GetItemMeshNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandLineFunctionality.CommandLineArgumentFunction("get_item_mesh_names", "module")]
	public static string GetCraftedItemMeshNames(List<string> arguments)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal string GetHorseMaterialNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetInitialModuleScreenAsRootScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnInitialModuleScreenActivated(bool isFromSplashScreenVideo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSignInStateUpdated(bool isLoggedIn, TextObject message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal bool SetEditorScreenAsRootScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckAssemblyForMissionMethods(Assembly assembly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FindMissions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal string GetMissionControllerClassNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadPlatformServices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSessionInvitationAccepted(SessionInvitationType targetGameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlatformRequestedMultiplayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadSubModules(List<ModuleInfo> modules, bool loadNewModules)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Type GetSubModuleType(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfSubmoduleCanBeLoadable(SubModuleInfo subModuleInfo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool GetSubModuleValiditiy(SubModuleInfo.SubModuleTags tag, string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static void MBThrowException()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnEnterEditMode(bool isFirstTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static Module GetInstance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static string GetGameStatus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinalizeModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FinalizeCurrentModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void SetLoadingFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnCloseSceneEditorPresentation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnSceneEditorModeOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConfigChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnConstrainedStateChange(bool isConstrained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFocusGained()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTextEnteredFromPlatform(string text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTextCanceledFromPlatform()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnSkinsXMLHasChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void OnImguiProfilerTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static string CreateProcessedSkinsXMLForNative(out string baseSkinsXmlPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal static string CreateProcessedActionSetsXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal static string CreateProcessedActionTypesXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal static string CreateProcessedAnimationsXMLForNative(out string animationsXmlPaths)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal static string CreateProcessedVoiceDefinitionsXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal static string CreateProcessedSoundEventDataXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, true)]
	internal static string CreateProcessedSoundParamsXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal static string CreateProcessedModuleDataXMLForNative(string xmlType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearStateOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddInitialStateOption(InitialStateOption initialStateOption)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OverrideInitialStateOption(string id, InitialStateOption newInitialStateOption)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<InitialStateOption> GetInitialStateOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public InitialStateOption GetInitialStateOptionWithId(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteInitialStateOptionWithId(string id)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCanLoadModules(bool canLoadModules)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateManagerOwner.OnStateStackEmpty()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameStateManagerOwner.OnStateChanged(GameState oldState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEditorMissionTester(IEditorMissionTester editorMissionTester)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void StartMissionForEditor(string missionName, string sceneName, string levels)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MBCallback(null, false)]
	internal void StartMissionForReplayEditor(string missionName, string sceneName, string levels, string fileName, bool record, float startTime, float endTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartMissionForEditorAux(string missionName, string sceneName, string levels, bool forReplay, string replayFileName, bool isRecord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FillMultiplayerGameTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerGameMode GetMultiplayerGameMode(string gameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMultiplayerGameMode(MultiplayerGameMode multiplayerGameMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBReadOnlyList<MultiplayerGameTypeInfo> GetMultiplayerGameTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool StartMultiplayerGame(string multiplayerGameType, string scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[AsyncStateMachine(typeof(_003CShutDownWithDelay_003Ed__137))]
	public void ShutDownWithDelay(string reason, int seconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeactiveModule(string moduleId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateModule(string moduleId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnBeforeGameStart(MBGameManager mbGameManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnGameEnd()
	{
		throw null;
	}
}
