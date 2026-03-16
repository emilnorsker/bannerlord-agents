using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerBattleInitializationModel : BattleInitializationModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<FormationClass> GetAllAvailableTroopTypes()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool CanPlayerSideDeployWithOrderOfBattleAux()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerBattleInitializationModel()
	{
		throw null;
	}
}
