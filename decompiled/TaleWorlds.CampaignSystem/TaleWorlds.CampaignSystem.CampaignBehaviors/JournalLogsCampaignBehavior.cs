using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.CampaignBehaviors;

public class JournalLogsCampaignBehavior : CampaignBehaviorBase
{
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
	private void OnIssueLogAdded(IssueBase issue, bool hideInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestLogAdded(QuestBase quest, bool hideInformation)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestStarted(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnQuestCompleted(QuestBase quest, QuestBase.QuestCompleteDetails detail)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OnIssueUpdated(IssueBase issue, IssueBase.IssueUpdateDetails details, Hero issueSolver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private JournalLogEntry CreateRelatedLog(IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private JournalLogEntry CreateRelatedLog(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private JournalLogEntry GetRelatedLog(IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private JournalLogEntry GetRelatedLog(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBReadOnlyList<JournalLog> GetEntries(IssueBase issue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private MBReadOnlyList<JournalLog> GetEntries(QuestBase quest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JournalLogsCampaignBehavior()
	{
		throw null;
	}
}
