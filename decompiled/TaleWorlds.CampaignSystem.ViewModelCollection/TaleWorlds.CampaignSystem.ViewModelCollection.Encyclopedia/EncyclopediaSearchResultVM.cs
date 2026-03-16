using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;

public class EncyclopediaSearchResultVM : ViewModel
{
	private string _searchedText;

	public readonly int MatchStartIndex;

	public string LinkId;

	public string PageType;

	public string _nameText;

	public string OrgNameText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string NameText
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
	public EncyclopediaSearchResultVM(EncyclopediaListItem source, string searchedText, int matchStartIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateSearchedText(string searchedText)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Execute()
	{
		throw null;
	}
}
