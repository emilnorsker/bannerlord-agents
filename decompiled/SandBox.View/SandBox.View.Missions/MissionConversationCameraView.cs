using System.Runtime.CompilerServices;
using SandBox.Conversation.MissionLogics;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace SandBox.View.Missions;

public class MissionConversationCameraView : MissionView
{
	private const string CustomCameraMultiAgentTag = "custom_camera_multi_agent";

	private MissionMainAgentController _missionMainAgentController;

	private ConversationMissionLogic _conversationMissionLogic;

	private Camera _customConversationCamera;

	private GameEntity _customMultiAgentConversationCameraEntity;

	private Agent _speakerAgent;

	private Agent _listenerAgent;

	public bool IsCameraOverridden
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

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
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool UpdateOverridenCamera(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateAgentLooksForConversation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SpeakerAgentIsChanged()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetFocusedObjectForCameraFocus()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeAgentLookToSpeaker(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeSpeakerLookToListener()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetConversationLookToPointOfInterest(Vec3 pointOfInterest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionConversationCameraView()
	{
		throw null;
	}
}
