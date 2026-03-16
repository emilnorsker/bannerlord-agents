using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;

namespace StoryMode.GameComponents;

public class StoryModeEncounterGameMenuModel : EncounterGameMenuModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetEncounterMenu(PartyBase attackerParty, PartyBase defenderParty, out bool startBattle, out bool joinBattle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetGenericStateMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetNewPartyJoinMenu(MobileParty newParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetRaidCompleteMenu()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsPlunderMenu(string menuId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeEncounterGameMenuModel()
	{
		throw null;
	}
}
