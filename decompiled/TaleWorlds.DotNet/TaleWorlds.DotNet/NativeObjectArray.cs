using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.DotNet;

[EngineClass("ftdnNative_object_array")]
public sealed class NativeObjectArray : NativeObject, IEnumerable<NativeObject>, IEnumerable
{
	[CompilerGenerated]
	private sealed class _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CTaleWorlds_002DDotNet_002DNativeObject_003E_002DGetEnumerator_003Ed__7 : IEnumerator<NativeObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private NativeObject _003C_003E2__current;

		public NativeObjectArray _003C_003E4__this;

		private int _003Ccount_003E5__2;

		private int _003Ci_003E5__3;

		NativeObject IEnumerator<NativeObject>.Current
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
		public _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CTaleWorlds_002DDotNet_002DNativeObject_003E_002DGetEnumerator_003Ed__7(int _003C_003E1__state)
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
	}

	[CompilerGenerated]
	private sealed class _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NativeObjectArray _003C_003E4__this;

		private int _003Ccount_003E5__2;

		private int _003Ci_003E5__3;

		object IEnumerator<object>.Current
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
		public _003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__8(int _003C_003E1__state)
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
	}

	public int Count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal NativeObjectArray(UIntPtr pointer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static NativeObjectArray Create()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NativeObject GetElementAt(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddElement(NativeObject nativeObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CTaleWorlds_002DDotNet_002DNativeObject_003E_002DGetEnumerator_003Ed__7))]
	IEnumerator<NativeObject> IEnumerable<NativeObject>.GetEnumerator()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CSystem_002DCollections_002DIEnumerable_002DGetEnumerator_003Ed__8))]
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw null;
	}
}
