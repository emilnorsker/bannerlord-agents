using System;
using System.Collections.Generic;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;

namespace AIInfluence;

/// <summary>
/// Bridges the Gauntlet NPC chat UI to the engine's native conversation option list
/// (<see cref="ConversationManager"/> / <see cref="ConversationSentenceOption"/>).
/// </summary>
public static class NativeConversationMenuBridge
{
    public static bool TryGetPlayerOptions(out List<(int Index, string Text)> options)
    {
        options = new List<(int, string)>();
        ConversationManager cm = Campaign.Current?.ConversationManager;
        if (cm == null || !cm.IsConversationInProgress)
            return false;

        cm.GetPlayerSentenceOptions();
        IList<ConversationSentenceOption> list = TryGetPlayerSentenceOptionList(cm);
        if (list == null || list.Count == 0)
            return false;
        for (int i = 0; i < list.Count; i++)
            options.Add((i, list[i].Text.ToString()));
        return true;
    }

    private static IList<ConversationSentenceOption> TryGetPlayerSentenceOptionList(ConversationManager cm)
    {
        Type t = cm.GetType();
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        foreach (string name in new[] { "_playerOptions", "_playerSentenceOptions", "_currentPlayerOptions" })
        {
            FieldInfo fi = t.GetField(name, flags);
            if (fi?.GetValue(cm) is IList<ConversationSentenceOption> list)
                return list;
        }
        foreach (FieldInfo fi in t.GetFields(flags))
        {
            if (fi.FieldType.IsGenericType &&
                fi.FieldType.GetGenericTypeDefinition() == typeof(List<>) &&
                fi.FieldType.GetGenericArguments()[0] == typeof(ConversationSentenceOption))
            {
                if (fi.GetValue(cm) is IList<ConversationSentenceOption> list)
                    return list;
            }
        }
        return null;
    }

    public static void ExecuteOption(int optionIndex)
    {
        ConversationManager cm = Campaign.Current?.ConversationManager;
        if (cm == null || !cm.IsConversationInProgress)
            throw new InvalidOperationException("No conversation in progress.");
        cm.DoOption(optionIndex);
    }
}
