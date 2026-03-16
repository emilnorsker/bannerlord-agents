using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Party.PartyTroopManagerPopUp;

public class PartyUpgradeTroopVM : PartyTroopManagerVM
{
	private int _disabledTroopsStartIndex;

	private string _upgradeCostText;

	private string _upgradesAndRequirementsText;

	[DataSourceProperty]
	public string UpgradeCostText
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
	public string UpgradesAndRequirementsText
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
	public PartyUpgradeTroopVM(PartyVM partyVM)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnRanOutTroop(PartyCharacterVM troop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTroopUpgraded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OpenPopUp()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteDone()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteCancel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ConfirmCancel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateUpgradesOfAllTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateTroops()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TooltipProperty> GetUsedHorsesTooltip()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteItemPrimaryAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteItemSecondaryAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ExecuteItemTertiaryAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpgradeTroopAtIndex(int upgradeIndex)
	{
		throw null;
	}
}
