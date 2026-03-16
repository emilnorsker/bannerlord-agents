using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.Encyclopedia;

public class EncyclopediaManager
{
	private Dictionary<Type, EncyclopediaPage> _pages;

	public const string HOME_ID = "Home";

	public const string LIST_PAGE_ID = "ListPage";

	public const string LAST_PAGE_ID = "LastPage";

	private Action<string, object> _executeLink;

	public IViewDataTracker ViewDataTracker
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
	public void CreateEncyclopediaPages()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<EncyclopediaPage> GetEncyclopediaPages()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaPage GetPageOf(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetIdentifier(Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GoToLink(string pageType, string stringID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GoToLink(string link)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetLinkCallback(Action<string, object> ExecuteLink)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaManager()
	{
		throw null;
	}
}
