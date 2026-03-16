using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineClass("rglMesh")]
public sealed class Mesh : Resource
{
	public string Name
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

	public MBMeshCullingMode CullingMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public float MorphTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	public uint Color
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

	public uint Color2
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

	public BillboardType Billboard
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

	public VisibilityMaskFlags VisibilityMask
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

	public int EditDataFaceCornerCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Mesh(UIntPtr meshPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mesh CreateMeshWithMaterial(Material material)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mesh CreateMesh(bool editable = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mesh GetBaseMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mesh GetFromResource(string meshName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Mesh GetRandomMeshWithVdecl(int inputLayout)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetColorAndStroke(uint color, uint strokeColor, bool drawStroke)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMeshRenderOrder(int renderOrder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasTag(string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Mesh CreateCopy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaterial(string newMaterialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVectorArgument(float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVectorArgument2(float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetVectorArgument()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetVectorArgument2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetupAdditionalBoneBuffer(int numBones)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAdditionalBoneFrame(int boneIndex, in MatrixFrame frame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaterial(Material material)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Material GetMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Material GetSecondMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddFaceCorner(Vec3 position, Vec3 normal, Vec2 uvCoord, uint color, UIntPtr lockHandle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int AddFace(int patchNode0, int patchNode1, int patchNode2, UIntPtr lockHandle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetColorAlpha(uint newAlpha)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetFaceCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetFaceCornerCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComputeNormals()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComputeTangents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMesh(string meshResourceName, MatrixFrame meshFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMesh(Mesh mesh, MatrixFrame meshFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetLocalFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLocalFrame(MatrixFrame meshFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisibilityMask(VisibilityMaskFlags visibilityMask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAsNotEffectedBySeason()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetBoundingBoxWidth()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetBoundingBoxHeight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetBoundingBoxMin()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Vec3 GetBoundingBoxMax()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTriangle(Vec3 p1, Vec3 p2, Vec3 p3, Vec2 uv1, Vec2 uv2, Vec2 uv3, uint color, UIntPtr lockHandle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTriangleWithVertexColors(Vec3 p1, Vec3 p2, Vec3 p3, Vec2 uv1, Vec2 uv2, Vec2 uv3, uint c1, uint c2, uint c3, UIntPtr lockHandle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HintIndicesDynamic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void HintVerticesDynamic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RecomputeBoundingBox()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEditDataFaceCornerVertexColor(int index, uint color)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetEditDataFaceCornerVertexColor(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PreloadForRendering()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetContourColor(Vec3 color, bool alwaysVisible, bool maskMesh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DisableContour()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetExternalBoundingBox(BoundingBox bbox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEditDataUser()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReleaseEditDataUser()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEditDataPolicy(EditDataPolicy policy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public UIntPtr LockEditDataWrite()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnlockEditDataWrite(UIntPtr handle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCustomClipPlane(Vec3 clipPlanePosition, Vec3 clipPlaneNormal, int planeIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetClothLinearVelocityMultiplier()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasCloth()
	{
		throw null;
	}
}
