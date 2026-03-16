using System;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.Network.Messages;

namespace TaleWorlds.MountAndBlade;

public sealed class MissionNetworkComponent : MissionNetwork
{
	private float _accumulatedTimeSinceLastTimerSync;

	private const float TimerSyncPeriod = 2f;

	private ChatBox _chatBox;

	public event Action OnMyClientSynchronized
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<NetworkCommunicator> OnClientSynchronizedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void AddRemoveMessageHandlers(GameNetwork.NetworkMessageHandlerRegistererContainer registerer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Team GetTeamOfPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private OrderController GetOrderControllerOfPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSyncMissionTimer(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetPeerTeam(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventCreateFreeMountAgentEvent(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventCreateAgent(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSynchronizeAgentEquipment(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventCreateAgentVisuals(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventRemoveAgentVisualsForPeer(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventRemoveAgentVisualsFromIndexForPeer(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventReplaceBotWithPlayer(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetWieldedItemIndex(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetWeaponNetworkData(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetWeaponAmmoData(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetWeaponReloadPhase(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventWeaponUsageIndexChangeMessage(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventStartSwitchingWeaponUsageIndex(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventInitializeFormation(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetSpawnedFormationCount(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAddTeam(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventTeamSetIsEnemyOf(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAssignFormationToPlayer(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventExistingObjectsBegin(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventExistingObjectsEnd(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventClearMission(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventCreateMissionObject(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventRemoveMissionObject(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventStopPhysicsAndSetFrameOfMissionObject(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventBurstMissionObjectParticles(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectVisibility(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectDisabled(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectColors(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectFrame(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectGlobalFrame(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectFrameOverTime(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectGlobalFrameOverTime(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectAnimationAtChannel(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetRangedSiegeWeaponAmmo(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventRangedSiegeWeaponChangeProjectile(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetStonePileAmmo(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetRangedSiegeWeaponState(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetSiegeLadderState(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetSiegeTowerGateState(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetSiegeTowerHasArrivedAtTarget(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetBatteringRamHasArrivedAtTarget(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetSiegeMachineMovementDistance(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectAnimationChannelParameter(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectVertexAnimation(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectVertexAnimationProgress(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectAnimationPaused(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAddMissionObjectBodyFlags(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventRemoveMissionObjectBodyFlags(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMachineTargetRotation(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetUsableGameObjectIsDeactivated(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetUsableGameObjectIsDisabledForPlayers(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetMissionObjectImpulse(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetAgentTargetPositionAndDirection(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetAgentTargetPosition(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventClearAgentTargetFrame(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAgentTeleportToFrame(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetAgentPeer(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetAgentIsPlayer(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetAgentHealth(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAgentSetTeam(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetAgentActionSet(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventMakeAgentDead(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAddPrefabComponentToAgentBone(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetAgentPrefabComponentVisibility(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAgentSetFormation(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventUseObject(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventStopUsingObject(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventHitSynchronizeObjectHitpoints(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventHitSynchronizeObjectDestructionLevel(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventHitBurstAllHeavyHitParticles(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSynchronizeMissionObject(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSpawnWeaponWithNewEntity(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAttachWeaponToSpawnedWeapon(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAttachWeaponToAgent(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventHandleMissileCollisionReaction(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSpawnWeaponAsDropFromAgent(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSpawnAttachedWeaponOnSpawnedWeapon(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSpawnAttachedWeaponOnCorpse(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventRemoveEquippedWeapon(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventBarkAgent(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventEquipWeaponWithNewEntity(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAttachWeaponToWeaponInAgentEquipmentSlot(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventEquipWeaponFromSpawnedItemEntity(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventCreateMissile(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventAgentHit(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventConsumeWeaponAmount(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleServerEventSetAgentOwningMissionPeer(GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventSetFollowedAgent(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventSetMachineRotation(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventRequestUseObject(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventRequestStopUsingObject(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventApplyOrder(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventApplySiegeWeaponOrder(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventApplyOrderWithPosition(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventApplyOrderWithFormation(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventApplyOrderWithFormationAndPercentage(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventApplyOrderWithFormationAndNumber(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventApplyOrderWithTwoPositions(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventApplyOrderWithGameEntity(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventApplyOrderWithAgent(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventSelectAllFormations(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventSelectAllSiegeWeapons(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventClearSelectedFormations(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventSelectFormation(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventSelectSiegeWeapon(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventUnselectFormation(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventUnselectSiegeWeapon(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventDropWeapon(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventCheerSelected(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventBarkSelected(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventBreakAgentVisualsInvulnerability(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HandleClientEventRequestToSpawnAsBot(NetworkCommunicator networkPeer, GameNetworkMessage baseMessage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendExistingObjectsToPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendTroopSelectionInformation(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendTeamsToPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendTeamRelationsToPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendFormationInformation(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendAgentVisualsToPeer(NetworkCommunicator networkPeer, Team peerTeam)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendAgentsToPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendSpawnedMissionObjectsToPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SynchronizeMissionObjectsToPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SendMissilesToPeer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPlayerDisconnectedFromServer(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleEarlyNewClientAfterLoadingFinished(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleLateNewClientAfterLoadingFinished(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandleEarlyPlayerDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HandlePlayerDisconnect(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAddTeam(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnClearScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPeerSelectedTeam(MissionPeer missionPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnClientSynchronized(NetworkCommunicator networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionNetworkComponent()
	{
		throw null;
	}
}
