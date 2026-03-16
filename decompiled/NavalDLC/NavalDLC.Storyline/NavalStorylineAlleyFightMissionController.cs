using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Storyline;

public class NavalStorylineAlleyFightMissionController : MissionLogic
{
	private const string EnemyTroopStringId = "naval_storyline_alley_fight_enemy";

	private const float SpeechDelayAfterCombatDuration = 1.5f;

	private const float BanterNotificationRepeatDuration = 12f;

	private const string GangradirEquipmentId = "item_set_gangradir_alleyfight";

	private bool _isMissionInitialized;

	private bool _isMissionFailed;

	private List<GameEntity> _entities;

	private Agent _gangradirAgent;

	private bool _willGangradirBecomeVulnerable;

	private float _gangradirInvulnerabilityTimer;

	private float _gangradirInvulnerabilityDurationAfterCinematic;

	private bool _shouldShowEndNotification;

	private bool _shouldShowBanterNotifications;

	private float _banterNotificationTimer;

	private int _banterLineIndex;

	private List<TextObject> _banterLines;

	private bool _shoulStartOutroConversation;

	private float _speechDelayTimer;

	private bool _isEnemyAttackToPlayerQueued;

	private float _enemyAttackToPlayerTimer;

	private float _enemyAttackToPlayerDuration;

	private Agent _directedEnemyAgent;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
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
	public void OnCinematicStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartFight()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnGangradir(GameEntity spawnPoint)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnEnemyTroop(string spawnPointId, string animationId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTeamAgentsShouldAttack(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnEnemyTeamDefeated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TriggerCombatEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetupConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartPostFightConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowNotification(TextObject text, BasicCharacterObject speaker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPlayerTeamDefeated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CharacterObject GetEnemyCharacterObject()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnConversationEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool MissionEnded(ref MissionResult missionResult)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalStorylineAlleyFightMissionController()
	{
		throw null;
	}
}
