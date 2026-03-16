using System.IO;
using System.Runtime.CompilerServices;

namespace psai.net;

internal class PlatformLayerStandalone : IPlatformLayer
{
	private Logik m_logik;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlatformLayerStandalone(Logik logik)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Initialize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Release()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string ConvertFilePathForPlatform(string filepath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Stream GetStreamOnPsaiSoundtrackFile(string filepath)
	{
		throw null;
	}
}
