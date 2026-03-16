using System;
using System.Runtime.CompilerServices;
using TaleWorlds.DotNet;
using TaleWorlds.Library;

namespace TaleWorlds.Engine;

[EngineClass("rglView")]
public abstract class View : NativeObject
{
	public enum TextureSaveFormat
	{
		TextureTypeUnknown,
		TextureTypeBmp,
		TextureTypeJpg,
		TextureTypePng,
		TextureTypeDds,
		TextureTypeTif,
		TextureTypePsd,
		TextureTypeRaw
	}

	public enum PostfxConfig : uint
	{
		pfx_config_bloom = 1u,
		pfx_config_sunshafts = 2u,
		pfx_config_motionblur = 4u,
		pfx_config_dof = 8u,
		pfx_config_tsao = 16u,
		pfx_config_fxaa = 64u,
		pfx_config_smaa = 128u,
		pfx_config_temporal_smaa = 256u,
		pfx_config_temporal_resolve = 512u,
		pfx_config_temporal_filter = 1024u,
		pfx_config_contour = 2048u,
		pfx_config_ssr = 4096u,
		pfx_config_sssss = 8192u,
		pfx_config_streaks = 16384u,
		pfx_config_lens_flares = 32768u,
		pfx_config_chromatic_aberration = 65536u,
		pfx_config_vignette = 131072u,
		pfx_config_sharpen = 262144u,
		pfx_config_grain = 524288u,
		pfx_config_temporal_shadow = 1048576u,
		pfx_config_editor_scene = 2097152u,
		pfx_config_custom1 = 16777216u,
		pfx_config_custom2 = 33554432u,
		pfx_config_custom3 = 67108864u,
		pfx_config_custom4 = 134217728u,
		pfx_config_hexagon_vignette = 268435456u,
		pfx_config_screen_rt_injection = 536870912u,
		pfx_config_high_dof = 1073741824u,
		pfx_lower_bound = 1u,
		pfx_upper_bound = 536870912u
	}

	public enum ViewRenderOptions
	{
		ClearColor,
		ClearDepth
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal View(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetScale(Vec2 scale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetOffset(Vec2 offset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderOrder(int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderOption(ViewRenderOptions optionEnum, bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderTarget(Texture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDepthTarget(Texture texture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DontClearBackground()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetClearColor(uint rgba)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnable(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetRenderOnDemand(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetAutoDepthTargetCreation(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetSaveFinalResultToDisk(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFileNameToSaveResult(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFileTypeToSave(TextureSaveFormat format)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFilePathToSaveResult(string name)
	{
		throw null;
	}
}
