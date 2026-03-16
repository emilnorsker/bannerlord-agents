using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.ImageIdentifiers;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement.ClanFinance;

public class ClanFinanceAlleyItemVM : ClanFinanceIncomeItemBaseVM
{
	[CompilerGenerated]
	private sealed class _003CGetHeroProperties_003Ed__12 : IEnumerable<ClanCardSelectionItemPropertyInfo>, IEnumerable, IEnumerator<ClanCardSelectionItemPropertyInfo>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ClanCardSelectionItemPropertyInfo _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private DefaultAlleyModel.AlleyMemberAvailabilityDetail detail;

		public DefaultAlleyModel.AlleyMemberAvailabilityDetail _003C_003E3__detail;

		private Hero hero;

		public Hero _003C_003E3__hero;

		private Alley alley;

		public Alley _003C_003E3__alley;

		public ClanFinanceAlleyItemVM _003C_003E4__this;

		ClanCardSelectionItemPropertyInfo IEnumerator<ClanCardSelectionItemPropertyInfo>.Current
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
		public _003CGetHeroProperties_003Ed__12(int _003C_003E1__state)
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
		IEnumerator<ClanCardSelectionItemPropertyInfo> IEnumerable<ClanCardSelectionItemPropertyInfo>.GetEnumerator()
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
	private sealed class _003CGetAvailableMembers_003Ed__13 : IEnumerable<ClanCardSelectionItemInfo>, IEnumerable, IEnumerator<ClanCardSelectionItemInfo>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ClanCardSelectionItemInfo _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public ClanFinanceAlleyItemVM _003C_003E4__this;

		private List<(Hero, DefaultAlleyModel.AlleyMemberAvailabilityDetail)> _003CavailabilityDetails_003E5__2;

		private List<Hero>.Enumerator _003C_003E7__wrap2;

		ClanCardSelectionItemInfo IEnumerator<ClanCardSelectionItemInfo>.Current
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
		public _003CGetAvailableMembers_003Ed__13(int _003C_003E1__state)
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
		IEnumerator<ClanCardSelectionItemInfo> IEnumerable<ClanCardSelectionItemInfo>.GetEnumerator()
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

	public readonly Alley Alley;

	private readonly Hero _alleyOwner;

	private readonly IAlleyCampaignBehavior _alleyBehavior;

	private readonly AlleyModel _alleyModel;

	private readonly Action<ClanFinanceAlleyItemVM> _onSelectionT;

	private readonly Action<ClanCardSelectionInfo> _openCardSelectionPopup;

	private HintViewModel _manageAlleyHint;

	private CharacterImageIdentifierVM _ownerVisual;

	private string _incomeText;

	private string _incomeTextWithVisual;

	[DataSourceProperty]
	public HintViewModel ManageAlleyHint
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public CharacterImageIdentifierVM OwnerVisual
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string IncomeText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public string IncomeTextWithVisual
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClanFinanceAlleyItemVM(Alley alley, Action<ClanCardSelectionInfo> openCardSelectionPopup, Action<ClanFinanceAlleyItemVM> onSelection, Action onRefresh)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void tempOnSelection(ClanFinanceIncomeItemBaseVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void PopulateStatsList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetStatusText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ClanCardSelectionItemPropertyInfo GetSkillProperty(Hero hero, SkillObject skill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetHeroProperties_003Ed__12))]
	private IEnumerable<ClanCardSelectionItemPropertyInfo> GetHeroProperties(Hero hero, Alley alley, DefaultAlleyModel.AlleyMemberAvailabilityDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[IteratorStateMachine(typeof(_003CGetAvailableMembers_003Ed__13))]
	private IEnumerable<ClanCardSelectionItemInfo> GetAvailableMembers()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMemberSelection(List<object> members, Action closePopup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteManageAlley()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteBeginHeroHint()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteEndHeroHint()
	{
		throw null;
	}
}
