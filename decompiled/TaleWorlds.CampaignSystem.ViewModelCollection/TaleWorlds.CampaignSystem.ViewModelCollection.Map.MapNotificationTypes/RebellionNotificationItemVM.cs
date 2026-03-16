using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapNotificationTypes;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapNotificationTypes;

public class RebellionNotificationItemVM : MapNotificationItemBaseVM
{
	private Settlement _settlement;

	protected Action _onInspectAction;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RebellionNotificationItemVM(SettlementRebellionMapNotification data)
	{
		throw null;
	}
}
