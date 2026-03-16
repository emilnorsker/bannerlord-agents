using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.MapNotificationTypes;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapNotificationTypes;

public class MarriageOfferNotificationItemVM : MapNotificationItemBaseVM
{
	private bool _playerInspectedNotification;

	private readonly Hero _suitor;

	private readonly Hero _maiden;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MarriageOfferNotificationItemVM(MarriageOfferMapNotification data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnMarriageOfferCanceled(Hero suitor, Hero maiden)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}
}
