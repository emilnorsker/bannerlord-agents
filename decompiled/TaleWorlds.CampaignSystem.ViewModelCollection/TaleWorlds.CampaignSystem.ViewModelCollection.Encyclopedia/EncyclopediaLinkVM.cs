using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;

public class EncyclopediaLinkVM : ViewModel
{
	private string _activeLink;

	[DataSourceProperty]
	public string ActiveLink
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
	public void ExecuteActiveLink()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaLinkVM()
	{
		throw null;
	}
}
