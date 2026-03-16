using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.ClanFinance;

public class ClanFinanceCommonAreaItemVM : ClanFinanceIncomeItemBaseVM
{
	private Alley _alley;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanFinanceCommonAreaItemVM(Alley alley, Action<ClanFinanceIncomeItemBaseVM> onSelection, Action onRefresh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void PopulateActionList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void PopulateStatsList()
	{
		throw null;
	}
}
