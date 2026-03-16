using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.GauntletUI;

public class SoundProperties
{
	[CompilerGenerated]
	private sealed class _003Cget_RegisteredStateSounds_003Ed__3 : IEnumerable<KeyValuePair<string, AudioProperty>>, IEnumerable, IEnumerator<KeyValuePair<string, AudioProperty>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private KeyValuePair<string, AudioProperty> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public SoundProperties _003C_003E4__this;

		private Dictionary<string, AudioProperty>.Enumerator _003C_003E7__wrap1;

		KeyValuePair<string, AudioProperty> IEnumerator<KeyValuePair<string, AudioProperty>>.Current
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
		public _003Cget_RegisteredStateSounds_003Ed__3(int _003C_003E1__state)
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
		IEnumerator<KeyValuePair<string, AudioProperty>> IEnumerable<KeyValuePair<string, AudioProperty>>.GetEnumerator()
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
	private sealed class _003Cget_RegisteredEventSounds_003Ed__5 : IEnumerable<KeyValuePair<string, AudioProperty>>, IEnumerable, IEnumerator<KeyValuePair<string, AudioProperty>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private KeyValuePair<string, AudioProperty> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public SoundProperties _003C_003E4__this;

		private Dictionary<string, AudioProperty>.Enumerator _003C_003E7__wrap1;

		KeyValuePair<string, AudioProperty> IEnumerator<KeyValuePair<string, AudioProperty>>.Current
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
		public _003Cget_RegisteredEventSounds_003Ed__5(int _003C_003E1__state)
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
		IEnumerator<KeyValuePair<string, AudioProperty>> IEnumerable<KeyValuePair<string, AudioProperty>>.GetEnumerator()
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

	private Dictionary<string, AudioProperty> _stateSounds;

	private Dictionary<string, AudioProperty> _eventSounds;

	public IEnumerable<KeyValuePair<string, AudioProperty>> RegisteredStateSounds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_RegisteredStateSounds_003Ed__3))]
		get
		{
			throw null;
		}
	}

	public IEnumerable<KeyValuePair<string, AudioProperty>> RegisteredEventSounds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[IteratorStateMachine(typeof(_003Cget_RegisteredEventSounds_003Ed__5))]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SoundProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddStateSound(string state, AudioProperty audioProperty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddEventSound(string state, AudioProperty audioProperty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FillFrom(SoundProperties soundProperties)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AudioProperty GetEventAudioProperty(string eventName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AudioProperty GetStateAudioProperty(string stateName)
	{
		throw null;
	}
}
