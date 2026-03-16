using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultBanditDensityModel : BanditDensityModel
{
	private Clan _deserterClan;

	public override int NumberOfMinimumBanditPartiesInAHideoutToInfestIt
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int NumberOfMaximumBanditPartiesInEachHideout
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int NumberOfMaximumBanditPartiesAroundEachHideout
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int NumberOfMaximumHideoutsAtEachBanditFaction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int NumberOfInitialHideoutsAtEachBanditFaction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int NumberOfMinimumBanditTroopsInHideoutMission
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int NumberOfMaximumTroopCountForFirstFightInHideout
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override int NumberOfMaximumTroopCountForBossFightInHideout
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override float SpawnPercentageForFirstFightInHideoutMission
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private Clan DeserterClan
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMinimumTroopCountForHideoutMission(MobileParty party, bool isAssault)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMaxSupportedNumberOfLootersForClan(Clan clan)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMaximumTroopCountForHideoutMission(MobileParty party, bool isAssault)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsPositionInsideNavalSafeZone(CampaignVec2 position)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultBanditDensityModel()
	{
		throw null;
	}
}
