using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class NPCRelationsCache
{
	private static NPCRelationsCache _instance;

	private Dictionary<string, HashSet<string>> _relationsCache = new Dictionary<string, HashSet<string>>();

	private Dictionary<string, CampaignTime> _lastUpdateTime = new Dictionary<string, CampaignTime>();

	private const float CACHE_LIFETIME_DAYS = 1f;

	public static NPCRelationsCache Instance => _instance ?? (_instance = new NPCRelationsCache());

	public HashSet<string> GetRelatedNPCs(Hero hero, bool forceRefresh = false)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null)
		{
			return new HashSet<string>();
		}
		string stringId = ((MBObjectBase)hero).StringId;
		if (!forceRefresh && _relationsCache.ContainsKey(stringId) && _lastUpdateTime.ContainsKey(stringId))
		{
			CampaignTime val = CampaignTime.Now - _lastUpdateTime[stringId];
			if (!((val).ToDays >= 1.0))
			{
				goto IL_007d;
			}
		}
		RefreshRelations(hero);
		goto IL_007d;
		IL_007d:
		if (_relationsCache.TryGetValue(stringId, out var value))
		{
			return value;
		}
		return new HashSet<string>();
	}

	private void RefreshRelations(Hero hero)
	{
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		HashSet<string> hashSet = new HashSet<string>();
		try
		{
			if (hero.Spouse != null && hero.Spouse.IsAlive)
			{
				hashSet.Add(((MBObjectBase)hero.Spouse).StringId);
			}
			if (hero.Father != null && hero.Father.IsAlive)
			{
				hashSet.Add(((MBObjectBase)hero.Father).StringId);
			}
			if (hero.Mother != null && hero.Mother.IsAlive)
			{
				hashSet.Add(((MBObjectBase)hero.Mother).StringId);
			}
			if (hero.Children != null)
			{
				foreach (Hero item in (List<Hero>)(object)hero.Children)
				{
					if (item != null && item.IsAlive)
					{
						hashSet.Add(((MBObjectBase)item).StringId);
					}
				}
			}
			if (hero.Siblings != null)
			{
				foreach (Hero sibling in hero.Siblings)
				{
					if (sibling != null && sibling.IsAlive)
					{
						hashSet.Add(((MBObjectBase)sibling).StringId);
					}
				}
			}
			foreach (Hero item2 in (List<Hero>)(object)Hero.AllAliveHeroes)
			{
				if (item2 == hero)
				{
					continue;
				}
				try
				{
					if (hero.IsFriend(item2))
					{
						hashSet.Add(((MBObjectBase)item2).StringId);
					}
				}
				catch
				{
				}
			}
			if (hero.Clan != null && hero.Clan.Heroes != null)
			{
				foreach (Hero item3 in (List<Hero>)(object)hero.Clan.Heroes)
				{
					if (item3 != null && item3 != hero && item3.IsAlive)
					{
						hashSet.Add(((MBObjectBase)item3).StringId);
					}
				}
			}
			if (hero.MapFaction != null)
			{
				foreach (Hero item4 in ((IEnumerable<Hero>)Hero.AllAliveHeroes).Where((Hero h) => h.IsLord))
				{
					if (item4 == hero)
					{
						continue;
					}
					try
					{
						if (item4.MapFaction == hero.MapFaction && hero.GetRelation(item4) > 0)
						{
							hashSet.Add(((MBObjectBase)item4).StringId);
						}
					}
					catch
					{
					}
				}
			}
			_relationsCache[((MBObjectBase)hero).StringId] = hashSet;
			_lastUpdateTime[((MBObjectBase)hero).StringId] = CampaignTime.Now;
			AIInfluenceBehavior.Instance?.LogMessage($"[RELATIONS_CACHE] Updated relations for {hero.Name}: {hashSet.Count} related NPCs");
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[RELATIONS_CACHE] ERROR refreshing relations for {hero.Name}: {ex.Message}");
			_relationsCache[((MBObjectBase)hero).StringId] = new HashSet<string>();
			_lastUpdateTime[((MBObjectBase)hero).StringId] = CampaignTime.Now;
		}
	}

	public void InvalidateCache(string npcId)
	{
		if (!string.IsNullOrEmpty(npcId))
		{
			_relationsCache.Remove(npcId);
			_lastUpdateTime.Remove(npcId);
			AIInfluenceBehavior.Instance?.LogMessage("[RELATIONS_CACHE] Invalidated cache for " + npcId);
		}
	}

	public void InvalidateCacheWithRelated(string npcId)
	{
		if (string.IsNullOrEmpty(npcId))
		{
			return;
		}
		HashSet<string> hashSet = null;
		if (_relationsCache.TryGetValue(npcId, out var value))
		{
			hashSet = new HashSet<string>(value);
		}
		InvalidateCache(npcId);
		if (hashSet == null)
		{
			return;
		}
		foreach (string item in hashSet)
		{
			_relationsCache.Remove(item);
			_lastUpdateTime.Remove(item);
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[RELATIONS_CACHE] Invalidated cache for {npcId} and {hashSet.Count} related NPCs");
	}

	public void ClearCache()
	{
		int count = _relationsCache.Count;
		_relationsCache.Clear();
		_lastUpdateTime.Clear();
		AIInfluenceBehavior.Instance?.LogMessage($"[RELATIONS_CACHE] Cache cleared ({count} entries removed)");
	}

	public string GetCacheStats()
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		int count = _relationsCache.Count;
		int num = _relationsCache.Values.Sum((HashSet<string> s) => s.Count);
		int num2 = ((count > 0) ? (num / count) : 0);
		int num3 = 0;
		foreach (KeyValuePair<string, CampaignTime> item in _lastUpdateTime)
		{
			CampaignTime val = CampaignTime.Now - item.Value;
			if ((val).ToDays >= 1.0)
			{
				num3++;
			}
		}
		return $"Relations Cache: {count} NPCs, {num} total relations (avg {num2} per NPC), {num3} outdated";
	}
}
