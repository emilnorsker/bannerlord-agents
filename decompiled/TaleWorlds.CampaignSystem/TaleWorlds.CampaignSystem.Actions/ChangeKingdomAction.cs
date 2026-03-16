using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Actions;

public static class ChangeKingdomAction
{
	public enum ChangeKingdomActionDetail
	{
		JoinAsMercenary,
		JoinKingdom,
		JoinKingdomByDefection,
		LeaveKingdom,
		LeaveWithRebellion,
		LeaveAsMercenary,
		LeaveByClanDestruction,
		CreateKingdom,
		LeaveByKingdomDestruction
	}

	public const float PotentialSettlementsPerNobleEffect = 0.2f;

	public const float NewGainedFiefsValueForKingdomConstant = 0.1f;

	public const float LordsUnitStrengthValue = 20f;

	public const float MercenaryUnitStrengthValue = 5f;

	public const float MinimumNeededGoldForRecruitingMercenaries = 20000f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Clan clan, Kingdom newKingdom, ChangeKingdomActionDetail detail, CampaignTime shouldStayInKingdomUntil, int awardMultiplier = 0, bool byRebellion = false, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByJoinToKingdom(Clan clan, Kingdom newKingdom, CampaignTime shouldStayInKingdomUntil = default(CampaignTime), bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByJoinToKingdomByDefection(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, CampaignTime shouldStayInKingdomUntil = default(CampaignTime), bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByCreateKingdom(Clan clan, Kingdom newKingdom, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByLeaveByKingdomDestruction(Clan clan, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByLeaveKingdom(Clan clan, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByLeaveWithRebellionAgainstKingdom(Clan clan, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByJoinFactionAsMercenary(Clan clan, Kingdom newKingdom, CampaignTime shouldStayInKingdomUntil = default(CampaignTime), int awardMultiplier = 50, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByLeaveKingdomAsMercenary(Clan mercenaryClan, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyByLeaveKingdomByClanDestruction(Clan clan, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CheckIfPartyIconIsDirty(Clan clan, Kingdom oldKingdom)
	{
		throw null;
	}
}
