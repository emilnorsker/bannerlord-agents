using System;
using System.Collections.Generic;
using System.Linq;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using static TaleWorlds.CampaignSystem.GameMenus.GameMenuOption;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class MessengerMenuBehavior : CampaignBehaviorBase
{
	public override void RegisterEvents()
	{
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	public static void AddTavernMenuOption(CampaignGameStarter starter)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0032: Expected O, but got Unknown
		starter.AddGameMenuOption("town_backstreet", "send_messenger_to_npc", "{=AIInfluence_SendMessengerMenu}Send messenger", new OnConditionDelegate(SendMessengerCondition), new OnConsequenceDelegate(SendMessengerConsequence), false, 1, false, (object)null);
	}

	private static bool SendMessengerCondition(MenuCallbackArgs args)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		args.optionLeaveType = (LeaveType)2;
		if (GlobalSettings<ModSettings>.Instance == null)
		{
			return true;
		}
		return GlobalSettings<ModSettings>.Instance.EnableModification && GlobalSettings<ModSettings>.Instance.EnableNPCInitiative;
	}

	private static void SendMessengerConsequence(MenuCallbackArgs args)
	{
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		AIInfluenceBehavior behavior = AIInfluenceBehavior.Instance;
		if (behavior == null)
		{
			return;
		}
		Dictionary<string, NPCContext> nPCContexts = behavior.GetNPCContexts();
		List<Hero> list = new List<Hero>();
		if (nPCContexts != null)
		{
			foreach (KeyValuePair<string, NPCContext> kvp in nPCContexts)
			{
				if (kvp.Value.InteractionCount > 5)
				{
					Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == kvp.Key));
					if (val != null && val.IsAlive && !val.IsPrisoner)
					{
						list.Add(val);
					}
				}
			}
		}
		List<InquiryElement> list2 = new List<InquiryElement>();
		foreach (Hero item in list)
		{
			Clan clan = item.Clan;
			string text = ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "";
			list2.Add(new InquiryElement((object)item, ((object)item.Name).ToString(), (ImageIdentifier)new CharacterImageIdentifier(CampaignUIHelper.GetCharacterCode(item.CharacterObject, false)), true, text));
		}
		MBInformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(((object)new TextObject("{=AIInfluence_SelectMessengerRecipient}Select NPC to send messenger", (Dictionary<string, object>)null)).ToString(), list.Any() ? string.Empty : ((object)new TextObject("{=AIInfluence_NoNPCsAvailable}No NPCs with enough interactions available.", (Dictionary<string, object>)null)).ToString(), list2, true, 1, 1, ((object)new TextObject("{=AIInfluence_SelectRecipientDone}Select", (Dictionary<string, object>)null)).ToString(), ((object)new TextObject("{=AIInfluence_Cancel}Cancel", (Dictionary<string, object>)null)).ToString(), (Action<List<InquiryElement>>)delegate(List<InquiryElement> selectedElements)
		{
			if (selectedElements != null && selectedElements.Any())
			{
				object identifier = selectedElements.First().Identifier;
				Hero val2 = (Hero)((identifier is Hero) ? identifier : null);
				if (val2 != null)
				{
					behavior.InitiativeSystem.InitiateMessengerFlow(val2);
				}
			}
		}, (Action<List<InquiryElement>>)null, "", false), false, false);
	}
}
