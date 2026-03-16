using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order;

namespace NavalDLC.ViewModelCollection.Order;

public class NavalMissionOrderVM : MissionOrderVM
{
	private List<ClassConfiguration> _classData;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMissionOrderVM(OrderController orderController, bool isDeployment, bool isMultiplayer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override MissionOrderTroopControllerVM CreateTroopController(OrderController orderController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnClassesSet(List<ClassConfiguration> classData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnOrderLayoutTypeChanged()
	{
		throw null;
	}
}
