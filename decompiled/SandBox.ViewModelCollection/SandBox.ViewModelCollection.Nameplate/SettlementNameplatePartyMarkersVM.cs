using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.Nameplate;

public class SettlementNameplatePartyMarkersVM : ViewModel
{
	public class PartyMarkerItemComparer : IComparer<SettlementNameplatePartyMarkerItemVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(SettlementNameplatePartyMarkerItemVM x, SettlementNameplatePartyMarkerItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public PartyMarkerItemComparer()
		{
			throw null;
		}
	}

	private Settlement _settlement;

	private bool _eventsRegistered;

	private PartyMarkerItemComparer _itemComparer;

	private MBBindingList<SettlementNameplatePartyMarkerItemVM> _partiesInSettlement;

	public MBBindingList<SettlementNameplatePartyMarkerItemVM> PartiesInSettlement
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
	public SettlementNameplatePartyMarkersVM(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulatePartyList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMobilePartyValid(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementLeft(MobileParty party, Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSettlementEntered(MobileParty partyEnteredSettlement, Settlement settlement, Hero leader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapEventEnded(MapEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UnloadEvents()
	{
		throw null;
	}
}
