using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.MissionRepresentatives;

public class FlagDominationMissionRepresentative : MissionRepresentativeBase
{
	private bool _survivedLastRound;

	private bool Forfeited
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGoldAmountForVisual()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateSelectedClassServer(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool CheckIfSurvivedLastRoundAndReset()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGoldGainsFromKillData(MPPerkObject.MPPerkHandler killerPerkHandler, MPPerkObject.MPPerkHandler assistingHitterPerkHandler, MultiplayerClassDivisions.MPHeroClass victimClass, bool isAssist, bool isFriendly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGoldGainFromKillDataAndUpdateFlags(MultiplayerClassDivisions.MPHeroClass victimClass, bool isAssist)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGoldGainsFromAllyDeathReward(int baseAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public FlagDominationMissionRepresentative()
	{
		throw null;
	}
}
