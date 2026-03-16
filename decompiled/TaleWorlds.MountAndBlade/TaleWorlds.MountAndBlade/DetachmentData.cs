using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class DetachmentData
{
	public List<Formation> joinedFormations;

	public List<(Agent, List<float>)> agentScores;

	public int MovingAgentCount;

	public int DefendingAgentCount;

	public float firstTime;

	public int AgentCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsPrecalculated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DetachmentData()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveScoreOfAgent(Agent agent)
	{
		throw null;
	}
}
