using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.Library;

public struct PlatformDirectoryPath
{
	public PlatformFileType Type;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string Path;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlatformDirectoryPath(PlatformFileType type, string path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PlatformDirectoryPath operator +(PlatformDirectoryPath path, string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}
}
