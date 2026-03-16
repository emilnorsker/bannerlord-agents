using System.Runtime.CompilerServices;
using TaleWorlds.CampaignSystem.Issues;
using TaleWorlds.CampaignSystem.LogEntries;
using TaleWorlds.Core;

namespace TaleWorlds.CampaignSystem.GameState;

public class QuestsState : TaleWorlds.Core.GameState
{
	private IQuestsStateHandler _handler;

	public IssueBase InitialSelectedIssue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public QuestBase InitialSelectedQuest
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public JournalLogEntry InitialSelectedLog
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public override bool IsMenuState
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	public IQuestsStateHandler Handler
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QuestsState()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QuestsState(IssueBase initialSelectedIssue)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QuestsState(QuestBase initialSelectedQuest)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public QuestsState(JournalLogEntry initialSelectedLog)
	{
		throw null;
	}
}
