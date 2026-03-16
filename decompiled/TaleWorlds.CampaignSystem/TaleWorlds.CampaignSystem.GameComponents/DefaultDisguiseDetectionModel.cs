using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultDisguiseDetectionModel : DisguiseDetectionModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateDisguiseDetectionProbability(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultDisguiseDetectionModel()
	{
		throw null;
	}
}
