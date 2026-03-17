using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class QuestActionData
{
	[JsonProperty("action")]
	public string Action { get; set; }

	[JsonProperty("title")]
	public string Title { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("reward_gold")]
	public int RewardGold { get; set; }

	[JsonProperty("duration_days")]
	public int DurationDays { get; set; }

	[JsonProperty("quest_id")]
	public string QuestId { get; set; }

	[JsonProperty("target_npc_ids")]
	public List<string> TargetNpcIds { get; set; }

	[JsonProperty("target_npc_id")]
	public string TargetNpcId { get; set; }

	[JsonProperty("ai_verification_notes")]
	public string AIVerificationNotes { get; set; }

	[JsonProperty("completer_npc_id")]
	public string CompleterNpcId { get; set; }

	[JsonProperty("update_log")]
	public string UpdateLog { get; set; }

	[JsonProperty("set_progress")]
	public int? SetProgress { get; set; }

	[JsonProperty("completion_reason")]
	public string CompletionReason { get; set; }

	[JsonProperty("progress_target")]
	public int? ProgressTarget { get; set; }

	[JsonProperty("progress_label")]
	public string ProgressLabel { get; set; }

	[JsonProperty("reward_items")]
	public List<QuestItemReward> RewardItems { get; set; }

	[JsonProperty("reward_skill")]
	public string RewardSkill { get; set; }

	[JsonProperty("reward_skill_xp")]
	public int RewardSkillXp { get; set; }

	[JsonProperty("crime_rating_change")]
	public int? CrimeRatingChange { get; set; }

	[JsonProperty("influence_change")]
	public int? InfluenceChange { get; set; }

	[JsonProperty("spawn_hostile_party")]
	public bool SpawnHostileParty { get; set; }

	[JsonProperty("hostile_party_size")]
	public int HostilePartySize { get; set; }

	[JsonProperty("hostile_party_label")]
	public string HostilePartyLabel { get; set; }

	[JsonProperty("hostile_troop_name")]
	public string HostileTroopName { get; set; }

	[JsonProperty("spawn_npc")]
	public SpawnNpcData SpawnNpc { get; set; }

	public List<string> GetEffectiveTargetNpcIds()
	{
		if (TargetNpcIds != null && TargetNpcIds.Count > 0)
		{
			return TargetNpcIds;
		}
		if (!string.IsNullOrEmpty(TargetNpcId))
		{
			return new List<string> { TargetNpcId };
		}
		return new List<string>();
	}
}
