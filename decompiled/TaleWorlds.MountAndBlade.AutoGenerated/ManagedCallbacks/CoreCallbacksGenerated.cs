using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TaleWorlds.Core;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManagedCallbacks;

internal static class CoreCallbacksGenerated
{
	internal delegate float Agent_DebugGetHealth_delegate(int thisPointer);

	internal delegate int Agent_GetFormationUnitSpacing_delegate(int thisPointer);

	internal delegate float Agent_GetMissileRangeWithHeightDifferenceAux_delegate(int thisPointer, float targetZ);

	internal delegate UIntPtr Agent_GetSoundAndCollisionInfoClassName_delegate(int thisPointer);

	internal delegate float Agent_GetWeaponInaccuracy_delegate(int thisPointer, EquipmentIndex weaponSlotIndex, int weaponUsageIndex);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool Agent_IsInSameFormationWith_delegate(int thisPointer, int otherAgent);

	internal delegate void Agent_OnAgentAlarmedStateChanged_delegate(int thisPointer, Agent.AIStateFlag flag);

	internal delegate void Agent_OnAIInputSet_delegate(int thisPointer, ref Agent.EventControlFlag eventFlag, ref Agent.MovementControlFlag movementFlag, ref Vec2 inputVector);

	internal delegate void Agent_OnDismount_delegate(int thisPointer, int mount);

	internal delegate void Agent_OnMount_delegate(int thisPointer, int mount);

	internal delegate void Agent_OnRemoveWeapon_delegate(int thisPointer, EquipmentIndex slotIndex);

	internal delegate void Agent_OnRetreating_delegate(int thisPointer);

	internal delegate void Agent_OnShieldDamaged_delegate(int thisPointer, EquipmentIndex slotIndex, int inflictedDamage);

	internal delegate void Agent_OnWeaponAmmoConsume_delegate(int thisPointer, EquipmentIndex slotIndex, short totalAmmo);

	internal delegate void Agent_OnWeaponAmmoReload_delegate(int thisPointer, EquipmentIndex slotIndex, EquipmentIndex ammoSlotIndex, short totalAmmo);

	internal delegate void Agent_OnWeaponAmmoRemoved_delegate(int thisPointer, EquipmentIndex slotIndex);

	internal delegate void Agent_OnWeaponAmountChange_delegate(int thisPointer, EquipmentIndex slotIndex, short amount);

	internal delegate void Agent_OnWeaponReloadPhaseChange_delegate(int thisPointer, EquipmentIndex slotIndex, short reloadPhase);

	internal delegate void Agent_OnWeaponSwitchingToAlternativeStart_delegate(int thisPointer, EquipmentIndex slotIndex, int usageIndex);

	internal delegate void Agent_OnWeaponUsageIndexChange_delegate(int thisPointer, EquipmentIndex slotIndex, int usageIndex);

	internal delegate void Agent_OnWieldedItemIndexChange_delegate(int thisPointer, [MarshalAs(UnmanagedType.U1)] bool isOffHand, [MarshalAs(UnmanagedType.U1)] bool isWieldedInstantly, [MarshalAs(UnmanagedType.U1)] bool isWieldedOnSpawn);

	internal delegate void Agent_SetAgentAIPerformingRetreatBehavior_delegate(int thisPointer, [MarshalAs(UnmanagedType.U1)] bool isAgentAIPerformingRetreatBehavior);

	internal delegate void Agent_UpdateAgentStats_delegate(int thisPointer);

	internal delegate void Agent_UpdateMountAgentCache_delegate(int thisPointer, int newMountAgent);

	internal delegate void Agent_UpdateRiderAgentCache_delegate(int thisPointer, int newRiderAgent);

	internal delegate void BannerlordTableauManager_RegisterCharacterTableauScene_delegate(NativeObjectPointer scene, int type);

	internal delegate void BannerlordTableauManager_RequestCharacterTableauSetup_delegate(int characterCodeId, NativeObjectPointer scene, NativeObjectPointer poseEntity);

	internal delegate void CoreManaged_CheckSharedStructureSizes_delegate();

