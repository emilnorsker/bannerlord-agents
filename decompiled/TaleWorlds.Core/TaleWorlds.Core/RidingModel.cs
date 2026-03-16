using System.Runtime.CompilerServices;

namespace TaleWorlds.Core;

public abstract class RidingModel : MBGameModel<RidingModel>
{
	public abstract float CalculateAcceleration(in EquipmentElement mountElement, in EquipmentElement harnessElement, int ridingSkill);

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected RidingModel()
	{
		throw null;
	}
}
