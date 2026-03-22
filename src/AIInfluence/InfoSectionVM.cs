using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// Collapsible info block: optional <see cref="TextLines"/> (plain bullets), optional <see cref="GlyphLines"/>
/// (skill icon or formation sprite + text — one list), optional party food line.
/// Call <see cref="RefreshVisibility"/> after mutating lists so Gauntlet <c>IsVisible</c> flags stay consistent.
/// </summary>
public class InfoSectionVM : ViewModel
{
    private bool _isExpanded = true;
    private string _headerText = "";
    private string _partyFoodText = "";
    private string _partyFoodColor = "#C6AC8DFF";
    private string _headerSkillId = DefaultSkills.Charm.StringId;
    private string _sectionPanelColor = "#0C101868";
    private bool _hasGlyphLines;
    private bool _hasStandardTextLines;
    private bool _showPartyFood;

    /// <summary>Background tint for this section block (same subtle value for all sections in <c>RebuildInfoPanelSections</c>).</summary>
    [DataSourceProperty]
    public string SectionPanelColor
    {
        get => _sectionPanelColor;
        set
        {
            if (value == _sectionPanelColor)
                return;
            _sectionPanelColor = value ?? "#0C101868";
            OnPropertyChangedWithValue(_sectionPanelColor, "SectionPanelColor");
        }
    }

    /// <summary>Vanilla skill icon for the section header (SkillIconVisualWidget).</summary>
    [DataSourceProperty]
    public string HeaderSkillId
    {
        get => _headerSkillId;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                value = DefaultSkills.Charm.StringId;
            if (value == _headerSkillId)
                return;
            _headerSkillId = value;
            OnPropertyChangedWithValue(_headerSkillId, nameof(HeaderSkillId));
            OnPropertyChangedWithValue(ShowHeaderSkillIcon, nameof(ShowHeaderSkillIcon));
        }
    }

    [DataSourceProperty]
    public bool ShowHeaderSkillIcon => !string.IsNullOrWhiteSpace(_headerSkillId);

    [DataSourceProperty]
    public string HeaderText
    {
        get => _headerText;
        set
        {
            if (value == _headerText)
                return;
            _headerText = value ?? "";
            OnPropertyChangedWithValue(_headerText, "HeaderText");
        }
    }

    [DataSourceProperty]
    public bool IsExpanded
    {
        get => _isExpanded;
        set
        {
            if (value == _isExpanded)
                return;
            _isExpanded = value;
            OnPropertyChangedWithValue(value, "IsExpanded");
            OnPropertyChangedWithValue(ExpandGlyph, "ExpandGlyph");
        }
    }

    /// <summary>ASCII toggle (Unicode arrows often render as “?” with encyclopedia fonts).</summary>
    [DataSourceProperty] public string ExpandGlyph => IsExpanded ? "v" : ">";

    /// <summary>Plain bullet lines (quests, character history, stats). Not for glyph rows.</summary>
    [DataSourceProperty] public MBBindingList<TextItemVM> TextLines { get; } = new MBBindingList<TextItemVM>();

    /// <summary>World-event skill rows and party formation rows — same row template (left glyph + text).</summary>
    [DataSourceProperty] public MBBindingList<InfoGlyphLineVM> GlyphLines { get; } = new MBBindingList<InfoGlyphLineVM>();

    [DataSourceProperty]
    public bool HasGlyphLines
    {
        get => _hasGlyphLines;
        set
        {
            if (value == _hasGlyphLines)
                return;
            _hasGlyphLines = value;
            OnPropertyChangedWithValue(value, nameof(HasGlyphLines));
        }
    }

    /// <summary>True when <see cref="TextLines"/> has at least one row (after <see cref="RefreshVisibility"/>).</summary>
    [DataSourceProperty]
    public bool HasStandardTextLines
    {
        get => _hasStandardTextLines;
        set
        {
            if (value == _hasStandardTextLines)
                return;
            _hasStandardTextLines = value;
            OnPropertyChangedWithValue(value, nameof(HasStandardTextLines));
        }
    }

    [DataSourceProperty]
    public bool ShowPartyFood
    {
        get => _showPartyFood;
        set
        {
            if (value == _showPartyFood)
                return;
            _showPartyFood = value;
            OnPropertyChangedWithValue(value, nameof(ShowPartyFood));
        }
    }

    [DataSourceProperty]
    public string PartyFoodText
    {
        get => _partyFoodText;
        set
        {
            if (value == _partyFoodText)
                return;
            _partyFoodText = value ?? "";
            OnPropertyChangedWithValue(_partyFoodText, "PartyFoodText");
        }
    }

    [DataSourceProperty]
    public string PartyFoodColor
    {
        get => _partyFoodColor;
        set
        {
            if (value == _partyFoodColor)
                return;
            _partyFoodColor = value ?? "#C6AC8DFF";
            OnPropertyChangedWithValue(_partyFoodColor, "PartyFoodColor");
        }
    }

    /// <summary>
    /// Syncs visibility flags from list counts and party-food text. Call after building or editing a section.
    /// </summary>
    public void RefreshVisibility()
    {
        HasGlyphLines = GlyphLines.Count > 0;
        HasStandardTextLines = TextLines.Count > 0;
        ShowPartyFood = ShowPartyFood && !string.IsNullOrWhiteSpace(PartyFoodText);
    }

    public void ExecuteToggle() => IsExpanded = !IsExpanded;
}
