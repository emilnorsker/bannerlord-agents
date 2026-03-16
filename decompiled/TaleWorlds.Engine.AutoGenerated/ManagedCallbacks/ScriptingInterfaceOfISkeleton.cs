using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfISkeleton : ISkeleton
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ActivateRagdollDelegate(UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddComponentDelegate(UIntPtr skeletonPointer, UIntPtr componentPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddComponentToBoneDelegate(UIntPtr skeletonPointer, sbyte boneIndex, UIntPtr component);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMeshDelegate(UIntPtr skeletonPointer, UIntPtr mesnPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMeshToBoneDelegate(UIntPtr skeletonPointer, UIntPtr multiMeshPointer, sbyte bone_index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddPrefabEntityToBoneDelegate(UIntPtr skeletonPointer, byte[] prefab_name, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearComponentsDelegate(UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearMeshesDelegate(UIntPtr skeletonPointer, [MarshalAs(UnmanagedType.U1)] bool clearBoneComponents);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearMeshesAtBoneDelegate(UIntPtr skeletonPointer, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateFromModelDelegate(byte[] skeletonModelName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateFromModelWithNullAnimTreeDelegate(UIntPtr entityPointer, byte[] skeletonModelName, float scale);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void EnableScriptDrivenPostIntegrateCallbackDelegate(UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ForceUpdateBoneFramesDelegate(UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void FreezeDelegate(UIntPtr skeletonPointer, [MarshalAs(UnmanagedType.U1)] bool isFrozen);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetAllMeshesDelegate(UIntPtr skeleton, UIntPtr nativeObjectArray);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAnimationAtChannelDelegate(UIntPtr skeletonPointer, int channelNo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAnimationIndexAtChannelDelegate(UIntPtr skeletonPointer, int channelNo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneBodyDelegate(UIntPtr skeletonPointer, sbyte boneIndex, ref CapsuleData data);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate sbyte GetBoneChildAtIndexDelegate(UIntPtr skeleton, sbyte boneIndex, sbyte childIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate sbyte GetBoneChildCountDelegate(UIntPtr skeleton, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetBoneComponentAtIndexDelegate(UIntPtr skeletonPointer, sbyte boneIndex, int componentIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetBoneComponentCountDelegate(UIntPtr skeletonPointer, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate sbyte GetBoneCountDelegate(UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneEntitialFrameDelegate(UIntPtr skeletonPointer, sbyte boneIndex, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneEntitialFrameAtChannelDelegate(UIntPtr skeletonPointer, int channelNo, sbyte boneIndex, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneEntitialFrameWithIndexDelegate(UIntPtr skeletonPointer, sbyte boneIndex, ref MatrixFrame outEntitialFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneEntitialFrameWithNameDelegate(UIntPtr skeletonPointer, byte[] boneName, ref MatrixFrame outEntitialFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneEntitialRestFrameDelegate(UIntPtr skeletonPointer, sbyte boneIndex, [MarshalAs(UnmanagedType.U1)] bool useBoneMapping, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate sbyte GetBoneIndexFromNameDelegate(byte[] skeletonModelName, byte[] boneName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoneLocalRestFrameDelegate(UIntPtr skeletonPointer, sbyte boneIndex, [MarshalAs(UnmanagedType.U1)] bool useBoneMapping, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetBoneNameDelegate(UIntPtr skeleton, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetComponentAtIndexDelegate(UIntPtr skeletonPointer, GameEntity.ComponentType componentType, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetComponentCountDelegate(UIntPtr skeletonPointer, GameEntity.ComponentType componentType);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate RagdollState GetCurrentRagdollStateDelegate(UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Transformation GetEntitialOutTransformDelegate(UIntPtr skeletonPointer, UIntPtr animResultPointer, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNameDelegate(UIntPtr skeleton);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate sbyte GetParentBoneIndexDelegate(UIntPtr skeleton, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetSkeletonAnimationParameterAtChannelDelegate(UIntPtr skeletonPointer, int channelNo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate float GetSkeletonAnimationSpeedAtChannelDelegate(UIntPtr skeletonPointer, int channelNo);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate sbyte GetSkeletonBoneMappingDelegate(UIntPtr skeletonPointer, sbyte boneIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasBoneComponentDelegate(UIntPtr skeletonPointer, sbyte boneIndex, UIntPtr component);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasComponentDelegate(UIntPtr skeletonPointer, UIntPtr componentPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool IsFrozenDelegate(UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveBoneComponentDelegate(UIntPtr skeletonPointer, sbyte boneIndex, UIntPtr component);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RemoveComponentDelegate(UIntPtr SkeletonPointer, UIntPtr componentPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResetClothsDelegate(UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ResetFramesDelegate(UIntPtr skeletonPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBoneLocalFrameDelegate(UIntPtr skeletonPointer, sbyte boneIndex, ref MatrixFrame localFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetOutBoneDisplacementDelegate(UIntPtr skeletonPointer, UIntPtr animResultPointer, sbyte boneIndex, Vec3 displacement);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetOutQuatDelegate(UIntPtr skeletonPointer, UIntPtr animResultPointer, sbyte boneIndex, Mat3 rotation);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSkeletonAnimationParameterAtChannelDelegate(UIntPtr skeletonPointer, int channelNo, float parameter);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSkeletonAnimationSpeedAtChannelDelegate(UIntPtr skeletonPointer, int channelNo, float speed);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetSkeletonUptoDateDelegate(UIntPtr skeletonPointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetUsePreciseBoundingVolumeDelegate(UIntPtr skeletonPointer, [MarshalAs(UnmanagedType.U1)] bool value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool SkeletonModelExistDelegate(byte[] skeletonModelName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TickAnimationsDelegate(UIntPtr skeletonPointer, ref MatrixFrame globalFrame, float dt, [MarshalAs(UnmanagedType.U1)] bool tickAnimsForChildren);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TickAnimationsAndForceUpdateDelegate(UIntPtr skeletonPointer, ref MatrixFrame globalFrame, float dt, [MarshalAs(UnmanagedType.U1)] bool tickAnimsForChildren);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UpdateEntitialFramesFromLocalFramesDelegate(UIntPtr skeletonPointer);

	private static readonly Encoding _utf8;

	public static ActivateRagdollDelegate call_ActivateRagdollDelegate;

	public static AddComponentDelegate call_AddComponentDelegate;

	public static AddComponentToBoneDelegate call_AddComponentToBoneDelegate;

	public static AddMeshDelegate call_AddMeshDelegate;

	public static AddMeshToBoneDelegate call_AddMeshToBoneDelegate;

	public static AddPrefabEntityToBoneDelegate call_AddPrefabEntityToBoneDelegate;

	public static ClearComponentsDelegate call_ClearComponentsDelegate;

	public static ClearMeshesDelegate call_ClearMeshesDelegate;

	public static ClearMeshesAtBoneDelegate call_ClearMeshesAtBoneDelegate;

	public static CreateFromModelDelegate call_CreateFromModelDelegate;

	public static CreateFromModelWithNullAnimTreeDelegate call_CreateFromModelWithNullAnimTreeDelegate;

	public static EnableScriptDrivenPostIntegrateCallbackDelegate call_EnableScriptDrivenPostIntegrateCallbackDelegate;

	public static ForceUpdateBoneFramesDelegate call_ForceUpdateBoneFramesDelegate;

	public static FreezeDelegate call_FreezeDelegate;

	public static GetAllMeshesDelegate call_GetAllMeshesDelegate;

	public static GetAnimationAtChannelDelegate call_GetAnimationAtChannelDelegate;

	public static GetAnimationIndexAtChannelDelegate call_GetAnimationIndexAtChannelDelegate;

	public static GetBoneBodyDelegate call_GetBoneBodyDelegate;

	public static GetBoneChildAtIndexDelegate call_GetBoneChildAtIndexDelegate;

	public static GetBoneChildCountDelegate call_GetBoneChildCountDelegate;

	public static GetBoneComponentAtIndexDelegate call_GetBoneComponentAtIndexDelegate;

	public static GetBoneComponentCountDelegate call_GetBoneComponentCountDelegate;

	public static GetBoneCountDelegate call_GetBoneCountDelegate;

	public static GetBoneEntitialFrameDelegate call_GetBoneEntitialFrameDelegate;

	public static GetBoneEntitialFrameAtChannelDelegate call_GetBoneEntitialFrameAtChannelDelegate;

	public static GetBoneEntitialFrameWithIndexDelegate call_GetBoneEntitialFrameWithIndexDelegate;

	public static GetBoneEntitialFrameWithNameDelegate call_GetBoneEntitialFrameWithNameDelegate;

	public static GetBoneEntitialRestFrameDelegate call_GetBoneEntitialRestFrameDelegate;

	public static GetBoneIndexFromNameDelegate call_GetBoneIndexFromNameDelegate;

	public static GetBoneLocalRestFrameDelegate call_GetBoneLocalRestFrameDelegate;

	public static GetBoneNameDelegate call_GetBoneNameDelegate;

	public static GetComponentAtIndexDelegate call_GetComponentAtIndexDelegate;

	public static GetComponentCountDelegate call_GetComponentCountDelegate;

	public static GetCurrentRagdollStateDelegate call_GetCurrentRagdollStateDelegate;

	public static GetEntitialOutTransformDelegate call_GetEntitialOutTransformDelegate;

	public static GetNameDelegate call_GetNameDelegate;

	public static GetParentBoneIndexDelegate call_GetParentBoneIndexDelegate;

	public static GetSkeletonAnimationParameterAtChannelDelegate call_GetSkeletonAnimationParameterAtChannelDelegate;

	public static GetSkeletonAnimationSpeedAtChannelDelegate call_GetSkeletonAnimationSpeedAtChannelDelegate;

	public static GetSkeletonBoneMappingDelegate call_GetSkeletonBoneMappingDelegate;

	public static HasBoneComponentDelegate call_HasBoneComponentDelegate;

	public static HasComponentDelegate call_HasComponentDelegate;

	public static IsFrozenDelegate call_IsFrozenDelegate;

	public static RemoveBoneComponentDelegate call_RemoveBoneComponentDelegate;

	public static RemoveComponentDelegate call_RemoveComponentDelegate;

	public static ResetClothsDelegate call_ResetClothsDelegate;

	public static ResetFramesDelegate call_ResetFramesDelegate;

	public static SetBoneLocalFrameDelegate call_SetBoneLocalFrameDelegate;

	public static SetOutBoneDisplacementDelegate call_SetOutBoneDisplacementDelegate;

	public static SetOutQuatDelegate call_SetOutQuatDelegate;

	public static SetSkeletonAnimationParameterAtChannelDelegate call_SetSkeletonAnimationParameterAtChannelDelegate;

	public static SetSkeletonAnimationSpeedAtChannelDelegate call_SetSkeletonAnimationSpeedAtChannelDelegate;

	public static SetSkeletonUptoDateDelegate call_SetSkeletonUptoDateDelegate;

	public static SetUsePreciseBoundingVolumeDelegate call_SetUsePreciseBoundingVolumeDelegate;

	public static SkeletonModelExistDelegate call_SkeletonModelExistDelegate;

	public static TickAnimationsDelegate call_TickAnimationsDelegate;

	public static TickAnimationsAndForceUpdateDelegate call_TickAnimationsAndForceUpdateDelegate;

	public static UpdateEntitialFramesFromLocalFramesDelegate call_UpdateEntitialFramesFromLocalFramesDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ActivateRagdoll(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddComponent(UIntPtr skeletonPointer, UIntPtr componentPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddComponentToBone(UIntPtr skeletonPointer, sbyte boneIndex, GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMesh(UIntPtr skeletonPointer, UIntPtr mesnPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMeshToBone(UIntPtr skeletonPointer, UIntPtr multiMeshPointer, sbyte bone_index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPrefabEntityToBone(UIntPtr skeletonPointer, string prefab_name, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearComponents(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMeshes(UIntPtr skeletonPointer, bool clearBoneComponents)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMeshesAtBone(UIntPtr skeletonPointer, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Skeleton CreateFromModel(string skeletonModelName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Skeleton CreateFromModelWithNullAnimTree(UIntPtr entityPointer, string skeletonModelName, float scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnableScriptDrivenPostIntegrateCallback(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ForceUpdateBoneFrames(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Freeze(UIntPtr skeletonPointer, bool isFrozen)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAllMeshes(Skeleton skeleton, NativeObjectArray nativeObjectArray)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetAnimationAtChannel(UIntPtr skeletonPointer, int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAnimationIndexAtChannel(UIntPtr skeletonPointer, int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneBody(UIntPtr skeletonPointer, sbyte boneIndex, ref CapsuleData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetBoneChildAtIndex(Skeleton skeleton, sbyte boneIndex, sbyte childIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetBoneChildCount(Skeleton skeleton, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntityComponent GetBoneComponentAtIndex(UIntPtr skeletonPointer, sbyte boneIndex, int componentIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetBoneComponentCount(UIntPtr skeletonPointer, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetBoneCount(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneEntitialFrame(UIntPtr skeletonPointer, sbyte boneIndex, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneEntitialFrameAtChannel(UIntPtr skeletonPointer, int channelNo, sbyte boneIndex, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneEntitialFrameWithIndex(UIntPtr skeletonPointer, sbyte boneIndex, ref MatrixFrame outEntitialFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneEntitialFrameWithName(UIntPtr skeletonPointer, string boneName, ref MatrixFrame outEntitialFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneEntitialRestFrame(UIntPtr skeletonPointer, sbyte boneIndex, bool useBoneMapping, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetBoneIndexFromName(string skeletonModelName, string boneName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoneLocalRestFrame(UIntPtr skeletonPointer, sbyte boneIndex, bool useBoneMapping, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetBoneName(Skeleton skeleton, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameEntityComponent GetComponentAtIndex(UIntPtr skeletonPointer, GameEntity.ComponentType componentType, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetComponentCount(UIntPtr skeletonPointer, GameEntity.ComponentType componentType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RagdollState GetCurrentRagdollState(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Transformation GetEntitialOutTransform(UIntPtr skeletonPointer, UIntPtr animResultPointer, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName(Skeleton skeleton)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetParentBoneIndex(Skeleton skeleton, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetSkeletonAnimationParameterAtChannel(UIntPtr skeletonPointer, int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetSkeletonAnimationSpeedAtChannel(UIntPtr skeletonPointer, int channelNo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public sbyte GetSkeletonBoneMapping(UIntPtr skeletonPointer, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasBoneComponent(UIntPtr skeletonPointer, sbyte boneIndex, GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasComponent(UIntPtr skeletonPointer, UIntPtr componentPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFrozen(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveBoneComponent(UIntPtr skeletonPointer, sbyte boneIndex, GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveComponent(UIntPtr SkeletonPointer, UIntPtr componentPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetCloths(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetFrames(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBoneLocalFrame(UIntPtr skeletonPointer, sbyte boneIndex, ref MatrixFrame localFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOutBoneDisplacement(UIntPtr skeletonPointer, UIntPtr animResultPointer, sbyte boneIndex, Vec3 displacement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOutQuat(UIntPtr skeletonPointer, UIntPtr animResultPointer, sbyte boneIndex, Mat3 rotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSkeletonAnimationParameterAtChannel(UIntPtr skeletonPointer, int channelNo, float parameter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSkeletonAnimationSpeedAtChannel(UIntPtr skeletonPointer, int channelNo, float speed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSkeletonUptoDate(UIntPtr skeletonPointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetUsePreciseBoundingVolume(UIntPtr skeletonPointer, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool SkeletonModelExist(string skeletonModelName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickAnimations(UIntPtr skeletonPointer, ref MatrixFrame globalFrame, float dt, bool tickAnimsForChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickAnimationsAndForceUpdate(UIntPtr skeletonPointer, ref MatrixFrame globalFrame, float dt, bool tickAnimsForChildren)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateEntitialFramesFromLocalFrames(UIntPtr skeletonPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfISkeleton()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfISkeleton()
	{
		throw null;
	}
}
