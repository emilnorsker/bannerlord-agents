using System;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

/// <summary>Slice 11 / 23: hazard checks — gm.query.* is generally allowed; mutates use API-backed rules.</summary>
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
		if (cmd.StartsWith("gm.query.", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (cmd.StartsWith("gm.kingdom.", StringComparison.OrdinalIgnoreCase) && Campaign.Current != null)
		{
			Hero main = Hero.MainHero;
			if (main?.Clan?.Kingdom == null)
			{
				rejectionReason = "hazard: gm.kingdom.* requires player clan to belong to a kingdom";
				return false;
			}
			if (main.Clan.Kingdom.Leader != main)
			{
				rejectionReason = "hazard: gm.kingdom.* requires player to be kingdom ruler for many kingdom console actions";
				return false;
			}
		}
		if (LooksLikeHighRiskFamily(cmd) && npcInterlocutor != null && npcInterlocutor.IsPrisoner)
		{
			rejectionReason = "hazard: high-risk GM family while NPC interlocutor is prisoner (NPC-path)";
			return false;
		}
		if (LooksLikeHighRiskFamily(cmd))
		{
			rejectionReason = "hazard: troop/bandit/caravan family blocked for unattended automation (use gm.query.* or disable hazard enforcement)";
			return false;
		}
		return true;
	}

	private static bool LooksLikeHighRiskFamily(string cmd)
	{
		if (cmd.StartsWith("gm.troop.", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (cmd.StartsWith("gm.bandit.", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (cmd.StartsWith("gm.caravan.", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return false;
	}
}
