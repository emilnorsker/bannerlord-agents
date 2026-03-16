using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace NavalDLC.ViewModelCollection;

public class NavalTestVM : ViewModel
{
	[DataSourceProperty]
	public string NavalText
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public NavalTestVM()
	{
		throw null;
	}
}
