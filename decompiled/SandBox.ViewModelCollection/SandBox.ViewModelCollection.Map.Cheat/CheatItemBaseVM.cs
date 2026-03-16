using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace SandBox.ViewModelCollection.Map.Cheat;

public abstract class CheatItemBaseVM : ViewModel
{
	private string _name;

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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CheatItemBaseVM()
	{
		throw null;
	}

	public abstract void ExecuteAction();
}
