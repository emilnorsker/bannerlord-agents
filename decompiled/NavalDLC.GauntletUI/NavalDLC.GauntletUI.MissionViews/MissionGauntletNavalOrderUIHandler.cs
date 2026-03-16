using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.View.MissionViews;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.GauntletUI.Mission.Singleplayer;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.ViewModelCollection.Order;

namespace NavalDLC.GauntletUI.MissionViews;

[OverrideView(typeof(NavalMissionOrderUIHandler))]
public class MissionGauntletNavalOrderUIHandler : MissionGauntletSingleplayerOrderUIHandler
{
	protected NavalShipTargetSelectionHandler _shipTargetHandler;

	private OrderController _orderController;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletNavalOrderUIHandler()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override MissionOrderVM CreateDataSource(OrderController orderController)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override OrderItemVM GetChargeOrder()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnClassesSet(List<ClassConfiguration> classData)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void TickInput(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnSelectedFormationsChanged()
	{
		throw null;
	}
}
