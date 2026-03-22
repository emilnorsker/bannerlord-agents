using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One row: skill icon (world events) or clan party formation strip (OrderFormationClassVisualBrushWidget + AIInfluence.ClanPartyFormationStrip) + text.
/// </summary>
public sealed class InfoGlyphLineVM : ViewModel
{
    private bool _isSkill;
    private bool _isTroopFormationGlyph;
    private int _formationClassIndex;
    private string _skillId = "";
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
    public bool IsTroopFormationGlyph
    {
        get => _isTroopFormationGlyph;
        set
        {
            if (value == _isTroopFormationGlyph)
                return;
            _isTroopFormationGlyph = value;
            OnPropertyChangedWithValue(value, nameof(IsTroopFormationGlyph));
        }
    }

    /// <summary>0–3 = Infantry…HorseArcher; matches TaleWorlds mission formation-class strip widget.</summary>
    [DataSourceProperty]
    public int FormationClassIndex
    {
        get => _formationClassIndex;
        set
        {
            if (value == _formationClassIndex)
                return;
            _formationClassIndex = value;
            OnPropertyChangedWithValue(value, nameof(FormationClassIndex));
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
            IsTroopFormationGlyph = false,
            FormationClassIndex = 0,
            SkillId = skillId ?? "",
            Text = text ?? "",
            Color = color ?? "#C6AC8DFF"
        };
    }

    /// <summary>Clan → parties tab strips: sprites resolved via brush layers (same paths as vanilla clan UI).</summary>
    public static InfoGlyphLineVM FromTroopFormation(FormationClass formation, int count)
    {
        string label = formation switch
        {
            FormationClass.Infantry => "Infantry",
            FormationClass.Ranged => "Ranged",
            FormationClass.Cavalry => "Cavalry",
            FormationClass.HorseArcher => "Horse archers",
            _ => "Troops"
        };
        int idx = (int)formation;
        if (idx < 0 || idx > 3)
            idx = 0;
        return new InfoGlyphLineVM
        {
            IsSkill = false,
            IsTroopFormationGlyph = true,
            FormationClassIndex = idx,
            SkillId = "",
            Text = $"{label} ({count})",
            Color = "#C6AC8DFF"
        };
    }
}
