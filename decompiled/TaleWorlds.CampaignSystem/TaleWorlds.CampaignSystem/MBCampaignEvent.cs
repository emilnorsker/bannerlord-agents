using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem;

public class MBCampaignEvent
{
	public delegate void CampaignEventDelegate(MBCampaignEvent campaignEvent, params object[] delegateParams);

	public string description;

	protected List<CampaignEventDelegate> handlers;

	[CachedData]
	protected CampaignTime NextTriggerTime;

	public CampaignTime TriggerPeriod
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

	public CampaignTime InitialWait
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

	public bool isEventDeleted
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBCampaignEvent(string eventName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MBCampaignEvent(CampaignTime triggerPeriod, CampaignTime initialWait)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddHandler(CampaignEventDelegate gameEventDelegate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RunHandlers(params object[] delegateParams)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Unregister(object instance)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CheckUpdate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeletePeriodicEvent()
	{
		throw null;
	}
}
