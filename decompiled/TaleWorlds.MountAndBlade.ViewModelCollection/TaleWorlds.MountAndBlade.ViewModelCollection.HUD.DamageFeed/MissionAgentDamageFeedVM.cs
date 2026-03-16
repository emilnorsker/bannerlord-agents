using System.Runtime.CompilerServices;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.HUD.DamageFeed;

public class MissionAgentDamageFeedVM : ViewModel
{
	private readonly TextObject _takenDamageText;

	private MBBindingList<MissionAgentDamageFeedItemVM> _feedList;

	[DataSourceProperty]
	public MBBindingList<MissionAgentDamageFeedItemVM> FeedList
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
	public MissionAgentDamageFeedVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CombatLogManagerOnPrintCombatLog(CombatLogData logData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveItem(MissionAgentDamageFeedItemVM item)
	{
		throw null;
	}
}
