using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AIInfluence.DynamicEvents;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace AIInfluence;

public class NpcChatWindowVM : ViewModel
{
    private readonly Hero _npc;
    private readonly Action _onReturn;
    private string _inputText = "";
    private bool _isSending;

    // ── Header ────────────────────────────────────────────────────────────
    [DataSourceProperty] public string NpcName { get; set; } = "";
    [DataSourceProperty] public string NpcTitle { get; set; } = "";

    // ── Left panel trait overlay ──────────────────────────────────────────
    [DataSourceProperty] public string RelationText { get; set; } = "";
    [DataSourceProperty] public string RelationColor { get; set; } = "#FFFFFFFF";
    [DataSourceProperty] public string TrustLabel { get; set; } = "";
    [DataSourceProperty] public string EmotionLabel { get; set; } = "";

    // ── Center ────────────────────────────────────────────────────────────
    [DataSourceProperty] public MBBindingList<ChatMessageItemVM> MessageList { get; } = new MBBindingList<ChatMessageItemVM>();

    [DataSourceProperty]
    public string InputText
    {
        get => _inputText;
        set
        {
            if (value != _inputText)
            {
                _inputText = value;
                ((ViewModel)this).OnPropertyChangedWithValue<string>(value, "InputText");
            }
        }
    }

    [DataSourceProperty]
    public bool IsSendEnabled
    {
        get => !_isSending;
        set { }
    }

    // ── Right panel – flat list, section headers included as items ────────
    [DataSourceProperty] public MBBindingList<TextItemVM> RightPanelItems { get; } = new MBBindingList<TextItemVM>();

    public NpcChatWindowVM(Hero npc, NPCContext context, Action onReturn)
    {
        _npc = npc;
        _onReturn = onReturn;
        PopulateHeader(npc);
        PopulateTraitOverlay(npc, context);
        PopulateHistory(context);
        PopulateRightPanel(npc, context);
    }

    // ── Populate ──────────────────────────────────────────────────────────

    private void PopulateHeader(Hero npc)
    {
        NpcName = ((object)npc.Name)?.ToString() ?? "Unknown";
        string clan = ((object)npc.Clan?.Name)?.ToString() ?? "";
        string occupation = npc.IsLord ? "Lord" : npc.IsWanderer ? "Wanderer" : npc.IsMerchant ? "Merchant" : "";
        NpcTitle = string.IsNullOrEmpty(clan) ? occupation : (string.IsNullOrEmpty(occupation) ? clan : $"{occupation} of {clan}");
    }

    private void PopulateTraitOverlay(Hero npc, NPCContext context)
    {
        int relation = (int)npc.GetRelation(Hero.MainHero);
        string label = relation >= 20 ? "Friendly" : relation >= 0 ? "Neutral" : relation >= -20 ? "Cautious" : "Hostile";
        RelationText = $"{label} ({relation:+#;-#;0})";
        RelationColor = relation >= 0 ? "#6FCF6FFF" : "#CF6F6FFF";
        TrustLabel = context.TrustLevel >= 60 ? "High Trust" : context.TrustLevel >= 30 ? "Moderate Trust" : "Low Trust";
        EmotionLabel = context.EmotionalState?.Mood ?? "";
    }

    private void PopulateHistory(NPCContext context)
    {
        if (context?.ConversationHistory == null) return;
        var history = context.ConversationHistory;
        int skip = Math.Max(0, history.Count - 10);
        foreach (string line in history.Skip(skip))
            MessageList.Add(ParseLine(line));
    }

