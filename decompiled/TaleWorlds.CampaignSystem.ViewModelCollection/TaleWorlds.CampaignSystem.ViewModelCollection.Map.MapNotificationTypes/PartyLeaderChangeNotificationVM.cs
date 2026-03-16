using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapNotificationTypes;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapNotificationTypes;

public class PartyLeaderChangeNotificationVM : MapNotificationItemBaseVM
{
	private bool _playerInspectedNotification;

	private readonly MobileParty _party;

	private TextObject _decisionPopupTitleText;

	private TextObject _partyLeaderChangePopupText;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PartyLeaderChangeNotificationVM(PartyLeaderChangeNotification data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnPartyLeaderChangeOfferCanceled(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMobilePartyDestroyed(MobileParty party, PartyBase destroyerParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckAndExecuteRemove(MobileParty party)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}
}
