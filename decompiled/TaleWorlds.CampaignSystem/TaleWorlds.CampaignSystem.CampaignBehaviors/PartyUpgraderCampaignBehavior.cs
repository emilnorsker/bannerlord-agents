using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class PartyUpgraderCampaignBehavior : CampaignBehaviorBase
{
	private readonly struct TroopUpgradeArgs
	{
		public readonly CharacterObject Target;

		public readonly CharacterObject UpgradeTarget;

		public readonly int PossibleUpgradeCount;

		public readonly int UpgradeGoldCost;

		public readonly int UpgradeXpCost;

		public readonly float UpgradeChance;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TroopUpgradeArgs(CharacterObject target, CharacterObject upgradeTarget, int possibleUpgradeCount, int upgradeGoldCost, int upgradeXpCost, float upgradeChance)
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MapEventEnded(MapEvent mapEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DailyTickParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TroopUpgradeArgs SelectPossibleUpgrade(List<TroopUpgradeArgs> possibleUpgrades)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TroopUpgradeArgs> GetPossibleUpgradeTargets(PartyBase party, TroopRosterElement element)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyEffects(PartyBase party, TroopUpgradeArgs upgradeArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpgradeTroop(PartyBase party, int rosterIndex, TroopUpgradeArgs upgradeArgs)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpgradeReadyTroops(PartyBase party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartyUpgraderCampaignBehavior()
	{
		throw null;
	}
}
