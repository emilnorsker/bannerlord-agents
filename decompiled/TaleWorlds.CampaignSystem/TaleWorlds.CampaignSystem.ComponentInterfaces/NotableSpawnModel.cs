using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class NotableSpawnModel : MBGameModel<NotableSpawnModel>
{
	public abstract int GetTargetNotableCountForSettlement(Settlement settlement, Occupation occupation);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected NotableSpawnModel()
	{
		throw null;
	}
}
