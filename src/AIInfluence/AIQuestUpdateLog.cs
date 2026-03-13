using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class AIQuestUpdateLog
{
	[JsonProperty("npc_id")]
	public string NpcId { get; set; }

	[JsonProperty("npc_name")]
	public string NpcName { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }

	[JsonProperty("day")]
	public double Day { get; set; }

	[JsonProperty("progress_set_to")]
	public int? ProgressSetTo { get; set; }
}
