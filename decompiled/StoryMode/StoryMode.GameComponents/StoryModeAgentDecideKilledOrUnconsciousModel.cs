using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace StoryMode.GameComponents;

public class StoryModeAgentDecideKilledOrUnconsciousModel : AgentDecideKilledOrUnconsciousModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, WeaponFlags weaponFlags, out float useSurgeryProbability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StoryModeAgentDecideKilledOrUnconsciousModel()
	{
		throw null;
	}
}
