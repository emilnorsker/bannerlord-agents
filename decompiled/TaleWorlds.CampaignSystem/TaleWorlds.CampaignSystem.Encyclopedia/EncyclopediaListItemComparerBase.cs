using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Encyclopedia;

public abstract class EncyclopediaListItemComparerBase : IComparer<EncyclopediaListItem>
{
	protected readonly TextObject _emptyValue;

	protected readonly TextObject _missingValue;

	public bool IsAscending
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
	public void SetSortOrder(bool isAscending)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SwitchSortOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetDefaultSortOrder()
	{
		throw null;
	}

	public abstract int Compare(EncyclopediaListItem x, EncyclopediaListItem y);

	public abstract string GetComparedValueText(EncyclopediaListItem item);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected int ResolveEquality(EncyclopediaListItem x, EncyclopediaListItem y)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected EncyclopediaListItemComparerBase()
	{
		throw null;
	}
}
