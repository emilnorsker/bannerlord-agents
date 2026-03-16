using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem;

public class CampaignGameStarter : IGameStarter
{
	private readonly GameMenuManager _gameMenuManager;

	private readonly ConversationManager _conversationManager;

	private readonly List<CampaignBehaviorBase> _campaignBehaviors;

	private readonly List<GameModel> _models;

	public ICollection<CampaignBehaviorBase> CampaignBehaviors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IEnumerable<GameModel> Models
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CampaignGameStarter(GameMenuManager gameMenuManager, ConversationManager conversationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnregisterNonReadyObjects()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddBehavior(CampaignBehaviorBase campaignBehavior)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveBehaviors<T>() where T : CampaignBehaviorBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool RemoveBehavior<T>(T behavior) where T : CampaignBehaviorBase
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetModel<T>() where T : GameModel
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddModel(GameModel gameModel)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddModel<T>(MBGameModel<T> gameModel) where T : GameModel
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddGameMenu(string menuId, string menuText, OnInitDelegate initDelegate, GameMenu.MenuOverlayType overlay = GameMenu.MenuOverlayType.None, GameMenu.MenuFlags menuFlags = GameMenu.MenuFlags.None, object relatedObject = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddWaitGameMenu(string idString, string text, OnInitDelegate initDelegate, OnConditionDelegate condition, OnConsequenceDelegate consequence, OnTickDelegate tick, GameMenu.MenuAndOptionType type, GameMenu.MenuOverlayType overlay = GameMenu.MenuOverlayType.None, float targetWaitHours = 0f, GameMenu.MenuFlags flags = GameMenu.MenuFlags.None, object relatedObject = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddGameMenuOption(string menuId, string optionId, string optionText, GameMenuOption.OnConditionDelegate condition, GameMenuOption.OnConsequenceDelegate consequence, bool isLeave = false, int index = -1, bool isRepeatable = false, object relatedObject = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GameMenu GetPresumedGameMenu(string stringId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ConversationSentence AddDialogLine(ConversationSentence dialogLine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddDialogFlow(DialogFlow dialogFlow, object relatedObject = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversationSentence AddPlayerLine(string id, string inputToken, string outputToken, string text, ConversationSentence.OnConditionDelegate conditionDelegate, ConversationSentence.OnConsequenceDelegate consequenceDelegate, int priority = 100, ConversationSentence.OnClickableConditionDelegate clickableConditionDelegate = null, ConversationSentence.OnPersuasionOptionDelegate persuasionOptionDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversationSentence AddRepeatablePlayerLine(string id, string inputToken, string outputToken, string text, string continueListingRepeatedObjectsText, string continueListingOptionOutputToken, ConversationSentence.OnConditionDelegate conditionDelegate, ConversationSentence.OnConsequenceDelegate consequenceDelegate, int priority = 100, ConversationSentence.OnClickableConditionDelegate clickableConditionDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversationSentence AddDialogLineWithVariation(string id, string inputToken, string outputToken, ConversationSentence.OnConditionDelegate conditionDelegate, ConversationSentence.OnConsequenceDelegate consequenceDelegate, int priority = 100, string idleActionId = "", string idleFaceAnimId = "", string reactionId = "", string reactionFaceAnimId = "", ConversationSentence.OnClickableConditionDelegate clickableConditionDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversationSentence AddDialogLine(string id, string inputToken, string outputToken, string text, ConversationSentence.OnConditionDelegate conditionDelegate, ConversationSentence.OnConsequenceDelegate consequenceDelegate, int priority = 100, ConversationSentence.OnClickableConditionDelegate clickableConditionDelegate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ConversationSentence AddDialogLineMultiAgent(string id, string inputToken, string outputToken, TextObject text, ConversationSentence.OnConditionDelegate conditionDelegate, ConversationSentence.OnConsequenceDelegate consequenceDelegate, int agentIndex, int nextAgentIndex, int priority = 100, ConversationSentence.OnClickableConditionDelegate clickableConditionDelegate = null)
	{
		throw null;
	}
}
