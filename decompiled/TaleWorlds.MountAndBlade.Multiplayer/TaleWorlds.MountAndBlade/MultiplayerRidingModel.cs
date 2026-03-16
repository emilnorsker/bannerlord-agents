using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerRidingModel : RidingModel
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override float CalculateAcceleration(in EquipmentElement mountElement, in EquipmentElement harnessElement, int ridingSkill)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerRidingModel()
	{
		throw null;
	}
}
