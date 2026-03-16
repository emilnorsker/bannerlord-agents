using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.BirthAndDeath;

public class BirthAndDeathOptionsProvider : ICampaignOptionProvider
{
	[CompilerGenerated]
	private sealed class _003CGetGameplayCampaignOptions_003Ed__0 : IEnumerable<ICampaignOptionData>, IEnumerable, IEnumerator<ICampaignOptionData>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ICampaignOptionData _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		ICampaignOptionData IEnumerator<ICampaignOptionData>.Current
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
		public _003CGetGameplayCampaignOptions_003Ed__0(int _003C_003E1__state)
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
		IEnumerator<ICampaignOptionData> IEnumerable<ICampaignOptionData>.GetEnumerator()
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
	private sealed class _003CGetCharacterCreationCampaignOptions_003Ed__1 : IEnumerable<ICampaignOptionData>, IEnumerable, IEnumerator<ICampaignOptionData>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ICampaignOptionData _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		ICampaignOptionData IEnumerator<ICampaignOptionData>.Current
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
		public _003CGetCharacterCreationCampaignOptions_003Ed__1(int _003C_003E1__state)
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
		IEnumerator<ICampaignOptionData> IEnumerable<ICampaignOptionData>.GetEnumerator()
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
	[IteratorStateMachine(typeof(_003CGetGameplayCampaignOptions_003Ed__0))]
	public IEnumerable<ICampaignOptionData> GetGameplayCampaignOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetCharacterCreationCampaignOptions_003Ed__1))]
	public IEnumerable<ICampaignOptionData> GetCharacterCreationCampaignOptions()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BirthAndDeathOptionsProvider()
	{
		throw null;
	}
}
