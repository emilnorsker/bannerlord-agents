using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection;

public class MissionDuelMarkersVM : ViewModel
{
	private class PeerMarkerDistanceComparer : IComparer<MissionDuelPeerMarkerVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(MissionDuelPeerMarkerVM x, MissionDuelPeerMarkerVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PeerMarkerDistanceComparer()
		{
			throw null;
		}
	}

	private const string ZoneLandmarkTag = "duel_zone_landmark";

	private const float FocusScreenDistanceThreshold = 350f;

	private const float LandmarkFocusDistanceThrehsold = 500f;

	private bool _hasEnteredLobby;

	private Camera _missionCamera;

	private MissionDuelPeerMarkerVM _previousFocusTarget;

	private MissionDuelPeerMarkerVM _currentFocusTarget;

	private MissionDuelLandmarkMarkerVM _previousLandmarkTarget;

	private MissionDuelLandmarkMarkerVM _currentLandmarkTarget;

	private PeerMarkerDistanceComparer _distanceComparer;

	private readonly Dictionary<MissionPeer, MissionDuelPeerMarkerVM> _targetPeersToMarkersDictionary;

	private readonly MissionMultiplayerGameModeDuelClient _client;

	private Vec2 _screenCenter;

	private Dictionary<MissionPeer, bool> _targetPeersInDuelDictionary;

	private int _playerPreferredArenaType;

	private bool _isPlayerFocused;

	private bool _isEnabled;

	private MBBindingList<MissionDuelPeerMarkerVM> _targets;

	private MBBindingList<MissionDuelLandmarkMarkerVM> _landmarks;

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
	public MBBindingList<MissionDuelPeerMarkerVM> Targets
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
	public MBBindingList<MissionDuelLandmarkMarkerVM> Landmarks
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
	public MissionDuelMarkersVM(Camera missionCamera, MissionMultiplayerGameModeDuelClient client)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateScreenCenter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnManagedOptionsChanged(ManagedOptionsType changedManagedOptionsType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTargets(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshPeerEquipments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRefreshPeerMarkers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTargetsEnabled(bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDuelRequestSent(MissionPeer targetPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnDuelRequested(MissionPeer targetPeer, TroopType troopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentSpawnedWithoutDuel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentBuiltForTheFirstTime()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDuelStarted(MissionPeer firstPeer, MissionPeer secondPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMarkerOfPeerEnabled(MissionPeer peer, bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerPreferredZoneChanged(int playerPrefferedArenaType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFocusGained()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFocusLost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPeerEquipmentRefreshed(MissionPeer peer)
	{
		throw null;
	}
}
