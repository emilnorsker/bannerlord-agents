using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.Refinement;

public class RefinementActionItemVM : ViewModel
{
	private readonly Action<RefinementActionItemVM> _onSelect;

	private MBBindingList<CraftingResourceItemVM> _inputMaterials;

	private MBBindingList<CraftingResourceItemVM> _outputMaterials;

	private bool _isSelected;

	private bool _isEnabled;

	public Crafting.RefiningFormula RefineFormula
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public MBBindingList<CraftingResourceItemVM> InputMaterials
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
	public MBBindingList<CraftingResourceItemVM> OutputMaterials
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
	public bool IsSelected
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RefinementActionItemVM(Crafting.RefiningFormula refineFormula, Action<RefinementActionItemVM> onSelect)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RefreshDynamicProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool UpdateInputAvailabilities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSelectAction()
	{
		throw null;
	}
}
