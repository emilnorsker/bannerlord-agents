using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NetworkMessages.FromServer;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.MissionRepresentatives;

public class DuelMissionRepresentative : MissionRepresentativeBase
{
	public const int DuelPrepTime = 3;

	public Action<MissionPeer, TroopType> OnDuelRequestedEvent;

	public Action<MissionPeer> OnDuelRequestSentEvent;

	public Action<MissionPeer, int> OnDuelPrepStartedEvent;

	public Action OnAgentSpawnedWithoutDuelEvent;

	public Action<MissionPeer, MissionPeer, int> OnDuelPreparationStartedForTheFirstTimeEvent;

	public Action<MissionPeer> OnDuelEndedEvent;

	public Action<MissionPeer> OnDuelRoundEndedEvent;

	public Action<TroopType> OnMyPreferredZoneChanged;

	private List<Tuple<MissionPeer, MissionTime>> _requesters;

	private MissionMultiplayerDuel _missionMultiplayerDuel;

	private IFocusable _focusedObject;

	public int Bounty
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

	public int Score
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

	public int NumberOfWins
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

	private bool _isInDuel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRemoveMessageHandlers(GameNetwork.NetworkMessageHandlerRegisterer.RegisterMode mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnInteraction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventDuelRequest(DuelRequest message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventDuelSessionStarted(DuelSessionStarted message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventDuelStarted(DuelPreparationStartedForTheFirstTime message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventDuelEnded(DuelEnded message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventDuelRoundEnded(DuelRoundEnded message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerPointUpdate(DuelPointsUpdateMessage message)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DuelRequested(Agent requesterAgent, TroopType selectedAreaTroopType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckHasRequestFromAndRemoveRequestIfNeeded(MissionPeer requestOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDuelPreparation(MissionPeer requesterPeer, MissionPeer requesteePeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnObjectFocused(IFocusable focusedObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnObjectFocusLost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentSpawned()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetBountyAndNumberOfWins()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnDuelWon(float gainedScore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DuelMissionRepresentative()
	{
		throw null;
	}
}
