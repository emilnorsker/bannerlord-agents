using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AIInfluence.Services;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

[JsonSerializable]
public class NPCContext
{
	public string Name { get; set; } = "Unknown_NPC";

	public string StringId { get; set; } = "";

	public string Gender { get; set; }

	public string AssignedTTSVoice { get; set; } = "";

	public string LastTTSPlayedText { get; set; } = "";

	public string LastTTSInstructions { get; set; } = "";

	[JsonIgnore]
	public TtsPreparedData PreparedTts { get; set; }

	public bool IsInPlayerParty { get; set; }

	public bool IsWithPlayer { get; set; }

	public bool IsPlayerKnown { get; set; }

	public PlayerInfo PlayerInfo { get; set; } = new PlayerInfo();

	public List<string> ConversationHistory { get; set; } = new List<string>();

	public string WarStatus { get; set; }

	public PlayerRelation PlayerRelation { get; set; }

	public string CurrentTask { get; set; }

	public List<CampaignEvent> RecentEvents { get; set; } = new List<CampaignEvent>();

	[JsonProperty("DialogueAnalysisEvents")]
	public List<CampaignEvent> DialogueAnalysisEvents { get; set; } = new List<CampaignEvent>();

	public EmotionalState EmotionalState { get; set; }

	public string LocationType { get; set; }

	public TimeContext TimeContext { get; set; }

	public PlayerForces PlayerForces { get; set; }

	public NPCForces NPCForces { get; set; }

	public List<string> Quirks { get; set; } = new List<string>();

	public float TrustLevel { get; set; }

	public int InteractionCount { get; set; }

	public string InformationAccessLevel { get; set; }

	public float LiePenaltySum { get; set; }

	public int? NegativeToneCount { get; set; }

	public string EscalationState { get; set; } = "neutral";

	public string CombatResponse { get; set; }

	public bool IsSurrendering { get; set; }

	public bool IsPlayerSurrendering { get; set; }

	public string MarriageResponse { get; set; }

	public string PendingDeath { get; set; }

	public string PendingSettlementCombat { get; set; }

	public string SettlementCombatResponse { get; set; }

	[JsonProperty("RoleplayDeathReason")]
	public string DeathReason { get; set; }

	[JsonProperty("KillerStringId")]
	public string KillerStringId { get; set; }

	public string LastDynamicResponse { get; set; }

	public AIResponse PendingAIResponse { get; set; }

	/// <summary>Technical action string captured before processing (for chat UI pills).</summary>
	public string LastTechnicalActionForDisplay { get; set; }

	public PendingRelationChange PendingRelationChange { get; set; }

	public PendingRelationChange PendingLiePenalty { get; set; }

	public PendingWorkshopSale PendingWorkshopSale { get; set; }

	public MoneyTransferInfo PendingMoneyTransfer { get; set; }

	public List<ItemTransferData> PendingItemTransfers { get; set; }

	public bool PendingIntimacyNotification { get; set; }

	public string PendingConceptionMotherName { get; set; }

	public string CharacterDescription { get; set; } = "";

	[JsonProperty("AIGeneratedPersonality")]
	public string AIGeneratedPersonality { get; set; } = null;

	[JsonProperty("AIGeneratedBackstory")]
	public string AIGeneratedBackstory { get; set; } = null;

	[JsonProperty("AIGeneratedSpeechQuirks")]
	public string AIGeneratedSpeechQuirks { get; set; } = null;

	[JsonProperty("KnownSecrets")]
	public List<string> KnownSecrets { get; set; } = new List<string>();

	[JsonProperty("KnownInfo")]
	public List<string> KnownInfo { get; set; } = new List<string>();

	[JsonProperty("ClanTierRecognitionChecked")]
	public bool ClanTierRecognitionChecked { get; set; } = false;

	[JsonProperty("KnowledgeGenerated")]
	public bool KnowledgeGenerated { get; set; } = false;

	[JsonProperty("RomanceLevel")]
	public float RomanceLevel { get; set; } = 0f;

	[JsonProperty("LastRomanceInteractionDays")]
	public int LastRomanceInteractionDays { get; set; } = -1;

	[JsonProperty("LastIntimateInteractionDays")]
	public int LastIntimateInteractionDays { get; set; } = -1;

	[JsonProperty("IsRomanceEligible")]
	public bool IsRomanceEligible { get; set; } = true;

	[JsonProperty("SettlementCombatInfo")]
	public SettlementCombatInfo SettlementCombatInfo { get; set; }

	[JsonProperty("DynamicEvents")]
	public List<string> DynamicEvents { get; set; } = new List<string>();

	[JsonProperty("IsSick")]
	public bool IsSick { get; set; } = false;

	[JsonProperty("CurrentDiseases")]
	public List<NPCDiseaseInfo> CurrentDiseases { get; set; } = new List<NPCDiseaseInfo>();

	[JsonProperty("DiseaseProgress")]
	public float DiseaseProgress { get; set; } = 0f;

	[JsonProperty("IsTreated")]
	public bool IsTreated { get; set; } = false;

	[JsonProperty("LastEventAnalysisMessageIndex")]
	public int LastEventAnalysisMessageIndex { get; set; } = -1;

	[JsonProperty("ProcessedMessageHashes")]
	public HashSet<string> ProcessedMessageHashes { get; set; } = new HashSet<string>();

	[JsonProperty("LastSeenFriends")]
	public Dictionary<string, float> LastSeenFriends { get; set; } = new Dictionary<string, float>();

	[JsonProperty("IsNPCInitiatedConversation")]
	public bool IsNPCInitiatedConversation { get; set; } = false;

	[JsonProperty("IsHostileInitiative")]
	public bool IsHostileInitiative { get; set; } = false;

