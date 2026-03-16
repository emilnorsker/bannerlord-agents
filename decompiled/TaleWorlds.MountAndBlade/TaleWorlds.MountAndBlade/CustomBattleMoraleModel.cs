using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace TaleWorlds.MountAndBlade;

public class CustomBattleMoraleModel : BattleMoraleModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override (float affectedSideMaxMoraleLoss, float affectorSideMaxMoraleGain) CalculateMaxMoraleChangeDueToAgentIncapacitated(Agent affectedAgent, AgentState affectedAgentState, Agent affectorAgent, in KillingBlow killingBlow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override (float affectedSideMaxMoraleLoss, float affectorSideMaxMoraleGain) CalculateMaxMoraleChangeDueToAgentPanicked(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateMoraleChangeToCharacter(Agent agent, float maxMoraleChange)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetEffectiveInitialMorale(Agent agent, float baseMorale)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanPanicDueToMorale(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateCasualtiesFactor(BattleSideEnum battleSide)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetAverageMorale(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateMoraleChangeOnShipSunk(IShipOrigin shipOrigin)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateMoraleOnRamming(Agent agent, IShipOrigin rammingShip, IShipOrigin rammedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateMoraleOnShipsConnected(Agent agent, IShipOrigin ownerShip, IShipOrigin targetShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomBattleMoraleModel()
	{
		throw null;
	}
}
