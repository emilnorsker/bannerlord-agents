using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public static class CharacterInfo
{
	public static string GetEquipmentDescription(Hero hero)
	{
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Invalid comparison between Unknown and I4
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			LogDebug("[CharacterInfo.GetEquipmentDescription] START for hero: " + (((hero == null) ? null : ((object)hero.Name)?.ToString()) ?? "NULL"));
			if (hero == null)
			{
				LogDebug("[CharacterInfo.GetEquipmentDescription] Hero is NULL, returning early");
				return "No equipment information available.";
			}
			Equipment val = null;
			if (Mission.Current != null && hero.CharacterObject != null)
			{
				LogDebug("[CharacterInfo.GetEquipmentDescription] Mission.Current exists");
				bool doesMissionRequireCivilianEquipment = Mission.Current.DoesMissionRequireCivilianEquipment;
				LogDebug($"[CharacterInfo.GetEquipmentDescription] DoesMissionRequireCivilianEquipment: {doesMissionRequireCivilianEquipment}");
				if (doesMissionRequireCivilianEquipment)
				{
					val = ((BasicCharacterObject)hero.CharacterObject).FirstCivilianEquipment;
					LogDebug("[CharacterInfo.GetEquipmentDescription] Using FirstCivilianEquipment");
				}
				else
				{
					val = ((BasicCharacterObject)hero.CharacterObject).FirstBattleEquipment;
					LogDebug("[CharacterInfo.GetEquipmentDescription] Using FirstBattleEquipment");
				}
			}
			else
			{
				LogDebug("[CharacterInfo.GetEquipmentDescription] Mission.Current is NULL, using fallback");
			}
			if (val == null)
			{
				LogDebug("[CharacterInfo.GetEquipmentDescription] Equipment is NULL, using CharacterObject.Equipment");
				CharacterObject characterObject = hero.CharacterObject;
				val = ((characterObject != null) ? ((BasicCharacterObject)characterObject).Equipment : null);
				LogDebug("[CharacterInfo.GetEquipmentDescription] CharacterObject.Equipment: " + ((val != null) ? "Present" : "NULL"));
			}
			if (val == null)
			{
				LogDebug("[CharacterInfo.GetEquipmentDescription] All equipment sources failed, returning early");
				return "No equipment information available.";
			}
			LogDebug("[CharacterInfo.GetEquipmentDescription] Building equipment description...");
			object obj = hero.CurrentSettlement;
			if (obj == null)
			{
				MobileParty partyBelongedTo = hero.PartyBelongedTo;
				obj = ((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null);
				if (obj == null)
				{
					Hero mainHero = Hero.MainHero;
					obj = ((mainHero != null) ? mainHero.CurrentSettlement : null);
					if (obj == null)
					{
						Hero mainHero2 = Hero.MainHero;
						if (mainHero2 == null)
						{
							obj = null;
						}
						else
						{
							MobileParty partyBelongedTo2 = mainHero2.PartyBelongedTo;
							obj = ((partyBelongedTo2 != null) ? partyBelongedTo2.CurrentSettlement : null);
						}
					}
				}
			}
			Settlement priceContextSettlement = (Settlement)obj;
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			EquipmentElement val2 = val[(EquipmentIndex)5];
			ItemObject item = (val2).Item;
			if (item != null)
			{
				list.Add(string.Format("{0} (head, string_id:{1}){2}", item.Name, ((MBObjectBase)item).StringId ?? "unknown", GetItemPriceInfo(item)));
			}
			val2 = val[(EquipmentIndex)9];
			ItemObject item2 = (val2).Item;
			if (item2 != null)
			{
				list.Add(string.Format("{0} (shoulders, string_id:{1}){2}", item2.Name, ((MBObjectBase)item2).StringId ?? "unknown", GetItemPriceInfo(item2)));
			}
			val2 = val[(EquipmentIndex)6];
			ItemObject item3 = (val2).Item;
			if (item3 != null)
			{
				list.Add(string.Format("{0} (torso, string_id:{1}){2}", item3.Name, ((MBObjectBase)item3).StringId ?? "unknown", GetItemPriceInfo(item3)));
			}
			val2 = val[(EquipmentIndex)8];
			ItemObject item4 = (val2).Item;
			if (item4 != null)
			{
				list.Add(string.Format("{0} (hands, string_id:{1}){2}", item4.Name, ((MBObjectBase)item4).StringId ?? "unknown", GetItemPriceInfo(item4)));
			}
			val2 = val[(EquipmentIndex)7];
			ItemObject item5 = (val2).Item;
			if (item5 != null)
			{
				list.Add(string.Format("{0} (legs, string_id:{1}){2}", item5.Name, ((MBObjectBase)item5).StringId ?? "unknown", GetItemPriceInfo(item5)));
			}
			for (EquipmentIndex val3 = (EquipmentIndex)0; (int)val3 <= 3; val3 = (EquipmentIndex)(val3 + 1))
			{
				val2 = val[val3];
				ItemObject item6 = (val2).Item;
				if (item6 != null)
				{
					list2.Add(string.Format("{0} (id:{1}){2}", item6.Name, ((MBObjectBase)item6).StringId ?? "unknown", GetItemPriceInfo(item6)));
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (list.Any())
			{
				stringBuilder.Append("Wears: " + string.Join(", ", list) + ". ");
			}
			else
			{
				stringBuilder.Append("Wears simple clothes. ");
			}
			if (list2.Any())
			{
				IEnumerable<string> values = list2.Distinct();
				stringBuilder.Append("Weapons: " + string.Join(", ", values) + ".");
			}
			else
			{
				stringBuilder.Append("Unarmed.");
			}
			string text = stringBuilder.ToString();
			LogDebug($"[CharacterInfo.GetEquipmentDescription] COMPLETE, returning {text.Length} chars");
			return text;
			string GetItemPriceInfo(ItemObject val4)
			{
				if (val4 == null)
				{
					return "";
				}
				int num = val4.Value;
				bool flag = false;
				if (priceContextSettlement != null)
				{
					try
					{
						if (priceContextSettlement.IsTown && priceContextSettlement.Town != null)
						{
							num = ((SettlementComponent)priceContextSettlement.Town).GetItemPrice(val4, (MobileParty)null, false);
							flag = true;
						}
						else if (priceContextSettlement.IsVillage && priceContextSettlement.Village != null)
						{
							num = ((SettlementComponent)priceContextSettlement.Village).GetItemPrice(val4, (MobileParty)null, false);
							flag = true;
						}
					}
					catch
					{
						num = val4.Value;
					}
				}
				string arg = (flag ? "approx. market price" : "approx. base value");
				return $" (approx. {num} gold, {arg})";
			}
		}
		catch (Exception ex)
		{
			LogDebug("[CharacterInfo.GetEquipmentDescription] EXCEPTION: " + ex.Message);
			LogDebug("[CharacterInfo.GetEquipmentDescription] StackTrace: " + ex.StackTrace);
			return "No equipment information available.";
		}
	}

	public static string GetAppearanceDescription(Hero hero)
	{
		if (((hero != null) ? hero.CharacterObject : null) == null)
		{
			return "No appearance information available.";
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = (int)hero.Age;
		string text = ((num < 18) ? "young" : ((num < 30) ? "young adult" : ((num < 50) ? "middle-aged" : "elderly")));
		string text2 = (hero.IsFemale ? "female" : "male");
		string buildDescription = GetBuildDescription(hero.Build);
		string weightDescription = GetWeightDescription(hero.Weight);
		stringBuilder.Append("A " + text + " " + text2 + " with " + buildDescription + " build and " + weightDescription + " physique.");
		return stringBuilder.ToString().Trim();
	}

	private static string GetBuildDescription(float build)
	{
		if (build < 0.3f)
		{
			return "slender";
		}
		if (build < 0.7f)
		{
			return "average";
		}
		return "muscular";
	}

	private static string GetWeightDescription(float weight)
	{
		if (weight < 0.3f)
		{
			return "lean";
		}
		if (weight < 0.7f)
		{
			return "average";
		}
		return "stocky";
	}

	private static Agent FindHeroAgent(Hero hero)
	{
		try
		{
			LogDebug("[CharacterInfo.FindHeroAgent] START for hero: " + (((hero == null) ? null : ((object)hero.Name)?.ToString()) ?? "NULL"));
			if (hero == null || Mission.Current == null)
			{
				LogDebug("[CharacterInfo.FindHeroAgent] Hero or Mission is NULL, returning null");
				return null;
			}
			if (hero == Hero.MainHero)
			{
				LogDebug("[CharacterInfo.FindHeroAgent] Hero is MainHero, returning Agent.Main: " + ((Agent.Main != null) ? "Present" : "NULL"));
				return Agent.Main;
			}
			LogDebug("[CharacterInfo.FindHeroAgent] Searching for NPC agent in mission...");
			int num = 0;
			foreach (Agent item in (List<Agent>)(object)Mission.Current.Agents)
			{
				num++;
				if (item != null && item.IsActive() && item.IsHuman)
				{
					BasicCharacterObject character = item.Character;
					CharacterObject val = (CharacterObject)(object)((character is CharacterObject) ? character : null);
					if (val != null && ((BasicCharacterObject)val).IsHero && val.HeroObject == hero)
					{
						LogDebug($"[CharacterInfo.FindHeroAgent] FOUND agent after checking {num} agents");
						return item;
					}
				}
			}
			LogDebug($"[CharacterInfo.FindHeroAgent] Agent NOT FOUND after checking {num} agents");
			return null;
		}
		catch (Exception ex)
		{
			LogDebug("[CharacterInfo.FindHeroAgent] EXCEPTION: " + ex.Message);
			return null;
		}
	}

	public static string FormatEncyclopediaDescription(string backstory, string personality)
	{
		if (string.IsNullOrWhiteSpace(backstory) && string.IsNullOrWhiteSpace(personality))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrWhiteSpace(backstory))
		{
			stringBuilder.Append(backstory.Trim());
		}
		if (!string.IsNullOrWhiteSpace(personality))
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append("\n\n");
			}
			stringBuilder.Append(personality.Trim());
		}
		return stringBuilder.ToString();
	}

	public static bool UpdateEncyclopediaDescription(Hero hero, string backstory, string personality)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		try
		{
			if (hero == null)
			{
				return false;
			}
			string text = FormatEncyclopediaDescription(backstory, personality);
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "";
			}
			if (hero.CharacterObject != null)
			{
				try
				{
					TextObject value = new TextObject(text, (Dictionary<string, object>)null);
					Type type = ((object)hero.CharacterObject).GetType();
					PropertyInfo property = type.GetProperty("EncyclopediaText", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (property != null && property.CanWrite)
					{
						property.SetValue(hero.CharacterObject, value);
						return true;
					}
				}
				catch (Exception)
				{
				}
			}
			try
			{
				TextObject value2 = new TextObject(text, (Dictionary<string, object>)null);
				Type type2 = ((object)hero).GetType();
				PropertyInfo property2 = type2.GetProperty("EncyclopediaText", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (property2 != null && property2.CanWrite)
				{
					property2.SetValue(hero, value2);
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}
		catch (Exception ex3)
		{
			LogDebug("[CharacterInfo.UpdateEncyclopediaDescription] EXCEPTION: " + ex3.Message);
			LogDebug("[CharacterInfo.UpdateEncyclopediaDescription] StackTrace: " + ex3.StackTrace);
			return false;
		}
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
}
