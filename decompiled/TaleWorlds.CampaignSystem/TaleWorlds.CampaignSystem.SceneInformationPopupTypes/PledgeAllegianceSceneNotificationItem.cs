using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.SceneInformationPopupTypes;

public class PledgeAllegianceSceneNotificationItem : SceneNotificationData
{
	private const int NumberOfTroops = 24;

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

	public bool PlayerWantsToRestore
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
	public override Banner[] GetBanners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override SceneNotificationCharacter[] GetSceneNotificationCharacters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PledgeAllegianceSceneNotificationItem(Hero playerHero, bool playerWantsToRestore)
	{
		throw null;
	}
}
