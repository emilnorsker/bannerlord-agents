using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence;

public class TournamentData
{
	public Settlement Settlement { get; set; }

	public Hero Winner { get; set; }

	public HashSet<string> ParticipantIds { get; set; } = new HashSet<string>();

	public List<Hero> ParticipantHeroes { get; set; } = new List<Hero>();

	public bool IsPlayerInvolved { get; set; }

	public bool PlayerWon { get; set; }

	public bool PlayerParticipated { get; set; }

	public bool ClanMemberWon { get; set; }

	public bool ClanMemberParticipated { get; set; }

	public Hero ClanMemberWinner { get; set; }

	public Hero ClanMemberParticipant { get; set; }
}
