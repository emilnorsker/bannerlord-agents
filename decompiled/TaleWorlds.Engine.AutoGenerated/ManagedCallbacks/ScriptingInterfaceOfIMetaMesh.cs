using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIMetaMesh : IMetaMesh
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddEditDataUserDelegate(UIntPtr meshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMeshDelegate(UIntPtr multiMeshPointer, UIntPtr meshPointer, uint lodLevel);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddMetaMeshDelegate(UIntPtr metaMeshPtr, UIntPtr otherMetaMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AssignClothBodyFromDelegate(UIntPtr multiMeshPointer, UIntPtr multiMeshToMergePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BatchMultiMeshesDelegate(UIntPtr multiMeshPointer, UIntPtr multiMeshToMergePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void BatchMultiMeshesMultipleDelegate(UIntPtr multiMeshPointer, IntPtr multiMeshToMergePointers, int metaMeshCount);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CheckMetaMeshExistenceDelegate(byte[] multiMeshPrefixName, int lod_count_check);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int CheckResourcesDelegate(UIntPtr meshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearEditDataDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearMeshesDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearMeshesForLodDelegate(UIntPtr multiMeshPointer, int lodToClear);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearMeshesForLowerLodsDelegate(UIntPtr multiMeshPointer, int lod);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ClearMeshesForOtherLodsDelegate(UIntPtr multiMeshPointer, int lodToKeep);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void CopyToDelegate(UIntPtr metaMesh, UIntPtr targetMesh, [MarshalAs(UnmanagedType.U1)] bool copyMeshes);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateCopyDelegate(UIntPtr ptr);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateCopyFromNameDelegate(byte[] multiMeshPrefixName, [MarshalAs(UnmanagedType.U1)] bool showErrors, [MarshalAs(UnmanagedType.U1)] bool mayReturnNull);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateMetaMeshDelegate(byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void DrawTextWithDefaultFontDelegate(UIntPtr multiMeshPointer, byte[] text, Vec2 textPositionMin, Vec2 textPositionMax, Vec2 size, uint color, TextFlags flags);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetAllMultiMeshesDelegate(IntPtr gameEntitiesTemp);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoundingBoxDelegate(UIntPtr multiMeshPointer, ref BoundingBox outBoundingBox);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetFactor1Delegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate uint GetFactor2Delegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetFrameDelegate(UIntPtr multiMeshPointer, ref MatrixFrame outFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetLodMaskForMeshAtIndexDelegate(UIntPtr multiMeshPointer, int meshIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetMeshAtIndexDelegate(UIntPtr multiMeshPointer, int meshIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetMeshCountDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetMeshCountWithTagDelegate(UIntPtr multiMeshPointer, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetMorphedCopyDelegate(byte[] multiMeshName, float morphTarget, [MarshalAs(UnmanagedType.U1)] bool showErrors);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetMultiMeshDelegate(byte[] name);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetMultiMeshCountDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNameDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetTotalGpuSizeDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetVectorArgument2Delegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetVectorUserDataDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate VisibilityMaskFlags GetVisibilityMaskDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasAnyGeneratedLodsDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasAnyLodsDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasClothDataDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool HasVertexBufferOrEditDataOrPackageItemDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void MergeMultiMeshesDelegate(UIntPtr multiMeshPointer, UIntPtr multiMeshToMergePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PreloadForRenderingDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PreloadShadersDelegate(UIntPtr multiMeshPointer, [MarshalAs(UnmanagedType.U1)] bool useTableau, [MarshalAs(UnmanagedType.U1)] bool useTeamColor);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void RecomputeBoundingBoxDelegate(UIntPtr multiMeshPointer, [MarshalAs(UnmanagedType.U1)] bool recomputeMeshes);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseDelegate(UIntPtr multiMeshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ReleaseEditDataUserDelegate(UIntPtr meshPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int RemoveMeshesWithoutTagDelegate(UIntPtr multiMeshPointer, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int RemoveMeshesWithTagDelegate(UIntPtr multiMeshPointer, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetBillboardingDelegate(UIntPtr multiMeshPointer, BillboardType billboard);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetContourColorDelegate(UIntPtr meshPointer, uint color);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetContourStateDelegate(UIntPtr meshPointer, [MarshalAs(UnmanagedType.U1)] bool alwaysVisible);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCullModeDelegate(UIntPtr metaMeshPtr, MBMeshCullingMode cullMode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetEditDataPolicyDelegate(UIntPtr meshPointer, EditDataPolicy policy);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFactor1Delegate(UIntPtr multiMeshPointer, uint factorColor1);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFactor1LinearDelegate(UIntPtr multiMeshPointer, uint linearFactorColor1);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFactor2Delegate(UIntPtr multiMeshPointer, uint factorColor2);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFactor2LinearDelegate(UIntPtr multiMeshPointer, uint linearFactorColor2);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFactorColorToSubMeshesWithTagDelegate(UIntPtr meshPointer, uint color, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetFrameDelegate(UIntPtr multiMeshPointer, ref MatrixFrame meshFrame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetGlossMultiplierDelegate(UIntPtr multiMeshPointer, float value);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetLodBiasDelegate(UIntPtr multiMeshPointer, int lod_bias);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMaterialDelegate(UIntPtr multiMeshPointer, UIntPtr materialPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetMaterialToSubMeshesWithTagDelegate(UIntPtr meshPointer, UIntPtr materialPointer, byte[] tag);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetNumLodsDelegate(UIntPtr multiMeshPointer, int num_lod);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetShaderToMaterialDelegate(UIntPtr multiMeshPointer, byte[] shaderName);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVectorArgumentDelegate(UIntPtr multiMeshPointer, float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVectorArgument2Delegate(UIntPtr multiMeshPointer, float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVectorUserDataDelegate(UIntPtr multiMeshPointer, ref Vec3 vectorArg);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetVisibilityMaskDelegate(UIntPtr multiMeshPointer, VisibilityMaskFlags visibilityMask);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UseHeadBoneFaceGenScalingDelegate(UIntPtr multiMeshPointer, UIntPtr skeleton, sbyte headLookDirectionBoneIndex, ref MatrixFrame frame);

	private static readonly Encoding _utf8;

	public static AddEditDataUserDelegate call_AddEditDataUserDelegate;

	public static AddMeshDelegate call_AddMeshDelegate;

	public static AddMetaMeshDelegate call_AddMetaMeshDelegate;

	public static AssignClothBodyFromDelegate call_AssignClothBodyFromDelegate;

	public static BatchMultiMeshesDelegate call_BatchMultiMeshesDelegate;

	public static BatchMultiMeshesMultipleDelegate call_BatchMultiMeshesMultipleDelegate;

	public static CheckMetaMeshExistenceDelegate call_CheckMetaMeshExistenceDelegate;

	public static CheckResourcesDelegate call_CheckResourcesDelegate;

	public static ClearEditDataDelegate call_ClearEditDataDelegate;

	public static ClearMeshesDelegate call_ClearMeshesDelegate;

	public static ClearMeshesForLodDelegate call_ClearMeshesForLodDelegate;

	public static ClearMeshesForLowerLodsDelegate call_ClearMeshesForLowerLodsDelegate;

	public static ClearMeshesForOtherLodsDelegate call_ClearMeshesForOtherLodsDelegate;

	public static CopyToDelegate call_CopyToDelegate;

	public static CreateCopyDelegate call_CreateCopyDelegate;

	public static CreateCopyFromNameDelegate call_CreateCopyFromNameDelegate;

	public static CreateMetaMeshDelegate call_CreateMetaMeshDelegate;

	public static DrawTextWithDefaultFontDelegate call_DrawTextWithDefaultFontDelegate;

	public static GetAllMultiMeshesDelegate call_GetAllMultiMeshesDelegate;

	public static GetBoundingBoxDelegate call_GetBoundingBoxDelegate;

	public static GetFactor1Delegate call_GetFactor1Delegate;

	public static GetFactor2Delegate call_GetFactor2Delegate;

	public static GetFrameDelegate call_GetFrameDelegate;

	public static GetLodMaskForMeshAtIndexDelegate call_GetLodMaskForMeshAtIndexDelegate;

	public static GetMeshAtIndexDelegate call_GetMeshAtIndexDelegate;

	public static GetMeshCountDelegate call_GetMeshCountDelegate;

	public static GetMeshCountWithTagDelegate call_GetMeshCountWithTagDelegate;

	public static GetMorphedCopyDelegate call_GetMorphedCopyDelegate;

	public static GetMultiMeshDelegate call_GetMultiMeshDelegate;

	public static GetMultiMeshCountDelegate call_GetMultiMeshCountDelegate;

	public static GetNameDelegate call_GetNameDelegate;

	public static GetTotalGpuSizeDelegate call_GetTotalGpuSizeDelegate;

	public static GetVectorArgument2Delegate call_GetVectorArgument2Delegate;

	public static GetVectorUserDataDelegate call_GetVectorUserDataDelegate;

	public static GetVisibilityMaskDelegate call_GetVisibilityMaskDelegate;

	public static HasAnyGeneratedLodsDelegate call_HasAnyGeneratedLodsDelegate;

	public static HasAnyLodsDelegate call_HasAnyLodsDelegate;

	public static HasClothDataDelegate call_HasClothDataDelegate;

	public static HasVertexBufferOrEditDataOrPackageItemDelegate call_HasVertexBufferOrEditDataOrPackageItemDelegate;

	public static MergeMultiMeshesDelegate call_MergeMultiMeshesDelegate;

	public static PreloadForRenderingDelegate call_PreloadForRenderingDelegate;

	public static PreloadShadersDelegate call_PreloadShadersDelegate;

	public static RecomputeBoundingBoxDelegate call_RecomputeBoundingBoxDelegate;

	public static ReleaseDelegate call_ReleaseDelegate;

	public static ReleaseEditDataUserDelegate call_ReleaseEditDataUserDelegate;

	public static RemoveMeshesWithoutTagDelegate call_RemoveMeshesWithoutTagDelegate;

	public static RemoveMeshesWithTagDelegate call_RemoveMeshesWithTagDelegate;

	public static SetBillboardingDelegate call_SetBillboardingDelegate;

	public static SetContourColorDelegate call_SetContourColorDelegate;

	public static SetContourStateDelegate call_SetContourStateDelegate;

	public static SetCullModeDelegate call_SetCullModeDelegate;

	public static SetEditDataPolicyDelegate call_SetEditDataPolicyDelegate;

	public static SetFactor1Delegate call_SetFactor1Delegate;

	public static SetFactor1LinearDelegate call_SetFactor1LinearDelegate;

	public static SetFactor2Delegate call_SetFactor2Delegate;

	public static SetFactor2LinearDelegate call_SetFactor2LinearDelegate;

	public static SetFactorColorToSubMeshesWithTagDelegate call_SetFactorColorToSubMeshesWithTagDelegate;

	public static SetFrameDelegate call_SetFrameDelegate;

	public static SetGlossMultiplierDelegate call_SetGlossMultiplierDelegate;

	public static SetLodBiasDelegate call_SetLodBiasDelegate;

	public static SetMaterialDelegate call_SetMaterialDelegate;

	public static SetMaterialToSubMeshesWithTagDelegate call_SetMaterialToSubMeshesWithTagDelegate;

	public static SetNumLodsDelegate call_SetNumLodsDelegate;

	public static SetShaderToMaterialDelegate call_SetShaderToMaterialDelegate;

	public static SetVectorArgumentDelegate call_SetVectorArgumentDelegate;

	public static SetVectorArgument2Delegate call_SetVectorArgument2Delegate;

	public static SetVectorUserDataDelegate call_SetVectorUserDataDelegate;

	public static SetVisibilityMaskDelegate call_SetVisibilityMaskDelegate;

	public static UseHeadBoneFaceGenScalingDelegate call_UseHeadBoneFaceGenScalingDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEditDataUser(UIntPtr meshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMesh(UIntPtr multiMeshPointer, UIntPtr meshPointer, uint lodLevel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMetaMesh(UIntPtr metaMeshPtr, UIntPtr otherMetaMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AssignClothBodyFrom(UIntPtr multiMeshPointer, UIntPtr multiMeshToMergePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BatchMultiMeshes(UIntPtr multiMeshPointer, UIntPtr multiMeshToMergePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BatchMultiMeshesMultiple(UIntPtr multiMeshPointer, UIntPtr[] multiMeshToMergePointers, int metaMeshCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckMetaMeshExistence(string multiMeshPrefixName, int lod_count_check)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CheckResources(UIntPtr meshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearEditData(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMeshes(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMeshesForLod(UIntPtr multiMeshPointer, int lodToClear)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMeshesForLowerLods(UIntPtr multiMeshPointer, int lod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMeshesForOtherLods(UIntPtr multiMeshPointer, int lodToKeep)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CopyTo(UIntPtr metaMesh, UIntPtr targetMesh, bool copyMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh CreateCopy(UIntPtr ptr)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh CreateCopyFromName(string multiMeshPrefixName, bool showErrors, bool mayReturnNull)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh CreateMetaMesh(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawTextWithDefaultFont(UIntPtr multiMeshPointer, string text, Vec2 textPositionMin, Vec2 textPositionMax, Vec2 size, uint color, TextFlags flags)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetAllMultiMeshes(UIntPtr[] gameEntitiesTemp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoundingBox(UIntPtr multiMeshPointer, ref BoundingBox outBoundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetFactor1(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetFactor2(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetFrame(UIntPtr multiMeshPointer, ref MatrixFrame outFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetLodMaskForMeshAtIndex(UIntPtr multiMeshPointer, int meshIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mesh GetMeshAtIndex(UIntPtr multiMeshPointer, int meshIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMeshCount(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMeshCountWithTag(UIntPtr multiMeshPointer, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh GetMorphedCopy(string multiMeshName, float morphTarget, bool showErrors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetaMesh GetMultiMesh(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetMultiMeshCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetTotalGpuSize(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetVectorArgument2(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetVectorUserData(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public VisibilityMaskFlags GetVisibilityMask(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAnyGeneratedLods(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasAnyLods(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasClothData(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasVertexBufferOrEditDataOrPackageItem(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MergeMultiMeshes(UIntPtr multiMeshPointer, UIntPtr multiMeshToMergePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadForRendering(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadShaders(UIntPtr multiMeshPointer, bool useTableau, bool useTeamColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RecomputeBoundingBox(UIntPtr multiMeshPointer, bool recomputeMeshes)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release(UIntPtr multiMeshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseEditDataUser(UIntPtr meshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int RemoveMeshesWithoutTag(UIntPtr multiMeshPointer, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int RemoveMeshesWithTag(UIntPtr multiMeshPointer, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBillboarding(UIntPtr multiMeshPointer, BillboardType billboard)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetContourColor(UIntPtr meshPointer, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetContourState(UIntPtr meshPointer, bool alwaysVisible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCullMode(UIntPtr metaMeshPtr, MBMeshCullingMode cullMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEditDataPolicy(UIntPtr meshPointer, EditDataPolicy policy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFactor1(UIntPtr multiMeshPointer, uint factorColor1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFactor1Linear(UIntPtr multiMeshPointer, uint linearFactorColor1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFactor2(UIntPtr multiMeshPointer, uint factorColor2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFactor2Linear(UIntPtr multiMeshPointer, uint linearFactorColor2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFactorColorToSubMeshesWithTag(UIntPtr meshPointer, uint color, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFrame(UIntPtr multiMeshPointer, ref MatrixFrame meshFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetGlossMultiplier(UIntPtr multiMeshPointer, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLodBias(UIntPtr multiMeshPointer, int lod_bias)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaterial(UIntPtr multiMeshPointer, UIntPtr materialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaterialToSubMeshesWithTag(UIntPtr meshPointer, UIntPtr materialPointer, string tag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetNumLods(UIntPtr multiMeshPointer, int num_lod)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShaderToMaterial(UIntPtr multiMeshPointer, string shaderName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVectorArgument(UIntPtr multiMeshPointer, float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVectorArgument2(UIntPtr multiMeshPointer, float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVectorUserData(UIntPtr multiMeshPointer, ref Vec3 vectorArg)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisibilityMask(UIntPtr multiMeshPointer, VisibilityMaskFlags visibilityMask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UseHeadBoneFaceGenScaling(UIntPtr multiMeshPointer, UIntPtr skeleton, sbyte headLookDirectionBoneIndex, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIMetaMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIMetaMesh()
	{
		throw null;
	}
}
