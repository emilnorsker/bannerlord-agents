using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.PlayerServices;

namespace TaleWorlds.PlatformService;

public static class FriendListService
{
	[CompilerGenerated]
	private sealed class _003CGetAllFriendsInAllPlatforms_003Ed__0 : IEnumerable<PlayerId>, IEnumerable, IEnumerator<PlayerId>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private PlayerId _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IFriendListService[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		private IEnumerator<PlayerId> _003C_003E7__wrap3;

		PlayerId IEnumerator<PlayerId>.Current
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
		public _003CGetAllFriendsInAllPlatforms_003Ed__0(int _003C_003E1__state)
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
		IEnumerator<PlayerId> IEnumerable<PlayerId>.GetEnumerator()
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
	[IteratorStateMachine(typeof(_003CGetAllFriendsInAllPlatforms_003Ed__0))]
	public static IEnumerable<PlayerId> GetAllFriendsInAllPlatforms()
	{
		throw null;
	}
}
