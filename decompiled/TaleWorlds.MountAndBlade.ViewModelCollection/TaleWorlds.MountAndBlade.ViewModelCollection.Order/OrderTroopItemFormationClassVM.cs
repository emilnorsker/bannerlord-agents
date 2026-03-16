using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.ViewModelCollection.Order;

public class OrderTroopItemFormationClassVM : ViewModel
{
	public readonly FormationClass FormationClass;

	private readonly Formation _formation;

	private int _formationClassValue;

	private int _troopCount;

	[DataSourceProperty]
	public int FormationClassValue
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
	public int TroopCount
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
	public OrderTroopItemFormationClassVM(Formation formation, FormationClass formationClass)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void UpdateTroopCount()
	{
		throw null;
	}
}
