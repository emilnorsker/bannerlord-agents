using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class MapTracksCampaignBehavior : CampaignBehaviorBase, IMapTracksCampaignBehavior, ICampaignBehavior
{
	private class TrackPool
	{
		private Stack<Track> _stack;

		private int MaxSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
		}

		public int Size
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public TrackPool(int size)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Track RequestTrack(MobileParty party, CampaignVec2 trackPosition, Vec2 trackDirection)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Track RequestMapArrow(TextObject pointerName, CampaignVec2 trackPosition, Vec2 trackDirection, float life)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ReleaseTrack(Track track)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			throw null;
		}
	}

	private const float PartyTrackPositionDelta = 5f;

	private List<Track> _allTracks;

	private MBList<Track> _detectedTracksCache;

	private Dictionary<MobileParty, CampaignVec2> _trackDataDictionary;

	private MBCampaignEvent _quarterHourlyTick;

	private LocatorGrid<Track> _trackLocator;

	private TrackPool _trackPool;

	public MBReadOnlyList<Track> DetectedTracks
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MapTracksCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyDestroyed(MobileParty mobileParty, PartyBase destroyerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnNewGameCreated(CampaignGameStarter gameStarted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHourlyTickParty(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnHourlyTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GameLoadFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEventHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QuarterHourlyTick(MBCampaignEvent campaignEvent, object[] delegateParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveExpiredTracks()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TrackDetected(Track track)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsTrackDropped(MobileParty mobileParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddTrack(MobileParty party, CampaignVec2 trackPosition, Vec2 trackDirection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddMapArrow(TextObject pointerName, CampaignVec2 trackPosition, Vec2 trackDirection, float life)
	{
		throw null;
	}
}
