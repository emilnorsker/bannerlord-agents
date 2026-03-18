using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AIInfluence.Diplomacy;
using AIInfluence.DynamicEvents;
using AIInfluence.Services;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

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

    private int _characterSectionStartIndex;

    private void AddNewestMessage(ChatMessageItemVM item) => MessageList.Add(item);

    public NpcChatWindowVM(Hero npc, NPCContext context, Action onReturn)
    {
        _npc = npc ?? throw new ArgumentNullException(nameof(npc));
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
        float trust = context?.TrustLevel ?? 0f;
        TrustLabel = trust >= 0.6f ? "High Trust" : trust >= 0.3f ? "Moderate Trust" : "Low Trust";
        EmotionLabel = context?.EmotionalState?.Mood ?? "";
    }

    private void RefreshTraitOverlay(Hero npc, NPCContext context)
    {
        PopulateTraitOverlay(npc, context);
        ((ViewModel)this).OnPropertyChangedWithValue<string>(RelationText, "RelationText");
        ((ViewModel)this).OnPropertyChangedWithValue<string>(RelationColor, "RelationColor");
        ((ViewModel)this).OnPropertyChangedWithValue<string>(TrustLabel, "TrustLabel");
        ((ViewModel)this).OnPropertyChangedWithValue<string>(EmotionLabel, "EmotionLabel");
    }

    private void PopulateHistory(NPCContext context)
    {
        if (context?.ConversationHistory == null) return;
        var history = context.ConversationHistory;
        int skip = Math.Max(0, history.Count - 10);
        foreach (string line in history.Skip(skip))
            AddNewestMessage(ParseLine(line));
    }

    private void PopulateRightPanel(Hero npc, NPCContext context)
    {
        const string Header = "#888888FF";

        RightPanelItems.Add(new TextItemVM("WORLD EVENTS", Header));
        try
        {
            var events = GetMergedEvents().OrderByDescending(e => e.CreationCampaignDays).Take(5);
            foreach (var e in events)
            {
                string text = string.IsNullOrWhiteSpace(e.Title) ? e.Description : e.Title;
                if (!string.IsNullOrWhiteSpace(text))
                    RightPanelItems.Add(new TextItemVM("• " + text));
            }
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] PopulateRightPanel DynamicEvents failed: " + ex.Message);
        }

        RightPanelItems.Add(new TextItemVM(" ", "#00000000"));
        RightPanelItems.Add(new TextItemVM("WHAT WE KNOW", Header));
        bool hasWhatWeKnow = false;
        if (!string.IsNullOrWhiteSpace(context?.AIGeneratedPersonality))
        {
            RightPanelItems.Add(new TextItemVM("• " + context.AIGeneratedPersonality));
            hasWhatWeKnow = true;
        }
        foreach (string q in context?.Quirks ?? new List<string>())
        {
            if (!string.IsNullOrWhiteSpace(q))
            {
                RightPanelItems.Add(new TextItemVM("• " + q));
                hasWhatWeKnow = true;
            }
        }
        if (!string.IsNullOrWhiteSpace(context?.AIGeneratedSpeechQuirks))
        {
            RightPanelItems.Add(new TextItemVM("• " + context.AIGeneratedSpeechQuirks));
            hasWhatWeKnow = true;
        }
        foreach (var info in ResolveKnownInfo(context, npc))
        {
            RightPanelItems.Add(new TextItemVM("• " + info));
            hasWhatWeKnow = true;
        }
        if (!hasWhatWeKnow)
            RightPanelItems.Add(new TextItemVM("• Personality not yet discovered", "#888888FF"));

        RightPanelItems.Add(new TextItemVM(" ", "#00000000"));
        _characterSectionStartIndex = RightPanelItems.Count;
        AddQuestSectionItems(context);
        AddCharacterSectionItems(npc, context);
    }

    private void AddQuestSectionItems(NPCContext context)
    {
        const string Header = "#888888FF";
        const string QuestColor = "#D0A96BFF";
        RightPanelItems.Add(new TextItemVM("QUEST", Header));
        if (context == null)
        {
            RightPanelItems.Add(new TextItemVM("• No active quest with this character", Header));
            return;
        }
        var questSources = new (IEnumerable<AIQuestInfo> source, Func<AIQuestInfo, string> format)[]
        {
            (OrEmpty(context.ActiveAIQuests), FormatActiveQuestLine),
            (OrEmpty(context.IncomingAIQuests), FormatIncomingQuestLine)
        };
        var all = questSources.SelectMany(s => s.source.Where(IsValidQuest).Select(q => (quest: q, formatter: s.format)));
        var lines = all.GroupBy(x => x.quest.QuestId).Select(g => { var f = g.First(); return f.formatter(f.quest); }).ToList();
        if (lines.Count == 0)
            RightPanelItems.Add(new TextItemVM("• No active quest with this character", Header));
        else
            foreach (var line in lines)
                RightPanelItems.Add(new TextItemVM(line, QuestColor));
    }

    private static IEnumerable<AIQuestInfo> OrEmpty(IList<AIQuestInfo> list) => list ?? Enumerable.Empty<AIQuestInfo>();
    private static bool IsValidQuest(AIQuestInfo q) => q != null && !string.IsNullOrWhiteSpace(q.Title) && IsQuestStillOngoing(q.QuestId);
    private static bool IsQuestStillOngoing(string questId) =>
        !string.IsNullOrEmpty(questId) && Campaign.Current?.QuestManager?.Quests?.Any(q => ((MBObjectBase)q).StringId == questId && q.IsOngoing) == true;
    private static string FormatActiveQuestLine(AIQuestInfo q)
    {
        if (q.ProgressTarget <= 0) return $"• {q.Title}";
        int current = Math.Max(0, Math.Min(q.ProgressCurrent, q.ProgressTarget));
        string label = string.IsNullOrWhiteSpace(q.ProgressLabel) ? "" : $" {q.ProgressLabel}";
        return $"• {q.Title} ({current}/{q.ProgressTarget}{label})";
    }
    private static string FormatIncomingQuestLine(AIQuestInfo q) => $"• {q.Title} (deliver here)";

    private static IEnumerable<string> ResolveKnownInfo(NPCContext context, Hero npc)
    {
        if (context?.KnownInfo == null || !context.KnownInfo.Any()) yield break;
        var infos = WorldInfoManager.InformationManager.Instance?.GetInfo();
        if (infos == null) yield break;
        string npcName = ((object)npc?.Name)?.ToString() ?? "";
        foreach (var i in infos.Where(i => !string.IsNullOrEmpty(i?.Id) && context.KnownInfo.Contains(i.Id)))
        {
            if (string.IsNullOrWhiteSpace(i.Description)) continue;
            yield return i.Description.Replace("{character}", npcName).Trim();
        }
    }

    private static List<DynamicEvent> GetMergedEvents()
    {
        var list = DynamicEventsManager.Instance?.GetActiveEvents() ?? new List<DynamicEvent>();
        List<DynamicEvent> diplomatic = new List<DynamicEvent>();
        try
        {
            var storage = new DiplomacyStorage();
            diplomatic = storage.LoadDiplomaticEvents() ?? new List<DynamicEvent>();
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] LoadDiplomaticEvents failed: " + ex.Message);
        }
        var merged = new List<DynamicEvent>();
        var seen = new HashSet<string>();
        foreach (var e in list)
        {
            if (e == null) continue;
            merged.Add(e);
            if (!string.IsNullOrEmpty(e.Id)) seen.Add(e.Id);
        }
        foreach (var e in diplomatic)
        {
            if (e != null && !string.IsNullOrEmpty(e.Id) && !seen.Contains(e.Id))
            {
                merged.Add(e);
                seen.Add(e.Id);
            }
        }
        return merged;
    }

    private void AddCharacterSectionItems(Hero npc, NPCContext context)
    {
        const string Header = "#888888FF";
        RightPanelItems.Add(new TextItemVM("CHARACTER", Header));
        int rel = (int)npc.GetRelation(Hero.MainHero);
        RightPanelItems.Add(new TextItemVM($"Relation: {rel:+#;-#;0}", rel >= 0 ? "#6FCF6FFF" : "#CF6F6FFF"));
        RightPanelItems.Add(new TextItemVM($"Trust: {(context?.TrustLevel ?? 0f) * 100f:F0}%"));
        RightPanelItems.Add(new TextItemVM($"Interactions: {context?.InteractionCount ?? 0}"));
        if (!string.IsNullOrWhiteSpace(context?.EmotionalState?.Mood))
            RightPanelItems.Add(new TextItemVM($"Mood: {context.EmotionalState.Mood}"));
    }

    private void RefreshCharacterSection(Hero npc, NPCContext context)
    {
        while (RightPanelItems.Count > _characterSectionStartIndex)
            RightPanelItems.RemoveAt(RightPanelItems.Count - 1);
        try
        {
            AddQuestSectionItems(context);
            AddCharacterSectionItems(npc, context);
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] RefreshCharacterSection failed: " + ex.Message);
            try { AddCharacterSectionItems(npc, context); } catch (Exception ex2) { AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] RefreshCharacterSection fallback failed: " + ex2.Message); }
        }
    }

    // ── Segment parser ────────────────────────────────────────────────────

    private static readonly Regex EmoteRegex = new Regex(@"\*([^*]+)\*", RegexOptions.Compiled);
    private const string NameColor        = "#C6AC8DFF";
    private const string SpeechTextColor  = "#E8DCC8FF";
    private const string NpcBubbleColor   = "#0D1118D0"; // dark blue-grey for NPC speech
    private const string PlayerBubbleColor = "#000000D0"; // darker for player speech
    private const string EmoteColor         = "#9B59B6FF";  // purple
    private const string ActionColor        = "#FFD700FF";  // golden
    private const string ActionBubbleColor  = "#3D2E1AE8";  // dark gold tint
    private const string RelationMessageColor = "#5B9BD5FF";  // blue
    private const string RelationBubbleColor  = "#1A2D3DE8";  // dark blue tint

    private bool IsPlayerSender(string sender)
    {
        if (string.IsNullOrEmpty(sender)) return false;
        string playerName = ((object)Hero.MainHero?.Name)?.ToString() ?? "";
        return sender.Equals(playerName, StringComparison.OrdinalIgnoreCase)
            || sender.Equals("Player", StringComparison.OrdinalIgnoreCase)
            || sender.Equals("You", StringComparison.OrdinalIgnoreCase);
    }

    private static string ResolveTypeTagColor(string typeTag)
    {
        string tone = (typeTag ?? "").Trim().ToLowerInvariant();
        return tone switch
        {
            "friendly" => "#6FCF6FFF",
            "hostile" or "angry" => "#CF6F6FFF",
            "cautious" => "#D0A96BFF",
            "neutral" => "#9BA4B5FF",
            _ => "#B6BDD0FF"
        };
    }

    /// <summary>
    /// Produces ONE ChatMessageItemVM per conversation turn.
    /// ContentSegments preserves the original speech/emote interleaving order.
    /// Supports persisted action pills: "Sender: content\n---\naction" format.
    /// </summary>
    private ChatMessageItemVM ParseLine(string line, string typeTag = "")
    {
        string actionSuffix = null;
        string relSuffix = null;
        int delimIdx = line.IndexOf(ActionDelim, StringComparison.Ordinal);
        if (delimIdx >= 0)
        {
            string rest = line.Substring(delimIdx + ActionDelim.Length);
            line = line.Substring(0, delimIdx);
            int relIdx = rest.IndexOf(RelationDelim, StringComparison.Ordinal);
            if (relIdx >= 0)
            {
                actionSuffix = rest.Substring(0, relIdx).Trim();
                relSuffix = rest.Substring(relIdx + RelationDelim.Length).Trim();
            }
            else
            {
                actionSuffix = rest.Trim();
            }
        }
        else
        {
            int relIdx = line.IndexOf(RelationDelim, StringComparison.Ordinal);
            if (relIdx >= 0)
            {
                relSuffix = line.Substring(relIdx + RelationDelim.Length).Trim();
                line = line.Substring(0, relIdx);
            }
        }

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
            TypeTagColor = isPlayer ? "#00000000" : ResolveTypeTagColor(typeTag),
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
            string emoteText = m.Groups[1].Value;  // strip asterisks: *text* -> text
            item.ContentSegments.Add(new ContentSegmentVM(emoteText, EmoteColor, bubbleColor, isPill: true));
            pos = m.Index + m.Length;
        }
        if (pos < content.Length)
        {
            string remainder = content.Substring(pos).Trim();
            if (!string.IsNullOrEmpty(remainder))
                item.ContentSegments.Add(new ContentSegmentVM(remainder, SpeechTextColor, bubbleColor));
        }

        if (!string.IsNullOrEmpty(actionSuffix))
            item.ContentSegments.Add(new ContentSegmentVM(actionSuffix, ActionColor, ActionBubbleColor, isPill: true));
        if (!string.IsNullOrEmpty(relSuffix))
            item.ContentSegments.Add(new ContentSegmentVM(relSuffix, RelationMessageColor, RelationBubbleColor, isPill: true));

        return item;
    }

    private void ReplaceStreamingSegments(ChatMessageItemVM targetItem, string npcName, string partialText)
    {
        if (targetItem == null) return;
        var parsed = ParseLine($"{npcName}: {partialText ?? ""}", "");
        while (targetItem.ContentSegments.Count > 0)
            targetItem.ContentSegments.RemoveAt(targetItem.ContentSegments.Count - 1);
        foreach (var segment in parsed.ContentSegments)
            targetItem.ContentSegments.Add(segment);
        if (targetItem.ContentSegments.Count == 0)
            targetItem.ContentSegments.Add(new ContentSegmentVM("", SpeechTextColor, NpcBubbleColor));
    }

    private const string ActionDelim   = "\n---\n";
    private const string RelationDelim = "\n===\n";

    private static string GetRelationChangeMessage(AIResponse r, NPCContext ctx, string npcName)
    {
        var rel = ctx?.PendingRelationChange;
        if (!string.IsNullOrEmpty(rel?.Message))
            return rel.Message;
        var lie = ctx?.PendingLiePenalty;
        if (!string.IsNullOrEmpty(lie?.Message))
            return lie.Message;
        if (r?.SuspectedLie == true)
            return $"Your relations with {npcName} have worsened due to suspicions of lying.";
        string t = (r?.Tone ?? "").Trim().ToLowerInvariant();
        if (t == "positive")
            return $"Your relations with {npcName} have improved due to your friendly tone.";
        if (t == "negative")
            return $"Your relations with {npcName} have worsened due to your aggressive tone.";
        return "";
    }

    private static string BuildPlayerActionText(AIResponse r)
    {
        if (r == null) return "";
        var parts = new List<string>();
        if (r.MoneyTransfer != null && r.MoneyTransfer.Amount != 0 && string.Equals(r.MoneyTransfer.Action, "receive", StringComparison.OrdinalIgnoreCase))
            parts.Add($"Transferred {Math.Abs(r.MoneyTransfer.Amount)} gold");
        if (r.ItemTransfers?.Count > 0 && r.ItemTransfers.Any(t => string.Equals(t.Action, "take", StringComparison.OrdinalIgnoreCase)))
            parts.Add($"Transferred {r.ItemTransfers.Count(t => string.Equals(t.Action, "take", StringComparison.OrdinalIgnoreCase))} item(s)");
        return string.Join(" ", parts);
    }

    private static string BuildNpcActionText(AIResponse r, NPCContext ctx)
    {
        if (r == null) return "";
        var parts = new List<string>();
        if (r.MoneyTransfer != null && r.MoneyTransfer.Amount != 0 && string.Equals(r.MoneyTransfer.Action, "give", StringComparison.OrdinalIgnoreCase))
            parts.Add($"Transferred {Math.Abs(r.MoneyTransfer.Amount)} gold");
        if (r.ItemTransfers?.Count > 0 && r.ItemTransfers.Any(t => string.Equals(t.Action, "give", StringComparison.OrdinalIgnoreCase)))
            parts.Add($"Transferred {r.ItemTransfers.Count(t => string.Equals(t.Action, "give", StringComparison.OrdinalIgnoreCase))} item(s)");
        if (!string.IsNullOrEmpty(r.QuestAction?.Action))
            parts.Add($"Quest: {r.QuestAction.Action}");
        if (!string.IsNullOrEmpty(r.Decision) && r.Decision != "none" && r.Decision != "none\n")
            parts.Add(r.Decision.Trim());
        string techAction = ctx?.LastTechnicalActionForDisplay;
        if (!string.IsNullOrEmpty(techAction) && !techAction.Equals("none", StringComparison.OrdinalIgnoreCase))
        {
            foreach (string action in techAction.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] segs = action.Trim().Split(new[] { ':' }, 2);
                string name = segs[0].Trim();
                string payload = segs.Length > 1 ? segs[1].Trim() : "";
                bool isStop = payload.Equals("STOP", StringComparison.OrdinalIgnoreCase);
                if (isStop)
                    parts.Add($"Stopped {name}");
                else if (name.Equals("follow_player", StringComparison.OrdinalIgnoreCase))
                    parts.Add("Now following you");
                else if (name.Equals("return_to_player", StringComparison.OrdinalIgnoreCase))
                    parts.Add("Returning to you");
                else if (name.Equals("go_to_settlement", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(payload))
                    parts.Add($"Traveling to {payload.Split(':')[0]}");
                else if (!string.IsNullOrEmpty(name))
                    parts.Add(name);
            }
        }
        if (!string.IsNullOrEmpty(r.RomanceIntent) && !r.RomanceIntent.Equals("none", StringComparison.OrdinalIgnoreCase))
        {
            string ri = r.RomanceIntent.Trim().ToLowerInvariant();
            if (ri == "flirt") parts.Add("Accepted your flirtation");
            else if (ri == "romance") parts.Add("Accepted your courtship");
            else if (ri == "proposal") parts.Add("Marriage proposal");
            else parts.Add($"Romance: {r.RomanceIntent}");
        }
        if (!string.IsNullOrEmpty(r.WorkshopAction) && r.WorkshopAction.Equals("sell", StringComparison.OrdinalIgnoreCase))
            parts.Add("Sold workshop to you");
        if (!string.IsNullOrEmpty(r.KingdomAction) && !r.KingdomAction.Equals("none", StringComparison.OrdinalIgnoreCase))
            parts.Add($"Kingdom: {r.KingdomAction}");
        return string.Join(" ", parts);
    }

    // ── Commands ──────────────────────────────────────────────────────────

    public void OnTextChanged(string newText)
    {
        if (newText != _inputText)
        {
            _inputText = newText ?? "";
            ((ViewModel)this).OnPropertyChangedWithValue<string>(_inputText, "InputText");
        }
    }

    public async void ExecuteSendMessage()
    {
        string message = _inputText?.Trim();
        if (string.IsNullOrEmpty(message) || _isSending) return;

        _isSending = true;
        ((ViewModel)this).OnPropertyChangedWithValue(false, "IsSendEnabled");

        string playerName = ((object)Hero.MainHero?.Name)?.ToString() ?? "You";

        try
        {
            if (AIInfluenceBehavior.Instance == null)
                return;
            InputText = "";
            var playerMessageItem = ParseLine($"{playerName}: {message}");
            AddNewestMessage(playerMessageItem);
            string npcName = ((object)_npc?.Name)?.ToString() ?? "NPC";

            // Capture the slot index where ProcessChatInput will append the player message.
            int playerHistoryIdx = -1;
            try
            {
                var preCtx = AIInfluenceBehavior.Instance.GetOrCreateNPCContext(_npc);
                playerHistoryIdx = preCtx?.ConversationHistory?.Count ?? -1;
            }
            catch (Exception) { }
            bool useOpenRouterStreaming = string.Equals(GlobalSettings<ModSettings>.Instance?.AIBackend?.SelectedValue, "OpenRouter", StringComparison.Ordinal);
            ChatMessageItemVM streamingItem = null;
            bool streamingRetired = false;
            string streamingTargetText = "";
            string streamingVisibleText = "";
            bool streamPumpActive = false;
            Action streamPumpStep = null;
            // Set by the reply handler; the pump calls this once the typewriter animation reaches
            // the final target text so the message is only swapped out after the full animation.
            Action finalizeNpcMessage = null;
            if (useOpenRouterStreaming)
            {
                streamingItem = ParseLine($"{npcName}: ", "");
                streamingItem.ContentSegments.Add(new ContentSegmentVM("", SpeechTextColor, NpcBubbleColor));
                AddNewestMessage(streamingItem);
                streamPumpStep = () =>
                {
                    if (streamingRetired || streamingItem == null)
                    {
                        streamPumpActive = false;
                        return;
                    }
                    if (streamingVisibleText.Length < streamingTargetText.Length)
                    {
                        streamingVisibleText = streamingTargetText.Substring(0, streamingVisibleText.Length + 1);
                        ReplaceStreamingSegments(streamingItem, npcName, streamingVisibleText);
                        DelayedTaskManager taskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
                        if (taskManager != null)
                        {
                            double revealInterval = Math.Max(0.005f, GlobalSettings<ModSettings>.Instance?.ChatStreamCharacterInterval ?? 0.05f);
                            taskManager.AddTask(revealInterval, streamPumpStep);
                        }
                        else
                        {
                            streamingVisibleText = streamingTargetText;
                            ReplaceStreamingSegments(streamingItem, npcName, streamingVisibleText);
                            streamPumpActive = false;
                            Action fin = finalizeNpcMessage;
                            finalizeNpcMessage = null;
                            fin?.Invoke();
                        }
                    }
                    else if (streamingVisibleText.Length > streamingTargetText.Length)
                    {
                        streamingVisibleText = streamingTargetText;
                        ReplaceStreamingSegments(streamingItem, npcName, streamingVisibleText);
                    }
                    else // visible == target: animation complete
                    {
                        streamPumpActive = false;
                        Action fin = finalizeNpcMessage;
                        finalizeNpcMessage = null;
                        fin?.Invoke();
                    }
                };
            }
            string reply = await AIInfluenceBehavior.Instance.ProcessChatInput(_npc, message, partial =>
            {
                TtsLipSyncService.MainThreadQueue.Enqueue(() =>
                {
                    if (!streamingRetired && streamingItem != null)
                    {
                        streamingTargetText = partial ?? "";
                        if (!streamPumpActive && streamPumpStep != null)
                        {
                            streamPumpActive = true;
                            streamPumpStep();
                        }
                    }
                });
            });
            if (!string.IsNullOrEmpty(reply))
            {
                // Call GetOrCreateNPCContext once — avoids two off-thread calls and a
                // race with the main game tick that could mutate the context dictionary.
                NPCContext ctx = null;
                AIResponse pendingResponse = null;
                try
                {
                    ctx = AIInfluenceBehavior.Instance?.GetOrCreateNPCContext(_npc);
                    pendingResponse = ctx?.PendingAIResponse;
                }
                catch (Exception ex)
                {
                    AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] GetOrCreateNPCContext failed: " + ex.Message);
                }

                string tone = pendingResponse?.Tone ?? "";
                string playerActionText = BuildPlayerActionText(pendingResponse);
                string npcActionText = BuildNpcActionText(pendingResponse, ctx);
                string relMsg = GetRelationChangeMessage(pendingResponse, ctx, npcName);

                // Swaps the streaming placeholder for the finalised message item and persists pills.
                // Called immediately for non-streaming responses, or by the pump once the typewriter
                // animation has finished revealing all characters.
                Action doFinalize = () =>
                {
                    try
                    {
                        streamingRetired = true;
                        if (streamingItem != null)
                            MessageList.Remove(streamingItem);

                        if (!string.IsNullOrEmpty(playerActionText) && playerMessageItem != null)
                            playerMessageItem.ContentSegments.Add(new ContentSegmentVM(playerActionText, ActionColor, ActionBubbleColor, true));

                        var npcItem = ParseLine($"{npcName}: {reply}", tone);
                        if (!string.IsNullOrEmpty(npcActionText))
                            npcItem.ContentSegments.Add(new ContentSegmentVM(npcActionText, ActionColor, ActionBubbleColor, true));
                        if (!string.IsNullOrEmpty(relMsg))
                            npcItem.ContentSegments.Add(new ContentSegmentVM(relMsg, RelationMessageColor, RelationBubbleColor, true));
                        AddNewestMessage(npcItem);

                        if (ctx?.ConversationHistory != null)
                        {
                            if (!string.IsNullOrEmpty(playerActionText) && playerHistoryIdx >= 0 && playerHistoryIdx < ctx.ConversationHistory.Count)
                                ctx.AppendActionToMessage(playerHistoryIdx, playerActionText);
                            int npcHistoryIdx = ctx.ConversationHistory.Count - 1;
                            if (npcHistoryIdx > playerHistoryIdx)
                            {
                                if (!string.IsNullOrEmpty(npcActionText))
                                    ctx.AppendActionToMessage(npcHistoryIdx, npcActionText);
                                if (!string.IsNullOrEmpty(relMsg))
                                    ctx.AppendRelationToMessage(npcHistoryIdx, relMsg);
                            }
                            try { AIInfluenceBehavior.Instance?.SaveNPCContext(((MBObjectBase)_npc).StringId, _npc, ctx); }
                            catch (Exception ex) { AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] SaveNPCContext after pill persist failed: " + ex.Message); }
                        }
                        if (ctx != null && AIInfluenceBehavior.Instance != null)
                        {
                            try
                            {
                                AIInfluenceBehavior.Instance.UpdateContextData(ctx, _npc);
                                try { AIInfluenceBehavior.Instance.SaveNPCContext(((MBObjectBase)_npc).StringId, _npc, ctx); }
                                catch (Exception ex) { AIInfluenceBehavior.Instance.LogMessage("[NpcChatWindow] SaveNPCContext after UpdateContextData failed: " + ex.Message); }
                            }
                            catch (Exception ex) { AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] UpdateContextData failed: " + ex.Message); }
                            TtsLipSyncService.MainThreadQueue.Enqueue(() =>
                            {
                                RefreshTraitOverlay(_npc, ctx);
                                RefreshCharacterSection(_npc, ctx);
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] UI mutation after reply failed: " + ex.Message);
                    }
                };

                if (useOpenRouterStreaming && streamingItem != null)
                {
                    // Let the typewriter pump finish animating to the full reply, then finalize.
                    finalizeNpcMessage = doFinalize;
                    streamingTargetText = reply;
                    if (!streamPumpActive && streamPumpStep != null)
                    {
                        streamPumpActive = true;
                        streamPumpStep();
                    }
                }
                else
                {
                    doFinalize();
                }
            }
            else if (streamingItem != null)
            {
                streamingRetired = true;
                MessageList.Remove(streamingItem);
            }
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] ExecuteSendMessage failed: " + ex.Message);
        }
        finally
        {
            _isSending = false;
            ((ViewModel)this).OnPropertyChangedWithValue(true, "IsSendEnabled");
        }
    }

    public void ExecuteReturn() => _onReturn?.Invoke();
}
