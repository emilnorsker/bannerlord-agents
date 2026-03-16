using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultNotableSpawnModel : NotableSpawnModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetTargetNotableCountForSettlement(Settlement settlement, Occupation occupation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultNotableSpawnModel()
	{
		throw null;
	}
}