    private void PopulateRightPanel(Hero npc, NPCContext context)
    {
        const string Header = "#888888FF";

        RightPanelItems.Add(new TextItemVM("WORLD EVENTS", Header));
        try
        {
            var events = DynamicEventsManager.Instance?.GetActiveEvents()
                             ?.OrderByDescending(e => e.CreationCampaignDays)
                             .Take(5) ?? Enumerable.Empty<DynamicEvent>();
            foreach (var e in events)
            {
                string text = string.IsNullOrWhiteSpace(e.Title) ? e.Description : e.Title;
                if (!string.IsNullOrWhiteSpace(text))
                    RightPanelItems.Add(new TextItemVM("• " + text));
            }
        }
        catch (Exception) { }

        RightPanelItems.Add(new TextItemVM(" ", "#00000000"));
        RightPanelItems.Add(new TextItemVM("WHAT WE KNOW", Header));
        if (!string.IsNullOrWhiteSpace(context?.AIGeneratedPersonality))
            RightPanelItems.Add(new TextItemVM("• " + context.AIGeneratedPersonality));
        foreach (string q in context?.Quirks ?? new List<string>())
            if (!string.IsNullOrWhiteSpace(q))
                RightPanelItems.Add(new TextItemVM("• " + q));
        foreach (string info in context?.KnownInfo ?? new List<string>())
            if (!string.IsNullOrWhiteSpace(info))
                RightPanelItems.Add(new TextItemVM("• " + info));

        int rel = (int)npc.GetRelation(Hero.MainHero);
        RightPanelItems.Add(new TextItemVM(" ", "#00000000"));
        RightPanelItems.Add(new TextItemVM("CHARACTER", Header));
        RightPanelItems.Add(new TextItemVM($"Relation: {rel:+#;-#;0}", rel >= 0 ? "#6FCF6FFF" : "#CF6F6FFF"));
        RightPanelItems.Add(new TextItemVM($"Trust: {context?.TrustLevel:F0}"));
        RightPanelItems.Add(new TextItemVM($"Interactions: {context?.InteractionCount ?? 0}"));
        if (!string.IsNullOrWhiteSpace(context?.EmotionalState?.Mood))
            RightPanelItems.Add(new TextItemVM($"Mood: {context.EmotionalState.Mood}"));
    }

    // ── Segment parser ────────────────────────────────────────────────────

    private static readonly Regex EmoteRegex = new Regex(@"\*([^*]+)\*", RegexOptions.Compiled);
    private const string NameColor        = "#C6AC8DFF";
    private const string SpeechTextColor  = "#E8DCC8FF";
    private const string NpcBubbleColor   = "#0D1118D0"; // dark blue-grey for NPC speech
    private const string PlayerBubbleColor = "#000000D0"; // darker for player speech
    private const string EmoteColor       = "#CF4444FF";
    private const string ActionColor      = "#9B59B6FF";

