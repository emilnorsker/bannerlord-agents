using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.Quest5;

public class Quest5CheckInteriorObjective : MissionObjective
{
	private class CheckInteriorObjectiveTarget : MissionObjectiveTarget<GameEntity>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public CheckInteriorObjectiveTarget(GameEntity target)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override TextObject GetName()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Vec3 GetGlobalPosition()
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool IsActive()
		{
			throw null;
		}
	}

	private readonly GameEntity _interiorSpawnPointEntity;

	private CheckInteriorObjectiveTarget _targetDoor;

	public override string UniqueId
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject Name
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public override TextObject Description
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Quest5CheckInteriorObjective(Mission mission, GameEntity targetDoor, GameEntity interiorSpawnPointEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsActivationRequirementsMet()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool IsCompletionRequirementsMet()
	{
		throw null;
	}
}
