using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;

namespace TaleWorlds.Engine;

public sealed class Material : Resource
{
	public enum MBTextureType
	{
		DiffuseMap,
		DiffuseMap2,
		BumpMap,
		EnvironmentMap,
		SpecularMap
	}

	[EngineStruct("rglAlpha_blend_mode", true, "rgl_abm", false)]
	public enum MBAlphaBlendMode : byte
	{
		NoAlphaBlend,
		Modulate,
		AddAlpha,
		Multiply,
		Add,
		Max,
		Factor,
		AddModulateCombined,
		NoAlphaBlendNoWrite,
		ModulateNoWrite,
		GbufferAlphaBlend,
		GbufferAlphaBlendWithVtResolve,
		NoAlphaBlendNoAlphaWrite,
		Total
	}

	[Flags]
	private enum MBMaterialShaderFlags
	{
		UseSpecular = 1,
		UseSpecularMap = 2,
		UseHemisphericalAmbient = 4,
		UseEnvironmentMap = 8,
		UseDXT5Normal = 0x10,
		UseDynamicLight = 0x20,
		UseSunLight = 0x40,
		UseSpecularAlpha = 0x80,
		UseFresnel = 0x100,
		SunShadowReceiver = 0x200,
		DynamicShadowReceiver = 0x400,
		UseDiffuseAlphaMap = 0x800,
		UseParallaxMapping = 0x1000,
		UseParallaxOcclusion = 0x2000,
		UseAlphaTestingBit0 = 0x4000,
		UseAlphaTestingBit1 = 0x8000,
		UseAreaMap = 0x10000,
		UseDetailNormalMap = 0x20000,
		UseGroundSlopeAlpha = 0x40000,
		UseSelfIllumination = 0x80000,
		UseColorMapping = 0x100000,
		UseCubicAmbient = 0x200000
	}

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

	public bool UsingSpecular
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

	public bool UsingSpecularMap
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

	public bool UsingEnvironmentMap
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

	public bool UsingSpecularAlpha
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

	public bool UsingDynamicLight
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

	public bool UsingSunLight
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

	public bool UsingFresnel
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

	public bool IsSunShadowReceiver
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

	public bool IsDynamicShadowReceiver
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

	public bool UsingDiffuseAlphaMap
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

	public bool UsingParallaxMapping
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

	public bool UsingParallaxOcclusion
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

	public MaterialFlags Flags
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
	public static Material GetDefaultMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Material GetOutlineMaterial(Mesh mesh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Material GetDefaultTableauSampleMaterial(bool transparency)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Material CreateTableauMaterial(RenderTargetComponent.TextureUpdateEventHandler eventHandler, object objectRef, Material sampleMaterial, int tableauSizeX, int tableauSizeY, bool continuousTableau = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal Material(UIntPtr sourceMaterialPointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Material CreateCopy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Material GetFromResource(string materialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShader(Shader shader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Shader GetShader()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ulong GetShaderFlags()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetShaderFlags(ulong flagEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetMeshVectorArgument(float x, float y, float z, float w)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTexture(MBTextureType textureType, Texture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTextureAtSlot(int textureSlot, Texture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAreaMapScale(float scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnableSkinning(bool enable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool UsingSkinning()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture GetTexture(MBTextureType textureType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Texture GetTextureWithSlot(int textureSlot)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Material GetAlphaMaskTableauMaterial()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBAlphaBlendMode GetAlphaBlendMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAlphaBlendMode(MBAlphaBlendMode alphaBlendMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAlphaTestValue(float alphaTestValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetAlphaTestValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckMaterialShaderFlag(MBMaterialShaderFlags flagEntry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetMaterialShaderFlag(MBMaterialShaderFlags flagEntry, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMaterialShaderFlag(string flagName, bool showErrors)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveMaterialShaderFlag(string flagName)
	{
		throw null;
	}
}
