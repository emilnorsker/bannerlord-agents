using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.HUD;

public class MissionAgentLockVisualizerVM : ViewModel
{
	private readonly Dictionary<Agent, MissionAgentLockItemVM> _allTrackedAgentsSet;

	private MBBindingList<MissionAgentLockItemVM> _allTrackedAgents;

	private bool _isEnabled;

	[DataSourceProperty]
	public MBBindingList<MissionAgentLockItemVM> AllTrackedAgents
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[DataSourceProperty]
	public bool IsEnabled
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAgentLockVisualizerVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnActiveLockAgentChange(Agent oldAgent, Agent newAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPossibleLockAgentChange(Agent oldPossibleAgent, Agent newPossibleAgent)
	{
		throw null;
	}
}
