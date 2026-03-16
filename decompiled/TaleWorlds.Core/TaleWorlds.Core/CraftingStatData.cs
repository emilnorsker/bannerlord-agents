using System.Runtime.CompilerServices;
using TaleWorlds.Localization;

namespace TaleWorlds.Core;

public struct CraftingStatData
{
	public readonly TextObject DescriptionText;

	public readonly float CurValue;

	public readonly float MaxValue;

	public readonly CraftingTemplate.CraftingStatTypes Type;

	public readonly DamageTypes DamageType;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CraftingStatData(TextObject descriptionText, float curValue, float maxValue, CraftingTemplate.CraftingStatTypes type, DamageTypes damageType = DamageTypes.Invalid)
	{
		throw null;
	}
}
