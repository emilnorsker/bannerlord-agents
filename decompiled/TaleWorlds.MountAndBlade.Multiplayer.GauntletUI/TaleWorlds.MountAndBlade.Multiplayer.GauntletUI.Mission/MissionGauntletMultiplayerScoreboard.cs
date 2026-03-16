using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.Multiplayer.View.MissionViews;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Scoreboard;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI.Mission;

[OverrideView(typeof(MissionScoreboardUIHandler))]
public class MissionGauntletMultiplayerScoreboard : MissionView
{
	private GauntletLayer _gauntletLayer;

	private MissionScoreboardVM _dataSource;

	private bool _isSingleTeam;

	private bool _isActive;

	private bool _isMissionEnding;

	private bool _mouseRequstedWhileScoreboardActive;

	private bool _isMouseVisible;

	private MissionLobbyComponent _missionLobbyComponent;

	private MultiplayerTeamSelectComponent _teamSelectComponent;

	public Action<bool> OnScoreboardToggled;

	private float _scoreboardStayDuration;

	private float _scoreboardStayTimeElapsed;

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UsedImplicitly]
	public MissionGauntletMultiplayerScoreboard(bool isSingleTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UnregisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ToggleScoreboard(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMouseState(bool isMouseVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleSpectateAgentFocusOut(Agent followedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleSpectateAgentFocusIn(Agent followedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MissionLobbyComponentOnCurrentMultiplayerStateChanged(MultiplayerGameState newState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTeamChanged(NetworkCommunicator peer, Team previousTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinalizeLayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeLayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectingTeam(List<Team> disableTeams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCultureSelectionRequested()
	{
		throw null;
	}
}
