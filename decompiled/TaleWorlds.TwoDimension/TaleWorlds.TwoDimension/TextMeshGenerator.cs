using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

internal class TextMeshGenerator
{
	private struct MeshNormalizationInfo
	{
		public readonly float MeshWidth;

		public readonly float MeshHeight;

		public readonly float[] NormalizedVertices;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MeshNormalizationInfo(float meshWidth, float meshHeight, float[] normalizedVertices)
		{
			throw null;
		}
	}

	private Font _font;

	private float[] _vertices;

	private MeshNormalizationInfo _meshNormalizationInfo;

	private float[] _uvs;

	private uint[] _indices;

	private int _textMeshCharacterCount;

	private float _scaleValue;

	private bool _areVerticesNormalized;

	private Rectangle2D _drawRectangle;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal TextMeshGenerator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Refresh(Font font, int possibleMaxCharacterLength, float scaleValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal TextDrawObject GenerateMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MeshNormalizationInfo GetNormalizedVertices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddCharacterToMesh(float x, float y, BitmapFontCharacter fontCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddValueToX(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void AddValueToY(float value)
	{
		throw null;
	}
}
