using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.WeaponCrafting.WeaponDesign;

public class WeaponClassSelectionPopupVM : ViewModel
{
	private readonly ICraftingCampaignBehavior _craftingBehavior;

	private readonly Action<int> _onSelect;

	private readonly List<CraftingTemplate> _templatesList;

	private readonly Func<CraftingTemplate, int> _getUnlockedPiecesCount;

	private string _popupHeader;

	private bool _isVisible;

	private MBBindingList<WeaponClassVM> _weaponClasses;

	[DataSourceProperty]
	public string PopupHeader
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
	public bool IsVisible
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
	public MBBindingList<WeaponClassVM> WeaponClasses
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
	public WeaponClassSelectionPopupVM(ICraftingCampaignBehavior craftingBehavior, List<CraftingTemplate> templatesList, Action<int> onSelect, Func<CraftingTemplate, int> getUnlockedPiecesCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshList()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateNewlyUnlockedPiecesCount(List<CraftingPiece> newlyUnlockedPieces)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CraftingPiece FindPieceInTemplate(CraftingTemplate template, CraftingPiece piece)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteSelectWeaponClass(int index)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteClosePopup()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteOpenPopup()
	{
		throw null;
	}
}
