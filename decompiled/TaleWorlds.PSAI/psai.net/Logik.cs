using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using psai.Editor;

namespace psai.net;

internal class Logik
{
	private const string PSAI_VERSION = ".NET 1.7.3";

	private const string m_fullVersionString = "psai Version .NET 1.7.3";

	internal const float COMPATIBILITY_PERCENTAGE_SAME_GROUP = 1f;

	internal const float COMPATIBILITY_PERCENTAGE_OTHER_GROUP = 0.5f;

	internal const int PSAI_CHANNEL_COUNT = 9;

	internal const int PSAI_CHANNEL_COUNT_HIGHLIGHTS = 2;

	internal const int PSAI_FADING_UPDATE_INVERVAL_MILLIS = 50;

	internal const int PSAI_FADEOUTMILLIS_PLAYIMMEDIATELY = 500;

	internal const int PSAI_FADEOUTMILLIS_STOPMUSIC = 1000;

	internal const int PSAI_FADEOUTMILLIS_HIGHLIGHT_INTERRUPTED = 2000;

	internal const int SNIPPET_TYPE_MIDDLE_OR_BRIDGE = 10;

	private static Random s_random;

	internal Soundtrack m_soundtrack;

	private List<FadeData> m_fadeVoices;

	private int m_currentVoiceNumber;

	private int m_targetVoice;

	private IPlatformLayer m_platformLayer;

	private bool m_initializationFailure;

	private static Stopwatch m_stopWatch;

	private Theme m_lastBasicMood;

	private int m_hilightVoiceIndex;

	private int m_lastRegularVoiceNumberReturned;

	private float m_psaiMasterVolume;

	private Segment m_currentSegmentPlaying;

	private int m_currentSnippetTypeRequested;

	private Theme m_effectiveTheme;

	private int m_timeStampCurrentSnippetPlaycall;

	private int m_estimatedTimestampOfTargetSnippetPlayback;

	private int m_timeStampOfLastIntensitySetForCurrentTheme;

	private int m_timeStampRestStart;

	private Segment m_targetSegment;

	private int m_targetSegmentSuitabilitiesRequested;

	private float m_currentIntensitySlope;

	private float m_lastIntensity;

	private bool m_holdIntensity;

	private float m_heldIntensity;

	private bool m_scheduleFadeoutUponSnippetPlayback;

	private float m_startOrRetriggerIntensityOfCurrentTheme;

	private int m_lastMusicDuration;

	private int m_remainingMusicDurationAtTimeOfHoldIntensity;

	private PsaiState m_psaiState;

	private PsaiState m_psaiStateIntended;

	private List<ThemeQueueEntry> m_themeQueue;

	private PsaiPlayMode m_psaiPlayMode;

	private PsaiPlayMode m_psaiPlayModeIntended;

	private bool m_returnToLastBasicMoodFlag;

	private PlaybackChannel[] m_playbackChannels;

	internal static int s_audioLayerMaximumLatencyForPlayingbackPrebufferedSounds;

	internal static int s_audioLayerMaximumLatencyForBufferingSounds;

	internal static int s_audioLayerMaximumLatencyForPlayingBackUnbufferedSounds;

	internal static int s_updateIntervalMillis;

	private PsaiTimer m_timerStartSnippetPlayback;

	private PsaiTimer m_timerSegmentEndApproaching;

	private PsaiTimer m_timerSegmentEndReached;

	private PsaiTimer m_timerFades;

	private PsaiTimer m_timerWakeUpFromRest;

	private int m_timeStampOfLastFadeUpdate;

	private ThemeQueueEntry m_latestEndOfSegmentTriggerCall;

	private bool m_paused;

	private int m_timeStampPauseOn;

	private int m_restModeSecondsOverride;

