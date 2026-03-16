using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade.Missions.Objectives;

namespace NavalDLC.Storyline.Objectives.Quest3;

internal class ShipObjectiveTarget : MissionObjectiveTarget
{
	private readonly MissionShip _ship;

	private readonly TextObject _name;

	private readonly bool _showController;

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal ShipObjectiveTarget(MissionShip ship, TextObject name, bool showController = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Vec3 GetGlobalPosition()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override TextObject GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool IsActive()
	{
		throw null;
	}
}
