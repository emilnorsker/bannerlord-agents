using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSiegeStrategyActionModel : SiegeStrategyActionModel
{
	private List<(SiegeEngineType, int)> _prepareAssaultEngineList;

	private List<(SiegeEngineType, int)> _breachWallsEngineList;

	private List<(SiegeEngineType, int)> _wearOutDefendersEngineList;

	private List<(SiegeEngineType, int)> _prepareAgainstAssaultEngineList;

	private List<(SiegeEngineType, int)> _counterBombardmentEngineList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void GetLogicalActionForStrategy(ISiegeEventSide side, out SiegeAction siegeAction, out SiegeEngineType siegeEngineType, out int deploymentIndex, out int reserveIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CheckIfStrategyListSatisfied(ISiegeEventSide side, List<(SiegeEngineType, int)> engineList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetLogicalActionToCompleteEngineList(ISiegeEventSide side, out SiegeAction siegeAction, out SiegeEngineType siegeEngineType, out int deploymentIndex, out int reserveIndex, List<(SiegeEngineType, int)> engineList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetLogicalActionForPreserveStrengthStrategy(ISiegeEventSide side, out SiegeAction siegeAction, out SiegeEngineType siegeEngineType, out int deploymentIndex, out int reserveIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetLogicalActionForPrepareAssaultStrategy(ISiegeEventSide side, out SiegeAction siegeAction, out SiegeEngineType siegeEngineType, out int deploymentIndex, out int reserveIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetLogicalActionForBreachWallsStrategy(ISiegeEventSide side, out SiegeAction siegeAction, out SiegeEngineType siegeEngineType, out int deploymentIndex, out int reserveIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetLogicalActionForWearOutDefendersStrategy(ISiegeEventSide side, out SiegeAction siegeAction, out SiegeEngineType siegeEngineType, out int deploymentIndex, out int reserveIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetLogicalActionForPrepareAgainstAssaultStrategy(ISiegeEventSide side, out SiegeAction siegeAction, out SiegeEngineType siegeEngineType, out int deploymentIndex, out int reserveIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GetLogicalActionForCounterBombardmentStrategy(ISiegeEventSide side, out SiegeAction siegeAction, out SiegeEngineType siegeEngineType, out int deploymentIndex, out int reserveIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSiegeStrategyActionModel()
	{
		throw null;
	}
}
