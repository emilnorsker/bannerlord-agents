using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade;

public class DetachmentManager
{
	private readonly MBList<(IDetachment, DetachmentData)> _detachments;

	private readonly Dictionary<IDetachment, DetachmentData> _detachmentDataDictionary;

	private readonly List<(int, float)> _slotIndexWeightTuplesCache;

	private readonly Team _team;

	public MBReadOnlyList<(IDetachment, DetachmentData)> Detachments
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DetachmentManager(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Team_OnFormationsChanged(Team team, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ContainsDetachment(IDetachment detachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void MakeDetachment(IDetachment detachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DestroyDetachment(IDetachment destroyedDetachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationJoinDetachment(Formation formation, IDetachment joinedDetachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFormationLeaveDetachment(Formation formation, IDetachment leftDetachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickDetachments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void TickAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentRemoved(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveScoresOfAgentFromDetachments(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveScoresOfAgentFromDetachment(Agent agent, IDetachment detachmentToBeRemovedFrom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgentAsMovingToDetachment(Agent agent, IDetachment detachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAgentAsMovingToDetachment(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddAgentAsDefendingToDetachment(Agent agent, IDetachment detachment)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveAgentAsDefendingToDetachment(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	private void AssertDetachments()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Conditional("DEBUG")]
	public void AssertDetachment(Team team, IDetachment detachment)
	{
		throw null;
	}
}
