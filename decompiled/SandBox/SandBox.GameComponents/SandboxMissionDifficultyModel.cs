using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace SandBox.GameComponents;

public class SandboxMissionDifficultyModel : MissionDifficultyModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetDamageMultiplierOfCombatDifficulty(Agent victimAgent, Agent attackerAgent = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SandboxMissionDifficultyModel()
	{
		throw null;
	}
}
