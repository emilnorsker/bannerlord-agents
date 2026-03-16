using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.View.Conversation;
using SandBox.View.Map;
using SandBox.View.Map.Visuals;
using SandBox.View.OrderProviders;
using TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.Overlay;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.SaveSystem.Load;

namespace SandBox.View;

public class SandBoxViewSubModule : MBSubModuleBase
{
	private bool _latestSaveLoaded;

	private TextObject _sandBoxAchievementsHint;

	private bool _isInitialized;

	private HideoutVisualOrderProvider _hideoutVisualOrderProvider;

	private ConversationViewManager _conversationViewManager;

	private SandBoxViewVisualManager _sandBoxViewVisualManager;

	private IMapConversationDataProvider _mapConversationDataProvider;

	private IGameMenuOverlayProvider _gameMenuOverlayProvider;

	private Dictionary<UIntPtr, MapEntityVisual> _visualsOfEntities;

	private Dictionary<UIntPtr, Tuple<MatrixFrame, SettlementVisual>> _frameAndVisualOfEngines;

	private static SandBoxViewSubModule _instance;

	public static SandBoxViewVisualManager SandBoxViewVisualManager
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static ConversationViewManager ConversationViewManager
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMapConversationDataProvider MapConversationDataProvider
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal static Dictionary<UIntPtr, MapEntityVisual> VisualsOfEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	internal static Dictionary<UIntPtr, Tuple<MatrixFrame, SettlementVisual>> FrameAndVisualOfEngines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSubModuleLoad()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSubModuleUnloaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnApplicationTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCampaignStart(Game game, object starterObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameLoaded(Game game, object initializerObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAfterGameInitializationFinished(Game game, object starterObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void BeginGameStart(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnGameEnd(Game game)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (bool, TextObject) IsSavedGamesDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (bool, TextObject) IsContinueCampaignDisabled(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private (bool, TextObject) IsSandboxDisabled()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ContinueCampaign(string saveName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnInitialState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartGame(LoadResult loadResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartGame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnImguiProfilerTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterTooltipTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnregisterTooltipTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetMapConversationDataProvider(IMapConversationDataProvider mapConversationDataProvider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnSaveHelperStateChange(SandBoxSaveHelper.SaveHelperState currentState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandBoxViewSubModule()
	{
		throw null;
	}
}
