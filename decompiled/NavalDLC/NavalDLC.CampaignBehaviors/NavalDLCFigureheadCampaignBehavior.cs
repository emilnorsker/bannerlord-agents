using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace NavalDLC.CampaignBehaviors;

public class NavalDLCFigureheadCampaignBehavior : CampaignBehaviorBase
{
	private MBReadOnlyList<Figurehead> _allFigureheadsCache;

	private CampaignTime _lastFigureheadLootTime;

	private Dictionary<Hero, Figurehead> _aiLordSelectedFigureheads;

	public CampaignTime LastFigureheadLootTime
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnFigureheadUnlocked(Figurehead figurehead)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBReadOnlyList<Figurehead> GetAllFigureheads()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnShipOwnerChanged(Ship ship, PartyBase oldOwner, ShipOwnerChangeDetail changeDetail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCFigureheadCampaignBehavior()
	{
		throw null;
	}
}
