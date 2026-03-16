using System.Runtime.CompilerServices;
using SandBox.BoardGames.MissionLogics;
using SandBox.ViewModelCollection.BoardGame;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.Source.Missions.Handlers;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;
using TaleWorlds.MountAndBlade.View.MissionViews.Singleplayer;
using TaleWorlds.TwoDimension;

namespace SandBox.GauntletUI.Missions;

[OverrideView(typeof(BoardGameView))]
public class MissionGauntletBoardGameView : MissionView, IBoardGameHandler
{
	private BoardGameVM _dataSource;

	private GauntletLayer _gauntletLayer;

	private GauntletMovieIdentifier _gauntletMovie;

	private GameEntity _cameraHolder;

	private SpriteCategory _spriteCategory;

	private bool _missionMouseVisibilityState;

	private InputUsageMask _missionInputRestrictions;

	public MissionBoardGameLogic _missionBoardGameHandler
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

	public Camera Camera
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
	public MissionGauntletBoardGameView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenActivate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool OnEscape()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBoardGameHandler.Activate()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBoardGameHandler.SwitchTurns()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBoardGameHandler.DiceRoll(int roll)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBoardGameHandler.Install()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IBoardGameHandler.Uninstall()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHotkeyPressedInAnyLayer(string hotkeyID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsHotkeyDownInAnyLayer(string hotkeyID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool IsGameKeyReleasedInAnyLayer(string hotKeyID)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetStaticCamera()
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
	public override void OnPhotoModeActivated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnPhotoModeDeactivated()
	{
		throw null;
	}
}
