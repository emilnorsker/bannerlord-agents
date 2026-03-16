using System;
using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Map.MapNotificationTypes;

public class QuestNotificationItemVM : MapNotificationItemBaseVM
{
	private QuestBase _quest;

	private IssueBase _issue;

	private Action<QuestBase> _onQuestNotificationInspect;

	private Action<IssueBase> _onIssueNotificationInspect;

	protected Action _onInspectAction;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QuestNotificationItemVM(QuestBase quest, InformationData data, Action<QuestBase> onQuestNotificationInspect, Action<MapNotificationItemBaseVM> onRemove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QuestNotificationItemVM(IssueBase issue, InformationData data, Action<IssueBase> onIssueNotificationInspect, Action<MapNotificationItemBaseVM> onRemove)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void ManualRefreshRelevantStatus()
	{
		throw null;
	}
}