    private bool IsPlayerSender(string sender)
    {
        if (string.IsNullOrEmpty(sender)) return false;
        string playerName = ((object)Hero.MainHero?.Name)?.ToString() ?? "";
        return sender.Equals(playerName, StringComparison.OrdinalIgnoreCase)
            || sender.Equals("Player", StringComparison.OrdinalIgnoreCase)
            || sender.Equals("You", StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Produces ONE ChatMessageItemVM per conversation turn.
    /// ContentSegments preserves the original speech/emote interleaving order.
    /// </summary>
    private ChatMessageItemVM ParseLine(string line, string typeTag = "")
    {
        int colonIdx = line.IndexOf(": ", StringComparison.Ordinal);
        string sender  = colonIdx > 0 ? line.Substring(0, colonIdx) : "";
        string content = colonIdx > 0 ? line.Substring(colonIdx + 2) : line;

        bool   isPlayer    = IsPlayerSender(sender);
        string bubbleColor = isPlayer ? PlayerBubbleColor : NpcBubbleColor;

        var item = new ChatMessageItemVM
        {
            SenderName  = sender,
            SenderColor = NameColor,
            TypeTag     = isPlayer ? "" : typeTag,
            IsPlayer    = isPlayer
        };

        // Walk content left to right, preserving speech/emote order
        int pos = 0;
        foreach (Match m in EmoteRegex.Matches(content))
        {
            if (m.Index > pos)
            {
                string speech = content.Substring(pos, m.Index - pos).Trim();
                if (!string.IsNullOrEmpty(speech))
                    item.ContentSegments.Add(new ContentSegmentVM(speech, SpeechTextColor, bubbleColor));
            }
            item.ContentSegments.Add(new ContentSegmentVM(m.Value, EmoteColor, "#00000000"));
            pos = m.Index + m.Length;
        }
        if (pos < content.Length)
        {
            string remainder = content.Substring(pos).Trim();
            if (!string.IsNullOrEmpty(remainder))
                item.ContentSegments.Add(new ContentSegmentVM(remainder, SpeechTextColor, bubbleColor));
        }

        return item;
    }

    private static string BuildActionText(AIResponse r)
    {
        if (r == null) return "";
        var parts = new List<string>();
        if (r.MoneyTransfer != null && r.MoneyTransfer.Amount != 0)
            parts.Add($"[Transferred {Math.Abs(r.MoneyTransfer.Amount)} gold]");
        if (r.ItemTransfers?.Count > 0)
            parts.Add($"[Transferred {r.ItemTransfers.Count} item(s)]");
        if (!string.IsNullOrEmpty(r.QuestAction?.Action))
            parts.Add($"[Quest: {r.QuestAction.Action}]");
        if (!string.IsNullOrEmpty(r.Decision) && r.Decision != "none" && r.Decision != "none\n")
            parts.Add($"[{r.Decision}]");
        return string.Join(" ", parts);
    }

    // ── Commands ──────────────────────────────────────────────────────────

    public void OnTextChanged(string newText) => _inputText = newText;

    public async void ExecuteSendMessage()
    {
        string message = _inputText?.Trim();
        if (string.IsNullOrEmpty(message) || _isSending) return;

        _isSending = true;
        ((ViewModel)this).OnPropertyChangedWithValue(false, "IsSendEnabled");
        InputText = "";

        string playerName = ((object)Hero.MainHero?.Name)?.ToString() ?? "You";

        try
        {
            MessageList.Add(ParseLine($"{playerName}: {message}"));

            if (AIInfluenceBehavior.Instance == null) return;
            string reply = await AIInfluenceBehavior.Instance.ProcessChatInput(_npc, message);
            if (!string.IsNullOrEmpty(reply))
            {
                string npcName = ((object)_npc?.Name)?.ToString() ?? "NPC";

                // Call GetOrCreateNPCContext once — avoids two off-thread calls and a
                // race with the main game tick that could mutate the context dictionary.
                AIResponse pendingResponse = null;
                try { pendingResponse = AIInfluenceBehavior.Instance?.GetOrCreateNPCContext(_npc)?.PendingAIResponse; }
                catch (Exception) { }

                string tone = pendingResponse?.Tone ?? "";

                // UI list mutations after await may run on a thread-pool thread.
                // Wrap to prevent a threading exception from leaking past the finally block.
                try
                {
                    await RunOnMainThread(() =>
                    {
                        var npcItem = ParseLine($"{npcName}: {reply}", tone);
                        string actionText = BuildActionText(pendingResponse);
                        if (!string.IsNullOrEmpty(actionText))
                            npcItem.ContentSegments.Add(new ContentSegmentVM(actionText, ActionColor, "#00000000"));
                        MessageList.Add(npcItem);
                    });
                }
                catch (Exception) { }
            }
        }
        finally
        {
            await RunOnMainThread(() =>
            {
                _isSending = false;
                ((ViewModel)this).OnPropertyChangedWithValue(true, "IsSendEnabled");
            });
        }
    }

    public void ExecuteReturn() => _onReturn?.Invoke();

    private static Task RunOnMainThread(Action action)
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        AIInfluence.Services.TtsLipSyncService.MainThreadQueue.Enqueue(delegate
        {
            try { action(); tcs.TrySetResult(true); }
            catch (Exception ex) { tcs.TrySetException(ex); }
        });
        return tcs.Task;
    }
}
