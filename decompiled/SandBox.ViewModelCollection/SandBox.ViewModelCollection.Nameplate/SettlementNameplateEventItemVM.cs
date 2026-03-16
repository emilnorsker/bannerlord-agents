using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.Nameplate;

public class SettlementNameplateEventItemVM : ViewModel
{
	public enum SettlementEventType
	{
		Tournament,
		AvailableIssue,
		ActiveQuest,
		ActiveStoryQuest,
		TrackedIssue,
		TrackedStoryQuest,
		Production
	}

	public readonly SettlementEventType EventType;

	private int _type;

	private string _additionalParameters;

	[DataSourceProperty]
	public int Type
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

	[DataSourceProperty]
	public string AdditionalParameters
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
	public SettlementNameplateEventItemVM(SettlementEventType eventType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public SettlementNameplateEventItemVM(string productionIconId = "")
	{
		throw null;
	}
}
