using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

[JsonSerializable]
public class TimeContext
{
	public string Season { get; set; }

	public int Year { get; set; }

	public int Month { get; set; }

	public string TimeOfDay { get; set; }

	public int Hour { get; set; }

	[JsonIgnore]
	public CampaignTime LastUpdated { get; set; }
}
