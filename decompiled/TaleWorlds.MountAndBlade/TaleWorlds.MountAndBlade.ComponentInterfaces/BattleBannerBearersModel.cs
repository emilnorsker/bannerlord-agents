using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.ComponentInterfaces;

public abstract class BattleBannerBearersModel : MBGameModel<BattleBannerBearersModel>
{
	public const float DefaultDetachmentCostMultiplier = 10f;

	private BannerBearerLogic _bannerBearerLogic;

	protected BannerBearerLogic BannerBearerLogic
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InitializeModel(BannerBearerLogic bannerBearerLogic)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void FinalizeModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsFormationBanner(Formation formation, SpawnedItemEntity item)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsBannerSearchingAgent(Agent agent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool IsInteractableFormationBanner(SpawnedItemEntity item, Agent interactingAgent)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasFormationBanner(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HasBannerOnGround(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ItemObject GetFormationBanner(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<Agent> GetFormationBannerBearers(Formation formation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BannerComponent GetActiveBanner(Formation formation)
	{
		throw null;
	}

	public abstract int GetMinimumFormationTroopCountToBearBanners();

	public abstract float GetBannerInteractionDistance(Agent interactingAgent);

	public abstract bool CanBannerBearerProvideEffectToFormation(Agent agent, Formation formation);

	public abstract bool CanAgentPickUpAnyBanner(Agent agent);

	public abstract bool CanAgentBecomeBannerBearer(Agent agent);

	public abstract int GetAgentBannerBearingPriority(Agent agent);

	public abstract bool CanFormationDeployBannerBearers(Formation formation);

	public abstract int GetDesiredNumberOfBannerBearersForFormation(Formation formation);

	public abstract ItemObject GetBannerBearerReplacementWeapon(BasicCharacterObject agentCharacter);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected BattleBannerBearersModel()
	{
		throw null;
	}
}
