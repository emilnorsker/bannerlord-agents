using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.Scripts;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.GauntletUI.SceneNotification;

public class GauntletSceneNotification : GlobalLayer
{
	private class SceneNotificationQueueItem
	{
		public SceneNotificationData Data;

		public int FramesUntilDisplay;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SceneNotificationQueueItem()
		{
			throw null;
		}
	}

	private readonly GauntletLayer _gauntletLayer;

	private readonly Queue<SceneNotificationQueueItem> _notificationQueue;

	private readonly List<ISceneNotificationContextProvider> _contextProviders;

	private SceneNotificationVM _dataSource;

	private bool _isActive;

	private bool _isLastActiveGameStatePaused;

	private bool _isPendingSceneLoad;

	private Scene _scene;

	private MBAgentRendererSceneController _agentRendererSceneController;

	private List<PopupSceneSpawnPoint> _sceneCharacterScripts;

	private PopupSceneCameraPath _cameraPathScript;

	private Dictionary<string, GameEntity> _customPrefabBannerEntities;

	public static GauntletSceneNotification Current
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

	public bool IsActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GauntletSceneNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAnySceneNotifiationActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHideSceneNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShowSceneNotification(SceneNotificationData campaignNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QueueTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPositiveAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OpenScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBannerTableauRenderDone(GameEntity bannerEntity, Texture bannerTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyBannerTextureToMesh(Mesh bannerMesh, Texture bannerTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateSceneNotification(SceneNotificationData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CloseNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetContinueKeyText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterContextProvider(ISceneNotificationContextProvider provider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveContextProvider(ISceneNotificationContextProvider provider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsGivenContextApplicableToCurrentContext(RelevantContextType givenContextType)
	{
		throw null;
	}
}
