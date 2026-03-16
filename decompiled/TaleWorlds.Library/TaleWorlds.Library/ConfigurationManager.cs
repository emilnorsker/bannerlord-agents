using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public static class ConfigurationManager
{
	private static IConfigurationManager _configurationManager;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetConfigurationManager(IConfigurationManager configurationManager)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetAppSettings(string name)
	{
		throw null;
	}
}
