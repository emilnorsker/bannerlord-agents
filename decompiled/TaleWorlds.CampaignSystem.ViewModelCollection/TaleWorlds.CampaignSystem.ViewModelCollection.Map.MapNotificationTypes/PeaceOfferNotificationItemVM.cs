using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.MapNotificationTypes;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapNotificationTypes;

public class PeaceOfferNotificationItemVM : MapNotificationItemBaseVM
{
	private bool _shouldDecisionBeCreatedOnClosed;

	private readonly IFaction _opponentFaction;

	private readonly int _tributeAmount;

	private readonly int _tributeDurationInDays;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PeaceOfferNotificationItemVM(PeaceOfferMapNotification data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification = true)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMakePeace(IFaction side1Faction, IFaction side2Faction, MakePeaceAction.MakePeaceDetail detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPeaceOfferClosed(IFaction opponentFaction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RemovePeaceOfferNotification(bool shouldDecisionCreatedOnClosed)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}
}
