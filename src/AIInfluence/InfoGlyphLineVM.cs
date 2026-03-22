using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One row: skill icon (world events) or clan party formation strip (literal SPGeneral\Clan\party_troop_* in XML) + text.
/// </summary>
public sealed class InfoGlyphLineVM : ViewModel
{
    private bool _isSkill;
    private bool _isClanPartyInfantry;
    private bool _isClanPartyRanged;
    private bool _isClanPartyCavalry;
    private bool _isClanPartyHorseArcher;
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
    public bool IsClanPartyInfantry
    {
        get => _isClanPartyInfantry;
        set
        {
            if (value == _isClanPartyInfantry)
                return;
            _isClanPartyInfantry = value;
            OnPropertyChangedWithValue(value, nameof(IsClanPartyInfantry));
        }
    }

    [DataSourceProperty]
    public bool IsClanPartyRanged
    {
        get => _isClanPartyRanged;
        set
        {
            if (value == _isClanPartyRanged)
                return;
            _isClanPartyRanged = value;
            OnPropertyChangedWithValue(value, nameof(IsClanPartyRanged));
        }
    }

    [DataSourceProperty]
    public bool IsClanPartyCavalry
    {
        get => _isClanPartyCavalry;
        set
        {
            if (value == _isClanPartyCavalry)
                return;
            _isClanPartyCavalry = value;
            OnPropertyChangedWithValue(value, nameof(IsClanPartyCavalry));
        }
    }

    [DataSourceProperty]
    public bool IsClanPartyHorseArcher
    {
        get => _isClanPartyHorseArcher;
        set
        {
            if (value == _isClanPartyHorseArcher)
                return;
            _isClanPartyHorseArcher = value;
            OnPropertyChangedWithValue(value, nameof(IsClanPartyHorseArcher));
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
            IsClanPartyInfantry = false,
            IsClanPartyRanged = false,
            IsClanPartyCavalry = false,
            IsClanPartyHorseArcher = false,
            SkillId = skillId ?? "",
            Text = text ?? "",
            Color = color ?? "#C6AC8DFF"
        };
    }

    /// <summary>Same formation strips as clan screen parties tab: <see cref="PartyTroopFormationHelper"/> paths, rendered via literal prefab sprites (not VM string → Sprite bind).</summary>
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
        return new InfoGlyphLineVM
        {
            IsSkill = false,
            SkillId = "",
            IsClanPartyInfantry = formation == FormationClass.Infantry,
            IsClanPartyRanged = formation == FormationClass.Ranged,
            IsClanPartyCavalry = formation == FormationClass.Cavalry,
            IsClanPartyHorseArcher = formation == FormationClass.HorseArcher,
            Text = $"{label} ({count})",
            Color = "#C6AC8DFF"
        };
    }
}
