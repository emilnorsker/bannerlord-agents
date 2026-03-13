using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public struct NPCMapApproachIntent
{
	public bool IsHostile;

	public CampaignTime DetectTime;

	public bool DialogShown;

	public float TimeoutDays;
}
