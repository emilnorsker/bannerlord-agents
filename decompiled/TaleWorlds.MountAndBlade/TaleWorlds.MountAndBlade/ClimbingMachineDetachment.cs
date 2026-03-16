using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Objects.Usables;

namespace TaleWorlds.MountAndBlade;

public class ClimbingMachineDetachment : IDetachment
{
	private const int Capacity = int.MaxValue;

	private readonly List<Agent> _agents;

	private readonly MBList<Formation> _userFormations;

	private readonly MBReadOnlyList<ClimbingMachine> _climbingMachines;

	private readonly MBList<Agent> _climberAgents;

	public MBReadOnlyList<Formation> UserFormations
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsLoose
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsActive
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClimbingMachineDetachment(in MBList<ClimbingMachine> climbingMachines)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Deactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgent(Agent agent, int slotIndex, Agent.AIScriptedFrameFlags customFlags = Agent.AIScriptedFrameFlags.None)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgentAtSlotIndex(Agent agent, int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.FormationStartUsing(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.FormationStopUsing(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsUsedByFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	Agent IDetachment.GetMovingAgentAtSlotIndex(int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.GetSlotIndexWeightTuples(List<(int, float)> slotIndexWeightTuples)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsSlotAtIndexAvailableForAgent(int slotIndex, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsAgentEligible(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.UnmarkDetachment()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsDetachmentRecentlyEvaluated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.MarkSlotAtIndex(int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsAgentUsingOrInterested(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.OnFormationLeave(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsStandingPointAvailableForAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<float> GetTemplateCostsOfAgent(Agent candidate, List<float> oldValue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetExactCostOfAgentAtSlot(Agent candidate, int slotIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetTemplateWeightOfAgent(Agent candidate)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float? GetWeightOfAgentAtNextSlot(List<Agent> newAgents, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float? GetWeightOfAgentAtNextSlot(List<(Agent, float)> agentTemplateScores, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float? GetWeightOfAgentAtOccupiedSlot(Agent detachedAgent, List<Agent> newAgents, out Agent match)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetNumberOfUsableSlots()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorldFrame? GetAgentFrame(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float? GetWeightOfNextSlot(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetWeightOfOccupiedSlot(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetDetachmentWeight(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.ResetEvaluation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IDetachment.IsEvaluated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IDetachment.SetAsEvaluated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.GetDetachmentWeightFromCache()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	float IDetachment.ComputeAndCacheDetachmentWeight(BattleSideEnum side)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickClimbingMachines()
	{
		throw null;
	}
}
