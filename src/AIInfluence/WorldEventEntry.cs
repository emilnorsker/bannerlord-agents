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
				((ViewModel)this).OnPropertyChanged("Title");
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
				((ViewModel)this).OnPropertyChanged("Category");
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
				((ViewModel)this).OnPropertyChanged("CategoryColor");
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
				((ViewModel)this).OnPropertyChanged("DeclarationContent");
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
				((ViewModel)this).OnPropertyChanged("IssuedTime");
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
				((ViewModel)this).OnPropertyChanged("InvolvedFactions");
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
				((ViewModel)this).OnPropertyChanged("LocationHint");
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
				((ViewModel)this).OnPropertyChanged("Faction1Name");
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
				((ViewModel)this).OnPropertyChanged("Faction2Name");
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
				((ViewModel)this).OnPropertyChanged("EntryOrder");
			}
		}
	}
}
