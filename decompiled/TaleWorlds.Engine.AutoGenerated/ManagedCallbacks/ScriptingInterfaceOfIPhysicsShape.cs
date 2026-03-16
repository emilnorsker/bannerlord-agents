using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using TaleWorlds.DotNet;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace ManagedCallbacks;

internal class ScriptingInterfaceOfIPhysicsShape : IPhysicsShape
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddCapsuleDelegate(UIntPtr shapePointer, ref CapsuleData data);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddPreloadQueueWithNameDelegate(byte[] bodyName, ref Vec3 scale);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void AddSphereDelegate(UIntPtr shapePointer, ref Vec3 origin, float radius);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int CapsuleCountDelegate(UIntPtr shapePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void clearDelegate(UIntPtr shapePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer CreateBodyCopyDelegate(UIntPtr bodyPointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetBoundingBoxDelegate(UIntPtr shapePointer, out BoundingBox boundingBox);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate Vec3 GetBoundingBoxCenterDelegate(UIntPtr shapePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetCapsuleDelegate(UIntPtr shapePointer, ref CapsuleData data, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetCapsuleWithMaterialDelegate(UIntPtr shapePointer, ref CapsuleData data, ref int materialIndex, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetDominantMaterialForTriangleMeshDelegate(UIntPtr shape, int meshIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate NativeObjectPointer GetFromResourceDelegate(byte[] bodyName, [MarshalAs(UnmanagedType.U1)] bool mayReturnNull);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int GetNameDelegate(UIntPtr shape);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetSphereDelegate(UIntPtr shapePointer, ref SphereData data, int sphereIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetSphereWithMaterialDelegate(UIntPtr shapePointer, ref SphereData data, ref int materialIndex, int sphereIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void GetTriangleDelegate(UIntPtr pointer, IntPtr data, int meshIndex, int triangleIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void InitDescriptionDelegate(UIntPtr shapePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void PrepareDelegate(UIntPtr shapePointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void ProcessPreloadQueueDelegate();

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void SetCapsuleDelegate(UIntPtr shapePointer, ref CapsuleData data, int index);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int SphereCountDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void TransformDelegate(UIntPtr shapePointer, ref MatrixFrame frame);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int TriangleCountInTriangleMeshDelegate(UIntPtr pointer, int meshIndex);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate int TriangleMeshCountDelegate(UIntPtr pointer);

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	[SuppressUnmanagedCodeSecurity]
	[MonoNativeFunctionWrapper]
	public delegate void UnloadDynamicBodiesDelegate();

	private static readonly Encoding _utf8;

	public static AddCapsuleDelegate call_AddCapsuleDelegate;

	public static AddPreloadQueueWithNameDelegate call_AddPreloadQueueWithNameDelegate;

	public static AddSphereDelegate call_AddSphereDelegate;

	public static CapsuleCountDelegate call_CapsuleCountDelegate;

	public static clearDelegate call_clearDelegate;

	public static CreateBodyCopyDelegate call_CreateBodyCopyDelegate;

	public static GetBoundingBoxDelegate call_GetBoundingBoxDelegate;

	public static GetBoundingBoxCenterDelegate call_GetBoundingBoxCenterDelegate;

	public static GetCapsuleDelegate call_GetCapsuleDelegate;

	public static GetCapsuleWithMaterialDelegate call_GetCapsuleWithMaterialDelegate;

	public static GetDominantMaterialForTriangleMeshDelegate call_GetDominantMaterialForTriangleMeshDelegate;

	public static GetFromResourceDelegate call_GetFromResourceDelegate;

	public static GetNameDelegate call_GetNameDelegate;

	public static GetSphereDelegate call_GetSphereDelegate;

	public static GetSphereWithMaterialDelegate call_GetSphereWithMaterialDelegate;

	public static GetTriangleDelegate call_GetTriangleDelegate;

	public static InitDescriptionDelegate call_InitDescriptionDelegate;

	public static PrepareDelegate call_PrepareDelegate;

	public static ProcessPreloadQueueDelegate call_ProcessPreloadQueueDelegate;

	public static SetCapsuleDelegate call_SetCapsuleDelegate;

	public static SphereCountDelegate call_SphereCountDelegate;

	public static TransformDelegate call_TransformDelegate;

	public static TriangleCountInTriangleMeshDelegate call_TriangleCountInTriangleMeshDelegate;

	public static TriangleMeshCountDelegate call_TriangleMeshCountDelegate;

	public static UnloadDynamicBodiesDelegate call_UnloadDynamicBodiesDelegate;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCapsule(UIntPtr shapePointer, ref CapsuleData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPreloadQueueWithName(string bodyName, ref Vec3 scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSphere(UIntPtr shapePointer, ref Vec3 origin, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CapsuleCount(UIntPtr shapePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void clear(UIntPtr shapePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PhysicsShape CreateBodyCopy(UIntPtr bodyPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoundingBox(UIntPtr shapePointer, out BoundingBox boundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetBoundingBoxCenter(UIntPtr shapePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetCapsule(UIntPtr shapePointer, ref CapsuleData data, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetCapsuleWithMaterial(UIntPtr shapePointer, ref CapsuleData data, ref int materialIndex, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetDominantMaterialForTriangleMesh(PhysicsShape shape, int meshIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PhysicsShape GetFromResource(string bodyName, bool mayReturnNull)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName(PhysicsShape shape)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSphere(UIntPtr shapePointer, ref SphereData data, int sphereIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSphereWithMaterial(UIntPtr shapePointer, ref SphereData data, ref int materialIndex, int sphereIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTriangle(UIntPtr pointer, Vec3[] data, int meshIndex, int triangleIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitDescription(UIntPtr shapePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Prepare(UIntPtr shapePointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ProcessPreloadQueue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCapsule(UIntPtr shapePointer, ref CapsuleData data, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SphereCount(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Transform(UIntPtr shapePointer, ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int TriangleCountInTriangleMesh(UIntPtr pointer, int meshIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int TriangleMeshCount(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnloadDynamicBodies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ScriptingInterfaceOfIPhysicsShape()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ScriptingInterfaceOfIPhysicsShape()
	{
		throw null;
	}
}
