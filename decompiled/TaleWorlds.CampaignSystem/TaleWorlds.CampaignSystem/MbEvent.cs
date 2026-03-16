using System;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem;

public class MbEvent : IMbEvent
{
	internal class EventHandlerRec
	{
		public EventHandlerRec Next;

		internal Action Action
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

		internal object Owner
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventHandlerRec(object owner, Action action)
		{
			throw null;
		}
	}

	private EventHandlerRec _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, Action action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec list)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearListeners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearListenerOfList(ref EventHandlerRec list, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MbEvent()
	{
		throw null;
	}
}
public class MbEvent<T> : IMbEvent<T>, IMbEventBase
{
	internal class EventHandlerRec<TS>
	{
		public EventHandlerRec<TS> Next;

		internal Action<TS> Action
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

		internal object Owner
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventHandlerRec(object owner, Action<TS> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, Action<T> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(T t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T> list, T t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearListeners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearListenerOfList(ref EventHandlerRec<T> list, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MbEvent()
	{
		throw null;
	}
}
public class MbEvent<T1, T2> : IMbEvent<T1, T2>, IMbEventBase
{
	internal class EventHandlerRec<TS, TQ>
	{
		public EventHandlerRec<TS, TQ> Next;

		internal Action<TS, TQ> Action
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

		internal object Owner
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventHandlerRec(object owner, Action<TS, TQ> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T1, T2> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, Action<T1, T2> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(T1 t1, T2 t2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T1, T2> list, T1 t1, T2 t2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearListeners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearListenerOfList(ref EventHandlerRec<T1, T2> list, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MbEvent()
	{
		throw null;
	}
}
public class MbEvent<T1, T2, T3> : IMbEvent<T1, T2, T3>, IMbEventBase
{
	internal class EventHandlerRec<TS, TQ, TR>
	{
		public EventHandlerRec<TS, TQ, TR> Next;

		internal Action<TS, TQ, TR> Action
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

		internal object Owner
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventHandlerRec(object owner, Action<TS, TQ, TR> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T1, T2, T3> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, Action<T1, T2, T3> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(T1 t1, T2 t2, T3 t3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T1, T2, T3> list, T1 t1, T2 t2, T3 t3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearListeners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearListenerOfList(ref EventHandlerRec<T1, T2, T3> list, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MbEvent()
	{
		throw null;
	}
}
public class MbEvent<T1, T2, T3, T4> : IMbEvent<T1, T2, T3, T4>, IMbEventBase
{
	internal class EventHandlerRec<TA, TB, TC, TD>
	{
		public EventHandlerRec<TA, TB, TC, TD> Next;

		internal Action<TA, TB, TC, TD> Action
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

		internal object Owner
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventHandlerRec(object owner, Action<TA, TB, TC, TD> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T1, T2, T3, T4> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, Action<T1, T2, T3, T4> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(T1 t1, T2 t2, T3 t3, T4 t4)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T1, T2, T3, T4> list, T1 t1, T2 t2, T3 t3, T4 t4)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearListeners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearListenerOfList(ref EventHandlerRec<T1, T2, T3, T4> list, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MbEvent()
	{
		throw null;
	}
}
public class MbEvent<T1, T2, T3, T4, T5> : IMbEvent<T1, T2, T3, T4, T5>, IMbEventBase
{
	internal class EventHandlerRec<TA, TB, TC, TD, TE>
	{
		public EventHandlerRec<TA, TB, TC, TD, TE> Next;

		internal Action<TA, TB, TC, TD, TE> Action
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

		internal object Owner
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventHandlerRec(object owner, Action<TA, TB, TC, TD, TE> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T1, T2, T3, T4, T5> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, Action<T1, T2, T3, T4, T5> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T1, T2, T3, T4, T5> list, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearListeners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearListenerOfList(ref EventHandlerRec<T1, T2, T3, T4, T5> list, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MbEvent()
	{
		throw null;
	}
}
public class MbEvent<T1, T2, T3, T4, T5, T6> : IMbEvent<T1, T2, T3, T4, T5, T6>, IMbEventBase
{
	internal class EventHandlerRec<TA, TB, TC, TD, TE, TF>
	{
		public EventHandlerRec<TA, TB, TC, TD, TE, TF> Next;

		internal Action<TA, TB, TC, TD, TE, TF> Action
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

		internal object Owner
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventHandlerRec(object owner, Action<TA, TB, TC, TD, TE, TF> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T1, T2, T3, T4, T5, T6> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, Action<T1, T2, T3, T4, T5, T6> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T1, T2, T3, T4, T5, T6> list, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearListeners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearListenerOfList(ref EventHandlerRec<T1, T2, T3, T4, T5, T6> list, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MbEvent()
	{
		throw null;
	}
}
public class MbEvent<T1, T2, T3, T4, T5, T6, T7> : IMbEvent<T1, T2, T3, T4, T5, T6, T7>, IMbEventBase
{
	internal class EventHandlerRec<TA, TB, TC, TD, TE, TF, TG>
	{
		public EventHandlerRec<TA, TB, TC, TD, TE, TF, TG> Next;

		internal Action<TA, TB, TC, TD, TE, TF, TG> Action
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

		internal object Owner
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

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EventHandlerRec(object owner, Action<TA, TB, TC, TD, TE, TF, TG> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T1, T2, T3, T4, T5, T6, T7> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, Action<T1, T2, T3, T4, T5, T6, T7> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T1, T2, T3, T4, T5, T6, T7> list, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearListeners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearListenerOfList(ref EventHandlerRec<T1, T2, T3, T4, T5, T6, T7> list, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MbEvent()
	{
		throw null;
	}
}
