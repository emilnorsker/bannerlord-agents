using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Engine.Options;

public class NativeOptions
{
	public enum ConfigQuality
	{
		GFXVeryLow,
		GFXLow,
		GFXMedium,
		GFXHigh,
		GFXVeryHigh,
		GFXCustom
	}

	public enum NativeOptionsType
	{
		None = -1,
		MasterVolume,
		SoundVolume,
		MusicVolume,
		VoiceChatVolume,
		VoiceOverVolume,
		SoundDevice,
		MaxSimultaneousSoundEventCount,
		SoundPreset,
		KeepSoundInBackground,
		SoundOcclusion,
		MouseSensitivity,
		InvertMouseYAxis,
		MouseYMovementScale,
		TrailAmount,
		EnableVibration,
		EnableGyroAssistedAim,
		GyroAimSensitivity,
		EnableTouchpadMouse,
		EnableAlternateAiming,
		DisplayMode,
		SelectedMonitor,
		SelectedAdapter,
		ScreenResolution,
		RefreshRate,
		ResolutionScale,
		FrameLimiter,
		VSync,
		Brightness,
		OverAll,
		ShaderQuality,
		TextureBudget,
		TextureQuality,
		ShadowmapResolution,
		ShadowmapType,
		ShadowmapFiltering,
		ParticleDetail,
		ParticleQuality,
		FoliageQuality,
		CharacterDetail,
		EnvironmentDetail,
		TerrainQuality,
		NumberOfRagDolls,
		AnimationSamplingQuality,
		Occlusion,
		TextureFiltering,
		WaterQuality,
		Antialiasing,
		DLSS,
		LightingQuality,
		DecalQuality,
		DepthOfField,
		SSR,
		ClothSimulation,
		InteractiveGrass,
		SunShafts,
		SSSSS,
		Tesselation,
		Bloom,
		FilmGrain,
		MotionBlur,
		SharpenAmount,
		PostFXLensFlare,
		PostFXStreaks,
		PostFXChromaticAberration,
		PostFXVignette,
		PostFXHexagonVignette,
		BrightnessMin,
		BrightnessMax,
		BrightnessCalibrated,
		ExposureCompensation,
		DynamicResolution,
		DynamicResolutionTarget,
		FSR,
		PhysicsTickRate,
		NumOfOptionTypes,
		TotalOptions
	}

	public delegate void OnNativeOptionChangedDelegate(NativeOptionsType changedNativeOptionsType);

	public static OnNativeOptionChangedDelegate OnNativeOptionChanged;

	private static List<NativeOptionData> _videoOptions;

	private static List<NativeOptionData> _graphicsOptions;

	public static List<NativeOptionData> VideoOptions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static List<NativeOptionData> GraphicsOptions
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static event Action OnNativeOptionsApplied
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetGFXPresetName(ConfigQuality presetIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsGFXOptionChangeable(ConfigQuality config)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CorrectSelection(List<NativeOptionData> audioOptions)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReadRGLConfigFiles()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetConfig(NativeOptionsType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultConfig(NativeOptionsType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static float GetDefaultConfigForOverallSettings(NativeOptionsType type, int config)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetGameKeys(int keyType, int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetSoundDeviceName(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetMonitorDeviceName(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetVideoDeviceName(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetSoundDeviceCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetMonitorDeviceCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetVideoDeviceCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetResolutionCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RefreshOptionsData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetRefreshRateCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetRefreshRateAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetCustomResolution(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetResolution(ref int width, ref int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetDesktopResolution(ref int width, ref int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Vec2 GetResolutionAtIndex(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetDLSSTechnique()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool Is120HzAvailable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetDLSSOptionCount()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool GetIsDLSSAvailable()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CheckGFXSupportStatus(int enumType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetConfig(NativeOptionsType type, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyConfigChanges(bool resizeWindow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetGameKeys(int keyType, int index, int key)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Apply(int texture_budget, int sharpen_amount, int hdr, int dof_mode, int motion_blur, int ssr, int size, int texture_filtering, int trail_amount, int dynamic_resolution_target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveResult SaveConfig()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetBrightness(float gamma)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetDefaultGameKeys()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetDefaultGameConfig()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeOptions()
	{
		throw null;
	}
}
