using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.Actions;

public static class ChangeVillageStateAction
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(Village village, Village.VillageStates newState, MobileParty raiderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyBySettingToNormal(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyBySettingToBeingRaided(Settlement settlement, MobileParty raider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyBySettingToBeingForcedForSupplies(Settlement settlement, MobileParty raider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyBySettingToBeingForcedForVolunteers(Settlement settlement, MobileParty raider)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyBySettingToLooted(Settlement settlement, MobileParty raider)
	{
		throw null;
	}
}
