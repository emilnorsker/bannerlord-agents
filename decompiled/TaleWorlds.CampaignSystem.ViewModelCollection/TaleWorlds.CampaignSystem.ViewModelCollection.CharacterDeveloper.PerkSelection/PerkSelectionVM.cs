using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper.PerkSelection;

public class PerkSelectionVM : ViewModel
{
	private readonly HeroDeveloper _developer;

	private readonly List<PerkObject> _selectedPerks;

	private readonly Action<SkillObject> _refreshPerksOf;

	private readonly Action _onPerkSelection;

	private PerkVM _currentInitialPerk;

	private bool _isActive;

	private MBBindingList<PerkSelectionItemVM> _availablePerks;

	[DataSourceProperty]
	public bool IsActive
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
	public MBBindingList<PerkSelectionItemVM> AvailablePerks
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
	public PerkSelectionVM(HeroDeveloper developer, Action<SkillObject> refreshPerksOf, Action onPerkSelection)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCurrentSelectionPerk(PerkVM perk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectPerk(PerkSelectionItemVM selectedPerk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ResetSelectedPerks()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApplySelectedPerks()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPerkSelected(PerkObject perk)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsAnyPerkSelected()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteDeactivate()
	{
		throw null;
	}
}
