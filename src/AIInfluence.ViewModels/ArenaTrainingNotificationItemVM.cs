using System;
using System.Collections.Generic;
using SandBox.ViewModelCollection;
using SandBox.ViewModelCollection.Nameplate.NameplateNotifications;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Localization;

namespace AIInfluence.ViewModels;

public class ArenaTrainingNotificationItemVM : SettlementNotificationItemBaseVM
{
	public ArenaTrainingNotificationItemVM(Action<SettlementNotificationItemBaseVM> onRemove, Hero hero, Settlement settlement, int createdTick, string customText = null)
		: base(onRemove, createdTick)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		string text = customText ?? ((object)new TextObject("{=AIInfluence_ArenaTrainNotification}Trains troops", (Dictionary<string, object>)null)).ToString();
		((SettlementNotificationItemBaseVM)this).Text = text;
		int relationType;
		if (hero != null)
		{
			((SettlementNotificationItemBaseVM)this).CharacterName = ((object)hero.Name)?.ToString() ?? "";
			((SettlementNotificationItemBaseVM)this).CharacterVisual = new CharacterImageIdentifierVM(SandBoxUIHelper.GetCharacterCode(hero.CharacterObject, false));
			relationType = 0;
			if (hero.Clan != null)
			{
				Hero mainHero = Hero.MainHero;
				if (((mainHero != null) ? mainHero.Clan : null) != null && hero.Clan.IsAtWarWith((IFaction)(object)Hero.MainHero.Clan))
				{
					relationType = -1;
					goto IL_00b9;
				}
			}
			if (hero != null)
			{
				relationType = 1;
			}
			goto IL_00b9;
		}
		((SettlementNotificationItemBaseVM)this).CharacterName = ((settlement == null) ? null : ((object)settlement.Name)?.ToString()) ?? "";
		((SettlementNotificationItemBaseVM)this).CharacterVisual = null;
		((SettlementNotificationItemBaseVM)this).RelationType = 0;
		goto IL_00fe;
		IL_00fe:
		((SettlementNotificationItemBaseVM)this).CreatedTick = createdTick;
		return;
		IL_00b9:
		((SettlementNotificationItemBaseVM)this).RelationType = relationType;
		goto IL_00fe;
	}
}
