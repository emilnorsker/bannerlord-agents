using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One row with a left glyph (skill icon or formation sprite) + text — same binding pattern for
/// world events and party troop strips (icon vs sprite is the same UI shape).
/// </summary>
public sealed class InfoGlyphLineVM : ViewModel
{
    [DataSourceProperty] public bool IsSkill { get; set; }
    [DataSourceProperty] public bool IsFormation { get; set; }
    [DataSourceProperty] public string SkillId { get; set; } = "";
    [DataSourceProperty] public string FormationSprite { get; set; } = "";
    [DataSourceProperty] public string Text { get; set; } = "";
    [DataSourceProperty] public string Color { get; set; } = "#C6AC8DFF";

    public static InfoGlyphLineVM FromWorldEvent(string skillId, string text, string color = "#C6AC8DFF")
    {
        return new InfoGlyphLineVM
        {
            IsSkill = true,
            IsFormation = false,
            SkillId = skillId ?? "",
            FormationSprite = "",
            Text = text ?? "",
            Color = color ?? "#C6AC8DFF"
        };
    }

    public static InfoGlyphLineVM FromTroopFormation(FormationClass formation, int count)
    {
        return new InfoGlyphLineVM
        {
            IsSkill = false,
            IsFormation = true,
            SkillId = "",
            FormationSprite = PartyTroopFormationHelper.GetFormationSpritePath(formation),
            Text = "(" + count + ")",
            Color = "#C6AC8DFF"
        };
    }
}
