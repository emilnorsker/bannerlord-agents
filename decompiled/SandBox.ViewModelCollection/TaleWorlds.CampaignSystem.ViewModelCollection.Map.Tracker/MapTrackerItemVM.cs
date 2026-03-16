using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ViewModelCollection.Quests;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Map.Tracker;

public abstract class MapTrackerItemVM<T> : MapTrackerItemVM where T : ITrackableCampaignObject
{
	public new T TrackedObject
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected MapTrackerItemVM(T trackableObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected sealed override void OnUpdateProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected sealed override void OnUpdatePosition(float screenX, float screenY, float screenW)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected sealed override void OnToggleTrack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected sealed override void OnGoToPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected sealed override void OnRefreshBinding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Track()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Untrack()
	{
		throw null;
	}
}
public abstract class MapTrackerItemVM : ViewModel
{
	public readonly ITrackableCampaignObject TrackedObject;

	protected float _latestX;

	protected float _latestY;

	protected float _latestW;

	protected IssueQuestFlags _previousQuestsBind;

	protected IssueQuestFlags _questsBind;

	protected bool _isVisibleOnMapBind;

	protected bool _isBehindBind;

	protected bool _canToggleTrackBind;

	protected string _nameBind;

	protected Vec2 _partyPositionBind;

	protected BannerImageIdentifierVM _factionVisualBind;

	public static Action<CampaignVec2> OnFastMoveCameraToPosition;

	private bool _isTracked;

	private bool _canToggleTrack;

	private bool _isEnabled;

	private bool _isBehind;

	private string _name;

	private string _trackerType;

	private Vec2 _partyPosition;

	private BannerImageIdentifierVM _factionVisual;

	private MBBindingList<QuestMarkerVM> _quests;

	[DataSourceProperty]
	public bool IsTracked
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

	[DataSourceProperty]
	public bool CanToggleTrack
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

	[DataSourceProperty]
	public bool IsEnabled
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

	[DataSourceProperty]
	public bool IsBehind
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

	[DataSourceProperty]
	public string Name
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

	[DataSourceProperty]
	public string TrackerType
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

	[DataSourceProperty]
	public Vec2 PartyPosition
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

	[DataSourceProperty]
	public BannerImageIdentifierVM FactionVisual
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

	[DataSourceProperty]
	public MBBindingList<QuestMarkerVM> Quests
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
	public MapTrackerItemVM(ITrackableCampaignObject trackedObject)
	{
		throw null;
	}

	protected abstract void OnShowTooltip();

	protected abstract void OnUpdateProperties();

	protected abstract void OnUpdatePosition(float screenX, float screenY, float screenW);

	protected abstract void OnToggleTrack();

	protected abstract void OnGoToPosition();

	protected abstract void OnRefreshBinding();

	protected abstract bool IsVisibleOnMap();

	protected abstract bool GetCanToggleTrack();

	protected abstract string GetTrackerType();

	protected abstract IssueQuestFlags GetRelatedQuests();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdatePosition(float screenX, float screenY, float screenW)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteToggleTrack()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteGoToPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteShowTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteHideTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshBinding()
	{
		throw null;
	}
}
