using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

[EngineClass("rglTwo_dimension_view")]
public sealed class TwoDimensionView : View
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal TwoDimensionView(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static TwoDimensionView CreateTwoDimension(string viewName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BeginFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EndFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateMeshFromDescription(WeakMaterial material, TwoDimensionMeshDrawData meshDrawData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CreateTextMeshFromCache(Material material, TwoDimensionTextMeshDrawData meshDrawData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateTextMeshFromDescription(float[] vertices, float[] uvs, uint[] indices, int indexCount, Material material, TwoDimensionTextMeshDrawData meshDrawData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WeakMaterial GetOrCreateMaterial(Texture mainTexture, Texture overlayTexture)
	{
		throw null;
	}
}
