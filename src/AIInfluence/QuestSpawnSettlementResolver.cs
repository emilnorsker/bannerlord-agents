using System;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace AIInfluence;

public static class QuestSpawnSettlementResolver
{
	public static Settlement Resolve(string name, Vec2 fallbackPos)
	{
		if (!string.IsNullOrWhiteSpace(name))
		{
			string normalizedName = name.Trim().ToLowerInvariant();
			Settlement matchedSettlement = Settlement.All?.FirstOrDefault(candidate => !candidate.IsHideout && candidate.Name != null && string.Equals(candidate.Name.ToString(), name, StringComparison.OrdinalIgnoreCase));
			if (matchedSettlement != null) return matchedSettlement;
			matchedSettlement = Settlement.All?.FirstOrDefault(candidate => !candidate.IsHideout && candidate.Name != null && candidate.Name.ToString().ToLowerInvariant().Contains(normalizedName));
			if (matchedSettlement != null) return matchedSettlement;
			matchedSettlement = Settlement.All?.FirstOrDefault(candidate => !candidate.IsHideout && candidate.StringId != null && candidate.StringId.ToLowerInvariant().Contains(normalizedName));
			if (matchedSettlement != null) return matchedSettlement;
		}
		return Settlement.All?.Where(candidateTown => candidateTown.IsTown).OrderBy(candidateTown => candidateTown.GetPosition2D.Distance(fallbackPos)).FirstOrDefault();
	}
}
