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
    [DataSourceProperty] public string SenderColor { get; set; } = "#C6AC8DFF";
    [DataSourceProperty] public string TypeTag     { get; set; } = "";

    // ── Ordered content (speech, emote, action in original sequence) ────────
    [DataSourceProperty] public MBBindingList<ContentSegmentVM> ContentSegments { get; }
        = new MBBindingList<ContentSegmentVM>();

    // ── Alignment ──────────────────────────────────────────────────────────
    [DataSourceProperty] public bool IsPlayer { get; set; } = false;
    [DataSourceProperty] public bool IsNpc    => !IsPlayer;
}
