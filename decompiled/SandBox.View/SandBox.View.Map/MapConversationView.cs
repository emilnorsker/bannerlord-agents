using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.Core;

namespace SandBox.View.Map;

public class MapConversationView : MapView
{
	public class MapConversationMission : ICampaignMission
	{
		public struct ConversationPlayArgs
		{
			public readonly string IdleActionId;

			public readonly string IdleFaceAnimId;

			public readonly string ReactionId;

			public readonly string ReactionFaceAnimId;

			public readonly string SoundPath;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public ConversationPlayArgs(string idleActionId, string idleFaceAnimId, string reactionId, string reactionFaceAnimId, string soundPath)
			{
				throw null;
			}
		}

		private Queue<ConversationPlayArgs> _conversationPlayQueue;

		GameState ICampaignMission.State
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		IMissionTroopSupplier ICampaignMission.AgentSupplier
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		Location ICampaignMission.Location
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

		Alley ICampaignMission.LastVisitedAlley
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

		MissionMode ICampaignMission.Mode
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		public MapConversationTableau ConversationTableau
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
		public MapConversationMission()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetConversationTableau(MapConversationTableau tableau)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Tick(float dt)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void OnFinalize()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void PlayCachedConversations()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.OnConversationPlay(string idleActionId, string idleFaceAnimId, string reactionId, string reactionFaceAnimId, string soundPath)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.AddAgentFollowing(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		bool ICampaignMission.AgentLookingAtAgent(IAgent agent1, IAgent agent2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		bool ICampaignMission.CheckIfAgentCanFollow(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		bool ICampaignMission.CheckIfAgentCanUnFollow(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.EndMission()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.OnCharacterLocationChanged(LocationCharacter locationCharacter, Location fromLocation, Location toLocation)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.OnCloseEncounterMenu()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.OnConversationContinue()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.OnConversationEnd(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.OnConversationStart(IAgent agent, bool setActionsInstantly)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.OnProcessSentence()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.RemoveAgentFollowing(IAgent agent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.SetMissionMode(MissionMode newMode, bool atStart)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.FadeOutCharacter(CharacterObject characterObject)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICampaignMission.OnGameStateChanged()
		{
			throw null;
		}
	}

	public MapConversationMission ConversationMission;

	public bool IsConversationActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void InitializeConversation(ConversationCharacterData playerCharacterData, ConversationCharacterData conversationPartnerData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected internal virtual void FinalizeConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void CreateConversationMissionIfMissing()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void DestroyConversationMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapConversationView()
	{
		throw null;
	}
}
