using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.SaveSystem;

namespace TaleWorlds.CampaignSystem.Issues.IssueQuestTasks;

public class RaidVillageQuestTask : QuestTaskBase
{
	[SaveableField(50)]
	private readonly Village _targetVillage;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public RaidVillageQuestTask(Village village, Action onSucceededAction, Action onFailedAction, Action onCanceledAction, DialogFlow dialogFlow = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnVillageLooted(Village village)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnClanChangedKingdom(Clan clan, Kingdom oldKingdom, Kingdom newKingdom, ChangeKingdomAction.ChangeKingdomActionDetail detail, bool showNotification)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void SetReferences()
	{
		throw null;
	}
}
