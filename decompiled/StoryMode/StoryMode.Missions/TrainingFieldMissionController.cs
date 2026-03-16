using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Conversation.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace StoryMode.Missions;

public class TrainingFieldMissionController : MissionLogic
{
	public class TutorialObjective
	{
		private TextObject _name;

		public string Id
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

		public bool IsFinished
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

		public bool HasBackground
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

		public bool IsActive
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

		public List<TutorialObjective> SubTasks
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

		public float Score
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
		public TutorialObjective(string id, bool isFinished = false, bool isActive = false, bool hasBackground = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetTextVariableOfName(string tag, int variable)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetNameString()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool SetActive(bool isActive)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool FinishTask()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void FinishSubTask(string subTaskName, float score)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool SetAllSubTasksInactive()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddSubTask(TutorialObjective newSubTask)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RestoreScoreFromSave(float score)
		{
			throw null;
		}
	}

	public struct DelayedAction
	{
		private float _orderGivenTime;

		private float _delayTime;

		private Action _order;

		private string _explanation;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DelayedAction(Action order, float delayTime, string explanation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Update()
		{
			throw null;
		}
	}

	public enum MouseObjectives
	{
		None,
		AttackLeft,
		AttackRight,
		AttackUp,
		AttackDown,
		DefendLeft,
		DefendRight,
		DefendUp,
		DefendDown
	}

	public enum ObjectivePerformingType
	{
		None,
		ByLookDirection,
		ByMovement,
		AutoBlock
	}

	private enum HorseReturningSituation
	{
		NotInPosition,
		BeginReturn,
		Returning,
		ReturnCompleted,
		Following
	}

	private const string SoundBasicMeleeGreet = "event:/mission/tutorial/vo/parrying/greet";

	private const string SoundBasicMeleeBlockLeft = "event:/mission/tutorial/vo/parrying/block_left";

	private const string SoundBasicMeleeBlockRight = "event:/mission/tutorial/vo/parrying/block_right";

	private const string SoundBasicMeleeBlockUp = "event:/mission/tutorial/vo/parrying/block_up";

	private const string SoundBasicMeleeBlockDown = "event:/mission/tutorial/vo/parrying/block_down";

	private const string SoundBasicMeleeAttackLeft = "event:/mission/tutorial/vo/parrying/attack_left";

	private const string SoundBasicMeleeAttackRight = "event:/mission/tutorial/vo/parrying/attack_right";

	private const string SoundBasicMeleeAttackUp = "event:/mission/tutorial/vo/parrying/attack_up";

	private const string SoundBasicMeleeAttackDown = "event:/mission/tutorial/vo/parrying/attack_down";

	private const string SoundBasicMeleeRemark = "event:/mission/tutorial/vo/parrying/remark";

	private const string SoundBasicMeleePraise = "event:/mission/tutorial/vo/parrying/praise";

	private const string SoundAdvancedMeleeGreet = "event:/mission/tutorial/vo/fighting/greet";

	private const string SoundAdvancedMeleeWarning = "event:/mission/tutorial/vo/fighting/warning";

	private const string SoundAdvancedMeleePlayerLose = "event:/mission/tutorial/vo/fighting/player_lose";

	private const string SoundAdvancedMeleePlayerWin = "event:/mission/tutorial/vo/fighting/player_win";

	private const string SoundRangedPickPrefix = "event:/mission/tutorial/vo/archery/pick_";

	private const string SoundRangedStartTraining = "event:/mission/tutorial/vo/archery/start_training";

	private const string SoundRangedHitTarget = "event:/mission/tutorial/vo/archery/hit_target";

	private const string SoundRangedMissTarget = "event:/mission/tutorial/vo/archery/miss_target";

	private const string SoundRangedFinish = "event:/mission/tutorial/vo/archery/finish";

	private const string SoundMountedPickPrefix = "event:/mission/tutorial/vo/riding/pick_";

	private const string SoundMountedMountHorse = "event:/mission/tutorial/vo/riding/mount_horse";

	private const string SoundMountedStartCourse = "event:/mission/tutorial/vo/riding/start_course";

	private const string SoundMountedCourseFinish = "event:/mission/tutorial/vo/riding/course_finish";

	private const string SoundMountedCoursePerfect = "event:/mission/tutorial/vo/riding/course_perfect";

	private const string FinishCourseSound = "event:/mission/tutorial/finish_course";

	private const string FinishTaskSound = "event:/mission/tutorial/finish_task";

	private const string HitTargetSound = "event:/mission/tutorial/hit_target";

