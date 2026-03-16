using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.CampaignSystem.ViewModelCollection.Quests;

public class QuestItemSortControllerVM : ViewModel
{
	public enum QuestItemSortOption
	{
		DateStarted,
		LastUpdated,
		TimeDue
	}

	private abstract class QuestItemComparerBase : IComparer<QuestItemVM>
	{
		protected enum JournalLogIndex
		{
			First,
			Last
		}

		public abstract int Compare(QuestItemVM x, QuestItemVM y);

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected JournalLog GetJournalLogAt(QuestItemVM questItem, JournalLogIndex logIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected QuestItemComparerBase()
		{
			throw null;
		}
	}

	private class QuestItemDateStartedComparer : QuestItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(QuestItemVM first, QuestItemVM second)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public QuestItemDateStartedComparer()
		{
			throw null;
		}
	}

	private class QuestItemLastUpdatedComparer : QuestItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(QuestItemVM first, QuestItemVM second)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public QuestItemLastUpdatedComparer()
		{
			throw null;
		}
	}

	private class QuestItemTimeDueComparer : QuestItemComparerBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public override int Compare(QuestItemVM first, QuestItemVM second)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public QuestItemTimeDueComparer()
		{
			throw null;
		}
	}

	private MBBindingList<QuestItemVM> _listToControl;

	private QuestItemDateStartedComparer _dateStartedComparer;

	private QuestItemLastUpdatedComparer _lastUpdatedComparer;

	private QuestItemTimeDueComparer _timeDueComparer;

	private bool _isThereAnyQuest;

	public QuestItemSortOption? CurrentSortOption
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

	[DataSourceProperty]
	public bool IsThereAnyQuest
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
	public QuestItemSortControllerVM(ref MBBindingList<QuestItemVM> listToControl)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByDateStarted()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByLastUpdated()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ExecuteSortByTimeDue()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SortByOption(QuestItemSortOption sortOption)
	{
		throw null;
	}
}
