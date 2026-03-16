using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.HUD.KillFeed.General;

public class SPGeneralKillNotificationVM : ViewModel
{
	private MBBindingList<SPGeneralKillNotificationItemVM> _notificationList;

	[DataSourceProperty]
	public MBBindingList<SPGeneralKillNotificationItemVM> NotificationList
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
	public SPGeneralKillNotificationVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, bool isHeadshot, bool isSuicide, bool isDrowning)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveItem(SPGeneralKillNotificationItemVM item)
	{
		throw null;
	}
}
