using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.MountAndBlade;

public class GeneralsAndCaptainsAssignmentLogic : MissionLogic
{
	public int MinimumAgentCountToLeadGeneralFormation;

	private BannerBearerLogic _bannerLogic;

	private readonly TextObject _attackerGeneralName;

	private readonly TextObject _defenderGeneralName;

	private readonly TextObject _attackerAllyGeneralName;

	private readonly TextObject _defenderAllyGeneralName;

	private readonly bool _createBodyguard;

	private bool _isPlayerTeamGeneralFormationSet;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GeneralsAndCaptainsAssignmentLogic(TextObject attackerGeneralName, TextObject defenderGeneralName, TextObject attackerAllyGeneralName = null, TextObject defenderAllyGeneralName = null, bool createBodyguard = true)
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
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void SortCaptainsByPriority(Team team, ref List<Agent> captains)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual Formation PickBestRegularFormationToLead(Agent agent, List<Formation> candidateFormations)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool CanTeamHaveGeneralsFormation(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AssignBestCaptainsForTeam(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetGeneralAgentOfTeam(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateGeneralFormationForTeam(Team team)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCaptainAssignedToFormation(Agent captain, Formation formation)
	{
		throw null;
	}
}
