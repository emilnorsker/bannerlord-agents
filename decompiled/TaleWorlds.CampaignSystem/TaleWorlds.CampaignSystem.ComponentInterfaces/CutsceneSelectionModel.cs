using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ComponentInterfaces;

public abstract class CutsceneSelectionModel : MBGameModel<CutsceneSelectionModel>
{
	public abstract SceneNotificationData GetKingdomDestroyedSceneNotification(Kingdom kingdom);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected CutsceneSelectionModel()
	{
		throw null;
	}
}
