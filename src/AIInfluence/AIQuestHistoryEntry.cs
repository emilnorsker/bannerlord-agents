using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class AIQuestHistoryEntry
{
	[JsonProperty("quest_id")]
	public string QuestId { get; set; }

	[JsonProperty("title")]
	public string Title { get; set; }

	[JsonProperty("outcome")]
	public string Outcome { get; set; }

	[JsonProperty("reason")]
	public string Reason { get; set; }

	[JsonProperty("completed_by_npc_id")]
	public string CompletedByNpcId { get; set; }

	[JsonProperty("day")]
	public double Day { get; set; }
}
