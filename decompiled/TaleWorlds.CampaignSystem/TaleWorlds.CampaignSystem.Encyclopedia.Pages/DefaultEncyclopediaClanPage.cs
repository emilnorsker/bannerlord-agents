using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace TaleWorlds.CampaignSystem.Encyclopedia.Pages;

[EncyclopediaModel(new Type[] { typeof(Clan) })]
public class DefaultEncyclopediaClanPage : EncyclopediaPage
{
	private class EncyclopediaListClanWealthComparer : EncyclopediaListClanComparer
	{
		private static Func<Clan, Clan, int> _comparison;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string GetClanWealthStatusText(Clan _clan)
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
		public EncyclopediaListClanWealthComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListClanWealthComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListClanTierComparer : EncyclopediaListClanComparer
	{
		private static Func<Clan, Clan, int> _comparison;

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
		public EncyclopediaListClanTierComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListClanTierComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListClanStrengthComparer : EncyclopediaListClanComparer
	{
		private static Func<Clan, Clan, int> _comparison;

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
		public EncyclopediaListClanStrengthComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListClanStrengthComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListClanFiefComparer : EncyclopediaListClanComparer
	{
		private static Func<Clan, Clan, int> _comparison;

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
		public EncyclopediaListClanFiefComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListClanFiefComparer()
		{
			throw null;
		}
	}

	private class EncyclopediaListClanMemberComparer : EncyclopediaListClanComparer
	{
		private static Func<Clan, Clan, int> _comparison;

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
		public EncyclopediaListClanMemberComparer()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EncyclopediaListClanMemberComparer()
		{
			throw null;
		}
	}

	public abstract class EncyclopediaListClanComparer : EncyclopediaListItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int CompareClans(EncyclopediaListItem x, EncyclopediaListItem y, Func<Clan, Clan, int> comparison)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected EncyclopediaListClanComparer()
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

		public DefaultEncyclopediaClanPage _003C_003E4__this;

		private IEnumerator<Clan> _003C_003E7__wrap1;

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
	public DefaultEncyclopediaClanPage()
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
	public override MBObjectBase GetObject(string typeName, string stringID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsValidEncyclopediaItem(object o)
	{
		throw null;
	}
}
