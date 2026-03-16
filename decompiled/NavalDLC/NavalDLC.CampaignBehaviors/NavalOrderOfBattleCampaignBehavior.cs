using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.SaveSystem;

namespace NavalDLC.CampaignBehaviors;

public class NavalOrderOfBattleCampaignBehavior : CampaignBehaviorBase
{
	public class NavalOrderOfBattleFormationData
	{
		[SaveableField(1)]
		public readonly Hero Captain;

		[SaveableField(2)]
		public readonly Ship Ship;

		[SaveableField(3)]
		public readonly DeploymentFormationClass FormationClass;

		[SaveableField(4)]
		public readonly Dictionary<FormationFilterType, bool> Filters;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public NavalOrderOfBattleFormationData(Hero captain, Ship ship, DeploymentFormationClass formationClass, Dictionary<FormationFilterType, bool> filters)
		{
			throw null;
		}
	}

	private List<NavalOrderOfBattleFormationData> _navalBattleFormationInfos;

	private List<NavalOrderOfBattleFormationData> _navalBattleArmyFormationInfos;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalOrderOfBattleCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalOrderOfBattleFormationData GetFormationDataAtIndex(int formationIndex, bool isInArmy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetFormationInfos(List<NavalOrderOfBattleFormationData> formationInfos, bool isInArmy)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipDestroyed(PartyBase owner, Ship ship, ShipDestroyDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHeroUnregistered(Hero hero)
	{
		throw null;
	}
}
