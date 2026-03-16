using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library.Http;

public static class HttpDriverManager
{
	private static ConcurrentDictionary<string, IHttpDriver> _httpDrivers;

	private static string _defaultHttpDriver;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static HttpDriverManager()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AddHttpDriver(string name, IHttpDriver driver)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetDefault(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IHttpDriver GetHttpDriver(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static IHttpDriver GetDefaultHttpDriver()
	{
		throw null;
	}
}
