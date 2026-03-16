using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Engine.Options;

public class NativeSelectionOptionData : NativeOptionData, ISelectionOptionData, IOptionData
{
	[CompilerGenerated]
	private sealed class _003CGetOptionNames_003Ed__6 : IEnumerable<SelectionData>, IEnumerable, IEnumerator<SelectionData>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private SelectionData _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private NativeOptions.NativeOptionsType type;

		public NativeOptions.NativeOptionsType _003C_003E3__type;

		private int _003Ci_003E5__2;

		private int _003Ci_003E5__3;

		private string _003CtypeName_003E5__4;

		SelectionData IEnumerator<SelectionData>.Current
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
		public _003CGetOptionNames_003Ed__6(int _003C_003E1__state)
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
		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DebuggerHidden]
		IEnumerator<SelectionData> IEnumerable<SelectionData>.GetEnumerator()
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

	private readonly int _selectableOptionsLimit;

	private readonly IEnumerable<SelectionData> _selectableOptionNames;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeSelectionOptionData(NativeOptions.NativeOptionsType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetSelectableOptionsLimit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerable<SelectionData> GetSelectableOptionNames()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int GetOptionsLimit(NativeOptions.NativeOptionsType optionType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetOptionNames_003Ed__6))]
	private static IEnumerable<SelectionData> GetOptionNames(NativeOptions.NativeOptionsType type)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetAspectRatioOfResolution(int width, int height)
	{
		throw null;
	}
}
