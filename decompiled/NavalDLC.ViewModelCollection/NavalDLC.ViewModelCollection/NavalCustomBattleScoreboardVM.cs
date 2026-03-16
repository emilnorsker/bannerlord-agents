using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection;
using TaleWorlds.MountAndBlade.ViewModelCollection.Scoreboard;

namespace NavalDLC.ViewModelCollection;

public class NavalCustomBattleScoreboardVM : CustomBattleScoreboardVM
{
	private class ScoreboardShipComparer : IComparer<SPScoreboardShipVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(SPScoreboardShipVM x, SPScoreboardShipVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int ResolveEquality(SPScoreboardShipVM x, SPScoreboardShipVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ScoreboardShipComparer()
		{
			throw null;
		}
	}

	private NavalShipsLogic _navalShipsLogic;

	private readonly ScoreboardShipComparer _scoreboardShipComparer;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalCustomBattleScoreboardVM()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Initialize(IMissionScreen missionScreen, Mission mission, Action releaseSimulationSources, Action<bool> onToggle)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnDeploymentFinished()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateTeamShips()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<TooltipProperty> GetShipTooltip(SPScoreboardShipVM shipVM)
	{
		throw null;
	}
}
