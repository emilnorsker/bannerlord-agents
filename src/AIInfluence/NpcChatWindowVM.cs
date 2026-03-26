using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AIInfluence.ChatTools;
using AIInfluence.DynamicEvents;
using AIInfluence.Services;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Items;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

/// <summary>
/// NPC chat Gauntlet root VM. The encyclopedia-style column mirrors <c>EncyclopediaHeroPageVM</c> visuals (tableau, traits, skills).
/// Message list, segment pills, and input are mod-specific. Encyclopedia bookmark UI is omitted — see <c>docs/UPCOMING_FEATURES.md</c>
/// for a possible future “Conversations” encyclopedia integration.
/// </summary>
public class NpcChatWindowVM : ViewModel
{
    private readonly Hero _npc;
    private readonly Action _onReturn;
    private string _inputText = "";
    private bool _isSending;

    // ── Header ────────────────────────────────────────────────────────────
    [DataSourceProperty] public string NpcName { get; set; } = "";
    [DataSourceProperty] public string NpcTitle { get; set; } = "";

    // ── Encyclopedia-style hero strip (SandBox EncyclopediaHeroPage.xml) ──
    [DataSourceProperty] public HeroViewModel HeroCharacter { get; private set; }
    [DataSourceProperty] public bool IsInformationHidden { get; set; }
    [DataSourceProperty] public string InfoHiddenReasonText { get; set; } = "";
    [DataSourceProperty] public bool IsPregnant { get; set; }
    [DataSourceProperty] public HintViewModel PregnantHint { get; private set; }
    [DataSourceProperty] public MBBindingList<EncyclopediaTraitItemVM> Traits { get; } = new MBBindingList<EncyclopediaTraitItemVM>();
    /// <summary>Encyclopedia skill grid; not named <c>Skills</c> to avoid shadowing <see cref="TaleWorlds.Core.Skills"/>.</summary>
    [DataSourceProperty] public MBBindingList<EncyclopediaSkillVM> HeroSkillList { get; } = new MBBindingList<EncyclopediaSkillVM>();
    [DataSourceProperty] public string SkillsText { get; set; } = "";
    [DataSourceProperty] public bool HasAnySkills { get; set; }

    // ── Chat column header (mood only; relation/trust = Character info section, native SP sliders) ──
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

    // ── Right panel – collapsible sections (clan-style) + NPC party strip ──
    [DataSourceProperty] public MBBindingList<InfoSectionVM> InfoSections { get; } = new MBBindingList<InfoSectionVM>();

    private void AddNewestMessage(ChatMessageItemVM item) => MessageList.Add(item);

    /// <summary>Hero this chat window is for (deferred pills from delayed tasks must match).</summary>
    public Hero TargetHero => _npc;

    /// <summary>Appends pills queued when an effect finishes after the chat row was built (e.g. workshop sale).</summary>
    public void AppendDeferredChatPills(NPCContext context)
    {
        if (context?.DeferredChatPillAppends == null || context.DeferredChatPillAppends.Count == 0)
            return;
        int lastNpc = -1;
        int lastPlayer = -1;
        for (int i = MessageList.Count - 1; i >= 0; i--)
        {
            ChatMessageItemVM row = MessageList[i];
            if (row.IsPlayer)
            {
                if (lastPlayer < 0)
                    lastPlayer = i;
            }
            else if (lastNpc < 0)
                lastNpc = i;
            if (lastPlayer >= 0 && lastNpc >= 0)
                break;
        }
        foreach ((string text, string color, bool forPlayerRow) in context.DeferredChatPillAppends)
        {
            string bullet = (text != null && text.StartsWith("• ", StringComparison.Ordinal)) ? text : "• " + (text ?? "").Trim();
            if (forPlayerRow)
            {
                if (lastPlayer >= 0)
                    MessageList[lastPlayer].ContentSegments.Add(new ContentSegmentVM(bullet, color));
            }
            else if (lastNpc >= 0)
                MessageList[lastNpc].ContentSegments.Add(new ContentSegmentVM(bullet, color));
        }
        context.DeferredChatPillAppends.Clear();
    }

