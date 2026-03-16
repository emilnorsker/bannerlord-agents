using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.Encyclopedia.Pages;

[EncyclopediaModel(new Type[] { typeof(Concept) })]
public class DefaultEncyclopediaConceptPage : EncyclopediaPage
{
	[CompilerGenerated]
	private sealed class _003CInitializeListItems_003Ed__1 : IEnumerable<EncyclopediaListItem>, IEnumerable, IEnumerator<EncyclopediaListItem>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private EncyclopediaListItem _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public DefaultEncyclopediaConceptPage _003C_003E4__this;

		private List<Concept>.Enumerator _003C_003E7__wrap1;

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
	public DefaultEncyclopediaConceptPage()
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
}
