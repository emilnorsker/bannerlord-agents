using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineClass("rglManaged_mesh_edit_operations")]
public sealed class ManagedMeshEditOperations : NativeObject
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ManagedMeshEditOperations(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ManagedMeshEditOperations Create(Mesh meshToEdit)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Weld()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddVertex(Vec3 vertexPos)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddFaceCorner(int vertexIndex, Vec2 uv0, Vec3 color, Vec3 normal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddFaceCorner(int vertexIndex, Vec2 uv0, Vec2 uv1, Vec3 color, Vec3 normal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddFace(int patchNode0, int patchNode1, int patchNode2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTriangle(Vec3 p1, Vec3 p2, Vec3 p3, Vec2 uv1, Vec2 uv2, Vec2 uv3, Vec3 color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTriangle(Vec3 p1, Vec3 p2, Vec3 p3, Vec3 n1, Vec3 n2, Vec3 n3, Vec2 uv1, Vec2 uv2, Vec2 uv3, Vec3 c1, Vec3 c2, Vec3 c3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRectangle3(Vec3 o, Vec2 size, Vec2 uv_origin, Vec2 uvSize, Vec3 color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRectangleWithInverseUV(Vec3 o, Vec2 size, Vec2 uv_origin, Vec2 uvSize, Vec3 color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRect(Vec3 originBegin, Vec3 originEnd, Vec2 uvBegin, Vec2 uvEnd, Vec3 color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddRectWithZUp(Vec3 originBegin, Vec3 originEnd, Vec2 uvBegin, Vec2 uvEnd, Vec3 color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InvertFacesWindingOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ScaleVertices(float newScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MoveVerticesAlongNormal(float moveAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ScaleVertices(Vec3 newScale, bool keepUvX = false, float maxUvSize = 1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TranslateVertices(Vec3 newOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMeshAux(Mesh mesh, MatrixFrame frame, sbyte boneNo, Vec3 color, bool transformNormal, bool heightGradient, bool addSkinData, bool useDoublePrecision = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int ComputeTangents(bool checkFixedNormals)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GenerateGrid(Vec2i numEdges, Vec2 edgeScale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RescaleMesh2d(Vec2 scaleSizeMin, Vec2 scaleSizeMax)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RescaleMesh2dRepeatX(Vec2 scaleSizeMin, Vec2 scaleSizeMax, float frameThickness = 0f, int frameSide = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RescaleMesh2dRepeatY(Vec2 scaleSizeMin, Vec2 scaleSizeMax, float frameThickness = 0f, int frameSide = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RescaleMesh2dRepeatXWithTiling(Vec2 scaleSizeMin, Vec2 scaleSizeMax, float frameThickness = 0f, int frameSide = 0, float xyRatio = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RescaleMesh2dRepeatYWithTiling(Vec2 scaleSizeMin, Vec2 scaleSizeMax, float frameThickness = 0f, int frameSide = 0, float xyRatio = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RescaleMesh2dWithoutChangingUV(Vec2 scaleSizeMin, Vec2 scaleSizeMax, float remaining)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddLine(Vec3 start, Vec3 end, Vec3 color, float lineWidth = 0.004f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComputeCornerNormals(bool checkFixedNormals = false, bool smoothCornerNormals = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComputeCornerNormalsWithSmoothingData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMesh(Mesh mesh, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMeshWithSkinData(Mesh mesh, MatrixFrame frame, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMeshWithColor(Mesh mesh, MatrixFrame frame, Vec3 vertexColor, bool useDoublePrecision = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMeshToBone(Mesh mesh, MatrixFrame frame, sbyte boneIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMeshWithFixedNormals(Mesh mesh, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMeshWithFixedNormalsWithHeightGradientColor(Mesh mesh, MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddSkinnedMeshWithColor(Mesh mesh, MatrixFrame frame, Vec3 vertexColor, bool useDoublePrecision = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCornerVertexColor(int cornerNo, Vec3 vertexColor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCornerUV(int cornerNo, Vec2 newUV, int uvNumber = 0)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReserveVertices(int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReserveFaceCorners(int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReserveFaces(int count)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int RemoveDuplicatedCorners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TransformVerticesToParent(MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TransformVerticesToLocal(MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVertexColor(Vec3 color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetVertexColor(int faceCornerIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVertexColorAlpha(float newAlpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetVertexColorAlpha()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void EnsureTransformedVertices()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplyCPUSkinning(Skeleton skeleton)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateOverlappedVertexNormals(Mesh attachedToMesh, MatrixFrame attachFrame, float mergeRadiusSQ = 0.0025f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTangentsOfFaceCorner(int faceCornerIndex, Vec3 tangent, Vec3 binormal)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPositionOfVertex(int vertexIndex, Vec3 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetPositionOfVertex(int vertexIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveFace(int faceIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeEditing()
	{
		throw null;
	}
}
