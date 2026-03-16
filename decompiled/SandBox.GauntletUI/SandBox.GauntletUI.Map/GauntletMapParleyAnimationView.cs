using System.Runtime.CompilerServices;
using SandBox.View.Map;
using SandBox.View.Map.Visuals;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View;

namespace SandBox.GauntletUI.Map;

[OverrideView(typeof(MapParleyAnimationView))]
public class GauntletMapParleyAnimationView : MapParleyAnimationView
{
	private readonly PartyBase _parleyedParty;

	private CampaignTimeControlMode _previousTimeControlMode;

	private const float _animationDuration = 1f;

	private float _remainingAnimationDuration;

	private readonly IParleyCampaignBehavior _behavior;

	private GameEntity _playerBannerEntity;

	private GameEntity _targetBannerEntity;

	private Vec3 _bannerTargetPosition;

	private MapEntityVisual<PartyBase> _mainPartyVisual;

	private MapEntityVisual<PartyBase> _parleyedPartyVisual;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public GauntletMapParleyAnimationView(PartyBase parleyedParty)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void CreateLayout()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CreateBanners()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GameEntity CreateAnimationBannerEntity(PartyBase party, MapEntityVisual<PartyBase> partyVisual)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RotateBannersTowardsEachother(GameEntity playerBanner, GameEntity targetBanner, Vec3 bannerTargetPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ScaleBanner(GameEntity bannerEntity, Vec3 scaleVector)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DestroyAnimationBannerEntities()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFrameTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnIdleTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Tick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnFinalize()
	{
		throw null;
	}
}
