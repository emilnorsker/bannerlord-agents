using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics.Arena;

public class ArenaDuelMissionController : MissionLogic
{
	private CharacterObject _duelCharacter;

	private bool _requireCivilianEquipment;

	private bool _spawnBothSideWithHorses;

	private bool _duelHasEnded;

	private Agent _duelAgent;

	private float _customAgentHealth;

	private BasicMissionTimer _duelEndTimer;

	private MBList<MatrixFrame> _initialSpawnFrames;

	private static Action<CharacterObject> _onDuelEnd;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ArenaDuelMissionController(CharacterObject duelCharacter, bool requireCivilianEquipment, bool spawnBothSideWithHorses, Action<CharacterObject> onDuelEnd, float customAgentHealth)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeMissionTeams()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeactivateOtherTournamentSets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Agent SpawnAgent(CharacterObject character, MatrixFrame spawnFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override InquiryData OnEndMissionRequest(out bool canPlayerLeave)
	{
		throw null;
	}
}
