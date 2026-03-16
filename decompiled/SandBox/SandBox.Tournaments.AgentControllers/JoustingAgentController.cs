using System.Runtime.CompilerServices;
using SandBox.Tournaments.MissionLogics;
using TaleWorlds.MountAndBlade;

namespace SandBox.Tournaments.AgentControllers;

public class JoustingAgentController : AgentController
{
	public enum JoustingAgentState
	{
		GoingToBackStart,
		GoToStartPosition,
		WaitInStartPosition,
		WaitingOpponent,
		Ready,
		StartRiding,
		Riding,
		RidingAtWrongSide,
		SwordDuel
	}

	private JoustingAgentState _state;

	public int CurrentCornerIndex;

	private const float MaxDistance = 3f;

	public int Score;

	private Agent _opponentAgent;

	public JoustingAgentState State
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

	public TournamentJoustingMissionController JoustingMissionController
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

	public Agent Opponent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool PrepareEquipmentsAfterDismount
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
	public override void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateMainAgentState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAIAgentState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrepareAgentToSwordDuel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void PrepareEquipmentsForSwordDuel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AddEquipmentsForSwordDuel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsRiding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JoustingAgentController()
	{
		throw null;
	}
}
