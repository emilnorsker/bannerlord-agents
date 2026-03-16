using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Objects;
using TaleWorlds.MountAndBlade.Objects.Usables;

namespace SandBox.Missions;

public class EavesdroppingMissionLogic : MissionLogic
{
	public class EavesdropSound
	{
		public TextObject Line;

		public int Priority;

		public CharacterObject Character;

		public string SoundPath;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EavesdropSound(TextObject line, int priority, CharacterObject character, string soundPath)
		{
			throw null;
		}
	}

	private const string EavesdroppingPointTag = "eavesdropping_point";

	private const string CustomCameraTag = "customcamera";

	private const string StartEavesdroppingEventId = "start_eavesdropping";

	private readonly Dictionary<EventTriggeringUsableMachine, Camera> _eavesdroppingPoints;

	private readonly Queue<EavesdropSound> _eavesdropSoundQueue;

	private SoundEvent _currentSoundEvent;

	private Timer _waitTimer;

	public bool EavesdropStarted;

	public Camera CurrentEavesdroppingCamera;

	private EventTriggeringUsableMachine _currentEventTriggeringUsableMachine;

	private readonly CharacterObject _disguiseShadowingTargetCharacter;

	private readonly CharacterObject _disguiseOfficerCharacter;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public EavesdroppingMissionLogic(CharacterObject disguiseShadowingTargetCharacter, CharacterObject disguiseOfficerCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEndMission()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnGenericMissionEventTriggered(GenericMissionEvent missionEvent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void StartEavesdropping(EventTriggeringUsableMachine eventTriggeringUsableMachine)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}
}
