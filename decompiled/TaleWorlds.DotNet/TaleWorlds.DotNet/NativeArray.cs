using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

[EngineClass("ftdnNative_array")]
public sealed class NativeArray : NativeObject
{
	[CompilerGenerated]
	private sealed class _003CGetEnumerator_003Ed__11<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable where T : struct
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public NativeArray _003C_003E4__this;

		private int _003Clength_003E5__2;

		private IntPtr _003CdataPointer_003E5__3;

		private int _003CelementSize_003E5__4;

		private int _003Ci_003E5__5;

		T IEnumerator<T>.Current
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
		public _003CGetEnumerator_003Ed__11(int _003C_003E1__state)
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
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
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

	private static readonly IntPtr _temporaryData;

	private const int TemporaryDataSize = 16384;

	private static readonly int DataPointerOffset;

	public int DataSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NativeArray()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal NativeArray(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NativeArray Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private UIntPtr GetDataPointer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetLength<T>() where T : struct
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T GetElementAt<T>(int index) where T : struct
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__11<>))]
	public IEnumerable<T> GetEnumerator<T>() where T : struct
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T[] ToArray<T>() where T : struct
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddElement(int value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddElement(float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddElement<T>(T value) where T : struct
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}
}
