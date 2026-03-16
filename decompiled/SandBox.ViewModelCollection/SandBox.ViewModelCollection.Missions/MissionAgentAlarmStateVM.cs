using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Objects;

namespace SandBox.ViewModelCollection.Missions;

public class MissionAgentAlarmStateVM : ViewModel
{
	private bool _isInitialized;

	private Mission _mission;

	private Camera _camera;

	private DisguiseMissionLogic _disguiseMissionLogic;

	private bool _areStealthBoxesDirty;

	private List<StealthBox> _stealthBoxes;

	private bool _isMainAgentInSafeArea;

	private MBBindingList<MissionAgentAlarmTargetVM> _targets;

	[DataSourceProperty]
	public MBBindingList<MissionAgentAlarmTargetVM> Targets
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
	public bool IsMainAgentInSafeArea
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
	public MissionAgentAlarmStateVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize(Mission mission, Camera camera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnStealthBoxInitialized(StealthBox stealthBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnStealthBoxRemoved(StealthBox stealthBox)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshStealthBoxEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Update()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsMainAgentInStealthArea()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentRemoved(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshTargets()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentBuild(Agent agent, Banner banner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnAgentTeamChanged(Team prevTeam, Team newTeam, Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnRemoveTarget(MissionAgentAlarmTargetVM targetToRemove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MissionAgentAlarmTargetVM GetAgentTargetFromAgent(Agent agent)
	{
		throw null;
	}
}
