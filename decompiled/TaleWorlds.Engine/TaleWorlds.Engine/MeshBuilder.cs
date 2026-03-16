using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

public class MeshBuilder
{
	[EngineStruct("rglMeshBuilder_face_corner", false, null)]
	public struct FaceCorner
	{
		public int vertexIndex;

		public Vec2 uvCoord;

		public Vec3 normal;

		public uint color;
	}

	[EngineStruct("rglMeshBuilder_face", false, null)]
	public struct Face
	{
		public int fc0;

		public int fc1;

		public int fc2;
	}

	private List<Vec3> vertices;

	private List<FaceCorner> faceCorners;

	private List<Face> faces;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MeshBuilder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddFaceCorner(Vec3 position, Vec3 normal, Vec2 uvCoord, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddFace(int patchNode0, int patchNode1, int patchNode2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mesh Finalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mesh CreateUnitMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mesh CreateTilingWindowMesh(string baseMeshName, Vec2 meshSizeMin, Vec2 meshSizeMax, Vec2 borderThickness, Vec2 bgBorderThickness)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mesh CreateTilingButtonMesh(string baseMeshName, Vec2 meshSizeMin, Vec2 meshSizeMax, Vec2 borderThickness)
	{
		throw null;
	}
}
