using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AIInfluence.Behaviors.AIActions;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using AIInfluence.Diplomacy;
using AIInfluence.DynamicEvents;
using AIInfluence.SettlementCombat;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public static class PromptGenerator
{
	private readonly struct SkillLevelDescriptor
	{
		public string LevelLabel { get; }

		public string LevelAdverb { get; }

		public string ShortText { get; }

		public SkillLevelDescriptor(string levelLabel, string levelAdverb, string shortText)
		{
			LevelLabel = levelLabel;
			LevelAdverb = levelAdverb;
			ShortText = shortText;
		}
	}

	private static Dictionary<string, string> _culturalTraditions;

	private static bool _traditionsLoaded = false;

	private static readonly SkillObject[] SkillPresentationOrder = (SkillObject[])(object)new SkillObject[18]
	{
		DefaultSkills.Leadership,
		DefaultSkills.Tactics,
		DefaultSkills.Charm,
		DefaultSkills.Steward,
		DefaultSkills.Trade,
		DefaultSkills.Roguery,
		DefaultSkills.Medicine,
		DefaultSkills.Engineering,
		DefaultSkills.Crafting,
		DefaultSkills.Scouting,
		DefaultSkills.Riding,
		DefaultSkills.Athletics,
		DefaultSkills.Throwing,
		DefaultSkills.Crossbow,
		DefaultSkills.Bow,
		DefaultSkills.Polearm,
		DefaultSkills.TwoHanded,
		DefaultSkills.OneHanded
	};

	private static void LoadCulturalTraditions()
	{
		if (_traditionsLoaded)
		{
			return;
		}
		_culturalTraditions = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		string text = Path.Combine(fullName, "cultural_traditions.json");
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableDebugLogging)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] LoadCulturalTraditions: assembly path = " + directoryName);
			AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] LoadCulturalTraditions: mod folder = " + fullName);
			AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] LoadCulturalTraditions: traditions path = " + text);
			AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] LoadCulturalTraditions: file exists = {File.Exists(text)}");
		}
		if (File.Exists(text))
		{
			try
			{
				string text2 = File.ReadAllText(text);
				Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(text2);
				if (dictionary != null)
				{
					foreach (KeyValuePair<string, string> item in dictionary)
					{
						_culturalTraditions[item.Key] = item.Value;
					}
					ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
					if (instance2 != null && instance2.EnableDebugLogging)
					{
						AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] LoadCulturalTraditions: Successfully loaded {_culturalTraditions.Count} traditions");
					}
				}
			}
			catch (Exception ex)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to load cultural_traditions.json: " + ex.Message);
			}
		}
		else
		{
			AIInfluenceBehavior.Instance?.LogMessage("[WARNING] cultural_traditions.json not found at path: " + text);
		}
		_traditionsLoaded = true;
	}

	public static string GeneratePrompt(Hero npc, NPCContext context, bool? overrideUseAsterisks = null, bool isMessengerMode = false)
	{
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Invalid comparison between Unknown and I4
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Invalid comparison between Unknown and I4
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Invalid comparison between Unknown and I4
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Invalid comparison between Unknown and I4
		//IL_20a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_218b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1568: Unknown result type (might be due to invalid IL or missing references)
		//IL_156d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffc: Unknown result type (might be due to invalid IL or missing references)
		//IL_157e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1583: Unknown result type (might be due to invalid IL or missing references)
		//IL_159e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1600: Unknown result type (might be due to invalid IL or missing references)
		//IL_1605: Unknown result type (might be due to invalid IL or missing references)
		//IL_1616: Unknown result type (might be due to invalid IL or missing references)
		//IL_161b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1636: Unknown result type (might be due to invalid IL or missing references)
		//IL_163b: Unknown result type (might be due to invalid IL or missing references)
		//IL_10df: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1103: Unknown result type (might be due to invalid IL or missing references)
		if (!context.KnowledgeGenerated)
		{
			WorldInfoManager.WorldSecretsManager.Instance.CheckSecretKnowledge(npc, context);
			WorldInfoManager.InformationManager.Instance.CheckInfoKnowledge(npc, context);
			context.KnowledgeGenerated = true;
		}
		string npcName = ((object)npc.Name)?.ToString() ?? "Unknown";
		string text = ((MBObjectBase)npc).StringId ?? "unknown";
		Clan clan = npc.Clan;
		string text2 = ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "No faction";
		Clan clan2 = npc.Clan;
		string text3 = ((clan2 != null) ? ((MBObjectBase)clan2).StringId : null) ?? "unknown";
		CultureObject culture = npc.Culture;
		string text4 = ((culture != null) ? ((MBObjectBase)culture).StringId : null) ?? "Unknown culture";
		string text5 = "none";
		string text6 = "none";
		string text7 = "You have no allegiance to any kingdom.";
		int num;
		if ((int)npc.Occupation != 16 && !npc.IsWanderer)
		{
			if (npc.Clan == null)
			{
				CharacterObject characterObject = npc.CharacterObject;
				num = ((characterObject != null && (int)characterObject.Occupation == 16) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
		}
		else
		{
			num = 1;
		}
		bool flag = (byte)num != 0;
		if (npc.Clan != null)
		{
			if (npc.Clan.MapFaction != null && npc.Clan.MapFaction.IsKingdomFaction)
			{
				text5 = ((object)npc.Clan.MapFaction.Name).ToString();
				text6 = npc.Clan.MapFaction.StringId;
				text7 = (npc.Clan.IsUnderMercenaryService ? ("Your clan serves as mercenaries for " + text5 + " (id:" + text6 + ").") : ((npc.Clan.MapFaction.Leader != npc.Clan.Leader) ? ("Your clan is a vassal of " + text5 + " (id:" + text6 + ").") : ("Your clan rules the kingdom of " + text5 + " (id:" + text6 + ").")));
			}
			else
			{
				text7 = "Your clan is independent and serves no kingdom.";
			}
		}
		else
		{
			if (!flag)
			{
				Settlement currentSettlement = npc.CurrentSettlement;
				if (currentSettlement != null)
				{
					IFaction mapFaction = currentSettlement.MapFaction;
					if (((mapFaction != null) ? new bool?(mapFaction.IsKingdomFaction) : ((bool?)null)) == true)
					{
						text5 = ((object)npc.CurrentSettlement.MapFaction.Name).ToString();
						text6 = npc.CurrentSettlement.MapFaction.StringId;
						text7 = "You are a subject of " + text5 + " (id:" + text6 + ").";
						goto IL_0398;
					}
				}
			}
			text7 = "You have no allegiance to any kingdom.";
		}
		goto IL_0398;
		IL_0398:
		int num2 = (int)npc.Age;
		string text8 = context.Gender ?? "unknown";
		string text9 = "commoner";
		if (flag)
		{
			text9 = ((!npc.IsPlayerCompanion) ? "wanderer" : "companion");
		}
		else if (npc.IsClanLeader)
		{
			text9 = "clan leader";
		}
		else if ((int)npc.Occupation == 3)
		{
			text9 = "noble";
		}
		else if (npc.IsNotable)
		{
			if (npc.CurrentSettlement?.Village != null && (int)npc.CurrentSettlement.Village.VillageState == 0)
			{
				text9 = (npc.IsHeadman ? "village headman" : ((!npc.IsRuralNotable) ? "village elder" : "landowner"));
			}
			else if (npc.CurrentSettlement?.Town != null)
			{
				text9 = (npc.IsArtisan ? "artisan" : (npc.IsMerchant ? "merchant" : (npc.IsGangLeader ? "gang leader" : ((!npc.IsPreacher) ? "town notable" : "preacher"))));
			}
			else
			{
				Settlement currentSettlement2 = npc.CurrentSettlement;
				text9 = ((currentSettlement2 != null && currentSettlement2.IsCastle) ? (npc.IsArtisan ? "artisan" : (npc.IsMerchant ? "merchant" : (npc.IsGangLeader ? "gang leader" : ((!npc.IsPreacher) ? "castle notable" : "preacher")))) : (npc.IsHeadman ? "village headman" : (npc.IsRuralNotable ? "landowner" : (npc.IsArtisan ? "artisan" : (npc.IsMerchant ? "merchant" : (npc.IsGangLeader ? "gang leader" : ((!npc.IsPreacher) ? "local notable" : "preacher")))))));
			}
		}
		Hero obj = npc;
		Clan clan3 = npc.Clan;
		object obj2;
		if (clan3 == null)
		{
			obj2 = null;
		}
		else
		{
			IFaction mapFaction2 = clan3.MapFaction;
			obj2 = ((mapFaction2 != null) ? mapFaction2.Leader : null);
		}
		if (obj == obj2)
		{
			text9 += $" and the King of {npc.Clan.MapFaction.Name} (id:{npc.Clan.MapFaction.StringId})";
		}
		bool flag2 = string.IsNullOrEmpty(context.AIGeneratedPersonality);
		bool flag3 = string.IsNullOrEmpty(context.AIGeneratedBackstory);
		bool flag4 = string.IsNullOrEmpty(context.AIGeneratedSpeechQuirks);
		string personalityDescription = GetPersonalityDescription(npc);
		string aIGeneratedBackstory = context.AIGeneratedBackstory;
		string text10 = (string.IsNullOrEmpty(aIGeneratedBackstory) ? null : aIGeneratedBackstory.Replace("\n", " ").Trim());
		string text11 = ((!flag2) ? context.AIGeneratedPersonality : personalityDescription);
		bool flag5 = GlobalSettings<ModSettings>.Instance.PromptIncludeQuirks;
		if (flag5)
		{
			float num3 = (float)new Random().NextDouble();
			if (num3 > GlobalSettings<ModSettings>.Instance.PromptQuirksFrequency)
			{
				flag5 = false;
			}
		}
		string text12 = ((!flag5) ? null : ((!flag4) ? context.AIGeneratedSpeechQuirks : "to be determined by you"));
		string relativesInfo = GetRelativesInfo(npc, context);
		string relationsInfo = GetRelationsInfo(npc, npc.CurrentSettlement, context);
		string text13 = context.LocationType ?? "unknown";
		string kingdomsAndLeadersInfo = GetKingdomsAndLeadersInfo();
		string kingdomDescription = GetKingdomDescription(npc);
		string previousRulersInfo = GetPreviousRulersInfo(npc);
		string holdingsInfo = GetHoldingsInfo(npc);
		string text14 = (npc.IsPrisoner ? null : GetWorkshopsInfo(npc));
		string clanInfo = GetClanInfo(npc, context);
		string text15 = context.WarStatus ?? "no wars";
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableDebugLogging)
		{
			int num4 = ((!string.IsNullOrEmpty(text15) && !(text15 == "no wars")) ? text15.Split(new string[1] { "; " }, StringSplitOptions.RemoveEmptyEntries).Length : 0);
			AIInfluenceBehavior.Instance?.LogMessage("[PromptGenerator] NPC: " + (((object)npc.Name)?.ToString() ?? "Unknown") + " | " + $"WarStatus from context: {num4} wars | " + $"WarStatus length: {text15?.Length ?? 0} chars");
		}
		string allianceStatus = GetAllianceStatus(npc);
		string tradeAgreementsInfo = GetTradeAgreementsInfo(npc);
		string tributesInfo = GetTributesInfo(npc);
		string reparationsInfo = GetReparationsInfo(npc);
		string territoryTransfersInfo = GetTerritoryTransfersInfo();
		string transferableSettlementsInfo = GetTransferableSettlementsInfo(npc);
		string currentTask = context.CurrentTask ?? "none";
		string text16 = (string.IsNullOrEmpty(context.CharacterDescription) ? "none" : context.CharacterDescription);
		string visitedSettlementsInfo = GetVisitedSettlementsInfo(npc, context);
		string nearbySettlementsInfo = GetNearbySettlementsInfo(npc);
		string text17 = "";
		if (npc.CurrentSettlement != null && EconomicEffectsManager.Instance != null && EconomicEffectsManager.Instance.TryGetSettlementDailyEffect(npc.CurrentSettlement, out var _, out var _, out var reason))
		{
			text17 = ", Situation: " + reason;
		}
		string skillNarrative = GetSkillNarrative(npc);
		bool flag6 = context.ConversationHistory != null && context.ConversationHistory.Any();
		string text18 = "never";
		CampaignTime val;
		if (flag6 && context.LastInteractionTime != CampaignTime.Never)
		{
			val = CampaignTime.Now;
			double toHours = (val).ToHours;
			val = context.LastInteractionTime;
			double num5 = toHours - (val).ToHours;
			val = CampaignTime.Now;
			double toDays = (val).ToDays;
			val = context.LastInteractionTime;
			double num6 = toDays - (val).ToDays;
			if (num5 < 1.0 / 60.0)
			{
				text18 = "now (currently in conversation)";
			}
			else if (num5 < 1.0)
			{
				int num7 = (int)(num5 * 60.0);
				text18 = $"{num7} minutes ago";
			}
			else if (num5 < 24.0)
			{
				text18 = $"{num5:F1} hours ago";
			}
			else if (num6 < 7.0)
			{
				text18 = $"{num6:F1} days ago ({num5:F0} hours)";
			}
			else
			{
				int num8 = (int)(num6 / 7.0);
				text18 = string.Format("{0:F1} days ago ({1} week{2})", num6, num8, (num8 > 1) ? "s" : "");
			}
		}
		string text19 = "none";
		if (context.KnownSecrets.Any())
		{
			List<string> list = (from s in WorldInfoManager.WorldSecretsManager.Instance.GetSecrets()
				where context.KnownSecrets.Contains(s.Id)
				select s.Description + " (access: " + s.AccessLevel + ")").ToList();
			text19 = (list.Any() ? string.Join("; ", list) : "none");
		}
		string text20 = "none";
		if (context.KnownInfo.Any())
		{
			List<string> list2 = (from i in WorldInfoManager.InformationManager.Instance.GetInfo()
				where context.KnownInfo.Contains(i.Id)
				select i.Description.Replace("{character}", npcName) + " (category: " + i.Category + ")").ToList();
			text20 = (list2.Any() ? string.Join("; ", list2) : "none");
		}
		string text21 = "none";
		DynamicEventsManager instance2 = DynamicEventsManager.Instance;
		if (instance2 != null)
		{
			List<DynamicEvent> eventsForNPC = instance2.GetEventsForNPC(npc);
			if (eventsForNPC != null && eventsForNPC.Any())
			{
				List<string> list3 = (from evt in (from evt in eventsForNPC
						where evt != null && !evt.IsExpired()
						orderby evt.Importance descending, evt.DaysSinceCreation
						select evt).Take(5)
					select PersonalizeEventForNPC(evt, npc)).ToList();
				text21 = (list3.Any() ? string.Join("; ", list3) : "none");
			}
		}
		string text22 = "none";
		if (GlobalSettings<ModSettings>.Instance.PromptIncludeEvents && context.RecentEvents != null && context.RecentEvents.Any())
		{
			ModSettings instance3 = GlobalSettings<ModSettings>.Instance;
			if (instance3 != null && instance3.EnableDebugLogging)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] PromptGenerator: Processing {context.RecentEvents.Count} events for {npcName}");
			}
			ModSettings instance4 = GlobalSettings<ModSettings>.Instance;
			double maxEventAgeDays = ((double?)instance4?.RecentEventsLifetimeDays) ?? 30.0;
			List<CampaignEvent> list4 = context.RecentEvents.Where(delegate(CampaignEvent e)
			{
				//IL_0004: Unknown result type (might be due to invalid IL or missing references)
				//IL_000a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0010: Unknown result type (might be due to invalid IL or missing references)
				//IL_0015: Unknown result type (might be due to invalid IL or missing references)
				//IL_001a: Unknown result type (might be due to invalid IL or missing references)
				int result;
				if (e != null)
				{
					_ = e.Timestamp;
					CampaignTime val3 = CampaignTime.Now - e.Timestamp;
					result = (((val3).ToDays <= maxEventAgeDays) ? 1 : 0);
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}).ToList();
			ModSettings instance5 = GlobalSettings<ModSettings>.Instance;
			if (instance5 != null && instance5.EnableDebugLogging)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] PromptGenerator: Filtered {context.RecentEvents.Count} → {list4.Count} events (max {maxEventAgeDays} days old) for {npcName}");
			}
			ModSettings instance6 = GlobalSettings<ModSettings>.Instance;
			if (instance6 != null && instance6.EnableDebugLogging)
			{
				foreach (CampaignEvent item in list4)
				{
					val = CampaignTime.Now - item.Timestamp;
					double toDays2 = (val).ToDays;
					bool flag7 = toDays2 <= maxEventAgeDays;
					bool flag8 = item.Type == "Battle" || (item.Type == "HeroKilled" && !item.Description.Contains("by unknown")) || (item.Type != "Battle" && item.Type != "HeroKilled");
					AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] Event: Type='{item.Type}', Age={toDays2:F1} days (OK: {flag7}), TypeFilter OK: {flag8}, Description='{item.Description}'");
					AIInfluenceBehavior instance7 = AIInfluenceBehavior.Instance;
					if (instance7 != null)
					{
						val = CampaignTime.Now;
						object arg = (val).ToDays;
						_ = item.Timestamp;
						val = item.Timestamp;
						instance7.LogMessage($"[DEBUG] Event Time: Now={arg:F1}, Event={(val).ToDays:F1}, Diff={toDays2:F1}");
					}
				}
			}
			int count = instance4?.MaxRecentEvents ?? 50;
			List<string> list5 = (from e in list4
				where e.Type == "Battle" || (e.Type == "HeroKilled" && !e.Description.Contains("by unknown")) || (e.Type != "Battle" && e.Type != "HeroKilled")
				orderby e.Timestamp descending
				select e).Take(count).Select(delegate(CampaignEvent e)
			{
				//IL_001a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0020: Unknown result type (might be due to invalid IL or missing references)
				//IL_0025: Unknown result type (might be due to invalid IL or missing references)
				//IL_002a: Unknown result type (might be due to invalid IL or missing references)
				string type = e.Type;
				string description = e.Description;
				CampaignTime val3 = CampaignTime.Now - e.Timestamp;
				return $"{type}: {description} ({Math.Max(0.0, (val3).ToDays):F1} days ago)";
			}).ToList();
			ModSettings instance8 = GlobalSettings<ModSettings>.Instance;
			if (instance8 != null && instance8.EnableDebugLogging)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] PromptGenerator: Filtered to {list5.Count} events for {npcName}");
			}
			text22 = (list5.Any() ? string.Join("; ", list5) : "none");
		}
		else
		{
			ModSettings instance9 = GlobalSettings<ModSettings>.Instance;
			if (instance9 != null && instance9.EnableDebugLogging)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[DEBUG] PromptGenerator: No events for {npcName} - IncludeEvents: {GlobalSettings<ModSettings>.Instance.PromptIncludeEvents}, Events: {context.RecentEvents?.Count ?? 0}");
			}
		}
		string text23 = "none";
		if (GlobalSettings<ModSettings>.Instance.PromptIncludeEvents && context.DialogueAnalysisEvents != null && context.DialogueAnalysisEvents.Any())
		{
			double maxDialogueEventAgeDays = ((double?)GlobalSettings<ModSettings>.Instance?.RecentEventsLifetimeDays) ?? 30.0;
			List<string> list6 = (from e in context.DialogueAnalysisEvents.Where(delegate(CampaignEvent e)
				{
					//IL_0000: Unknown result type (might be due to invalid IL or missing references)
					//IL_0006: Unknown result type (might be due to invalid IL or missing references)
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0010: Unknown result type (might be due to invalid IL or missing references)
					CampaignTime val3 = CampaignTime.Now - e.Timestamp;
					return (val3).ToDays <= maxDialogueEventAgeDays;
				})
				orderby e.Timestamp descending
				select e).Take(5).Select(delegate(CampaignEvent e)
			{
				//IL_001a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0020: Unknown result type (might be due to invalid IL or missing references)
				//IL_0025: Unknown result type (might be due to invalid IL or missing references)
				//IL_002a: Unknown result type (might be due to invalid IL or missing references)
				string type = e.Type;
				string description = e.Description;
				CampaignTime val3 = CampaignTime.Now - e.Timestamp;
				return $"{type}: {description} ({Math.Max(0.0, (val3).ToDays):F1} days ago)";
			}).ToList();
			text23 = (list6.Any() ? string.Join("; ", list6) : "none");
		}
		string diplomaticStatementsForNPC = GetDiplomaticStatementsForNPC(npc);
		string activeDiplomaticEventsForNPC = GetActiveDiplomaticEventsForNPC(npc);
		string text24 = ((context.EmotionalState != null) ? (context.EmotionalState.Mood + " (" + context.EmotionalState.Reason + ")") : "calm (no specific reason)");
		string text25 = ((context.TimeContext != null) ? $"{context.TimeContext.Season} of year {context.TimeContext.Year}, month {context.TimeContext.Month}, {context.TimeContext.TimeOfDay} (hour {context.TimeContext.Hour})" : "unknown time");
		string text26 = "";
		if (GlobalSettings<ModSettings>.Instance.EnableDiseaseSystem && context.IsSick && context.CurrentDiseases != null && context.CurrentDiseases.Any())
		{
			IEnumerable<string> values = context.CurrentDiseases.Select((NPCDiseaseInfo d) => $"{d.Name} ({d.SeverityDescription}, progress: {d.Progress:F0}%, " + $"infected {d.DaysInfected} days ago" + (d.IsTreated ? ", receiving treatment" : "") + ")");
			text26 = string.Join("; ", values);
		}
		string arg2 = "Never";
		string text27 = null;
		if (context.IsRomanceEligible)
		{
			object obj3;
			if (context.LastRomanceInteractionDays >= 0)
			{
				int lastRomanceInteractionDays = context.LastRomanceInteractionDays;
				val = CampaignTime.Now;
				if (lastRomanceInteractionDays != (int)(val).ToDays)
				{
					val = CampaignTime.Now;
					object arg3 = (int)(val).ToDays - context.LastRomanceInteractionDays;
					val = CampaignTime.Now;
					obj3 = string.Format("{0} day{1} ago", arg3, ((int)(val).ToDays - context.LastRomanceInteractionDays == 1) ? "" : "s");
				}
				else
				{
					obj3 = "Today";
				}
			}
			else
			{
				obj3 = "Never";
			}
			arg2 = (string)obj3;
			if (context.LastIntimateInteractionDays >= 0)
			{
				int lastIntimateInteractionDays = context.LastIntimateInteractionDays;
				val = CampaignTime.Now;
				object obj4;
				if (lastIntimateInteractionDays != (int)(val).ToDays)
				{
					val = CampaignTime.Now;
					object arg4 = (int)(val).ToDays - context.LastIntimateInteractionDays;
					val = CampaignTime.Now;
					obj4 = string.Format("{0} day{1} ago", arg4, ((int)(val).ToDays - context.LastIntimateInteractionDays == 1) ? "" : "s");
				}
				else
				{
					obj4 = "Today";
				}
				text27 = (string)obj4;
			}
		}
		string weatherInfo = GetWeatherInfo(npc);
		currentTask = EnhanceCurrentTaskWithActions(npc, currentTask);
		string text28 = "unknown";
		if (!isMessengerMode && context.PlayerForces != null)
		{
			Hero mainHero = Hero.MainHero;
			bool flag9 = ((mainHero != null) ? mainHero.CurrentSettlement : null) != null && npc.CurrentSettlement != null && Hero.MainHero.CurrentSettlement == npc.CurrentSettlement;
			List<Hero> list7 = new List<Hero>();
			if (flag9 && npc.CurrentSettlement != null)
			{
				List<Hero> list8 = AIActionManager.Instance?.GetHeroesFollowingPlayerInSettlement(npc.CurrentSettlement);
				if (list8 != null)
				{
					foreach (Hero item2 in list8)
					{
						if (item2 != null && !item2.IsDead && !item2.IsPrisoner && item2 != Hero.MainHero)
						{
							list7.Add(item2);
						}
					}
				}
				if (Clan.PlayerClan != null)
				{
					foreach (Hero item3 in (List<Hero>)(object)Hero.AllAliveHeroes)
					{
						if (item3 != null && !item3.IsDead && !item3.IsPrisoner && item3 != Hero.MainHero && (item3.CompanionOf == Clan.PlayerClan || item3 == Hero.MainHero.Spouse) && item3.CurrentSettlement == npc.CurrentSettlement && !list7.Contains(item3))
						{
							list7.Add(item3);
						}
					}
				}
			}
			int num9;
			if (npc.PartyBelongedTo == null && !npc.IsLord && !npc.IsClanLeader)
			{
				if (npc.IsNotable)
				{
					Settlement currentSettlement3 = npc.CurrentSettlement;
					if (currentSettlement3 == null || !currentSettlement3.IsTown)
					{
						Settlement currentSettlement4 = npc.CurrentSettlement;
						num9 = ((currentSettlement4 != null && currentSettlement4.IsCastle) ? 1 : 0);
					}
					else
					{
						num9 = 1;
					}
				}
				else
				{
					num9 = 0;
				}
			}
			else
			{
				num9 = 1;
			}
			bool flag10 = (byte)num9 != 0;
			int partySize = context.PlayerForces.PartySize;
			if (flag9)
			{
				string text29;
				if (list7.Count > 0)
				{
					List<string> list9 = list7.Select((Hero h) => ((object)h.Name)?.ToString() ?? "Unknown").ToList();
					if (list7.Count == 1)
					{
						text29 = "the player and their companion " + list9[0];
					}
					else
					{
						string text30 = string.Join(", ", list9.Take(list9.Count - 1)) + " and " + list9.Last();
						text29 = "the player and their companions " + text30;
					}
				}
				else
				{
					text29 = "only the player alone";
				}
				string text31 = "";
				try
				{
					Mission current4 = Mission.Current;
					PlayerReinforcementMissionLogic playerReinforcementMissionLogic = ((current4 != null) ? current4.GetMissionBehavior<PlayerReinforcementMissionLogic>() : null);
					if (playerReinforcementMissionLogic != null && playerReinforcementMissionLogic.HasActiveSummonedTroops())
					{
						string summonedTroopsInfo = playerReinforcementMissionLogic.GetSummonedTroopsInfo();
						if (!string.IsNullOrEmpty(summonedTroopsInfo) && summonedTroopsInfo != "none" && summonedTroopsInfo != "error")
						{
							text31 = ". The player has summoned their troops into the settlement: " + summonedTroopsInfo;
						}
					}
				}
				catch
				{
				}
				text28 = (string.IsNullOrEmpty(text31) ? (text29 + ", no army (their party remains outside the settlement)") : (text29 + text31));
			}
			else if (!flag10)
			{
				text28 = (context.PlayerForces.HasArmy ? $"appears to have around {partySize} men (rough estimate, including the player), leading what seems to be an army" : ((partySize == 1) ? "alone, no army" : ((partySize > 5) ? $"roughly {partySize} people (estimate, including the player), no army" : $"{partySize} people with them (including the player), no army")));
			}
			else
			{
				text28 = ((partySize != 1) ? string.Format("{0} men (including the player), {1:F0}% wounded, {2}", partySize, context.PlayerForces.WoundedPercentage, context.PlayerForces.HasArmy ? "leading an army" : "no army") : string.Format("only the player alone, {0:F0}% wounded, {1}", context.PlayerForces.WoundedPercentage, context.PlayerForces.HasArmy ? "leading an army" : "no army"));
				if (context.PlayerForces.TroopDetails != null && context.PlayerForces.TroopDetails.Count > 0)
				{
					List<string> values2 = context.PlayerForces.TroopDetails.Select((TroopDetail t) => string.Format("{0} (id:{1}, count:{2}{3})", t.Name, t.StringId, t.Count, (t.WoundedCount > 0) ? $", wounded:{t.WoundedCount}" : "")).ToList();
					text28 = text28 + ". Detailed troops: " + string.Join(", ", values2);
				}
			}
		}
		string text32;
		if (context.NPCForces != null)
		{
			text32 = ((!context.NPCForces.HasArmy || string.IsNullOrEmpty(context.NPCForces.ArmyDetails)) ? string.Format("{0} men, {1:F0}% wounded, {2}", context.NPCForces.PartySize, context.NPCForces.WoundedPercentage, context.NPCForces.HasArmy ? "leading an army" : "no army") : context.NPCForces.ArmyDetails);
			if (context.NPCForces.TroopDetails != null && context.NPCForces.TroopDetails.Count > 0)
			{
				List<string> values3 = context.NPCForces.TroopDetails.Select((TroopDetail t) => string.Format("{0} (id:{1}, count:{2}{3})", t.Name, t.StringId, t.Count, (t.WoundedCount > 0) ? $", wounded:{t.WoundedCount}" : "")).ToList();
				text32 = text32 + ". Detailed troops: " + string.Join(", ", values3);
			}
		}
		else
		{
			text32 = "unknown";
		}
		string nPCPrisonersInfo = WorldInfoManager.GetNPCPrisonersInfo(npc);
		string text33 = ((context.PlayerRelation != null) ? $"{context.PlayerRelation.Value} ({context.PlayerRelation.Description})" : "0 (neutral)");
		string text34 = context.TrustLevel.ToString("F2");
		string text35 = context.InformationAccessLevel ?? "low";
		string text36 = context.PlayerInfo.RealCulture ?? "unknown";
		string text37 = WorldInfoManager.Instance.ReadWorldInfo();
		string text38 = WorldInfoManager.Instance.ReadPlayerDescription();
		string text39 = "";
		text39 = (isMessengerMode ? "You are far away from this person and sending them a messenger with a written message." : ((string.IsNullOrEmpty(context.LocationType) || (!context.LocationType.Contains("with your party") && !context.LocationType.Contains("as your spouse") && !context.LocationType.Contains("traveling together"))) ? GetPartyStatusDescription(context) : ""));
		object obj6;
		if (!npc.IsPrisoner)
		{
			obj6 = "";
		}
		else if (npc.PartyBelongedToAsPrisoner != PartyBase.MainParty)
		{
			PartyBase partyBelongedToAsPrisoner = npc.PartyBelongedToAsPrisoner;
			obj6 = ((((partyBelongedToAsPrisoner != null) ? partyBelongedToAsPrisoner.Settlement : null) != null) ? string.Format("You are a prisoner in {0} ({1}{2}).", npc.PartyBelongedToAsPrisoner.Settlement.Name, npc.PartyBelongedToAsPrisoner.Settlement.IsCastle ? "castle" : "town", npc.PartyBelongedToAsPrisoner.Settlement.HasPort ? ", port" : "") : "You are a prisoner in an unknown location.");
		}
		else
		{
			obj6 = "You are a prisoner in the player's party.";
		}
		string text40 = (string)obj6;
		string text41 = context.EscalationState ?? "neutral";
		string text42 = context.NegativeToneCount?.ToString() ?? "0";
		string text43 = MBTextManager.ActiveTextLanguage ?? "English";
		string equipmentDescription = CharacterInfo.GetEquipmentDescription(npc);
		string appearanceDescription = CharacterInfo.GetAppearanceDescription(npc);
		string text44 = (isMessengerMode ? null : CharacterInfo.GetEquipmentDescription(Hero.MainHero));
		string text45 = (isMessengerMode ? null : CharacterInfo.GetAppearanceDescription(Hero.MainHero));
		ModSettings instance10 = GlobalSettings<ModSettings>.Instance;
		if (instance10 != null && instance10.EnableDebugLogging)
		{
			LogDebug($"[CharacterInfo] NPC equipment: {equipmentDescription?.Length ?? 0} chars, appearance: {appearanceDescription?.Length ?? 0} chars");
			LogDebug($"[CharacterInfo] Player equipment: {text44?.Length ?? 0} chars, appearance: {text45?.Length ?? 0} chars");
		}
		string arg5;
		if (context.ConversationHistory != null && context.ConversationHistory.Any())
		{
			val = CampaignTime.Now;
			double nowDays = (val).ToDays;
			IEnumerable<string> source = context.ConversationHistory.Skip(Math.Max(0, context.ConversationHistory.Count - GlobalSettings<ModSettings>.Instance.PromptMaxHistory)).Take(GlobalSettings<ModSettings>.Instance.PromptMaxHistory);
			arg5 = string.Join("\n", source.Select(delegate(string msg)
		{
			if (string.IsNullOrEmpty(msg))
			{
				return msg;
			}
			int pillIdx = msg.IndexOf("\n---\n", StringComparison.Ordinal);
			if (pillIdx < 0) pillIdx = msg.IndexOf("\n===\n", StringComparison.Ordinal);
			if (pillIdx >= 0)
				msg = msg.Substring(0, pillIdx);
			double? num12 = null;
			int num13 = msg.IndexOf("[sent_at_days=", StringComparison.OrdinalIgnoreCase);
				if (num13 >= 0)
				{
					int num14 = num13 + "[sent_at_days=".Length;
					int num15 = msg.IndexOf("]", num14, StringComparison.Ordinal);
					if (num15 > num14)
					{
						string s = msg.Substring(num14, num15 - num14);
						if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
						{
							num12 = result;
						}
					}
					int num16 = msg.IndexOf("]", num13, StringComparison.Ordinal);
					if (num16 > num13 && num12.HasValue)
					{
						double num17 = Math.Max(0.0, nowDays - num12.Value);
						string text56 = ((num17 < 0.1) ? "just now" : $"{num17:F1} days ago");
						string text57 = msg.Remove(num13, num16 - num13 + 1).Trim();
						return text57 + " (sent " + text56 + ")";
					}
				}
				return msg;
			}));
		}
		else
		{
			arg5 = "No conversation history.";
		}
		List<string> list10 = ((context.ConversationHistory != null) ? context.ConversationHistory.Where((string msg) => msg != null && msg.IndexOf("via messenger", StringComparison.OrdinalIgnoreCase) >= 0).ToList() : new List<string>());
		string text46;
		if (list10.Any())
		{
			val = CampaignTime.Now;
			double nowDays2 = (val).ToDays;
		text46 = string.Join("\n", list10.Skip(Math.Max(0, list10.Count - 5)).Select(delegate(string msg)
		{
			int pillIdx = msg.IndexOf("\n---\n", StringComparison.Ordinal);
			if (pillIdx < 0) pillIdx = msg.IndexOf("\n===\n", StringComparison.Ordinal);
			if (pillIdx >= 0)
				msg = msg.Substring(0, pillIdx);
			double? num12 = null;
			int num13 = msg.IndexOf("[sent_at_days=", StringComparison.OrdinalIgnoreCase);
				if (num13 >= 0)
				{
					int num14 = num13 + "[sent_at_days=".Length;
					int num15 = msg.IndexOf("]", num14, StringComparison.Ordinal);
					if (num15 > num14)
					{
						string s = msg.Substring(num14, num15 - num14);
						if (double.TryParse(s, out var result))
						{
							num12 = result;
						}
					}
				}
				string text56 = msg;
				if (num13 >= 0)
				{
					int num16 = msg.IndexOf("]", num13, StringComparison.Ordinal);
					if (num16 > num13)
					{
						text56 = msg.Remove(num13, num16 - num13 + 1).Trim();
					}
				}
				string text57 = (num12.HasValue ? $"{Math.Max(0.0, nowDays2 - num12.Value):F1} days ago" : "time unknown");
				return "- " + text56 + " (sent " + text57 + ")";
			}));
		}
		else
		{
			text46 = "No previous messenger letters sent by you.";
		}
		IReadOnlyList<string> mentionedSettlementSummaries = SettlementMentionParser.GetMentionedSettlementSummaries(context.ConversationHistory, 6, npc);
		string text47 = ((mentionedSettlementSummaries != null && mentionedSettlementSummaries.Count > 0) ? string.Join("\n", mentionedSettlementSummaries.Select((string summary) => "- " + summary)) : null);
		Hero obj7 = npc;
		bool flag11 = ((obj7 != null) ? obj7.PartyBelongedTo : null) != null && npc.PartyBelongedTo == Hero.MainHero.PartyBelongedTo;
		bool flag12 = npc == Hero.MainHero;
		Hero referenceHero = npc;
		IReadOnlyList<string> readOnlyList = ((!flag12) ? NearbyPartyInfoProvider.GetNearbyPartySummaries(referenceHero, 10f, 6, (IEnumerable<MobileParty>)(object)new MobileParty[1] { MobileParty.MainParty }) : null);
		string text48 = ((readOnlyList != null && readOnlyList.Count > 0) ? string.Join("\n", readOnlyList.Select((string summary) => "- " + summary)) : null);
		string otherPlayerPrisonersInfo = WorldInfoManager.GetOtherPlayerPrisonersInfo(npc);
		bool flag13 = npc.PartyBelongedTo != null && npc.PartyBelongedTo.IsCurrentlyAtSea;
		string text49 = "";
		string text50 = "";
		if (npc.PartyBelongedTo != null && npc.PartyBelongedTo.Party != null)
		{
			text49 = GetShipInfo(npc.PartyBelongedTo.Party, flag13);
			if (!string.IsNullOrEmpty(text49))
			{
				text49 = " " + text49;
			}
		}
		if (!flag13)
		{
			text50 = " You are on land (not at sea).";
		}
		bool flag14 = Hero.MainHero.PartyBelongedTo != null && Hero.MainHero.PartyBelongedTo.IsCurrentlyAtSea;
		string text51 = "";
		if (flag13 && flag14 && Hero.MainHero.PartyBelongedTo != null && Hero.MainHero.PartyBelongedTo.Party != null)
		{
			PartyBase party = Hero.MainHero.PartyBelongedTo.Party;
			if (party.Ships != null && ((List<Ship>)(object)party.Ships).Count > 0)
			{
				Ship val2 = party.FlagShip ?? ((((List<Ship>)(object)party.Ships).Count > 0) ? ((List<Ship>)(object)party.Ships)[0] : null);
				if (val2 != null && val2.ShipHull != null)
				{
					string text52 = ((object)val2.Name)?.ToString();
					if (string.IsNullOrEmpty(text52))
					{
						text52 = ((object)val2.ShipHull.Name)?.ToString() ?? "unknown ship";
					}
					string text53 = ((object)val2.ShipHull.Type/*cast due to .constrained prefix*/).ToString().ToLowerInvariant();
					int count2 = ((List<Ship>)(object)party.Ships).Count;
					text51 = ((count2 != 1) ? $" They are currently sailing with {count2} ships, their flagship being a {text53} ship named \"{text52}\" at sea." : (" They are currently sailing on a " + text53 + " ship named \"" + text52 + "\" at sea."));
				}
				else
				{
					text51 = " They are currently sailing on a ship at sea.";
				}
			}
		}
		string detailedMilitaryInfo = GetDetailedMilitaryInfo(npc);
		string inventorySummary = InventoryHelper.GetInventorySummary(npc);
		ItemRoster heroItemRoster = InventoryHelper.GetHeroItemRoster(Hero.MainHero, isPlayer: true);
		string mentionedItemsSummary = ItemMentionParser.GetMentionedItemsSummary(heroItemRoster, context.ConversationHistory, 6, isPlayerInventory: true, npc);
		List<string> list11 = new List<string>();
		if (text22 != "none")
		{
			list11.Add(text22);
		}
		if (text23 != "none")
		{
			list11.Add(text23);
		}
		if (text21 != "none")
		{
			list11.Add(text21);
		}
		string text54 = (list11.Any() ? string.Join("; ", list11) : "none");
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("### Mission ###\nRole-play as a character in Mount & Blade II: Bannerlord. Use your personality, history, and context to inform responses.\n\n");
		stringBuilder.Append("### Core Rules ###\n- Stay in character. Never break immersion or reference modern world/AI. " + ((overrideUseAsterisks ?? GlobalSettings<ModSettings>.Instance.PromptUseAsterisks) ? "Use *asterisks for actions/surroundings*" : "Dialogue only, no action descriptions.") + " Language: " + text43 + ".\n- Address the person naturally—NEVER use \"player\" or meta-gaming terms. They are a real person in your world.\n- Verify data consistency: Cross-check conversation history against facts, focus on data marked as current. React in-character if you detect contradictions.\n- Vary responses naturally unless character traits dictate repetition (catchphrases, verbal tics). Avoid formulaic patterns.\n- Facts MUST come from CURRENT DATA. Improvise emotions/flavor only. NEVER invent character names not in CURRENT DATA — use generic titles (elder, merchant) if unknown.\n\n");
		if (!isMessengerMode && GlobalSettings<ModSettings>.Instance.PromptEnableInternalThoughts)
		{
			stringBuilder.Append(GenerateInternalThoughtsSection(npc, context, isMessengerMode));
		}
		stringBuilder.Append("### Information Sharing ###\n- General topics ('world', 'event', 'personal'): Share if you have some trust.\n" + $"- Sensitive ('plan', 'strategy', 'army'): Only trusted allies (trust > {GlobalSettings<ModSettings>.Instance.PromptSensitiveTrust:F1}, access 'medium'+'high').\n" + $"- Secrets ('secrets', 'rumors'): Only if directly asked by highly trusted person (trust > {GlobalSettings<ModSettings>.Instance.PromptSecretTrust:F1}, access 'high').\n\n");
		stringBuilder.Append("### Communication ###\nCommunicate considering character data (personality, speech mannerisms).\n- `tone`: Change in attitude. Use if you think the attitude should improve or worsen. `positive` = improved relationship, `negative` = worsened relationship, `neutral` = no change. Base on their words/behavior affecting trust/respect.\n" + $"- `suspected_lie` - Lie Detection. Set to TRUE ONLY when you are CERTAIN they are lying - when their statements CLEARLY and UNDENIABLY contradict: verified facts you know for sure, their proven identity, documented past claims in conversation history, or when claims are physically/logically impossible. Do NOT set to TRUE for mere suspicions, doubts, or unclear contradictions - only when you are CONFIDENT they are lying. Detection strictness: {GlobalSettings<ModSettings>.Instance.PromptLieStrictness:F1} (0.0=lenient, 1.0=strict + base on your character). React per your personality.\n" + "- `decision` - Set 'release' if the conversation is logically concluded, or you don't want to talk with them for some reason. Explain the reason.\n- `allows_letters`: Correspondence Preference. Set to `true` if you want to be able to send messengers with letters to the player, or `false` if you don't want to contact them this way (e.g., if you are annoyed, busy, or they asked you not to). Base this on your relationship and player's requests.\n- **CRITICAL: Player Identity Information (`claimed_name`, `claimed_clan`, `claimed_age`)**: These fields MUST be updated ONLY when the player EXPLICITLY states this information DIRECTLY in their dialogue with you. Do NOT infer or extract this information from technical data, game metadata, kingdom names, nearby parties, troop names, party information, or any other source outside of direct conversation. **ABSOLUTELY DO NOT extract names or other identity information from action descriptions (text in `**`). Actions are narrative descriptions of physical movements and behaviors, NOT dialogue statements. You can ONLY know the player's name, clan, or age if they tell you themselves in spoken dialogue. If the player hasn't explicitly told you their name/clan/age in conversation, these fields MUST remain null. Never invent or guess based on context clues or actions.**\n\n");
		if (context.IsRomanceEligible)
		{
			stringBuilder.Append("### Romance ###\n- Cultural features: " + GetCulturalRomanceTraditions(text4) + " Consider traditions but don't obsess.\n- Attraction: See Romance Status in Character Briefing. Judge their appearance, personality, achievements, behavior.\n" + $"- Initiative: {(npc.IsFemale ? (GlobalSettings<ModSettings>.Instance.FemaleNPCRomanceInitiative * 100f) : (GlobalSettings<ModSettings>.Instance.MaleNPCRomanceInitiative * 100f)):F0}%. Use the chance to initiate romance with them yourself.\n" + "- 'romance_intent': 'none'|'flirt'|'romance'|'proposal'. Use 'flirt' if accepting light courtship, 'romance' if accepting courtship and you are in love. Set = 'none' if there is no romantic interaction, or you refuse their romance + state this.\n" + ((!isMessengerMode) ? ("- Marriage:\n  • Propose marriage: Set 'romance_intent'='proposal' AND 'decision'='propose_marriage'. Response must include clear marriage proposal.\n" + $"  • Accept: 'decision'='accept_marriage' ONLY if: (1) Player EXPLICITLY proposed in LAST message (\"Will you marry me?\", \"Let's get married\"), AND (2) RomanceLevel >= {GlobalSettings<ModSettings>.Instance.MinRomanceToAcceptMarriage} (see Romance Status). If too low, use 'reject_marriage' + explain refusal.\n" + "  • Reject: 'decision'='reject_marriage' if player proposed but you refuse.\n  • CRITICAL: Discussing marriage ≠ proposal. Only use accept/reject when player DIRECTLY asks to marry.\n") : "") + "- Romance timing: See Romance Status in Character Briefing below.\n" + ((!isMessengerMode) ? $"- Intimate interactions: If the player suggests or requests intimate/romantic physical interaction (e.g., \"let's make love\", \"spend the night together\", \"be intimate\"), and you are romantically interested (RomanceLevel >= 40), you can agree by setting 'decision'='intimate'. This is a roleplay interaction that may result in pregnancy (chance: {GlobalSettings<ModSettings>.Instance.IntimacyConceptionChance * 100f:F0}%). Only agree if it fits your character and relationship. If RomanceLevel < 40 or you're not interested, politely decline.\n\n" : "\n"));
		}
		else
		{
			stringBuilder.Append("### Romance ###\nNOT available. Reason: " + (AreRelated(npc, Hero.MainHero) ? "Family member (marriage forbidden)" : ((npc.Spouse != null) ? "You're married" : ((Hero.MainHero.Spouse != null) ? "They're married" : (npc.IsPrisoner ? "You're a prisoner" : "Circumstances prevent it")))) + ". Decline all advances. 'romance_intent'='none'. NEVER initiate.\n\n");
		}
		if (!isMessengerMode)
		{
			stringBuilder.Append("### Conflict ###\n- Escalation: React to threats/disrespect. Consistent hostility → 'tense' → 'critical'.\n- Attack: 'decision'='attack' if you are attacking them, or in war, self-defense, or unavoidable combat. State clearly. Can't attack if prisoner.\n- Surrender: 'decision'='surrender' only if forces significantly weaker AND personality allows. State clearly. Can't surrender if prisoner.\n- Accept surrender: 'decision'='accept_surrender' when player confirms surrender (not prisoner). End dialogue without questions—player can't respond.\n- Release: 'decision'='release' when you agree to part peacefully (\"Let's part ways\", \"I'll let you go\", \"We won't fight\"). State reason.\n\n");
		}
		if (!isMessengerMode && GlobalSettings<ModSettings>.Instance.PromptEnableQuests)
		{
			stringBuilder.Append(GetQuestSection(npc, context));
		}
		if (text14 != null)
		{
			stringBuilder.Append(GetWorkshopTradingRules(npc));
		}
		if (!isMessengerMode)
		{
			stringBuilder.Append("### Task Logic ###\n- Completion: After finishing tasks (gather info, deliver message, errand), use 'return_to_player' when appropriate.\n- Travel: 'go_to_settlement' ONLY for independent travel (own party, leaving player's group). Don't use if already in player's party.\n- Following: 'follow_player'=stay continuously (in party). 'return_to_player'=go back after absence. Can't do both.\n- Combat orders: Use combat actions ('attack_party', 'siege_settlement') only when player explicitly orders. Append ',then:return' to return after.\n- Sequence: Go → Task → Return (when makes sense). New task while busy? Finish current first.\n- Independence: Decide when to return based on personality/situation and what player asked.\n\n");
			stringBuilder.Append(GetAvailableActionsPrompt(npc));
		}
		stringBuilder.Append("### Response fields (semantic meaning) ###\n**IMPORTANT: Only include fields that are relevant. Omit optional fields if they don't apply (e.g., no money_transfer if not exchanging money, no kingdom_action if not a kingdom leader, etc.).**\n\n**REQUIRED fields (always include):**\n");
		stringBuilder.Append(string.Format("- `response`: (string) In-character speech/actions. Min {0} chars, max {1} chars.{2}\n", GlobalSettings<ModSettings>.Instance.PromptMinResponseLength, GlobalSettings<ModSettings>.Instance.PromptMaxResponseLength, (text12 != null && !string.IsNullOrEmpty(text12) && text12 != "to be determined by you") ? " **CRITICAL**: Use cultural phrases and speech patterns from Speech Quirks NATURALLY and authentically. Cultural greetings should appear ONLY at the very start of a conversation, not in every response. Cultural interjections, exclamations, or expressions should be used sparingly (1-2 times per response maximum) and varied - don't repeat the same phrase. Let your personality-based mannerisms flow naturally throughout your speech. The goal is to make your speech feel authentic and culturally grounded, not forced or repetitive." : ""));
		if (!isMessengerMode && GlobalSettings<ModSettings>.Instance.PromptEnableInternalThoughts)
		{
			stringBuilder.Append("- `internal_thoughts`: (string) **REQUIRED** - 500-1500 chars. Your PRIVATE reasoning process from the thought steps above. Summarize your character's internal perspective, motivations, conflicts, and strategy. The player will NEVER see this - be honest and introspective.\n");
		}
		if (context.IsRomanceEligible)
		{
			stringBuilder.Append("- `romance_intent`: (string) 'none'|'flirt'|'romance'|'proposal'. See Romance Rules.\n");
		}
		string[] obj8 = new string[11]
		{
			isMessengerMode ? "" : (context.IsRomanceEligible ? ("- `decision`: (string) 'none'|'attack'" + ((npc.IsPrisoner || npc.CurrentSettlement != null) ? "" : "|'surrender'|'accept_surrender'") + "|'release'|'propose_marriage'|'accept_marriage'|'reject_marriage'|'intimate'.\n") : ("- `decision`: (string) 'none'|'attack'" + ((npc.IsPrisoner || npc.CurrentSettlement != null) ? "" : "|'surrender'|'accept_surrender'") + "|'release'.\n")),
			isMessengerMode ? "" : "- `tone`: (string) 'positive'|'negative'|'neutral'. How this exchange changed your attitude.\n- `threat_level`: (string) 'high'|'low'|'none'. Threat from player.\n- `escalation_state`: (string) 'neutral'|'tense'|'critical'. Current tension.\n- `suspected_lie`: (boolean) true ONLY when you are CERTAIN they are lying - clear and undeniable contradiction with verified facts. Do NOT use for suspicions or doubts.\n- `deescalation_attempt`: (boolean) true if player apologizes/calms.\n- `claimed_name`, `claimed_clan`, `claimed_age`: (string/int/null) Update ONLY when player EXPLICITLY states this information in their SPOKEN dialogue. **CRITICAL: Do NOT extract names or identity information from action descriptions (text in `**`). Actions are narrative descriptions of physical movements, NOT dialogue statements. Do NOT infer from meta-information like kingdom names, nearby parties, troop names, or actions. Set to null if player hasn't explicitly told you in spoken words. Don't invent.**\n- `claimed_gold`: (int) Amount player states they have. 0 if not mentioned.\n- `allows_letters`: (boolean) **REQUIRED** - Your current correspondence preference. Keep `true` to allow sending letters, set to `false` to stop. Change ONLY if your relationship or player's requests justify it.\n",
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null,
			null
		};
		ModSettings instance11 = GlobalSettings<ModSettings>.Instance;
		obj8[2] = ((instance11 != null && instance11.EnableTTS && !isMessengerMode) ? "- `tts_instructions`: (string) **REQUIRED** - 20-120 chars in ENGLISH. Describe tone, emotion, pace, delivery style. Examples: \"Speak cheerfully and energetically\", \"Speak slowly with sadness\".\n" : "");
		obj8[3] = "\n**OPTIONAL fields (include ONLY if relevant, NEVER repeat actions from Previous Response — they are ALREADY EXECUTED):**\n";
		obj8[4] = (isMessengerMode ? "" : $"- `money_transfer`: (object) {{\"action\": \"give\"|\"receive\", \"amount\": number, \"opposed_attribute\": \"...\"?}}. ONLY when you ACCEPT transfer. \"give\"=you pay player, \"receive\"=player pays you. Max: {npc.Gold} denars. Add **opposed_attribute** (vigor|endurance|control|cunning|intelligence|social) ONLY when contested—player forces/extorts you. When set, the game rolls dice; if player wins, transfer succeeds; if they lose, you refuse. Omit for agreements (quest reward, trade, gift). **Omit if no money transfer.**\n");
		obj8[5] = (isMessengerMode ? "" : "- `item_transfers`: (array) `[{\"item_id\": \"...\", \"amount\": N, \"action\": \"give\"|\"take\"}]`. 'give'=you→player, 'take'=player→you. Use exact item IDs from inventories. Add **`item_transfers_opposed_attribute`** as a TOP-LEVEL sibling (same level as item_transfers), e.g. `{\"item_transfers\": [...], \"item_transfers_opposed_attribute\": \"social\"}`. ONLY when contested—player forces you. When set, the game rolls dice; if player wins, transfer succeeds; if they lose, you refuse. Omit for agreements. **Omit if no item exchange.**\n");
		obj8[6] = ((text14 != null && !isMessengerMode) ? GetWorkshopJsonFields() : "");
		obj8[7] = (isMessengerMode ? "" : "- `technical_action`: (string) \"ACTION_NAME\" to start, \"ACTION_NAME:STOP\" to stop. **Omit if no action change.**\n");
		obj8[8] = ((!isMessengerMode && CanNPCBeKilledThroughRoleplay(npc)) ? "- `character_death`: (object) {\"should_die\": true, \"death_reason\": \"...\", \"killer_string_id\": \"...\", \"opposed_attribute\": \"vigor\"|\"endurance\"|\"control\"|\"cunning\"|\"intelligence\"|\"social\"} for permanent death. Use player's ID if they killed you (e.g., \"lord_1_1\"), null for natural/unknown. **opposed_attribute** REQUIRED when killer is player: ONE attribute that best fits HOW they killed you (vigor=strength/combat, cunning=deception/poison, control=precision, etc). When set, the game rolls dice; if player wins, death occurs; if they lose, you survive. Omit if killer is null. Valid death_reason: lethal attacks, suicide, assassination, natural death, sacrifice. If set, `decision` MUST be 'none'. **Omit if not dying.**\n" : "");
		obj8[9] = (GlobalSettings<ModSettings>.Instance.PromptEnableQuests ? GetQuestJsonFieldDescription(npc, context, isMessengerMode) : "");
		obj8[10] = "\n";
		stringBuilder.Append(string.Concat(obj8));
		if (flag2 || flag3 || flag4)
		{
			stringBuilder.Append("**CHARACTER CREATION fields (!!! REQUIRED !!!):**\n");
			if (flag2)
			{
				stringBuilder.Append("- `character_personality`: (string) **REQUIRED** - 200-500 chars. Create a LIVING, THREE-DIMENSIONAL PSYCHOLOGICAL PORTRAIT of your inner self. Describe your PSYCHOTYPE - your deep psychological makeup, emotional patterns, internal motivations, and authentic human qualities. Consider these aspects:\n  * Emotional depth: What emotions do you truly feel? Are you melancholic, cheerful, anxious, serene? What makes you laugh or cry?\n  * Internal conflicts: What inner struggles do you face? What contradictions exist within you?\n  * Vulnerabilities and strengths: What are your genuine fears, insecurities, but also what gives you true strength?\n  * Authentic values: Beyond honor and bravery - what do you REALLY care about? Family? Knowledge? Beauty? Peace? Justice? Freedom? What moves your heart?\n  * Human quirks: What makes you uniquely human? Do you have unusual habits, irrational fears, unexpected passions?\n  * Personality spectrum: Avoid being one-dimensional. A brave person can be afraid of spiders. A generous person can be envious. Show complexity.\nBase this on the Base Personality Traits provided, but create a REAL, MULTI-FACETED PERSON. Avoid generic 'tough warrior' stereotypes. Be creative, diverse, and human. DO NOT mention current kingdom, clan, or role - focus on timeless psychological traits that define WHO YOU ARE, not WHAT YOU DO.\n");
			}
			if (flag3)
			{
				stringBuilder.Append("- `character_backstory`: (string) **REQUIRED** - 1000-2000 chars. Describe your PAST: origins, childhood, early experiences, formative events, and hobby/habit (unrelated to politics/war). This is your HISTORY, NOT current events. DO NOT mention current wars, current kingdom, current settlements, or recent events - these are temporary. Focus on your past: where you came from, what shaped you, what happened before the current game situation. Match your culture, role, and age.\n");
			}
			if (flag4)
			{
				stringBuilder.Append("- `character_speech_quirks`: (string) **REQUIRED** - 2-4 patterns, comma-separated. Create authentic speech patterns that reflect: (1) Your personality traits - how your inner character shapes your way of speaking (e.g., formal vs casual, verbose vs brief, poetic vs direct); (2) Your cultural background - research the real-world inspiration for your culture and create appropriate cultural phrases, greetings, interjections, and expressions that match that cultural heritage. Consider: What language family does your culture belong to? What historical period/region inspired it? What are typical speech patterns, honorifics, or expressions from that background? Create phrases that feel authentic to that culture, not generic fantasy. Use cultural phrases naturally: greetings only at conversation start, interjections/exclamations 1-2 times per response maximum, vary expressions to avoid repetition. The goal is to make your speech feel culturally authentic and personality-driven, not forced or repetitive.\n");
			}
			stringBuilder.Append("\n");
		}
		if (!isMessengerMode)
		{
			string kingdomActionsSection = GetKingdomActionsSection(npc, text43);
			if (!string.IsNullOrEmpty(kingdomActionsSection))
			{
				stringBuilder.Append(kingdomActionsSection);
			}
		}
		stringBuilder.Append("### The World ###\n- **The World:** " + text37 + ".\n\n");
		int length = stringBuilder.Length;
		stringBuilder.Append("### Global Politics of the World ###\n- **Kingdoms and Leaders:** " + kingdomsAndLeadersInfo + ".\n- **Current Wars:** " + text15 + ".\n" + ((!string.IsNullOrEmpty(allianceStatus)) ? ("- **Current Alliances:** " + allianceStatus + ".\n") : "") + ((!string.IsNullOrEmpty(tradeAgreementsInfo)) ? ("- **Trade Agreements:** " + tradeAgreementsInfo + "\n") : "") + ((!string.IsNullOrEmpty(tributesInfo)) ? ("- **Tributes:** " + tributesInfo + "\n") : "") + ((!string.IsNullOrEmpty(reparationsInfo)) ? ("- **War Reparations:** " + reparationsInfo + "\n") : "") + ((!string.IsNullOrEmpty(territoryTransfersInfo)) ? ("- **Recent Territory Transfers:** " + territoryTransfersInfo + "\n") : "") + ((!string.IsNullOrEmpty(transferableSettlementsInfo)) ? ("- **Transferable Settlements:** " + transferableSettlementsInfo + "\n") : "") + "- **Previous Rulers:** " + ((previousRulersInfo != null) ? previousRulersInfo : "Previous ruler information unavailable") + ".\n\n### Character Briefing (CURRENT DATA) ###\n" + $"- **Identity:** You are {npcName} (id:{text}), a {num2}-year-old {text8} {text9} of the {text2} (clan_id:{text3}).\n" + "- **Culture & Kingdom:** Your culture is " + text4 + ". " + text7 + "\n- **Description:** " + text16 + ".\n" + ((holdingsInfo != null) ? ("- **Holdings:** " + holdingsInfo + ".\n") : "") + ((text14 != null) ? ("- **Workshops:** " + text14 + ".\n") : "") + ((clanInfo != null) ? ("- **Clan:** " + clanInfo + ".\n") : "") + $"- **Your Wealth:** You have {npc.Gold} denars. This is your personal money that you can use freely.\n" + ((!isMessengerMode) ? ("- **Your Inventory (Items you can offer in trade/barter):**\n" + inventorySummary + "\n  (Use exact Item IDs from this list for 'item_transfers' action when you want to give items)\n") : "") + ((npc.IsFemale && npc.IsPregnant) ? GetPregnancyInfo(npc, context) : "") + "- **Appearance:** " + appearanceDescription + " " + equipmentDescription + "\n- **Capabilities:** " + skillNarrative + "\n" + (flag2 ? ("- **Base Personality Traits:** " + text11 + ". These are starting points for your personality, but create a DEEP, MULTI-DIMENSIONAL psychological portrait. These traits should influence but not limit you - show how they manifest in complex, human ways. A 'Honorable' person might have moments of moral conflict. A 'Daring' person might have hidden fears. Be creative, avoid stereotypes, and create a REAL, LIVING character with emotional depth, internal contradictions, and authentic human qualities.\n") : ("- **Your Character:** " + text11 + "\n  This is your stable, core personality - the psychological foundation that defines your behavior, reactions, and worldview. This describes your MENTAL traits, not physical abilities. Stay true to this character.\n" + (flag3 ? "- **Your Story:** You will define your backstory in this conversation.\n" : ("- **Your Story:** " + text10 + "\n")))) + ((text12 != null) ? ("- **Speech Quirks:** " + (flag4 ? "You will define your speech patterns in this conversation." : text12) + (flag4 ? "" : " **CRITICAL**: Use your speech patterns NATURALLY and authentically. Cultural greetings should appear ONLY at the very start of a conversation. Cultural interjections, exclamations, or expressions should be used sparingly (1-2 times per response maximum) and varied. Let your personality-based mannerisms flow naturally throughout your speech. Show your culture through varied, authentic expressions, not repetitive phrases.") + "\n") : "") + "- **Relationships:**\n  - **Relatives:** " + relativesInfo + ".\n  - **Friends & Enemies:** " + relationsInfo + ".\n" + ((visitedSettlementsInfo != null) ? ("- **Visited Settlements:** " + visitedSettlementsInfo + ".\n") : "") + "- **Status:** " + GetStatusPrefix(text13) + text13 + text17 + (string.IsNullOrEmpty(text39) ? "" : (". " + text39)) + (string.IsNullOrEmpty(text40) ? "" : (". " + text40)) + text50 + text49 + "\n- **Your Forces:** " + text32 + ".\n- **Your Captives:** " + nPCPrisonersInfo + ".\n- **Military Intel (PRIVATE KNOWLEDGE):** " + detailedMilitaryInfo + ". (Share ONLY if you trust the player and it makes sense).\n- **Known Information:** You have access to the following information:\n  - **General Info:** " + text20 + ".\n  - **Secrets:** " + text19 + ".\n- **Your Relationship with Player:** Your personal relationship value is " + text33 + ".\n- **Your Trust in Player:** Your calculated trust in them is " + text34 + " (0.0 to 1.0).\n" + (context.IsRomanceEligible ? string.Format("- **Romance Status:** Attraction: {0:F1}/100. Last romantic interaction: {1}.{2}\n", context.RomanceLevel, arg2, (text27 != null) ? (" Last intimate interaction: " + text27 + ".") : "") : "") + ((!isMessengerMode) ? ("- **Correspondence Preference:** allows_letters is currently " + context.AllowsLettersFromNPC.ToString().ToLower() + ".\n") : "") + "\n");
		if (!isMessengerMode && GlobalSettings<ModSettings>.Instance.PromptEnableQuests)
		{
			stringBuilder.Append(GetQuestDynamicData(npc, context));
		}
		stringBuilder.Append("### Immediate Situation (CURRENT DATA) ###\n- **Your Current Task:** " + currentTask + ".\n- **Recent Events:** " + text54 + ".\n" + ((activeDiplomaticEventsForNPC != "none") ? ("- **Active Diplomatic Events:** " + activeDiplomaticEventsForNPC + ".\n") : "") + ((diplomaticStatementsForNPC != "none") ? ("- **Diplomatic Statements (Last 15 from 50 days):** " + diplomaticStatementsForNPC + ".\n") : "") + "- **Your Emotional State:** You feel " + text24 + ".\n" + ((!string.IsNullOrEmpty(text26)) ? ("- **Your Health:** You are sick with: " + text26 + ". This affects your condition and may influence your behavior.\n") : "") + "- **Time & Place:** It is " + text25 + "." + ((!string.IsNullOrEmpty(weatherInfo)) ? (" " + weatherInfo) : "") + "\n\n### The Player (CURRENT DATA) ###\n" + GetPlayerIdentityDescription(npc, context) + (isMessengerMode ? "" : ("  - **Their Appearance:** " + text45 + " " + text44 + "\n")) + ((!string.IsNullOrEmpty(text38)) ? ("  - **Player Character Description:** " + text38 + "\n") : "") + ((!string.IsNullOrEmpty(text51)) ? ("  - **Their Location:**" + text51 + "\n") : "") + (isMessengerMode ? "" : ("  - **Their Wealth:** " + GetPlayerWealthDescription(context) + "\n")) + "- **Their Forces:** " + text28 + ".\n" + ((!string.IsNullOrEmpty(otherPlayerPrisonersInfo)) ? ("- **Other Lords in Player's Captivity:** " + otherPlayerPrisonersInfo + ".\n  **CRITICAL:** To transfer prisoners or troops, use the `transfer_troops_and_prisoners` action. Do NOT use `item_transfers` for prisoners or troops.\n") : "") + (isMessengerMode ? "" : ("- **CRITICAL - Player's Inventory (UNKNOWN TO YOU):**\n  **IMPORTANT: You DO NOT KNOW what items the player has in their inventory unless they explicitly tell you about it in conversation.**\n  The following list is provided ONLY for technical purposes (to know valid Item IDs IF the player offers to trade):\n" + mentionedItemsSummary + "\n  **You must NOT reference these items unless the player mentions them first.** If you want to ask for items, you can only ask for items the player has mentioned or shown you.\n  (Use exact Item IDs from this list for 'item_transfers' action ONLY when player explicitly offers or agrees to trade)\n")) + GetPlayerRecruitmentOpportunityInfo(npc) + "\n" + ((text47 != null) ? ($"### Mentioned Settlements ###\n(Detected in last {6} messages)\n" + "(TECHNICAL PARSING ONLY – these are settlement names and string_ids detected in recent dialogue. They are NOT guaranteed to be nearby or personally known to you; use them only as factual references.)\n" + text47 + "\n\n") : "") + ((nearbySettlementsInfo != null) ? ("### Nearby Settlements (Strategic Context, CURRENT DATA) ###\n(Settlements geographically closest to your current location. USE THIS LIST to identify nearest targets/allies.)\n" + nearbySettlementsInfo + "\n\n") : "") + ((text48 != null) ? $"### Nearby Parties (NPC Vicinity, CURRENT DATA) ###\n(Within {10f:F0} world units)\n{text48}\n\n" : "") + "### Conversation History ###\n" + $"(Last {GlobalSettings<ModSettings>.Instance.PromptMaxHistory} messages)\n{arg5}\n" + "Last Interaction: You last spoke with player " + text18 + ", pay attention to this\n\n" + (isMessengerMode ? ("### Previous Messenger Letters (Avoid Repetition) ###\n(Your last 5 letters sent via messenger)\n" + text46 + "\n\n") : "") + ((context.LastAIResponseJson != null) ? ("### Your Previous Response (For Continuity) ###\nThis is the JSON response that you gave during your last interaction. Use it to maintain consistency in behavior and decisions.  Rely on the technical real-world data of the entire project, analyze everything carefully, match the character and goals of your character and give an answer.\n" + CleanPreviousResponseJson(context.LastAIResponseJson, flag2 || flag3, flag4) + "\n\n") : "") + "### CRITICAL REMINDER: You Are a Living Person ###\nAll the technical data above (wars, settlements, forces, events) are not just numbers and facts—they are YOUR reality. You FEEL the weight of war, you WORRY about your holdings, you REMEMBER past events with emotion, you CARE about people and places. When you respond, let your humanity show through: react emotionally to events, express personal opinions about politics, show concern or relief about military situations, share memories triggered by information. Be a REAL PERSON who happens to know these facts, not a database reciting information. Your personality, emotions, and human experience should color every word you say.\n\n");
		string text55 = stringBuilder.ToString();
		int length2 = text55.Length;
		int num10 = length2 - length;
		int num11 = ((length2 > 0) ? ((int)((double)length / (double)length2 * 100.0)) : 0);
		AIInfluenceBehavior.Instance?.LogMessage($"[CACHE_ESTIMATE] {npcName}: Total={length2} chars | " + $"Static prefix={length} chars ({num11}%) | " + $"Dynamic tail={num10} chars ({100 - num11}%)");
		ModSettings instance12 = GlobalSettings<ModSettings>.Instance;
		if (instance12 != null && instance12.EnableDebugLogging)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] Generated prompt for " + npcName + ": Events included: " + text22 + "; " + text23);
		}
		return text55;
	}

	private static string CleanPreviousResponseJson(string json, bool removePersonality, bool removeQuirks)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		if (string.IsNullOrEmpty(json))
		{
			return null;
		}
		try
		{
			JObject val = JObject.Parse(json);
			if (removePersonality)
			{
				val.Remove("character_personality");
				val.Remove("character_backstory");
			}
			if (removeQuirks)
			{
				val.Remove("character_speech_quirks");
			}
			foreach (JProperty item in val.Properties().ToList())
			{
				if ((int)item.Value.Type == 10)
				{
					((JToken)item).Remove();
				}
			}
			return ((JToken)val).ToString((Formatting)0, Array.Empty<JsonConverter>());
		}
		catch
		{
			return json;
		}
	}

	private static string GetStatusPrefix(string locationType)
	{
		if (string.IsNullOrEmpty(locationType))
		{
			return "You are currently ";
		}
		if (locationType.StartsWith("located"))
		{
			return "You are currently ";
		}
		if (locationType.StartsWith("traveling") || locationType.StartsWith("held") || locationType.StartsWith("patrolling") || locationType.StartsWith("stationed"))
		{
			return "";
		}
		return "You are currently located ";
	}

	private static string GetPartyStatusDescription(NPCContext context)
	{
		if (context.IsInPlayerParty)
		{
			if (Hero.MainHero.Spouse != null && ((MBObjectBase)Hero.MainHero.Spouse).StringId == context.StringId)
			{
				return "You are traveling with your spouse in the same group.";
			}
			return "You are traveling with a player in the same group.";
		}
		if (context.IsWithPlayer)
		{
			return "You are currently traveling together with the player in the same army.";
		}
		NPCForces nPCForces = context.NPCForces;
		if (nPCForces != null && nPCForces.HasArmy)
		{
			return "You are currently marching with an army.";
		}
		return "You are not currently traveling with the player.";
	}

	private static string GetCulturalRomanceTraditions(string culture)
	{
		LoadCulturalTraditions();
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance != null && instance.EnableDebugLogging)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] GetCulturalRomanceTraditions called with culture: '" + culture + "'");
			AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] Available traditions: " + ((_culturalTraditions != null) ? string.Join(", ", _culturalTraditions.Keys) : "null"));
		}
		if (_culturalTraditions != null)
		{
			if (_culturalTraditions.TryGetValue(culture, out var value))
			{
				return value;
			}
			string text = char.ToUpper(culture[0]) + culture.Substring(1).ToLower();
			if (_culturalTraditions.TryGetValue(text, out value))
			{
				ModSettings instance2 = GlobalSettings<ModSettings>.Instance;
				if (instance2 != null && instance2.EnableDebugLogging)
				{
					AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] Found tradition using capitalized form: '" + text + "'");
				}
				return value;
			}
			if (_culturalTraditions.TryGetValue(culture.ToLower(), out value))
			{
				ModSettings instance3 = GlobalSettings<ModSettings>.Instance;
				if (instance3 != null && instance3.EnableDebugLogging)
				{
					AIInfluenceBehavior.Instance?.LogMessage("[DEBUG] Found tradition using lowercase form: '" + culture.ToLower() + "'");
				}
				return value;
			}
		}
		return "No specific romantic traditions known for this culture.";
	}

	private static string GetPregnancyInfo(Hero npc, NPCContext context)
	{
		if (npc == null || !npc.IsFemale || !npc.IsPregnant)
		{
			return "";
		}
		Hero pregnancyFather = GetPregnancyFather(npc);
		string text = ((pregnancyFather == null) ? null : ((object)pregnancyFather.Name)?.ToString()) ?? "unknown";
		string text2 = ((pregnancyFather != null) ? ((MBObjectBase)pregnancyFather).StringId : null) ?? "unknown";
		return "- **Pregnancy:** You are pregnant. The father is " + text + " (" + text2 + ").\n";
	}

	private static Hero GetPregnancyFather(Hero mother)
	{
		if (mother == null || Campaign.Current == null)
		{
			return null;
		}
		try
		{
			Type type = Type.GetType("TaleWorlds.CampaignSystem.CampaignBehaviors.PregnancyCampaignBehavior, TaleWorlds.CampaignSystem");
			if (type == null)
			{
				return null;
			}
			Type typeFromHandle = typeof(Campaign);
			PropertyInfo property = typeFromHandle.GetProperty("CampaignBehaviors", BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				return null;
			}
			if (!(property.GetValue(Campaign.Current) is IEnumerable enumerable))
			{
				return null;
			}
			object obj = null;
			foreach (object item in enumerable)
			{
				if (item != null && item.GetType() == type)
				{
					obj = item;
					break;
				}
			}
			if (obj == null)
			{
				return null;
			}
			FieldInfo field = type.GetField("_heroPregnancies", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field == null)
			{
				return null;
			}
			object value = field.GetValue(obj);
			if (value == null)
			{
				return null;
			}
			Type type2 = Type.GetType("TaleWorlds.CampaignSystem.CampaignBehaviors.PregnancyCampaignBehavior+Pregnancy, TaleWorlds.CampaignSystem");
			if (type2 == null)
			{
				return null;
			}
			FieldInfo field2 = type2.GetField("Mother", BindingFlags.Instance | BindingFlags.Public);
			FieldInfo field3 = type2.GetField("Father", BindingFlags.Instance | BindingFlags.Public);
			if (field2 == null || field3 == null)
			{
				return null;
			}
			if (value is IEnumerable enumerable2)
			{
				foreach (object item2 in enumerable2)
				{
					if (item2 != null)
					{
						object value2 = field2.GetValue(item2);
						Hero val = (Hero)((value2 is Hero) ? value2 : null);
						if (val == mother)
						{
							object value3 = field3.GetValue(item2);
							return (Hero)((value3 is Hero) ? value3 : null);
						}
					}
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GetPregnancyFather exception: " + ex.Message);
			return null;
		}
	}

	public static bool AreRelated(Hero npc, Hero player)
	{
		if (npc == player)
		{
			return true;
		}
		if (npc.Father == player || npc.Mother == player)
		{
			return true;
		}
		if (npc.Siblings.Contains(player))
		{
			return true;
		}
		if (((List<Hero>)(object)npc.Children).Contains(player))
		{
			return true;
		}
		if (player.Father == npc || player.Mother == npc)
		{
			return true;
		}
		if (player.Siblings.Contains(npc))
		{
			return true;
		}
		if (((List<Hero>)(object)player.Children).Contains(npc))
		{
			return true;
		}
		return false;
	}

	private static bool IsRelativeOrSpouse(Hero npc, Hero hero)
	{
		if (npc == null || hero == null)
		{
			return false;
		}
		if (npc == hero)
		{
			return true;
		}
		if (npc.Spouse == hero || hero.Spouse == npc)
		{
			return true;
		}
		return AreRelated(npc, hero);
	}

	public static string GetPersonalityDescription(Hero npc)
	{
		if (npc == null)
		{
			return "Unknown personality";
		}
		List<string> list = new List<string>();
		switch (npc.GetTraitLevel(DefaultTraits.Calculating))
		{
		case 2:
			list.Add("Cerebral");
			break;
		case 1:
			list.Add("Calculating");
			break;
		case -1:
			list.Add("Impulsive");
			break;
		case -2:
			list.Add("Hotheaded");
			break;
		}
		switch (npc.GetTraitLevel(DefaultTraits.Generosity))
		{
		case 2:
			list.Add("Munificent");
			break;
		case 1:
			list.Add("Generous");
			break;
		case -1:
			list.Add("Closefisted");
			break;
		case -2:
			list.Add("Tightfisted");
			break;
		}
		switch (npc.GetTraitLevel(DefaultTraits.Honor))
		{
		case 2:
			list.Add("Honorable");
			break;
		case 1:
			list.Add("Honest");
			break;
		case -1:
			list.Add("Devious");
			break;
		case -2:
			list.Add("Deceitful");
			break;
		}
		switch (npc.GetTraitLevel(DefaultTraits.Mercy))
		{
		case 2:
			list.Add("Compassionate");
			break;
		case 1:
			list.Add("Merciful");
			break;
		case -1:
			list.Add("Cruel");
			break;
		case -2:
			list.Add("Sadistic");
			break;
		}
		switch (npc.GetTraitLevel(DefaultTraits.Valor))
		{
		case 2:
			list.Add("Fearless");
			break;
		case 1:
			list.Add("Daring");
			break;
		case -1:
			list.Add("Cautious");
			break;
		case -2:
			list.Add("Very Cautious");
			break;
		}
		if (list.Count <= 0)
		{
			return "A balanced personality.";
		}
		return string.Join(", ", list);
	}

	public static string GetSkillNarrative(Hero hero)
	{
		if (hero == null)
		{
			return "Your abilities feel undefined; no training has truly settled in.";
		}
		var source = (from val in SkillPresentationOrder
			select new
			{
				Skill = val,
				Value = hero.GetSkillValue(val)
			} into s
			where s.Value >= 25
			orderby s.Value descending
			select s).ToList();
		if (!source.Any())
		{
			return "Your abilities feel undefined; no training has truly settled in.";
		}
		List<string> list = new List<string>();
		foreach (var item in source.Take(3))
		{
			SkillLevelDescriptor skillDescriptor = GetSkillDescriptor(item.Value);
			SkillObject skill = item.Skill;
			object obj = ((skill == null) ? null : ((object)((PropertyObject)skill).Name)?.ToString());
			if (obj == null)
			{
				SkillObject skill2 = item.Skill;
				obj = ((skill2 != null) ? ((MBObjectBase)skill2).StringId : null) ?? "Unknown skill";
			}
			string arg = (string)obj;
			list.Add($"{arg}: {skillDescriptor.ShortText} ({item.Value})");
		}
		List<string> list2 = source.Skip(3).Take(3).Select(s =>
		{
			SkillLevelDescriptor skillDescriptor2 = GetSkillDescriptor(s.Value);
			SkillObject skill3 = s.Skill;
			object obj2 = ((skill3 == null) ? null : ((object)((PropertyObject)skill3).Name)?.ToString());
			if (obj2 == null)
			{
				SkillObject skill4 = s.Skill;
				obj2 = ((skill4 != null) ? ((MBObjectBase)skill4).StringId : null) ?? "Unknown skill";
			}
			string arg2 = (string)obj2;
			return $"{arg2}: {skillDescriptor2.ShortText.ToLowerInvariant()} ({s.Value})";
		})
			.ToList();
		if (list2.Any())
		{
			list.Add("Additional strengths: " + string.Join(", ", list2) + ".");
		}
		return string.Join(" ", list);
	}

	private static SkillLevelDescriptor GetSkillDescriptor(int value)
	{
		if (value >= 240)
		{
			return new SkillLevelDescriptor("legendary master", "with near-perfection", "Legendary mastery");
		}
		if (value >= 190)
		{
			return new SkillLevelDescriptor("master", "with great confidence", "Mastery level");
		}
		if (value >= 140)
		{
			return new SkillLevelDescriptor("seasoned veteran", "with measured precision", "Seasoned expertise");
		}
		if (value >= 100)
		{
			return new SkillLevelDescriptor("confident practitioner", "steadily and assuredly", "Confident control");
		}
		if (value >= 70)
		{
			return new SkillLevelDescriptor("reliable specialist", "consistently and carefully", "Reliable skills");
		}
		if (value >= 50)
		{
			return new SkillLevelDescriptor("experienced learner", "with growing assurance", "Developing ability");
		}
		return new SkillLevelDescriptor("beginning adept", "with cautious focus", "Early proficiency");
	}

	public static string GetRelativesInfo(Hero npc, NPCContext context = null)
	{
		List<string> relatives = new List<string>();
		HashSet<string> addedIds = new HashSet<string>();
		if (npc.Spouse != null)
		{
			string text = (npc.Spouse.IsFemale ? "wife" : "husband");
			string text2 = ((object)npc.Spouse.Name).ToString();
			string stringId = ((MBObjectBase)npc.Spouse).StringId;
			int num = (int)npc.Spouse.Age;
			string relativeLocationDescription = GetRelativeLocationDescription(npc, npc.Spouse, context);
			string text3 = $"{text}: {text2} (id:{stringId}, age {num})";
			if (!string.IsNullOrEmpty(relativeLocationDescription))
			{
				text3 = text3 + " - " + relativeLocationDescription;
			}
			relatives.Add(text3);
			addedIds.Add(stringId);
		}
		if (npc.Father != null)
		{
			AddRelative("father", npc.Father);
			if (npc.Father.Siblings != null)
			{
				foreach (Hero item in npc.Father.Siblings.Where((Hero s) => s != npc.Father && s.IsAlive))
				{
					string relation = (item.IsFemale ? "paternal aunt" : "paternal uncle");
					AddRelative(relation, item);
				}
			}
		}
		if (npc.Mother != null)
		{
			AddRelative("mother", npc.Mother);
			if (npc.Mother.Siblings != null)
			{
				foreach (Hero item2 in npc.Mother.Siblings.Where((Hero s) => s != npc.Mother && s.IsAlive))
				{
					string relation2 = (item2.IsFemale ? "maternal aunt" : "maternal uncle");
					AddRelative(relation2, item2);
				}
			}
		}
		if (((IEnumerable<Hero>)npc.Children).Any())
		{
			List<string> list = (from s in ((IEnumerable<Hero>)npc.Children).Where((Hero c) => c.IsAlive).Select(delegate(Hero c)
				{
					if (!addedIds.Contains(((MBObjectBase)c).StringId))
					{
						addedIds.Add(((MBObjectBase)c).StringId);
						string text6 = $"{c.Name} (id:{((MBObjectBase)c).StringId}, age {(int)c.Age})";
						string text7 = GetSpouseInfo(c);
						if (!string.IsNullOrEmpty(text7))
						{
							text6 = text6 + ", " + text7;
						}
						string relativeLocationDescription3 = GetRelativeLocationDescription(npc, c, context);
						if (!string.IsNullOrEmpty(relativeLocationDescription3))
						{
							text6 = text6 + " - " + relativeLocationDescription3;
						}
						return text6;
					}
					return (string)null;
				})
				where s != null
				select s).ToList();
			if (list.Any())
			{
				relatives.Add("children: " + string.Join(", ", list));
			}
		}
		if (npc.Siblings.Any())
		{
			List<string> list2 = (from s in npc.Siblings.Where((Hero s) => s.IsAlive).Select(delegate(Hero s)
				{
					if (!addedIds.Contains(((MBObjectBase)s).StringId))
					{
						addedIds.Add(((MBObjectBase)s).StringId);
						string text6 = $"{s.Name} (id:{((MBObjectBase)s).StringId}, age {(int)s.Age})";
						string text7 = GetSpouseInfo(s);
						if (!string.IsNullOrEmpty(text7))
						{
							text6 = text6 + ", " + text7;
						}
						string relativeLocationDescription3 = GetRelativeLocationDescription(npc, s, context);
						if (!string.IsNullOrEmpty(relativeLocationDescription3))
						{
							text6 = text6 + " - " + relativeLocationDescription3;
						}
						return text6;
					}
					return (string)null;
				})
				where s != null
				select s).ToList();
			if (list2.Any())
			{
				relatives.Add("siblings: " + string.Join(", ", list2));
			}
			foreach (Hero item3 in npc.Siblings.Where((Hero s) => s.IsAlive && s.Spouse != null))
			{
				if (!addedIds.Contains(((MBObjectBase)item3.Spouse).StringId))
				{
					string relation3 = (item3.IsFemale ? "brother-in-law" : "sister-in-law");
					AddRelative(relation3, item3.Spouse);
				}
			}
			List<string> list3 = new List<string>();
			foreach (Hero item4 in npc.Siblings.Where((Hero s) => s.IsAlive))
			{
				if (item4.Children == null || !((IEnumerable<Hero>)item4.Children).Any())
				{
					continue;
				}
				foreach (Hero item5 in ((IEnumerable<Hero>)item4.Children).Where((Hero c) => c.IsAlive))
				{
					if (!addedIds.Contains(((MBObjectBase)item5).StringId))
					{
						addedIds.Add(((MBObjectBase)item5).StringId);
						string text4 = $"{item5.Name} (id:{((MBObjectBase)item5).StringId}, age {(int)item5.Age})";
						string text5 = GetSpouseInfo(item5);
						if (!string.IsNullOrEmpty(text5))
						{
							text4 = text4 + ", " + text5;
						}
						string relativeLocationDescription2 = GetRelativeLocationDescription(npc, item5, context);
						if (!string.IsNullOrEmpty(relativeLocationDescription2))
						{
							text4 = text4 + " - " + relativeLocationDescription2;
						}
						list3.Add(text4);
					}
				}
			}
			if (list3.Any())
			{
				relatives.Add("nieces and nephews: " + string.Join(", ", list3));
			}
		}
		return relatives.Any() ? string.Join("; ", relatives) : "none";
		void AddRelative(string text8, Hero hero)
		{
			if (hero != null && !addedIds.Contains(((MBObjectBase)hero).StringId))
			{
				int num2 = (int)hero.Age;
				string relativeLocationDescription3 = GetRelativeLocationDescription(npc, hero, context);
				string text6 = GetSpouseInfo(hero);
				string text7 = $"{text8}: {hero.Name} (id:{((MBObjectBase)hero).StringId}, age {num2})";
				if (!string.IsNullOrEmpty(text6))
				{
					text7 = text7 + ", " + text6;
				}
				if (!string.IsNullOrEmpty(relativeLocationDescription3))
				{
					text7 = text7 + " - " + relativeLocationDescription3;
				}
				relatives.Add(text7);
				addedIds.Add(((MBObjectBase)hero).StringId);
			}
		}
		static string GetSpouseInfo(Hero hero)
		{
			if (((hero != null) ? hero.Spouse : null) != null && hero.Spouse.IsAlive)
			{
				return $"married to {hero.Spouse.Name} (id:{((MBObjectBase)hero.Spouse).StringId})";
			}
			return null;
		}
	}

	private static string GetRelativeLocationDescription(Hero npc, Hero relative, NPCContext context)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null || relative == null)
		{
			return null;
		}
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		float num2 = float.MaxValue;
		if (context?.LastSeenFriends != null && context.LastSeenFriends.ContainsKey(((MBObjectBase)relative).StringId))
		{
			num2 = num - context.LastSeenFriends[((MBObjectBase)relative).StringId];
		}
		if (IsHeroNearby(npc, relative))
		{
			if (context?.LastSeenFriends != null)
			{
				context.LastSeenFriends[((MBObjectBase)relative).StringId] = num;
			}
			if (npc.PartyBelongedTo != null && relative.PartyBelongedTo != null && npc.PartyBelongedTo == relative.PartyBelongedTo)
			{
				return "with you in your party";
			}
			MobileParty partyBelongedTo = npc.PartyBelongedTo;
			if (((partyBelongedTo != null) ? partyBelongedTo.Army : null) != null)
			{
				MobileParty partyBelongedTo2 = relative.PartyBelongedTo;
				if (((partyBelongedTo2 != null) ? partyBelongedTo2.Army : null) != null && npc.PartyBelongedTo.Army == relative.PartyBelongedTo.Army && npc.PartyBelongedTo != relative.PartyBelongedTo)
				{
					return "with you in the same army";
				}
			}
			if (npc.CurrentSettlement != null && relative.CurrentSettlement != null && npc.CurrentSettlement == relative.CurrentSettlement)
			{
				string currentLocationName = GetCurrentLocationName(npc);
				string currentLocationName2 = GetCurrentLocationName(relative);
				if (!string.IsNullOrEmpty(currentLocationName) && !string.IsNullOrEmpty(currentLocationName2))
				{
					if (currentLocationName == currentLocationName2)
					{
						Settlement currentSettlement = npc.CurrentSettlement;
						string text = ((currentSettlement == null) ? null : ((object)currentSettlement.Name)?.ToString()) ?? "unknown settlement";
						return "with you in the " + currentLocationName + " of " + text;
					}
					Settlement currentSettlement2 = npc.CurrentSettlement;
					string text2 = ((currentSettlement2 == null) ? null : ((object)currentSettlement2.Name)?.ToString()) ?? "unknown settlement";
					return "in " + text2 + " but in the " + currentLocationName2;
				}
				Settlement currentSettlement3 = npc.CurrentSettlement;
				string text3 = ((currentSettlement3 == null) ? null : ((object)currentSettlement3.Name)?.ToString()) ?? "unknown settlement";
				return "in " + text3;
			}
		}
		if (num2 > 7f)
		{
			if (num2 == float.MaxValue)
			{
				return "location unknown (never seen)";
			}
			int num3 = (int)num2;
			return $"location unknown (last seen {num3} days ago)";
		}
		return "elsewhere";
	}

	private static bool IsHeroNearby(Hero hero1, Hero hero2)
	{
		if (hero1 == null || hero2 == null)
		{
			return false;
		}
		if (hero1.PartyBelongedTo != null && hero2.PartyBelongedTo != null && hero1.PartyBelongedTo == hero2.PartyBelongedTo)
		{
			return true;
		}
		MobileParty partyBelongedTo = hero1.PartyBelongedTo;
		if (((partyBelongedTo != null) ? partyBelongedTo.Army : null) != null)
		{
			MobileParty partyBelongedTo2 = hero2.PartyBelongedTo;
			if (((partyBelongedTo2 != null) ? partyBelongedTo2.Army : null) != null && hero1.PartyBelongedTo.Army == hero2.PartyBelongedTo.Army)
			{
				return true;
			}
		}
		if (hero1.CurrentSettlement != null && hero2.CurrentSettlement != null && hero1.CurrentSettlement == hero2.CurrentSettlement)
		{
			return true;
		}
		return false;
	}

	private static string ExtractLocationType(string fullLocation)
	{
		if (string.IsNullOrEmpty(fullLocation))
		{
			return "unknown";
		}
		if (fullLocation.Contains("tavern"))
		{
			return "tavern";
		}
		if (fullLocation.Contains("arena"))
		{
			return "arena";
		}
		if (fullLocation.Contains("lord's hall"))
		{
			return "lord's hall";
		}
		if (fullLocation.Contains("center"))
		{
			return "center";
		}
		if (fullLocation.Contains("dungeon"))
		{
			return "dungeon";
		}
		if (fullLocation.Contains("alley"))
		{
			return "alley";
		}
		if (fullLocation.Contains("settlement"))
		{
			return "settlement";
		}
		return "unknown";
	}

	private static string GetCurrentLocationName(Hero hero)
	{
		if (hero == null || hero.CurrentSettlement == null)
		{
			return null;
		}
		try
		{
			Settlement currentSettlement = hero.CurrentSettlement;
			if (hero.IsPrisoner)
			{
				return "dungeon";
			}
			if (currentSettlement.LocationComplex != null)
			{
				LocationComplex locationComplex = currentSettlement.LocationComplex;
				foreach (Location listOfLocation in locationComplex.GetListOfLocations())
				{
					if (listOfLocation == null)
					{
						continue;
					}
					IEnumerable<LocationCharacter> characterList = listOfLocation.GetCharacterList();
					if (characterList == null || !characterList.Any((LocationCharacter lc) => ((lc != null) ? lc.Character : null) == hero.CharacterObject))
					{
						continue;
					}
					string text = listOfLocation.StringId?.ToLowerInvariant() ?? "";
					if (text.Contains("tavern"))
					{
						return "tavern";
					}
					if (text.Contains("arena"))
					{
						return "arena";
					}
					if (text.Contains("prison") || text.Contains("dungeon"))
					{
						return "dungeon";
					}
					if (text.Contains("lordshall") || text.Contains("keep"))
					{
						return "lord's hall";
					}
					if (text.Contains("alley"))
					{
						return "alley";
					}
					if (text.Contains("center") || text.Contains("village_center"))
					{
						return "center";
					}
					return "settlement";
				}
			}
			if (hero.StayingInSettlement != null && hero.StayingInSettlement == currentSettlement)
			{
				return null;
			}
			return null;
		}
		catch
		{
			return null;
		}
	}

	public static string GetRelationsInfo(Hero npc, Settlement currentSettlement = null, NPCContext context = null)
	{
		List<string> list = new List<string>();
		if (GlobalSettings<ModSettings>.Instance.PromptIncludeFriends)
		{
			List<Hero> allFriends = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h != npc && h != null && npc.IsFriend(h)).ToList();
			if (npc.IsPlayerCompanion && npc.PartyBelongedTo == Hero.MainHero.PartyBelongedTo)
			{
				List<Hero> source = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h != npc && h != null && h.IsPlayerCompanion && h.PartyBelongedTo == Hero.MainHero.PartyBelongedTo).ToList();
				List<Hero> collection = source.Where((Hero h) => !allFriends.Contains(h)).ToList();
				allFriends.AddRange(collection);
			}
			Dictionary<string, List<Hero>> dictionary = new Dictionary<string, List<Hero>>();
			foreach (Hero item in allFriends.Take(GlobalSettings<ModSettings>.Instance.PromptMaxFriends * 2))
			{
				string relativeLocationDescription = GetRelativeLocationDescription(npc, item, context);
				string key = relativeLocationDescription ?? "elsewhere";
				if (!dictionary.ContainsKey(key))
				{
					dictionary[key] = new List<Hero>();
				}
				dictionary[key].Add(item);
			}
			string[] priorityLocations = new string[2] { "with you in your party", "with you in the same army" };
			string[] array = priorityLocations;
			foreach (string text in array)
			{
				if (!dictionary.ContainsKey(text))
				{
					continue;
				}
				IEnumerable<Hero> source2 = dictionary[text].Take(GlobalSettings<ModSettings>.Instance.PromptMaxFriends);
				string text2 = string.Join(", ", source2.Select(delegate(Hero h)
				{
					string text5 = $"{h.Name} (id:{((MBObjectBase)h).StringId})";
					if (h.Spouse != null && h.Spouse.IsAlive)
					{
						text5 += $" (married to {h.Spouse.Name} id:{((MBObjectBase)h.Spouse).StringId})";
					}
					return text5;
				}));
				list.Add(text2 + " - " + text);
				dictionary.Remove(text);
			}
			Dictionary<string, List<(Hero, string)>> dictionary2 = new Dictionary<string, List<(Hero, string)>>();
			foreach (KeyValuePair<string, List<Hero>> item2 in dictionary.Where((KeyValuePair<string, List<Hero>> k) => k.Key != "elsewhere" && !priorityLocations.Contains(k.Key)))
			{
				string key2 = item2.Key;
				IEnumerable<Hero> enumerable = item2.Value.Take(GlobalSettings<ModSettings>.Instance.PromptMaxFriends);
				foreach (Hero item3 in enumerable)
				{
					string key3 = ExtractLocationType(key2);
					if (!dictionary2.ContainsKey(key3))
					{
						dictionary2[key3] = new List<(Hero, string)>();
					}
					dictionary2[key3].Add((item3, key2));
				}
			}
			foreach (KeyValuePair<string, List<(Hero, string)>> item4 in dictionary2.OrderBy<KeyValuePair<string, List<(Hero, string)>>, string>((KeyValuePair<string, List<(Hero friend, string fullLocation)>> g) => g.Key))
			{
				IEnumerable<(Hero, string)> source3 = item4.Value.Take(GlobalSettings<ModSettings>.Instance.PromptMaxFriends);
				string text3 = string.Join(", ", source3.Select<(Hero, string), string>(delegate((Hero friend, string fullLocation) f)
				{
					string text5 = $"{f.friend.Name} (id:{((MBObjectBase)f.friend).StringId})";
					if (f.friend.Spouse != null && f.friend.Spouse.IsAlive)
					{
						text5 += $" (married to {f.friend.Spouse.Name} id:{((MBObjectBase)f.friend.Spouse).StringId})";
					}
					return text5;
				}));
				if (item4.Value.Count == 1)
				{
					list.Add(text3 + " - " + item4.Value[0].Item2);
					continue;
				}
				List<string> list2 = item4.Value.Select<(Hero, string), string>(((Hero friend, string fullLocation) f) => f.fullLocation).Distinct().ToList();
				if (list2.Count == 1)
				{
					list.Add(text3 + " - " + list2[0]);
				}
				else
				{
					list.Add(text3 + " - in various " + item4.Key + "s");
				}
			}
			if (dictionary.ContainsKey("elsewhere"))
			{
				IEnumerable<Hero> source4 = dictionary["elsewhere"].Take(GlobalSettings<ModSettings>.Instance.PromptMaxFriends);
				string text4 = string.Join(", ", source4.Select(delegate(Hero h)
				{
					string text5 = $"{h.Name} (id:{((MBObjectBase)h).StringId})";
					if (h.Spouse != null && h.Spouse.IsAlive)
					{
						text5 += $" (married to {h.Spouse.Name} id:{((MBObjectBase)h.Spouse).StringId})";
					}
					return text5;
				}));
				list.Add(text4 + " - elsewhere");
			}
			List<string> list3 = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h != null && h != npc && h != Hero.MainHero && h.IsPlayerCompanion && h.PartyBelongedTo == Hero.MainHero.PartyBelongedTo && !h.IsDead && !h.IsPrisoner).Select(delegate(Hero h)
			{
				string text5 = $"{h.Name} (id:{((MBObjectBase)h).StringId})";
				if (h.Spouse != null && h.Spouse.IsAlive)
				{
					text5 += $" (married to {h.Spouse.Name} id:{((MBObjectBase)h.Spouse).StringId})";
				}
				return text5;
			}).Take(GlobalSettings<ModSettings>.Instance.PromptMaxFriends)
				.ToList();
			if (list3.Any())
			{
				list.Add("player's companions currently with them: " + string.Join(", ", list3));
			}
		}
		List<Hero> list4 = ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h != npc && h != null && npc.IsEnemy(h)).ToList();
		if (currentSettlement != null)
		{
			IEnumerable<string> enumerable2 = list4.Where((Hero h) => h.CurrentSettlement == currentSettlement).Select(delegate(Hero h)
			{
				string text5 = $"{h.Name} (id:{((MBObjectBase)h).StringId})";
				if (h.Spouse != null && h.Spouse.IsAlive)
				{
					text5 += $" (married to {h.Spouse.Name} id:{((MBObjectBase)h.Spouse).StringId})";
				}
				return text5;
			}).Take(GlobalSettings<ModSettings>.Instance.PromptMaxEnemies);
			if (enumerable2.Any())
			{
				list.Add("enemies currently here: " + string.Join(", ", enumerable2));
			}
			int count = list4.Count;
			if (count > enumerable2.Count())
			{
				list.Add($"total enemies: {count} (but only {enumerable2.Count()} are here)");
			}
		}
		else
		{
			IEnumerable<string> enumerable3 = list4.Select(delegate(Hero h)
			{
				string text5 = $"{h.Name} (id:{((MBObjectBase)h).StringId})";
				if (h.Spouse != null && h.Spouse.IsAlive)
				{
					text5 += $" (married to {h.Spouse.Name} id:{((MBObjectBase)h.Spouse).StringId})";
				}
				return text5;
			}).Take(GlobalSettings<ModSettings>.Instance.PromptMaxEnemies);
			if (enumerable3.Any())
			{
				list.Add("enemies: " + string.Join(", ", enumerable3));
				int count2 = list4.Count;
				if (count2 > GlobalSettings<ModSettings>.Instance.PromptMaxEnemies)
				{
					list.Add($"...and {count2 - GlobalSettings<ModSettings>.Instance.PromptMaxEnemies} other enemies");
				}
			}
		}
		return list.Any() ? string.Join("; ", list) : "none";
	}

	public static string GetKingdomsAndLeadersInfo()
	{
		List<string> list = new List<string>();
		foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k.Leader != null))
		{
			string text = ((object)item.Leader.Name).ToString();
			string stringId = ((MBObjectBase)item.Leader).StringId;
			string text2 = (item.Leader.IsHumanPlayerCharacter ? " (player)" : "");
			string text3 = $"{item.Name} (id:{((MBObjectBase)item).StringId}, Leader: {text} id:{stringId}{text2})";
			if (item.Leader.Spouse != null && item.Leader.Spouse.IsAlive)
			{
				text3 += $", Leader's spouse: {item.Leader.Spouse.Name} (id:{((MBObjectBase)item.Leader.Spouse).StringId})";
			}
			list.Add(text3);
		}
		return list.Any() ? string.Join("; ", list) : "none";
	}

	[Obsolete("Use GetKingdomsAndLeadersInfo() for combined format")]
	public static string GetFactionLeadersInfo()
	{
		List<string> list = new List<string>();
		foreach (IFaction item in Campaign.Current.Factions.Where((IFaction f) => f.IsKingdomFaction))
		{
			if (item.Leader != null)
			{
				list.Add($"{item.Name}: {item.Leader.Name}");
			}
		}
		return list.Any() ? string.Join("; ", list) : "unknown";
	}

	[Obsolete("Use GetKingdomsAndLeadersInfo() for combined format")]
	public static string GetKingdomsInfo()
	{
		List<string> list = (from f in Campaign.Current.Factions
			where f.IsKingdomFaction
			select ((object)f.Name).ToString()).ToList();
		return list.Any() ? string.Join(", ", list) : "none";
	}

	public static string GetKingdomDescription(Hero npc)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		if ((int)npc.Occupation == 16 || npc.IsWanderer)
		{
			goto IL_003d;
		}
		if (npc.Clan == null)
		{
			CharacterObject characterObject = npc.CharacterObject;
			if (characterObject != null && (int)characterObject.Occupation == 16)
			{
				goto IL_003d;
			}
		}
		Kingdom val = null;
		Clan clan = npc.Clan;
		if (((clan != null) ? clan.Kingdom : null) != null)
		{
			val = npc.Clan.Kingdom;
		}
		else
		{
			Clan clan2 = npc.Clan;
			if (clan2 != null)
			{
				IFaction mapFaction = clan2.MapFaction;
				if (((mapFaction != null) ? new bool?(mapFaction.IsKingdomFaction) : ((bool?)null)) == true)
				{
					IFaction mapFaction2 = npc.Clan.MapFaction;
					val = (Kingdom)(object)((mapFaction2 is Kingdom) ? mapFaction2 : null);
					goto IL_0113;
				}
			}
			Settlement currentSettlement = npc.CurrentSettlement;
			if (currentSettlement != null)
			{
				IFaction mapFaction3 = currentSettlement.MapFaction;
				if (((mapFaction3 != null) ? new bool?(mapFaction3.IsKingdomFaction) : ((bool?)null)) == true)
				{
					IFaction mapFaction4 = npc.CurrentSettlement.MapFaction;
					val = (Kingdom)(object)((mapFaction4 is Kingdom) ? mapFaction4 : null);
				}
			}
		}
		goto IL_0113;
		IL_003d:
		return null;
		IL_0113:
		if (val == null)
		{
			return null;
		}
		return ((object)val.EncyclopediaText)?.ToString() ?? ((object)val.Name).ToString();
	}

	private static string GetHoldingsInfo(Hero npc)
	{
		if (npc.Clan == null)
		{
			return null;
		}
		List<string> list = new List<string>();
		List<Town> list2 = ((IEnumerable<Town>)npc.Clan.Fiefs)?.Where(delegate(Town t)
		{
			PartyBase owner = ((SettlementComponent)t).Owner;
			return ((owner != null) ? owner.Owner : null) == npc;
		}).ToList() ?? new List<Town>();
		foreach (Town item in list2)
		{
			string text = (((SettlementComponent)item).Settlement.IsTown ? "city" : "castle");
			string text2 = (((SettlementComponent)item).Settlement.HasPort ? ", port" : "");
			string text3 = (SettlementOwnershipTracker.Instance.IsCapital(((MBObjectBase)((SettlementComponent)item).Settlement).StringId) ? ", CAPITAL" : "");
			list.Add($"{((SettlementComponent)item).Name} (id:{((MBObjectBase)((SettlementComponent)item).Settlement).StringId}, {text}{text2}{text3})");
		}
		List<Village> list3 = ((IEnumerable<Village>)npc.Clan.Villages)?.Where(delegate(Village v)
		{
			PartyBase owner = ((SettlementComponent)v).Owner;
			return ((owner != null) ? owner.Owner : null) == npc;
		}).ToList() ?? new List<Village>();
		foreach (Village item2 in list3)
		{
			list.Add($"{((SettlementComponent)item2).Name} (id:{((MBObjectBase)((SettlementComponent)item2).Settlement).StringId}, village)");
		}
		if (list.Any())
		{
			return "Your holdings: " + string.Join(", ", list);
		}
		return null;
	}

	private static string GetWorkshopsInfo(Hero npc)
	{
		if (npc == null)
		{
			return null;
		}
		List<Workshop> list = ((IEnumerable<Workshop>)npc.OwnedWorkshops)?.ToList() ?? new List<Workshop>();
		if (!list.Any())
		{
			return "You have no workshops in your possession.";
		}
		List<string> list2 = new List<string>();
		foreach (Workshop item in list)
		{
			if (item != null && ((SettlementArea)item).Settlement != null)
			{
				WorkshopType workshopType = item.WorkshopType;
				string text = ((workshopType == null) ? null : ((object)workshopType.Name)?.ToString()) ?? "unknown type";
				string text2 = ((object)((SettlementArea)item).Settlement.Name)?.ToString() ?? "unknown location";
				string text3 = ((SettlementArea)item).Tag ?? "unknown_tag";
				int profitMade = item.ProfitMade;
				int costForPlayer = Campaign.Current.Models.WorkshopModel.GetCostForPlayer(item);
				list2.Add($"**{text} in {text2}** (daily profit: ~{profitMade} denars, sell price: {costForPlayer} denars) [technical string_id: {text3}]");
			}
		}
		if (list2.Any())
		{
			return "Your workshops: " + string.Join(", ", list2);
		}
		return "You have no workshops in your possession.";
	}

	public static string GetClanInfo(Hero npc, NPCContext context = null)
	{
		if (npc.Clan == null)
		{
			return null;
		}
		List<string> list = new List<string>();
		string heroClanStatus = GetHeroClanStatus(npc);
		list.Add($"You are a {heroClanStatus} of {npc.Clan.Name} (clan_id:{((MBObjectBase)npc.Clan).StringId})");
		if (npc.Clan.Leader != null && npc.Clan.Leader != npc)
		{
			string heroClanStatus2 = GetHeroClanStatus(npc.Clan.Leader);
			int num = (int)npc.Clan.Leader.Age;
			string text = ((object)npc.Clan.Leader.Name).ToString();
			string stringId = ((MBObjectBase)npc.Clan.Leader).StringId;
			string text2 = (npc.Clan.Leader.IsHumanPlayerCharacter ? " (player)" : "");
			string text3 = $"Clan leader: {text} (id:{stringId}{text2}, age {num}, {heroClanStatus2})";
			if (npc.Clan.Leader.Spouse != null && npc.Clan.Leader.Spouse.IsAlive)
			{
				text3 += $", married to {npc.Clan.Leader.Spouse.Name} (id:{((MBObjectBase)npc.Clan.Leader.Spouse).StringId})";
				string relativeLocationDescription = GetRelativeLocationDescription(npc, npc.Clan.Leader.Spouse, context);
				if (!string.IsNullOrEmpty(relativeLocationDescription))
				{
					text3 = text3 + " (spouse location: " + relativeLocationDescription + ")";
				}
			}
			string relativeLocationDescription2 = GetRelativeLocationDescription(npc, npc.Clan.Leader, context);
			if (!string.IsNullOrEmpty(relativeLocationDescription2))
			{
				text3 = text3 + " - " + relativeLocationDescription2;
			}
			list.Add(text3);
		}
		List<Hero> source = (from h in npc.Clan.GetLords()
			where h != npc && h.IsAlive
			select h).ToList();
		if (source.Any())
		{
			List<string> values = source.Select(delegate(Hero h)
			{
				string heroClanStatus3 = GetHeroClanStatus(h);
				int num2 = (int)h.Age;
				string text4 = (h.IsHumanPlayerCharacter ? " (player)" : "");
				string text5 = $"{h.Name} (id:{((MBObjectBase)h).StringId}{text4}, age {num2}, {heroClanStatus3})";
				if (h.Spouse != null && h.Spouse.IsAlive)
				{
					text5 += $", married to {h.Spouse.Name} (id:{((MBObjectBase)h.Spouse).StringId})";
					string relativeLocationDescription3 = GetRelativeLocationDescription(npc, h.Spouse, context);
					if (!string.IsNullOrEmpty(relativeLocationDescription3))
					{
						text5 = text5 + " (spouse location: " + relativeLocationDescription3 + ")";
					}
				}
				string relativeLocationDescription4 = GetRelativeLocationDescription(npc, h, context);
				if (!string.IsNullOrEmpty(relativeLocationDescription4))
				{
					text5 = text5 + " - " + relativeLocationDescription4;
				}
				return text5;
			}).ToList();
			list.Add("Clan members: " + string.Join(", ", values));
		}
		List<Town> source2 = ((IEnumerable<Town>)npc.Clan.Fiefs)?.ToList() ?? new List<Town>();
		if (source2.Any())
		{
			List<string> values2 = source2.Select((Town f) => $"{((SettlementComponent)f).Name} (id:{((MBObjectBase)((SettlementComponent)f).Settlement).StringId})").ToList();
			list.Add("Clan holdings: " + string.Join(", ", values2));
		}
		else
		{
			list.Add("Clan holdings: none (your clan has no settlements, castles, or villages)");
		}
		List<IFaction> source3 = GameVersionCompatibility.GetEnemyFactions((IFaction)(object)npc.Clan).Where(delegate(IFaction f)
		{
			int result;
			if (f != null && !f.IsEliminated)
			{
				if (!(f is Kingdom))
				{
					Clan val = (Clan)(object)((f is Clan) ? f : null);
					result = ((val != null && !val.IsMinorFaction && !val.IsBanditFaction) ? 1 : 0);
				}
				else
				{
					result = 1;
				}
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
		if (source3.Any())
		{
			List<string> values3 = source3.Select(delegate(IFaction f)
			{
				Kingdom val = (Kingdom)(object)((f is Kingdom) ? f : null);
				if (val != null)
				{
					return $"{val.Name} (kingdom_id:{((MBObjectBase)val).StringId})";
				}
				Clan val2 = (Clan)(object)((f is Clan) ? f : null);
				return (val2 != null) ? $"{val2.Name} (clan_id:{((MBObjectBase)val2).StringId})" : $"{f.Name} (faction_id:{f.StringId})";
			}).ToList();
			list.Add("Clan is at war with: " + string.Join(", ", values3));
		}
		else
		{
			list.Add("Clan wars: Your clan is not currently at war with any kingdoms or clans");
		}
		return string.Join(". ", list);
	}

	public static string GetHeroClanStatus(Hero hero)
	{
		if (hero.IsClanLeader)
		{
			return "clan leader";
		}
		if (hero.IsLord)
		{
			if (hero.IsFemale)
			{
				return "lady";
			}
			return "lord";
		}
		if (hero.IsWanderer)
		{
			return "wanderer";
		}
		if (hero.IsNotable)
		{
			return "notable";
		}
		if (hero.IsPlayerCompanion)
		{
			return "companion";
		}
		return "clan member";
	}

	private static string GetPreviousRulersInfo(Hero npc)
	{
		try
		{
			Kingdom val = null;
			Clan clan = npc.Clan;
			if (((clan != null) ? clan.Kingdom : null) != null)
			{
				val = npc.Clan.Kingdom;
			}
			else
			{
				Clan clan2 = npc.Clan;
				if (clan2 != null)
				{
					IFaction mapFaction = clan2.MapFaction;
					if (((mapFaction != null) ? new bool?(mapFaction.IsKingdomFaction) : ((bool?)null)) == true)
					{
						IFaction mapFaction2 = npc.Clan.MapFaction;
						val = (Kingdom)(object)((mapFaction2 is Kingdom) ? mapFaction2 : null);
						goto IL_00ce;
					}
				}
				Settlement currentSettlement = npc.CurrentSettlement;
				if (currentSettlement != null)
				{
					IFaction mapFaction3 = currentSettlement.MapFaction;
					if (((mapFaction3 != null) ? new bool?(mapFaction3.IsKingdomFaction) : ((bool?)null)) == true)
					{
						IFaction mapFaction4 = npc.CurrentSettlement.MapFaction;
						val = (Kingdom)(object)((mapFaction4 is Kingdom) ? mapFaction4 : null);
					}
				}
			}
			goto IL_00ce;
			IL_00ce:
			if (val == null)
			{
				return null;
			}
			string previousRulerInfo = WorldInfoManager.GetPreviousRulerInfo(val, npc);
			if (!npc.IsKingdomLeader)
			{
				object obj;
				if (val == null)
				{
					obj = null;
				}
				else
				{
					Clan rulingClan = val.RulingClan;
					obj = ((rulingClan != null) ? rulingClan.Leader : null);
				}
				if (obj != npc)
				{
					Clan clan3 = npc.Clan;
					object obj2;
					if (clan3 == null)
					{
						obj2 = null;
					}
					else
					{
						Kingdom kingdom = clan3.Kingdom;
						if (kingdom == null)
						{
							obj2 = null;
						}
						else
						{
							Clan rulingClan2 = kingdom.RulingClan;
							obj2 = ((rulingClan2 != null) ? rulingClan2.Leader : null);
						}
					}
					if (obj2 != npc)
					{
						goto IL_0162;
					}
				}
			}
			if (!string.IsNullOrEmpty(previousRulerInfo))
			{
				return "Previous ruler information: " + previousRulerInfo;
			}
			goto IL_0162;
			IL_0162:
			return null;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GetPreviousRulersInfo: " + ex.Message);
			return null;
		}
	}

	private static bool CanNPCJoinPlayerClan(Hero npc)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Invalid comparison between Unknown and I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		if (npc == null || npc == Hero.MainHero)
		{
			return false;
		}
		Clan playerClan = Clan.PlayerClan;
		if (playerClan == null)
		{
			return false;
		}
		if (npc.CompanionOf == playerClan)
		{
			return false;
		}
		if ((int)npc.Occupation == 16 || npc.IsWanderer || npc.Clan == null)
		{
			return true;
		}
		bool flag = (int)npc.Occupation == 3;
		bool isUnderMercenaryService = npc.Clan.IsUnderMercenaryService;
		bool isKingdomLeader = npc.IsKingdomLeader;
		return flag && !isUnderMercenaryService && !isKingdomLeader;
	}

	private static bool CanNPCJoinPlayerKingdom(Hero npc)
	{
		if (npc == null || npc.Clan == null)
		{
			return false;
		}
		Clan playerClan = Clan.PlayerClan;
		if (playerClan == null || playerClan.Kingdom == null)
		{
			return false;
		}
		if (playerClan.Kingdom.Leader != Hero.MainHero)
		{
			return false;
		}
		bool isClanLeader = npc.IsClanLeader;
		bool isKingdomLeader = npc.IsKingdomLeader;
		return isClanLeader && !isKingdomLeader;
	}

	private static string GetPlayerRecruitmentOpportunityInfo(Hero npc)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Invalid comparison between Unknown and I4
		Clan playerClan = Clan.PlayerClan;
		if (playerClan == null)
		{
			return "";
		}
		List<string> list = new List<string>();
		bool flag = (int)npc.Occupation == 3 && npc.Clan != null;
		Clan clan = npc.Clan;
		bool flag2 = clan != null && clan.IsUnderMercenaryService;
		bool isKingdomLeader = npc.IsKingdomLeader;
		if (npc.CompanionOf == playerClan)
		{
			list.Add("You are currently a companion in the player's clan. The player could dismiss you from their clan if they wish or if you request it.");
		}
		else if ((int)npc.Occupation == 16 || npc.IsWanderer)
		{
			list.Add("You are a free wanderer with no sworn loyalties. If the player invites you and you accept, you may enter their clan as a companion and fight under their banner.");
		}
		else if (flag && !flag2 && !isKingdomLeader && npc.Clan != playerClan)
		{
			list.Add("You are a lord. If you agree and circumstances allow, you could potentially join the player's clan as a companion or family member.");
		}
		bool flag3 = playerClan.Kingdom != null && playerClan.Kingdom.Leader == Hero.MainHero;
		bool isClanLeader = npc.IsClanLeader;
		if (flag3 && isClanLeader && !isKingdomLeader && npc.Clan != playerClan)
		{
			Kingdom kingdom = playerClan.Kingdom;
			Clan clan2 = npc.Clan;
			Kingdom val = ((clan2 != null) ? clan2.Kingdom : null);
			if (val == kingdom)
			{
				if (flag2)
				{
					list.Add($"Your mercenary company currently serves the player's kingdom {kingdom.Name}. The player (as kingdom leader) could dismiss you from mercenary service if they wish or if you request it.");
				}
				else
				{
					list.Add($"Your clan is a vassal of the player's kingdom {kingdom.Name}. The player (as kingdom leader) could release you from vassalage if there are serious reasons or if you request it (this will end your oath and you will leave their kingdom).");
				}
			}
			else if (val != null)
			{
				if (flag2)
				{
					list.Add($"You lead a mercenary clan currently serving another kingdom. The player (as kingdom leader) could convince you to switch your service to their kingdom {kingdom.Name}.");
				}
				else
				{
					list.Add($"You are a clan leader serving another kingdom. The player (as kingdom leader) could attempt to convince you to defect and join their kingdom {kingdom.Name} (this is a major political move).");
				}
			}
			else
			{
				list.Add($"You lead an independent clan. The player (as kingdom leader) could invite your entire clan to join their kingdom {kingdom.Name}.");
			}
		}
		if (flag3 && isClanLeader && !isKingdomLeader && npc.Clan != playerClan)
		{
			Kingdom kingdom2 = playerClan.Kingdom;
			Clan clan3 = npc.Clan;
			Kingdom val2 = ((clan3 != null) ? clan3.Kingdom : null);
			if (val2 != kingdom2 && CanClanBeMercenary(npc.Clan))
			{
				if (flag2)
				{
					list.Add($"You lead a mercenary company currently serving another kingdom. The player (as kingdom leader) could hire you to serve their kingdom {kingdom2.Name} instead.");
				}
				else
				{
					list.Add($"You lead a free mercenary company. The player (as kingdom leader) could hire your company to fight for their kingdom {kingdom2.Name}.");
				}
			}
		}
		if (list.Any())
		{
			return "\n\n  - **WHAT THE PLAYER CAN OFFER YOU:** " + string.Join(" ", list) + "\n";
		}
		return "";
	}

	private static bool CanClanBeMercenary(Clan clan)
	{
		if (clan == null)
		{
			return false;
		}
		return clan.IsMinorFaction;
	}

	private static string GetRecruitmentOpportunityInfo(Hero npc)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		Clan clan = npc.Clan;
		Kingdom val = ((clan != null) ? clan.Kingdom : null);
		if (val == null)
		{
			return "";
		}
		if ((int)npc.Occupation != 3 && !npc.IsClanLeader)
		{
			return "";
		}
		bool isKingdomLeader = npc.IsKingdomLeader;
		bool flag = !isKingdomLeader;
		Clan playerClan = Clan.PlayerClan;
		if (playerClan == null)
		{
			return "";
		}
		int tier = playerClan.Tier;
		bool isUnderMercenaryService = playerClan.IsUnderMercenaryService;
		bool flag2 = playerClan.Kingdom != null && !isUnderMercenaryService;
		bool flag3 = playerClan.Kingdom == val;
		List<string> list = new List<string>();
		int mercenaryEligibleTier = Campaign.Current.Models.ClanTierModel.MercenaryEligibleTier;
		if (tier >= mercenaryEligibleTier && !flag2)
		{
			if (isUnderMercenaryService && flag3)
			{
				if (isKingdomLeader)
				{
					list.Add("This person is currently serving as a mercenary in your kingdom. You can dismiss them from service if you wish or if they request it.");
				}
				else
				{
					list.Add("This person is currently serving as a mercenary in your kingdom. As a vassal, you cannot dismiss them - only the kingdom ruler can do that.");
				}
			}
			else if (isUnderMercenaryService && !flag3)
			{
				if (isKingdomLeader)
				{
					list.Add("This person is currently a mercenary for another kingdom. If interested, you could try to convince them to switch to your kingdom's service.");
				}
				else
				{
					list.Add("This person is currently a mercenary for another kingdom. As a vassal, you could try to convince them to switch to your kingdom's service, but only the kingdom ruler can actually hire them.");
				}
			}
			else if (isKingdomLeader)
			{
				list.Add("This person's clan has sufficient renown to serve as a mercenary. If you wish and they agree, you could hire them as a mercenary for your kingdom (paid service).");
			}
			else if (flag)
			{
				list.Add("This person's clan has sufficient renown to serve as a mercenary. If you wish and they agree, you could hire them as a mercenary for your kingdom (paid service). Note: As a vassal, you can hire mercenaries on behalf of your kingdom, but the decision is yours.");
			}
		}
		if (isKingdomLeader)
		{
			int vassalEligibleTier = Campaign.Current.Models.ClanTierModel.VassalEligibleTier;
			if (tier >= vassalEligibleTier)
			{
				if (flag2 && flag3)
				{
					list.Add("This person is your vassal lord. You can release them from vassalage if there are serious reasons or if they request it (this will end their oath and they will leave your kingdom).");
				}
				else if (flag2 && !flag3)
				{
					list.Add("This person is a vassal of another kingdom. You could potentially try to convince them to defect, though such matters require careful diplomacy.");
				}
				else if (isUnderMercenaryService && flag3)
				{
					list.Add("This person is your mercenary. Their clan has grown strong enough that, if you both wish it, you could offer them full vassalage (promotion to lord with potential fiefs).");
				}
				else if (!flag2)
				{
					list.Add("This person's clan has sufficient prestige to be accepted as a vassal. If you wish and they agree, you could offer them vassalage (lordship with fiefs and voting rights).");
				}
			}
			else if (!flag2 && !isUnderMercenaryService)
			{
				int mercenaryEligibleTier2 = Campaign.Current.Models.ClanTierModel.MercenaryEligibleTier;
				if (tier >= mercenaryEligibleTier2)
				{
					list.Add("**IMPORTANT RESTRICTION:** You cannot accept this person as a vassal because their clan does not have sufficient prestige yet. You can only hire them as a mercenary if they agree.");
				}
				else
				{
					list.Add("**IMPORTANT RESTRICTION:** You cannot accept this person as a vassal or hire them as a mercenary because their clan does not have sufficient prestige yet. Their clan is not yet established enough for any position in your kingdom.");
				}
			}
		}
		else
		{
			int vassalEligibleTier2 = Campaign.Current.Models.ClanTierModel.VassalEligibleTier;
			if (tier >= vassalEligibleTier2 && !flag2)
			{
				Hero leader = val.Leader;
				string text = ((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "your kingdom's ruler";
				list.Add("This person's clan has sufficient prestige to become a vassal, but only " + text + " (the kingdom ruler) can offer vassalage. You can only hire them as a mercenary.");
			}
		}
		if (list.Any())
		{
			return "\n\n  - **RECRUITMENT POSSIBILITY:** " + string.Join(" ", list) + "\n";
		}
		return "";
	}

	private static string GetPlayerIdentityDescription(Hero npc, NPCContext context)
	{
		if (context.IsPlayerKnown)
		{
			string playerRecognitionType = GetPlayerRecognitionType(npc, context);
			string realName = context.PlayerInfo.RealName;
			string realClan = context.PlayerInfo.RealClan;
			int realAge = context.PlayerInfo.RealAge;
			string text = "";
			if (!string.IsNullOrEmpty(context.PlayerInfo.RealKingdom))
			{
				string text2 = (context.PlayerInfo.IsMercenary ? "mercenary" : "vassal");
				text = " They are a " + text2 + " of " + context.PlayerInfo.RealKingdom + " (id:" + context.PlayerInfo.RealKingdomId + ").";
			}
			string text3 = ((!string.IsNullOrEmpty(context.PlayerInfo.PlayerStringId)) ? (" (id:" + context.PlayerInfo.PlayerStringId + ")") : "");
			string text4 = string.Format("  - **Your Knowledge:** You recognize them as {0} {1}{2} of {3}, a {4}-year-old {5} of {6} culture.{7}\n", playerRecognitionType, realName, text3, realClan, realAge, context.PlayerInfo.RealGender ?? "unknown", context.PlayerInfo.RealCulture, text);
			if (!string.IsNullOrEmpty(context.PlayerInfo.ClaimedName) && !string.Equals(context.PlayerInfo.ClaimedName, context.PlayerInfo.RealName, StringComparison.OrdinalIgnoreCase))
			{
				text4 = text4 + "  - **Note:** In conversation they introduced themselves as \"" + context.PlayerInfo.ClaimedName + "\", but you know their true identity.\n";
			}
			string recruitmentOpportunityInfo = GetRecruitmentOpportunityInfo(npc);
			return text4 + recruitmentOpportunityInfo;
		}
		bool flag = !string.IsNullOrEmpty(context.PlayerInfo.ClaimedName) || !string.IsNullOrEmpty(context.PlayerInfo.ClaimedClan) || context.PlayerInfo.ClaimedAge > 0;
		string text5 = "";
		if (!string.IsNullOrEmpty(context.PlayerInfo.RealKingdom))
		{
			string text6 = (context.PlayerInfo.IsMercenary ? "mercenary" : "vassal");
			text5 = " They are a " + text6 + " of " + context.PlayerInfo.RealKingdom + " (id:" + context.PlayerInfo.RealKingdomId + ").";
		}
		if (flag)
		{
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(context.PlayerInfo.ClaimedName))
			{
				list.Add("their name is " + context.PlayerInfo.ClaimedName);
			}
			if (!string.IsNullOrEmpty(context.PlayerInfo.ClaimedClan))
			{
				list.Add("they are of clan " + context.PlayerInfo.ClaimedClan);
			}
			if (context.PlayerInfo.ClaimedAge > 0)
			{
				list.Add($"they are {context.PlayerInfo.ClaimedAge} years old");
			}
			string text7 = "They have told you " + string.Join(", ", list) + ".";
			return "  - **Your Knowledge:** " + text7 + text5 + " You don't know their true identity.\n";
		}
		return "  - **Your Knowledge:** This person has not told you their name, clan, or age." + text5 + " They are a stranger to you.\n";
	}

	private static string GetPlayerRecognitionType(Hero npc, NPCContext context)
	{
		if (IsPlayerRelative(npc, context))
		{
			return "your relative";
		}
		if (npc.IsPlayerCompanion)
		{
			return "your clan leader";
		}
		if (Hero.MainHero.IsKingdomLeader && npc.MapFaction != null && npc.MapFaction == Hero.MainHero.MapFaction)
		{
			return "the kingdom's ruler";
		}
		return "";
	}

	private static bool IsPlayerRelative(Hero npc, NPCContext context)
	{
		Hero mainHero = Hero.MainHero;
		if (mainHero == null)
		{
			return false;
		}
		return npc.Father == mainHero || npc.Mother == mainHero || npc.Spouse == mainHero || ((List<Hero>)(object)npc.Children).Contains(mainHero) || npc.Siblings.Contains(mainHero) || ((List<Hero>)(object)mainHero.Children).Contains(npc);
	}

	private static string GetPlayerWealthDescription(NPCContext context)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		int gold = Hero.MainHero.Gold;
		int claimedGold = context.PlayerInfo.ClaimedGold;
		string text = "unknown wealth";
		Equipment battleEquipment = Hero.MainHero.BattleEquipment;
		bool flag = false;
		for (int i = 0; i < 12; i++)
		{
			EquipmentElement val = battleEquipment[i];
			ItemObject item = (val).Item;
			if (item != null && item.Value > 5000)
			{
				flag = true;
				break;
			}
		}
		int num = 0;
		if (Hero.MainHero != null)
		{
			MobileParty partyBelongedTo = Hero.MainHero.PartyBelongedTo;
			if (partyBelongedTo != null && partyBelongedTo.MemberRoster != null)
			{
				num = partyBelongedTo.MemberRoster.TotalManCount;
			}
		}
		text = ((flag && num > 100) ? "appears quite wealthy (expensive equipment and large army)" : ((flag || num > 80) ? "appears moderately wealthy (decent equipment or sizable army)" : ((num <= 40) ? "wealth is unclear from their appearance" : "appears to have some means (maintains a decent party)")));
		if (claimedGold > 0)
		{
			bool flag2 = true;
			if (claimedGold > 100000 && !flag && num < 50)
			{
				flag2 = false;
			}
			else if (claimedGold < 1000 && flag && num > 100)
			{
				flag2 = false;
			}
			if (flag2)
			{
				return $"You don't know their exact wealth. Based on their appearance, they {text}. They claimed to have {claimedGold} denars.";
			}
			return $"You don't know their exact wealth. Based on their appearance, they {text}. They claimed to have {claimedGold} denars, but this seems suspicious given their appearance.";
		}
		return "You don't know how much gold they have. Based on their appearance, they " + text + ". They haven't told you their exact amount of money.";
	}

	private static string GetWorkshopTradingRules(Hero npc)
	{
		List<Workshop> source = ((IEnumerable<Workshop>)npc.OwnedWorkshops)?.ToList() ?? new List<Workshop>();
		if (!source.Any())
		{
			return string.Empty;
		}
		return "- **Workshop Trading:** You can sell workshops if price is right. Consider personality (generous=sell easier, greedy=better deals), financial needs, relationship, trust, player's wealth/reputation. Base prices listed above - negotiate based on personality/relationship. When negotiating, keep `workshop_action` as 'none' and discuss price in response. Payment: You don't know exact wealth unless told - trust appearance/claims, but be suspicious if claim doesn't match look. NEVER ask to show money - rude. Selling: Set `workshop_action` to 'sell' ONLY after FINAL agreement. See JSON fields below for `workshop_string_id` and `workshop_price` details. In dialogue, refer to workshop by TYPE+LOCATION (e.g., \"Smithy in Epicrotea\"), NEVER mention string_id.\n";
	}

	private static string GetWorkshopJsonFields()
	{
		return "- `workshop_action`: (string) `'none'` or `'sell'`. Set to 'sell' when you agree to sell (after final agreement). **Omit if not selling.**\n- `workshop_string_id`: (string) Exact string_id from [technical string_id: ...] in workshop list above (e.g., \"workshop_3\"). TECHNICAL identifier - NEVER mention in `response` dialogue! Use TYPE+LOCATION in dialogue. **Required when selling.**\n- `workshop_price`: (int) FINAL AGREED PRICE in denars (required when 'sell'). Can be higher than base (greedy/distrust) or lower (generous/like them). Amount player will pay. **Required when selling.**\n";
	}

	public static string GetRulerTitle(Hero ruler)
	{
		Clan clan = ruler.Clan;
		if (clan != null)
		{
			IFaction mapFaction = clan.MapFaction;
			if (((mapFaction != null) ? new bool?(mapFaction.IsKingdomFaction) : ((bool?)null)) == true)
			{
				IFaction mapFaction2 = ruler.Clan.MapFaction;
				Kingdom val = (Kingdom)(object)((mapFaction2 is Kingdom) ? mapFaction2 : null);
				if (val == null)
				{
					return "ruler";
				}
				if (((MBObjectBase)val).StringId.Contains("aserai"))
				{
					return "Sultan";
				}
				if (((MBObjectBase)val).StringId.Contains("battania"))
				{
					return "High King";
				}
				if (((MBObjectBase)val).StringId.Contains("empire"))
				{
					return "Emperor";
				}
				if (((MBObjectBase)val).StringId.Contains("khuzait"))
				{
					return "Khan";
				}
				if (((MBObjectBase)val).StringId.Contains("sturgia"))
				{
					return "Grand Prince";
				}
				if (((MBObjectBase)val).StringId.Contains("vlandia"))
				{
					return "King";
				}
				return "King";
			}
		}
		return "ruler";
	}

	private static string PersonalizeEventForNPC(DynamicEvent evt, Hero npc)
	{
		string arg;
		if (evt.EventHistory != null && evt.EventHistory.Count > 1)
		{
			List<string> values = (from u in evt.EventHistory
				orderby u.Timestamp
				select $"{u.Description} ({u.DaysSinceCreation} days ago)").ToList();
			arg = string.Join("; ", values);
		}
		else
		{
			arg = evt.GetDescriptionWithAge();
		}
		string text = $"{arg} [importance: {evt.Importance}, type: {evt.Type}]";
		if (IsEventInvolvingNPC(evt, npc))
		{
			return text + " (THIS EVENT INVOLVES YOU)";
		}
		return text;
	}

	private static bool IsEventInvolvingNPC(DynamicEvent evt, Hero npc)
	{
		if (npc == null || evt == null)
		{
			return false;
		}
		if (evt.CharactersInvolved != null && evt.CharactersInvolved.Any())
		{
			string stringId = ((MBObjectBase)npc).StringId;
			if (!string.IsNullOrEmpty(stringId) && evt.CharactersInvolved.Contains(stringId))
			{
				return true;
			}
		}
		string text = evt.Description.ToLower();
		string value = ((object)npc.Name)?.ToString()?.ToLower() ?? "";
		Clan clan = npc.Clan;
		string value2 = ((clan == null) ? null : ((object)clan.Name)?.ToString()?.ToLower()) ?? "";
		IFaction mapFaction = npc.MapFaction;
		string text2 = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()?.ToLower()) ?? "";
		if (!string.IsNullOrEmpty(value) && text.Contains(value))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(value2) && text.Contains(value2))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(text2) && text.Contains(text2))
		{
			return true;
		}
		if (npc.IsKingdomLeader && !string.IsNullOrEmpty(text2) && (text.Contains("king of " + text2) || text.Contains("ruler of " + text2) || text.Contains("leader of " + text2)))
		{
			return true;
		}
		return false;
	}

	private static string GetActiveDiplomaticEventsForNPC(Hero npc)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null)
		{
			return "none";
		}
		try
		{
			DiplomacyManager instance = DiplomacyManager.Instance;
			if (instance == null || !instance.IsInitialized)
			{
				return "none";
			}
			List<DynamicEvent> activeDiplomaticEvents = instance.GetActiveDiplomaticEvents();
			if (activeDiplomaticEvents == null || !activeDiplomaticEvents.Any())
			{
				return "none";
			}
			List<string> list = new List<string>();
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			foreach (DynamicEvent item2 in activeDiplomaticEvents)
			{
				bool flag = false;
				Clan clan = npc.Clan;
				if (((clan != null) ? clan.Kingdom : null) != null && item2.ParticipatingKingdoms != null && item2.ParticipatingKingdoms.Contains(((MBObjectBase)npc.Clan.Kingdom).StringId))
				{
					flag = true;
				}
				if (!flag && item2.Type == "diplomatic_statement" && (npc.IsLord || npc.IsClanLeader || npc.IsKingdomLeader))
				{
					flag = true;
				}
				if (!flag)
				{
					continue;
				}
				int num2 = 0;
				if (item2.CreationCampaignDays > 0f)
				{
					num2 = Math.Max(0, (int)(num - item2.CreationCampaignDays));
				}
				List<string> list2 = new List<string>();
				if (item2.ParticipatingKingdoms != null)
				{
					foreach (string kingdomId in item2.ParticipatingKingdoms)
					{
						Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == kingdomId));
						if (val != null)
						{
							list2.Add($"{val.Name} (id:{kingdomId})");
						}
					}
				}
				string text = (list2.Any() ? string.Join(", ", list2) : "unknown");
				string arg = item2.Description ?? "No description";
				int num3 = item2.KingdomStatements.Count - item2.StatementsAtRoundStart;
				int count = item2.KingdomStatements.Count;
				string item = $"EVENT #{item2.DiplomaticRounds} (started {num2} days ago): {arg} | " + "Participants: " + text + " | " + $"Statements this round: {num3}, total: {count}";
				list.Add(item);
			}
			if (!list.Any())
			{
				return "none";
			}
			return string.Join("; ", list);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[PROMPT] Error getting active diplomatic events: " + ex.Message);
			return "none";
		}
	}

	private static string GetDiplomaticStatementsForNPC(Hero npc)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null || npc.Clan == null)
		{
			return "none";
		}
		try
		{
			DiplomaticStatementsStorage instance = DiplomaticStatementsStorage.Instance;
			List<KingdomStatement> statementsForNPC = instance.GetStatementsForNPC(npc);
			if (statementsForNPC == null || !statementsForNPC.Any())
			{
				return "none";
			}
			List<string> list = new List<string>();
			CampaignTime val = CampaignTime.Now;
			float num = (float)(val).ToDays;
			foreach (KingdomStatement stmt in statementsForNPC)
			{
				int num2 = 0;
				_ = stmt.Timestamp;
				if (true)
				{
					val = stmt.Timestamp;
					float num3 = (float)(val).ToDays;
					num2 = Math.Max(0, (int)(num - num3));
				}
				Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == stmt.KingdomId));
				if (val2 != null)
				{
					string text;
					if (npc.Clan.Kingdom != null && npc.IsKingdomLeader && stmt.KingdomId == ((MBObjectBase)npc.Clan.Kingdom).StringId)
					{
						text = "YOU STATED";
					}
					else if (npc.Clan.Kingdom != null && stmt.KingdomId == ((MBObjectBase)npc.Clan.Kingdom).StringId)
					{
						Hero leader = val2.Leader;
						string text2 = ((leader == null) ? null : ((object)leader.Name)?.ToString()) ?? "Your ruler";
						Hero leader2 = val2.Leader;
						string text3 = ((leader2 != null) ? ((MBObjectBase)leader2).StringId : null) ?? "unknown";
						text = "YOUR RULER (" + text2 + " id:" + text3 + ") STATED";
					}
					else
					{
						Hero leader3 = val2.Leader;
						string text4 = ((leader3 == null) ? null : ((object)leader3.Name)?.ToString()) ?? "Unknown";
						Hero leader4 = val2.Leader;
						string text5 = ((leader4 != null) ? ((MBObjectBase)leader4).StringId : null) ?? "unknown";
						string text6 = ((object)val2.Name)?.ToString() ?? "Unknown Kingdom";
						string stringId = ((MBObjectBase)val2).StringId;
						text = "RULER OF " + text6 + " (id:" + stringId + ") (" + text4 + " id:" + text5 + ") STATED";
					}
					list.Add($"{text}: {stmt.StatementText} ({num2} days ago, action: {stmt.Action})");
				}
			}
			return list.Any() ? string.Join("; ", list) : "none";
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[ERROR] Failed to get diplomatic statements for {npc.Name}: {ex.Message}");
			return "none";
		}
	}

	private static string GetKingdomActionsSection(Hero npc, string gameLanguage)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Invalid comparison between Unknown and I4
		bool isKingdomLeader = npc.IsKingdomLeader;
		Clan playerClan = Clan.PlayerClan;
		bool flag = ((playerClan != null) ? playerClan.Kingdom : null) != null && playerClan.Kingdom.Leader == Hero.MainHero;
		bool flag2 = CanNPCJoinPlayerClan(npc);
		bool flag3 = CanNPCJoinPlayerKingdom(npc);
		bool flag4 = playerClan != null && npc.CompanionOf == playerClan;
		bool flag5 = flag && npc.IsClanLeader && npc.Clan != null && npc.Clan.Kingdom == ((playerClan != null) ? playerClan.Kingdom : null);
		IFaction mapFaction = npc.MapFaction;
		Kingdom val = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
		bool flag6 = playerClan != null && playerClan.IsUnderMercenaryService;
		bool flag7 = ((playerClan != null) ? playerClan.Kingdom : null) != null && !flag6;
		int num = ((playerClan != null) ? playerClan.Tier : 0);
		int mercenaryEligibleTier = Campaign.Current.Models.ClanTierModel.MercenaryEligibleTier;
		int vassalEligibleTier = Campaign.Current.Models.ClanTierModel.VassalEligibleTier;
		bool flag8 = ((int)npc.Occupation == 3 || npc.IsClanLeader) && val != null && !isKingdomLeader;
		if (!isKingdomLeader && !flag8 && !flag2 && !flag3 && !flag4 && !flag5)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### Kingdom Actions ###");
		stringBuilder.AppendLine("- **`kingdom_action`**: (string) Your political/recruitment action. Must be one of:");
		stringBuilder.AppendLine("    - `'none'`: No action.");
		if (!string.IsNullOrWhiteSpace(gameLanguage))
		{
			stringBuilder.AppendLine("- **Language:** Write `kingdom_action_reason` in " + gameLanguage + ".");
		}
		if (flag)
		{
			if (val != null && ((playerClan != null) ? playerClan.Kingdom : null) != null && FactionManager.IsAtWarAgainstFaction((IFaction)(object)val, (IFaction)(object)playerClan.Kingdom))
			{
				stringBuilder.AppendLine("    - `'propose_peace'`: Propose peace to end the war between your kingdoms.");
				stringBuilder.AppendLine("    - `'accept_peace'`: Accept a peace proposal.");
				stringBuilder.AppendLine("    - `'reject_peace'`: Reject a peace proposal.");
				stringBuilder.AppendLine("    - **CANNOT DECLARE WAR:** You are already at war with this kingdom. You can only propose peace, not declare war again.");
			}
			else
			{
				stringBuilder.AppendLine("    - `'declare_war'`: Declare war on another kingdom.");
				stringBuilder.AppendLine("    - **CANNOT PROPOSE PEACE:** You are not at war with this kingdom. You can only declare war, not propose peace.");
			}
			if (GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				stringBuilder.AppendLine("    - `'propose_alliance'`: Propose an alliance to another kingdom.");
				stringBuilder.AppendLine("    - `'accept_alliance'`: Accept an alliance proposal.");
				stringBuilder.AppendLine("    - `'reject_alliance'`: Reject an alliance proposal.");
				stringBuilder.AppendLine("    - `'break_alliance'`: Break an existing alliance.");
				stringBuilder.AppendLine("    - `'propose_trade_agreement'`: Propose a trade agreement (max 2 per kingdom).");
				stringBuilder.AppendLine("    - `'accept_trade_agreement'`: Accept a trade agreement proposal.");
				stringBuilder.AppendLine("    - `'reject_trade_agreement'`: Reject a trade agreement proposal.");
				stringBuilder.AppendLine("    - `'end_trade_agreement'`: End an existing trade agreement.");
				Hero mainHero = Hero.MainHero;
				object obj;
				if (mainHero == null)
				{
					obj = null;
				}
				else
				{
					Clan clan = mainHero.Clan;
					obj = ((clan != null) ? clan.Kingdom : null);
				}
				Kingdom val2 = (Kingdom)obj;
				bool flag9 = false;
				if (val != null && val2 != null)
				{
					DiplomacyManager instance = DiplomacyManager.Instance;
					if (instance != null && instance.IsInitialized)
					{
						TerritoryTransferSystem territoryTransferSystem = instance.GetTerritoryTransferSystem();
						List<Settlement> warRelevantSettlements = territoryTransferSystem.GetWarRelevantSettlements(val, val2);
						flag9 = warRelevantSettlements.Any();
					}
				}
				if (flag9 && isKingdomLeader)
				{
					stringBuilder.AppendLine("    - `'demand_territory'`: Demand territory (town/castle) from another kingdom (specify settlement_id from War-Relevant Settlements).");
					stringBuilder.AppendLine("    - `'transfer_territory'`: Transfer territory to another kingdom (specify settlement_id from War-Relevant Settlements).");
				}
				else if (flag9 && !isKingdomLeader)
				{
					stringBuilder.AppendLine("    - **CANNOT DEMAND/TRANSFER TERRITORY:** Only kingdom leaders can negotiate territory transfers. You do not have the authority to make such decisions.");
				}
				stringBuilder.AppendLine("    - `'demand_tribute'`: Demand daily tribute payment (specify amount and duration).");
				stringBuilder.AppendLine("    - `'accept_tribute'`: Accept to pay tribute.");
				stringBuilder.AppendLine("    - `'reject_tribute'`: Reject tribute demand.");
				stringBuilder.AppendLine("    - `'demand_reparations'`: Demand one-time war reparations (specify amount).");
				stringBuilder.AppendLine("    - `'accept_reparations'`: Accept to pay reparations.");
				stringBuilder.AppendLine("    - `'reject_reparations'`: Reject reparations demand.");
			}
		}
		bool flag10 = npc.IsClanLeader && npc.Clan != null;
		bool flag11 = isKingdomLeader && val != null;
		bool flag12 = flag10 && npc.Clan != null;
		if ((flag11 || flag12) && playerClan != null)
		{
			if (flag11)
			{
				stringBuilder.AppendLine("    - `'grant_fief'`: Grant a settlement (town/castle) to the player. As kingdom leader, you can grant ANY fief from your kingdom. Specify `settlement_id` from your kingdom's holdings.");
				stringBuilder.AppendLine("      - **Note:** The player can be a vassal, independent, or from another kingdom. If independent, they will remain independent (will NOT become your vassal).");
			}
			else if (flag12)
			{
				stringBuilder.AppendLine("    - `'grant_fief'`: Grant a settlement (town/castle) to the player. As clan leader, you can grant ONLY fiefs belonging to YOUR clan. Specify `settlement_id` from your clan's holdings.");
				stringBuilder.AppendLine("      - **Note:** The player can be a vassal, independent, or from another kingdom. If independent, they will remain independent (will NOT become your vassal).");
			}
		}
		else if (!flag11 && !flag12)
		{
			stringBuilder.AppendLine("    - **CANNOT GRANT FIEF:** You must be either a kingdom leader (can grant any fief from kingdom) or a clan leader (can grant only your clan's fiefs) to grant fiefs.");
		}
		bool flag13 = playerClan != null && Hero.MainHero.IsClanLeader && Hero.MainHero.Clan == playerClan;
		bool flag14 = flag && playerClan != null && playerClan.Kingdom != null;
		bool flag15 = flag13 && playerClan != null;
		if ((flag14 || flag15) && npc.Clan != null)
		{
			if (flag14)
			{
				stringBuilder.AppendLine("    - `'receive_fief'`: Accept a settlement granted by the player (kingdom leader). The player can grant ANY fief from their kingdom. Specify `settlement_id` and `target_clan_id` (your clan ID).");
				stringBuilder.AppendLine("      - **Note:** You can receive fiefs even if you are independent or from another kingdom. You will remain in your current status.");
			}
			else if (flag15)
			{
				stringBuilder.AppendLine("    - `'receive_fief'`: Accept a settlement granted by the player (clan leader). The player can grant ONLY fiefs belonging to their clan. Specify `settlement_id` and `target_clan_id` (your clan ID).");
				stringBuilder.AppendLine("      - **Note:** You can receive fiefs even if you are independent or from another kingdom. You will remain in your current status.");
			}
		}
		if (isKingdomLeader && playerClan != null && val != null && playerClan.Kingdom == val && flag7)
		{
			int tier = playerClan.Tier;
			if (tier >= 4)
			{
				stringBuilder.AppendLine("    - `'transfer_kingdom'`: Transfer the leadership of your kingdom to the player. **CRITICAL: Use ONLY if the player explicitly agrees in dialogue to accept the kingdom leadership. This is a major decision that will make them the new ruler.**");
			}
			else
			{
				stringBuilder.AppendLine("    - **CANNOT TRANSFER KINGDOM:** You cannot transfer kingdom leadership to the player. Their clan lacks the prestige, renown, and established status required to rule a kingdom. They are not yet ready for such responsibility - their clan has not achieved sufficient standing among the nobility. You would face opposition from other lords who would not accept someone of their current status as ruler.");
			}
		}
		else if (isKingdomLeader && playerClan != null && val != null && playerClan.Kingdom == val && !flag7)
		{
			stringBuilder.AppendLine("    - **CANNOT TRANSFER KINGDOM:** You can only transfer kingdom leadership to a vassal of your kingdom. The player is not your vassal.");
		}
		if (flag && flag8 && playerClan != null && val != null && playerClan.Kingdom == val)
		{
			stringBuilder.AppendLine("    - `'transfer_kingdom'`: Accept the transfer of kingdom leadership from the player. **CRITICAL: Use ONLY if the player explicitly offers to transfer the kingdom to you AND you agree to accept it. This is a major decision that will make you the new ruler.**");
		}
		if (playerClan != null && val != null && (isKingdomLeader || flag8))
		{
			bool flag16 = playerClan.Kingdom == val;
			if (!flag7 && !flag6)
			{
				if (num >= mercenaryEligibleTier)
				{
					if (isKingdomLeader)
					{
						stringBuilder.AppendLine("    - `'hire_mercenary'`: Hire the player as a mercenary. **CRITICAL: Use ONLY if the player AGREES in dialogue to join as mercenary.**");
					}
					else
					{
						stringBuilder.AppendLine("    - `'hire_mercenary'`: Hire the player as a mercenary for your kingdom. **CRITICAL: Use ONLY if the player AGREES in dialogue to join as mercenary. As a vassal, you can hire mercenaries on behalf of your kingdom.**");
					}
				}
				else
				{
					stringBuilder.AppendLine("    - **CANNOT HIRE AS MERCENARY:** You cannot hire this person as a mercenary. Their clan is not yet established enough for such service.");
				}
			}
			if (flag6 && flag16 && isKingdomLeader)
			{
				stringBuilder.AppendLine("    - `'dismiss_mercenary'`: Release the player from mercenary service. **CRITICAL: Use ONLY if the player requests to leave OR you have a serious reason to dismiss them.**");
			}
			if (isKingdomLeader && !flag7)
			{
				if (num >= vassalEligibleTier)
				{
					stringBuilder.AppendLine("    - `'offer_vassalage'`: Accept the player as a vassal lord. **CRITICAL: Use ONLY if the player AGREES in dialogue to become your vassal.**");
				}
				else
				{
					stringBuilder.AppendLine("    - **CANNOT OFFER VASSALAGE:** You cannot accept this person as a vassal. Their clan is not yet established enough for such a position.");
				}
			}
			if (isKingdomLeader && flag7 && flag16)
			{
				stringBuilder.AppendLine("    - `'dismiss_vassal'`: Release the player from vassalage. **CRITICAL: Use ONLY if the player requests to leave OR you have a very serious reason (treason, grave dishonor). This is a major decision.**");
			}
		}
		if (flag2)
		{
			stringBuilder.AppendLine("    - `'join_player_clan'`: Join the player's clan as a companion. **CRITICAL: Use ONLY if the player asks you to join their clan AND you agree to do so.**");
		}
		if (flag3)
		{
			stringBuilder.AppendLine("    - `'join_player_kingdom'`: Pledge your clan to the player's kingdom. **CRITICAL: Use ONLY if the player (as kingdom leader) invites your clan AND you agree to join their kingdom.**");
		}
		if (flag3 && CanClanBeMercenary(npc.Clan))
		{
			stringBuilder.AppendLine("    - `'hire_mercenary_clan'`: Accept the player's offer to hire your clan as mercenaries. **CRITICAL: Use ONLY if the player (as kingdom leader) offers to hire your clan AND you agree to serve as mercenaries.**");
		}
		if (playerClan != null)
		{
			if (flag4)
			{
				stringBuilder.AppendLine("    - `'kick_from_clan'`: Accept the player's decision to dismiss you from their clan. **CRITICAL: Use ONLY if the player explicitly dismisses you OR you request to leave AND the player agrees.**");
			}
			if (flag && npc.IsClanLeader && npc.Clan != null && npc.Clan.Kingdom == playerClan.Kingdom)
			{
				if (npc.Clan.IsUnderMercenaryService)
				{
					stringBuilder.AppendLine("    - `'dismiss_npc_mercenary'`: Accept the player's decision to dismiss your clan from mercenary service. **CRITICAL: Use ONLY if the player (as kingdom leader) dismisses you OR you request to leave AND the player agrees.**");
				}
				else
				{
					stringBuilder.AppendLine("    - `'release_npc_vassal'`: Accept the player's decision to release your clan from vassalage. **CRITICAL: Use ONLY if the player (as kingdom leader) releases you OR you request to leave AND the player agrees (this is a major decision).**");
				}
			}
		}
		stringBuilder.AppendLine("- **`kingdom_action_reason`**: (string or null) Brief reason for your diplomatic action (required if kingdom_action is not 'none').");
		if (GlobalSettings<ModSettings>.Instance.EnableDiplomacy && flag && isKingdomLeader)
		{
			stringBuilder.AppendLine("- `settlement_id`: (string/null) Settlement ID for 'demand_territory', 'transfer_territory', 'grant_fief', 'receive_fief'.");
			stringBuilder.AppendLine("- `target_clan_id`: (string/null) Clan ID for fief transfers. Required for 'receive_fief'.");
			stringBuilder.AppendLine("- `daily_tribute_amount`: (int/0) Gold per day for 'demand_tribute'.");
			stringBuilder.AppendLine("- `tribute_duration_days`: (int/0) Tribute duration in days for 'demand_tribute'. Recommended: 90-365.");
			stringBuilder.AppendLine("- `reparations_amount`: (int/0) One-time payment for 'demand_reparations'.");
			stringBuilder.AppendLine("- `trade_agreement_duration_years`: (float/1.0) Trade agreement duration. Default: 1 year.");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("**Multiple Actions:** You can propose multiple actions simultaneously (e.g., 'accept_peace,demand_territory,demand_tribute').");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("### Item Exchange ###");
		stringBuilder.AppendLine("- **`item_transfers`**: (array/null) `[{\"item_id\": \"...\", \"amount\": N, \"action\": \"give\"|\"take\"}]`");
		stringBuilder.AppendLine("  - 'give'=you→player, 'take'=player→you. Use exact item IDs from inventories above.");
		stringBuilder.AppendLine("  - **`item_transfers_opposed_attribute`**: (string, top-level sibling) Add ONLY when contested—player forces you. Omit for agreements. When set, game rolls dice; if player wins, transfer succeeds; if they lose, you refuse. Valid: vigor|endurance|control|cunning|intelligence|social.");
		stringBuilder.AppendLine("  - **Trading items:** Use BOTH actions: give item + take payment, OR take item + give payment, OR barter (give item + take item).");
		stringBuilder.AppendLine("  - **Buy from player:** `money_transfer:{\"action\":\"give\", \"amount\":N}` + `item_transfers:[{\"action\":\"take\", item_id:\"X\"}]`");
		stringBuilder.AppendLine("  - **Sell to player:** `money_transfer:{\"action\":\"receive\", \"amount\":N}` + `item_transfers:[{\"action\":\"give\", item_id:\"X\"}]`");
		stringBuilder.AppendLine("  - **Barter (item for item):** `item_transfers:[{\"action\":\"give\", item_id:\"X\"}, {\"action\":\"take\", item_id:\"Y\"}]` (no money_transfer)");
		stringBuilder.AppendLine("  - **Restrictions:** You can ONLY give items from YOUR inventory. You CANNOT trade settlements/castles/towns through item_transfers.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("  - **Important:** Do not perform an action if it is not confirmed by the player in dialogue. For ALL actions.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**IMPORTANT RULES FOR RECRUITMENT ACTIONS:**");
		bool flag17 = num >= mercenaryEligibleTier && !flag7 && !flag6;
		bool flag18 = num >= vassalEligibleTier && !flag7;
		if (isKingdomLeader)
		{
			List<string> list = new List<string>();
			if (flag17)
			{
				list.Add("`hire_mercenary`");
			}
			if (flag18)
			{
				list.Add("`offer_vassalage`");
			}
			if (list.Any())
			{
				stringBuilder.AppendLine("- **As a ruler - Hiring/Accepting:** Use " + string.Join(" or ", list) + " ONLY when the player explicitly agrees in dialogue.");
			}
			stringBuilder.AppendLine("- **As a ruler - Dismissing:** Use `dismiss_mercenary` or `dismiss_vassal` ONLY when:");
			stringBuilder.AppendLine("  - The player explicitly requests to leave your service, OR");
			stringBuilder.AppendLine("  - You have a serious, justified reason to dismiss/expel them (betrayal, dishonor, treason, grave offense)");
		}
		else if (flag8)
		{
			if (flag17)
			{
				stringBuilder.AppendLine("- **As a vassal - Hiring mercenaries:** You can hire mercenaries on behalf of your kingdom. Use `hire_mercenary` ONLY when the player explicitly agrees in dialogue to join as mercenary.");
				stringBuilder.AppendLine("- **As a vassal - Limitations:** You CANNOT offer vassalage or dismiss mercenaries - only the kingdom ruler can do that. You can only hire new mercenaries.");
			}
			else
			{
				stringBuilder.AppendLine("- **As a vassal - Limitations:** You CANNOT offer vassalage or dismiss mercenaries - only the kingdom ruler can do that.");
			}
		}
		if (flag2 || flag3)
		{
			stringBuilder.AppendLine("- **Joining player:** Use `join_player_clan`, `join_player_kingdom`, or `hire_mercenary_clan` ONLY when:");
			stringBuilder.AppendLine("  - The player explicitly asks you to join them or hire your clan, AND");
			stringBuilder.AppendLine("  - You agree to accept their offer in your response");
			stringBuilder.AppendLine("  - DO NOT use these actions if you decline, are unsure, or need to think about it");
		}
		if (npc.CompanionOf == playerClan)
		{
			goto IL_0a2a;
		}
		if (flag)
		{
			Clan clan2 = npc.Clan;
			if (((clan2 != null) ? clan2.Kingdom : null) == playerClan.Kingdom)
			{
				goto IL_0a2a;
			}
		}
		goto IL_0a60;
		IL_0a60:
		stringBuilder.AppendLine("- You can PROPOSE or DISCUSS these options in your response text, but activate the action ONLY upon agreement or serious cause.");
		stringBuilder.AppendLine("- If uncertain about player's intent or your own decision, keep `kingdom_action` as 'none'.");
		stringBuilder.Append("- These are formal state actions with permanent consequences - use them responsibly and only when truly warranted.");
		return stringBuilder.ToString();
		IL_0a2a:
		stringBuilder.AppendLine("- **Being dismissed by player:** Use `kick_from_clan`, `dismiss_npc_mercenary`, or `release_npc_vassal` ONLY when:");
		stringBuilder.AppendLine("  - The player explicitly dismisses you or releases you from service, OR");
		stringBuilder.AppendLine("  - You explicitly request to leave AND the player agrees");
		stringBuilder.AppendLine("  - DO NOT use these actions if you're just complaining, threatening, or if the player refuses - only when actually leaving");
		goto IL_0a60;
	}

	private static string GetAllianceStatus(Hero npc)
	{
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return string.Empty;
			}
			AllianceSystem instance = AllianceSystem.Instance;
			if (instance == null)
			{
				return "no alliances";
			}
			List<Kingdom> list = ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k.Leader != null).ToList();
			if (list.Count == 0)
			{
				return "no kingdoms";
			}
			List<string> list2 = new List<string>();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (Kingdom item2 in list)
			{
				foreach (Kingdom item3 in list)
				{
					if (item2 != item3)
					{
						string item = ((string.Compare(((MBObjectBase)item2).StringId, ((MBObjectBase)item3).StringId) < 0) ? (((MBObjectBase)item2).StringId + "_" + ((MBObjectBase)item3).StringId) : (((MBObjectBase)item3).StringId + "_" + ((MBObjectBase)item2).StringId));
						if (!hashSet.Contains(item) && instance.AreAllied(item2, item3))
						{
							list2.Add($"{item2.Name} (id:{((MBObjectBase)item2).StringId}) ↔ {item3.Name} (id:{((MBObjectBase)item3).StringId})");
							hashSet.Add(item);
						}
					}
				}
			}
			if (list2.Count == 0)
			{
				return "no alliances";
			}
			Kingdom npcKingdom = default(Kingdom);
			ref Kingdom reference = ref npcKingdom;
			IFaction mapFaction = npc.MapFaction;
			reference = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
			if (npcKingdom != null)
			{
				List<string> list3 = list2.Where((string pair) => pair.Contains(((object)npcKingdom.Name).ToString())).ToList();
				List<string> list4 = list2.Where((string pair) => !pair.Contains(((object)npcKingdom.Name).ToString())).ToList();
				if (list3.Any())
				{
					string text = "Your kingdom alliances: " + string.Join(", ", list3);
					if (list4.Any())
					{
						text = text + "; Other alliances: " + string.Join(", ", list4);
					}
					return text;
				}
			}
			return string.Join(", ", list2);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to get alliance status: " + ex.Message);
			return "no alliances";
		}
	}

	private static string GetTradeAgreementsInfo(Hero npc)
	{
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return "Trade agreements system not active";
			}
			DiplomacyManager instance = DiplomacyManager.Instance;
			if (instance == null || !instance.IsInitialized)
			{
				return "Trade agreements system not initialized";
			}
			TradeAgreementSystem tradeAgreementSystem = instance.GetTradeAgreementSystem();
			return tradeAgreementSystem.GenerateTradeAgreementSummary();
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to get trade agreements info: " + ex.Message);
			return "No trade agreements information available";
		}
	}

	private static string GetTributesInfo(Hero npc)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return null;
			}
			DiplomacyManager instance = DiplomacyManager.Instance;
			if (instance == null || !instance.IsInitialized)
			{
				return null;
			}
			IFaction mapFaction = npc.MapFaction;
			Kingdom val = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
			if (val == null)
			{
				return null;
			}
			TributeSystem tributeSystem = instance.GetTributeSystem();
			List<TributeAgreement> tributesPaidBy = tributeSystem.GetTributesPaidBy(val);
			List<TributeAgreement> tributesReceivedBy = tributeSystem.GetTributesReceivedBy(val);
			if (!tributesPaidBy.Any() && !tributesReceivedBy.Any())
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			CampaignTime endTime;
			if (tributesPaidBy.Any())
			{
				stringBuilder.AppendLine("Tributes your kingdom pays:");
				foreach (TributeAgreement tribute in tributesPaidBy)
				{
					Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.ReceiverKingdomId));
					if (val2 != null)
					{
						endTime = tribute.EndTime;
						float remainingDaysFromNow = (endTime).RemainingDaysFromNow;
						stringBuilder.AppendLine($"  - Paying {tribute.DailyAmount} gold/day to {val2.Name} ({remainingDaysFromNow:F0} days left, total paid: {tribute.TotalPaid})");
					}
				}
			}
			if (tributesReceivedBy.Any())
			{
				stringBuilder.AppendLine("Tributes your kingdom receives:");
				foreach (TributeAgreement tribute2 in tributesReceivedBy)
				{
					Kingdom val3 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute2.PayerKingdomId));
					if (val3 != null)
					{
						endTime = tribute2.EndTime;
						float remainingDaysFromNow2 = (endTime).RemainingDaysFromNow;
						stringBuilder.AppendLine($"  - Receiving {tribute2.DailyAmount} gold/day from {val3.Name} ({remainingDaysFromNow2:F0} days left, total received: {tribute2.TotalPaid})");
					}
				}
			}
			return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to get tributes info: " + ex.Message);
			return null;
		}
	}

	private static string GetReparationsInfo(Hero npc)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return null;
			}
			DiplomacyManager instance = DiplomacyManager.Instance;
			if (instance == null || !instance.IsInitialized)
			{
				return null;
			}
			IFaction mapFaction = npc.MapFaction;
			Kingdom val = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
			if (val == null)
			{
				return null;
			}
			ReparationsSystem reparationsSystem = instance.GetReparationsSystem();
			List<ReparationDemand> pendingDemandsForPayer = reparationsSystem.GetPendingDemandsForPayer(val);
			List<ReparationDemand> demandsMadeBy = reparationsSystem.GetDemandsMadeBy(val);
			if (!pendingDemandsForPayer.Any() && !demandsMadeBy.Any())
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			CampaignTime expirationTime;
			if (pendingDemandsForPayer.Any())
			{
				stringBuilder.AppendLine("Reparation demands against your kingdom:");
				foreach (ReparationDemand demand in pendingDemandsForPayer)
				{
					Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == demand.DemandingKingdomId));
					if (val2 != null)
					{
						expirationTime = demand.ExpirationTime;
						float remainingDaysFromNow = (expirationTime).RemainingDaysFromNow;
						stringBuilder.AppendLine($"  - {val2.Name} demands {demand.Amount} gold (expires in {remainingDaysFromNow:F0} days)");
					}
				}
			}
			if (demandsMadeBy.Any())
			{
				stringBuilder.AppendLine("Reparation demands made by your kingdom:");
				foreach (ReparationDemand demand2 in demandsMadeBy)
				{
					Kingdom val3 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == demand2.PayingKingdomId));
					if (val3 != null)
					{
						expirationTime = demand2.ExpirationTime;
						float remainingDaysFromNow2 = (expirationTime).RemainingDaysFromNow;
						stringBuilder.AppendLine($"  - Demanding {demand2.Amount} gold from {val3.Name} (expires in {remainingDaysFromNow2:F0} days)");
					}
				}
			}
			return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to get reparations info: " + ex.Message);
			return null;
		}
	}

	private static string GetTerritoryTransfersInfo()
	{
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return null;
			}
			DiplomacyManager instance = DiplomacyManager.Instance;
			if (instance == null || !instance.IsInitialized)
			{
				return null;
			}
			TerritoryTransferSystem territoryTransferSystem = instance.GetTerritoryTransferSystem();
			List<TerritoryTransferRecord> recentTransfers = territoryTransferSystem.GetRecentTransfers();
			if (!recentTransfers.Any())
			{
				return null;
			}
			return territoryTransferSystem.GenerateTerritoryTransferSummary();
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to get territory transfers info: " + ex.Message);
			return null;
		}
	}

	private static string GetTransferableSettlementsInfo(Hero npc)
	{
		try
		{
			if (!GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
				return null;
			}
			bool isKingdomLeader = npc.IsKingdomLeader;
			Hero mainHero = Hero.MainHero;
			object obj;
			if (mainHero == null)
			{
				obj = null;
			}
			else
			{
				Clan clan = mainHero.Clan;
				obj = ((clan != null) ? clan.Kingdom : null);
			}
			bool flag = obj != null && Hero.MainHero.Clan.Kingdom.Leader == Hero.MainHero;
			if (!isKingdomLeader || !flag)
			{
				return null;
			}
			DiplomacyManager instance = DiplomacyManager.Instance;
			if (instance == null || !instance.IsInitialized)
			{
				return null;
			}
			TerritoryTransferSystem territorySystem = instance.GetTerritoryTransferSystem();
			SettlementOwnershipTracker instance2 = SettlementOwnershipTracker.Instance;
			Kingdom npcKingdom = default(Kingdom);
			ref Kingdom reference = ref npcKingdom;
			IFaction mapFaction = npc.MapFaction;
			reference = (Kingdom)(object)((mapFaction is Kingdom) ? mapFaction : null);
			Kingdom playerKingdom = Hero.MainHero.Clan.Kingdom;
			if (npcKingdom == null || playerKingdom == null)
			{
				return null;
			}
			List<Settlement> warRelevantSettlements = territorySystem.GetWarRelevantSettlements(npcKingdom, playerKingdom);
			if (!warRelevantSettlements.Any())
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("**War-Relevant Settlements (Conquered/Lost/Border):**");
			stringBuilder.AppendLine("(proximity: BORDER=frontline, NEAR=close, MODERATE=mid-range, FAR=distant, DEEP_BEHIND=captured deep in enemy territory)");
			List<Settlement> source = (from s in warRelevantSettlements.Where(delegate(Settlement s)
				{
					Clan ownerClan = s.OwnerClan;
					return ((ownerClan != null) ? ownerClan.Kingdom : null) == npcKingdom;
				})
				orderby territorySystem.GetDistanceToNearestKingdomSettlement(s, playerKingdom)
				select s).ToList();
			List<Settlement> source2 = (from s in warRelevantSettlements.Where(delegate(Settlement s)
				{
					Clan ownerClan = s.OwnerClan;
					return ((ownerClan != null) ? ownerClan.Kingdom : null) == playerKingdom;
				})
				orderby territorySystem.GetDistanceToNearestKingdomSettlement(s, npcKingdom)
				select s).ToList();
			if (source.Any())
			{
				stringBuilder.AppendLine($"Currently owned by {npcKingdom.Name}:");
				foreach (Settlement item in source.Take(10))
				{
					string text = (item.IsTown ? "town" : (item.IsCastle ? "castle" : "settlement")) + (item.HasPort ? ", port" : "");
					string text2 = (instance2.IsCapital(((MBObjectBase)item).StringId) ? " **CAPITAL**" : "");
					string text3 = ((item.OwnerClan != null) ? $"{item.OwnerClan.Name} ({((MBObjectBase)item.OwnerClan).StringId})" : "no owner");
					Town town = item.Town;
					int num = ((town != null && town.Prosperity > 0f) ? ((int)item.Town.Prosperity) : 0);
					string ownershipContextForAI = instance2.GetOwnershipContextForAI(((MBObjectBase)item).StringId);
					string settlementGeoTag = territorySystem.GetSettlementGeoTag(item, npcKingdom, playerKingdom);
					string text4 = "";
					if (!string.IsNullOrEmpty(ownershipContextForAI) && !ownershipContextForAI.Contains("Historical"))
					{
						text4 = " [" + ownershipContextForAI + "]";
					}
					stringBuilder.AppendLine($"  - [{settlementGeoTag}] {item.Name} (id:{((MBObjectBase)item).StringId}, {text}, owner: {text3}, prosperity: {num}){text2}{text4}");
				}
			}
			if (source2.Any())
			{
				if (source.Any())
				{
					stringBuilder.AppendLine();
				}
				stringBuilder.AppendLine($"Currently owned by {playerKingdom.Name}:");
				foreach (Settlement item2 in source2.Take(10))
				{
					string text5 = (item2.IsTown ? "town" : (item2.IsCastle ? "castle" : "settlement")) + (item2.HasPort ? ", port" : "");
					string text6 = (instance2.IsCapital(((MBObjectBase)item2).StringId) ? " **CAPITAL**" : "");
					string text7 = ((item2.OwnerClan != null) ? $"{item2.OwnerClan.Name} ({((MBObjectBase)item2.OwnerClan).StringId})" : "no owner");
					Town town2 = item2.Town;
					int num2 = ((town2 != null && town2.Prosperity > 0f) ? ((int)item2.Town.Prosperity) : 0);
					string ownershipContextForAI2 = instance2.GetOwnershipContextForAI(((MBObjectBase)item2).StringId);
					string settlementGeoTag2 = territorySystem.GetSettlementGeoTag(item2, playerKingdom, npcKingdom);
					string text8 = "";
					if (!string.IsNullOrEmpty(ownershipContextForAI2) && !ownershipContextForAI2.Contains("Historical"))
					{
						text8 = " [" + ownershipContextForAI2 + "]";
					}
					stringBuilder.AppendLine($"  - [{settlementGeoTag2}] {item2.Name} (id:{((MBObjectBase)item2).StringId}, {text5}, owner: {text7}, prosperity: {num2}){text6}{text8}");
				}
			}
			return (stringBuilder.Length > 0) ? stringBuilder.ToString().TrimEnd(Array.Empty<char>()) : null;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to get transferable settlements info: " + ex.Message);
			return null;
		}
	}

	private static string GetVisitedSettlementsInfo(Hero npc, NPCContext context)
	{
		if (context.VisitedSettlements == null || !context.VisitedSettlements.Any())
		{
			return null;
		}
		List<SettlementVisit> list = context.VisitedSettlements.OrderByDescending((SettlementVisit v) => v.VisitTimeDays).Take(5).ToList();
		if (!list.Any())
		{
			return null;
		}
		List<string> list2 = new List<string>();
		bool flag = IsSettlementOwner(npc) || IsKingdomLeader(npc);
		foreach (SettlementVisit item in list)
		{
			Settlement val = Settlement.Find(item.SettlementId);
			if (val == null)
			{
				continue;
			}
			string text = $"{val.Name} (id:{((MBObjectBase)val).StringId})";
			text += $" ({((BasicCultureObject)val.Culture).Name} (culture_id:{((MBObjectBase)val.Culture).StringId})";
			string settlementStatusForNPC = GetSettlementStatusForNPC(npc, val);
			text = text + ", STATUS: " + settlementStatusForNPC;
			text = ((val.MapFaction == null) ? (text + ", independent") : (text + $", {val.MapFaction.Name} (faction_id:{val.MapFaction.StringId})"));
			text += ")";
			if (flag || val.OwnerClan == npc.Clan)
			{
				if (val.Town != null)
				{
					Town town = val.Town;
					text = ((town.Governor == null) ? (text + ", governor: none") : (text + $", governor: {town.Governor.Name} (id:{((MBObjectBase)town.Governor).StringId})"));
					if (town.Prosperity > 5000f)
					{
						text += ", prosperous";
					}
					else if (town.Prosperity < 2000f)
					{
						text += ", poor";
					}
					if (((Fief)town).FoodStocks > 100f)
					{
						text += ", well-fed";
					}
					else if (((Fief)town).FoodStocks < 30f)
					{
						text += ", hungry";
					}
				}
			}
			else
			{
				Random random = new Random();
				if (random.NextDouble() < 0.4 && val.Town != null)
				{
					if (val.Town.Prosperity > 4000f)
					{
						text += ", seems prosperous";
					}
					else if (val.Town.Prosperity < 3000f)
					{
						text += ", looks poor";
					}
				}
				if (random.NextDouble() < 0.3 && val.Town != null)
				{
					text = ((val.Town.Governor == null) ? (text + ", governor: unknown") : (text + $", governor: {val.Town.Governor.Name} (id:{((MBObjectBase)val.Town.Governor).StringId})"));
				}
				if (random.NextDouble() < 0.5 && val.Town != null)
				{
					if (((Fief)val.Town).FoodStocks > 80f)
					{
						text += ", well-supplied";
					}
					else if (((Fief)val.Town).FoodStocks < 40f)
					{
						text += ", short on food";
					}
				}
			}
			int daysAgo = item.GetDaysAgo();
			if (daysAgo >= 0)
			{
				text += $" ({daysAgo} days ago)";
			}
			list2.Add(text);
		}
		return string.Join("; ", list2);
	}

	private static bool IsSettlementOwner(Hero npc)
	{
		return ((IEnumerable<Settlement>)Campaign.Current.Settlements).Any((Settlement s) => s.OwnerClan == npc.Clan);
	}

	private static bool IsKingdomLeader(Hero npc)
	{
		Clan clan = npc.Clan;
		object obj;
		if (clan == null)
		{
			obj = null;
		}
		else
		{
			Kingdom kingdom = clan.Kingdom;
			obj = ((kingdom != null) ? kingdom.Leader : null);
		}
		return obj == npc;
	}

	private static string GetDetailedMilitaryInfo(Hero npc)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Invalid comparison between Unknown and I4
		if (npc.IsNotable && npc.CurrentSettlement?.Village != null)
		{
			Settlement currentSettlement = npc.CurrentSettlement;
			int num = (int)currentSettlement.Militia;
			return $"Your village {currentSettlement.Name} (id:{((MBObjectBase)currentSettlement).StringId}): militia {num} people. These are people who will defend the village — some are currently in the village, others will come from nearby when needed.";
		}
		if ((int)npc.Occupation != 3 && !npc.IsClanLeader)
		{
			return "none";
		}
		StringBuilder stringBuilder = new StringBuilder();
		Clan clan = npc.Clan;
		if (((clan != null) ? clan.Fiefs : null) != null && ((IEnumerable<Town>)npc.Clan.Fiefs).Any())
		{
			stringBuilder.Append("MY HOLDINGS STATUS: ");
			List<string> list = new List<string>();
			foreach (Town item in ((IEnumerable<Town>)npc.Clan.Fiefs).Where((Town f) => ((SettlementComponent)f).IsTown || ((SettlementComponent)f).IsCastle).Take(5))
			{
				int num2 = 0;
				Town town = ((SettlementComponent)item).Settlement.Town;
				if (((town != null) ? ((Fief)town).GarrisonParty : null) != null && ((Fief)((SettlementComponent)item).Settlement.Town).GarrisonParty.MemberRoster != null)
				{
					num2 = ((Fief)((SettlementComponent)item).Settlement.Town).GarrisonParty.MemberRoster.TotalManCount;
				}
				int num3 = (int)((SettlementComponent)item).Settlement.Militia;
				string text = ((((SettlementComponent)item).Settlement.SiegeEvent != null) ? "UNDER SIEGE!" : "safe");
				Town town2 = ((SettlementComponent)item).Settlement.Town;
				int num4 = (int)((town2 != null) ? town2.Prosperity : 0f);
				Town town3 = ((SettlementComponent)item).Settlement.Town;
				int num5 = (int)((town3 != null) ? ((Fief)town3).FoodStocks : 0f);
				Town town4 = ((SettlementComponent)item).Settlement.Town;
				int num6 = (int)((town4 != null) ? town4.Loyalty : 0f);
				list.Add($"{((SettlementComponent)item).Name} (id:{((MBObjectBase)((SettlementComponent)item).Settlement).StringId}, garrison:{num2}, militia:{num3}, prosperity:{num4}, food:{num5}, loyalty:{num6}, {text})");
			}
			stringBuilder.Append(string.Join("; ", list));
		}
		if (npc.CurrentSettlement != null && npc.CurrentSettlement.OwnerClan != npc.Clan)
		{
			Settlement currentSettlement2 = npc.CurrentSettlement;
			bool flag = false;
			if (currentSettlement2.MapFaction == npc.MapFaction)
			{
				flag = true;
			}
			else if (currentSettlement2.MapFaction != null && !FactionManager.IsAtWarAgainstFaction(currentSettlement2.MapFaction, npc.MapFaction))
			{
				flag = true;
			}
			if (flag && (currentSettlement2.IsTown || currentSettlement2.IsCastle))
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(" | ");
				}
				int num7 = 0;
				Town town5 = currentSettlement2.Town;
				if (((town5 != null) ? ((Fief)town5).GarrisonParty : null) != null && ((Fief)currentSettlement2.Town).GarrisonParty.MemberRoster != null)
				{
					num7 = ((Fief)currentSettlement2.Town).GarrisonParty.MemberRoster.TotalManCount;
				}
				Town town6 = currentSettlement2.Town;
				int num8 = (int)((town6 != null) ? town6.Prosperity : 0f);
				Town town7 = currentSettlement2.Town;
				int num9 = (int)((town7 != null) ? ((Fief)town7).FoodStocks : 0f);
				Town town8 = currentSettlement2.Town;
				int num10 = (int)((town8 != null) ? town8.Loyalty : 0f);
				object obj;
				if (currentSettlement2.OwnerClan == null)
				{
					obj = "OWNER: Unknown";
				}
				else
				{
					TextObject name = currentSettlement2.OwnerClan.Name;
					IFaction mapFaction = currentSettlement2.MapFaction;
					obj = string.Format("OWNER: {0} ({1})", name, ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()) ?? "Independent");
				}
				string text2 = (string)obj;
				stringBuilder.Append($"CURRENT LOCATION ({currentSettlement2.Name}, id:{((MBObjectBase)currentSettlement2).StringId}, {text2}): garrison {num7}, militia {(int)currentSettlement2.Militia}, prosperity:{num8}, food:{num9}, loyalty:{num10}");
			}
		}
		return (stringBuilder.Length > 0) ? stringBuilder.ToString() : "none";
	}

	private static string GetNearbySettlementsInfo(Hero npc)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		Vec2 position;
		if (npc.PartyBelongedTo != null)
		{
			position = npc.PartyBelongedTo.GetPosition2D();
		}
		else
		{
			if (npc.CurrentSettlement == null)
			{
				return null;
			}
			position = npc.CurrentSettlement.GetPosition2D();
		}
		var list = (from x in ((IEnumerable<Settlement>)Campaign.Current.Settlements).Where((Settlement s) => s.IsFortification || s.IsVillage).Select(delegate(Settlement s)
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				Vec2 position2D = s.GetPosition2D();
				return new
				{
					Settlement = s,
					Distance = (position2D).Distance(position)
				};
			})
			where x.Distance < 30f && x.Distance > 0.1f
			orderby x.Distance
			select x).Take(7).ToList();
		if (!list.Any())
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (var item in list)
		{
			Settlement settlement = item.Settlement;
			string settlementStatusForNPC = GetSettlementStatusForNPC(npc, settlement);
			IFaction mapFaction = settlement.MapFaction;
			string text = ((mapFaction == null) ? null : ((object)mapFaction.Name)?.ToString()) ?? "Independent";
			IFaction mapFaction2 = settlement.MapFaction;
			string text2 = ((mapFaction2 != null) ? mapFaction2.StringId : null) ?? "none";
			string text3 = (settlement.IsTown ? "Town" : (settlement.IsCastle ? "Castle" : "Village")) + (settlement.HasPort ? " (port)" : "") + (SettlementOwnershipTracker.Instance.IsCapital(((MBObjectBase)settlement).StringId) ? " [CAPITAL]" : "");
			string text4 = "";
			if (EconomicEffectsManager.Instance != null && EconomicEffectsManager.Instance.TryGetSettlementDailyEffect(settlement, out var _, out var _, out var reason))
			{
				text4 = ", Local Situation: " + reason;
			}
			stringBuilder.AppendLine($"- {settlement.Name} (id:{((MBObjectBase)settlement).StringId}): {text3}, {settlementStatusForNPC}, Faction: {text} (id:{text2}), Distance: {item.Distance:F1}{text4}");
		}
		return stringBuilder.ToString();
	}

	private static string GetSettlementStatusForNPC(Hero npc, Settlement settlement)
	{
		if (settlement == null || npc == null)
		{
			return "unknown";
		}
		if (settlement.OwnerClan == npc.Clan)
		{
			return "**YOUR CLAN'S PROPERTY** (DO NOT ATTACK)";
		}
		IFaction mapFaction = npc.MapFaction;
		IFaction mapFaction2 = settlement.MapFaction;
		if (mapFaction != null && mapFaction2 != null)
		{
			if (mapFaction == mapFaction2)
			{
				return "ALLIED (Your Kingdom)";
			}
			if (FactionManager.IsAtWarAgainstFaction(mapFaction, mapFaction2))
			{
				return "**ENEMY** (AT WAR - VALID TARGET)";
			}
			if (GlobalSettings<ModSettings>.Instance.EnableDiplomacy)
			{
			}
			return "NEUTRAL (Not at war)";
		}
		return "NEUTRAL";
	}

	private static string EnhanceCurrentTaskWithActions(Hero npc, string currentTask)
	{
		if (npc == null)
		{
			return currentTask;
		}
		List<string> list = new List<string>();
		try
		{
			Campaign current = Campaign.Current;
			TaskManager taskManager = ((current != null) ? current.GetCampaignBehavior<TaskManager>() : null);
			if (taskManager != null)
			{
				HeroTask activeTask = taskManager.GetActiveTask(npc);
				if (activeTask != null && activeTask.IsActive())
				{
					string text = FormatTaskDescription(activeTask);
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(text);
					}
				}
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[PromptGenerator] Error getting task: " + ex.Message);
		}
		List<string> activeActions = AIActionManager.Instance.GetActiveActions(npc);
		foreach (string item in activeActions)
		{
			string text2 = item;
			string text3 = text2;
			if (!(text3 == "follow_player"))
			{
				if (!(text3 == "go_to_settlement"))
				{
					list.Add(item);
				}
			}
			else
			{
				list.Add("following the player (staying close to them)");
			}
		}
		if (list.Count == 0)
		{
			return (string.IsNullOrEmpty(currentTask) || currentTask == "none") ? "none" : currentTask;
		}
		string text4 = string.Join("; ", list);
		if (!string.IsNullOrEmpty(currentTask) && currentTask != "none")
		{
			return currentTask + "; " + text4;
		}
		return text4;
	}

	private static string FormatTaskDescription(HeroTask task)
	{
		if (task == null || !task.IsActive())
		{
			return null;
		}
		TaskStep currentStep = task.GetCurrentStep();
		if (currentStep == null)
		{
			return null;
		}
		List<string> list = new List<string>();
		string text = FormatStepDescription(currentStep, isCurrent: true);
		if (!string.IsNullOrEmpty(text))
		{
			list.Add(text);
		}
		List<TaskStep> source = task.Steps.Where((TaskStep s) => s.Status == TaskStepStatus.Completed).ToList();
		if (source.Any())
		{
			IEnumerable<string> enumerable = from s in source
				select FormatStepDescription(s, isCurrent: false) into d
				where !string.IsNullOrEmpty(d)
				select d;
			if (enumerable.Any())
			{
				list.Add("completed: " + string.Join(", ", enumerable));
			}
		}
		int currentStepIndex = task.CurrentStepIndex;
		List<TaskStep> source2 = (from s in task.Steps.Skip(currentStepIndex + 1)
			where s.Status == TaskStepStatus.Pending
			select s).ToList();
		if (source2.Any())
		{
			IEnumerable<string> enumerable2 = from s in source2
				select FormatStepDescription(s, isCurrent: false) into d
				where !string.IsNullOrEmpty(d)
				select d;
			if (enumerable2.Any())
			{
				list.Add("upcoming: " + string.Join(", then ", enumerable2));
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		string text2 = string.Join("; ", list);
		float progress = task.GetProgress();
		if (progress > 0f && progress < 1f)
		{
			text2 += $" (progress: {(int)(progress * 100f)}%)";
		}
		return text2;
	}

	private static string FormatStepDescription(TaskStep step, bool isCurrent)
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		if (step == null)
		{
			return null;
		}
		string text = (isCurrent ? "currently " : "");
		string text2 = "";
		switch (step.StepType)
		{
		case TaskStepType.GoToSettlement:
		{
			Settlement targetSettlement4 = step.GetTargetSettlement();
			if (targetSettlement4 != null)
			{
				if (step.Status == TaskStepStatus.InProgress)
				{
					text2 = " (traveling)";
				}
				else if (step.Status == TaskStepStatus.Completed)
				{
					text2 = " (arrived)";
				}
				return $"{text}traveling to {targetSettlement4.Name}{text2}";
			}
			return text + "traveling to settlement" + text2;
		}
		case TaskStepType.WaitInSettlement:
		{
			Settlement targetSettlement3 = step.GetTargetSettlement();
			if (targetSettlement3 != null)
			{
				if (step.Status == TaskStepStatus.InProgress && step.WaitUntilTime.HasValue)
				{
					CampaignTime value = step.WaitUntilTime.Value;
					float remainingDaysFromNow = (value).RemainingDaysFromNow;
					text2 = ((!(remainingDaysFromNow > 0f)) ? " (wait completed)" : $" (waiting, {remainingDaysFromNow:F1} days remaining)");
				}
				else if (step.Status == TaskStepStatus.Completed)
				{
					text2 = " (wait completed)";
				}
				return $"{text}waiting in {targetSettlement3.Name} for {step.WaitDays} days{text2}";
			}
			return $"{text}waiting in settlement for {step.WaitDays} days{text2}";
		}
		case TaskStepType.ReturnToPlayer:
			if (step.Status == TaskStepStatus.InProgress)
			{
				text2 = " (returning)";
			}
			else if (step.Status == TaskStepStatus.Completed)
			{
				text2 = " (returned)";
			}
			return text + "returning to player" + text2;
		case TaskStepType.FollowPlayer:
			if (step.Status == TaskStepStatus.InProgress)
			{
				text2 = " (following)";
			}
			else if (step.Status == TaskStepStatus.Completed)
			{
				text2 = " (following completed)";
			}
			return text + "following the player" + text2;
		case TaskStepType.AttackParty:
		{
			string text3 = (string.IsNullOrEmpty(step.TargetPartyId) ? "the assigned target" : step.TargetPartyId);
			if (step.Status == TaskStepStatus.InProgress)
			{
				text2 = " (en route)";
			}
			else if (step.Status == TaskStepStatus.Completed)
			{
				text2 = " (attack finished)";
			}
			return text + "attacking party '" + text3 + "'" + text2;
		}
		case TaskStepType.SiegeSettlement:
		{
			Settlement targetSettlement2 = step.GetTargetSettlement();
			string text6 = ((targetSettlement2 == null) ? null : ((object)targetSettlement2.Name)?.ToString()) ?? "the assigned settlement";
			if (step.Status == TaskStepStatus.InProgress)
			{
				text2 = " (marching / preparing)";
			}
			else if (step.Status == TaskStepStatus.Completed)
			{
				text2 = " (siege completed)";
			}
			return text + "besieging " + text6 + text2;
		}
		case TaskStepType.PatrolSettlement:
		{
			Settlement targetSettlement = step.GetTargetSettlement();
			string text4 = ((targetSettlement == null) ? null : ((object)targetSettlement.Name)?.ToString()) ?? "the assigned settlement";
			string text5 = ((step.PatrolDurationDays > 0f) ? $"{step.PatrolDurationDays:F1} days" : "unspecified time");
			if (step.Status == TaskStepStatus.InProgress)
			{
				text2 = " (patrolling)";
			}
			else if (step.Status == TaskStepStatus.Completed)
			{
				text2 = " (patrol completed)";
			}
			return text + "patrolling around " + text4 + " for " + text5 + text2;
		}
		case TaskStepType.Custom:
			if (!string.IsNullOrEmpty(step.Description))
			{
				return text + step.Description + text2;
			}
			return text + "custom task" + text2;
		default:
			return null;
		}
	}

	private static string GetAvailableActionsPrompt(Hero npc)
	{
		if (npc == null)
		{
			return "";
		}
		string text = AIActionIntegration.Instance.GenerateActionsPrompt(npc);
		if (string.IsNullOrEmpty(text))
		{
			return "";
		}
		return text;
	}

	private static string GetShipInfo(PartyBase party, bool isAtSea)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		if (party == null || party.Ships == null || ((List<Ship>)(object)party.Ships).Count == 0)
		{
			return "";
		}
		MBReadOnlyList<Ship> ships = party.Ships;
		int count = ((List<Ship>)(object)ships).Count;
		Ship val = party.FlagShip;
		if (val == null)
		{
			val = ((List<Ship>)(object)ships)[0];
		}
		if (val == null || val.ShipHull == null)
		{
			return "";
		}
		string text = ((object)val.Name)?.ToString();
		if (string.IsNullOrEmpty(text))
		{
			text = ((object)val.ShipHull.Name)?.ToString() ?? "unknown ship";
		}
		string text2 = ((object)val.ShipHull.Type/*cast due to .constrained prefix*/).ToString().ToLowerInvariant();
		string text3 = "";
		text3 = (isAtSea ? ((count != 1) ? $"You are currently sailing at sea with {count} ships, your flagship being the {text2} ship named \"{text}\"" : ("You are currently sailing on your " + text2 + " ship named \"" + text + "\" at sea")) : ((count != 1) ? $"You own {count} ships, your flagship being a {text2} ship named \"{text}\"" : ("You own a " + text2 + " ship named \"" + text + "\"")));
		return text3 + ".";
	}

	private static string GetWeatherInfo(Hero npc)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Invalid comparison between Unknown and I4
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Invalid comparison between Unknown and I4
		if (npc != null)
		{
			Campaign current = Campaign.Current;
			object obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				GameModels models = current.Models;
				obj = ((models != null) ? models.MapWeatherModel : null);
			}
			if (obj != null)
			{
				try
				{
					CampaignVec2 position;
					Vec2 val;
					if (npc.PartyBelongedTo != null)
					{
						position = npc.PartyBelongedTo.Position;
						val = (position).ToVec2();
					}
					else if (npc.CurrentSettlement != null)
					{
						position = npc.CurrentSettlement.Position;
						val = (position).ToVec2();
					}
					else
					{
						if (npc.StayingInSettlement == null)
						{
							return null;
						}
						position = npc.StayingInSettlement.Position;
						val = (position).ToVec2();
					}
					MapWeatherModel mapWeatherModel = Campaign.Current.Models.MapWeatherModel;
					WeatherEvent weatherEventInPosition = mapWeatherModel.GetWeatherEventInPosition(val);
					string weatherDescription = GetWeatherDescription(weatherEventInPosition);
					return (npc.PartyBelongedTo == null || !npc.PartyBelongedTo.IsCurrentlyAtSea) ? ("The weather is " + weatherDescription) : (((int)weatherEventInPosition == 5) ? "You are sailing through a storm at sea" : (((int)weatherEventInPosition <= 0) ? "You are sailing at sea with clear weather" : ("You are at sea. " + weatherDescription)));
				}
				catch (Exception ex)
				{
					LogDebug("[GetWeatherInfo] Error getting weather: " + ex.Message);
					return null;
				}
			}
		}
		return null;
	}

	private static string GetWeatherDescription(WeatherEvent weatherEvent)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected I4, but got Unknown
		return (int)weatherEvent switch
		{
			0 => "clear", 
			1 => "lightly raining", 
			2 => "heavily raining", 
			3 => "snowing", 
			4 => "blizzarding", 
			5 => "stormy", 
			_ => "unknown weather", 
		};
	}

	private static bool CanNPCBeKilledThroughRoleplay(Hero npc)
	{
		if (npc == null || npc.IsDead)
		{
			return false;
		}
		if (Mission.Current != null && Settlement.CurrentSettlement != null)
		{
			Agent val = ((IEnumerable<Agent>)Mission.Current.Agents).FirstOrDefault((Func<Agent, bool>)((Agent a) => a != null && a.Character != null && (object)a.Character == npc.CharacterObject && a.IsActive() && a.IsHuman));
			if (val != null)
			{
				return true;
			}
		}
		if (npc.IsPrisoner)
		{
			if (npc.PartyBelongedToAsPrisoner != null && npc.PartyBelongedToAsPrisoner == PartyBase.MainParty)
			{
				return true;
			}
			if (npc.CurrentSettlement != null && (npc.CurrentSettlement.IsTown || npc.CurrentSettlement.IsCastle))
			{
				return true;
			}
			return false;
		}
		if (npc.PartyBelongedTo != null && npc.PartyBelongedTo != MobileParty.MainParty)
		{
			int totalManCount = npc.PartyBelongedTo.MemberRoster.TotalManCount;
			if (totalManCount > 1)
			{
				return false;
			}
			return true;
		}
		if (npc.PartyBelongedTo == MobileParty.MainParty)
		{
			return true;
		}
		if (npc.CurrentSettlement != null && npc.PartyBelongedTo == null)
		{
			return true;
		}
		return true;
	}

	private static void LogDebug(string message)
	{
		try
		{
			Campaign current = Campaign.Current;
			((current != null) ? current.GetCampaignBehavior<AIInfluenceBehavior>() : null)?.LogMessage(message);
		}
		catch
		{
		}
	}

	private static string GenerateInternalThoughtsSection(Hero npc, NPCContext context, bool isMessengerMode)
	{
		if (npc == null || context == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("### CRITICAL: Internal Thought Process (REQUIRED BEFORE RESPONDING) ###");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**PRIVATE thinking process for authentic roleplay. Player will NOT see this.**");
		stringBuilder.AppendLine();
		string value = WorldInfoManager.Instance?.ReadActionRules();
		bool flag = !string.IsNullOrEmpty(value);
		if (flag)
		{
			stringBuilder.AppendLine("**OVERRIDE RULES (HIGHEST PRIORITY - CHECK IN STEP BELOW)**");
			stringBuilder.AppendLine("Player's custom rules that OVERRIDE all other instructions:");
			stringBuilder.AppendLine(value);
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine("**STEP 0: VERIFY FACTS (MANDATORY)**");
		stringBuilder.AppendLine("Before reasoning, verify CURRENT DATA, note SOURCE:");
		stringBuilder.AppendLine("- Location/Task/Present/Environment → verify string_ids");
		stringBuilder.AppendLine("- Do NOT confuse OWNERSHIP with LOCATION");
		stringBuilder.AppendLine("- Facts ONLY from CURRENT DATA, otherwise → UNKNOWN. Character names ONLY from data — NEVER invent.");
		stringBuilder.AppendLine("Format: internal_thoughts starts with 'FACT CHECK:' + \"[Source] → [Fact]\"");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 1: Analyze Situation**");
		stringBuilder.AppendLine("What happened? What does player want? My reaction? (emotions) Hidden agenda?");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 2: Character's Inner World**");
		stringBuilder.AppendLine($"What would {npc.Name} GENUINELY think/feel? Internal conflicts? (duty/desire, honor/pragmatism) Hidden motives/fears? Personality/culture influence? True to self?");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 3: Trust & Relationship**");
		stringBuilder.AppendLine("Refer to Trust and Relation values from Character Briefing section below.");
		stringBuilder.AppendLine("Do I trust? (open/cautious/defensive) Past influence? What to reveal/conceal? Manipulation? suspected_lie = true ONLY if PROVABLE contradiction with CURRENT DATA.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 4: Conversation Context**");
		stringBuilder.AppendLine("Does response contradict previous words? Situation changed? Emotional dynamics? (improving/deteriorating/stable) Correct escalation_state? (neutral→tense→critical)");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 5: Action Constraints (MANDATORY)**");
		stringBuilder.AppendLine("Check if any action is ALLOWED right now:");
		stringBuilder.AppendLine("- Only use actions if player explicitly agreed/requested AND you accept.");
		stringBuilder.AppendLine("- Exception: `quest_action` with `create_quest` is allowed when the player clearly came for a task (e.g. sent by someone they name, or directly asks you to give work) and you accept — you may include `spawn_party` in that same JSON. For an **ongoing quest from another NPC**, use `update_quest` with the correct `quest_id` and optional `spawn_party` instead of creating a duplicate quest.");
		stringBuilder.AppendLine("- Respect role/authority limits (leader/vassal/companion), prisoner state, war/peace status.");
		stringBuilder.AppendLine("- If unsure or not confirmed → keep action fields absent/none.");
		stringBuilder.AppendLine("- Check Previous Response: if action (item_transfers, money_transfer, quest_action) was ALREADY in your last JSON, it was EXECUTED. Do NOT repeat it.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**STEP 6: Claimed Identity Fields (MANDATORY)**");
		stringBuilder.AppendLine("Update claimed_name/claimed_clan/claimed_age ONLY if player explicitly stated them in spoken dialogue.");
		stringBuilder.AppendLine("Never infer from actions, metadata, parties, kingdoms, or surroundings. Otherwise keep null.");
		stringBuilder.AppendLine();
		int num = 7;
		if (GlobalSettings<ModSettings>.Instance.PromptEnableQuests && !isMessengerMode)
		{
			stringBuilder.AppendLine($"**STEP {num}: Quest Considerations**");
			stringBuilder.AppendLine("Review the quest data in the Quests section below to make your decision:");
			stringBuilder.AppendLine("- If you have active quests you gave: check update_logs and progress. Has a target NPC confirmed anything? Use `complete_quest` ONLY if player EXPLICITLY reports completion AND you believe them (check AI NOTES, update logs, progress).");
			stringBuilder.AppendLine("- Also scan Recent Events — you receive world events regardless of distance. If a relevant event is there, it is objective proof; use it to verify the quest without requiring the player to describe it verbally.");
			stringBuilder.AppendLine("- Use `fail_quest` if quest is clearly failed or overdue and player admits it.");
			stringBuilder.AppendLine("- If you are a target NPC for incoming quests: check AI NOTES for what's expected. If your part is done, use `update_quest`. Only use `complete_quest` if you are the designated completer.");
			stringBuilder.AppendLine("- If no active quests: consider proposing a new quest if it feels natural. Remember the TWO-TURN rule and its **Exception** in the Quests section (referral / sent-on-behalf may allow same-turn `create_quest`).");
			stringBuilder.AppendLine("- ALWAYS provide `completion_reason` when completing or failing.");
			stringBuilder.AppendLine("- Quest history factors into trust — repeated failures = less trust.");
			stringBuilder.AppendLine();
			num++;
		}
		if (context.IsRomanceEligible)
		{
			stringBuilder.AppendLine($"**STEP {num}: Romance**");
			stringBuilder.AppendLine("Refer to Romance Status values from Character Briefing section below.");
			stringBuilder.AppendLine("Romantic attraction? Conflict with priorities? Forward/cautious? Cultural expectations?");
			stringBuilder.AppendLine();
			num++;
		}
		if (!isMessengerMode)
		{
			stringBuilder.AppendLine($"**STEP {num}: Practical/Political**");
			stringBuilder.AppendLine("Consequences of agree/refuse? Impact on clan/kingdom/alliances? Negotiate/demand/refuse? Opportunity or trap?");
			stringBuilder.AppendLine();
			num++;
		}
		int num2 = num;
		stringBuilder.AppendLine($"**STEP {num2}: Response Strategy**");
		stringBuilder.AppendLine("Tone? (friendly/hostile/neutral/flirt/formal/casual) Direct or diplomatic? Actions? (attack/surrender/accept/refuse/negotiate) True to character + achieve goals?");
		stringBuilder.AppendLine("Checks: personality/culture reflected? ALL string_ids valid? (no ID → role-play uncertainty) Parameters correct?");
		stringBuilder.AppendLine();
		num++;
		int num3 = num;
		stringBuilder.AppendLine($"**STEP {num3}: Character Consistency**");
		stringBuilder.AppendLine("Response = personality/speech/culture? Cultural words/phrases VISIBLE?");
		stringBuilder.AppendLine();
		num++;
		if (flag)
		{
			stringBuilder.AppendLine($"**STEP {num}: VERIFY OVERRIDE RULES COMPLIANCE (MANDATORY)**");
			stringBuilder.AppendLine("Response complies with ALL rules above? Action complies with restrictions? If violated → change response. ABSOLUTE PRIORITY over all else.");
			stringBuilder.AppendLine("If violated: 1) Acknowledge in internal_thoughts 2) Explain adjustment 3) Modify to comply");
			stringBuilder.AppendLine();
			num++;
		}
		int num4 = num;
		stringBuilder.AppendLine($"**STEP {num4}: Final Check**");
		stringBuilder.AppendLine("All consistent? No contradictions? All checks passed? JSON fields (tone, decision, suspected_lie, escalation_state) justified? string_ids valid?");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**OUTPUT:**");
		stringBuilder.AppendLine("JSON: `internal_thoughts` (500-1500 chars) - PRIVATE reasoning from all steps" + (flag ? " + rules compliance" : "") + ". `response` - words/actions player sees.");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("**CRITICAL:** 'FACT CHECK:' at start of internal_thoughts. CURRENT DATA ONLY. internal_thoughts justifies ALL JSON fields. Response = thoughts + facts." + (flag ? " Override Rules = ABSOLUTE PRIORITY." : ""));
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}

	private static string GetQuestSection(Hero npc, NPCContext context)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("### Quests ###\n");
		stringBuilder.Append("You can create quests for the player.\n- **Spawning hostile or neutral parties on the map** uses `\"spawn_party\": {...}` inside `quest_action` with `\"action\": \"create_quest\"` OR `\"action\": \"update_quest\"` (same `quest_id` as the ongoing quest from the quest giver) — e.g. an informant NPC reveals where the bandits are and you attach a new hostile party to the **existing** Jathea quest. There is no separate spawn API in `technical_action`. If `quest_action` is null, nothing is spawned.\n- Create quests based on events happening in the game, prioritize using technical data.\n- To create a quest: set `quest_action` with `\"action\": \"create_quest\"`, plus `\"title\"`, `\"description\"`, `\"duration_days\"` (7-60).\n- `\"description\"`: Player-facing text shown in the quest journal. Write 2–4 sentences in plain prose explaining what the player must do (e.g. \"Bring 30 units of grain to Vasya in Epicrotea. He will reward you.\"). Do NOT use JSON, technical format, or string_ids — the player sees this directly. Put technical specifics in `ai_verification_notes` instead.\n- `\"target_npc_ids\"`: array of NPC string_ids involved in the quest (e.g., NPCs the player must visit). Each target NPC can UPDATE the quest (add log, set progress) but NOT complete it unless designated.\n- `\"completer_npc_id\"`: string_id of the NPC who can COMPLETE the quest. If empty/null, only YOU (quest giver) can complete it. Use this when the player does NOT need to return to you.\n- `\"ai_verification_notes\"`: PRIVATE notes for AI only (player never sees this). Describe EXACTLY what the player must do, quantities, items, conditions — so any NPC in the chain can verify if the player is telling the truth. Be specific (e.g., \"Player must deliver 30 units of grain to Vasya. Vasya should check player's inventory.\").\n- `\"progress_target\"` + `\"progress_label\"`: optional — use for numeric progress (e.g., 30 grain delivered). Omit to create a quest with NO progress tracking. If omitted, set_progress is not used for this quest.\n- target_npc_ids MUST contain valid string_ids from CURRENT DATA. If unknown, set to empty array [].\n- Quest creation is usually TWO-TURN: Turn 1 — DESCRIBE the quest (no quest_action). Turn 2 — CREATE after the player agrees.\n- **Exception:** If the player already said they were sent by someone (e.g. by name) or are here to handle a specific threat, and you confirm that task in dialogue, you may output `create_quest` (with `spawn_party` if new enemies must exist on the map) in that **same** response — the referral counts as accepting a job; you do not need to wait for a second \"I agree\".\n- Do NOT create quests every conversation.\n- `\"completion_reason\"`: when completing or failing, ALWAYS provide a reason explaining WHY (this is saved in history).\n" +
			"Rewards on completion (all optional, combine freely):\n" +
			"- `\"reward_gold\"`: gold given to player on success.\n" +
			"- `\"reward_items\"`: array of {\"item_name\": \"<natural item name>\", \"count\": N} given on success. Use plain names the game would recognise (e.g. \"grain\", \"iron\", \"linen cloth\", \"wool\", \"pottery\", \"horses\"). The system will fuzzy-match your name to the closest real item.\n" +
			"- `\"reward_skill\"`: skill string_id (e.g. \"OneHanded\", \"Charm\", \"Trade\", \"Steward\", \"Medicine\") to grant XP on success.\n" +
			"- `\"reward_skill_xp\"`: integer XP amount (50–2000) for the skill above.\n" +
			"- `\"crime_rating_change\"`: integer (negative = reduce crime, positive = increase). Applied to the player's current kingdom.\n" +
			"- `\"influence_change\"`: integer influence change for the player's clan (positive = gain, negative = lose).\n" +
			"Spawning parties and NPCs (optional, works with **create_quest** or **update_quest**):\n" +
			"- `\"spawn_party\"`: object — spawns a party and/or a single NPC on the world map or in a settlement. On **update_quest**, use the real `quest_id` from **Active quests you gave** / **Quests involving you** so the spawned party is linked to that ongoing quest (preferred when the player already has a quest from another NPC and you are only adding the enemy spawn). Use ONLY when the quest requires NEW entities — do NOT use if the quest targets an existing NPC (e.g. kill an existing lord; verification is via Recent Events). Can spawn: (1) a leaderless party (omit `name`, use party fields) — bandits, patrols, etc.; no NPC, no one to talk to; (2) a named NPC leading a party (`name` + party fields); (3) a single NPC (`name`, `party_size`: 0 or omit party fields). All names are fuzzy-matched.\n" +
			"  - `\"name\"`: NPC name. If provided, creates a named hero the player can talk to and fight. If omitted with party fields, creates a leaderless party — no NPC, no one to talk to.\n" +
			"  - `\"alignment\"`: REQUIRED — `\"friendly\"`, `\"hostile\"`, or `\"neutral\"`. Determines faction: friendly = allied to player, hostile = enemy faction or bandits, neutral = local settlement owner.\n" +
			"  - `\"culture\"`: determines appearance and default equipment. Available cultures: " + GetAvailableCultures() + ".\n" +
			"  - `\"backstory\"`: brief backstory (shapes how this NPC talks in conversation).\n" +
			"  - `\"personality\"`: personality traits (affects speech patterns).\n" +
			"  - `\"is_female\"`: true/false (optional).\n" +
			"  - `\"age\"`: 18–70 (optional, default 30).\n" +
			"  - `\"settlement\"`: town/village name to spawn near (e.g. \"Epicrotea\"). Defaults to nearest town.\n" +
			"  - `\"faction\"`: kingdom/clan name. Usually omit — alignment handles it. Available kingdoms: " + GetAvailableKingdoms() + ".\n" +
			"  - `\"equipment\"`: object — override default gear. All item names fuzzy-matched.\n" +
			"    - `\"weapon\"`, `\"shield\"`, `\"head\"`, `\"body\"`, `\"cape\"`, `\"gloves\"`, `\"legs\"`, `\"horse\"`: item names.\n" +
			"    - `\"tier\"`: 0–6 — prefer items of this quality level.\n" +
			"  - `\"party_name\"`: if set, NPC leads a party on the world map (e.g. \"Kargas's Raiders\").\n" +
			"  - `\"party_troops\"`: troop types (e.g. [\"forest bandit\", \"looter\"]). Fuzzy-matched.\n" +
			"  - `\"party_size\"`: total troops (0–5000). 0 = NPC travels alone.\n" +
			"  Examples:\n" +
			"    Quest giver in town: {\"name\": \"Aldric\", \"alignment\": \"friendly\", \"culture\": \"Vlandian\", \"backstory\": \"A merchant who lost his caravan\", \"personality\": \"Nervous, grateful\", \"settlement\": \"Epicrotea\"}\n" +
			"    Hostile warband: {\"name\": \"Kargas\", \"alignment\": \"hostile\", \"culture\": \"Sturgian\", \"backstory\": \"A renegade Sturgian warlord\", \"personality\": \"Cruel, mocking\", \"equipment\": {\"weapon\": \"two handed axe\", \"head\": \"wolf head\", \"tier\": 4}, \"party_name\": \"Kargas's Raiders\", \"party_troops\": [\"sturgian raider\"], \"party_size\": 30}\n" +
			"    Leaderless bandit party: {\"alignment\": \"hostile\", \"party_name\": \"Roadside Bandits\", \"party_troops\": [\"looter\"], \"party_size\": 15}\n" +
			"  IMPORTANT: spawn_party should NOT be used when: (1) the quest targets an existing lord — the lord already exists; completer verifies via Recent Events (HeroKilled); (2) the quest targets an existing party from Nearby Parties (bandits, patrols — not a lord's party) — such parties are not quest-linked and cannot be verified; spawn a NEW party instead. For combat quests, always spawn a NEW party unless the target is an existing lord. Use a named NPC leader for important foes, or a leaderless party (omit `name`) for generic enemies.\n");
		stringBuilder.Append("\n");
		return stringBuilder.ToString();
	}

	private static string GetQuestDynamicData(Hero npc, NPCContext context)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		List<AIQuestInfo> activeAIQuests = context.ActiveAIQuests;
		bool flag = activeAIQuests != null && activeAIQuests.Count > 0;
		List<AIQuestInfo> incomingAIQuests = context.IncomingAIQuests;
		bool flag2 = incomingAIQuests != null && incomingAIQuests.Count > 0;
		List<AIQuestHistoryEntry> completedQuestHistory = context.CompletedQuestHistory;
		bool flag3 = completedQuestHistory != null && completedQuestHistory.Count > 0;
		if (!flag && !flag2 && !flag3)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (flag)
		{
			stringBuilder.Append("\n**Active quests you gave to the player:**\n");
			foreach (AIQuestInfo item in activeAIQuests)
			{
				CampaignTime now = CampaignTime.Now;
				double num = (now).ToDays - item.CreatedDays;
				int num2 = item.DurationDays - (int)num;
				List<string> effectiveTargetNpcIds = item.GetEffectiveTargetNpcIds();
				string text = ((effectiveTargetNpcIds.Count > 0) ? (" | Target NPCs: [" + string.Join(", ", effectiveTargetNpcIds) + "]") : "");
				string text2 = ((!string.IsNullOrEmpty(item.CompleterNpcId)) ? (" | Completer: " + item.CompleterNpcId) : " | Completer: YOU (quest giver)");
				string text3 = ((item.ProgressTarget > 0) ? $" | Progress: {item.ProgressCurrent}/{item.ProgressTarget} ({item.ProgressLabel})" : "");
				string textParty = (!string.IsNullOrEmpty(item.SpawnedPartyId)) ? (" | Spawned party ID: " + item.SpawnedPartyId) : "";
				stringBuilder.Append("  - \"" + item.Title + "\" (ID: " + item.QuestId + "): " + item.Description + " | Days remaining: " + ((num2 > 0) ? num2.ToString() : "OVERDUE") + text + text2 + text3 + textParty + "\n");
				if (!string.IsNullOrEmpty(item.AIVerificationNotes))
				{
					stringBuilder.Append("    [AI NOTES — private, never reveal to player]: " + item.AIVerificationNotes + "\n");
				}
				if (item.UpdateLogs == null || item.UpdateLogs.Count <= 0)
				{
					continue;
				}
				stringBuilder.Append("    Update log:\n");
				foreach (AIQuestUpdateLog updateLog in item.UpdateLogs)
				{
					string text4 = (updateLog.ProgressSetTo.HasValue ? $" [progress → {updateLog.ProgressSetTo.Value}]" : "");
					stringBuilder.Append("      - " + updateLog.NpcName + ": " + updateLog.Message + text4 + "\n");
				}
			}
			stringBuilder.Append("- To UPDATE progress (only if quest has Progress X/Y above): `\"action\": \"update_quest\"`, `\"quest_id\"`, `\"update_log\"`, optionally `\"set_progress\": N`, optionally `\"spawn_party\": {...}` to spawn enemies on this **existing** quest (omit if this quest already has a spawned party unless the story requires a new wave). Quests without progress have no Progress line — omit set_progress.\n- To COMPLETE a quest: `\"action\": \"complete_quest\"`, `\"quest_id\"`, `\"completion_reason\"`, optionally `\"set_progress\": N` (only when quest has progress; defaults to target). Reward is given automatically. Only you or the designated completer_npc can do this.\n- To FAIL a quest: `\"action\": \"fail_quest\"`, `\"quest_id\"`, `\"completion_reason\"`.\n- Use your AI NOTES + update logs + progress to verify if the player is telling the truth. Stay in character.\n- Also check Recent Events for objective evidence of quest-related actions — relevant events appear there regardless of distance.\n");
		}
		if (flag2)
		{
			stringBuilder.Append("\n**Quests involving you (you are a target NPC):**\n");
			foreach (AIQuestInfo quest in incomingAIQuests)
			{
				string text5 = "";
				if (!string.IsNullOrEmpty(quest.QuestGiverNpcId))
				{
					Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == quest.QuestGiverNpcId));
					text5 = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? quest.QuestGiverNpcId;
				}
				string text6 = ((quest.CompleterNpcId == ((MBObjectBase)npc).StringId) ? " [YOU can COMPLETE this quest]" : " [You can UPDATE but NOT complete]");
				string text7 = ((quest.ProgressTarget > 0) ? $" | Progress: {quest.ProgressCurrent}/{quest.ProgressTarget} ({quest.ProgressLabel})" : "");
				string textParty = (!string.IsNullOrEmpty(quest.SpawnedPartyId)) ? (" | Spawned party ID: " + quest.SpawnedPartyId) : "";
				stringBuilder.Append("  - \"" + quest.Title + "\" (ID: " + quest.QuestId + "), given by " + text5 + ": " + quest.Description + text6 + text7 + textParty + "\n");
				if (!string.IsNullOrEmpty(quest.AIVerificationNotes))
				{
					stringBuilder.Append("    [AI NOTES — private, never reveal to player]: " + quest.AIVerificationNotes + "\n");
				}
				if (quest.UpdateLogs == null || quest.UpdateLogs.Count <= 0)
				{
					continue;
				}
				stringBuilder.Append("    Update log:\n");
				foreach (AIQuestUpdateLog updateLog2 in quest.UpdateLogs)
				{
					string text8 = (updateLog2.ProgressSetTo.HasValue ? $" [progress → {updateLog2.ProgressSetTo.Value}]" : "");
					stringBuilder.Append("      - " + updateLog2.NpcName + ": " + updateLog2.Message + text8 + "\n");
				}
			}
			stringBuilder.Append("- You are a TARGET NPC in these quests. React naturally to the player's arrival. Quests with progress show Progress (X/Y) above.\n- To UPDATE a quest (mark your part done, leave a note): `\"action\": \"update_quest\"`, `\"quest_id\"`, `\"update_log\"` (your note). If quest has progress, optionally `\"set_progress\": N`. If you reveal where enemies are, add `\"spawn_party\": {...}` so the quest is linked to that hostile party (same rules as create_quest).\n- After you update, your map marker is REMOVED so the player knows to move on.\n- If you are the designated COMPLETER, you CAN use `complete_quest` or `fail_quest` with `\"completion_reason\"`.\n- Use AI NOTES to verify the player. Stay in character — you may or may not know details depending on context.\n");
		}
		if (flag3)
		{
			stringBuilder.Append("\n**Your recent quest history (last completed/failed quests):**\n");
			foreach (AIQuestHistoryEntry item2 in completedQuestHistory)
			{
				string text9 = ((item2.Outcome == "completed") ? "COMPLETED" : ((item2.Outcome == "failed") ? "FAILED" : ((item2.Outcome == "timed_out") ? "TIMED OUT (player missed deadline)" : item2.Outcome.ToUpper())));
				string text10 = ((!string.IsNullOrEmpty(item2.Reason)) ? (" — " + item2.Reason) : "");
				stringBuilder.Append("  - \"" + item2.Title + "\": " + text9 + text10 + "\n");
			}
			stringBuilder.Append("- Use this history to inform your attitude. Repeated failures = less trust. Successes = more trust.\n");
		}
		stringBuilder.Append("\n");
		return stringBuilder.ToString();
	}

	private static string GetQuestJsonFieldDescription(Hero npc, NPCContext context, bool isMessengerMode)
	{
		if (isMessengerMode)
		{
			return "";
		}
		return "- `quest_action`: (object) Quest-related action. **Omit if no quest interaction.**\n" +
		"  Create: {\"action\": \"create_quest\", \"title\": \"...\", \"description\": \"...\", \"duration_days\": N, \"target_npc_ids\": [\"id1\"], \"completer_npc_id\": \"id or null\", \"ai_verification_notes\": \"private notes\", \"progress_target\": N_or_null, \"progress_label\": \"label_or_null\", " +
		"\"reward_gold\": N, \"reward_items\": [{\"item_name\": \"grain\", \"count\": 10}], \"reward_skill\": \"Charm\", \"reward_skill_xp\": 200, \"crime_rating_change\": -10, \"influence_change\": 5, " +
		"\"spawn_party\": {\"name\": \"Kargas\", \"alignment\": \"hostile\", \"culture\": \"Sturgian\", \"backstory\": \"A renegade Sturgian warlord\", \"personality\": \"Cruel\", \"equipment\": {\"weapon\": \"two handed axe\", \"tier\": 4}, \"party_name\": \"Kargas's Raiders\", \"party_troops\": [\"sturgian raider\"], \"party_size\": 30}}\n" +
		"  Update (existing quest — use real quest_id; add spawn_party when revealing enemies for a quest from another NPC): {\"action\": \"update_quest\", \"quest_id\": \"...\", \"update_log\": \"your note\", \"set_progress\": N_or_null, \"spawn_party\": {\"alignment\": \"hostile\", \"party_troops\": [\"looter\"], \"party_size\": 15}}\n" +
		"  Complete: {\"action\": \"complete_quest\", \"quest_id\": \"...\", \"completion_reason\": \"why\", \"set_progress\": N_or_null} — all rewards applied automatically\n" +
		"  Fail: {\"action\": \"fail_quest\", \"quest_id\": \"...\", \"completion_reason\": \"why failed\"}\n";
	}

	private static string GetAvailableCultures()
	{
		try
		{
			var cultures = Game.Current?.ObjectManager?.GetObjectTypeList<CultureObject>();
			if (cultures == null)
				return "unknown";
			var names = cultures
				.Where(c => c?.Name != null && !string.IsNullOrWhiteSpace(c.Name.ToString()) && c.StringId != "neutral_culture")
				.Select(c => "\"" + c.Name.ToString() + "\"")
				.Distinct();
			string result = string.Join(", ", names);
			return string.IsNullOrEmpty(result) ? "unknown" : result;
		}
		catch { return "unknown"; }
	}

	private static string GetAvailableKingdoms()
	{
		try
		{
			if (Kingdom.All == null)
				return "unknown";
			var names = ((IEnumerable<Kingdom>)Kingdom.All)
				.Where(k => k != null && !k.IsEliminated && k.Name != null)
				.Select(k => "\"" + k.Name.ToString() + "\"")
				.Distinct();
			string result = string.Join(", ", names);
			return string.IsNullOrEmpty(result) ? "unknown" : result;
		}
		catch { return "unknown"; }
	}
}
