using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class PrisonerDonationModel : MBGameModel<PrisonerDonationModel>
{
	public abstract float CalculateRelationGainAfterHeroPrisonerDonate(PartyBase donatingParty, Hero donatedHero, Settlement donatedSettlement);

	public abstract float CalculateInfluenceGainAfterPrisonerDonation(PartyBase donatingParty, CharacterObject donatedPrisoner, Settlement donatedSettlement);

	public abstract float CalculateInfluenceGainAfterTroopDonation(PartyBase donatingParty, CharacterObject donatedTroop, Settlement donatedSettlement);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected PrisonerDonationModel()
	{
		throw null;
	}
}
