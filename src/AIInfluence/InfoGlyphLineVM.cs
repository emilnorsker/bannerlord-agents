using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One row with a left glyph (skill icon or formation sprite) + text — same binding pattern for
/// world events and party troop strips (icon vs sprite is the same UI shape).
/// </summary>
public sealed class InfoGlyphLineVM : ViewModel
{
    private bool _isSkill;
    private bool _isFormation;
    private string _skillId = "";
    private string _formationSprite = "";
    private string _text = "";
    private string _color = "#C6AC8DFF";

    [DataSourceProperty]
    public bool IsSkill
    {
        get => _isSkill;
        set
        {
            if (value == _isSkill)
                return;
            _isSkill = value;
            OnPropertyChangedWithValue(value, nameof(IsSkill));
        }
    }

    [DataSourceProperty]
    public bool IsFormation
    {
        get => _isFormation;
        set
        {
            if (value == _isFormation)
                return;
            _isFormation = value;
            OnPropertyChangedWithValue(value, nameof(IsFormation));
        }
    }

    [DataSourceProperty]
    public string SkillId
    {
        get => _skillId;
        set
        {
            value ??= "";
            if (value == _skillId)
                return;
            _skillId = value;
            OnPropertyChangedWithValue(_skillId, nameof(SkillId));
        }
    }

    [DataSourceProperty]
    public string FormationSprite
    {
        get => _formationSprite;
        set
        {
            value ??= "";
            if (value == _formationSprite)
                return;
            _formationSprite = value;
            OnPropertyChangedWithValue(_formationSprite, nameof(FormationSprite));
        }
    }

    [DataSourceProperty]
    public string Text
    {
        get => _text;
        set
        {
            value ??= "";
            if (value == _text)
                return;
            _text = value;
            OnPropertyChangedWithValue(_text, nameof(Text));
        }
    }

    [DataSourceProperty]
    public string Color
    {
        get => _color;
        set
        {
            value ??= "#C6AC8DFF";
            if (value == _color)
                return;
            _color = value;
            OnPropertyChangedWithValue(_color, nameof(Color));
        }
    }

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

    /// <summary>Uses <see cref="SkillIconVisualWidget"/> (same as world events). Plain <c>Widget</c> + <c>Sprite=@FormationSprite</c> does not reliably bind game sprite paths in Gauntlet.</summary>
    public static InfoGlyphLineVM FromTroopFormation(FormationClass formation, int count)
    {
        string skillId = formation switch
        {
            FormationClass.Ranged => DefaultSkills.Bow.StringId,
            FormationClass.Cavalry => DefaultSkills.Riding.StringId,
            FormationClass.HorseArcher => DefaultSkills.Bow.StringId,
            _ => DefaultSkills.OneHanded.StringId
        };
        string label = formation switch
        {
            FormationClass.Infantry => "Infantry",
            FormationClass.Ranged => "Ranged",
            FormationClass.Cavalry => "Cavalry",
            FormationClass.HorseArcher => "Horse archers",
            _ => "Troops"
        };
        return new InfoGlyphLineVM
        {
            IsSkill = true,
            IsFormation = false,
            SkillId = skillId,
            FormationSprite = "",
            Text = $"{label} ({count})",
            Color = "#C6AC8DFF"
        };
    }
}