	internal delegate void CoreManaged_EngineApiMethodInterfaceInitializer_delegate(int id, IntPtr pointer);

	internal delegate void CoreManaged_FillEngineApiPointers_delegate();

	internal delegate void CoreManaged_Finalize_delegate();

	internal delegate void CoreManaged_OnLoadCommonFinished_delegate();

	internal delegate void CoreManaged_Start_delegate();

	internal delegate void GameNetwork_HandleConsoleCommand_delegate(IntPtr command);

	internal delegate void GameNetwork_HandleDisconnect_delegate();

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool GameNetwork_HandleNetworkPacketAsClient_delegate();

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool GameNetwork_HandleNetworkPacketAsServer_delegate(int networkPeer);

	internal delegate void GameNetwork_HandleRemovePlayer_delegate(int peer, [MarshalAs(UnmanagedType.U1)] bool isTimedOut);

	internal delegate void GameNetwork_SyncRelevantGameOptionsToServer_delegate();

	internal delegate int ManagedOptions_GetConfigCount_delegate();

	internal delegate float ManagedOptions_GetConfigValue_delegate(int type);

	internal delegate void MBEditor_CloseEditorScene_delegate();

	internal delegate void MBEditor_DestroyEditor_delegate(NativeObjectPointer scene);

	internal delegate void MBEditor_SetEditorScene_delegate(NativeObjectPointer scene);

	internal delegate int MBMultiplayerData_GetCurrentPlayerCount_delegate();

	internal delegate UIntPtr MBMultiplayerData_GetGameModule_delegate();

	internal delegate UIntPtr MBMultiplayerData_GetGameType_delegate();

	internal delegate UIntPtr MBMultiplayerData_GetMap_delegate();

	internal delegate int MBMultiplayerData_GetPlayerCountLimit_delegate();

	internal delegate UIntPtr MBMultiplayerData_GetServerId_delegate();

	internal delegate UIntPtr MBMultiplayerData_GetServerName_delegate();

	internal delegate void MBMultiplayerData_UpdateGameServerInfo_delegate(IntPtr id, IntPtr gameServer, IntPtr gameModule, IntPtr gameType, IntPtr map, int currentPlayerCount, int maxPlayerCount, IntPtr address, int port);

	internal delegate void Mission_ApplySkeletonScaleToAllEquippedItems_delegate(int thisPointer, IntPtr itemName);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool Mission_CanPhysicsCollideBetweenTwoEntities_delegate(int thisPointer, UIntPtr entity0Ptr, UIntPtr entity1Ptr);

	internal delegate void Mission_ChargeDamageCallback_delegate(int thisPointer, ref AttackCollisionData collisionData, Blow blow, int attacker, int victim);

	internal delegate void Mission_DebugLogNativeMissionNetworkEvent_delegate(int eventEnum, IntPtr eventName, int bitCount);

	internal delegate void Mission_EndMission_delegate(int thisPointer);

	internal delegate void Mission_FallDamageCallback_delegate(int thisPointer, ref AttackCollisionData collisionData, Blow b, int attacker, int victim);

	internal delegate AgentState Mission_GetAgentState_delegate(int thisPointer, int affectorAgent, int agent, DamageTypes damageType, WeaponFlags weaponFlags);

	internal delegate WorldPosition Mission_GetClosestFleePositionForAgent_delegate(int thisPointer, int agent);

	internal delegate void Mission_GetDefendCollisionResults_delegate(int thisPointer, int attackerAgent, int defenderAgent, CombatCollisionResult collisionResult, int attackerWeaponSlotIndex, [MarshalAs(UnmanagedType.U1)] bool isAlternativeAttack, StrikeType strikeType, Agent.UsageDirection attackDirection, float collisionDistanceOnWeapon, float attackProgress, [MarshalAs(UnmanagedType.U1)] bool attackIsParried, [MarshalAs(UnmanagedType.U1)] bool isPassiveUsageHit, [MarshalAs(UnmanagedType.U1)] bool isHeavyAttack, ref float defenderStunPeriod, ref float attackerStunPeriod, [MarshalAs(UnmanagedType.U1)] ref bool crushedThrough);

