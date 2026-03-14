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

    // ── Right panel ───────────────────────────────────────────────────────
    [DataSourceProperty] public MBBindingList<TextItemVM> WorldEventList { get; } = new MBBindingList<TextItemVM>();
    [DataSourceProperty] public MBBindingList<TextItemVM> KnowledgeList { get; } = new MBBindingList<TextItemVM>();
    [DataSourceProperty] public MBBindingList<TextItemVM> StatList { get; } = new MBBindingList<TextItemVM>();

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
            foreach (var segment in ParseLine(line))
                MessageList.Add(segment);
    }

    private void PopulateRightPanel(Hero npc, NPCContext context)
    {
        // World events
        try
        {
            var events = DynamicEventsManager.Instance?.GetActiveEvents()
                             ?.OrderByDescending(e => e.CreationCampaignDays)
                             .Take(5) ?? Enumerable.Empty<DynamicEvent>();
            foreach (var e in events)
            {
                string text = string.IsNullOrWhiteSpace(e.Title) ? e.Description : e.Title;
                if (!string.IsNullOrWhiteSpace(text))
                    WorldEventList.Add(new TextItemVM(text));
            }
        }
        catch (Exception) { }

        // What we know
        if (!string.IsNullOrWhiteSpace(context?.AIGeneratedPersonality))
            KnowledgeList.Add(new TextItemVM(context.AIGeneratedPersonality));
        foreach (string q in context?.Quirks ?? new System.Collections.Generic.List<string>())
            if (!string.IsNullOrWhiteSpace(q))
                KnowledgeList.Add(new TextItemVM(q));
        foreach (string info in context?.KnownInfo ?? new System.Collections.Generic.List<string>())
            if (!string.IsNullOrWhiteSpace(info))
                KnowledgeList.Add(new TextItemVM(info));

        // Stats
        int rel = (int)npc.GetRelation(Hero.MainHero);
        StatList.Add(new TextItemVM($"Relation: {rel:+#;-#;0}", rel >= 0 ? "#6FCF6FFF" : "#CF6F6FFF"));
        StatList.Add(new TextItemVM($"Trust: {context?.TrustLevel:F0}"));
        StatList.Add(new TextItemVM($"Interactions: {context?.InteractionCount ?? 0}"));
        if (!string.IsNullOrWhiteSpace(context?.EmotionalState?.Mood))
            StatList.Add(new TextItemVM($"Mood: {context.EmotionalState.Mood}"));
    }

    // ── Segment parser ────────────────────────────────────────────────────

    private static readonly Regex EmoteRegex = new Regex(@"\*([^*]+)\*", RegexOptions.Compiled);
    private const string SenderColor = "#C6AC8DFF";

    private IEnumerable<ChatMessageItemVM> ParseLine(string line)
    {
        int colonIdx = line.IndexOf(": ", StringComparison.Ordinal);
        string sender = colonIdx > 0 ? line.Substring(0, colonIdx) : "";
        string content = colonIdx > 0 ? line.Substring(colonIdx + 2) : line;

        // Sender label always first
        if (!string.IsNullOrEmpty(sender))
            yield return new ChatMessageItemVM(sender, SenderColor, "", "#00000000", "sender");

        // Split content into segments preserving order
        int pos = 0;
        foreach (Match m in EmoteRegex.Matches(content))
        {
            // Text before emote
            if (m.Index > pos)
            {
                string speech = content.Substring(pos, m.Index - pos).Trim();
                if (!string.IsNullOrEmpty(speech))
                    yield return new ChatMessageItemVM("", SenderColor, speech, "#1A1A1A99", "speech");
            }
            yield return new ChatMessageItemVM("", "#CF4444FF", m.Value, "#00000000", "emote");
            pos = m.Index + m.Length;
        }
        // Remaining speech after last emote
        if (pos < content.Length)
        {
            string remainder = content.Substring(pos).Trim();
            if (!string.IsNullOrEmpty(remainder))
                yield return new ChatMessageItemVM("", SenderColor, remainder, "#1A1A1A99", "speech");
        }
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
        foreach (var seg in ParseLine($"{playerName}: {message}"))
            MessageList.Add(seg);

        try
        {
            string reply = await AIInfluenceBehavior.Instance.ProcessChatInput(_npc, message);
            if (!string.IsNullOrEmpty(reply))
            {
                string npcName = ((object)_npc?.Name)?.ToString() ?? "NPC";
                foreach (var seg in ParseLine($"{npcName}: {reply}"))
                    MessageList.Add(seg);
            }
        }
        finally
        {
            _isSending = false;
            ((ViewModel)this).OnPropertyChangedWithValue(true, "IsSendEnabled");
        }
    }

    public void ExecuteReturn() => _onReturn?.Invoke();
}
