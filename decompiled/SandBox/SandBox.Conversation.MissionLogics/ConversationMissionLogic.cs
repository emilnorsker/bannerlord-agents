using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Conversation.MissionLogics;

public class ConversationMissionLogic : MissionLogic
{
	private enum NavalConversationCameraState
	{
		None,
		SameShip,
		Level,
		LookDown,
		LookUp
	}

	private const float MinimumAgentHeightForRopeAnimation = 1.76f;

	private const float MaximumWindStrength = 6f;

	private const float MaximumWaveStrength = 2.5f;

	private const float WindStrengthAmplifier = 2f;

	private readonly List<Agent> _addBloodToAgents;

	private Agent _curConversationPartnerAgent;

	private bool _isRenderingStarted;

	private bool _conversationStarted;

	private bool _isCivilianEquipmentRequiredForLeader;

	private bool _isCivilianEquipmentRequiredForBodyGuards;

	private List<GameEntity> _usedSpawnPoints;

	private GameEntity _agentHangPointShort;

	private GameEntity _agentHangPointSecondShort;

	private GameEntity _agentHangPointTall;

	private GameEntity _agentHangPointSecondTall;

	private GameEntity _conversationSet;

	private bool _realCameraController;

	private readonly bool _isNaval;

	private float _otherPartyHeightMultiplier;

	private NavalConversationCameraState _navalConversationState;

	public GameEntity CustomConversationCameraEntity;

	private bool IsReadyForConversation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public ConversationCharacterData OtherSideConversationData
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

	public ConversationCharacterData PlayerConversationData
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

	public bool IsMultiAgentConversation
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
	public ConversationMissionLogic(ConversationCharacterData playerCharacterData, ConversationCharacterData otherCharacterData, bool isMultiAgentConversation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnPlayer(ConversationCharacterData playerConversationData, MatrixFrame initialFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnOtherSide(ConversationCharacterData characterData, MatrixFrame initialFrame, bool spawnWithHorse, bool isDefenderSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetDefenderSideSpawnFrame()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetAttackerSideSpawnFrame(bool hasHorse)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetPlayerSideSpawnFrameInSettlement()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetOtherSideSpawnFrameInSettlement(MatrixFrame playerFrame)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRenderingStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitializeAfterCreation(Agent conversationPartnerAgent, PartyBase conversationPartnerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnBodyguards(bool isDefenderSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpawnCharacter(CharacterObject character, ConversationCharacterData characterData, MatrixFrame initialFrame, in ActionIndexCache conversationAction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MatrixFrame GetBodyguardSpawnFrame(bool spawnWithHorse, bool isDefenderSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetNavalConversationCameraTag(PartyBase encounteredParty)
	{
		throw null;
	}
}
