using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.ViewModelCollection.Quests;
using TaleWorlds.Engine;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace SandBox.ViewModelCollection.Missions.NameMarker.Targets;

public class MissionAgentMarkerTargetVM : MissionNameMarkerTargetVM<Agent>
{
	private class QuestMarkerComparer : IComparer<QuestMarkerVM>
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public int Compare(QuestMarkerVM x, QuestMarkerVM y)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public QuestMarkerComparer()
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MissionAgentMarkerTargetVM(Agent target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void UpdatePosition(Camera missionCamera)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override TextObject GetName()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateQuestStatus()
	{
		throw null;
	}
}
