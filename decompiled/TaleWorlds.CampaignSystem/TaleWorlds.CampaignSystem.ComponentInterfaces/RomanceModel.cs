using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class RomanceModel : MBGameModel<RomanceModel>
{
	public abstract int GetAttractionValuePercentage(Hero potentiallyInterestedCharacter, Hero heroOfInterest);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected RomanceModel()
	{
		throw null;
	}
}
