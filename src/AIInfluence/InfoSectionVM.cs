using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>Collapsible block (clan-style section): header row + optional text lines + optional troop rows + optional party food line.</summary>
public class InfoSectionVM : ViewModel
{
    private bool _isExpanded = true;
    private string _headerText = "";
    private string _partyFoodText = "";
    private string _partyFoodColor = "#C6AC8DFF";

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
