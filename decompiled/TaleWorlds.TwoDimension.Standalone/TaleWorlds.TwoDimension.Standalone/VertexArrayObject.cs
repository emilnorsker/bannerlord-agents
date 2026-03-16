using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension.Standalone;

public class VertexArrayObject
{
	private uint _vertexArrayObject;

	private uint _vertexBuffer;

	private uint _uvBuffer;

	private uint _indexBuffer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private VertexArrayObject(uint vertexArrayObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadVertexData(float[] vertices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadUVData(float[] uvs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadIndexData(uint[] indices)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadDataToBuffer(uint buffer, float[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadDataToIndexBuffer(uint buffer, uint[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Bind()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void UnBind()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static uint CreateArrayBuffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static uint CreateElementArrayBuffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VertexArrayObject Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static VertexArrayObject CreateWithUVBuffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void BindBuffer(uint index, uint buffer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void BindIndexBuffer(uint buffer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static uint CreateVertexArray()
	{
		throw null;
	}
}