	internal static Logik Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GetRandomInt(int min, int max)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float GetRandomFloat()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void UpdateMaximumLatencyForPlayingBackUnbufferedSounds()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult SetMaximumLatencyNeededByPlatformToBufferSounddata(int latencyInMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult SetMaximumLatencyNeededByPlatformToPlayBackBufferedSounds(int latencyInMilliseconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Logik()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Logik()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult LoadSoundtrackFromProjectFile(List<string> pathToProjectFiles)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult LoadSoundtrackByPsaiProject(PsaiProject psaiProject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitMembersAfterSoundtrackHasLoaded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetLastBasicMoodId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLastBasicMood(int themeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool CheckIfFileExists(string filepath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetRemainingMusicDurationSecondsOfCurrentTheme()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GetTimestampMillisElapsedSinceInitialisation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PsaiResult Readfile_ProtoBuf(Stream stream)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal string getVersion()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal long GetCurrentSystemTimeMillis()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void startFade(int voiceId, int fadeoutMillis, int timeOffsetMillis)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddFadeData(int voiceNumber, int fadeoutMillis, float currentVolume, int delayMillis)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int getNextVoiceNumber(bool forHighlight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PsaiErrorCheck(PsaiResult result, string infoAboutLastCall)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetMillisElapsedAfterCurrentSnippetPlaycall()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult setPaused(bool setPaused)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetThemeAsLastBasicMood(Theme latestBasicMood)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfAnyThemeIsCurrentlyPlaying()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult ReturnToLastBasicMood(bool immediately)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int getUpcomingThemeId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult TriggerMusicTheme(int argThemeId, float argIntensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult TriggerMusicTheme(int argThemeId, float argIntensity, int argMusicDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult TriggerMusicTheme(Theme argTheme, float argIntensity, int argMusicDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float ClampPercentValue(float argValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult AddToCurrentIntensity(float deltaIntensity, bool resetIntensityFalloffToFullMusicDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult PlaySegmentLayeredAndImmediately(int segmentId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void PlaySegmentLayeredAndImmediately(Segment segment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PsaiResult startHighlight(Theme highlightTheme)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearLatestEndOfSegmentTriggerCall()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearQueuedTheme()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool pushThemeToThemeQueue(int themeId, float intensity, int musicDuration, bool clearThemeQueue, int restTimeMillis, PsaiPlayMode playMode, bool holdIntensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ThemeType getThemeTypeOfFirstThemeQueueEntry()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal float getUpcomingIntensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal float getCurrentIntensity()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PsaiResult PlaySegment(Segment targetSnippet, bool immediately)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PsaiResult LoadSegment(Segment snippet, int channelIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayTargetSegmentImmediately()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetSegmentEndApproachingAndReachedTimersAfterPlaybackHasStarted(int snippetPlaybackDelayMillis)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal float getVolume()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void setVolume(float vol)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PsaiResult PlayThemeNowOrAtEndOfCurrentSegmentAndStartEvaluation(ThemeQueueEntry tqe, bool immediately)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PsaiResult PlayThemeNowOrAtEndOfCurrentSegmentAndStartEvaluation(int themeId, float intensity, int musicDuration, bool immediately, bool holdIntensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult StopMusic(bool immediately)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult StopMusic(bool immediately, int fadeOutMilliSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WriteLogWarningIfThereIsNoDirectPathForEffectiveSnippetToEndSnippet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfThereIsAPathToEndSegmentForEffectiveSegmentAndLogWarningIfThereIsnt()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void updateFades()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult HoldCurrentIntensity(bool hold)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCurrentIntensityAndMusicDuration(float intensity, int musicDuration, bool recalculateIntensitySlope)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SegmentEndApproachingHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PsaiResult PlayThemeAtEndOfCurrentSegment(Theme argTheme, float intensity, int musicDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PsaiResult PlayThemeAtEndOfCurrentTheme(Theme argTheme, float argIntensity, int argMusicDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SegmentEndReachedHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitiateTransitionToRestOrSilence(PsaiState psaiStateIntended)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitiateTransitionToRestMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IntensityZeroHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult GoToRest(bool immediately, int fadeOutMilliSeconds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PsaiResult GoToRest(bool immediately, int fadeOutMilliSeconds, int restSecondsOverrideMin, int restSecondsOverrideMax)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnterRestMode(int themeIdToWakeUpWith, int themeIdToUseForRestingTimeCalculation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WakeUpFromRestHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Segment GetBestCompatibleSegment(Segment sourceSegment, int targetThemeId, float intensity, int allowedSegmentSuitabilities)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Segment GetBestStartSegmentForTheme(int themeId, float intensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Segment GetBestStartSegmentForTheme_internal(Theme theme, float intensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Segment ChooseBestSegmentFromList(List<Follower> segmentList, Weighting weighting, float intensity, int maxPlaycount, int minPlaycount, float maxDeltaIntensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlaySegmentOfCurrentTheme(SegmentSuitability snippetType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Segment substituteSegment(int themeId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnterSilenceMode()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool menuModeIsActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool cutSceneIsActive()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult MenuModeEnter(int menuThemeId, float menuIntensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult MenuModeLeave()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult CutSceneEnter(int themeId, float intensity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiResult CutSceneLeave(bool immediately, bool reset)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ThemeQueueEntry getFollowingThemeQueueEntry()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetPlayMode(PsaiPlayMode playMode)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PushEffectiveThemeToThemeQueue(PsaiPlayMode playModeToReturnTo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Segment GetEffectiveSegment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int getEffectiveThemeId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetEffectiveSegmentSuitabilitiesRequested()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopAndPlayNextFollowingTheme(bool immediately)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void removeFirstFollowingThemeQueueEntry()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal PsaiInfo getPsaiInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int getCurrentSnippetId()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetRemainingMillisecondsOfCurrentSegmentPlayback()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal int GetRemainingMillisecondsUntilNextSegmentStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool CheckIfAtLeastOneDirectTransitionOrLayeringIsPossible(int sourceSegmentId, int targetThemeId)
	{
		throw null;
	}
}
