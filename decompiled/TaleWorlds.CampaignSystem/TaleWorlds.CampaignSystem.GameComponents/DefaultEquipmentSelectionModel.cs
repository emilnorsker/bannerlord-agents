using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultEquipmentSelectionModel : EquipmentSelectionModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBList<MBEquipmentRoster> GetEquipmentRostersForHeroComeOfAge(Hero hero, bool isCivilian)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBList<MBEquipmentRoster> GetEquipmentRostersForHeroReachesTeenAge(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBList<MBEquipmentRoster> GetEquipmentRostersForInitialChildrenGeneration(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBList<MBEquipmentRoster> GetEquipmentRostersForDeliveredOffspring(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override MBList<MBEquipmentRoster> GetEquipmentRostersForCompanion(Hero hero, bool isCivilian)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsRosterAppropriateForHeroAsTemplate(MBEquipmentRoster equipmentRoster, Hero hero, bool shouldMatchGender, EquipmentFlags customFlags = EquipmentFlags.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHeroCombatant(Hero hero)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEquipmentsToRoster(Hero hero, EquipmentFlags suitableFlags, ref MBList<MBEquipmentRoster> roster, bool shouldMatchGender)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultEquipmentSelectionModel()
	{
		throw null;
	}
}
