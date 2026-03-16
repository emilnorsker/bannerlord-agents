using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;

namespace Helpers;

public static class NavigationHelper
{
	public class EmbarkDisembarkData
	{
		public static readonly EmbarkDisembarkData Invalid;

		public bool IsValidTransition;

		public CampaignVec2 NavMeshEdgePosition;

		public CampaignVec2 TransitionStartPosition;

		public CampaignVec2 TransitionEndPosition;

		public bool IsTargetingTheDeadZone;

		public bool IsTargetingOwnSideOfTheDeadZone;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public EmbarkDisembarkData(bool isValid, CampaignVec2 navMeshEdgePosition, CampaignVec2 transitionStartPosition, CampaignVec2 transitionEndPosition, bool isTargetingTheDeadZone, bool isTargetingOwnSideOfTheDeadZone)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static EmbarkDisembarkData()
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsPositionValidForNavigationType(CampaignVec2 vec2, MobileParty.NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsPositionValidForNavigationType(PathFaceRecord face, MobileParty.NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CanPlayerNavigateToPosition(CampaignVec2 vec2, out MobileParty.NavigationType navigationType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignVec2 GetClosestNavMeshFaceCenterPositionForPosition(CampaignVec2 vec2, int[] excludedFaceIds)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static EmbarkDisembarkData GetEmbarkDisembarkDataForTick(CampaignVec2 position, Vec2 direction)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static EmbarkDisembarkData GetEmbarkAndDisembarkDataForPlayer(CampaignVec2 position, Vec2 direction, CampaignVec2 moveTargetPointOfTheParty, bool isMoveTargetOnLand)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void CalculateTransitionStartAndEndPosition(CampaignVec2 position, Vec2 direction, out CampaignVec2 transitionStartPosition, out CampaignVec2 transitionEndPosition, out Vec2 originalEdge)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignVec2 FindPointAroundPosition(CampaignVec2 centerPosition, MobileParty.NavigationType navigationCapability, float maxDistance, float minDistance = 0f, bool requirePath = true, bool useUniformDistribution = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignVec2 FindReachablePointAroundPosition(CampaignVec2 center, int[] excludedFaceIds, float maxDistance, float minDistance = 0f, bool useUniformDistribution = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignVec2 FindReachablePointAroundPosition(CampaignVec2 center, MobileParty.NavigationType navigationCapability, float maxDistance, float minDistance = 0f, bool useUniformDistribution = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignVec2 FindPointInsideArea(Vec2 minBorder, Vec2 maxBorder, MobileParty.NavigationType navigationCapability)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsPointInsideBorders(Vec2 point, Vec2 minBorders, Vec2 maxBorders)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CampaignVec2 FindPointInsideArea(Vec2 minBorders, Vec2 maxBorders, CampaignVec2 center, MobileParty.NavigationType navigationCapability, float maxDistance, float minDistance = 0f, bool requirePathFromCenter = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static CampaignVec2 FindPointInCircle(CampaignVec2 center, float min, float max, bool useUniformDistribution)
	{
		throw null;
	}
}
