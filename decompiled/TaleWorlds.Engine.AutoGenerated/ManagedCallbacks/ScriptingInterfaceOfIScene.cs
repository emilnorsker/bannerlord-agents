using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIScene : IScene
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddAlwaysRenderedSkeletonDelegate(UIntPtr scenePointer, UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddDecalInstanceDelegate(UIntPtr scenePointer, UIntPtr decalMeshPointer, byte[] decalSetID, [MarshalAs(UnmanagedType.U1)] bool deletable);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int AddDirectionalLightDelegate(UIntPtr scenePointer, Vec3 position, Vec3 direction, float radius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddEntityWithMeshDelegate(UIntPtr scenePointer, UIntPtr meshPointer, ref MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddEntityWithMultiMeshDelegate(UIntPtr scenePointer, UIntPtr multiMeshPointer, ref MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer AddItemEntityDelegate(UIntPtr scenePointer, ref MatrixFrame frame, UIntPtr meshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddPathDelegate(UIntPtr scenePointer, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddPathPointDelegate(UIntPtr scenePointer, byte[] name, ref MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int AddPointLightDelegate(UIntPtr scenePointer, Vec3 position, float radius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddWaterWakeWithCapsuleDelegate(UIntPtr scene, Vec3 positionA, float radiusA, Vec3 positionB, float radiusB, float wakeVisibility, float foamVisibility);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool AttachEntityDelegate(UIntPtr scenePointer, UIntPtr entity, [MarshalAs(UnmanagedType.U1)] bool showWarnings);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool BoxCastDelegate(UIntPtr scenePointer, ref Vec3 boxPointBegin, ref Vec3 boxPointEnd, ref Vec3 dir, float distance, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool BoxCastOnlyForCameraDelegate(UIntPtr scenePointer, IntPtr boxPoints, in Vec3 centerPoint, in Vec3 dir, float distance, UIntPtr ignoredEntityPointer, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityPointer, BodyFlags bodyExcludeFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CalculateEffectiveLightingDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckPathEntitiesFrameChangedDelegate(UIntPtr scenePointer, byte[] containsName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool CheckPointCanSeePointDelegate(UIntPtr scenePointer, Vec3 sourcePoint, Vec3 targetPoint, float distanceToCheck);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CheckResourcesDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool checkInvisibleEntities);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearAllDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearCurrentFrameTickEntitiesDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearDecalsDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearNavMeshDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool ContainsTerrainDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CreateBurstParticleDelegate(UIntPtr scene, int particleId, ref MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CreateDynamicRainTextureDelegate(UIntPtr scenePointer, int w, int h);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateNewSceneDelegate([MarshalAs(UnmanagedType.U1)] bool initializePhysics, [MarshalAs(UnmanagedType.U1)] bool enableDecals, int atlasGroup, byte[] sceneName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreatePathMeshDelegate(UIntPtr scenePointer, byte[] baseEntityName, [MarshalAs(UnmanagedType.U1)] bool isWaterPath);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreatePathMesh2Delegate(UIntPtr scenePointer, IntPtr pathNodes, int pathNodeCount, [MarshalAs(UnmanagedType.U1)] bool isWaterPath);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeletePathWithNameDelegate(UIntPtr scenePointer, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeleteWaterWakeRendererDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DeRegisterShipVisualDelegate(UIntPtr scenePointer, UIntPtr visualPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DisableStaticShadowsDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool DoesPathExistBetweenFacesDelegate(UIntPtr scenePointer, int firstNavMeshFace, int secondNavMeshFace, [MarshalAs(UnmanagedType.U1)] bool ignoreDisabled);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool DoesPathExistBetweenPositionsDelegate(UIntPtr scenePointer, WorldPosition position, WorldPosition destination);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnableFixedTickDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnableInclusiveAsyncPhysxDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnsurePostfxSystemDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnsureWaterWakeRendererDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FillEntityWithHardBorderPhysicsBarrierDelegate(UIntPtr scenePointer, UIntPtr entityPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FillTerrainHeightDataDelegate(UIntPtr scene, int xIndex, int yIndex, IntPtr heightArray);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FillTerrainPhysicsMaterialIndexDataDelegate(UIntPtr scene, int xIndex, int yIndex, IntPtr materialIndexArray);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 FindClosestExitPositionForPositionOnABoundaryFaceDelegate(UIntPtr scenePointer, Vec3 position, UIntPtr boundaryNavMeshFacePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FinishSceneSoundsDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool FocusRayCastForFixedPhysicsDelegate(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags, [MarshalAs(UnmanagedType.U1)] bool isFixedWorld);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ForceLoadResourcesDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool checkInvisibleEntities);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GenerateContactsWithCapsuleDelegate(UIntPtr scenePointer, ref CapsuleData cap, BodyFlags excludeFlags, [MarshalAs(UnmanagedType.U1)] bool isFixedTick, IntPtr intersections, IntPtr entityIds);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GenerateContactsWithCapsuleAgainstEntityDelegate(UIntPtr scenePointer, ref CapsuleData cap, BodyFlags excludeFlags, UIntPtr entityId, IntPtr intersections);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAllColorGradeNamesDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetAllEntitiesWithScriptComponentDelegate(UIntPtr scenePointer, byte[] scriptComponentName, UIntPtr output);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAllFilterNamesDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetAllNavmeshFaceRecordsDelegate(UIntPtr scenePointer, IntPtr faceRecords);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoundingBoxDelegate(UIntPtr scenePointer, ref Vec3 min, ref Vec3 max);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBulkWaterLevelAtPositionsDelegate(UIntPtr scene, IntPtr waterHeightQueryArray, int arraySize, IntPtr waterHeightsAtVolumes, IntPtr waterSurfaceNormals);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBulkWaterLevelAtVolumesDelegate(UIntPtr scene, UIntPtr volumeQueryDataArray, int volumeCount, in MatrixFrame entityFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetCampaignEntityWithNameDelegate(UIntPtr scenePointer, byte[] entityName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetEnginePhysicsEnabledDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetEntitiesDelegate(UIntPtr scenePointer, UIntPtr entityObjectsArrayPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetEntityCountDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetEntityWithGuidDelegate(UIntPtr scenePointer, byte[] guid);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetFallDensityDelegate(UIntPtr scenepTR);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetFirstEntityWithNameDelegate(UIntPtr scenePointer, byte[] entityName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetFirstEntityWithScriptComponentDelegate(UIntPtr scenePointer, byte[] scriptComponentName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetFloraInstanceCountDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetFloraRendererTextureUsageDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetFogDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 GetGlobalWindStrengthVectorDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 GetGlobalWindVelocityDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetGroundHeightAndBodyFlagsAtPositionDelegate(UIntPtr scenePointer, Vec3 position, out BodyFlags contactPointFlags, BodyFlags excludeFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetGroundHeightAndNormalAtPositionDelegate(UIntPtr scenePointer, Vec3 position, ref Vec3 normal, uint excludeFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetGroundHeightAtPositionDelegate(UIntPtr scenePointer, Vec3 position, uint excludeFlags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 GetHardBoundaryVertexDelegate(UIntPtr scenePointer, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetHardBoundaryVertexCountDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetHeightAtPointDelegate(UIntPtr scenePointer, Vec2 point, BodyFlags excludeBodyFlags, ref float height);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetIdOfNavMeshFaceDelegate(UIntPtr scenePointer, int navMeshFace);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetInterpolationFactorForBodyWorldTransformSmoothingDelegate(UIntPtr scene, out float interpolationFactor, out float fixedDt);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetLastFinalRenderCameraFrameDelegate(UIntPtr scenePointer, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetLastFinalRenderCameraPositionDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 GetLastPointOnNavigationMeshFromPositionToDestinationDelegate(UIntPtr scenePointer, int startingFace, Vec2 position, Vec2 destination, IntPtr exclusionGroupIds, int exclusionGroupIdsCount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetLastPointOnNavigationMeshFromWorldPositionToDestinationDelegate(UIntPtr scenePointer, ref WorldPosition position, Vec2 destination);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 GetLastPositionOnNavMeshFaceForPointAndDirectionDelegate(UIntPtr scenePointer, in PathFaceRecord record, Vec2 position, Vec2 direction);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetLoadingStateNameDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetModulePathDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNameDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetNavigationMeshCRCDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetNavigationMeshForPositionDelegate(UIntPtr scenePointer, in Vec3 position, ref int faceGroupId, float heightDifferenceLimit, [MarshalAs(UnmanagedType.U1)] bool excludeDynamicNavigationMeshes);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetNavMeshFaceCenterPositionDelegate(UIntPtr scenePointer, int navMeshFace, ref Vec3 centerPos);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNavMeshFaceCountDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNavmeshFaceCountBetweenTwoIdsDelegate(UIntPtr scenePointer, int firstId, int secondId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetNavMeshFaceFirstVertexZDelegate(UIntPtr scenePointer, int navMeshFaceIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetNavMeshFaceIndexDelegate(UIntPtr scenePointer, ref PathFaceRecord record, Vec2 position, [MarshalAs(UnmanagedType.U1)] bool isRegion1, [MarshalAs(UnmanagedType.U1)] bool checkIfDisabled, [MarshalAs(UnmanagedType.U1)] bool ignoreHeight);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetNavMeshFaceIndex3Delegate(UIntPtr scenePointer, ref PathFaceRecord record, Vec3 position, [MarshalAs(UnmanagedType.U1)] bool checkIfDisabled);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetNavmeshFaceRecordsBetweenTwoIdsDelegate(UIntPtr scenePointer, int firstId, int secondId, IntPtr faceRecords);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate PathFaceRecord GetNavMeshPathFaceRecordDelegate(UIntPtr scenePointer, int navMeshFace);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr GetNearestNavigationMeshForPositionDelegate(UIntPtr scenePointer, in Vec3 position, float heightDifferenceLimit, [MarshalAs(UnmanagedType.U1)] bool excludeDynamicNavigationMeshes);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNodeDataCountDelegate(UIntPtr scene, int xIndex, int yIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetNormalAtDelegate(UIntPtr scenePointer, Vec2 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetNorthAngleDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNumberOfPathsWithNamePrefixDelegate(UIntPtr ptr, byte[] prefix);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetPathBetweenAIFaceIndicesDelegate(UIntPtr scenePointer, int startingAiFace, int endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, IntPtr result, ref int pathSize, IntPtr exclusionGroupIds, int exclusionGroupIdsCount, float extraCostMultiplier);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetPathBetweenAIFaceIndicesWithRegionSwitchCostDelegate(UIntPtr scenePointer, int startingAiFace, int endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, IntPtr result, ref int pathSize, IntPtr exclusionGroupIds, int exclusionGroupIdsCount, float extraCostMultiplier, int regionSwitchCostTo0, int regionSwitchCostTo1);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetPathBetweenAIFacePointersDelegate(UIntPtr scenePointer, UIntPtr startingAiFace, UIntPtr endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, IntPtr result, ref int pathSize, IntPtr exclusionGroupIds, int exclusionGroupIdsCount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetPathBetweenAIFacePointersWithRegionSwitchCostDelegate(UIntPtr scenePointer, UIntPtr startingAiFace, UIntPtr endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, IntPtr result, ref int pathSize, IntPtr exclusionGroupIds, int exclusionGroupIdsCount, int regionSwitchCostTo0, int regionSwitchCostTo1);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetPathDistanceBetweenAIFacesDelegate(UIntPtr scenePointer, int startingAiFace, int endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, float distanceLimit, out float distance, IntPtr exclusionGroupIds, int exclusionGroupIdsCount, int regionSwitchCostTo0, int regionSwitchCostTo1);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetPathDistanceBetweenPositionsDelegate(UIntPtr scenePointer, ref WorldPosition position, ref WorldPosition destination, float agentRadius, ref float pathLength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate PathFaceRecord GetPathFaceRecordFromNavMeshFacePointerDelegate(UIntPtr scenePointer, UIntPtr navMeshFacePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetPathsWithNamePrefixDelegate(UIntPtr ptr, IntPtr points, byte[] prefix);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetPathWithNameDelegate(UIntPtr scenePointer, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetPhotoModeFocusDelegate(UIntPtr scene, ref float focus, ref float focusStart, ref float focusEnd, ref float exposure, [MarshalAs(UnmanagedType.U1)] ref bool vignetteOn);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetPhotoModeFovDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetPhotoModeOnDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetPhotoModeOrbitDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetPhotoModeRollDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetPhysicsMinMaxDelegate(UIntPtr scenePointer, ref Vec3 min_max);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetRainDensityDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetRootEntitiesDelegate(UIntPtr scene, UIntPtr output);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetRootEntityCountDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetSceneColorGradeIndexDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetSceneFilterIndexDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetSceneLimitsDelegate(UIntPtr scenePointer, ref Vec3 min, ref Vec3 max);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetSceneXMLCRCDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetScriptedEntityDelegate(UIntPtr scenePointer, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetScriptedEntityCountDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetSkyboxMeshDelegate(UIntPtr ptr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetSnowDensityDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec2 GetSoftBoundaryVertexDelegate(UIntPtr scenePointer, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetSoftBoundaryVertexCountDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetSunDirectionDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetTerrainDataDelegate(UIntPtr scene, out Vec2i nodeDimension, out float nodeSize, out int layerCount, out int layerVersion);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetTerrainHeightDelegate(UIntPtr scenePointer, Vec2 position, [MarshalAs(UnmanagedType.U1)] bool checkHoles);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetTerrainHeightAndNormalDelegate(UIntPtr scenePointer, Vec2 position, out float height, out Vec3 normal);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetTerrainMemoryUsageDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool GetTerrainMinMaxHeightDelegate(UIntPtr scene, ref float min, ref float max);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetTerrainNodeDataDelegate(UIntPtr scene, int xIndex, int yIndex, out int vertexCountAlongAxis, out float quadLength, out float minHeight, out float maxHeight);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetTerrainPhysicsMaterialIndexAtLayerDelegate(UIntPtr scene, int layerIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetTimeOfDayDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetTimeSpeedDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetUpgradeLevelCountDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetUpgradeLevelMaskDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetUpgradeLevelMaskOfLevelNameDelegate(UIntPtr scenePointer, byte[] levelName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetUpgradeLevelNameOfIndexDelegate(UIntPtr scenePointer, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetWaterLevelDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetWaterLevelAtPositionDelegate(UIntPtr scene, Vec2 position, [MarshalAs(UnmanagedType.U1)] bool useWaterRenderer, [MarshalAs(UnmanagedType.U1)] bool checkWaterBodyEntities);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetWaterSpeedAtPositionDelegate(UIntPtr scenePointer, in Vec2 position, [MarshalAs(UnmanagedType.U1)] bool doChoppinessCorrection);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetWaterStrengthDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetWindFlowMapDataDelegate(UIntPtr scenePointer, IntPtr flowmapData);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetWinterTimeFactorDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasDecalRendererDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasNavmeshFaceUnsharedEdgesDelegate(UIntPtr scenePointer, in PathFaceRecord faceRecord);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasTerrainHeightmapDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void InvalidateTerrainPhysicsMaterialsDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsAnyFaceWithIdDelegate(UIntPtr scenePointer, int faceGroupId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsAtmosphereIndoorDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsDefaultEditorSceneDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsEditorSceneDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsLineToPointClearDelegate(UIntPtr scenePointer, int startingFace, Vec2 position, Vec2 destination, float agentRadius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsLineToPointClear2Delegate(UIntPtr scenePointer, UIntPtr startingFace, Vec2 position, Vec2 destination, float agentRadius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsLoadingFinishedDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsMultiplayerSceneDelegate(UIntPtr scene);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsPositionOnADynamicNavMeshDelegate(UIntPtr scenePointer, Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LoadNavMeshPrefabDelegate(UIntPtr scenePointer, byte[] navMeshPrefabName, int navMeshGroupIdShift);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void LoadNavMeshPrefabWithFrameDelegate(UIntPtr scenePointer, byte[] navMeshPrefabName, MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void MarkFacesWithIdAsLadderDelegate(UIntPtr scenePointer, int faceGroupId, [MarshalAs(UnmanagedType.U1)] bool isLadder);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void MergeFacesWithIdDelegate(UIntPtr scenePointer, int faceGroupId0, int faceGroupId1, int newFaceGroupId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void OptimizeSceneDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool optimizeFlora, [MarshalAs(UnmanagedType.U1)] bool optimizeOro);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PauseSceneSoundsDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PreloadForRenderingDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RayCastExcludingTwoEntitiesDelegate(BodyFlags flags, UIntPtr scenePointer, in Ray ray, UIntPtr entity1, UIntPtr entity2);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RayCastForClosestEntityOrTerrainDelegate(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags, [MarshalAs(UnmanagedType.U1)] bool isFixedWorld);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RayCastForClosestEntityOrTerrainIgnoreEntityDelegate(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags, UIntPtr ignoredEntityPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool RayCastForRammingDelegate(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 intersectionPoint, ref UIntPtr intersectedEntityIndex, BodyFlags bodyExcludeFlags, BodyFlags bodyIncludeFlags, UIntPtr ignoredEntityPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReadDelegate(UIntPtr scenePointer, byte[] sceneName, ref SceneInitializationData initData, byte[] forcedAtmoName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReadAndCalculateInitialCameraDelegate(UIntPtr scenePointer, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReadInModuleDelegate(UIntPtr scenePointer, byte[] sceneName, byte[] moduleId, ref SceneInitializationData initData, byte[] forcedAtmoName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate UIntPtr RegisterShipVisualToWaterRendererDelegate(UIntPtr scenePointer, UIntPtr entityPointer, in Vec3 bb);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveAlwaysRenderedSkeletonDelegate(UIntPtr scenePointer, UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveDecalInstanceDelegate(UIntPtr scenePointer, UIntPtr decalMeshPointer, byte[] decalSetID);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveEntityDelegate(UIntPtr scenePointer, UIntPtr entityId, int removeReason);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResumeLoadingRenderingsDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResumeSceneSoundsDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SaveNavMeshPrefabWithFrameDelegate(UIntPtr scenePointer, byte[] navMeshPrefabName, MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool SceneHadWaterWakeRendererDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int SelectEntitiesCollidedWithDelegate(UIntPtr scenePointer, ref Ray ray, IntPtr entityIds, IntPtr intersections);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int SelectEntitiesInBoxWithScriptComponentDelegate(UIntPtr scenePointer, ref Vec3 boundingBoxMin, ref Vec3 boundingBoxMax, IntPtr entitiesOutput, int maxCount, byte[] scriptComponentName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SeparateFacesWithIdDelegate(UIntPtr scenePointer, int faceGroupId0, int faceGroupId1);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAberrationOffsetDelegate(UIntPtr scenePointer, float aberrationOffset);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAberrationSizeDelegate(UIntPtr scenePointer, float aberrationSize);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAberrationSmoothDelegate(UIntPtr scenePointer, float aberrationSmooth);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int SetAbilityOfFacesWithIdDelegate(UIntPtr scenePointer, int faceGroupId, [MarshalAs(UnmanagedType.U1)] bool isEnabled);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetActiveVisibilityLevelsDelegate(UIntPtr scenePointer, byte[] levelsAppended);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAntialiasingModeDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool mode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetAtmosphereWithNameDelegate(UIntPtr ptr, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBloomDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool mode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBloomAmountDelegate(UIntPtr scenePointer, float bloomAmount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBloomStrengthDelegate(UIntPtr scenePointer, float bloomStrength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBrightpassTresholdDelegate(UIntPtr scenePointer, float threshold);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetClothSimulationStateDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool state);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetColorGradeBlendDelegate(UIntPtr scenePointer, byte[] texture1, byte[] texture2, float alpha);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDLSSModeDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool mode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDofFocusDelegate(UIntPtr scenePointer, float dofFocus);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDofModeDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool mode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDofParamsDelegate(UIntPtr scenePointer, float dofFocusStart, float dofFocusEnd, [MarshalAs(UnmanagedType.U1)] bool isVignetteOn);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDoNotAddEntitiesToTickListDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDoNotWaitForLoadingStatesToRenderDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDontLoadInvisibleEntitiesDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDrynessFactorDelegate(UIntPtr scenePointer, float drynessFactor);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDynamicShadowmapCascadesRadiusMultiplierDelegate(UIntPtr scenePointer, float extraRadius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetDynamicSnowTextureDelegate(UIntPtr scenePointer, UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEnvironmentMultiplierDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool useMultiplier, float multiplier);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetExternalInjectionTextureDelegate(UIntPtr scenePointer, UIntPtr texturePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFetchCrcInfoOfSceneDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFixedTickCallbackActiveDelegate(UIntPtr scene, [MarshalAs(UnmanagedType.U1)] bool isActive);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFogDelegate(UIntPtr scenePointer, float fogDensity, ref Vec3 fogColor, float fogFalloff);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFogAdvancedDelegate(UIntPtr scenePointer, float fogFalloffOffset, float fogFalloffMinFog, float fogFalloffStartDist);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFogAmbientColorDelegate(UIntPtr scenePointer, ref Vec3 fogAmbientColor);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetForcedSnowDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetGlobalWindStrengthVectorDelegate(UIntPtr scenePointer, in Vec2 strengthVector);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetGlobalWindVelocityDelegate(UIntPtr scenePointer, in Vec2 windVelocity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetGrainAmountDelegate(UIntPtr scenePointer, float grainAmount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetHexagonVignetteAlphaDelegate(UIntPtr scenePointer, float Alpha);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetHexagonVignetteColorDelegate(UIntPtr scenePointer, ref Vec3 p_hexagon_vignette_color);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetHumidityDelegate(UIntPtr scenePointer, float humidity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLandscapeRainMaskDataDelegate(UIntPtr scenePointer, ManagedArray data);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensDistortionDelegate(UIntPtr scenePointer, float lensDistortion);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareAberrationOffsetDelegate(UIntPtr scenePointer, float lensFlareAberrationOffset);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareAmountDelegate(UIntPtr scenePointer, float lensFlareAmount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareBlurSigmaDelegate(UIntPtr scenePointer, float lensFlareBlurSigma);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareBlurSizeDelegate(UIntPtr scenePointer, int lensFlareBlurSize);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareDiffractionWeightDelegate(UIntPtr scenePointer, float lensFlareDiffractionWeight);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareDirtWeightDelegate(UIntPtr scenePointer, float lensFlareDirtWeight);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareGhostSamplesDelegate(UIntPtr scenePointer, int lensFlareGhostSamples);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareGhostWeightDelegate(UIntPtr scenePointer, float lensFlareGhostWeight);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareHaloWeightDelegate(UIntPtr scenePointer, float lensFlareHaloWeight);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareHaloWidthDelegate(UIntPtr scenePointer, float lensFlareHaloWidth);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareStrengthDelegate(UIntPtr scenePointer, float lensFlareStrength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLensFlareThresholdDelegate(UIntPtr scenePointer, float lensFlareThreshold);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLightDiffuseColorDelegate(UIntPtr scenePointer, int lightIndex, Vec3 diffuseColor);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLightDirectionDelegate(UIntPtr scenePointer, int lightIndex, Vec3 direction);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLightPositionDelegate(UIntPtr scenePointer, int lightIndex, Vec3 position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMaxExposureDelegate(UIntPtr scenePointer, float maxExposure);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMiddleGrayDelegate(UIntPtr scenePointer, float middleGray);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMieScatterFocusDelegate(UIntPtr scenePointer, float strength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMieScatterStrengthDelegate(UIntPtr scenePointer, float strength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMinExposureDelegate(UIntPtr scenePointer, float minExposure);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMotionBlurModeDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool mode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetNameDelegate(UIntPtr scenePointer, byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetNavMeshRegionMapDelegate(UIntPtr scenePointer, IntPtr regionMap, int regionMapSize);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetOcclusionModeDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool mode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetOnCollisionFilterCallbackActiveDelegate(UIntPtr scene, [MarshalAs(UnmanagedType.U1)] bool isActive);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetOwnerThreadDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhotoAtmosphereViaTodDelegate(UIntPtr scenePointer, float tod, [MarshalAs(UnmanagedType.U1)] bool withStorm);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhotoModeFocusDelegate(UIntPtr scene, float focusStart, float focusEnd, float focus, float exposure);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhotoModeFovDelegate(UIntPtr scene, float verticalFov);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhotoModeOnDelegate(UIntPtr scene, [MarshalAs(UnmanagedType.U1)] bool on);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhotoModeOrbitDelegate(UIntPtr scene, [MarshalAs(UnmanagedType.U1)] bool orbit);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhotoModeRollDelegate(UIntPtr scene, float roll);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPhotoModeVignetteDelegate(UIntPtr scene, [MarshalAs(UnmanagedType.U1)] bool vignetteOn);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetPlaySoundEventsAfterReadyToRenderDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetRainDensityDelegate(UIntPtr scenePointer, float density);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSceneColorGradeDelegate(UIntPtr scene, byte[] textureName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSceneColorGradeIndexDelegate(UIntPtr scene, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int SetSceneFilterIndexDelegate(UIntPtr scene, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetShadowDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool shadowEnabled);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSkyBrightnessDelegate(UIntPtr scenePointer, float brightness);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSkyRotationDelegate(UIntPtr scenePointer, float rotation);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSnowDensityDelegate(UIntPtr scenePointer, float density);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetStreakAmountDelegate(UIntPtr scenePointer, float streakAmount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetStreakIntensityDelegate(UIntPtr scenePointer, float stretchAmount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetStreakStrengthDelegate(UIntPtr scenePointer, float strengthAmount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetStreakStretchDelegate(UIntPtr scenePointer, float stretchAmount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetStreakThresholdDelegate(UIntPtr scenePointer, float streakThreshold);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetStreakTintDelegate(UIntPtr scenePointer, ref Vec3 p_streak_tint_color);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSunDelegate(UIntPtr scenePointer, Vec3 color, float altitude, float angle, float intensity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSunAngleAltitudeDelegate(UIntPtr scenePointer, float angle, float altitude);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSunDirectionDelegate(UIntPtr scenePointer, Vec3 direction);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSunLightDelegate(UIntPtr scenePointer, Vec3 color, Vec3 direction);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSunshaftModeDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool mode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSunShaftStrengthDelegate(UIntPtr scenePointer, float strength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSunSizeDelegate(UIntPtr scenePointer, float size);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTargetExposureDelegate(UIntPtr scenePointer, float targetExposure);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTemperatureDelegate(UIntPtr scenePointer, float temperature);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTerrainDynamicParamsDelegate(UIntPtr scenePointer, Vec3 dynamic_params);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTimeOfDayDelegate(UIntPtr scenePointer, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetTimeSpeedDelegate(UIntPtr scenePointer, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetUpgradeLevelDelegate(UIntPtr scenePointer, int level);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetUpgradeLevelVisibilityDelegate(UIntPtr scenePointer, byte[] concatLevels);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetUpgradeLevelVisibilityWithMaskDelegate(UIntPtr scenePointer, uint mask);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetUseConstantTimeDelegate(UIntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetUsesDeleteLaterSystemDelegate(UIntPtr scenePointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVignetteInnerRadiusDelegate(UIntPtr scenePointer, float vignetteInnerRadius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVignetteOpacityDelegate(UIntPtr scenePointer, float vignetteOpacity);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVignetteOuterRadiusDelegate(UIntPtr scenePointer, float vignetteOuterRadius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetWaterStrengthDelegate(UIntPtr scene, float newWaterStrength);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetWaterWakeCameraOffsetDelegate(UIntPtr scenePointer, float cameraOffset);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetWaterWakeWorldSizeDelegate(UIntPtr scenePointer, float worldSize, float eraseFactor);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetWinterTimeFactorDelegate(UIntPtr scenePointer, float winterTimeFactor);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void StallLoadingRenderingsUntilFurtherNoticeDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool SwapFaceConnectionsWithIdDelegate(UIntPtr scenePointer, int hubFaceGroupID, int toBeSeparatedFaceGroupId, int toBeMergedFaceGroupId, [MarshalAs(UnmanagedType.U1)] bool canFail);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int TakePhotoModePictureDelegate(UIntPtr scene, [MarshalAs(UnmanagedType.U1)] bool saveAmbientOcclusionPass, [MarshalAs(UnmanagedType.U1)] bool saveObjectIdPass, [MarshalAs(UnmanagedType.U1)] bool saveShadowPass);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TickDelegate(UIntPtr scenePointer, float deltaTime);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TickWakeDelegate(UIntPtr scenePointer, float dt);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WaitWaterRendererCPUSimulationDelegate(UIntPtr scenePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WorldPositionComputeNearestNavMeshDelegate(ref WorldPosition position);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void WorldPositionValidateZDelegate(ref WorldPosition position, int minimumValidityState);

	private static readonly Encoding _utf8;

	public static AddAlwaysRenderedSkeletonDelegate call_AddAlwaysRenderedSkeletonDelegate;

	public static AddDecalInstanceDelegate call_AddDecalInstanceDelegate;

	public static AddDirectionalLightDelegate call_AddDirectionalLightDelegate;

	public static AddEntityWithMeshDelegate call_AddEntityWithMeshDelegate;

	public static AddEntityWithMultiMeshDelegate call_AddEntityWithMultiMeshDelegate;

	public static AddItemEntityDelegate call_AddItemEntityDelegate;

	public static AddPathDelegate call_AddPathDelegate;

	public static AddPathPointDelegate call_AddPathPointDelegate;

	public static AddPointLightDelegate call_AddPointLightDelegate;

	public static AddWaterWakeWithCapsuleDelegate call_AddWaterWakeWithCapsuleDelegate;

	public static AttachEntityDelegate call_AttachEntityDelegate;

	public static BoxCastDelegate call_BoxCastDelegate;

	public static BoxCastOnlyForCameraDelegate call_BoxCastOnlyForCameraDelegate;

	public static CalculateEffectiveLightingDelegate call_CalculateEffectiveLightingDelegate;

	public static CheckPathEntitiesFrameChangedDelegate call_CheckPathEntitiesFrameChangedDelegate;

	public static CheckPointCanSeePointDelegate call_CheckPointCanSeePointDelegate;

	public static CheckResourcesDelegate call_CheckResourcesDelegate;

	public static ClearAllDelegate call_ClearAllDelegate;

	public static ClearCurrentFrameTickEntitiesDelegate call_ClearCurrentFrameTickEntitiesDelegate;

	public static ClearDecalsDelegate call_ClearDecalsDelegate;

	public static ClearNavMeshDelegate call_ClearNavMeshDelegate;

	public static ContainsTerrainDelegate call_ContainsTerrainDelegate;

	public static CreateBurstParticleDelegate call_CreateBurstParticleDelegate;

	public static CreateDynamicRainTextureDelegate call_CreateDynamicRainTextureDelegate;

	public static CreateNewSceneDelegate call_CreateNewSceneDelegate;

	public static CreatePathMeshDelegate call_CreatePathMeshDelegate;

	public static CreatePathMesh2Delegate call_CreatePathMesh2Delegate;

	public static DeletePathWithNameDelegate call_DeletePathWithNameDelegate;

	public static DeleteWaterWakeRendererDelegate call_DeleteWaterWakeRendererDelegate;

	public static DeRegisterShipVisualDelegate call_DeRegisterShipVisualDelegate;

	public static DisableStaticShadowsDelegate call_DisableStaticShadowsDelegate;

	public static DoesPathExistBetweenFacesDelegate call_DoesPathExistBetweenFacesDelegate;

	public static DoesPathExistBetweenPositionsDelegate call_DoesPathExistBetweenPositionsDelegate;

	public static EnableFixedTickDelegate call_EnableFixedTickDelegate;

	public static EnableInclusiveAsyncPhysxDelegate call_EnableInclusiveAsyncPhysxDelegate;

	public static EnsurePostfxSystemDelegate call_EnsurePostfxSystemDelegate;

	public static EnsureWaterWakeRendererDelegate call_EnsureWaterWakeRendererDelegate;

	public static FillEntityWithHardBorderPhysicsBarrierDelegate call_FillEntityWithHardBorderPhysicsBarrierDelegate;

	public static FillTerrainHeightDataDelegate call_FillTerrainHeightDataDelegate;

	public static FillTerrainPhysicsMaterialIndexDataDelegate call_FillTerrainPhysicsMaterialIndexDataDelegate;

	public static FindClosestExitPositionForPositionOnABoundaryFaceDelegate call_FindClosestExitPositionForPositionOnABoundaryFaceDelegate;

	public static FinishSceneSoundsDelegate call_FinishSceneSoundsDelegate;

	public static FocusRayCastForFixedPhysicsDelegate call_FocusRayCastForFixedPhysicsDelegate;

	public static ForceLoadResourcesDelegate call_ForceLoadResourcesDelegate;

	public static GenerateContactsWithCapsuleDelegate call_GenerateContactsWithCapsuleDelegate;

	public static GenerateContactsWithCapsuleAgainstEntityDelegate call_GenerateContactsWithCapsuleAgainstEntityDelegate;

	public static GetAllColorGradeNamesDelegate call_GetAllColorGradeNamesDelegate;

	public static GetAllEntitiesWithScriptComponentDelegate call_GetAllEntitiesWithScriptComponentDelegate;

	public static GetAllFilterNamesDelegate call_GetAllFilterNamesDelegate;

	public static GetAllNavmeshFaceRecordsDelegate call_GetAllNavmeshFaceRecordsDelegate;

	public static GetBoundingBoxDelegate call_GetBoundingBoxDelegate;

	public static GetBulkWaterLevelAtPositionsDelegate call_GetBulkWaterLevelAtPositionsDelegate;

	public static GetBulkWaterLevelAtVolumesDelegate call_GetBulkWaterLevelAtVolumesDelegate;

	public static GetCampaignEntityWithNameDelegate call_GetCampaignEntityWithNameDelegate;

	public static GetEnginePhysicsEnabledDelegate call_GetEnginePhysicsEnabledDelegate;

	public static GetEntitiesDelegate call_GetEntitiesDelegate;

	public static GetEntityCountDelegate call_GetEntityCountDelegate;

	public static GetEntityWithGuidDelegate call_GetEntityWithGuidDelegate;

	public static GetFallDensityDelegate call_GetFallDensityDelegate;

	public static GetFirstEntityWithNameDelegate call_GetFirstEntityWithNameDelegate;

	public static GetFirstEntityWithScriptComponentDelegate call_GetFirstEntityWithScriptComponentDelegate;

	public static GetFloraInstanceCountDelegate call_GetFloraInstanceCountDelegate;

	public static GetFloraRendererTextureUsageDelegate call_GetFloraRendererTextureUsageDelegate;

	public static GetFogDelegate call_GetFogDelegate;

	public static GetGlobalWindStrengthVectorDelegate call_GetGlobalWindStrengthVectorDelegate;

	public static GetGlobalWindVelocityDelegate call_GetGlobalWindVelocityDelegate;

	public static GetGroundHeightAndBodyFlagsAtPositionDelegate call_GetGroundHeightAndBodyFlagsAtPositionDelegate;

	public static GetGroundHeightAndNormalAtPositionDelegate call_GetGroundHeightAndNormalAtPositionDelegate;

	public static GetGroundHeightAtPositionDelegate call_GetGroundHeightAtPositionDelegate;

	public static GetHardBoundaryVertexDelegate call_GetHardBoundaryVertexDelegate;

	public static GetHardBoundaryVertexCountDelegate call_GetHardBoundaryVertexCountDelegate;

	public static GetHeightAtPointDelegate call_GetHeightAtPointDelegate;

	public static GetIdOfNavMeshFaceDelegate call_GetIdOfNavMeshFaceDelegate;

	public static GetInterpolationFactorForBodyWorldTransformSmoothingDelegate call_GetInterpolationFactorForBodyWorldTransformSmoothingDelegate;

	public static GetLastFinalRenderCameraFrameDelegate call_GetLastFinalRenderCameraFrameDelegate;

	public static GetLastFinalRenderCameraPositionDelegate call_GetLastFinalRenderCameraPositionDelegate;

	public static GetLastPointOnNavigationMeshFromPositionToDestinationDelegate call_GetLastPointOnNavigationMeshFromPositionToDestinationDelegate;

	public static GetLastPointOnNavigationMeshFromWorldPositionToDestinationDelegate call_GetLastPointOnNavigationMeshFromWorldPositionToDestinationDelegate;

	public static GetLastPositionOnNavMeshFaceForPointAndDirectionDelegate call_GetLastPositionOnNavMeshFaceForPointAndDirectionDelegate;

	public static GetLoadingStateNameDelegate call_GetLoadingStateNameDelegate;

	public static GetModulePathDelegate call_GetModulePathDelegate;

	public static GetNameDelegate call_GetNameDelegate;

	public static GetNavigationMeshCRCDelegate call_GetNavigationMeshCRCDelegate;

	public static GetNavigationMeshForPositionDelegate call_GetNavigationMeshForPositionDelegate;

	public static GetNavMeshFaceCenterPositionDelegate call_GetNavMeshFaceCenterPositionDelegate;

	public static GetNavMeshFaceCountDelegate call_GetNavMeshFaceCountDelegate;

	public static GetNavmeshFaceCountBetweenTwoIdsDelegate call_GetNavmeshFaceCountBetweenTwoIdsDelegate;

	public static GetNavMeshFaceFirstVertexZDelegate call_GetNavMeshFaceFirstVertexZDelegate;

	public static GetNavMeshFaceIndexDelegate call_GetNavMeshFaceIndexDelegate;

	public static GetNavMeshFaceIndex3Delegate call_GetNavMeshFaceIndex3Delegate;

	public static GetNavmeshFaceRecordsBetweenTwoIdsDelegate call_GetNavmeshFaceRecordsBetweenTwoIdsDelegate;

	public static GetNavMeshPathFaceRecordDelegate call_GetNavMeshPathFaceRecordDelegate;

	public static GetNearestNavigationMeshForPositionDelegate call_GetNearestNavigationMeshForPositionDelegate;

	public static GetNodeDataCountDelegate call_GetNodeDataCountDelegate;

	public static GetNormalAtDelegate call_GetNormalAtDelegate;

	public static GetNorthAngleDelegate call_GetNorthAngleDelegate;

	public static GetNumberOfPathsWithNamePrefixDelegate call_GetNumberOfPathsWithNamePrefixDelegate;

	public static GetPathBetweenAIFaceIndicesDelegate call_GetPathBetweenAIFaceIndicesDelegate;

	public static GetPathBetweenAIFaceIndicesWithRegionSwitchCostDelegate call_GetPathBetweenAIFaceIndicesWithRegionSwitchCostDelegate;

	public static GetPathBetweenAIFacePointersDelegate call_GetPathBetweenAIFacePointersDelegate;

	public static GetPathBetweenAIFacePointersWithRegionSwitchCostDelegate call_GetPathBetweenAIFacePointersWithRegionSwitchCostDelegate;

	public static GetPathDistanceBetweenAIFacesDelegate call_GetPathDistanceBetweenAIFacesDelegate;

	public static GetPathDistanceBetweenPositionsDelegate call_GetPathDistanceBetweenPositionsDelegate;

	public static GetPathFaceRecordFromNavMeshFacePointerDelegate call_GetPathFaceRecordFromNavMeshFacePointerDelegate;

	public static GetPathsWithNamePrefixDelegate call_GetPathsWithNamePrefixDelegate;

	public static GetPathWithNameDelegate call_GetPathWithNameDelegate;

	public static GetPhotoModeFocusDelegate call_GetPhotoModeFocusDelegate;

	public static GetPhotoModeFovDelegate call_GetPhotoModeFovDelegate;

	public static GetPhotoModeOnDelegate call_GetPhotoModeOnDelegate;

	public static GetPhotoModeOrbitDelegate call_GetPhotoModeOrbitDelegate;

	public static GetPhotoModeRollDelegate call_GetPhotoModeRollDelegate;

	public static GetPhysicsMinMaxDelegate call_GetPhysicsMinMaxDelegate;

	public static GetRainDensityDelegate call_GetRainDensityDelegate;

	public static GetRootEntitiesDelegate call_GetRootEntitiesDelegate;

	public static GetRootEntityCountDelegate call_GetRootEntityCountDelegate;

	public static GetSceneColorGradeIndexDelegate call_GetSceneColorGradeIndexDelegate;

	public static GetSceneFilterIndexDelegate call_GetSceneFilterIndexDelegate;

	public static GetSceneLimitsDelegate call_GetSceneLimitsDelegate;

	public static GetSceneXMLCRCDelegate call_GetSceneXMLCRCDelegate;

	public static GetScriptedEntityDelegate call_GetScriptedEntityDelegate;

	public static GetScriptedEntityCountDelegate call_GetScriptedEntityCountDelegate;

	public static GetSkyboxMeshDelegate call_GetSkyboxMeshDelegate;

	public static GetSnowDensityDelegate call_GetSnowDensityDelegate;

	public static GetSoftBoundaryVertexDelegate call_GetSoftBoundaryVertexDelegate;

	public static GetSoftBoundaryVertexCountDelegate call_GetSoftBoundaryVertexCountDelegate;

	public static GetSunDirectionDelegate call_GetSunDirectionDelegate;

	public static GetTerrainDataDelegate call_GetTerrainDataDelegate;

	public static GetTerrainHeightDelegate call_GetTerrainHeightDelegate;

	public static GetTerrainHeightAndNormalDelegate call_GetTerrainHeightAndNormalDelegate;

	public static GetTerrainMemoryUsageDelegate call_GetTerrainMemoryUsageDelegate;

	public static GetTerrainMinMaxHeightDelegate call_GetTerrainMinMaxHeightDelegate;

	public static GetTerrainNodeDataDelegate call_GetTerrainNodeDataDelegate;

	public static GetTerrainPhysicsMaterialIndexAtLayerDelegate call_GetTerrainPhysicsMaterialIndexAtLayerDelegate;

	public static GetTimeOfDayDelegate call_GetTimeOfDayDelegate;

	public static GetTimeSpeedDelegate call_GetTimeSpeedDelegate;

	public static GetUpgradeLevelCountDelegate call_GetUpgradeLevelCountDelegate;

	public static GetUpgradeLevelMaskDelegate call_GetUpgradeLevelMaskDelegate;

	public static GetUpgradeLevelMaskOfLevelNameDelegate call_GetUpgradeLevelMaskOfLevelNameDelegate;

	public static GetUpgradeLevelNameOfIndexDelegate call_GetUpgradeLevelNameOfIndexDelegate;

	public static GetWaterLevelDelegate call_GetWaterLevelDelegate;

	public static GetWaterLevelAtPositionDelegate call_GetWaterLevelAtPositionDelegate;

	public static GetWaterSpeedAtPositionDelegate call_GetWaterSpeedAtPositionDelegate;

	public static GetWaterStrengthDelegate call_GetWaterStrengthDelegate;

	public static GetWindFlowMapDataDelegate call_GetWindFlowMapDataDelegate;

	public static GetWinterTimeFactorDelegate call_GetWinterTimeFactorDelegate;

	public static HasDecalRendererDelegate call_HasDecalRendererDelegate;

	public static HasNavmeshFaceUnsharedEdgesDelegate call_HasNavmeshFaceUnsharedEdgesDelegate;

	public static HasTerrainHeightmapDelegate call_HasTerrainHeightmapDelegate;

	public static InvalidateTerrainPhysicsMaterialsDelegate call_InvalidateTerrainPhysicsMaterialsDelegate;

	public static IsAnyFaceWithIdDelegate call_IsAnyFaceWithIdDelegate;

	public static IsAtmosphereIndoorDelegate call_IsAtmosphereIndoorDelegate;

	public static IsDefaultEditorSceneDelegate call_IsDefaultEditorSceneDelegate;

	public static IsEditorSceneDelegate call_IsEditorSceneDelegate;

	public static IsLineToPointClearDelegate call_IsLineToPointClearDelegate;

	public static IsLineToPointClear2Delegate call_IsLineToPointClear2Delegate;

	public static IsLoadingFinishedDelegate call_IsLoadingFinishedDelegate;

	public static IsMultiplayerSceneDelegate call_IsMultiplayerSceneDelegate;

	public static IsPositionOnADynamicNavMeshDelegate call_IsPositionOnADynamicNavMeshDelegate;

	public static LoadNavMeshPrefabDelegate call_LoadNavMeshPrefabDelegate;

	public static LoadNavMeshPrefabWithFrameDelegate call_LoadNavMeshPrefabWithFrameDelegate;

	public static MarkFacesWithIdAsLadderDelegate call_MarkFacesWithIdAsLadderDelegate;

	public static MergeFacesWithIdDelegate call_MergeFacesWithIdDelegate;

	public static OptimizeSceneDelegate call_OptimizeSceneDelegate;

	public static PauseSceneSoundsDelegate call_PauseSceneSoundsDelegate;

	public static PreloadForRenderingDelegate call_PreloadForRenderingDelegate;

	public static RayCastExcludingTwoEntitiesDelegate call_RayCastExcludingTwoEntitiesDelegate;

	public static RayCastForClosestEntityOrTerrainDelegate call_RayCastForClosestEntityOrTerrainDelegate;

	public static RayCastForClosestEntityOrTerrainIgnoreEntityDelegate call_RayCastForClosestEntityOrTerrainIgnoreEntityDelegate;

	public static RayCastForRammingDelegate call_RayCastForRammingDelegate;

	public static ReadDelegate call_ReadDelegate;

	public static ReadAndCalculateInitialCameraDelegate call_ReadAndCalculateInitialCameraDelegate;

	public static ReadInModuleDelegate call_ReadInModuleDelegate;

	public static RegisterShipVisualToWaterRendererDelegate call_RegisterShipVisualToWaterRendererDelegate;

	public static RemoveAlwaysRenderedSkeletonDelegate call_RemoveAlwaysRenderedSkeletonDelegate;

	public static RemoveDecalInstanceDelegate call_RemoveDecalInstanceDelegate;

	public static RemoveEntityDelegate call_RemoveEntityDelegate;

	public static ResumeLoadingRenderingsDelegate call_ResumeLoadingRenderingsDelegate;

	public static ResumeSceneSoundsDelegate call_ResumeSceneSoundsDelegate;

	public static SaveNavMeshPrefabWithFrameDelegate call_SaveNavMeshPrefabWithFrameDelegate;

	public static SceneHadWaterWakeRendererDelegate call_SceneHadWaterWakeRendererDelegate;

	public static SelectEntitiesCollidedWithDelegate call_SelectEntitiesCollidedWithDelegate;

	public static SelectEntitiesInBoxWithScriptComponentDelegate call_SelectEntitiesInBoxWithScriptComponentDelegate;

	public static SeparateFacesWithIdDelegate call_SeparateFacesWithIdDelegate;

	public static SetAberrationOffsetDelegate call_SetAberrationOffsetDelegate;

	public static SetAberrationSizeDelegate call_SetAberrationSizeDelegate;

	public static SetAberrationSmoothDelegate call_SetAberrationSmoothDelegate;

	public static SetAbilityOfFacesWithIdDelegate call_SetAbilityOfFacesWithIdDelegate;

	public static SetActiveVisibilityLevelsDelegate call_SetActiveVisibilityLevelsDelegate;

	public static SetAntialiasingModeDelegate call_SetAntialiasingModeDelegate;

	public static SetAtmosphereWithNameDelegate call_SetAtmosphereWithNameDelegate;

	public static SetBloomDelegate call_SetBloomDelegate;

	public static SetBloomAmountDelegate call_SetBloomAmountDelegate;

	public static SetBloomStrengthDelegate call_SetBloomStrengthDelegate;

	public static SetBrightpassTresholdDelegate call_SetBrightpassTresholdDelegate;

	public static SetClothSimulationStateDelegate call_SetClothSimulationStateDelegate;

	public static SetColorGradeBlendDelegate call_SetColorGradeBlendDelegate;

	public static SetDLSSModeDelegate call_SetDLSSModeDelegate;

	public static SetDofFocusDelegate call_SetDofFocusDelegate;

	public static SetDofModeDelegate call_SetDofModeDelegate;

	public static SetDofParamsDelegate call_SetDofParamsDelegate;

	public static SetDoNotAddEntitiesToTickListDelegate call_SetDoNotAddEntitiesToTickListDelegate;

	public static SetDoNotWaitForLoadingStatesToRenderDelegate call_SetDoNotWaitForLoadingStatesToRenderDelegate;

	public static SetDontLoadInvisibleEntitiesDelegate call_SetDontLoadInvisibleEntitiesDelegate;

	public static SetDrynessFactorDelegate call_SetDrynessFactorDelegate;

	public static SetDynamicShadowmapCascadesRadiusMultiplierDelegate call_SetDynamicShadowmapCascadesRadiusMultiplierDelegate;

	public static SetDynamicSnowTextureDelegate call_SetDynamicSnowTextureDelegate;

	public static SetEnvironmentMultiplierDelegate call_SetEnvironmentMultiplierDelegate;

	public static SetExternalInjectionTextureDelegate call_SetExternalInjectionTextureDelegate;

	public static SetFetchCrcInfoOfSceneDelegate call_SetFetchCrcInfoOfSceneDelegate;

	public static SetFixedTickCallbackActiveDelegate call_SetFixedTickCallbackActiveDelegate;

	public static SetFogDelegate call_SetFogDelegate;

	public static SetFogAdvancedDelegate call_SetFogAdvancedDelegate;

	public static SetFogAmbientColorDelegate call_SetFogAmbientColorDelegate;

	public static SetForcedSnowDelegate call_SetForcedSnowDelegate;

	public static SetGlobalWindStrengthVectorDelegate call_SetGlobalWindStrengthVectorDelegate;

	public static SetGlobalWindVelocityDelegate call_SetGlobalWindVelocityDelegate;

	public static SetGrainAmountDelegate call_SetGrainAmountDelegate;

	public static SetHexagonVignetteAlphaDelegate call_SetHexagonVignetteAlphaDelegate;

	public static SetHexagonVignetteColorDelegate call_SetHexagonVignetteColorDelegate;

	public static SetHumidityDelegate call_SetHumidityDelegate;

	public static SetLandscapeRainMaskDataDelegate call_SetLandscapeRainMaskDataDelegate;

	public static SetLensDistortionDelegate call_SetLensDistortionDelegate;

	public static SetLensFlareAberrationOffsetDelegate call_SetLensFlareAberrationOffsetDelegate;

	public static SetLensFlareAmountDelegate call_SetLensFlareAmountDelegate;

	public static SetLensFlareBlurSigmaDelegate call_SetLensFlareBlurSigmaDelegate;

	public static SetLensFlareBlurSizeDelegate call_SetLensFlareBlurSizeDelegate;

	public static SetLensFlareDiffractionWeightDelegate call_SetLensFlareDiffractionWeightDelegate;

	public static SetLensFlareDirtWeightDelegate call_SetLensFlareDirtWeightDelegate;

	public static SetLensFlareGhostSamplesDelegate call_SetLensFlareGhostSamplesDelegate;

	public static SetLensFlareGhostWeightDelegate call_SetLensFlareGhostWeightDelegate;

	public static SetLensFlareHaloWeightDelegate call_SetLensFlareHaloWeightDelegate;

	public static SetLensFlareHaloWidthDelegate call_SetLensFlareHaloWidthDelegate;

	public static SetLensFlareStrengthDelegate call_SetLensFlareStrengthDelegate;

	public static SetLensFlareThresholdDelegate call_SetLensFlareThresholdDelegate;

	public static SetLightDiffuseColorDelegate call_SetLightDiffuseColorDelegate;

	public static SetLightDirectionDelegate call_SetLightDirectionDelegate;

	public static SetLightPositionDelegate call_SetLightPositionDelegate;

	public static SetMaxExposureDelegate call_SetMaxExposureDelegate;

	public static SetMiddleGrayDelegate call_SetMiddleGrayDelegate;

	public static SetMieScatterFocusDelegate call_SetMieScatterFocusDelegate;

	public static SetMieScatterStrengthDelegate call_SetMieScatterStrengthDelegate;

	public static SetMinExposureDelegate call_SetMinExposureDelegate;

	public static SetMotionBlurModeDelegate call_SetMotionBlurModeDelegate;

	public static SetNameDelegate call_SetNameDelegate;

	public static SetNavMeshRegionMapDelegate call_SetNavMeshRegionMapDelegate;

	public static SetOcclusionModeDelegate call_SetOcclusionModeDelegate;

	public static SetOnCollisionFilterCallbackActiveDelegate call_SetOnCollisionFilterCallbackActiveDelegate;

	public static SetOwnerThreadDelegate call_SetOwnerThreadDelegate;

	public static SetPhotoAtmosphereViaTodDelegate call_SetPhotoAtmosphereViaTodDelegate;

	public static SetPhotoModeFocusDelegate call_SetPhotoModeFocusDelegate;

	public static SetPhotoModeFovDelegate call_SetPhotoModeFovDelegate;

	public static SetPhotoModeOnDelegate call_SetPhotoModeOnDelegate;

	public static SetPhotoModeOrbitDelegate call_SetPhotoModeOrbitDelegate;

	public static SetPhotoModeRollDelegate call_SetPhotoModeRollDelegate;

	public static SetPhotoModeVignetteDelegate call_SetPhotoModeVignetteDelegate;

	public static SetPlaySoundEventsAfterReadyToRenderDelegate call_SetPlaySoundEventsAfterReadyToRenderDelegate;

	public static SetRainDensityDelegate call_SetRainDensityDelegate;

	public static SetSceneColorGradeDelegate call_SetSceneColorGradeDelegate;

	public static SetSceneColorGradeIndexDelegate call_SetSceneColorGradeIndexDelegate;

	public static SetSceneFilterIndexDelegate call_SetSceneFilterIndexDelegate;

	public static SetShadowDelegate call_SetShadowDelegate;

	public static SetSkyBrightnessDelegate call_SetSkyBrightnessDelegate;

	public static SetSkyRotationDelegate call_SetSkyRotationDelegate;

	public static SetSnowDensityDelegate call_SetSnowDensityDelegate;

	public static SetStreakAmountDelegate call_SetStreakAmountDelegate;

	public static SetStreakIntensityDelegate call_SetStreakIntensityDelegate;

	public static SetStreakStrengthDelegate call_SetStreakStrengthDelegate;

	public static SetStreakStretchDelegate call_SetStreakStretchDelegate;

	public static SetStreakThresholdDelegate call_SetStreakThresholdDelegate;

	public static SetStreakTintDelegate call_SetStreakTintDelegate;

	public static SetSunDelegate call_SetSunDelegate;

	public static SetSunAngleAltitudeDelegate call_SetSunAngleAltitudeDelegate;

	public static SetSunDirectionDelegate call_SetSunDirectionDelegate;

	public static SetSunLightDelegate call_SetSunLightDelegate;

	public static SetSunshaftModeDelegate call_SetSunshaftModeDelegate;

	public static SetSunShaftStrengthDelegate call_SetSunShaftStrengthDelegate;

	public static SetSunSizeDelegate call_SetSunSizeDelegate;

	public static SetTargetExposureDelegate call_SetTargetExposureDelegate;

	public static SetTemperatureDelegate call_SetTemperatureDelegate;

	public static SetTerrainDynamicParamsDelegate call_SetTerrainDynamicParamsDelegate;

	public static SetTimeOfDayDelegate call_SetTimeOfDayDelegate;

	public static SetTimeSpeedDelegate call_SetTimeSpeedDelegate;

	public static SetUpgradeLevelDelegate call_SetUpgradeLevelDelegate;

	public static SetUpgradeLevelVisibilityDelegate call_SetUpgradeLevelVisibilityDelegate;

	public static SetUpgradeLevelVisibilityWithMaskDelegate call_SetUpgradeLevelVisibilityWithMaskDelegate;

	public static SetUseConstantTimeDelegate call_SetUseConstantTimeDelegate;

	public static SetUsesDeleteLaterSystemDelegate call_SetUsesDeleteLaterSystemDelegate;

	public static SetVignetteInnerRadiusDelegate call_SetVignetteInnerRadiusDelegate;

	public static SetVignetteOpacityDelegate call_SetVignetteOpacityDelegate;

	public static SetVignetteOuterRadiusDelegate call_SetVignetteOuterRadiusDelegate;

	public static SetWaterStrengthDelegate call_SetWaterStrengthDelegate;

	public static SetWaterWakeCameraOffsetDelegate call_SetWaterWakeCameraOffsetDelegate;

	public static SetWaterWakeWorldSizeDelegate call_SetWaterWakeWorldSizeDelegate;

	public static SetWinterTimeFactorDelegate call_SetWinterTimeFactorDelegate;

	public static StallLoadingRenderingsUntilFurtherNoticeDelegate call_StallLoadingRenderingsUntilFurtherNoticeDelegate;

	public static SwapFaceConnectionsWithIdDelegate call_SwapFaceConnectionsWithIdDelegate;

	public static TakePhotoModePictureDelegate call_TakePhotoModePictureDelegate;

	public static TickDelegate call_TickDelegate;

	public static TickWakeDelegate call_TickWakeDelegate;

	public static WaitWaterRendererCPUSimulationDelegate call_WaitWaterRendererCPUSimulationDelegate;

	public static WorldPositionComputeNearestNavMeshDelegate call_WorldPositionComputeNearestNavMeshDelegate;

	public static WorldPositionValidateZDelegate call_WorldPositionValidateZDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAlwaysRenderedSkeleton(UIntPtr scenePointer, UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddDecalInstance(UIntPtr scenePointer, UIntPtr decalMeshPointer, string decalSetID, bool deletable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddDirectionalLight(UIntPtr scenePointer, Vec3 position, Vec3 direction, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEntityWithMesh(UIntPtr scenePointer, UIntPtr meshPointer, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEntityWithMultiMesh(UIntPtr scenePointer, UIntPtr multiMeshPointer, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity AddItemEntity(UIntPtr scenePointer, ref MatrixFrame frame, UIntPtr meshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPath(UIntPtr scenePointer, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPathPoint(UIntPtr scenePointer, string name, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddPointLight(UIntPtr scenePointer, Vec3 position, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddWaterWakeWithCapsule(Scene scene, Vec3 positionA, float radiusA, Vec3 positionB, float radiusB, float wakeVisibility, float foamVisibility)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool AttachEntity(UIntPtr scenePointer, UIntPtr entity, bool showWarnings)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool BoxCast(UIntPtr scenePointer, ref Vec3 boxPointBegin, ref Vec3 boxPointEnd, ref Vec3 dir, float distance, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool BoxCastOnlyForCamera(UIntPtr scenePointer, Vec3[] boxPoints, in Vec3 centerPoint, in Vec3 dir, float distance, UIntPtr ignoredEntityPointer, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityPointer, BodyFlags bodyExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CalculateEffectiveLighting(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckPathEntitiesFrameChanged(UIntPtr scenePointer, string containsName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckPointCanSeePoint(UIntPtr scenePointer, Vec3 sourcePoint, Vec3 targetPoint, float distanceToCheck)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckResources(UIntPtr scenePointer, bool checkInvisibleEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAll(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearCurrentFrameTickEntities(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearDecals(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearNavMesh(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsTerrain(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateBurstParticle(Scene scene, int particleId, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateDynamicRainTexture(UIntPtr scenePointer, int w, int h)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Scene CreateNewScene(bool initializePhysics, bool enableDecals, int atlasGroup, string sceneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh CreatePathMesh(UIntPtr scenePointer, string baseEntityName, bool isWaterPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh CreatePathMesh2(UIntPtr scenePointer, UIntPtr[] pathNodes, int pathNodeCount, bool isWaterPath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeletePathWithName(UIntPtr scenePointer, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeleteWaterWakeRenderer(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeRegisterShipVisual(UIntPtr scenePointer, UIntPtr visualPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableStaticShadows(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoesPathExistBetweenFaces(UIntPtr scenePointer, int firstNavMeshFace, int secondNavMeshFace, bool ignoreDisabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool DoesPathExistBetweenPositions(UIntPtr scenePointer, WorldPosition position, WorldPosition destination)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableFixedTick(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableInclusiveAsyncPhysx(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnsurePostfxSystem(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnsureWaterWakeRenderer(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillEntityWithHardBorderPhysicsBarrier(UIntPtr scenePointer, UIntPtr entityPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillTerrainHeightData(Scene scene, int xIndex, int yIndex, float[] heightArray)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillTerrainPhysicsMaterialIndexData(Scene scene, int xIndex, int yIndex, short[] materialIndexArray)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 FindClosestExitPositionForPositionOnABoundaryFace(UIntPtr scenePointer, Vec3 position, UIntPtr boundaryNavMeshFacePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinishSceneSounds(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool FocusRayCastForFixedPhysics(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags, bool isFixedWorld)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceLoadResources(UIntPtr scenePointer, bool checkInvisibleEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GenerateContactsWithCapsule(UIntPtr scenePointer, ref CapsuleData cap, BodyFlags excludeFlags, bool isFixedTick, Intersection[] intersections, UIntPtr[] entityIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GenerateContactsWithCapsuleAgainstEntity(UIntPtr scenePointer, ref CapsuleData cap, BodyFlags excludeFlags, UIntPtr entityId, Intersection[] intersections)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAllColorGradeNames(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAllEntitiesWithScriptComponent(UIntPtr scenePointer, string scriptComponentName, UIntPtr output)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAllFilterNames(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAllNavmeshFaceRecords(UIntPtr scenePointer, PathFaceRecord[] faceRecords)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoundingBox(UIntPtr scenePointer, ref Vec3 min, ref Vec3 max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBulkWaterLevelAtPositions(Scene scene, Vec2[] waterHeightQueryArray, int arraySize, float[] waterHeightsAtVolumes, Vec3[] waterSurfaceNormals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBulkWaterLevelAtVolumes(UIntPtr scene, UIntPtr volumeQueryDataArray, int volumeCount, in MatrixFrame entityFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetCampaignEntityWithName(UIntPtr scenePointer, string entityName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetEnginePhysicsEnabled(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetEntities(UIntPtr scenePointer, UIntPtr entityObjectsArrayPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetEntityCount(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetEntityWithGuid(UIntPtr scenePointer, string guid)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFallDensity(UIntPtr scenepTR)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetFirstEntityWithName(UIntPtr scenePointer, string entityName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetFirstEntityWithScriptComponent(UIntPtr scenePointer, string scriptComponentName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFloraInstanceCount(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetFloraRendererTextureUsage(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFog(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetGlobalWindStrengthVector(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetGlobalWindVelocity(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetGroundHeightAndBodyFlagsAtPosition(UIntPtr scenePointer, Vec3 position, out BodyFlags contactPointFlags, BodyFlags excludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetGroundHeightAndNormalAtPosition(UIntPtr scenePointer, Vec3 position, ref Vec3 normal, uint excludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetGroundHeightAtPosition(UIntPtr scenePointer, Vec3 position, uint excludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetHardBoundaryVertex(UIntPtr scenePointer, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetHardBoundaryVertexCount(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetHeightAtPoint(UIntPtr scenePointer, Vec2 point, BodyFlags excludeBodyFlags, ref float height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetIdOfNavMeshFace(UIntPtr scenePointer, int navMeshFace)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetInterpolationFactorForBodyWorldTransformSmoothing(Scene scene, out float interpolationFactor, out float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetLastFinalRenderCameraFrame(UIntPtr scenePointer, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetLastFinalRenderCameraPosition(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetLastPointOnNavigationMeshFromPositionToDestination(UIntPtr scenePointer, int startingFace, Vec2 position, Vec2 destination, int[] exclusionGroupIds, int exclusionGroupIdsCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetLastPointOnNavigationMeshFromWorldPositionToDestination(UIntPtr scenePointer, ref WorldPosition position, Vec2 destination)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetLastPositionOnNavMeshFaceForPointAndDirection(UIntPtr scenePointer, in PathFaceRecord record, Vec2 position, Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetLoadingStateName(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetModulePath(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetNavigationMeshCRC(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNavigationMeshForPosition(UIntPtr scenePointer, in Vec3 position, ref int faceGroupId, float heightDifferenceLimit, bool excludeDynamicNavigationMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetNavMeshFaceCenterPosition(UIntPtr scenePointer, int navMeshFace, ref Vec3 centerPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNavMeshFaceCount(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNavmeshFaceCountBetweenTwoIds(UIntPtr scenePointer, int firstId, int secondId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetNavMeshFaceFirstVertexZ(UIntPtr scenePointer, int navMeshFaceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetNavMeshFaceIndex(UIntPtr scenePointer, ref PathFaceRecord record, Vec2 position, bool isRegion1, bool checkIfDisabled, bool ignoreHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetNavMeshFaceIndex3(UIntPtr scenePointer, ref PathFaceRecord record, Vec3 position, bool checkIfDisabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetNavmeshFaceRecordsBetweenTwoIds(UIntPtr scenePointer, int firstId, int secondId, PathFaceRecord[] faceRecords)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PathFaceRecord GetNavMeshPathFaceRecord(UIntPtr scenePointer, int navMeshFace)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr GetNearestNavigationMeshForPosition(UIntPtr scenePointer, in Vec3 position, float heightDifferenceLimit, bool excludeDynamicNavigationMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNodeDataCount(Scene scene, int xIndex, int yIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetNormalAt(UIntPtr scenePointer, Vec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetNorthAngle(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfPathsWithNamePrefix(UIntPtr ptr, string prefix)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenAIFaceIndices(UIntPtr scenePointer, int startingAiFace, int endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, Vec2[] result, ref int pathSize, int[] exclusionGroupIds, int exclusionGroupIdsCount, float extraCostMultiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenAIFaceIndicesWithRegionSwitchCost(UIntPtr scenePointer, int startingAiFace, int endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, Vec2[] result, ref int pathSize, int[] exclusionGroupIds, int exclusionGroupIdsCount, float extraCostMultiplier, int regionSwitchCostTo0, int regionSwitchCostTo1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenAIFacePointers(UIntPtr scenePointer, UIntPtr startingAiFace, UIntPtr endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, Vec2[] result, ref int pathSize, int[] exclusionGroupIds, int exclusionGroupIdsCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathBetweenAIFacePointersWithRegionSwitchCost(UIntPtr scenePointer, UIntPtr startingAiFace, UIntPtr endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, Vec2[] result, ref int pathSize, int[] exclusionGroupIds, int exclusionGroupIdsCount, int regionSwitchCostTo0, int regionSwitchCostTo1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathDistanceBetweenAIFaces(UIntPtr scenePointer, int startingAiFace, int endingAiFace, Vec2 startingPosition, Vec2 endingPosition, float agentRadius, float distanceLimit, out float distance, int[] exclusionGroupIds, int exclusionGroupIdsCount, int regionSwitchCostTo0, int regionSwitchCostTo1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPathDistanceBetweenPositions(UIntPtr scenePointer, ref WorldPosition position, ref WorldPosition destination, float agentRadius, ref float pathLength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PathFaceRecord GetPathFaceRecordFromNavMeshFacePointer(UIntPtr scenePointer, UIntPtr navMeshFacePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPathsWithNamePrefix(UIntPtr ptr, UIntPtr[] points, string prefix)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Path GetPathWithName(UIntPtr scenePointer, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPhotoModeFocus(Scene scene, ref float focus, ref float focusStart, ref float focusEnd, ref float exposure, ref bool vignetteOn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetPhotoModeFov(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPhotoModeOn(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetPhotoModeOrbit(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetPhotoModeRoll(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPhysicsMinMax(UIntPtr scenePointer, ref Vec3 min_max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetRainDensity(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetRootEntities(Scene scene, NativeObjectArray output)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRootEntityCount(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSceneColorGradeIndex(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSceneFilterIndex(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSceneLimits(UIntPtr scenePointer, ref Vec3 min, ref Vec3 max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetSceneXMLCRC(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntity GetScriptedEntity(UIntPtr scenePointer, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetScriptedEntityCount(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mesh GetSkyboxMesh(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetSnowDensity(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec2 GetSoftBoundaryVertex(UIntPtr scenePointer, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSoftBoundaryVertexCount(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetSunDirection(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTerrainData(Scene scene, out Vec2i nodeDimension, out float nodeSize, out int layerCount, out int layerVersion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTerrainHeight(UIntPtr scenePointer, Vec2 position, bool checkHoles)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTerrainHeightAndNormal(UIntPtr scenePointer, Vec2 position, out float height, out Vec3 normal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTerrainMemoryUsage(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetTerrainMinMaxHeight(Scene scene, ref float min, ref float max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTerrainNodeData(Scene scene, int xIndex, int yIndex, out int vertexCountAlongAxis, out float quadLength, out float minHeight, out float maxHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTerrainPhysicsMaterialIndexAtLayer(Scene scene, int layerIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTimeOfDay(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTimeSpeed(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetUpgradeLevelCount(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetUpgradeLevelMask(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetUpgradeLevelMaskOfLevelName(UIntPtr scenePointer, string levelName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetUpgradeLevelNameOfIndex(UIntPtr scenePointer, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWaterLevel(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWaterLevelAtPosition(Scene scene, Vec2 position, bool useWaterRenderer, bool checkWaterBodyEntities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetWaterSpeedAtPosition(UIntPtr scenePointer, in Vec2 position, bool doChoppinessCorrection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWaterStrength(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetWindFlowMapData(UIntPtr scenePointer, float[] flowmapData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWinterTimeFactor(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasDecalRenderer(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasNavmeshFaceUnsharedEdges(UIntPtr scenePointer, in PathFaceRecord faceRecord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasTerrainHeightmap(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvalidateTerrainPhysicsMaterials(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAnyFaceWithId(UIntPtr scenePointer, int faceGroupId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAtmosphereIndoor(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsDefaultEditorScene(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsEditorScene(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLineToPointClear(UIntPtr scenePointer, int startingFace, Vec2 position, Vec2 destination, float agentRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLineToPointClear2(UIntPtr scenePointer, UIntPtr startingFace, Vec2 position, Vec2 destination, float agentRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsLoadingFinished(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsMultiplayerScene(Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPositionOnADynamicNavMesh(UIntPtr scenePointer, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadNavMeshPrefab(UIntPtr scenePointer, string navMeshPrefabName, int navMeshGroupIdShift)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadNavMeshPrefabWithFrame(UIntPtr scenePointer, string navMeshPrefabName, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MarkFacesWithIdAsLadder(UIntPtr scenePointer, int faceGroupId, bool isLadder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MergeFacesWithId(UIntPtr scenePointer, int faceGroupId0, int faceGroupId1, int newFaceGroupId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OptimizeScene(UIntPtr scenePointer, bool optimizeFlora, bool optimizeOro)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PauseSceneSounds(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadForRendering(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastExcludingTwoEntities(BodyFlags flags, UIntPtr scenePointer, in Ray ray, UIntPtr entity1, UIntPtr entity2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrain(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags, bool isFixedWorld)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForClosestEntityOrTerrainIgnoreEntity(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags, UIntPtr ignoredEntityPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RayCastForRamming(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 intersectionPoint, ref UIntPtr intersectedEntityIndex, BodyFlags bodyExcludeFlags, BodyFlags bodyIncludeFlags, UIntPtr ignoredEntityPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Read(UIntPtr scenePointer, string sceneName, ref SceneInitializationData initData, string forcedAtmoName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReadAndCalculateInitialCamera(UIntPtr scenePointer, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReadInModule(UIntPtr scenePointer, string sceneName, string moduleId, ref SceneInitializationData initData, string forcedAtmoName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr RegisterShipVisualToWaterRenderer(UIntPtr scenePointer, UIntPtr entityPointer, in Vec3 bb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAlwaysRenderedSkeleton(UIntPtr scenePointer, UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveDecalInstance(UIntPtr scenePointer, UIntPtr decalMeshPointer, string decalSetID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveEntity(UIntPtr scenePointer, UIntPtr entityId, int removeReason)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResumeLoadingRenderings(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResumeSceneSounds(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SaveNavMeshPrefabWithFrame(UIntPtr scenePointer, string navMeshPrefabName, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SceneHadWaterWakeRenderer(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SelectEntitiesCollidedWith(UIntPtr scenePointer, ref Ray ray, UIntPtr[] entityIds, Intersection[] intersections)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SelectEntitiesInBoxWithScriptComponent(UIntPtr scenePointer, ref Vec3 boundingBoxMin, ref Vec3 boundingBoxMax, UIntPtr[] entitiesOutput, int maxCount, string scriptComponentName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SeparateFacesWithId(UIntPtr scenePointer, int faceGroupId0, int faceGroupId1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAberrationOffset(UIntPtr scenePointer, float aberrationOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAberrationSize(UIntPtr scenePointer, float aberrationSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAberrationSmooth(UIntPtr scenePointer, float aberrationSmooth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SetAbilityOfFacesWithId(UIntPtr scenePointer, int faceGroupId, bool isEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetActiveVisibilityLevels(UIntPtr scenePointer, string levelsAppended)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAntialiasingMode(UIntPtr scenePointer, bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAtmosphereWithName(UIntPtr ptr, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBloom(UIntPtr scenePointer, bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBloomAmount(UIntPtr scenePointer, float bloomAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBloomStrength(UIntPtr scenePointer, float bloomStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBrightpassTreshold(UIntPtr scenePointer, float threshold)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClothSimulationState(UIntPtr scenePointer, bool state)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetColorGradeBlend(UIntPtr scenePointer, string texture1, string texture2, float alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDLSSMode(UIntPtr scenePointer, bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDofFocus(UIntPtr scenePointer, float dofFocus)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDofMode(UIntPtr scenePointer, bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDofParams(UIntPtr scenePointer, float dofFocusStart, float dofFocusEnd, bool isVignetteOn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDoNotAddEntitiesToTickList(UIntPtr scenePointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDoNotWaitForLoadingStatesToRender(UIntPtr scenePointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDontLoadInvisibleEntities(UIntPtr scenePointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDrynessFactor(UIntPtr scenePointer, float drynessFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDynamicShadowmapCascadesRadiusMultiplier(UIntPtr scenePointer, float extraRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDynamicSnowTexture(UIntPtr scenePointer, UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnvironmentMultiplier(UIntPtr scenePointer, bool useMultiplier, float multiplier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetExternalInjectionTexture(UIntPtr scenePointer, UIntPtr texturePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFetchCrcInfoOfScene(UIntPtr scenePointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFixedTickCallbackActive(Scene scene, bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFog(UIntPtr scenePointer, float fogDensity, ref Vec3 fogColor, float fogFalloff)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFogAdvanced(UIntPtr scenePointer, float fogFalloffOffset, float fogFalloffMinFog, float fogFalloffStartDist)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFogAmbientColor(UIntPtr scenePointer, ref Vec3 fogAmbientColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetForcedSnow(UIntPtr scenePointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlobalWindStrengthVector(UIntPtr scenePointer, in Vec2 strengthVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlobalWindVelocity(UIntPtr scenePointer, in Vec2 windVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGrainAmount(UIntPtr scenePointer, float grainAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHexagonVignetteAlpha(UIntPtr scenePointer, float Alpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHexagonVignetteColor(UIntPtr scenePointer, ref Vec3 p_hexagon_vignette_color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetHumidity(UIntPtr scenePointer, float humidity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLandscapeRainMaskData(UIntPtr scenePointer, byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensDistortion(UIntPtr scenePointer, float lensDistortion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareAberrationOffset(UIntPtr scenePointer, float lensFlareAberrationOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareAmount(UIntPtr scenePointer, float lensFlareAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareBlurSigma(UIntPtr scenePointer, float lensFlareBlurSigma)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareBlurSize(UIntPtr scenePointer, int lensFlareBlurSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareDiffractionWeight(UIntPtr scenePointer, float lensFlareDiffractionWeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareDirtWeight(UIntPtr scenePointer, float lensFlareDirtWeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareGhostSamples(UIntPtr scenePointer, int lensFlareGhostSamples)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareGhostWeight(UIntPtr scenePointer, float lensFlareGhostWeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareHaloWeight(UIntPtr scenePointer, float lensFlareHaloWeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareHaloWidth(UIntPtr scenePointer, float lensFlareHaloWidth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareStrength(UIntPtr scenePointer, float lensFlareStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLensFlareThreshold(UIntPtr scenePointer, float lensFlareThreshold)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLightDiffuseColor(UIntPtr scenePointer, int lightIndex, Vec3 diffuseColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLightDirection(UIntPtr scenePointer, int lightIndex, Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLightPosition(UIntPtr scenePointer, int lightIndex, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaxExposure(UIntPtr scenePointer, float maxExposure)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMiddleGray(UIntPtr scenePointer, float middleGray)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMieScatterFocus(UIntPtr scenePointer, float strength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMieScatterStrength(UIntPtr scenePointer, float strength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMinExposure(UIntPtr scenePointer, float minExposure)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMotionBlurMode(UIntPtr scenePointer, bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetName(UIntPtr scenePointer, string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNavMeshRegionMap(UIntPtr scenePointer, bool[] regionMap, int regionMapSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOcclusionMode(UIntPtr scenePointer, bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOnCollisionFilterCallbackActive(Scene scene, bool isActive)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOwnerThread(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoAtmosphereViaTod(UIntPtr scenePointer, float tod, bool withStorm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeFocus(Scene scene, float focusStart, float focusEnd, float focus, float exposure)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeFov(Scene scene, float verticalFov)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeOn(Scene scene, bool on)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeOrbit(Scene scene, bool orbit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeRoll(Scene scene, float roll)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPhotoModeVignette(Scene scene, bool vignetteOn)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPlaySoundEventsAfterReadyToRender(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRainDensity(UIntPtr scenePointer, float density)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSceneColorGrade(Scene scene, string textureName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSceneColorGradeIndex(Scene scene, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SetSceneFilterIndex(Scene scene, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShadow(UIntPtr scenePointer, bool shadowEnabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSkyBrightness(UIntPtr scenePointer, float brightness)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSkyRotation(UIntPtr scenePointer, float rotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSnowDensity(UIntPtr scenePointer, float density)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStreakAmount(UIntPtr scenePointer, float streakAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStreakIntensity(UIntPtr scenePointer, float stretchAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStreakStrength(UIntPtr scenePointer, float strengthAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStreakStretch(UIntPtr scenePointer, float stretchAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStreakThreshold(UIntPtr scenePointer, float streakThreshold)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetStreakTint(UIntPtr scenePointer, ref Vec3 p_streak_tint_color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSun(UIntPtr scenePointer, Vec3 color, float altitude, float angle, float intensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunAngleAltitude(UIntPtr scenePointer, float angle, float altitude)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunDirection(UIntPtr scenePointer, Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunLight(UIntPtr scenePointer, Vec3 color, Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunshaftMode(UIntPtr scenePointer, bool mode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunShaftStrength(UIntPtr scenePointer, float strength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSunSize(UIntPtr scenePointer, float size)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetExposure(UIntPtr scenePointer, float targetExposure)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTemperature(UIntPtr scenePointer, float temperature)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTerrainDynamicParams(UIntPtr scenePointer, Vec3 dynamic_params)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTimeOfDay(UIntPtr scenePointer, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTimeSpeed(UIntPtr scenePointer, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpgradeLevel(UIntPtr scenePointer, int level)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpgradeLevelVisibility(UIntPtr scenePointer, string concatLevels)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUpgradeLevelVisibilityWithMask(UIntPtr scenePointer, uint mask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUseConstantTime(UIntPtr ptr, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsesDeleteLaterSystem(UIntPtr scenePointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVignetteInnerRadius(UIntPtr scenePointer, float vignetteInnerRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVignetteOpacity(UIntPtr scenePointer, float vignetteOpacity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVignetteOuterRadius(UIntPtr scenePointer, float vignetteOuterRadius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWaterStrength(Scene scene, float newWaterStrength)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWaterWakeCameraOffset(UIntPtr scenePointer, float cameraOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWaterWakeWorldSize(UIntPtr scenePointer, float worldSize, float eraseFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetWinterTimeFactor(UIntPtr scenePointer, float winterTimeFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StallLoadingRenderingsUntilFurtherNotice(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SwapFaceConnectionsWithId(UIntPtr scenePointer, int hubFaceGroupID, int toBeSeparatedFaceGroupId, int toBeMergedFaceGroupId, bool canFail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string TakePhotoModePicture(Scene scene, bool saveAmbientOcclusionPass, bool saveObjectIdPass, bool saveShadowPass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick(UIntPtr scenePointer, float deltaTime)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickWake(UIntPtr scenePointer, float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WaitWaterRendererCPUSimulation(UIntPtr scenePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WorldPositionComputeNearestNavMesh(ref WorldPosition position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void WorldPositionValidateZ(ref WorldPosition position, int minimumValidityState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIScene()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScene.HasNavmeshFaceUnsharedEdges(UIntPtr scenePointer, in PathFaceRecord faceRecord)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vec3 IScene.GetWaterSpeedAtPosition(UIntPtr scenePointer, in Vec2 position, bool doChoppinessCorrection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IScene.GetBulkWaterLevelAtVolumes(UIntPtr scene, UIntPtr volumeQueryDataArray, int volumeCount, in MatrixFrame entityFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	UIntPtr IScene.RegisterShipVisualToWaterRenderer(UIntPtr scenePointer, UIntPtr entityPointer, in Vec3 bb)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IScene.SetGlobalWindStrengthVector(UIntPtr scenePointer, in Vec2 strengthVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IScene.SetGlobalWindVelocity(UIntPtr scenePointer, in Vec2 windVelocity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScene.RayCastExcludingTwoEntities(BodyFlags flags, UIntPtr scenePointer, in Ray ray, UIntPtr entity1, UIntPtr entity2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScene.RayCastForClosestEntityOrTerrain(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags, bool isFixedWorld)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScene.FocusRayCastForFixedPhysics(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags, bool isFixedWorld)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScene.RayCastForRamming(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 intersectionPoint, ref UIntPtr intersectedEntityIndex, BodyFlags bodyExcludeFlags, BodyFlags bodyIncludeFlags, UIntPtr ignoredEntityPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScene.RayCastForClosestEntityOrTerrainIgnoreEntity(UIntPtr scenePointer, in Vec3 sourcePoint, in Vec3 targetPoint, float rayThickness, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityIndex, BodyFlags bodyExcludeFlags, UIntPtr ignoredEntityPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IScene.BoxCastOnlyForCamera(UIntPtr scenePointer, Vec3[] boxPoints, in Vec3 centerPoint, in Vec3 dir, float distance, UIntPtr ignoredEntityPointer, ref float collisionDistance, ref Vec3 closestPoint, ref UIntPtr entityPointer, BodyFlags bodyExcludeFlags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	UIntPtr IScene.GetNavigationMeshForPosition(UIntPtr scenePointer, in Vec3 position, ref int faceGroupId, float heightDifferenceLimit, bool excludeDynamicNavigationMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	UIntPtr IScene.GetNearestNavigationMeshForPosition(UIntPtr scenePointer, in Vec3 position, float heightDifferenceLimit, bool excludeDynamicNavigationMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Vec2 IScene.GetLastPositionOnNavMeshFaceForPointAndDirection(UIntPtr scenePointer, in PathFaceRecord record, Vec2 position, Vec2 direction)
	{
		throw null;
	}
}
