using System.Runtime.CompilerServices;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade.Diamond;
using TaleWorlds.MountAndBlade.Multiplayer.ViewModelCollection;
using TaleWorlds.PlayerServices;
using TaleWorlds.ScreenSystem;

namespace TaleWorlds.MountAndBlade.Multiplayer.GauntletUI;

public class MultiplayerReportPlayerScreen : GlobalLayer
{
	private MultiplayerReportPlayerVM _dataSource;

	private GauntletMovieIdentifier _movie;

	private bool _isActive;

	public static MultiplayerReportPlayerScreen Current
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
	public MultiplayerReportPlayerScreen()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnClose()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnReportRequest(string gameId, PlayerId playerId, string playerName, bool isRequestedFromMission)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnReportDone(string gameId, PlayerId playerId, string playerName, PlayerReportType reportReason, string reasonText)
	{
		throw null;
	}
}
