using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.Core.ViewModelCollection;

public class CraftingItemViewModel : ViewModel
{
	private string _usedPieces;

	private int _weaponClass;

	[DataSourceProperty]
	public string UsedPieces
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
	public int WeaponClass
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
	public WeaponClass GetWeaponClass()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCraftingData(WeaponClass weaponClass, WeaponDesignElement[] craftingPieces)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CraftingItemViewModel()
	{
		throw null;
	}
}
