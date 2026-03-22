using System.Collections.Generic;
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

    public static IEnumerable<(FormationClass formation, int count, CharacterObject sample)> AggregateTroopFormations(MobileParty party)
    {
        if (party?.MemberRoster == null)
            yield break;
        var totals = new Dictionary<FormationClass, int>();
        var samples = new Dictionary<FormationClass, CharacterObject>();
        foreach (TroopRosterElement elem in party.MemberRoster.GetTroopRoster())
        {
            CharacterObject ch = elem.Character;
            if (ch == null || elem.Number <= 0)
                continue;
            FormationClass fc = DetermineFormationClass(ch);
            if (!totals.ContainsKey(fc))
            {
                totals[fc] = 0;
                samples[fc] = ch;
            }
            totals[fc] += elem.Number;
        }
        foreach (FormationClass fc in new[] { FormationClass.Infantry, FormationClass.Ranged, FormationClass.Cavalry, FormationClass.HorseArcher })
        {
            if (totals.TryGetValue(fc, out int n) && n > 0 && samples.TryGetValue(fc, out CharacterObject sample))
                yield return (fc, n, sample);
        }
    }
}
