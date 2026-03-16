using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineClass("rglPhysics_shape")]
public sealed class PhysicsShape : Resource
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PhysicsShape GetFromResource(string bodyName, bool mayReturnNull = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddPreloadQueueWithName(string bodyName, Vec3 scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ProcessPreloadQueue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UnloadDynamicBodies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PhysicsShape(UIntPtr bodyPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PhysicsShape CreateCopy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int SphereCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSphere(ref SphereData data, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetSphere(ref SphereData data, out PhysicsMaterial material, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PhysicsMaterial GetDominantMaterialForTriangleMesh(int meshIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int TriangleMeshCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int TriangleCountInTriangleMesh(int meshIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetTriangle(Vec3[] triangle, int meshIndex, int triangleIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Prepare()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int CapsuleCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddCapsule(CapsuleData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitDescription()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSphere(SphereData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCapsule(CapsuleData data, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetCapsule(ref CapsuleData data, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetCapsule(ref CapsuleData data, out PhysicsMaterial material, int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBoundingBox(out BoundingBox boundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetBoundingBoxCenter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Transform(ref MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}
}
