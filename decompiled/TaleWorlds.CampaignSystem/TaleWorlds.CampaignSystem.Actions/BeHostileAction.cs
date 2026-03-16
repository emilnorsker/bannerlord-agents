using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.Actions;

public static class BeHostileAction
{
	private const float MinorCoercionValue = 1f;

	private const float MajorCoercionValue = 2f;

	private const float EncounterValue = 6f;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyInternal(PartyBase attackerParty, PartyBase defenderParty, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyGeneralConsequencesOnPeace(PartyBase attackerParty, PartyBase defenderParty, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyHostileAction(PartyBase attackerParty, PartyBase defenderParty, float value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyMinorCoercionHostileAction(PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyMajorCoercionHostileAction(PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApplyEncounterHostileAction(PartyBase attackerParty, PartyBase defenderParty)
	{
		throw null;
	}
}