	private TextObject _trainingFinishedText;

	private List<DelayedAction> _delayedActions;

	private MissionConversationLogic _missionConversationHandler;

	private const string RangedNpcCharacter = "tutorial_npc_ranged";

	private const string BowTrainingShootingPositionTag = "bow_training_shooting_position";

	private const string SpawnerRangedNpcTag = "spawner_ranged_npc_tag";

	private const string RangedNpcTargetTag = "_ranged_npc_target";

	private const float ShootingPositionActivationDistance = 2f;

	private const string BasicMeleeNpcSpawnPointTag = "spawner_melee_npc";

	private const string BasicMeleeNpcCharacter = "tutorial_npc_basic_melee";

	private const string AdvancedMeleeNpcSpawnPointTagEasy = "spawner_adv_melee_npc_easy";

	private const string AdvancedMeleeNpcSpawnPointTagNormal = "spawner_adv_melee_npc_normal";

	private const string AdvancedMeleeNpcEasySecondPositionTag = "adv_melee_npc_easy_second_pos";

	private const string AdvancedMeleeNpcNormalSecondPositionTag = "adv_melee_npc_normal_second_pos";

	private const string AdvancedMeleeEasyNpcCharacter = "tutorial_npc_advanced_melee_easy";

	private const string AdvancedMeleeNormalNpcCharacter = "tutorial_npc_advanced_melee_normal";

	private const string AdvancedMeleeBattleAreaTag = "battle_area";

	private const string MountedAISpawnPositionTag = "_mounted_ai_spawn_position";

	private const string MountedAICharacter = "tutorial_npc_mounted_ai";

	private const string MountedAITargetTag = "_mounted_ai_target";

	private const string MountedAIWaitingPositionTag = "_mounted_ai_waiting_position";

	private const string CheckpointTag = "mounted_checkpoint";

	private const string HorseSpawnPositionTag = "spawner_horse";

	private const string FinishGateClosedTag = "finish_gate_closed";

	private const string FinishGateOpenTag = "finish_gate_open";

	private const string NameOfTheHorse = "old_horse";

	private readonly List<TutorialArea> _trainingAreas;

	private TutorialArea _activeTutorialArea;

	private bool _courseFinished;

	private int _trainingProgress;

	private int _trainingSubTypeIndex;

	private string _activeTrainingSubTypeTag;

	private float _beginningTime;

	private float _timeScore;

	private bool _showTutorialObjectivesAnyway;

	private Dictionary<string, float> _tutorialScores;

	private GameEntity _shootingPosition;

	private Agent _bowNpc;

	private WorldPosition _rangedNpcSpawnPosition;

	private WorldPosition _rangedTargetPosition;

	private Vec3 _rangedTargetRotation;

	private GameEntity _rangedNpcSpawnPoint;

	private int _rangedLastBrokenTargetCount;

	private List<DestructableComponent> _targetsForRangedNpc;

	private DestructableComponent _lastTargetGiven;

	private bool _atShootingPosition;

	private bool _targetPositionSet;

	private List<TutorialObjective> _rangedObjectives;

	private TextObject _remainingTargetText;

	private Agent _meleeTrainer;

	private WorldPosition _meleeTrainerDefaultPosition;

	private float _timer;

	private List<TutorialObjective> _meleeObjectives;

	private Agent _advancedMeleeTrainerEasy;

	private Agent _advancedMeleeTrainerNormal;

	private float _playerCampaignHealth;

	private float _playerHealth;

	private float _advancedMeleeTrainerEasyHealth;

	private float _advancedMeleeTrainerNormalHealth;

	private MatrixFrame _advancedMeleeTrainerEasyInitialPosition;

	private MatrixFrame _advancedMeleeTrainerEasySecondPosition;

	private MatrixFrame _advancedMeleeTrainerNormalInitialPosition;

	private MatrixFrame _advancedMeleeTrainerNormalSecondPosition;

	private readonly TextObject _fightStartsIn;

	private readonly List<TutorialObjective> _advMeleeObjectives;

	private bool _playerLeftBattleArea;

	private GameEntity _finishGateClosed;

	private GameEntity _finishGateOpen;

	private int _finishGateStatus;

	private List<(VolumeBox, bool)> _checkpoints;

	private int _currentCheckpointIndex;

	private int _mountedLastBrokenTargetCount;

	private float _enteringDotProduct;

	private Agent _horse;

	private WorldPosition _horseBeginningPosition;

	private HorseReturningSituation _horseBehaviorMode;

