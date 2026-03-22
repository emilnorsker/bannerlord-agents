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
    private string _backgroundColorLeft = "#00000000";
    private string _backgroundColorRight = "#00000000";
    private bool _hasSplitTintBackground;

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

    /// <summary>Left half of the split-tint underlay (world events).</summary>
    [DataSourceProperty]
    public string BackgroundColorLeft
    {
        get => _backgroundColorLeft;
        set
        {
            value ??= "#00000000";
            if (value == _backgroundColorLeft)
                return;
            _backgroundColorLeft = value;
            OnPropertyChangedWithValue(_backgroundColorLeft, nameof(BackgroundColorLeft));
        }
    }

    /// <summary>Right half of the split-tint underlay (world events).</summary>
    [DataSourceProperty]
    public string BackgroundColorRight
    {
        get => _backgroundColorRight;
        set
        {
            value ??= "#00000000";
            if (value == _backgroundColorRight)
                return;
            _backgroundColorRight = value;
            OnPropertyChangedWithValue(_backgroundColorRight, nameof(BackgroundColorRight));
        }
    }

    /// <summary>True when the row uses the two-tone underlay (50/50 quads), not a continuous gradient.</summary>
    [DataSourceProperty]
    public bool HasSplitTintBackground
    {
        get => _hasSplitTintBackground;
        set
        {
            if (value == _hasSplitTintBackground)
                return;
            _hasSplitTintBackground = value;
            OnPropertyChangedWithValue(value, nameof(HasSplitTintBackground));
        }
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

    public static InfoGlyphLineVM FromWorldEvent(string skillId, string text, string textColor, string backgroundLeft, string backgroundRight)
    {
        return new InfoGlyphLineVM
        {
            IsSkill = true,
            SkillId = skillId ?? "",
            Text = text ?? "",
            Color = textColor ?? "#C6AC8DFF",
            BackgroundColorLeft = backgroundLeft ?? "#00000000",
            BackgroundColorRight = backgroundRight ?? "#00000000",
            HasSplitTintBackground = true
        };
    }
}
