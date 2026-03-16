using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace TaleWorlds.CampaignSystem.Encyclopedia.Pages;

[EncyclopediaModel(new Type[] { typeof(Hero) })]
public class DefaultEncyclopediaHeroPage : EncyclopediaPage
{
	private class EncyclopediaListHeroAgeComparer : EncyclopediaListHeroComparer
	{
		private static Func<Hero, Hero, int> _comparison;

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
		public EncyclopediaListHeroAgeComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListHeroAgeComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListHeroRelationComparer : EncyclopediaListHeroComparer
	{
		private static Func<Hero, Hero, int> _comparison;

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
		public EncyclopediaListHeroRelationComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListHeroRelationComparer()
		{
			throw null;
		}
	}

	public abstract class EncyclopediaListHeroComparer : EncyclopediaListItemComparerBase
	{
		protected delegate bool HeroVisibilityComparerDelegate(Hero h1, Hero h2, out int comparisonResult);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected bool CompareVisibility(Hero h1, Hero h2, out int comparisonResult)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected int CompareHeroes(EncyclopediaListItem x, EncyclopediaListItem y, Func<Hero, Hero, int> comparison)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected EncyclopediaListHeroComparer()
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

		public DefaultEncyclopediaHeroPage _003C_003E4__this;

		private int _003CcomingOfAge_003E5__2;

		private TextObject _003CheroName_003E5__3;

		private List<Hero>.Enumerator _003C_003E7__wrap3;

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
		private void _003C_003Em__Finally2()
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
	public DefaultEncyclopediaHeroPage()
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
	public override string GetStringID()
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
	public override MBObjectBase GetObject(string typeName, string stringID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsValidEncyclopediaItem(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CanPlayerSeeValuesOf(Hero hero)
	{
		throw null;
	}
}
