using System;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

/// <summary>Slice 11: reject or warn on error-prone gm.* lines using campaign facts.</summary>
public static class GameMasterHazardIndex
{
	public static bool TryPassPreconditions(string line, Hero npcInterlocutor, out string rejectionReason)
	{
		rejectionReason = null;
		if (string.IsNullOrWhiteSpace(line))
		{
			rejectionReason = "empty line";
			return false;
		}
		string[] parts = line.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		if (parts.Length == 0)
		{
			rejectionReason = "no command token";
			return false;
		}
		string cmd = parts[0].ToLowerInvariant();
		if (cmd.StartsWith("gm.kingdom.", StringComparison.OrdinalIgnoreCase) && Campaign.Current != null)
		{
			Hero main = Hero.MainHero;
			if (main?.Clan?.Kingdom == null)
			{
				rejectionReason = "hazard: gm.kingdom.* requires player clan to belong to a kingdom";
				return false;
			}
			bool isRuler = main.Clan.Kingdom.Leader == main;
			if (!isRuler)
			{
				rejectionReason = "hazard: gm.kingdom.* requires player to be kingdom ruler (vassals lack authority for many kingdom console actions)";
				return false;
			}
		}
		if (LooksLikeMassDestructive(cmd))
		{
			rejectionReason = "hazard: command family is treated as high-risk for automation; disable hazard index in settings to allow (not recommended)";
			return false;
		}
		return true;
	}

	private static bool LooksLikeMassDestructive(string cmd)
	{
		if (cmd.StartsWith("gm.troop.", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (cmd.StartsWith("gm.bandit.", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return false;
	}
}
