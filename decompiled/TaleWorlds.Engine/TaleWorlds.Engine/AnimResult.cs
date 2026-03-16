using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public struct AnimResult
{
	private UIntPtr _nativePointer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static AnimResult CreateWithPointer(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Transformation GetEntitialOutTransform(sbyte boneIndex, Skeleton skeleton)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOutBoneDisplacement(sbyte boneIndex, Vec3 position, Skeleton skeleton)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOutQuat(sbyte boneIndex, Mat3 rotation, Skeleton skeleton)
	{
		throw null;
	}
}
