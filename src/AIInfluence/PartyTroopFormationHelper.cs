using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace AIInfluence;

internal static class PartyTroopFormationHelper
{
    /// <summary>Same logic as settlement combat: foot ranged / foot melee / mounted ranged / mounted melee.</summary>
    public static FormationClass DetermineFormationClass(CharacterObject character)
    {
        if (character == null)
            return FormationClass.Infantry;
        if (character.IsHero)
            return FormationClass.Infantry;
        BasicCharacterObject b = character;
        if (b.IsMounted)
            return b.IsRanged ? FormationClass.HorseArcher : FormationClass.Cavalry;
        return b.IsRanged ? FormationClass.Ranged : FormationClass.Infantry;
    }

    /// <summary>Per-formation totals (including zeros) for the same strip as the Clan screen Parties detail panel.</summary>
    public static void GetFormationCounts(MobileParty party, out int infantry, out int ranged, out int cavalry, out int horseArcher)
    {
        infantry = ranged = cavalry = horseArcher = 0;
        if (party?.MemberRoster == null)
            return;
        foreach (TroopRosterElement elem in party.MemberRoster.GetTroopRoster())
        {
            if (elem.Character == null || elem.Number <= 0)
                continue;
            FormationClass fc = DetermineFormationClass(elem.Character);
            switch (fc)
            {
                case FormationClass.Infantry: infantry += elem.Number; break;
                case FormationClass.Ranged: ranged += elem.Number; break;
                case FormationClass.Cavalry: cavalry += elem.Number; break;
                case FormationClass.HorseArcher: horseArcher += elem.Number; break;
            }
        }
    }
}
