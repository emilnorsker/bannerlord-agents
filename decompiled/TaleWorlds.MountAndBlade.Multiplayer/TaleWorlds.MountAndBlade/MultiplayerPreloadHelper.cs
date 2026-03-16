using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade;

public class MultiplayerPreloadHelper : MissionNetwork
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public override List<EquipmentElement> GetExtraEquipmentElementsForCharacter(BasicCharacterObject character, bool getAllEquipments = false)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MultiplayerPreloadHelper()
	{
		throw null;
	}
}
