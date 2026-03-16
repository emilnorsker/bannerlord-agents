using System.Runtime.CompilerServices;
using TaleWorlds.Engine;

namespace TaleWorlds.MountAndBlade.MissionRepresentatives;

public class SiegeMissionRepresentative : MissionRepresentativeBase
{
	private const int FirstRangedKillGold = 10;

	private const int FirstMeleeKillGold = 10;

	private const int FirstAssistGold = 10;

	private const int SecondAssistGold = 10;

	private const int ThirdAssistGold = 10;

	private const int FifthKillGold = 20;

	private const int TenthKillGold = 30;

	private GoldGainFlags _currentGoldGains;

	private int _killCountOnSpawn;

	private int _assistCountOnSpawn;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnAgentSpawned()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGoldGainsFromKillDataAndUpdateFlags(MPPerkObject.MPPerkHandler killerPerkHandler, MPPerkObject.MPPerkHandler assistingHitterPerkHandler, MultiplayerClassDivisions.MPHeroClass victimClass, bool isAssist, bool isRanged, bool isFriendly)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGoldGainsFromObjectiveAssist(GameEntity objectiveMostParentEntity, float contributionRatio, bool isCompleted)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int GetGoldGainsFromAllyDeathReward(int baseAmount)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int GetTotalGoldDistributionForDestructable(GameEntity objectiveMostParentEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SiegeMissionRepresentative()
	{
		throw null;
	}
}
