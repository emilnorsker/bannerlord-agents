using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.HUDExtensions;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.KillFeed;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection;

public class MultiplayerDuelVM : ViewModel
{
	public struct DuelArenaProperties
	{
		public GameEntity FlagEntity;

		public int Index;

		public TroopType ArenaTroopType;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DuelArenaProperties(GameEntity flagEntity, int index, TroopType arenaTroopType)
		{
			throw null;
		}
	}

	private const string ArenaFlagTag = "area_flag";

	private const string AremaTypeFlagTagBase = "flag_";

	private readonly MissionMultiplayerGameModeDuelClient _client;

	private readonly MissionMultiplayerGameModeBaseClient _gameMode;

	private bool _isMyRepresentativeAssigned;

	private List<DuelArenaProperties> _duelArenaProperties;

	private TextObject _scoreWithSeparatorText;

	private bool _isAgentBuiltForTheFirstTime;

	private bool _hasPlayerChangedArenaPreferrence;

	private string _cachedPlayerClassID;

	private bool _showSpawnPoints;

	private Camera _missionCamera;

	private bool _isEnabled;

	private bool _areOngoingDuelsActive;

	private bool _isPlayerInDuel;

	private int _playerBounty;

	private int _playerPreferredArenaType;

	private string _playerScoreText;

	private string _remainingRoundTime;

	private MissionDuelMarkersVM _markers;

	private DuelMatchVM _playerDuelMatch;

	private MBBindingList<DuelMatchVM> _ongoingDuels;

	private MBBindingList<MPDuelKillNotificationItemVM> _killNotifications;

	[DataSourceProperty]
	public bool IsEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool AreOngoingDuelsActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsPlayerInDuel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public int PlayerBounty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public int PlayerPrefferedArenaType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string PlayerScoreText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string RemainingRoundTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MissionDuelMarkersVM Markers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public DuelMatchVM PlayerDuelMatch
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<DuelMatchVM> OngoingDuels
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<MPDuelKillNotificationItemVM> KillNotifications
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerDuelVM(Camera missionCamera, MissionMultiplayerGameModeDuelClient client)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMyRepresentativeAssigned()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void DebugTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnManagedOptionChanged(ManagedOptionsType changedManagedOptionsType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDuelPrepStarted(MissionPeer opponentPeer, int duelStartTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAgentSpawnedWithoutDuel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerPreferredZoneChanged(TroopType zoneType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDuelStarted(MissionPeer firstPeer, MissionPeer secondPeer, int flagIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDuelEnded(MissionPeer winnerPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDuelRoundEnded(MissionPeer winnerPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePlayerScore()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveKillNotification(MPDuelKillNotificationItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnScreenResolutionChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMainAgentRemoved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnMainAgentBuild()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetArenaTypeName(TroopType duelArenaType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextObject GetArenaTypeLocalizedName(TroopType duelArenaType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private DuelArenaProperties GetArenaPropertiesOfFlagEntity(GameEntity flagEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TroopType GetAgentDefaultPreferredArenaType(Agent agent)
	{
		throw null;
	}
}
