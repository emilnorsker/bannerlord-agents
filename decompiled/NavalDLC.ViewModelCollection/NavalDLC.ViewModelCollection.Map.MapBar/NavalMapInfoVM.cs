using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapBar;
using TaleWorlds.Core.ViewModelCollection.Information;

namespace NavalDLC.ViewModelCollection.Map.MapBar;

public class NavalMapInfoVM : MapInfoVM
{
	private MapInfoItemVM _shipHealthInfo;

	private string _invalidShipHealthText;

	private readonly ShipHealthPercentageComparer _shipHealthPercentageComparer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMapInfoVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CreateItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void UpdatePlayerInfo(bool updateForced)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TooltipProperty> GetShipTooltip()
	{
		throw null;
	}
}
