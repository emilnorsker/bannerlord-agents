using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace psai.net;

public class PsaiCore
{
	private Logik m_logik;

	private static PsaiCore s_singleton;

	public static PsaiCore Instance
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
	public static bool IsInstanceInitialized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiCore()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult SetMaximumLatencyNeededByPlatformToBufferSounddata(int latencyInMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult SetMaximumLatencyNeededByPlatformToPlayBackBufferedSounddata(int latencyInMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult LoadSoundtrackFromProjectFile(List<string> pathToProjectFiles)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult TriggerMusicTheme(int themeId, float intensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult TriggerMusicTheme(int themeId, float intensity, int musicDurationInSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult AddToCurrentIntensity(float deltaIntensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult StopMusic(bool immediately)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult StopMusic(bool immediately, float fadeOutSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult ReturnToLastBasicMood(bool immediately)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult GoToRest(bool immediately, float fadeOutSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult GoToRest(bool immediately, float fadeOutSeconds, int restTimeMin, int restTimeMax)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult HoldCurrentIntensity(bool hold)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetVersion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetVolume()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetVolume(float volume)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPaused(bool setPaused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetCurrentIntensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiInfo GetPsaiInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SoundtrackInfo GetSoundtrackInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ThemeInfo GetThemeInfo(int themeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SegmentInfo GetSegmentInfo(int segmentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCurrentSegmentId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetCurrentThemeId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRemainingMillisecondsOfCurrentSegmentPlayback()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetRemainingMillisecondsUntilNextSegmentStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult MenuModeEnter(int menuThemeId, float menuThemeIntensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult MenuModeLeave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool MenuModeIsActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CutSceneIsActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult CutSceneEnter(int themeId, float intensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult CutSceneLeave(bool immediately, bool reset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult PlaySegment(int segmentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfAtLeastOneDirectTransitionOrLayeringIsPossible(int sourceSegmentId, int targetThemeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLastBasicMood(int themeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release()
	{
		throw null;
	}
}
