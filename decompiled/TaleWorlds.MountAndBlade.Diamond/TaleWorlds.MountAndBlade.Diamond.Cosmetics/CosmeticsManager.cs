using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.Diamond.Cosmetics;

public static class CosmeticsManager
{
	public enum CosmeticRarity
	{
		Default,
		Common,
		Rare,
		Unique
	}

	public enum CosmeticType
	{
		Clothing,
		Frame,
		Sigil,
		Taunt
	}

	private static MBReadOnlyList<CosmeticElement> _cosmeticElementList;

	private static Dictionary<string, CosmeticElement> _cosmeticElementsLookup;

	public static MBReadOnlyList<CosmeticElement> CosmeticElementsList
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static CosmeticsManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static CosmeticElement GetCosmeticElement(string cosmeticId)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LoadFromXml(string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool CheckForCosmeticsListDuplicatesDebug()
	{
		throw null;
	}
}
