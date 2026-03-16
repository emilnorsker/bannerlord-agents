using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace TaleWorlds.CampaignSystem.Encyclopedia;

public abstract class EncyclopediaPage
{
	private readonly Type[] _identifierTypes;

	private readonly Dictionary<Type, string> _identifiers;

	private IEnumerable<EncyclopediaFilterGroup> _filters;

	private IEnumerable<EncyclopediaListItem> _items;

	private IEnumerable<EncyclopediaSortController> _sortControllers;

	public int HomePageOrderIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public EncyclopediaPage Parent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	protected abstract IEnumerable<EncyclopediaListItem> InitializeListItems();

	protected abstract IEnumerable<EncyclopediaFilterGroup> InitializeFilterItems();

	protected abstract IEnumerable<EncyclopediaSortController> InitializeSortControllers();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EncyclopediaPage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsRelevant()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasIdentifierType(Type identifierType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal bool HasIdentifier(string identifier)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetIdentifier(Type identifierType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string[] GetIdentifierNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFiltered(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual string GetViewFullyQualifiedName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual string GetStringID()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual TextObject GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual MBObjectBase GetObject(string typeName, string stringID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual bool IsValidEncyclopediaItem(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual TextObject GetDescriptionText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<EncyclopediaListItem> GetListItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<EncyclopediaFilterGroup> GetFilterItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<EncyclopediaSortController> GetSortControllers()
	{
		throw null;
	}
}
