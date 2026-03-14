using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AIInfluence.Behaviors.AIActions;
using AIInfluence.Services;
using AIInfluence.SettlementCombat;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Conversation;
using OnConditionDelegate = TaleWorlds.CampaignSystem.Conversation.ConversationSentence.OnConditionDelegate;
using OnConsequenceDelegate = TaleWorlds.CampaignSystem.Conversation.ConversationSentence.OnConsequenceDelegate;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class DialogManager
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static OnConditionDelegate _003C_003E9__6_0;

		public static OnConditionDelegate _003C_003E9__6_3;

		public static OnConditionDelegate _003C_003E9__6_7;

		public static OnConditionDelegate _003C_003E9__6_8;

		public static OnConditionDelegate _003C_003E9__6_9;

		public static OnConditionDelegate _003C_003E9__6_11;

		public static OnConditionDelegate _003C_003E9__6_22;

		public static OnConditionDelegate _003C_003E9__6_23;

		public static OnConditionDelegate _003C_003E9__6_25;

		public static OnConditionDelegate _003C_003E9__6_26;

		public static OnConditionDelegate _003C_003E9__6_27;

		public static OnConditionDelegate _003C_003E9__6_28;

		public static OnConditionDelegate _003C_003E9__6_33;

		public static OnConditionDelegate _003C_003E9__6_34;

		public static OnConditionDelegate _003C_003E9__6_35;

		public static OnConditionDelegate _003C_003E9__6_37;

		public static OnConditionDelegate _003C_003E9__6_39;

		public static OnConditionDelegate _003C_003E9__6_40;

		public static Func<AIActionBase, bool> _003C_003E9__8_0;

		internal bool _003CRegisterDialogs_003Eb__6_0()
		{
			return Hero.OneToOneConversationHero != null && GlobalSettings<ModSettings>.Instance.EnableModification;
		}

		internal bool _003CRegisterDialogs_003Eb__6_3()
		{
			return true;
		}

		internal bool _003CRegisterDialogs_003Eb__6_7()
		{
			return true;
		}

		internal bool _003CRegisterDialogs_003Eb__6_8()
		{
			return GlobalSettings<ModSettings>.Instance.EnableModification && IsPlayerKingdomGovernor();
		}

		internal bool _003CRegisterDialogs_003Eb__6_9()
		{
			return GlobalSettings<ModSettings>.Instance.EnableModification && IsPlayerKingdomGovernor();
		}

		internal bool _003CRegisterDialogs_003Eb__6_11()
		{
			return GlobalSettings<ModSettings>.Instance.EnableModification && IsPlayerKingdomGovernor();
		}

		internal bool _003CRegisterDialogs_003Eb__6_22()
		{
			return true;
		}

		internal bool _003CRegisterDialogs_003Eb__6_23()
		{
			return Hero.OneToOneConversationHero != null;
		}

		internal bool _003CRegisterDialogs_003Eb__6_25()
		{
			return true;
		}

		internal bool _003CRegisterDialogs_003Eb__6_26()
		{
			return true;
		}

		internal bool _003CRegisterDialogs_003Eb__6_27()
		{
			return Hero.OneToOneConversationHero != null;
		}

		internal bool _003CRegisterDialogs_003Eb__6_28()
		{
			return Hero.OneToOneConversationHero != null;
		}

		internal bool _003CRegisterDialogs_003Eb__6_33()
		{
			return false;
		}

		internal bool _003CRegisterDialogs_003Eb__6_34()
		{
			return Hero.OneToOneConversationHero != null;
		}

		internal bool _003CRegisterDialogs_003Eb__6_35()
		{
			return Hero.OneToOneConversationHero != null;
		}

		internal bool _003CRegisterDialogs_003Eb__6_37()
		{
			return Hero.OneToOneConversationHero != null;
		}

		internal bool _003CRegisterDialogs_003Eb__6_39()
		{
			return Hero.OneToOneConversationHero != null;
		}

		internal bool _003CRegisterDialogs_003Eb__6_40()
		{
			return Hero.OneToOneConversationHero != null;
		}

		internal bool _003CGetFollowingPlayerParties_003Eb__8_0(AIActionBase a)
		{
			return a.ActionName == "follow_player" && a.IsActive;
		}
	}

	private AIInfluenceBehavior _behavior;

	private readonly AIDecisionHandler _decisionHandler;

	private static DialogManager _instance;

	public static DialogManager Instance
	{
		get
		{
			return _instance;
		}
		private set
		{
			_instance = value;
		}
	}

	private bool TryPrepareTechnicalActionParameter(Hero npc, string actionName, string parameter)
	{
		if (npc == null)
		{
			return false;
		}
		return AIActionIntegration.Instance.TryPrepareActionParameter(npc, actionName, parameter);
	}

	private DialogManager(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
		_decisionHandler = new AIDecisionHandler(behavior);
	}

	public static void Initialize(AIInfluenceBehavior behavior)
	{
		if (_instance == null)
		{
			_instance = new DialogManager(behavior);
		}
		else
		{
			_instance._behavior = behavior;
		}
	}

	public void RegisterDialogs(CampaignGameStarter starter)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a7: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0127: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_0296: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_02ca: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_02fe: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_0332: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected O, but got Unknown
		//IL_0366: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected O, but got Unknown
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected O, but got Unknown
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Expected O, but got Unknown
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected O, but got Unknown
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Expected O, but got Unknown
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Expected O, but got Unknown
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected O, but got Unknown
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Expected O, but got Unknown
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Expected O, but got Unknown
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected O, but got Unknown
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Expected O, but got Unknown
		//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Expected O, but got Unknown
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Expected O, but got Unknown
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Expected O, but got Unknown
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Expected O, but got Unknown
		//IL_0776: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Expected O, but got Unknown
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ae: Expected O, but got Unknown
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Expected O, but got Unknown
		try
		{
			MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", "{=AIInfluence_DefaultResponse}I have nothing to say right now.", false);
			object obj = _003C_003Ec._003C_003E9__6_0;
			if (obj == null)
			{
				OnConditionDelegate val = () => Hero.OneToOneConversationHero != null && GlobalSettings<ModSettings>.Instance.EnableModification;
				_003C_003Ec._003C_003E9__6_0 = val;
				obj = (object)val;
			}
			SafeAddPlayerLine(starter, "aiinfluence_start", "hero_main_options", "aiinfluence_response", "{=AIInfluence_PlayerStart}Talk [AI Influence]", (OnConditionDelegate)obj, null);
			SafeAddDialogLine(starter, "aiinfluence_response", "aiinfluence_response", "aiinfluence_input", "{=AIInfluence_NPCResponse}I'm listening.", null, null);
			SafeAddDialogLine(starter, "aiinfluence_npc_initiative_start", "start", "aiinfluence_neutral_waiting", "{=AIInfluence_NeutralApproach}*The Lord approaches you... Wait for him to speak.* (wait for the notification, then click 'View response')", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && GlobalSettings<ModSettings>.Instance.EnableModification && IsNeutralNPCInitiatedConversation(Hero.OneToOneConversationHero)), (OnConsequenceDelegate)delegate
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				if (oneToOneConversationHero != null)
				{
					_behavior.GetNPCInitiativeSystem().GenerateNeutralInitiativeResponse(oneToOneConversationHero);
				}
			}, 2000000);
			object obj2 = _003C_003Ec._003C_003E9__6_3;
			if (obj2 == null)
			{
				OnConditionDelegate val2 = () => true;
				_003C_003Ec._003C_003E9__6_3 = val2;
				obj2 = (object)val2;
			}
			SafeAddPlayerLine(starter, "aiinfluence_neutral_wait_view", "aiinfluence_neutral_waiting", "aiinfluence_dynamic_response", "{=AIInfluence_PlayerAsk}View NPC's response", (OnConditionDelegate)obj2, (OnConsequenceDelegate)delegate
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				if (oneToOneConversationHero != null)
				{
					NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(oneToOneConversationHero);
					orCreateNPCContext.IsNPCInitiatedConversation = false;
					_behavior.SaveNPCContext(((MBObjectBase)oneToOneConversationHero).StringId, oneToOneConversationHero, orCreateNPCContext);
				}
			});
			SafeAddDialogLine(starter, "aiinfluence_npc_hostile_initiative_start", "start", "aiinfluence_hostile_waiting", "{=AIInfluence_HostileApproach}*The Lord approaches you with a hostile look... Wait for him to speak.* (wait for the notification, then click 'View response'", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && GlobalSettings<ModSettings>.Instance.EnableModification && IsHostileNPCInitiatedConversation(Hero.OneToOneConversationHero)), (OnConsequenceDelegate)delegate
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				if (oneToOneConversationHero != null)
				{
					_behavior.GetNPCInitiativeSystem().GenerateHostileInitiativeResponse(oneToOneConversationHero);
				}
			}, 2000000);
			object obj3 = _003C_003Ec._003C_003E9__6_7;
			if (obj3 == null)
			{
				OnConditionDelegate val3 = () => true;
				_003C_003Ec._003C_003E9__6_7 = val3;
				obj3 = (object)val3;
			}
			SafeAddPlayerLine(starter, "aiinfluence_hostile_wait_view", "aiinfluence_hostile_waiting", "aiinfluence_dynamic_response", "{=AIInfluence_PlayerAsk}View NPC's response", (OnConditionDelegate)obj3, null);
			object obj4 = _003C_003Ec._003C_003E9__6_8;
			if (obj4 == null)
			{
				OnConditionDelegate val4 = () => GlobalSettings<ModSettings>.Instance.EnableModification && IsPlayerKingdomGovernor();
				_003C_003Ec._003C_003E9__6_8 = val4;
				obj4 = (object)val4;
			}
			SafeAddPlayerLine(starter, "aiinfluence_diplomatic_start", "hero_main_options", "aiinfluence_diplomatic_response", "{=AIInfluence_DiplomaticStart}Make diplomatic statement [AI Influence]", (OnConditionDelegate)obj4, null);
			SafeAddDialogLine(starter, "aiinfluence_diplomatic_response", "aiinfluence_diplomatic_response", "aiinfluence_diplomatic_input", "{=AIInfluence_DiplomaticPrompt}What statement do you wish to make on behalf of our kingdom?", null, null);
			object obj5 = _003C_003Ec._003C_003E9__6_9;
			if (obj5 == null)
			{
				OnConditionDelegate val5 = () => GlobalSettings<ModSettings>.Instance.EnableModification && IsPlayerKingdomGovernor();
				_003C_003Ec._003C_003E9__6_9 = val5;
				obj5 = (object)val5;
			}
			SafeAddPlayerLine(starter, "aiinfluence_diplomatic_input", "aiinfluence_diplomatic_input", "aiinfluence_diplomatic_processing", "{=AIInfluence_DiplomaticSpeak}Speak", (OnConditionDelegate)obj5, (OnConsequenceDelegate)delegate
			{
				_behavior.HandlePlayerDiplomaticInput();
			});
			SafeAddDialogLine(starter, "aiinfluence_diplomatic_processing", "aiinfluence_diplomatic_processing", "end_conversation", "{=AIInfluence_DiplomaticProcessed}We will publish your statement as soon as possible.", null, null);
			object obj6 = _003C_003Ec._003C_003E9__6_11;
			if (obj6 == null)
			{
				OnConditionDelegate val6 = () => GlobalSettings<ModSettings>.Instance.EnableModification && IsPlayerKingdomGovernor();
				_003C_003Ec._003C_003E9__6_11 = val6;
				obj6 = (object)val6;
			}
			SafeAddPlayerLine(starter, "aiinfluence_diplomatic_exit", "aiinfluence_diplomatic_input", "end_conversation", "{=AIInfluence_DiplomaticExit}Return", (OnConditionDelegate)obj6, null);
			SafeAddPlayerLine(starter, "aiinfluence_input", "aiinfluence_input", "aiinfluence_processing", "{=AIInfluence_PlayerThink}Speak", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && IsNonCombatConversation(Hero.OneToOneConversationHero)), (OnConsequenceDelegate)delegate
			{
				_behavior.HandlePlayerInput();
			});
			SafeAddPlayerLine(starter, "aiinfluence_exit", "aiinfluence_input", "end_conversation", "{=AIInfluence_PlayerExit}Return", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && IsNonCombatConversation(Hero.OneToOneConversationHero) && !IsHostileNPCInitiatedConversation(Hero.OneToOneConversationHero)), (OnConsequenceDelegate)delegate
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				if (oneToOneConversationHero != null)
				{
					NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(oneToOneConversationHero);
					orCreateNPCContext.CombatResponse = null;
					orCreateNPCContext.IsSurrendering = false;
					orCreateNPCContext.MarriageResponse = null;
					orCreateNPCContext.PendingWorkshopSale = null;
					orCreateNPCContext.PendingMoneyTransfer = null;
					orCreateNPCContext.PendingItemTransfers = null;
					orCreateNPCContext.PendingDeath = null;
					orCreateNPCContext.IsNPCInitiatedConversation = false;
					orCreateNPCContext.IsHostileInitiative = false;
					_behavior.SaveNPCContext(((MBObjectBase)oneToOneConversationHero).StringId, oneToOneConversationHero, orCreateNPCContext);
					_behavior.LogMessage("[DEBUG] Exiting dialog with NPC " + ((MBObjectBase)oneToOneConversationHero).StringId + " to end_conversation.");
				}
			});
			SafeAddPlayerLine(starter, "aiinfluence_hostile_exit_caught", "aiinfluence_input", "lord_demands_surrender_after_comment", "{=AIInfluence_PlayerExit}Return", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && IsNonCombatConversation(Hero.OneToOneConversationHero) && IsHostileNPCInitiatedConversation(Hero.OneToOneConversationHero) && IsPlayerDefenderInEncounter()), (OnConsequenceDelegate)delegate
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				if (oneToOneConversationHero != null)
				{
					NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(oneToOneConversationHero);
					orCreateNPCContext.CombatResponse = null;
					orCreateNPCContext.IsSurrendering = false;
					orCreateNPCContext.MarriageResponse = null;
					orCreateNPCContext.PendingWorkshopSale = null;
					orCreateNPCContext.PendingMoneyTransfer = null;
					orCreateNPCContext.PendingItemTransfers = null;
					orCreateNPCContext.PendingDeath = null;
					orCreateNPCContext.IsNPCInitiatedConversation = false;
					orCreateNPCContext.IsHostileInitiative = false;
					_behavior.SaveNPCContext(((MBObjectBase)oneToOneConversationHero).StringId, oneToOneConversationHero, orCreateNPCContext);
					_behavior.LogMessage($"[DEBUG] Exiting hostile initiative dialog (caught) with {oneToOneConversationHero.Name} -> lord_demands_surrender_after_comment");
				}
			});
			SafeAddPlayerLine(starter, "aiinfluence_hostile_exit_normal", "aiinfluence_input", "start", "{=AIInfluence_PlayerExit}Return", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && IsNonCombatConversation(Hero.OneToOneConversationHero) && IsHostileNPCInitiatedConversation(Hero.OneToOneConversationHero) && !IsPlayerDefenderInEncounter()), (OnConsequenceDelegate)delegate
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				if (oneToOneConversationHero != null)
				{
					NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(oneToOneConversationHero);
					orCreateNPCContext.CombatResponse = null;
					orCreateNPCContext.IsSurrendering = false;
					orCreateNPCContext.MarriageResponse = null;
					orCreateNPCContext.PendingWorkshopSale = null;
					orCreateNPCContext.PendingMoneyTransfer = null;
					orCreateNPCContext.PendingItemTransfers = null;
					orCreateNPCContext.PendingDeath = null;
					orCreateNPCContext.IsNPCInitiatedConversation = false;
					orCreateNPCContext.IsHostileInitiative = false;
					_behavior.SaveNPCContext(((MBObjectBase)oneToOneConversationHero).StringId, oneToOneConversationHero, orCreateNPCContext);
					_behavior.LogMessage($"[DEBUG] Exiting hostile initiative dialog (attacker/neutral) with {oneToOneConversationHero.Name} -> start");
				}
			});
			SafeAddPlayerLine(starter, "aiinfluence_test_follow", "aiinfluence_input", "aiinfluence_test_follow_response", "[TEST] Start Follow Player", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && IsNonCombatConversation(Hero.OneToOneConversationHero)), (OnConsequenceDelegate)delegate
			{
				//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0100: Unknown result type (might be due to invalid IL or missing references)
				//IL_010a: Expected O, but got Unknown
				//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b8: Expected O, but got Unknown
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_0079: Unknown result type (might be due to invalid IL or missing references)
				//IL_0083: Expected O, but got Unknown
				try
				{
					Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
					if (oneToOneConversationHero != null)
					{
						_behavior.LogMessage("[TEST] Test follow_player button clicked. NPC: " + ((MBObjectBase)oneToOneConversationHero).StringId);
						if (AIActionManager.Instance.StartAction(oneToOneConversationHero, "follow_player"))
						{
							_behavior.LogMessage($"[TEST] follow_player action started successfully for {oneToOneConversationHero.Name}");
							InformationManager.DisplayMessage(new InformationMessage($"[TEST] {oneToOneConversationHero.Name} is now following you!", ExtraColors.GreenAIInfluence));
						}
						else
						{
							_behavior.LogMessage($"[TEST] Failed to start follow_player action for {oneToOneConversationHero.Name}");
							InformationManager.DisplayMessage(new InformationMessage("[TEST] Failed to start follow action", ExtraColors.RedAIInfluence));
						}
					}
				}
				catch (Exception ex2)
				{
					_behavior.LogMessage("[ERROR] Test follow_player failed: " + ex2.Message + "\n" + ex2.StackTrace);
					InformationManager.DisplayMessage(new InformationMessage("Test failed: " + ex2.Message, ExtraColors.RedAIInfluence));
				}
			});
			object obj7 = _003C_003Ec._003C_003E9__6_22;
			if (obj7 == null)
			{
				OnConditionDelegate val7 = () => true;
				_003C_003Ec._003C_003E9__6_22 = val7;
				obj7 = (object)val7;
			}
			SafeAddDialogLine(starter, "aiinfluence_test_follow_response", "aiinfluence_test_follow_response", "aiinfluence_input", "[TEST] Action executed. Check logs.", (OnConditionDelegate)obj7, null);
			object obj8 = _003C_003Ec._003C_003E9__6_23;
			if (obj8 == null)
			{
				OnConditionDelegate val8 = () => Hero.OneToOneConversationHero != null;
				_003C_003Ec._003C_003E9__6_23 = val8;
				obj8 = (object)val8;
			}
			SafeAddPlayerLine(starter, "aiinfluence_test_stop_follow", "aiinfluence_input", "aiinfluence_test_stop_follow_response", "[TEST] Stop Follow", (OnConditionDelegate)obj8, (OnConsequenceDelegate)delegate
			{
				//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected O, but got Unknown
				//IL_009a: Unknown result type (might be due to invalid IL or missing references)
				//IL_009f: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a9: Expected O, but got Unknown
				try
				{
					Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
					if (oneToOneConversationHero != null)
					{
						_behavior.LogMessage("[TEST] Test stop follow_player button clicked. NPC: " + ((MBObjectBase)oneToOneConversationHero).StringId);
						if (AIActionManager.Instance.StopAction(oneToOneConversationHero, "follow_player", showMessage: true))
						{
							_behavior.LogMessage("[TEST] Successfully stopped follow_player for " + ((MBObjectBase)oneToOneConversationHero).StringId);
						}
						else
						{
							_behavior.LogMessage("[TEST] Failed to stop follow_player for " + ((MBObjectBase)oneToOneConversationHero).StringId + " - action not active");
							InformationManager.DisplayMessage(new InformationMessage($"No active follow action for {oneToOneConversationHero.Name}", ExtraColors.RedAIInfluence));
						}
					}
				}
				catch (Exception ex2)
				{
					_behavior.LogMessage("[ERROR] Test stop follow_player failed: " + ex2.Message + "\n" + ex2.StackTrace);
					InformationManager.DisplayMessage(new InformationMessage("Test failed: " + ex2.Message, ExtraColors.RedAIInfluence));
				}
			});
			object obj9 = _003C_003Ec._003C_003E9__6_25;
			if (obj9 == null)
			{
				OnConditionDelegate val9 = () => true;
				_003C_003Ec._003C_003E9__6_25 = val9;
				obj9 = (object)val9;
			}
			SafeAddDialogLine(starter, "aiinfluence_test_stop_follow_response", "aiinfluence_test_stop_follow_response", "aiinfluence_input", "[TEST] Stop action executed. Check logs.", (OnConditionDelegate)obj9, null);
			object obj10 = _003C_003Ec._003C_003E9__6_26;
			if (obj10 == null)
			{
				OnConditionDelegate val10 = () => true;
				_003C_003Ec._003C_003E9__6_26 = val10;
				obj10 = (object)val10;
			}
			SafeAddDialogLine(starter, "end_conversation", "end_conversation", "hero_main_options", "{=AIInfluence_EndConversation}...", (OnConditionDelegate)obj10, null);
			SafeAddDialogLine(starter, "aiinfluence_processing", "aiinfluence_processing", "aiinfluence_waiting", "{=AIInfluence_NPCProcessing}(Send a message and wait for the NPC's response)", null, null);
			object obj11 = _003C_003Ec._003C_003E9__6_27;
			if (obj11 == null)
			{
				OnConditionDelegate val11 = () => Hero.OneToOneConversationHero != null;
				_003C_003Ec._003C_003E9__6_27 = val11;
				obj11 = (object)val11;
			}
			SafeAddPlayerLine(starter, "aiinfluence_waiting", "aiinfluence_waiting", "aiinfluence_dynamic_response", "{=AIInfluence_PlayerAsk}View NPC's response", (OnConditionDelegate)obj11, null);
			object obj12 = _003C_003Ec._003C_003E9__6_28;
			if (obj12 == null)
			{
				OnConditionDelegate val12 = () => Hero.OneToOneConversationHero != null;
				_003C_003Ec._003C_003E9__6_28 = val12;
				obj12 = (object)val12;
			}
			SafeAddDialogLine(starter, "aiinfluence_dynamic_response", "aiinfluence_dynamic_response", "aiinfluence_apply_changes", "{=AIInfluence_DynamicResponse}{DYNAMIC_NPC_RESPONSE}", (OnConditionDelegate)obj12, (OnConsequenceDelegate)delegate
			{
				//IL_0e30: Unknown result type (might be due to invalid IL or missing references)
				//IL_0ec2: Unknown result type (might be due to invalid IL or missing references)
				//IL_0930: Unknown result type (might be due to invalid IL or missing references)
				//IL_093a: Expected O, but got Unknown
				//IL_093a: Unknown result type (might be due to invalid IL or missing references)
				//IL_093f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0949: Expected O, but got Unknown
				//IL_0b06: Unknown result type (might be due to invalid IL or missing references)
				//IL_0b10: Expected O, but got Unknown
				//IL_0b10: Unknown result type (might be due to invalid IL or missing references)
				//IL_0b15: Unknown result type (might be due to invalid IL or missing references)
				//IL_0b1f: Expected O, but got Unknown
				//IL_0b5b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0b65: Expected O, but got Unknown
				//IL_0b65: Unknown result type (might be due to invalid IL or missing references)
				//IL_0b6a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0b74: Expected O, but got Unknown
				//IL_1d80: Unknown result type (might be due to invalid IL or missing references)
				//IL_1d8a: Expected O, but got Unknown
				//IL_1d8a: Unknown result type (might be due to invalid IL or missing references)
				//IL_1d8f: Unknown result type (might be due to invalid IL or missing references)
				//IL_1d99: Expected O, but got Unknown
				//IL_19db: Unknown result type (might be due to invalid IL or missing references)
				//IL_19e5: Expected O, but got Unknown
				//IL_19e5: Unknown result type (might be due to invalid IL or missing references)
				//IL_19ea: Unknown result type (might be due to invalid IL or missing references)
				//IL_19f4: Expected O, but got Unknown
				//IL_1542: Unknown result type (might be due to invalid IL or missing references)
				//IL_154c: Expected O, but got Unknown
				//IL_15d7: Unknown result type (might be due to invalid IL or missing references)
				//IL_15ee: Unknown result type (might be due to invalid IL or missing references)
				//IL_15f3: Unknown result type (might be due to invalid IL or missing references)
				//IL_15fd: Expected O, but got Unknown
				//IL_1470: Unknown result type (might be due to invalid IL or missing references)
				//IL_147a: Expected O, but got Unknown
				//IL_14d8: Unknown result type (might be due to invalid IL or missing references)
				//IL_14e2: Expected O, but got Unknown
				//IL_14e2: Unknown result type (might be due to invalid IL or missing references)
				//IL_14e7: Unknown result type (might be due to invalid IL or missing references)
				//IL_14f1: Expected O, but got Unknown
				//IL_1bf3: Unknown result type (might be due to invalid IL or missing references)
				//IL_1c0a: Unknown result type (might be due to invalid IL or missing references)
				//IL_1c0f: Unknown result type (might be due to invalid IL or missing references)
				//IL_1c19: Expected O, but got Unknown
				//IL_1b42: Unknown result type (might be due to invalid IL or missing references)
				//IL_1b5e: Unknown result type (might be due to invalid IL or missing references)
				//IL_1b63: Unknown result type (might be due to invalid IL or missing references)
				//IL_1b6d: Expected O, but got Unknown
				//IL_1836: Unknown result type (might be due to invalid IL or missing references)
				//IL_186d: Unknown result type (might be due to invalid IL or missing references)
				//IL_1872: Unknown result type (might be due to invalid IL or missing references)
				//IL_187c: Expected O, but got Unknown
				Hero npc = Hero.OneToOneConversationHero;
				if (npc != null)
				{
					NPCContext context = _behavior.GetOrCreateNPCContext(npc);
					if (context.PendingAIResponse != null)
					{
						if (!string.IsNullOrEmpty(context.PendingAIResponse.TechnicalAction) && context.PendingAIResponse.TechnicalAction != "none")
						{
							try
							{
								string technicalAction = context.PendingAIResponse.TechnicalAction;
								_behavior.LogMessage("[DEBUG] Processing technical action: " + technicalAction);
								HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "create_rp_item" };
								string[] array;
								if (technicalAction.Contains(":"))
								{
									string item = technicalAction.Split(new char[1] { ':' }, 2)[0].Trim();
									array = ((!hashSet.Contains(item)) ? technicalAction.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries) : new string[1] { technicalAction });
								}
								else
								{
									array = technicalAction.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
								}
								string[] array2 = array;
								foreach (string text in array2)
								{
									string text2 = text.Trim();
									if (!string.IsNullOrEmpty(text2))
									{
										_behavior.LogMessage("[DEBUG] Processing single action: " + text2);
										string[] array3 = text2.Split(new char[1] { ':' }, 2);
										if (array3.Length != 0)
										{
											string text3 = array3[0].Trim();
											string text4 = ((array3.Length > 1) ? array3[1].Trim() : "");
											_behavior.LogMessage("[DEBUG] Action name: '" + text3 + "', payload: '" + text4 + "'");
											if (npc.IsPrisoner && !text4.Equals("STOP", StringComparison.OrdinalIgnoreCase))
											{
												_behavior.LogMessage($"[TECHNICAL_ACTION] Skipping technical action '{text3}' for prisoner {npc.Name} - prisoners cannot execute actions requiring freedom of movement.");
												context.PendingAIResponse.TechnicalAction = null;
											}
											else if (text4.Equals("STOP", StringComparison.OrdinalIgnoreCase))
											{
												bool flag = false;
												if (text3.Equals("follow_player", StringComparison.OrdinalIgnoreCase))
												{
													string text5 = context.PendingAIResponse?.Decision?.ToLower() ?? "";
													if (text5 == "release")
													{
														flag = true;
														_behavior.LogMessage("[TECHNICAL_ACTION] Will show message when stopping follow_player because decision is 'release'");
													}
												}
												if (AIActionManager.Instance.StopAction(npc, text3, flag))
												{
													_behavior.LogMessage($"[TECHNICAL_ACTION] Successfully stopped {text3} for {npc.Name} (showMessage: {flag})");
												}
												else
												{
													_behavior.LogMessage($"[TECHNICAL_ACTION] Failed to stop {text3} for {npc.Name} - action not active");
												}
											}
											else
											{
												AIActionManager.Instance.StopAction(npc, text3);
												_behavior.LogMessage($"[TECHNICAL_ACTION] Preparing action '{text3}' with payload '{text4}' for {npc.Name}");
												bool flag2 = TryPrepareTechnicalActionParameter(npc, text3, text4);
												_behavior.LogMessage($"[TECHNICAL_ACTION] TryPrepareTechnicalActionParameter returned {flag2} for {npc.Name}");
												if (flag2)
												{
													bool flag3 = AIActionManager.Instance.StartAction(npc, text3);
													_behavior.LogMessage($"[TECHNICAL_ACTION] StartAction returned {flag3} for {npc.Name}");
												}
												else
												{
													_behavior.LogMessage($"[TECHNICAL_ACTION] Failed to prepare action '{text3}' for {npc.Name}");
												}
											}
										}
									}
								}
							}
							catch (Exception ex2)
							{
								_behavior.LogMessage("[ERROR] Failed to process technical action: " + ex2.Message + "\n" + ex2.StackTrace);
							}
						}
						if (!string.IsNullOrEmpty(context.PendingAIResponse.KingdomAction) && context.PendingAIResponse.KingdomAction != "none")
						{
							try
							{
								_behavior.LogMessage("[DEBUG] Processing kingdom action: " + context.PendingAIResponse.KingdomAction);
								_behavior.ProcessKingdomAction(npc, context.PendingAIResponse, context);
							}
							catch (Exception ex3)
							{
								_behavior.LogMessage("[ERROR] Failed to process kingdom action: " + ex3.Message);
							}
						}
						if (!string.IsNullOrEmpty(context.PendingAIResponse.Decision) && context.PendingAIResponse.Decision != "none")
						{
							try
							{
								string text6 = context.PendingAIResponse.Decision.ToLower();
								_behavior.LogMessage("[DEBUG] Processing pending decision: " + text6);
								switch (text6)
								{
								case "attack":
								{
									string text8 = context.PendingAIResponse.Response ?? $"{npc.Name} prepares to fight!";
									context.CombatResponse = "attack: " + text8;
									break;
								}
								case "release":
									if (context.CombatResponse == null || !context.CombatResponse.Contains("release"))
									{
										string text9 = context.PendingAIResponse.Response ?? $"{npc.Name} lets you go... for now.";
										context.CombatResponse = "release: " + text9;
										context.IsSurrendering = false;
										_behavior.LogMessage("[DEBUG] Applied pending release decision to CombatResponse");
									}
									else
									{
										_behavior.LogMessage("[DEBUG] Release decision already applied to CombatResponse, skipping duplicate processing");
									}
									break;
								case "surrender":
									context.CombatResponse = null;
									break;
								case "accept_surrender":
								{
									string text7 = context.PendingAIResponse.Response ?? $"{npc.Name} accepts your surrender.";
									context.CombatResponse = "accept_surrender: " + text7;
									context.IsPlayerSurrendering = true;
									break;
								}
								default:
									context.CombatResponse = null;
									break;
								}
							}
							catch (Exception ex4)
							{
								_behavior.LogMessage("[ERROR] Failed to process pending decision: " + ex4.Message);
							}
						}
						if (context.PendingAIResponse.AllowsLettersFromNPC.HasValue && context.PendingAIResponse.AllowsLettersFromNPC.Value != context.AllowsLettersFromNPC)
						{
							context.AllowsLettersFromNPC = context.PendingAIResponse.AllowsLettersFromNPC.Value;
							_behavior.LogMessage($"[DEBUG] {npc.Name} changed AllowsLettersFromNPC to {context.AllowsLettersFromNPC} (dialog)");
							Dictionary<string, object> dictionary = new Dictionary<string, object> { 
							{
								"NPC_NAME",
								((object)npc.Name).ToString()
							} };
							string text10 = (context.AllowsLettersFromNPC ? "AIInfluence_NPCWillSendLetters" : "AIInfluence_NPCWillNotSendLetters");
							string text11 = (context.AllowsLettersFromNPC ? "{NPC_NAME} will now send you letters." : "{NPC_NAME} will no longer send you letters.");
							InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=" + text10 + "}" + text11, dictionary)).ToString(), Colors.Gray));
						}
						if (context.PendingAIResponse.QuestAction != null && !string.IsNullOrEmpty(context.PendingAIResponse.QuestAction.Action))
						{
							QuestActionData capturedQuestAction = context.PendingAIResponse.QuestAction;
							Hero capturedNpc = npc;
							_behavior.GetDelayedTaskManager().AddTask(5.0, delegate
							{
								try
								{
									NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(capturedNpc);
									_behavior.ProcessQuestAction(capturedNpc, orCreateNPCContext, capturedQuestAction);
								}
								catch (Exception ex5)
								{
									_behavior.LogMessage("[ERROR] Failed to process delayed quest action: " + ex5.Message);
								}
							});
							_behavior.LogMessage($"[QUEST] Scheduled quest action '{context.PendingAIResponse.QuestAction.Action}' with 5s delay for {npc.Name}");
						}
						context.PendingAIResponse = null;
						if (context.PendingIntimacyNotification)
						{
							_behavior.LogMessage($"[INTIMACY] Processing pending intimate interaction for NPC {((MBObjectBase)npc).StringId}");
							float intimacyConceptionChance = GlobalSettings<ModSettings>.Instance.IntimacyConceptionChance;
							float intimacyRomanceIncrease = GlobalSettings<ModSettings>.Instance.IntimacyRomanceIncrease;
							context.PendingConceptionMotherName = null;
							IntimacySystem.HandleIntimateInteraction(npc, Hero.MainHero, context, intimacyConceptionChance, intimacyRomanceIncrease);
							string value = ((object)npc.Name)?.ToString() ?? "Unknown";
							InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_IntimacyOccurred}You share an intimate moment with {npcName}.", new Dictionary<string, object> { { "npcName", value } })).ToString(), ExtraColors.GreenAIInfluence));
							if (!string.IsNullOrEmpty(context.PendingConceptionMotherName))
							{
								InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_ConceptionOccurred}{motherName} may have conceived a child...", new Dictionary<string, object> { { "motherName", context.PendingConceptionMotherName } })).ToString(), ExtraColors.GreenAIInfluence));
								context.PendingConceptionMotherName = null;
							}
							context.PendingIntimacyNotification = false;
							_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
							_behavior.LogMessage($"[INTIMACY] Intimate interaction processed and notification shown for NPC {((MBObjectBase)npc).StringId}");
						}
						context.InteractionCount++;
						_behavior.UpdateContextData(context, npc);
						_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
					}
					ModSettings instance = GlobalSettings<ModSettings>.Instance;
					if (instance != null && instance.EnableTTS)
					{
						if (context.PreparedTts != null)
						{
							_behavior.LogMessage($"[TTS] Playing pre-prepared TTS for {npc.Name}");
							TtsLipSyncService.PlayPrepared(context.PreparedTts);
							context.PreparedTts = null;
						}
						else
						{
							_behavior.LogMessage($"[TTS] No prepared TTS available for {npc.Name}, skipping playback.");
						}
					}
					_behavior.LogMessage($"[DEBUG] Displaying dynamic response for NPC {((MBObjectBase)npc).StringId}. CombatResponse={context.CombatResponse}, IsSurrendering={context.IsSurrendering}, MarriageResponse={context.MarriageResponse}");
					if (npc.IsPrisoner)
					{
						context.CombatResponse = null;
						context.IsSurrendering = false;
						context.MarriageResponse = null;
						context.PendingWorkshopSale = null;
						_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
						_behavior.LogMessage("[DEBUG] NPC " + ((MBObjectBase)npc).StringId + " is a prisoner. Cleared CombatResponse, IsSurrendering, MarriageResponse, PendingWorkshopSale. PendingDeath preserved (prisoners can be executed).");
					}
					if (context.PendingRelationChange != null)
					{
						PendingRelationChange pendingRelationChange = context.PendingRelationChange;
						_behavior.ApplyRelationChangeWithDelay(npc, pendingRelationChange.RelationChange, pendingRelationChange.Color, pendingRelationChange.Message);
						_behavior.LogMessage($"[DEBUG] Scheduled relation change for NPC {((MBObjectBase)npc).StringId} by {pendingRelationChange.RelationChange} in 4s.");
						context.PendingRelationChange = null;
					}
					if (context.PendingLiePenalty != null)
					{
						PendingRelationChange pendingLiePenalty = context.PendingLiePenalty;
						_behavior.ApplyRelationChangeWithDelay(npc, pendingLiePenalty.RelationChange, pendingLiePenalty.Color, pendingLiePenalty.Message);
						_behavior.LogMessage($"[DEBUG] Scheduled lie penalty for NPC {((MBObjectBase)npc).StringId} by {pendingLiePenalty.RelationChange} in 4s.");
						context.PendingLiePenalty = null;
					}
					if (context.PendingWorkshopSale != null && !npc.IsPrisoner)
					{
						_behavior.LogMessage($"[DEBUG] Executing pending workshop sale for NPC {((MBObjectBase)npc).StringId}.");
						_behavior.ExecutePendingWorkshopSale(npc, context);
						_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
					}
					else if (context.PendingWorkshopSale != null && npc.IsPrisoner)
					{
						_behavior.LogMessage($"[DEBUG] Cleared pending workshop sale for prisoner {((MBObjectBase)npc).StringId}.");
						context.PendingWorkshopSale = null;
					}
					if (context.PendingMoneyTransfer != null)
					{
						_behavior.LogMessage($"[MONEY_TRANSFER] Executing pending money transfer for NPC {((MBObjectBase)npc).StringId} (Prisoner: {npc.IsPrisoner}): {context.PendingMoneyTransfer.Action} {context.PendingMoneyTransfer.Amount} denars");
						_behavior.ProcessMoneyTransfer(npc, context, context.PendingMoneyTransfer);
						context.PendingMoneyTransfer = null;
						_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
						_behavior.LogMessage($"[MONEY_TRANSFER] Money transfer completed for NPC {((MBObjectBase)npc).StringId}");
					}
					if (context.PendingItemTransfers != null && context.PendingItemTransfers.Count > 0)
					{
						_behavior.LogMessage($"[ITEM_TRANSFER] Executing pending item transfers for NPC {((MBObjectBase)npc).StringId} (Prisoner: {npc.IsPrisoner}): {context.PendingItemTransfers.Count} items");
						_behavior.ProcessItemTransfers(npc, context, context.PendingItemTransfers);
						context.PendingItemTransfers = null;
						_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
						_behavior.LogMessage($"[ITEM_TRANSFER] Item transfers completed for NPC {((MBObjectBase)npc).StringId}");
					}
					_behavior.LogMessage($"[DEBUG] NPC {((MBObjectBase)npc).StringId} is prisoner: {npc.IsPrisoner}, CombatResponse: '{context.CombatResponse}'");
					if (!npc.IsPrisoner)
					{
						bool flag4 = context.CombatResponse != null && context.CombatResponse.IndexOf("attack", StringComparison.OrdinalIgnoreCase) >= 0;
						bool flag5 = context.CombatResponse != null && context.CombatResponse.IndexOf("release", StringComparison.OrdinalIgnoreCase) >= 0;
						bool flag6 = context.CombatResponse != null && context.CombatResponse.IndexOf("accept_surrender", StringComparison.OrdinalIgnoreCase) >= 0;
						_behavior.LogMessage($"[DEBUG] For non-prisoner {((MBObjectBase)npc).StringId}: flag5 (attack) = {flag4}, isRelease = {flag5}, isAcceptSurrender = {flag6}");
						if (IsCastleMenuConversation(npc) && (flag4 || flag5 || flag6))
						{
							_behavior.LogMessage("[WARNING] Combat action (attack/release/accept_surrender) blocked for " + ((MBObjectBase)npc).StringId + " - dialogue is through castle menu, not in mission. Clearing CombatResponse.");
							context.CombatResponse = null;
							_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
							return;
						}
						if (flag4)
						{
							if (Settlement.CurrentSettlement != null && Mission.Current != null)
							{
								_behavior.LogMessage("[DEBUG] Settlement combat detected - processing with 5s delay");
								string message = ((object)new TextObject("{=AIInfluence_RelationWorsenedCombat}Your relations with {npcName} have worsened due to the conflict.", new Dictionary<string, object> { { "npcName", npc.Name } })).ToString();
								_behavior.GetDelayedTaskManager().AddTask(7.0, delegate
								{
									//IL_0025: Unknown result type (might be due to invalid IL or missing references)
									//IL_002a: Unknown result type (might be due to invalid IL or missing references)
									//IL_0034: Expected O, but got Unknown
									ChangeRelationAction.ApplyRelationChangeBetweenHeroes(npc, Hero.MainHero, -30, true);
									InformationManager.DisplayMessage(new InformationMessage(message, ExtraColors.RedAIInfluence));
								});
								_behavior.GetDelayedTaskManager().AddTask(5.0, delegate
								{
									if (context.PendingSettlementCombat == "attack")
									{
										_behavior.LogMessage("[SETTLEMENT_COMBAT] Initiating combat analysis for attack in settlement");
										SettlementCombatManager settlementCombatManager = _behavior.GetSettlementCombatManager();
										if (settlementCombatManager != null)
										{
											settlementCombatManager.InitiateCombat(npc, context, CombatTriggerType.NPCAttack, context.SettlementCombatResponse);
											context.PendingSettlementCombat = null;
											context.SettlementCombatResponse = null;
											_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
										}
										else
										{
											_behavior.LogMessage("[ERROR] SettlementCombatManager not found!");
										}
									}
									else
									{
										_behavior.LogMessage("[SETTLEMENT_COMBAT] PendingSettlementCombat flag was cleared, skipping");
									}
								});
								InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCAction_SettlementCombat}NPC is analyzing the situation before attacking in settlement... (dialog will close automatically)", (Dictionary<string, object>)null)).ToString(), Colors.Gray));
							}
							else
							{
								float dialogDelay = GlobalSettings<ModSettings>.Instance.DialogDelay;
								string message2 = ((object)new TextObject("{=AIInfluence_RelationWorsenedCombat}Your relations with {npcName} have worsened due to the conflict.", new Dictionary<string, object> { { "npcName", npc.Name } })).ToString();
								_behavior.GetDelayedTaskManager().AddTask(7.0, delegate
								{
									//IL_0025: Unknown result type (might be due to invalid IL or missing references)
									//IL_002a: Unknown result type (might be due to invalid IL or missing references)
									//IL_0034: Expected O, but got Unknown
									ChangeRelationAction.ApplyRelationChangeBetweenHeroes(npc, Hero.MainHero, -30, true);
									InformationManager.DisplayMessage(new InformationMessage(message2, ExtraColors.RedAIInfluence));
								});
								_behavior.GetDelayedTaskManager().AddTask(dialogDelay, delegate
								{
									try
									{
										_behavior.InitiateCombatLogic(npc, context);
									}
									catch (Exception ex5)
									{
										_behavior.LogMessage("[ERROR] Failed to initiate combat with " + ((MBObjectBase)npc).StringId + ": " + ex5.Message + "\n" + ex5.StackTrace);
									}
								});
								_behavior.LogMessage($"[DEBUG] Scheduled combat with {((MBObjectBase)npc).StringId} in {dialogDelay:F0} seconds.");
								InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCAction_Attack}NPC is preparing to attack... (dialog will close automatically in {DELAY} seconds)", (Dictionary<string, object>)null).SetTextVariable("DELAY", (int)dialogDelay)).ToString(), Colors.Gray));
							}
						}
						else if (flag5)
						{
							if (IsCastleMenuConversation(npc))
							{
								_behavior.LogMessage("[WARNING] Release action blocked for " + ((MBObjectBase)npc).StringId + " - dialogue is through castle menu, not in mission. Clearing CombatResponse.");
								context.CombatResponse = null;
								_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
								return;
							}
							bool flag7 = npc.MapFaction != null && Hero.MainHero.MapFaction != null && FactionManager.IsAtWarAgainstFaction(npc.MapFaction, Hero.MainHero.MapFaction);
							int num;
							if (Settlement.CurrentSettlement == null && npc.CurrentSettlement == null)
							{
								MobileParty partyBelongedTo = npc.PartyBelongedTo;
								num = ((((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null) != null) ? 1 : 0);
							}
							else
							{
								num = 1;
							}
							bool flag8 = (byte)num != 0;
							bool hostileAndField = flag7 && !flag8;
							_behavior.LogMessage($"[DEBUG] Processing release decision for {((MBObjectBase)npc).StringId}. PlayerEncounter.Current: {PlayerEncounter.Current != null}, isEnemy={flag7}, isInSettlement={flag8}");
							float dialogDelay2 = GlobalSettings<ModSettings>.Instance.DialogDelay;
							_behavior.GetDelayedTaskManager().AddTask(dialogDelay2, delegate
							{
								try
								{
									bool flag9 = Mission.Current != null;
									if (!flag9 && hostileAndField)
									{
										_behavior.LogMessage("[DEBUG] Processing player release (hostile, field) for " + ((MBObjectBase)npc).StringId);
										MobileParty partyBelongedTo2 = npc.PartyBelongedTo;
										bool flag10 = partyBelongedTo2 != null && partyBelongedTo2.Army != null;
										bool flag11 = flag10 && partyBelongedTo2.Army.LeaderParty == partyBelongedTo2;
										if (PlayerEncounter.Current != null)
										{
											PlayerEncounter.ProtectPlayerSide(4f);
											if (partyBelongedTo2 != null)
											{
												partyBelongedTo2.Ai.SetDoNotAttackMainParty(24);
												_behavior.LogMessage($"[DEBUG] Set NPC party {partyBelongedTo2.Name} to not attack player for 24 hours");
												ProtectFollowingPlayerParties(partyBelongedTo2, flag11);
												if (flag11)
												{
													foreach (MobileParty item2 in (List<MobileParty>)(object)partyBelongedTo2.Army.Parties)
													{
														if (item2 != partyBelongedTo2)
														{
															item2.Ai.SetDoNotAttackMainParty(24);
															_behavior.LogMessage($"[DEBUG] Set army party {item2.Name} to not attack player for 24 hours");
														}
													}
												}
											}
											PlayerEncounter.LeaveEncounter = true;
											PlayerEncounter.Finish(false);
											_behavior.LogMessage($"[DEBUG] NPC {npc.Name} released player from encounter using vanilla methods.");
										}
										else if (flag10)
										{
											_behavior.LogMessage($"[DEBUG] PlayerEncounter.Current is null for {((MBObjectBase)npc).StringId}, but NPC is in army (isArmyLeader: {flag11}) - setting do not attack flags directly");
											if (partyBelongedTo2 != null)
											{
												partyBelongedTo2.Ai.SetDoNotAttackMainParty(24);
												_behavior.LogMessage($"[DEBUG] Set NPC party {partyBelongedTo2.Name} to not attack player for 24 hours (direct, no PlayerEncounter)");
												ProtectFollowingPlayerParties(partyBelongedTo2, flag11);
												if (flag11)
												{
													foreach (MobileParty item3 in (List<MobileParty>)(object)partyBelongedTo2.Army.Parties)
													{
														if (item3 != partyBelongedTo2)
														{
															item3.Ai.SetDoNotAttackMainParty(24);
															_behavior.LogMessage($"[DEBUG] Set army party {item3.Name} to not attack player for 24 hours (direct, no PlayerEncounter)");
														}
													}
												}
											}
										}
										else
										{
											_behavior.LogMessage("[WARNING] PlayerEncounter.Current is null and NPC is not in army, cannot release player");
										}
									}
									else if (!flag9)
									{
										_behavior.LogMessage("[DEBUG] Processing player release (non-hostile or settlement, map) for " + ((MBObjectBase)npc).StringId);
										MobileParty partyBelongedTo3 = npc.PartyBelongedTo;
										bool flag12 = partyBelongedTo3 != null && partyBelongedTo3.Army != null;
										if (PlayerEncounter.Current != null)
										{
											PlayerEncounter.LeaveEncounter = true;
											PlayerEncounter.Finish(false);
											_behavior.LogMessage($"[DEBUG] Finished encounter without protection for {npc.Name}");
										}
										else if (flag12)
										{
											_behavior.LogMessage("[DEBUG] PlayerEncounter.Current is null for " + ((MBObjectBase)npc).StringId + ", but NPC is in army - will close dialog directly");
										}
									}
									else
									{
										bool flag13 = Hero.MainHero.PartyBelongedTo != null && Hero.MainHero.PartyBelongedTo.IsCurrentlyAtSea;
										if (flag13 && PlayerEncounter.Current != null)
										{
											_behavior.LogMessage("[DEBUG] Processing player release inside mission on water for " + ((MBObjectBase)npc).StringId + " - handling PlayerEncounter");
											MobileParty partyBelongedTo4 = npc.PartyBelongedTo;
											bool flag14 = partyBelongedTo4 != null && partyBelongedTo4.Army != null && partyBelongedTo4.Army.LeaderParty == partyBelongedTo4;
											PlayerEncounter.ProtectPlayerSide(4f);
											if (partyBelongedTo4 != null)
											{
												partyBelongedTo4.Ai.SetDoNotAttackMainParty(24);
												_behavior.LogMessage($"[DEBUG] Set NPC party {partyBelongedTo4.Name} to not attack player for 24 hours (on water)");
												ProtectFollowingPlayerParties(partyBelongedTo4, flag14);
												if (flag14)
												{
													foreach (MobileParty item4 in (List<MobileParty>)(object)partyBelongedTo4.Army.Parties)
													{
														if (item4 != partyBelongedTo4)
														{
															item4.Ai.SetDoNotAttackMainParty(24);
															_behavior.LogMessage($"[DEBUG] Set army party {item4.Name} to not attack player for 24 hours (on water)");
														}
													}
												}
											}
											PlayerEncounter.LeaveEncounter = true;
											PlayerEncounter.Finish(false);
											_behavior.LogMessage($"[DEBUG] Finished PlayerEncounter for {npc.Name} on water to prevent combat window");
										}
										else
										{
											_behavior.LogMessage($"[DEBUG] Processing player release inside mission for {((MBObjectBase)npc).StringId} (skip PlayerEncounter.Finish, playerIsAtSea={flag13})");
										}
									}
									Campaign current4 = Campaign.Current;
									ConversationManager val19 = ((current4 != null) ? current4.ConversationManager : null);
									if (val19 != null && val19.IsConversationInProgress)
									{
										Campaign.Current.ConversationManager.EndConversation();
										MobileParty partyBelongedTo5 = npc.PartyBelongedTo;
										bool flag15 = partyBelongedTo5 != null && partyBelongedTo5.Army != null;
										_behavior.LogMessage(string.Format("[DEBUG] Ended conversation after releasing player (branch hostileAndField={0}, inMission={1}, isInArmy={2}, PlayerEncounter={3}) with {4}.", hostileAndField, flag9, flag15, (PlayerEncounter.Current != null) ? "exists" : "null", ((MBObjectBase)npc).StringId));
									}
									context.CombatResponse = null;
									_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
								}
								catch (Exception ex5)
								{
									_behavior.LogMessage("[ERROR] Failed to release player: " + ex5.Message);
									context.CombatResponse = null;
									_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
									Campaign current5 = Campaign.Current;
									if (current5 != null)
									{
										ConversationManager conversationManager = current5.ConversationManager;
										if (((conversationManager != null) ? new bool?(conversationManager.IsConversationInProgress) : ((bool?)null)) == true)
										{
											Campaign.Current.ConversationManager.EndConversation();
											_behavior.LogMessage("[DEBUG] Closed conversation after release error for " + ((MBObjectBase)npc).StringId);
										}
									}
								}
							});
							_behavior.LogMessage($"[DEBUG] Scheduled player release for {((MBObjectBase)npc).StringId} in {dialogDelay2:F0} seconds.");
							InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCAction_Release}{NPC_NAME} is leaving... (dialog will close automatically in {DELAY} seconds)", (Dictionary<string, object>)null).SetTextVariable("NPC_NAME", npc.Name).SetTextVariable("DELAY", (int)dialogDelay2)).ToString(), Colors.Gray));
						}
						else if (flag6)
						{
							if (IsCastleMenuConversation(npc))
							{
								_behavior.LogMessage("[WARNING] Accept_surrender action blocked for " + ((MBObjectBase)npc).StringId + " - dialogue is through castle menu, not in mission. Clearing CombatResponse.");
								context.CombatResponse = null;
								_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
								return;
							}
							_behavior.LogMessage($"[DEBUG] Processing accept_surrender decision for {((MBObjectBase)npc).StringId}. PlayerEncounter.Current: {PlayerEncounter.Current != null}");
							float dialogDelay3 = GlobalSettings<ModSettings>.Instance.DialogDelay;
							_behavior.GetDelayedTaskManager().AddTask(dialogDelay3, delegate
							{
								try
								{
									_behavior.LogMessage("[DEBUG] Processing player surrender for " + ((MBObjectBase)npc).StringId);
									MobileParty partyBelongedTo2 = npc.PartyBelongedTo;
									bool flag9 = partyBelongedTo2 != null && partyBelongedTo2.Army != null;
									bool flag10 = flag9 && partyBelongedTo2.Army.LeaderParty == partyBelongedTo2;
									PartyBase val19 = null;
									if (PlayerEncounter.Current != null)
									{
										PlayerEncounter.PlayerSurrender = true;
										_behavior.LogMessage("[DEBUG] Set PlayerEncounter.PlayerSurrender = true");
										MobileParty partyBelongedTo3 = npc.PartyBelongedTo;
										val19 = ((partyBelongedTo3 != null) ? partyBelongedTo3.Party : null) ?? npc.PartyBelongedToAsPrisoner;
									}
									else if (flag9)
									{
										_behavior.LogMessage($"[DEBUG] PlayerEncounter.Current is null for {((MBObjectBase)npc).StringId}, but NPC is in army (isArmyLeader: {flag10}) - finding party for prisoner");
										if (flag10 && partyBelongedTo2 != null)
										{
											val19 = partyBelongedTo2.Party;
											_behavior.LogMessage($"[DEBUG] Using army leader party for prisoner: {partyBelongedTo2.Name}");
										}
										else if (partyBelongedTo2 != null)
										{
											val19 = partyBelongedTo2.Party;
											_behavior.LogMessage($"[DEBUG] Using NPC party for prisoner: {partyBelongedTo2.Name}");
										}
										else
										{
											val19 = npc.PartyBelongedToAsPrisoner;
										}
									}
									else
									{
										MobileParty partyBelongedTo4 = npc.PartyBelongedTo;
										val19 = ((partyBelongedTo4 != null) ? partyBelongedTo4.Party : null) ?? npc.PartyBelongedToAsPrisoner;
										_behavior.LogMessage("[WARNING] PlayerEncounter.Current is null and NPC is not in army - attempting to use party directly");
									}
									if (val19 != null && val19.IsActive)
									{
										TakePrisonerAction.Apply(val19, Hero.MainHero);
										_behavior.LogMessage($"[DEBUG] Player taken prisoner by {npc.Name}'s party ({val19.Name})");
									}
									else
									{
										_behavior.LogMessage($"[ERROR] Could not find active party for NPC {npc.Name} to take player prisoner");
									}
									Campaign current = Campaign.Current;
									ConversationManager val20 = ((current != null) ? current.ConversationManager : null);
									if (val20 != null && val20.IsConversationInProgress)
									{
										Campaign.Current.ConversationManager.EndConversation();
										_behavior.LogMessage(string.Format("[DEBUG] Ended conversation after accepting player surrender (isInArmy={0}, PlayerEncounter={1}) with {2}.", flag9, (PlayerEncounter.Current != null) ? "exists" : "null", ((MBObjectBase)npc).StringId));
									}
									context.CombatResponse = null;
									context.IsPlayerSurrendering = false;
									_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
								}
								catch (Exception ex5)
								{
									_behavior.LogMessage("[ERROR] Failed to process player surrender: " + ex5.Message);
									context.CombatResponse = null;
									context.IsPlayerSurrendering = false;
									_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
									Campaign current2 = Campaign.Current;
									if (current2 != null)
									{
										ConversationManager conversationManager = current2.ConversationManager;
										if (((conversationManager != null) ? new bool?(conversationManager.IsConversationInProgress) : ((bool?)null)) == true)
										{
											Campaign.Current.ConversationManager.EndConversation();
											_behavior.LogMessage("[DEBUG] Closed conversation after accept_surrender error for " + ((MBObjectBase)npc).StringId);
										}
									}
								}
							});
							_behavior.LogMessage($"[DEBUG] Scheduled player surrender for {((MBObjectBase)npc).StringId} in {dialogDelay3:F0} seconds.");
							InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_PlayerSurrender}You have surrendered to {npcName}... (dialog will close automatically in {DELAY} seconds)", new Dictionary<string, object>
							{
								{ "npcName", npc.Name },
								{
									"DELAY",
									(int)dialogDelay3
								}
							})).ToString(), Colors.Gray));
						}
						else if (context.IsSurrendering)
						{
							if (IsCastleMenuConversation(npc))
							{
								_behavior.LogMessage("[WARNING] Surrender action blocked for " + ((MBObjectBase)npc).StringId + " - dialogue is through castle menu, not in mission. Clearing IsSurrendering.");
								context.IsSurrendering = false;
								_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
								return;
							}
							float dialogDelay4 = GlobalSettings<ModSettings>.Instance.DialogDelay;
							_behavior.GetDelayedTaskManager().AddTask(dialogDelay4, delegate
							{
								try
								{
									MobileParty partyBelongedTo2 = npc.PartyBelongedTo;
									bool flag9 = partyBelongedTo2 != null && partyBelongedTo2.Army != null;
									_decisionHandler.HandleSurrender(npc, ((object)npc.Name).ToString(), context, null);
									context.IsSurrendering = false;
									context.CombatResponse = null;
									_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
									_behavior.LogMessage($"[DEBUG] NPC {((MBObjectBase)npc).StringId} surrendered after {dialogDelay4:F0} seconds (isInArmy: {flag9}).");
									Campaign current = Campaign.Current;
									ConversationManager val19 = ((current != null) ? current.ConversationManager : null);
									if (val19 != null && val19.IsConversationInProgress)
									{
										Campaign.Current.ConversationManager.EndConversation();
										_behavior.LogMessage($"[DEBUG] Ended conversation after surrender of {((MBObjectBase)npc).StringId} (isInArmy: {flag9}).");
									}
								}
								catch (Exception ex5)
								{
									_behavior.LogMessage("[ERROR] Failed to process surrender for " + ((MBObjectBase)npc).StringId + ": " + ex5.Message + "\n" + ex5.StackTrace);
									context.IsSurrendering = false;
									context.CombatResponse = null;
									_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
									Campaign current2 = Campaign.Current;
									if (current2 != null)
									{
										ConversationManager conversationManager = current2.ConversationManager;
										if (((conversationManager != null) ? new bool?(conversationManager.IsConversationInProgress) : ((bool?)null)) == true)
										{
											Campaign.Current.ConversationManager.EndConversation();
											_behavior.LogMessage("[DEBUG] Closed conversation after surrender error for " + ((MBObjectBase)npc).StringId);
										}
									}
								}
							});
							_behavior.LogMessage($"[DEBUG] Scheduled surrender for {((MBObjectBase)npc).StringId} in {dialogDelay4:F0} seconds.");
							InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCAction_Surrender}NPC is deciding to surrender... (dialog will close automatically in {DELAY} seconds)", (Dictionary<string, object>)null).SetTextVariable("DELAY", (int)dialogDelay4)).ToString(), Colors.Gray));
						}
						else if (context.MarriageResponse == "married")
						{
							float dialogDelay5 = GlobalSettings<ModSettings>.Instance.DialogDelay;
							_behavior.GetDelayedTaskManager().AddTask(dialogDelay5, delegate
							{
								try
								{
									_behavior.LogMessage("[DEBUG] Executing delayed marriage for " + ((MBObjectBase)npc).StringId + "...");
									MarriageSystem.AcceptMarriage(npc, Hero.MainHero, context);
									_behavior.LogMessage("[DEBUG] Marriage completed for " + ((MBObjectBase)npc).StringId);
									context.MarriageResponse = null;
									_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
									_behavior.LogMessage("[DEBUG] Cleared MarriageResponse for " + ((MBObjectBase)npc).StringId + " after wedding.");
								}
								catch (Exception ex5)
								{
									_behavior.LogMessage("[ERROR] Failed to process marriage for " + ((MBObjectBase)npc).StringId + ": " + ex5.Message + "\n" + ex5.StackTrace);
									context.MarriageResponse = null;
									_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
									Campaign current = Campaign.Current;
									if (current != null)
									{
										ConversationManager conversationManager = current.ConversationManager;
										if (((conversationManager != null) ? new bool?(conversationManager.IsConversationInProgress) : ((bool?)null)) == true)
										{
											Campaign.Current.ConversationManager.EndConversation();
											_behavior.LogMessage("[DEBUG] Closed conversation after marriage error for " + ((MBObjectBase)npc).StringId);
										}
									}
								}
							});
							_behavior.LogMessage($"[DEBUG] Scheduled wedding for {((MBObjectBase)npc).StringId} in {dialogDelay5:F0} seconds.");
							InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCAction_Marriage}Wedding will occur in {DELAY} seconds... (dialog will close automatically in {DELAY} seconds)", (Dictionary<string, object>)null).SetTextVariable("DELAY", (int)dialogDelay5)).ToString(), Colors.Gray));
						}
						else if (context.MarriageResponse == "rejected")
						{
							context.MarriageResponse = null;
							_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
							_behavior.LogMessage("[DEBUG] Cleared rejected MarriageResponse for " + ((MBObjectBase)npc).StringId + ". Dialog continues.");
						}
					}
					if (context.PendingDeath == "pending")
					{
						bool isSettlementCombat = context.PendingSettlementCombat == "roleplay_death";
						_behavior.GetDelayedTaskManager().AddTask(5.0, delegate
						{
							try
							{
								_behavior.LogMessage($"[ROLEPLAY] Processing delayed death for {((MBObjectBase)npc).StringId} (prisoner: {npc.IsPrisoner}), Settlement Combat: {isSettlementCombat}");
								if (isSettlementCombat)
								{
									_behavior.LogMessage("[SETTLEMENT_COMBAT] Initiating combat analysis for roleplay death in settlement");
									SettlementCombatManager settlementCombatManager = _behavior.GetSettlementCombatManager();
									if (settlementCombatManager != null)
									{
										settlementCombatManager.InitiateCombat(npc, context, CombatTriggerType.RoleplayDeath, context.SettlementCombatResponse);
										context.PendingSettlementCombat = null;
										context.SettlementCombatResponse = null;
										_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
									}
									else
									{
										_behavior.LogMessage("[ERROR] SettlementCombatManager not found!");
									}
								}
								else
								{
									Campaign current = Campaign.Current;
									bool flag9;
									if (current == null)
									{
										flag9 = false;
									}
									else
									{
										ConversationManager conversationManager = current.ConversationManager;
										flag9 = ((conversationManager != null) ? new bool?(conversationManager.IsConversationInProgress) : ((bool?)null)) == true;
									}
									if (flag9)
									{
										Campaign.Current.ConversationManager.EndConversation();
										_behavior.LogMessage("[DEBUG] Ended conversation before death of " + ((MBObjectBase)npc).StringId + ".");
									}
									_behavior.GetDelayedTaskManager().AddTask(1.0, delegate
									{
										try
										{
											if (npc != null && !npc.IsDead)
											{
												Hero val19 = null;
												if (!string.IsNullOrEmpty(context.KillerStringId))
												{
													val19 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => h != null && ((MBObjectBase)h).StringId == context.KillerStringId));
													if (val19 != null)
													{
														_behavior.LogMessage($"[ROLEPLAY] Killer identified as: {val19.Name} ({context.KillerStringId})");
													}
													else
													{
														_behavior.LogMessage("[ROLEPLAY] Killer with ID " + context.KillerStringId + " not found, using null");
													}
												}
												else
												{
													_behavior.LogMessage("[ROLEPLAY] Natural death (no killer specified)");
												}
												_behavior.KillCharacterHeroPublic(npc, val19, killedInAction: false);
												_behavior.LogMessage($"[ROLEPLAY] Character {npc.Name} (prisoner: {npc.IsPrisoner}) has been removed from the game.");
											}
											context.PendingDeath = null;
											context.KillerStringId = null;
											_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
										}
										catch (Exception ex6)
										{
											_behavior.LogMessage("[ERROR] Failed to kill character " + ((MBObjectBase)npc).StringId + ": " + ex6.Message + "\n" + ex6.StackTrace);
										}
									});
								}
							}
							catch (Exception ex5)
							{
								_behavior.LogMessage("[ERROR] Failed to process pending death for " + ((MBObjectBase)npc).StringId + ": " + ex5.Message + "\n" + ex5.StackTrace);
							}
						});
						float dialogDelay6 = GlobalSettings<ModSettings>.Instance.DialogDelay;
						_behavior.LogMessage($"[DEBUG] Scheduled character death for {((MBObjectBase)npc).StringId} (prisoner: {npc.IsPrisoner}) in {dialogDelay6:F0} seconds.");
						InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_NPCAction_Death}NPC is experiencing final moments... (dialog will close automatically)", (Dictionary<string, object>)null)).ToString(), Colors.Gray));
					}
				}
			});
			SafeAddDialogLine(starter, "aiinfluence_apply_changes", "aiinfluence_apply_changes", "aiinfluence_input", "{=AIInfluence_NPCContinue}...", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && IsNonCombatConversation(Hero.OneToOneConversationHero)), null);
			SafeAddDialogLine(starter, "aiinfluence_apply_changes_combat", "aiinfluence_apply_changes", "aiinfluence_locked", "{=AIInfluence_DynamicResponse}{DYNAMIC_NPC_RESPONSE}", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && !IsNonCombatConversation(Hero.OneToOneConversationHero)), null);
			SafeAddDialogLine(starter, "aiinfluence_locked", "aiinfluence_locked", "aiinfluence_locked", "{=AIInfluence_DynamicResponse}{DYNAMIC_NPC_RESPONSE}", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && !IsNonCombatConversation(Hero.OneToOneConversationHero)), null);
			object obj13 = _003C_003Ec._003C_003E9__6_33;
			if (obj13 == null)
			{
				OnConditionDelegate val13 = () => false;
				_003C_003Ec._003C_003E9__6_33 = val13;
				obj13 = (object)val13;
			}
			SafeAddPlayerLine(starter, "aiinfluence_locked_player", "aiinfluence_locked", "aiinfluence_locked", "{=AIInfluence_LockedPlaceholder}...", (OnConditionDelegate)obj13, null);
			object obj14 = _003C_003Ec._003C_003E9__6_34;
			if (obj14 == null)
			{
				OnConditionDelegate val14 = () => Hero.OneToOneConversationHero != null;
				_003C_003Ec._003C_003E9__6_34 = val14;
				obj14 = (object)val14;
			}
			SafeAddPlayerLine(starter, "aiinfluence_surrender_start", "player_responds_to_surrender_demand", "aiinfluence_surrender_response", "{=AIInfluence_PlayerStart}Talk [AI Influence]", (OnConditionDelegate)obj14, null);
			SafeAddDialogLine(starter, "aiinfluence_surrender_response", "aiinfluence_surrender_response", "aiinfluence_surrender_input", "{=AIInfluence_NPCResponse}I'm listening.", null, null);
			object obj15 = _003C_003Ec._003C_003E9__6_35;
			if (obj15 == null)
			{
				OnConditionDelegate val15 = () => Hero.OneToOneConversationHero != null;
				_003C_003Ec._003C_003E9__6_35 = val15;
				obj15 = (object)val15;
			}
			SafeAddPlayerLine(starter, "aiinfluence_surrender_input", "aiinfluence_surrender_input", "aiinfluence_surrender_processing", "{=AIInfluence_PlayerThink}Speak", (OnConditionDelegate)obj15, (OnConsequenceDelegate)delegate
			{
				_behavior.HandlePlayerInput();
			});
			object obj16 = _003C_003Ec._003C_003E9__6_37;
			if (obj16 == null)
			{
				OnConditionDelegate val16 = () => Hero.OneToOneConversationHero != null;
				_003C_003Ec._003C_003E9__6_37 = val16;
				obj16 = (object)val16;
			}
			SafeAddPlayerLine(starter, "aiinfluence_surrender_exit", "aiinfluence_surrender_input", "lord_demands_surrender_after_comment", "{=AIInfluence_PlayerExit}Return", (OnConditionDelegate)obj16, (OnConsequenceDelegate)delegate
			{
				Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
				if (oneToOneConversationHero != null)
				{
					NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(oneToOneConversationHero);
					orCreateNPCContext.CombatResponse = null;
					orCreateNPCContext.IsSurrendering = false;
					orCreateNPCContext.MarriageResponse = null;
					orCreateNPCContext.PendingWorkshopSale = null;
					orCreateNPCContext.PendingMoneyTransfer = null;
					orCreateNPCContext.PendingItemTransfers = null;
					orCreateNPCContext.PendingDeath = null;
					_behavior.SaveNPCContext(((MBObjectBase)oneToOneConversationHero).StringId, oneToOneConversationHero, orCreateNPCContext);
					_behavior.LogMessage("[DEBUG] Exiting surrender dialog with NPC " + ((MBObjectBase)oneToOneConversationHero).StringId + " to lord_demands_surrender_after_comment.");
				}
			});
			SafeAddDialogLine(starter, "aiinfluence_surrender_processing", "aiinfluence_surrender_processing", "aiinfluence_surrender_waiting", "{=AIInfluence_NPCProcessing}(Send a message and wait for the NPC's response)", null, null);
			object obj17 = _003C_003Ec._003C_003E9__6_39;
			if (obj17 == null)
			{
				OnConditionDelegate val17 = () => Hero.OneToOneConversationHero != null;
				_003C_003Ec._003C_003E9__6_39 = val17;
				obj17 = (object)val17;
			}
			SafeAddPlayerLine(starter, "aiinfluence_surrender_waiting", "aiinfluence_surrender_waiting", "aiinfluence_surrender_dynamic_response", "{=AIInfluence_PlayerAsk}View NPC's response", (OnConditionDelegate)obj17, null);
			object obj18 = _003C_003Ec._003C_003E9__6_40;
			if (obj18 == null)
			{
				OnConditionDelegate val18 = () => Hero.OneToOneConversationHero != null;
				_003C_003Ec._003C_003E9__6_40 = val18;
				obj18 = (object)val18;
			}
			SafeAddDialogLine(starter, "aiinfluence_surrender_dynamic_response", "aiinfluence_surrender_dynamic_response", "aiinfluence_surrender_apply_changes", "{=AIInfluence_DynamicResponse}{DYNAMIC_NPC_RESPONSE}", (OnConditionDelegate)obj18, (OnConsequenceDelegate)delegate
			{
				//IL_0327: Unknown result type (might be due to invalid IL or missing references)
				//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
				Hero npc = Hero.OneToOneConversationHero;
				if (npc != null)
				{
					NPCContext context = _behavior.GetOrCreateNPCContext(npc);
					ModSettings instance = GlobalSettings<ModSettings>.Instance;
					if (instance != null && instance.EnableTTS)
					{
						if (context.PreparedTts != null)
						{
							_behavior.LogMessage($"[TTS] Playing pre-prepared TTS for {npc.Name} (surrender flow)");
							TtsLipSyncService.PlayPrepared(context.PreparedTts);
							context.PreparedTts = null;
						}
						else
						{
							_behavior.LogMessage($"[TTS] No prepared TTS available for {npc.Name} (surrender flow), skipping playback.");
						}
					}
					_behavior.LogMessage($"[DEBUG] Displaying dynamic response for NPC {((MBObjectBase)npc).StringId} in surrender dialog. CombatResponse={context.CombatResponse}, IsSurrendering={context.IsSurrendering}, MarriageResponse={context.MarriageResponse}");
					if (!npc.IsPrisoner && context.CombatResponse != null)
					{
						bool flag = context.CombatResponse.IndexOf("attack", StringComparison.OrdinalIgnoreCase) >= 0;
						bool flag2 = context.CombatResponse.IndexOf("release", StringComparison.OrdinalIgnoreCase) >= 0;
						bool flag3 = context.CombatResponse.IndexOf("accept_surrender", StringComparison.OrdinalIgnoreCase) >= 0;
						_behavior.LogMessage($"[DEBUG] In surrender dialog for {((MBObjectBase)npc).StringId}: isAttack={flag}, isRelease={flag2}, isAcceptSurrender={flag3}");
						if (flag)
						{
							if (Settlement.CurrentSettlement != null && Mission.Current != null)
							{
								_behavior.LogMessage("[DEBUG] Settlement combat in surrender dialog - PendingSettlementCombat: " + context.PendingSettlementCombat);
								if (context.PendingSettlementCombat == "attack")
								{
									_behavior.GetDelayedTaskManager().AddTask(5.0, delegate
									{
										SettlementCombatManager settlementCombatManager = _behavior.GetSettlementCombatManager();
										if (settlementCombatManager != null && context.PendingSettlementCombat == "attack")
										{
											_behavior.LogMessage("[SETTLEMENT_COMBAT] Initiating combat from surrender dialog");
											settlementCombatManager.InitiateCombat(npc, context, CombatTriggerType.NPCAttack, context.SettlementCombatResponse);
											context.PendingSettlementCombat = null;
											context.SettlementCombatResponse = null;
											_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
										}
									});
								}
							}
							else
							{
								float dialogDelay = GlobalSettings<ModSettings>.Instance.DialogDelay;
								_behavior.GetDelayedTaskManager().AddTask(dialogDelay, delegate
								{
									try
									{
										_behavior.LogMessage("[DEBUG] Calling InitiateCombatLogic from surrender dialog for " + ((MBObjectBase)npc).StringId);
										_behavior.InitiateCombatLogic(npc, context);
									}
									catch (Exception ex2)
									{
										_behavior.LogMessage("[ERROR] Failed to initiate combat from surrender dialog: " + ex2.Message);
									}
								});
							}
						}
					}
					if (context.PendingRelationChange != null)
					{
						PendingRelationChange pendingRelationChange = context.PendingRelationChange;
						_behavior.ApplyRelationChangeWithDelay(npc, pendingRelationChange.RelationChange, pendingRelationChange.Color, pendingRelationChange.Message);
						_behavior.LogMessage($"[DEBUG] Scheduled relation change for NPC {((MBObjectBase)npc).StringId} by {pendingRelationChange.RelationChange} in 4s.");
						context.PendingRelationChange = null;
					}
					if (context.PendingLiePenalty != null)
					{
						PendingRelationChange pendingLiePenalty = context.PendingLiePenalty;
						_behavior.ApplyRelationChangeWithDelay(npc, pendingLiePenalty.RelationChange, pendingLiePenalty.Color, pendingLiePenalty.Message);
						_behavior.LogMessage($"[DEBUG] Scheduled lie penalty for NPC {((MBObjectBase)npc).StringId} by {pendingLiePenalty.RelationChange} in 4s.");
						context.PendingLiePenalty = null;
					}
					if (context.PendingWorkshopSale != null && !npc.IsPrisoner)
					{
						_behavior.LogMessage($"[DEBUG] Executing pending workshop sale for NPC {((MBObjectBase)npc).StringId} (surrender dialog).");
						_behavior.ExecutePendingWorkshopSale(npc, context);
						_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
					}
					else if (context.PendingWorkshopSale != null && npc.IsPrisoner)
					{
						_behavior.LogMessage($"[DEBUG] Cleared pending workshop sale for prisoner {((MBObjectBase)npc).StringId} (surrender dialog).");
						context.PendingWorkshopSale = null;
					}
					if (context.PendingAIResponse != null)
					{
						context.PendingAIResponse = null;
						context.InteractionCount++;
						_behavior.UpdateContextData(context, npc);
					}
					if (context.PendingMoneyTransfer != null)
					{
						_behavior.LogMessage($"[MONEY_TRANSFER] Executing pending money transfer for NPC {((MBObjectBase)npc).StringId} (Prisoner: {npc.IsPrisoner}, surrender dialog): {context.PendingMoneyTransfer.Action} {context.PendingMoneyTransfer.Amount} denars");
						_behavior.ProcessMoneyTransfer(npc, context, context.PendingMoneyTransfer);
						context.PendingMoneyTransfer = null;
						_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
						_behavior.LogMessage($"[MONEY_TRANSFER] Money transfer completed for NPC {((MBObjectBase)npc).StringId} (surrender dialog)");
					}
					if (context.PendingItemTransfers != null && context.PendingItemTransfers.Count > 0)
					{
						_behavior.LogMessage($"[ITEM_TRANSFER] Executing pending item transfers for NPC {((MBObjectBase)npc).StringId} (Prisoner: {npc.IsPrisoner}, surrender dialog): {context.PendingItemTransfers.Count} items");
						_behavior.ProcessItemTransfers(npc, context, context.PendingItemTransfers);
						context.PendingItemTransfers = null;
						_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
						_behavior.LogMessage($"[ITEM_TRANSFER] Item transfers completed for NPC {((MBObjectBase)npc).StringId} (surrender dialog)");
					}
				}
			});
			SafeAddDialogLine(starter, "aiinfluence_surrender_apply_changes", "aiinfluence_surrender_apply_changes", "aiinfluence_surrender_input", "{=AIInfluence_NPCContinue}...", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && IsNonCombatConversation(Hero.OneToOneConversationHero)), null);
			SafeAddDialogLine(starter, "aiinfluence_surrender_apply_changes_combat", "aiinfluence_surrender_apply_changes", "aiinfluence_locked", "{=AIInfluence_DynamicResponse}{DYNAMIC_NPC_RESPONSE}", (OnConditionDelegate)(() => Hero.OneToOneConversationHero != null && !IsNonCombatConversation(Hero.OneToOneConversationHero)), null);
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[ERROR] Failed to add dialogs: " + ex.Message);
		}
	}

	private bool IsNonCombatConversation(Hero npc)
	{
		NPCContext orCreateNPCContext = _behavior.GetOrCreateNPCContext(npc);
		if (npc.IsPrisoner)
		{
			return true;
		}
		bool flag = orCreateNPCContext.CombatResponse != null && orCreateNPCContext.CombatResponse.IndexOf("release", StringComparison.OrdinalIgnoreCase) >= 0;
		return orCreateNPCContext.CombatResponse == null && !orCreateNPCContext.IsSurrendering && orCreateNPCContext.PendingDeath == null && orCreateNPCContext.MarriageResponse != "married";
	}

	private List<MobileParty> GetFollowingPlayerParties()
	{
		List<MobileParty> list = new List<MobileParty>();
		try
		{
			if (AIActionManager.Instance == null)
			{
				return list;
			}
			FieldInfo field = typeof(AIActionManager).GetField("_activeActions", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field == null)
			{
				_behavior.LogMessage("[WARNING] Could not access _activeActions field via reflection");
				return list;
			}
			if (!(field.GetValue(AIActionManager.Instance) is Dictionary<Hero, List<AIActionBase>> dictionary))
			{
				return list;
			}
			foreach (KeyValuePair<Hero, List<AIActionBase>> item in dictionary)
			{
				Hero key = item.Key;
				if (key == null || key.IsDead || key.IsPrisoner)
				{
					continue;
				}
				List<AIActionBase> value = item.Value;
				if (value == null)
				{
					continue;
				}
				AIActionBase aIActionBase = value.FirstOrDefault((AIActionBase a) => a.ActionName == "follow_player" && a.IsActive);
				if (aIActionBase != null)
				{
					MobileParty partyBelongedTo = key.PartyBelongedTo;
					if (partyBelongedTo != null && partyBelongedTo != MobileParty.MainParty && !list.Contains(partyBelongedTo))
					{
						list.Add(partyBelongedTo);
						_behavior.LogMessage($"[DEBUG] Found following party: {partyBelongedTo.Name} (leader: {key.Name})");
					}
				}
			}
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[ERROR] Failed to get following player parties: " + ex.Message);
		}
		return list;
	}

	private void ProtectFollowingPlayerParties(MobileParty npcParty, bool isArmyLeader = false)
	{
		try
		{
			List<MobileParty> followingPlayerParties = GetFollowingPlayerParties();
			if (followingPlayerParties.Count == 0 || npcParty == null)
			{
				return;
			}
			Type type = ((object)npcParty.Ai).GetType();
			MethodInfo method = type.GetMethod("SetDoNotAttackParty", new Type[2]
			{
				typeof(MobileParty),
				typeof(float)
			});
			foreach (MobileParty item in followingPlayerParties)
			{
				if (item == null || item == MobileParty.MainParty)
				{
					continue;
				}
				if (method != null)
				{
					try
					{
						method.Invoke(npcParty.Ai, new object[2] { item, 24f });
						_behavior.LogMessage($"[DEBUG] Protected following party {item.Name} from attack by {npcParty.Name} for 24 hours (using SetDoNotAttackParty)");
					}
					catch (Exception ex)
					{
						_behavior.LogMessage("[WARNING] Failed to use SetDoNotAttackParty: " + ex.Message);
						SetPartyIgnoredUntil(item, 24);
						_behavior.LogMessage($"[DEBUG] Protected following party {item.Name} from attack by {npcParty.Name} for 24 hours (using IgnoreByOtherPartiesTill as fallback)");
					}
				}
				else
				{
					SetPartyIgnoredUntil(item, 24);
					_behavior.LogMessage($"[DEBUG] Protected following party {item.Name} from attack by {npcParty.Name} for 24 hours (using IgnoreByOtherPartiesTill)");
				}
				if (!isArmyLeader || npcParty.Army == null)
				{
					continue;
				}
				foreach (MobileParty item2 in (List<MobileParty>)(object)npcParty.Army.Parties)
				{
					if (item2 == npcParty || item2 == null)
					{
						continue;
					}
					if (method != null)
					{
						try
						{
							method.Invoke(item2.Ai, new object[2] { item, 24f });
							_behavior.LogMessage($"[DEBUG] Protected following party {item.Name} from attack by army party {item2.Name} for 24 hours");
						}
						catch (Exception ex2)
						{
							_behavior.LogMessage("[WARNING] Failed to use SetDoNotAttackParty for army party: " + ex2.Message);
						}
					}
					else
					{
						_behavior.LogMessage($"[DEBUG] Following party {item.Name} already protected from all parties (army party {item2.Name} included)");
					}
				}
			}
		}
		catch (Exception ex3)
		{
			_behavior.LogMessage("[ERROR] Failed to protect following player parties: " + ex3.Message);
		}
	}

	private void SetPartyIgnoredUntil(MobileParty party, int hours)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (party != null)
			{
				CampaignTime val = CampaignTime.HoursFromNow((float)hours);
				party.IgnoreByOtherPartiesTill(val);
				_behavior.LogMessage($"[DEBUG] Set party {party.Name} to be ignored by other parties until {val}");
			}
		}
		catch (Exception ex)
		{
			_behavior.LogMessage($"[ERROR] Failed to set party {((party != null) ? party.Name : null)} as ignored: {ex.Message}");
		}
	}

	private bool IsCastleMenuConversation(Hero npc)
	{
		if (npc == null)
		{
			return false;
		}
		if (Mission.Current != null)
		{
			return false;
		}
		if (CampaignMission.Current != null)
		{
			return false;
		}
		NPCContext nPCContextByStringId = _behavior.GetNPCContextByStringId(((MBObjectBase)npc).StringId);
		if (nPCContextByStringId != null && nPCContextByStringId.IsNPCInitiatedConversation)
		{
			return false;
		}
		if (npc.CurrentSettlement == null)
		{
			return false;
		}
		GameStateManager current = GameStateManager.Current;
		GameState val = ((current != null) ? current.ActiveState : null);
		if (val is MapState)
		{
			Hero mainHero = Hero.MainHero;
			return ((mainHero != null) ? mainHero.CurrentSettlement : null) != null;
		}
		return true;
	}

	private bool IsNPCInitiatedConversation(Hero npc)
	{
		if (npc == null)
		{
			return false;
		}
		return _behavior.GetNPCContextByStringId(((MBObjectBase)npc).StringId)?.IsNPCInitiatedConversation ?? false;
	}

	private bool IsHostileNPCInitiatedConversation(Hero npc)
	{
		if (npc == null)
		{
			return false;
		}
		NPCContext nPCContextByStringId = _behavior.GetNPCContextByStringId(((MBObjectBase)npc).StringId);
		if (nPCContextByStringId == null)
		{
			return false;
		}
		return nPCContextByStringId.IsNPCInitiatedConversation && nPCContextByStringId.IsHostileInitiative;
	}

	private bool IsNeutralNPCInitiatedConversation(Hero npc)
	{
		if (npc == null)
		{
			return false;
		}
		NPCContext nPCContextByStringId = _behavior.GetNPCContextByStringId(((MBObjectBase)npc).StringId);
		if (nPCContextByStringId == null)
		{
			return false;
		}
		return nPCContextByStringId.IsNPCInitiatedConversation && !nPCContextByStringId.IsHostileInitiative;
	}

	private bool IsPlayerDefenderInEncounter()
	{
		return PlayerEncounter.Current != null && !PlayerEncounter.PlayerIsAttacker;
	}

	private void SafeAddPlayerLine(CampaignGameStarter starter, string id, string inputToken, string outputToken, string text, OnConditionDelegate conditionDelegate, OnConsequenceDelegate consequenceDelegate)
	{
		if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(inputToken))
		{
			starter.AddPlayerLine(id, inputToken, outputToken, text, conditionDelegate, consequenceDelegate, 100, (OnClickableConditionDelegate)null, (OnPersuasionOptionDelegate)null);
		}
		else
		{
			_behavior.LogMessage("[WARNING] Skipped adding player line. id or inputToken is null/empty.");
		}
	}

	private void SafeAddDialogLine(CampaignGameStarter starter, string id, string inputToken, string outputToken, string text, OnConditionDelegate conditionDelegate, OnConsequenceDelegate consequenceDelegate, int priority = 100)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(inputToken))
		{
			starter.AddDialogLineMultiAgent(id, inputToken, outputToken, new TextObject(text, (Dictionary<string, object>)null), conditionDelegate, consequenceDelegate, 0, 0, priority, (OnClickableConditionDelegate)null);
		}
		else
		{
			_behavior.LogMessage("[WARNING] Skipped adding dialog line. id or inputToken is null/empty.");
		}
	}

	private static string GetDynamicNPCResponseText()
	{
		try
		{
			FieldInfo field = typeof(MBTextManager).GetField("_cachedTextVariables", BindingFlags.Static | BindingFlags.NonPublic);
			if (field != null && field.GetValue(null) is IDictionary dictionary && dictionary.Contains("DYNAMIC_NPC_RESPONSE"))
			{
				return dictionary["DYNAMIC_NPC_RESPONSE"]?.ToString();
			}
		}
		catch
		{
		}
		return null;
	}

	private void WieldBestMeleeWeaponForAgent(Agent agent)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Invalid comparison between Unknown and I4
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Invalid comparison between Unknown and I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Invalid comparison between Unknown and I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Invalid comparison between Unknown and I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Invalid comparison between Unknown and I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Invalid comparison between Unknown and I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Invalid comparison between Unknown and I4
		try
		{
			if (agent == null || !agent.IsActive())
			{
				return;
			}
			EquipmentIndex val = (EquipmentIndex)(-1);
			for (EquipmentIndex val2 = (EquipmentIndex)0; (int)val2 < 5; val2 = (EquipmentIndex)(val2 + 1))
			{
				MissionWeapon val3 = agent.Equipment[val2];
				if (!(val3).IsEmpty)
				{
					val3 = agent.Equipment[val2];
					WeaponClass weaponClass = (val3).CurrentUsageItem.WeaponClass;
					if ((int)weaponClass == 2 || (int)weaponClass == 3 || (int)weaponClass == 4 || (int)weaponClass == 5 || (int)weaponClass == 6 || (int)weaponClass == 8 || (int)weaponClass == 7 || (int)weaponClass == 1 || (int)weaponClass == 9 || (int)weaponClass == 10 || (int)weaponClass == 11)
					{
						val = val2;
						break;
					}
					if ((int)val == -1)
					{
						val = val2;
					}
				}
			}
			if ((int)val != -1)
			{
				agent.TryToWieldWeaponInSlot(val, (WeaponWieldActionType)2, false);
			}
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[ERROR] WieldBestMeleeWeaponForAgent failed: " + ex.Message);
		}
	}

	private static bool IsPlayerKingdomGovernor()
	{
		try
		{
			Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
			if (oneToOneConversationHero == null)
			{
				return false;
			}
			Hero mainHero = Hero.MainHero;
			object obj;
			if (mainHero == null)
			{
				obj = null;
			}
			else
			{
				Clan clan = mainHero.Clan;
				obj = ((clan != null) ? clan.Kingdom : null);
			}
			Kingdom val = (Kingdom)obj;
			if (val == null)
			{
				return false;
			}
			if (val.Leader != Hero.MainHero)
			{
				return false;
			}
			if (oneToOneConversationHero.GovernorOf != null)
			{
				Town governorOf = oneToOneConversationHero.GovernorOf;
				Clan ownerClan = governorOf.OwnerClan;
				if (((ownerClan != null) ? ownerClan.Kingdom : null) == val)
				{
					return true;
				}
			}
			return false;
		}
		catch
		{
			return false;
		}
	}
}
