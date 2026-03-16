using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.GauntletUI.Mission;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.GauntletUI.MissionViews;

[OverrideView(typeof(MissionAgentStatusUIHandler))]
internal class MissionGauntletNavalAgentStatus : MissionGauntletAgentStatus
{
	private NavalShipsLogic _navalShipsLogic;

	private TextObject _selectShipText;

	private TextObject _attemptBoardingText;

	private IShipOrigin _focusedShipOrigin;

	private bool _focusedShipIsEnemy;

	private bool _canSelectShip;

	private bool _canAttemptBoarding;

	private bool _isBoardingBlocked;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateShipInteractionTexts(IShipOrigin origin, bool isEnemy = false, bool canSelectShip = false, bool canAttemptBoarding = false, bool isBoardingBlocked = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionGauntletNavalAgentStatus()
	{
		throw null;
	}
}
