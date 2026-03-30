using System.Collections.Generic;

namespace AIInfluence.WorldSystem;

public static class PatternMatcher
{
    public static bool Matches(EventPattern pattern, IReadOnlyList<EventDiaryEntry> entries)
    {
        bool rawMatch = MatchesRaw(pattern, entries);
        return pattern.Negated ? !rawMatch : rawMatch;
    }

    private static bool MatchesRaw(EventPattern pattern, IReadOnlyList<EventDiaryEntry> entries)
    {
        if (pattern.Events.Count == 0)
            return true;

        switch (pattern.MatchType)
        {
            case PatternMatchType.Single:
                return MatchesSingle(pattern.Events[0], entries);
            case PatternMatchType.Consecutive:
                return MatchesConsecutive(pattern.Events, entries);
            case PatternMatchType.NonConsecutive:
                return MatchesNonConsecutive(pattern.Events, entries);
            default:
                return false;
        }
    }

    private static bool MatchesSingle(EventTemplate template, IReadOnlyList<EventDiaryEntry> entries)
    {
        for (int i = 0; i < entries.Count; i++)
        {
            if (TemplateMatches(template, entries[i]))
                return true;
        }
        return false;
    }

    private static bool MatchesConsecutive(List<EventTemplate> templates, IReadOnlyList<EventDiaryEntry> entries)
    {
        if (templates.Count > entries.Count)
            return false;

        for (int start = 0; start <= entries.Count - templates.Count; start++)
        {
            bool allMatch = true;
            for (int offset = 0; offset < templates.Count; offset++)
            {
                if (!TemplateMatches(templates[offset], entries[start + offset]))
                {
                    allMatch = false;
                    break;
                }
            }
            if (allMatch)
                return true;
        }
        return false;
    }

    private static bool MatchesNonConsecutive(List<EventTemplate> templates, IReadOnlyList<EventDiaryEntry> entries)
    {
        int templateIndex = 0;
        for (int i = 0; i < entries.Count && templateIndex < templates.Count; i++)
        {
            if (TemplateMatches(templates[templateIndex], entries[i]))
                templateIndex++;
        }
        return templateIndex == templates.Count;
    }

    private static bool TemplateMatches(EventTemplate template, EventDiaryEntry entry)
    {
        if (template.IsWildcard)
            return true;
        return template.EventCode == entry.EventCode;
    }
}
