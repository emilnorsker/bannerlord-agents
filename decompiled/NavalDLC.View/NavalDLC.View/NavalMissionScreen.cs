using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.Screens;

namespace NavalDLC.View;

[GameStateScreen(typeof(NavalMissionState))]
internal class NavalMissionScreen : MissionScreen
{
	private NavalShipsLogic _navalShipsLogic;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMissionScreen(MissionState missionState)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void InitializeMissionView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CanViewCharacter()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CanToggleCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void TeleportMainAgentToCameraFocusForCheat()
	{
		throw null;
	}
}
