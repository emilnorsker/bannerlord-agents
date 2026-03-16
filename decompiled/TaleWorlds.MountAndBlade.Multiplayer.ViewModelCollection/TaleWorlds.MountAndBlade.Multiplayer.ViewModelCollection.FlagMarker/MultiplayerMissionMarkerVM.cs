using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.FlagMarker.Targets;
using TaleWorlds.MountAndBlade.Objects;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.FlagMarker;

public class MultiplayerMissionMarkerVM : ViewModel
{
	public class MarkerDistanceComparer : IComparer<MissionMarkerTargetVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(MissionMarkerTargetVM x, MissionMarkerTargetVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MarkerDistanceComparer()
		{
			throw null;
		}
	}

	private readonly Camera _missionCamera;

	private bool _prevEnabledState;

	private bool _fadeOutTimerStarted;

	private float _fadeOutTimer;

	private MarkerDistanceComparer _distanceComparer;

	private readonly ICommanderInfo _commanderInfo;

	private readonly Dictionary<MissionPeer, MissionPeerMarkerTargetVM> _teammateDictionary;

	private readonly MissionMultiplayerSiegeClient _siegeClient;

	private readonly List<PlayerId> _friendIDs;

	private MBBindingList<MissionFlagMarkerTargetVM> _flagTargets;

	private MBBindingList<MissionPeerMarkerTargetVM> _peerTargets;

	private MBBindingList<MissionSiegeEngineMarkerTargetVM> _siegeEngineTargets;

	private MBBindingList<MissionAlwaysVisibleMarkerTargetVM> _alwaysVisibleTargets;

	private bool _isEnabled;

	[DataSourceProperty]
	public MBBindingList<MissionFlagMarkerTargetVM> FlagTargets
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
	public MBBindingList<MissionPeerMarkerTargetVM> PeerTargets
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
	public MBBindingList<MissionSiegeEngineMarkerTargetVM> SiegeEngineTargets
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
	public MBBindingList<MissionAlwaysVisibleMarkerTargetVM> AlwaysVisibleTargets
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerMissionMarkerVM(Camera missionCamera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCapturePointRemainingMoraleGainsChanged(int[] remainingMoraleGainsArr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTeamChanged(NetworkCommunicator peer, Team previousTeam, Team newTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTargetScreenPositions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAlwaysVisibleTargetScreenPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFlagNumberChangedEvent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitCapturePoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetCapturePointLists()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCapturePointOwnerChangedEvent(FlagCapturePoint flag, Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRefreshPeerMarkers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnRemoveAlwaysVisibleMarker(MissionAlwaysVisibleMarkerTargetVM marker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTargetStates(bool state)
	{
		throw null;
	}
}
