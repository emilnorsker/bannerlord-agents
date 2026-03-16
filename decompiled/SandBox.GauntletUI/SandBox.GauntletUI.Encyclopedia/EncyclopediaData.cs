using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.List;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.ScreenSystem;

namespace SandBox.GauntletUI.Encyclopedia;

public class EncyclopediaData
{
	private Dictionary<string, EncyclopediaPage> _pages;

	private string _previousPageID;

	private EncyclopediaHomeVM _homeDatasource;

	private GauntletMovieIdentifier _homeGauntletMovie;

	private Dictionary<EncyclopediaPage, EncyclopediaListVM> _lists;

	private EncyclopediaPageVM _activeDatasource;

	private GauntletLayer _activeGauntletLayer;

	private GauntletMovieIdentifier _activeGauntletMovie;

	private EncyclopediaNavigatorVM _navigatorDatasource;

	private GauntletMovieIdentifier _navigatorActiveGauntletMovie;

	private readonly ScreenBase _screen;

	private TutorialContexts _prevContext;

	private readonly GauntletMapEncyclopediaView _manager;

	private object _initialState;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaData(GauntletMapEncyclopediaView manager, ScreenBase screen, EncyclopediaHomeVM homeDatasource, EncyclopediaNavigatorVM navigatorDatasource)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTutorialContextChanged(TutorialContextChangedEvent obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void OnTick()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetEncyclopediaPage(string pageId, object obj)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal EncyclopediaPageVM ExecuteLink(string pageId, object obj, bool needsRefresh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private EncyclopediaPageVM GetEncyclopediaPageInstance(EncyclopediaPage page, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IsEncyclopediaPageType(EncyclopediaPage page, Type type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CloseEncyclopedia()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetPageFilters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTutorialPageContext(EncyclopediaPageVM _page)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetTutorialListPageContext(EncyclopediaPage _page)
	{
		throw null;
	}
}
