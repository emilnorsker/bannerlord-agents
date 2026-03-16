using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond;

[Serializable]
public class MultipleBattleResult
{
	private int _currentBattleIndex;

	public List<BattleResult> BattleResults
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultipleBattleResult()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CreateNewBattleResult(string gameType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BattleResult GetCurrentBattleResult()
	{
		throw null;
	}
}
