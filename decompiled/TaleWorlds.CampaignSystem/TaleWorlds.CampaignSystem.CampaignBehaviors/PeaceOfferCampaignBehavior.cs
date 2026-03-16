using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class PeaceOfferCampaignBehavior : CampaignBehaviorBase
{
	private static TextObject PeaceOfferDefaultPanelDescriptionText;

	private static TextObject PeaceOfferTributePaidPanelDescriptionText;

	private static TextObject PeaceOfferTributeWantedPanelDescriptionText;

	private static TextObject PeaceOfferDefaultPanelPlayerIsVassalDescriptionText;

	private static TextObject PeaceOfferTributePaidPanelPlayerIsVassalDescriptionText;

	private static TextObject PeaceOfferTributeWantedPanelPlayerIsVassalDescriptionText;

	private IFaction _opponentFaction;

	private int _currentPeaceOfferTributeAmount;

	private int _currentPeaceOfferTributeDuration;

	private int _influenceCostOfDecline;

	private static TextObject PeacePanelTitleText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static TextObject PeacePanelOkText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static TextObject PeacePanelAffirmativeText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private static TextObject PeacePanelNegativeText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPeaceOffered(IFaction opponentFaction, int tributeAmount, int tributeDuration)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPeaceOfferResolved(IFaction opponentFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OkPeaceOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AcceptPeaceOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeclinePeaceOffer()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PeaceOfferCampaignBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static PeaceOfferCampaignBehavior()
	{
		throw null;
	}
}
