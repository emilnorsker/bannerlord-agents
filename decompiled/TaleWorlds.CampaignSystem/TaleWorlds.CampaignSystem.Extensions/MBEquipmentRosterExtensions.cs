using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.Extensions;

public static class MBEquipmentRosterExtensions
{
	public static MBReadOnlyList<MBEquipmentRoster> All
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Equipment> GetCivilianEquipments(this MBEquipmentRoster instance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Equipment> GetStealthEquipments(this MBEquipmentRoster instance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IEnumerable<Equipment> GetBattleEquipments(this MBEquipmentRoster instance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Equipment GetRandomCivilianEquipment(this MBEquipmentRoster instance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Equipment GetRandomStealthEquipment(this MBEquipmentRoster instance)
	{
		throw null;
	}
}
