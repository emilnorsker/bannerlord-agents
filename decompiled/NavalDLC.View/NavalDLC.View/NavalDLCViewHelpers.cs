using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using NavalDLC.View.Map.Visuals;
using TaleWorlds.CampaignSystem.Naval;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace NavalDLC.View;

public class NavalDLCViewHelpers
{
	public static class ShipVisualHelper
	{
		private const string BannerTag = "banner_with_faction_color";

		private const float AnimationSpeedMultiplier = 0.1f;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static GameEntity GetFlagshipEntity(PartyBase party, Scene scene)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static GameEntity GetShipEntity(Ship ship, Scene scene, List<ShipVisualSlotInfo> selectedPieces, bool createPhysics = false)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static GameEntity GetShipEntityForCampaign(Ship ship, Scene scene, List<ShipVisualSlotInfo> selectedPieces)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void CollectSailVisuals(WeakGameEntity shipEntity, List<SailVisual> sailVisuals)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void FoldSails(List<SailVisual> sailVisuals)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void UnfoldSails(List<SailVisual> sailVisuals)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void RefreshShipVisuals(WeakGameEntity shipEntity, Ship ship, List<SailVisual> sailVisuals)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void RefreshShipVisuals(GameEntity shipEntity, List<ShipVisualSlotInfo> selectedPieces, uint sailColor1, uint sailColor2, Banner banner, float healthPercent)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void UpdateBanner(Banner banner, List<SailVisual> sailVisuals)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void SetBanner(GameEntity bannerEntity, Banner banner, bool isUpdated = false)
		{
			throw null;
		}
	}

	public static class BannerVisualHelper
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MetaMesh GetBannerOfCharacter(Banner banner, string bannerMeshName)
		{
			throw null;
		}
	}

	public static class BlockadeVisualHelper
	{
		private const float AnimationSpeedMultiplier = 0.1f;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<Vec3> GetPositionsOnBlockadeArc(Settlement settlement, int numberOfArcs, int numberOfPositions, float angle, float distanceBetweenArcs)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void AddBlockadeVisuals(Dictionary<Ship, NavalMobilePartyVisual.BlockadeShipVisual> shipToBlockadeShipVisualCache, PartyBase party, GameEntity strategicEntity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static NavalMobilePartyVisual.BlockadeShipVisual CreateBlockadeShipVisual(GameEntity shipEntity)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void InitializeBlockadeVisual(Vec3 position, GameEntity shipEntity, Vec3 centerOfArc)
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalDLCViewHelpers()
	{
		throw null;
	}
}
