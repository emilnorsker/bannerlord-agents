using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One row: skill icon (world events) + text.
/// </summary>
public sealed class InfoGlyphLineVM : ViewModel
{
    private bool _isSkill;
    private string _skillId = "";
    private string _text = "";
    private string _color = "#C6AC8DFF";
    private bool _hasWorldEventBackground;
    private string _severityTintColor = "#FFFFFFFF";

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

    /// <summary>True when the vanilla gradient underlay is shown (world events).</summary>
    [DataSourceProperty]
    public bool HasWorldEventBackground
    {
        get => _hasWorldEventBackground;
        set
        {
            if (value == _hasWorldEventBackground)
                return;
            _hasWorldEventBackground = value;
            OnPropertyChangedWithValue(value, nameof(HasWorldEventBackground));
        }
    }

    /// <summary>Tint multiplied with <c>scrollable_field_gradient_9</c> (ARGB).</summary>
    [DataSourceProperty]
    public string SeverityTintColor
    {
        get => _severityTintColor;
        set
        {
            value ??= "#FFFFFFFF";
            if (value == _severityTintColor)
                return;
            _severityTintColor = value;
            OnPropertyChangedWithValue(_severityTintColor, nameof(SeverityTintColor));
        }
    }

    public static InfoGlyphLineVM FromWorldEvent(string skillId, string text, int importance)
    {
        return new InfoGlyphLineVM
        {
            IsSkill = true,
            SkillId = skillId ?? "",
            Text = text ?? "",
            Color = "#C6AC8DFF",
            HasWorldEventBackground = true,
            SeverityTintColor = WorldEventGlyphHelper.GetSeverityTintColor(importance)
        };
    }

    public static InfoGlyphLineVM FromWorldEvent(string skillId, string text, string color = "#C6AC8DFF")
    {
        return new InfoGlyphLineVM
        {
            IsSkill = true,
            SkillId = skillId ?? "",
            Text = text ?? "",
            Color = color ?? "#C6AC8DFF"
        };
    }
}
