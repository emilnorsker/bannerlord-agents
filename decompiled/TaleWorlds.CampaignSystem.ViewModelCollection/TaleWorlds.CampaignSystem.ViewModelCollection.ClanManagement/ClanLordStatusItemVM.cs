using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;

public class ClanLordStatusItemVM : ViewModel
{
	public enum LordStatus
	{
		Dead,
		Married,
		Pregnant,
		InBattle,
		InSiege,
		Child,
		Prisoner,
		Sick
	}

	private int _type;

	private HintViewModel _hint;

	[DataSourceProperty]
	public int Type
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
	public HintViewModel Hint
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
	public ClanLordStatusItemVM(LordStatus status, TextObject hintText)
	{
		throw null;
	}
}
