using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace NavalDLC.ComponentInterfaces;

public abstract class ClanShipOwnershipModel : MBGameModel<ClanShipOwnershipModel>
{
	public abstract int GetIdealShipNumberForClan(Clan clan);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ClanShipOwnershipModel()
	{
		throw null;
	}
}
