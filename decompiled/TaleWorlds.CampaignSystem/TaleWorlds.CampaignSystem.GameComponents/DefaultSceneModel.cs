using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Map;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameComponents;

public class DefaultSceneModel : SceneModel
{
	private static readonly TerrainType[] _conversationTerrains;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetBattleSceneForMapPatch(MapPatchData mapPatch, bool isNavalEncounter)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string GetConversationSceneForMapPosition(CampaignVec2 campaignPosition)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static TerrainType GetTerrainByCount(List<TerrainType> terrainTypeSamples, TerrainType currentPositionTerrainType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultSceneModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DefaultSceneModel()
	{
		throw null;
	}
}
