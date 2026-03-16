using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

public class MissionAudienceHandler : MissionView
{
	private const int GapBetweenCheerSmallInSeconds = 10;

	private const int GapBetweenCheerMedium = 4;

	private float _minChance;

	private float _maxChance;

	private float _minDist;

	private float _maxDist;

	private float _minHeight;

	private float _maxHeight;

	private List<GameEntity> _audienceMidPoints;

	private List<KeyValuePair<GameEntity, float>> _audienceList;

	private readonly float _density;

	private GameEntity _arenaSoundEntity;

	private SoundEvent _ambientSoundEvent;

	private MissionTime _lastOneShotSoundEventStarted;

	private bool _allOneShotSoundEventsAreDisabled;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAudienceHandler(float density)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Cheer(bool onEnd = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetAudienceEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private float GetDistanceSquareToArena(GameEntity audienceEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CharacterObject GetRandomAudienceCharacterToSpawn()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnAudienceAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionModeChange(MissionMode oldMissionMode, bool atStart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}
}
