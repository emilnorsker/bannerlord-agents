using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace TaleWorlds.CampaignSystem.SceneInformationPopupTypes;

public class JoinKingdomSceneNotificationItem : SceneNotificationData
{
	private const int NumberOfKingdomMembers = 5;

	private readonly CampaignTime _creationCampaignTime;

	public Clan NewMemberClan
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
	}

	public Kingdom KingdomToUse
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

	public override RelevantContextType RelevantContext
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
	public JoinKingdomSceneNotificationItem(Clan newMember, Kingdom kingdom)
	{
		throw null;
	}
}
