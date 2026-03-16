using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class DisguiseDetectionModel : MBGameModel<DisguiseDetectionModel>
{
	public abstract float CalculateDisguiseDetectionProbability(Settlement settlement);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected DisguiseDetectionModel()
	{
		throw null;
	}
}
