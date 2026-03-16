using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.ViewModelCollection.Map.Tracker;

namespace SandBox.ViewModelCollection.Map.Tracker;

public class MapTrackerProvider
{
	private class TrackerContainer
	{
		private readonly Dictionary<ITrackableCampaignObject, MapTrackerItemVM> _trackers;

		public OnTrackerAddedOrRemovedDelegate OnTrackerAddedOrRemoved;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TrackerContainer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MapTrackerItemVM[] GetTrackers()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool HasTrackerFor(ITrackableCampaignObject trackable)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MapTrackerItemVM GetTrackerFor(ITrackableCampaignObject trackable)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddTracker(MapTrackerItemVM tracker)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RemoveTracker(MapTrackerItemVM tracker)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ClearTrackers()
		{
			throw null;
		}
	}

	public delegate void OnTrackerAddedOrRemovedDelegate(MapTrackerItemVM tracker, bool added);

	private TrackerContainer _trackerContainer;

	public event OnTrackerAddedOrRemovedDelegate OnTrackerAddedOrRemoved
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapTrackerProvider()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapTrackerItemVM[] GetTrackers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetTrackers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanAddMobileParty(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanAddArmy(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveIfExists(ITrackableCampaignObject trackable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddIfEligible(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddIfEligible(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddIfEligible(MapMarker mapMarker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyDestroyed(MobileParty mobileParty, PartyBase arg2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyQuestStatusChanged(MobileParty mobileParty, bool isUsedByQuest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyDisbanded(MobileParty disbandedParty, Settlement relatedSettlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyCreated(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnArmyDispersed(Army army, ArmyDispersionReason arg2, bool arg3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnArmyCreated(Army army)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomActionDetail detail, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCompanionClanCreated(Clan clan, bool isCompanion)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapMarkerRemoved(MapMarker marker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMapMarkerCreated(MapMarker marker)
	{
		throw null;
	}
}
