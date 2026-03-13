using System;
using System.Collections.Generic;
using SandBox.ViewModelCollection;
using SandBox.ViewModelCollection.Nameplate.NameplateNotifications;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Localization;

namespace AIInfluence.ViewModels;

public class HeroVisitedHospitalNotificationItemVM : SettlementNotificationItemBaseVM
{
	public HeroVisitedHospitalNotificationItemVM(Action<SettlementNotificationItemBaseVM> onRemove, Hero hero, Settlement settlement, int createdTick)
		: base(onRemove, createdTick)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		string text = ((settlement != null && settlement.IsVillage) ? "{=AIInfluence_VisitedHealerLog}Visited the healer" : "{=AIInfluence_VisitedHospitalLog}Visited the hospital");
		((SettlementNotificationItemBaseVM)this).Text = ((object)new TextObject(text, (Dictionary<string, object>)null)).ToString();
		((SettlementNotificationItemBaseVM)this).CharacterName = ((hero == null) ? null : ((object)hero.Name)?.ToString()) ?? "";
		((SettlementNotificationItemBaseVM)this).CharacterVisual = ((hero != null) ? new CharacterImageIdentifierVM(SandBoxUIHelper.GetCharacterCode(hero.CharacterObject, false)) : new CharacterImageIdentifierVM((CharacterCode)null));
		int relationType = 0;
		if (hero != null && hero.Clan != null)
		{
			Hero mainHero = Hero.MainHero;
			if (((mainHero != null) ? mainHero.Clan : null) != null && hero.Clan.IsAtWarWith((IFaction)(object)Hero.MainHero.Clan))
			{
				relationType = -1;
				goto IL_00cb;
			}
		}
		if (hero != null)
		{
			relationType = 1;
		}
		goto IL_00cb;
		IL_00cb:
		((SettlementNotificationItemBaseVM)this).RelationType = relationType;
		((SettlementNotificationItemBaseVM)this).CreatedTick = createdTick;
	}
}
