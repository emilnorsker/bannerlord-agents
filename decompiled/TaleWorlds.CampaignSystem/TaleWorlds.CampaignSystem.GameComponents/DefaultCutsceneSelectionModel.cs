using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultCutsceneSelectionModel : CutsceneSelectionModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override SceneNotificationData GetKingdomDestroyedSceneNotification(Kingdom kingdom)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultCutsceneSelectionModel()
	{
		throw null;
	}
}
