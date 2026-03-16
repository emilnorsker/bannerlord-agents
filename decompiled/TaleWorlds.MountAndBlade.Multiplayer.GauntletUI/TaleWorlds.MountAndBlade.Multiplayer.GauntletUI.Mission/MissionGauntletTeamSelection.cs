using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.Multiplayer.View.MissionViews;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.TeamSelection;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI.Mission;

[OverrideView(typeof(MultiplayerTeamSelectUIHandler))]
public class MissionGauntletTeamSelection : MissionView
{
	private GauntletLayer _gauntletLayer;

	private MultiplayerTeamSelectVM _dataSource;

	private MissionNetworkComponent _missionNetworkComponent;

	private MultiplayerTeamSelectComponent _multiplayerTeamSelectComponent;

	private MissionGauntletMultiplayerScoreboard _scoreboardGauntletComponent;

	private MissionGauntletClassLoadout _classLoadoutGauntletComponent;

	private MissionLobbyComponent _lobbyComponent;

	private List<Team> _disabledTeams;

	private bool _toOpen;

	private bool _isSynchronized;

	private bool _isActive;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletTeamSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
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
	private void OnClose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnOpen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnChangeTeamTo(Team targetTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMyTeamChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAutoassign()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MissionLobbyComponentOnSelectingTeam(List<Team> disabledTeams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MissionLobbyComponentOnFriendsUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MissionLobbyComponentOnUpdateTeams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnScoreboardToggled(bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMyClientSynchronized()
	{
		throw null;
	}
}
