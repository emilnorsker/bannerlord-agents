using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class BattleCampaignBehavior : CampaignBehaviorBase
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnCollectLootItems(PartyBase winnerParty, ItemRoster gainedLoots)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OnHeroCombatHit(CharacterObject attacker, CharacterObject attacked, PartyBase party, WeaponComponentData attackerWeapon, bool isFatal, int xpGained)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsWeaponSuitableToGetBaptisedInBloodPerkBonus(WeaponComponentData attackerWeapon)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleCampaignBehavior()
	{
		throw null;
	}
}
