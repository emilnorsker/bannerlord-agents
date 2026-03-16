using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace NavalDLC.CustomBattle.CustomBattle;

public class NavalCustomBattleArmyCompositionGroupVM : ViewModel
{
	public int[] CompositionValues;

	private bool _updatingSliders;

	private BasicCultureObject _selectedCulture;

	private float _cachedArmySizeRatio;

	private readonly MBReadOnlyList<SkillObject> _allSkills;

	private readonly List<BasicCharacterObject> _allCharacterObjects;

	private NavalCustomBattleArmyCompositionItemVM _meleeInfantryComposition;

	private NavalCustomBattleArmyCompositionItemVM _rangedInfantryComposition;

	private int _armySize;

	private int _maxArmySize;

	private int _minArmySize;

	private int _skeletalSize;

	private int _deckSize;

	private string _armySizeTitle;

	private string _warningText;

	private bool _isWarned;

	[DataSourceProperty]
	public NavalCustomBattleArmyCompositionItemVM MeleeInfantryComposition
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
	public NavalCustomBattleArmyCompositionItemVM RangedInfantryComposition
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
	public string ArmySizeTitle
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
	public string WarningText
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
	public bool IsWarned
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
	public int ArmySize
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
	public int MaxArmySize
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
	public int MinArmySize
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

	public int SkeletalSize
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

	public int DeckSize
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
	public NavalCustomBattleArmyCompositionGroupVM(NavalCustomBattleTroopTypeSelectionPopUpVM troopTypeSelectionPopUp)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCurrentSelectedCulture(BasicCultureObject selectedCulture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateSliders(int value, int changedSliderIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetArmyCompositionValue(int index, int value, NavalCustomBattleArmyCompositionItemVM composition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteRandomize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateTroopCountLimits(int minTroopCount, int maxTroopCount, int skeletalSize, int deckSize)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateIsWarned()
	{
		throw null;
	}
}
