using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace SandBox.ViewModelCollection.Nameplate.NameplateNotifications.SettlementNotificationTypes;

public class ItemSoldNotificationItemVM : SettlementNotificationItemBaseVM
{
	private int _number;

	private PartyBase _heroParty;

	public ItemRosterElement Item
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public PartyBase ReceiverParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public PartyBase PayerParty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemSoldNotificationItemVM(Action<SettlementNotificationItemBaseVM> onRemove, PartyBase receiverParty, PartyBase payerParty, ItemRosterElement item, int number, int createdTick)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNewTransaction(int amount)
	{
		throw null;
	}
}
