using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Objects.AnimationPoints;
using TaleWorlds.Engine;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects.Usables;

public class MusicianGroup : UsableMachine
{
	public const int GapBetweenTracks = 8;

	public const bool DisableAmbientMusic = true;

	private const int TempoMidValue = 120;

	private const int TempoSpeedUpLimit = 130;

	private const int TempoSlowDownLimit = 100;

	private List<PlayMusicPoint> _musicianPoints;

	private SoundEvent _trackEvent;

	private BasicMissionTimer _gapTimer;

	private List<SettlementMusicData> _playList;

	private int _currentTrackIndex;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetActionTextForStandingPoint(UsableMissionObject usableGameObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText(WeakGameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override UsableMachineAIBase CreateAIBehaviorObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPlayList(List<SettlementMusicData> playList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TickRequirement GetTickRequirement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckNewTrackStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckTrackEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StopMusicians()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupInstruments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Tuple<InstrumentData, float> GetInstrumentEmptyData(int tempo)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartTrack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicianGroup()
	{
		throw null;
	}
}
