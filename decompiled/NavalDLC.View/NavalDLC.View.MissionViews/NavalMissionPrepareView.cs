using System.Runtime.CompilerServices;
using NavalDLC.Missions.MissionLogics;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.MissionViews;

namespace NavalDLC.View.MissionViews;

public class NavalMissionPrepareView : MissionView
{
	private NavalShipsLogic _navalShipsLogic;

	private string BannerTag
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnBehaviorInitialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnShipSpawned(MissionShip missionShip)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetSailColors(GameEntity sailEntity, uint sailColor1, uint sailColor2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetOwnerBanner(GameEntity bannerEntity, Banner ownerBanner)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnTextureRendered(Texture tex, GameEntity bannerEntity)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void OnRemoveBehavior()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void StartBannerChangeAnimationForShip(MissionShip ship, MissionShip ship2, Formation formation, Formation formation2)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnCaptureBannerTextureRendered(Texture newTexture, MissionShip ship)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalMissionPrepareView()
	{
		throw null;
	}
}
