using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Objects.Cinematics;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics.Hideout;

public class HideoutAmbushBossFightCinematicController : MissionLogic
{
	public delegate void OnInitialFadeOutFinished(ref Agent playerAgent, ref List<Agent> playerCompanions, ref Agent bossAgent, ref List<Agent> bossCompanions, ref float placementPerturbation, ref float placementAngle);

	public delegate void OnHideoutCinematicFinished();

	public readonly struct HideoutCinematicAgentInfo
	{
		public readonly Agent Agent;

		public readonly MatrixFrame InitialFrame;

		public readonly MatrixFrame TargetFrame;

		public readonly HideoutAgentType Type;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public HideoutCinematicAgentInfo(Agent agent, HideoutAgentType type, in MatrixFrame initialFrame, in MatrixFrame targetFrame)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool HasReachedTarget(float proximityThreshold = 0.5f)
		{
			throw null;
		}
	}

	public enum HideoutCinematicState
	{
		None,
		InitialFadeOut,
		PreCinematic,
		Cinematic,
		PostCinematic,
		Completed
	}

	public enum HideoutAgentType
	{
		Player,
		Boss,
		Ally,
		Bandit
	}

	public enum HideoutPreCinematicPhase
	{
		NotStarted,
		InitializeFormations,
		StopFormations,
		InitializeAgents,
		MoveAgents,
		Completed
	}

	public enum HideoutPostCinematicPhase
	{
		NotStarted,
		MoveAgents,
		FinalizeAgents,
		Completed
	}

	private const float AgentTargetProximityThreshold = 0.5f;

	private const float AgentMaxSpeedCinematicOverride = 0.65f;

	public const string HideoutSceneEntityTag = "hideout_boss_fight";

	public const float DefaultTransitionDuration = 0.4f;

	public const float DefaultStateDuration = 0.2f;

	public const float DefaultCinematicDuration = 8f;

	public const float DefaultPlacementPerturbation = 0.25f;

	public const float DefaultPlacementAngle = MathF.PI / 15f;

	private OnInitialFadeOutFinished _initialFadeOutFinished;

	private float _cinematicDuration;

	private float _stateDuration;

	private float _transitionDuration;

	private float _remainingCinematicDuration;

	private float _remainingStateDuration;

	private float _remainingTransitionDuration;

	private List<Formation> _cachedAgentFormations;

	private List<HideoutCinematicAgentInfo> _hideoutAgentsInfo;

	private HideoutCinematicAgentInfo _bossAgentInfo;

	private HideoutCinematicAgentInfo _playerAgentInfo;

	private bool _isBehaviorInit;

	private HideoutPreCinematicPhase _preCinematicPhase;

	private HideoutPostCinematicPhase _postCinematicPhase;

	private HideoutBossFightBehavior _hideoutBossFightBehavior;

	public HideoutCinematicState State
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

	public bool InStateTransition
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

	public bool IsCinematicActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float CinematicDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float TransitionDuration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override MissionBehaviorType BehaviorType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event Action OnCinematicFinished
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

	public event Action<HideoutCinematicState> OnCinematicStateChanged
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

	public event Action<HideoutCinematicState, float> OnCinematicTransition
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
	public HideoutAmbushBossFightCinematicController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartCinematic(OnInitialFadeOutFinished initialFadeOutFinished, Action cinematicFinishedCallback, float transitionDuration = 0.4f, float stateDuration = 0.2f, float cinematicDuration = 8f, bool forceDismountAgents = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBossStandingEyePosition(out Vec3 eyePosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetPlayerStandingEyePosition(out Vec3 eyePosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MatrixFrame GetBanditsInitialFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetScenePrefabParameters(out float innerRadius, out float outerRadius, out float walkDistance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickStateTransition(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TickInitialFadeOut(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TickPreCinematic(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TickCinematic(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool TickPostCinematic(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BeginStateTransition(HideoutCinematicState nextState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ComputeAgentFrames(Agent playerAgent, List<Agent> playerCompanions, Agent bossAgent, List<Agent> bossCompanions, float placementPerturbation, float placementAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetAllyFrames(out List<MatrixFrame> initialFrames, out List<MatrixFrame> targetFrames, MatrixFrame initialPlayerFrame, MatrixFrame targetPlayerFrame, int agentCount, float agentOffsetAngle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSpineTroopCount(int totalTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetBanditFrames(out List<MatrixFrame> initialFrames, out List<MatrixFrame> targetFrames, MatrixFrame initialBossFrame, MatrixFrame targetBossFrame, int agentCount, float agentOffsetAngle)
	{
		throw null;
	}
}
