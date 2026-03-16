using System.Runtime.CompilerServices;
using TaleWorlds.Core;

namespace TaleWorlds.MountAndBlade.ComponentInterfaces;

public abstract class ApplyWeatherEffectsModel : MBGameModel<ApplyWeatherEffectsModel>
{
	public abstract void ApplyWeatherEffects();

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ApplyWeatherEffectsModel()
	{
		throw null;
	}
}
