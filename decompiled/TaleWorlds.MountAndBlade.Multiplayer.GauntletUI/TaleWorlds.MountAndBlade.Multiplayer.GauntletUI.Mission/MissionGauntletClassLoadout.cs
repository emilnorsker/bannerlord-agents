using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.Multiplayer.View.MissionViews;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.ClassLoadout;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI.Mission;

[OverrideView(typeof(MissionLobbyEquipmentUIHandler))]
public class MissionGauntletClassLoadout : MissionView
{
	private MultiplayerClassLoadoutVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private MissionRepresentativeBase _myRepresentative;

	private MissionNetworkComponent _missionNetworkComponent;

	private MissionLobbyComponent _missionLobbyComponent;

	private MissionLobbyEquipmentNetworkComponent _missionLobbyEquipmentNetworkComponent;

	private MissionMultiplayerGameModeBaseClient _gameModeClient;

	private MultiplayerTeamSelectComponent _teamSelectComponent;

	private MissionGauntletMultiplayerScoreboard _scoreboardGauntletComponent;

	private MPHeroClass _lastSelectedHeroClass;

	private bool _tryToInitialize;

	public bool IsActive
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

	public bool IsForceClosed
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
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMyClientSynchronized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTeamChanged(NetworkCommunicator peer, Team previousTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRefreshSelection(MPHeroClass heroClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTryToggle(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool OnToggled(bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectingTeam(List<Team> disableTeams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnScoreboardToggled(bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPeerEquipmentRefreshed(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGoldUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletClassLoadout()
	{
		throw null;
	}
}
