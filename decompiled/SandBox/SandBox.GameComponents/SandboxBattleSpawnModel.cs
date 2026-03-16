using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace SandBox.GameComponents;

public class SandboxBattleSpawnModel : BattleSpawnModel
{
	private enum OrderOfBattleInnerClassType
	{
		None,
		PrimaryClass,
		SecondaryClass
	}

	private struct FormationOrderOfBattleConfiguration
	{
		public DeploymentFormationClass OOBFormationClass;

		public FormationClass PrimaryFormationClass;

		public int PrimaryClassTroopCount;

		public int PrimaryClassDesiredTroopCount;

		public FormationClass SecondaryFormationClass;

		public int SecondaryClassTroopCount;

		public int SecondaryClassDesiredTroopCount;

		public Hero Captain;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionEnd()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<(IAgentOriginBase origin, int formationIndex)> GetInitialSpawnAssignments(BattleSideEnum battleSide, List<IAgentOriginBase> troopOrigins)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<(IAgentOriginBase origin, int formationIndex)> GetReinforcementAssignments(BattleSideEnum battleSide, List<IAgentOriginBase> troopOrigins)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool GetOrderOfBattleConfigurationsForFormations(BattleSideEnum battleSide, List<IAgentOriginBase> troopOrigins, out FormationOrderOfBattleConfiguration[] formationOrderOfBattleConfigurations)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static int[] CalculateTroopCountsPerDefaultFormation(BattleSideEnum battleSide, List<IAgentOriginBase> troopOrigins)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static FormationClass FindBestOrderOfBattleFormationClassAssignmentForTroop(BattleSideEnum battleSide, IAgentOriginBase origin, FormationOrderOfBattleConfiguration[] formationOrderOfBattleConfigurations, out OrderOfBattleInnerClassType bestClassInnerClassType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandboxBattleSpawnModel()
	{
		throw null;
	}
}
