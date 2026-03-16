using System.Runtime.CompilerServices;
using SandBox.Conversation.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

public class MissionConversationPrepareView : MissionView
{
	public const string BannerTagId = "banner_with_faction_color";

	private ConversationMissionLogic _conversationMissionLogic;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetOwnerBanner(GameEntity bannerEntity, Banner ownerBanner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTextureRendered(Texture tex, GameEntity bannerEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionConversationPrepareView()
	{
		throw null;
	}
}
