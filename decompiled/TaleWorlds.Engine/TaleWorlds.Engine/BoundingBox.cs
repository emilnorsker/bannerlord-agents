using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineStruct("rglBounding_box::Plain_bounding_box", false, null)]
public struct BoundingBox
{
	public struct TransformedBoundingBoxPointsContainer
	{
		public Vec3 p0;

		public Vec3 p1;

		public Vec3 p2;

		public Vec3 p3;

		public Vec3 p4;

		public Vec3 p5;

		public Vec3 p6;

		public Vec3 p7;

		public Vec3 this[int index]
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public (Vec3, Vec3) ComputeTransformedMinMax()
		{
			throw null;
		}
	}

	[CustomEngineStructMemberData("box_min_")]
	public Vec3 min;

	[CustomEngineStructMemberData("box_max_")]
	public Vec3 max;

	[CustomEngineStructMemberData("box_center_")]
	public Vec3 center;

	[CustomEngineStructMemberData("radius_")]
	public float radius;

	public Vec3 this[int index]
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BoundingBox(in Vec3 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RelaxMinMaxWithPoint(in Vec3 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RelaxMinMaxWithPointAndRadius(in Vec3 point, float radius)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RecomputeRadius()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TransformedBoundingBoxPointsContainer GetTransformedTipPointsToParent(in MatrixFrame parentFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TransformedBoundingBoxPointsContainer GetTransformedTipPointsToChild(in MatrixFrame childFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RelaxWithBoundingBox(BoundingBox modifiedBoundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RelaxWithArbitraryBoundingBox(BoundingBox otherBoundingBox, MatrixFrame otherGlobalFrame, MatrixFrame globalFrameOfThisBoundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RelaxWithChildBoundingBox(BoundingBox childBoundingBox, MatrixFrame childFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginRelaxation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool ModifyPlane(ref float plane, float otherPlane, float modifyAmount, float changeTolerance, bool isMin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ArrangeWithAnotherBoundingBox(ref BoundingBox boundingBox, BoundingBox otherBoundingBox, float changeAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool PointInsideBox(Vec3 point, float epsilon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetLongestHalfDimensionOfBoundingBox(BoundingBox boundingBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RenderBoundingBox()
	{
		throw null;
	}
}
