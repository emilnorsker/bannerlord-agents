using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.HUD.DamageFeed;

public class MissionAgentDamageFeedItemVM : ViewModel
{
	private readonly Action<MissionAgentDamageFeedItemVM> _onRemove;

	private string _feedText;

	[DataSourceProperty]
	public string FeedText
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
	public MissionAgentDamageFeedItemVM(string feedText, Action<MissionAgentDamageFeedItemVM> onRemove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteRemove()
	{
		throw null;
	}
}
