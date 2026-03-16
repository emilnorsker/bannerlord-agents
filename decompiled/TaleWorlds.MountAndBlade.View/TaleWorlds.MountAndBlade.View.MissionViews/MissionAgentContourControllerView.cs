using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.View.MissionViews;

public class MissionAgentContourControllerView : MissionView
{
	private const bool IsEnabled = false;

	private uint _nonFocusedContourColor;

	private uint _focusedContourColor;

	private uint _friendlyContourColor;

	private List<Agent> _contourAgents;

	private Agent _currentFocusedAgent;

	private bool _isContourAppliedToAllAgents;

	private bool _isContourAppliedToFocusedAgent;

	private bool _isMultiplayer;

	private bool _isAllowedByOption
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAgentContourControllerView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PopulateContourListWithAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFocusGained(Agent agent, IFocusable focusableObject, bool isInteractable)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFocusLost(Agent agent, IFocusable focusableObject)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddContourToFocusedAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveContourFromFocusedAgent()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ApplyContourToAllAgents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemoveContourFromAllAgents()
	{
		throw null;
	}
}
