using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaleWorlds.Library;

public static class SRTHelper
{
	public static class SrtParser
	{
		[CompilerGenerated]
		private sealed class _003CGetSrtSubTitleParts_003Ed__2 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private TextReader reader;

			public TextReader _003C_003E3__reader;

			private MBStringBuilder _003Csb_003E5__2;

			string IEnumerator<string>.Current
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
			public _003CGetSrtSubTitleParts_003Ed__2(int _003C_003E1__state)
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
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
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

		private static readonly string[] _delimiters;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<SubtitleItem> ParseStream(Stream subtitleStream, Encoding encoding)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003CGetSrtSubTitleParts_003Ed__2))]
		private static IEnumerable<string> GetSrtSubTitleParts(TextReader reader)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool TryParseTimecodeLine(string line, out int startTc, out int endTc)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int ParseSrtTimecode(string s)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static SrtParser()
		{
			throw null;
		}
	}

	public static class StreamHelpers
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Stream CopyStream(Stream inputStream)
		{
			throw null;
		}
	}

	public class SubtitleItem
	{
		public int StartTime
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public int EndTime
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public List<string> Lines
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SubtitleItem()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			throw null;
		}
	}
}
