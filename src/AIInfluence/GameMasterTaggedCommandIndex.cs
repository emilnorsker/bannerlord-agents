using System.Text;

namespace AIInfluence;

/// <summary>Slice 12: compact machine-readable index (subset of BLGM surface; expand with wiki export later).</summary>
public static class GameMasterTaggedCommandIndex
{
	public static string BuildPromptAppendix()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine("BLGM command families (tags: scope|risk):");
		sb.AppendLine("- gm.query.* : read-only lookup heroes/clans/kingdoms/settlements/items/troops (scope:world|risk:low)");
		sb.AppendLine("- gm.hero.* : hero edits (scope:hero|risk:high)");
		sb.AppendLine("- gm.clan.* : clan edits (scope:clan|risk:high)");
		sb.AppendLine("- gm.kingdom.* : kingdom policy/wars/diplomacy (scope:kingdom|risk:high, often ruler-only)");
		sb.AppendLine("- gm.settlement.* : settlement edits (scope:settlement|risk:high)");
		sb.AppendLine("- gm.item.* : item spawn/edit (scope:item|risk:high)");
		sb.AppendLine("- gm.troop.* : party/troop mass ops (scope:party|risk:very_high)");
		sb.AppendLine("- gm.caravan.* / gm.bandit.* : world spawns (scope:world|risk:very_high)");
		sb.AppendLine("Rule: prefer gm.query.* to resolve string_ids before any mutate.");
		return sb.ToString();
	}
}
