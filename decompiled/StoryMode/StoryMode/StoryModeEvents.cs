using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;

namespace StoryMode;

public class StoryModeEvents : CampaignEventReceiver
{
	private readonly MbEvent<MainStoryLineSide> _onMainStoryLineSideChosenEvent;

	private readonly MbEvent _onStoryModeTutorialEndedEvent;

	private readonly MbEvent _onStealthTutorialActivatedEvent;

	private readonly MbEvent _onBannerPieceCollectedEvent;

	private readonly MbEvent _onConspiracyActivatedEvent;

	private readonly MbEvent _onTravelToVillageTutorialQuestStartedEvent;

	public static StoryModeEvents Instance
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent<MainStoryLineSide> OnMainStoryLineSideChosenEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnStoryModeTutorialEndedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnStealthTutorialActivatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnBannerPieceCollectedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnConspiracyActivatedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public static IMbEvent OnTravelToVillageTutorialQuestStartedEvent
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
	public void OnMainStoryLineSideChosen(MainStoryLineSide side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnStoryModeTutorialEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnStealthTutorialActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnBannerPieceCollected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnConspiracyActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTravelToVillageTutorialQuestStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeEvents()
	{
		throw null;
	}
}
