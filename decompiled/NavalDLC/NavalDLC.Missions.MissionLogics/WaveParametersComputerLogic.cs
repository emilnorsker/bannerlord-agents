using System.Runtime.CompilerServices;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace NavalDLC.Missions.MissionLogics;

public class WaveParametersComputerLogic : MissionLogic
{
	public struct WaterParameters
	{
		public float Amplitude;

		public float Wavelength;

		public float WaveNumber;

		public float Omega;

		public float WaveMax;

		public float WaveMin;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public WaveParametersComputerLogic()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static WaterParameters AnalyzeHeightMap(Vec2 waveDirection, Scene scene)
	{
		throw null;
	}
}
