using TaleWorlds.Core;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>One formation row: clan-style sprite + (count), matching clan party troop strip (not inventory portraits).</summary>
public class PartyTroopRowVM : ViewModel
{
    [DataSourceProperty] public string FormationSprite { get; }
    [DataSourceProperty] public string CountInParens { get; }

    public PartyTroopRowVM(FormationClass formation, int count)
    {
        FormationSprite = PartyTroopFormationHelper.GetFormationSpritePath(formation);
        CountInParens = "(" + count + ")";
    }
}
