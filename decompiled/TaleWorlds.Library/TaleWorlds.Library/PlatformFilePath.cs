using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TaleWorlds.Library;

public struct PlatformFilePath
{
	public PlatformDirectoryPath FolderPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string FileName;

	public string FileFullPath
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public PlatformFilePath(PlatformDirectoryPath folderPath, string fileName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PlatformFilePath operator +(PlatformFilePath path, string str)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string GetFileNameWithoutExtension()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override string ToString()
	{
		throw null;
	}
}
