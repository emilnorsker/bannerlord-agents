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
			string n = name.Trim().ToLowerInvariant();
			Settlement s = Settlement.All?.FirstOrDefault(x => !x.IsHideout && x.Name != null && string.Equals(x.Name.ToString(), name, StringComparison.OrdinalIgnoreCase));
			if (s != null) return s;
			s = Settlement.All?.FirstOrDefault(x => !x.IsHideout && x.Name != null && x.Name.ToString().ToLowerInvariant().Contains(n));
			if (s != null) return s;
			s = Settlement.All?.FirstOrDefault(x => !x.IsHideout && x.StringId != null && x.StringId.ToLowerInvariant().Contains(n));
			if (s != null) return s;
		}
		return Settlement.All?.Where(x => x.IsTown).OrderBy(x => x.GetPosition2D.Distance(fallbackPos)).FirstOrDefault();
	}
}
