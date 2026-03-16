using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.Quest4;

public class BoardFloatingFortressObjective : MissionObjective
{
	private readonly MissionShip _playerShip;

	private readonly MBList<MissionShip> _enemyShips;

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
	public BoardFloatingFortressObjective(Mission mission, MissionShip playerShip, MBList<MissionShip> enemyShips)
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
