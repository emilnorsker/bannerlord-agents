using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View;

internal class MusicNavalBattleMissionView : MissionView, IMusicHandler
{
	private enum BattleState
	{
		Starting,
		Started,
		TurnedOneSide,
		Ending
	}

	private enum NavalBattleThemes
	{
		VikingSeaBattle1 = 10241,
		VikingSeaBattle2,
		MediterraneanSeaBattle1,
		Maintheme,
		MediterraneanSeaBattle2
	}

	private const float ChargeOrderIntensityIncreaseCooldownInSeconds = 60f;

	private const float BattleSizeEffectOnStartIntensity = 0.8f;

	private const string CultureSturgia = "sturgia";

	private const string CultureBattania = "battania";

	private const string CultureNord = "nord";

	private BattleState _battleState;

	private NavalShipsLogic _navalShipsLogic;

	private NavalAgentsLogic _navalAgentsLogic;

	private float _waterStrengthIntensityMultiplier;

	private float _mainAgentBaseHealth;

	private int[] _startingTroopCounts;

	private MissionTime _nextPossibleTimeToIncreaseIntensityForChargeOrder;

	bool IMusicHandler.IsPausable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private MatrixFrame _listenerGlobalFrame
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MusicNavalBattleMissionView()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnMissionScreenFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PlayerOrderControllerOnOrderIssued(OrderType orderType, IEnumerable<Formation> appliedFormations, OrderController orderController, object[] parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckIntensityFall()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentRemoved(Agent affectedAgent, Agent affectorAgent, AgentState agentState, KillingBlow blow)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipSunk(MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipRamming(MissionShip rammingShip, MissionShip rammedShip, float damagePercent, bool isFirstImpact, CapsuleData capsuleData, int ramQuality)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipHookThrow(MissionShip hookingShip, MissionShip hookedShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForStarting()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private NavalBattleThemes GetNavalBattleTheme(BasicCultureObject culture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CheckForEnding()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void IMusicHandler.OnUpdated(float dt)
	{
		throw null;
	}
}
