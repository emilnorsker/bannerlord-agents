using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.BarterSystem.Barterables;

public class NoAttackBarterable : Barterable
{
	private readonly IFaction _otherFaction;

	private readonly CampaignTime _duration;

	private readonly Hero _otherHero;

	private readonly PartyBase _otherParty;

	public override string StringID
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NoAttackBarterable(Hero originalOwner, Hero otherHero, PartyBase ownerParty, PartyBase otherParty, CampaignTime duration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Apply()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetUnitValueForFaction(IFaction faction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ImageIdentifier GetVisualIdentifier()
	{
		throw null;
	}
}
