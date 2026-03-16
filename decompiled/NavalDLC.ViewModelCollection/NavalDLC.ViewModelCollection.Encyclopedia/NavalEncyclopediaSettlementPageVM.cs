using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;

namespace NavalDLC.ViewModelCollection.Encyclopedia;

[EncyclopediaViewModel(typeof(Settlement))]
public class NavalEncyclopediaSettlementPageVM : EncyclopediaSettlementPageVM
{
	private string _shipyardText;

	private BasicTooltipViewModel _shipyardHint;

	[DataSourceProperty]
	public string ShipyardText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public BasicTooltipViewModel ShipyardHint
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalEncyclopediaSettlementPageVM(EncyclopediaPageArgs args)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Refresh()
	{
		throw null;
	}
}
