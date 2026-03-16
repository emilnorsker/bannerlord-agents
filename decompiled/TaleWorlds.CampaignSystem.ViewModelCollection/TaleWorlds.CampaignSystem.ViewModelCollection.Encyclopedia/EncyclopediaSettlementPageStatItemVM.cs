using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;

public class EncyclopediaSettlementPageStatItemVM : ViewModel
{
	public enum DescriptionType
	{
		Wall,
		Shipyard,
		Garrison,
		Militia,
		Food,
		Prosperity,
		Loyalty,
		Security
	}

	private BasicTooltipViewModel _basicTooltipViewModel;

	private string _typeString;

	private string _statText;

	[DataSourceProperty]
	public BasicTooltipViewModel BasicTooltipViewModel
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
	public string TypeString
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
	public string StatText
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
	public EncyclopediaSettlementPageStatItemVM(BasicTooltipViewModel basicTooltipViewModel, DescriptionType type, string statText)
	{
		throw null;
	}
}
