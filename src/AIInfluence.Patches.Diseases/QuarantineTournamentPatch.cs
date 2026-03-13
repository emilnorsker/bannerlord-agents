using AIInfluence.Diseases;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.TournamentGames;

namespace AIInfluence.Patches.Diseases;

[HarmonyPatch(typeof(TournamentCampaignBehavior), "ConsiderStartOrEndTournament")]
public static class QuarantineTournamentPatch
{
	[HarmonyPrefix]
	public static bool Prefix(Town town)
	{
		if (((town != null) ? ((SettlementComponent)town).Settlement : null) == null)
		{
			return true;
		}
		ModSettings instance = GlobalSettings<ModSettings>.Instance;
		if (instance == null || !instance.EnableDiseaseSystem)
		{
			return true;
		}
		if (DiseaseManager.Instance == null)
		{
			return true;
		}
		if (DiseaseManager.Instance.IsSettlementUnderQuarantine(((SettlementComponent)town).Settlement))
		{
			Campaign current = Campaign.Current;
			object obj;
			if (current == null)
			{
				obj = null;
			}
			else
			{
				ITournamentManager tournamentManager = current.TournamentManager;
				obj = ((tournamentManager != null) ? tournamentManager.GetTournamentGame(town) : null);
			}
			TournamentGame val = (TournamentGame)obj;
			if (val != null)
			{
				Campaign.Current.TournamentManager.ResolveTournament(val, town);
			}
			return false;
		}
		return true;
	}
}
