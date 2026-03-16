using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace TaleWorlds.CampaignSystem.Encyclopedia.Pages;

[EncyclopediaModel(new Type[] { typeof(ShipHull) })]
public class DefaultEncyclopediaShipPage : EncyclopediaPage
{
	private class EncyclopediaListShipClassComparer : EncyclopediaListShipComparer
	{
		private static Func<ShipHull, ShipHull, int> _comparison;

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
		public EncyclopediaListShipClassComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListShipClassComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListShipSlotCountComparer : EncyclopediaListShipComparer
	{
		private static Func<ShipHull, ShipHull, int> _comparison;

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
		public EncyclopediaListShipSlotCountComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListShipSlotCountComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListShipHealthComparer : EncyclopediaListShipComparer
	{
		private static Func<ShipHull, ShipHull, int> _comparison;

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
		public EncyclopediaListShipHealthComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListShipHealthComparer()
		{
			throw null;
		}
	}

	public abstract class EncyclopediaListShipComparer : EncyclopediaListItemComparerBase
	{
		protected delegate bool ShipVisibilityComparerDelegate(ShipHull s1, ShipHull s2, out int comparisonResult);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected bool CompareVisibility(ShipHull s1, ShipHull s2, out int comparisonResult)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected int CompareShips(EncyclopediaListItem x, EncyclopediaListItem y, Func<ShipHull, ShipHull, int> comparison)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected EncyclopediaListShipComparer()
		{
			throw null;
		}
	}

	[CompilerGenerated]
	private sealed class _003CInitializeListItems_003Ed__2 : IEnumerable<EncyclopediaListItem>, IEnumerable, IEnumerator<EncyclopediaListItem>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EncyclopediaListItem _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public DefaultEncyclopediaShipPage _003C_003E4__this;

		private IEnumerator<ShipHull> _003C_003E7__wrap1;

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
		public _003CInitializeListItems_003Ed__2(int _003C_003E1__state)
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
	public DefaultEncyclopediaShipPage()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsRelevant()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CInitializeListItems_003Ed__2))]
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
	private bool HasSailOfType(MissionShipObject ship, SailType sailType)
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
	private static bool CanPlayerSeeValuesOf(ShipHull shipHull)
	{
		throw null;
	}
}
