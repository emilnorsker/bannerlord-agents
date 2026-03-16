using System.IO.Compression;
using System.Runtime.CompilerServices;
using TaleWorlds.Library;

namespace TaleWorlds.SaveSystem;

internal static class ZipExtensions
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FillFrom(this ZipArchiveEntry entry, byte[] data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FillFrom(this ZipArchiveEntry entry, BinaryWriter writer)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static BinaryReader GetBinaryReader(this ZipArchiveEntry entry)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static byte[] GetBinaryData(this ZipArchiveEntry entry)
	{
		throw null;
	}
}
