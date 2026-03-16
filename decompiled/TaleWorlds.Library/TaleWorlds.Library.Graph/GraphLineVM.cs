using System.Runtime.CompilerServices;

namespace TaleWorlds.Library.Graph;

public class GraphLineVM : ViewModel
{
	private MBBindingList<GraphLinePointVM> _points;

	private string _name;

	private string _ID;

	[DataSourceProperty]
	public MBBindingList<GraphLinePointVM> Points
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
	public string Name
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
	public string ID
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
	public GraphLineVM(string ID, string name)
	{
		throw null;
	}
}
