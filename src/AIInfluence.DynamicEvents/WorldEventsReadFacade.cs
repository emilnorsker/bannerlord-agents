using System.Collections.Generic;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

/// <summary>
/// Single entry point for UI and tools that need the merged dynamic-event registry
/// (primary storage + diplomatic_events.json). Prefer this over duplicating merge logic.
/// </summary>
public static class WorldEventsReadFacade
{
	public static List<DynamicEvent> GetActiveEventsMerged()
	{
		return DynamicEventsManager.Instance?.GetActiveEvents() ?? new List<DynamicEvent>();
	}

	public static List<DynamicEvent> GetEventsKnownToNpc(Hero npc, bool persistKnowledgeSync = true)
	{
		return DynamicEventsManager.Instance?.GetEventsForNPC(npc, persistKnowledgeSync) ?? new List<DynamicEvent>();
	}
}
