using System.Runtime.CompilerServices;
using TaleWorlds.MountAndBlade;

namespace SandBox.Objects;

public class StealthIndoorLightingArea : VolumeBox
{
	public float AmbientLightStrength;

	public float SunMoonLightStrength;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public StealthIndoorLightingArea()
	{
		throw null;
	}
}