	internal delegate void Mission_MeleeHitCallback_delegate(int thisPointer, ref AttackCollisionData collisionData, int attacker, int victim, NativeObjectPointer realHitEntity, ref float inOutMomentumRemaining, ref MeleeCollisionReaction colReaction, CrushThroughState crushThroughState, Vec3 blowDir, Vec3 swingDir, ref HitParticleResultData hitParticleResultData, [MarshalAs(UnmanagedType.U1)] bool crushedThroughWithoutAgentCollision);

	internal delegate void Mission_MissileAreaDamageCallback_delegate(int thisPointer, ref AttackCollisionData collisionDataInput, ref Blow blowInput, int alreadyDamagedAgent, int shooterAgent, [MarshalAs(UnmanagedType.U1)] bool isBigExplosion);

	internal delegate void Mission_MissileCalculatePassbySoundParametersCallbackMT_delegate(int thisPointer, int missileIndex, ref SoundEventParameter soundEventParameter);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool Mission_MissileHitCallback_delegate(int thisPointer, out int extraHitParticleIndex, ref AttackCollisionData collisionData, Vec3 missileStartingPosition, Vec3 missilePosition, Vec3 missileAngularVelocity, Vec3 movementVelocity, MatrixFrame attachGlobalFrame, MatrixFrame affectedShieldGlobalFrame, int numDamagedAgents, int attacker, int victim, NativeObjectPointer hitEntity);

	internal delegate void Mission_OnAgentAddedAsCorpse_delegate(int thisPointer, int affectedAgent, int corpsesToFadeIndex);

	internal delegate void Mission_OnAgentDeleted_delegate(int thisPointer, int affectedAgent);

	internal delegate float Mission_OnAgentHitBlocked_delegate(int thisPointer, int affectedAgent, int affectorAgent, ref AttackCollisionData collisionData, Vec3 blowDirection, Vec3 swingDirection, [MarshalAs(UnmanagedType.U1)] bool isMissile);

	internal delegate void Mission_OnAgentRemoved_delegate(int thisPointer, int affectedAgent, int affectorAgent, AgentState agentState, KillingBlow killingBlow);

	internal delegate void Mission_OnAgentShootMissile_delegate(int thisPointer, int shooterAgent, EquipmentIndex weaponIndex, Vec3 position, Vec3 velocity, Mat3 orientation, [MarshalAs(UnmanagedType.U1)] bool hasRigidBody, [MarshalAs(UnmanagedType.U1)] bool isPrimaryWeaponShot, int forcedMissileIndex);

	internal delegate void Mission_OnFixedTick_delegate(int thisPointer, float fixedDt);

	internal delegate void Mission_OnMissileRemoved_delegate(int thisPointer, int missileIndex);

	internal delegate void Mission_OnPreTick_delegate(int thisPointer, float dt);

	internal delegate void Mission_OnSceneCreated_delegate(int thisPointer, NativeObjectPointer scene);

	internal delegate void Mission_PauseMission_delegate(int thisPointer);

	internal delegate void Mission_ResetMission_delegate(int thisPointer);

	internal delegate void Mission_SpawnWeaponAsDropFromAgent_delegate(int thisPointer, int agent, EquipmentIndex equipmentIndex, ref Vec3 globalVelocity, ref Vec3 globalAngularVelocity, Mission.WeaponSpawnFlags spawnFlags);

	internal delegate void Mission_TickAgentsAndTeams_delegate(int thisPointer, float dt, [MarshalAs(UnmanagedType.U1)] bool tickPaused);

	internal delegate void Mission_UpdateMissionTimeCache_delegate(int thisPointer, float curTime);

	internal delegate UIntPtr Module_CreateProcessedActionSetsXMLForNative_delegate();

	internal delegate UIntPtr Module_CreateProcessedActionTypesXMLForNative_delegate();

	internal delegate UIntPtr Module_CreateProcessedAnimationsXMLForNative_delegate(out string animationsXmlPaths);

