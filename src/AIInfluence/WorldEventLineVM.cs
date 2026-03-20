using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>One world-event line: skill icon (by event type) + text.</summary>
public sealed class WorldEventLineVM : ViewModel
{
    [DataSourceProperty] public string SkillId { get; set; } = "";
    [DataSourceProperty] public string Text { get; set; } = "";
    [DataSourceProperty] public string Color { get; set; } = "#C6AC8DFF";

    public WorldEventLineVM(string skillId, string text, string color = "#C6AC8DFF")
    {
        SkillId = skillId ?? "";
        Text = text ?? "";
        Color = color ?? "#C6AC8DFF";
    }
}
