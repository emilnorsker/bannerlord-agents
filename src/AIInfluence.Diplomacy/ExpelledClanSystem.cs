using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class ExpelledClanSystem
{
	private static ExpelledClanSystem _instance;

	private readonly DiplomacyStorage _storage;

	public static ExpelledClanSystem Instance => _instance ?? (_instance = new ExpelledClanSystem());

	public Dictionary<string, List<ExpulsionRecord>> ExpelledClans { get; set; } = new Dictionary<string, List<ExpulsionRecord>>();

	private ExpelledClanSystem()
	{
		_storage = new DiplomacyStorage();
		LoadData();
	}

	public static void Reset()
	{
		if (_instance != null)
		{
			_instance.ExpelledClans.Clear();
			AIInfluenceBehavior.Instance?.LogMessage("[EXPELLED_CLAN_SYSTEM] Expelled clan system state reset for new campaign");
		}
		_instance = null;
	}

	public void LoadData()
	{
		ExpelledClans.Clear();
		ExpelledClans = _storage.LoadExpelledClans() ?? new Dictionary<string, List<ExpulsionRecord>>();
		if (Clan.PlayerClan == null)
		{
			return;
		}
		string playerClanId = ((MBObjectBase)Clan.PlayerClan).StringId;
		bool flag = false;
		foreach (string item in ExpelledClans.Keys.ToList())
		{
			if (ExpelledClans[item].Any((ExpulsionRecord r) => r.ClanId == playerClanId))
			{
				ExpelledClans[item].RemoveAll((ExpulsionRecord r) => r.ClanId == playerClanId);
				flag = true;
			}
		}
		if (flag)
		{
			SaveData();
			DiplomacyLogger.Instance.Log("[EXPELLED_CLAN_SYSTEM] Cleaned up old ban records for player's clan on load");
		}
	}

	public void SaveData()
	{
		_storage.SaveExpelledClans(ExpelledClans);
	}

	public void BanClan(Kingdom kingdom, Clan clan, string reason = "Expelled by ruler")
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null || clan == null)
		{
			return;
		}
		if (clan == Clan.PlayerClan)
		{
			DiplomacyLogger.Instance.Log("[EXPELLED_CLAN_SYSTEM] Skipping ban for player's clan - player can always rejoin kingdoms");
			return;
		}
		string stringId = ((MBObjectBase)kingdom).StringId;
		string clanId = ((MBObjectBase)clan).StringId;
		if (!ExpelledClans.ContainsKey(stringId))
		{
			ExpelledClans[stringId] = new List<ExpulsionRecord>();
		}
		if (!ExpelledClans[stringId].Any((ExpulsionRecord r) => r.ClanId == clanId))
		{
			ExpulsionRecord item = new ExpulsionRecord
			{
				ClanId = clanId,
				KingdomId = stringId,
				ExpulsionDate = CampaignTime.Now,
				Reason = reason
			};
			ExpelledClans[stringId].Add(item);
			SaveData();
			DiplomacyLogger.Instance.Log($"[EXPELLED_CLAN_SYSTEM] Banned clan {clan.Name} ({clanId}) from {kingdom.Name} ({stringId}). Reason: {reason}");
		}
	}

	public bool IsClanBanned(Kingdom kingdom, Clan clan)
	{
		if (kingdom == null || clan == null)
		{
			return false;
		}
		string stringId = ((MBObjectBase)kingdom).StringId;
		string clanId = ((MBObjectBase)clan).StringId;
		if (ExpelledClans.TryGetValue(stringId, out var value))
		{
			return value.Any((ExpulsionRecord r) => r.ClanId == clanId);
		}
		return false;
	}

	public ExpulsionRecord GetExpulsionRecord(Kingdom kingdom, Clan clan)
	{
		if (kingdom == null || clan == null)
		{
			return null;
		}
		string stringId = ((MBObjectBase)kingdom).StringId;
		string clanId = ((MBObjectBase)clan).StringId;
		if (ExpelledClans.TryGetValue(stringId, out var value))
		{
			return value.FirstOrDefault((ExpulsionRecord r) => r.ClanId == clanId);
		}
		return null;
	}

	public void PardonClan(Kingdom kingdom, Clan clan)
	{
		if (kingdom == null || clan == null)
		{
			return;
		}
		string stringId = ((MBObjectBase)kingdom).StringId;
		string clanId = ((MBObjectBase)clan).StringId;
		if (ExpelledClans.TryGetValue(stringId, out var value))
		{
			int num = value.RemoveAll((ExpulsionRecord r) => r.ClanId == clanId);
			if (num > 0)
			{
				SaveData();
				DiplomacyLogger.Instance.Log($"[EXPELLED_CLAN_SYSTEM] Pardoned clan {clan.Name} ({clanId}) in {kingdom.Name} ({stringId})");
			}
		}
	}
}
