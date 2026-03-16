using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;

public class ClanRoleItemVM : ViewModel
{
	private class ClanRoleMemberComparer : IComparer<ClanRoleMemberItemVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(ClanRoleMemberItemVM x, ClanRoleMemberItemVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ClanRoleMemberComparer()
		{
			throw null;
		}
	}

	private Action<ClanRoleItemVM> _onRoleSelectionToggled;

	private Action _onRoleAssigned;

	private MBBindingList<ClanPartyMemberItemVM> _heroMembers;

	private MobileParty _party;

	private ClanRoleMemberComparer _comparer;

	private bool _isEnabled;

	private MBBindingList<ClanRoleMemberItemVM> _members;

	private ClanRoleMemberItemVM _effectiveOwner;

	private HintViewModel _notAssignedHint;

	private HintViewModel _disabledHint;

	private bool _isNotAssigned;

	private bool _hasEffects;

	private string _name;

	private string _assignedMemberEffects;

	private string _noEffectText;

	public PartyRole Role
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

	[DataSourceProperty]
	public bool IsEnabled
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
	public MBBindingList<ClanRoleMemberItemVM> Members
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
	public ClanRoleMemberItemVM EffectiveOwner
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
	public HintViewModel NotAssignedHint
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
	public HintViewModel DisabledHint
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
	public bool IsNotAssigned
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
	public bool HasEffects
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
	public string Name
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
	public string AssignedMemberEffects
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
	public string NoEffectText
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
	public ClanRoleItemVM(MobileParty party, PartyRole role, MBBindingList<ClanPartyMemberItemVM> heroMembers, Action<ClanRoleItemVM> onRoleSelectionToggled, Action onRoleAssigned)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Refresh()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteToggleRoleSelection()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetMemberAssignedToRole(MobileParty party, PartyRole role, out Hero roleOwner, out Hero effectiveRoleOwner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRoleAssigned()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetEnabled(bool enabled, TextObject disabledHint)
	{
		throw null;
	}
}
