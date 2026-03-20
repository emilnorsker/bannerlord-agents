using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>Collapsible block (clan-style section): header row + optional text lines + optional troop rows + optional party food line.</summary>
public class InfoSectionVM : ViewModel
{
    private bool _isExpanded = true;
    private string _headerText = "";
    private string _partyFoodText = "";
    private string _partyFoodColor = "#C6AC8DFF";
    private string _sectionPanelColor = "#121820F0";

    /// <summary>Background tint for this section block (alternates top→bottom when the info panel is rebuilt).</summary>
    [DataSourceProperty]
    public string SectionPanelColor
    {
        get => _sectionPanelColor;
        set
        {
            if (value == _sectionPanelColor)
                return;
            _sectionPanelColor = value ?? "#121820F0";
            OnPropertyChangedWithValue(_sectionPanelColor, "SectionPanelColor");
        }
    }

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

    [DataSourceProperty] public string ExpandGlyph => IsExpanded ? "▼" : "▶";

    [DataSourceProperty] public MBBindingList<TextItemVM> TextLines { get; } = new MBBindingList<TextItemVM>();
    [DataSourceProperty] public MBBindingList<PartyTroopRowVM> TroopRows { get; } = new MBBindingList<PartyTroopRowVM>();
    [DataSourceProperty] public MBBindingList<WorldEventLineVM> WorldEventLines { get; } = new MBBindingList<WorldEventLineVM>();

    /// <summary>When false, only <c>WorldEventLines</c> is shown (world events with skill icons).</summary>
    [DataSourceProperty] public bool HasStandardTextLines { get; set; } = true;
    [DataSourceProperty] public bool HasWorldEventLines { get; set; }

    [DataSourceProperty] public bool HasTroopRows { get; set; }
    [DataSourceProperty] public bool ShowPartyFood { get; set; }

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

    public void ExecuteToggle() => IsExpanded = !IsExpanded;
}
