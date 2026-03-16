using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

public struct TextDrawObject : IDrawObject
{
	public bool IsValid;

	public float[] Text_Vertices;

	public float[] Text_TextureCoordinates;

	public uint[] Text_Indices;

	public float Text_MeshWidth;

	public float Text_MeshHeight;

	public ulong HashCode1;

	public ulong HashCode2;

	public Rectangle2D Rectangle;

	public static TextDrawObject Invalid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	bool IDrawObject.IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	Rectangle2D IDrawObject.Rectangle
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
	private static TextDrawObject CreateInvalid()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TextDrawObject Create(float[] vertices, float[] uvs, uint[] indices, float text_MeshWidth, float text_MeshHeight, in Rectangle2D rectangle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ConvertToHashInPlace()
	{
		throw null;
	}
}
