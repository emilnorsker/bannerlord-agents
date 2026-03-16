using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Storyline;
using NavalDLC.View.MissionViews;
using SandBox.Objects.AreaMarkers;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.GauntletUI.MissionViews;

[OverrideView(typeof(FloatingFortressView))]
public class MissionGauntletFloatingFortressView : FloatingFortressView
{
	private abstract class Keyframe<T>
	{
		public float Time
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public T Value
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Keyframe(float time, T value)
		{
			throw null;
		}
	}

	private abstract class Track<TKeyframe, TValue> where TKeyframe : Keyframe<TValue>
	{
		protected readonly List<TKeyframe> Keyframes;

		private int _lastKeyframeIndex;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddKeyframe(TKeyframe keyframe)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RemoveKeyframe(TKeyframe keyframe)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ClearKeyframes()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool IsCompleted(float time)
		{
			throw null;
		}

		public abstract TValue Evaluate(float time);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected (TKeyframe prev, TKeyframe next, float t) GetKeyframesAtTime(float time)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected Track()
		{
			throw null;
		}
	}

	private class MatrixFrameKeyFrame : Keyframe<MatrixFrame>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MatrixFrameKeyFrame(float time, MatrixFrame value)
		{
			throw null;
		}
	}

	private class MatrixFrameTrack : Track<MatrixFrameKeyFrame, MatrixFrame>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override MatrixFrame Evaluate(float time)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MatrixFrameTrack()
		{
			throw null;
		}
	}

	private class EventKeyframe : Keyframe<Action>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventKeyframe(float time, Action value)
		{
			throw null;
		}
	}

	private class EventTrack : Track<EventKeyframe, Action>
	{
		private readonly HashSet<EventKeyframe> _triggeredEvents;

		private float _lastEvaluatedTime;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Action Evaluate(float time)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventTrack()
		{
			throw null;
		}
	}

	private enum FadeOutReason
	{
		Initialize,
		BallistaCinematicEnded,
		PhaseOneCompleted
	}

	private const float EarliestSkipTime = 2.5f;

	private const float FadeOutTransitionTime = 1.5f;

	private readonly Dictionary<DestructableComponent, AnimatedBasicAreaIndicator> _markerByBallista;

	private bool _canInvokeFadeOutEvent;

	private FadeOutReason _fadeOutReason;

	private float _initialFadeOutWaitTime;

	private bool _isInitialized;

	private bool _isPhaseOneCompleted;

	private bool _isShowingBallistaHint;

	private bool _hasUsedBallista;

	private bool _willFadeOutForPhaseOneCompletion;

	private float _remainingTimeForPhaseOneFadeOut;

	private Camera _cinematicCamera;

	private bool _shouldTickCinematic;

	private float _cinematicElapsedTime;

	private MatrixFrameTrack _cinematicCameraTrack;

	private EventTrack _cinematicEventTrack;

	private FloatingFortressSetPieceBattleMissionController _controller;

	private MissionCameraFadeView _fadeView;

	private MissionHintLogic _hintLogic;

	private NavalShipsLogic _navalShipsLogic;

	private MissionMainAgentController _missionMainAgentController;

	private MissionGauntletShipControlView _shipControlView;

	private MissionGauntletShipControlView.ShipControlFeatureFlags _suspendedFeatures;

	public bool AreMarkersDirty
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
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBallistaDestroyed(DestructableComponent target, Agent attackerAgent, in MissionWeapon weapon, ScriptComponentBehavior attackerScriptComponentBehavior, int inflictedDamage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFixedMissionTick(float fixedDt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeCinematicKeyframes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPhaseOneCompleted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static AnimatedBasicAreaIndicator AddMarker(WeakGameEntity gameEntity, TextObject name, string type, float radius = 5f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletFloatingFortressView()
	{
		throw null;
	}
}
