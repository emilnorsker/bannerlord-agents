using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.Library;

public static class FileHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveResult SaveFile(PlatformFilePath path, byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveResult SaveFileString(PlatformFilePath path, string data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetFileFullPath(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static SaveResult AppendLineToFileString(PlatformFilePath path, string data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Task<SaveResult> SaveFileAsync(PlatformFilePath path, byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Task<SaveResult> SaveFileStringAsync(PlatformFilePath path, string data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetError()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool FileExists(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Task<string> GetFileContentStringAsync(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetFileContentString(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DeleteFile(PlatformFilePath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static PlatformFilePath[] GetFiles(PlatformDirectoryPath path, string searchPattern, SearchOption searchOption)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] GetFileContent(PlatformFilePath filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] GetMetaDataContent(PlatformFilePath filePath)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CopyFile(PlatformFilePath source, PlatformFilePath target)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
	{
		throw null;
	}
}
