using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class SettlementMenuOverlayModel : MBGameModel<SettlementMenuOverlayModel>
{
	public abstract Dictionary<Hero, bool> GetOverlayHeroes();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected SettlementMenuOverlayModel()
	{
		throw null;
	}
}
