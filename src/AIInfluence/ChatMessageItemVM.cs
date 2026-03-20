using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One item per conversation turn.
/// ContentSegments preserves the original speech/emote/action interleaving order.
/// </summary>
public class ChatMessageItemVM : ViewModel
{
    // ── Sender row ─────────────────────────────────────────────────────────
    [DataSourceProperty] public string SenderName  { get; set; } = "";
    [DataSourceProperty] public string TypeTag     { get; set; } = "";
    [DataSourceProperty] public string TypeTagColor { get; set; } = "#9BA4B5FF";

    // ── Ordered content (speech, emote, action in original sequence) ────────
    [DataSourceProperty] public MBBindingList<ContentSegmentVM> ContentSegments { get; }
        = new MBBindingList<ContentSegmentVM>();

    // ── Alignment ──────────────────────────────────────────────────────────
    [DataSourceProperty] public bool IsPlayer { get; set; } = false;
    [DataSourceProperty] public bool IsNpc    => !IsPlayer;
}
