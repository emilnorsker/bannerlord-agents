using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Encyclopedia.Pages;

[EncyclopediaModel(new Type[] { typeof(Settlement) })]
public class DefaultEncyclopediaSettlementPage : EncyclopediaPage
{
	private class EncyclopediaListSettlementGarrisonComparer : EncyclopediaListSettlementComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int GarrisonComparison(Town t1, Town t2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override bool CompareVisibility(Settlement s1, Settlement s2, out int comparisonResult)
		{
			throw null;
		}

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
		public EncyclopediaListSettlementGarrisonComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListSettlementFoodComparer : EncyclopediaListSettlementComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(EncyclopediaListItem x, EncyclopediaListItem y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int FoodComparison(Town t1, Town t2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string GetComparedValueText(EncyclopediaListItem item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EncyclopediaListSettlementFoodComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListSettlementSecurityComparer : EncyclopediaListSettlementComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(EncyclopediaListItem x, EncyclopediaListItem y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int SecurityComparison(Town t1, Town t2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string GetComparedValueText(EncyclopediaListItem item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EncyclopediaListSettlementSecurityComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListSettlementLoyaltyComparer : EncyclopediaListSettlementComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(EncyclopediaListItem x, EncyclopediaListItem y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int LoyaltyComparison(Town t1, Town t2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string GetComparedValueText(EncyclopediaListItem item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EncyclopediaListSettlementLoyaltyComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListSettlementMilitiaComparer : EncyclopediaListSettlementComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(EncyclopediaListItem x, EncyclopediaListItem y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int MilitiaComparison(Settlement t1, Settlement t2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string GetComparedValueText(EncyclopediaListItem item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EncyclopediaListSettlementMilitiaComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListSettlementProsperityComparer : EncyclopediaListSettlementComparer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(EncyclopediaListItem x, EncyclopediaListItem y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int ProsperityComparison(Town t1, Town t2)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string GetComparedValueText(EncyclopediaListItem item)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EncyclopediaListSettlementProsperityComparer()
		{
			throw null;
		}
	}

	public abstract class EncyclopediaListSettlementComparer : EncyclopediaListItemComparerBase
	{
		protected delegate bool SettlementVisibilityComparerDelegate(Settlement s1, Settlement s2, out int comparisonResult);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected virtual bool CompareVisibility(Settlement s1, Settlement s2, out int comparisonResult)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected int CompareSettlements(EncyclopediaListItem x, EncyclopediaListItem y, SettlementVisibilityComparerDelegate visibilityComparison, Func<Settlement, Settlement, int> comparison)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected int CompareFiefs(EncyclopediaListItem x, EncyclopediaListItem y, SettlementVisibilityComparerDelegate visibilityComparison, Func<Town, Town, int> comparison)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected EncyclopediaListSettlementComparer()
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

		public DefaultEncyclopediaSettlementPage _003C_003E4__this;

		private List<Settlement>.Enumerator _003C_003E7__wrap1;

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
	public DefaultEncyclopediaSettlementPage()
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CanPlayerSeeValuesOf(Settlement settlement)
	{
		throw null;
	}
}
