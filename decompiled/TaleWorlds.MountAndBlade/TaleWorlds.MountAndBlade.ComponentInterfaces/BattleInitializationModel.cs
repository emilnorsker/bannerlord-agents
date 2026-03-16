using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.ComponentInterfaces;

public abstract class BattleInitializationModel : MBGameModel<BattleInitializationModel>
{
	public const int MinimumTroopCountForPlayerDeployment = 20;

	private bool _canPlayerSideDeployWithOOB;

	private bool _isCanPlayerSideDeployWithOOBCached;

	private bool _isInitialized;

	public abstract List<FormationClass> GetAllAvailableTroopTypes();

	protected abstract bool CanPlayerSideDeployWithOrderOfBattleAux();

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CanPlayerSideDeployWithOrderOfBattle()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected BattleInitializationModel()
	{
		throw null;
	}
}
