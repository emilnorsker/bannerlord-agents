using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public class DefaultRidingModel : RidingModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateAcceleration(in EquipmentElement mountElement, in EquipmentElement harnessElement, int ridingSkill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultRidingModel()
	{
		throw null;
	}
}
