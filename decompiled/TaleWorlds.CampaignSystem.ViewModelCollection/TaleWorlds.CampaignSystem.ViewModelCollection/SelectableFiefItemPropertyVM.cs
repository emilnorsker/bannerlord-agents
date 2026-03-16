using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection;

public class SelectableFiefItemPropertyVM : SelectableItemPropertyVM
{
	private int _changeAmount;

	[DataSourceProperty]
	public int ChangeAmount
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
	public SelectableFiefItemPropertyVM(string name, string value, int changeAmount, PropertyType type, BasicTooltipViewModel hint = null, bool isWarning = false)
	{
		throw null;
	}
}
