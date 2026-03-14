using TaleWorlds.Library;

namespace AIInfluence;

public class WorldEventEntry : ViewModel
{
	private string _title;

	private string _category;

	private string _declarationContent;

	private string _issuedTime;

	private string _involvedFactions;

	private string _locationHint;

	private string _faction1Name;

	private string _faction2Name;

	private float _sortOrder;

	private long _entryOrder;

	private string _categoryColor;

	[DataSourceProperty]
	public string Title
	{
		get
		{
			return _title;
		}
		set
		{
			if (value != _title)
			{
				_title = value;
				base.OnPropertyChanged("Title");
			}
		}
	}

	[DataSourceProperty]
	public string Category
	{
		get
		{
			return _category;
		}
		set
		{
			if (value != _category)
			{
				_category = value;
				base.OnPropertyChanged("Category");
			}
		}
	}

	[DataSourceProperty]
	public string CategoryColor
	{
		get
		{
			return _categoryColor;
		}
		set
		{
			if (value != _categoryColor)
			{
				_categoryColor = value;
				base.OnPropertyChanged("CategoryColor");
			}
		}
	}

	[DataSourceProperty]
	public string DeclarationContent
	{
		get
		{
			return _declarationContent;
		}
		set
		{
			if (value != _declarationContent)
			{
				_declarationContent = value;
				base.OnPropertyChanged("DeclarationContent");
			}
		}
	}

	[DataSourceProperty]
	public string IssuedTime
	{
		get
		{
			return _issuedTime;
		}
		set
		{
			if (value != _issuedTime)
			{
				_issuedTime = value;
				base.OnPropertyChanged("IssuedTime");
			}
		}
	}

	[DataSourceProperty]
	public string InvolvedFactions
	{
		get
		{
			return _involvedFactions;
		}
		set
		{
			if (value != _involvedFactions)
			{
				_involvedFactions = value;
				base.OnPropertyChanged("InvolvedFactions");
			}
		}
	}

	[DataSourceProperty]
	public string LocationHint
	{
		get
		{
			return _locationHint;
		}
		set
		{
			if (value != _locationHint)
			{
				_locationHint = value;
				base.OnPropertyChanged("LocationHint");
			}
		}
	}

	[DataSourceProperty]
	public string Faction1Name
	{
		get
		{
			return _faction1Name;
		}
		set
		{
			if (value != _faction1Name)
			{
				_faction1Name = value;
				base.OnPropertyChanged("Faction1Name");
			}
		}
	}

	[DataSourceProperty]
	public string Faction2Name
	{
		get
		{
			return _faction2Name;
		}
		set
		{
			if (value != _faction2Name)
			{
				_faction2Name = value;
				base.OnPropertyChanged("Faction2Name");
			}
		}
	}

	public float SortOrder
	{
		get
		{
			return _sortOrder;
		}
		set
		{
			_sortOrder = value;
		}
	}

	public long EntryOrder
	{
		get
		{
			return _entryOrder;
		}
		set
		{
			if (value != _entryOrder)
			{
				_entryOrder = value;
				base.OnPropertyChanged("EntryOrder");
			}
		}
	}
}
