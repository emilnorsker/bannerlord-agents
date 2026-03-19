using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace AIInfluence;

/// <summary>
/// <see cref="TaleWorlds.CampaignSystem.Encyclopedia.EncyclopediaManager"/> bookmark APIs exist at runtime but are not exposed on the compile-time reference used by the mod SDK.
/// Reflection matches the method names present in <c>TaleWorlds.CampaignSystem.dll</c> (e.g. <c>AddEncyclopediaBookmarkToItem</c>, <c>IsEncyclopediaBookmarked</c>).
/// </summary>
internal static class EncyclopediaBookmarkHelper
{
    private static MethodInfo _addBookmark;
    private static MethodInfo _removeBookmark;
    private static MethodInfo _isBookmarked;
    private static bool _resolved;

    private static void Resolve(object encyclopediaManager)
    {
        if (_resolved || encyclopediaManager == null)
            return;
        _resolved = true;
        Type t = encyclopediaManager.GetType();
        const BindingFlags bf = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        _addBookmark = t.GetMethod("AddEncyclopediaBookmarkToItem", bf);
        _removeBookmark = t.GetMethod("RemoveEncyclopediaBookmarkFromItem", bf);
        _isBookmarked = t.GetMethod("IsEncyclopediaBookmarked", bf);
    }

    public static bool TryIsBookmarked(Hero hero)
    {
        object mgr = Campaign.Current?.EncyclopediaManager;
        if (mgr == null || hero == null)
            return false;
        Resolve(mgr);
        if (_isBookmarked == null)
            return false;
        try
        {
            object r = _isBookmarked.Invoke(mgr, new object[] { hero });
            return r is bool b && b;
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[EncyclopediaBookmarkHelper] IsEncyclopediaBookmarked failed: " + ex.Message);
            return false;
        }
    }

    public static void TrySetBookmarked(Hero hero, bool add)
    {
        object mgr = Campaign.Current?.EncyclopediaManager;
        if (mgr == null || hero == null)
            return;
        Resolve(mgr);
        try
        {
            if (add)
            {
                if (_addBookmark != null)
                    _addBookmark.Invoke(mgr, new object[] { hero });
            }
            else if (_removeBookmark != null)
                _removeBookmark.Invoke(mgr, new object[] { hero });
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[EncyclopediaBookmarkHelper] bookmark toggle failed: " + ex.Message);
        }
    }
}
