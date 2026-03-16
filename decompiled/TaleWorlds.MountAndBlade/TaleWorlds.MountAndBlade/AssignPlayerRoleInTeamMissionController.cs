using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade;

public class AssignPlayerRoleInTeamMissionController : MissionLogic
{
	protected readonly List<string> CharactersInPlayerSideByPriority;

	protected Queue<string> CharacterNamesInPlayerSideByPriorityQueue;

	protected List<Formation> RemainingFormationsToAssignSergeantsTo;

	protected Dictionary<int, Agent> FormationsLockedWithSergeants;

	protected Dictionary<int, Agent> FormationsWithLooselyChosenSergeants;

	public bool IsPlayerInArmy
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public bool IsPlayerGeneral
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public bool IsPlayerSergeant
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public int PlayerChosenIndex
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		protected set
		{
			throw null;
		}
	}

	public event PlayerTurnToChooseFormationToLeadEvent OnPlayerTurnToChooseFormationToLead
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event AllFormationsAssignedSergeantsEvent OnAllFormationsAssignedSergeants
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AssignPlayerRoleInTeamMissionController(bool isPlayerGeneral, bool isPlayerSergeant, bool isPlayerInArmy, List<string> charactersInPlayerSideByPriority = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnTeamDeployed(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnPlayerTeamDeployed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnPlayerChoiceMade(int chosenIndex)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPlayerChoiceFinalized()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void AssignSergeant(Formation formationToLead, Agent sergeant)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Formation ChooseFormationToLead(IEnumerable<Formation> formationsToChooseFrom, Agent agent)
	{
		throw null;
	}
}
