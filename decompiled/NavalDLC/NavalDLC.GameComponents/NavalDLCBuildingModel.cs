using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Buildings;

namespace NavalDLC.GameComponents;

public class NavalDLCBuildingModel : BuildingModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanAddBuildingTypeToTown(BuildingType buildingType, Town town)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCBuildingModel()
	{
		throw null;
	}
}
