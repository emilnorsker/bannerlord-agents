using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.SceneInformationPopupTypes;

public class AntiEmpireConspiracyBeginsSceneNotificationItem : EmpireConspiracySupportsSceneNotificationItemBase
{
	private readonly List<Kingdom> _antiEmpireFactions;

	public override TextObject TitleText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public AntiEmpireConspiracyBeginsSceneNotificationItem(Hero kingHero, List<Kingdom> antiEmpireFactions)
	{
		throw null;
	}
}
