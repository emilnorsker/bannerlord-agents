using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Options;
using TaleWorlds.MountAndBlade.Multiplayer.View.MissionViews;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.TwoDimension;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI.Mission;

[OverrideView(typeof(MissionMultiplayerDuelUI))]
public class MissionGauntletDuelUI : MissionView
{
	private MultiplayerDuelVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private SpriteCategory _mpMissionCategory;

	private MissionMultiplayerGameModeDuelClient _client;

	private MissionLobbyEquipmentNetworkComponent _equipmentController;

	private MissionLobbyComponent _lobbyComponent;

	private bool _isPeerEquipmentsDirty;

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
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNativeOptionChanged(NativeOptionsType optionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentBuild(Agent agent, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFocusGained(Agent agent, IFocusable focusableObject, bool isInteractable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFocusLost(Agent agent, IFocusable focusableObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPeerEquipmentIndexRefreshed(MissionPeer peer, int equipmentSetIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEquipmentRefreshed(MissionPeer peer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPostMatchEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletDuelUI()
	{
		throw null;
	}
}
