using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIGameEntity : IGameEntity
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ActivateRagdollDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddAllMeshesOfGameEntityDelegate(UIntPtr entityId, UIntPtr copiedEntityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddCapsuleAsBodyDelegate(UIntPtr entityId, Vec3 p1, Vec3 p2, float radius, uint bodyFlags, byte[] physicsMaterialName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddChildDelegate(UIntPtr parententity, UIntPtr childentity, [MarshalAs(UnmanagedType.U1)] bool autoLocalizeFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddComponentDelegate(UIntPtr pointer, UIntPtr componentPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr AddDistanceJointDelegate(UIntPtr entityId, UIntPtr otherEntityId, float minDistance, float maxDistance);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr AddDistanceJointWithFramesDelegate(UIntPtr entityId, UIntPtr otherEntityId, MatrixFrame globalFrameOnA, MatrixFrame globalFrameOnB, float minDistance, float maxDistance);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddEditDataUserToAllMeshesDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool entity_components, [MarshalAs(UnmanagedType.U1)] bool skeleton_components);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool AddLightDelegate(UIntPtr entityId, UIntPtr lightPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMeshDelegate(UIntPtr entityId, UIntPtr mesh, [MarshalAs(UnmanagedType.U1)] bool recomputeBoundingBox);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMeshToBoneDelegate(UIntPtr entityId, UIntPtr multiMeshPointer, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMultiMeshDelegate(UIntPtr entityId, UIntPtr multiMeshPtr, [MarshalAs(UnmanagedType.U1)] bool updateVisMask);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMultiMeshToSkeletonDelegate(UIntPtr gameEntity, UIntPtr multiMesh);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMultiMeshToSkeletonBoneDelegate(UIntPtr gameEntity, UIntPtr multiMesh, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddParticleSystemComponentDelegate(UIntPtr entityId, byte[] particleid);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddPhysicsDelegate(UIntPtr entityId, UIntPtr body, float mass, ref Vec3 localCenterOfMass, ref Vec3 initialGlobalVelocity, ref Vec3 initialAngularGlobalVelocity, int physicsMaterial, [MarshalAs(UnmanagedType.U1)] bool isStatic, int collisionGroupID);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddSphereAsBodyDelegate(UIntPtr entityId, Vec3 center, float radius, uint bodyFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddSplashPositionToWaterVisualRecordDelegate(UIntPtr entityPointer, UIntPtr visualPrefab, in Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddTagDelegate(UIntPtr entityId, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ApplyAccelerationToDynamicBodyDelegate(UIntPtr entityId, ref Vec3 acceleration);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ApplyForceToDynamicBodyDelegate(UIntPtr entityId, ref Vec3 force, GameEntityPhysicsExtensions.ForceMode forceMode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ApplyGlobalForceAtLocalPosToDynamicBodyDelegate(UIntPtr entityId, ref Vec3 localPosition, ref Vec3 globalForce, GameEntityPhysicsExtensions.ForceMode forceMode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ApplyLocalForceAtLocalPosToDynamicBodyDelegate(UIntPtr entityId, ref Vec3 localPosition, ref Vec3 localForce, GameEntityPhysicsExtensions.ForceMode forceMode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ApplyLocalImpulseToDynamicBodyDelegate(UIntPtr entityId, ref Vec3 localPosition, ref Vec3 impulse);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ApplyTorqueToDynamicBodyDelegate(UIntPtr entityId, ref Vec3 torque, GameEntityPhysicsExtensions.ForceMode forceMode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AttachNavigationMeshFacesDelegate(UIntPtr entityId, int faceGroupId, [MarshalAs(UnmanagedType.U1)] bool isConnected, [MarshalAs(UnmanagedType.U1)] bool isBlocker, [MarshalAs(UnmanagedType.U1)] bool autoLocalize, [MarshalAs(UnmanagedType.U1)] bool finalizeBlockerConvexHullComputation, [MarshalAs(UnmanagedType.U1)] bool updateEntityFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BreakPrefabDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BurstEntityParticleDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool doChildren);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CallScriptCallbacksDelegate(UIntPtr entityPointer, [MarshalAs(UnmanagedType.U1)] bool registerScriptComponents);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ChangeMetaMeshOrRemoveItIfNotExistsDelegate(UIntPtr entityId, UIntPtr entityMetaMeshPointer, UIntPtr newMetaMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ChangeResolutionMultiplierOfWaterVisualDelegate(UIntPtr visualPrefab, float multiplier, in Vec3 waterEffectsBB);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckIsPrefabLinkRootPrefabDelegate(UIntPtr entityPtr, int depth);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckPointWithOrientedBoundingBoxDelegate(UIntPtr entityId, Vec3 point);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckResourcesDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool addToQueue, [MarshalAs(UnmanagedType.U1)] bool checkFaceResources);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearComponentsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearEntityComponentsDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool resetAll, [MarshalAs(UnmanagedType.U1)] bool removeScripts, [MarshalAs(UnmanagedType.U1)] bool deleteChildEntities);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearOnlyOwnComponentsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ComputeTrajectoryVolumeDelegate(UIntPtr gameEntity, float missileSpeed, float verticalAngleMaxInDegrees, float verticalAngleMinInDegrees, float horizontalAngleRangeInDegrees, float airFrictionConstant);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ComputeVelocityDeltaFromImpulseDelegate(UIntPtr entityPtr, in Vec3 impulsiveForce, in Vec3 impulsiveTorque, out Vec3 deltaLinearVelocity, out Vec3 deltaAngularVelocity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ConvertDynamicBodyToRayCastDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CookTrianglePhysxMeshDelegate(UIntPtr cookingInstancePointer, UIntPtr shapePointer, UIntPtr quadPinnedPointer, int physicsMaterial, int numberOfVertices, UIntPtr indicesPinnedPointer, int numberOfIndices);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CopyComponentsToSkeletonDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CopyFromPrefabDelegate(UIntPtr prefab);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CopyScriptComponentFromAnotherEntityDelegate(UIntPtr prefab, UIntPtr other_prefab, byte[] script_name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CreateAndAddScriptComponentDelegate(UIntPtr entityId, byte[] name, [MarshalAs(UnmanagedType.U1)] bool callScriptCallbacks);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateEmptyDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool isModifiableFromEditor, UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool createPhysics, [MarshalAs(UnmanagedType.U1)] bool callScriptCallbacks);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr CreateEmptyPhysxShapeDelegate(UIntPtr entityPointer, [MarshalAs(UnmanagedType.U1)] bool isVariable, int physxMaterialIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateEmptyWithoutSceneDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateFromPrefabDelegate(UIntPtr scenePointer, byte[] prefabid, [MarshalAs(UnmanagedType.U1)] bool callScriptCallbacks, [MarshalAs(UnmanagedType.U1)] bool createPhysics, uint scriptInclusionHashTag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateFromPrefabWithInitialFrameDelegate(UIntPtr scenePointer, byte[] prefabid, ref MatrixFrame frame, [MarshalAs(UnmanagedType.U1)] bool callScriptCallbacks);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr CreatePhysxCookingInstanceDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CreateVariableRatePhysicsDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool forChildren);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeleteEmptyShapeDelegate(UIntPtr entity, UIntPtr shape1, UIntPtr shape2);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeletePhysxCookingInstanceDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeRegisterWaterMeshMaterialsDelegate(UIntPtr entityPointer, UIntPtr visualPrefab);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeRegisterWaterSDFClipDelegate(UIntPtr entityId, int slot);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeselectEntityOnEditorDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DetachAllAttachedNavigationMeshFacesDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DisableContourDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DisableDynamicBodySimulationDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DisableGravityDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnableDynamicBodyDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer FindWithNameDelegate(UIntPtr scenePointer, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FreezeDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool isFrozen);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetAngularVelocityDelegate(UIntPtr entityPtr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAttachedNavmeshFaceCountDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetAttachedNavmeshFaceRecordsDelegate(UIntPtr entityId, IntPtr faceRecords);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetAttachedNavmeshFaceVertexIndicesDelegate(UIntPtr entityId, in PathFaceRecord faceRecord, IntPtr indices);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetBodyFlagsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetBodyShapeDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBodyVisualWorldTransformDelegate(UIntPtr entityPtr, out MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBodyWorldTransformDelegate(UIntPtr entityPtr, out MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate sbyte GetBoneCountDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneEntitialFrameWithIndexDelegate(UIntPtr entityId, sbyte boneIndex, ref MatrixFrame outEntitialFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneEntitialFrameWithNameDelegate(UIntPtr entityId, byte[] boneName, ref MatrixFrame outEntitialFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetBoundingBoxMaxDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetBoundingBoxMinDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetCameraParamsFromCameraScriptDelegate(UIntPtr entityId, UIntPtr camPtr, ref Vec3 dof_params);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetCenterOfMassDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetChildDelegate(UIntPtr entityId, int childIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetChildCountDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetChildPointerDelegate(UIntPtr entityId, int childIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetComponentAtIndexDelegate(UIntPtr entityId, GameEntity.ComponentType componentType, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetComponentCountDelegate(UIntPtr entityId, GameEntity.ComponentType componentType);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetEditModeLevelVisibilityDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate EntityFlags GetEntityFlagsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate EntityVisibilityFlags GetEntityVisibilityFlagsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetFactorColorDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetFirstChildWithTagRecursiveDelegate(UIntPtr entityPtr, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetFirstEntityWithTagDelegate(UIntPtr scenePointer, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetFirstEntityWithTagExpressionDelegate(UIntPtr scenePointer, byte[] tagExpression);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetFirstMeshDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate BoundingBox GetGlobalBoundingBoxDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetGlobalBoxMaxDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetGlobalBoxMinDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetGlobalFrameDelegate(UIntPtr meshPointer, out MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetGlobalFrameImpreciseForFixedTickDelegate(UIntPtr entityId, out MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetGlobalScaleDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 GetGlobalWindStrengthVectorOfSceneDelegate(UIntPtr entityPtr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 GetGlobalWindVelocityOfSceneDelegate(UIntPtr entityPtr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 GetGlobalWindVelocityWithGustNoiseOfSceneDelegate(UIntPtr entityPtr, float globalTime);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetGuidDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetLastFinalRenderCameraPositionOfSceneDelegate(UIntPtr entityPtr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetLightDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetLinearVelocityDelegate(UIntPtr entityPtr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate BoundingBox GetLocalBoundingBoxDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetLocalFrameDelegate(UIntPtr entityId, out MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetLocalPhysicsBoundingBoxDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool includeChildren, out BoundingBox outBoundingBox);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetLodLevelForDistanceSqDelegate(UIntPtr entityId, float distanceSquared);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetMassDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetMassSpaceInertiaDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetMassSpaceInverseInertiaDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetMeshBendedPositionDelegate(UIntPtr entityId, ref MatrixFrame worldSpacePosition, ref MatrixFrame output);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate GameEntity.Mobility GetMobilityDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNameDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetNativeScriptComponentVariableDelegate(UIntPtr entityPtr, byte[] className, byte[] fieldName, ref ScriptComponentFieldHolder data, RglScriptFieldType variableType);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetNextEntityWithTagDelegate(UIntPtr currententityId, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetNextEntityWithTagExpressionDelegate(UIntPtr currententityId, byte[] tagExpression);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetNextPrefabDelegate(UIntPtr currentPrefab);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetOldPrefabNameDelegate(UIntPtr prefab);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetParentDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetParentPointerDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetPhysicsDescBodyFlagsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetPhysicsMaterialIndexDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetPhysicsMinMaxDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool includeChildren, ref Vec3 bbmin, ref Vec3 bbmax, [MarshalAs(UnmanagedType.U1)] bool returnLocal);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetPhysicsStateDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetPhysicsTriangleCountDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetPrefabNameDelegate(UIntPtr prefab);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetPreviousGlobalFrameDelegate(UIntPtr entityPtr, out MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetQuickBoneEntitialFrameDelegate(UIntPtr entityId, sbyte index, out MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetRadiusDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetRootParentPointerDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetSceneDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetScenePointerDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetScriptComponentDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetScriptComponentAtIndexDelegate(UIntPtr entityId, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetScriptComponentCountDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetScriptComponentIndexDelegate(UIntPtr entityId, uint nameHash);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetSkeletonDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetTagsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetUpgradeLevelMaskDelegate(UIntPtr prefab);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetUpgradeLevelMaskCumulativeDelegate(UIntPtr prefab);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetVisibilityExcludeParentsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetVisibilityLevelMaskIncludingParentsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetWaterLevelAtPositionDelegate(UIntPtr entityId, in Vec2 position, [MarshalAs(UnmanagedType.U1)] bool useWaterRenderer, [MarshalAs(UnmanagedType.U1)] bool checkWaterBodyEntities);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasBatchedKinematicPhysicsFlagDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasBatchedRayCastPhysicsFlagDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasBodyDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasComplexAnimTreeDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasComponentDelegate(UIntPtr pointer, UIntPtr componentPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasDynamicRigidBodyDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasDynamicRigidBodyAndActiveSimulationDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasFrameChangedDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasKinematicRigidBodyDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasPhysicsBodyDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasPhysicsDefinitionDelegate(UIntPtr entityId, int excludeFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasSceneDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasScriptComponentDelegate(UIntPtr entityId, byte[] scName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasScriptComponentHashDelegate(UIntPtr entityId, uint scNameHash);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasStaticPhysicsBodyDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasTagDelegate(UIntPtr entityId, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsDynamicBodyStationaryDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsEngineBodySleepingDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsEntitySelectedOnEditorDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsFrozenDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsGhostObjectDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsGravityDisabledDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsGuidValidDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsInEditorSceneDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsVisibleIncludeParentsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PauseParticleSystemDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool doChildren);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PopCapsuleShapeFromEntityBodyDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool PrefabExistsDelegate(byte[] prefabName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PushCapsuleShapeToEntityBodyDelegate(UIntPtr entityId, Vec3 p1, Vec3 p2, float radius, byte[] physicsMaterialName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RayHitEntityDelegate(UIntPtr entityId, in Vec3 rayOrigin, in Vec3 rayDirection, float maxLength, ref float resultLength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RayHitEntityWithNormalDelegate(UIntPtr entityId, in Vec3 rayOrigin, in Vec3 rayDirection, float maxLength, ref Vec3 resultNormal, ref float resultLength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RecomputeBoundingBoxDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RefreshMeshesToRenderToHullWaterDelegate(UIntPtr entityPointer, UIntPtr visualPrefab, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int RegisterWaterSDFClipDelegate(UIntPtr entityId, UIntPtr textureID);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RelaxLocalBoundingBoxDelegate(UIntPtr entityId, in BoundingBox boundingBox);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseEditDataUserToAllMeshesDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool entity_components, [MarshalAs(UnmanagedType.U1)] bool skeleton_components);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveDelegate(UIntPtr entityId, int removeReason);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveAllChildrenDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveAllParticleSystemsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveChildDelegate(UIntPtr parentEntity, UIntPtr childEntity, [MarshalAs(UnmanagedType.U1)] bool keepPhysics, [MarshalAs(UnmanagedType.U1)] bool keepScenePointer, [MarshalAs(UnmanagedType.U1)] bool callScriptCallbacks, int removeReason);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RemoveComponentDelegate(UIntPtr pointer, UIntPtr componentPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RemoveComponentWithMeshDelegate(UIntPtr entityId, UIntPtr mesh);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveEnginePhysicsDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveFromPredisplayEntityDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveJointDelegate(UIntPtr jointId, UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RemoveMultiMeshDelegate(UIntPtr entityId, UIntPtr multiMeshPtr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveMultiMeshFromSkeletonDelegate(UIntPtr gameEntity, UIntPtr multiMesh);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveMultiMeshFromSkeletonBoneDelegate(UIntPtr gameEntity, UIntPtr multiMesh, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemovePhysicsDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool clearingTheScene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveScriptComponentDelegate(UIntPtr entityId, UIntPtr scriptComponentPtr, int removeReason);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveTagDelegate(UIntPtr entityId, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReplacePhysicsBodyWithQuadPhysicsBodyDelegate(UIntPtr pointer, UIntPtr quad, int physicsMaterial, BodyFlags bodyFlags, int numberOfVertices, UIntPtr indices, int numberOfIndices);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResetHullWaterDelegate(UIntPtr visualPrefab);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResumeParticleSystemDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool doChildren);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SelectEntityOnEditorDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAlphaDelegate(UIntPtr entityId, float alpha);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAngularVelocityDelegate(UIntPtr entityPtr, in Vec3 newAngularVelocity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAnimationSoundActivationDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool activate);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAnimTreeChannelParameterDelegate(UIntPtr entityId, float phase, int channel_no);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAsContourEntityDelegate(UIntPtr entityId, uint color);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAsPredisplayEntityDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAsReplayEntityDelegate(UIntPtr gameEntity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBodyFlagsDelegate(UIntPtr entityId, uint bodyFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBodyFlagsRecursiveDelegate(UIntPtr entityId, uint bodyFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBodyShapeDelegate(UIntPtr entityId, UIntPtr shape);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBoneFrameToAllMeshesDelegate(UIntPtr entityPtr, int boneIndex, in MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBoundingboxDirtyDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCenterOfMassDelegate(UIntPtr entityId, ref Vec3 localCenterOfMass);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetClothComponentKeepStateDelegate(UIntPtr entityId, UIntPtr metaMesh, [MarshalAs(UnmanagedType.U1)] bool keepState);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetClothComponentKeepStateOfAllMeshesDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool keepState);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetClothMaxDistanceMultiplierDelegate(UIntPtr gameEntity, float multiplier);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetColorToAllMeshesWithTagRecursiveDelegate(UIntPtr gameEntity, uint color, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetContourStateDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool alwaysVisible);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCostAdderForAttachedFacesDelegate(UIntPtr entityId, float cost);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCullModeDelegate(UIntPtr entityPtr, MBMeshCullingMode cullMode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCustomClipPlaneDelegate(UIntPtr entityId, Vec3 position, Vec3 normal, [MarshalAs(UnmanagedType.U1)] bool setForChildren);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCustomVertexPositionEnabledDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool customVertexPositionEnabled);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDampingDelegate(UIntPtr entityId, float linearDamping, float angularDamping);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDoNotCheckVisibilityDelegate(UIntPtr entityPtr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEnforcedMaximumLodLevelDelegate(UIntPtr entityId, int lodLevel);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEntityEnvMapVisibilityDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEntityFlagsDelegate(UIntPtr entityId, EntityFlags entityFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEntityVisibilityFlagsDelegate(UIntPtr entityId, EntityVisibilityFlags entityVisibilityFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetExternalReferencesUsageDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFactor2ColorDelegate(UIntPtr entityId, uint factor2Color);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFactorColorDelegate(UIntPtr entityId, uint factorColor);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetForceDecalsToRenderDelegate(UIntPtr entityPtr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetForceNotAffectedBySeasonDelegate(UIntPtr entityPtr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFrameChangedDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetGlobalFrameDelegate(UIntPtr entityId, in MatrixFrame frame, [MarshalAs(UnmanagedType.U1)] bool isTeleportation);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetGlobalPositionDelegate(UIntPtr entityId, in Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetHasCustomBoundingBoxValidationSystemDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool hasCustomBoundingBox);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLinearVelocityDelegate(UIntPtr entityPtr, Vec3 newLinearVelocity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLocalFrameDelegate(UIntPtr entityId, ref MatrixFrame frame, [MarshalAs(UnmanagedType.U1)] bool isTeleportation);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLocalPositionDelegate(UIntPtr entityId, Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetManualGlobalBoundingBoxDelegate(UIntPtr entityId, Vec3 boundingBoxStartGlobal, Vec3 boundingBoxEndGlobal);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetManualLocalBoundingBoxDelegate(UIntPtr entityId, in BoundingBox boundingBox);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMassAndUpdateInertiaAndCenterOfMassDelegate(UIntPtr entityId, float mass);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMassSpaceInertiaDelegate(UIntPtr entityId, ref Vec3 inertia);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMaterialForAllMeshesDelegate(UIntPtr entityId, UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMaxDepenetrationVelocityDelegate(UIntPtr entityId, float maxDepenetrationVelocity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMobilityDelegate(UIntPtr entityId, GameEntity.Mobility mobility);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMorphFrameOfComponentsDelegate(UIntPtr entityId, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetNameDelegate(UIntPtr entityId, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetNativeScriptComponentVariableDelegate(UIntPtr entityPtr, byte[] className, byte[] fieldName, ref ScriptComponentFieldHolder data, RglScriptFieldType variableType);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhysicsMoveToBatchedDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhysicsStateDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool isEnabled, [MarshalAs(UnmanagedType.U1)] bool setChildren);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhysicsStateOnlyVariableDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool isEnabled, [MarshalAs(UnmanagedType.U1)] bool setChildren);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPositionsForAttachedNavmeshVerticesDelegate(UIntPtr entityId, IntPtr indices, int indexCount, IntPtr positions);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPreviousFrameInvalidDelegate(UIntPtr gameEntity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetReadyToRenderDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool ready);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRuntimeEmissionRateMultiplierDelegate(UIntPtr entityId, float emission_rate_multiplier);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSkeletonDelegate(UIntPtr entityId, UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSolverIterationCountsDelegate(UIntPtr entityId, int positionIterationCount, int velocityIterationCount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetupAdditionalBoneBufferForMeshesDelegate(UIntPtr entityPtr, int boneCount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetUpdateValidityOnFrameChangedOfFacesWithIdDelegate(UIntPtr entityId, int faceGroupId, [MarshalAs(UnmanagedType.U1)] bool updateValidity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetUpgradeLevelMaskDelegate(UIntPtr prefab, uint mask);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVectorArgumentDelegate(UIntPtr entityId, float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVelocityLimitsDelegate(UIntPtr entityId, float maxLinearVelocity, float maxAngularVelocity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVisibilityExcludeParentsDelegate(UIntPtr entityId, [MarshalAs(UnmanagedType.U1)] bool visibility);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVisualRecordWakeParamsDelegate(UIntPtr visualRecord, in Vec3 wakeParams);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetWaterSDFClipDataDelegate(UIntPtr entityId, int slotIndex, in MatrixFrame frame, [MarshalAs(UnmanagedType.U1)] bool visibility);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetWaterVisualRecordFrameAndDtDelegate(UIntPtr entityPointer, UIntPtr visualPrefab, in MatrixFrame frame, float dt);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SwapPhysxShapeInEntityDelegate(UIntPtr entityPtr, UIntPtr oldShape, UIntPtr newShape, [MarshalAs(UnmanagedType.U1)] bool isVariable);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateAttachedNavigationMeshFacesDelegate(UIntPtr entityId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateGlobalBoundsDelegate(UIntPtr entityPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateHullWaterEffectFramesDelegate(UIntPtr entityPointer, UIntPtr visualPrefab);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateTriadFrameForEditorDelegate(UIntPtr meshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateVisibilityMaskDelegate(UIntPtr entityPtr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ValidateBoundingBoxDelegate(UIntPtr entityPointer);

	private static readonly Encoding _utf8;

	public static ActivateRagdollDelegate call_ActivateRagdollDelegate;

	public static AddAllMeshesOfGameEntityDelegate call_AddAllMeshesOfGameEntityDelegate;

	public static AddCapsuleAsBodyDelegate call_AddCapsuleAsBodyDelegate;

	public static AddChildDelegate call_AddChildDelegate;

	public static AddComponentDelegate call_AddComponentDelegate;

	public static AddDistanceJointDelegate call_AddDistanceJointDelegate;

	public static AddDistanceJointWithFramesDelegate call_AddDistanceJointWithFramesDelegate;

	public static AddEditDataUserToAllMeshesDelegate call_AddEditDataUserToAllMeshesDelegate;

	public static AddLightDelegate call_AddLightDelegate;

	public static AddMeshDelegate call_AddMeshDelegate;

	public static AddMeshToBoneDelegate call_AddMeshToBoneDelegate;

	public static AddMultiMeshDelegate call_AddMultiMeshDelegate;

	public static AddMultiMeshToSkeletonDelegate call_AddMultiMeshToSkeletonDelegate;

	public static AddMultiMeshToSkeletonBoneDelegate call_AddMultiMeshToSkeletonBoneDelegate;

	public static AddParticleSystemComponentDelegate call_AddParticleSystemComponentDelegate;

	public static AddPhysicsDelegate call_AddPhysicsDelegate;

	public static AddSphereAsBodyDelegate call_AddSphereAsBodyDelegate;

	public static AddSplashPositionToWaterVisualRecordDelegate call_AddSplashPositionToWaterVisualRecordDelegate;

	public static AddTagDelegate call_AddTagDelegate;

	public static ApplyAccelerationToDynamicBodyDelegate call_ApplyAccelerationToDynamicBodyDelegate;

	public static ApplyForceToDynamicBodyDelegate call_ApplyForceToDynamicBodyDelegate;

	public static ApplyGlobalForceAtLocalPosToDynamicBodyDelegate call_ApplyGlobalForceAtLocalPosToDynamicBodyDelegate;

	public static ApplyLocalForceAtLocalPosToDynamicBodyDelegate call_ApplyLocalForceAtLocalPosToDynamicBodyDelegate;

	public static ApplyLocalImpulseToDynamicBodyDelegate call_ApplyLocalImpulseToDynamicBodyDelegate;

	public static ApplyTorqueToDynamicBodyDelegate call_ApplyTorqueToDynamicBodyDelegate;

	public static AttachNavigationMeshFacesDelegate call_AttachNavigationMeshFacesDelegate;

	public static BreakPrefabDelegate call_BreakPrefabDelegate;

	public static BurstEntityParticleDelegate call_BurstEntityParticleDelegate;

	public static CallScriptCallbacksDelegate call_CallScriptCallbacksDelegate;

	public static ChangeMetaMeshOrRemoveItIfNotExistsDelegate call_ChangeMetaMeshOrRemoveItIfNotExistsDelegate;

	public static ChangeResolutionMultiplierOfWaterVisualDelegate call_ChangeResolutionMultiplierOfWaterVisualDelegate;

	public static CheckIsPrefabLinkRootPrefabDelegate call_CheckIsPrefabLinkRootPrefabDelegate;

	public static CheckPointWithOrientedBoundingBoxDelegate call_CheckPointWithOrientedBoundingBoxDelegate;

	public static CheckResourcesDelegate call_CheckResourcesDelegate;

	public static ClearComponentsDelegate call_ClearComponentsDelegate;

	public static ClearEntityComponentsDelegate call_ClearEntityComponentsDelegate;

	public static ClearOnlyOwnComponentsDelegate call_ClearOnlyOwnComponentsDelegate;

	public static ComputeTrajectoryVolumeDelegate call_ComputeTrajectoryVolumeDelegate;

	public static ComputeVelocityDeltaFromImpulseDelegate call_ComputeVelocityDeltaFromImpulseDelegate;

	public static ConvertDynamicBodyToRayCastDelegate call_ConvertDynamicBodyToRayCastDelegate;

	public static CookTrianglePhysxMeshDelegate call_CookTrianglePhysxMeshDelegate;

	public static CopyComponentsToSkeletonDelegate call_CopyComponentsToSkeletonDelegate;

	public static CopyFromPrefabDelegate call_CopyFromPrefabDelegate;

	public static CopyScriptComponentFromAnotherEntityDelegate call_CopyScriptComponentFromAnotherEntityDelegate;

	public static CreateAndAddScriptComponentDelegate call_CreateAndAddScriptComponentDelegate;

	public static CreateEmptyDelegate call_CreateEmptyDelegate;

	public static CreateEmptyPhysxShapeDelegate call_CreateEmptyPhysxShapeDelegate;

	public static CreateEmptyWithoutSceneDelegate call_CreateEmptyWithoutSceneDelegate;

	public static CreateFromPrefabDelegate call_CreateFromPrefabDelegate;

	public static CreateFromPrefabWithInitialFrameDelegate call_CreateFromPrefabWithInitialFrameDelegate;

	public static CreatePhysxCookingInstanceDelegate call_CreatePhysxCookingInstanceDelegate;

	public static CreateVariableRatePhysicsDelegate call_CreateVariableRatePhysicsDelegate;

	public static DeleteEmptyShapeDelegate call_DeleteEmptyShapeDelegate;

	public static DeletePhysxCookingInstanceDelegate call_DeletePhysxCookingInstanceDelegate;

	public static DeRegisterWaterMeshMaterialsDelegate call_DeRegisterWaterMeshMaterialsDelegate;

	public static DeRegisterWaterSDFClipDelegate call_DeRegisterWaterSDFClipDelegate;

	public static DeselectEntityOnEditorDelegate call_DeselectEntityOnEditorDelegate;

	public static DetachAllAttachedNavigationMeshFacesDelegate call_DetachAllAttachedNavigationMeshFacesDelegate;

	public static DisableContourDelegate call_DisableContourDelegate;

	public static DisableDynamicBodySimulationDelegate call_DisableDynamicBodySimulationDelegate;

	public static DisableGravityDelegate call_DisableGravityDelegate;

	public static EnableDynamicBodyDelegate call_EnableDynamicBodyDelegate;

	public static FindWithNameDelegate call_FindWithNameDelegate;

	public static FreezeDelegate call_FreezeDelegate;

	public static GetAngularVelocityDelegate call_GetAngularVelocityDelegate;

	public static GetAttachedNavmeshFaceCountDelegate call_GetAttachedNavmeshFaceCountDelegate;

	public static GetAttachedNavmeshFaceRecordsDelegate call_GetAttachedNavmeshFaceRecordsDelegate;

	public static GetAttachedNavmeshFaceVertexIndicesDelegate call_GetAttachedNavmeshFaceVertexIndicesDelegate;

	public static GetBodyFlagsDelegate call_GetBodyFlagsDelegate;

	public static GetBodyShapeDelegate call_GetBodyShapeDelegate;

	public static GetBodyVisualWorldTransformDelegate call_GetBodyVisualWorldTransformDelegate;

	public static GetBodyWorldTransformDelegate call_GetBodyWorldTransformDelegate;

	public static GetBoneCountDelegate call_GetBoneCountDelegate;

	public static GetBoneEntitialFrameWithIndexDelegate call_GetBoneEntitialFrameWithIndexDelegate;

	public static GetBoneEntitialFrameWithNameDelegate call_GetBoneEntitialFrameWithNameDelegate;

	public static GetBoundingBoxMaxDelegate call_GetBoundingBoxMaxDelegate;

	public static GetBoundingBoxMinDelegate call_GetBoundingBoxMinDelegate;

	public static GetCameraParamsFromCameraScriptDelegate call_GetCameraParamsFromCameraScriptDelegate;

	public static GetCenterOfMassDelegate call_GetCenterOfMassDelegate;

	public static GetChildDelegate call_GetChildDelegate;

	public static GetChildCountDelegate call_GetChildCountDelegate;

	public static GetChildPointerDelegate call_GetChildPointerDelegate;

	public static GetComponentAtIndexDelegate call_GetComponentAtIndexDelegate;

	public static GetComponentCountDelegate call_GetComponentCountDelegate;

	public static GetEditModeLevelVisibilityDelegate call_GetEditModeLevelVisibilityDelegate;

	public static GetEntityFlagsDelegate call_GetEntityFlagsDelegate;

	public static GetEntityVisibilityFlagsDelegate call_GetEntityVisibilityFlagsDelegate;

	public static GetFactorColorDelegate call_GetFactorColorDelegate;

	public static GetFirstChildWithTagRecursiveDelegate call_GetFirstChildWithTagRecursiveDelegate;

	public static GetFirstEntityWithTagDelegate call_GetFirstEntityWithTagDelegate;

	public static GetFirstEntityWithTagExpressionDelegate call_GetFirstEntityWithTagExpressionDelegate;

	public static GetFirstMeshDelegate call_GetFirstMeshDelegate;

	public static GetGlobalBoundingBoxDelegate call_GetGlobalBoundingBoxDelegate;

	public static GetGlobalBoxMaxDelegate call_GetGlobalBoxMaxDelegate;

	public static GetGlobalBoxMinDelegate call_GetGlobalBoxMinDelegate;

	public static GetGlobalFrameDelegate call_GetGlobalFrameDelegate;

	public static GetGlobalFrameImpreciseForFixedTickDelegate call_GetGlobalFrameImpreciseForFixedTickDelegate;

	public static GetGlobalScaleDelegate call_GetGlobalScaleDelegate;

	public static GetGlobalWindStrengthVectorOfSceneDelegate call_GetGlobalWindStrengthVectorOfSceneDelegate;

	public static GetGlobalWindVelocityOfSceneDelegate call_GetGlobalWindVelocityOfSceneDelegate;

	public static GetGlobalWindVelocityWithGustNoiseOfSceneDelegate call_GetGlobalWindVelocityWithGustNoiseOfSceneDelegate;

	public static GetGuidDelegate call_GetGuidDelegate;

	public static GetLastFinalRenderCameraPositionOfSceneDelegate call_GetLastFinalRenderCameraPositionOfSceneDelegate;

	public static GetLightDelegate call_GetLightDelegate;

	public static GetLinearVelocityDelegate call_GetLinearVelocityDelegate;

	public static GetLocalBoundingBoxDelegate call_GetLocalBoundingBoxDelegate;

	public static GetLocalFrameDelegate call_GetLocalFrameDelegate;

	public static GetLocalPhysicsBoundingBoxDelegate call_GetLocalPhysicsBoundingBoxDelegate;

	public static GetLodLevelForDistanceSqDelegate call_GetLodLevelForDistanceSqDelegate;

	public static GetMassDelegate call_GetMassDelegate;

	public static GetMassSpaceInertiaDelegate call_GetMassSpaceInertiaDelegate;

	public static GetMassSpaceInverseInertiaDelegate call_GetMassSpaceInverseInertiaDelegate;

	public static GetMeshBendedPositionDelegate call_GetMeshBendedPositionDelegate;

	public static GetMobilityDelegate call_GetMobilityDelegate;

	public static GetNameDelegate call_GetNameDelegate;

	public static GetNativeScriptComponentVariableDelegate call_GetNativeScriptComponentVariableDelegate;

	public static GetNextEntityWithTagDelegate call_GetNextEntityWithTagDelegate;

	public static GetNextEntityWithTagExpressionDelegate call_GetNextEntityWithTagExpressionDelegate;

	public static GetNextPrefabDelegate call_GetNextPrefabDelegate;

	public static GetOldPrefabNameDelegate call_GetOldPrefabNameDelegate;

	public static GetParentDelegate call_GetParentDelegate;

	public static GetParentPointerDelegate call_GetParentPointerDelegate;

	public static GetPhysicsDescBodyFlagsDelegate call_GetPhysicsDescBodyFlagsDelegate;

	public static GetPhysicsMaterialIndexDelegate call_GetPhysicsMaterialIndexDelegate;

	public static GetPhysicsMinMaxDelegate call_GetPhysicsMinMaxDelegate;

	public static GetPhysicsStateDelegate call_GetPhysicsStateDelegate;

	public static GetPhysicsTriangleCountDelegate call_GetPhysicsTriangleCountDelegate;

	public static GetPrefabNameDelegate call_GetPrefabNameDelegate;

	public static GetPreviousGlobalFrameDelegate call_GetPreviousGlobalFrameDelegate;

	public static GetQuickBoneEntitialFrameDelegate call_GetQuickBoneEntitialFrameDelegate;

	public static GetRadiusDelegate call_GetRadiusDelegate;

	public static GetRootParentPointerDelegate call_GetRootParentPointerDelegate;

	public static GetSceneDelegate call_GetSceneDelegate;

	public static GetScenePointerDelegate call_GetScenePointerDelegate;

	public static GetScriptComponentDelegate call_GetScriptComponentDelegate;

	public static GetScriptComponentAtIndexDelegate call_GetScriptComponentAtIndexDelegate;

	public static GetScriptComponentCountDelegate call_GetScriptComponentCountDelegate;

	public static GetScriptComponentIndexDelegate call_GetScriptComponentIndexDelegate;

	public static GetSkeletonDelegate call_GetSkeletonDelegate;

	public static GetTagsDelegate call_GetTagsDelegate;

	public static GetUpgradeLevelMaskDelegate call_GetUpgradeLevelMaskDelegate;

	public static GetUpgradeLevelMaskCumulativeDelegate call_GetUpgradeLevelMaskCumulativeDelegate;

	public static GetVisibilityExcludeParentsDelegate call_GetVisibilityExcludeParentsDelegate;

	public static GetVisibilityLevelMaskIncludingParentsDelegate call_GetVisibilityLevelMaskIncludingParentsDelegate;

	public static GetWaterLevelAtPositionDelegate call_GetWaterLevelAtPositionDelegate;

	public static HasBatchedKinematicPhysicsFlagDelegate call_HasBatchedKinematicPhysicsFlagDelegate;

	public static HasBatchedRayCastPhysicsFlagDelegate call_HasBatchedRayCastPhysicsFlagDelegate;

	public static HasBodyDelegate call_HasBodyDelegate;

	public static HasComplexAnimTreeDelegate call_HasComplexAnimTreeDelegate;

	public static HasComponentDelegate call_HasComponentDelegate;

	public static HasDynamicRigidBodyDelegate call_HasDynamicRigidBodyDelegate;

	public static HasDynamicRigidBodyAndActiveSimulationDelegate call_HasDynamicRigidBodyAndActiveSimulationDelegate;

	public static HasFrameChangedDelegate call_HasFrameChangedDelegate;

	public static HasKinematicRigidBodyDelegate call_HasKinematicRigidBodyDelegate;

	public static HasPhysicsBodyDelegate call_HasPhysicsBodyDelegate;

	public static HasPhysicsDefinitionDelegate call_HasPhysicsDefinitionDelegate;

	public static HasSceneDelegate call_HasSceneDelegate;

	public static HasScriptComponentDelegate call_HasScriptComponentDelegate;

	public static HasScriptComponentHashDelegate call_HasScriptComponentHashDelegate;

	public static HasStaticPhysicsBodyDelegate call_HasStaticPhysicsBodyDelegate;

	public static HasTagDelegate call_HasTagDelegate;

	public static IsDynamicBodyStationaryDelegate call_IsDynamicBodyStationaryDelegate;

	public static IsEngineBodySleepingDelegate call_IsEngineBodySleepingDelegate;

	public static IsEntitySelectedOnEditorDelegate call_IsEntitySelectedOnEditorDelegate;

	public static IsFrozenDelegate call_IsFrozenDelegate;

	public static IsGhostObjectDelegate call_IsGhostObjectDelegate;

	public static IsGravityDisabledDelegate call_IsGravityDisabledDelegate;

	public static IsGuidValidDelegate call_IsGuidValidDelegate;

	public static IsInEditorSceneDelegate call_IsInEditorSceneDelegate;

	public static IsVisibleIncludeParentsDelegate call_IsVisibleIncludeParentsDelegate;

	public static PauseParticleSystemDelegate call_PauseParticleSystemDelegate;

	public static PopCapsuleShapeFromEntityBodyDelegate call_PopCapsuleShapeFromEntityBodyDelegate;

	public static PrefabExistsDelegate call_PrefabExistsDelegate;

	public static PushCapsuleShapeToEntityBodyDelegate call_PushCapsuleShapeToEntityBodyDelegate;

	public static RayHitEntityDelegate call_RayHitEntityDelegate;

	public static RayHitEntityWithNormalDelegate call_RayHitEntityWithNormalDelegate;

	public static RecomputeBoundingBoxDelegate call_RecomputeBoundingBoxDelegate;

	public static RefreshMeshesToRenderToHullWaterDelegate call_RefreshMeshesToRenderToHullWaterDelegate;

	public static RegisterWaterSDFClipDelegate call_RegisterWaterSDFClipDelegate;

	public static RelaxLocalBoundingBoxDelegate call_RelaxLocalBoundingBoxDelegate;

	public static ReleaseEditDataUserToAllMeshesDelegate call_ReleaseEditDataUserToAllMeshesDelegate;

	public static RemoveDelegate call_RemoveDelegate;

	public static RemoveAllChildrenDelegate call_RemoveAllChildrenDelegate;

	public static RemoveAllParticleSystemsDelegate call_RemoveAllParticleSystemsDelegate;

	public static RemoveChildDelegate call_RemoveChildDelegate;

	public static RemoveComponentDelegate call_RemoveComponentDelegate;

	public static RemoveComponentWithMeshDelegate call_RemoveComponentWithMeshDelegate;

	public static RemoveEnginePhysicsDelegate call_RemoveEnginePhysicsDelegate;

	public static RemoveFromPredisplayEntityDelegate call_RemoveFromPredisplayEntityDelegate;

	public static RemoveJointDelegate call_RemoveJointDelegate;

	public static RemoveMultiMeshDelegate call_RemoveMultiMeshDelegate;

	public static RemoveMultiMeshFromSkeletonDelegate call_RemoveMultiMeshFromSkeletonDelegate;

	public static RemoveMultiMeshFromSkeletonBoneDelegate call_RemoveMultiMeshFromSkeletonBoneDelegate;

	public static RemovePhysicsDelegate call_RemovePhysicsDelegate;

	public static RemoveScriptComponentDelegate call_RemoveScriptComponentDelegate;

	public static RemoveTagDelegate call_RemoveTagDelegate;

	public static ReplacePhysicsBodyWithQuadPhysicsBodyDelegate call_ReplacePhysicsBodyWithQuadPhysicsBodyDelegate;

	public static ResetHullWaterDelegate call_ResetHullWaterDelegate;

	public static ResumeParticleSystemDelegate call_ResumeParticleSystemDelegate;

	public static SelectEntityOnEditorDelegate call_SelectEntityOnEditorDelegate;

	public static SetAlphaDelegate call_SetAlphaDelegate;

	public static SetAngularVelocityDelegate call_SetAngularVelocityDelegate;

	public static SetAnimationSoundActivationDelegate call_SetAnimationSoundActivationDelegate;

	public static SetAnimTreeChannelParameterDelegate call_SetAnimTreeChannelParameterDelegate;

	public static SetAsContourEntityDelegate call_SetAsContourEntityDelegate;

	public static SetAsPredisplayEntityDelegate call_SetAsPredisplayEntityDelegate;

	public static SetAsReplayEntityDelegate call_SetAsReplayEntityDelegate;

	public static SetBodyFlagsDelegate call_SetBodyFlagsDelegate;

	public static SetBodyFlagsRecursiveDelegate call_SetBodyFlagsRecursiveDelegate;

	public static SetBodyShapeDelegate call_SetBodyShapeDelegate;

	public static SetBoneFrameToAllMeshesDelegate call_SetBoneFrameToAllMeshesDelegate;

	public static SetBoundingboxDirtyDelegate call_SetBoundingboxDirtyDelegate;

	public static SetCenterOfMassDelegate call_SetCenterOfMassDelegate;

	public static SetClothComponentKeepStateDelegate call_SetClothComponentKeepStateDelegate;

	public static SetClothComponentKeepStateOfAllMeshesDelegate call_SetClothComponentKeepStateOfAllMeshesDelegate;

	public static SetClothMaxDistanceMultiplierDelegate call_SetClothMaxDistanceMultiplierDelegate;

	public static SetColorToAllMeshesWithTagRecursiveDelegate call_SetColorToAllMeshesWithTagRecursiveDelegate;

	public static SetContourStateDelegate call_SetContourStateDelegate;

	public static SetCostAdderForAttachedFacesDelegate call_SetCostAdderForAttachedFacesDelegate;

	public static SetCullModeDelegate call_SetCullModeDelegate;

	public static SetCustomClipPlaneDelegate call_SetCustomClipPlaneDelegate;

	public static SetCustomVertexPositionEnabledDelegate call_SetCustomVertexPositionEnabledDelegate;

	public static SetDampingDelegate call_SetDampingDelegate;

	public static SetDoNotCheckVisibilityDelegate call_SetDoNotCheckVisibilityDelegate;

	public static SetEnforcedMaximumLodLevelDelegate call_SetEnforcedMaximumLodLevelDelegate;

	public static SetEntityEnvMapVisibilityDelegate call_SetEntityEnvMapVisibilityDelegate;

	public static SetEntityFlagsDelegate call_SetEntityFlagsDelegate;

	public static SetEntityVisibilityFlagsDelegate call_SetEntityVisibilityFlagsDelegate;

	public static SetExternalReferencesUsageDelegate call_SetExternalReferencesUsageDelegate;

	public static SetFactor2ColorDelegate call_SetFactor2ColorDelegate;

	public static SetFactorColorDelegate call_SetFactorColorDelegate;

	public static SetForceDecalsToRenderDelegate call_SetForceDecalsToRenderDelegate;

	public static SetForceNotAffectedBySeasonDelegate call_SetForceNotAffectedBySeasonDelegate;

	public static SetFrameChangedDelegate call_SetFrameChangedDelegate;

	public static SetGlobalFrameDelegate call_SetGlobalFrameDelegate;

	public static SetGlobalPositionDelegate call_SetGlobalPositionDelegate;

	public static SetHasCustomBoundingBoxValidationSystemDelegate call_SetHasCustomBoundingBoxValidationSystemDelegate;

	public static SetLinearVelocityDelegate call_SetLinearVelocityDelegate;

	public static SetLocalFrameDelegate call_SetLocalFrameDelegate;

	public static SetLocalPositionDelegate call_SetLocalPositionDelegate;

	public static SetManualGlobalBoundingBoxDelegate call_SetManualGlobalBoundingBoxDelegate;

	public static SetManualLocalBoundingBoxDelegate call_SetManualLocalBoundingBoxDelegate;

	public static SetMassAndUpdateInertiaAndCenterOfMassDelegate call_SetMassAndUpdateInertiaAndCenterOfMassDelegate;

	public static SetMassSpaceInertiaDelegate call_SetMassSpaceInertiaDelegate;

	public static SetMaterialForAllMeshesDelegate call_SetMaterialForAllMeshesDelegate;

	public static SetMaxDepenetrationVelocityDelegate call_SetMaxDepenetrationVelocityDelegate;

	public static SetMobilityDelegate call_SetMobilityDelegate;

	public static SetMorphFrameOfComponentsDelegate call_SetMorphFrameOfComponentsDelegate;

	public static SetNameDelegate call_SetNameDelegate;

	public static SetNativeScriptComponentVariableDelegate call_SetNativeScriptComponentVariableDelegate;

	public static SetPhysicsMoveToBatchedDelegate call_SetPhysicsMoveToBatchedDelegate;

	public static SetPhysicsStateDelegate call_SetPhysicsStateDelegate;

	public static SetPhysicsStateOnlyVariableDelegate call_SetPhysicsStateOnlyVariableDelegate;

	public static SetPositionsForAttachedNavmeshVerticesDelegate call_SetPositionsForAttachedNavmeshVerticesDelegate;

	public static SetPreviousFrameInvalidDelegate call_SetPreviousFrameInvalidDelegate;

	public static SetReadyToRenderDelegate call_SetReadyToRenderDelegate;

	public static SetRuntimeEmissionRateMultiplierDelegate call_SetRuntimeEmissionRateMultiplierDelegate;

	public static SetSkeletonDelegate call_SetSkeletonDelegate;

	public static SetSolverIterationCountsDelegate call_SetSolverIterationCountsDelegate;

	public static SetupAdditionalBoneBufferForMeshesDelegate call_SetupAdditionalBoneBufferForMeshesDelegate;

	public static SetUpdateValidityOnFrameChangedOfFacesWithIdDelegate call_SetUpdateValidityOnFrameChangedOfFacesWithIdDelegate;

	public static SetUpgradeLevelMaskDelegate call_SetUpgradeLevelMaskDelegate;

	public static SetVectorArgumentDelegate call_SetVectorArgumentDelegate;

	public static SetVelocityLimitsDelegate call_SetVelocityLimitsDelegate;

	public static SetVisibilityExcludeParentsDelegate call_SetVisibilityExcludeParentsDelegate;

	public static SetVisualRecordWakeParamsDelegate call_SetVisualRecordWakeParamsDelegate;

	public static SetWaterSDFClipDataDelegate call_SetWaterSDFClipDataDelegate;

	public static SetWaterVisualRecordFrameAndDtDelegate call_SetWaterVisualRecordFrameAndDtDelegate;

	public static SwapPhysxShapeInEntityDelegate call_SwapPhysxShapeInEntityDelegate;

	public static UpdateAttachedNavigationMeshFacesDelegate call_UpdateAttachedNavigationMeshFacesDelegate;

	public static UpdateGlobalBoundsDelegate call_UpdateGlobalBoundsDelegate;

	public static UpdateHullWaterEffectFramesDelegate call_UpdateHullWaterEffectFramesDelegate;

	public static UpdateTriadFrameForEditorDelegate call_UpdateTriadFrameForEditorDelegate;

	public static UpdateVisibilityMaskDelegate call_UpdateVisibilityMaskDelegate;

	public static ValidateBoundingBoxDelegate call_ValidateBoundingBoxDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateRagdoll(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAllMeshesOfGameEntity(UIntPtr entityId, UIntPtr copiedEntityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCapsuleAsBody(UIntPtr entityId, Vec3 p1, Vec3 p2, float radius, uint bodyFlags, string physicsMaterialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddChild(UIntPtr parententity, UIntPtr childentity, bool autoLocalizeFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddComponent(UIntPtr pointer, UIntPtr componentPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr AddDistanceJoint(UIntPtr entityId, UIntPtr otherEntityId, float minDistance, float maxDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr AddDistanceJointWithFrames(UIntPtr entityId, UIntPtr otherEntityId, MatrixFrame globalFrameOnA, MatrixFrame globalFrameOnB, float minDistance, float maxDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEditDataUserToAllMeshes(UIntPtr entityId, bool entity_components, bool skeleton_components)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AddLight(UIntPtr entityId, UIntPtr lightPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMesh(UIntPtr entityId, UIntPtr mesh, bool recomputeBoundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMeshToBone(UIntPtr entityId, UIntPtr multiMeshPointer, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMultiMesh(UIntPtr entityId, UIntPtr multiMeshPtr, bool updateVisMask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMultiMeshToSkeleton(UIntPtr gameEntity, UIntPtr multiMesh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMultiMeshToSkeletonBone(UIntPtr gameEntity, UIntPtr multiMesh, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddParticleSystemComponent(UIntPtr entityId, string particleid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPhysics(UIntPtr entityId, UIntPtr body, float mass, ref Vec3 localCenterOfMass, ref Vec3 initialGlobalVelocity, ref Vec3 initialAngularGlobalVelocity, int physicsMaterial, bool isStatic, int collisionGroupID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSphereAsBody(UIntPtr entityId, Vec3 center, float radius, uint bodyFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSplashPositionToWaterVisualRecord(UIntPtr entityPointer, UIntPtr visualPrefab, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTag(UIntPtr entityId, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyAccelerationToDynamicBody(UIntPtr entityId, ref Vec3 acceleration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyForceToDynamicBody(UIntPtr entityId, ref Vec3 force, GameEntityPhysicsExtensions.ForceMode forceMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyGlobalForceAtLocalPosToDynamicBody(UIntPtr entityId, ref Vec3 localPosition, ref Vec3 globalForce, GameEntityPhysicsExtensions.ForceMode forceMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyLocalForceAtLocalPosToDynamicBody(UIntPtr entityId, ref Vec3 localPosition, ref Vec3 localForce, GameEntityPhysicsExtensions.ForceMode forceMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyLocalImpulseToDynamicBody(UIntPtr entityId, ref Vec3 localPosition, ref Vec3 impulse)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyTorqueToDynamicBody(UIntPtr entityId, ref Vec3 torque, GameEntityPhysicsExtensions.ForceMode forceMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AttachNavigationMeshFaces(UIntPtr entityId, int faceGroupId, bool isConnected, bool isBlocker, bool autoLocalize, bool finalizeBlockerConvexHullComputation, bool updateEntityFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BreakPrefab(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BurstEntityParticle(UIntPtr entityId, bool doChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CallScriptCallbacks(UIntPtr entityPointer, bool registerScriptComponents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeMetaMeshOrRemoveItIfNotExists(UIntPtr entityId, UIntPtr entityMetaMeshPointer, UIntPtr newMetaMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ChangeResolutionMultiplierOfWaterVisual(UIntPtr visualPrefab, float multiplier, in Vec3 waterEffectsBB)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIsPrefabLinkRootPrefab(UIntPtr entityPtr, int depth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckPointWithOrientedBoundingBox(UIntPtr entityId, Vec3 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckResources(UIntPtr entityId, bool addToQueue, bool checkFaceResources)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearComponents(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearEntityComponents(UIntPtr entityId, bool resetAll, bool removeScripts, bool deleteChildEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearOnlyOwnComponents(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComputeTrajectoryVolume(UIntPtr gameEntity, float missileSpeed, float verticalAngleMaxInDegrees, float verticalAngleMinInDegrees, float horizontalAngleRangeInDegrees, float airFrictionConstant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComputeVelocityDeltaFromImpulse(UIntPtr entityPtr, in Vec3 impulsiveForce, in Vec3 impulsiveTorque, out Vec3 deltaLinearVelocity, out Vec3 deltaAngularVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConvertDynamicBodyToRayCast(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CookTrianglePhysxMesh(UIntPtr cookingInstancePointer, UIntPtr shapePointer, UIntPtr quadPinnedPointer, int physicsMaterial, int numberOfVertices, UIntPtr indicesPinnedPointer, int numberOfIndices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyComponentsToSkeleton(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity CopyFromPrefab(UIntPtr prefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyScriptComponentFromAnotherEntity(UIntPtr prefab, UIntPtr other_prefab, string script_name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateAndAddScriptComponent(UIntPtr entityId, string name, bool callScriptCallbacks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity CreateEmpty(UIntPtr scenePointer, bool isModifiableFromEditor, UIntPtr entityId, bool createPhysics, bool callScriptCallbacks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr CreateEmptyPhysxShape(UIntPtr entityPointer, bool isVariable, int physxMaterialIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity CreateEmptyWithoutScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity CreateFromPrefab(UIntPtr scenePointer, string prefabid, bool callScriptCallbacks, bool createPhysics, uint scriptInclusionHashTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity CreateFromPrefabWithInitialFrame(UIntPtr scenePointer, string prefabid, ref MatrixFrame frame, bool callScriptCallbacks)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr CreatePhysxCookingInstance()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateVariableRatePhysics(UIntPtr entityId, bool forChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteEmptyShape(UIntPtr entity, UIntPtr shape1, UIntPtr shape2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeletePhysxCookingInstance(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeRegisterWaterMeshMaterials(UIntPtr entityPointer, UIntPtr visualPrefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeRegisterWaterSDFClip(UIntPtr entityId, int slot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeselectEntityOnEditor(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DetachAllAttachedNavigationMeshFaces(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableContour(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableDynamicBodySimulation(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableGravity(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableDynamicBody(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity FindWithName(UIntPtr scenePointer, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Freeze(UIntPtr entityId, bool isFrozen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetAngularVelocity(UIntPtr entityPtr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAttachedNavmeshFaceCount(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAttachedNavmeshFaceRecords(UIntPtr entityId, PathFaceRecord[] faceRecords)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAttachedNavmeshFaceVertexIndices(UIntPtr entityId, in PathFaceRecord faceRecord, int[] indices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetBodyFlags(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PhysicsShape GetBodyShape(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBodyVisualWorldTransform(UIntPtr entityPtr, out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBodyWorldTransform(UIntPtr entityPtr, out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetBoneCount(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneEntitialFrameWithIndex(UIntPtr entityId, sbyte boneIndex, ref MatrixFrame outEntitialFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneEntitialFrameWithName(UIntPtr entityId, string boneName, ref MatrixFrame outEntitialFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetBoundingBoxMax(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetBoundingBoxMin(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetCameraParamsFromCameraScript(UIntPtr entityId, UIntPtr camPtr, ref Vec3 dof_params)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetCenterOfMass(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetChild(UIntPtr entityId, int childIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetChildCount(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetChildPointer(UIntPtr entityId, int childIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntityComponent GetComponentAtIndex(UIntPtr entityId, GameEntity.ComponentType componentType, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetComponentCount(UIntPtr entityId, GameEntity.ComponentType componentType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetEditModeLevelVisibility(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntityFlags GetEntityFlags(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EntityVisibilityFlags GetEntityVisibilityFlags(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetFactorColor(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetFirstChildWithTagRecursive(UIntPtr entityPtr, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetFirstEntityWithTag(UIntPtr scenePointer, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetFirstEntityWithTagExpression(UIntPtr scenePointer, string tagExpression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mesh GetFirstMesh(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoundingBox GetGlobalBoundingBox(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetGlobalBoxMax(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetGlobalBoxMin(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetGlobalFrame(UIntPtr meshPointer, out MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetGlobalFrameImpreciseForFixedTick(UIntPtr entityId, out MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetGlobalScale(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetGlobalWindStrengthVectorOfScene(UIntPtr entityPtr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetGlobalWindVelocityOfScene(UIntPtr entityPtr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetGlobalWindVelocityWithGustNoiseOfScene(UIntPtr entityPtr, float globalTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetGuid(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetLastFinalRenderCameraPositionOfScene(UIntPtr entityPtr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Light GetLight(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetLinearVelocity(UIntPtr entityPtr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoundingBox GetLocalBoundingBox(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetLocalFrame(UIntPtr entityId, out MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetLocalPhysicsBoundingBox(UIntPtr entityId, bool includeChildren, out BoundingBox outBoundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetLodLevelForDistanceSq(UIntPtr entityId, float distanceSquared)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetMass(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetMassSpaceInertia(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetMassSpaceInverseInertia(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetMeshBendedPosition(UIntPtr entityId, ref MatrixFrame worldSpacePosition, ref MatrixFrame output)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity.Mobility GetMobility(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetNativeScriptComponentVariable(UIntPtr entityPtr, string className, string fieldName, ref ScriptComponentFieldHolder data, RglScriptFieldType variableType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNextEntityWithTag(UIntPtr currententityId, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNextEntityWithTagExpression(UIntPtr currententityId, string tagExpression)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetNextPrefab(UIntPtr currentPrefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetOldPrefabName(UIntPtr prefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetParent(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetParentPointer(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetPhysicsDescBodyFlags(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPhysicsMaterialIndex(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPhysicsMinMax(UIntPtr entityId, bool includeChildren, ref Vec3 bbmin, ref Vec3 bbmax, bool returnLocal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPhysicsState(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetPhysicsTriangleCount(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetPrefabName(UIntPtr prefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPreviousGlobalFrame(UIntPtr entityPtr, out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetQuickBoneEntitialFrame(UIntPtr entityId, sbyte index, out MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetRadius(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetRootParentPointer(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Scene GetScene(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetScenePointer(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptComponentBehavior GetScriptComponent(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptComponentBehavior GetScriptComponentAtIndex(UIntPtr entityId, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetScriptComponentCount(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetScriptComponentIndex(UIntPtr entityId, uint nameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Skeleton GetSkeleton(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetTags(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetUpgradeLevelMask(UIntPtr prefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetUpgradeLevelMaskCumulative(UIntPtr prefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetVisibilityExcludeParents(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetVisibilityLevelMaskIncludingParents(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWaterLevelAtPosition(UIntPtr entityId, in Vec2 position, bool useWaterRenderer, bool checkWaterBodyEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasBatchedKinematicPhysicsFlag(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasBatchedRayCastPhysicsFlag(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasBody(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasComplexAnimTree(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasComponent(UIntPtr pointer, UIntPtr componentPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasDynamicRigidBody(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasDynamicRigidBodyAndActiveSimulation(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasFrameChanged(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasKinematicRigidBody(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasPhysicsBody(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasPhysicsDefinition(UIntPtr entityId, int excludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasScene(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasScriptComponent(UIntPtr entityId, string scName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasScriptComponentHash(UIntPtr entityId, uint scNameHash)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasStaticPhysicsBody(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasTag(UIntPtr entityId, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDynamicBodyStationary(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEngineBodySleeping(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEntitySelectedOnEditor(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFrozen(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsGhostObject(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsGravityDisabled(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsGuidValid(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInEditorScene(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsVisibleIncludeParents(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PauseParticleSystem(UIntPtr entityId, bool doChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PopCapsuleShapeFromEntityBody(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool PrefabExists(string prefabName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PushCapsuleShapeToEntityBody(UIntPtr entityId, Vec3 p1, Vec3 p2, float radius, string physicsMaterialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayHitEntity(UIntPtr entityId, in Vec3 rayOrigin, in Vec3 rayDirection, float maxLength, ref float resultLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayHitEntityWithNormal(UIntPtr entityId, in Vec3 rayOrigin, in Vec3 rayDirection, float maxLength, ref Vec3 resultNormal, ref float resultLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RecomputeBoundingBox(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshMeshesToRenderToHullWater(UIntPtr entityPointer, UIntPtr visualPrefab, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int RegisterWaterSDFClip(UIntPtr entityId, UIntPtr textureID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RelaxLocalBoundingBox(UIntPtr entityId, in BoundingBox boundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseEditDataUserToAllMeshes(UIntPtr entityId, bool entity_components, bool skeleton_components)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Remove(UIntPtr entityId, int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAllChildren(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAllParticleSystems(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveChild(UIntPtr parentEntity, UIntPtr childEntity, bool keepPhysics, bool keepScenePointer, bool callScriptCallbacks, int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveComponent(UIntPtr pointer, UIntPtr componentPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveComponentWithMesh(UIntPtr entityId, UIntPtr mesh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEnginePhysics(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveFromPredisplayEntity(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveJoint(UIntPtr jointId, UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveMultiMesh(UIntPtr entityId, UIntPtr multiMeshPtr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveMultiMeshFromSkeleton(UIntPtr gameEntity, UIntPtr multiMesh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveMultiMeshFromSkeletonBone(UIntPtr gameEntity, UIntPtr multiMesh, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemovePhysics(UIntPtr entityId, bool clearingTheScene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveScriptComponent(UIntPtr entityId, UIntPtr scriptComponentPtr, int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveTag(UIntPtr entityId, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReplacePhysicsBodyWithQuadPhysicsBody(UIntPtr pointer, UIntPtr quad, int physicsMaterial, BodyFlags bodyFlags, int numberOfVertices, UIntPtr indices, int numberOfIndices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetHullWater(UIntPtr visualPrefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResumeParticleSystem(UIntPtr entityId, bool doChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SelectEntityOnEditor(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAlpha(UIntPtr entityId, float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAngularVelocity(UIntPtr entityPtr, in Vec3 newAngularVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnimationSoundActivation(UIntPtr entityId, bool activate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAnimTreeChannelParameter(UIntPtr entityId, float phase, int channel_no)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAsContourEntity(UIntPtr entityId, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAsPredisplayEntity(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAsReplayEntity(UIntPtr gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBodyFlags(UIntPtr entityId, uint bodyFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBodyFlagsRecursive(UIntPtr entityId, uint bodyFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBodyShape(UIntPtr entityId, UIntPtr shape)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBoneFrameToAllMeshes(UIntPtr entityPtr, int boneIndex, in MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBoundingboxDirty(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCenterOfMass(UIntPtr entityId, ref Vec3 localCenterOfMass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClothComponentKeepState(UIntPtr entityId, UIntPtr metaMesh, bool keepState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClothComponentKeepStateOfAllMeshes(UIntPtr entityId, bool keepState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClothMaxDistanceMultiplier(UIntPtr gameEntity, float multiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetColorToAllMeshesWithTagRecursive(UIntPtr gameEntity, uint color, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetContourState(UIntPtr entityId, bool alwaysVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCostAdderForAttachedFaces(UIntPtr entityId, float cost)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCullMode(UIntPtr entityPtr, MBMeshCullingMode cullMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomClipPlane(UIntPtr entityId, Vec3 position, Vec3 normal, bool setForChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomVertexPositionEnabled(UIntPtr entityId, bool customVertexPositionEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDamping(UIntPtr entityId, float linearDamping, float angularDamping)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDoNotCheckVisibility(UIntPtr entityPtr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnforcedMaximumLodLevel(UIntPtr entityId, int lodLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEntityEnvMapVisibility(UIntPtr entityId, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEntityFlags(UIntPtr entityId, EntityFlags entityFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEntityVisibilityFlags(UIntPtr entityId, EntityVisibilityFlags entityVisibilityFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetExternalReferencesUsage(UIntPtr entityId, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFactor2Color(UIntPtr entityId, uint factor2Color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFactorColor(UIntPtr entityId, uint factorColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForceDecalsToRender(UIntPtr entityPtr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForceNotAffectedBySeason(UIntPtr entityPtr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFrameChanged(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlobalFrame(UIntPtr entityId, in MatrixFrame frame, bool isTeleportation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlobalPosition(UIntPtr entityId, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHasCustomBoundingBoxValidationSystem(UIntPtr entityId, bool hasCustomBoundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLinearVelocity(UIntPtr entityPtr, Vec3 newLinearVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLocalFrame(UIntPtr entityId, ref MatrixFrame frame, bool isTeleportation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLocalPosition(UIntPtr entityId, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetManualGlobalBoundingBox(UIntPtr entityId, Vec3 boundingBoxStartGlobal, Vec3 boundingBoxEndGlobal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetManualLocalBoundingBox(UIntPtr entityId, in BoundingBox boundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMassAndUpdateInertiaAndCenterOfMass(UIntPtr entityId, float mass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMassSpaceInertia(UIntPtr entityId, ref Vec3 inertia)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaterialForAllMeshes(UIntPtr entityId, UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaxDepenetrationVelocity(UIntPtr entityId, float maxDepenetrationVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMobility(UIntPtr entityId, GameEntity.Mobility mobility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMorphFrameOfComponents(UIntPtr entityId, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetName(UIntPtr entityId, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNativeScriptComponentVariable(UIntPtr entityPtr, string className, string fieldName, ref ScriptComponentFieldHolder data, RglScriptFieldType variableType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhysicsMoveToBatched(UIntPtr entityId, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhysicsState(UIntPtr entityId, bool isEnabled, bool setChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhysicsStateOnlyVariable(UIntPtr entityId, bool isEnabled, bool setChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPositionsForAttachedNavmeshVertices(UIntPtr entityId, int[] indices, int indexCount, Vec3[] positions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPreviousFrameInvalid(UIntPtr gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetReadyToRender(UIntPtr entityId, bool ready)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRuntimeEmissionRateMultiplier(UIntPtr entityId, float emission_rate_multiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSkeleton(UIntPtr entityId, UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSolverIterationCounts(UIntPtr entityId, int positionIterationCount, int velocityIterationCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetupAdditionalBoneBufferForMeshes(UIntPtr entityPtr, int boneCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpdateValidityOnFrameChangedOfFacesWithId(UIntPtr entityId, int faceGroupId, bool updateValidity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpgradeLevelMask(UIntPtr prefab, uint mask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVectorArgument(UIntPtr entityId, float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVelocityLimits(UIntPtr entityId, float maxLinearVelocity, float maxAngularVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisibilityExcludeParents(UIntPtr entityId, bool visibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisualRecordWakeParams(UIntPtr visualRecord, in Vec3 wakeParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWaterSDFClipData(UIntPtr entityId, int slotIndex, in MatrixFrame frame, bool visibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWaterVisualRecordFrameAndDt(UIntPtr entityPointer, UIntPtr visualPrefab, in MatrixFrame frame, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwapPhysxShapeInEntity(UIntPtr entityPtr, UIntPtr oldShape, UIntPtr newShape, bool isVariable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateAttachedNavigationMeshFaces(UIntPtr entityId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateGlobalBounds(UIntPtr entityPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateHullWaterEffectFrames(UIntPtr entityPointer, UIntPtr visualPrefab)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateTriadFrameForEditor(UIntPtr meshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateVisibilityMask(UIntPtr entityPtr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ValidateBoundingBox(UIntPtr entityPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIGameEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIGameEntity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.SetWaterSDFClipData(UIntPtr entityId, int slotIndex, in MatrixFrame frame, bool visibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.SetGlobalFrame(UIntPtr entityId, in MatrixFrame frame, bool isTeleportation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.ComputeVelocityDeltaFromImpulse(UIntPtr entityPtr, in Vec3 impulsiveForce, in Vec3 impulsiveTorque, out Vec3 deltaLinearVelocity, out Vec3 deltaAngularVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.SetGlobalPosition(UIntPtr entityId, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.SetVisualRecordWakeParams(UIntPtr visualRecord, in Vec3 wakeParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.ChangeResolutionMultiplierOfWaterVisual(UIntPtr visualPrefab, float multiplier, in Vec3 waterEffectsBB)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.SetWaterVisualRecordFrameAndDt(UIntPtr entityPointer, UIntPtr visualPrefab, in MatrixFrame frame, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.AddSplashPositionToWaterVisualRecord(UIntPtr entityPointer, UIntPtr visualPrefab, in Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.GetAttachedNavmeshFaceVertexIndices(UIntPtr entityId, in PathFaceRecord faceRecord, int[] indices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IGameEntity.GetWaterLevelAtPosition(UIntPtr entityId, in Vec2 position, bool useWaterRenderer, bool checkWaterBodyEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IGameEntity.RayHitEntity(UIntPtr entityId, in Vec3 rayOrigin, in Vec3 rayDirection, float maxLength, ref float resultLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IGameEntity.RayHitEntityWithNormal(UIntPtr entityId, in Vec3 rayOrigin, in Vec3 rayDirection, float maxLength, ref Vec3 resultNormal, ref float resultLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.SetManualLocalBoundingBox(UIntPtr entityId, in BoundingBox boundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.RelaxLocalBoundingBox(UIntPtr entityId, in BoundingBox boundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.SetAngularVelocity(UIntPtr entityPtr, in Vec3 newAngularVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IGameEntity.SetBoneFrameToAllMeshes(UIntPtr entityPtr, int boneIndex, in MatrixFrame frame)
	{
		throw null;
	}
}
