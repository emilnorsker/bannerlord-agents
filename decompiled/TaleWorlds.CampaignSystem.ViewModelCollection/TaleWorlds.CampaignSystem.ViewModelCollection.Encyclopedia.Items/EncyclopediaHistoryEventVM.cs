using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Items;

public class EncyclopediaHistoryEventVM : EncyclopediaLinkVM
{
	private readonly IEncyclopediaLog _log;

	private string _historyEventText;

	private string _historyEventTimeText;

	[DataSourceProperty]
	public string HistoryEventTimeText
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
	public string HistoryEventText
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
	public EncyclopediaHistoryEventVM(IEncyclopediaLog log)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteLink(string link)
	{
		throw null;
	}
}
