using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement.Diplomacy;

public class KingdomWarItemVM : KingdomDiplomacyItemVM
{
	private readonly Action<KingdomWarItemVM> _onSelect;

	private readonly StanceLink _war;

	private ExplainedNumber _warProgressOfFaction1;

	private ExplainedNumber _warProgressOfFaction2;

	private int _numberOfTownsCapturedByFaction1;

	private int _numberOfTownsCapturedByFaction2;

	private int _numberOfCastlesCapturedByFaction1;

	private int _numberOfCastlesCapturedByFaction2;

	private int _numberOfRaidsMadeByFaction1;

	private int _numberOfRaidsMadeByFaction2;

	private string _warName;

	private string _numberOfDaysSinceWarBegan;

	private int _score;

	private bool _isBehaviorSelectionEnabled;

	private int _casualtiesOfFaction1;

	private int _casualtiesOfFaction2;

	private MBBindingList<KingdomWarLogItemVM> _warLog;

	[DataSourceProperty]
	public string WarName
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
	public string NumberOfDaysSinceWarBegan
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
	public bool IsBehaviorSelectionEnabled
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
	public int Score
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
	public int CasualtiesOfFaction1
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
	public int CasualtiesOfFaction2
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
	public MBBindingList<KingdomWarLogItemVM> WarLog
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
	public KingdomWarItemVM(StanceLink war, Action<KingdomWarItemVM> onSelect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSelect()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void UpdateDiplomacyProperties()
	{
		throw null;
	}
}
