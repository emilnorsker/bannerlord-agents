using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AIInfluence;

public class SettlementOwnershipHistory
{
	[JsonProperty("SettlementId")]
	public string SettlementId { get; set; }

	[JsonProperty("SettlementName")]
	public string SettlementName { get; set; }

	[JsonProperty("OriginalOwnerKingdomId")]
	public string OriginalOwnerKingdomId { get; set; }

	[JsonProperty("OriginalOwnerKingdomName")]
	public string OriginalOwnerKingdomName { get; set; }

	[JsonProperty("CurrentOwnerKingdomId")]
	public string CurrentOwnerKingdomId { get; set; }

	[JsonProperty("CurrentOwnerKingdomName")]
	public string CurrentOwnerKingdomName { get; set; }

	[JsonProperty("OwnershipChanges")]
	public List<OwnershipChange> OwnershipChanges { get; set; } = new List<OwnershipChange>();

	public string GetOwnershipDescription()
	{
		if (OriginalOwnerKingdomId == CurrentOwnerKingdomId)
		{
			return "Historical " + OriginalOwnerKingdomName + " settlement";
		}
		string text = "Was " + OriginalOwnerKingdomName;
		if (OwnershipChanges.Count == 1)
		{
			OwnershipChange ownershipChange = OwnershipChanges[0];
			text = text + ", became " + ownershipChange.ToKingdomName;
		}
		else if (OwnershipChanges.Count > 1)
		{
			OwnershipChange ownershipChange2 = OwnershipChanges.Last();
			text = text + ", became " + ownershipChange2.ToKingdomName;
			if (OwnershipChanges.Count > 2)
			{
				for (int i = 0; i < OwnershipChanges.Count - 1; i++)
				{
					text = text + ", then " + OwnershipChanges[i].ToKingdomName;
				}
			}
		}
		return text;
	}
}
