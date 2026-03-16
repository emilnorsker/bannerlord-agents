using System.Runtime.CompilerServices;

namespace TaleWorlds.MountAndBlade.CustomBattle.CustomBattle;

public struct CustomBattleCompositionData
{
	public readonly bool IsValid;

	public readonly float RangedPercentage;

	public readonly float CavalryPercentage;

	public readonly float RangedCavalryPercentage;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CustomBattleCompositionData(float rangedPercentage, float cavalryPercentage, float rangedCavalryPercentage)
	{
		throw null;
	}
}
