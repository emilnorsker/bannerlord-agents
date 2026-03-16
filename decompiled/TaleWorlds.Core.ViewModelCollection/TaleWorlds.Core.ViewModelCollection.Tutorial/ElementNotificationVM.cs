using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core.ViewModelCollection.Tutorial;

public class ElementNotificationVM : ViewModel
{
	private string _elementID;

	[DataSourceProperty]
	public string ElementID
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
	public ElementNotificationVM()
	{
		throw null;
	}
}
