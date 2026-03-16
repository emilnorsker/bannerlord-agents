using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem;

public class ReferenceMBEvent<T1> : ReferenceIMBEvent<T1>, IMbEventBase
{
	internal class EventHandlerRec<TS>
	{
		public EventHandlerRec<TS> Next;

		internal ReferenceAction<TS> Action
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
		public EventHandlerRec(object owner, ReferenceAction<TS> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T1> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, ReferenceAction<T1> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(ref T1 t1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T1> list, ref T1 t1)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ClearListeners(object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ClearListenerOfList(ref EventHandlerRec<T1> list, object o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ReferenceMBEvent()
	{
		throw null;
	}
}
public class ReferenceMBEvent<T1, T2> : ReferenceIMBEvent<T1, T2>, IMbEventBase
{
	internal class EventHandlerRec<TS, TQ>
	{
		public EventHandlerRec<TS, TQ> Next;

		internal ReferenceAction<TS, TQ> Action
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
		public EventHandlerRec(object owner, ReferenceAction<TS, TQ> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T1, T2> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, ReferenceAction<T1, T2> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(T1 t1, ref T2 t2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T1, T2> list, T1 t1, ref T2 t2)
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
	public ReferenceMBEvent()
	{
		throw null;
	}
}
public class ReferenceMBEvent<T1, T2, T3> : ReferenceIMBEvent<T1, T2, T3>, IMbEventBase
{
	internal class EventHandlerRec<TS, TQ, TR>
	{
		public EventHandlerRec<TS, TQ, TR> Next;

		internal ReferenceAction<TS, TQ, TR> Action
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
		public EventHandlerRec(object owner, ReferenceAction<TS, TQ, TR> action)
		{
			throw null;
		}
	}

	private EventHandlerRec<T1, T2, T3> _nonSerializedListenerList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddNonSerializedListener(object owner, ReferenceAction<T1, T2, T3> action)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Invoke(T1 t1, T2 t2, ref T3 t3)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InvokeList(EventHandlerRec<T1, T2, T3> list, T1 t1, T2 t2, ref T3 t3)
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
	public ReferenceMBEvent()
	{
		throw null;
	}
}