	private List<TutorialObjective> _mountedObjectives;

	private Agent _mountedAI;

	private MatrixFrame _mountedAISpawnPosition;

	private MatrixFrame _mountedAIWaitingPosition;

	private int _mountedAICurrentCheckpointTarget;

	private int _mountedAICurrentHitTarget;

	private bool _enteredRadiusOfTarget;

	private bool _allTargetsDestroyed;

	private List<DestructableComponent> _mountedAITargets;

	private bool _continueLoop;

	private List<Vec3> _mountedAICheckpointList;

	private List<TutorialObjective> _detailedObjectives;

	private readonly List<TutorialObjective> _tutorialObjectives;

	public Action UIStartTimer;

	public Func<float> UIEndTimer;

	public Action<string> TimerTick;

	public Action<TextObject> CurrentObjectiveTick;

	public Action<MouseObjectives, ObjectivePerformingType> CurrentMouseObjectiveTick;

	public Action<List<TutorialObjective>> AllObjectivesTick;

	private static bool _updateObjectivesWillBeCalled;

	private Agent _brotherConversationAgent;

	public TextObject InitialCurrentObjective
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
	public override void OnCreated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LoadTutorialScores()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRenderingStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateObjectives()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetSelectedTrainingSubTypeIndex()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetHighlightedWeaponRack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EnableAllTrainingIcons()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrainingAreaUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateConversationPermission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetTrainingArea()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTrainingAreaExit(bool enableTrainingIcons)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckAllObjectivesFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTrainingAreaEnter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InTrainingArea()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnStartTraining(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EndTraining()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SuccessfullyFinishTraining(float score)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefillAmmoOfAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpecialTrainingAreaExit(TrainingType trainingType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpecialTrainingAreaEnter(TrainingType trainingType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpecialTrainingStart(TrainingType trainingType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpecialInTrainingAreaUpdate(TrainingType trainingType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DropAllWeaponsOfMainAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveAllWeaponsFromMainAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CollectWeaponsAndObjectives()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeAllAgentsImmortal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool HasAllWeaponsPicked()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckMainAgentEquipment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EndTimer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnConversationBrother()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeBowTraining()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GiveMoveOrderToRangedAgent(WorldPosition worldPosition, Vec3 rotation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WeakGameEntity GetValidTarget()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateBowTraining()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBowTrainingEnter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnBowNPC()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BowInTrainingAreaUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadCrossbowForStarting()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentShootMissile(Agent shooterAgent, EquipmentIndex weaponIndex, Vec3 position, Vec3 velocity, Mat3 orientation, bool hasRigidBody, int forcedMissileIndex = -1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BowTrainingEndedSuccessfully()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBowTrainingStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnBowTrainingExit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeAdvancedMeleeTraining()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnAdvancedMeleeTrainerEasy()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnAdvancedMeleeTrainerNormal()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AdvancedMeleeTrainingUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndHandlePlayerInsideBattleArea()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerLeftBattleArea()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerReEnteredBattleArea()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEasyTrainerBeaten()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeTrainersPatrolling()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnLost()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BeginNPCFight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAdvancedTrainingStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAdvancedTrainingExit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnAdvancedTrainingAreaEnter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetAgentDefensiveness(Agent agent, float formationOrderDefensivenessFactor)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeMeleeTraining()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MeleeTrainingUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SwordTraining()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShieldTraining()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnScoreHit(Agent affectedAgent, Agent affectorAgent, WeaponComponentData attackerWeapon, bool isBlocked, bool isSiegeEngineHit, in Blow blow, in AttackCollisionData collisionData, float damagedHp, float hitDistance, float shotDifficulty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickMouseObjective(MouseObjectives objective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsAttackDirection(MouseObjectives objective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MouseObjectives GetAdjustedMouseObjective(MouseObjectives baseObjective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ObjectivePerformingType GetObjectivePerformingType(MouseObjectives baseObjective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MouseObjectives GetInverseDirection(MouseObjectives objective)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeMountedTraining()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnMountedAI()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMountedAIBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GoToStartingPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RestoreAndShowAllMountedAITargets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HideAllMountedAITargets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateHorseBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnHorse()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MountedTrainingUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetCheckpoints()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckpointUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetHorseMountable(bool mountable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMountedTrainingStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMountedTrainingExit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetFinishGateStatus(bool open)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MountedTrainingEndedSuccessfully()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TrainingFieldMissionController()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static TrainingFieldMissionController()
	{
		throw null;
	}
}
