using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace TaleWorlds.MountAndBlade;

public class DefaultMissionDifficultyModel : MissionDifficultyModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultMissionDifficultyModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDamageMultiplierOfCombatDifficulty(Agent victimAgent, Agent attackerAgent = null)
	{
		throw null;
	}
}
