using System.Collections.Generic;
using AIInfluence;
using TaleWorlds.CampaignSystem;

namespace AIInfluence.DynamicEvents;

/// <summary>
/// Single entry point for UI and tools that need the merged dynamic-event registry
/// (unified <c>dynamic_events.json</c> catalog). Prefer this over ad hoc file reads.
/// All <c>GetEventsKnownToNpc*</c> methods require the <strong>canonical</strong> <see cref="NPCContext"/>
/// from <see cref="AIInfluenceBehavior.GetOrCreateNPCContext"/> (same reference as the behavior dictionary).
/// </summary>
public static class WorldEventsReadFacade
{
	public static List<DynamicEvent> GetActiveEventsMerged()
	{
		return DynamicEventsManager.Instance?.GetActiveEvents() ?? new List<DynamicEvent>();
	}

	/// <summary>Same as <see cref="DynamicEventsManager.GetEventsForNPC"/> with <c>persistKnowledgeSync: false</c> (typical for UI).</summary>
	public static List<DynamicEvent> GetEventsKnownToNpcForUi(Hero npc, NPCContext context)
	{
		return DynamicEventsManager.Instance?.GetEventsForNPC(npc, context, persistKnowledgeSync: false) ?? new List<DynamicEvent>();
	}

	/// <summary>When knowledge changes must be written through <see cref="AIInfluenceBehavior.SaveNPCContext"/> (e.g. prompt build).</summary>
	public static List<DynamicEvent> GetEventsKnownToNpcPersisting(Hero npc, NPCContext context)
	{
		return DynamicEventsManager.Instance?.GetEventsForNPC(npc, context, persistKnowledgeSync: true) ?? new List<DynamicEvent>();
	}
}
