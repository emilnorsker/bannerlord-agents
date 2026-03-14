using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public static class IntimacySystem
{
	private static readonly AIInfluenceBehavior _behavior = AIInfluenceBehavior.Instance;

	public static void HandleIntimateInteraction(Hero npc, Hero player, NPCContext context, float conceptionChance = 0.15f, float romanceIncrease = 15f)
	{
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null || player == null || context == null)
		{
			_behavior.LogMessage("[ERROR] IntimacySystem: Invalid parameters");
			return;
		}
		string arg = ((object)npc.Name)?.ToString() ?? "Unknown";
		_behavior.LogMessage($"[INTIMACY] Processing intimate interaction between {player.Name} and {arg}");
		if (!CanHaveIntimateInteraction(npc, player, context))
		{
			_behavior.LogMessage("[INTIMACY] Cannot have intimate interaction: conditions not met");
			return;
		}
		Hero val = (npc.IsFemale ? npc : (player.IsFemale ? player : null));
		Hero val2 = (npc.IsFemale ? player : (player.IsFemale ? npc : null));
		if (val != null && val2 != null)
		{
			bool isPregnant = val.IsPregnant;
			bool flag = IsAgeAppropriateForPregnancy(val);
			if (!isPregnant && flag)
			{
				float num = (float)new Random().NextDouble();
				_behavior.LogMessage($"[INTIMACY] Conception chance: {conceptionChance * 100f:F1}%, Roll: {num:F3}");
				if (num < conceptionChance)
				{
					MakePregnant(val, val2);
					_behavior.LogMessage($"[INTIMACY] Conception successful! {val.Name} is now pregnant with {val2.Name}'s child.");
					if (context != null)
					{
						context.PendingConceptionMotherName = ((object)val.Name)?.ToString();
					}
				}
				else
				{
					_behavior.LogMessage($"[INTIMACY] Conception did not occur (roll {num:F3} >= chance {conceptionChance:F3})");
				}
			}
			else if (isPregnant)
			{
				_behavior.LogMessage($"[INTIMACY] {val.Name} is already pregnant - intimacy occurred without conception");
			}
			else
			{
				_behavior.LogMessage($"[INTIMACY] {val.Name} is not in appropriate age range for pregnancy (age: {val.Age:F1}, required: 18-45) - intimacy occurred without conception");
			}
		}
		else
		{
			_behavior.LogMessage("[INTIMACY] No pregnancy possible: both characters are the same gender or both male - intimacy occurred without conception");
		}
		if (context != null)
		{
			context.RomanceLevel = Math.Min(100f, context.RomanceLevel + romanceIncrease);
			CampaignTime now = CampaignTime.Now;
			context.LastRomanceInteractionDays = (int)(now).ToDays;
			now = CampaignTime.Now;
			context.LastIntimateInteractionDays = (int)(now).ToDays;
			_behavior.LogMessage($"[INTIMACY] Romance level increased by {romanceIncrease:F1} to {context.RomanceLevel:F1}");
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		}
	}

	private static bool CanHaveIntimateInteraction(Hero npc, Hero player, NPCContext context)
	{
		if (npc == null || player == null || context == null)
		{
			return false;
		}
		if (!context.IsRomanceEligible)
		{
			_behavior.LogMessage("[INTIMACY] Cannot have intimate interaction: romance is not eligible (IsRomanceEligible=false)");
			return false;
		}
		if (npc.Father == player || npc.Mother == player || player.Father == npc || player.Mother == npc || npc.Siblings.Contains(player) || player.Siblings.Contains(npc) || ((List<Hero>)(object)npc.Children).Contains(player) || ((List<Hero>)(object)player.Children).Contains(npc))
		{
			_behavior.LogMessage("[INTIMACY] Cannot have intimate interaction: characters are related");
			return false;
		}
		if (npc.IsChild || player.IsChild)
		{
			_behavior.LogMessage("[INTIMACY] Cannot have intimate interaction: one of the characters is a child");
			return false;
		}
		if (!GlobalSettings<ModSettings>.Instance.AllowRomanceWithMarried)
		{
			if (npc.Spouse != null && npc.Spouse != player)
			{
				_behavior.LogMessage("[INTIMACY] Cannot have intimate interaction: NPC is married and AllowRomanceWithMarried is false");
				return false;
			}
			if (player.Spouse != null && player.Spouse != npc)
			{
				_behavior.LogMessage("[INTIMACY] Cannot have intimate interaction: Player is married and AllowRomanceWithMarried is false");
				return false;
			}
		}
		return true;
	}

	private static bool IsAgeAppropriateForPregnancy(Hero hero)
	{
		if (hero == null)
		{
			return false;
		}
		return hero.Age >= 18f && hero.Age < 45f;
	}

	private static void MakePregnant(Hero mother, Hero father)
	{
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		if (mother == null || father == null)
		{
			_behavior.LogMessage("[ERROR] IntimacySystem.MakePregnant: mother or father is null");
			return;
		}
		try
		{
			if (mother.Spouse == father)
			{
				MakePregnantAction.Apply(mother);
				_behavior.LogMessage($"[INTIMACY] Made {mother.Name} pregnant via MakePregnantAction (married to {father.Name})");
				return;
			}
			mother.IsPregnant = true;
			PregnancyCampaignBehavior campaignBehavior = Campaign.Current.GetCampaignBehavior<PregnancyCampaignBehavior>();
			if (campaignBehavior == null)
			{
				_behavior.LogMessage("[ERROR] IntimacySystem: PregnancyCampaignBehavior not found via GetCampaignBehavior");
				return;
			}
			FieldInfo field = typeof(PregnancyCampaignBehavior).GetField("_heroPregnancies", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field == null)
			{
				_behavior.LogMessage("[ERROR] IntimacySystem: _heroPregnancies field not found");
				return;
			}
			object value = field.GetValue(campaignBehavior);
			if (value == null)
			{
				_behavior.LogMessage("[ERROR] IntimacySystem: _heroPregnancies is null");
				return;
			}
			Type nestedType = typeof(PregnancyCampaignBehavior).GetNestedType("Pregnancy", BindingFlags.Public | BindingFlags.NonPublic);
			if (nestedType == null)
			{
				_behavior.LogMessage("[ERROR] IntimacySystem: Pregnancy nested type not found");
				return;
			}
			ConstructorInfo constructor = nestedType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[3]
			{
				typeof(Hero),
				typeof(Hero),
				typeof(CampaignTime)
			}, null);
			if (constructor == null)
			{
				_behavior.LogMessage("[ERROR] IntimacySystem: Pregnancy constructor not found");
				return;
			}
			CampaignTime val = CampaignTime.DaysFromNow(Campaign.Current.Models.PregnancyModel.PregnancyDurationInDays);
			object value2 = constructor.Invoke(new object[3] { mother, father, val });
			if (value is IList list)
			{
				list.Add(value2);
				_behavior.LogMessage($"[INTIMACY] Created pregnancy: {mother.Name} + {father.Name} (unmarried), due in {Campaign.Current.Models.PregnancyModel.PregnancyDurationInDays:F0} days");
			}
			else
			{
				_behavior.LogMessage("[ERROR] IntimacySystem: _heroPregnancies is not IList");
			}
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[ERROR] IntimacySystem.MakePregnant: " + ex.Message + "\n" + ex.StackTrace);
		}
	}
}