	internal delegate UIntPtr Module_CreateProcessedModuleDataXMLForNative_delegate(IntPtr xmlType);

	internal delegate UIntPtr Module_CreateProcessedSkinsXMLForNative_delegate(out string baseSkinsXmlPath);

	internal delegate UIntPtr Module_CreateProcessedSoundEventDataXMLForNative_delegate();

	internal delegate UIntPtr Module_CreateProcessedSoundParamsXMLForNative_delegate();

	internal delegate UIntPtr Module_CreateProcessedVoiceDefinitionsXMLForNative_delegate();

	internal delegate UIntPtr Module_GetGameStatus_delegate();

	internal delegate UIntPtr Module_GetHorseMaterialNames_delegate(int thisPointer);

	internal delegate int Module_GetInstance_delegate();

	internal delegate UIntPtr Module_GetItemMeshNames_delegate(int thisPointer);

	internal delegate UIntPtr Module_GetMetaMeshPackageMapping_delegate(int thisPointer);

	internal delegate UIntPtr Module_GetMissionControllerClassNames_delegate(int thisPointer);

	internal delegate void Module_Initialize_delegate(int thisPointer);

	internal delegate void Module_LoadSingleModule_delegate(int thisPointer, IntPtr modulePath);

	internal delegate void Module_MBThrowException_delegate();

	internal delegate void Module_OnCloseSceneEditorPresentation_delegate(int thisPointer);

	internal delegate void Module_OnDumpCreated_delegate(int thisPointer);

	internal delegate void Module_OnDumpCreationStarted_delegate(int thisPointer);

	internal delegate void Module_OnEnterEditMode_delegate(int thisPointer, [MarshalAs(UnmanagedType.U1)] bool isFirstTime);

	internal delegate void Module_OnImguiProfilerTick_delegate(int thisPointer);

	internal delegate void Module_OnSceneEditorModeOver_delegate(int thisPointer);

	internal delegate void Module_OnSkinsXMLHasChanged_delegate(int thisPointer);

	internal delegate void Module_RunTest_delegate(int thisPointer, IntPtr commandLine);

	[return: MarshalAs(UnmanagedType.U1)]
	internal delegate bool Module_SetEditorScreenAsRootScreen_delegate(int thisPointer);

	internal delegate void Module_SetLoadingFinished_delegate(int thisPointer);

	internal delegate void Module_StartMissionForEditor_delegate(int thisPointer, IntPtr missionName, IntPtr sceneName, IntPtr levels);

	internal delegate void Module_StartMissionForReplayEditor_delegate(int thisPointer, IntPtr missionName, IntPtr sceneName, IntPtr levels, IntPtr fileName, [MarshalAs(UnmanagedType.U1)] bool record, float startTime, float endTime);

	internal delegate void Module_TickTest_delegate(int thisPointer, float dt);

	internal delegate Vec3 WeaponComponentMissionExtensions_CalculateCenterOfMass_delegate(NativeObjectPointer body);

