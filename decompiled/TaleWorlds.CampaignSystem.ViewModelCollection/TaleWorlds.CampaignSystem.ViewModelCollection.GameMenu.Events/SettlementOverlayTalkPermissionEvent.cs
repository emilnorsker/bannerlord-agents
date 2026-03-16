using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Library.EventSystem;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.GameMenu.Events;

public class SettlementOverlayTalkPermissionEvent : EventBase
{
	public Hero HeroToTalkTo;

	public Action<bool, TextObject> IsTalkAvailable
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
	public SettlementOverlayTalkPermissionEvent(Hero heroToTalkTo, Action<bool, TextObject> isTalkAvailable)
	{
		throw null;
	}
}
