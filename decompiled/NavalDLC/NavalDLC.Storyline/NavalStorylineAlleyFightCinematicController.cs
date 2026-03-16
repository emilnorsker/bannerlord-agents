using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.MissionLogics;

namespace NavalDLC.Storyline;

public class NavalStorylineAlleyFightCinematicController : MissionLogic
{
	public enum NavalAlleyFightCinematicState
	{
		Ready,
		InitialFadeOut,
		BlackScreen,
		InitialFadeIn,
		FirstCamera,
		FinalCamera,
		Completed
	}

	private class ConversationLine
	{
		public TextObject Line;

		public CharacterObject Speaker;

		public DialogNotificationHandle Handle;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ConversationLine(TextObject line, CharacterObject speaker)
		{
			throw null;
		}
	}

	private const float CinematicTriggerRadius = 3f;

	private const float FadeDuration = 0.75f;

	private const float BlackScreenDuration = 0.25f;

	private const float FirstCameraDuration = 10f;

	private const int SkipHotKey = 14;

	private bool _isMissionInitialized;

	private List<GameEntity> _entities;

	private GameEntity _currentCameraEntity;

	private GameEntity _cameraEntity;

	private GameEntity _cameraEntity2;

	private GameEntity _cinematicTriggerZone;

	private NavalAlleyFightCinematicState _currentCinematicState;

	private float _cinematicTimer;

	private NavalStorylineAlleyFightMissionController _missionController;

	private MissionHintLogic _missionHintLogic;

	private List<ConversationLine> _allLines;

	private CharacterObject _enemyCharacterObject;

	private bool _isPostFightConversationQueued;

	private float _postFightDialogueFadeTimer;

	private bool _isConversationSetup;

	private const float PostFightDialogueFadeOutDuration = 0.75f;

	private const float PostFightDialogueBlackDuration = 1f;

	private const float PostFightDialogueFadeInDuration = 0.75f;

	private TextObject SkipHintText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public event Action<NavalAlleyFightCinematicState> OnCinematicStateChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<float, float, float> OnFightEndedEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	public event Action<Vec3> OnConversationSetupEvent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateEntityReferences()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void GetCameraFrame(out Vec3 position, out Vec3 forward)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetFadeDuration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public float GetBlackScreenDuration()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetCinematicState(NavalAlleyFightCinematicState newState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TickCinematic(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivatePlayerEavesdropAnimation()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FinishCinematic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HandleSkipCinematic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFightEnded()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ShowSkipCinematicHintText()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnConversationSetup(Vec3 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalStorylineAlleyFightCinematicController()
	{
		throw null;
	}
}
