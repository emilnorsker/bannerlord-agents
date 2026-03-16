using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Objects.AreaMarkers;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Workshops;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.MissionLogics.Towns;

public class WorkshopMissionHandler : MissionLogic
{
	private Settlement _settlement;

	private string[] _propKinds;

	private Dictionary<int, Dictionary<string, List<MatrixFrame>>> _propFrames;

	private List<GameEntity> _listOfCurrentProps;

	private List<WorkshopAreaMarker> _areaMarkers;

	private List<Tuple<Workshop, GameEntity>> _workshopSignEntities;

	public IEnumerable<Tuple<Workshop, GameEntity>> WorkshopSignEntities
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WorkshopMissionHandler(Settlement settlement)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void EarlyStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void AfterStart()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private WorkshopAreaMarker FindWorkshop(GameEntity prop)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetBenches()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void InitShopSigns()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private List<string> GetPrefabNames(int areaIndex, string propKind)
	{
		throw null;
	}
}
