using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.GauntletUI.Mission;
using TaleWorlds.MountAndBlade.Multiplayer.View.MissionViews;
using TaleWorlds.MountAndBlade.Source.Missions;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.ViewModelCollection.EscapeMenu;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI.Mission;

[OverrideView(typeof(MissionMultiplayerEscapeMenu))]
public class MissionGauntletMultiplayerEscapeMenu : MissionGauntletEscapeMenuBase
{
	private MissionOptionsComponent _missionOptionsComponent;

	private MissionLobbyComponent _missionLobbyComponent;

	private MultiplayerAdminComponent _missionAdminComponent;

	private MultiplayerTeamSelectComponent _missionTeamSelectComponent;

	private MissionMultiplayerGameModeBaseClient _gameModeClient;

	private readonly string _gameType;

	private EscapeMenuItemVM _changeTroopItem;

	private EscapeMenuItemVM _changeCultureItem;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletMultiplayerEscapeMenu(string gameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool OnEscape()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override List<EscapeMenuItemVM> GetEscapeMenuItems()
	{
		throw null;
	}
}
