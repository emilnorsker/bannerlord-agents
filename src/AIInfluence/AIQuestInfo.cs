using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

[JsonSerializable]
public class AIQuestInfo
{
	[JsonProperty("quest_id")]
	public string QuestId { get; set; }

	[JsonProperty("title")]
	public string Title { get; set; }

	[JsonProperty("description")]
	public string Description { get; set; }

	[JsonProperty("reward_gold")]
	public int RewardGold { get; set; }

	[JsonProperty("created_days")]
	public double CreatedDays { get; set; }

	[JsonProperty("duration_days")]
	public int DurationDays { get; set; }

	[JsonProperty("quest_giver_npc_id")]
	public string QuestGiverNpcId { get; set; }

	[JsonProperty("target_npc_id")]
	public string TargetNpcId { get; set; }

	[JsonProperty("target_npc_ids")]
	public List<string> TargetNpcIds { get; set; } = new List<string>();

	[JsonProperty("ai_verification_notes")]
	public string AIVerificationNotes { get; set; }

	[JsonProperty("completer_npc_id")]
	public string CompleterNpcId { get; set; }

	[JsonProperty("progress_current")]
	public int ProgressCurrent { get; set; }

	[JsonProperty("progress_target")]
	public int ProgressTarget { get; set; }

	[JsonProperty("progress_label")]
	public string ProgressLabel { get; set; }

	[JsonProperty("update_logs")]
	public List<AIQuestUpdateLog> UpdateLogs { get; set; } = new List<AIQuestUpdateLog>();

	[JsonProperty("reward_items")]
	public List<QuestItemReward> RewardItems { get; set; } = new List<QuestItemReward>();

	[JsonProperty("reward_skill")]
	public string RewardSkill { get; set; }

	[JsonProperty("reward_skill_xp")]
	public int RewardSkillXp { get; set; }

	[JsonProperty("crime_rating_change")]
	public int? CrimeRatingChange { get; set; }

	[JsonProperty("influence_change")]
	public int? InfluenceChange { get; set; }

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
