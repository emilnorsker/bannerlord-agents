using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Encyclopedia.Pages;

[EncyclopediaModel(new Type[] { typeof(CharacterObject) })]
public class DefaultEncyclopediaUnitPage : EncyclopediaPage
{
	private class EncyclopediaListUnitTierComparer : EncyclopediaListUnitComparer
	{
		private static Func<CharacterObject, CharacterObject, int> _comparison;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(EncyclopediaListItem x, EncyclopediaListItem y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string GetComparedValueText(EncyclopediaListItem item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EncyclopediaListUnitTierComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListUnitTierComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListUnitLevelComparer : EncyclopediaListUnitComparer
	{
		private static Func<CharacterObject, CharacterObject, int> _comparison;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(EncyclopediaListItem x, EncyclopediaListItem y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string GetComparedValueText(EncyclopediaListItem item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EncyclopediaListUnitLevelComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListUnitLevelComparer()
		{
			throw null;
		}
	}

	public abstract class EncyclopediaListUnitComparer : EncyclopediaListItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int CompareUnits(EncyclopediaListItem x, EncyclopediaListItem y, Func<CharacterObject, CharacterObject, int> comparison)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected EncyclopediaListUnitComparer()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CInitializeListItems_003Ed__1 : IEnumerable<EncyclopediaListItem>, IEnumerable, IEnumerator<EncyclopediaListItem>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EncyclopediaListItem _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public DefaultEncyclopediaUnitPage _003C_003E4__this;

		private List<CharacterObject>.Enumerator _003C_003E7__wrap1;

		EncyclopediaListItem IEnumerator<EncyclopediaListItem>.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		object IEnumerator.Current
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[DebuggerHidden]
			get
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		public _003CInitializeListItems_003Ed__1(int _003C_003E1__state)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool MoveNext()
		{
			throw null;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _003C_003Em__Finally1()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<EncyclopediaListItem> IEnumerable<EncyclopediaListItem>.GetEnumerator()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultEncyclopediaUnitPage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CInitializeListItems_003Ed__1))]
	protected override IEnumerable<EncyclopediaListItem> InitializeListItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override IEnumerable<EncyclopediaFilterGroup> InitializeFilterItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual List<EncyclopediaFilterItem> GetTypeFilterItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual List<EncyclopediaFilterItem> GetOccupationFilterItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual List<EncyclopediaFilterItem> GetCultureFilterItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual List<EncyclopediaFilterItem> GetOutlawFilterItems()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override IEnumerable<EncyclopediaSortController> InitializeSortControllers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetViewFullyQualifiedName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetDescriptionText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetStringID()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsValidEncyclopediaItem(object o)
	{
		throw null;
	}
}
