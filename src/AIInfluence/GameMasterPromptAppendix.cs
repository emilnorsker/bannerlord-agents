using System;
using System.Text;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

/// <summary>Optional prompt text for paths that may emit <c>blgm_plan</c> (slices 9–10).</summary>
public static class GameMasterPromptAppendix
{
	public static string NpcChatBlgmInstructions(Hero npc, NPCContext context)
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine();
		sb.AppendLine("### OPTIONAL Bannerlord.GameMaster automation (OpenRouter only) ###");
		sb.AppendLine("You may add a JSON field \"blgm_plan\" alongside the normal dialogue fields:");
		sb.AppendLine("{\"gm_command\":\"gm.query.kingdom\",\"args\":[],\"intent\":\"query\",\"probe_help_first\":false,\"story_intent\":\"\"}");
		sb.AppendLine("Use only when a console query/mutation genuinely advances the roleplay. Prefer intent=query. For uncertain arity set probe_help_first=true or intent=probe_help with args [].");
		sb.Append(GameMasterTaggedCommandIndex.BuildPromptAppendix());
		if (npc != null)
		{
			sb.AppendLine("NPC string_id: " + ((MBObjectBase)npc).StringId);
			Clan c = npc.Clan;
			if (c != null)
			{
				sb.AppendLine("NPC clan: " + ((MBObjectBase)c).StringId);
				if (c.Kingdom != null)
				{
					sb.AppendLine("NPC kingdom: " + ((MBObjectBase)c.Kingdom).StringId);
				}
			}
		}
		Hero main = Hero.MainHero;
		if (main?.Clan != null)
		{
			sb.AppendLine("Player clan: " + ((MBObjectBase)main.Clan).StringId);
			if (main.Clan.Kingdom != null)
			{
				Kingdom k = main.Clan.Kingdom;
				sb.AppendLine("Player kingdom: " + ((MBObjectBase)k).StringId + ", player_is_ruler: " + (k.Leader == main));
			}
		}
		ModSettings sNpc = GlobalSettings<ModSettings>.Instance;
		if (sNpc?.GameMasterNpcSocialAppendixEnabled == true && npc != null && Hero.MainHero != null)
		{
			sb.AppendLine("NPC relation with player (API): " + npc.GetRelation(Hero.MainHero));
		}
		if (context != null && !string.IsNullOrEmpty(context.StringId))
		{
			sb.AppendLine("Conversation NPCContext.StringId: " + context.StringId);
			sb.Append(GameMasterObservationStore.FormatInjectionBlock("NpcChat|" + context.StringId));
		}
		return sb.ToString();
	}

	public static string WorldEventsBlgmInstructions(bool queryOnly, string requestType)
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine();
		sb.AppendLine("### OPTIONAL blgm_plan (OpenRouter only) ###");
		sb.AppendLine("You may include \"blgm_plan\": {\"gm_command\":...,\"args\":[...],\"intent\":\"query|mutate|probe_help\",\"probe_help_first\":bool,\"story_intent\":string} in the SAME JSON object as your normal fields.");
		if (queryOnly)
		{
			sb.AppendLine("POLICY: only gm.query.* commands are allowed from this path; omit blgm_plan otherwise.");
		}
		sb.Append(GameMasterTaggedCommandIndex.BuildPromptAppendix());
		if (requestType == "dynamic_event_generation" || requestType == "dynamic_events" || requestType == "kingdom_destruction_event")
		{
			sb.Append(GameMasterObservationStore.FormatInjectionBlock("World|DynamicEvents"));
		}
		else if (requestType == "diplomacy_statement" || requestType == "player_statement_analysis")
		{
			sb.Append(GameMasterObservationStore.FormatInjectionBlock((requestType == "player_statement_analysis") ? "Dip|PlayerAnalysis" : "Dip|Global"));
		}
		return sb.ToString();
	}

	public static string MaybeAppendForBackendRequest(string prompt, string requestType, string backend)
	{
		if (string.IsNullOrEmpty(prompt) || !string.Equals(backend, "OpenRouter", StringComparison.OrdinalIgnoreCase))
		{
			return prompt;
		}
		ModSettings s = GlobalSettings<ModSettings>.Instance;
		if (s == null)
		{
			return prompt;
		}
		if (requestType == "dynamic_event_generation" || requestType == "dynamic_events" || requestType == "kingdom_destruction_event")
		{
			if (!s.GameMasterDynamicEventsBlgmEnabled)
			{
				return prompt;
			}
			return prompt + WorldEventsBlgmInstructions(s.GameMasterWorldEventsBlgmQueryOnly, requestType);
		}
		if (requestType == "diplomacy_statement" || requestType == "player_statement_analysis")
		{
			if (!s.GameMasterDiplomacyBlgmEnabled)
			{
				return prompt;
			}
			return prompt + WorldEventsBlgmInstructions(s.GameMasterDiplomacyBlgmQueryOnly, requestType);
		}
		return prompt;
	}
}
