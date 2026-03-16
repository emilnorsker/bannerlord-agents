using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.SceneInformationPopupTypes;

public class MarriageSceneNotificationItem : SceneNotificationData
{
	private const int NumberOfAudienceHeroes = 6;

	private readonly CampaignTime _creationCampaignTime;

	public Hero GroomHero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Hero BrideHero
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

	public override RelevantContextType RelevantContext
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
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
	public MarriageSceneNotificationItem(Hero groomHero, Hero brideHero, CampaignTime creationTime, RelevantContextType relevantContextType = RelevantContextType.Any)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<Hero> GetAudienceMembers(Hero brideHero, Hero groomHero)
	{
		throw null;
	}
}
