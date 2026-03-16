using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.Library;

public struct AtmosphereInfo
{
	public uint Seed;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string AtmosphereName;

	public SunInformation SunInfo;

	public RainInformation RainInfo;

	public SnowInformation SnowInfo;

	public AmbientInformation AmbientInfo;

	public FogInformation FogInfo;

	public SkyInformation SkyInfo;

	public NauticalInformation NauticalInfo;

	public TimeInformation TimeInfo;

	public AreaInformation AreaInfo;

	public PostProcessInformation PostProInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string InterpolatedAtmosphereName;

	public bool IsValid
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static AtmosphereInfo GetInvalidAtmosphereInfo()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeserializeFrom(IReader reader)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SerializeTo(IWriter writer)
	{
		throw null;
	}
}
