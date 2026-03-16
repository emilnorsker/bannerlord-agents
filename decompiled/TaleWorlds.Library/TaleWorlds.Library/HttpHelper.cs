using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaleWorlds.Library;

public static class HttpHelper
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Task<string> DownloadStringTaskAsync(string url)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Task<byte[]> DownloadDataTaskAsync(string url)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Task<string> PostStringAsync(string url, string postData, string mediaType = "application/json")
	{
		throw null;
	}
}
