using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapBar;

public class MapInfoVM : ViewModel
{
	private IViewDataTracker _viewDataTracker;

	private MapInfoItemVM _goldInfo;

	private MapInfoItemVM _influenceInfo;

	private MapInfoItemVM _hitPointsInfo;

	private MapInfoItemVM _troopsInfo;

	private MapInfoItemVM _foodInfo;

	private MapInfoItemVM _moraleInfo;

	private MapInfoItemVM _speedInfo;

	private MapInfoItemVM _viewDistanceInfo;

	private MapInfoItemVM _troopWageInfo;

	private bool _isMainHeroSick;

	private bool _isMainPartyAtSea;

	private bool _isInfoBarExtended;

	private bool _isInfoBarEnabled;

	private HintViewModel _extendHint;

	private MBBindingList<MapInfoItemVM> _primaryInfoItems;

	private MBBindingList<MapInfoItemVM> _secondaryInfoItems;

	[DataSourceProperty]
	public bool IsInfoBarExtended
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
	public bool IsInfoBarEnabled
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
	public HintViewModel ExtendHint
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
	public MBBindingList<MapInfoItemVM> PrimaryInfoItems
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
	public MBBindingList<MapInfoItemVM> SecondaryInfoItems
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
	public MapInfoVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void CreateItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Tick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Refresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void UpdatePlayerInfo(bool updateForced)
	{
		throw null;
	}
}
