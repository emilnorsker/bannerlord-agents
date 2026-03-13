using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence;

public static class ArenaTrainingNotification
{
	public static event Action<Settlement, Hero, string> OnTrainingStarted;

	public static void Notify(Settlement settlement, Hero heroTrainer, string customText = null)
	{
		if (settlement != null)
		{
			ArenaTrainingNotification.OnTrainingStarted?.Invoke(settlement, heroTrainer, customText);
		}
	}
}
