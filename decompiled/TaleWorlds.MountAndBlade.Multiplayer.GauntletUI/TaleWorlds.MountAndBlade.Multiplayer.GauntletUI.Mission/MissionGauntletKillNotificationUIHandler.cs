using System.Runtime.CompilerServices;
using NetworkMessages.FromServer;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.Multiplayer.View.MissionViews;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.KillFeed;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI.Mission;

[OverrideView(typeof(MissionMultiplayerKillNotificationUIHandler))]
public class MissionGauntletKillNotificationUIHandler : MissionView
{
	private MPKillFeedVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private MissionMultiplayerTeamDeathmatchClient _tdmClient;

	private MissionMultiplayerSiegeClient _siegeClient;

	private MissionMultiplayerGameModeDuelClient _duelClient;

	private MissionMultiplayerGameModeFlagDominationClient _flagDominationClient;

	private bool _isGeneralFeedEnabled;

	private bool _doesGameModeAllowGeneralFeed;

	private bool _isPersonalFeedEnabled;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnOptionChange(ManagedOptionsType changedManagedOptionsType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGoldGain(GoldGain goldGainMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCombatLogManagerOnPrintCombatLog(CombatLogData logData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletKillNotificationUIHandler()
	{
		throw null;
	}
}
