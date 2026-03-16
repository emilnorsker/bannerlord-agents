using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.CustomBattle.CustomBattle;

namespace TaleWorlds.MountAndBlade.CustomBattle;

public class ArmyCompositionItemVM : ViewModel
{
	public enum CompositionType
	{
		MeleeInfantry,
		RangedInfantry,
		MeleeCavalry,
		RangedCavalry
	}

	private readonly MBReadOnlyList<SkillObject> _allSkills;

	private readonly List<BasicCharacterObject> _allCharacterObjects;

	private readonly Action<int, int> _onCompositionValueChanged;

	private readonly TroopTypeSelectionPopUpVM _troopTypeSelectionPopUp;

	private BasicCultureObject _culture;

	private readonly CompositionType _type;

	private readonly int[] _compositionValues;

	private MBBindingList<CustomBattleTroopTypeVM> _troopTypes;

	private HintViewModel _invalidHint;

	private HintViewModel _addTroopTypeHint;

	private bool _isLocked;

	private bool _isValid;

	private string _compositionValuePercentageText;

	[DataSourceProperty]
	public MBBindingList<CustomBattleTroopTypeVM> TroopTypes
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
	public HintViewModel InvalidHint
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
	public HintViewModel AddTroopTypeHint
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
	public bool IsLocked
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
	public bool IsValid
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
	public int CompositionValue
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
	public string CompositionValuePercentageText
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
	public ArmyCompositionItemVM(CompositionType type, List<BasicCharacterObject> allCharacterObjects, MBReadOnlyList<SkillObject> allSkills, Action<int, int> onCompositionValueChanged, TroopTypeSelectionPopUpVM troopTypeSelectionPopUp, int[] compositionValues)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCurrentSelectedCulture(BasicCultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteRandomize(int compositionValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteAddTroopTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshCompositionValue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdatePercentageText(int percentage)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnValidityChanged(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateTroopTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsValidUnitItem(BasicCharacterObject o)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBReadOnlyList<BasicCharacterObject> GetDefaultCharacters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static StringItemWithHintVM GetTroopTypeIconData(BasicCharacterObject basicCharacterObject, CompositionType type, bool isBig = false)
	{
		throw null;
	}
}