	[JsonProperty("AllowsLettersFromNPC")]
	public bool AllowsLettersFromNPC { get; set; } = false;

	[JsonProperty("AdditionalContext")]
	public string AdditionalContext { get; set; } = "";

	[JsonProperty("ActiveAIQuests")]
	public List<AIQuestInfo> ActiveAIQuests { get; set; } = new List<AIQuestInfo>();

	[JsonProperty("IncomingAIQuests")]
	public List<AIQuestInfo> IncomingAIQuests { get; set; } = new List<AIQuestInfo>();

	[JsonProperty("CompletedQuestHistory")]
	public List<AIQuestHistoryEntry> CompletedQuestHistory { get; set; } = new List<AIQuestHistoryEntry>();

	[JsonProperty("LastInteractionTimeDays")]
	public double LastInteractionTimeDays { get; set; } = -1.0;

	[JsonIgnore]
	public Hero Hero { get; set; }

	[JsonProperty("VisitedSettlements")]
	public List<SettlementVisit> VisitedSettlements { get; set; } = new List<SettlementVisit>();

	[JsonProperty("LastAIResponseJson")]
	public string LastAIResponseJson { get; set; } = null;

	[JsonIgnore]
	public CampaignTime LastInteractionTime
	{
		get
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			return (LastInteractionTimeDays < 0.0) ? CampaignTime.Never : CampaignTime.Days((float)LastInteractionTimeDays);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			LastInteractionTimeDays = ((value == CampaignTime.Never) ? (-1.0) : (value).ToDays);
		}
	}

	public void AddMessage(string message)
	{
		ConversationHistory.Add(message);
	}

	/// <summary>Appends action pill text to a message for persistence. Format: "msg\n---\naction".</summary>
	public void AppendActionToMessage(int index, string actionText)
	{
		if (ConversationHistory == null || index < 0 || index >= ConversationHistory.Count || string.IsNullOrEmpty(actionText))
			return;
		if (ConversationHistory[index].Contains("\n---\n"))
			return; // already has an action suffix; do not append again
		ConversationHistory[index] = ConversationHistory[index] + "\n---\n" + actionText;
	}

	/// <summary>Appends relation pill text to a message for persistence. Format: "msg[\n---\naction]\n===\nrelation".</summary>
	public void AppendRelationToMessage(int index, string relationText)
	{
		if (ConversationHistory == null || index < 0 || index >= ConversationHistory.Count || string.IsNullOrEmpty(relationText))
			return;
		if (ConversationHistory[index].Contains("\n===\n"))
			return; // already has a relation suffix; do not append again
		ConversationHistory[index] = ConversationHistory[index] + "\n===\n" + relationText;
	}

	public string GetFormattedHistory()
	{
		return ConversationHistory.Any() ? string.Join("\n", ConversationHistory) : "No conversation history.";
	}

	public void AddDynamicEvent(string eventId)
	{
		if (DynamicEvents == null)
		{
			DynamicEvents = new List<string>();
		}
		if (!DynamicEvents.Contains(eventId))
		{
			DynamicEvents.Add(eventId);
		}
	}

	public void RemoveExpiredEvents(List<string> expiredEventIds)
	{
		if (DynamicEvents != null && expiredEventIds != null)
		{
			DynamicEvents.RemoveAll((string id) => expiredEventIds.Contains(id));
		}
	}

	public bool HasKnowledgeOf(string eventId)
	{
		return DynamicEvents != null && DynamicEvents.Contains(eventId);
	}

	public List<string> GetNewMessagesForEventAnalysis()
	{
		if (ConversationHistory == null || ConversationHistory.Count == 0)
		{
			return new List<string>();
		}
		if (ProcessedMessageHashes == null)
		{
			ProcessedMessageHashes = new HashSet<string>();
		}
		List<string> list = new List<string>();
		int num = LastEventAnalysisMessageIndex + 1;
		if (num < ConversationHistory.Count)
		{
			List<string> list2 = ConversationHistory.Skip(num).ToList();
			foreach (string item3 in list2)
			{
				string item = ComputeMessageHash(item3);
				if (!ProcessedMessageHashes.Contains(item))
				{
					list.Add(StripPillSuffix(item3));
				}
			}
		}
		else
		{
			foreach (string item4 in ConversationHistory)
			{
				string item2 = ComputeMessageHash(item4);
				if (!ProcessedMessageHashes.Contains(item2))
				{
					list.Add(StripPillSuffix(item4));
				}
			}
		}
		return list;
	}

	private static string StripPillSuffix(string message)
	{
		if (string.IsNullOrEmpty(message)) return message;
		int idx = message.IndexOf("\n---\n", StringComparison.Ordinal);
		if (idx < 0) idx = message.IndexOf("\n===\n", StringComparison.Ordinal);
		return idx >= 0 ? message.Substring(0, idx) : message;
	}

	private string ComputeMessageHash(string message)
	{
		if (string.IsNullOrEmpty(message))
		{
			return string.Empty;
		}
		string canonical = StripPillSuffix(message);
		using SHA256 sHA = SHA256.Create();
		byte[] inArray = sHA.ComputeHash(Encoding.UTF8.GetBytes(canonical));
		return Convert.ToBase64String(inArray);
	}

	public void MarkMessagesAsSentToEventAnalysis()
	{
		if (ConversationHistory == null || ConversationHistory.Count <= 0)
		{
			return;
		}
		if (ProcessedMessageHashes == null)
		{
			ProcessedMessageHashes = new HashSet<string>();
		}
		LastEventAnalysisMessageIndex = ConversationHistory.Count - 1;
		foreach (string item2 in ConversationHistory)
		{
			string item = ComputeMessageHash(item2);
			ProcessedMessageHashes.Add(item);
		}
	}
}
