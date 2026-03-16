using System.Linq;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.SceneInformationPopupTypes;

public class DeclareDragonBannerSceneNotificationItem : SceneNotificationData
{
	private const int NumberOfCharacters = 17;

	private readonly CampaignTime _creationCampaignTime;

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
	public DeclareDragonBannerSceneNotificationItem(bool playerWantsToRestore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private SceneNotificationCharacter GetCharacterAtIndex(int index, IOrderedEnumerable<Hero> clanHeroesPool)
	{
		throw null;
	}
}
