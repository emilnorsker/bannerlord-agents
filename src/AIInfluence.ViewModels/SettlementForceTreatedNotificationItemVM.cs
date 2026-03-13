using System;
using System.Collections.Generic;
using SandBox.ViewModelCollection;
using SandBox.ViewModelCollection.Nameplate.NameplateNotifications;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Localization;

namespace AIInfluence.ViewModels;

public class SettlementForceTreatedNotificationItemVM : SettlementNotificationItemBaseVM
{
	public SettlementForceTreatedNotificationItemVM(Action<SettlementNotificationItemBaseVM> onRemove, Settlement settlement, string targetType, int createdTick, Hero lordHero = null, string ownerDisplayName = null)
		: base(onRemove, createdTick)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		bool flag = settlement != null && settlement.IsVillage;
		bool flag2 = lordHero != null;
		string text = ((targetType == "party_troops") ? (flag2 ? "{=AIInfluence_PartyTreatedActionLog}Party being treated" : "{=AIInfluence_PartyTreatedLog}Party being treated") : ((!(targetType == "garrison")) ? (flag ? "{=AIInfluence_VillageDefendersTreatedLog}Defenders being treated" : "{=AIInfluence_MilitiaTreatedLog}Militia being treated") : (flag ? "{=AIInfluence_VillageDefendersTreatedLog}Defenders being treated" : "{=AIInfluence_GarrisonTreatedLog}Garrison being treated")));
		((SettlementNotificationItemBaseVM)this).Text = ((object)new TextObject(text, (Dictionary<string, object>)null)).ToString();
		int relationType;
		if (targetType == "party_troops" && flag2)
		{
			((SettlementNotificationItemBaseVM)this).CharacterName = ((object)lordHero.Name)?.ToString() ?? "";
			((SettlementNotificationItemBaseVM)this).CharacterVisual = new CharacterImageIdentifierVM(SandBoxUIHelper.GetCharacterCode(lordHero.CharacterObject, false));
			if (lordHero.Clan != null)
			{
				Hero mainHero = Hero.MainHero;
				if (((mainHero != null) ? mainHero.Clan : null) != null && lordHero.Clan.IsAtWarWith((IFaction)(object)Hero.MainHero.Clan))
				{
					relationType = -1;
					goto IL_0117;
				}
			}
			relationType = 1;
			goto IL_0117;
		}
		if (targetType == "party_troops" && !string.IsNullOrEmpty(ownerDisplayName))
		{
			((SettlementNotificationItemBaseVM)this).Text = ((object)new TextObject("{=AIInfluence_PartyTreatedWithLordLog}Party of {HERO_NAME} being treated", (Dictionary<string, object>)null).SetTextVariable("HERO_NAME", ownerDisplayName)).ToString();
			((SettlementNotificationItemBaseVM)this).CharacterName = "";
			((SettlementNotificationItemBaseVM)this).CharacterVisual = null;
			((SettlementNotificationItemBaseVM)this).RelationType = 0;
		}
		else if (targetType == "party_troops")
		{
			((SettlementNotificationItemBaseVM)this).CharacterName = "";
			((SettlementNotificationItemBaseVM)this).CharacterVisual = null;
			((SettlementNotificationItemBaseVM)this).RelationType = 0;
		}
		else
		{
			((SettlementNotificationItemBaseVM)this).CharacterName = ((settlement == null) ? null : ((object)settlement.Name)?.ToString()) ?? "";
			((SettlementNotificationItemBaseVM)this).CharacterVisual = null;
			((SettlementNotificationItemBaseVM)this).RelationType = 0;
		}
		goto IL_01f1;
		IL_01f1:
		((SettlementNotificationItemBaseVM)this).CreatedTick = createdTick;
		return;
		IL_0117:
		((SettlementNotificationItemBaseVM)this).RelationType = relationType;
		goto IL_01f1;
	}
}
