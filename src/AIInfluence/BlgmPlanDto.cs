using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence;

/// <summary>Optional structured Bannerlord.GameMaster line emitted by OpenRouter completions (slices 9–14, 16–17).</summary>
[JsonSerializable]
public sealed class BlgmPlanDto
{
	[JsonProperty("gm_command")]
	public string GmCommand { get; set; }

	[JsonProperty("args")]
	public List<string> Args { get; set; }

	/// <summary>query | mutate | probe_help (advisory; host still enforces policy).</summary>
	[JsonProperty("intent")]
	public string Intent { get; set; }

	[JsonProperty("probe_help_first")]
	public bool ProbeHelpFirst { get; set; }

	/// <summary>Why this GM action exists for the story (slice 28).</summary>
	[JsonProperty("story_intent")]
	public string StoryIntent { get; set; }
}
