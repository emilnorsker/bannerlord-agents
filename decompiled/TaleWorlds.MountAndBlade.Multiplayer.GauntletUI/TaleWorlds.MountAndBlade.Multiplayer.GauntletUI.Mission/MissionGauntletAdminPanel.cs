using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Multiplayer.Admin;
using TaleWorlds.MountAndBlade.Multiplayer.View.MissionViews;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.AdminPanel;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI.Mission;

[OverrideView(typeof(MultiplayerAdminPanelUIHandler))]
public class MissionGauntletAdminPanel : MissionView
{
	public delegate IAdminPanelOptionProvider CreateOptionProviderDelegeate();

	public delegate MultiplayerAdminPanelOptionBaseVM CreateOptionViewModelDelegate(IAdminPanelOption option);

	public delegate MultiplayerAdminPanelOptionBaseVM CreateActionViewModelDelegate(IAdminPanelAction action);

	private GauntletLayer _gauntletLayer;

	private MultiplayerAdminPanelVM _dataSource;

	private GauntletMovieIdentifier _movie;

	private bool _isActive;

	private MultiplayerAdminComponent _multiplayerAdminComponent;

	private MissionLobbyComponent _missionLobbyComponent;

	private readonly MBList<CreateOptionProviderDelegeate> _optionProviderCreators;

	private readonly MBList<CreateOptionViewModelDelegate> _optionViewModelCreators;

	private readonly MBList<CreateActionViewModelDelegate> _actionViewModelCreators;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletAdminPanel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private IAdminPanelOptionProvider CreateDefaultAdminPanelOptionProvider()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool OnEscape()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddOptionProviderCreator(CreateOptionProviderDelegeate creator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnExitAdminPanel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShowAdminPanel(bool show)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddOptionViewModelCreator(CreateOptionViewModelDelegate creator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddActionViewModelCreator(CreateActionViewModelDelegate creator)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MultiplayerAdminPanelOptionBaseVM CreateDefaultOptionViewModels(IAdminPanelOption option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MultiplayerAdminPanelOptionBaseVM CreateDefaultActionViewModels(IAdminPanelAction action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MultiplayerAdminPanelOptionBaseVM OnCreateOptionViewModel(IAdminPanelOption option)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MultiplayerAdminPanelOptionBaseVM OnCreateActionViewModel(IAdminPanelAction action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEscapeMenuToggled(bool isOpened)
	{
		throw null;
	}
}
