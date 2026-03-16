using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.BarterSystem.Barterables;
using TaleWorlds.CampaignSystem.Party;

namespace TaleWorlds.CampaignSystem.BarterSystem;

public class BarterData
{
	public readonly Hero OffererHero;

	public readonly Hero OtherHero;

	public readonly PartyBase OffererParty;

	public readonly PartyBase OtherParty;

	private List<Barterable> _barterables;

	private List<BarterGroup> _barterGroups;

	public readonly BarterManager.BarterContextInitializer ContextInitializer;

	public readonly int PersuasionCostReduction;

	public IFaction OffererMapFaction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IFaction OtherMapFaction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public bool IsAiBarter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BarterData(Hero offerer, Hero other, PartyBase offererParty, PartyBase otherParty, BarterManager.BarterContextInitializer contextInitializer = null, int persuasionCostReduction = 0, bool isAiBarter = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddBarterable<T>(Barterable barterable, bool isContextDependent = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AddBarterGroup(BarterGroup barterGroup)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<BarterGroup> GetBarterGroups()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Barterable> GetBarterables()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BarterGroup GetBarterGroup<T>()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Barterable> GetOfferedBarterables()
	{
		throw null;
	}
}