    public NpcChatWindowVM(Hero npc, NPCContext context, Action onReturn)
    {
        _npc = npc ?? throw new ArgumentNullException(nameof(npc));
        _onReturn = onReturn;
        // Always bind to the canonical in-memory context (same instance ProcessChatInput mutates).
        NPCContext resolvedContext = AIInfluenceBehavior.Instance?.GetOrCreateNPCContext(npc) ?? context;
        PopulateHeader(npc);
        PopulateEncyclopediaHeroStrip(npc);
        PopulateTraitOverlay(npc, resolvedContext);
        PopulateHistory(resolvedContext);
        PopulateRightPanel(npc, resolvedContext);
        SyncCharacterSectionRelationTrust(npc, resolvedContext);
    }

    /// <summary>Releases tableau resources for <see cref="HeroCharacter"/>; call before clearing the view model reference.</summary>
    public void FinalizeEncyclopediaHeroStrip()
    {
        try
        {
            HeroCharacter?.OnFinalize();
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] HeroCharacter.OnFinalize failed: " + ex.Message);
        }
    }

    private void PopulateEncyclopediaHeroStrip(Hero npc)
    {
        IsInformationHidden = false;
        InfoHiddenReasonText = "";
        PregnantHint = new HintViewModel(new TextObject("{=4ytmLxOy}"));
        IsPregnant = npc.IsPregnant;
        try
        {
            var vm = new HeroViewModel();
            vm.FillFrom(npc, -1, false, false);
            HeroCharacter = vm;
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] HeroViewModel.FillFrom failed: " + ex.Message);
            HeroCharacter = new HeroViewModel();
        }
        Traits.Clear();
        foreach (TraitObject trait in TraitObject.All)
        {
            if (trait == null || trait.IsHidden)
                continue;
            int level = npc.GetTraitLevel(trait);
            if (level != 0)
                Traits.Add(new EncyclopediaTraitItemVM(trait, npc));
        }
        HeroSkillList.Clear();
        foreach (SkillObject skill in Skills.All)
        {
            int v = (int)npc.GetSkillValue(skill);
            if (v > 0)
                HeroSkillList.Add(new EncyclopediaSkillVM(skill, v));
        }
        HasAnySkills = HeroSkillList.Count > 0;
        SkillsText = new TextObject("{=Y7qbwrWE}")
            .SetTextVariable("HERO_NAME", npc.Name)
            .ToString();
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
        EmotionLabel = context?.EmotionalState?.Mood ?? "";
    }

    private void RefreshTraitOverlay(Hero npc, NPCContext context)
    {
        PopulateTraitOverlay(npc, context);
        SyncCharacterSectionRelationTrust(npc, context);
        ((ViewModel)this).OnPropertyChangedWithValue<string>(EmotionLabel, "EmotionLabel");
    }

    private static void ApplyRelationTrustSlidersToSection(InfoSectionVM section, Hero npc, NPCContext context)
    {
        int relRaw = Hero.MainHero != null ? (int)npc.GetRelation(Hero.MainHero) : 0;
        float rel = relRaw;
        if (rel > 100f)
            rel = 100f;
        if (rel < -100f)
            rel = -100f;
        section.RelationSliderPositionFloat = rel + 100f;
        section.RelationValueAsString = $"{relRaw:+#;-#;0}";
        float t = context?.TrustLevel ?? 0f;
        if (t < 0f)
            t = 0f;
        if (t > 1f)
            t = 1f;
        section.TrustPercentFloat = t * 100f;
        section.TrustValueAsString = $"{t * 100f:F0}%";
    }

    private void SyncCharacterSectionRelationTrust(Hero npc, NPCContext context)
    {
        foreach (InfoSectionVM s in InfoSections)
        {
            if (!s.ShowNativeRelationTrustSliders)
                continue;
            ApplyRelationTrustSlidersToSection(s, npc, context);
            break;
        }
    }

    private void PopulateHistory(NPCContext context)
    {
        if (context?.ConversationHistory == null) return;
        var history = context.ConversationHistory;
        int skip = Math.Max(0, history.Count - 10);
        foreach (string line in history.Skip(skip))
            AddNewestMessage(ParseLine(line));
    }

    private void PopulateRightPanel(Hero npc, NPCContext context) => RebuildInfoPanelSections(npc, context);

    private void RebuildInfoPanelSections(Hero npc, NPCContext context)
    {
        const string headerMuted = "#888888FF";
        const string questGold = "#D0A96BFF";
        // One subtle panel tint per section row (no encyclopedia frame layer on the column).
        const string sectionStripe = "#0C101868";
        InfoSections.Clear();
        // InfoSectionsList uses VerticalBottomToTop in ChatInterface.xml; sections added in build order (Character … Party) without VM reordering.
        var built = new[]
        {
            BuildCharacterSection(npc, context),
            BuildCharacterHistorySection(context, headerMuted),
            BuildBehaviorSection(context, headerMuted),
            BuildQuestSection(context, headerMuted, questGold),
            BuildWorldEventsSection(context, headerMuted),
            BuildNpcPartySection(npc)
        };
        foreach (var section in built)
        {
            section.SectionPanelColor = sectionStripe;
            InfoSections.Add(section);
        }
    }

    private static InfoSectionVM BuildNpcPartySection(Hero npc)
    {
        var section = new InfoSectionVM { HeaderText = "NPC party info", HeaderSkillId = DefaultSkills.Leadership.StringId };
        MobileParty party = npc.PartyBelongedTo;
        if (party == null)
        {
            section.TextLines.Add(new TextItemVM("Not in a party on the map.", "#888888FF"));
            section.ShowPartyFood = false;
            section.RefreshVisibility();
            return section;
        }
        PartyTroopFormationHelper.GetFormationCounts(party, out int inf, out int rng, out int cav, out int ha);
        section.InfantryCount = inf;
        section.RangedCount = rng;
        section.CavalryCount = cav;
        section.HorseArcherCount = ha;
        section.ShowPartyTroopStrip = inf + rng + cav + ha > 0;
        section.InfantryHint = new HintViewModel(GameTexts.FindText("str_formation_class_string", "Infantry"));
        section.RangedHint = new HintViewModel(GameTexts.FindText("str_formation_class_string", "Ranged"));
        section.CavalryHint = new HintViewModel(GameTexts.FindText("str_formation_class_string", "Cavalry"));
        section.HorseArcherHint = new HintViewModel(GameTexts.FindText("str_formation_class_string", "HorseArcher"));
        float days = party.GetNumDaysForFoodToLast();
        var (_, col) = NpcPartyFoodSupply.Classify(days);
        string leaderName = ((object)npc.Name)?.ToString() ?? "";
        section.PartyFoodText = NpcPartyFoodSupply.FormatNarrative(days, leaderName);
        section.PartyFoodColor = col;
        section.ShowPartyFood = true;
        section.RefreshVisibility();
        return section;
    }

    private static InfoSectionVM BuildQuestSection(NPCContext context, string headerMuted, string questGold)
    {
        var section = new InfoSectionVM { HeaderText = "Quests", HeaderSkillId = DefaultSkills.Trade.StringId };
        List<string> lines = CollectQuestLines(context);
        if (lines.Count == 0)
            section.TextLines.Add(new TextItemVM("• No active quest with this character", headerMuted));
        else
            foreach (string line in lines)
                section.TextLines.Add(new TextItemVM(line, questGold));
        section.RefreshVisibility();
        return section;
    }

    private static List<string> CollectQuestLines(NPCContext context)
    {
        if (context == null)
            return new List<string>();
        var questSources = new (IEnumerable<AIQuestInfo> source, Func<AIQuestInfo, string> format)[]
        {
            (OrEmpty(context.ActiveAIQuests), FormatActiveQuestLine),
            (OrEmpty(context.IncomingAIQuests), FormatIncomingQuestLine)
        };
        var all = questSources.SelectMany(s => s.source.Where(IsValidQuest).Select(q => (quest: q, formatter: s.format)));
        return all.GroupBy(x => x.quest.QuestId).Select(g => { var f = g.First(); return f.formatter(f.quest); }).ToList();
    }

    /// <summary>Show title + description when both exist (avoids dropping the body when title is non-empty).</summary>
    private static string FormatWorldEventDisplayText(DynamicEvent e)
    {
        if (e == null) return "";
        string t = (e.Title ?? "").Trim();
        string d = (e.Description ?? "").Trim();
        if (string.IsNullOrEmpty(t)) return d;
        if (string.IsNullOrEmpty(d)) return t;
        if (d.StartsWith(t, StringComparison.OrdinalIgnoreCase)) return d;
        return $"{t} — {d}";
    }

    private InfoSectionVM BuildWorldEventsSection(NPCContext context, string headerMuted)
    {
        var section = new InfoSectionVM { HeaderText = "World events", HeaderSkillId = DefaultSkills.Scouting.StringId };
        try
        {
            foreach (var e in WorldEventsReadFacade.GetEventsKnownToNpcForUi(_npc, context).OrderByDescending(ev => ev.CreationCampaignDays).Take(5))
            {
                string text = FormatWorldEventDisplayText(e);
                if (string.IsNullOrWhiteSpace(text))
                    continue;
                string skillId = WorldEventGlyphHelper.GetSkillIdForEventType(e.Type);
                section.GlyphLines.Add(InfoGlyphLineVM.FromWorldEvent(skillId, "• " + text, e.Importance));
            }
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] BuildWorldEventsSection failed: " + ex.Message);
        }
        if (section.GlyphLines.Count == 0)
            section.TextLines.Add(new TextItemVM("• None", headerMuted));
        section.RefreshVisibility();
        return section;
    }

    /// <summary><c>character_backstory</c> → <see cref="NPCContext.AIGeneratedBackstory"/> (plain bullets; split on newlines).</summary>
    private static InfoSectionVM BuildCharacterHistorySection(NPCContext context, string headerMuted)
    {
        var section = new InfoSectionVM { HeaderText = "Character history", HeaderSkillId = DefaultSkills.Roguery.StringId };
        string backstory = context?.AIGeneratedBackstory?.Trim();
        if (string.IsNullOrWhiteSpace(backstory))
        {
            section.TextLines.Add(new TextItemVM("• No backstory recorded yet", headerMuted));
            section.RefreshVisibility();
            return section;
        }
        foreach (string line in backstory.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            string t = line.Trim();
            if (t.Length > 0)
                section.TextLines.Add(new TextItemVM("• " + t));
        }
        if (section.TextLines.Count == 0)
            section.TextLines.Add(new TextItemVM("• No backstory recorded yet", headerMuted));
        section.RefreshVisibility();
        return section;
    }

    /// <summary>AI personality / speech / mood — separate from factual history.</summary>
    private static InfoSectionVM BuildBehaviorSection(NPCContext context, string headerMuted)
    {
        var section = new InfoSectionVM { HeaderText = "Behavior", HeaderSkillId = DefaultSkills.Steward.StringId };
        bool any = false;
        if (!string.IsNullOrWhiteSpace(context?.AIGeneratedPersonality))
        {
            section.TextLines.Add(new TextItemVM("• " + context.AIGeneratedPersonality));
            any = true;
        }
        foreach (string q in context?.Quirks ?? new List<string>())
        {
            if (!string.IsNullOrWhiteSpace(q))
            {
                section.TextLines.Add(new TextItemVM("• " + q));
                any = true;
            }
        }
        if (!string.IsNullOrWhiteSpace(context?.AIGeneratedSpeechQuirks))
        {
            section.TextLines.Add(new TextItemVM("• " + context.AIGeneratedSpeechQuirks));
            any = true;
        }
        if (!string.IsNullOrWhiteSpace(context?.EmotionalState?.Mood))
        {
            section.TextLines.Add(new TextItemVM($"• Mood: {context.EmotionalState.Mood}"));
            any = true;
        }
        if (!any)
            section.TextLines.Add(new TextItemVM("• Not yet discovered", headerMuted));
        section.RefreshVisibility();
        return section;
    }

    private static InfoSectionVM BuildCharacterSection(Hero npc, NPCContext context)
    {
        var section = new InfoSectionVM { HeaderText = "Character", HeaderSkillId = DefaultSkills.Charm.StringId };
        section.ShowNativeRelationTrustSliders = true;
        ApplyRelationTrustSlidersToSection(section, npc, context);
        section.TextLines.Add(new TextItemVM($"Interactions: {context?.InteractionCount ?? 0}"));
        section.RefreshVisibility();
        return section;
    }

    private static IEnumerable<AIQuestInfo> OrEmpty(IList<AIQuestInfo> list) => list ?? Enumerable.Empty<AIQuestInfo>();
    private static bool IsValidQuest(AIQuestInfo q) => q != null && !string.IsNullOrWhiteSpace(q.Title) && IsQuestStillOngoing(q.QuestId);
    /// <summary>Checks if quest exists in campaign and is ongoing. Uses ToList() to avoid InvalidOperationException if Quests is modified during iteration.</summary>
    private static bool IsQuestStillOngoing(string questId)
    {
        if (string.IsNullOrEmpty(questId)) return false;
        var quests = Campaign.Current?.QuestManager?.Quests?.ToList();
        return quests != null && quests.Any(q => ((MBObjectBase)q).StringId == questId && q.IsOngoing);
    }
    /// <summary>Formats an active quest line with optional progress (e.g. "2/3 targets").</summary>
    private static string FormatActiveQuestLine(AIQuestInfo q)
    {
        if (q.ProgressTarget <= 0) return $"• {q.Title}";
        int current = Math.Max(0, Math.Min(q.ProgressCurrent, q.ProgressTarget));
        string label = string.IsNullOrWhiteSpace(q.ProgressLabel) ? "" : $" {q.ProgressLabel}";
        return $"• {q.Title} ({current}/{q.ProgressTarget}{label})";
    }
    /// <summary>Formats an incoming quest line (NPC is delivery target).</summary>
    private static string FormatIncomingQuestLine(AIQuestInfo q) => $"• {q.Title} (deliver here)";

    private void RefreshCharacterSection(Hero npc, NPCContext context)
    {
        try
        {
            RebuildInfoPanelSections(npc, context);
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] RefreshCharacterSection failed: " + ex.Message);
        }
    }

    // ── Segment parser ────────────────────────────────────────────────────

    // Matches *text* (complete) or *text at end (streaming); capture is text inside
    private static readonly Regex EmoteRegex = new Regex(@"\*([^*]*)(?:\*|$)", RegexOptions.Compiled);
    private const string EmoteColor           = "#9B59B6FF";  // purple
    private const string ActionColor          = "#FFD700FF";  // golden (fallback)
    private const string RelationMessageColor = "#5B9BD5FF";  // blue

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

        bool isPlayer = IsPlayerSender(sender);

        var item = new ChatMessageItemVM
        {
            SenderName  = sender,
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
                    item.ContentSegments.Add(new ContentSegmentVM(speech));
            }
            string emoteText = m.Groups[1].Value;
            if (!string.IsNullOrEmpty(emoteText))
                item.ContentSegments.Add(new ContentSegmentVM(emoteText, EmoteColor));
            pos = m.Index + m.Length;
        }
        if (pos < content.Length)
        {
            string remainder = content.Substring(pos).Trim();
            if (!string.IsNullOrEmpty(remainder))
                item.ContentSegments.Add(new ContentSegmentVM(remainder));
        }

        if (!string.IsNullOrEmpty(actionSuffix))
            item.ContentSegments.Add(new ContentSegmentVM(actionSuffix, ActionColor));
        if (!string.IsNullOrEmpty(relSuffix))
            item.ContentSegments.Add(new ContentSegmentVM(relSuffix, RelationMessageColor));

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
            targetItem.ContentSegments.Add(new ContentSegmentVM(""));
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

        bool releaseSendLockInFinally = true;
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
            catch (Exception ex)
            {
                AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] pre-send GetOrCreateNPCContext: " + ex.Message);
            }
            ChatMessageItemVM streamingItem = null;
            bool streamingRetired = false;
            string streamingTargetText = "";
            string streamingVisibleText = "";
            bool streamPumpActive = false;
            Action streamPumpStep = null;
            // Set by the reply handler; the pump calls this once the typewriter animation reaches
            // the final target text so the message is only swapped out after the full animation.
            Action finalizeNpcMessage = null;
            streamingItem = ParseLine($"{npcName}: ", "");
            streamingItem.ContentSegments.Add(new ContentSegmentVM(""));
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
                    streamPumpActive = false;
                }
                else // visible == target: animation complete
                {
                    streamPumpActive = false;
                    Action fin = finalizeNpcMessage;
                    finalizeNpcMessage = null;
                    fin?.Invoke();
                }
            };
            string reply = await AIInfluenceBehavior.Instance.ProcessChatInput(_npc, message, messagePreviewText =>
            {
                MainThreadDispatcher.Queue.Enqueue(() =>
                {
                    if (!streamingRetired && streamingItem != null)
                    {
                        streamingTargetText = messagePreviewText ?? "";
                        if (!streamPumpActive && streamPumpStep != null)
                        {
                            streamPumpActive = true;
                            streamPumpStep();
                        }
                    }
                });
            });
            // Keep _isSending true until doFinalize runs so a second send cannot start ProcessChatInput
            // and ClearNpcTurnDialogueTools before quest_action is applied (see ApplyPendingQuestActionFromTools).
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
            var playerPills = ctx?.ToolPlayerPillsForCurrentTurn != null
                ? new List<(string text, string textColor)>(ctx.ToolPlayerPillsForCurrentTurn)
                : new List<(string text, string textColor)>();
            var npcPills = ctx?.ToolPillsForCurrentTurn != null
                ? new List<(string text, string textColor)>(ctx.ToolPillsForCurrentTurn)
                : new List<(string text, string textColor)>();
            if (ctx?.PendingKingdomActionFromTools != null)
            {
                (string kText, string kColor) = ChatToolPillBuilder.FormatKingdomActionPill(ctx.PendingKingdomActionFromTools);
                if (!string.IsNullOrEmpty(kText))
                    npcPills.Add((kText, kColor));
            }
            string relMsg = GetRelationChangeMessage(pendingResponse, ctx, npcName);
            bool needsChatRows = !string.IsNullOrEmpty(reply) || npcPills.Count > 0 || playerPills.Count > 0 || !string.IsNullOrEmpty(relMsg);
            string npcLineBody = string.IsNullOrEmpty(reply) ? "(actions only)" : reply;

            if (needsChatRows)
            {
                Action doFinalize = () =>
                {
                    try
                    {
                        streamingRetired = true;
                        if (streamingItem != null)
                            MessageList.Remove(streamingItem);

                        if (playerPills.Count > 0 && playerMessageItem != null)
                        {
                            foreach (var (text, textColor) in playerPills)
                                playerMessageItem.ContentSegments.Add(new ContentSegmentVM(text, textColor));
                        }

                        var npcItem = ParseLine($"{npcName}: {npcLineBody}", tone);
                        foreach (var (text, textColor) in npcPills)
                            npcItem.ContentSegments.Add(new ContentSegmentVM(text, textColor));
                        if (!string.IsNullOrEmpty(relMsg))
                            npcItem.ContentSegments.Add(new ContentSegmentVM(relMsg, RelationMessageColor));
                        AddNewestMessage(npcItem);
                        AppendDeferredChatPills(ctx);

                        if (ctx?.ConversationHistory != null)
                        {
                            string playerActionText = string.Join(" · ", playerPills.Select(p => p.text));
                            if (!string.IsNullOrEmpty(playerActionText) && playerHistoryIdx >= 0 && playerHistoryIdx < ctx.ConversationHistory.Count)
                                ctx.AppendActionToMessage(playerHistoryIdx, playerActionText);
                            int npcHistoryIdx = ctx.ConversationHistory.Count - 1;
                            if (npcHistoryIdx > playerHistoryIdx)
                            {
                                string npcActionText = string.Join(" · ", npcPills.Select(p => p.text));
                                if (!string.IsNullOrEmpty(npcActionText))
                                    ctx.AppendActionToMessage(npcHistoryIdx, npcActionText);
                                if (!string.IsNullOrEmpty(relMsg))
                                    ctx.AppendRelationToMessage(npcHistoryIdx, relMsg);
                            }
                            try { AIInfluenceBehavior.Instance?.SaveNPCContext(((MBObjectBase)_npc).StringId, _npc, ctx); }
                            catch (Exception ex) { AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] SaveNPCContext after pill persist failed: " + ex.Message); }
                        }
                        AIInfluenceBehavior.Instance?.ApplyPendingQuestActionFromTools(_npc, ctx);
                        AIInfluenceBehavior.Instance?.ApplyPendingKingdomActionFromTools(_npc, ctx);
                        if (ctx != null && AIInfluenceBehavior.Instance != null)
                        {
                            try
                            {
                                AIInfluenceBehavior.Instance.UpdateContextData(ctx, _npc);
                                try { AIInfluenceBehavior.Instance.SaveNPCContext(((MBObjectBase)_npc).StringId, _npc, ctx); }
                                catch (Exception ex) { AIInfluenceBehavior.Instance.LogMessage("[NpcChatWindow] SaveNPCContext after UpdateContextData failed: " + ex.Message); }
                            }
                            catch (Exception ex) { AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] UpdateContextData failed: " + ex.Message); }
                            MainThreadDispatcher.Queue.Enqueue(() =>
                            {
                                if (!NpcChatWindowManager.IsOpen || NpcChatWindowManager.GetCurrentViewModel() != this) return;
                                RefreshTraitOverlay(_npc, ctx);
                                RefreshCharacterSection(_npc, ctx);
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] UI mutation after reply failed: " + ex.Message);
                    }
                    finally
                    {
                        _isSending = false;
                        ((ViewModel)this).OnPropertyChangedWithValue(true, "IsSendEnabled");
                    }
                };

                if (streamingItem != null)
                {
                    releaseSendLockInFinally = false;
                    MainThreadDispatcher.Queue.Enqueue(() =>
                    {
                        streamingTargetText = npcLineBody;
                        finalizeNpcMessage = doFinalize;
                        if (!streamPumpActive && streamPumpStep != null)
                        {
                            streamPumpActive = true;
                            streamPumpStep();
                        }
                        if (!streamPumpActive && finalizeNpcMessage != null)
                        {
                            finalizeNpcMessage = null;
                            doFinalize();
                        }
                    });
                }
                else
                {
                    doFinalize();
                    releaseSendLockInFinally = false;
                }
            }
            else
            {
                MainThreadDispatcher.Queue.Enqueue(() =>
                {
                    AIInfluenceBehavior.Instance?.ApplyPendingQuestActionFromTools(_npc, ctx);
                    AIInfluenceBehavior.Instance?.ApplyPendingKingdomActionFromTools(_npc, ctx);
                    if (streamingItem != null)
                    {
                        streamingRetired = true;
                        MessageList.Remove(streamingItem);
                    }
                    if (ctx != null && AIInfluenceBehavior.Instance != null)
                    {
                        if (NpcChatWindowManager.IsOpen && NpcChatWindowManager.GetCurrentViewModel() == this)
                        {
                            RefreshTraitOverlay(_npc, ctx);
                            RefreshCharacterSection(_npc, ctx);
                        }
                    }
                    _isSending = false;
                    ((ViewModel)this).OnPropertyChangedWithValue(true, "IsSendEnabled");
                });
                releaseSendLockInFinally = false;
            }
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] ExecuteSendMessage failed: " + ex.Message);
        }
        finally
        {
            if (releaseSendLockInFinally)
            {
                _isSending = false;
                ((ViewModel)this).OnPropertyChangedWithValue(true, "IsSendEnabled");
            }
        }
    }

    public void ExecuteReturn() => _onReturn?.Invoke();
}
