using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;

namespace NavalDLC.Storyline;

public class PirateBattleMissionController : MissionLogic
{
	private const int InitialAllyMeleeTroopCount = 10;

	private const int InitialAllyRangedTroopCount = 10;

	private const int SecondPhaseMinTotalAllyTroopCount = 14;

	private const int SecondPhasePrisonerMeleeTroopCount = 7;

	private const int SecondPhasePrisonerRangedTroopCount = 7;

	private const float AfterFightShipChangeDuration = 0.5f;

	private const string AllyMeleeTroopStringId = "gangradirs_kin_melee";

	private const string AllyRangedTroopStringId = "gangradirs_kin_ranged";

	private const string EnemyTroopStringId = "sea_hounds_pups";

	private const float MissionStateChangeTimer = 3f;

	private const float WindStrength = 1.5f;

	private const float FadeDuration = 0.5f;

	private const float BlackScreenDuration = 0.75f;

	private static readonly Dictionary<string, string> PlayerShipUpgradePieces;

	private static readonly Dictionary<string, string> SecondShipUpgradePieces;

	private static readonly Dictionary<string, string> ReinforcementShipUpgradePieces;

	private bool _isMissionInitialized;

	private List<GameEntity> _entities;

	private Agent _gangradirAgent;

	private MissionShip _playerShip;

	private MissionShip _secondShip;

	private MissionShip _reinforcementShip;

	private readonly MobileParty _pirateParty;

	private MissionTimer _victoryTimer;

	private MissionTimer _defeatTimer;

	private float _notificationTimer;

	private TextObject _currentNotificationText;

	private bool _isInSecondPhase;

	private bool _isMissionSuccessful;

	private bool _isMissionFailed;

	private bool _hasShownChargeNotification;

	private bool _hasShownSecondPhaseChargeNotification;

	private bool _hasIncreasedMusicIntensityForSecondPhase;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private MissionObjectiveLogic _missionObjectiveLogic;

	private bool _isGangradirAfterFightFirstNotificationShown;

	private bool _isGangradirAfterFightSecondNotificationShown;

	private float _afterFightShipChangeTimer;

	private bool _isShipTransferQueued;

	private bool _isSecondShipSelected;

	private readonly int _pirateTroopCount;

	private bool _isDialogueQueued;

	private bool _isSecondPhaseSetup;

	private float _dialogueTimer;

	public bool IsFirstShipCleared
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

	public bool HasSelectedShip
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

	public event Action<float, float> OnBeginScreenFadeEvent
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

	public event Action<float> OnCameraBearingNeedsUpdateEvent
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

	public event Action OnShipsInitializedEvent
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
	public PirateBattleMissionController(MobileParty pirateParty, int pirateTroopCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateEntityReferences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAllyTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnHero(CharacterObject character, string spawnPointTag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnEnemyAgents(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAllyPrisonerAgents(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionShip CreateShip(string shipHullId, string spawnPointId, Formation formation, PartyBase owner, Dictionary<string, string> upgradePieces, string materialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ChangeShipColors(MissionShip missionShip, uint color1, uint color2, string materialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSailColors(GameEntity sailEntity, uint sailColor1, uint sailColor2, string materialName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsShipEffectivelyDepleted(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEnemyTeamDefeated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowNotification(TextObject text)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFirstEnemyShipCleared()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFirstFightPopUpClosed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetupSecondPhase()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartDialogue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerSelectedFirstShipToCommand()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerSelectedSecondShipToCommand()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerSelectedShipToCommand()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleShipSelection(bool isFirstShipSelected)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ReplenishPlayerShipTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSecondEnemyShipCleared()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnVictoryPopUpClosed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerTeamDefeated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HaveAllyShipsBeenCutLoose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerOrdered(OrderType orderType, MBReadOnlyList<Formation> appliedFormations, OrderController orderController, object[] delegateParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowChargeNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowSecondPhaseChargeNotification()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PirateBattleMissionController()
	{
		throw null;
	}
}
