using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order;

namespace NavalDLC.ViewModelCollection.Order;

public class NavalMissionOrderTroopControllerVM : MissionOrderTroopControllerVM
{
	private List<ClassConfiguration> _classData;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMissionOrderTroopControllerVM(MissionOrderVM missionOrder, bool isDeployment, Action onTransferFinised)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override OrderTroopItemVM CreateTroopItemVM(Formation formation, Action<OrderTroopItemVM> onSelectFormation, Func<Formation, int> getFormationMorale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnClassesSet(List<ClassConfiguration> classData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnAfterNewTroopItemAdded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SelectAllFormations(bool uiFeedback = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AddSelectedFormation(OrderTroopItemVM item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsOnlyPlayerFormationSelected()
	{
		throw null;
	}
}
