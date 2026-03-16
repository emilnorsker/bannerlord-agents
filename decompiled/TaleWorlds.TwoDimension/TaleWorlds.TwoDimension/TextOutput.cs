using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.TwoDimension;

internal class TextOutput
{
	[CompilerGenerated]
	private sealed class _003Cget_Tokens_003Ed__28 : IEnumerable<TextTokenOutput>, IEnumerable, IEnumerator<TextTokenOutput>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private TextTokenOutput _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public TextOutput _003C_003E4__this;

		private int _003Ci_003E5__2;

		private TextLineOutput _003CtokensWithLine_003E5__3;

		private int _003Cj_003E5__4;

		TextTokenOutput IEnumerator<TextTokenOutput>.Current
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
		public _003Cget_Tokens_003Ed__28(int _003C_003E1__state)
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
		IEnumerator<TextTokenOutput> IEnumerable<TextTokenOutput>.GetEnumerator()
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

	[CompilerGenerated]
	private sealed class _003Cget_TokensWithNewLines_003Ed__30 : IEnumerable<TextTokenOutput>, IEnumerable, IEnumerator<TextTokenOutput>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private TextTokenOutput _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public TextOutput _003C_003E4__this;

		private int _003Ci_003E5__2;

		private TextLineOutput _003CtokensWithLine_003E5__3;

		private int _003Cj_003E5__4;

		TextTokenOutput IEnumerator<TextTokenOutput>.Current
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
		public _003Cget_TokensWithNewLines_003Ed__30(int _003C_003E1__state)
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
		IEnumerator<TextTokenOutput> IEnumerable<TextTokenOutput>.GetEnumerator()
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

	private List<TextLineOutput> _tokensWithLines;

	private readonly float _lineHeight;

	public float TextHeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float TotalLineScale
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float LastLineWidth
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public float MaxLineHeight
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

	public float MaxLineWidth
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

	public float MaxLineScale
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

	public int LineCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IEnumerable<TextTokenOutput> Tokens
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_Tokens_003Ed__28))]
		get
		{
			throw null;
		}
	}

	public IEnumerable<TextTokenOutput> TokensWithNewLines
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_TokensWithNewLines_003Ed__30))]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextOutput(float lineHeight)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextLineOutput AddNewLine(bool currentLineEnded, float newLineBaseHeight = 0f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddToken(TextToken textToken, float tokenWidth, float scaleValue, string style = "Default", float tokenHeight = -1f)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<TextTokenOutput> RemoveTokensFromEnd(int numberOfTokensToRemove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public TextLineOutput GetLine(int i)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}
}
