using System.Runtime.CompilerServices;
using NavalDLC.Map;
using NavalDLC.Storyline;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace NavalDLC;

public class NavalDLCEvents : CampaignEventReceiver
{
	private readonly MbEvent<PartyBase, NavalStorylinePartyData> _isPartyQuestPartyEvent;

	private readonly MbEvent<bool> _onNavalStorylineActivityChangedEvent;

	private readonly MbEvent _onSisterRansomedEvent;

	private readonly MbEvent _onSisterRansomRequestedEvent;

	private readonly MbEvent _onGangradirSavedEvent;

	private readonly MbEvent<NavalStorylineData.StorylineCancelDetail> _onNavalStorylineCanceledEvent;

	private readonly MbEvent _onNavalStorylineTutorialSkippedEvent;

	private readonly MbEvent<Storm> _onStormCreatedEvent;

	public static NavalDLCEvents Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<PartyBase, NavalStorylinePartyData> IsNavalQuestPartyEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<bool> OnNavalStorylineActivityChangedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnSisterRansomedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnSisterRansomRequestedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnGangradirSavedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<NavalStorylineData.StorylineCancelDetail> OnNavalStorylineCanceledEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnNavalStorylineTutorialSkippedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<Storm> OnStormCreatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RemoveListeners(object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void IsNavalQuestParty(PartyBase party, NavalStorylinePartyData result)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnNavalStorylineActivityChanged(bool activity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSisterRansomed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnSisterRansomRequested()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnGangradirSaved()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnNavalStorylineCanceled(NavalStorylineData.StorylineCancelDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnNavalStorylineTutorialSkipped()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnStormCreated(Storm storm)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCEvents()
	{
		throw null;
	}
}
