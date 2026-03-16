using System;
using System.Runtime.CompilerServices;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapNotificationTypes;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(MapNotificationView))]
public class GauntletMapNotificationView : MapNotificationView
{
	private MapNotificationVM _dataSource;

	private GauntletMovieIdentifier _movie;

	private INavigationHandler _mapNavigationHandler;

	private GauntletLayer _layerAsGauntletLayer;

	private bool _isHoveringOnNotification;

	private const string _defaultSound = "event:/ui/default";

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapNotificationView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CreateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnReceiveNewNotification(MapNotificationItemBaseVM newNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterMapNotificationType(Type data, Type item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMenuModeTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMapConversationOver()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleInput()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ResetNotifications()
	{
		throw null;
	}
}
