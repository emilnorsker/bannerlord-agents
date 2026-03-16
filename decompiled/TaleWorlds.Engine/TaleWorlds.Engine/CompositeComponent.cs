using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineClass("rglComposite_component")]
public sealed class CompositeComponent : GameEntityComponent
{
	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public MatrixFrame Frame
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

	public Vec3 VectorUserData
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
	internal CompositeComponent(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsNull(CompositeComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CompositeComponent CreateCompositeComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CompositeComponent CreateCopy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddComponent(GameEntityComponent component)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddPrefabEntity(string prefabName, Scene scene)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	~CompositeComponent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetFactor1()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public uint GetFactor2()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFactor1(uint factorColor1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFactor2(uint factorColor2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVectorArgument(float vectorArgument0, float vectorArgument1, float vectorArgument2, float vectorArgument3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMaterial(Material material)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisibilityMask(VisibilityMaskFlags visibilityMask)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MetaMesh GetFirstMetaMesh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMultiMesh(string MultiMeshName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVisible(bool visible)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool GetVisible()
	{
		throw null;
	}
}
