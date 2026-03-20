using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>One formation group in the NPC party strip (portrait of a representative troop + count).</summary>
public class PartyTroopRowVM : ViewModel
{
    [DataSourceProperty] public ImageIdentifier Portrait { get; }
    [DataSourceProperty] public string FormationName { get; }
    [DataSourceProperty] public string CountLabel { get; }

    public PartyTroopRowVM(FormationClass formation, int count, CharacterObject representativeTroop)
    {
        FormationName = PartyTroopFormationHelper.FormatFormationName(formation);
        CountLabel = count.ToString();
        Portrait = new CharacterImageIdentifier(CampaignUIHelper.GetCharacterCode(representativeTroop, false));
    }
}
