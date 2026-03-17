using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using AIInfluence.Util;

namespace AIInfluence;

public static class QuestPartyMapMarkerService
{
	public static void AddMarker(string questId, MobileParty party, string displayName)
	{
		if (string.IsNullOrEmpty(questId) || party == null || Campaign.Current?.MapMarkerManager == null)
			return;
		Campaign.Current.MapMarkerManager.RemoveAllMapMarkersByQuestId(questId);
		Banner banner = party.MapFaction?.Banner ?? party.LeaderHero?.Clan?.Banner
			?? Hero.MainHero?.Clan?.Banner ?? Clan.BanditFactions?.FirstOrDefault()?.Banner;
		if (banner == null)
			return;
		Vec2 pos = party.GetPosition2D();
		Vec3 position = new Vec3(pos.X, pos.Y, 0f);
		TextObject name = new TextObject(displayName, (Dictionary<string, object>)null);
		Campaign.Current.MapMarkerManager.CreateMapMarker(banner, name, position, isVisibleOnMap: true, questId);
	}

	public static void RemoveMarker(string questId)
	{
		if (string.IsNullOrEmpty(questId) || Campaign.Current?.MapMarkerManager == null)
			return;
		Campaign.Current.MapMarkerManager.RemoveAllMapMarkersByQuestId(questId);
	}
}
