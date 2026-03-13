using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.DeathHistory;

public class DeathHistoryBehavior : CampaignBehaviorBase
{
	private AIInfluenceBehavior _aiBehavior;

	public override void RegisterEvents()
	{
		CampaignEvents.HeroKilledEvent.AddNonSerializedListener((object)this, (Action<Hero, Hero, KillCharacterActionDetail, bool>)OnHeroKilled);
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	private void OnHeroKilled(Hero victim, Hero killer, KillCharacterActionDetail detail, bool showNotification)
	{
		if (GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			if (victim == Hero.MainHero)
			{
				ShowDeathHistoryInquiry(victim, isPlayer: true);
			}
			else
			{
				TryOfferDeathHistory(victim);
			}
		}
	}

	private void TryOfferDeathHistory(Hero hero)
	{
		if (_aiBehavior == null)
		{
			_aiBehavior = Campaign.Current.GetCampaignBehavior<AIInfluenceBehavior>();
		}
		if (_aiBehavior != null)
		{
			NPCContext nPCContextByStringId = _aiBehavior.GetNPCContextByStringId(((MBObjectBase)hero).StringId);
			if (nPCContextByStringId != null && nPCContextByStringId.InteractionCount > 50)
			{
				ShowDeathHistoryInquiry(hero, isPlayer: false);
			}
		}
	}

	public void ShowDeathHistoryInquiry(Hero hero, bool isPlayer, Action onComplete = null)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		string text = (isPlayer ? "AIInfluence_DeathHistory_Player_Title" : "AIInfluence_DeathHistory_NPC_Title");
		string text2 = (isPlayer ? "AIInfluence_DeathHistory_Player_Text" : "AIInfluence_DeathHistory_NPC_Text");
		TextObject val = new TextObject("{=" + text + "}" + (isPlayer ? "Your Journey Ends" : "Character Death: {NAME}"), (Dictionary<string, object>)null);
		if (!isPlayer)
		{
			val.SetTextVariable("NAME", hero.Name);
		}
		TextObject val2 = new TextObject("{=" + text2 + "}" + (isPlayer ? "Your life has come to an end..." : "{NAME} has passed away..."), (Dictionary<string, object>)null);
		if (!isPlayer)
		{
			val2.SetTextVariable("NAME", hero.Name);
		}
		string text3 = UnescapeFormatting(((object)val2).ToString());
		InformationManager.ShowInquiry(new InquiryData(((object)val).ToString(), text3, true, true, ((object)new TextObject("{=AIInfluence_DeathHistory_Yes}Yes, generate history", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_DeathHistory_No}No, let them rest", (Dictionary<string, object>)null)).ToString(), (Action)delegate
		{
			GenerateAndShowHistory(hero, isPlayer, onComplete);
		}, (Action)delegate
		{
			onComplete?.Invoke();
		}, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), true, false);
	}

	private async void GenerateAndShowHistory(Hero hero, bool isPlayer, Action onComplete)
	{
		try
		{
			if (_aiBehavior == null)
			{
				_aiBehavior = Campaign.Current.GetCampaignBehavior<AIInfluenceBehavior>();
			}
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_DeathHistory_Generating}Chroniclers are writing the history...", (Dictionary<string, object>)null)).ToString(), Color.FromUint(4293307392u)));
			string prompt = DeathHistoryPromptGenerator.GenerateDeathHistoryPrompt(hero, _aiBehavior);
			AIInfluenceBehavior.Instance?.LogMessage($"[DEATH_HISTORY] Generating obituary for {hero.Name} (isPlayer={isPlayer}). Prompt length: {prompt?.Length ?? 0} chars");
			AIInfluenceBehavior.Instance?.LogMessage("[DEATH_HISTORY] Full prompt:\n" + prompt);
			string aiResponse = await _aiBehavior.SendAIRequest(prompt, "history_gen");
			AIInfluenceBehavior.Instance?.LogMessage($"[DEATH_HISTORY] AI response for {hero.Name}:\n{aiResponse}");
			DeathHistoryLogger.Instance.LogHistoryGeneration(((object)hero.Name).ToString(), isPlayer, prompt, aiResponse);
			if (string.IsNullOrEmpty(aiResponse) || aiResponse.StartsWith("Error:"))
			{
				InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_DeathHistory_Error}Chroniclers could not decipher the records.", (Dictionary<string, object>)null)).ToString(), Colors.Red));
				onComplete?.Invoke();
				return;
			}
			string historyText = ExtractHistoryText(aiResponse);
			if (string.IsNullOrEmpty(historyText) || historyText.Length < 50)
			{
				historyText = RemoveJsonFromText(aiResponse);
			}
			historyText = historyText.Replace("\\n", "\n").Replace("\\t", "\t");
			ShowHistoryResult(hero, historyText, onComplete);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			InformationManager.DisplayMessage(new InformationMessage("Error generating history: " + ex2.Message, Colors.Red));
			onComplete?.Invoke();
		}
	}

	private void ShowHistoryResult(Hero hero, string historyText, Action onComplete)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		InformationManager.ShowInquiry(new InquiryData(((object)new TextObject("{=AIInfluence_DeathHistory_Result_Title}Life History: {NAME}", (Dictionary<string, object>)null).SetTextVariable("NAME", hero.Name)).ToString(), historyText, true, false, ((object)new TextObject("{=AIInfluence_DeathHistory_Close}Close Book", (Dictionary<string, object>)null)).ToString(), "", (Action)delegate
		{
			onComplete?.Invoke();
		}, (Action)null, "", 0f, (Action)null, (Func<ValueTuple<bool, string>>)null, (Func<ValueTuple<bool, string>>)null), true, false);
	}

	private string ExtractHistoryText(string aiResponse)
	{
		if (string.IsNullOrWhiteSpace(aiResponse))
		{
			return string.Empty;
		}
		string input = aiResponse.Trim();
		input = Regex.Replace(input, "^```json\\s*|\\s*```$", "", RegexOptions.Multiline);
		input = Regex.Replace(input, "^```\\s*|\\s*```$", "", RegexOptions.Multiline);
		try
		{
			int num = input.IndexOf('{');
			int num2 = input.LastIndexOf('}');
			if (num >= 0 && num2 > num)
			{
				string text = input.Substring(num, num2 - num + 1);
				JObject val = JObject.Parse(text);
				if (val["response"] != null)
				{
					string text2 = ((object)val["response"]).ToString();
					if (!string.IsNullOrWhiteSpace(text2) && text2.Length > 50)
					{
						return text2;
					}
				}
				string text3 = ((num > 0) ? input.Substring(0, num).Trim() : string.Empty);
				if (!string.IsNullOrWhiteSpace(text3) && text3.Length > 50)
				{
					return text3;
				}
				string text4 = ((num2 < input.Length - 1) ? input.Substring(num2 + 1).Trim() : string.Empty);
				if (!string.IsNullOrWhiteSpace(text4) && text4.Length > 50)
				{
					return text4;
				}
			}
		}
		catch
		{
		}
		return RemoveJsonFromText(input);
	}

	private string RemoveJsonFromText(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}
		string input = text;
		input = Regex.Replace(input, "```json\\s*[\\s\\S]*?```", "", RegexOptions.Multiline);
		input = Regex.Replace(input, "```\\s*[\\s\\S]*?```", "", RegexOptions.Multiline);
		string pattern = "\\{[^{}]*\"(?:response|romance_intent|decision|tone|threat_level|escalation_state|suspected_lie|deescalation_attempt|claimed_name|claimed_clan|claimed_age|claimed_gold|money_transfer|item_transfers|character_personality|character_backstory|kingdom_action|kingdom_action_reason|settlement_id|target_clan_id|daily_tribute_amount|tribute_duration_days|reparations_amount|trade_agreement_duration_years|technical_action|character_death|tts_instructions|workshop_action|workshop_string_id|witnesses|notable_phrases)\":[^{}]*(?:\\{[^{}]*\\}[^{}]*)*\\}";
		input = Regex.Replace(input, pattern, "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
		input = Regex.Replace(input, "\\n\\s*\"\\w+\":\\s*\"[^\"]*\",?\\s*", "\n", RegexOptions.Multiline);
		input = Regex.Replace(input, "\\n\\s*\"\\w+\":\\s*null,?\\s*", "\n", RegexOptions.Multiline);
		input = Regex.Replace(input, "\\n\\s*\"\\w+\":\\s*\\d+,?\\s*", "\n", RegexOptions.Multiline);
		input = Regex.Replace(input, "\\n\\s*\"\\w+\":\\s*(true|false),?\\s*", "\n", RegexOptions.Multiline);
		input = Regex.Replace(input, "\\n\\s*\"\\w+\":\\s*\\[[^\\]]*\\],?\\s*", "\n", RegexOptions.Multiline);
		input = Regex.Replace(input, "\\n\\s*\"\\w+\":\\s*\\{[^}]*\\},?\\s*", "\n", RegexOptions.Multiline);
		input = Regex.Replace(input, "\\s*[{}]\\s*", " ", RegexOptions.Multiline);
		input = Regex.Replace(input, ",\\s*$", "", RegexOptions.Multiline);
		input = Regex.Replace(input, "\\n\\s*\\n\\s*\\n+", "\n\n", RegexOptions.Multiline);
		return input.Trim();
	}

	private static string UnescapeFormatting(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		text = text.Replace("\\n", "\n");
		text = text.Replace("\\t", "\t");
		text = text.Replace("\\r", "\r");
		return text;
	}
}
