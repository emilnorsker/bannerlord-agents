using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.SceneInformationPopupTypes;

public class MainHeroBattleVictoryDeathNotificationItem : SceneNotificationData
{
	private const int NumberOfCorpses = 2;

	private const int NumberOfCompanions = 3;

	private readonly CampaignTime _creationCampaignTime;

	public Hero DeadHero
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public List<CharacterObject> EncounterAllyCharacters
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
	public override SceneNotificationCharacter[] GetSceneNotificationCharacters()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MainHeroBattleVictoryDeathNotificationItem(Hero deadHero, List<CharacterObject> encounterAllyCharacters)
	{
		throw null;
	}
}
