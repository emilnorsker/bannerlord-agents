using System.Numerics;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.TwoDimension;

public struct Rectangle2D
{
	private struct RectangleRenderProperties
	{
		public Vector2 ScaleMultiplier;

		public Vector2 PositionOffsetPixel;

		public float RotationOffset;

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
		internal static RectangleRenderProperties CreateEmpty()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
		internal void FillValuesFrom(RectangleRenderProperties other)
		{
			throw null;
		}
	}

	private static class RectangleHelper
	{
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
		public static MatrixFrame CreateMatrixFrame(float posX, float posY, float pivotX, float pivotY, float scaleX, float scaleY, float rotation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
		public static SimpleRectangle GetBoundingBox(in Rectangle2D rectangle)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
		private static float GetTwoDimensionalCrossProduct(in Vector2 p1, in Vector2 p2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
		private static bool AreLinesIntersecting(in Vector2 line1Start, in Vector2 line1End, in Vector2 line2Start, in Vector2 line2End)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
		public static bool DoRectanglesIntersect(in Rectangle2D rect1, in Rectangle2D rect2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
		public static bool IsPointInside(in Vector2 point, in Rectangle2D rect)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
		public static bool IsSubRectOf(in Rectangle2D rect1, in Rectangle2D rect2)
		{
			throw null;
		}
	}

	public bool IsValid;

	public Vector2 TopLeft;

	public Vector2 TopRight;

	public Vector2 BottomRight;

	public Vector2 BottomLeft;

	public Vector2 LocalPosition;

	public Vector2 LocalScale;

	public Vector2 LocalPivot;

	public float LocalRotation;

	private RectangleRenderProperties _renderProperties;

	private bool _hasDifferentVisuals;

	private bool _visualsNeedCalculation;

	private Vector2 _cachedOrigin;

	private MatrixFrame _cachedOrthonormalMatrix;

	private MatrixFrame _cachedMatrixFrame;

	private MatrixFrame _cachedVisualMatrixFrame;

	private SimpleRectangle _boundingBox;

	private bool _hasRotation;

	public static Rectangle2D Invalid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Rectangle2D CreateInvalid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public static Rectangle2D Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public Rectangle2D FillLocalValuesFrom(in Rectangle2D other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public Vector2 GetVisualScale()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public void AddVisualOffset(float offsetX, float offsetY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public void SetVisualOffset(float offsetX, float offsetY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public void AddVisualScale(float scaleX, float scaleY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public void SetVisualScale(float scaleX, float scaleY)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public void AddVisualRotationOffset(float rotationOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public void SetVisualRotationOffset(float rotationOffset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public void ValidateVisuals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawCorners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public void CalculateMatrixFrame(in Rectangle2D parentRectangle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public void CalculateVisualMatrixFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public Vector2 GetCachedOrigin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public MatrixFrame GetCachedMatrixFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public MatrixFrame GetCachedVisualMatrixFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public Vector2 GetCenter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public SimpleRectangle GetBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public bool IsIdentical(in Rectangle2D other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public bool IsCollide(in Rectangle2D other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public bool IsSubRectOf(in Rectangle2D other)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public bool IsPointInside(in Vector2 point)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public Vector2 TransformScreenPositionToLocal(in Vector2 screenPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining)]
	public Vector2 TransformLocalPositionToScreen(in Vector2 localPosition)
	{
		throw null;
	}
}