	internal static Delegate[] Delegates
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
	public static void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_DebugGetHealth_delegate))]
	internal static float Agent_DebugGetHealth(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_GetFormationUnitSpacing_delegate))]
	internal static int Agent_GetFormationUnitSpacing(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_GetMissileRangeWithHeightDifferenceAux_delegate))]
	internal static float Agent_GetMissileRangeWithHeightDifferenceAux(int thisPointer, float targetZ)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_GetSoundAndCollisionInfoClassName_delegate))]
	internal static UIntPtr Agent_GetSoundAndCollisionInfoClassName(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_GetWeaponInaccuracy_delegate))]
	internal static float Agent_GetWeaponInaccuracy(int thisPointer, EquipmentIndex weaponSlotIndex, int weaponUsageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_IsInSameFormationWith_delegate))]
	internal static bool Agent_IsInSameFormationWith(int thisPointer, int otherAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnAgentAlarmedStateChanged_delegate))]
	internal static void Agent_OnAgentAlarmedStateChanged(int thisPointer, Agent.AIStateFlag flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnAIInputSet_delegate))]
	internal static void Agent_OnAIInputSet(int thisPointer, ref Agent.EventControlFlag eventFlag, ref Agent.MovementControlFlag movementFlag, ref Vec2 inputVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnDismount_delegate))]
	internal static void Agent_OnDismount(int thisPointer, int mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnMount_delegate))]
	internal static void Agent_OnMount(int thisPointer, int mount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnRemoveWeapon_delegate))]
	internal static void Agent_OnRemoveWeapon(int thisPointer, EquipmentIndex slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnRetreating_delegate))]
	internal static void Agent_OnRetreating(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnShieldDamaged_delegate))]
	internal static void Agent_OnShieldDamaged(int thisPointer, EquipmentIndex slotIndex, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnWeaponAmmoConsume_delegate))]
	internal static void Agent_OnWeaponAmmoConsume(int thisPointer, EquipmentIndex slotIndex, short totalAmmo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnWeaponAmmoReload_delegate))]
	internal static void Agent_OnWeaponAmmoReload(int thisPointer, EquipmentIndex slotIndex, EquipmentIndex ammoSlotIndex, short totalAmmo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnWeaponAmmoRemoved_delegate))]
	internal static void Agent_OnWeaponAmmoRemoved(int thisPointer, EquipmentIndex slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnWeaponAmountChange_delegate))]
	internal static void Agent_OnWeaponAmountChange(int thisPointer, EquipmentIndex slotIndex, short amount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnWeaponReloadPhaseChange_delegate))]
	internal static void Agent_OnWeaponReloadPhaseChange(int thisPointer, EquipmentIndex slotIndex, short reloadPhase)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnWeaponSwitchingToAlternativeStart_delegate))]
	internal static void Agent_OnWeaponSwitchingToAlternativeStart(int thisPointer, EquipmentIndex slotIndex, int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnWeaponUsageIndexChange_delegate))]
	internal static void Agent_OnWeaponUsageIndexChange(int thisPointer, EquipmentIndex slotIndex, int usageIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_OnWieldedItemIndexChange_delegate))]
	internal static void Agent_OnWieldedItemIndexChange(int thisPointer, bool isOffHand, bool isWieldedInstantly, bool isWieldedOnSpawn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_SetAgentAIPerformingRetreatBehavior_delegate))]
	internal static void Agent_SetAgentAIPerformingRetreatBehavior(int thisPointer, bool isAgentAIPerformingRetreatBehavior)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_UpdateAgentStats_delegate))]
	internal static void Agent_UpdateAgentStats(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_UpdateMountAgentCache_delegate))]
	internal static void Agent_UpdateMountAgentCache(int thisPointer, int newMountAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Agent_UpdateRiderAgentCache_delegate))]
	internal static void Agent_UpdateRiderAgentCache(int thisPointer, int newRiderAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(BannerlordTableauManager_RegisterCharacterTableauScene_delegate))]
	internal static void BannerlordTableauManager_RegisterCharacterTableauScene(NativeObjectPointer scene, int type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(BannerlordTableauManager_RequestCharacterTableauSetup_delegate))]
	internal static void BannerlordTableauManager_RequestCharacterTableauSetup(int characterCodeId, NativeObjectPointer scene, NativeObjectPointer poseEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(CoreManaged_CheckSharedStructureSizes_delegate))]
	internal static void CoreManaged_CheckSharedStructureSizes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(CoreManaged_EngineApiMethodInterfaceInitializer_delegate))]
	internal static void CoreManaged_EngineApiMethodInterfaceInitializer(int id, IntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(CoreManaged_FillEngineApiPointers_delegate))]
	internal static void CoreManaged_FillEngineApiPointers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(CoreManaged_Finalize_delegate))]
	internal static void CoreManaged_Finalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(CoreManaged_OnLoadCommonFinished_delegate))]
	internal static void CoreManaged_OnLoadCommonFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(CoreManaged_Start_delegate))]
	internal static void CoreManaged_Start()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(GameNetwork_HandleConsoleCommand_delegate))]
	internal static void GameNetwork_HandleConsoleCommand(IntPtr command)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(GameNetwork_HandleDisconnect_delegate))]
	internal static void GameNetwork_HandleDisconnect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(GameNetwork_HandleNetworkPacketAsClient_delegate))]
	internal static bool GameNetwork_HandleNetworkPacketAsClient()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(GameNetwork_HandleNetworkPacketAsServer_delegate))]
	internal static bool GameNetwork_HandleNetworkPacketAsServer(int networkPeer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(GameNetwork_HandleRemovePlayer_delegate))]
	internal static void GameNetwork_HandleRemovePlayer(int peer, bool isTimedOut)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(GameNetwork_SyncRelevantGameOptionsToServer_delegate))]
	internal static void GameNetwork_SyncRelevantGameOptionsToServer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedOptions_GetConfigCount_delegate))]
	internal static int ManagedOptions_GetConfigCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(ManagedOptions_GetConfigValue_delegate))]
	internal static float ManagedOptions_GetConfigValue(int type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBEditor_CloseEditorScene_delegate))]
	internal static void MBEditor_CloseEditorScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBEditor_DestroyEditor_delegate))]
	internal static void MBEditor_DestroyEditor(NativeObjectPointer scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBEditor_SetEditorScene_delegate))]
	internal static void MBEditor_SetEditorScene(NativeObjectPointer scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBMultiplayerData_GetCurrentPlayerCount_delegate))]
	internal static int MBMultiplayerData_GetCurrentPlayerCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBMultiplayerData_GetGameModule_delegate))]
	internal static UIntPtr MBMultiplayerData_GetGameModule()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBMultiplayerData_GetGameType_delegate))]
	internal static UIntPtr MBMultiplayerData_GetGameType()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBMultiplayerData_GetMap_delegate))]
	internal static UIntPtr MBMultiplayerData_GetMap()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBMultiplayerData_GetPlayerCountLimit_delegate))]
	internal static int MBMultiplayerData_GetPlayerCountLimit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBMultiplayerData_GetServerId_delegate))]
	internal static UIntPtr MBMultiplayerData_GetServerId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBMultiplayerData_GetServerName_delegate))]
	internal static UIntPtr MBMultiplayerData_GetServerName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(MBMultiplayerData_UpdateGameServerInfo_delegate))]
	internal static void MBMultiplayerData_UpdateGameServerInfo(IntPtr id, IntPtr gameServer, IntPtr gameModule, IntPtr gameType, IntPtr map, int currentPlayerCount, int maxPlayerCount, IntPtr address, int port)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_ApplySkeletonScaleToAllEquippedItems_delegate))]
	internal static void Mission_ApplySkeletonScaleToAllEquippedItems(int thisPointer, IntPtr itemName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_CanPhysicsCollideBetweenTwoEntities_delegate))]
	internal static bool Mission_CanPhysicsCollideBetweenTwoEntities(int thisPointer, UIntPtr entity0Ptr, UIntPtr entity1Ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_ChargeDamageCallback_delegate))]
	internal static void Mission_ChargeDamageCallback(int thisPointer, ref AttackCollisionData collisionData, Blow blow, int attacker, int victim)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_DebugLogNativeMissionNetworkEvent_delegate))]
	internal static void Mission_DebugLogNativeMissionNetworkEvent(int eventEnum, IntPtr eventName, int bitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_EndMission_delegate))]
	internal static void Mission_EndMission(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_FallDamageCallback_delegate))]
	internal static void Mission_FallDamageCallback(int thisPointer, ref AttackCollisionData collisionData, Blow b, int attacker, int victim)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_GetAgentState_delegate))]
	internal static AgentState Mission_GetAgentState(int thisPointer, int affectorAgent, int agent, DamageTypes damageType, WeaponFlags weaponFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_GetClosestFleePositionForAgent_delegate))]
	internal static WorldPosition Mission_GetClosestFleePositionForAgent(int thisPointer, int agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_GetDefendCollisionResults_delegate))]
	internal static void Mission_GetDefendCollisionResults(int thisPointer, int attackerAgent, int defenderAgent, CombatCollisionResult collisionResult, int attackerWeaponSlotIndex, bool isAlternativeAttack, StrikeType strikeType, Agent.UsageDirection attackDirection, float collisionDistanceOnWeapon, float attackProgress, bool attackIsParried, bool isPassiveUsageHit, bool isHeavyAttack, ref float defenderStunPeriod, ref float attackerStunPeriod, ref bool crushedThrough)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_MeleeHitCallback_delegate))]
	internal static void Mission_MeleeHitCallback(int thisPointer, ref AttackCollisionData collisionData, int attacker, int victim, NativeObjectPointer realHitEntity, ref float inOutMomentumRemaining, ref MeleeCollisionReaction colReaction, CrushThroughState crushThroughState, Vec3 blowDir, Vec3 swingDir, ref HitParticleResultData hitParticleResultData, bool crushedThroughWithoutAgentCollision)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_MissileAreaDamageCallback_delegate))]
	internal static void Mission_MissileAreaDamageCallback(int thisPointer, ref AttackCollisionData collisionDataInput, ref Blow blowInput, int alreadyDamagedAgent, int shooterAgent, bool isBigExplosion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_MissileCalculatePassbySoundParametersCallbackMT_delegate))]
	internal static void Mission_MissileCalculatePassbySoundParametersCallbackMT(int thisPointer, int missileIndex, ref SoundEventParameter soundEventParameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_MissileHitCallback_delegate))]
	internal static bool Mission_MissileHitCallback(int thisPointer, out int extraHitParticleIndex, ref AttackCollisionData collisionData, Vec3 missileStartingPosition, Vec3 missilePosition, Vec3 missileAngularVelocity, Vec3 movementVelocity, MatrixFrame attachGlobalFrame, MatrixFrame affectedShieldGlobalFrame, int numDamagedAgents, int attacker, int victim, NativeObjectPointer hitEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_OnAgentAddedAsCorpse_delegate))]
	internal static void Mission_OnAgentAddedAsCorpse(int thisPointer, int affectedAgent, int corpsesToFadeIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_OnAgentDeleted_delegate))]
	internal static void Mission_OnAgentDeleted(int thisPointer, int affectedAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_OnAgentHitBlocked_delegate))]
	internal static float Mission_OnAgentHitBlocked(int thisPointer, int affectedAgent, int affectorAgent, ref AttackCollisionData collisionData, Vec3 blowDirection, Vec3 swingDirection, bool isMissile)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_OnAgentRemoved_delegate))]
	internal static void Mission_OnAgentRemoved(int thisPointer, int affectedAgent, int affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_OnAgentShootMissile_delegate))]
	internal static void Mission_OnAgentShootMissile(int thisPointer, int shooterAgent, EquipmentIndex weaponIndex, Vec3 position, Vec3 velocity, Mat3 orientation, bool hasRigidBody, bool isPrimaryWeaponShot, int forcedMissileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_OnFixedTick_delegate))]
	internal static void Mission_OnFixedTick(int thisPointer, float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_OnMissileRemoved_delegate))]
	internal static void Mission_OnMissileRemoved(int thisPointer, int missileIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_OnPreTick_delegate))]
	internal static void Mission_OnPreTick(int thisPointer, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_OnSceneCreated_delegate))]
	internal static void Mission_OnSceneCreated(int thisPointer, NativeObjectPointer scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_PauseMission_delegate))]
	internal static void Mission_PauseMission(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_ResetMission_delegate))]
	internal static void Mission_ResetMission(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_SpawnWeaponAsDropFromAgent_delegate))]
	internal static void Mission_SpawnWeaponAsDropFromAgent(int thisPointer, int agent, EquipmentIndex equipmentIndex, ref Vec3 globalVelocity, ref Vec3 globalAngularVelocity, Mission.WeaponSpawnFlags spawnFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_TickAgentsAndTeams_delegate))]
	internal static void Mission_TickAgentsAndTeams(int thisPointer, float dt, bool tickPaused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Mission_UpdateMissionTimeCache_delegate))]
	internal static void Mission_UpdateMissionTimeCache(int thisPointer, float curTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_CreateProcessedActionSetsXMLForNative_delegate))]
	internal static UIntPtr Module_CreateProcessedActionSetsXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_CreateProcessedActionTypesXMLForNative_delegate))]
	internal static UIntPtr Module_CreateProcessedActionTypesXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_CreateProcessedAnimationsXMLForNative_delegate))]
	internal static UIntPtr Module_CreateProcessedAnimationsXMLForNative(out string animationsXmlPaths)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_CreateProcessedModuleDataXMLForNative_delegate))]
	internal static UIntPtr Module_CreateProcessedModuleDataXMLForNative(IntPtr xmlType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_CreateProcessedSkinsXMLForNative_delegate))]
	internal static UIntPtr Module_CreateProcessedSkinsXMLForNative(out string baseSkinsXmlPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_CreateProcessedSoundEventDataXMLForNative_delegate))]
	internal static UIntPtr Module_CreateProcessedSoundEventDataXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_CreateProcessedSoundParamsXMLForNative_delegate))]
	internal static UIntPtr Module_CreateProcessedSoundParamsXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_CreateProcessedVoiceDefinitionsXMLForNative_delegate))]
	internal static UIntPtr Module_CreateProcessedVoiceDefinitionsXMLForNative()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_GetGameStatus_delegate))]
	internal static UIntPtr Module_GetGameStatus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_GetHorseMaterialNames_delegate))]
	internal static UIntPtr Module_GetHorseMaterialNames(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_GetInstance_delegate))]
	internal static int Module_GetInstance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_GetItemMeshNames_delegate))]
	internal static UIntPtr Module_GetItemMeshNames(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_GetMetaMeshPackageMapping_delegate))]
	internal static UIntPtr Module_GetMetaMeshPackageMapping(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_GetMissionControllerClassNames_delegate))]
	internal static UIntPtr Module_GetMissionControllerClassNames(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_Initialize_delegate))]
	internal static void Module_Initialize(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_LoadSingleModule_delegate))]
	internal static void Module_LoadSingleModule(int thisPointer, IntPtr modulePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_MBThrowException_delegate))]
	internal static void Module_MBThrowException()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_OnCloseSceneEditorPresentation_delegate))]
	internal static void Module_OnCloseSceneEditorPresentation(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_OnDumpCreated_delegate))]
	internal static void Module_OnDumpCreated(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_OnDumpCreationStarted_delegate))]
	internal static void Module_OnDumpCreationStarted(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_OnEnterEditMode_delegate))]
	internal static void Module_OnEnterEditMode(int thisPointer, bool isFirstTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_OnImguiProfilerTick_delegate))]
	internal static void Module_OnImguiProfilerTick(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_OnSceneEditorModeOver_delegate))]
	internal static void Module_OnSceneEditorModeOver(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_OnSkinsXMLHasChanged_delegate))]
	internal static void Module_OnSkinsXMLHasChanged(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_RunTest_delegate))]
	internal static void Module_RunTest(int thisPointer, IntPtr commandLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_SetEditorScreenAsRootScreen_delegate))]
	internal static bool Module_SetEditorScreenAsRootScreen(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_SetLoadingFinished_delegate))]
	internal static void Module_SetLoadingFinished(int thisPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_StartMissionForEditor_delegate))]
	internal static void Module_StartMissionForEditor(int thisPointer, IntPtr missionName, IntPtr sceneName, IntPtr levels)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_StartMissionForReplayEditor_delegate))]
	internal static void Module_StartMissionForReplayEditor(int thisPointer, IntPtr missionName, IntPtr sceneName, IntPtr levels, IntPtr fileName, bool record, float startTime, float endTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(Module_TickTest_delegate))]
	internal static void Module_TickTest(int thisPointer, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[MonoPInvokeCallback(typeof(WeaponComponentMissionExtensions_CalculateCenterOfMass_delegate))]
	internal static Vec3 WeaponComponentMissionExtensions_CalculateCenterOfMass(NativeObjectPointer body)
	{
		throw null;
	}
}
