using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Diamond.Cosmetics;
using TaleWorlds.MountAndBlade.Diamond.Cosmetics.CosmeticTypes;

namespace TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection.Lobby.Armory.CosmeticItem;

public class MPArmoryCosmeticTauntItemVM : MPArmoryCosmeticItemBaseVM
{
	private bool _isSelected;

	private bool _requiresOnFoot;

	private float _previewAnimationRatio;

	private string _selectSlotText;

	private string _cancelEquipText;

	private string _tauntId;

	private HintViewModel _blocksMovementOnUsageHint;

	private MBBindingList<StringItemWithEnabledAndHintVM> _tauntUsages;

	public MPArmoryCosmeticsVM.TauntCategoryFlag TauntCategory
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public TauntCosmeticElement TauntCosmeticElement
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
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
	public bool RequiresOnFoot
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
	public float PreviewAnimationRatio
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
	public string SelectSlotText
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
	public string CancelEquipText
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
	public string TauntID
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
	public MBBindingList<StringItemWithEnabledAndHintVM> TauntUsages
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
	public HintViewModel BlocksMovementOnUsageHint
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
	public MPArmoryCosmeticTauntItemVM(string tauntId, CosmeticElement cosmetic, string cosmeticID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshTauntUsages()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MPArmoryCosmeticsVM.TauntCategoryFlag GetCategoryOfTaunt()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AllUsagesHaveFlag(MBReadOnlyList<TauntUsage> list, TauntUsageFlag flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AnyUsageHaveFlag(MBReadOnlyList<TauntUsage> list, TauntUsageFlag flag)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AnyUsageNotHaveFlag(MBReadOnlyList<TauntUsage> list, TauntUsageFlag flag)
	{
		throw null;
	}
}
