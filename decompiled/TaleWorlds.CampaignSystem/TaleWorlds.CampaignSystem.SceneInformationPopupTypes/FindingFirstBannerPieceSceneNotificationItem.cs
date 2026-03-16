using System;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.SceneInformationPopupTypes;

public class FindingFirstBannerPieceSceneNotificationItem : SceneNotificationData
{
	private readonly Action _onCloseAction;

	private readonly CampaignTime _creationCampaignTime;

	public Hero PlayerHero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public override string SceneID
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject TitleText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnCloseAction()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FindingFirstBannerPieceSceneNotificationItem(Hero playerHero, Action onCloseAction = null)
	{
		throw null;
	}
}
