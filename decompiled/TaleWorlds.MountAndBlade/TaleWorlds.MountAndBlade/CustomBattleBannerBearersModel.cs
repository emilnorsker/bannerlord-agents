using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade.ComponentInterfaces;

namespace TaleWorlds.MountAndBlade;

public class CustomBattleBannerBearersModel : BattleBannerBearersModel
{
	private static readonly int[] BannerBearerPriorityPerTier;

	private static List<ItemObject> ReplacementWeapons;

	private static MissionAgentSpawnLogic _missionSpawnLogic;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetMinimumFormationTroopCountToBearBanners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float GetBannerInteractionDistance(Agent interactingAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanBannerBearerProvideEffectToFormation(Agent agent, Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanAgentPickUpAnyBanner(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanAgentBecomeBannerBearer(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetAgentBannerBearingPriority(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override bool CanFormationDeployBannerBearers(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override int GetDesiredNumberOfBannerBearersForFormation(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override ItemObject GetBannerBearerReplacementWeapon(BasicCharacterObject agentCharacter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomBattleBannerBearersModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CustomBattleBannerBearersModel()
	{
		throw null;
	}
}
