using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SandBox.Objects.AreaMarkers;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;

namespace SandBox.Missions.AgentBehaviors;

public class NotableSpawnPointHandler : MissionLogic
{
	private int _merchantNotableCount;

	private int _gangLeaderNotableCount;

	private int _preacherNotableCount;

	private int _artisanNotableCount;

	private int _ruralNotableCount;

	private GameEntity _currentMerchantSetGameEntity;

	private GameEntity _currentPreacherSetGameEntity;

	private GameEntity _currentGangLeaderSetGameEntity;

	private GameEntity _currentArtisanSetGameEntity;

	private GameEntity _currentRuralNotableSetGameEntity;

	private List<Hero> _workshopAssignedHeroes;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FindAndSetChild(GameEntity childGameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateParentSetInsideWorkshop(WorkshopAreaMarker areaMarker)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ActivateParentSetOutsideWorkshop()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeactivateAll()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DeactivateAllExcept(GameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MakeInvisibleAndDeactivate(GameEntity gameEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NotableSpawnPointHandler()
	{
		throw null;
	}
}
