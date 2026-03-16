using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.OrderOfBattle;

internal static class OrderOfBattleUIHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static List<Agent> GetExcludedAgentsForTransfer(OrderOfBattleFormationItemVM formationVM, FormationClass formationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static (Formation formation, int troopCount, TroopTraitsMask troopFilter, List<Agent> excludedAgents) CreateMassTransferData(OrderOfBattleFormationClassVM affectedClass, FormationClass formationClass, TroopTraitsMask filter, int unitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static (Formation formation, int troopCount, TroopTraitsMask troopFilter, List<Agent> excludedAgents) CreateMassTransferData(OrderOfBattleFormationItemVM affectedFormation, FormationClass formationClass, TroopTraitsMask filter, int unitCount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static (int, bool, bool) GetRelevantTroopTransferParameters(OrderOfBattleFormationClassVM classVM)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static OrderOfBattleFormationClassVM GetFormationClassWithExtremumWeight(List<OrderOfBattleFormationClassVM> classes, bool isMinimum)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static List<OrderOfBattleFormationClassVM> GetMatchingClasses(List<OrderOfBattleFormationItemVM> formationList, OrderOfBattleFormationClassVM formationClass, Func<OrderOfBattleFormationClassVM, bool> predicate = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool IsAgentInFormationClass(Agent agent, FormationClass fc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static List<Agent> GetBannerBearersOfFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int GetCountOfUnitsInClass(OrderOfBattleFormationClassVM classVM, bool includeHeroes, bool includeBannerBearers)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GetTotalCountOfUnitsInClass(Formation formation, FormationClass fc)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GetCountOfRealUnitsInClass(OrderOfBattleFormationClassVM classVM)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GetVisibleCountOfUnitsInClass(OrderOfBattleFormationClassVM classVM)
	{
		throw null;
	}
}
