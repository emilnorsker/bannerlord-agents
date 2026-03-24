using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.DeathHistory;

public static class DeathHistoryPromptGenerator
{
	public static string GenerateDeathHistoryPrompt(Hero hero, AIInfluenceBehavior behavior)
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Invalid comparison between Unknown and I4
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		bool flag = hero == Hero.MainHero;
		StringBuilder stringBuilder = new StringBuilder();
		NPCContext nPCContext = null;
		if (!flag)
		{
			nPCContext = behavior.GetNPCContextByStringId(((MBObjectBase)hero).StringId);
		}
		stringBuilder.AppendLine("TASK: Write a comprehensive life history and obituary for the following character who has just passed away.");
		stringBuilder.AppendLine("Style: Historical, respectful, yet honest. Highlight their achievements, personality, and impact on the world.");
		stringBuilder.AppendLine("Length: The history must be between 3000 and 8000 characters. Ensure the narrative is detailed and comprehensive.");
		string language = BannerlordConfig.Language;
		stringBuilder.AppendLine("Language: " + language + " (output MUST be in " + language + ").");
		if (flag)
		{
			stringBuilder.AppendLine("IMPORTANT: This was the PLAYER character. Focus on their journey, their rise to power, and their interactions with the world.");
		}
		else
		{
			stringBuilder.AppendLine("IMPORTANT: This was an NPC who interacted significantly with the player.");
		}
		stringBuilder.AppendLine("\n=== 1. BASIC INFO ===");
		stringBuilder.AppendLine($"Name: {hero.Name}");
		stringBuilder.AppendLine($"Age: {hero.Age:F0}");
		CampaignTime validBirthDay = GetValidBirthDay(hero);
		string text = FormatCampaignDate(validBirthDay);
		stringBuilder.AppendLine("Born: " + text);
		CampaignTime validDeathDay = GetValidDeathDay(hero);
		string text2 = FormatCampaignDate(validDeathDay);
		stringBuilder.AppendLine("Died: " + text2);
		string text3 = null;
		string text4 = null;
		if (nPCContext != null && !string.IsNullOrEmpty(nPCContext.DeathReason))
		{
			text3 = nPCContext.DeathReason;
		}
		else if ((int)hero.DeathMark > 0)
		{
			text3 = ((object)hero.DeathMark/*cast due to .constrained prefix*/).ToString();
			if (hero.DeathMarkKillerHero != null)
			{
				text4 = ((object)hero.DeathMarkKillerHero.Name).ToString();
			}
		}
		if (!string.IsNullOrEmpty(text3))
		{
			stringBuilder.AppendLine("Cause of Death: " + text3);
			if (!string.IsNullOrEmpty(text4))
			{
				stringBuilder.AppendLine("Killed by: " + text4);
			}
		}
		stringBuilder.AppendLine("\n=== 2. PERSONALITY ===");
		stringBuilder.AppendLine("Personality Traits: " + PromptGenerator.GetPersonalityDescription(hero));
		stringBuilder.AppendLine("Skills & Mastery: " + PromptGenerator.GetSkillNarrative(hero));
		if (nPCContext != null && !string.IsNullOrEmpty(nPCContext.AIGeneratedSpeechQuirks))
		{
			stringBuilder.AppendLine("Speech Quirks: " + nPCContext.AIGeneratedSpeechQuirks);
		}
		else if (nPCContext != null && nPCContext.Quirks != null && nPCContext.Quirks.Any())
		{
			stringBuilder.AppendLine("Speech Quirks: " + string.Join(", ", nPCContext.Quirks));
		}
		if (nPCContext != null && !string.IsNullOrEmpty(nPCContext.CharacterDescription))
		{
			stringBuilder.AppendLine("Description: " + nPCContext.CharacterDescription);
		}
		stringBuilder.AppendLine("\n=== 3. FAMILY & RELATIONS ===");
		stringBuilder.AppendLine("Family: " + PromptGenerator.GetRelativesInfo(hero));
		stringBuilder.AppendLine(PromptGenerator.GetRelationsInfo(hero));
		if (!flag)
		{
			stringBuilder.AppendLine($"Final Relation with Player: {hero.GetRelation(Hero.MainHero)}");
			if (nPCContext != null)
			{
				stringBuilder.AppendLine($"Trust Level: {nPCContext.TrustLevel:F2}");
				stringBuilder.AppendLine($"Romance Level: {nPCContext.RomanceLevel:F0}");
				if (nPCContext.LastInteractionTimeDays > 0.0)
				{
					stringBuilder.AppendLine($"Days since last interaction: {nPCContext.LastInteractionTimeDays:F0}");
				}
			}
			if (hero.LastMeetingTimeWithPlayer != CampaignTime.Zero)
			{
				stringBuilder.AppendLine($"Last meeting with player: {hero.LastMeetingTimeWithPlayer}");
			}
		}
		if (nPCContext != null)
		{
			if (nPCContext.KnownSecrets != null && nPCContext.KnownSecrets.Any())
			{
				stringBuilder.AppendLine("\nKnown Secrets: " + string.Join(", ", nPCContext.KnownSecrets));
			}
			if (nPCContext.KnownInfo != null && nPCContext.KnownInfo.Any())
			{
				stringBuilder.AppendLine("Known Information: " + string.Join("; ", nPCContext.KnownInfo));
			}
		}
		stringBuilder.AppendLine("\n=== 4. CAREER ===");
		stringBuilder.AppendLine("Clan Status: " + PromptGenerator.GetHeroClanStatus(hero));
		stringBuilder.AppendLine("Clan Info: " + PromptGenerator.GetClanInfo(hero));
		stringBuilder.AppendLine("Kingdom: " + PromptGenerator.GetKingdomDescription(hero));
		stringBuilder.AppendLine("Holdings (Historical): " + GetHoldingsInfo(hero));
		stringBuilder.AppendLine("Workshops (Historical): " + GetWorkshopsInfo(hero));
		stringBuilder.AppendLine("\n=== 5. LIFE EVENTS ===");
		AppendLifeEvents(stringBuilder, hero);
		stringBuilder.AppendLine("\n=== 6. INTERACTIONS ===");
		if (flag)
		{
			AppendPlayerInteractionHistory(stringBuilder, behavior);
		}
		else if (nPCContext != null)
		{
			stringBuilder.AppendLine($"Total Interactions: {nPCContext.InteractionCount}");
			if (nPCContext.ConversationHistory != null && nPCContext.ConversationHistory.Any())
			{
				stringBuilder.AppendLine("\n--- Dialogue History (Chronological) ---");
				List<string> conversationHistory = nPCContext.ConversationHistory;
				int count = conversationHistory.Count;
				int num = Math.Min(count, 200);
				int count2 = count - num;
				foreach (string item in conversationHistory.Skip(count2))
				{
					stringBuilder.AppendLine(item);
				}
			}
		}
		return stringBuilder.ToString();
	}

	private static void AppendLifeEvents(StringBuilder prompt, Hero hero)
	{
		LogEntryHistory logEntryHistory = Campaign.Current.LogEntryHistory;
		IEnumerable<CharacterKilledLogEntry> enumerable = (from log in logEntryHistory.GetGameActionLogs<CharacterKilledLogEntry>((Func<CharacterKilledLogEntry, bool>)((CharacterKilledLogEntry log) => log.Victim == hero || log.Killer == hero))
			orderby ((LogEntry)log).GameTime descending
			select log).Take(5);
		foreach (CharacterKilledLogEntry item in enumerable)
		{
			prompt.AppendLine($"- Death Event: {item}");
		}
		IEnumerable<CharacterMarriedLogEntry> enumerable2 = (from log in logEntryHistory.GetGameActionLogs<CharacterMarriedLogEntry>((Func<CharacterMarriedLogEntry, bool>)((CharacterMarriedLogEntry log) => log.MarriedHero == hero || log.MarriedTo == hero))
			orderby ((LogEntry)log).GameTime descending
			select log).Take(5);
		foreach (CharacterMarriedLogEntry item2 in enumerable2)
		{
			prompt.AppendLine($"- Marriage: {item2}");
		}
		IEnumerable<PlayerBattleEndedLogEntry> enumerable3 = (from log in logEntryHistory.GetGameActionLogs<PlayerBattleEndedLogEntry>((Func<PlayerBattleEndedLogEntry, bool>)((PlayerBattleEndedLogEntry log) => true))
			orderby ((LogEntry)log).GameTime descending
			select log).Take(5);
		foreach (PlayerBattleEndedLogEntry item3 in enumerable3)
		{
			prompt.AppendLine($"- Battle: {item3}");
		}
		IEnumerable<TakePrisonerLogEntry> enumerable4 = (from log in logEntryHistory.GetGameActionLogs<TakePrisonerLogEntry>((Func<TakePrisonerLogEntry, bool>)((TakePrisonerLogEntry log) => log.Prisoner == hero || log.CapturerHero == hero))
			orderby ((LogEntry)log).GameTime descending
			select log).Take(5);
		foreach (TakePrisonerLogEntry item4 in enumerable4)
		{
			prompt.AppendLine($"- Imprisonment: {item4}");
		}
		IEnumerable<EndCaptivityLogEntry> enumerable5 = (from log in logEntryHistory.GetGameActionLogs<EndCaptivityLogEntry>((Func<EndCaptivityLogEntry, bool>)((EndCaptivityLogEntry log) => log.Prisoner == hero))
			orderby ((LogEntry)log).GameTime descending
			select log).Take(5);
		foreach (EndCaptivityLogEntry item5 in enumerable5)
		{
			prompt.AppendLine($"- Released from captivity: {item5}");
		}
		IEnumerable<TournamentWonLogEntry> enumerable6 = (from log in logEntryHistory.GetGameActionLogs<TournamentWonLogEntry>((Func<TournamentWonLogEntry, bool>)((TournamentWonLogEntry log) => log.Winner == hero))
			orderby ((LogEntry)log).GameTime descending
			select log).Take(5);
		foreach (TournamentWonLogEntry item6 in enumerable6)
		{
			prompt.AppendLine($"- Tournament Victory: {item6}");
		}
	}

	private static void AppendPlayerInteractionHistory(StringBuilder prompt, AIInfluenceBehavior behavior)
	{
		Dictionary<string, NPCContext> nPCContexts = behavior.GetNPCContexts();
		if (nPCContexts == null)
		{
			return;
		}
		List<KeyValuePair<string, NPCContext>> list = nPCContexts.OrderByDescending((KeyValuePair<string, NPCContext> kvp) => kvp.Value.InteractionCount).ToList();
		foreach (KeyValuePair<string, NPCContext> item in list)
		{
			NPCContext value = item.Value;
			if (value.ConversationHistory == null || !value.ConversationHistory.Any() || value.InteractionCount < 5)
			{
				continue;
			}
			List<string> conversationHistory = value.ConversationHistory;
			int num = conversationHistory.FindIndex((string msg) => msg?.StartsWith("Player: ") ?? false);
			if (num < 0)
			{
				continue;
			}
			string npcId = item.Key;
			Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == npcId));
			string text = ((val != null) ? ((object)val.Name).ToString() : npcId);
			List<string> list2 = conversationHistory.Skip(num).ToList();
			int num2 = Math.Min(list2.Count, 200);
			int count = list2.Count - num2;
			prompt.AppendLine("\n--- Dialogue with " + text + " ---");
			foreach (string item2 in list2.Skip(count))
			{
				prompt.AppendLine(item2);
			}
		}
	}

	private static string GetHoldingsInfo(Hero npc)
	{
		if (((npc != null) ? npc.Clan : null) == null)
		{
			return "none";
		}
		List<string> list = new List<string>();
		foreach (Settlement item in (List<Settlement>)(object)npc.Clan.Settlements)
		{
			if (item.IsTown)
			{
				list.Add($"{item.Name} (Town)");
			}
			else if (item.IsCastle)
			{
				list.Add($"{item.Name} (Castle)");
			}
			else if (item.IsVillage)
			{
				list.Add($"{item.Name} (Village)");
			}
		}
		return list.Any() ? string.Join(", ", list) : "none";
	}

	private static string GetWorkshopsInfo(Hero npc)
	{
		if (((npc != null) ? npc.OwnedWorkshops : null) == null || !((IEnumerable<Workshop>)npc.OwnedWorkshops).Any())
		{
			return "none";
		}
		List<string> list = new List<string>();
		foreach (Workshop item in (List<Workshop>)(object)npc.OwnedWorkshops)
		{
			if (item != null && item.WorkshopType != null)
			{
				TextObject name = item.WorkshopType.Name;
				Settlement settlement = ((SettlementArea)item).Settlement;
				list.Add($"{name} in {((settlement != null) ? settlement.Name : null)}");
			}
		}
		return list.Any() ? string.Join(", ", list) : "none";
	}

	private static CampaignTime GetValidBirthDay(Hero hero)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null)
		{
			return CampaignTime.Zero;
		}
		if (hero.BirthDay != CampaignTime.Zero && IsValidCampaignTime(hero.BirthDay))
		{
			return hero.BirthDay;
		}
		try
		{
			CampaignTime now = CampaignTime.Now;
			CampaignTime val = CampaignTime.Years(hero.Age);
			CampaignTime val2 = now - val;
			if (IsValidCampaignTime(val2))
			{
				return val2;
			}
		}
		catch (Exception)
		{
		}
		return CampaignTime.Zero;
	}

	private static CampaignTime GetValidDeathDay(Hero hero)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null)
		{
			return CampaignTime.Zero;
		}
		if (hero.IsDead && hero.DeathDay != CampaignTime.Zero && IsValidCampaignTime(hero.DeathDay))
		{
			return hero.DeathDay;
		}
		if (hero.IsDead)
		{
			return CampaignTime.Now;
		}
		return CampaignTime.Zero;
	}

	private static bool IsValidCampaignTime(CampaignTime campaignTime)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (campaignTime == CampaignTime.Zero || campaignTime == CampaignTime.Never)
		{
			return false;
		}
		try
		{
			int getYear = (campaignTime).GetYear;
			if (getYear < 0 || getYear > 2000)
			{
				return false;
			}
			double toDays = (campaignTime).ToDays;
			if (toDays < 0.0 || toDays > 1000000.0)
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static string FormatCampaignDate(CampaignTime campaignTime)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected I4, but got Unknown
		if (campaignTime == CampaignTime.Zero || campaignTime == CampaignTime.Never)
		{
			return "unknown";
		}
		if (!IsValidCampaignTime(campaignTime))
		{
			return "unknown";
		}
		try
		{
			int getYear = (campaignTime).GetYear;
			int num = (int)(campaignTime).GetSeasonOfYear;
			if (num < 0 || num > 3)
			{
				return $"Year {getYear}";
			}
			string seasonName = GetSeasonName(num);
			return $"Year {getYear}, {seasonName}";
		}
		catch (Exception)
		{
			try
			{
				int getYear2 = (campaignTime).GetYear;
				if (getYear2 >= 0 && getYear2 <= 2000)
				{
					return $"Year {getYear2}";
				}
			}
			catch
			{
			}
			return "unknown";
		}
	}

	private static string GetSeasonName(int season)
	{
		return season switch
		{
			0 => "Spring", 
			1 => "Summer", 
			2 => "Autumn", 
			3 => "Winter", 
			_ => "Unknown", 
		};
	}
}
