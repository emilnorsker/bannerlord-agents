using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.SceneInformationPopupTypes;

public class EmpireConspiracyBeginsSceneNotificationItem : SceneNotificationData
{
	private const int AudienceNumber = 8;

	private readonly uint[] _audienceColors;

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

	public Kingdom Empire
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public bool IsConspiracyAgainstEmpire
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
	public EmpireConspiracyBeginsSceneNotificationItem(Hero playerHero, Kingdom empire, bool isConspiracyAgainstEmpire)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private CharacterObject GetFacePropertiesFromAudienceIndex(bool playerWantsRestore, int audienceMemberIndex)
	{
		throw null;
	}
}
