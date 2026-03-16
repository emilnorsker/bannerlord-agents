using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library.EventSystem;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.KingdomManagement;

public class LeaveKingdomPermissionEvent : EventBase
{
	public Action<bool, TextObject> IsLeaveKingdomPossbile
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public LeaveKingdomPermissionEvent(Action<bool, TextObject> isLeaveKingdomPossbile)
	{
		throw null;
	}
}
