using System.Runtime.CompilerServices;
using SandBox.Conversation.MissionLogics;
using SandBox.View.Missions;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.ViewModelCollection.Conversation;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.GauntletUI.Mission;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI.Missions;

[OverrideView(typeof(MissionConversationView))]
public class MissionGauntletConversationView : MissionView, IConversationStateHandler
{
	private MissionConversationVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private MissionConversationCameraView _conversationCameraView;

	private MissionGauntletEscapeMenuBase _escapeView;

	private SpriteCategory _conversationCategory;

	public MissionConversationLogic ConversationHandler
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletConversationView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationInstall()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionModeChange(MissionMode oldMissionMode, bool atStart)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationUninstall()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string GetContinueKeyText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationDeactivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.OnConversationContinue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IConversationStateHandler.ExecuteConversationContinue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsGameKeyReleasedInAnyLayer(string hotKeyID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsReleasedInSceneLayer(string hotKeyID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsReleasedInGauntletLayer(string hotKeyID)
	{
		throw null;
	}
}
