using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem;

public struct BattleResultPartyData
{
	public readonly PartyBase Party;

	public readonly List<CharacterObject> Characters;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleResultPartyData(PartyBase party)
	{
		throw null;
	}
}
