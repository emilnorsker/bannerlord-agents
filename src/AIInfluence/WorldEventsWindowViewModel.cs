using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AIInfluence.Diplomacy;
using AIInfluence.DynamicEvents;
using Bannerlord.UIExtenderEx.Attributes;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using TaleWorlds.ScreenSystem;

namespace AIInfluence;

public class WorldEventsWindowViewModel : ViewModel
{
	private WorldEventsWindowLayer _parentLayer;

	private HashSet<string> _statementKeys = new HashSet<string>();

	private long _entrySequence;

	[DataSourceProperty]
	public string TitleText { get; set; }

	[DataSourceProperty]
	public string SubtitleText { get; set; }

	[DataSourceProperty]
	public string LastUpdatedText { get; set; }

	[DataSourceProperty]
	public bool ShowSubtitle => !string.IsNullOrEmpty(SubtitleText);

	[DataSourceProperty]
	public bool ShowLastUpdated => !string.IsNullOrEmpty(LastUpdatedText);

	[DataSourceProperty]
	public string SummaryDescription { get; set; }

	[DataSourceProperty]
	public string FilterHint { get; set; }

	[DataSourceProperty]
	public MBBindingList<WorldEventEntry> DeclarationList { get; set; }

	public WorldEventsWindowViewModel(WorldEventsWindowLayer parentLayer)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		_parentLayer = parentLayer;
		LoadRealData();
		TitleText = ((object)new TextObject("{=AIInfluence_WorldEventsTitle}World Events", (Dictionary<string, object>)null)).ToString();
		SubtitleText = "";
		LastUpdatedText = "";
	}

	private void LoadRealData()
	{
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected O, but got Unknown
		DeclarationList = new MBBindingList<WorldEventEntry>();
		_entrySequence = 0L;
		try
		{
			List<DynamicEvent> list = DynamicEventsManager.Instance?.GetActiveEvents() ?? new List<DynamicEvent>();
			List<DynamicEvent> list2 = new List<DynamicEvent>();
			try
			{
				DiplomacyStorage diplomacyStorage = new DiplomacyStorage();
				list2 = diplomacyStorage.LoadDiplomaticEvents() ?? new List<DynamicEvent>();
			}
			catch (Exception)
			{
			}
			List<DynamicEvent> list3 = new List<DynamicEvent>();
			Dictionary<string, DynamicEvent> dictionary = list2.Where((DynamicEvent e) => e != null && !string.IsNullOrEmpty(e.Id)).ToDictionary((DynamicEvent e) => e.Id, (DynamicEvent e) => e);
			foreach (DynamicEvent item in list)
			{
				if (dictionary.TryGetValue(item.Id, out var value))
				{
					MergeDiplomaticEventData(item, value);
				}
				list3.Add(item);
			}
			HashSet<string> hashSet = new HashSet<string>(from e in list
				select e.Id into id
				where !string.IsNullOrEmpty(id)
				select id);
			foreach (DynamicEvent item2 in list2)
			{
				if (item2 != null && !string.IsNullOrEmpty(item2.Id) && !hashSet.Contains(item2.Id))
				{
					list3.Add(item2);
				}
			}
			if (list3.Any())
			{
				List<DynamicEvent> list4 = list3.OrderByDescending((DynamicEvent e) => e.CreationCampaignDays).ToList();
				Dictionary<string, DynamicEvent> dictionary2 = list4.ToDictionary((DynamicEvent e) => e.Id, (DynamicEvent e) => e);
				List<(WorldEventEntry, float, long)> list5 = new List<(WorldEventEntry, float, long)>();
				foreach (DynamicEvent item3 in list4)
				{
					List<(WorldEventEntry, float, long)> collection = CollectEventEntries(item3);
					list5.AddRange(collection);
				}
				List<KingdomStatement> list6 = DiplomaticStatementsStorage.Instance?.GetRecentStatements() ?? new List<KingdomStatement>();
				foreach (KingdomStatement item4 in list6)
				{
					if (!string.IsNullOrEmpty(item4.EventId) && dictionary2.TryGetValue(item4.EventId, out var value2))
					{
						WorldEventEntry worldEventEntry = CreateStatementEntry(item4, value2);
						if (worldEventEntry != null)
						{
							list5.Add((worldEventEntry, item4.CampaignDays, ++_entrySequence));
						}
					}
				}
				List<WorldEventEntry> list7 = (from e in list5
					orderby e.Item3 descending, e.Item2 descending
					select e.Item1).ToList();
				foreach (WorldEventEntry item5 in list7)
				{
					((Collection<WorldEventEntry>)(object)DeclarationList).Add(item5);
				}
			}
			SummaryDescription = "";
			FilterHint = "";
		}
		catch (Exception)
		{
			SummaryDescription = ((object)new TextObject("{=AIInfluence_ErrorLoadingEvents}Error loading events", (Dictionary<string, object>)null)).ToString();
			FilterHint = "";
		}
	}

	private List<(WorldEventEntry entry, float sortTime, long sequenceOrder)> CollectEventEntries(DynamicEvent dynamicEvent)
	{
		List<(WorldEventEntry, float, long)> list = new List<(WorldEventEntry, float, long)>();
		try
		{
			List<EventUpdate> eventHistory = dynamicEvent.EventHistory;
			if (eventHistory == null || !eventHistory.Any())
			{
				WorldEventEntry worldEventEntry = CreateMainEventCard(dynamicEvent);
				if (worldEventEntry != null)
				{
					list.Add((worldEventEntry, dynamicEvent.CreationCampaignDays, ++_entrySequence));
				}
			}
			else
			{
				List<EventUpdate> list2 = eventHistory.OrderByDescending((EventUpdate h) => h.CampaignDays).ToList();
				foreach (EventUpdate item2 in list2)
				{
					WorldEventEntry worldEventEntry2 = CreateEventUpdateCard(dynamicEvent, item2);
					if (worldEventEntry2 != null)
					{
						list.Add((worldEventEntry2, item2.CampaignDays, ++_entrySequence));
					}
				}
			}
			if (dynamicEvent.KingdomStatements != null && dynamicEvent.KingdomStatements.Any())
			{
				List<KingdomStatement> list3 = dynamicEvent.KingdomStatements.OrderByDescending((KingdomStatement s) => s.CampaignDays).ToList();
				foreach (KingdomStatement item3 in list3)
				{
					if (RegisterStatement(item3))
					{
						WorldEventEntry worldEventEntry3 = CreateStatementCard(item3, dynamicEvent);
						if (worldEventEntry3 != null)
						{
							float item = ((item3.CampaignDays > 0f) ? item3.CampaignDays : dynamicEvent.CreationCampaignDays);
							list.Add((worldEventEntry3, item, ++_entrySequence));
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	private WorldEventEntry CreateMainEventCard(DynamicEvent dynamicEvent)
	{
		string category = LocalizeCategory(dynamicEvent.Type);
		string title = GenerateEventTitle(dynamicEvent);
		string text = dynamicEvent.Description;
		if (dynamicEvent.EconomicEffects != null && dynamicEvent.EconomicEffects.Any())
		{
			string text2 = BuildEconomicEffectsText(dynamicEvent.EconomicEffects);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = (string.IsNullOrWhiteSpace(text) ? text2 : (text + "\n\n" + text2));
			}
		}
		string issuedTime = FormatEventTime(dynamicEvent);
		string involvedFactionsText = GetInvolvedFactionsText(dynamicEvent);
		string locationHint = GetLocationHint(dynamicEvent);
		return new WorldEventEntry
		{
			Title = title,
			Category = category,
			DeclarationContent = text,
			IssuedTime = issuedTime,
			InvolvedFactions = involvedFactionsText,
			LocationHint = locationHint,
			SortOrder = dynamicEvent.CreationCampaignDays,
			EntryOrder = ++_entrySequence,
			CategoryColor = GetCategoryColor(dynamicEvent.Type)
		};
	}

	private WorldEventEntry CreateEventUpdateCard(DynamicEvent dynamicEvent, EventUpdate update)
	{
		string category = LocalizeCategory(dynamicEvent.Type);
		string title = ((!string.IsNullOrWhiteSpace(dynamicEvent.Title)) ? dynamicEvent.Title : GenerateEventTitle(dynamicEvent));
		string text = update.Description;
		if (update.EconomicEffects != null && update.EconomicEffects.Any())
		{
			string text2 = BuildEconomicEffectsText(update.EconomicEffects);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = (string.IsNullOrWhiteSpace(text) ? text2 : (text + "\n\n" + text2));
			}
		}
		string issuedTime = FormatIssuedTimeFromCampaignDays(update.CampaignDays);
		string involvedFactionsText = GetInvolvedFactionsText(dynamicEvent);
		string locationHint = GetLocationHint(dynamicEvent);
		return new WorldEventEntry
		{
			Title = title,
			Category = category,
			DeclarationContent = text,
			IssuedTime = issuedTime,
			InvolvedFactions = involvedFactionsText,
			LocationHint = locationHint,
			SortOrder = update.CampaignDays,
			EntryOrder = ++_entrySequence,
			CategoryColor = GetCategoryColor(dynamicEvent.Type)
		};
	}

	private WorldEventEntry CreateStatementCard(KingdomStatement statement, DynamicEvent dynamicEvent)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == statement.KingdomId));
		object obj;
		if (val == null)
		{
			obj = null;
		}
		else
		{
			Hero leader = val.Leader;
			obj = ((leader == null) ? null : ((object)leader.Name)?.ToString());
		}
		if (obj == null)
		{
			obj = ((object)new TextObject("{=AIInfluence_UnknownRuler}Unknown ruler", (Dictionary<string, object>)null)).ToString();
		}
		string text = (string)obj;
		string involvedFactions = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? statement.KingdomId;
		string text2 = ((object)new TextObject("{=AIInfluence_RulerStatement}Ruler's statement", (Dictionary<string, object>)null)).ToString();
		string title = text2 + " " + text;
		string statementText = statement.StatementText;
		int num = 0;
		if (statement.CampaignDays > 0f)
		{
			_ = CampaignTime.Now;
			if (true)
			{
				CampaignTime now = CampaignTime.Now;
				float num2 = (float)(now).ToDays;
				num = Math.Max(0, (int)(num2 - statement.CampaignDays));
			}
		}
		string issuedTime = num switch
		{
			0 => ((object)new TextObject("{=AIInfluence_Today}Today", (Dictionary<string, object>)null)).ToString(), 
			1 => ((object)new TextObject("{=AIInfluence_1DayAgo}1 day ago", (Dictionary<string, object>)null)).ToString(), 
			_ => ((object)new TextObject("{=AIInfluence_DaysAgo}{DAYS} days ago", (Dictionary<string, object>)null).SetTextVariable("DAYS", num)).ToString(), 
		};
		string category = LocalizeCategory("political");
		string text3 = BuildActionsText(statement);
		string declarationContent = statementText;
		if (!string.IsNullOrWhiteSpace(text3))
		{
			declarationContent = (string.IsNullOrWhiteSpace(statementText) ? text3 : (statementText + "\n\n" + text3));
		}
		return new WorldEventEntry
		{
			Title = title,
			Category = category,
			DeclarationContent = declarationContent,
			IssuedTime = issuedTime,
			InvolvedFactions = involvedFactions,
			LocationHint = "",
			SortOrder = ((statement.CampaignDays > 0f) ? statement.CampaignDays : dynamicEvent.CreationCampaignDays),
			EntryOrder = ++_entrySequence,
			CategoryColor = GetCategoryColor("political")
		};
	}

	private WorldEventEntry CreateStatementEntry(KingdomStatement statement, DynamicEvent relatedEvent)
	{
		if (statement == null || relatedEvent == null)
		{
			return null;
		}
		if (!RegisterStatement(statement))
		{
			return null;
		}
		return CreateStatementCard(statement, relatedEvent);
	}

	private string GenerateEventTitle(DynamicEvent dynamicEvent)
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		if (!string.IsNullOrWhiteSpace(dynamicEvent?.Title))
		{
			return dynamicEvent.Title;
		}
		string text = LocalizeCategory(dynamicEvent.Type);
		if (dynamicEvent.ParticipatingKingdoms != null && dynamicEvent.ParticipatingKingdoms.Any())
		{
			if (dynamicEvent.ParticipatingKingdoms.Count == 1)
			{
				string kingdomName = GetKingdomName(dynamicEvent.ParticipatingKingdoms[0]);
				return text + ": " + kingdomName;
			}
			if (dynamicEvent.ParticipatingKingdoms.Count == 2)
			{
				string kingdomName2 = GetKingdomName(dynamicEvent.ParticipatingKingdoms[0]);
				string kingdomName3 = GetKingdomName(dynamicEvent.ParticipatingKingdoms[1]);
				return text + ": " + kingdomName2 + " — " + kingdomName3;
			}
			string text2 = ((object)new TextObject("{=AIInfluence_MultipleFactions}Multiple factions", (Dictionary<string, object>)null)).ToString();
			return text + ": " + text2;
		}
		if (dynamicEvent.KingdomStatements != null && dynamicEvent.KingdomStatements.Any())
		{
			KingdomStatement firstStatement = dynamicEvent.KingdomStatements.First();
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == firstStatement.KingdomId));
			string text3 = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? firstStatement.KingdomId;
			return text + ": " + text3;
		}
		if (dynamicEvent.KingdomsInvolved != null && dynamicEvent.KingdomsInvolved is List<string> list && list.Any())
		{
			if (list.Count == 1)
			{
				string kingdomName4 = GetKingdomName(list[0]);
				return text + ": " + kingdomName4;
			}
			if (list.Count == 2)
			{
				string kingdomName5 = GetKingdomName(list[0]);
				string kingdomName6 = GetKingdomName(list[1]);
				return text + ": " + kingdomName5 + " — " + kingdomName6;
			}
			string text4 = ((object)new TextObject("{=AIInfluence_MultipleFactions}Multiple factions", (Dictionary<string, object>)null)).ToString();
			return text + ": " + text4;
		}
		if (!string.IsNullOrEmpty(dynamicEvent.Description))
		{
			string text5 = ((dynamicEvent.Description.Length > 50) ? (dynamicEvent.Description.Substring(0, 50) + "...") : dynamicEvent.Description);
			return text + ": " + text5;
		}
		return text;
	}

	private string FormatEventTime(DynamicEvent dynamicEvent)
	{
		int daysSinceCreation = dynamicEvent.DaysSinceCreation;
		return FormatDaysAgo(daysSinceCreation);
	}

	private string FormatIssuedTimeFromCampaignDays(float campaignDays)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		_ = CampaignTime.Now;
		CampaignTime now = CampaignTime.Now;
		float num = (float)(now).ToDays;
		int daysAgo = Math.Max(0, (int)(num - campaignDays));
		return FormatDaysAgo(daysAgo);
	}

	private string FormatDaysAgo(int daysAgo)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		if (daysAgo <= 0)
		{
			return ((object)new TextObject("{=AIInfluence_Today}Today", (Dictionary<string, object>)null)).ToString();
		}
		int num = daysAgo % 100;
		int num2 = daysAgo % 10;
		string text = ((num >= 11 && num <= 14) ? "AIInfluence_DaysAgoMany" : ((num2 == 1) ? "AIInfluence_1DayAgo" : ((num2 < 2 || num2 > 4) ? "AIInfluence_DaysAgoMany" : "AIInfluence_DaysAgoFew")));
		if (text == "AIInfluence_1DayAgo")
		{
			return ((object)new TextObject("{=AIInfluence_1DayAgo}1 day ago", (Dictionary<string, object>)null)).ToString();
		}
		return ((object)new TextObject("{=" + text + "}{DAYS} days ago", (Dictionary<string, object>)null).SetTextVariable("DAYS", daysAgo)).ToString();
	}

	private string BuildActionsText(KingdomStatement statement)
	{
		if (statement == null)
		{
			return "";
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<DiplomaticAction> list3 = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
		List<string> targetKingdomIds = ((statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any()) ? statement.TargetKingdomIds : ((!string.IsNullOrEmpty(statement.TargetKingdomId)) ? new List<string> { statement.TargetKingdomId } : new List<string>()));
		for (int i = 0; i < list3.Count; i++)
		{
			DiplomaticAction action = list3[i];
			string text = FormatAction(statement, action, i, targetKingdomIds);
			if (!string.IsNullOrWhiteSpace(text))
			{
				list2.Add(text);
			}
		}
		if (list2.Any())
		{
			list.AddRange(list2);
		}
		if (!string.IsNullOrWhiteSpace(statement.Reason))
		{
		}
		return list.Any() ? string.Join("\n", list) : "";
	}

	private string BuildEconomicEffectsText(List<EconomicEffect> effects)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		if (effects == null || !effects.Any())
		{
			return "";
		}
		List<string> list = new List<string>();
		foreach (EconomicEffect effect in effects)
		{
			if (effect == null)
			{
				continue;
			}
			List<string> list2 = new List<string>();
			string localizedEffectTargetName = GetLocalizedEffectTargetName(effect);
			if (!string.IsNullOrWhiteSpace(localizedEffectTargetName))
			{
				list2.Add(localizedEffectTargetName);
			}
			List<string> list3 = new List<string>();
			if (Math.Abs(effect.ProsperityDelta) > 0.01f)
			{
				string text = ((effect.ProsperityDelta > 0f) ? $"+{effect.ProsperityDelta:F0}" : effect.ProsperityDelta.ToString("F0"));
				list3.Add(((object)new TextObject("{=AIInfluence_EconomicEffect_ProsperityDelta}Prosperity: {VALUE}", (Dictionary<string, object>)null).SetTextVariable("VALUE", text)).ToString());
			}
			if (Math.Abs(effect.ProsperityDeltaPerDay) > 0.01f && effect.DurationDays > 0)
			{
				string text2 = ((effect.ProsperityDeltaPerDay > 0f) ? $"+{effect.ProsperityDeltaPerDay:F1}" : effect.ProsperityDeltaPerDay.ToString("F1"));
				list3.Add(((object)new TextObject("{=AIInfluence_EconomicEffect_ProsperityDeltaPerDay}Prosperity: {VALUE} per day ({DAYS} days)", (Dictionary<string, object>)null).SetTextVariable("VALUE", text2).SetTextVariable("DAYS", effect.DurationDays)).ToString());
			}
			if (Math.Abs(effect.FoodDelta) > 0.01f)
			{
				string text3 = ((effect.FoodDelta > 0f) ? $"+{effect.FoodDelta:F0}" : effect.FoodDelta.ToString("F0"));
				list3.Add(((object)new TextObject("{=AIInfluence_EconomicEffect_FoodDelta}Food: {VALUE}", (Dictionary<string, object>)null).SetTextVariable("VALUE", text3)).ToString());
			}
			if (Math.Abs(effect.FoodDeltaPerDay) > 0.01f && effect.DurationDays > 0)
			{
				string text4 = ((effect.FoodDeltaPerDay > 0f) ? $"+{effect.FoodDeltaPerDay:F1}" : effect.FoodDeltaPerDay.ToString("F1"));
				list3.Add(((object)new TextObject("{=AIInfluence_EconomicEffect_FoodDeltaPerDay}Food: {VALUE} per day ({DAYS} days)", (Dictionary<string, object>)null).SetTextVariable("VALUE", text4).SetTextVariable("DAYS", effect.DurationDays)).ToString());
			}
			if (Math.Abs(effect.SecurityDelta) > 0.01f)
			{
				string text5 = ((effect.SecurityDelta > 0f) ? $"+{effect.SecurityDelta:F0}" : effect.SecurityDelta.ToString("F0"));
				list3.Add(((object)new TextObject("{=AIInfluence_EconomicEffect_SecurityDelta}Security: {VALUE}", (Dictionary<string, object>)null).SetTextVariable("VALUE", text5)).ToString());
			}
			if (Math.Abs(effect.SecurityDeltaPerDay) > 0.01f && effect.DurationDays > 0)
			{
				string text6 = ((effect.SecurityDeltaPerDay > 0f) ? $"+{effect.SecurityDeltaPerDay:F2}" : effect.SecurityDeltaPerDay.ToString("F2"));
				list3.Add(((object)new TextObject("{=AIInfluence_EconomicEffect_SecurityDeltaPerDay}Security: {VALUE} per day ({DAYS} days)", (Dictionary<string, object>)null).SetTextVariable("VALUE", text6).SetTextVariable("DAYS", effect.DurationDays)).ToString());
			}
			if (Math.Abs(effect.LoyaltyDelta) > 0.01f)
			{
				string text7 = ((effect.LoyaltyDelta > 0f) ? $"+{effect.LoyaltyDelta:F0}" : effect.LoyaltyDelta.ToString("F0"));
				list3.Add(((object)new TextObject("{=AIInfluence_EconomicEffect_LoyaltyDelta}Loyalty: {VALUE}", (Dictionary<string, object>)null).SetTextVariable("VALUE", text7)).ToString());
			}
			if (Math.Abs(effect.LoyaltyDeltaPerDay) > 0.01f && effect.DurationDays > 0)
			{
				string text8 = ((effect.LoyaltyDeltaPerDay > 0f) ? $"+{effect.LoyaltyDeltaPerDay:F2}" : effect.LoyaltyDeltaPerDay.ToString("F2"));
				list3.Add(((object)new TextObject("{=AIInfluence_EconomicEffect_LoyaltyDeltaPerDay}Loyalty: {VALUE} per day ({DAYS} days)", (Dictionary<string, object>)null).SetTextVariable("VALUE", text8).SetTextVariable("DAYS", effect.DurationDays)).ToString());
			}
			if (Math.Abs(effect.IncomeMultiplier - 1f) > 0.001f)
			{
				float num = (effect.IncomeMultiplier - 1f) * 100f;
				string text9 = ((num > 0f) ? $"+{num:F0}" : num.ToString("F0"));
				list3.Add(((object)new TextObject("{=AIInfluence_EconomicEffect_IncomeMultiplier}Income: {VALUE}%", (Dictionary<string, object>)null).SetTextVariable("VALUE", text9)).ToString());
			}
			if (list3.Any())
			{
				string text10 = string.Join(", ", list3);
				List<string> list4 = new List<string>();
				if (!string.IsNullOrWhiteSpace(localizedEffectTargetName))
				{
					list4.Add(localizedEffectTargetName + ": " + text10);
				}
				else
				{
					list4.Add(text10);
				}
				if (!string.IsNullOrWhiteSpace(effect.Reason))
				{
					list4.Add(effect.Reason);
				}
				list.Add(string.Join(". ", list4));
				continue;
			}
			List<string> list5 = new List<string>();
			if (!string.IsNullOrWhiteSpace(localizedEffectTargetName))
			{
				list5.Add(localizedEffectTargetName);
			}
			if (!string.IsNullOrWhiteSpace(effect.Reason))
			{
				list5.Add(effect.Reason);
			}
			if (list5.Any())
			{
				list.Add(string.Join(": ", list5));
			}
		}
		return list.Any() ? string.Join("\n", list) : "";
	}

	private string GetLocalizedEffectTargetName(EconomicEffect effect)
	{
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Expected O, but got Unknown
		//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Expected O, but got Unknown
		if (effect == null)
		{
			return "";
		}
		switch (effect.TargetType?.ToLowerInvariant())
		{
		case "settlement":
		{
			if (!string.IsNullOrEmpty(effect.TargetId))
			{
				Settlement val3 = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == effect.TargetId));
				if (val3 != null)
				{
					if (effect.TargetIds != null && effect.TargetIds.Count > 1)
					{
						int num = effect.TargetIds.Count - 1;
						return ((object)new TextObject("{=AIInfluence_EconomicEffect_AndMore}{SETTLEMENT} and {COUNT} more", (Dictionary<string, object>)null).SetTextVariable("SETTLEMENT", ((object)val3.Name)?.ToString() ?? effect.TargetId).SetTextVariable("COUNT", num)).ToString();
					}
					return ((object)val3.Name)?.ToString() ?? effect.TargetId;
				}
				return effect.TargetId;
			}
			if (effect.TargetIds == null || !effect.TargetIds.Any())
			{
				break;
			}
			List<string> list = (from id in effect.TargetIds
				select ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == id)) into s
				where s != null
				select ((object)s.Name)?.ToString() into n
				where !string.IsNullOrEmpty(n)
				select n).Take(3).ToList();
			if (list.Any())
			{
				string text5 = string.Join(", ", list);
				if (effect.TargetIds.Count > list.Count)
				{
					int num2 = effect.TargetIds.Count - list.Count;
					text5 = ((object)new TextObject("{=AIInfluence_EconomicEffect_AndMore}{SETTLEMENTS} and {COUNT} more", (Dictionary<string, object>)null).SetTextVariable("SETTLEMENTS", text5).SetTextVariable("COUNT", num2)).ToString();
				}
				return text5;
			}
			break;
		}
		case "kingdom":
		{
			if (string.IsNullOrEmpty(effect.TargetId))
			{
				break;
			}
			Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == effect.TargetId));
			if (val2 != null)
			{
				string text3 = effect.TargetScope ?? "single";
				if (text3 == "single" || string.IsNullOrEmpty(text3))
				{
					return ((object)val2.Name)?.ToString() ?? effect.TargetId;
				}
				string text4 = text3 switch
				{
					"all_settlements" => ((object)new TextObject("{=AIInfluence_EconomicEffect_Scope_AllSettlements}all settlements", (Dictionary<string, object>)null)).ToString(), 
					"towns" => ((object)new TextObject("{=AIInfluence_EconomicEffect_Scope_Towns}towns", (Dictionary<string, object>)null)).ToString(), 
					"castles" => ((object)new TextObject("{=AIInfluence_EconomicEffect_Scope_Castles}castles", (Dictionary<string, object>)null)).ToString(), 
					"villages" => ((object)new TextObject("{=AIInfluence_EconomicEffect_Scope_Villages}villages", (Dictionary<string, object>)null)).ToString(), 
					_ => "", 
				};
				if (!string.IsNullOrEmpty(text4))
				{
					return ((object)new TextObject("{=AIInfluence_EconomicEffect_In}in {TARGET}", (Dictionary<string, object>)null).SetTextVariable("TARGET", $"{val2.Name} ({text4})")).ToString();
				}
				return ((object)val2.Name)?.ToString() ?? effect.TargetId;
			}
			return effect.TargetId;
		}
		case "clan":
		{
			if (string.IsNullOrEmpty(effect.TargetId))
			{
				break;
			}
			Clan val = ((IEnumerable<Clan>)Clan.All).FirstOrDefault((Func<Clan, bool>)((Clan c) => ((MBObjectBase)c).StringId == effect.TargetId));
			if (val != null)
			{
				string text = effect.TargetScope ?? "single";
				if (text == "single" || string.IsNullOrEmpty(text))
				{
					return ((object)val.Name)?.ToString() ?? effect.TargetId;
				}
				string text2 = text switch
				{
					"all_settlements" => ((object)new TextObject("{=AIInfluence_EconomicEffect_Scope_AllSettlements}all settlements", (Dictionary<string, object>)null)).ToString(), 
					"towns" => ((object)new TextObject("{=AIInfluence_EconomicEffect_Scope_Towns}towns", (Dictionary<string, object>)null)).ToString(), 
					"castles" => ((object)new TextObject("{=AIInfluence_EconomicEffect_Scope_Castles}castles", (Dictionary<string, object>)null)).ToString(), 
					"villages" => ((object)new TextObject("{=AIInfluence_EconomicEffect_Scope_Villages}villages", (Dictionary<string, object>)null)).ToString(), 
					_ => "", 
				};
				if (!string.IsNullOrEmpty(text2))
				{
					return ((object)new TextObject("{=AIInfluence_EconomicEffect_In}in {TARGET}", (Dictionary<string, object>)null).SetTextVariable("TARGET", $"{val.Name} ({text2})")).ToString();
				}
				return ((object)val.Name)?.ToString() ?? effect.TargetId;
			}
			return effect.TargetId;
		}
		}
		return "";
	}

	private bool RegisterStatement(KingdomStatement statement)
	{
		if (statement == null)
		{
			return false;
		}
		string item = BuildStatementKey(statement);
		if (_statementKeys.Contains(item))
		{
			return false;
		}
		_statementKeys.Add(item);
		return true;
	}

	private string BuildStatementKey(KingdomStatement statement)
	{
		string text = statement.EventId ?? "";
		string text2 = statement.KingdomId ?? "";
		int num = (int)statement.CampaignDays;
		string text3 = statement.StatementText ?? "";
		return $"{text}|{text2}|{num}|{text3}".GetHashCode().ToString();
	}

	private void MergeDiplomaticEventData(DynamicEvent target, DynamicEvent source)
	{
		if (target == null || source == null)
		{
			return;
		}
		if (!string.IsNullOrWhiteSpace(source.Description))
		{
			target.Description = source.Description;
		}
		if (source.ParticipatingKingdoms != null && source.ParticipatingKingdoms.Any())
		{
			target.ParticipatingKingdoms = new List<string>(source.ParticipatingKingdoms);
		}
		if (source.EventHistory == null || !source.EventHistory.Any())
		{
			return;
		}
		if (target.EventHistory == null)
		{
			target.EventHistory = new List<EventUpdate>();
		}
		foreach (EventUpdate update in source.EventHistory)
		{
			if (!target.EventHistory.Any((EventUpdate u) => u.Description == update.Description && Math.Abs(u.CampaignDays - update.CampaignDays) < 0.01f))
			{
				target.EventHistory.Add(update);
			}
		}
		target.EventHistory = target.EventHistory.OrderByDescending((EventUpdate u) => u.CampaignDays).ToList();
	}

	private string ResolveSettlementIdForAction(KingdomStatement statement, int actionIndex)
	{
		if (string.IsNullOrWhiteSpace(statement.SettlementId))
		{
			return null;
		}
		string[] array = statement.SettlementId.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length <= 1)
		{
			return statement.SettlementId?.Trim();
		}
		List<DiplomaticAction> list = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
		int num = 0;
		for (int i = 0; i < list.Count && i <= actionIndex; i++)
		{
			DiplomaticAction diplomaticAction = list[i];
			bool flag = diplomaticAction == DiplomaticAction.TransferTerritory || diplomaticAction == DiplomaticAction.RejectTerritory || diplomaticAction == DiplomaticAction.DemandTerritory || diplomaticAction == DiplomaticAction.QuarantineSettlement;
			if (flag && i == actionIndex)
			{
				return (num < array.Length) ? array[num].Trim() : array[0].Trim();
			}
			if (flag)
			{
				num++;
			}
		}
		return array[0].Trim();
	}

	private string FormatAction(KingdomStatement statement, DiplomaticAction action, int actionIndex, List<string> targetKingdomIds)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0749: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d9: Unknown result type (might be due to invalid IL or missing references)
		string sourceName = GetKingdomName(statement.KingdomId);
		if (action == DiplomaticAction.QuarantineSettlement)
		{
			string text = ResolveSettlementIdForAction(statement, actionIndex);
			string text2 = GetSettlementName(text);
			if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text))
			{
				text2 = text;
			}
			int num = ((statement.QuarantineDurationDays > 0) ? statement.QuarantineDurationDays : 14);
			return ((object)new TextObject("{=AIInfluence_Action_QuarantineSettlement}{SOURCE} closed {SETTLEMENT} for quarantine for {DAYS} days", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("SETTLEMENT", text2 ?? "").SetTextVariable("DAYS", num)).ToString();
		}
		List<string> list = new List<string>();
		List<DiplomaticAction> list2 = ((statement.Actions != null && statement.Actions.Any()) ? statement.Actions : new List<DiplomaticAction> { statement.Action });
		if (list2.Count == targetKingdomIds.Count && actionIndex < targetKingdomIds.Count)
		{
			string id = targetKingdomIds[actionIndex];
			string kingdomName = GetKingdomName(id);
			if (!string.IsNullOrWhiteSpace(kingdomName))
			{
				list.Add(kingdomName);
			}
		}
		else if (targetKingdomIds.Any())
		{
			foreach (string targetKingdomId in targetKingdomIds)
			{
				string kingdomName2 = GetKingdomName(targetKingdomId);
				if (!string.IsNullOrWhiteSpace(kingdomName2))
				{
					list.Add(kingdomName2);
				}
			}
		}
		if (!list.Any() && !string.IsNullOrWhiteSpace(statement.TargetKingdomId))
		{
			string kingdomName3 = GetKingdomName(statement.TargetKingdomId);
			if (!string.IsNullOrWhiteSpace(kingdomName3))
			{
				list.Add(kingdomName3);
			}
		}
		if (action == DiplomaticAction.ExpelClan && !string.IsNullOrWhiteSpace(statement.TargetClanId))
		{
			string clanName = GetClanName(statement.TargetClanId);
			if (!string.IsNullOrWhiteSpace(clanName))
			{
				list.Add(clanName);
			}
		}
		if (action == DiplomaticAction.ExpelClan)
		{
			list = list.Where((string t) => string.Equals(t, GetClanName(statement.TargetClanId), StringComparison.OrdinalIgnoreCase)).ToList();
		}
		list = list.Where((string t) => !string.IsNullOrWhiteSpace(t)).Distinct<string>(StringComparer.OrdinalIgnoreCase).ToList();
		list.RemoveAll((string t) => string.Equals(t, sourceName, StringComparison.OrdinalIgnoreCase));
		if (!list.Any())
		{
			return string.Empty;
		}
		string text3 = string.Join(", ", list);
		return action switch
		{
			DiplomaticAction.DeclareWar => ((object)new TextObject("{=AIInfluence_Action_DeclareWar}{SOURCE} declares war on {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.ProposePeace => ((object)new TextObject("{=AIInfluence_Action_ProposePeace}{SOURCE} proposes peace to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.AcceptPeace => ((object)new TextObject("{=AIInfluence_Action_AcceptPeace}{SOURCE} accepts peace with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.RejectPeace => ((object)new TextObject("{=AIInfluence_Action_RejectPeace}{SOURCE} rejects peace with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.ProposeAlliance => ((object)new TextObject("{=AIInfluence_Action_ProposeAlliance}{SOURCE} proposes alliance to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.AcceptAlliance => ((object)new TextObject("{=AIInfluence_Action_AcceptAlliance}{SOURCE} accepts alliance with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.RejectAlliance => ((object)new TextObject("{=AIInfluence_Action_RejectAlliance}{SOURCE} rejects alliance with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.BreakAlliance => ((object)new TextObject("{=AIInfluence_Action_BreakAlliance}{SOURCE} breaks alliance with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.ProposeTradeAgreement => ((object)new TextObject("{=AIInfluence_Action_ProposeTrade}{SOURCE} proposes trade agreement to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.AcceptTradeAgreement => ((object)new TextObject("{=AIInfluence_Action_AcceptTrade}{SOURCE} accepts trade agreement with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.RejectTradeAgreement => ((object)new TextObject("{=AIInfluence_Action_RejectTrade}{SOURCE} rejects trade agreement with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.EndTradeAgreement => ((object)new TextObject("{=AIInfluence_Action_EndTrade}{SOURCE} ends trade agreement with {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.DemandTribute => ((object)new TextObject("{=AIInfluence_Action_DemandTribute}{SOURCE} demands tribute from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.AcceptTribute => ((object)new TextObject("{=AIInfluence_Action_AcceptTribute}{SOURCE} accepts tribute from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.RejectTribute => ((object)new TextObject("{=AIInfluence_Action_RejectTribute}{SOURCE} refuses tribute to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.EndTribute => ((object)new TextObject("{=AIInfluence_Action_EndTribute}{SOURCE} ends tribute to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.DemandReparations => ((object)new TextObject("{=AIInfluence_Action_DemandReparations}{SOURCE} demands reparations from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.AcceptReparations => ((object)new TextObject("{=AIInfluence_Action_AcceptReparations}{SOURCE} accepts reparations from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.RejectReparations => ((object)new TextObject("{=AIInfluence_Action_RejectReparations}{SOURCE} rejects reparations from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.TransferTerritory => ((object)new TextObject("{=AIInfluence_Action_TransferTerritory}{SOURCE} transfers territory to {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.DemandTerritory => ((object)new TextObject("{=AIInfluence_Action_DemandTerritory}{SOURCE} demands territory from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.RejectTerritory => ((object)new TextObject("{=AIInfluence_Action_RejectTerritory}{SOURCE} rejects territory demand from {TARGETS}", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.ExpelClan => ((object)new TextObject("{=AIInfluence_Action_ExpelClan}{SOURCE} expels clan {TARGETS} from the kingdom", (Dictionary<string, object>)null).SetTextVariable("SOURCE", sourceName).SetTextVariable("TARGETS", text3)).ToString(), 
			DiplomaticAction.QuarantineSettlement => "", 
			_ => "", 
		};
	}

	private string GetSettlementName(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			return "";
		}
		Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => string.Equals(((MBObjectBase)s).StringId, id.Trim(), StringComparison.OrdinalIgnoreCase)));
		return ((val == null) ? null : ((object)val.Name)?.ToString()) ?? "";
	}

	private string GetInvolvedFactionsText(DynamicEvent dynamicEvent)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		if (dynamicEvent.KingdomsInvolved == null)
		{
			return "";
		}
		if (dynamicEvent.KingdomsInvolved is string text && text == "all")
		{
			return ((object)new TextObject("{=AIInfluence_AllKingdoms}All kingdoms", (Dictionary<string, object>)null)).ToString();
		}
		object kingdomsInvolved = dynamicEvent.KingdomsInvolved;
		List<string> kingdomsList = kingdomsInvolved as List<string>;
		if (kingdomsList != null)
		{
			if (!kingdomsList.Any())
			{
				return "";
			}
			if (dynamicEvent.ParticipatingKingdoms != null && dynamicEvent.ParticipatingKingdoms.Any())
			{
				List<string> source = (from id in GetOrderedParticipatingKingdoms(dynamicEvent)
					where kingdomsList.Contains(id)
					select id).ToList();
				if (source.Any())
				{
					List<string> list = (from id in source
						select GetKingdomName(id) into name
						where !string.IsNullOrWhiteSpace(name)
						select name).ToList();
					if (list.Any())
					{
						return string.Join(", ", list);
					}
				}
			}
			List<string> list2 = (from id in kingdomsList
				select GetKingdomName(id) into name
				where !string.IsNullOrWhiteSpace(name)
				select name).ToList();
			if (!list2.Any())
			{
				return "";
			}
			return string.Join(", ", list2);
		}
		return "";
	}

	private string GetLocationHint(DynamicEvent dynamicEvent)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		if (dynamicEvent.ParticipatingKingdoms != null && dynamicEvent.ParticipatingKingdoms.Any())
		{
			List<string> orderedParticipatingKingdoms = GetOrderedParticipatingKingdoms(dynamicEvent);
			List<string> list = (from id in orderedParticipatingKingdoms
				select GetKingdomName(id) into name
				where !string.IsNullOrWhiteSpace(name)
				select name).ToList();
			if (list.Any())
			{
				string text = ((object)new TextObject("{=AIInfluence_Participants}Participants", (Dictionary<string, object>)null)).ToString();
				return text + ": " + string.Join(", ", list);
			}
		}
		return "";
	}

	private List<string> GetOrderedParticipatingKingdoms(DynamicEvent dynamicEvent)
	{
		if (dynamicEvent == null || string.IsNullOrEmpty(dynamicEvent.Id))
		{
			return dynamicEvent?.ParticipatingKingdoms?.ToList() ?? new List<string>();
		}
		try
		{
			DiplomacyManager instance = DiplomacyManager.Instance;
			if (instance != null)
			{
				List<string> orderedParticipatingKingdoms = instance.GetOrderedParticipatingKingdoms(dynamicEvent.Id);
				if (orderedParticipatingKingdoms != null && orderedParticipatingKingdoms.Any())
				{
					return orderedParticipatingKingdoms;
				}
			}
		}
		catch (Exception)
		{
		}
		return dynamicEvent.ParticipatingKingdoms?.ToList() ?? new List<string>();
	}

	private Kingdom GetKingdomById(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			return null;
		}
		string trimmed = id.Trim();
		MBObjectManager instance = MBObjectManager.Instance;
		Kingdom val = ((instance != null) ? instance.GetObject<Kingdom>(trimmed) : null);
		if (val == null)
		{
			val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => string.Equals(((MBObjectBase)k).StringId, trimmed, StringComparison.OrdinalIgnoreCase)));
		}
		if (val == null)
		{
		}
		return val;
	}

	private string GetKingdomName(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return "";
		}
		Kingdom kingdomById = GetKingdomById(id);
		return ((kingdomById == null) ? null : ((object)kingdomById.Name)?.ToString()) ?? id;
	}

	private Clan GetClanById(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			return null;
		}
		string trimmed = id.Trim();
		MBObjectManager instance = MBObjectManager.Instance;
		Clan val = ((instance != null) ? instance.GetObject<Clan>(trimmed) : null);
		if (val == null)
		{
			val = ((IEnumerable<Clan>)Clan.All).FirstOrDefault((Func<Clan, bool>)((Clan c) => string.Equals(((MBObjectBase)c).StringId, trimmed, StringComparison.OrdinalIgnoreCase)));
		}
		return val;
	}

	private string GetClanName(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			return "";
		}
		Clan clanById = GetClanById(id);
		return ((clanById == null) ? null : ((object)clanById.Name)?.ToString()) ?? id;
	}

	private string LocalizeCategory(string category)
	{
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		var (text, text2) = (string.IsNullOrWhiteSpace(category) ? "" : category.Trim().ToLowerInvariant()) switch
		{
			"military" => ("AIInfluence_Category_Military", "Military"), 
			"political" => ("AIInfluence_Category_Political", "Political"), 
			"economic" => ("AIInfluence_Category_Economic", "Economic"), 
			"social" => ("AIInfluence_Category_Social", "Social"), 
			"mysterious" => ("AIInfluence_Category_Mysterious", "Mysterious"), 
			"news" => ("AIInfluence_Category_News", "News"), 
			"local" => ("AIInfluence_Category_Local", "Local"), 
			"rumor" => ("AIInfluence_Category_Rumor", "Rumor"), 
			"disease_outbreak" => ("AIInfluence_Category_DiseaseOutbreak", "Disease Outbreak"), 
			_ => ("AIInfluence_Category_Other", "Other"), 
		};
		return ((object)new TextObject("{=" + text + "}" + text2, (Dictionary<string, object>)null)).ToString();
	}

	private string GetCategoryColor(string category)
	{
		return (string.IsNullOrWhiteSpace(category) ? "" : category.Trim().ToLowerInvariant()) switch
		{
			"military" => "#556B2F22", 
			"political" => "#4169E122", 
			"economic" => "#32CD3222", 
			"social" => "#20B2AA22", 
			"mysterious" => "#8A2BE222", 
			"news" => "#DC143C22", 
			"local" => "#8B451322", 
			"rumor" => "#70809022", 
			"disease_outbreak" => "#8B000022", 
			_ => "#9DE07722", 
		};
	}

	private void SortDeclarationListByTime()
	{
		List<WorldEventEntry> list = (from e in (IEnumerable<WorldEventEntry>)DeclarationList
			orderby e.SortOrder descending, e.EntryOrder descending
			select e).ToList();
		((Collection<WorldEventEntry>)(object)DeclarationList).Clear();
		foreach (WorldEventEntry item in list)
		{
			((Collection<WorldEventEntry>)(object)DeclarationList).Add(item);
		}
	}

	[DataSourceMethod]
	public void ExecuteCloseWindow()
	{
		ScreenBase topScreen = ScreenManager.TopScreen;
		MapScreen val = (MapScreen)(object)((topScreen is MapScreen) ? topScreen : null);
		if (val != null && ((List<ScreenLayer>)(object)((ScreenBase)val).Layers).Contains((ScreenLayer)(object)_parentLayer))
		{
			((ScreenBase)val).RemoveLayer((ScreenLayer)(object)_parentLayer);
			_parentLayer = null;
		}
	}
}
