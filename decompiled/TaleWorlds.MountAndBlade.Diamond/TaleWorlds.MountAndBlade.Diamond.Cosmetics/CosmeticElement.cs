using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.Diamond.Cosmetics;

public class CosmeticElement
{
	public int UsageIndex;

	public string Id;

	public CosmeticsManager.CosmeticRarity Rarity;

	public int Cost;

	public CosmeticsManager.CosmeticType Type;

	public bool IsFree
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CosmeticElement(string id, CosmeticsManager.CosmeticRarity rarity, int cost, CosmeticsManager.CosmeticType type)
	{
		throw null;
	}
}
