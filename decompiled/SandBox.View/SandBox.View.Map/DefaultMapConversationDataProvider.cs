using System.Runtime.CompilerServices;

namespace SandBox.View.Map;

public class DefaultMapConversationDataProvider : IMapConversationDataProvider
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	string IMapConversationDataProvider.GetAtmosphereNameFromData(MapConversationTableauData data)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string GetLocationNameFromLocationId(string locationId, out bool isLocationInside)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DefaultMapConversationDataProvider()
	{
		throw null;
	}
}
