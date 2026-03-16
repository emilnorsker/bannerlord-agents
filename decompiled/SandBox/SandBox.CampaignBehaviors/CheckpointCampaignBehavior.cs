using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace SandBox.CampaignBehaviors;

public class CheckpointCampaignBehavior : CampaignBehaviorBase
{
	public int LastUsedMissionCheckpointId;

	public List<AgentSaveData> CorpseList;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void RegisterEvents()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SyncData(IDataStore dataStore)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CheckpointCampaignBehavior()
	{
		throw null;
	}
}
